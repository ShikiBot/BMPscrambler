namespace BMPscrambler.Classes
{
    class CypherImage
    {
        public double Key { get; }
        readonly private BitmapConverter bmpConvert;

        public CypherImage()
        {
            Key = GenerateKey();
            bmpConvert = new BitmapConverter();
        }

        public CypherImage(double key)
        {
            Key = key;
            bmpConvert = new BitmapConverter();
        }

        private double GenerateKey()
        {
            return 0;
        }

        public System.Drawing.Bitmap Cypher(System.Drawing.Bitmap image)
        {
            byte[] arr = bmpConvert.Bitmap2Array(image);             
            return bmpConvert.Array2Bitmap(arr);
        }
    }    
}
