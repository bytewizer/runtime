using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// In-memory implementation of <see cref="IConfigurationProvider"/>
    /// </summary>
    public class MemoryConfigurationProvider : ConfigurationProvider
    {
        private readonly MemoryConfigurationSource _source;

        /// <summary>
        /// Initialize a new instance from the source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        public MemoryConfigurationProvider(MemoryConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            _source = source;

            if (_source.InitialData != null)
            {
                foreach (DictionaryEntry pair in _source.InitialData)
                {
                    var searchKey = (string)pair.Key;
                    Data.Add(searchKey.ToLower(), pair.Value);
                }
            }
        }

        /// <summary>
        /// Add a new key and value pair.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <param name="value">The configuration value.</param>
        public void Add(string key, string value)
        {
            Data.Add(key.ToLower(), value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}
