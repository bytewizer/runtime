using System;
using System.Text;

namespace Bytewizer.TinyCLR.Utilities
{
    /// <summary>
    /// Contains various array-related tools and utilities.
    /// </summary>
    public class ByteArrayUtilities
    {
        /// <summary>
        /// Reverses a the payload <paramref name="data" />
        /// </summary>
        /// <param name="data">The payload to reverse</param>
        /// <returns><paramref name="data" /> reversed in place</returns>
        public static void Reverse(byte[] data)
        {
            if (data != null && data.Length > 1)
            {
                int length = data.Length;
                for (var n = 0; n < length / 2; ++n)
                {
                    byte temp = data[length - n - 1];
                    data[length - n - 1] = data[n];
                    data[n] = temp;
                }
            }
        }

        /// <summary>
        /// Concatenates the given arrays into a single array.
        /// </summary>
        /// <param name="byteArrays">The arrays to concatenate</param>
        /// <returns>The concatenated resulting array.</returns>
        public static byte[] Concat(params byte[][] byteArrays)
        {
            int size = 0;
            foreach (byte[] btArray in byteArrays)
            {
                size += btArray.Length;
            }

            if (size <= 0)
            {
                return new byte[0];
            }

            byte[] result = new byte[size];
            int idx = 0;
            foreach (byte[] btArray in byteArrays)
            {
                Array.Copy(btArray, 0, result, idx, btArray.Length);
                idx += btArray.Length;
            }

            return result;
        }

        /// <summary>
        /// Checks if the buffer passed in is entirely full of nulls
        /// </summary>
        public static bool IsEntirelyNull(byte[] buffer)
        {
            foreach (byte b in buffer)
            {
                if (b != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Converts to a string containing the buffer described in hex
        /// </summary>
        public static string DescribeAsHex(byte[] buffer, string separator, int bytesPerLine)
        {
            StringBuilder sb = new StringBuilder();

            int n = 0;
            foreach (byte b in buffer)
            {
                sb.Append(string.Format("{0:X2}{1}", b, separator));
                if (++n % bytesPerLine == 0)
                {
                    sb.Append("\r\n");
                }
            }

            sb.Append("\r\n");
            return sb.ToString();
        }
    }
}