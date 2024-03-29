﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    
    public class Cryptography
    {
        public static BigInteger ExtendedEuclide(BigInteger a, BigInteger b)//Принимает E и N
        {
            BigInteger x1 = 0;
            BigInteger x2 = 1;
            BigInteger y1 = 1;
            BigInteger y2 = 0;
            BigInteger B = b;
            while (b > 0)
            {
                BigInteger q = a / b;
                BigInteger r = a - q * b;
                BigInteger x = x = x2 - q * x1;
                BigInteger y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            if (x2 < 0)
            {
                x2 += B;
            }
            return x2;
        } //Расширенный алгоритм Евклида возвращает Х(который в RSA является секретным ключем D)


        public static BigInteger Get3Root(BigInteger c)
        {
            int lenH = c.ToByteArray().Length;
            int lenL = lenH - 1;

            int degH = ((8 * lenH) / 3) + 1;
            int degL = (8 * (lenH - 1)) / 3;

            BigInteger h = BigInteger.Pow(2, degH);
            BigInteger l = BigInteger.Pow(2, degL);

            BigInteger ans = 0;
            while (l <= h)
            {
                // Finding the mid value

                BigInteger mid = l + (h - l) / 2;
                // Checking the mid value
                if (mid * mid * mid == c)
                {
                    return mid;
                }

                // Shift the lower bound
                if (mid * mid * mid < c)
                {
                    l = mid + 1;
                    ans = mid;
                }
                // Shift the upper bound
                else
                {
                    h = mid - 1;
                }
            }
            return ans;
        }

        public static BigInteger GetNRoot(BigInteger c, int deg)
        {
            int lenH = c.ToByteArray().Length;
            int lenL = lenH - 1;

            int degH = ((8 * lenH) / deg) + 1;
            int degL = (8 * (lenH - 1)) / deg;

            BigInteger h = BigInteger.Pow(2, degH);
            BigInteger l = BigInteger.Pow(2, degL);

            BigInteger ans = 0;
            while (l <= h)
            {
                // Finding the mid value
                BigInteger mid = l + (h - l) / 2;
                BigInteger midDeg = BigInteger.Pow(mid, deg);

                // Checking the mid value
                if (midDeg == c) return mid;

                // Shift the lower bound
                if (midDeg < c)
                {
                    l = mid + 1;
                    ans = mid;
                }
                // Shift the upper bound
                else h = mid - 1;
            }
            return ans;
        }



        public static byte[] ToAes256(byte[] src, byte[] AESKey)
        {

            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.KeySize = 256;
            encryptor.BlockSize = 128;
            encryptor.Padding = PaddingMode.PKCS7;

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
        public static byte[] FromAes256(byte[] cipherText, byte[] AESKey)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            encryptor.KeySize = 256;
            encryptor.BlockSize = 128;
            encryptor.Padding = PaddingMode.PKCS7;

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

        /// <summary>
        /// lengthBytes в байтах
        /// </summary>
        public static BigInteger getRandomBigInteger(int lengthBytes)
        {
            Random random = new Random();
            byte[] data = new byte[lengthBytes];
            random.NextBytes(data);
            return new BigInteger(data, true);
        }
        public static BigInteger getRandomBigInteger(long lengthBytes)
        {
            Random random = new Random();
            byte[] data = new byte[lengthBytes];
            random.NextBytes(data);
            return new BigInteger(data, true);
        }

        internal static BigInteger getInverse(BigInteger a, BigInteger mod)//Принимает E и N
        {
            if (a <= 0) a += mod;
            BigInteger x1 = 0;
            BigInteger x2 = 1;
            BigInteger y1 = 1;
            BigInteger y2 = 0;
            BigInteger B = mod;
            while (mod > 0)
            {
                BigInteger q = a / mod;
                BigInteger r = a - q * mod;
                BigInteger x = x2 - q * x1;
                BigInteger y = y2 - q * y1;
                a = mod;
                mod = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            if (x2 < 0)
            {
                x2 += B;
            }
            return x2;
        } //Расширенный алгоритм Евклида возвращает Х(который в RSA является секретным ключем D)


        /// <summary>
        /// keySize - в битах
        /// </summary>
        public static void GeneratePrimePair(int keySize, out BigInteger p, out BigInteger q)
        {
            Random r = new Random();
            do
            {
                int divide = r.Next(keySize / 4, keySize);
                var png = new PrimeNumberGenerator(keySize, 2, divide);
                BigInteger[] primes = png.run();
                p = primes[0];
                q = primes[1];
            } while (!IsProbablyPrime(p, 100) && !IsProbablyPrime(q, 100));
            Debug.WriteLine("Generated prime: " + p.ToString());
            Debug.WriteLine("Generated prime: " + q.ToString());
        }
        /// <summary>
        /// keySize - в битах
        /// </summary>
        public static void GeneratePrime(int keySize, out BigInteger p)
        {
            Random r = new Random();
            do
            {
                int divide = r.Next(keySize / 4, keySize);
                var png = new PrimeNumberGenerator(keySize, 1, divide);
                BigInteger[] primes = png.run();
                p = primes[0];
            } while (!IsProbablyPrime(p, 100));
            Debug.WriteLine("Generated prime: " + p.ToString());
        }

        public static bool IsProbablyPrime(BigInteger value, int witnesses = 10)
        {
            Random rnd = new Random();
            if (value <= 1)
                return false;

            if (witnesses <= 0)
                witnesses = 10;

            BigInteger d = value - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Byte[] bytes = new Byte[value.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    rnd.NextBytes(bytes);

                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1)
                        return false;
                    if (x == value - 1)
                        break;
                }

                if (x != value - 1)
                    return false;
            }

            return true;
        }


        public static byte[] CalculateSHA256(byte[] data)
        {
            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(data);
        }
        public static byte[] CalculateSHA256(string str)
        {
            UTF8Encoding objUtf8 = new UTF8Encoding();
            return CalculateSHA256(objUtf8.GetBytes(str));
        }


    }
}
