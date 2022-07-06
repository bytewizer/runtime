// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting.Internal
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting.Internal
#endif
{
    internal class Host : IHost, IDisposable
    {
        private object[] _hostedServices;

        public Host(IServiceProvider services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Services = services;
        }

        /// <inheritdoc />
        public IServiceProvider Services { get; }

        /// <inheritdoc />
        public void Start()
        {
            _hostedServices = Services.GetServices(typeof(IHostedService));

            ArrayList exceptions = null;
            foreach (IHostedService hostedService in _hostedServices)
            {
                try
                {
                    // TODO: Thead exceptions are not passed back to main thread. What to do?
                    hostedService.StartAsync();

                    if (hostedService is BackgroundService backgroundService)
                    {
                        backgroundService.ExecuteThread().Start();
                    }
                }
                catch (Exception ex)
                {
                    exceptions ??= new ArrayList();
                    exceptions.Add(ex);
                }
            }

            if (exceptions != null)
            {
                throw new AggregateException("One or more hosted services failed to start.", exceptions);
            }
        }

        /// <inheritdoc />
        public void Stop()
        {
            ArrayList exceptions = null;
            foreach (IHostedService hostedService in _hostedServices)
            {
                try
                {
                    hostedService.StopAsync();
                }
                catch (Exception ex)
                {
                    exceptions ??= new ArrayList();
                    exceptions.Add(ex);
                }
            }

            if (exceptions != null)
            {
                throw new AggregateException("One or more hosted services failed to stop.", exceptions); ;
            }
        }

        public void Dispose()
        {
            _hostedServices = null;
        }
    }
}