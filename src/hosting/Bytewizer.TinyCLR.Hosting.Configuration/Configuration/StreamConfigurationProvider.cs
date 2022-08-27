using System;
using System.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Stream based configuration provider
    /// </summary>
    public abstract class StreamConfigurationProvider : ConfigurationProvider
    {
        /// <summary>
        /// The source settings for this provider.
        /// </summary>
        public StreamConfigurationSource Source { get; }

        private bool _loaded;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">The source.</param>
        public StreamConfigurationProvider(StreamConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            Source = source;
        }

        /// <summary>
        /// Load the configuration data from the stream.
        /// </summary>
        /// <param name="stream">The data stream.</param>
        public abstract void Load(Stream stream);

        /// <summary>
        /// Load the configuration data from the stream. Will throw after the first call.
        /// </summary>
        public override void Load()
        {
            if (_loaded)
            {
                throw new InvalidOperationException();
            }

            if (Source.Stream == null)
            {
                throw new InvalidOperationException();
            }

            Load(Source.Stream);
            _loaded = true;
        }
    }
}
