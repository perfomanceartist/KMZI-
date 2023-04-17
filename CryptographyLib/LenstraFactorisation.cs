using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    public class LenstraFactorisation
    {
        public BigInteger[] D;
        public BigInteger[] alpha;
        public int limit;
        public int limitAlpha = 1000;

        public DateTime startTime;
        public Int64 iterations;
        public BigInteger n;
        public LenstraFactorisation(int limit)
        {
            this.limit = limit;
            D = Sieve();
        }

        public void ShowTimerMessage(Object obj)
        {
            //Int64 iterations = Convert.ToInt64(obj);
            Console.Clear();

            TimeSpan difference = (DateTime.Now - startTime);
            string timeString = difference.Hours + ":" + difference.Minutes + ":" + difference.Seconds;

            Console.WriteLine("Current statistics:");
            Console.WriteLine("Iterations: " + iterations.ToString());
            Console.WriteLine("Total time: " + timeString);
            Console.WriteLine("-------------------------");
        }


        public BigInteger Factor (BigInteger n, int tries, out Int64 actualTries)
        {

            startTime = DateTime.Now;
            Timer timer = new Timer(ShowTimerMessage, null, 0, 5000);
            for (iterations = 0; iterations < tries; iterations++)
            {
                BigInteger d = Factor(n);
                
                if (d != 0 && d != 1)
                {
                    actualTries = iterations + 1;
                    return d;
                }
            }
            actualTries = tries;
            return 1;
        }


        public BigInteger Factor (BigInteger n)
        {
            this.n = n;
            AlphaInit();

            BigInteger x = Cryptography.getRandomBigInteger(1024) % n;
            BigInteger y = Cryptography.getRandomBigInteger(1024) % n;


            EllipticCurve curve = new EllipticCurve();
            curve.p = n;
            curve.A = Cryptography.getRandomBigInteger(8) % n;
            curve.B = (y * y - x * x * x - curve.A * x) % n;
            curve.xP = x;
            curve.yP = y;

            EllipticCurvePoint Q = new EllipticCurvePoint(x, y, curve);
            for (int i = 0; i < D.Length; i++)
            {
                BigInteger d = 1;
                BigInteger p = BigInteger.ModPow(D[i], alpha[i], n);
                Q = EllipticCurvePoint.Multiply(p, Q, n, out d);
                if (d != 0 && d != 1) return d;
            }

            return 1;
        }


        private BigInteger[] Sieve()
        {
            List<BigInteger> primes = new List<BigInteger>();
            primes.Add(2);
            for (int i = 3; i < limit; i+=2)
            {
                bool flag = true;
                for (int j = 0; j < primes.Count; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        flag = false;
                        break;                        
                    }
                }
                if (!flag) continue;
                primes.Add(i);
            }
            return primes.ToArray();
        }

        private void AlphaInit()
        {
            
            int size = D.Length;
            alpha = new BigInteger[size];

            

            for (int i = 0; i < size; i++)
            {
                BigInteger p = D[i];
                BigInteger a;
                for (a = 0; p < limitAlpha; a++)
                {
                    p *= D[i];
                }
                alpha[i] = a;
            }

        }

    }
}
