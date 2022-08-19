using System;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Logging
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// Extension methods for setting up logging services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class LoggingServiceCollectionExtensions
    {
        /// <summary>
        /// Adds logging services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            return AddLogging(services, builder => { });
        }

        /// <summary>
        /// Adds logging services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The <see cref="ILoggingBuilder"/> configuration delegate.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddLogging(this IServiceCollection services, LoggingBuilderAction configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException();
            }

            services.Add(new ServiceDescriptor(
                typeof(LoggerFilterOptions),
                new LoggerFilterOptions() { MinLevel = LogLevel.Information }
            ));

            services.TryAdd(new ServiceDescriptor(
                typeof(ILoggerFactory),
                typeof(LoggerFactory),
                ServiceLifetime.Singleton
            ));

            configure(new LoggingBuilder(services));

            return services;
        }
    }
}