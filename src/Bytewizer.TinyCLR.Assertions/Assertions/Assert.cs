// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

#nullable enable

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

namespace Bytewizer.TinyCLR.Assertions
{
    /// <summary>
    /// The Assert class contains a collection of static methods that implement the most common assertions.
    /// </summary>
    // Abstract because we support syntax extension by inheriting and declaring new static members.
    public abstract partial class Assert
    {
        private static int assertCount = 0;

        #region Equals and ReferenceEquals

        /// <summary>
        /// DO NOT USE! Use Assert.AreEqual(...) instead.
        /// The Equals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new bool Equals(object a, object b)
        {
            throw new InvalidOperationException("Assert.Equals should not be used. Use Assert.AreEqual instead.");
        }

        /// <summary>
        /// DO NOT USE!
        /// The ReferenceEquals method throws an InvalidOperationException. This is done
        /// to make sure there is no mistake by calling this function.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new void ReferenceEquals(object a, object b)
        {
            throw new InvalidOperationException("Assert.ReferenceEquals should not be used. Use Assert.AreSame instead.");
        }

        #endregion

        #region Pass

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        static public void Pass(string? message, params object?[]? args)
        {
            if (message == null)
            {
                message = string.Empty;
            }
            else if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }

            throw new SuccessException(message);
        }

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        static public void Pass(string? message)
        {
            Assert.Pass(message, null);
        }

        /// <summary>
        /// Throws a <see cref="SuccessException"/> with the message and arguments
        /// that are passed in. This allows a test to be cut short, with a result
        /// of success returned.
        /// </summary>
        static public void Pass()
        {
            Assert.Pass(string.Empty, null);
        }

        #endregion

        #region Fail

        /// <summary>
        /// Marks the test as failed with the message and arguments that are passed in. Returns without throwing an
        /// exception when inside a multiple assert block.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        static public void Fail(string? message, params object?[]? args)
        {
            if (message == null)
            {
                message = string.Empty;
            }
            else if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }

            throw new AssertionException(message);
        }

        /// <summary>
        /// Marks the test as failed with the message that is passed in. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="message">The message to initialize the <see cref="AssertionException"/> with.</param>
        static public void Fail(string? message)
        {
            Assert.Fail(message, null);
        }

        /// <summary>
        /// Marks the test as failed. Returns without throwing an exception when inside a multiple assert block.
        /// </summary>
        static public void Fail()
        {
            Assert.Fail(string.Empty, null);
        }

        #endregion

        #region Contains

        /// <summary>
        /// Asserts that an object is contained in a collection. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The collection to be examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void Contains(object? expected, ICollection? actual, string? message, params object?[]? args)
        {
            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that an object is contained in a collection. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The collection to be examined</param>
        public static void Contains(object? expected, ICollection? actual)
        {
            // TODO
            throw new NotImplementedException();
        }

        #endregion

        #region Assert Count

        /// <summary>
        /// Number of Asserts made so far this test run
        /// </summary>
        public static int AssertCount
        {
            get { return assertCount; }
        }

        /// <summary>
        /// Resets <see cref="AssertCount"/> to 0
        /// </summary>
        public static void ResetAssertCount()
        {
            assertCount = 0;
        }

        #endregion

        #region Helper Methods

        private static void IncrementAssertCount()
        {
            assertCount++;
        }

        #endregion
    }
}
