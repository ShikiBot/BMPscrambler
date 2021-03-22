namespace BMPscrambler.Classes
{
    class ImageInfo
    {
        public double H { get; }
        public double Hmax { get; }
        public double Size { get; }
        public System.Drawing.Bitmap Image { get; }

        public ImageInfo(System.Drawing.Bitmap image)
        {
            Image = image;
            Size = image.Width * image.Height;
            Hmax = GetHmax();
            H = GetH();            
        }

        private double GetHmax()
        {
            return System.Math.Log(Image.Width * Image.Height, 2);
        }

        private double GetH()
        {
            System.Collections.Generic.IDictionary<int, double> counts = new System.Collections.Generic.Dictionary<int, double>();
            double I = 0;            
            for (int i = 0; i < Size; i++)
            {
                System.Drawing.Color c = Image.GetPixel(i % Image.Width, i / Image.Width);
                if (!counts.ContainsKey(c.ToArgb()))
                    counts.Add(c.ToArgb(), 1);
                else
                    counts[c.ToArgb()]++;
            }
            foreach (int x in counts.Keys)
                I += (double)(counts[x] / Size) * System.Math.Log(Size / counts[x], 2);
            return I;
        }
    }
}

