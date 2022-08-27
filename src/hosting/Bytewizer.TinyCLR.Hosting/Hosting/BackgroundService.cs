// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;

namespace Bytewizer.TinyCLR.Hosting

{
    /// <summary>
    /// Base class for implementing a long running <see cref="IHostedService"/>.
    /// </summary>
    public abstract class BackgroundService : IHostedService
    {
        private Thread _executeThread;

        /// <summary>
        /// Gets or sets the amount of time to wait for the <see cref="ExecuteThread"/> to terminate.
        /// </summary>
        protected TimeSpan ShutdownTimeout { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Gets or sets whether cancellation has been requested for this service.
        /// </summary>
        protected bool CancellationRequested { get; set; } = false;

        /// <summary>
        /// Gets the <see cref="Thread"/> that executes the background operation.
        /// </summary>
        /// <remarks>
        /// Will return <see langword="null"/> if the background operation hasn't started.
        /// </remarks>
        public virtual Thread ExecuteThread() => _executeThread;

        /// <summary>
        /// This method is called when the <see cref="IHostedService"/> starts.
        /// </summary>
        protected abstract void ExecuteAsync();

        /// <inheritdoc />
        public virtual void Start()
        {
            // Store the thread we're executing
            _executeThread = new Thread(() =>
            {
                ExecuteAsync();
            });
        }

        /// <inheritdoc />
        public virtual void Stop()
        {
            if (_executeThread == null)
            {
                return;
            }

            // Signal cancellation to the executing method
            CancellationRequested = true;

            try
            {
                // Wait for thread to exit
                _executeThread.Join(ShutdownTimeout);
            }
            finally
            {
                _executeThread = null;
            }
        }
    }
}