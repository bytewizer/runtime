using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Represents a new instance of a persistence store for users using the default implementation of <see cref="IdentityUser"/>.
    /// </summary>
    public class UserStore
    {
        private readonly Hashtable _users;
        private readonly object _syncLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore"/> class.
        /// </summary>
        public UserStore()
            : this(new Hashtable())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore"/> class.
        /// </summary>
        public UserStore(Hashtable users)
        {
            _users = users;
        }

        /// <summary>
        /// A navigation property for the users the store contains.
        /// </summary>
        public Hashtable Users { get => _users; }

        /// <summary>
        /// Creates the specified user in the store.
        /// </summary>
        /// <param name="user">The user to create.</param>
        public IdentityResult Create(IIdentityUser user)
        {
            try
            {
                if (!_users.Contains(user.UserName))
                {
                    lock (_syncLock)
                    {
                        _users.Add(user.UserName, user);
                    }

                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed($"User {user.Id} failed to be added. User name must be unique.");
                }
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(ex);
            }
        }

        /// <summary>
        /// Deletes the specified user from the store.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        public IdentityResult Delete(IIdentityUser user)
        {
            try
            {
                if (_users.Contains(user.UserName))
                {
                    lock (_syncLock)
                    {
                        _users.Remove(user.UserName);
                    }

                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed($"User {user.Id} failed to be deleted. User name did not exist.");
                }
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(ex);
            }
        }

        /// <summary>
        /// Determines whether the user has a password set.
        /// </summary>
        /// <param name="user"></param>
        public virtual bool HasPassword(IIdentityUser user)
        {
            if (TryGetUser(user.UserName, out user))
            {
                if (user.PasswordHash == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes all the users in the store.
        /// </summary>
        public void Clear()
        {
            lock (_syncLock)
            {
                _users.Clear();
            }
        }

        /// <summary>
        /// Retrive the specified user from the user store.
        /// </summary>
        /// <param name="username">The user name to retrive.</param>
        /// <param name="user">The <see cref="IIdentityUser"/> retrived if located.</param>
        public bool TryGetUser(string username, out IIdentityUser user)
        {
            user = null;

            if (_users.Contains(username))
            {
                // user found so return user details
                user = (IIdentityUser)Users[username];
                return true;
            }

            // return false if user not found
            return false;
        }

        /// <summary>
        /// Finds and returns a user who has the specified user name.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        public IIdentityUser FindByName(string username)
        {
            if (_users.Contains(username))
            {
                // user found so return user details
                return (IIdentityUser)_users[username];
            }

            return null;
        }

        /// <summary>
        /// Finds and returns a user who has the specified user id.
        /// </summary>
        /// <param name="userId">The user id to search for.</param>
        public IIdentityUser FindById(string userId)
        {
            foreach (IIdentityUser user in _users.Values)
            {
                if (user.Id == userId)
                {
                    // user found so return user details
                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Get the password hash for a user
        /// </summary>
        /// <param name="user"></param>
        public byte[] GetPasswordHash(IIdentityUser user)
        {
            IIdentityUser identityUser = FindByName(user.UserName);
            if (identityUser != null)
            {
                return identityUser.PasswordHash;
            }

            return null;
        }
    }
}
