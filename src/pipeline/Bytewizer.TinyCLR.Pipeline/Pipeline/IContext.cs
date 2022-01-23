#if NanoCLR
namespace Bytewizer.NanoCLR.Pipeline
#else
namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// An interface for <see cref="IMiddleware"/>.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Clears the context and connected socket channel.
        /// </summary>
        void Clear();
    }
}