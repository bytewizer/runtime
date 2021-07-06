using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Logging.Debug;
using Bytewizer.TinyCLR.Logging.Serial;

using GHIElectronics.TinyCLR.Pins;
using System;

namespace Bytewizer.Playground.Logging
{
    class Program
    {
        private static readonly ILoggerFactory loggerFactory = new LoggerFactory();

        static void Main()
        {
            loggerFactory.AddDebug(LogLevel.Debug);
            loggerFactory.AddSerial(SC20260.UartPort.Uart1, LogLevel.Critical);

            TestLoggerExtensions();
        }

        private static void TestLoggerExtensions()
        {            
            ILogger logger = loggerFactory.CreateLogger(nameof(TestLoggerExtensions));
           
            logger.Log(LogLevel.Information, new EventId(10, "Id Name"), "logging without extensions", null);

            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            logger.LogCritical("Critical");

            logger.LogTrace("{0} {1}", new object[] { "param 1", 42 });
            logger.LogDebug("{0} {1}", new object[] { "param 1", 42 });
            logger.LogInformation("Just some information and nothing else");
            logger.LogWarning("{0} {1}", new object[] { "param 1", 42 });
            logger.LogError(new Exception("Big problem"), "{0} {1}", new object[] { "param 1", 42 });
            logger.LogCritical(42, new Exception("Insane problem"), "{0} {1}", new object[] { "param 1", 42 });
        }
    }
}