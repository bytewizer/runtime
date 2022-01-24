// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// ILogger extension methods.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="message">The entry to be written.</param>
        public static void Log(this ILogger logger, LogLevel logLevel, string message)
        {
            logger.Log(logLevel, new EventId(), message, null);
        }
    }
}