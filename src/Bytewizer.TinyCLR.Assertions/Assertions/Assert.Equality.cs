// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Assertions
{
    public abstract partial class Assert
    {
        #region AreEqual

        #region Doubles

        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the expected value is infinity then the delta
        /// value is ignored. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the the expected and the actual</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void AreEqual(double expected, double actual, double delta, string message, params object[] args)
        {
            // Delta must be positive otherwise the following case fails
            if (delta < 0)
            {
                throw new ArgumentException(nameof(delta), "Delta must be a positive value.");
            }

            IncrementAssertCount();

            // handle infinity specially since subtracting two infinite values gives NaN and the following test fails
            if (double.IsNaN(expected) || double.IsInfinity(expected))
            {
                if (!(expected == actual))
                {
                    throw new NotEqualAssertionException(expected, actual, string.Format(message, args));
                }
            }
            else if (!(Math.Abs(expected - actual) <= delta))
            {
                throw new NotEqualAssertionException(expected, actual, string.Format(message, args));
            }
        }

        /// <summary>
        /// Verifies that two doubles are equal considering a delta. If the expected value is infinity then the delta
        /// value is ignored. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The actual value</param>
        /// <param name="delta">The maximum acceptable difference between the the expected and the actual</param>
        public static void AreEqual(double expected, double actual, double delta)
        {
            Assert.AreEqual(expected, actual, delta, string.Empty);
        }

        #endregion

        #region Objects

        /// <summary>
        /// Verifies that two objects are equal. Two objects are considered equal if both are null, or if both have the
        /// same value. NUnit has special semantics for some object types. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void AreEqual(object expected, object actual, string message, params object[] args)
        {
            IncrementAssertCount();

            if (expected == null && actual == null)
            {
                return;
            }

            if (expected != null && actual != null)
            {
                if (ObjectsEqual(expected, actual))
                {
                    return;
                }
            }

            throw new NotEqualAssertionException(expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Verifies that two objects are equal. Two objects are considered equal if both are null, or if both have the
        /// same value. NUnit has special semantics for some object types. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        public static void AreEqual(object expected, object actual)
        {
            Assert.AreEqual(expected, actual, string.Empty, null);
        }

        #endregion

        #endregion

        #region AreNotEqual

        #region Objects

        /// <summary>
        /// Verifies that two objects are not equal. Two objects are considered equal if both are null, or if both have
        /// the same value. NUnit has special semantics for some object types. Returns without throwing an exception
        /// when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void AreNotEqual(object expected, object actual, string message, params object[] args)
        {
            IncrementAssertCount();

            if (expected == null ^ actual == null)
            {
                return;
            }

            if (!ObjectsEqual(expected, actual))
            {
                return;
            }

            throw new NotEqualAssertionException(expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Verifies that two objects are not equal. Two objects are considered equal if both are null, or if both have
        /// the same value. NUnit has special semantics for some object types. Returns without throwing an exception
        /// when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The value that is expected</param>
        /// <param name="actual">The actual value</param>
        public static void AreNotEqual(object expected, object actual)
        {
            Assert.AreNotEqual(expected, actual, string.Empty, null);
        }

        #endregion

        #endregion

        #region AreSame

        /// <summary>
        /// Asserts that two objects refer to the same object. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void AreSame(object expected, object actual, string message, params object[] args)
        {
            IncrementAssertCount();

            if (object.ReferenceEquals(expected, actual))
            {
                return;
            }

            Assert.Fail(
                "The two objects were expected to be the same. {0}",
                string.Format(message, args));
        }

        /// <summary>
        /// Asserts that two objects refer to the same object. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        public static void AreSame(object expected, object actual)
        {
            Assert.AreSame(expected, actual, string.Empty, null);
        }

        #endregion

        #region AreNotSame

        /// <summary>
        /// Asserts that two objects do not refer to the same object. Returns without throwing an exception when inside
        /// a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void AreNotSame(object expected, object actual, string message, params object[] args)
        {
            IncrementAssertCount();

            if (!object.ReferenceEquals(expected, actual))
            {
                return;
            }

            Assert.Fail(
                "The two objects were not expected to be the same. {0}",
                string.Format(message, args));
        }

        /// <summary>
        /// Asserts that two objects do not refer to the same object. Returns without throwing an exception when inside
        /// a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The actual object</param>
        public static void AreNotSame(object expected, object actual)
        {
            Assert.AreNotSame(expected, actual, string.Empty, null);
        }

        #endregion

        #region Helper Methods

        private static bool ElementsEqual(IEnumerable expected, IEnumerable actual, out string failMessage)
        {
            failMessage = string.Empty;
            if (expected == null && actual == null)
                return true;
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            IEnumerator expectedEnumerator = null;
            IEnumerator actualEnumerator = null;
            try
            {
                expectedEnumerator = expected.GetEnumerator();
                actualEnumerator = actual.GetEnumerator();

                bool expectedHasElement;
                do
                {
                    expectedHasElement = expectedEnumerator.MoveNext();
                    bool actualHasElement = actualEnumerator.MoveNext();
                    if (expectedHasElement != actualHasElement)
                    {
                        failMessage = "Collection do not have the same number of elements";
                        return false;
                    }
                    if (expectedHasElement)
                    {
                        bool equalElements = Assert.ObjectsEqual(expectedEnumerator.Current, actualEnumerator.Current);
                        if (!equalElements)
                        {
                            failMessage = "Element of the collection different";
                            return false;
                        }
                    }
                } while (expectedHasElement);
                return true;
            }
            finally
            {
                IDisposable disp = expectedEnumerator as IDisposable;
                if (disp != null)
                    disp.Dispose();
                disp = actualEnumerator as IDisposable;
                if (disp != null)
                    disp.Dispose();

            }
        }

        private static void AreEquivalent(ICollection expected, ICollection actual, string message, params object[] args)
        {
            bool found;
            bool foundAll = true;

            foreach (object o in expected)
            {
                //do a check to see if it is in the collection already
                found = CheckItemInCollection(actual, o);

                if (!found)
                {
                    foundAll = false;
                    break;
                }
            }

            if (foundAll)
            {
                foreach (object o in actual)
                {
                    found = CheckItemInCollection(expected, o);

                    if (!found)
                    {
                        foundAll = false;
                        break;
                    }
                }
            }

            if (!foundAll)
            {
                if (args != null)
                    Assert.Fail(message, args);
                else
                    Assert.Fail(message);
            }
        }

        private static bool CheckItemInCollection(ICollection collection, object item)
        {
            //Reused Arraylist's implementation of Contains, uses Equals override and null checking of items

            IList list = new ArrayList();
            foreach (var record in collection)
            {
                list.Add(record);
            }

            return list.Contains(item);
        }

        private static bool ObjectsEqual(object expected, object actual)
        {
            if (IsNumericType(expected) && IsNumericType(actual))
            {
                string sExpected = expected.ToString();
                string sActual = actual.ToString();

                return sExpected.Equals(sActual);
            }
            else if (IsArrayType(expected) && IsArrayType(actual))
            {
                return ElementsEqual((IEnumerable)expected, (IEnumerable)actual, out string failMessage);
            }
            else
            {
                return object.Equals(expected, actual);
            }
        }

        private static bool IsArrayType(object obj)
        {
            bool isArrayType = false;

            if (obj != null)
            {
                isArrayType = obj.GetType().IsArray;
            }
            
            return isArrayType;
        }

        private static bool IsNumericType(object obj)
        {
            if (null != obj)
            {
                if (obj is byte) return true;
                if (obj is sbyte) return true;
                if (obj is double) return true;
                if (obj is float) return true;
                if (obj is int) return true;
                if (obj is uint) return true;
                if (obj is long) return true;
                if (obj is short) return true;
                if (obj is ushort) return true;

                if (obj is Byte) return true;
                if (obj is SByte) return true;
                if (obj is Double) return true;
                if (obj is Single) return true;
                if (obj is Int32) return true;
                if (obj is UInt32) return true;
                if (obj is Int64) return true;
                if (obj is UInt64) return true;
                if (obj is Int16) return true;
                if (obj is UInt16) return true;
            }

            return false;
        }

        private static void AssertDoublesAreEqual(double expected, double actual, double delta, string message, object[] args)
        {
            if (double.IsNaN(expected) || double.IsInfinity(expected))
            {
                Assert.AreEqual(expected, actual, message, args);
            }
            else
            {
                Assert.AreEqual(expected, actual, delta, message, args);
            }
        }

        #endregion
    }
}