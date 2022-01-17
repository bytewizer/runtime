using System;

namespace Bytewizer.TinyCLR.Logging
{
    public static class DiagnosticsLoggerExtensions
    {
        private static readonly EventId _unhandledException = new EventId(100, "Unhandled Exception");

        public static void UnhandledException(this ILogger logger, string name, string message, Exception exception)
        {
            logger.Log(
                LogLevel.Error,
                new EventId(100, name),
                message,
                exception
                );
        }

        public static void UnhandledException(this ILogger logger, Exception exception)
        {
            logger.Log(
                LogLevel.Error,
                _unhandledException,
                "An unhandled exception has occurred while executing.",
                exception
                );
        }
    }
}