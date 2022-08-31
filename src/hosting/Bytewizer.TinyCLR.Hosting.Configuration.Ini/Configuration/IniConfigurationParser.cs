//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Ini
{
    internal sealed class IniConfigurationParser
    {
        private readonly Hashtable _data = new Hashtable();

        public static Hashtable Parse(Stream input)
            => new IniConfigurationParser().ParseStream(input);

        private Hashtable ParseStream(Stream input)
        {
            try
            {
                using (var reader = new StreamReader(input))
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

                        if (_data.Contains(key))
                        {
                            throw new FormatException(key);
                        }

                        _data[key.ToLower()] = value;
                    }
                }
            }
            catch
            {
                throw new FormatException("Failed to parse ini file.");
            }

            return _data;
        }
    }
}

