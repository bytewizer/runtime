// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    /// <summary>
    /// Specifies the name of a cryptographic hash algorithm.
    /// </summary>
    public struct HashAlgorithmName : IEquatable
    {
        // Returning a new instance every time is free here since HashAlgorithmName is a struct with
        // a single string field. The optimized codegen should be equivalent to return "MD5".

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing "MD5"
        /// </summary>
        public static HashAlgorithmName MD5 { get { return new HashAlgorithmName("MD5"); } }

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing "SHA1"
        /// </summary>
        public static HashAlgorithmName SHA1 { get { return new HashAlgorithmName("SHA1"); } }

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing "SHA256"
        /// </summary>
        public static HashAlgorithmName SHA256 { get { return new HashAlgorithmName("SHA256"); } }

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing "SHA384"
        /// </summary>
        public static HashAlgorithmName SHA384 { get { return new HashAlgorithmName("SHA384"); } }

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing "SHA512"
        /// </summary>
        public static HashAlgorithmName SHA512 { get { return new HashAlgorithmName("SHA512"); } }

        private readonly string _name;

        /// <summary>
        /// Gets a <see cref="HashAlgorithmName" /> representing a custom name.
        /// </summary>
        /// <param name="name">The custom hash algorithm name.</param>
        public HashAlgorithmName(string name)
        {
            // Note: No validation because we have to deal with default(HashAlgorithmName) regardless.
            _name = name;
        }

        /// <summary>
        /// Gets the underlying string representation of the algorithm name. 
        /// </summary>
        /// <remarks>
        /// May be null or empty to indicate that no hash algorithm is applicable.
        /// </remarks>
        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return _name ?? String.Empty;
        }

        public override bool Equals(object obj)
        {
            return obj is HashAlgorithmName && Equals((HashAlgorithmName)obj);
        }

        public bool Equals(HashAlgorithmName other)
        {
            // NOTE: intentionally ordinal and case sensitive, matches CNG.
            return _name == other._name;
        }

        public override int GetHashCode()
        {
            return _name == null ? 0 : _name.GetHashCode();
        }

        public static bool operator ==(HashAlgorithmName left, HashAlgorithmName right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HashAlgorithmName left, HashAlgorithmName right)
        {
            return !(left == right);
        }
    }

    public interface IEquatable
    {
    }
}
