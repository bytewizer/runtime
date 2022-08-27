//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// The root node for a configuration.
    /// </summary>
    public class ConfigurationRoot : IConfigurationRoot, IDisposable
    {
        private readonly ArrayList _providers;

        /// <summary>
        /// Initializes a Configuration root with a list of providers.
        /// </summary>
        /// <param name="providers">The <see cref="IConfigurationProvider"/>s for this configuration.</param>
        public ConfigurationRoot(ArrayList providers)
        {
            if (providers == null)
            {
                throw new ArgumentNullException();
            }

            _providers = providers;

            foreach (IConfigurationProvider provider in providers)
            {
                provider.Load();
            }
        }

        /// <summary>
        /// The <see cref="IConfigurationProvider"/>s for this configuration.
        /// </summary>
        public IEnumerable Providers => _providers;

        /// <summary>
        /// Gets or sets the value corresponding to a configuration key.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        public object this[string key]
        {
            get => GetConfiguration(_providers, key);
            set => SetConfiguration(_providers, key, value);
        }

        /// <summary>
        /// Force the configuration values to be reloaded from the underlying sources.
        /// </summary>
        public void Reload()
        {
            foreach (IConfigurationProvider provider in _providers)
            {
                provider.Load();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {

            // dispose providers
            foreach (IConfigurationProvider provider in _providers)
            {
                ((IDisposable)provider)?.Dispose();
            }
        }

        internal static object GetConfiguration(ArrayList providers, string key)
        {
            for (int index = providers.Count - 1; index >= 0; index--)
            {
                
                IConfigurationProvider provider = (IConfigurationProvider)providers[index];

                if (provider.TryGet(key, out object value))
                {
                    return value;
                }
            }

            return null;
        }

        internal static void SetConfiguration(ArrayList providers, string key, object value)
        {
            if (providers.Count == 0)
            {
                throw new InvalidOperationException();
            }

            foreach (IConfigurationProvider provider in providers)
            {
                provider.Set(key, value);
            }
        }
    }
}
