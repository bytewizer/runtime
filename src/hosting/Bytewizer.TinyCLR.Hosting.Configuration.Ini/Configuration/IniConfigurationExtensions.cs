//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    /// <summary>
    /// Extension methods for adding <see cref="IniStreamConfigurationProvider"/>.
    /// </summary>
    public static class IniConfigurationExtensions
    {
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

