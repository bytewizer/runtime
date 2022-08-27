// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

#if NanoCLR
using Bytewizer.NanoCLR.DependencyInjection;

namespace nanoFramework.Hosting
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionHostedServiceExtensions
    {
        /// <summary>
        /// Add an <see cref="IHostedService"/> registration for the given type.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
        /// <param name="implementationInstance">The instance of the service.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> can't be null</exception>
        /// <exception cref="ArgumentException">Implementation type must inherit <see cref="IHostedService"/> interface.</exception>
        public static IServiceCollection AddHostedService(this IServiceCollection services, object implementationInstance)
        {
            return services.AddSingleton(typeof(IHostedService), implementationInstance);
        }
        
        /// <summary>
        /// Add an <see cref="IHostedService"/> registration for the given type.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="implementationType"/> can't be null</exception>
        /// <exception cref="ArgumentException">Implementation type must inherit <see cref="IHostedService"/> interface.</exception>
        public static IServiceCollection AddHostedService(this IServiceCollection services, Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException();
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException();
            }

#if NanoCLR

            foreach (Type interfaceType in implementationType.GetInterfaces())
            {
                if (interfaceType.Equals(typeof(IHostedService)))
                {
                    return services.AddSingleton(typeof(IHostedService), implementationType);
                }
            }

            throw new ArgumentException();
#else
            Type[] type = implementationType.GetInterfaces();
            Type[] baseType = implementationType.BaseType.GetInterfaces();
            Type[] implementationTypes = new Type[type.Length + baseType.Length];

            Array.Copy(type, implementationTypes, type.Length);
            Array.Copy(baseType, 0, implementationTypes, type.Length, baseType.Length);

            foreach (Type interfaceType in implementationTypes)
            {
                if (interfaceType.Equals(typeof(IHostedService)))
                {
                    return services.AddSingleton(typeof(IHostedService), implementationType);
                }
            }

            throw new ArgumentException();
#endif
        }
    }
}