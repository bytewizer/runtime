// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;
using System.Collections;

#if NanoCLR
namespace Bytewizer.NanoCLR.Assertions
#else
namespace Bytewizer.TinyCLR.Assertions
#endif
{
    public abstract partial class Assert
    {
        #region True

        /// <summary>
        /// Asserts that a condition is true. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void True(bool condition, string message, params object[] args)
        {
            IncrementAssertCount();

            if (!condition)
            {
                Assert.Fail(message, args);
            }
        }

        /// <summary>
        /// Asserts that a condition is true. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        public static void True(bool condition)
        {
            Assert.True(condition, string.Empty, null);
        }

        /// <summary>
        /// Asserts that a condition is true. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsTrue(bool condition, string message, params object[] args)
        {
            IncrementAssertCount();

            if (!condition)
            {
                Assert.Fail(message, args);
            }
        }

        /// <summary>
        /// Asserts that a condition is true. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="condition">The evaluated condition</param>
        public static void IsTrue(bool condition)
        {
            Assert.True(condition, string.Empty, null);
        }

        #endregion

        #region False

        /// <summary>
        /// Asserts that a condition is false. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void False(bool condition, string message, params object[] args)
        {
            IncrementAssertCount();

            if (condition)
            {
                Assert.Fail(message, args);
            }
        }

        /// <summary>
        /// Asserts that a condition is false. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        public static void False(bool condition)
        {
            Assert.False(condition, string.Empty, null);
        }

        /// <summary>
        /// Asserts that a condition is false. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsFalse(bool condition, string message, params object[] args)
        {
            Assert.False(condition, message, args);
        }

        /// <summary>
        /// Asserts that a condition is false. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary> 
        /// <param name="condition">The evaluated condition</param>
        public static void IsFalse(bool condition)
        {
            Assert.False(condition, string.Empty, null);
        }

        #endregion

        #region NotNull

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotNull(object anObject, string message, params object[] args)
        {
           Assert.IsTrue(anObject != null, message, args);
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        public static void NotNull(object anObject)
        {
            Assert.NotNull(anObject, string.Empty, null);
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNotNull(object anObject, string message, params object[] args)
        {
            Assert.NotNull(anObject, message, args);
        }

        /// <summary>
        /// Verifies that the object that is passed in is not equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        public static void IsNotNull(object anObject)
        {
            Assert.NotNull(anObject, string.Empty, null);
        }

        #endregion

        #region Null

        /// <summary>
        /// Verifies that the object that is passed in is equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Null(object anObject, string message, params object[] args)
        {
            Assert.IsTrue(anObject == null, message, args);
        }

        /// <summary>
        /// Verifies that the object that is passed in is equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        public static void Null(object anObject)
        {
            Assert.Null(anObject, string.Empty, null);
        }

        /// <summary>
        /// Verifies that the object that is passed in is equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNull(object anObject, string message, params object[] args)
        {
            Assert.Null(anObject, message, args);
        }

        /// <summary>
        /// Verifies that the object that is passed in is equal to <see langword="null"/>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="anObject">The object that is to be tested</param>
        public static void IsNull(object anObject)
        {
            Assert.Null(anObject, string.Empty, null);
        }

        #endregion

        #region IsNaN

        /// <summary>
        /// Verifies that the double that is passed in is an <c>NaN</c>. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNaN(double aDouble, string message, params object[] args)
        {
            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifies that the double that is passed in is an <c>NaN</c> value. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="aDouble">The value that is to be tested</param>
        public static void IsNaN(double aDouble)
        {
            Assert.IsNaN(aDouble, string.Empty, null);
        }

        #endregion

        #region IsEmpty

        #region String

        /// <summary>
        /// Assert that a string is empty. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsEmpty(string aString, string message, params object[] args)
        {
            if (aString != "" || !aString.Equals(string.Empty))
            {
                if (args != null)
                {
                    FailIsNotEmpty(aString, message, args);
                }
                else
                {
                    FailIsNotEmpty(aString, message);
                }
            }
        }

        /// <summary>
        /// Assert that a string is empty. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        public static void IsEmpty(string aString)
        {
            Assert.IsEmpty(aString, string.Empty, null);
        }

        #endregion

        #region Collection

        /// <summary>
        /// Assert that an array, list or other collection is empty. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsEmpty(ICollection collection, string message, params object[] args)
        {
            if (collection.Count != 0)
            {
                if (args != null)
                {
                    FailIsNotEmpty(collection, message, args);
                }
                else
                {
                    FailIsNotEmpty(collection, message);
                }
            }
        }

        /// <summary>
        /// Assert that an array, list or other collection is empty. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        public static void IsEmpty(ICollection collection)
        {
            Assert.IsEmpty(collection, string.Empty, null);
        }

        #endregion

        #endregion

        #region IsNotEmpty

        #region String

        /// <summary>
        /// Assert that a string is not empty. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNotEmpty(string aString, string message, params object[] args)
        {
            if (aString == "" || aString.Equals(string.Empty))
            {
                if (args != null)
                {
                    FailIsEmpty(aString, message, args);
                }
                else
                    FailIsEmpty(aString, message);
            }
        }

        /// <summary>
        /// Assert that a string is not empty. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="aString">The string to be tested</param>
        public static void IsNotEmpty(string aString)
        {
            Assert.IsNotEmpty(aString, string.Empty, null);
        }

        #endregion

        #region Collection

        /// <summary>
        /// Assert that an array, list or other collection is not empty. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNotEmpty(ICollection collection, string message, params object[] args)
        {
            if (collection.Count == 0)
            {
                if (args != null)
                {
                    FailIsNotEmpty(collection, message, args);
                }
                else
                {
                    FailIsNotEmpty(collection, message);
                }
            }
        }

        /// <summary>
        /// Assert that an array, list or other collection is not empty. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="collection">An array, list or other collection implementing ICollection</param>
        public static void IsNotEmpty(ICollection collection)
        {
            Assert.IsNotEmpty(collection, string.Empty, null);
        }

        #endregion

        #endregion

        #region Zero

        #region Ints

        /// <summary>
        /// Asserts that an int is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(int actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that an int is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(int actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #region UnsignedInts

        /// <summary>
        /// Asserts that an unsigned int is zero. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(uint actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that an unsigned int is zero. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(uint actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Asserts that a Long is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(long actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that a Long is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(long actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #region UnsignedLongs

        /// <summary>
        /// Asserts that an unsigned Long is zero. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(ulong actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that an unsigned Long is zero. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(ulong actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Asserts that a double is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(double actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that a double is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(double actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #region Floats

        /// <summary>
        /// Asserts that a float is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Zero(float actual)
        {
            Assert.True(actual == 0);
        }

        /// <summary>
        /// Asserts that a float is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Zero(float actual, string message, params object[] args)
        {
            Assert.True(actual == 0, message, args);
        }

        #endregion

        #endregion

        #region NotZero

        #region Ints

        /// <summary>
        /// Asserts that an int is not zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(int actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that an int is not zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(int actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #region UnsignedInts

        /// <summary>
        /// Asserts that an unsigned int is not zero. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(uint actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that an unsigned int is not zero. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(uint actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Asserts that a Long is not zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(long actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that a Long is not zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(long actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #region UnsignedLongs

        /// <summary>
        /// Asserts that an unsigned Long is not zero. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(ulong actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that an unsigned Long is not zero. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(ulong actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Asserts that a double is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(double actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that a double is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(double actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #region Floats

        /// <summary>
        /// Asserts that a float is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void NotZero(float actual)
        {
            Assert.True(actual != 0);
        }

        /// <summary>
        /// Asserts that a float is zero. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void NotZero(float actual, string message, params object[] args)
        {
            Assert.True(actual != 0, message, args);
        }

        #endregion

        #endregion

        #region Positive

        #region Ints

        /// <summary>
        /// Asserts that an int is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(int actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that an int is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(int actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #region UnsignedInts

        /// <summary>
        /// Asserts that an unsigned int is positive. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(uint actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that an unsigned int is positive. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(uint actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Asserts that a Long is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(long actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that a Long is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(long actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #region UnsignedLongs

        /// <summary>
        /// Asserts that an unsigned Long is positive. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(ulong actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that an unsigned Long is positive. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(ulong actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Asserts that a double is positive. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(double actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that a double is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(double actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #region Floats

        /// <summary>
        /// Asserts that a float is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Positive(float actual)
        {
            Assert.True(actual > 0);
        }

        /// <summary>
        /// Asserts that a float is positive. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Positive(float actual, string message, params object[] args)
        {
            Assert.True(actual > 0, message, args);
        }

        #endregion

        #endregion

        #region Negative

        #region Ints

        /// <summary>
        /// Asserts that an int is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(int actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that an int is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(int actual, string message, params object[] args)
        {
            Assert.True(actual < 0);
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #region UnsignedInts

        /// <summary>
        /// Asserts that an unsigned int is negative. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(uint actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that an unsigned int is negative. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(uint actual, string message, params object[] args)
        {
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #region Longs

        /// <summary>
        /// Asserts that a Long is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(long actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that a Long is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(long actual, string message, params object[] args)
        {
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #region UnsignedLongs

        /// <summary>
        /// Asserts that an unsigned Long is negative. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(ulong actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that an unsigned Long is negative. Returns without throwing an exception when inside a multiple
        /// assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(ulong actual, string message, params object[] args)
        {
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #region Doubles

        /// <summary>
        /// Asserts that a double is negative. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(double actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that a double is negative. Returns without throwing an exception when inside a multiple assert
        /// block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(double actual, string message, params object[] args)
        {
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #region Floats

        /// <summary>
        /// Asserts that a float is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        public static void Negative(float actual)
        {
            Assert.True(actual < 0);
        }

        /// <summary>
        /// Asserts that a float is negative. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        /// <param name="actual">The number to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Negative(float actual, string message, params object[] args)
        {
            Assert.True(actual < 0, message, args);
        }

        #endregion

        #endregion

        private static void FailIsEmpty(object expected, string message, params object[] args)
        {
            Assert.Fail(
                "The object was expected to be empty but was not. {0}",
                string.Format(message,  args));
        }

        private static void FailIsNotEmpty(object expected, string format, params object[] args)
        {
            string formatted = string.Empty;
            
            if (format != null)
            {
                formatted = format + " ";
            }

            Assert.Fail(format + "The object was expected not to be empty but was", args);
        }
    }
}
