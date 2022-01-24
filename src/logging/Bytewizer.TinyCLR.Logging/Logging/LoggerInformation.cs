// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    internal readonly struct LoggerInformation
    {
        public LoggerInformation(ILoggerProvider provider, string category)
            : this()
        {
            ProviderType = provider.GetType();
            Logger = provider.CreateLogger(category);
            Category = category;
        }

        public ILogger Logger { get; }

        public string Category { get; }

        public Type ProviderType { get; }
    }
}
