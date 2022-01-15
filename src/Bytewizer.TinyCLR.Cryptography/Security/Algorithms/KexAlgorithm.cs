using System;

using Bytewizer.TinyCLR.Security.Cryptography;

namespace Bytewizer.TinyCLR.Security.Algorithms
{
    public abstract class KexAlgorithm
    {
        protected HashAlgorithm _hashAlgorithm;

        public abstract byte[] CreateKeyExchange();

        public abstract byte[] DecryptKeyExchange(byte[] exchangeData);

        public byte[] ComputeHash(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return _hashAlgorithm.ComputeHash(input);
        }
    }
}