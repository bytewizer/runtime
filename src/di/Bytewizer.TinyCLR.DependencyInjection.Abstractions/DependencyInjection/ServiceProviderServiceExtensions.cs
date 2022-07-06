// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
namespace Bytewizer.NanoCLR.DependencyInjection
#else
namespace Bytewizer.TinyCLR.DependencyInjection
#endif
{
    /// <summary>
    /// Extension methods for getting services from an <see cref="IServiceProvider" />.
    /// </summary>
    public static class ServiceProviderServiceExtensions
    {
        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>An array of services of type <paramref name="serviceType"/>.</returns>
        public static object[] GetServices(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            return provider.GetService(new Type[] { serviceType });
        }

        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <param name="serviceType">An array of <paramref name="serviceType"/> object that specifies the type of service object to get.</param>
        /// <returns>An array of services of type <paramref name="serviceType"/>.</returns>
        /// <exception cref="ArgumentNullException">'provider' or 'serviceType' can't be <see langword="null"/>.</exception>
        public static object[] GetServices(this IServiceProvider provider, Type[] serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException();
            }

            return provider.GetService(serviceType);
        }

        /// <summary>
        /// Get service of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType"/>.</returns>
        /// <exception cref="InvalidOperationException">There is no service of type <paramref name="serviceType"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="provider"/> or <paramref name="serviceType"></paramref> can't be <see langword="null"/>.</exception>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException();
            }

            object service = provider.GetService(serviceType);

            if (service == null)
            {
                throw new InvalidOperationException();
            }

            return service;
        }
    }
}
