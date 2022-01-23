// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;

#if NanoCLR
namespace Bytewizer.NanoCLR.DependencyInjection
#else
namespace Bytewizer.TinyCLR.DependencyInjection
#endif
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Specifies the contract for a collection of service descriptors.
    /// </summary>
    public interface IServiceCollection
    {
        ServiceDescriptor this[int index] { get; set; }

        int Count { get; }
        bool IsReadOnly { get; }

        int Add(ServiceDescriptor item);
        void Clear();
        bool Contains(ServiceDescriptor item);
        void CopyTo(ServiceDescriptor[] array, int arrayIndex);
        IEnumerator GetEnumerator();
        int IndexOf(ServiceDescriptor item);
        void Insert(int index, ServiceDescriptor item);
        void Remove(ServiceDescriptor item);
        void RemoveAt(int index);
    }
}