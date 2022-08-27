using System;
using System.Text;
using GHIElectronics.TinyCLR.Cryptography;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Implements HMAC-SHA256 identity password hashing.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Returns a hashed representation of the supplied <paramref name="password"/> for the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user whose password is to be hashed.</param>
        /// <param name="password">The password to hash.</param>
        /// <returns>A hashed representation of the supplied <paramref name="password"/> for the specified <paramref name="user"/>.</returns>
        public byte[] HashPassword(IIdentityUser user, string password)
        {
            byte[] pass = Encoding.UTF8.GetBytes(password);

            var key = new byte[32];
            _random.NextBytes(key);

            var salt = new byte[key.Length + pass.Length];
            Array.Copy(key, 0, salt, 0, key.Length);
            Array.Copy(pass, 0, salt, key.Length, pass.Length);

            user.PasswordSalt = salt;
            user.PasswordHash = new HMACSHA256(salt).ComputeHash(pass);

            return user.PasswordHash;
        }

        /// <summary>
        /// Returns a <see cref="IdentityResult"/> indicating the result of a password hash comparison.
        /// </summary>
        /// <param name="user">The user whose password should be verified.</param>
        /// <param name="hashedPassword">The hash value for a user's stored password.</param>
        /// <param name="providedPassword">The password supplied for comparison.</param>
        /// <returns>A <see cref="IdentityResult"/> indicating the result of a password hash comparison.</returns>
        public IdentityResult VerifyHashedPassword(IIdentityUser user, byte[] hashedPassword, string providedPassword)
        {
            try
            {
                byte[] password = Encoding.UTF8.GetBytes(providedPassword);
                var hashBytes = new HMACSHA256(user.PasswordSalt).ComputeHash(password);
                
                if (VerifyHashedPassword(hashedPassword, hashBytes))
                {
                    return IdentityResult.Success;
                }
                else
                {
                    return IdentityResult.Failed("Authentication failed: Invalid security hash value.");
                }
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(ex);
            }
        }

        private static bool VerifyHashedPassword(byte[] hashedPassword, byte[] password)
        {
           

            if (hashedPassword.Length < 1 || password.Length < 1)
            {
                return false;
            }

            if (hashedPassword.Length != password.Length)
            {
                return false;
            }

            for (var index = 0; index < hashedPassword.Length; index++)
            {
                if (hashedPassword[index] != password[index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
