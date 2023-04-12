using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    public class RSAPrivateKey
    {


        public BigInteger N;

        public BigInteger D;

        public RSAPrivateKey(BigInteger n, BigInteger d)
        {
            N = n;
            D = d;
        }

        static public RSAPrivateKey ReadFromFile(string filename)
        {
            string data = File.ReadAllText(filename);

            data = data.Substring("-----BEGIN PRIVATE KEY-----".Length);
            data = data.Trim();

            data = data.Substring(0, data.Length - "-----END PRIVATE KEY-----".Length);
            data = data.TrimEnd();
            byte[] dataBytes = Convert.FromBase64String(data);

            return ASN.DecodeRSAPrivateKey(dataBytes);
        }

        static public void WriteToFile(RSAPrivateKey key, string filename)
        {
            string data = "-----BEGIN PRIVATE KEY-----" + Environment.NewLine;
            data += Convert.ToBase64String(ASN.EncodeRSAPrivateKey(key)) + Environment.NewLine;
            data += "-----END PRIVATE KEY-----" + Environment.NewLine;
            File.WriteAllText(filename, data);
        }


    }

    public class RSAPublicKey
    {


        public BigInteger E;

        public BigInteger N;

        public RSAPublicKey(BigInteger e, BigInteger n)
        {
            E = e;
            N = n;
        }

        public static RSAPublicKey ReadFromFile(string filename)
        {
            string data = File.ReadAllText(filename);

            data = data.Substring("-----BEGIN PUBLIC KEY-----".Length);

            data = data.Trim();

            data = data.Substring(0, data.Length - "-----END PUBLIC KEY-----".Length);

            data = data.TrimEnd();

            byte[] dataBytes = Convert.FromBase64String(data);

            return ASN.DecodeRSAPublicKey(dataBytes);
        }

        public static void WriteToFile(RSAPublicKey key, string filename)
        {
            string data = "-----BEGIN PUBLIC KEY-----" + Environment.NewLine;
            data += Convert.ToBase64String(ASN.EncodeRSAPublicKey(key)) + Environment.NewLine;
            data += "-----END PUBLIC KEY-----" + Environment.NewLine;
            File.WriteAllText(filename, data);
        }

    }

    public class RSA
    {

        public static BigInteger[] getContinuedFraction(BigInteger b, BigInteger a, long limit, out int size)
        {
            BigInteger[] coeffs = new BigInteger[limit];

            for (size = 0; size < limit; size++)
            {
                BigInteger div = BigInteger.Divide(b, a);
                coeffs[size] = div;
                BigInteger t = a;
                BigInteger.DivRem(b, a, out a); //остаток  a = b - div * a;
                b = t;
                if (a == 0) break;
            }
            return coeffs;
        }




        public static BigInteger WienerAttack(BigInteger n, BigInteger e)
        {
            long limit = n.GetBitLength(); int size;
            BigInteger[] coeffs = getContinuedFraction(n, e, limit, out size);

            /*foreach (BigInteger coefficient in coeffs)
            {
                Console.WriteLine(coefficient.ToString());
            }*/

            BigInteger qi;
            //BigInteger pi2 = 1, pi1 = 0;
            BigInteger qi2 = 0, qi1 = 1;

            long lenNBytes = n.GetBitLength();

            
            for (int i = 0; i < limit; i++)
            {
                qi = coeffs[i] * qi1 + qi2;

                BigInteger m = Cryptography.getRandomBigInteger(lenNBytes) % n;

                if (BigInteger.ModPow(m, e * qi, n) == m) return qi;

                qi2 = qi1;
                qi1 = qi;
            }
            
            return 0;
        }

        public static bool WienerAttack(RSAPublicKey publicKey, out RSAPrivateKey privateKey)
        {
            BigInteger d = WienerAttack(publicKey.N, publicKey.E);
            privateKey = new RSAPrivateKey(publicKey.N, d);
            return (d != 0);
        }


        


        public static bool CommonEAttack(BigInteger e, List<BigInteger> listN, List<BigInteger> listC, out BigInteger x)
        {
            BigInteger M = 1;

            foreach (BigInteger a in listN)
            {
                M *= a;
            }

            List<BigInteger> listM = new List<BigInteger>();

            foreach (BigInteger a in listN)
            {
                listM.Add(BigInteger.Divide(M, a));
            }

            List<BigInteger> listInverseM = new List<BigInteger>();

            for (int i = 0; i < listN.Count; i++)
            {
                listInverseM.Add(Cryptography.ExtendedEuclide(listM[i], listN[i]));
            }

            x = 0;
            for (int i = 0; i < listN.Count; i++)
            {
                BigInteger t = (listC[i] * listM[i] * listInverseM[i]) % M;
                x = (x + t) % M;
            }

            //int intE = Convert.ToInt32(e.ToByteArray());
            x = Cryptography.Get3Root(x);
           // x = Cryptography.GetNRoot(x, intE);
            return true;
        }

        public static bool CommonEAttack(List<string> publicKeyFiles, List<string> encryptedFiles, string path)
        {

            List<BigInteger> listN = new List<BigInteger>();
            BigInteger e = RSAPublicKey.ReadFromFile(publicKeyFiles[0]).E;
            foreach (string keyFile in publicKeyFiles)
            {
                listN.Add(RSAPublicKey.ReadFromFile(keyFile).N);
            }

            List<byte[]> encryptedMessages = new List<byte[]>();
            List<BigInteger> aesKeys = new List<BigInteger>();
            foreach (string messageFile in encryptedFiles)
            {
                byte[] bytes = File.ReadAllBytes(messageFile);
                RSAPublicKey key;
                byte[] aesKey;
                byte[] message;
                ASN.decodeEncryptionHeader(bytes, out key, out aesKey, out message);
                aesKeys.Add(new BigInteger(aesKey));
                encryptedMessages.Add(message);
            }
            BigInteger origKey;
            CommonEAttack(e, listN, aesKeys, out origKey);

            byte[] encMsg = encryptedMessages[0];
            byte[] origMsg = Cryptography.FromAes256(encMsg, origKey.ToByteArray());

            File.WriteAllBytes(path, origMsg);
            return true;
        }


        public static bool CommonNAttack(string filenamePublicA, string filenamePrivateA, string filenamePublicB, out string P, out string Q, out string D)
        {
            //throw new NotImplementedException();
            RSAPublicKey publicA, publicB; RSAPrivateKey privateA;
            try
            {
                publicA = RSAPublicKey.ReadFromFile(filenamePublicA);
                publicB = RSAPublicKey.ReadFromFile(filenamePublicB);
                privateA = RSAPrivateKey.ReadFromFile(filenamePrivateA);
            }
            catch
            {
                P = Q = D = "";
                return false;
            }


            if (publicA.N != publicB.N || privateA.N != publicA.N)
            {
                P = Q = D = "";
                return false;
            }

            BigInteger N = publicA.N;

            //Представить разность 𝑒𝐵 𝑑𝐵 − 1 в виде 2^f * 𝑠, где 𝑠 – нечетное число
            BigInteger sub = publicA.E * privateA.D - 1;
            BigInteger s; BigInteger f = 0;
            while (sub.IsEven)
            {
                sub /= 2; f++;
            }
            s = sub;

            BigInteger p, q, d;

            do
            {
                //Случайное b = a^s
                BigInteger a = Cryptography.getRandomBigInteger(N.ToByteArray().Length) % N;
                BigInteger b = BigInteger.ModPow(a, s, N);

                BigInteger b1 = b, b2, t;
                for (b2 = BigInteger.ModPow(b1, 2, N); b2 % N != 1; b1 = b2, b2 = BigInteger.ModPow(b2, 2, N)) ;
                if (b1 % N == N - 1) continue;
                t = b1;

                p = BigInteger.GreatestCommonDivisor(t + 1, N);
                q = BigInteger.GreatestCommonDivisor(t - 1, N);

                BigInteger phi = (p - 1) * (q - 1);
                d = Cryptography.ExtendedEuclide(publicB.E, phi);
                if ((publicB.E * d) % phi != 1) continue;
                break;

            } while (true);

            P = p.ToString();
            Q = q.ToString();
            D = d.ToString();

            return true;
        }

        public static void ExportPrivateKey(string path, string P, string Q, string D)
        {
            BigInteger bigP = BigInteger.Parse(P);
            BigInteger bigQ = BigInteger.Parse(Q);
            BigInteger bigD = BigInteger.Parse(D);

            RSAPrivateKey key = new RSAPrivateKey(bigP * bigQ, bigD);
            RSAPrivateKey.WriteToFile(key, path);
        }


        public static bool checkKey(BigInteger P, BigInteger Q, BigInteger E, BigInteger D, bool wienerCheck = true, bool pollardCheck = true)
        {
           
            BigInteger N = P * Q;
            BigInteger phi = (P - 1) * (Q - 1);

            if ((E * D) % phi != 1) return false;

            BigInteger m = Cryptography.getRandomBigInteger(16);
            BigInteger c = BigInteger.ModPow(m, E, N);
            if (BigInteger.ModPow(c, D, N) != m) return false;

            if (wienerCheck)
            {
                BigInteger min = P < Q ? P : Q;
                BigInteger max = P > Q ? P : Q;

                if (min < 2 * max) // Атака Винера
                {
                    if (81 * BigInteger.Pow(D, 4) < N) return false;
                }
            }
            

            if (pollardCheck)
            {
                int[] primes = new int[] { 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                    73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
                    179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
                    283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
                    419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
                    547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
                    661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
                    811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
                    947, 953, 967, 971, 977};

                foreach (int prime in primes)
                {
                    if ((P - 1) % prime == 0) return false;
                    if ((Q - 1) % prime == 0) return false;
                }
            }
            

            return true;
        }

        //Common N
        public static void GenerateRSAKeys(string P, string Q, out string E, out string D)
        {

            //throw new NotImplementedException();
            BigInteger bigP = BigInteger.Parse(P);
            BigInteger bigQ = BigInteger.Parse(Q);
            BigInteger phi = (bigP - 1) * (bigQ - 1);
            BigInteger e, d;
            do
            {
                e = Cryptography.getRandomBigInteger(phi.ToByteArray().Length);
                d = Cryptography.ExtendedEuclide(e, phi);
            } while ((e * d) % phi != 1 && (81 * d * d * d * d > bigP * bigQ));

            

            E = e.ToString();
            D = d.ToString();
        }

        //Default
        public static void GenerateRSAKeys(int keySize, out string N, out string P, out string Q, out string E, out string D, bool wienerCheck = true)
        {
            BigInteger bigN, bigP, bigQ, bigE, bigD, bigPhi;

            do
            {
                Cryptography.GeneratePrimePair(keySize, out bigP, out bigQ);
                bigN = bigP * bigQ;
                bigPhi = (bigP - 1) * (bigQ - 1);
                bigE = 65537;
                bigD = Cryptography.ExtendedEuclide(bigE, bigPhi);

                if (checkKey(bigP, bigQ, bigE, bigD, wienerCheck) == false) continue;
                break;
            } while (true);

            N = bigN.ToString();
            P = bigP.ToString();
            Q = bigQ.ToString();
            E = bigE.ToString();
            D = bigD.ToString();
        }

        //Common E
        public static void GenerateRSAKeys(int keySize, string E, out string N, out string P, out string Q, out string D, bool wienerCheck = true)
        {
            BigInteger bigN, bigP, bigQ, bigE, bigD, bigPhi;

            bigE = BigInteger.Parse(E);
            do
            {
                Cryptography.GeneratePrimePair(keySize, out bigP, out bigQ);
                bigN = bigP * bigQ;
                bigPhi = (bigP - 1) * (bigQ - 1);
                
                bigD = Cryptography.ExtendedEuclide(bigE, bigPhi);

                BigInteger min = bigP < bigQ ? bigP : bigQ;
                BigInteger max = bigP > bigQ ? bigP : bigQ;

                if (checkKey(bigP, bigQ, bigE, bigD, wienerCheck) == false) continue;
                break;
            } while (true);

            N = bigN.ToString();
            P = bigP.ToString();
            Q = bigQ.ToString();
            D = bigD.ToString();
        }

        internal static BigInteger RSAEncrypt(BigInteger data, RSAPrivateKey key)
        {
            return BigInteger.ModPow(data, key.D, key.N);
        }

        internal static BigInteger RSAEncrypt(BigInteger data, RSAPublicKey key)
        {
            return BigInteger.ModPow(data, key.E, key.N);
        }

        internal static BigInteger RSADecrypt(BigInteger data, RSAPrivateKey key)
        {
            return BigInteger.ModPow(data, key.D, key.N);
        }

        internal static BigInteger RSADecrypt(BigInteger data, RSAPublicKey key)
        {
            return BigInteger.ModPow(data, key.E, key.N);
        }


        public static void RSASign(string filenamePublicKey, string filenamePrivateKey, string fileNameData, string filenameSign)
        {

            RSAPublicKey publicKey = RSAPublicKey.ReadFromFile(filenamePublicKey);
            RSAPrivateKey privateKey = RSAPrivateKey.ReadFromFile(filenamePrivateKey);
            byte[] data = File.ReadAllBytes(fileNameData);

            byte[] signment = RSASign(publicKey, privateKey, data);
            File.WriteAllBytes(filenameSign, signment);
        }

        internal static byte[] RSASign(RSAPublicKey publicKey, RSAPrivateKey privateKey, byte[] data)
        {
            byte[] hash = Cryptography.CalculateSHA256(data);
            BigInteger hashInt = new BigInteger(hash);
            BigInteger hashIntEncrypted = RSAEncrypt(hashInt, privateKey);

            return ASN.GenerateSignHeader(publicKey, hashIntEncrypted.ToByteArray());
        }


        public static bool RSAVerify(string filenameMessage, string filenameSign)
        {
            byte[] message = File.ReadAllBytes(filenameMessage);
            byte[] sign = File.ReadAllBytes(filenameSign);
            return RSAVerify(message, sign);
        }

        public static bool RSAVerify(byte[] message, byte[] signment)
        {
            RSAPublicKey key;
            byte[] signHash;
            ASN.decodeSignHeader(signment, out key, out signHash);
            byte[] messageHash = Cryptography.CalculateSHA256(message);

            BigInteger signHashInt = new BigInteger(signHash);
            BigInteger signHashIntDecrypted = RSADecrypt(signHashInt, key);

            return Enumerable.SequenceEqual<byte>(signHashIntDecrypted.ToByteArray(), messageHash);
        }


        public static void ExportPublicKey(string path, string N, string E)
        {
            BigInteger bigN = BigInteger.Parse(N);
            BigInteger bigE = BigInteger.Parse(E);
            RSAPublicKey key = new RSAPublicKey(bigE, bigN);
            RSAPublicKey.WriteToFile(key, path);
        }

        public  static void ExportPrivateKey(string path, string N, string D)
        {
            BigInteger bigN = BigInteger.Parse(N);
            BigInteger bigD = BigInteger.Parse(D);
            RSAPrivateKey key = new RSAPrivateKey(bigN, bigD);
            RSAPrivateKey.WriteToFile(key, path);
        }

        public static byte[] EncryptFile(string filenameRSA, string filenameAES, string filenameData)
        {
            RSAPublicKey rsaPublicKey = RSAPublicKey.ReadFromFile(filenameRSA);
            byte[] AESKey = File.ReadAllBytes(filenameAES);
            byte[] data = File.ReadAllBytes(filenameData);

            return EncryptFile(rsaPublicKey, AESKey, data);
        }

        public static byte[] DecryptFile(string filenameRSA, string filenameData)
        {
            RSAPrivateKey rsaPrivateKey = RSAPrivateKey.ReadFromFile(filenameRSA);
            byte[] data = File.ReadAllBytes(filenameData);

            return DecryptFile(rsaPrivateKey, data);
        }


        internal static byte[] EncryptFile(RSAPublicKey rsaPublicKey, byte[] AESKey, byte[] data)
        {
            byte[] encrypted = Cryptography.ToAes256(data, AESKey);

            Console.WriteLine("N:" + rsaPublicKey.N.ToString());
            Console.WriteLine("E:" + rsaPublicKey.E.ToString());
            Console.WriteLine("AES before encrypting: " + BitConverter.ToString(AESKey));

            BigInteger aesBigInt = new BigInteger(AESKey);
            Console.WriteLine("AES before encrypting (BigInteger): " + aesBigInt.ToString());
            aesBigInt = RSAEncrypt(aesBigInt, rsaPublicKey) % rsaPublicKey.N;
            Console.WriteLine("AES after encrypting (BigInteger): " + aesBigInt.ToString());
            Console.WriteLine("AES after encrypting: " + BitConverter.ToString(aesBigInt.ToByteArray()));



            byte[] header = ASN.GenerateEncryptionHeader(rsaPublicKey, aesBigInt.ToByteArray());

            byte[] result = new byte[header.Length + encrypted.Length];
            header.CopyTo(result, 0);
            encrypted.CopyTo(result, header.Length);
            return result;
        }


        internal static byte[] DecryptFile(RSAPrivateKey rsaPrivateKey, byte[] data)
        {
            RSAPublicKey tempKey;
            byte[] AESKey;
            byte[] message;
            ASN.decodeEncryptionHeader(data, out tempKey, out AESKey, out message);

            //string messageString = Encoding.ASCII.GetString(message);
            Console.WriteLine("tempKey.N:" + tempKey.N.ToString());
            Console.WriteLine("rsaPrivateKey.N:" + rsaPrivateKey.N.ToString()); //tempKEY.N - правильно, rsaPrivateKey.N - нет
            Console.WriteLine("D:" + rsaPrivateKey.D.ToString());
            Console.WriteLine("AES before decrypting: " + BitConverter.ToString(AESKey));

            BigInteger aesBigInt = new BigInteger(AESKey);
            Console.WriteLine("AES before decrypting (BigInteger): " + aesBigInt.ToString());
            BigInteger aesBigIntDec = RSADecrypt(aesBigInt, rsaPrivateKey) % rsaPrivateKey.N;
            //aesBigIntDec = aesBigInt % BigInteger.Pow(2, 256);
            Console.WriteLine("AES after decrypting (BigInteger): " + aesBigIntDec.ToString());
            AESKey = aesBigIntDec.ToByteArray();

            Console.WriteLine("AES after decrypting: " + BitConverter.ToString(AESKey));

            return Cryptography.FromAes256(message, AESKey);
        }
    }


}
