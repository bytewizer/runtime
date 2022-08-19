#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Logging
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Logging
#endif
{
    public sealed class LoggingBuilder : ILoggingBuilder
    {
        public LoggingBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}