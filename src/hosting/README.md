# Hosting
The Generic Host provides convenience methods for creating dependency injection (DI) application containers with preconfigured defaults.

## Generic Host
A Generic Host configures a DI application container as well as provides services in the DI container which handle the the application lifetime. When a host starts it calls `Start()` on each implementation of `IHostedService` registered in the service container's collection of hosted services. In the application container all `IHostedService` object that inherent `BackgroundService` or `SchedulerService` have their `ExecuteAsync()` methods called.

This API mirrors as close as possible the official .NET 
[Generic Host](https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host).

```csharp
namespace Hosting
{
    public class Program
    {
        public static void Main()
        {
            IHost host = CreateHostBuilder().Build();
            
            // starts application and blocks the main calling thread 
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(typeof(BackgroundQueue));
                    services.AddHostedService(typeof(SensorService));
                    services.AddHostedService(typeof(DisplayService));
                });
    }
}
```

## IHostedService interface

When you register an `IHostedService` the host builder will call the `Start()` and `Stop()` methods of `IHostedService` during application start and stop respectively. You can create multiple implementations of `IHostedService` and register them using the `ConfigureService()` method in the DI container. All hosted services will be started and stopped along with the application.

```csharp
public class CustomService : IHostedService
{
    public void Start() { }

    public void Stop() { }
}
```

## BackgroundService base class

Provides a base class for implementing a long running `IHostedService`. The method `ExecuteAsync()` is called asynchronously to run the background service. Your implementation of `ExecuteAsync()` should finish promptly when the `CancellationRequested` is fired in order to gracefully shut down the service.

```csharp
public class SensorService : BackgroundService
{
    protected override void ExecuteAsync()
    {
        while (!CancellationRequested)
        {
            // to allow other threads time to process include 
            // at least one millsecond sleep in loop
            Thread.Sleep(1);
        }
    }
}
```

## SchedulerService base class

 Provides a base class for implementing a scheduled [Timer](https://docs.nanoframework.net/api/System.Threading.Timer.html) running `IHostedServce`. The timer triggers at a specified time and interval the `ExecuteAsync()` method. The timer is disabled on `Stop()` and disposed when the service container is disposed.

```csharp
public class DisplayService : SchedulerService
{
    // represents a timer control that involks ExecuteAsync at a 
    // specified interval of time repeatedly
    public DisplayService() : base(TimeSpan.FromSeconds(1)) {}

    protected override void ExecuteAsync(object state)
    {   
    }
}
```

## IServiceCollection extensions method

Extending `IServiceCollection` is a pretty straightforward way to add additional features to the application container.

```csharp
public static IServiceCollection AddLogging(this IServiceCollection services, LogLevel level)
{
    if (services == null)
    {
        throw new ArgumentNullException();
    }

    var loggerFactory = new DebugLoggerFactory();
    LogDispatcher.LoggerFactory = loggerFactory;

    var logger = (DebugLogger)loggerFactory.GetCurrentClassLogger();
    logger.MinLogLevel = level;

    // using TryAdd prevents duplicate logging objects if AddLogging() 
    // is added more then once to ConfigureServices
    services.TryAdd(new ServiceDescriptor(typeof(ILogger), logger));
    services.TryAdd(new ServiceDescriptor(typeof(ILoggerFactory), loggerFactory));

    return services;
}
```

The extension can then be registered like this:

```csharp
public static IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            services.AddLogging(LogLevel.Debug);
            services.AddSingleton(typeof(LoggingService));
        });
```

And used like this:

```csharp
public class LoggingService : IHostedService
{
    private ILogger Logger { get; set; }

    public LoggingService(ILogger logger)
    {
        Logger = logger;
    }

    public void Start()
    {
        Logger.Log(LogLevel.Information, new EventId(10, "Start"), "Logging started", null);
    }

    public void Stop()
    {
        Logger.Log(LogLevel.Information, new EventId(11, "Stop"), "Logging stopped", null);
    }
}
```

## Validate On Build

The default builder enables DI validation when the debugger is attached. This check is performed to ensure that all services registered with the container can actually be created. This can be particularly useful during development to fail fast and allow developers to fix issues. The setting can be modified by using the `UseDefaultServiceProvider()` method.

```csharp
public static IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder()
        .UseDefaultServiceProvider(options =>
        {
            options.ValidateOnBuild = false;
        });
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Hosting
```

## .NET nanoFramework Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.nanoclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.NanoCLR.Hosting
```