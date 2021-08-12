using System;

using Bytewizer.TinyCLR.Logging;
using Bytewizer.TinyCLR.Pipeline;

namespace Bytewizer.Playground.Pipeline
{
    public class Middleware2 : Middleware
    {
        private readonly ILogger _logger;

        public Middleware2(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(Middleware2));
        }

        protected override void Invoke(IContext context, RequestDelegate next)
        {
            var ctx = context as Context;
            ctx.Message += "...2";

            _logger.Log(LogLevel.Information, "Middleware 2: Code executed before 'next'");

            // if you do not include the 'next' delegate in the module. Execution will turn around in
            // the pipeline skipping down stream modules.  
            Random rnd = new Random();
            if (rnd.Next(2) == 0) // random true/false
            {
                next(context);
            }
            else
            {
                _logger.Log(LogLevel.Information, "Skipping Middleware 2 in pipeline and turning back");
            }

            _logger.Log(LogLevel.Information, "Middleware 2: Code executed after 'next'");
        }
    }
}
