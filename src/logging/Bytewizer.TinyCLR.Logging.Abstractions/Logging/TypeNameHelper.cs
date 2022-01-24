// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    internal static class TypeNameHelper
    {
        public static string GetTypeDisplayName(object item, bool fullName = true)
        {
            return item == null ? null : GetTypeDisplayName(item.GetType(), fullName);
        }

        /// <summary>
        /// Pretty print a type name.
        /// </summary>
        /// <param name="type">The <see cref="Type"/>.</param>
        /// <param name="fullName"><c>true</c> to print a fully qualified name.</param>
        public static string GetTypeDisplayName(Type type, bool fullName = true)
        {
            return fullName ? type.FullName : type.Name; ;
        }
    }
}
