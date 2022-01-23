#if NanoCLR
namespace Bytewizer.NanoCLR.Pipeline
#else
namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// Represents a function that can process a pipeline middleware.
    /// </summary>
    public delegate IMiddleware MiddlewareDelegate();
}