# Dependency Injection (DI)

Provides dependency injection for Inversion of Control (IoC) between classes and their dependencies built for TinyCLR OS and .NET nanoFramework.

## Simple Dependency Injection Example
```CSharp
class Program
{     
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton(typeof(ILoggerFactory), typeof(LoggerFactory))
            .AddSingleton(typeof(IFooService), typeof(FooService))
            .AddSingleton(typeof(IBarService), typeof(BarService))
            .BuildServiceProvider();

        var loggerFactory = (LoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
        loggerFactory.AddDebug();

        var logger = loggerFactory.CreateLogger(typeof(Program));
        logger.LogInformation("Starting application");

        //do the actual work here
        var bar = (BarService)serviceProvider.GetService(typeof(IBarService));
        bar.DoSomeRealWork();

        logger.LogInformation("All done!");
    }
}

public interface IFooService
{
    void DoThing(int number);
}

public interface IBarService
{
    void DoSomeRealWork();
}

public class BarService : IBarService
{
    private readonly IFooService _fooService;
    
    public BarService(IFooService fooService)
    {
        _fooService = fooService;
    }

    public void DoSomeRealWork()
    {
        for (int i = 0; i < 10; i++)
        {
            _fooService.DoThing(i);
        }
    }
}

public class FooService : IFooService
{
    private readonly ILogger _logger;
    
    public FooService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger(typeof(FooService));
    }

    public void DoThing(int number)
    {
        _logger.LogInformation($"Doing the thing {number}");
    }
}
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Dependencyinjection
```

## .NET nanoFramework Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.nanoclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.NanoCLR.Dependencyinjection
```