// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace nanoFramework.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// A program abstraction.
    /// </summary>
    public interface IHost : IDisposable
    {
        /// <summary>
        /// The programs configured services.
        /// </summary>
        IServiceProvider Services { get; }

        /// <summary>
        /// Start the program.
        /// </summary>
        /// <exception cref="AggregateException">One or more hosted services failed to start.</exception>
        void Start();

        /// <summary>
        /// Attempts to gracefully stop the program.
        /// </summary>
        /// <exception cref="AggregateException">One or more hosted services failed to stop.</exception>
        void Stop();
    }
}