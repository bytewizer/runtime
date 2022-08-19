using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Identity
{
    /// <summary>
    /// Represents the result of an identity operation.
    /// </summary>
    public class IdentityResult
    {
        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// An <see cref="ArrayList"/> of <see cref="Exception"/> containing errors
        /// that occurred during the identity operation.
        /// </summary>
        public ArrayList Errors { get; private set; }

        /// <summary>
        /// Returns an <see cref="IdentityResult"/> indicating a successful identity operation.
        /// </summary>
        /// <returns>An <see cref="IdentityResult"/> indicating a successful operation.</returns>
        public static IdentityResult Success => new IdentityResult { Succeeded = true };

        /// <summary>
        /// Creates an <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="error"/> if applicable.
        /// </summary>
        /// <param name="error">An <see cref="Exception"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="error"/> if applicable.</returns>
        public static IdentityResult Failed(string error)
        {
            var errors = new ArrayList() { new Exception(error) };

            return Failed(errors);
        }

        /// <summary>
        /// Creates an <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="error"/> if applicable.
        /// </summary>
        /// <param name="error">An <see cref="Exception"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="error"/> if applicable.</returns>
        public static IdentityResult Failed(Exception error)
        {
            var errors = new ArrayList() { error };

            return Failed(errors);
        }

        /// <summary>
        /// Creates an <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="Exception"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static IdentityResult Failed(ArrayList errors)
        {
            var result = new IdentityResult { Succeeded = false };

            if (errors != null)
            {
                result.Errors = errors;
            }

            return result;
        }
    }
}
