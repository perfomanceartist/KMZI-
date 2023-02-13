using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace RSA__Lab_1_
{
    public class CryptoEnvelope
    {
        

        /// <summary>
        /// Шифрует исходное сообщение AES-CBC ключом (добавляет соль)
        /// </summary>
        /// <param name="src">Сообщение для зашифрования</param>
        /// <returns></returns>
        public byte[] ToAes256(byte[] src, byte[] AESKey)
        {

            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set privateKey and IV
            encryptor.Key = AESKey;
            encryptor.IV = new byte[16];
            encryptor.Padding = PaddingMode.PKCS7;
            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = src;

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            //string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherBytes;
        }


        /// <summary>
        /// Расшифровывает криптованного сообщения
        /// </summary>
        /// <param name="shifr">Шифротекст в байтах</param>
        /// <returns>Возвращает исходную строку</returns>
        public byte[] FromAes256(byte[] cipherText, byte[] AESKey)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set privateKey and IV
            encryptor.Key = AESKey;
            encryptor.IV = new byte[16];
            encryptor.Padding = PaddingMode.PKCS7;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;
            byte[] plainBytes;
            try
            {
                // Convert the ciphertext string into a byte array
                //byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] cipherBytes = new byte[cipherText.Length];
                cipherText.CopyTo(cipherBytes, 0);


                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainBytes;
        }

        public void GenerateRSAKeys(int keySize, string N, out string E, out string D)
        {
            throw new NotImplementedException();
        }

        public void GenerateRSAKeys(int keySize, out string N, out string P, out string Q, out string E, out string D)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(keySize))
            {
                RSAParameters RSAKeyInfo = RSA.ExportParameters(true);
                //BigInteger p = new BigInteger(RSAKeyInfo.P);
                //BigInteger q = new BigInteger(RSAKeyInfo.Q);
                //BigInteger phi = (p - 1) * (q - 1);

                N = (new BigInteger(RSAKeyInfo.Modulus, true)).ToString();
                P = (new BigInteger(RSAKeyInfo.P, true)).ToString();
                Q = (new BigInteger(RSAKeyInfo.Q, true)).ToString();
                E = new BigInteger(RSAKeyInfo.Exponent, true).ToString();
                D = new BigInteger(RSAKeyInfo.D, true).ToString();
            }

                
        }

        public byte[] CalculateSHA256(byte[] data)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(data); 
        }
        public byte[] CalculateSHA256(string str)
        {            
            UTF8Encoding objUtf8 = new UTF8Encoding();
            return CalculateSHA256(objUtf8.GetBytes(str));
        }

        internal BigInteger RSAEncrypt(BigInteger data, RSAPrivateKey key)
        {
            return BigInteger.ModPow(data, key.D, key.N);
        }

        internal BigInteger RSAEncrypt(BigInteger data, RSAPublicKey key)
        {
            return BigInteger.ModPow(data, key.E, key.N);
        }

        internal BigInteger RSADecrypt(BigInteger data, RSAPrivateKey key)
        {
            return BigInteger.ModPow(data, key.D, key.N);
        }

        internal BigInteger RSADecrypt(BigInteger data, RSAPublicKey key)
        {
            return BigInteger.ModPow(data, key.E, key.N);
        }



        


        public void Sign(string filenamePublicKey, string filenamePrivateKey, string fileNameData, string filenameSign)
        {
            
            RSAPublicKey publicKey = RSAPublicKey.ReadFromFile(filenamePublicKey);
            RSAPrivateKey privateKey = RSAPrivateKey.ReadFromFile(filenamePrivateKey);
            byte[] data = File.ReadAllBytes(fileNameData);

            byte[] signment = Sign(publicKey, privateKey, data);
            File.WriteAllBytes(filenameSign, signment);
        }

        internal byte[] Sign(RSAPublicKey publicKey, RSAPrivateKey privateKey, byte[] data)
        {
            byte[] hash = CalculateSHA256(data);
            BigInteger hashInt = new BigInteger(hash);
            BigInteger hashIntEncrypted = RSAEncrypt(hashInt, privateKey);

            return ASN.GenerateSignHeader(publicKey, hashIntEncrypted.ToByteArray());
        }


        public bool Verify(string filenameMessage, string filenameSign)
        {
            byte[] message = File.ReadAllBytes(filenameMessage);
            byte[] sign = File.ReadAllBytes(filenameSign);
            return Verify(message, sign);
        }

        public bool Verify(byte[] message, byte[] signment)
        {
            RSAPublicKey key;
            byte[] signHash;
            ASN.decodeSignHeader(signment, out key, out signHash);
            byte[] messageHash = CalculateSHA256(message);

            BigInteger signHashInt = new BigInteger(signHash);
            BigInteger signHashIntDecrypted = RSADecrypt(signHashInt, key);

            return Enumerable.SequenceEqual<byte>(signHashIntDecrypted.ToByteArray(), messageHash);
        }


        

        public byte[] EncryptFile(string filenameRSA, string filenameAES, string filenameData)
        {
            RSAPublicKey rsaPublicKey = RSAPublicKey.ReadFromFile(filenameRSA);
            byte[] AESKey = File.ReadAllBytes(filenameAES);
            byte[] data = File.ReadAllBytes(filenameData);

            return EncryptFile(rsaPublicKey, AESKey, data);
        }

        public byte[] DecryptFile(string filenameRSA, string filenameData)
        {
            RSAPrivateKey rsaPrivateKey = RSAPrivateKey.ReadFromFile(filenameRSA);
            byte[] data = File.ReadAllBytes(filenameData);

            return DecryptFile(rsaPrivateKey, data);
        }


        internal byte[] EncryptFile(RSAPublicKey rsaPublicKey, byte[] AESKey, byte[] data)
        {
            byte[] encrypted = ToAes256(data, AESKey);


            Console.WriteLine("AES before encrypting: " + BitConverter.ToString(AESKey));

            BigInteger aesBigInt = new BigInteger(AESKey);
            Console.WriteLine("AES before encrypting (BigInteger): " + aesBigInt.ToString());
            aesBigInt = RSAEncrypt(aesBigInt, rsaPublicKey);
            Console.WriteLine("AES after encrypting (BigInteger): " + aesBigInt.ToString());
            Console.WriteLine("AES after encrypting: " + BitConverter.ToString(AESKey));



            byte[] header = ASN.GenerateEncryptionHeader(rsaPublicKey, aesBigInt.ToByteArray());

            byte[] result = new byte[header.Length + encrypted.Length];
            header.CopyTo(result, 0);
            encrypted.CopyTo(result, header.Length);
            return result;
        }


        internal byte[] DecryptFile(RSAPrivateKey rsaPrivateKey, byte[] data) 
        {
            RSAPublicKey tempKey;
            byte[] AESKey;
            byte[] message;
            ASN.decodeEncryptionHeader(data, out tempKey, out AESKey, out message);

            //string messageString = Encoding.ASCII.GetString(message);

            Console.WriteLine("AES before decrypting: " + BitConverter.ToString(AESKey));

            BigInteger aesBigInt = new BigInteger(AESKey);
            Console.WriteLine("AES before decrypting (BigInteger): " + aesBigInt.ToString());
            BigInteger aesBigIntDec = RSADecrypt(aesBigInt, rsaPrivateKey);
            Console.WriteLine("AES after decrypting (BigInteger): " + aesBigIntDec.ToString());
            AESKey = aesBigIntDec.ToByteArray();

            Console.WriteLine("AES after decrypting: " + BitConverter.ToString(AESKey));

            return FromAes256(message, AESKey);
        }
    }

    
}
