using RSA__Lab_1_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASN_Test
{
    internal class RSAPublicKey
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
            data += "-----END PUBLIC KEY-----" + Environment.NewLine ;
            File.WriteAllText(filename, data);
        }


    }
}
