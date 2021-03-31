using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using BMPscrambler.Classes;
using System.Linq;


namespace BMPscrambler
{
    public partial class Form1 : Form
    {
        readonly ImageInfo originalImage;
        ImageInfo cypheredImage;
        readonly CypherImage cImage;
        HillCipher hillCipher = new HillCipher();
        int k = 2;
        long abc = 4294967296; //(int)Math.Pow(256, 4);
        Matrix mess, ekey, dkey, cim, im;

        public Form1()
        {
            InitializeComponent();
            cImage = new CypherImage();
            originalImage = new ImageInfo(Properties.Resources.GokuSSBlue);
            cypheredImage = new ImageInfo(Properties.Resources.GokuSSBlue);

            //int x, y;
            //MessageBox.Show(hillCipher.Gcd(379, 37, out x, out y) + " " + x + " " + y);

            /*mess = new Matrix(CypherImage.ToLongArray(originalImage.Image), k);
            var keys = hillCipher.GenKey(k, abc);
            ekey = keys[KeyType.ENCRYPT];
            dkey = keys[KeyType.DECRYPT];
            //key = new Matrix(new int[,] { { 0, 12, 29 }, { 16, 9, 14 }, { 9, 8, 13 } });
            cim = hillCipher.Encrypt(mess, ekey, k, abc);            
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(cim.Array.Cast<long>().ToArray()));*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(originalImage.Hmax + "     " + originalImage.H + "\n" + cypheredImage.Hmax + "     " + cypheredImage.H);
            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mess = new Matrix(CypherImage.ToLongArray(originalImage.Image), k);
            var keys = hillCipher.GenKey(k, abc);
            ekey = keys[KeyType.ENCRYPT];
            dkey = keys[KeyType.DECRYPT];
            cim = hillCipher.Encrypt(mess, ekey, k, abc);
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(cim.Array.Cast<long>().ToArray()));
            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k++;
            /*mess = new Matrix(CypherImage.ToLongArray(originalImage.Image), k);
            var keys = hillCipher.GenKey(k, abc);
            ekey = keys[KeyType.ENCRYPT];
            dkey = keys[KeyType.DECRYPT];
            cim = hillCipher.Encrypt(mess, ekey, k, abc);
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(cim.Array.Cast<long>().ToArray()));
            pictureBox2.Image = cypheredImage.Image;*/
            label1.Text = cypheredImage.H + " " + k;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = k > 2 ? k-=1 : k;
            /*mess = new Matrix(CypherImage.ToLongArray(originalImage.Image), k);
            var keys = hillCipher.GenKey(k, abc);
            ekey = keys[KeyType.ENCRYPT];
            dkey = keys[KeyType.DECRYPT];
            cim = hillCipher.Encrypt(mess, ekey, k, abc);
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(cim.Array.Cast<long>().ToArray()));*/
            label1.Text = cypheredImage.H + " " + k;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Matrix message = new Matrix(new int[,] { { 25, 9, 21 }, { 17, 35, 35 } });
            //MessageBox.Show("message\n" + message.ToString());
            Matrix kkey = new Matrix(new int[,] { { 0, 12, 29 }, { 16, 9, 14 }, { 9, 8, 13 } });
            //MessageBox.Show("key\n" + kkey.ToString());
            Matrix cmessage = hillCipher.Encrypt(message, kkey, 3, 37);
            //MessageBox.Show("cmessage\n" + cmessage.ToString());
            //MessageBox.Show("det\n" + kkey.Determinant());
            Matrix revkkey = kkey.InverseByMod(33, 37);
            //MessageBox.Show("revkkey\n" + revkkey.ToString());
            Matrix matrixD = (kkey * revkkey) % 37;
            //MessageBox.Show(matrixD.ToString());
            Matrix dmessage = hillCipher.Decrypt(cmessage, kkey, k, 37);
            //MessageBox.Show(dmessage.ToString());*/

            im = hillCipher.Decrypt(mess, dkey, k, abc);            
            cypheredImage = new ImageInfo(HillCipher.FromLongArray(im.Array.Cast<long>().ToArray()));
            label1.Text = cypheredImage.H + " " + k;
            pictureBox2.Image = cypheredImage.Image;
        }
    }
}