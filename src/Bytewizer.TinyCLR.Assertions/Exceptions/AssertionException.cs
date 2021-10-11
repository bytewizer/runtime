using System;

namespace Bytewizer.TinyCLR.Assertions
{
    /// <summary>
    /// Thrown when an assertion failed.
    /// </summary>
    [Serializable]
    public class AssertionException : Exception
    {

        /// <summary>
        /// Initializes an instance of the <see cref="AssertionException" /> class.
        /// </summary>
        public AssertionException()
        { }

        /// <param name="message">The error message that explains
        /// the reason for the exception</param>
        public AssertionException(string message) : base(message)
        {}

        /// <param name="message">The error message that explains
        /// the reason for the exception</param>
        /// <param name="inner">The exception that caused the
        /// current exception</param>
        public AssertionException(string message, Exception inner) :
            base(message, inner)
        {}
    }
}
