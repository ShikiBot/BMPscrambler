using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using BMPscrambler.Classes;
using System.Linq;
using System.Collections.Generic;

namespace BMPscrambler
{
    public partial class Form1 : Form
    {
        readonly ImageInfo originalImage;
        ImageInfo cypheredImage;
        readonly CypherImage cImage;
        HillCipher hillCipher = new HillCipher();
        SinglePermutation perm1 = new SinglePermutation();
        int k = 3;
        long abc = 4294967296; //(int)Math.Pow(256, 4);
        Matrix mess, ekey, dkey, cim, im;
        int[] key;

        public Form1()
        {
            InitializeComponent();
            cImage = new CypherImage();
            originalImage = new ImageInfo(Properties.Resources.GokuSSBlue);
            cypheredImage = new ImageInfo(Properties.Resources.GokuSSBlue);            
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(originalImage.Hmax + "     " + originalImage.H + "\n" + cypheredImage.Hmax + "     " + cypheredImage.H);
            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //hill
            /*mess = new Matrix(CypherImage.ToLongArray(originalImage.Image), k);
            var keys = hillCipher.GenKey(k, abc);
            ekey = keys[KeyType.ENCRYPT];
            dkey = keys[KeyType.DECRYPT];
            cim = hillCipher.Encrypt(mess, ekey, k, abc);
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(cim.Array.Cast<long>().ToArray()));*/

            //1perutation
            key = perm1.genKey(k);
            cypheredImage = new ImageInfo(perm1.Code(originalImage.Image, key));


            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k++;
            label1.Text = cypheredImage.H + " " + k;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = k > 2 ? k-=1 : k;
            label1.Text = cypheredImage.H + " " + k;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //hill
            /*im = hillCipher.Decrypt(mess, dkey, k, abc);            
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(im.Array.Cast<long>().ToArray()));*/


            //1perutation
            cypheredImage = new ImageInfo(perm1.Decode(cypheredImage.Image, key));


            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }
    }
}