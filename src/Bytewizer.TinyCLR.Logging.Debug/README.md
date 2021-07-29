# Debug Logging

Provides a flexable debug logging provider built for TinyCLR OS.

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

        logger.Log(LogLevel.Information, new EventId(10, "Id Name"), "logging without extensions", null);
    }
}
```

## TinyCLR Packages
Install the package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or from the `Package Manager Console` :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Logging.Debug
```