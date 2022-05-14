using System;
using System.Text;
using System.Diagnostics;

using Bytewizer.TinyCLR.Assertions;
using Bytewizer.TinyCLR.Security.Algorithms;
using Bytewizer.TinyCLR.Security.Cryptography;

using GHIElectronics.TinyCLR.Cryptography;

namespace Bytewizer.Playground.Cryptography
{
    public class ProviderTests : TestFixture
    {
        private static string password = "very strong password 123412;,[p;[; 172634812";

        public void Test()
        {
            //byte[] byteArray = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //var newBigInt = new BigInteger(byteArray);

            //var dh2048 = new DiffieHellman(2048);
            //var dh1024 = new DiffieHellman(1024);

            //var group14 = new DiffieHellmanGroupSha1(new DiffieHellman(1024));
            //var serverExchangeValue = group14.CreateKeyExchange();

            var group1 = new DiffieHellmanGroupSha1(new DiffieHellman(1024));
            var hash = group1.ComputeHash(GetKey(password));


            byte[] dataToEncrypt = Encoding.UTF8.GetBytes("Data to Encrypt");
            byte[] encryptedData;
            byte[] decryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {

                //Encrypt data.
                using (RSACryptoServiceProvider encryptRSA = new RSACryptoServiceProvider())
                {

                    var tom = encryptRSA.KeyExchangeAlgorithm;
                    encryptRSA.ImportParameters(RSA.ExportParameters(false));
                    encryptedData = encryptRSA.Encrypt(dataToEncrypt);
                }

                //Decrypt data.
                using (RSACryptoServiceProvider decryptRSA = new RSACryptoServiceProvider())
                {

                    var tom = decryptRSA.KeyExchangeAlgorithm;  
                    decryptRSA.ImportParameters(RSA.ExportParameters(true));
                    decryptedData = decryptRSA.Decrypt(encryptedData);
                }
            }

            Debug.WriteLine("Decrypted: " + Encoding.UTF8.GetString(decryptedData));
        }

        public void AES()
        {
            var textToEncrypt = "something you want to hide";

            Debug.WriteLine(String.Format("original text: {0}{1}{0}",
                Environment.NewLine, textToEncrypt));

            var encryptedData = EncryptString(textToEncrypt);
            Debug.WriteLine(String.Format("encrypted data:{0}{1}{0}",
                Environment.NewLine, Convert.ToBase64String(encryptedData)));

            var decryptedText = DecryptToString(encryptedData);
            Debug.WriteLine(String.Format("decrypted text:{0}{1}{0}",
                Environment.NewLine, decryptedText));

            Assert.AreEqual(decryptedText, textToEncrypt);
        }

        private static byte[] EncryptString(string toEncrypt)
        {
            var key = GetKey(password);

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;
          
                using (var encryptor = aes.CreateEncryptor(key, key))
                {
                    var plainText = Encoding.UTF8.GetBytes(toEncrypt);
                    return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                }
            }
        }

        private static string DecryptToString(byte[] encryptedData)
        {
            var key = GetKey(password);

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;

                using (var encryptor = aes.CreateDecryptor(key, key))
                {
                    var decryptedBytes = encryptor
                        .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        private static byte[] GetKey(string password)
        {
            var keyBytes = Encoding.UTF8.GetBytes(password);
            using (var md5 = TinyCLR.Security.Cryptography.MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }
    }
}