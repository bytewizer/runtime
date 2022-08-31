//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    /// <summary>
    /// Loads configuration key/values from an INI stream into a provider.
    /// </summary>
    public class IniStreamConfigurationProvider : StreamConfigurationProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">The <see cref="IniStreamConfigurationSource"/>.</param>
        public IniStreamConfigurationProvider(IniStreamConfigurationSource source) 
            : base(source) { }

        /// <summary>
        /// Loads INI configuration key/values from a stream into a provider.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to load ini configuration data from.</param>
        public override void Load(Stream stream)
        {
            Data = IniConfigurationParser.Parse(stream);
        }
    }
}
