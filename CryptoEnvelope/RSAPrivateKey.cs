using RSA__Lab_1_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA__Lab_1_
{
    internal class RSAPrivateKey
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

            data = data.Substring( "-----BEGIN PRIVATE KEY-----".Length);
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
}
