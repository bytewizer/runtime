using System;
using System.Text;

using Bytewizer.NanoCLR.Assertions;

namespace Bytewizer.NanoCLR.Tests.CoreTests
{
    public class AssertTest : TestFixture
    {
        public void IsTrueTestCase()
        {
            Assert.True(5 > 4);
        }

        public void IsFalseTestCase()
        {
            Assert.IsFalse(3 > 4);
        }
    }
}
