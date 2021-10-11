using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class AssertComparisonsTests : TestFixture
    {
        #region Greater
        public void Greater()
        {
            Assert.Greater(1, 0);
            Assert.Greater((uint)1, (uint)0);
            Assert.Greater((long)1, (long)0);
            Assert.Greater((ulong)1, (ulong)0);
            Assert.Greater((double)1, (double)0);
            Assert.Greater((float)1, (float)0);
        }

        public void NotGreater()
        {
            try
            {
                Assert.Greater(5, 8);
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("5 is not greater than 8. ", ex.Message);
            }
        }

        public void GreaterMixedTypes()
        {
            Assert.Greater(5, 3L, "int to long");
            Assert.Greater(5, 3.5f, "int to float");
            Assert.Greater(5, 3.5d, "int to double");
            Assert.Greater(5, 3U, "int to uint");
            Assert.Greater(5, 3UL, "int to ulong");

            Assert.Greater(5L, 3, "long to int");
            Assert.Greater(5L, 3.5f, "long to float");
            Assert.Greater(5L, 3.5d, "long to double");
            Assert.Greater(5L, 3U, "long to uint");
            Assert.Greater(5L, 3UL, "long to ulong");

            Assert.Greater(8.2f, 5, "float to int");
            Assert.Greater(8.2f, 8L, "float to long");
            Assert.Greater(8.2f, 3.5d, "float to double");
            Assert.Greater(8.2f, 8U, "float to uint");
            Assert.Greater(8.2f, 8UL, "float to ulong");

            Assert.Greater(8.2d, 5, "double to int");
            Assert.Greater(8.2d, 5L, "double to long");
            Assert.Greater(8.2d, 3.5f, "double to float");
            Assert.Greater(8.2d, 8U, "double to uint");
            Assert.Greater(8.2d, 8UL, "double to ulong");

            Assert.Greater(5U, 3, "uint to int");
            Assert.Greater(5U, 3L, "uint to long");
            Assert.Greater(5U, 3.5f, "uint to float");
            Assert.Greater(5U, 3.5d, "uint to double");
            Assert.Greater(5U, 3UL, "uint to ulong");

            Assert.Greater(5ul, 3, "ulong to int");
            Assert.Greater(5UL, 3L, "ulong to long");
            Assert.Greater(5UL, 3.5f, "ulong to float");
            Assert.Greater(5UL, 3.5d, "ulong to double");
            Assert.Greater(5UL, 3U, "ulong to uint");
        }
        #endregion

        #region Less
        public void Less()
        {
            Assert.Less(0, 1);
            Assert.Less((uint)0, (uint)1);
            Assert.Less((long)0, (long)1);
            Assert.Less((ulong)0, (ulong)1);
            Assert.Less((double)0, (double)1);
            Assert.Less((float)0, (float)1);
        }

        public void NotLess()
        {
            try
            {
                Assert.LessOrEqual(8, 5);
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("8 is not lower than 5. ", ex.Message);
            }
        }

        public void LessMixedTypes()
        {
            Assert.Less(5, 8L, "int to long");
            Assert.Less(5, 8.2f, "int to float");
            Assert.Less(5, 8.2d, "int to double");
            Assert.Less(5, 8U, "int to uint");
            Assert.Less(5, 8UL, "int to ulong");

            Assert.Less(5L, 8, "long to int");
            Assert.Less(5L, 8.2f, "long to float");
            Assert.Less(5L, 8.2d, "long to double");
            Assert.Less(5L, 8U, "long to uint");
            Assert.Less(5L, 8UL, "long to ulong");

            Assert.Less(3.5f, 5, "float to int");
            Assert.Less(3.5f, 8L, "float to long");
            Assert.Less(3.5f, 8.2d, "float to double");
            Assert.Less(3.5f, 8U, "float to uint");
            Assert.Less(3.5f, 8UL, "float to ulong");

            Assert.Less(3.5d, 5, "double to int");
            Assert.Less(3.5d, 5L, "double to long");
            Assert.Less(3.5d, 8.2f, "double to float");
            Assert.Less(3.5d, 8U, "double to uint");
            Assert.Less(3.5d, 8UL, "double to ulong");


            Assert.Less(5U, 8, "uint to int");
            Assert.Less(5U, 8L, "uint to long");
            Assert.Less(5U, 8.2f, "uint to float");
            Assert.Less(5U, 8.2d, "uint to double");
            Assert.Less(5U, 8UL, "uint to ulong");

            Assert.Less(5ul, 8, "ulong to int");
            Assert.Less(5UL, 8L, "ulong to long");
            Assert.Less(5UL, 8.2f, "ulong to float");
            Assert.Less(5UL, 8.2d, "ulong to double");
            Assert.Less(5UL, 8U, "ulong to uint");

        }
        #endregion

        #region GreaterOrEqual
        public void GreaterOrEqual()
        {
            Assert.GreaterOrEqual(0, 0);
            Assert.GreaterOrEqual((uint)0, (uint)0);
            Assert.GreaterOrEqual((long)0, (long)0);
            Assert.GreaterOrEqual((ulong)0, (ulong)0);
            Assert.GreaterOrEqual((double)0, (double)0);
            Assert.GreaterOrEqual((float)0, (float)0);

            Assert.GreaterOrEqual(1, 0);
            Assert.GreaterOrEqual((uint)1, (uint)0);
            Assert.GreaterOrEqual((long)1, (long)0);
            Assert.GreaterOrEqual((ulong)1, (ulong)0);
            Assert.GreaterOrEqual((double)1, (double)0);
            Assert.GreaterOrEqual((float)1, (float)0);
        }

        public void NotGreaterOrEqual()
        {
            try
            {
                Assert.GreaterOrEqual(5, 8);
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("5 is not greater than 8. ", ex.Message);
            }
        }

        public void GreaterOrEqualMixedTypes()
        {
            Assert.GreaterOrEqual(5, 3L, "int to long");
            Assert.GreaterOrEqual(5, 3.5f, "int to float");
            Assert.GreaterOrEqual(5, 3.5d, "int to double");
            Assert.GreaterOrEqual(5, 3U, "int to uint");
            Assert.GreaterOrEqual(5, 3UL, "int to ulong");

            Assert.GreaterOrEqual(5L, 3, "long to int");
            Assert.GreaterOrEqual(5L, 3.5f, "long to float");
            Assert.GreaterOrEqual(5L, 3.5d, "long to double");
            Assert.GreaterOrEqual(5L, 3U, "long to uint");
            Assert.GreaterOrEqual(5L, 3UL, "long to ulong");

            Assert.GreaterOrEqual(8.2f, 5, "float to int");
            Assert.GreaterOrEqual(8.2f, 8L, "float to long");
            Assert.GreaterOrEqual(8.2f, 3.5d, "float to double");
            Assert.GreaterOrEqual(8.2f, 8U, "float to uint");
            Assert.GreaterOrEqual(8.2f, 8UL, "float to ulong");

            Assert.GreaterOrEqual(8.2d, 5, "double to int");
            Assert.GreaterOrEqual(8.2d, 5L, "double to long");
            Assert.GreaterOrEqual(8.2d, 3.5f, "double to float");
            Assert.GreaterOrEqual(8.2d, 8U, "double to uint");
            Assert.GreaterOrEqual(8.2d, 8UL, "double to ulong");

            Assert.GreaterOrEqual(5U, 3, "uint to int");
            Assert.GreaterOrEqual(5U, 3L, "uint to long");
            Assert.GreaterOrEqual(5U, 3.5f, "uint to float");
            Assert.GreaterOrEqual(5U, 3.5d, "uint to double");
            Assert.GreaterOrEqual(5U, 3UL, "uint to ulong");

            Assert.GreaterOrEqual(5ul, 3, "ulong to int");
            Assert.GreaterOrEqual(5UL, 3L, "ulong to long");
            Assert.GreaterOrEqual(5UL, 3.5f, "ulong to float");
            Assert.GreaterOrEqual(5UL, 3.5d, "ulong to double");
            Assert.GreaterOrEqual(5UL, 3U, "ulong to uint");
        }

        #endregion

        #region LessOrEqual
        public void LessOrEqual()
        {
            Assert.LessOrEqual(0, 1);
            Assert.LessOrEqual((uint)0, (uint)1);
            Assert.LessOrEqual((long)0, (long)1);
            Assert.LessOrEqual((ulong)0, (ulong)1);
            Assert.LessOrEqual((double)0, (double)1);
            Assert.LessOrEqual((float)0, (float)1);

            Assert.LessOrEqual(0, 0);
            Assert.LessOrEqual((uint)0, (uint)0);
            Assert.LessOrEqual((long)0, (long)0);
            Assert.LessOrEqual((ulong)0, (ulong)0);
            Assert.LessOrEqual((double)0, (double)0);
            Assert.LessOrEqual((float)0, (float)0);
        }

        public void NotLessOrEqual()
        {
            try
            {
                Assert.LessOrEqual(8, 5);
            }
            catch (AssertionException ex)
            {
                Assert.AreEqual("8 is not lower than 5. ", ex.Message);
            }
        }

        public void LessOrEqualMixedTypes()
        {
            Assert.LessOrEqual(5, 8L, "int to long");
            Assert.LessOrEqual(5, 8.2f, "int to float");
            Assert.LessOrEqual(5, 8.2d, "int to double");
            Assert.LessOrEqual(5, 8U, "int to uint");
            Assert.LessOrEqual(5, 8UL, "int to ulong");

            Assert.LessOrEqual(5L, 8, "long to int");
            Assert.LessOrEqual(5L, 8.2f, "long to float");
            Assert.LessOrEqual(5L, 8.2d, "long to double");
            Assert.LessOrEqual(5L, 8U, "long to uint");
            Assert.LessOrEqual(5L, 8UL, "long to ulong");

            Assert.LessOrEqual(3.5f, 5, "float to int");
            Assert.LessOrEqual(3.5f, 8L, "float to long");
            Assert.LessOrEqual(3.5f, 8.2d, "float to double");
            Assert.LessOrEqual(3.5f, 8U, "float to uint");
            Assert.LessOrEqual(3.5f, 8UL, "float to ulong");

            Assert.LessOrEqual(3.5d, 5, "double to int");
            Assert.LessOrEqual(3.5d, 5L, "double to long");
            Assert.LessOrEqual(3.5d, 8.2f, "double to float");
            Assert.LessOrEqual(3.5d, 8U, "double to uint");
            Assert.LessOrEqual(3.5d, 8UL, "double to ulong");

            Assert.LessOrEqual(5U, 8, "uint to int");
            Assert.LessOrEqual(5U, 8L, "uint to long");
            Assert.LessOrEqual(5U, 8.2f, "uint to float");
            Assert.LessOrEqual(5U, 8.2d, "uint to double");
            Assert.LessOrEqual(5U, 8UL, "uint to ulong");

            Assert.LessOrEqual(5ul, 8, "ulong to int");
            Assert.LessOrEqual(5UL, 8L, "ulong to long");
            Assert.LessOrEqual(5UL, 8.2f, "ulong to float");
            Assert.LessOrEqual(5UL, 8.2d, "ulong to double");
            Assert.LessOrEqual(5UL, 8U, "ulong to uint");
        }

        #endregion
    }
}