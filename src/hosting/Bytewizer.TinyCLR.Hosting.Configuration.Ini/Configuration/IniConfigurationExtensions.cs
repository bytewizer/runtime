//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;

using GHIElectronics.TinyCLR.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    /// <summary>
    /// Extension methods for adding <see cref="IniStreamConfigurationProvider"/>.
    /// </summary>
    public static class IniConfigurationExtensions
    {
        /// <summary>
        /// Adds the INI configuration provider at <paramref name="path"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="driveProvider">The drive provider to the file.</param>
        /// <param name="path">Path relative to the base path stored in
        /// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddIniFile(this IConfigurationBuilder builder, IDriveProvider driveProvider, string path, bool optional)
        {
            if (builder == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            return builder.Add(new IniFileConfigurationSource()
            { Path = path, Optional = optional, DriveProvider = driveProvider });
        }

        /// <summary>
        /// Adds a INI configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="stream">The <see cref="Stream"/> to read the ini configuration data from.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddIniStream(this IConfigurationBuilder builder, Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException();
            }

            return builder.Add(new IniStreamConfigurationSource() { Stream = stream });
        }
    }
}

