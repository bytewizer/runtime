using System;
using System.IO;
using System.Text;
using System.Diagnostics;

using Bytewizer.TinyCLR.IO.Zip;
using Bytewizer.TinyCLR.IO.GZip;
using Bytewizer.TinyCLR.IO.Compression;

using GHIElectronics.TinyCLR.IO;
using GHIElectronics.TinyCLR.Pins;
using GHIElectronics.TinyCLR.Devices.Storage;
using Bytewizer.TinyCLR.IO;

namespace Bytewizer.Playground.Compression
{
    class Program
    {
        static void Main()
        {
            var sd = StorageController.FromName(SC20260.StorageController.SdCard);
            var drive = FileSystem.Mount(sd.Hdc);

            var message = "Effect if in up no depend seemed. Ecstatic elegance gay but disposed. We me rent been part what. An concluded sportsman " +
                "offending so provision mr education. Bed uncommonly his discovered for estimating far. Equally he minutes my hastily. Up hung mr we" +
                " give rest half. Painful so he an comfort is manners.";

            
            var bytes = Compress(Encoding.UTF8.GetBytes(message));
            var percent =  (1 - (double)bytes.Length / message.ToCharArray().Length) * 100;

            Debug.WriteLine($"Orginal / Compressed Message Size: {message.ToCharArray().Length} / {bytes.Length} = {percent:N2}%");

            var decompressMessage = Encoding.UTF8.GetString(Uncompress(bytes));

            Debug.WriteLine($"Orginal Message:      {message}");
            Debug.WriteLine($"Uncompressed Message: {decompressMessage}");

            var file = File.OpenRead(@"sample.zip");

            ZipFile zFile = new ZipFile(file);
            Debug.WriteLine("Listing of : " + zFile.Name);
            Debug.WriteLine("");
            Debug.WriteLine("Raw Size    Size      Date     Time     Name");
            Debug.WriteLine("--------  --------  --------  ------  ---------");
            foreach (ZipEntry e in zFile)
            {
                DateTime d = e.DateTime;
                Debug.WriteLine(String.Format("{0, -10}{1, -10}{2}  {3}   {4}", e.Size, e.CompressedSize,
                d.ToString("dd-MM-yy"), d.ToString("t"), e.Name));
            }

            ZipInputStream s = new ZipInputStream(file);

            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                int size = 2048;
                byte[] data = new byte[2048];


                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            Debug.WriteLine(Encoding.UTF8.GetString(data, 0, size));
                        }
                        else
                        {
                            break;
                        }
                    }
            }
            s.Close();


            var file2 = File.OpenRead(@"sample.gz");

            GZipInputStream s2 = new GZipInputStream(file2);

            while (true)
            {
                int size = 2048;
                byte[] data = new byte[2048];

                while (true)
                {
                    size = s2.Read(data, 0, data.Length);
                    if (size > 0)
                    {
                        Debug.WriteLine(Encoding.UTF8.GetString(data, 0, size));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            s.Close();

        }

        public static byte[] Compress(byte[] input)
        {
            // Create the compressor with highest level of compression  
            Deflater compressor = new Deflater();
            compressor.SetLevel(Deflater.BEST_COMPRESSION);

            // Give the compressor the data to compress  
            compressor.SetInput(input);
            compressor.Finish();

            MemoryStream bos = new MemoryStream(input.Length);

            // Compress the data  
            byte[] buf = new byte[1024];
            while (!compressor.IsFinished)
            {
                int count = compressor.Deflate(buf);
                bos.Write(buf, 0, count);
            }

            // Get the compressed data  
            return bos.ToArray();
        }

        public static byte[] Uncompress(byte[] input)
        {
            Inflater decompressor = new Inflater();
            decompressor.SetInput(input);

            // Create an expandable byte array to hold the decompressed data  
            MemoryStream bos = new MemoryStream(input.Length);

            // Decompress the data  
            byte[] buf = new byte[1024];
            while (!decompressor.IsFinished)
            {
                int count = decompressor.Inflate(buf);
                bos.Write(buf, 0, count);
            }

            // Get the decompressed data  
            return bos.ToArray();
        }
    }
}