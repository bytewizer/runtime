#if NanoCLR
namespace Bytewizer.NanoCLR.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// An interface representing a server service.
    /// </summary>
    public interface IServerService
    {
        /// <summary>
        /// Start the server accepting incoming requests.
        /// </summary>
        bool Start();

        /// <summary>
        /// Stop processing requests and gracefully shut down the server if possible.
        /// </summary>
        bool Stop();
    }
}