// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Represents a function that can process a provider.
    /// </summary>
    /// <param name="configure">The delegate that configures the <see cref="ServiceProviderOptions"/>.</param>
    public delegate void ProviderAction(ServiceProviderOptions configure);
}
