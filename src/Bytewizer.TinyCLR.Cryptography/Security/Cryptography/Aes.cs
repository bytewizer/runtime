// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Bytewizer.TinyCLR.Security.Cryptography
{
    /// <summary>
    /// Abstract base class for implementations of the AES algorithm
    /// </summary>
    public abstract class Aes : SymmetricAlgorithm
    {
        private static KeySizes[] s_legalBlockSizes = { new KeySizes(128, 128, 0) };
        private static KeySizes[] s_legalKeySizes = { new KeySizes(128, 256, 64) };

        /// <summary>
        ///     Setup the default values for AES encryption
        /// </summary>
        protected Aes()
        {
            LegalBlockSizesValue = s_legalBlockSizes;
            LegalKeySizesValue = s_legalKeySizes;

            BlockSizeValue = 128;
            FeedbackSizeValue = 8;
            KeySizeValue = 256;
            ModeValue = CipherMode.CBC;
        }

        public static new Aes Create()
        {
            return new AesCryptoServiceProvider();
        }
    }
}
