//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Represents a function that can process a service.
    /// </summary>
    /// <param name="builder">The delegate that configures the <see cref="IConfigurationBuilder"/></param>
    public delegate void ConfigurationAction(IConfigurationBuilder builder);
}
