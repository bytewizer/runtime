using System;
using System.Text;

namespace Bytewizer.TinyCLR.Utilities
{
    /// <summary>
    /// Contains various string-related tools and utilities.
    /// </summary>
    public class StringUtilities
    {
        /// <summary>
        /// Returns a random string of the desired size.
        /// </summary>
        /// <param name="size">Size of the random string to return</param>
        /// <returns>The resulting string</returns>
        public static string GetRandomString(int size)
        {
            Random random = new Random();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.Append(Convert.ToChar(Convert.ToUInt16(Math.Floor((26 * random.NextDouble()) + 65).ToString())));
            }

            return sb.ToString();
        }
    }
}
