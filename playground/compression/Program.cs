using System;
using System.Text;
using System.Diagnostics;
using System.IO;

using Bytewizer.TinyCLR;
using Bytewizer.TinyCLR.IO.Compression;

namespace Bytewizer.Playground.Compression
{
    class Program
    {
        static void Main()
        {
            string text = "The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog.";
            byte[] data = Encoding.UTF8.GetBytes(text);

            byte[] compressBytes;
            using (var stream = new MemoryStream(data))
            {
                compressBytes = GetCompressBytes(stream);
            }

            byte[] decompressBytes = GetDecompressBytes(compressBytes);

            //Debug.WriteLine(BitConverter.ToString(data));
            Debug.WriteLine($"Compressed: {BitConverter.ToString(compressBytes)}");
            Debug.WriteLine($"Decompressed: {BitConverter.ToString(decompressBytes)}");
            Debug.WriteLine($"Bytes Checked: {CheckBytes(data, decompressBytes)}");
            Debug.WriteLine($"Message: {Encoding.UTF8.GetString(decompressBytes)}");

        }
        public static byte[] GetCompressBytes(Stream input)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                input.CopyTo(zipStream);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }

        private static byte[] GetDecompressBytes(byte[] input)
        {
            var output = new MemoryStream();

            using (var compressStream = new MemoryStream(input))
            {
                using (var decompressor = new GZipStream(compressStream, CompressionMode.Decompress))
                {
                    decompressor.CopyTo(output);

                    output.Position = 0;
                    return output.ToArray();
                }
            }
        }
        static bool CheckBytes(byte[] data1, byte[] data2)
        {
            if (data1.Length != data2.Length) return false;
            for (int i = 0; i < data2.Length; i++)
                if (data1[i] != data2[i]) return false;
            return true;
        }
    }
}