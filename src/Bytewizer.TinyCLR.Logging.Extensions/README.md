# Logging Convenience Extentions 

Provides a set of convenience extentions to the ILogger interface.

## Simple Serial Logging Example
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
PM> Install-Package Bytewizer.TinyCLR.Logging.Extensions
```
