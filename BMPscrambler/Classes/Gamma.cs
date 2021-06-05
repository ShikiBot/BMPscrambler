using System;
using System.Drawing;

namespace BMPscrambler.Classes
{
    class Gamma<T> : Symmetric<T>
    {
        private const int abc = 256;
        public int[] Message { get; set; }
        private int Length { get; }

        public Gamma(Bitmap bitmap, T key, int length) : base(bitmap, key)
        {
            Message = ImageInfo.ToInt32Array();
            Length = length;
        }

        public Gamma<int> Encrypt()
        {
            int[] key = LFSR(Convert.ToInt32(Key), Length);
            for (int i = 0; i < Message.Length; i++)
                Message[i] = (((Message[i] + key[i % key.Length]) % abc) + abc) % abc;
            return new Gamma<int>(ImageInfo.ToImage(Message), Convert.ToInt32(Key), Length);
        }

        public Gamma<int> Decrypt()
        {
            int[] key = LFSR(Convert.ToInt32(Key), Length);
            for (int i = 0; i < Message.Length; i++)          
                Message[i] = (((Message[i] + abc - key[i % key.Length]) % abc) +abc) % abc;
            return new Gamma<int>(ImageInfo.ToImage(Message), Convert.ToInt32(Key), Length);
        }        

        private int LFSR(int seed)
        {
            int b0 = (seed & 0b00000001);
            int b2 = (seed & 0b00000100) >> 2;
            int b3 = (seed & 0b00001000) >> 3;
            int b4 = (seed & 0b00010000) >> 4;
            int b7 = b4 ^ b3 ^ b2 ^ b0;
            return (b7 << 8) | (seed >> 1);
        }

        private int[] LFSR(int seed, int len)
        {
            int[] array = new int[len];
            array[0] = seed;
            for (int i = 1; i < len; i++)
                array[i] = LFSR(array[i-1]);
            return array;
        }
    }
}
