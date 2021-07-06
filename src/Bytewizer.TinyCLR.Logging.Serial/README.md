# Serial Logging

Provides a flexable serial/uart logging provider.

## Simple Serial Logging Example
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

## TinyCLR Packages
```bash
PM> Install-Package Bytewizer.TinyCLR.Logging.Serial
```