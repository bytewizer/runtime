using System;
using System.Text;

#if NanoCLR
namespace Bytewizer.NanoCLR
#else
namespace Bytewizer.TinyCLR
#endif
{
    /// <summary>
    /// Contains extension methods for <see cref="byte"/> array object.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Compares this instance to a specified byte array and returns an indication of their relative values.
        /// </summary>
        /// <param name="first">The source byte array.</param>
        /// <param name="second">The byte array to compare.</param>
        public static bool IsEqual(this byte[] first, byte[] second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null)
            {
                return false;
            }

            if (second == null)
            {
                return false;
            }

            if (first.Length != second.Length)
            {
                return false;
            }

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Reverses the sequence of a subset of the elements in the one-dimensional Array.
        /// </summary>
        /// <param name="source">The one-dimensional byte array to reverse.</param>
        public static byte[] Reverse(this byte[] source)
        {
            return Reverse(source, 0, source.Length);
        }

        /// <summary>
        /// Reverses the sequence of a subset of the elements in the one-dimensional Array.
        /// </summary>
        /// <param name="source">The one-dimensional Array to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="count">The number of elements in the section to reverse.</param>
        public static byte[] Reverse(this byte[] source, int index, int count)
        {
            var taken = Take(source, index, count);

            int j = taken.Length - 1;
            for (int i = 0; i < j; i++, j--)
            {
                byte z = taken[i];
                taken[i] = taken[j];
                taken[j] = z;
            }

            return taken;
        }

        /// <summary>
        /// Bypasses a specified number of elements in a sequence and then returns the remaining elements.
        /// </summary>
        /// <param name="source">The array to return a number of bytes from.</param>
        /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
        public static byte[] Skip(this byte[] source, int count)
        {
            return Take(source, count, source.Length - count);
        }

        /// <summary>
        /// Returns a specified number of contiguous bytes.
        /// </summary>
        /// <param name="source">The array to return a number of bytes from.</param>
        /// <param name="count">The number of bytes to take from <paramref name="source"/>.</param>
        public static byte[] Take(this byte[] source, int count)
        {
            return Take(source, 0, count);
        }

        /// <summary>
        /// Returns a specified number of contiguous bytes from a given offset.
        /// </summary>
        /// <param name="source">The array to return a number of bytes from.</param>
        /// <param name="index">The zero-based offset in <paramref name="source"/> at which to begin taking bytes.</param>
        /// <param name="count">The number of bytes to take from <paramref name="source"/>.</param>
        public static byte[] Take(this byte[] source, int index, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (count < 1)
            {
                return new byte[0];
            }

            if (index == 0 && source.Length == count)
            {
                return source;
            }

            var taken = new byte[count];
            Array.Copy(source, index, taken, 0, count);

            return taken;
        }

        /// <summary>
        /// Concatenates the given arrays into a single array.
        /// </summary>
        /// <param name="first">The first sequence to concatenate.</param>
        /// <param name="second">The sequence to concatenate to the first sequence.</param>
        public static byte[] Concat(this byte[] first, byte[] second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            var bytes = new byte[first.Length + second.Length];

            Array.Copy(first, bytes, first.Length);
            Array.Copy(second, 0, bytes, first.Length, second.Length);

            return bytes;
        }

        /// <summary>
        /// Creates a hex string from an array.
        /// </summary>
        /// <param name="source">The array to create the hex string.</param>
        public static string ToHex(this byte[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var sb = new StringBuilder(source.Length * 2);

            foreach (byte item in source)
            {
                sb.Append(item.ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates a UTF8 encoded string from an array.
        /// </summary>
        /// <param name="source">The array to create the UTF8 encoded string.</param>
        public static string ToUTF8(this byte[] source)
        {
            return Encoding.UTF8.GetString(source, 0, source.Length);
        }
    }
}