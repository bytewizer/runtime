// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace nanoFramework.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Context containing the common services on the <see cref="IHost" />. Some properties may be null until set by the <see cref="IHost" />.
    /// </summary>
    public class HostBuilderContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostBuilderContext"/> class.
        /// </summary>
        public HostBuilderContext(object[] properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException();
            }

            Properties = properties;
        }

        /// <summary>
        /// A central location for sharing state between components during the host building process.
        /// </summary>
        public object[] Properties { get; }
    }
}