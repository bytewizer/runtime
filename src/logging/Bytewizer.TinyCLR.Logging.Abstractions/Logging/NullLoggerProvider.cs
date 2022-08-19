// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// Provider for the <see cref="NullLogger"/>.
    /// </summary>
    public class NullLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// Returns the shared instance of <see cref="NullLoggerProvider"/>.
        /// </summary>
        public static NullLoggerProvider Instance { get; } = new NullLoggerProvider();

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            return NullLogger.Instance;
        }

        /// <inheritdoc />
        public void Dispose() { }
    }
}
