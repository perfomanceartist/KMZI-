// See https://aka.ms/new-console-template for more information


using ASN_Test;
using RSA__Lab_1_;
using System.Globalization;
using System.Numerics;




BigInteger n = BigInteger.Parse("121449330700731988981006809446942716543052496570124384717097606287955261242563431820966205511740052168036445563886031257401841159153278853200862052900635582283345814580557283036129447369846502130652173337025034916639555598344314580159945705104214492272831516696220848301299207065695691966462956926333617266689");
BigInteger e = 65537;
BigInteger d = BigInteger.Parse("29924528009451457315185284021991104059343755658854823449527627848969308307443341883897070152792748560499451042397907025718676946427318109182408722252154706853137959755337079923616400457204992696235201020641254033174464168266715713267863832106813078951947701954703787120226140950091098878401565816098647579393");

RSAPublicKey publicKey = new RSAPublicKey(e, n);
RSAPrivateKey privateKey = new RSAPrivateKey(n, d);

publicKey.N.ToByteArray();
//RSAPublicKey.WriteToFile(publicKey, "publicKey.pam");
//RSAPrivateKey.WriteToFile(privateKey, "privateKey.pam");





/*

BigInteger p = BigInteger.Parse("1812084319");
BigInteger q = BigInteger.Parse("12611920634232574451913390811");
BigInteger phi = (p - 1) * (q - 1);

BigInteger n = BigInteger.Parse("22853863613765382763312275034731792709");

BigInteger e = 26153821;
BigInteger d = BigInteger.Parse("6911621367117433573665010327570776241");



RSAPrivateKey privKey = new RSAPrivateKey(n, d);
RSAPublicKey publKey = new RSAPublicKey(e, n);


//BigInteger a = new BigInteger(new byte[256] { 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04, 01, 02, 03, 04 });

BigInteger _a = envelope.RSAEncrypt(a, publKey);
BigInteger __a = envelope.RSADecrypt(_a, privKey);

//RSAPublicKey key = RSAPublicKey.ReadFromFile("key.pam");

*/
CryptoEnvelope envelope = new CryptoEnvelope();

envelope.Sign("publicKey.pam", "privateKey.pam", "TEST.txt", "sign.txt");
bool verified = envelope.Verify("TEST.txt", "sign.txt");

Console.WriteLine(verified ? "verified" : "not verified");

//byte[] encr = envelope.EncryptFile("publicKey.pam", "aes.key", "TEST.txt");
//File.WriteAllBytes("encrypted.txt", encr);

RSAPublicKey key;
byte[] aesKey;



//ASN.decodeEncryptionHeader(File.ReadAllBytes("encrypted.txt"), out key, out aesKey);
//byte[] decr = envelope.DecryptFile("privateKey.pam", "encrypted.txt");
//File.WriteAllBytes("decrypted.txt", decr);


Console.WriteLine();


