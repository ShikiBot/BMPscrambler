using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using BMPscrambler.Classes;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Imaging;

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
            Bitmap bitmap = Properties.Resources._21.Clone(new Rectangle(0, 0, 100, 100), PixelFormat.Format8bppIndexed); // Properties.Resources._21 - bitmap картинки в argb
            ColorPalette palette = new Bitmap(100, 100, PixelFormat.Format8bppIndexed).Palette; // палитра у Properties.Resources._21 не полная => нужно зафиксить
            palette.Entries[0] = Color.FromArgb(0, 0, 0, 0); // изначально после конвертации 32bpp в 8bpp палитра не содержит прозрачного цвета, добавляем
            for (int i = 1; i < 255; i++) // производится добор палитры до 256 цветов
                palette.Entries[i] = i < bitmap.Palette.Entries.Length ? bitmap.Palette.Entries[i] : Color.FromArgb(i, i, i);
            bitmap.Palette = palette; //замена поломаной палитры на зафикшеную
            originalImage = new ImageInfo(bitmap);
            cypheredImage = new ImageInfo(bitmap);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(originalImage.Hmax + "     " + originalImage.H + "\n" + cypheredImage.Hmax + "     " + cypheredImage.H);
            pictureBox1.Image = originalImage.Image;
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

            //var keys = hillCipher.GenKey(k);

            //1perutation
            /*key = perm1.genKey(k);
            cypheredImage = new ImageInfo(perm1.Code(originalImage.Image, key));*/


            //gamma
            Gamma gamma = new Gamma();
            gamma.LFSR(0b10001100, "x8 + x4 + x3+x2+ 1");

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