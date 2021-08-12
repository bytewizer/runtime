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
            testRunner.Run();
            testRunner.DebugResults();
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
}