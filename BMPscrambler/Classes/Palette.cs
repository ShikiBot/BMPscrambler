using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BMPscrambler.Classes
{
    class Palette
    {
        private Bitmap image;
        public Bitmap Image { get { return image; } set { image = Image; } }        
        public ColorPalette CPalette { get; }

        public Palette(Bitmap bitmap)
        {
            if (bitmap.PixelFormat != PixelFormat.Format8bppIndexed) image = Get8bppImage(bitmap);
            else image = bitmap;
            CPalette = Image.Palette;
        }

        public int[] ToInt32Array()
        {
            int[] iarray = new int[10000];
            for (int i = 0; i < 10000; i++)            
                iarray[i] = Array.IndexOf(CPalette.Entries, Image.GetPixel(i / 100, i % 100));
            return iarray;
        }

        public int[,] ToIntArray()
        {
            int[,] iarray = new int[100, 100];
            for (int i = 0; i < 10000; i++)
                iarray[i / 100, i % 100] = Array.IndexOf(CPalette.Entries, Image.GetPixel(i / 100, i % 100));
            return iarray;
        }

        public Bitmap ToImage(int[] array)
        {
            Bitmap bitmap = new Bitmap(100, 100);
            for (int i = 0; i < 10000; i++)
                bitmap.SetPixel(i / 100, i % 100, CPalette.Entries[array[i]]);
            return Get8bppImage(bitmap);
        }

        private Bitmap Get8bppImage(Bitmap bitmap)
        {
            Bitmap image = bitmap.Clone(new Rectangle(0, 0, 100, 100), PixelFormat.Format8bppIndexed);
            ColorPalette palette = new Bitmap(100, 100, PixelFormat.Format8bppIndexed).Palette;
            palette.Entries[0] = Color.FromArgb(0, 0, 0, 0);
            for (int i = 1; i < 255; i++)
                palette.Entries[i] = i < image.Palette.Entries.Length ? image.Palette.Entries[i] : Color.FromArgb(i, i, i);
            image.Palette = palette;
            return image;
        }
    }
}
