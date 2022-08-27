using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
{
    /// <summary>
    /// Represents a function that can process a provider.
    /// </summary>
    /// <param name="context">The context for the request.</param>
    /// <param name="configure">The delegate that configures the <see cref="ServiceProviderOptions"/>.</param>
    public delegate void ProviderContextDelegate(HostBuilderContext context, ServiceProviderOptions configure);
}
