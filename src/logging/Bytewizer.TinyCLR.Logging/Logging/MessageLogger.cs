// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    internal readonly struct MessageLogger
    {
        public MessageLogger(ILogger logger, string category, string providerTypeFullName, LogLevel minLevel)
        {
            Logger = logger;
            Category = category;
            ProviderTypeFullName = providerTypeFullName;
            MinLevel = minLevel;
        }

        public ILogger Logger { get; }

        public string Category { get; }

        private string ProviderTypeFullName { get; }

        public LogLevel MinLevel { get; }


        public bool IsEnabled(LogLevel level)
        {
            if (level < MinLevel)
            {
                return false;
            }

            return true;
        }
    }
}
