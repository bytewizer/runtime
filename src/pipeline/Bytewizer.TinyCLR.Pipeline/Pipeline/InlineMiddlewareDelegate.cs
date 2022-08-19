#if NanoCLR
namespace Bytewizer.NanoCLR.Pipeline
#else
namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// Represents a function that can process an inline pipeline middleware.
    /// </summary>
    public delegate void InlineDelegate(IContext context, RequestDelegate next);
}