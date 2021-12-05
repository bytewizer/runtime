using System;
using System.Collections;

using Bytewizer.TinyCLR.Assertions;

namespace Bytewizer.Playground.Assertions
{
    public class CollectionAssertTests : TestFixture
    {
        #region Equals and ReferenceEquals
        public void EqualsThrowsException()
        {
            object o = new object();
            Assert.Throws(typeof(InvalidOperationException), () => CollectionAssert.Equals(o, o));
        }

        public void ReferenceEqualsThrowsException()
        {
            object o = new object();
            Assert.Throws(typeof(InvalidOperationException), () => CollectionAssert.ReferenceEquals(o, o));
        }
        #endregion

        #region AllItemsAreInstancesOfType
        public void ItemsOfType()
        {
            ArrayList al = new ArrayList { "x", "y", "z" };
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string));
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test");
            CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test {0}", "1");
        }

        public void ItemsOfTypeFailMsg()
        {
            ArrayList al = new ArrayList { "x", "y", new object() };
            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test");
            });
        }

        public void ItemsOfTypeFailMsgParam()
        {
            ArrayList al = new ArrayList { "x", "y", new object() };
            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string), "test {0}", "1");
            });
        }

        public void ItemsOfTypeFailNoMsg()
        {
            ArrayList al = new ArrayList { "x", "y", new object() };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreInstancesOfType(al, typeof(string));
            });
        }
        #endregion

        #region AllItemsAreNotNull
        public void ItemsNotNull()
        {
            ArrayList al = new ArrayList { "x", "y", "z" };
            CollectionAssert.AllItemsAreNotNull(al);
            CollectionAssert.AllItemsAreNotNull(al, "test");
            CollectionAssert.AllItemsAreNotNull(al, "test {0}", "1");
        }

        public void ItemsNotNullFail()
        {
            ArrayList al = new ArrayList { "x", null, "z" };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreNotNull(al);
            });
        }

        public void ItemsNotNullFailMsgParam()
        {
            ArrayList al = new ArrayList { "x", null, "z" };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreNotNull(al, "test {0}", "1");
            });
        }

        public void ItemsNotNullFailMsg()
        {
            ArrayList al = new ArrayList { "x", null, "z" };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreNotNull(al, "test");
            });
        }
        #endregion

        #region AllItemsAreUnique
        public void Unique()
        {
            ArrayList al = new ArrayList
            {
                new object(),
                new object(),
                new object()
            };

            CollectionAssert.AllItemsAreUnique(al);
            CollectionAssert.AllItemsAreUnique(al, "test");
            CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");

            al = new ArrayList { "x", "y", "z" };

            CollectionAssert.AllItemsAreUnique(al);
            CollectionAssert.AllItemsAreUnique(al, "test");
            CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");
        }

        public void UniqueFail()
        {
            object x = new object();
            ArrayList al = new ArrayList { x, new object(), x };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreUnique(al);
            });
        }


        public void UniqueFailMsg()
        {
            object x = new object();
            ArrayList al = new ArrayList { x, new object(), x };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreUnique(al, "test");
            });
        }

        public void UniqueFailMsgParam()
        {
            object x = new object();
            ArrayList al = new ArrayList { x, new object(), x };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AllItemsAreUnique(al, "test {0}", "1");
            });
        }
        #endregion

        #region AreEqual
        public void AreEqual()
        {
            ArrayList arr = new ArrayList() { "One", "Two", "Three", "Four" };
            ArrayList arr2 = new ArrayList() { "One", "Two", "Three", "Four" };

            CollectionAssert.AreEqual(arr, arr2);
        }
        #endregion

        #region AreEquivalent
        public void Equivalent()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList set1 = new ArrayList { x, y, z };
            ArrayList set2 = new ArrayList { z, y, x };

            CollectionAssert.AreEquivalent(set1, set2);
            CollectionAssert.AreEquivalent(set1, set2, "test");
            CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
        }

        public void EquivalentFailOne()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList set1 = new ArrayList { x, y, z };
            ArrayList set2 = new ArrayList { x, y, x };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
            });
        }

        public void EquivalentFailTwo()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList set1 = new ArrayList { x, y, x };
            ArrayList set2 = new ArrayList { x, y, z };

            Assert.Throws(typeof(AssertionException), () =>
            {
                CollectionAssert.AreEquivalent(set1, set2, "test {0}", "1");
            });
        }
        #endregion

        #region AreNotEqual
        public void AreNotEqual()
        {
            ArrayList set1 = new ArrayList { "x", "y", "x" };
            ArrayList set2 = new ArrayList { "x", "y", "z" };

            CollectionAssert.AreNotEqual(set1, set2);
        }
        #endregion

        #region AreNotEquivalent
        public void NotEquivalent()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList set1 = new ArrayList { x, y, z };
            ArrayList set2 = new ArrayList { x, y, x };

            CollectionAssert.AreNotEquivalent(set1, set2);
            CollectionAssert.AreNotEquivalent(set1, set2, "test");
            CollectionAssert.AreNotEquivalent(set1, set2, "test {0}", "1");
        }
        #endregion

        #region Contains
        public void Contains()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList al = new ArrayList { x, y, z };

            CollectionAssert.Contains(al, x);
        }
        #endregion

        #region DoesNotContain
        public void DoesNotContain()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };
            Hashtable a = new Hashtable() { { 5, "Five" }, { 6, "Six" } };

            ArrayList al = new ArrayList { x, y, z };

            CollectionAssert.DoesNotContain(al, a);
            CollectionAssert.DoesNotContain(al, a, "test");
            CollectionAssert.DoesNotContain(al, a, "test {0}", "1");
        }
        #endregion

        #region IsSubsetOf
        public void IsSubsetOf()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };

            ArrayList set1 = new ArrayList { x, y };
            ArrayList set2 = new ArrayList { x, y, z };

            CollectionAssert.IsSubsetOf(set1, set2);
        }
        #endregion

        #region IsNotSubsetOf
        public void IsNotSubsetOf()
        {
            ArrayList x = new ArrayList() { "One", "Two", "Three", "Four" };
            Hashtable y = new Hashtable() { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" } };
            ArrayList z = new ArrayList() { "Five", 6, "Seven", 8 };
            
            ArrayList a = new ArrayList() { "Eight", 9, "Ten", 10 };

            ArrayList set1 = new ArrayList { x, y, a };
            ArrayList set2 = new ArrayList { x, y, z };

            CollectionAssert.IsNotSubsetOf(set1, set2);
            CollectionAssert.IsNotSubsetOf(set1, set2, "test");
            CollectionAssert.IsNotSubsetOf(set1, set2, "test {0}", "1");
        }
        #endregion
    }
}