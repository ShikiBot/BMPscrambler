using System.Drawing;

namespace BMPscrambler.Classes
{
    class Asymmetric<T>: Crypto
    {
        public T PublicKey { get; set; }
        public T PrivateKey { get; set; }

        public Asymmetric(Bitmap bitmap, T publicKey, T privateKey): base(bitmap)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
