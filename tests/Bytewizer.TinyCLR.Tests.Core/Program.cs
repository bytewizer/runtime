using System.Threading;
using System.Diagnostics;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.TinyCLR.Tests
{
    internal class Program
    {
        static void Main()
        {
            var testRunner = new TestRunner();
            var results = testRunner.Run();

            Debug.WriteLine(results);
            Debug.WriteLine("Test Runner Completed");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}