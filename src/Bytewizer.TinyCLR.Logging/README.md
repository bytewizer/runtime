# Logging

Provides a flexable logging provider.

## Simple Debug Logging Example
```CSharp
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
```