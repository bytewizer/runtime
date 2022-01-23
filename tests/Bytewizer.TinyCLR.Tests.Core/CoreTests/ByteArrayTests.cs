#if NanoCLR
using Bytewizer.NanoCLR;
using Bytewizer.NanoCLR.Assertions;
#else
using Bytewizer.TinyCLR;
using Bytewizer.TinyCLR.Assertions;
#endif

namespace Bytewizer.TestHarness.Core
{
    public class ByteArrayTests : TestFixture
    {
       public void IsEqualTo()
        {
            var fisrt = new byte[] { 1, 2, 3 };
            var second = new byte[] { 1, 2, 3 }; 
            var third = new byte[] { 3, 2, 1 };
            var forth = new byte[] { 3, 2, 1, 4 };

            Assert.True(fisrt.IsEqual(second));
            Assert.False(fisrt.IsEqual(third));
            Assert.False(fisrt.IsEqual(forth));
        }

        public void Reverse()
        {
            var fisrt = new byte[] { 1, 2, 3 };
            var second = new byte[] { 3, 2, 1 };
            var third = new byte[] { 0, 1, 2, 3, 0 };

            var value = fisrt.Reverse();
            Assert.AreEqual(value, second);

            var value1 = third.Reverse(1, 3);
            Assert.AreEqual(value1, second);
        }

        public void Skip()
        {
            var first = new byte[] { 0, 0, 0, 1, 2, 3 };
            var second = new byte[] { 1, 2, 3 };

            var value = first.Skip(3) ;
            Assert.AreEqual(value, second);
        }

        public void Take()
        {
            var first = new byte[] { 0, 0, 0, 1, 2, 3 };
            var second = new byte[] { 0, 0, 0 };
            var third = new byte[] { 1, 2 };

            var value = first.Take(3);
            Assert.AreEqual(value, second);

            var value1 = first.Take(3, 2);
            Assert.AreEqual(value1, third);
        }

        public void Concat()
        {
            var first = new byte[] { 0, 0, 0, 1, 2, 3 };
            var second = new byte[] { 0, 0, 0 };
            var third = new byte[] { 0, 0, 0, 1, 2, 3, 0, 0, 0 }; 

            var value = first.Concat(second);
            Assert.AreEqual(value, third);
        }

        public void ToUTF8()
        {
            var first = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var second = "Hello";

            var value = first.ToUTF8();
            Assert.AreEqual(value, second);
        }

        public void ToHex()
        {
            var first = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var second = "48656c6c6f";

            var value = first.ToHex();
            Assert.AreEqual(value, second);
        }

    }
}