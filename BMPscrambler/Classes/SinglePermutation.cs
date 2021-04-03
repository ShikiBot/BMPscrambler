using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPscrambler.Classes
{
    class SinglePermutation 
    {
        public Bitmap Code(Bitmap image, int[] key)
        {
            Bitmap Cimage = new Bitmap(image);
            for (int i = 0; i < image.Width * image.Height / key.Length; i++)
                for (int j = 0; j < key.Length; j++)
                    Cimage.SetPixel((i*key.Length + j) / Cimage.Width, (i * key.Length + j) % Cimage.Width, image.GetPixel((i * key.Length + key[j]) / image.Width, (i * key.Length + key[j]) % image.Width));
            return Cimage;
        }

        public Bitmap Decode(Bitmap image, int[] key)
        {
            Bitmap Cimage = new Bitmap(image);
            for (int i = 0; i < image.Width * image.Height / key.Length; i++)
                for (int j = 0; j < key.Length; j++)
                    Cimage.SetPixel((i * key.Length + key[j]) / image.Width, (i * key.Length + key[j]) % image.Width, image.GetPixel((i * key.Length + j) / Cimage.Width, (i * key.Length + j) % Cimage.Width));
            return Cimage;
        }

        public int[] GenKey(int count)
        {
            int[] key = new int[count];
            for (int i = 0; i < count; i++)
                key[i] = i;
            key = Shuffle(key);
            return key;
        }

        private int[] Shuffle(int[] array)
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
