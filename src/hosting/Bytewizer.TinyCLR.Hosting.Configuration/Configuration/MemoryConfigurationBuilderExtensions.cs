using System;
using System.Collections;
//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// <see cref="IConfigurationBuilder"/> extension methods for the <see cref="MemoryConfigurationProvider"/>.
    /// </summary>
    public static class MemoryConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an empty memory configuration provider to <paramref name="configurationBuilder"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddInMemoryCollection(
            this IConfigurationBuilder configurationBuilder)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException();
            }

            return configurationBuilder.Add(new MemoryConfigurationSource { InitialData = new Hashtable() });
        }

        /// <summary>
        /// Adds the memory configuration provider to <paramref name="configurationBuilder"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="initialData">The data to add to memory configuration provider.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddInMemoryCollection(
            this IConfigurationBuilder configurationBuilder,
            Hashtable initialData)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException();
            }

            return configurationBuilder.Add(new MemoryConfigurationSource { InitialData = initialData });
        }
    }
}