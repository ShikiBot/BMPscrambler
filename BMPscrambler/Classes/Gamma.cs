using System;
using System.Drawing;

namespace BMPscrambler.Classes
{
    class Gamma<T> : Symmetric<T>
    {
        private int[] Message { get; }
        private enum Byte
        {
            Digit0 = 1,
            Digit1 = 1 << 1,
            Digit2 = 1 << 2,
            Digit3 = 1 << 3,
            Digit4 = 1 << 4,
            Digit5 = 1 << 5,
            Digit6 = 1 << 6,
            Digit7 = 1 << 7,
            Digit8 = 1 << 8
        }

        public Gamma(Bitmap bitmap, T key) : base(bitmap, key)
        {
            Message = ImageInfo.ToInt32Array();
        }

        public Gamma<int> Encrypt()
        {
            int key = LFSR(Convert.ToInt32(Key), "x8+x4+x3+x2+1");
            for (int i = 0; i < Message.Length; i++)
            {
                Message[i] = (Message[i] + key) % 256;
                key = LFSR(key, "x8+x4+x3+x2+1");
            }
            return new Gamma<int>(ImageInfo.ToImage(Message), key);
        }

        public Gamma<int> Decrypt()
        {
            int key = LFSR(Convert.ToInt32(Key), "x8+x4+x3+x2+1");
            for (int i = 0; i < Message.Length; i++)
            {
                Message[i] = (Message[i] + 256 - key) % 256;
                key = LFSR(key, "x8+x4+x3+x2+1");
            }
            return new Gamma<int>(ImageInfo.ToImage(Message), key);
        }        

        public int LFSR(int seed, string formula)
        {
            formula = formula.Replace(" ", "");
            string[] frml = formula.ToLower().Split('+');
            int length = Convert.ToInt32(frml[0].Remove(0,1));
            while (seed > Math.Pow(2, length)) seed >>= 1;
            int bn = seed & (1 << Convert.ToInt32(frml[1].Remove(0, 1))) >> Convert.ToInt32(frml[1].Remove(0, 1));
            
            for (int i = 2; i < frml.Length; i++)
                switch (frml[i])
                {                    
                    case "x8": bn ^= (seed & (int)Byte.Digit8) >> 8; break;
                    case "x7": bn ^= (seed & (int)Byte.Digit7) >> 7; break;
                    case "x6": bn ^= (seed & (int)Byte.Digit6) >> 6; break;
                    case "x5": bn ^= (seed & (int)Byte.Digit5) >> 5; break;
                    case "x4": bn ^= (seed & (int)Byte.Digit4) >> 4; break;
                    case "x3": bn ^= (seed & (int)Byte.Digit3) >> 3; break;
                    case "x2": bn ^= (seed & (int)Byte.Digit2) >> 2; break;
                    case "1": bn ^= seed & (int)Byte.Digit1; break;
                }                          
            return (bn << length) | (seed >> 1);
        }
    }
}
