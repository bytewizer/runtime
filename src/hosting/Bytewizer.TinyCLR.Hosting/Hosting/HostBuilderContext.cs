// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;

namespace Bytewizer.TinyCLR.Hosting
{
    /// <summary>
    /// Context containing the common services on the <see cref="IHost" />. Some properties may be null until set by the <see cref="IHost" />.
    /// </summary>
    public class HostBuilderContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostBuilderContext"/> class.
        /// </summary>
        public HostBuilderContext(Hashtable properties)
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
        public Hashtable Properties { get; }

        /// <summary>
        /// The <see cref="IConfiguration" /> containing the merged configuration of the application and the <see cref="IHost" />.
        /// </summary>
        public IConfiguration Configuration { get; set; } = null!;
    }
}