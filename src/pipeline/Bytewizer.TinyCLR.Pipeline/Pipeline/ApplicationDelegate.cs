using System;

#if NanoCLR
using Bytewizer.NanoCLR.Pipeline.Builder;
namespace Bytewizer.NanoCLR.Pipeline
#else
using Bytewizer.TinyCLR.Pipeline.Builder;

namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// Represents a function that can configure an application pipeline.
    /// </summary>
    public delegate void ApplicationDelegate(IApplicationBuilder builder);
}
