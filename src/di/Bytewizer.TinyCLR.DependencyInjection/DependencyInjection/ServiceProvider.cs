﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;

#if NanoCLR
namespace Bytewizer.NanoCLR.DependencyInjection
#else
namespace Bytewizer.TinyCLR.DependencyInjection
#endif
{
    /// <summary>
    /// The default <see cref="IServiceProvider"/>.
    /// </summary>
    /// <exception cref="AggregateException">Some services are not able to be constructed.</exception>
    public sealed class ServiceProvider : IServiceProvider, IDisposable
    {
        private bool _disposed;
        internal ServiceProviderEngine _engine;

        internal ServiceProvider(IServiceCollection services, ServiceProviderOptions options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _engine = GetEngine();
            _engine.Services = services;
            _engine.Services.Add(new ServiceDescriptor(typeof(IServiceProvider), this));

            if (options.ValidateOnBuild)
            {
                ArrayList exceptions = null;

                foreach (ServiceDescriptor descriptor in services)
                {
                    try
                    {
                        _engine.ValidateService(descriptor);
                    }
                    catch (Exception ex)
                    {
                        exceptions ??= new ArrayList();
                        exceptions.Add(ex);
                    }
                }

                if (exceptions != null)
                {
                    throw new AggregateException(string.Empty, exceptions);
                }
            }
        }

        /// <inheritdoc/>
        public object GetService(Type serviceType)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException();
            }

            return _engine.GetService(serviceType);
        }

        /// <inheritdoc/>
        public object[] GetService(Type[] serviceType)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException();
            }

            return _engine.GetService(serviceType);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _engine.DisposeServices();
        }

        private ServiceProviderEngine GetEngine()
        {
            return ServiceProviderEngine.Instance;
        }
    }
}