// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;
using System.ComponentModel;

namespace Bytewizer.TinyCLR.Assertions
{
    /// <summary>
    /// Basic Asserts on strings.
    /// </summary>
    // Abstract because we support syntax extension by inheriting and declaring new static members.
    public abstract class StringAssert
    {
        #region Equals and ReferenceEquals

        /// <summary>
        /// DO NOT USE! Use StringAssert.AreEqualIgnoringCase(...) or Assert.AreEqual(...) instead.
        /// The Equals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable IDE0060 // Remove unused parameter
        public static new bool Equals(object a, object b)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            throw new InvalidOperationException("StringAssert.Equals should not be used. Use StringAssert.AreEqualIgnoringCase or Assert.AreEqual instead.");
        }

        /// <summary>
        /// DO NOT USE!
        /// The ReferenceEquals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable IDE0060 // Remove unused parameter
        public static new void ReferenceEquals(object a, object b)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            throw new InvalidOperationException("StringAssert.ReferenceEquals should not be used.");
        }

        #endregion

        #region Contains

        /// <summary>
        /// Asserts that a string is found within another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void Contains(string expected, string actual, string message, params object[] args)
        {
            Assert.True(expected.Contains(actual),
                "String {0} does not contain {1} {2}",
                expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string is found within another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void Contains(string expected, string actual)
        {
            Contains(expected, actual, string.Empty, null);
        }

        #endregion

        #region DoesNotContain

        /// <summary>
        /// Asserts that a string is not found within another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void DoesNotContain(string expected, string actual, string message, params object[] args)
        {
            Assert.True(!actual.Contains(expected),
                "String {0} does not contain {1} {2}",
                actual, expected, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string is found within another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void DoesNotContain(string expected, string actual)
        {
            DoesNotContain(expected, actual, string.Empty, null);
        }

        #endregion

        #region StartsWith

        /// <summary>
        /// Asserts that a string starts with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void StartsWith(string expected, string actual, string message, params object[] args)
        {
           Assert.True(expected.StartsWith(actual), 
               "String {0} starts with {1} {2}",
                expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string starts with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void StartsWith(string expected, string actual)
        {
            StartsWith(expected, actual, string.Empty, null);
        }

        #endregion

        #region DoesNotStartWith

        /// <summary>
        /// Asserts that a string does not start with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void DoesNotStartWith(string expected, string actual, string message, params object[] args)
        {
            Assert.True(!expected.StartsWith(actual), 
                "String {0} does not start with {1} {2}",
                expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string does not start with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void DoesNotStartWith(string expected, string actual)
        {
            DoesNotStartWith(expected, actual, string.Empty, null);
        }

        #endregion

        #region EndsWith

        /// <summary>
        /// Asserts that a string ends with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void EndsWith(string expected, string actual, string message, params object[] args)
        {
            Assert.True(expected.EndsWith(actual), 
                "String {0} ends with {1} {2}",
                expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string ends with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void EndsWith(string expected, string actual)
        {
            EndsWith(expected, actual, string.Empty, null);
        }

        #endregion

        #region DoesNotEndWith

        /// <summary>
        /// Asserts that a string does not end with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void DoesNotEndWith(string expected, string actual, string message, params object[] args)
        {
            Assert.True(!expected.EndsWith(actual),
                "String {0} does not ends with {1} {2}",
                expected, actual, string.Format(message, args));
        }

        /// <summary>
        /// Asserts that a string does not end with another string.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The string to be examined</param>
        public static void DoesNotEndWith(string expected, string actual)
        {
            DoesNotEndWith(expected, actual, string.Empty, null);
        }

        #endregion

        #region AreEqualIgnoringCase

        /// <summary>
        /// Asserts that two strings are equal, without regard to case.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The actual string</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void AreEqualIgnoringCase(string expected, string actual, string message, params object[] args)
        {
            if (expected == null || actual == null)
            {
                Assert.AreEqual(expected, actual, message, args);
            }
            else
            {
                Assert.AreEqual(expected.ToLower(), actual.ToLower(), message, args);
            }
        }

        /// <summary>
        /// Asserts that two strings are equal, without regard to case.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The actual string</param>
        public static void AreEqualIgnoringCase(string expected, string actual)
        {
            AreEqualIgnoringCase(expected, actual, string.Empty, null);
        }

        #endregion

        #region AreNotEqualIgnoringCase

        /// <summary>
        /// Asserts that two strings are not equal, without regard to case.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The actual string</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Arguments used in formatting the message</param>
        public static void AreNotEqualIgnoringCase(string expected, string actual, string message, params object[] args)
        {
            if (expected == null || actual == null)
            {
                Assert.AreNotEqual(expected, actual, message, args);
            }
            else
            {
                Assert.AreNotEqual(expected.ToLower(), actual.ToLower(), message, args);
            }
        }

        /// <summary>
        /// Asserts that two strings are not equal, without regard to case.
        /// </summary>
        /// <param name="expected">The expected string</param>
        /// <param name="actual">The actual string</param>
        public static void AreNotEqualIgnoringCase(string expected, string actual)
        {
            AreNotEqualIgnoringCase(expected, actual, string.Empty, null);
        }

        #endregion
    }
}
