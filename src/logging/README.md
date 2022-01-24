# Logging

Provides a flexable logging provider built for TinyCLR OS and .NET nanoFramework.

## Simple Debug Logging Example
```CSharp
class Program
{
    private static readonly ILoggerFactory loggerFactory = new LoggerFactory();

    static void Main()
    {
        loggerFactory.AddDebug(LogLevel.Debug);        
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

## Simple Serial Logging Example (TinyCLR OS only)
```CSharp
class Program
{
    private static readonly ILoggerFactory loggerFactory = new LoggerFactory();

    static void Main()
    {
        loggerFactory.AddSerial(SC20260.UartPort.Uart1);  
        
        TestLoggerExtensions();
    }

    private static void TestLoggerExtensions()
    {
        ILogger logger = loggerFactory.CreateLogger(nameof(TestLoggerExtensions));

        logger.Log(LogLevel.Information, new EventId(10, "Id Name"), "logging without extensions", null);
    }
}
```

## Logging Abstraction

Provides a minimalistic logger useful for libraries that does nothing.

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Logging
PM> Install-Package Bytewizer.TinyCLR.Logging.Debug
PM> Install-Package Bytewizer.TinyCLR.Logging.Serial
PM> Install-Package Bytewizer.TinyCLR.Logging.Extensions
```

## .NET nanoFramework Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.nanoclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Logging
PM> Install-Package Bytewizer.TinyCLR.Logging.Debug
PM> Install-Package Bytewizer.TinyCLR.Logging.Extensions
```