
#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Logging.Debug
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Logging.Debug
#endif
{
    /// <summary>
    /// Extension methods for the <see cref="ILoggingBuilder"/> class.
    /// </summary>
    public static class DebugLoggerBuilderExtensions
    {

        /// <summary>
        /// Adds a debug logger that is enabled as defined by the log level.
        /// </summary>
        /// <param name="builder">The extension method argument.</param>
        public static ILoggingBuilder AddDebug(this ILoggingBuilder builder)
        {
            builder.Services.Add(new ServiceDescriptor(
                typeof(ILoggerProvider),
                new DebugLoggerProvider()
            ));

            return builder;
        }
    }
}