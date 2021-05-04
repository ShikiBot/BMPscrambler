using System.Drawing;

namespace BMPscrambler.Classes
{
    class Crypto
    {
        public ImageInfo ImageInfo { get; }

        public Crypto(Bitmap bitmap)
        {
            ImageInfo = new ImageInfo(bitmap);
        }
    }
}
