// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;

#if NanoCLR
namespace nanoFramework.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Extensions for <see cref="IHost"/>.
    /// </summary>
    public static class HostingAbstractionsHostExtensions
    {
        /// <summary>
        /// Runs an application and block the calling thread.
        /// </summary>
        /// <param name="host">The <see cref="IHost"/> to run.</param>
        public static void Run(this IHost host)
        {
            if (host == null)
            {
                throw new ArgumentNullException();
            }

            host.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}