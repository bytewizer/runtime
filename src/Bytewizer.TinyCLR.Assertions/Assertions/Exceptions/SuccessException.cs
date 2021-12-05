using System;

namespace Bytewizer.TinyCLR.Assertions
{

    /// <summary>
    /// Thrown when an assertion failed.
    /// </summary>
    [Serializable]
    public class SuccessException : AssertionException
    {
        /// <param name="message"></param>
        public SuccessException(string message)
            : base(message)
        { }

        /// <param name="message">The error message that explains
        /// the reason for the exception</param>
        /// <param name="inner">The exception that caused the
        /// current exception</param>
        public SuccessException(string message, Exception inner)
            :
            base(message, inner)
        { }
    }
}
