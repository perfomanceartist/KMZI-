// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");


RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);

RSAParameters RSAKeyInfo = RSA.ExportParameters(true);

//Set RSAKeyInfo to the public key values.

BigInteger p = new BigInteger(RSAKeyInfo.P);
BigInteger q = new BigInteger(RSAKeyInfo.Q);

BigInteger phi = (p - 1) * (q - 1);
