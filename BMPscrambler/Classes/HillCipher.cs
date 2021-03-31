using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BMPscrambler.Classes
{
    class HillCipher: CypherImage
    {
        public IDictionary<KeyType, Matrix> GenKey(int len, long abc)
        {
            Random random = new Random();
            long[,] key = new long[len, len];
            for (int i = 0; i < Math.Pow(len, 2); i++)
                key[i / len, i % len] = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)).ToArgb();
            var keys = new Dictionary<KeyType, Matrix>();            
            Matrix MEkey = new Matrix(key), MDkey = new Matrix(len, len);
            long revDet, detK = MEkey.Determinant();
            bool flag = true;
            while (flag)
            {
                flag = false;                
                try { 
                    revDet = Gcd(detK, abc);
                    MDkey = MEkey.InverseByMod(revDet, abc);
                } catch { flag = true; }                
                if (!(MEkey * MDkey % abc).IsIdentityMatrix()) flag = true;                 
            }
            MessageBox.Show((MEkey * MDkey % abc).ToString());
            keys.Add(KeyType.ENCRYPT, MEkey);
            keys.Add(KeyType.DECRYPT, MDkey);
            return keys;
        }

        public Matrix Encrypt(Matrix message, Matrix key, int len, long abc)
        {
            int length = message.Length % len == 0 ? message.Length / len : (message.Length + (len - (message.Length % len))) / len;
            for (int i = 0; i < length; i++)
            {
                Matrix msg = new Matrix( message.GetRow(i), len );
                msg = (msg * key) % abc;
                message.SetRow(msg, i);
            }
            return message;
        }

        public Matrix Decrypt(Matrix message, Matrix newKey, int len, long abc)
        {
            int length = message.Length % len == 0 ? message.Length / len : (message.Length + (len - (message.Length % len))) / len;
            for (int i = 0; i < length; i++)
            {
                Matrix msg = new Matrix(message.GetRow(i), len);
                msg = (msg * newKey) % abc;
                message.SetRow(msg, i);
            }
            return message;
        }

        public long Gcd(long a, long n) // a = det, mod = n
        {
            long t = 0;
            long r = n;
            long newt = 1;
            long newr = a;
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
            if (t < 0) t+=n;
            return t;
        }

        /*int Gcd(int det, int mod)
        {
            double B = 1;
            double C = 0;
            double D = det % mod;
            double E = mod;
            while (D > 1)
            {
                double F = E / D;
                double G = C - B * F;
                double H = E - D * F;
                C = B;
                E = D;
                B = G;
                D = H;
            }
            return (int)Math.Round(((B % mod) + mod) % mod);
        }*/

        /*public int Gcd(int a, int b, out int x, out int y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }
            int x1, y1;
            int d1 = Gcd(b, ((a % b) + b) % b, out x1, out y1);
            x = y1;
            y = x1 - (a / b) * y1;
            return d1;
            
        }*/
    }
}
