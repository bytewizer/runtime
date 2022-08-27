
using System;
using System.Collections;
using System.Diagnostics;

using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
{
    /// <summary>
    /// Default implementation of <see cref="IHostBuilder"/>.
    /// </summary>
    public class HostBuilder : IHostBuilder
    {
        private bool _hostBuilt;
        private readonly HostBuilderContext _hostBuilderContext;
        private readonly ServiceProviderOptions _providerOptions;

        private readonly ArrayList _configureActions;
        private readonly ArrayList _configureAppActions;
        private readonly ArrayList _configureServicesActions;

        /// <summary>
        /// Initializes a new instance of <see cref="HostBuilder"/>.
        /// </summary>
        public HostBuilder()
        {
            _configureActions = new ArrayList();
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

            // Create host builder context
            _hostBuilderContext = new HostBuilderContext(Properties);

            // Create service provider
            Services = new ServiceCollection();
        }

        /// <summary>
        /// A collection of services for the application to compose.
        /// </summary>
        public IServiceCollection Services { get; set; }

        /// <inheritdoc />
        public Hashtable Properties { get; set; } = new Hashtable();

        /// <inheritdoc />
        public IHostBuilder ConfigureApp(ServiceContextDelegate configureDelegate)
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
        public IHostBuilder Configure(ServiceProviderDelegate configureDelegate)
        {
            if (configureDelegate == null)
            {
                throw new ArgumentNullException();
            }

            _configureActions.Add(configureDelegate);

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

            foreach (ServiceContextDelegate configureAppAction in _configureAppActions)
            {
                configureAppAction(_hostBuilderContext, Services);
            }

            foreach (ServiceContextDelegate configureServicesAction in _configureServicesActions)
            {
                configureServicesAction(_hostBuilderContext, Services);
            }

            Services.AddSingleton(typeof(IHost), typeof(Internal.Host));
            Services.AddSingleton(typeof(IHostBuilder), _hostBuilderContext);

            var appServices = Services.BuildServiceProvider(_providerOptions);

            if (appServices == null)
            {
                throw new InvalidOperationException();
            }

            foreach (ServiceProviderDelegate configureAction in _configureActions)
            {
                configureAction(Services, appServices);
            }

            return (Internal.Host)appServices.GetRequiredService(typeof(IHost));
        }
    }
}
