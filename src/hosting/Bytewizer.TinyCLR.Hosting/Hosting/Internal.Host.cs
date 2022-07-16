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
    /// <summary>
    /// Default implementation of <see cref="IHost"/>.
    /// </summary>
    internal class Host : IHost
    {
        private bool _disposed;
        private object[] _hostedServices;

        /// <summary>
        /// Initializes a new instance of <see cref="Host"/>.
        /// </summary>
        public Host(IServiceProvider services)
        {
            if (services == null)
            {
                throw new ArgumentNullException();
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

            for (int index = 0; index < _hostedServices.Length; index++)
            {
                try
                {
                    ((IHostedService)_hostedServices[index]).Start();

                    if (_hostedServices[index] is BackgroundService backgroundService)
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
                throw new AggregateException(string.Empty, exceptions);
            }
        }

        /// <inheritdoc />
        public void Stop()
        {
            if (_hostedServices == null)
            {
                return;
            }

            ArrayList exceptions = null;

            for (int index = _hostedServices.Length - 1; index >= 0; index--)
            {
                try
                {
                    ((IHostedService)_hostedServices[index]).Stop();
                }
                catch (Exception ex)
                {
                    exceptions ??= new ArrayList();
                    exceptions.Add(ex);
                }
            }

            _hostedServices = null;

            if (exceptions != null)
            {
                throw new AggregateException(string.Empty, exceptions);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ((IDisposable)Services).Dispose();
                }

                _disposed = true;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}