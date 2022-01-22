// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

namespace Bytewizer.TinyCLR.Assertions
{
    public abstract partial class Assert
    {
        #region IsAssignableFrom

        /// <summary>
        /// Asserts that an object may be assigned a value of a given Type. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsAssignableFrom(Type expected, object actual, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that an object may be assigned a value of a given Type. Returns without throwing an exception when
        /// inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        public static void IsAssignableFrom(Type expected, object actual)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region IsNotAssignableFrom

        /// <summary>
        /// Asserts that an object may not be assigned a value of a given Type. Returns without throwing an exception
        /// when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNotAssignableFrom(Type expected, object actual, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that an object may not be assigned a value of a given Type. Returns without throwing an exception
        /// when inside a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type.</param>
        /// <param name="actual">The object under examination</param>
        public static void IsNotAssignableFrom(Type expected, object actual)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region IsInstanceOf

        /// <summary>
        /// Asserts that an object is an instance of a given type. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsInstanceOf(Type expected, object actual, string message, params object[] args)
        {
          if (actual == null)
            { 
                return;
            }

            Assert.True(expected.IsInstanceOfType(actual), message, args);
        }

        /// <summary>
        /// Asserts that an object is an instance of a given type. Returns without throwing an exception when inside a
        /// multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        public static void IsInstanceOf(Type expected, object actual)
        {
            Assert.IsInstanceOf(expected, actual, null, null);
        }
        
        #endregion

        #region IsNotInstanceOf

        /// <summary>
        /// Asserts that an object is not an instance of a given type. Returns without throwing an exception when inside
        /// a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        /// <param name="message">The message to display in case of failure</param>
        /// <param name="args">Array of objects to be used in formatting the message</param>
        public static void IsNotInstanceOf(Type expected, object actual, string message, params object[] args)
        {
            if (actual == null)
            {
                return;
            }

            Assert.True(!expected.IsInstanceOfType(actual), message, args);
        }

        /// <summary>
        /// Asserts that an object is not an instance of a given type. Returns without throwing an exception when inside
        /// a multiple assert block.
        /// </summary>
        /// <param name="expected">The expected Type</param>
        /// <param name="actual">The object being examined</param>
        public static void IsNotInstanceOf(Type expected, object actual)
        {
            Assert.IsNotInstanceOf(expected, actual, null, null);
        }
        
        #endregion
    }
}