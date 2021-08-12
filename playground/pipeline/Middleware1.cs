using System;

using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Pipeline;

namespace Bytewizer.Playground.Pipeline
{
    public class Middleware1 : Middleware
    {
        private readonly ILogger _logger;

        public Middleware1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(Middleware1));
        }

        public Middleware1(ILoggerFactory loggerFactory, MiddlewareOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _logger = loggerFactory.CreateLogger(nameof(Middleware1));
        }

        protected override void Invoke(IContext context, RequestDelegate next)
        {
            var ctx = context as Context;
            ctx.Message += "...1";

            _logger.Log(LogLevel.Information, "Middleware 1: Code executed before 'next'");
            next(context);
            _logger.Log(LogLevel.Information, "Middleware 1: Code executed after 'next'");
            _logger.Log(LogLevel.Information, ctx.Message);
        }
    }
}