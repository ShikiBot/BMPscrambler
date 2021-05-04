using System;
using System.Windows.Forms;
using BMPscrambler.Classes;

namespace BMPscrambler
{
    public partial class Form1 : Form
    {
        readonly Random random;
        readonly ImageInfo originalImage;
        ImageInfo cypheredImage;
        HillCipher<Matrix> hillCipher;
        SinglePermutation<int[]> perm1;
        Gamma<int> gamma;        
        int k = 2;
        Matrix bf, af;

        public Form1()
        {
            InitializeComponent();
            originalImage = new ImageInfo(Properties.Resources._21);
            cypheredImage = new ImageInfo(Properties.Resources._21);
            random = new Random();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = originalImage.Image;
            label1.Text = originalImage.H + " " + k;
            pictureBox2.Image = originalImage.Image;
        }

        private void Btne_Click(object sender, EventArgs e)
        {
            //hill
            /*int rnd = random.Next(0, 10);
            if (k < 12)
            {
                hillCipher = new HillCipher<Matrix>(originalImage.Image,
                    HillCipher<Matrix>.GetKeys(k, rnd)[KeyType.ENCRYPT],
                    HillCipher<Matrix>.GetKeys(k, rnd)[KeyType.DECRYPT]);
                btnd.Enabled = true;
            }
            else
            {
                hillCipher = new HillCipher<Matrix>(originalImage.Image,
                    HillCipher<Matrix>.GenNewKey(k)[KeyType.ENCRYPT],
                    HillCipher<Matrix>.GenNewKey(k)[KeyType.DECRYPT]);
                btnd.Enabled = false;
            }
            HillCipher<Matrix> res = hillCipher.Encrypt();
            res.Message = hillCipher.Message;
            hillCipher = res;
            bf = hillCipher.Message;
            cypheredImage = hillCipher.ImageInfo;*/

            //1perutation
            /*perm1 = new SinglePermutation<int[]>(originalImage.Image, SinglePermutation<int>.GenKey(k));
            perm1 = perm1.Encrypt();
            cypheredImage = perm1.ImageInfo;*/

            //gamma
            gamma = new Gamma<int>(originalImage.Image, random.Next(0, 256));
            gamma = gamma.Encrypt();
            cypheredImage = gamma.ImageInfo;

            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void Btnplus_Click(object sender, EventArgs e)
        {
            k++;
            label1.Text = cypheredImage.H + " " + k;
            
        }

        private void Btnmin_Click(object sender, EventArgs e)
        {
            k = k > 2 ? k-=1 : k;
            label1.Text = cypheredImage.H + " " + k;
        }

        private void Btnd_Click(object sender, EventArgs e)
        {
            //hill
            /*HillCipher<Matrix> res = hillCipher.Decrypt();
            res.Message = hillCipher.Message;
            hillCipher = res;
            cypheredImage = hillCipher.ImageInfo;*/

            //1perutation
            /*perm1 = perm1.Decrypt();
            cypheredImage = perm1.ImageInfo;*/

            //gamma
            gamma = gamma.Decrypt();
            cypheredImage = gamma.ImageInfo;

            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }
    }
}