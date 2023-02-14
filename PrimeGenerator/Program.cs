// See https://aka.ms/new-console-template for more information
using RSA__Lab_1_;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");

CryptoEnvelope envelope = new CryptoEnvelope();

BigInteger data = BigInteger.Parse("1814565766402527470104038909434809373945086533855861134940556411704373871105");
BigInteger e = BigInteger.Parse("65537");
BigInteger n = BigInteger.Parse("8684654362059533362732789640707763531363377466771941556459943160061288157206674934635013300531432099918313385331921685047366681870593385249313135");
BigInteger d = BigInteger.Parse("8689238114309025248866511987509266353261997522103553989579399008882733576251722800164026261662207832828870556984745101604511409655801304164091748700578203");

BigInteger p = BigInteger.Parse("108496204152631882258931059004460588305846321476938990354332425937813615540941");
BigInteger q = BigInteger.Parse("77614072088429622593066605649093997209013512095626037584902121208408172355281");

Console.WriteLine("N: " + (n == p * q));
BigInteger check = (e * d) % ((p - 1) * (q - 1));

BigInteger c = BigInteger.ModPow(data, e, n) % n;
BigInteger m = BigInteger.ModPow(c, d, n) % n;
Console.WriteLine(m == data);
Console.WriteLine("Hello, World!");
//File.WriteAllBytes("encrypted.txt", envelope.EncryptFile("publ1.pam", "aes.key", "TEST.txt" ));

//File.WriteAllBytes("decrypted.txt", envelope.DecryptFile("priv1.pam", "encrypted.txt"));

