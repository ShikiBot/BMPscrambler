using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BMPscrambler.Classes
{
    class CypherImage
    {
        public static byte[] ToByteArray(Bitmap image)
        {
            List<byte> imageByte = new List<byte>();
            for (int i = 0; i < image.Width * image.Height; i++)
            {
                imageByte.Add(Convert.ToByte(image.GetPixel(i / image.Width, i % image.Width).A));
                imageByte.Add(Convert.ToByte(image.GetPixel(i / image.Width, i % image.Width).R));
                imageByte.Add(Convert.ToByte(image.GetPixel(i / image.Width, i % image.Width).G));
                imageByte.Add(Convert.ToByte(image.GetPixel(i / image.Width, i % image.Width).B));
            }
            return imageByte.ToArray();
        }

        public static long[] ToLongArray(Bitmap image)
        {
            List<long> imageLong = new List<long>();
            for (int i = 0; i < image.Width * image.Height; i++)
                imageLong.Add((long)image.GetPixel(i / image.Width, i % image.Width).ToArgb());
                //imageByte.Add(image.counts[image.Image.GetPixel(i / image.Image.Width, i % image.Image.Width)]);
            return imageLong.ToArray();
        }        

        public static Bitmap FromByteArray(byte[] array)
        {
            Bitmap image = new Bitmap((int)Math.Sqrt(array.Length / 4), (int)Math.Sqrt(array.Length / 4));
            for (int i = 0; i < array.Length / 4; i++)
                image.SetPixel(i / image.Width, i % image.Width, Color.FromArgb(array[i * 4], array[i * 4 + 1], array[i * 4 + 2], array[i * 4 + 3]));
            return image;
        }

        public static Bitmap FromLongArray(long[] array)
        {
            Bitmap image = new Bitmap((int)Math.Sqrt(array.Length), (int)Math.Sqrt(array.Length));
            for (int i = 0; i < image.Width * image.Height; i++)
                image.SetPixel(i / image.Width, i % image.Width, Color.FromArgb((int)array[i]));
                //image.SetPixel(i / image.Width, i % image.Width, info.counts.FirstOrDefault(x => x.Value == array[i]).Key);
            return image;
        }
    }
}
