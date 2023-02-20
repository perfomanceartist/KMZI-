
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLib
{
    internal class ASN
    {
        protected static int getLengthInt(byte[] lenBytes, int startIndex)
        {
            if ((lenBytes[startIndex] & 0x80) == 0)
            {
                return lenBytes[startIndex];
            }
            byte k = (byte)(lenBytes[startIndex] & 0x7F);
            int len = 0;
            for (int i = 1; i <= k; i++)
            {
                len <<= 8;
                len |= lenBytes[startIndex + i];
            }
            return len;
        }

        protected static int getLengthInt(byte[] lenBytes)
        {
            return getLengthInt(lenBytes, 0);

        }

        protected static byte[] getLengthBytes(int len)
        {

            byte[] lenBytes;
            if (len < 128)
            {
                lenBytes = new byte[1];
                lenBytes[0] = (byte)len;
            }
            else
            {
                byte k = getMinK(len);
                lenBytes = new byte[1 + k];
                lenBytes[0] |= 0x80;
                lenBytes[0] |= (byte)k;

                for (int i = k; i >= 1; i--)
                {
                    byte t = (byte)(len & 0xFF);
                    len >>= 8;
                    lenBytes[i] = t;
                }
            }

            return lenBytes;
        }

        protected static byte getMinK(int l)
        {
            if (l < 128) return 0;
            byte count = 0;
            while (l > 0)
            {
                count++;
                l >>= 8;
            }
            return count;
        }



        internal class ASNElement
        {
            protected byte tag;
            protected int length;
            protected byte[] value = new byte[0];

            
            public virtual byte[] Encode()
            {
                throw new NotImplementedException();
                //return new byte[1];
            }

            public virtual void Decode(byte[] data)
            {
                throw new NotImplementedException();
            }
        }

        internal sealed class ASNSet : ASNSequence
        {
            public ASNSet()
            {
                tag = 0x31;
            }
        }
        internal sealed class ASNOctetString : ASNElement
        {
            public string algName;

            public ASNOctetString()
            {
                algName = "";
                tag = 0x04;
                length = 2;
                value = new byte[2];
            }
            public ASNOctetString(string algName) : base()
            {
                tag = 0x04;
                length = 2;
                value = new byte[2];
                this.algName = algName;
                if (algName == "RSA")
                {
                    value[0] = 0x00;
                    value[1] = 0x01;
                }
                else if (algName == "AES")
                {
                    value[0] = 0x10;
                    value[1] = 0x82;
                }
                else if (algName == "RSA-SHA256")
                {
                    value[0] = 0x00;
                    value[1] = 0x40;
                }
                else if (algName == "Massey-Omura")
                {
                    length = 4;
                    value = new byte[4];
                    value[0] = 0x80;
                    value[1] = 0x07;
                    value[2] = 0x02;
                    value[3] = 0x00;
                }
            }

            public override void Decode(byte[] data)
            {
                if (data[0] == 0x00 && data[1] == 0x01) algName = "RSA";
                else if (data[0] == 0x10 && data[1] == 0x82) algName = "AES";
                else if (data[0] == 0x00 && data[1] == 0x40) algName = "RSA-SHA256";
                else if (data.Length >= 4)
                {
                    if (data[0] == 0x80 &&
                        data[1] == 0x07 &&
                        data[2] == 0x02 &&
                        data[3] == 0x00) algName = "Massey-Omura";
                }
            }

            public override byte[] Encode()
            {
                byte[] data = new byte[1 + 1 + length]; 

                /*if (algName == "RSA" || algName == "AES" || algName == "RSA-SHA256")
                {
                    data = new byte[1 + 1 + 2];
                }
                else if (algName == "Massey-Omura")
                {
                    data = new byte[1 + 1 + 4];
                }*/
                
                data[0] = tag;
                data[1] = (byte)length;
                value.CopyTo(data, 2);
                return data;
            }
        }

        internal class ASNSequence : ASNElement
        {
            public List<ASNElement> elements;
            public ASNSequence()
            {
                tag = 0x30;
                length = 0;
                elements = new List<ASNElement>();
            }


            public void Add(ASNElement asnElem)
            {
                elements.Add(asnElem);
            }

            public override void Decode(byte[] data)
            {               
                length = getLengthInt(data, 1);
                value = new byte[length];
                Array.Copy(data, 1 + 1 + getMinK(length), value, 0, length);                
                
                for (int i = 0; i < length; )
                {
                    int len = getLengthInt(value, i + 1);

                    byte[] bytesToDecode = new byte[1 + 1 + getMinK(len) + len];
                    Array.Copy(value, i, bytesToDecode, 0, bytesToDecode.Length);

                    ASNElement asnElem;
                    if (value[i] == 0x02) //ASNInteger
                    {
                        asnElem = new ASNInteger();                        
                        /*
                        i++;
                        byte[] elemData = new byte[length - 1];
                        Array.Copy(value, i, elemData, 0, elemData.Length);

                        int len = getLengthInt(elemData);
                        elemData = new byte[len];
                        Array.Copy(value, i + 1 + len, elemData, 0, len);
                        ASNInteger asnInt = new ASNInteger(elemData);
                        elements.Add(asnInt);
                        i += 

                        ASNInteger asnInt;
                        int asnIntLen = 0;
                        byte k = 0;
                        if ((value[i + 1] & 0x80) == 0) //Длина меньше 128 байт
                        {
                            asnIntLen = value[i + 1];
                            byte[] asnIntBytes = new byte[asnIntLen];
                            Array.Copy(value, i + 2, asnIntBytes, 0, asnIntLen);
                            asnInt = new ASNInteger(asnIntBytes);
                        }
                        else
                        {
                            k = (byte)(value[i + 1] & 0x7F);
                            byte[] asnIntLenBytes = new byte[k];
                            Array.Copy(value, i + 2, asnIntLenBytes, 0, k);
                            asnIntLen = BitConverter.ToInt32(asnIntLenBytes);

                            byte[] asnIntBytes = new byte[asnIntLen];
                            Array.Copy(value, i + 2 + k, asnIntBytes, 0, asnIntLen);
                            asnInt = new ASNInteger(asnIntBytes);
                        }
                        i += 1 + 1 + k + asnIntLen;
                        */

                    }
                    else if (value[i] == 0x30) //ASNSequence
                    {
                        asnElem = new ASNSequence();
                    }
                    else if (value[i] == 0x31) //ASNSequence
                    {
                        asnElem = new ASNSet();
                    }
                    else if (value[i] == 0x04) //ASNSequence
                    {
                        asnElem = new ASNOctetString();
                    }

                    else
                    {
                        asnElem = new ASNElement();
                    }
                    asnElem.Decode(bytesToDecode);
                    elements.Add(asnElem);

                    i += bytesToDecode.Length;
                }
            }

            public override byte[] Encode()
            {
                value = new byte[0];
                foreach (ASNElement elem in elements)
                {
                    byte[] elemData = elem.Encode();
                    int oldLen = value.Length;
                    Array.Resize<byte>(ref value, value.Length + elemData.Length);
                    elemData.CopyTo(value, oldLen);
                }
                int len = value.Length;
                byte[] lenBytes = getLengthBytes(len);


                byte[] temp = new byte[1 + lenBytes.Length + value.Length];
                temp[0] = tag;
                lenBytes.CopyTo(temp, 1);
                value.CopyTo(temp, 1 + lenBytes.Length);

                return temp;
            }
            /*
            private void ExtractElementsFromData()
            {
                for (int i = 0; i < value.Length; )
                {
                    if (value[i] == 0x02) //ASNInteger
                    {
                        ASNInteger asnInt;
                        int asnIntLen = 0;
                        byte k = 0;
                        if ((value[i + 1] & 0x80) == 0) //Длина меньше 128 байт
                        {
                            asnIntLen = value[i + 1];
                            byte[] asnIntBytes = new byte[asnIntLen];
                            Array.Copy(value, i + 2, asnIntBytes, 0, asnIntLen);
                            asnInt = new ASNInteger(asnIntBytes);
                        }
                        else
                        {
                            k = (byte) ( value[i + 1] &  0x7F);
                            byte[] asnIntLenBytes = new byte[k];
                            Array.Copy(value, i + 2, asnIntLenBytes, 0, k);
                            asnIntLen = BitConverter.ToInt32(asnIntLenBytes);

                            byte[] asnIntBytes = new byte[asnIntLen];
                            Array.Copy(value, i + 2 + k, asnIntBytes, 0, asnIntLen);
                            asnInt = new ASNInteger(asnIntBytes);
                        }
                        i += 1 + 1 + k + asnIntLen;
                        elements.Add(asnInt);
                    }
                    else if (value[i] == 0x30) //ASNSequence
                    {

                    }
                }
            }

            public ASNSequence(byte[] newData)
            {
                if ((newData[1] & 0x80) == 0)
                {
                    length = newData[1];
                    value = new byte[newData.Length - 2];
                    Array.Copy(newData, 2, value, 0, length); 
                }
                else
                {
                    byte k = (byte)(newData[1] & 0x7F);
                    byte[] lenBytes = new byte[k];
                    Array.Copy(newData, 2, lenBytes, 0, k);
                    length = BitConverter.ToInt32(lenBytes);

                    value = new byte[length];
                    Array.Copy(newData, 2 + k, value, 0, length);
                }

                ExtractElementsFromData();


            }

            public void Add(ASNInteger asnInt)
            {
                elements.Add(asnInt);
            }

            public void Add(byte[] newData)
            {
                length += newData.Length;
                byte[] newArr = new byte[data.Length + newData.Length];
                data.CopyTo(newArr, 0);
                newData.CopyTo(newArr, data.Length);
                data = newArr;
                
            }

            public byte[] Decode()
            {
                byte[] lengthBytes;
                if (length < 128)
                {
                    lengthBytes = new byte[1];
                    lengthBytes[0] = (byte)length;
                }
                else
                {
                    int k = getMinK(length);
                    lengthBytes = new byte[1 + k];
                    lengthBytes[0] |= 0x80;
                    lengthBytes[0] |= (byte)k;
                    BitConverter.GetBytes(length).CopyTo(lengthBytes, 1);
                }
                


                byte[] value = new byte[1 + lengthBytes.Length + data.Length];
                value[0] = 0x30;
                lengthBytes.CopyTo(value, 1);
                data.CopyTo(value, lengthBytes.Length + 1);
                return value;
            }

            private void updateLength(int additionalDataLength)
            {
                
                length += additionalDataLength;
                if (length < 128)
                {
                    value[1] = (byte)length;
                }
                else
                {
                    int old_k = getMinK(length - additionalDataLength);
                    int k = getMinK(length);
                    value[1] |= 0x80;
                    value[1] |= (byte)k;
                    byte[] newValue = new byte[1 + 1 + k + length];
                    newValue[0] = value[0];
                    newValue[1] |= 0x80;
                    newValue[1] |= (byte)k;
                    BitConverter.GetBytes(length).CopyTo(newValue, 2);

                    Array.Copy(value, 2 + old_k, newValue, 2 + k, value.Length - 2 - old_k);
                }
            }
            */
            
        }

        internal sealed class ASNInteger : ASNElement
        {
            
            public ASNInteger()
            {
                tag = 0x02;
            }
            
            public ASNInteger(byte[] data) : this()
            {
                Array.Reverse(data);
                value = new byte[data.Length];
                data.CopyTo(value, 0);
                /*
                int k = getMinK(data.Length);
                value = new byte[1 + 1 + k + data.Length];
                value[0] = tag;
                if (data.Length < 128)
                {
                    value[1] = (byte)data.Length;
                }
                else
                {
                    value[1] |= 0x80;
                    value[1] |= (byte)k;
                    BitConverter.GetBytes(data.Length).CopyTo(value, 2);
                }
                data.CopyTo(value, 2 + k);*/
            }

            public BigInteger GetBigInteger()
            {
                Array.Reverse(value);
                return new BigInteger(value, true);
            }
            /// <summary>
            /// Возвращает BigInteger в ASN-формате
            /// </summary>
            public override byte[] Encode()
            {
                byte[] lenBytes = getLengthBytes(value.Length);
                byte[] data = new byte[1 + lenBytes.Length + value.Length];

                lenBytes.CopyTo(data, 1);
                value.CopyTo(data, 1 + lenBytes.Length);
                data[0] = tag;
                return data;
            }

            /// <summary>
            /// Переводит массив байт (полноценный) в ASNInteger
            /// </summary>
            public override void Decode(byte[] data)
            {
                length = getLengthInt(data, 1);
                value = new byte[length];
                Array.Copy(data, data.Length - length, value, 0, length);       
            }

        }

        public static byte[] GenerateSignHeader(RSAPublicKey key, byte[] hash)
        {
            


            ASNSequence mainSeq = new ASNSequence();

            ASNSet set = new ASNSet(); //TODO
            ASNSequence keySeq = new ASNSequence();
            ASNOctetString rsaID = new ASNOctetString("RSA-SHA256");

            ASNSequence rsaSeq = new ASNSequence();
            ASNInteger rsaN = new ASNInteger(key.N.ToByteArray());
            ASNInteger rsaE = new ASNInteger(key.E.ToByteArray());
            rsaSeq.Add(rsaN); rsaSeq.Add(rsaE);

            ASNSequence rsaParams = new ASNSequence();

            ASNSequence signSeq = new ASNSequence();
            ASNInteger signValue = new ASNInteger(hash);
            signSeq.Add(signValue);

            keySeq.Add(rsaID);
            keySeq.Add(rsaSeq);
            keySeq.Add(rsaParams);
            keySeq.Add(signSeq);

            set.Add(keySeq);
            mainSeq.Add(set);

            ASNSequence additionalSeq = new ASNSequence();
            mainSeq.Add(additionalSeq);

            return mainSeq.Encode();
        }
        public static byte[] GenerateEncryptionHeader(RSAPublicKey key, byte[] aesKey)
        {
            //throw new NotImplementedException();
            ASNSequence mainSeq = new ASNSequence();

            ASNSet set = new ASNSet(); //TODO
            ASNSequence keySeq = new ASNSequence();
            ASNOctetString rsaID = new ASNOctetString("RSA"); 

            ASNSequence rsaSeq = new ASNSequence();
            ASNInteger rsaN = new ASNInteger(key.N.ToByteArray());
            ASNInteger rsaE = new ASNInteger(key.E.ToByteArray());
            rsaSeq.Add(rsaN); rsaSeq.Add(rsaE);

            ASNSequence rsaParams = new ASNSequence();

            ASNSequence aesSeq = new ASNSequence();
            ASNInteger aesKeyValue = new ASNInteger(aesKey);
            aesSeq.Add(aesKeyValue);

            keySeq.Add(rsaID);
            keySeq.Add(rsaSeq);
            keySeq.Add(rsaParams);
            keySeq.Add(aesSeq);

            set.Add(keySeq);
            mainSeq.Add(set);

            ASNSequence additionalSeq = new ASNSequence();
            ASNOctetString aesID = new ASNOctetString("AES"); 
            additionalSeq.Add(aesID);
            mainSeq.Add(additionalSeq);

            return mainSeq.Encode();
        }


        public static void decodeSignHeader(byte[] data, out byte[] hash)
        {            
            RSAPublicKey publicKey;
            decodeSignHeader(data, out publicKey, out hash);
        }

        public static void decodeSignHeader(byte[] data, out RSAPublicKey key, out byte[] hash)
        {
            
            ASNSequence mainSeq = new ASNSequence();
            mainSeq.Decode(data);

            ASNSet set = (ASNSet)mainSeq.elements[0];
            ASNSequence keySeq = (ASNSequence)set.elements[0];
            ASNSequence rsaKeySeq = (ASNSequence)keySeq.elements[1];
            ASNInteger asnN = (ASNInteger)rsaKeySeq.elements[0];
            ASNInteger asnE = (ASNInteger)rsaKeySeq.elements[1];


            key = new RSAPublicKey(asnE.GetBigInteger(), asnN.GetBigInteger());

            ASNSequence asnHashSeq = (ASNSequence)keySeq.elements[3];
            ASNInteger asnHashInt = (ASNInteger)asnHashSeq.elements[0];
            hash = asnHashInt.GetBigInteger().ToByteArray();
        }


        public static void decodeEncryptionHeader(byte[] data, out RSAPublicKey rsaKey, out byte[] aesKey, out byte[] message)
        {
            int headerLen = getLengthInt(data, 1);
            byte[] headerBytes = new byte[1 + 1 + getMinK(headerLen) + headerLen];
            Array.Copy(data, headerBytes, headerBytes.Length);

            message = new byte[data.Length - (1 + 1 + getMinK(headerLen) + headerLen)];
            Array.Copy(
                data, 
                data.Length - message.Length, 
                message, 
                0,
                message.Length
            );


            ASNSequence mainSeq = new ASNSequence();
            mainSeq.Decode(headerBytes);

            ASNSet set = (ASNSet)mainSeq.elements[0];
            ASNSequence keySeq = (ASNSequence)set.elements[0];
            ASNSequence rsaKeySeq = (ASNSequence)keySeq.elements[1];
            ASNInteger asnN = (ASNInteger)rsaKeySeq.elements[0];
            ASNInteger asnE = (ASNInteger)rsaKeySeq.elements[1];


            rsaKey = new RSAPublicKey(asnE.GetBigInteger(), asnN.GetBigInteger());

            ASNSequence asnAESSeq = (ASNSequence)keySeq.elements[3];
            ASNInteger asnAESInt = (ASNInteger)asnAESSeq.elements[0];
            aesKey = asnAESInt.GetBigInteger().ToByteArray();
        }

        

        public static byte[] EncodeRSAPrivateKey(RSAPrivateKey key) {
            ASNInteger asnN = new ASNInteger(key.N.ToByteArray());
            ASNInteger asnD = new ASNInteger(key.D.ToByteArray());
            
            ASNSequence seq = new ASNSequence();
            seq.Add(asnN);
            seq.Add(asnD);
            return seq.Encode();
        }

        public static byte[] EncodeRSAPublicKey(RSAPublicKey key)
        {
            ASNInteger asnN = new ASNInteger(key.N.ToByteArray());
            ASNInteger asnE = new ASNInteger(key.E.ToByteArray());

            ASNSequence seq = new ASNSequence();
            seq.Add(asnN);
            seq.Add(asnE);
            return seq.Encode();
        }


        public static RSAPrivateKey DecodeRSAPrivateKey(byte[] data)
        {
            ASNSequence seq = new ASNSequence();
            seq.Decode(data);
            BigInteger n = ((ASNInteger)(seq.elements[0])).GetBigInteger();
            BigInteger d = ((ASNInteger)(seq.elements[1])).GetBigInteger();
            return new RSAPrivateKey(n, d);
        }

        public static RSAPublicKey DecodeRSAPublicKey(byte[] data)
        {
            ASNSequence seq = new ASNSequence();
            seq.Decode(data);
            BigInteger n = ((ASNInteger)(seq.elements[0])).GetBigInteger();
            BigInteger e = ((ASNInteger)(seq.elements[1])).GetBigInteger();
            return new RSAPublicKey(e, n);
        }


        public class Messey_Omura
        {
            public static byte[] encodeA(BigInteger p, BigInteger r, byte[] tA)
            {
                ASNSequence mainSeq = new ASNSequence();

                ASNSet set = new ASNSet(); //TODO
                ASNSequence keySeq = new ASNSequence();
                ASNOctetString algID = new ASNOctetString("Massey-Omura");

                ASNSequence openKeySeq = new ASNSequence(); //значение открытого ключа, не используется

                ASNSequence algParams = new ASNSequence();
                ASNInteger primeParam = new ASNInteger(p.ToByteArray());
                ASNInteger ordParam = new ASNInteger(r.ToByteArray());
                algParams.Add(primeParam); algParams.Add(ordParam);

                ASNSequence tASeq = new ASNSequence();
                ASNInteger tAValue = new ASNInteger(tA);
                tASeq.Add(tAValue);

                keySeq.Add(algID);
                keySeq.Add(openKeySeq);
                keySeq.Add(algParams);
                keySeq.Add(tASeq);

                set.Add(keySeq);
                mainSeq.Add(set);

                ASNSequence additionalSeq = new ASNSequence();
                mainSeq.Add(additionalSeq);

                return mainSeq.Encode();
            }

            public static void decodeA(byte[] data, out BigInteger p, out BigInteger r, out byte[] tA)
            {
                ASNSequence mainSeq = new ASNSequence();
                mainSeq.Decode(data);

                ASNSet set = (ASNSet)mainSeq.elements[0];
                ASNSequence keySeq = (ASNSequence)set.elements[0];
                ASNSequence algParams = (ASNSequence)keySeq.elements[2];
                ASNInteger asnP = (ASNInteger)algParams.elements[0];
                ASNInteger asnR = (ASNInteger)algParams.elements[1];


                p = asnP.GetBigInteger();
                r = asnR.GetBigInteger();

                ASNSequence tASeq = (ASNSequence)keySeq.elements[3];
                ASNInteger asnTA = (ASNInteger)tASeq.elements[0];

                tA = asnTA.GetBigInteger().ToByteArray();
            }

            public static byte[] encodeAB(byte[] tAB)
            {
                ASNSequence mainSeq = new ASNSequence();

                ASNSet set = new ASNSet(); //TODO
                ASNSequence keySeq = new ASNSequence();
                ASNOctetString algID = new ASNOctetString("Massey-Omura");

                ASNSequence openKeySeq = new ASNSequence(); //значение открытого ключа, не используется

                ASNSequence algParams = new ASNSequence();

                ASNSequence tABSeq = new ASNSequence();
                ASNInteger tABValue = new ASNInteger(tAB);
                tABSeq.Add(tABValue);

                keySeq.Add(algID);
                keySeq.Add(openKeySeq);
                keySeq.Add(algParams);
                keySeq.Add(tABSeq);

                set.Add(keySeq);
                mainSeq.Add(set);

                ASNSequence additionalSeq = new ASNSequence();
                mainSeq.Add(additionalSeq);

                return mainSeq.Encode();
            }

            public static void decodeAB(byte[] data, out byte[] tAB)
            {
                ASNSequence mainSeq = new ASNSequence();
                mainSeq.Decode(data);

                ASNSet set = (ASNSet)mainSeq.elements[0];
                ASNSequence keySeq = (ASNSequence)set.elements[0];

                ASNSequence tABSeq = (ASNSequence)keySeq.elements[3];
                ASNInteger asnTA = (ASNInteger)tABSeq.elements[0];

                tAB = asnTA.GetBigInteger().ToByteArray();
            }


            public static byte[] encodeB(byte[] tB)
            {
                ASNSequence mainSeq = new ASNSequence();

                ASNSet set = new ASNSet(); //TODO
                ASNSequence keySeq = new ASNSequence();
                ASNOctetString algID = new ASNOctetString("Massey-Omura");

                ASNSequence openKeySeq = new ASNSequence(); //значение открытого ключа, не используется

                ASNSequence algParams = new ASNSequence();

                ASNSequence tBSeq = new ASNSequence();
                ASNInteger tBValue = new ASNInteger(tB);
                tBSeq.Add(tBValue);

                keySeq.Add(algID);
                keySeq.Add(openKeySeq);
                keySeq.Add(algParams);
                keySeq.Add(tBSeq);

                set.Add(keySeq);
                mainSeq.Add(set);

                ASNSequence additionalSeq = new ASNSequence();
                ASNOctetString aesID = new ASNOctetString("AES");
                additionalSeq.Add(aesID);
                mainSeq.Add(additionalSeq);

                return mainSeq.Encode();
            }

            public static void decodeB(byte[] data, out byte[] tB)
            {
                ASNSequence mainSeq = new ASNSequence();
                mainSeq.Decode(data);

                ASNSet set = (ASNSet)mainSeq.elements[0];
                ASNSequence keySeq = (ASNSequence)set.elements[0];

                ASNSequence tBSeq = (ASNSequence)keySeq.elements[3];
                ASNInteger asnTB = (ASNInteger)tBSeq.elements[0];

                tB = asnTB.GetBigInteger().ToByteArray();
            }


        }





    }
}
