using System;

#if NanoCLR
using Bytewizer.NanoCLR.Assertions;
#else
using Bytewizer.TinyCLR.Assertions;
#endif

namespace Bytewizer.TestHarness.Assertions
{
    public class AssertExeceptionTests : TestFixture
    {
        #region Throws
        public void ThrowsSucceedsWithDelegate()
        {
            Assert.Throws(typeof(ArgumentException), delegate { throw new ArgumentException(); });
        }

        public void ThrowsSucceedsWithLambda()
        {
            Assert.Throws(typeof(ArgumentException), () => { throw new ArgumentException(); });
        }
        #endregion
    }
}