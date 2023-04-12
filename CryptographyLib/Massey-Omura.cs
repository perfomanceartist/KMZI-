using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    public class Massey_Omura
    {
        public BigInteger p; 
        public BigInteger r; //порядок мультипликативной группы поля Fp = p-1

        public BigInteger a;
        public BigInteger inverseA;
        public BigInteger b;
        public BigInteger inverseB;

        
        public int keySize = 1024;

        private bool checkForSmallPrimes(BigInteger x)
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
                if ((x - 1) % prime == 0) return false;                
            }
            return true;
        }

        public Massey_Omura(int keySize) {
            this.keySize = keySize;
            do
            {
                Cryptography.GeneratePrime(keySize, out p);
                if (!checkForSmallPrimes(p)) continue;
            } while (p < BigInteger.Pow(2, 1024));
            r = p - 1;
        }
        public Massey_Omura()
        {
            do
            {
                Cryptography.GeneratePrime(keySize, out p);
                if (!checkForSmallPrimes(p)) continue;
            } while (p < BigInteger.Pow(2, 1024));
            //В практических реализациях для a и b используются числа порядка 10^100 и p порядка 10^300.
            //Соответственно, ключ будет порядка 10^300 или 2^1000.
            r = p - 1;
        }


        public byte[] getA(byte[] key) {

            do
            {
                a = Cryptography.getRandomBigInteger(r.ToByteArray().Length);
                if (BigInteger.GreatestCommonDivisor(a, r) != 1) continue;
                inverseA = Cryptography.getInverse(a, r);
            } while (inverseA == 0 || ((a * inverseA) % r) != 1);
            bool check = (a * inverseA) % r == 1;
            BigInteger t = new BigInteger(key, true);
            BigInteger tA = BigInteger.ModPow(t, a, p);
            Debug.WriteLine("p (modulo):" + p.ToString());
            Debug.WriteLine("r (Порядок группы):" + r.ToString());
            Debug.WriteLine("t (key):" + t.ToString());
            Debug.WriteLine("a:" + a.ToString());
            Debug.WriteLine("tA:" + tA.ToString());
            return ASN.Messey_Omura.encodeA(p, r, tA.ToByteArray());
        }

        public byte[] getAB(byte[] asntA)
        {
            byte[] tA;
            ASN.Messey_Omura.decodeA(asntA, out p, out r, out tA);
            Debug.WriteLine("tA (received):" + new BigInteger(tA, true).ToString());

            do
            {
                b = Cryptography.getRandomBigInteger(r.ToByteArray().Length);
                if (BigInteger.GreatestCommonDivisor(b, r) != 1) continue;
                inverseB = Cryptography.getInverse(b, r);                
            } while (inverseB == 0 || ((b * inverseB) % r) != 1);
            bool check = (b * inverseB) % r == 1;
            Debug.WriteLine("b:" + b.ToString());
            BigInteger tAB = BigInteger.ModPow(new BigInteger(tA, true), b, p);
            Debug.WriteLine("tAB:" + tAB.ToString());
            return ASN.Messey_Omura.encodeAB(tAB.ToByteArray());
        }

        public byte[] getB(byte[] asntAB)
        {
            byte[] tAB;
            ASN.Messey_Omura.decodeAB(asntAB, out tAB);
            Debug.WriteLine("tAB (received):" + new BigInteger(tAB, true).ToString());

            BigInteger tB = BigInteger.ModPow(new BigInteger(tAB, true), inverseA, p);
            Debug.WriteLine("tB:" + tB.ToString());
            return ASN.Messey_Omura.encodeB(tB.ToByteArray());
        }

        public byte[] getT(byte[] asntB)
        {
            byte[] tB;
            ASN.Messey_Omura.decodeB(asntB, out tB);
            Debug.WriteLine("tB (received):" + new BigInteger(tB, true).ToString());

            BigInteger key = BigInteger.ModPow(new BigInteger(tB, true), inverseB, p) % BigInteger.Pow(2, 256);
            Debug.WriteLine("t (key):" + key.ToString());
            byte[] keyBytes = new byte[32];
            Array.Copy(key.ToByteArray(), keyBytes, 32);
            return keyBytes;
        }
    }
}
