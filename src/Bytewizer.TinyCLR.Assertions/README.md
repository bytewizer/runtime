# Testing Assertions

Provides a testing framework built for TinyCLR OS.

## Simple Unit Test Example
```CSharp
class Program
{
    static void Main()
    {
        var testRunner = new TestRunner();
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
        Assert.True(3 > 4);
    }
}
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packagesq=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Assertions
```