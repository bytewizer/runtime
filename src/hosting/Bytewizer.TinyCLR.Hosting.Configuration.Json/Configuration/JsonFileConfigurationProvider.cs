//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Json
{
    /// <summary>
    /// Loads configuration key/values from a json file stream into a provider.
    /// </summary>
    public class JsonFileConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">The <see cref="JsonFileConfigurationSource"/>.</param>
        public JsonFileConfigurationProvider(JsonFileConfigurationSource source) : base(source) { }

        /// <summary>
        /// Loads json configuration key/values from a stream into a provider.
        /// </summary>
        /// <param name="stream">The json <see cref="Stream"/> to load configuration data from.</param>
        public override void Load(Stream stream)
        {         
            Data = JsonConfigurationParser.Parse(stream);
        }
    }
}
