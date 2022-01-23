#if NanoCLR
namespace Bytewizer.NanoCLR.Pipeline
#else
namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// Represents a function that can process a request.
    /// </summary>
    /// <param name="context">The context for the request.</param>
    public delegate void RequestDelegate(IContext context);
}