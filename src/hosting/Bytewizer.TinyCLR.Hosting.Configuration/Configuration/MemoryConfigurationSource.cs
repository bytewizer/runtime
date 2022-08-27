using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Represents in-memory data as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class MemoryConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The initial key value configuration pairs.
        /// </summary>
        public Hashtable InitialData { get; set; }

        /// <summary>
        /// Builds the <see cref="MemoryConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="MemoryConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MemoryConfigurationProvider(this);
        }
    }
}

