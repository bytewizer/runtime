# Compression

Provides deflate algorithm described in RFC 1951 compression methods built for TinyCLR OS.

## Simple Example
```CSharp
class Program
{
    static void Main()
    {
        var message = "Effect if in up no depend seemed. Ecstatic elegance gay but disposed. We me rent been part what. An concluded sportsman " +
            "offending so provision mr education. Bed uncommonly his discovered for estimating far. Equally he minutes my hastily. Up hung mr we" +
            " give rest half. Painful so he an comfort is manners.";

            
        Debug.WriteLine($"Orginal Message Size: {message.ToCharArray().Length}");

        var bytes = Compress(Encoding.UTF8.GetBytes(message));
        Debug.WriteLine($"Compressed Message Size: {bytes.Length}");

        var decompressMessage = Encoding.UTF8.GetString(Uncompress(bytes));

        Debug.WriteLine($"Orginal Message: {message}");
        Debug.WriteLine($"Uncompressed Message: {decompressMessage}");
           
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
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packagesq=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Compression
```