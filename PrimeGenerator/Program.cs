// See https://aka.ms/new-console-template for more information
using RSA__Lab_1_;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

CryptoEnvelope envelope = new CryptoEnvelope();

BigInteger m = BigInteger.Parse("1814565766402527470104038909434809373945086533855861134940556411704373871105");

BigInteger m3 = BigInteger.Pow(m, 11);

//BigInteger _m = envelope.GetNRoot(m3, 11);
//Console.WriteLine(_m == m);



//File.WriteAllBytes("encrypted.txt", envelope.EncryptFile("publ1.pam", "aes.key", "TEST.txt" ));

//File.WriteAllBytes("decrypted.txt", envelope.DecryptFile("priv1.pam", "encrypted.txt"));

