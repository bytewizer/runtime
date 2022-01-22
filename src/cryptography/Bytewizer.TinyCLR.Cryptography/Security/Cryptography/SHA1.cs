// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    public abstract class SHA1 : HashAlgorithm
    {
        protected SHA1() {
            HashSizeValue = 160;
        }

        new static public SHA1 Create() {

            return new SHA1CryptoServiceProvider ();
       }
    }
}

