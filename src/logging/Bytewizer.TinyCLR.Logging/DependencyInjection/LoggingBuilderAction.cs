//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

#if NanoCLR
namespace Bytewizer.NanoCLR.Logging
#else
namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// Represents a function that can process a service.
    /// </summary>
    /// <param name="builder">The delegate that configures the <see cref="ILoggingBuilder"/></param>
    public delegate void LoggingBuilderAction(ILoggingBuilder builder);
}
