//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.IO;
using GHIElectronics.TinyCLR.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Json
{
    /// <summary>
    /// File based <see cref="IConfigurationSource" />.
    /// </summary>
    public abstract class FileConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The stream containing the configuration data.
        /// </summary>
        public Stream Stream { get; set; }

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
        /// Builds the <see cref="FileConfigurationSource"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>An <see cref="IConfigurationProvider"/></returns>
        public abstract IConfigurationProvider Build(IConfigurationBuilder builder);
    }
}

