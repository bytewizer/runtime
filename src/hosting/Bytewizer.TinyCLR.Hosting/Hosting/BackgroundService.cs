// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;

#if NanoCLR
namespace nanoFramework.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Base class for implementing a long running <see cref="IHostedService"/>.
    /// </summary>
    public abstract class BackgroundService : IHostedService, IDisposable
    {
        private Thread _executeThread;

        /// <summary>
        /// Gets whether cancellation has been requested for this service.
        /// </summary>
        protected bool IsCancellationRequested { get; private set; }

        /// <summary>
        /// Gets the <see cref="Thread"/> that executes the background operation.
        /// </summary>
        /// <remarks>
        /// Will return <see langword="null"/> if the background operation hasn't started.
        /// </remarks>
        public virtual Thread ExecuteThread() => _executeThread;

        /// <summary>
        /// This method is called when the <see cref="IHostedService"/> starts. The implementation should return a thread that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        protected abstract void ExecuteAsync();

        /// <inheritdoc />
        public virtual void StartAsync()
        {
            // Store the thread we're executing
            _executeThread = new Thread(() =>
            {
                ExecuteAsync();
            });
        }

        /// <inheritdoc />
        public virtual void StopAsync()
        {
            if (_executeThread == null)
            {
                return;
            }

            // Signal cancellation to the executing method
            IsCancellationRequested = true;

            // Wait for thread to exit
            _executeThread.Join();
            _executeThread = null;
        }

        /// <inheritdoc />
        public virtual void Dispose() { }
    }
}