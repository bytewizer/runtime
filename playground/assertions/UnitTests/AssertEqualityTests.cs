using System;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class AssertEqualityTests : TestFixture
    {
        #region AreEqual

        #region Doubles

        public void EqualsNaNFails()
        {
            //Assert.AreEqual(1.234, double.NaN, 0.0);
        }

        public void NanEqualsFails()
        {
            //Assert.AreEqual(double.NaN, 1.234, 0.0);
        }

        public void NanEqualsNaNSucceeds()
        {
            Assert.AreEqual(double.NaN, double.NaN, 0.0);
        }

        public void NegInfinityEqualsInfinity()
        {
            Assert.AreEqual(double.NegativeInfinity, double.NegativeInfinity, 0.0);
        }

        public void PosInfinityEqualsInfinity()
        {
            Assert.AreEqual(double.PositiveInfinity, double.PositiveInfinity, 0.0);
        }

        public void PosInfinityNotEquals()
        {
            //Assert.AreEqual(double.PositiveInfinity, 1.23, 0.0);
        }

        public void PosInfinityNotEqualsNegInfinity()
        {
            //Assert.AreEqual(double.PositiveInfinity, double.NegativeInfinity, 0.0);
        }

        #endregion

        #region Objects

        public void Equals()
        {
            string sMessage = "Hello";
            string expected = sMessage;
            string actual = sMessage;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual);
        }

        public void EqualsNull()
        {
            Assert.AreEqual(null, null);
        }

        public void IntegerLongComparison()
        {
            Assert.AreEqual(1, 1L);
            Assert.AreEqual(1L, 1);
        }

        public void IntegerEquals()
        {
            int val = 42;
            Assert.AreEqual(val, 42);
        }

        public void Float()
        {
            float val = (float)1.0;
            float expected = val;
            float actual = val;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual, (float)0.0);
        }

        public void Byte()
        {
            byte val = 1;
            byte expected = val;
            byte actual = val;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual);
        }

        public void String()
        {
            string s1 = "test";
            string s2 = new System.Text.StringBuilder(s1).ToString();

            Assert.IsTrue(s1.Equals(s2));
            Assert.AreEqual(s1, s2);
        }

        public void Short()
        {
            short val = 1;
            short expected = val;
            short actual = val;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual);
        }

        public void Int()
        {
            int val = 1;
            int expected = val;
            int actual = val;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual);
        }

        public void UInt()
        {
            uint val = 1;
            uint expected = val;
            uint actual = val;

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expected, actual);
        }

        public void EqualsSameTypes()
        {
            byte b1 = 35;
            sbyte sb2 = 35;
            double d5 = 35;
            float f6 = 35;
            int i7 = 35;
            uint u8 = 35;
            long l9 = 35;
            short s10 = 35;
            ushort us11 = 35;
            char c1 = '3';
            char c2 = 'a';

            System.Byte b12 = 35;
            System.SByte sb13 = 35;
            System.Double d15 = 35;
            System.Single s16 = 35;
            System.Int32 i17 = 35;
            System.UInt32 ui18 = 35;
            System.Int64 i19 = 35;
            System.UInt64 ui20 = 35;
            System.Int16 i21 = 35;
            System.UInt16 i22 = 35;
            System.Char c12 = '3';
            System.Char c22 = 'a';

            Assert.AreEqual(35, b1);
            Assert.AreEqual(35, sb2);
            Assert.AreEqual(35, d5);
            Assert.AreEqual(35, f6);
            Assert.AreEqual(35, i7);
            Assert.AreEqual(35, u8);
            Assert.AreEqual(35, l9);
            Assert.AreEqual(35, s10);
            Assert.AreEqual(35, us11);
            Assert.AreEqual('3', c1);
            Assert.AreEqual('a', c2);

            Assert.AreEqual(35, b12);
            Assert.AreEqual(35, sb13);
            Assert.AreEqual(35, d15);
            Assert.AreEqual(35, s16);
            Assert.AreEqual(35, i17);
            Assert.AreEqual(35, ui18);
            Assert.AreEqual(35, i19);
            Assert.AreEqual(35, ui20);
            Assert.AreEqual(35, i21);
            Assert.AreEqual(35, i22);
            Assert.AreEqual('3', c12);
            Assert.AreEqual('a', c22);

            byte b23 = 35;
            sbyte sb24 = 35;
            double d26 = 35;
            float f27 = 35;
            int i28 = 35;
            uint u29 = 35;
            long l30 = 35;
            short s31 = 35;
            ushort us32 = 35;
            char c3 = '3';
            char c4 = 'a';

            Assert.AreEqual(35, b23);
            Assert.AreEqual(35, sb24);
            Assert.AreEqual(35, d26);
            Assert.AreEqual(35, f27);
            Assert.AreEqual(35, i28);
            Assert.AreEqual(35, u29);
            Assert.AreEqual(35, l30);
            Assert.AreEqual(35, s31);
            Assert.AreEqual(35, us32);
            Assert.AreEqual('3', c3);
            Assert.AreEqual('a', c4);
        }

        public void EnumsEqual()
        {
            TestEnum actual = TestEnum.A;
            Assert.AreEqual(TestEnum.A, actual);
        }
        #endregion

        #region Arrays
        public void ArrayIsEqualToItself()
        {
            string[] array = { "one", "two", "three" };
            Assert.AreEqual(array, array);
        }

        public void ArraysOfString()
        {
            string[] array1 = { "one", "two", "three" };
            string[] array2 = { "one", "two", "three" };
            Assert.IsFalse(array1 == array2);
            Assert.AreEqual(array1, array2);
            Assert.AreEqual(array2, array1);
        }

        public void ArraysOfInt()
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 1, 2, 3 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        public void ArraysOfDouble()
        {
            double[] a = new double[] { 1.0, 2.0, 3.0 };
            double[] b = new double[] { 1.0, 2.0, 3.0 };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        //public void ArrayOfIntAndArrayOfDouble()
        //{
        //    int[] a = new int[] { 1, 2, 3 };
        //    double[] b = new double[] { 1.0, 2.0, 3.0 };
        //    Assert.AreEqual(a, b);
        //    Assert.AreEqual(b, a);
        //}

        //public void ArraysDeclaredAsDifferentTypes()
        //{
        //    string[] array1 = { "one", "two", "three" };
        //    object[] array2 = { "one", "two", "three" };
        //    Assert.AreEqual(array1, array2, "String[] not equal to Object[]");
        //    Assert.AreEqual(array2, array1, "Object[] not equal to String[]");
        //}

        public void ArraysOfMixedTypes()
        {
            DateTime now = DateTime.Now;
            object[] array1 = new object[] { 1, 2.0f, 3.5d, 7.000m, "Hello", now };
            object[] array2 = new object[] { 1.0d, 2, 3.5, 7, "Hello", now };
            Assert.AreEqual(array1, array2);
            Assert.AreEqual(array2, array1);
        }

        public void ArraysOfArrays()
        {
            int[][] a = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int[][] b = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
        }

        public void JaggedArrays()
        {
            int[][] expected = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9 } };
            int[][] actual = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9 } };

            Assert.AreEqual(expected, actual);
        }

        //public void ArraysPassedAsObjects()
        //{
        //    object a = new int[] { 1, 2, 3 };
        //    object b = new double[] { 1.0, 2.0, 3.0 };
        //    Assert.AreEqual(a, b);
        //    Assert.AreEqual(b, a);
        //}

        //public void ArrayAndCollection()
        //{
        //    int[] a = new int[] { 1, 2, 3 };
        //    ICollection b = new SimpleObjectCollection(1, 2, 3);
        //    Assert.AreEqual(a, b);
        //    Assert.AreEqual(b, a);
        //}

        //public void ArraysWithDifferentRanksComparedAsCollection()
        //{
        //    int[] expected = new int[] { 1, 2, 3, 4 };
        //    int[,] actual = new int[,] { { 1, 2 }, { 3, 4 } };

        //    Assert.AreNotEqual(expected, actual);
        //}

        //public void ArraysWithDifferentDimensionsMatchedAsCollection()
        //{            
        //    int[][] expected = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 }, new int[] { 8, 9 } };
        //    int[][] actual = new int[][] { new int[] { 1, 2}, new int[] { 4, 5, 6}, new int[] { 8, 9 } };

        //    Assert.AreNotEqual(expected, actual);
        //}

        #endregion

        #endregion

        #region AreNotEqual

        #region Objects
        public void NotEqual()
        {
            string expected = "Hello";
            string actual = "World";

            Assert.IsTrue(expected != actual);
            Assert.AreNotEqual(expected, actual);
        }

        public void NotEqualNull()
        {
            Assert.AreNotEqual("Hello", null);
        }
        #endregion

        #region Arrays
        //public void DifferentLengthArrays()
        //{
        //    string[] array1 = { "one", "two", "three" };
        //    string[] array2 = { "one", "two", "three", "four", "five" };

        //    Assert.AreNotEqual(array1, array2);
        //    Assert.AreNotEqual(array2, array1);
        //}

        //public void SameLengthDifferentContent()
        //{
        //    string[] array1 = { "one", "two", "three" };
        //    string[] array2 = { "one", "two", "ten" };
        //    Assert.AreNotEqual(array1, array2);
        //    Assert.AreNotEqual(array2, array1);
        //}

        //public void ArraysDeclaredAsDifferentTypes()
        //{
        //    string[] array1 = { "one", "two", "three" };
        //    object[] array2 = { "one", "three", "two" };
        //    Assert.AreNotEqual(array1, array2);
        //    Assert.AreNotEqual(array2, array1);
        //}
        #endregion

        #endregion

        #region AreSame
        public void Same()
        {
            string val = "S1";
            string s1 = val;
            string s2 = val;

            Assert.AreSame(s1, s2);
        }

        public void SameFails()
        {
            string s1 = "S1";
            string s2 = "S2";

            Assert.Throws(typeof(AssertionException), () => Assert.AreSame(s1, s2));
        }
        #endregion

        #region AreNotSame
        public void NotSame()
        {
            string s1 = "S1";
            string s2 = "S2";

            Assert.AreNotSame(s1, s2);
        }

        public void NotSameFails()
        {
            string s1 = "S1";
            string s2 = "S1";

            Assert.Throws(typeof(AssertionException), () => Assert.AreNotSame(s1, s2));
        }
        #endregion

        private enum TestEnum
        {
            A,
            B,
            C
        }
    }
}