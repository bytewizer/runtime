//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    /// <summary>
    /// An INI file based <see cref="StreamConfigurationProvider"/>.
    /// </summary>
    public class IniStreamConfigurationProvider : StreamConfigurationProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">The <see cref="IniStreamConfigurationSource"/>.</param>
        public IniStreamConfigurationProvider(IniStreamConfigurationSource source) : base(source) { }

        /// <summary>
        /// Read a stream of INI values into a key/value dictionary.
        /// </summary>
        /// <param name="stream">The stream of INI data.</param>
        /// <returns>The <see cref="Hashtable"/> which was read from the stream.</returns>
        public static Hashtable Read(Stream stream)
        {
            var data = new Hashtable();
            
            using (var reader = new StreamReader(stream))
            {
                string sectionPrefix = string.Empty;

                while (reader.Peek() != -1)
                {
                    string rawLine = reader.ReadLine()!; // Since Peak didn't return -1, stream hasn't ended.
                    string line = rawLine.Trim();

                    // Ignore blank lines
                    //if (string.IsNullOrWhiteSpace(line))
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    // Ignore comments
                    if (line[0] is ';' or '#' or '/')
                    {
                        continue;
                    }
                    // [Section:header]
                    if (line[0] == '[' && line[line.Length - 1] == ']')
                    {
                        // remove the brackets
                        sectionPrefix = line.Substring(1, line.Length - 2).Trim() + ":";

                        continue;
                    }

                    // key = value OR "value"
                    int separator = line.IndexOf('=');
                    if (separator < 0)
                    {
                        throw new FormatException(rawLine);
                    }

                    string key = sectionPrefix + line.Substring(0, separator).Trim();
                    string value = line.Substring(separator + 1).Trim();

                    // Remove quotes
                    if (value.Length > 1 && value[0] == '"' && value[value.Length - 1] == '"')
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    if (data.Contains(key))
                    {
                        throw new FormatException(key);
                    }

                    data[key.ToLower()] = value;
                }
            }
            return data;
        }

        /// <summary>
        /// Loads INI configuration key/values from a stream into a provider.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to load ini configuration data from.</param>
        public override void Load(Stream stream)
        {
            Data = Read(stream);
        }
    }
}
