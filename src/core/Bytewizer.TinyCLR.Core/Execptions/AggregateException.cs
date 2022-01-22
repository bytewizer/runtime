using System;
using System.Text;
using System.Collections;
using System.Diagnostics;

#if NanoCLR
namespace Bytewizer.NanoCLR
#else
namespace Bytewizer.TinyCLR
#endif
{
    /// <summary>Represents one or more errors that occur during application execution.</summary>
    /// <remarks>
    /// <see cref="AggregateException"/> is used to consolidate multiple failures into a single, throwable
    /// exception object.
    /// </remarks>
    [Serializable]
    [DebuggerDisplay("Count = {InnerExceptionCount}")]
    public class AggregateException : Exception
    {
        private readonly Exception[] _innerExceptions; // Complete set of exceptions.

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateException"/> class with
        /// a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public AggregateException(string message, ArrayList innerException)
            : base(message)
        {
            _innerExceptions = (Exception[])innerException.ToArray(typeof(Exception));
        }

        /// <summary>
        /// Gets a message that describes the exception.
        /// </summary>
        public override string Message
        {
            get
            {
                if (_innerExceptions.Length == 0)
                {
                    return base.Message;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(base.Message);
                sb.Append(' ');
                for (int i = 0; i < _innerExceptions.Length; i++)
                {
                    sb.Append('(');
                    sb.Append(_innerExceptions[i].Message);
                    sb.Append(") ");
                }
                sb.Length--;

                return sb.ToString();
            }
        }

        internal int InnerExceptionCount => _innerExceptions.Length;
    }
}