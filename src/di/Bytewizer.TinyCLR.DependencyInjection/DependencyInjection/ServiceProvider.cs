// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Reflection;

#if NanoCLR
namespace Bytewizer.NanoCLR.DependencyInjection
#else
namespace Bytewizer.TinyCLR.DependencyInjection
#endif
{
    /// <summary>
    /// The default IServiceProvider.
    /// </summary>
    public sealed class ServiceProvider : IServiceProvider, IDisposable
    {
        internal IServiceCollection _serviceDescriptors;

        internal ServiceProvider(IServiceCollection serviceDescriptors, ServiceProviderOptions options)
        {
            _serviceDescriptors = serviceDescriptors;

            if (options.ValidateOnBuild)
            {
                ArrayList exceptions = null;
                foreach (ServiceDescriptor serviceDescriptor in serviceDescriptors)
                {
                    try
                    {
                        ValidateService(serviceDescriptor);
                    }
                    catch (Exception e)
                    {
                        exceptions = exceptions ?? new ArrayList();
                        exceptions.Add(e);
                    }
                }

                if (exceptions != null)
                {
                    //throw new AggregateException("Some services are not able to be constructed", exceptions.ToArray());
                }
            }

            _serviceDescriptors.Add(new ServiceDescriptor(typeof(IServiceProvider), this));

        }

        /// <inheritdoc />
        public IEnumerable GetServices(Type serviceType)
        {
            ArrayList services = new ArrayList();

            foreach (ServiceDescriptor serviceDescriptor in _serviceDescriptors)
            {
                if (serviceDescriptor.ServiceType == serviceType)
                {
                    if (serviceDescriptor.Lifetime == ServiceLifetime.Singleton
                      & serviceDescriptor.ImplementationInstance != null)
                    {
                        services.Add(serviceDescriptor.ImplementationInstance);
                    }
                    else
                    {
                        var instance = Resolve(serviceDescriptor.ImplementationType);
                        {
                            lock (_serviceDescriptors)
                            {
                                serviceDescriptor.ImplementationInstance = instance;
                            }
                        }

                        services.Add(instance);
                    }
                }
            }

            return services;
        }

        /// <inheritdoc />
        public object GetService(Type serviceType)
        {
            // TODO: Performance enhancements
            var services = (ArrayList)GetServices(serviceType);
            if (services.Count == 0)
            {
                return null;
            }

            // returns the last added service of this type
            return services[services.Count - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void ValidateService(ServiceDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        private object Resolve(Type implementationType)
        {
            ConstructorInfo constructor = implementationType.GetConstructors()[0];  // No GetConstructors
            ParameterInfo[] constructorParameters = constructor.GetParameters(); // No Paramterinfo

            object instance;

            if (constructorParameters.Length == 0)
            {
                instance = Activator.CreateInstance(implementationType);
            }
            else
            {
                Type[] types = new Type[constructorParameters.Length];
                object[] parameters = new object[constructorParameters.Length];

                for (int i = 0; i < constructorParameters.Length; i++)
                {
                    var parameterType = constructorParameters[i].ParameterType;

                    var service = GetService(parameterType);
                    if (service == null)
                    {
                        throw new InvalidOperationException(
                            $"Unable to resolve service for type '{ parameterType }' while attempting to activate.");
                    }

                    parameters[i] = service;
                    types[i] = parameterType;
                }

                instance = Activator.CreateInstance(implementationType, types, parameters);
            }

            return instance;
        }
    }
}