//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.IO;
using System.Collections;
using System.Diagnostics;

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
                        var property = new JProperty(member.Name, member.Value);
                        
                        foreach (DictionaryEntry pair in GetNode(property))
                        {
                            Debug.WriteLine($"{pair.Key} = {pair.Value}");
                            _data.Add(pair.Key.ToString().ToLower(), pair.Value.ToString());
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
                            Debug.WriteLine($"{pair.Key} = {pair.Value}");
                            _data.Add(pair.Key.ToString().ToLower(), pair.Value.ToString());
                        }
                    }
                }
            }
            catch
            {
                throw new FormatException();
            }

            return _data;
        }

        private static Hashtable GetNode(JProperty node)
        {
            var items = new Hashtable();

            if (node.Value is JObject jobj)
            {
                foreach (JProperty property in jobj.Members)
                {
                    var key = string.Concat(node.Name, ":", property.Name);
                    var values = GetNode(new JProperty(key, property.Value));

                    foreach (DictionaryEntry pair in values)
                    {
                        items.Add(pair.Key, pair.Value);
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
                        items.Add(pair.Key, pair.Value);
                    }
                }

                return items;
            }

            items.Add(node.Name, node.Value);

            return items;
        }
    }
}

