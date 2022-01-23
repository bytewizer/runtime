// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;
using System.Collections;
using System.ComponentModel;

#if NanoCLR
namespace Bytewizer.NanoCLR.Assertions
#else
namespace Bytewizer.TinyCLR.Assertions
#endif
{
    /// <summary>
    /// A set of Assert methods operating on one or more collections
    /// </summary>
    // Abstract because we support syntax extension by inheriting and declaring new static members.
    public abstract class CollectionAssert
    {
        #region Equals and ReferenceEquals

        /// <summary>
        /// DO NOT USE! Use CollectionAssert.AreEqual(...) instead.
        /// The Equals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new bool Equals(object a, object b)
        {
            throw new InvalidOperationException("CollectionAssert.Equals should not be used. Use CollectionAssert.AreEqual instead.");
        }

        /// <summary>
        /// DO NOT USE!
        /// The ReferenceEquals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static new void ReferenceEquals(object a, object b)
        {
            throw new InvalidOperationException("CollectionAssert.ReferenceEquals should not be used.");
        }

        #endregion

        #region AllItemsAreInstancesOfType

        /// <summary>
        /// Asserts that all items contained in collection are of the type specified by expectedType.
        /// </summary>
        /// <param name="collection">IEnumerable containing objects to be considered</param>
        /// <param name="expectedType">System.Type that all objects in collection must be instances of</param>
        public static void AllItemsAreInstancesOfType(IEnumerable collection, Type expectedType)
        {
            AllItemsAreInstancesOfType(collection, expectedType, string.Empty, null);
        }

        /// <summary>
        /// Asserts that all items contained in collection are of the type specified by expectedType.
        /// </summary>
        /// <param name="collection">IEnumerable containing objects to be considered</param>
        /// <param name="expectedType">System.Type that all objects in collection must be instances of</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AllItemsAreInstancesOfType(IEnumerable collection, Type expectedType, string message, params object[] args)
        {
            bool fail = false;

            foreach (object o in collection)
            {
                if (o.GetType() != expectedType)
                {
                    fail = true;
                    break;
                }
            }

            if (fail)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region AllItemsAreNotNull

        /// <summary>
        /// Asserts that all items contained in collection are not equal to null.
        /// </summary>
        /// <param name="collection">IEnumerable containing objects to be considered</param>
        public static void AllItemsAreNotNull(IEnumerable collection)
        {
            AllItemsAreNotNull(collection, string.Empty, null);
        }

        /// <summary>
        /// Asserts that all items contained in collection are not equal to null.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AllItemsAreNotNull(IEnumerable collection, string message, params object[] args)
        {
            bool fail = false;

            foreach (object o in collection)
            {
                if (o == null)
                {
                    fail = true;
                    break;
                }
            }

            if (fail)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region AllItemsAreUnique

        /// <summary>
        /// Ensures that every object contained in collection exists within the collection
        /// once and only once.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        public static void AllItemsAreUnique(IEnumerable collection)
        {
            AllItemsAreUnique(collection, string.Empty, null);
        }

        /// <summary>
        /// Ensures that every object contained in collection exists within the collection
        /// once and only once.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AllItemsAreUnique(IEnumerable collection, string message, params object[] args)
        {
            bool fail = false;
            ArrayList arr = new ArrayList();

            foreach (object o in collection)
            {
                //do a check to see if it is in the collection already
                if (arr.Contains(o))
                {
                    fail = true;
                    break;
                }
                else
                {
                    arr.Add(o);
                }
            }

            if (fail)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region AreEqual

        /// <summary>
        /// Asserts that expected and actual are exactly equal.  The collections must have the same count,
        /// and contain the exact same objects in the same order.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        public static void AreEqual(IEnumerable expected, IEnumerable actual)
        {
            AreEqual(expected, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that expected and actual are exactly equal.  The collections must have the same count,
        /// and contain the exact same objects in the same order.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AreEqual(IEnumerable expected, IEnumerable actual, string message, params object[] args)
        {
            {
                if (expected == null && actual == null)
                {
                    return;
                }

                var item1 = expected as ICollection;
                var item2 = expected as ICollection;

                Assert.IsNotNull(expected);
                Assert.IsNotNull(actual);

                AreCountEqual(item1.Count, item2);
                AreElementsEqual(expected, actual);
            }
        }

        #endregion

        #region AreEquivalent

        /// <summary>
        /// Asserts that expected and actual are equivalent, containing the same objects but the match may be in any order.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        public static void AreEquivalent(IEnumerable expected, IEnumerable actual)
        {
            AreEquivalent(expected, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that expected and actual are equivalent, containing the same objects but the match may be in any order.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AreEquivalent(IEnumerable expected, IEnumerable actual, string message, params object[] args)
        {
            bool found;
            bool foundAll = true;

            foreach (object o in expected)
            {
                found = CheckItemInCollection(actual as ICollection, o);

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
                    found = CheckItemInCollection(expected as ICollection, o);

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
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region AreNotEqual

        /// <summary>
        /// Asserts that expected and actual are not exactly equal.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        public static void AreNotEqual(IEnumerable expected, IEnumerable actual)
        {
            AreNotEqual(expected, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that expected and actual are not exactly equal.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AreNotEqual(IEnumerable expected, IEnumerable actual, string message, params object[] args)
        {
            bool needToFail = false;

            try
            {
                AreEqual(expected, actual);
                needToFail = true;
            }
            catch (AssertionException)
            {
                //Do Nothing as expected
            }

            if (needToFail)
            {
                Assert.Fail(message, args);
            }
        }

        #endregion

        #region AreNotEquivalent

        /// <summary>
        /// Asserts that expected and actual are not equivalent.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        public static void AreNotEquivalent(IEnumerable expected, IEnumerable actual)
        {
            AreNotEquivalent(expected, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that expected and actual are not equivalent.
        /// </summary>
        /// <param name="expected">The first IEnumerable of objects to be considered</param>
        /// <param name="actual">The second IEnumerable of objects to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void AreNotEquivalent(IEnumerable expected, IEnumerable actual, string message, params object[] args)
        {
            bool needToFail = false;

            try
            {
                AreEquivalent(expected, actual, message, args);
                needToFail = true;

            }
            catch (AssertionException)
            {
                //Do Nothing as expected
            }

            if (needToFail)
            {
                Assert.Fail(message, args);
            }
        }

        #endregion

        #region Contains

        /// <summary>
        /// Asserts that collection contains actual as an item.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="actual">Object to be found within collection</param>
        public static void Contains(IEnumerable collection, Object actual)
        {
            Contains(collection, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that collection contains actual as an item.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="actual">Object to be found within collection</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void Contains(IEnumerable collection, Object actual, string message, params object[] args)
        {
            bool found;
            found = CheckItemInCollection(collection as ICollection, actual);

            if (!found)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region DoesNotContain

        /// <summary>
        /// Asserts that collection does not contain actual as an item.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="actual">Object that cannot exist within collection</param>
        public static void DoesNotContain(IEnumerable collection, Object actual)
        {
            DoesNotContain(collection, actual, string.Empty, null);
        }

        /// <summary>
        /// Asserts that collection does not contain actual as an item.
        /// </summary>
        /// <param name="collection">IEnumerable of objects to be considered</param>
        /// <param name="actual">Object that cannot exist within collection</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void DoesNotContain(IEnumerable collection, object actual, string message, params object[] args)
        {
            bool needToFail = false;

            try
            {
                Contains(collection, actual, message, args);

                needToFail = true;
            }
            catch (AssertionException)
            {
                //Do Nothing as expected
            }

            if (needToFail)
            {
                Assert.Fail(message, args);
            }
        }

        #endregion

        #region IsNotSubsetOf

        /// <summary>
        /// Asserts that the superset does not contain the subset
        /// </summary>
        /// <param name="subset">The IEnumerable subset to be considered</param>
        /// <param name="superset">The IEnumerable superset to be considered</param>
        public static void IsNotSubsetOf(IEnumerable subset, IEnumerable superset)
        {
            IsNotSubsetOf(subset, superset, string.Empty, null);
        }

        /// <summary>
        /// Asserts that the superset does not contain the subset
        /// </summary>
        /// <param name="subset">The IEnumerable subset to be considered</param>
        /// <param name="superset">The IEnumerable superset to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void IsNotSubsetOf(IEnumerable subset, IEnumerable superset, string message, params object[] args)
        {
            bool needToFail = false;
            try
            {
                IsSubsetOf(subset, superset, message, args);

                needToFail = true;

            }
            catch (AssertionException)
            {
                //Do Nothing as expected
            }

            if (needToFail)
            {
                Assert.Fail(message, args);
            }
        }

        #endregion

        #region IsSubsetOf

        /// <summary>
        /// Asserts that the superset contains the subset.
        /// </summary>
        /// <param name="subset">The IEnumerable subset to be considered</param>
        /// <param name="superset">The IEnumerable superset to be considered</param>
        public static void IsSubsetOf(IEnumerable subset, IEnumerable superset)
        {
            IsSubsetOf(subset, superset, string.Empty, null);
        }

        /// <summary>
        /// Asserts that the superset contains the subset.
        /// </summary>
        /// <param name="subset">The IEnumerable subset to be considered</param>
        /// <param name="superset">The IEnumerable superset to be considered</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void IsSubsetOf(IEnumerable subset, IEnumerable superset, string message, params object[] args)
        {
            bool foundAll = true;

            //All of superset are in subset
            foreach (object o in subset)
            {
                bool found = CheckItemInCollection(superset as ICollection, o);
                if (!found)
                {
                    foundAll = false;
                    break;
                }
            }

            if (!foundAll)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// Assert that an array, list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing IEnumerable</param>
        /// <param name="message">The message to be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void IsEmpty(IEnumerable collection, string message, params object[] args)
        {
            var items = collection as ICollection;

            if (items.Count != 0)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        /// <summary>
        /// Assert that an array,list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing IEnumerable</param>
        public static void IsEmpty(ICollection collection)
        {
            IsEmpty(collection, string.Empty, null);
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// Assert that an array, list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing IEnumerable</param>
        /// <param name="message">The message to be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void IsNotEmpty(IEnumerable collection, string message, params object[] args)
        {
            var items = collection as ICollection;

            if (items.Count == 0)
            {
                if (args != null)
                {
                    Assert.Fail(message, args);
                }
                else
                {
                    Assert.Fail(message);
                }
            }
        }

        /// <summary>
        /// Assert that an array,list or other collection is empty
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing IEnumerable</param>
        public static void IsNotEmpty(ICollection collection)
        {
            IsNotEmpty(collection, string.Empty, null);
        }
        #endregion

        #region Helper Methods

        private static bool CheckItemInCollection(ICollection collection, object item)
        {
            IList list = new ArrayList();

            foreach (var record in collection)
            {
                list.Add(record);
            }
            
            return list.Contains(item);
        }

        private static void AreElementsEqual(IEnumerable expected, IEnumerable actual)
        {

            bool areEqual = ElementsEqual(expected, actual, out string failMessage);
            if (!areEqual)
            {
                Assert.Fail(failMessage);
            }
        }

        private static void AreCountEqual(int expected, ICollection actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count,
                "Property Count not equal");
        }

        private static bool ElementsEqual(IEnumerable expected, IEnumerable actual, out string failMessage)
        {
            failMessage = string.Empty;

            if (expected == null && actual == null)
            {
                return true;
            }

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
                        bool equalElements = ObjectsEqual(expectedEnumerator.Current, actualEnumerator.Current);
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
                if (expectedEnumerator is IDisposable disp)
                {
                    disp.Dispose();
                }

                disp = actualEnumerator as IDisposable;
                if (disp != null)
                {
                    disp.Dispose();
                }
            }
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

        #endregion
    }
}
