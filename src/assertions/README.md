# Testing Assertions

Provides a testing framework built for TinyCLR OS and .NET nanoFramework. This includes a full set of asserts including comparisons, conditions, equality, exceptions, types, collections, and strings.

## Simple Unit Test Example
```CSharp
class Program
{
    static void Main()
    {
        Assembly[] assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };

        var testRunner = new TestRunner(assemblies);
        testRunner.Run();
        Debug.WriteLine(testRunner.Results());
    }
}

// Test class must inherit from the TestFixture class
public class UnitTests : TestFixture
{
    // Test method must be public and void
    public void IsTrueTestCase()
    {
        Assert.True(5 > 4);
    }
}
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packagesq=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Assertions
```

## .NET nanoFramework Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.nanoclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.NanoCLR.Assertions
```