namespace BMPscrambler.Classes
{
    class BitmapConverter
    {
        public byte[] Bitmap2Array(System.Drawing.Bitmap image)
        {
            System.ComponentModel.TypeConverter bmpConverter = System.ComponentModel.TypeDescriptor.GetConverter(image.GetType());
            return (byte[])bmpConverter.ConvertTo(image, typeof(byte[]));
        }

        public System.Drawing.Bitmap Array2Bitmap(byte[] array)
        {
            System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
            System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(array);
            return new System.Drawing.Bitmap(img);
        }
    }
}
