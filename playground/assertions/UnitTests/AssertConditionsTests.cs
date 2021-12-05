using System.Collections;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class AssertConditionsTests : TestFixture
    {
        #region True
        public void IsTrue()
        {
            Assert.IsTrue(true);
        }
        #endregion

        #region False
        public void IsFalse()
        {
            Assert.IsFalse(false);
        }
        #endregion

        #region NotNull
        public void NotNull()
        {
            Assert.NotNull("hello");
        }

        public void IsNotNull()
        {
            Assert.IsNotNull("hello");
        }
        #endregion

        #region Null
        public void Null()
        {
            Assert.Null(null);
        }

        public void IsNull()
        {
            Assert.IsNull(null);
        }
        #endregion

        #region IsEmpty
        public void IsEmpty()
        {
            Assert.IsEmpty("", "Failed on empty String");
            Assert.IsEmpty(new int[0], "Failed on empty Array");
            Assert.IsEmpty(new ArrayList(), "Failed on empty ArrayList");
            Assert.IsEmpty(new Hashtable(), "Failed on empty Hashtable");
        }
        #endregion

        #region IsNotEmpty
        public void IsNotEmpty()
        {
            ArrayList arr = new ArrayList
            {
                "Testing"
            };

            Hashtable hash = new Hashtable
            {
                { "Unit", "Testing" }
            };

            Assert.IsNotEmpty("Unit", "Failed on non empty String");
            Assert.IsNotEmpty(new int[1] { 1 }, "Failed on non empty Array");
            Assert.IsNotEmpty(arr, "Failed on non empty ArrayList");
            Assert.IsNotEmpty(hash, "Failed on empty Hashtable");
        }
        #endregion

        #region Zero
        public void Zero()
        {
            Assert.Zero(0);
            Assert.Zero((uint)0);
            Assert.Zero((long)0);
            Assert.Zero((ulong)0);
            Assert.Zero((double)0);
            Assert.Zero((float)0);
        }
        
        public void ZeroFailsWhenNumberIsNotAZero()
        {
            Assert.Throws(typeof(AssertionException), () => Assert.Zero(1));
            Assert.Throws(typeof(AssertionException), () => Assert.Zero((uint)1));
            Assert.Throws(typeof(AssertionException), () => Assert.Zero((long)1));
            Assert.Throws(typeof(AssertionException), () => Assert.Zero((ulong)1));
            Assert.Throws(typeof(AssertionException), () => Assert.Zero((double)1));
            Assert.Throws(typeof(AssertionException), () => Assert.Zero((float)1));
        }

        #endregion

        #region NotZero
        public void NotZero()
        {
            Assert.NotZero(1);
            Assert.NotZero((uint)1);
            Assert.NotZero((long)1);
            Assert.NotZero((ulong)1);
            Assert.NotZero((double)1);
            Assert.NotZero((float)1);
        }
        #endregion

        #region Positive
        public void Positive()
        {
            Assert.Positive(1);
            Assert.Positive((uint)1);
            Assert.Positive((long)1);
            Assert.Positive((ulong)1);
            Assert.Positive((double)1);
            Assert.Positive((float)1);
        }
        #endregion

        #region Negative
        public void Negative()
        {
            Assert.Negative(-1);
            Assert.Negative((long)-1);
            Assert.Negative((double)-1);
            Assert.Negative((float)-1);
        }
        #endregion
    }
}