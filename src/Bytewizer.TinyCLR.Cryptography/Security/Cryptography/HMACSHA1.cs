// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    public class HMACSHA1 : HMAC {
        //
        // public constructors
        //

        public HMACSHA1 () : this (GenerateRandom(64)) {}

        public HMACSHA1 (byte[] key) : this (key, false) {}

        public HMACSHA1 (byte[] key, bool useManagedSha1) {
            m_hashName = "SHA1";
//#if FEATURE_CRYPTO && !FULL_AOT_RUNTIME
//            if (useManagedSha1) {
//#endif // FEATURE_CRYPTO
//                m_hash1 = new SHA1Managed();
//                m_hash2 = new SHA1Managed();
//#if FEATURE_CRYPTO && !FULL_AOT_RUNTIME
//            } else {
                m_hash1 = new SHA1CryptoServiceProvider();
                m_hash2 = new SHA1CryptoServiceProvider();
//            }
//#endif // FEATURE_CRYPTO

            HashSizeValue = 160;
            base.InitializeKey(key);
        }

        internal static byte[] GenerateRandom(int keySize)
        {
            Random rnd = new Random();
            byte[] key = new byte[keySize];
            rnd.NextBytes(key);
            return key;
        }
    }
}
