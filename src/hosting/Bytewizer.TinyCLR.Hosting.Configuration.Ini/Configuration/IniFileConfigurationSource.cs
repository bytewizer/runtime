//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using GHIElectronics.TinyCLR.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    /// <summary>
    /// Represents a INI file as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class IniFileConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Determines if loading the file is optional.
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// The drive provider to the file.
        /// </summary>
        public IDriveProvider DriveProvider { get; set; }

        /// <summary>
        /// Builds the <see cref="IniFileConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>An <see cref="IniFileConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new IniFileConfigurationProvider(this);
    }
}

