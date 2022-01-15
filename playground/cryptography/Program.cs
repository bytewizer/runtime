using System.Diagnostics;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Cryptography
{
    internal class Program
    {
        static void Main()
        {
            var testRunner = new TestRunner();
            var results = testRunner.Run();

            Debug.WriteLine(results);
        }
    }
}
