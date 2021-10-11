using System;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class AssertTest : TestFixture
    {
        #region Equals and ReferenceEquals

        public void EqualsThrowsException()
        {
            object o = new object();
            Assert.Throws(typeof(InvalidOperationException), () => Assert.Equals(o, o));
        }

        public void ReferenceEqualsThrowsException()
        {
            object o = new object();
            Assert.Throws(typeof(InvalidOperationException), () => Assert.ReferenceEquals(o, o));
        }
        #endregion

        #region Pass
        public void ThrowsSuccessException()
        {
            Assert.Throws(typeof(SuccessException), () => Assert.Pass());
        }

        public void ThrowsSuccessExceptionWithMessage()
        {
            try
            {
                Assert.Pass("MESSAGE");
            }
            catch (SuccessException ex)
            {
                Assert.AreEqual("MESSAGE", ex.Message);
            }
        }

        public void ThrowsSuccessExceptionWithMessageAndArgs()
        {
            try
            {
                Assert.Pass("MESSAGE: {0}+{1}={2}", 2, 2, 4);
            }
            catch (SuccessException ex)
            {
                Assert.AreEqual("MESSAGE: 2+2=4", ex.Message);
            }
        }
        #endregion

        #region Fail
        public void ThrowsAssertionException()
        {
            Assert.Throws(typeof(AssertionException), () => Assert.Fail());
        }

        public void ThrowsAssertionExceptionWithMessage()
        {
            try
            {
                Assert.Fail("MESSAGE");
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("MESSAGE", ex.Message);
            }
        }

        public void ThrowsAssertionExceptionWithMessageAndArgs()
        {
            try
            {
                Assert.Fail("MESSAGE: {0}+{1}={2}", 2, 2, 4);
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("MESSAGE: 2+2=4", ex.Message);
            }
        }
        #endregion

        #region Contains
        #endregion

        #region Assert Count
        #endregion
    }
}

//        #region Messages

//        //public void FailWithCustomMessage()
//        //{
//        //    string message = "CustomMessage";

//        //    try
//        //    {
//        //        Assert.Fail("CustomMessage");
//        //    }
//        //    catch (AssertionException ex)
//        //    {
//        //        Assert.AreEqual(message, ex.Message);
//        //    }
//        //}

//        #endregion

