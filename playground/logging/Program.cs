using System;
using System.Collections;
using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Logging.Debug;

namespace Bytewizer.Playground.Logging
{
    class Program
    {
        private static readonly ILoggerFactory loggerFactory = new LoggerFactory();

        static void Main()
        {
            loggerFactory.AddDebug();

            TestLoggerExtensions();
        }

        private static void TestLoggerExtensions()
        {
            ILogger logger = loggerFactory.CreateLogger(nameof(TestLoggerExtensions));

            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            logger.LogCritical("Critical");
        }
    }
}