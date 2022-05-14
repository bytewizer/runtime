using System.Text;

namespace Bytewizer.TinyCLR.Utilities.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for <see cref="byte"/> array instances.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encodes all the characters in the string into a sequence of UTF8 bytes.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <returns>A byte array containing the results of encoding the set of characters.</returns>
        public static byte[] GetBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the left side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of the string.</returns>
        public static string Left(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(0, length);
        }

        /// <summary>
        /// Returns a new string containing the specified number of characters from the right side of the current string.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in the string, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of the string.</returns>
        public static string Right(this string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }

            return input.Substring(input.Length - length, length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the left side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the left side of the current string where deleted.</returns>
        public static string RemoveLeft(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(length);
        }

        /// <summary>
        /// Returns a new string in which a specified number of characters from the right side of the current string are deleted.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="length">The number of characters to remove. If greater than or equal to the number of characters in the string, an empty string is returned.</param>
        /// <returns>Returns a string in which a specified number of characters from the right side of the current string where deleted.</returns>
        public static string RemoveRight(this string input, int length)
        {
            if (input.Length <= length)
            {
                return string.Empty;
            }

            return input.Substring(0, input.Length - length);
        }

        /// <summary>
        /// Returns a new string by repeating the current string the specified number of times.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="count">The number of times the current string occurs.</param>
        /// <returns>A new string by repeating the current string the specified number of times.</returns>
        public static string Times(this string input, int count)
        {
            var stringBuilder = new StringBuilder();

            while (count-- > 0)
            {
                stringBuilder.Append(input);
            }

            return stringBuilder.ToString();
        }
    }
}
