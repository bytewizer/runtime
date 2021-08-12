// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

#nullable enable

using System;

namespace Bytewizer.TinyCLR.Assertions
{
    public abstract partial class Assert
    {
        #region Throws

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called. The returned exception may be <see
        /// langword="null"/> when inside a multiple assert block.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A test delegate action</param>
        /// <param name="message">The message that will be displayed on failure</param>
        /// <param name="args">Arguments to be used in formatting the message</param>
        public static void Throws(Type expectedExceptionType, Action code, string? message, params object?[]? args)
        {
            try
            {
                code.Invoke();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == expectedExceptionType)
                {
                    return;
                }

                Assert.Fail(
                    "An exception {0} has been thrown but is not type {1}. {2}",
                    ex.GetType(), expectedExceptionType, message);
            }

            Assert.Fail(
                "No exception has been thrown. {0}",
                message);
        }

        /// <summary>
        /// Verifies that a delegate throws a particular exception when called. The returned exception may be <see
        /// langword="null"/> when inside a multiple assert block.
        /// </summary>
        /// <param name="expectedExceptionType">The exception Type expected</param>
        /// <param name="code">A TestDelegate</param>
        public static void Throws(Type expectedExceptionType, Action code)
        {
            Throws(expectedExceptionType, code, string.Empty, null);
        }

        #endregion
    }
}
