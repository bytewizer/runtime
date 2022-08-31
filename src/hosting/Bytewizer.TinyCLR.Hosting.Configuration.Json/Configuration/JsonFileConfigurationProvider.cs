//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Json
{
    /// <summary>
    /// Loads configuration key/values from a JSON file stream into a provider.
    /// </summary>
    public class JsonFileConfigurationProvider : ConfigurationProvider
    {
        private bool _loaded;

        /// <summary>
        /// The source settings for this provider.
        /// </summary>
        public JsonFileConfigurationSource Source { get; }

        /// <summary>
        /// Initializes a new <see cref="JsonFileConfigurationProvider"/>
        /// </summary>
        /// <param name="source">The <see cref="JsonFileConfigurationSource"/>.</param>
        public JsonFileConfigurationProvider(JsonFileConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            Source = source;
        }

        /// <summary>
        /// Generates a string representing this provider name and relevant details.
        /// </summary>
        /// <returns> The configuration name. </returns>
        public override string ToString()
            => $"{GetType().Name} for '{Source.Path}' ({(Source.Optional ? "optional" : "required")})";

        /// <summary>
        /// Loads JSON configuration key/values from a stream into a provider.
        /// </summary>
        /// <param name="stream">The json <see cref="Stream"/> to load configuration data from.</param>
        public void Load(Stream stream)
        {         
            Data = JsonConfigurationParser.Parse(stream);
        }

        /// <summary>
        /// Load the configuration data from the stream. Will throw after the first call.
        /// </summary>
        public override void Load()
        {
            if (_loaded)
            {
                throw new InvalidOperationException();
            }

            try
            {
                var filePath = Path.Combine(Source.DriveProvider.Name, Source.Path);
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                Load(stream);
            }
            catch (Exception ex)
            {
                if (Source.Optional == false)
                {
                    throw ex;
                }
            }

            _loaded = true;
        }
    }
}
