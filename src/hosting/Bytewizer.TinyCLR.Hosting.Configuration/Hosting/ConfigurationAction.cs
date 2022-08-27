namespace Bytewizer.TinyCLR.Hosting.Configuration
{
    /// <summary>
    /// Represents a function that can process a service.
    /// </summary>
    /// <param name="builder">The delegate that configures the <see cref="IConfigurationBuilder"/></param>
    public delegate void ConfigurationAction(IConfigurationBuilder builder);
}
