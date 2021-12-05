using System;
using System.Text;
using System.Collections;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Provides the APIs for managing user in a persistence store.
    /// </summary>
    public class IdentityProvider : IIdentityProvider
    {
        private readonly UserStore _userStore;
        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider"/> class.
        /// </summary>
        public IdentityProvider()
            : this(new UserStore(), new PasswordHasher())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider"/> class.
        /// </summary>
        /// <param name="userStore">The password hashing implementation to use when saving passwords.</param>
        /// <param name="passwordHasher">The persistence store of users.</param>
        public IdentityProvider(UserStore userStore, IPasswordHasher passwordHasher)
        {
            _userStore = userStore;
            PasswordHasher = passwordHasher;

            PasswordValidators.Add(new DefaultPasswordValidator());
            UserValidators.Add(new DefaultUserValidator());
        }

        /// <summary>
        /// The <see cref="IPasswordHasher"/> used to hash passwords.
        /// </summary>
        public IPasswordHasher PasswordHasher { get; private set; }

        /// <summary>
        /// The <see cref="IUserValidator"/> used to validate users.
        /// </summary>
        public ArrayList UserValidators { get; set; } = new ArrayList(1);

        /// <summary>
        /// The <see cref="IPasswordValidator"/> used to validate passwords.
        /// </summary>
        public ArrayList PasswordValidators { get; set; } = new ArrayList(1);

        /// <summary>
        /// Gets the persistence store of users the manager operates over.
        /// </summary>
        public Hashtable Users { get => _userStore.Users; }

        /// <inheritdoc/>
        public virtual IdentityResult Create(IIdentityUser user, string password)
        {
            return Create(user, Encoding.UTF8.GetBytes(password));
        }

        /// <inheritdoc/>
        public virtual IdentityResult Create(IIdentityUser user, byte[] password)
        {
            var errors = new ArrayList();

            var userResults = ValidateUser(user);
            if (!userResults.Succeeded)
            {
                errors.AddRange(userResults.Errors);
            }
            var passwordResults = ValidatePassword(user, password);
            if (!passwordResults.Succeeded)
            {
                errors.AddRange(passwordResults.Errors);
            }
            var updateResults = UpdatePassword(user, password, false);
            if (!updateResults.Succeeded)
            {
                errors.AddRange(updateResults.Errors);
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(new AggregateException($"User validation failed:", errors));
            }

            var store = _userStore.Create(user);
            if (store.Succeeded)
            {
                lock (_lock)
                {
                    OnStoreChanged(this);
                }
            }

            return store;
        }

        /// <inheritdoc/>
        public virtual IdentityResult Delete(IIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var store = _userStore.Delete(user);
            if (store.Succeeded)
            {
                lock (_lock)
                {
                    OnStoreChanged(this);
                }
            }

            return store;
        }

        /// <inheritdoc/>
        public virtual IIdentityUser FindByName(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return _userStore.FindByName(userName);
        }

        /// <inheritdoc/>
        public virtual IIdentityUser FindById(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _userStore.FindById(userId);
        }

        /// <inheritdoc/>
        public virtual bool CheckPassword(IIdentityUser user, string password)
        {
            return CheckPassword(user, Encoding.UTF8.GetBytes(password));
        }

        /// <inheritdoc/>
        public virtual bool CheckPassword(IIdentityUser user, byte[] password)
        {
            var validate = VerifyPassword(user, password);
            if (validate.Succeeded)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public virtual IdentityResult VerifyPassword(IIdentityUser user, string password)
        {
            return VerifyPassword(user, Encoding.UTF8.GetBytes(password));
        }

        /// <inheritdoc/>
        public virtual IdentityResult VerifyPassword(IIdentityUser user, byte[] password)
        {
            var hash = _userStore.GetPasswordHash(user);
            if (hash == null)
            {
                return IdentityResult.Failed(new Exception("Authentication failed: (Invalid user name or password)."));
            }

            return PasswordHasher.VerifyHashedPassword(user, hash, password);
        }

        /// <inheritdoc/>
        public virtual IdentityResult UpdatePassword(IIdentityUser user, string newPassword)
        {
            return UpdatePassword(user, Encoding.UTF8.GetBytes(newPassword), true);
        }

        /// <inheritdoc/>
        public virtual IdentityResult UpdatePassword(IIdentityUser user, byte[] newPassword, bool validatePassword)
        {
            if (validatePassword)
            {
                var validate = ValidatePassword(user, newPassword);
                if (!validate.Succeeded)
                {
                    return validate;
                }
            }

            user.PasswordHash = newPassword != null ? PasswordHasher.HashPassword(user, newPassword) : null;

            if (user.PasswordHash != null)
            {
                lock (_lock)
                {
                    OnStoreChanged(this);
                }
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Should return <see cref="IdentityResult.Success"/> if validation is successful. This is
        /// called before saving the user via Create or Update.
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A <see cref="IdentityResult"/> representing whether validation was successful.</returns>
        private IdentityResult ValidateUser(IIdentityUser user)
        {
            var errors = new ArrayList();
            foreach (IUserValidator Validator in UserValidators)
            {
                var result = Validator.Validate(this, user);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors);
                }
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(new AggregateException($"User {user.Id} account validation failed:", errors));
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Should return <see cref="IdentityResult.Success"/> if validation is successful. This is
        /// called before updating the password hash.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>A <see cref="IdentityResult"/> representing whether validation was successful.</returns>
        private IdentityResult ValidatePassword(IIdentityUser user, byte[] password)
        {
            var errors = new ArrayList();

            foreach (IPasswordValidator Validator in PasswordValidators)
            {
                var result = Validator.Validate(this, user, password);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors);
                }
            }

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(new AggregateException($"User {user.Id} password validation failed:", errors));
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// A change to idenity store has occured.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        protected virtual void OnStoreChanged(object sender)
        {
            StoreChanged(this);
        }

        /// <summary>
        /// An event that is raised when an change to the idenity store has occured.
        /// </summary>
        public event StoreChangedHandler StoreChanged = delegate { };
    }
}