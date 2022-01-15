# Compression

Provides Zip compression methods built for TinyCLR OS.

## Simple Example
```CSharp
class Program
{
    static void Main(string[] args)
    {
        var sd = StorageController.FromName(SC20260.StorageController.SdCard);
        var drive = FileSystem.Mount(sd.Hdc);

        var file = File.OpenRead(@"sample.zip");
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
    }
}
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packagesq=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Compression
```