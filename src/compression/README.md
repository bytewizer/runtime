# Compression

Provides deflate, gzip, and zip compression methods built for TinyCLR OS and .NET nanoFramework.

```CSharp
static void Main()
{
    var message = "ZVCArOoMrdsyWqsIIKuabQLezxmQAyTTeGvyEBzRflhBawSGqcUgioZBMKxhJNXvWOLTWfADSnbz" + 
    "ZSMuOKbaApXvkWIBfmtveNhcrwEgdrMypxajucTAvQIrnXLSYiOjezNMcnpMCddwhbLNBZgIFUSHBEKVgpEsMQxqcI" + 
    "jweZxgOEOWRIyuoqzrMIBFUevWHeHuBpdRLacOSQYHxYRCrJuljsXFSJXLZGUhaVSMXqkaejuAsGNlYFjyZKMiUvMd" + 
    "ORrEjYrTDMVLdEJDbGihHJZCDbgDZKnHZxlJZECVXxwAJOsfLTpWNJtLnvOPHzrPMtHmUARQVuecpfICYHnJDWrLhG" + 
    "FKzFRqzRLVVbBWHEukqVtaWSZzMTRNlQgjbpYctlBRAMKPwrscGHGkFCNRKKjUWTxVMfArEWGzCQtscyCVJCtHFUJK" +
    "GoHRsPDddYPACxufiOOaykKnqqIMhFFoIGAbmDNUFNNCUZaTDCAhdvAqjQmLWlTt";

    
    var bytes = Compress(Encoding.UTF8.GetBytes(message));
    var percent =  (1 - (double)bytes.Length / message.ToCharArray().Length) * 100;

    Debug.WriteLine($"Orginal / Compressed Message Size: {message.ToCharArray().Length} / {bytes.Length} = {percent:N2}%");

    var decompressMessage = Encoding.UTF8.GetString(Uncompress(bytes));

    Debug.WriteLine($"Orginal Message:      {message}");
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
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packagesq=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Compression
PM> Install-Package Bytewizer.TinyCLR.Compression.Zip
PM> Install-Package Bytewizer.TinyCLR.Compression.GZip
```
## .NET nanoFramework Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.nanoclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.NanoCLR.Compression
PM> Install-Package Bytewizer.NanoCLR.Compression.Zip
PM> Install-Package Bytewizer.NanoCLR.Compression.GZip
```

## RFC - Related Request for Comments 
- [RFC 2616 - DEFLATE Compressed Data Format Specification](https://tools.ietf.org/html/rfc1951)