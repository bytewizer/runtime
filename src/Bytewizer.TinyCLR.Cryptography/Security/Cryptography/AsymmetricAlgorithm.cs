// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    public abstract class AsymmetricAlgorithm : IDisposable 
    {
        protected int KeySizeValue;
        protected KeySizes[] LegalKeySizesValue;

        protected AsymmetricAlgorithm() {}

        public void Dispose() 
        {
            Clear();
        }

        public void Clear() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            return;
        }
    
        public virtual int KeySize 
        {
            get { return KeySizeValue; }
            set {
                int   i;
                int   j;

                for (i=0; i<LegalKeySizesValue.Length; i++) {
                    if (LegalKeySizesValue[i].SkipSize == 0) {
                        if (LegalKeySizesValue[i].MinSize == value) { // assume MinSize = MaxSize
                            KeySizeValue = value;
                            return;
                        }
                    } else {
                        for (j = LegalKeySizesValue[i].MinSize; j<=LegalKeySizesValue[i].MaxSize;
                             j += LegalKeySizesValue[i].SkipSize) {
                            if (j == value) {
                                KeySizeValue = value;
                                return;
                            }
                        }
                    }
                }
                throw new Exception("Cryptography_InvalidKeySize");
            }
        }
        
        public virtual KeySizes[] LegalKeySizes 
        { 
            get { return (KeySizes[]) LegalKeySizesValue.Clone(); }
        }
        
        static public AsymmetricAlgorithm Create() {
            return null;
       }
    }
}    
