using System;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
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