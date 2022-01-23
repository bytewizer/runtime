using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Bytewizer.NanoCLR.Assertions;

namespace Bytewizer.NanoCLR.Tests
{
    public class Program
    {
        public static void Main()
        {
            Assembly[] assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };

            var testRunner = new TestRunner(assemblies);
            var results = testRunner.Run();

            Debug.WriteLine(results);

            Thread.Sleep(100);
            Debug.WriteLine("Test Runner Completed");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}