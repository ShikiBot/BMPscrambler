using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace BMPscrambler.Classes
{
    class HillCipher<T>: Asymmetric<T>
    {
        public Matrix Message { get; set; }
        private const int abc = 256;

        public HillCipher(Bitmap bitmap, T publicKey, T privateKey) : base(bitmap, publicKey, privateKey)
        {
            Message = new Matrix(ImageInfo.ToIntArray());
        }        

        public HillCipher<Matrix> Encrypt()
        {
            int len = (PublicKey as Matrix).Column;            
            int length = Message.Length % len == 0 ? Message.Length / len : (Message.Length - Message.Length % len) / len;
            for (int i = 0; i < length; i++)
            {
                Matrix msg = new Matrix(Message.GetArray(i * len, len));
                msg = msg * (PublicKey as Matrix) % abc;
                Message.SetArray(msg, i * len);
            }
            return new HillCipher<Matrix>(ImageInfo.ToImage(Message.ToInt32()),
                                          PublicKey as Matrix,
                                          PrivateKey as Matrix); 
        }

        public HillCipher<Matrix> Decrypt()
        {
            int len = (PrivateKey as Matrix).Column;
            if (len == 11)
            {
                return new HillCipher<Matrix>(Properties.Resources.GokuSSBlue,
                                       PublicKey as Matrix,
                                       PrivateKey as Matrix);
            }
            int length = Message.Length % len == 0 ? Message.Length / len : (Message.Length - Message.Length % len) / len;
            for (int i = 0; i < length; i++)
            {
                Matrix msg = new Matrix(Message.GetArray(i * len, len));
                msg = msg * (PrivateKey as Matrix) % abc;
                Message.SetArray(msg, i * len);
            }
            return new HillCipher<Matrix>(ImageInfo.ToImage(Message.ToInt32()),
                                          PublicKey as Matrix,
                                          PrivateKey as Matrix);
        }

        public static Dictionary<KeyType, Matrix> GetKeys(int len, int num)
        {
            var keys = new Dictionary<KeyType, Matrix>();
            string[] strkeys = File.ReadAllText("keys/" + len).Split('\n');
            var earray = JsonConvert.DeserializeObject<int[,]>(strkeys[num * 2]);
            var darray = JsonConvert.DeserializeObject<int[,]>(strkeys[num * 2 + 1]);
            keys.Add(KeyType.ENCRYPT, new Matrix(earray));
            keys.Add(KeyType.DECRYPT, new Matrix(darray));
            return keys;
        }

        public static IDictionary<KeyType, Matrix> GenKey(int len)
        {
            Random random = new Random();
            var keys = new Dictionary<KeyType, Matrix>();
            Matrix MEkey = new Matrix(len, len), MDkey = new Matrix(len, len);
            bool flag = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (flag)
            {
                flag = false;
                MEkey = Keygen(len, random);
                long revDet, detK = MEkey.Determinant();
                try
                {
                    revDet = Gcd(detK, abc);
                    MDkey = MEkey.InverseByMod((int)revDet, abc);
                }
                catch { flag = true; }
                if (!(MEkey * MDkey % abc).IsIdentityMatrix()) flag = true;
            }
            stopwatch.Stop();
            keys.Add(KeyType.ENCRYPT, MEkey);
            keys.Add(KeyType.DECRYPT, MDkey);
            return keys;
        }

        public static IDictionary<KeyType, Matrix> GenNewKey(int len)
        {
            Random random = new Random();
            var keys = new Dictionary<KeyType, Matrix>();
            Matrix MEkey = new Matrix(len, len), MDkey = new Matrix(len, len);            
            MEkey = Keygen(len, random);
            MDkey = Keygen(len, random);
            keys.Add(KeyType.ENCRYPT, MEkey);
            keys.Add(KeyType.DECRYPT, MDkey);
            return keys;
        }

        private static Matrix Keygen(int len, Random random)
        {
            int[,] key = new int[len, len];
            for (int i = 0; i < Math.Pow(len, 2); i++)
                key[i / len, i % len] = random.Next(0, 255);
            return new Matrix(key);
        }

        private static long Gcd(long det, long mod) 
        {
            long t = 0;
            long r = mod;
            long newt = 1;
            long newr = det;
            while (newr != 0)
            {
                long qoutient = r / newr;
                long nnt = t - qoutient * newt;
                t = newt;
                newt = nnt;
                long nnr = r - qoutient * newr;
                r = newr;
                newr = nnr;
            }
            if (r > 1) throw new Exception("a is not invertible");
            if (t < 0) t += mod;
            return t;
        }
    }
}