// #region Fail, Ignore, IsNull, IsNotNull, IsTrue, IsFalse



        //        public void AreEqualInt()
        //        {
        //            Assert.AreEqual(0, 0);
        //        }

        //        //public void AreEqualIntDelta()
        //        //{
        //        //    Assert.AreEqual(0, 1, 1);
        //        //}

        //        public void AreEqualString()
        //        {
        //            Assert.AreEqual("hello", "hello");
        //        }

        //        public void AreEqualDoubleDelta()
        //        {
        //            Assert.AreEqual(0.0, 1.0, 1.0);
        //        }

        //        //public void AreEqualFloatDelta()
        //        //{
        //        //    float l = 0;
        //        //    float r = 1;
        //        //    Assert.AreEqual(l, r, r);
        //        //}

        //        public void AreSame()
        //        {
        //            ArrayList list = new ArrayList();
        //            Assert.AreSame(list, list);
        //        }

        //        #endregion

        //        #region AreNotEqual

        //        public void NotEqual()
        //        {
        //            Assert.AreNotEqual(5, 3);
        //        }

        //        // Expected Exception
        //        //public void NotEqualFails()
        //        //{
        //        //    Assert.AreNotEqual(5, 5);
        //        //}

        //        public void NullNotEqualToNonNull()
        //        {
        //            Assert.AreNotEqual(null, 3);
        //        }

        //        public void ArraysNotEqual()
        //        {
        //            Assert.AreNotEqual(new object[] { 1, 2, 3 }, new int[] { 1, 3, 2 });
        //        }

        //        // Expected Exception
        //        //public void ArraysNotEqualFails()
        //        //{
        //        //    Assert.AreNotEqual(new object[] { 1, 2, 3 }, new object[] { 1, 2, 3 });
        //        //}

        //        #endregion

        //        #region <, <=, >, >=
        //        #region LowerThan

        //        public void LowerThanInt()
        //        {
        //            Assert.LowerThan(0, 1);
        //        }

        //        public void LowerThanShort()
        //        {
        //            Assert.LowerThan((short)0, (short)1);
        //        }

        //        public void LowerThanByte()
        //        {
        //            Assert.LowerThan((byte)0, (byte)1);
        //        }

        //        public void LowerThanLong()
        //        {
        //            Assert.LowerThan((long)0, (long)1);
        //        }

        //        public void LowerThanDouble()
        //        {
        //            Assert.LowerThan((double)0, (double)1);
        //        }

        //        public void LowerThanFloat()
        //        {
        //            Assert.LowerThan((float)0, (float)1);
        //        }

        //        //[Test]
        //        //public void LowerThanFailEqualFloat()
        //        //{
        //        //    Assert.LowerThan((float)0, (float)0);
        //        //}
        //        //[Test]
        //        //public void LowerThanFailLessFloat()
        //        //{
        //        //    Assert.LowerThan((float)0, (float)-1);
        //        //}

        //        #endregion

        //        #region LowerEqualThan

        //        public void LowerEqualThanInt()
        //        {
        //            Assert.LowerEqualThan(0, 1);
        //        }

        //        public void LowerEqualThanEqualInt()
        //        {
        //            Assert.LowerEqualThan(0, 0);
        //        }


        //        public void LowerEqualThanShort()
        //        {
        //            Assert.LowerEqualThan((short)0, (short)1);
        //        }

        //        public void LowerEqualThanEqualShort()
        //        {
        //            Assert.LowerEqualThan((short)0, (short)0);
        //        }


        //        public void LowerEqualThanByte()
        //        {
        //            Assert.LowerEqualThan((byte)0, (byte)1);
        //        }

        //        public void LowerEqualThanEqualByte()
        //        {
        //            Assert.LowerEqualThan((byte)0, (byte)0);
        //        }

        //        public void LowerEqualThanLong()
        //        {
        //            Assert.LowerEqualThan((long)0, (long)1);
        //        }

        //        public void LowerEqualThanEqualLong()
        //        {
        //            Assert.LowerEqualThan((long)0, (long)0);
        //        }

        //        public void LowerEqualThanDouble()
        //        {
        //            Assert.LowerEqualThan((double)0, (double)1);
        //        }

        //        public void LowerEqualThanEqualDouble()
        //        {
        //            Assert.LowerEqualThan((double)0, (double)0);
        //        }

        //        public void LowerEqualThanFloat()
        //        {
        //            Assert.LowerEqualThan((float)0, (float)1);
        //        }

        //        public void LowerEqualThanEqualFloat()
        //        {
        //            Assert.LowerEqualThan((float)0, (float)0);
        //        }

        //        #endregion

        //        #region Less

        //        public void LessInt()
        //        {
        //            Assert.Less(0, 1);
        //        }

        //        public void LessShort()
        //        {
        //            Assert.Less((short)0, (short)1);
        //        }


        //        public void LessByte()
        //        {
        //            Assert.Less((byte)0, (byte)1);
        //        }

        //        public void LessLong()
        //        {
        //            Assert.Less((long)0, (long)1);
        //        }

        //        public void LessDouble()
        //        {
        //            Assert.Less((double)0, (double)1);
        //        }


        //        public void LessFloat()
        //        {
        //            Assert.Less((float)0, (float)1);
        //        }
        //        #endregion

        //        #region GreaterThan

        //        public void GreaterThanInt()
        //        {
        //            Assert.GreaterThan(1, 0);
        //        }


        //        public void GreaterThanShort()
        //        {
        //            Assert.GreaterThan((short)1, (short)0);
        //        }

        //        public void GreaterThanByte()
        //        {
        //            Assert.GreaterThan((byte)1, (byte)0);
        //        }

        //        public void GreaterThanLong()
        //        {
        //            Assert.GreaterThan((long)1, (long)0);
        //        }


        //        public void GreaterThanDouble()
        //        {
        //            Assert.GreaterThan((double)1, (double)0);
        //        }

        //        public void GreaterThanFloat()
        //        {
        //            Assert.GreaterThan((float)1, (float)0);
        //        }

        //        #endregion

        //        #region Greater

        //        public void GreaterInt()
        //        {
        //            Assert.Greater(1, 0);
        //        }

        //        public void GreaterShort()
        //        {
        //            Assert.Greater((short)1, (short)0);
        //        }

        //        public void GreaterByte()
        //        {
        //            Assert.Greater((byte)1, (byte)0);
        //        }

        //        public void GreaterLong()
        //        {
        //            Assert.Greater((long)1, (long)0);
        //        }


        //        public void GreaterDouble()
        //        {
        //            Assert.Greater((double)1, (double)0);
        //        }


        //        public void GreaterFloat()
        //        {
        //            Assert.Greater((float)1, (float)0);
        //        }

        //        #endregion

        //        #region GreaterEqualThan

        //        public void GreaterEqualThanInt()
        //        {
        //            Assert.GreaterEqualThan(1, 0);
        //        }


        //        public void GreaterEqualThanShort()
        //        {
        //            Assert.GreaterEqualThan((short)1, (short)0);
        //        }

        //        public void GreaterEqualThanEqualShort()
        //        {
        //            Assert.GreaterEqualThan((short)0, (short)0);
        //        }


        //        public void GreaterEqualThanByte()
        //        {
        //            Assert.GreaterEqualThan((byte)1, (byte)0);
        //        }

        //        public void GreaterEqualThanEqualByte()
        //        {
        //            Assert.GreaterEqualThan((byte)0, (byte)0);
        //        }


        //        public void GreaterEqualThanLong()
        //        {
        //            Assert.GreaterEqualThan((long)1, (long)0);
        //        }


        //        public void GreaterEqualThanEqualLong()
        //        {
        //            Assert.GreaterEqualThan((long)0, (long)0);
        //        }


        //        public void GreaterEqualThanDouble()
        //        {
        //            Assert.GreaterEqualThan((double)1, (double)0);
        //        }


        //        public void GreaterEqualThanEqualDouble()
        //        {
        //            Assert.GreaterEqualThan((double)0, (double)0);
        //        }


        //        public void GreaterEqualThanFloat()
        //        {
        //            Assert.GreaterEqualThan((float)1, (float)0);
        //        }

        //        public void GreaterEqualThanEqualFloat()
        //        {
        //            Assert.GreaterEqualThan((float)0, (float)0);
        //        }

        //        #endregion

        //        #endregion

        //        #region In, NotIn

        //        #region In

        //        #region IDictionary

        //        public void InDictionary()
        //        {
        //            Hashtable dic = new Hashtable();
        //            string test = "test";
        //            dic.Add(test, null);
        //            Assert.In(test, dic);
        //        }

        //        #endregion

        //        #region IList

        //        //public void InListTestNull()
        //        //{
        //        //    ArrayList list = new ArrayList();
        //        //    list.Add(null);
        //        //    Assert.In(null, list);
        //        //}

        //        public void InList()
        //        {
        //            ArrayList list = new ArrayList();
        //            string test = "test";
        //            list.Add(test);
        //            Assert.In(test, list);
        //        }

        //        #endregion

        //        #region IEnumerable

        //        //public void InEnumerableTestNull()
        //        //{
        //        //    ArrayList list = new ArrayList();
        //        //    list.Add(null);
        //        //    Assert.In(null, (IEnumerable)list);
        //        //}

        //        public void InEnumerable()
        //        {
        //            ArrayList list = new ArrayList();
        //            string test = "test";
        //            list.Add(test);
        //            Assert.In(test, (IEnumerable)list);
        //        }

        //        #endregion

        //        #endregion

        //        #endregion

        //        #region NotIn

        //        #region IDictionary

        //        public void NotInDictionary()
        //        {
        //            Hashtable dic = new Hashtable();
        //            string test = "test";
        //            dic.Add(test, null);
        //            Assert.NotIn(test + "modified", dic);
        //        }

        //        #endregion

        //        #region IList

        //        //public void NotInListTestNull()
        //        //{
        //        //    Assert.NotIn(null, new ArrayList());
        //        //}

        //        public void NotInList()
        //        {
        //            ArrayList list = new ArrayList();
        //            string test = "test";
        //            list.Add(test);
        //            Assert.NotIn(test + "modified", list);
        //        }

        //        #endregion

        //        #region IEnumerable

        //        //public void NotInEnumerableTestNull()
        //        //{
        //        //    Assert.NotIn(null, (IEnumerable)new ArrayList());
        //        //}


        //        public void NotInEnumerable()
        //        {
        //            ArrayList list = new ArrayList();
        //            string test = "test";
        //            list.Add(test);
        //            Assert.NotIn(test + "modified", (IEnumerable)list);
        //        }

        //        #endregion

        //        #endregion

        //        #region IsEmpty

        //        public void IsEmpty()
        //        {
        //            Assert.IsEmpty("", "Failed on empty String");
        //            Assert.IsEmpty(new int[0], "Failed on empty Array");
        //            Assert.IsEmpty(new ArrayList(), "Failed on empty ArrayList");
        //            Assert.IsEmpty(new Hashtable(), "Failed on empty Hashtable");
        //        }

        //        //[Test]
        //        //[ExpectedException(typeof(AssertionException))]
        //        //public void IsEmptyFailsOnString()
        //        //{
        //        //    Assert.IsEmpty("Hi!");
        //        //}

        //        //[Test]
        //        //[ExpectedException(typeof(AssertionException))]
        //        //public void IsEmptyFailsOnNullString()
        //        //{
        //        //    Assert.IsEmpty((string)null);
        //        //}

        //        //[Test]
        //        //[ExpectedException(typeof(AssertionException))]
        //        //public void IsEmptyFailsOnNonEmptyArray()
        //        //{
        //        //    Assert.IsEmpty(new int[] { 1, 2, 3 });
        //        //}

        //        #endregion
        //        #region IsNotEmpty

        //        public void IsNotEmpty()
        //        {
        //            ArrayList arr = new ArrayList();
        //            arr.Add("Testing");

        //            Hashtable hash = new Hashtable();
        //            hash.Add("MbUnit", "Testing");

        //            Assert.IsNotEmpty("MbUnit", "Failed on non empty String");
        //            Assert.IsNotEmpty(new int[1] { 1 }, "Failed on non empty Array");
        //            Assert.IsNotEmpty(arr, "Failed on non empty ArrayList");
        //            Assert.IsNotEmpty(hash, "Failed on empty Hashtable");
        //        }

        //        //[Test]
        //        //[ExpectedException(typeof(AssertionException))]
        //        //public void IsNotEmptyFailsOnString()
        //        //{
        //        //    Assert.IsNotEmpty(string.Empty);
        //        //}

        //        //[Test]
        //        //[ExpectedException(typeof(AssertionException))]
        //        //public void IsNotEmptyFailsOnNonEmptyArray()
        //        //{
        //        //    Assert.IsNotEmpty(new int[0] { });
        //        //}


        //        #endregion

        //        #region Contains

        //        public void Contains()
        //        {
        //            string s = "TestUnit";
        //            string contain = "Unit";
        //            Assert.Contains(s, contain);
        //        }

        //        #endregion
