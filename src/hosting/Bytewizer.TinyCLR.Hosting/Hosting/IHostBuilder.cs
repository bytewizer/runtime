// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else
using Bytewizer.TinyCLR.DependencyInjection;
using nanoFramework.Hosting;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// A program initialization abstraction.
    /// </summary>
    public interface IHostBuilder
    {
        /// <summary>
        /// A central location for sharing state between components during the host building process.
        /// </summary>
        Hashtable Properties { get; set; }

        /// <summary>
        /// Sets up the configuration for the remainder of the build process and application. This can be called multiple times and
        /// the results will be additive. The results will be available at <see cref="HostBuilderContext.Configuration"/> for
        /// subsequent operations, as well as in <see cref="IHost.Services"/>.
        /// </summary>
        /// <param name="configureDelegate">The delegate that will be used
        /// to construct the <see cref="IConfiguration"/> for the application.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        IHostBuilder ConfigureApp(ServiceContextDelegate configureDelegate);

        /// <summary>
        /// Adds services to the container. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="IServiceCollection"/> that will be used
        /// to construct the <see cref="IServiceProvider"/>.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        IHostBuilder ConfigureServices(ServiceContextDelegate configureDelegate);

        /// <summary>
        /// Adds service providers to the container. This can be called multiple times and the results will be additive.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="IServiceProvider"/>.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        IHostBuilder Configure(ServiceProviderDelegate configureDelegate);

        /// <summary>
        /// Specify the <see cref="IServiceProvider"/> to be the default one.
        /// </summary>
        /// <param name="configureDelegate">The delegate for configuring the <see cref="ServiceProviderOptions"/> that will be used
        /// to construct the <see cref="IServiceProvider"/>.</param>
        /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
        IHostBuilder UseDefaultServiceProvider(ProviderContextDelegate configureDelegate);

        /// <summary>
        /// Run the given actions to initialize the host. This can only be called once.
        /// </summary>
        /// <returns>An initialized <see cref="IHost"/>.</returns>
        /// <exception cref="InvalidOperationException">"Build can only be called once."</exception>
        IHost Build();
    }
}
