// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace Bytewizer.NanoCLR.DependencyInjection
#else
namespace Bytewizer.TinyCLR.DependencyInjection
#endif
{
    /// <summary>
    /// The <see cref="System.IDisposable.Dispose"/> method ends the scope lifetime. Once Dispose
    /// is called, any scoped services that have been resolved from
    /// <see cref="IServiceScope.ServiceProvider"/> will be
    /// disposed.
    /// </summary>
    public interface IServiceScope : IDisposable
    {
        /// <summary>
        /// The <see cref="System.IServiceProvider"/> used to resolve dependencies from the scope.
        /// </summary>
        IServiceProvider ServiceProvider { get; }
    }
}