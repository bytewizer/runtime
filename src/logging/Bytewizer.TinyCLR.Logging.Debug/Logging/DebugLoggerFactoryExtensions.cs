// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Logging.Debug
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Logging.Debug
#endif
{
    /// <summary>
    /// Extension methods for the <see cref="ILoggerFactory"/> class.
    /// </summary>
    public static class DebugLoggerFactoryExtensions
    {
        /// <summary>
        /// Adds a debug logger named 'Debug' to the factory.
        /// </summary>
        /// <param name="builder">The extension method argument.</param>
        public static ILoggingBuilder AddDebug(this ILoggingBuilder builder)
        {
            builder.Services.TryAdd(new ServiceDescriptor(
                    typeof(ILoggerProvider),
                    typeof(DebugLoggerProvider),
                    ServiceLifetime.Singleton
                ));

            return builder;
        }
    }
}