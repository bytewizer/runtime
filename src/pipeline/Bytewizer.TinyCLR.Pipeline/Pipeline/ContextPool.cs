
using System;
using System.Collections;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Pipeline
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Pipeline
#endif
{
    /// <summary>
    /// Context pool for reusing context objects.
    /// </summary>
    public sealed class ContextPool
    {
        private readonly ArrayList _used;
        private readonly ArrayList _available;
        private readonly IServiceProvider _services;

        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextPool"/> class.
        /// </summary>
        public ContextPool(IServiceProvider services)
        {
            _available = new ArrayList();
            _used = new ArrayList();
            _services = services;
        }

        /// <summary>
        /// Gets a <see cref="IContext"/> object from pool.
        /// </summary>
        public IContext GetContext(Type context)
        {
            lock (_available)
            {
                if (_available.Count > 0)
                {
                    IContext ctx = _available[0] as IContext;

                    lock (_lock)
                    {
                        _available.RemoveAt(0);
                        _used.Add(ctx);
                    }
                    return ctx;
                }
                else
                {
                    IContext ctx = ActivatorUtilities.GetServiceOrCreateInstance(_services, context) as IContext;
                    lock (_lock)
                    {
                        _used.Add(ctx);
                    }
                    return ctx;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="IContext"/> object back to the pool and clears context.
        /// </summary>
        public void Release(IContext context)
        {
            // Clears context for reuse.
            context.Clear();

            lock (_lock)
            {
                _used.Remove(context);
                _available.Add(context);
            }
        }
    }
}
