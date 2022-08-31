namespace Bytewizer.TinyCLR.Hosting
{
    /// <summary>
    /// <see cref="IConfiguration"/> extension methods.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Extracts the value with the specified key and converts it to a <see cref="string"/>.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="key">The key of the configuration section's value to convert.</param>
        public static string GetValue(this IConfiguration configuration, string key)
        {            
            if (configuration == null)
            {
                return null;
            }
            
            return (string)configuration[key];
        }

        /// <summary>
        /// Extracts the value with the specified key and converts it to a <see cref="string"/>.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="key">The key of the configuration section's value to convert.</param>
        /// <param name="defaultValue">The default value to use if no value is found.</param>
        public static string GetValue(this IConfiguration configuration, string key, string defaultValue)
        {
            if (configuration == null)
            {
                return null;
            }

            return (string)GetValueOrDefault(configuration, key, defaultValue);
        }

        /// <summary>
        /// Extracts the value with the specified key or sets to default value.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="key">The key of the configuration section's value to convert.</param>
        /// <param name="defaultValue">The default value to use if no value is found.</param>
        public static object GetValueOrDefault(this IConfiguration configuration, string key, object defaultValue)
        {
            if (configuration == null)
            {
                return null;
            }

            var value = configuration[key];

            if (value == null)
            {
                return defaultValue;
            }

            var type = defaultValue.GetType();
            
            if (type == typeof(string)) return (string)value;
            if (type == typeof(bool)) return ((string)value).ToBoolean();
            if (type == typeof(int)) return int.Parse((string)value);
            if (type == typeof(uint)) return uint.Parse((string)value);
            if (type == typeof(byte)) return byte.Parse((string)value);
            if (type == typeof(sbyte)) return sbyte.Parse((string)value);
            if (type == typeof(short)) return short.Parse((string)value);
            if (type == typeof(ushort)) return ushort.Parse((string)value);
            if (type == typeof(long)) return long.Parse((string)value);
            if (type == typeof(ulong)) return ulong.Parse((string)value);
            if (type == typeof(double)) return double.Parse((string)value);

            return value;
        }
    }

    internal static class StringExtensions
    {
        public static bool ToBoolean(this string value)
        {
            switch (value.ToLower().Trim())
            {
                case "true":
                    return true;
                case "1":
                    return true;
                case "false":
                    return false;
                case "0":
                    return false;
                default:
                    return false;
            }
        }
    }
}
