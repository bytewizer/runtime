// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Bytewizer.TinyCLR.Security.Cryptography {

    public abstract class MD5 : HashAlgorithm
    {      
        protected MD5() {
            HashSizeValue = 128;
        }

        new static public MD5 Create() 
        {
           return new MD5CryptoServiceProvider();
        }
    }
}
