using System;
using System.Windows.Forms;
using BMPscrambler.Classes;

namespace BMPscrambler
{
    public partial class Form1 : Form
    {
        readonly ImageInfo originalImage;
        readonly ImageInfo cypheredImage;
        readonly CypherImage cImage;

        public Form1()
        {
            InitializeComponent();
            cImage = new CypherImage();
            originalImage = new ImageInfo(Properties.Resources.GokuSSBlue);
            cypheredImage = new ImageInfo(cImage.Cypher(originalImage.Image));          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(originalImage.Hmax + "     " + originalImage.H + "\n" + cypheredImage.Hmax + "     " + cypheredImage.H);
            pictureBox2.Image = cypheredImage.Image;
        }
    }
}





























//for (int i = 0; i < originalImage.Image.Width * originalImage.Image.Height; i++)
//{
//    Color c = originalImage.Image.GetPixel(i % originalImage.Image.Width, i / originalImage.Image.Width);
//    originalImage.image.SetPixel(i % originalImage.image.Width, i / originalImage.image.Width, c);
//}