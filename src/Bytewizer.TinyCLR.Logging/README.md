# Logging

Provides a flexable logging provider.

## Simple Serial Logging Example
```CSharp
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

        // Requires Bytewizer.TinyCLR.Logging.Extensions convenience packages
        logger.LogTrace("Trace");
        logger.LogDebug("Debug");
        logger.LogInformation("Information");
        logger.LogWarning("Warning");
        logger.LogError("Error");
        logger.LogCritical("Critical");
    }
}
```

## TinyCLR Packages
Install the package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or from the `Package Manager Console` :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Logging.Debug
PM> Install-Package Bytewizer.TinyCLR.Logging.Serial
PM> Install-Package Bytewizer.TinyCLR.Logging.Extensions
```