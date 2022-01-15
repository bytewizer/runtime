using System;

namespace Bytewizer.TinyCLR.Utilities
{
    /// <summary>
    /// Contains various byte array-related extensions.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Trims the length of a byte array.
        /// </summary>
        /// <param name="bytes">Byte array to trim.</param>
        /// <param name="length">Number of bytes to trim.</param>
        /// <returns>The resulting byte array.</returns>
        public static byte[] Trim(this byte[] bytes, int length)
        {
            byte[] result = new byte[bytes.Length - length];

            Array.Copy(bytes, result, bytes.Length - length);

            return result;
        }

        /// <summary>
        /// Trim zero 
        /// </summary>
        /// <param name="arr"></param>
        public static byte[] TrimZero(this byte[] arr)
        {
            // get left position
            int left = 0;
            for (left = 0; left < arr.Length && arr[left] == 0; left++) ;

            // get from right 
            int right;
            for (right = 0; right < arr.Length && arr[arr.Length - right - 1] == 0; right++) ;

            // nothing to do
            if (left == 0 && right == 0)
            {
                return arr;
            }

            // trim and return 
            byte[] ret = new byte[arr.Length - left - right];
            Array.Copy(arr, left, ret, 0, arr.Length - left - right);
            return ret;

        }

        /// <summary>
        /// Pads with leading zeros if needed.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="length">The length to pad to.</param>
        public static byte[] Pad(this byte[] data, int length)
        {
            if (length <= data.Length)
                return data;
            var newData = new byte[length];
            Array.Copy(data, 0, newData, newData.Length - data.Length, data.Length);

            return newData;
        }
    }
}