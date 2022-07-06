using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Logging.Debug;
using Bytewizer.TinyCLR.DependencyInjection;
using System;

namespace Bytewizer.Playground.DependencyInjection
{
    class Program
    {     
        static void Main()
        {

            var structInstance = typeof(StructFakeService).GetConstructor(new Type[] { typeof(FakeObject) }).Invoke(new object[] { new FakeObject() });
            var serviceProvider = new ServiceCollection()
                //.AddSingleton(typeof(ILoggerProvider), typeof(DebugLoggerProvider))
                .AddSingleton(typeof(IFooService), typeof(FooService))
                .AddSingleton(typeof(IBarService), typeof(BarService))
                .BuildServiceProvider();

            var loggerProvider = (FooService)serviceProvider.GetService(typeof(IFooService));
            //loggerFactory.AddDebug();

            //var logger = loggerFactory.CreateLogger(typeof(Program));
            //logger.LogInformation("Starting application");

            ////do the actual work here
            //var bar = (BarService)serviceProvider.GetService(typeof(IBarService));
            //bar.DoSomeRealWork();

            //logger.LogInformation("All done!");
        }
    }

    public struct FakeObject
    {
    }

    public struct StructFakeService
    {
        private readonly FakeObject _fakeObject;

        public StructFakeService(FakeObject fakeObject)
        {
            _fakeObject = fakeObject;
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
}