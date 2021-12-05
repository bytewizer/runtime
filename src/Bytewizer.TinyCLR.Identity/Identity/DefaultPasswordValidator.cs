using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Implements identity password validation.
    /// </summary>
    public class DefaultPasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// Returns a <see cref="IdentityResult"/> indicating the result of a password validation comparison.
        /// </summary>
        /// <param name="manager">Provides the APIs for managing user in a persistence store.</param>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="password">The password supplied for comparison.</param>
        /// <returns>A <see cref="IdentityResult"/> indicating the result of a password hash comparison.</returns>
        public IdentityResult Validate(IdentityProvider manager, IIdentityUser user, byte[] password)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            var errors = new ArrayList();

            if (password.Length < 8)
            {
                errors.Add(new Exception("Password must be at least 8 characters long"));
            }

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors);
            }

            return IdentityResult.Success;
        }
    }
}