using System.Collections.Generic;
using System.Drawing;

namespace BMPscrambler.Classes
{
    class ImageInfo: Palette
    {
        public double H { get; }
        public double Hmax { get; }
        public double Size { get; }
        public int Width { get; }
        public int Height { get; }
        private IDictionary<Color, int> counts;

        public ImageInfo(Bitmap image) : base(image)
        {
            Size = image.Width * image.Height;
            ColorCount();
            Hmax = GetHmax();
            H = GetH();
            Width = image.Width;
            Height = image.Height;
        }

        private double GetHmax()
        {
            return System.Math.Log(Image.Width * Image.Height, 2);
        }

        private double GetH()
        {
            double I = 0;
            foreach (Color x in counts.Keys)
                I += counts[x] / Size * System.Math.Log(Size / counts[x], 2);
            return I;
        }

        private void ColorCount()
        {
            counts = new Dictionary<Color, int>();
            for (int i = 0; i < Size; i++)
            {
                Color c = Image.GetPixel(i % Image.Width, i / Image.Width);
                if (!counts.ContainsKey(c)) counts.Add(c, 1);
                else counts[c]++;
            }
        }
    }
}

