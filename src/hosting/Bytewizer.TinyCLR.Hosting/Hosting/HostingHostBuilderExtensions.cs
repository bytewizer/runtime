// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else

using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Extensions for <see cref="IHostBuilder"/>.
    /// </summary>
    public static class HostingHostBuilderExtensions
    {
        /// <summary>
        /// Adds services to the container. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IHostBuilder" /> to configure.</param>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="IServiceCollection"/>.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        public static IHostBuilder ConfigureServices(this IHostBuilder hostBuilder, ServiceAction configureDelegate)
        {
            if (hostBuilder == null)
            {
                throw new ArgumentNullException();
            }

            return hostBuilder.ConfigureServices((context, collection) => configureDelegate(collection));
        }

        /// <summary>
        /// Specify the <see cref="IServiceProvider"/> to be the default one.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="ServiceProviderOptions"/>.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        public static IHostBuilder UseDefaultServiceProvider(this IHostBuilder hostBuilder, ProviderAction configureDelegate)
        {
            if (hostBuilder == null)
            {
                throw new ArgumentNullException();
            }

            return hostBuilder.UseDefaultServiceProvider((context, options) => configureDelegate(options));
        }
    }
}