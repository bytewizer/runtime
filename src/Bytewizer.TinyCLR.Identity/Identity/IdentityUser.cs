using System;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IdentityUser"/> class.
    /// </summary>
    public class IdentityUser : IIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUser"/> class.
        /// </summary>
        /// <remarks>The Id property is initialized from a new GUID string value.</remarks>
        /// <param username="user">The user name.</param>
        public IdentityUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            Id = DateTime.Now.Ticks.ToString();
            Name = userName;
        }

        /// <inheritdoc/>
        public string Id { get; private set; }

        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public byte[] PasswordHash { get; set; }

        /// <inheritdoc/>
        public byte[] PasswordSalt { get; set; }
    }
}