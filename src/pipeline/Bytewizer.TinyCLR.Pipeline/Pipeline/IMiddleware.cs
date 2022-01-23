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
    /// An interface for <see cref="Middleware"/>.
    /// </summary>
    public interface IMiddleware : IApplication
    {
    }
}