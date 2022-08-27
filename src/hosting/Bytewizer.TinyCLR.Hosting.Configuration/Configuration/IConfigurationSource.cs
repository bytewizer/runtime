//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Represents a source of configuration key/values for an application.
    /// </summary>
    public interface IConfigurationSource
    {
        /// <summary>
        /// Builds the <see cref="IConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>An <see cref="IConfigurationProvider"/></returns>
        IConfigurationProvider Build(IConfigurationBuilder builder);
    }
}
