using System;
using System.Drawing;

namespace BMPscrambler.Classes
{
    class SinglePermutation<T> : Symmetric<T>
    {
        public SinglePermutation(Bitmap bitmap, T key) : base(bitmap, key)
        {

        }

        public SinglePermutation<int[]> Encrypt()
        {
            Bitmap Cimage = new Bitmap(ImageInfo.Image);
            for (int i = 0; i < ImageInfo.Width * ImageInfo.Height / (Key as int[]).Length; i++)
                for (int j = 0; j < (Key as int[]).Length; j++)
                {
                    int x = (i * (Key as int[]).Length + (Key as int[])[j]) / ImageInfo.Width;
                    int y = (i * (Key as int[]).Length + (Key as int[])[j]) % ImageInfo.Width;
                    int newx = (i * (Key as int[]).Length + j) / Cimage.Width;
                    int newy = (i * (Key as int[]).Length + j) % Cimage.Width;
                    Cimage.SetPixel(newx, newy, ImageInfo.Image.GetPixel(x, y));
                }
            return new SinglePermutation<int[]>(Cimage, Key as int[]);
        }

        public SinglePermutation<int[]> Decrypt()
        {
            Bitmap image = new Bitmap(ImageInfo.Image);
            for (int i = 0; i < image.Width * image.Height / (Key as int[]).Length; i++)
                for (int j = 0; j < (Key as int[]).Length; j++)
                {
                    int x = (i * (Key as int[]).Length + j) / ImageInfo.Width;
                    int y = (i * (Key as int[]).Length + j) % ImageInfo.Width;
                    int newx = (i * (Key as int[]).Length + (Key as int[])[j]) / image.Width;
                    int newy = (i * (Key as int[]).Length + (Key as int[])[j]) % image.Width;
                    image.SetPixel(newx, newy, ImageInfo.Image.GetPixel(x, y));

                }
            return new SinglePermutation<int[]>(image, Key as int[]); ;
        }

        public static int[] GenKey(int count)
        {
            int[] key = new int[count];
            for (int i = 0; i < count; i++)
                key[i] = i;
            key = Shuffle(key);
            return key;
        }

        private static int[] Shuffle(int[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                int temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }
    }
}
