// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text;
using System.Diagnostics;

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging.Debug
#else
namespace Bytewizer.TinyCLR.Logging.Debug
#endif
{
    /// <summary>
    /// A logger that writes messages in the debug output window only when a debugger is attached.
    /// </summary>
    internal partial class DebugLogger : ILogger
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogger"/> class.
        /// </summary>
        /// <param name="name">The name of the logger.</param>
        public DebugLogger(string name)
        {
            _name = string.IsNullOrEmpty(name) ? nameof(DebugLogger) : name;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return Debugger.IsAttached &&
                logLevel != LogLevel.None;
        }

        /// <inheritdoc />
        public void Log(LogLevel logLevel, EventId eventId, object state, Exception exception)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = state.ToString();

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var builder = new StringBuilder();

            builder.Append(LogLevelString.GetName(logLevel));
            builder.Append(": ");
            builder.Append(_name);
            builder.Append("[");
            builder.Append(eventId.Id);
            builder.Append("]");
            builder.Append(": ");
            builder.Append(message);

            if (exception != null)
            {
                builder.Append(": ");
                builder.Append(exception);
            }

            DebugWriteLine(builder.ToString());
        }
    }
}
