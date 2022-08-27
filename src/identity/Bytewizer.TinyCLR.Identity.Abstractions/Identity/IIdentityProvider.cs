namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IIdentityProvider"/> interface.
    /// </summary>
    public interface IIdentityProvider
    {
        /// <summary>
        /// Retrive the specified user from the user store.
        /// </summary>
        /// <param name="username">The user name to retrive.</param>
        /// <param name="user">The <see cref="IIdentityUser"/> retrived if located.</param>
        bool TryGetUser(string username, out IIdentityUser user);

        /// <summary>
        /// Finds and returns a user, if any, who has the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user id to search for.</param>
        IIdentityUser FindById(string userId);

        /// <summary>
        /// Finds and returns a user, if any, who has the specified user name.
        /// </summary>
        /// <param name="username">The user name to search for.</param>
        IIdentityUser FindByName(string username);

        /// <summary>
        /// Determines whether the password is valid for the user.
        /// </summary>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="password">The password to verify.</param>
        bool CheckPassword(IIdentityUser user, string password);

        /// <summary>
        /// Deletes the specified <paramref name="user"/> from the user store.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        IdentityResult Delete(IIdentityUser user);

        /// <summary>
        /// Creates the specified <paramref name="user"/> in the user store with no password.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <param name="password">The password for the user to hash and store.</param>
        IdentityResult Create(IIdentityUser user, string password);

        /// <summary>
        /// Returns a <see cref="IdentityResult"/> indicating the result of a password hash comparison.
        /// </summary>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="password">The password to verify.</param>
        IdentityResult VerifyPassword(IIdentityUser user, string password);

        /// <summary>
        /// Updates a user's password hash.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="validatePassword">Whether to validate the password.</param>
        /// <returns>Whether the password has was successfully updated.</returns>
        IdentityResult UpdatePassword(IIdentityUser user, string newPassword, bool validatePassword);
    }
}