using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Logging.Debug;
using Bytewizer.TinyCLR.Pipeline.Builder;
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.Playground.Pipeline
{
    class Program
    {
        private static ILogger _logger;

        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(typeof(ILoggerFactory), typeof(LoggerFactory))
                .AddSingleton(typeof(Middleware1))
                .AddSingleton(typeof(Middleware2))
                .AddSingleton(typeof(Middleware3))
                .BuildServiceProvider();

            var loggerFactory = (LoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
            loggerFactory.AddDebug();

            _logger = loggerFactory.CreateLogger(nameof(Main));

            var builder = new ApplicationBuilder(serviceProvider);
            builder.UseMiddleware1();
            builder.UseMiddleware2();
            builder.UseMiddleware3();

            // Properties use to set/get values used by other middleware
            _logger.Log(LogLevel.Information, (string)builder.GetProperty("key1"));
            _logger.Log(LogLevel.Information, (string)builder.GetProperty("key2"));
            _logger.Log(LogLevel.Information, (string)builder.GetProperty("key3"));

            var app = builder.Build();

            app.Use((context, next) =>
            {
                _logger.Log(LogLevel.Information, "Inline: Code executed before 'next'");
                next(context);
                _logger.Log(LogLevel.Information, "Inline: Code executed after 'next'");
            });

            var ctx = new Context() { Message = "Context: Finished" };
            app.Invoke(ctx);
        }
    }
} 