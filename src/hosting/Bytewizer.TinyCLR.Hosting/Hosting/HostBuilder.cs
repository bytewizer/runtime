// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Diagnostics;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Default implementation of <see cref="IHostBuilder"/>.
    /// </summary>
    public class HostBuilder : IHostBuilder
    {
        private bool _hostBuilt;
        private HostBuilderContext _hostBuilderContext;

        private readonly ServiceProviderOptions _providerOptions;
        private readonly ArrayList _configureAppActions;
        private readonly ArrayList _configureServicesActions;

        /// <summary>
        /// Initializes a new instance of <see cref="HostBuilder"/>.
        /// </summary>
        public HostBuilder()
        {
            _configureAppActions = new ArrayList();
            _configureServicesActions = new ArrayList();

            if (Debugger.IsAttached)
            {
                // enables di validation as default when debugger is attached   
                _providerOptions = new ServiceProviderOptions()
                {
                    ValidateOnBuild = true
                };
            }
            else
            {
                _providerOptions = new ServiceProviderOptions();
            }
        }

        /// <inheritdoc />
        public object[] Properties { get; set; } = new object[0];

        /// <inheritdoc />
        public IHostBuilder ConfigureAppConfiguration(ServiceContextDelegate configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException();
            }

            _configureAppActions.Add(configureDelegate);

            return this;
        }

        /// <inheritdoc />
        public IHostBuilder ConfigureServices(ServiceContextDelegate configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException();
            }

            _configureServicesActions.Add(configureDelegate);

            return this;
        }

        /// <inheritdoc />
        public IHostBuilder UseDefaultServiceProvider(ProviderContextDelegate configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException();
            }

            configureDelegate(_hostBuilderContext, _providerOptions);

            return this;
        }

        /// <inheritdoc />
        public IHost Build()
        {
            if (_hostBuilt)
            {
                throw new InvalidOperationException();
            }
            _hostBuilt = true;

            // Create host builder context
            _hostBuilderContext = new HostBuilderContext(Properties);

            // Create service provider
            var services = new ServiceCollection();

            foreach (ServiceContextDelegate configureAppAction in _configureAppActions)
            {
                configureAppAction(_hostBuilderContext, services);
            }

            foreach (ServiceContextDelegate configureServicesAction in _configureServicesActions)
            {
                configureServicesAction(_hostBuilderContext, services);
            }

            services.AddSingleton(typeof(IHost), typeof(Internal.Host));
            services.AddSingleton(typeof(IHostBuilder), _hostBuilderContext);

            var appServices = services.BuildServiceProvider(_providerOptions);

            if (appServices == null)
            {
                throw new InvalidOperationException();
            }

            return (Internal.Host)appServices.GetRequiredService(typeof(IHost));
        }
    }
}
