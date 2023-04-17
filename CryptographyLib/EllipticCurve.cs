using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    public class EllipticCurvePoint
    {
        public BigInteger x;
        public BigInteger y;
        public EllipticCurve curve;
        public bool isNull;
        public EllipticCurvePoint(BigInteger x, BigInteger y, EllipticCurve curve, bool isNull = false)
        {
            this.x = x;
            this.y = y;
            this.curve = curve;
            this.isNull = isNull;
        }


        public static EllipticCurvePoint Add(EllipticCurvePoint a, EllipticCurvePoint b)
        {
            BigInteger p = a.curve.p;

            if (a.isNull) return b;
            if (b.isNull) return a;

            if (a.x == b.x && a.y == b.y)
            {
                BigInteger lambda = (3 * a.x * a.x + a.curve.A) * Cryptography.getInverse((2 * a.y), p) % p;
                if (lambda < 0) lambda += p;
                BigInteger x3 = (lambda * lambda - 2 * a.x) % p;
                BigInteger y3 = (lambda * (a.x - x3) - a.y) % p;
                if (x3 < 0) x3 += p;
                if (y3 < 0) y3 += p;
                return new EllipticCurvePoint(x3, y3, a.curve);
            }
            else if (a.x == b.x && (a.y == (-1) * b.y || a.y == b.y + p))
            {
                return new EllipticCurvePoint(0, 0, a.curve, isNull:true);
            }
            else
            {
                BigInteger lambda = (b.y - a.y) * Cryptography.getInverse((b.x - a.x), p) % p;
                if (lambda < 0) lambda += p;
                BigInteger x3 = (lambda * lambda - a.x - b.x) % p;
                BigInteger y3 = (lambda * (a.x - x3) - a.y) % p;
                if (x3 < 0) x3 += p;
                if (y3 < 0) y3 += p;
                return new EllipticCurvePoint(x3, y3, a.curve);
            }
        }

        public static EllipticCurvePoint Multiply(BigInteger k, EllipticCurvePoint P)
        {
            if (k < 0)
            {
                k = -k;
                P = new EllipticCurvePoint(P.x, -P.y, P.curve);
            }
            EllipticCurvePoint Q;
            bool[] kBits = new bool[k.GetBitLength()]; int j = 0;

            

            while (k > 0)
            {
                kBits[j] = !k.IsEven;
                k >>= 1;
                j++;
            }
            Array.Reverse(kBits);
            Q = new EllipticCurvePoint(0, 0, P.curve, isNull:true);
            for (int i = 0; i < kBits.Length; i++)
            {
                Q = EllipticCurvePoint.Add(Q, Q);
                if (kBits[i]) Q = EllipticCurvePoint.Add(Q, P);
            }

            return Q;
        }

        public static EllipticCurvePoint Add(EllipticCurvePoint a, EllipticCurvePoint b, BigInteger n, out BigInteger d)
        {
            d = 1;
            BigInteger p = a.curve.p;

            if (a.isNull) return b;
            if (b.isNull) return a;

            if (a.x == b.x && a.y == b.y)
            {
                BigInteger lambda = (3 * a.x * a.x + a.curve.A) * Cryptography.getInverse((2 * a.y), p) % p;
                if (lambda < 0) lambda += p;

                d = BigInteger.GreatestCommonDivisor(n, a.y) % n;
                if (d != 0 && d != 1) return a;

                BigInteger x3 = (lambda * lambda - 2 * a.x) % p;
                BigInteger y3 = (lambda * (a.x - x3) - a.y) % p;
                if (x3 < 0) x3 += p;
                if (y3 < 0) y3 += p;
                return new EllipticCurvePoint(x3, y3, a.curve);
            }
            else if (a.x == b.x && (a.y == (-1) * b.y || a.y == b.y + p))
            {
                return new EllipticCurvePoint(0, 0, a.curve, isNull: true);
            }
            else
            {
                BigInteger lambda = (b.y - a.y) * Cryptography.getInverse((b.x - a.x), p) % p;
                if (lambda < 0) lambda += p;

                d = BigInteger.GreatestCommonDivisor(n, b.x - a.x) % n;
                if (d != 0 && d != 1) return a;

                BigInteger x3 = (lambda * lambda - a.x - b.x) % p;
                BigInteger y3 = (lambda * (a.x - x3) - a.y) % p;
                if (x3 < 0) x3 += p;
                if (y3 < 0) y3 += p;
                return new EllipticCurvePoint(x3, y3, a.curve);
            }
        }

        public static EllipticCurvePoint Multiply(BigInteger k, EllipticCurvePoint P, BigInteger n, out BigInteger d)
        {
            d = 1;
            if (k < 0)
            {
                k = -k;
                P = new EllipticCurvePoint(P.x, -P.y, P.curve);
            }
            EllipticCurvePoint Q;
            bool[] kBits = new bool[k.GetBitLength()]; int j = 0;



            while (k > 0)
            {
                kBits[j] = !k.IsEven;
                k >>= 1;
                j++;
            }
            Array.Reverse(kBits);
            Q = new EllipticCurvePoint(0, 0, P.curve, isNull: true);
            for (int i = 0; i < kBits.Length; i++)
            {
                Q = EllipticCurvePoint.Add(Q, Q, n, out d);
                if (d != 0 && d != 1) return P;
                if (kBits[i]) Q = EllipticCurvePoint.Add(Q, P, n, out d);
                if (d != 0 && d != 1) return P;
            }

            return Q;
        }


    }

    public class GOST
    {
        EllipticCurve curve;

        public GOST()
        {
            this.curve = new EllipticCurve();
        }
        public GOST(EllipticCurve curve)
        {
            this.curve = curve;
        }

        public GOST (string A, string B, string p, string xP, string yP, string q)
        {
            this.curve = new EllipticCurve(A, B, p, xP, yP, q);
        }

        public byte[] getHash(byte[] message)
        {
            byte[] hash = Cryptography.CalculateSHA256(message);           
            Debug.Write(BitConverter.ToString(hash));
            return hash;
        }

        public void Sign(string d, string messageFilename, string path)
        {
            BigInteger bigD = BigInteger.Parse(d);

            byte[] msg = File.ReadAllBytes(messageFilename);
            byte[] sign = Sign(bigD, msg);
            File.WriteAllBytes(path, sign);
        }

        public byte[] Sign(BigInteger d, byte[] message)
        {
            return Sign(d, curve, message);
        }

        public byte[] Sign(BigInteger d, EllipticCurve curve, byte[] message)
        {
            byte[] hash = getHash(message);
            BigInteger alpha = new BigInteger(hash, true);
            BigInteger e = alpha % curve.q;
            if (e == 0) e = 1;
            BigInteger r, s;
            EllipticCurvePoint C;
            EllipticCurvePoint P = new EllipticCurvePoint(curve.xP, curve.yP, curve);
            do
            {
                BigInteger k = Cryptography.getRandomBigInteger(curve.q.ToByteArray().Length);
                C = EllipticCurvePoint.Multiply(k, P);
                r = C.x % curve.q;
                if (r == 0) continue;
                if (r < 0) r += curve.q;
                s = (r * d + k * e) % curve.q;
                if (s == 0) continue;
                if (s < 0) s += curve.q;
                break;
            } while (true);

            EllipticCurvePoint Q = EllipticCurvePoint.Multiply(d, P);
            return ASN.GOST.Encode(Q, r, s);
        }

        public bool Verify(string messageFilename, string signFilename)
        {
            byte[] msg = File.ReadAllBytes(messageFilename);
            byte[] sign = File.ReadAllBytes(signFilename);
            return Verify(msg, sign);
        }

        public bool Verify(byte[] message, byte[] sign)
        {
            BigInteger r, s;
            EllipticCurvePoint Q;
            ASN.GOST.Decode(sign, out Q, out r, out s);
            if (r == 0 || r >= Q.curve.q) return false;
            if (s == 0 || s >= Q.curve.q) return false;

            byte[] hash = getHash(message);

            BigInteger alpha = new BigInteger(hash, true);
            BigInteger e = alpha % Q.curve.q;
            if (e == 0) e = 1;

            BigInteger v = Cryptography.getInverse(e, Q.curve.q);
            
            BigInteger z1 = (s * v) % Q.curve.q;
            BigInteger z2 =  (Q.curve.q - r * v) % Q.curve.q;
            if (z2 < 0) z2 += Q.curve.q;

            EllipticCurvePoint P = new EllipticCurvePoint(Q.curve.xP, Q.curve.yP, Q.curve);
            EllipticCurvePoint z1P = EllipticCurvePoint.Multiply(z1, P);
            EllipticCurvePoint z2Q = EllipticCurvePoint.Multiply(z2, Q);
            EllipticCurvePoint C = EllipticCurvePoint.Add(z1P, z2Q);

            BigInteger R = C.x % Q.curve.q;

            return R == r;
        }
    }


    public class EllipticCurve
    {
        public BigInteger p;
        public BigInteger q;

        public BigInteger A; 
        public BigInteger B;
        public BigInteger xP;
        public BigInteger yP;

        public EllipticCurve()
        {
            A = 1;
            B = BigInteger.Parse("41431894589448105498289586872587560387979247722721848579560344157562082667257");
            p = BigInteger.Parse("57896044622894643241131754937450315750132642216230685504884320870273678881443");

            xP = BigInteger.Parse("54672615043105947691210796380713598019547553171137275980323095812145568854782");
            yP = BigInteger.Parse("42098178416750523198643432544018510845496542305814546233883323764837032783338");
            q = BigInteger.Parse("28948022311447321620565877468725157875067316353637126186229732812867492750347");
        }



        public EllipticCurve(string sA, string sB, string sp, string sxP, string syP, string sq)
        {
            A = BigInteger.Parse(sA);
            B = BigInteger.Parse(sB);
            p = BigInteger.Parse(sp);

            xP = BigInteger.Parse(sxP);
            yP = BigInteger.Parse(syP);
            q = BigInteger.Parse(sq);
        }


    }
}
