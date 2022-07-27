//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Extension methods for setting up configuration in an <see cref="IHostBuilder" />.
    /// </summary>
    public static class ConfigurationHostingHostBuilderExtensions
    {
        /// <summary>
        /// Sets up the configuration for the remainder of the build process and application. This can be called multiple times and
        /// the results will be additive. The results will be available at <see cref="HostBuilderContext.Configuration"/> for
        /// subsequent operations, as well as in <see cref="IHost.Services"/>.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IHostBuilder" /> to configure.</param>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="IConfigurationBuilder"/> that will be used
        /// to construct the <see cref="IConfiguration"/> for the host.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        public static IHostBuilder ConfigureAppConfiguration(this IHostBuilder hostBuilder, ConfigurationAction  configureDelegate)
        {
            hostBuilder.ConfigureAppConfiguration((context, collection) => 
            {
                var configurationBuilder = new ConfigurationBuilder();
                
                configureDelegate(configurationBuilder);

                context.Configuration = configurationBuilder.Build();

                collection.AddSingleton(typeof(IConfigurationRoot), context.Configuration);
                collection.AddSingleton(typeof(IConfiguration), context.Configuration);
            });

            return hostBuilder;
        }
    }
}