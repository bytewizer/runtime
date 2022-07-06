// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    public class HostBuilder : IHostBuilder
    {
        private bool _hostBuilt;
        private IServiceProvider _appServices;
        private HostBuilderContext _hostBuilderContext;
        private ServiceProviderOptions _providerOptions;

        private readonly ArrayList _configureServicesActions = new ArrayList();

        /// <inheritdoc />
        public object[] Properties { get; } = new object[0];

        /// <inheritdoc />
        public IHostBuilder ConfigureServices(ServiceContextDelegate configureDelegate)
        {
            _configureServicesActions.Add(configureDelegate ?? throw new ArgumentNullException(nameof(configureDelegate)));
            return this;
        }

        /// <inheritdoc />
        public IHostBuilder UseDefaultServiceProvider(ProviderContextDelegate configureDelegate)
        {
            _providerOptions = new ServiceProviderOptions();
            configureDelegate(_hostBuilderContext, _providerOptions);
            return this;
        }

        /// <inheritdoc />
        public IHost Build()
        {
            if (_hostBuilt)
            {
                throw new InvalidOperationException("Build can only be called once.");
            }
            _hostBuilt = true;

            // Create host builder context
            _hostBuilderContext = new HostBuilderContext(Properties);

            // Create service provider
            var services = new ServiceCollection();

            services.AddSingleton(typeof(IHost), typeof(Internal.Host));
            services.AddSingleton(typeof(IHostBuilder), _hostBuilderContext);

            foreach (ServiceContextDelegate configureServicesAction in _configureServicesActions)
            {
                configureServicesAction(_hostBuilderContext, services);
            }

            if (_providerOptions == null)
            {
                _appServices = services.BuildServiceProvider();
            }
            else
            {
                _appServices = services.BuildServiceProvider(_providerOptions);
            }

            if (_appServices == null)
            {
                throw new InvalidOperationException($"The BuildServiceProvider returned a null ServiceProvider.");
            }

            return (Internal.Host)_appServices.GetRequiredService(typeof(IHost));
        }
    }
}
