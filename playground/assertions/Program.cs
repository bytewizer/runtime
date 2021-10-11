using System;
using System.Reflection;
using System.Collections;
using System.Diagnostics;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    class Program
    {
        static void Main()
        {
            var testRunner = new TestRunner();
            var results = testRunner.Run();

            Debug.WriteLine(results);
        }
    }

    // Test class must inherit from the TestFixture class
    public class UnitTests : TestFixture
    {
        // Constructors must containe no parameters
        public UnitTests()
        {
            Debug.WriteLine("Invoked constructors before tests run");
        }

        // Test method must be public and void
        public void IsTrueTestCase()
        {
            Assert.True(4 > 3);
        }
    }
}