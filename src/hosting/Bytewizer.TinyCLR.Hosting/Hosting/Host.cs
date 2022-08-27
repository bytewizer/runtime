namespace Bytewizer.TinyCLR.Hosting
{
    /// <summary>
    /// Provides convenience methods for creating instances of <see cref="IHostBuilder"/>.
    /// </summary>
    public static class Host
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostBuilder"/>.
        /// </summary>
        /// <returns>The initialized <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateBuilder()
        {
            return new HostBuilder();
        }
    }
}