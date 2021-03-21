namespace BMPscrambler.Classes
{
    class ImageInfo
    {
        public double H { get; }
        public double Hmax { get; }
        public System.Drawing.Bitmap Image { get; }

        readonly private System.Collections.Generic.IDictionary<int, double> counts;

        public ImageInfo(System.Drawing.Bitmap image)
        {
            this.Image = image;
            counts = new System.Collections.Generic.Dictionary<int, double>();
            Hmax = GetHmax();
            H = GetH();            
        }

        private double GetHmax()
        {
            return System.Math.Log(Image.Width * Image.Height, 2);
        }

        private double GetH()
        {
            double I = 0;            
            for (int i = 0; i < Image.Width * Image.Height; i++)
            {
                System.Drawing.Color c = Image.GetPixel(i % Image.Width, i / Image.Width);
                if (!counts.ContainsKey(c.ToArgb()))
                    counts.Add(c.ToArgb(), 1);
                else
                    counts[c.ToArgb()]++;
            }
            foreach (int x in counts.Keys)
                I += (double)(counts[x] / (Image.Width * Image.Height)) * System.Math.Log(Image.Width * Image.Height / counts[x], 2);
            return I;
        }
    }
}

