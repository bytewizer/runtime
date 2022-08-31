//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;
using System.Collections;

using GHIElectronics.TinyCLR.Data.Json;

namespace Bytewizer.TinyCLR.Hosting.Configuration.Json
{
    internal sealed class JsonConfigurationParser
    {
        private readonly Hashtable _data = new Hashtable();

        public static Hashtable Parse(Stream input)
            => new JsonConfigurationParser().ParseStream(input);

        private Hashtable ParseStream(Stream input)
        {
            try
            {
                JToken token = JsonConverter.Deserialize(input);

                if (token is JObject jobj)
                {
                    foreach (JProperty member in jobj.Members)
                    {                        
                        foreach (DictionaryEntry pair in GetNode(member))
                        {
                            _data.Add(
                                    pair.Key.ToString().ToLower(), 
                                    pair.Value.ToString().Trim('"').TrimEnd('"')
                                );
                        }
                    }
                }

                if (token is JArray jarray)
                {
                    for (int i = 0; i < jarray.Length; i++)
                    {
                        var property = new JProperty($"root{i}", jarray[i]);
                        
                        foreach (DictionaryEntry pair in GetNode(property))
                        {
                            _data.Add(
                                    pair.Key.ToString().ToLower(),
                                    pair.Value.ToString().Trim('"').TrimEnd('"')
                                );
                        }
                    }
                }
            }
            catch
            {
                throw new FormatException("Failed to parse json file.");
            }

            return _data;
        }

        private static ArrayList GetNode(JProperty node)
        {
            var items = new ArrayList();

            if (node.Value is JObject jobj)
            {
                foreach (JProperty member in jobj.Members)
                {
                    var key = string.Concat(node.Name, ":", member.Name);
                    var values = GetNode(new JProperty(key, member.Value));

                    foreach (DictionaryEntry pair in values)
                    {
                        items.Add(pair);
                    }
                }

                return items;
            }

            if (node.Value is JArray jarray)
            {
                for (int i = 0; i < jarray.Length; i++)
                {
                    var key = string.Concat(node.Name, ":", i);
                    var values = GetNode(new JProperty(key, jarray[i]));

                    foreach (DictionaryEntry pair in values)
                    {
                        items.Add(pair);
                    }
                }

                return items;
            }

            items.Add(new DictionaryEntry (node.Name, node.Value));

            return items;
        }
    }
}

