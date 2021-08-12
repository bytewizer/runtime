using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Pipeline;

namespace Bytewizer.Playground.Pipeline
{
    public class Middleware3 : Middleware
    {
        private readonly ILogger _logger;

        public Middleware3(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(Middleware3));
        }

        protected override void Invoke(IContext context, RequestDelegate next)
        {
            var ctx = context as Context;
            ctx.Message += "...3";

            _logger.Log(LogLevel.Information, "Middleware 3: Code executed before 'next'");
            next(context); // this is optional and skipped in the last module of the pipeline
            _logger.Log(LogLevel.Information, "Middleware 3: Code executed after 'next'");
        }
    }
}
