// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    public abstract class KeyedHashAlgorithm : HashAlgorithm
    {
        protected byte[] KeyValue;

        protected KeyedHashAlgorithm() { }

        // IDisposable methods
        protected override void Dispose(bool disposing)
        {
            // For keyed hash algorithms, we always want to zero out the key value
            if (disposing)
            {
                if (KeyValue != null)
                    Array.Clear(KeyValue, 0, KeyValue.Length);
                KeyValue = null;
            }
            base.Dispose(disposing);
        }

        public virtual byte[] Key
        {
            get { return (byte[])KeyValue.Clone(); }
            set
            {
                if (State != 0)
                    throw new Exception("Cryptography_HashKeySet");
                KeyValue = (byte[])value.Clone();
            }
        }

        new static public KeyedHashAlgorithm Create()
        {
            return new HMACSHA1();
        }
    }
}
