using System;
using System.Drawing;
using System.Media;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BMPscrambler.Classes;
using System.Text;

namespace BMPscrambler
{
    public partial class Form1 : Form
    {
        readonly Random random;
        readonly ImageInfo originalImage;
        readonly Bitmap bmp = Properties.Resources._21;
        ImageInfo cypheredImage;        
        HillCipher<Matrix> hillCipher;
        SinglePermutation<int[]> perm1;
        Gamma<int> gamma;
        RadioButton lastRB = new RadioButton();
        int k = 2;
        public Form1()
        {
            InitializeComponent();
            originalImage = new ImageInfo(bmp);
            cypheredImage = new ImageInfo(bmp);
            random = new Random();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = originalImage.Image;
            Horig.Text = "H = " + originalImage.H;
            pictureBox2.Image = originalImage.Image;
            Hcypher.Text = "H = " + originalImage.H;
            Hmax.Text = "Hmax = " + originalImage.Hmax;
        }

        private void Btne_Click(object sender, EventArgs e)
        {
            if (radioHill.Checked) //hill
            {
                lastRB = radioHill;
                int rnd = random.Next(0, 10);
                if (k < 11)
                {
                    hillCipher = new HillCipher<Matrix>(cypheredImage.Image,
                        HillCipher<Matrix>.GetKeys(k, rnd)[KeyType.ENCRYPT],
                        HillCipher<Matrix>.GetKeys(k, rnd)[KeyType.DECRYPT]);
                    btnd.Enabled = true;
                }
                else
                {
                    hillCipher = new HillCipher<Matrix>(cypheredImage.Image,
                        HillCipher<Matrix>.GenNewKey(k)[KeyType.ENCRYPT],
                        HillCipher<Matrix>.GenNewKey(k)[KeyType.DECRYPT]);
                    btnd.Enabled = false;
                }
                var tmp = hillCipher.Message;
                hillCipher = hillCipher.Encrypt();
                hillCipher.Message = tmp;

                cypheredImage = hillCipher.ImageInfo;
            }
            else if (radioPermut.Checked) //1perutation
            {
                lastRB = radioPermut;
                perm1 = new SinglePermutation<int[]>(
                    cypheredImage.Image, SinglePermutation<int>.GenKey(k));
                perm1 = perm1.Encrypt();
                cypheredImage = perm1.ImageInfo;
            }
            else if (radioGamm.Checked) //gamma
            {
                lastRB = radioGamm;
                gamma = new Gamma<int>(cypheredImage.Image, 
                    random.Next(0, 256), k);
                var tmp = gamma.Message;
                gamma = gamma.Encrypt();
                gamma.Message = tmp;
                cypheredImage = gamma.ImageInfo;
            }
            else SystemSounds.Exclamation.Play();
            Hcypher.Text = "H = " + cypheredImage.H;
            pictureBox2.Image = cypheredImage.Image;
        }
        private void Btnd_Click(object sender, EventArgs e)
        {
            if (lastRB == radioHill) //hill
            {
                hillCipher = hillCipher.Decrypt();                
                cypheredImage = hillCipher.ImageInfo;
            }
            else if (lastRB == radioPermut) //1perutation
            {
                perm1 = perm1.Decrypt();
                cypheredImage = perm1.ImageInfo;
            }
            else if (lastRB == radioGamm)//gamma
            {
                gamma = gamma.Decrypt();
                cypheredImage = gamma.ImageInfo;
            }
            else SystemSounds.Exclamation.Play();
            Hcypher.Text = "H = " + cypheredImage.H;
            pictureBox2.Image = cypheredImage.Image;
        }

        private void Btnmin1_Click(object sender, EventArgs e)
        {
            k = k > 2 ? k -= 1 : k;
            keyLen.Text = "Длинна ключа: " + k;
        }
        private void Btnmin10_Click(object sender, EventArgs e)
        {
            k = k > 12 ? k -= 10 : k;
            keyLen.Text = "Длинна ключа: " + k;
        }        
        private void Btnmin100_Click(object sender, EventArgs e)
        {
            k = k > 102 ? k -= 100 : k;
            keyLen.Text = "Длинна ключа: " + k;
        }
        private void Btnplus1_Click(object sender, EventArgs e)
        {
            k += 1;
            keyLen.Text = "Длинна ключа: " + k;
        }
        private void Btnplus10_Click(object sender, EventArgs e)
        {
            k += 10;
            keyLen.Text = "Длинна ключа: " + k;
        }
        private void Btnplus100_Click(object sender, EventArgs e)
        {
            k += 100;
            keyLen.Text = "Длинна ключа: " + k;

        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch;
            string fileheader = new StringBuilder().AppendLine("Key length;Hmax;H;Encryption time").ToString();
            File.WriteAllText("hill.csv", fileheader);
            File.WriteAllText("gamma.csv", fileheader);
            File.WriteAllText("1permutation.csv", fileheader);
            for (int k = 2; k <= 11; k++)
            {
                StringBuilder hcs = new StringBuilder();
                StringBuilder gcs = new StringBuilder();
                StringBuilder pcs = new StringBuilder();
                for (int j = 0; j < 10; j++)
                {                    
                    Gamma<int> gc = new Gamma<int>(bmp, random.Next(0, 256), k);
                    SinglePermutation<int[]> pc = new SinglePermutation<int[]>(bmp, SinglePermutation<int>.GenKey(k));
                    if (k > 100 & k % 100 == 0)
                    {
                        HillCipher<Matrix> hc = new HillCipher<Matrix>(
                            bmp,
                            HillCipher<Matrix>.GenNewKey(k/100)[KeyType.ENCRYPT],
                            HillCipher<Matrix>.GenNewKey(k/100)[KeyType.ENCRYPT]);
                        stopwatch = new Stopwatch();
                        stopwatch.Start();
                        hc = hc.Encrypt();
                        stopwatch.Stop();
                        hcs.AppendLine(String.Format("{0};{1};{2};{3}",
                            k,
                            hc.ImageInfo.Hmax,
                            hc.ImageInfo.H,
                            stopwatch.ElapsedMilliseconds));
                    }
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                    gc = gc.Encrypt();
                    stopwatch.Stop();
                    gcs.AppendLine(String.Format("{0};{1};{2};{3}",
                        k,
                        gc.ImageInfo.Hmax,
                        gc.ImageInfo.H,
                        stopwatch.ElapsedMilliseconds));
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                    pc = pc.Encrypt();
                    stopwatch.Stop();
                    pcs.AppendLine(String.Format("{0};{1};{2};{3}",
                        k,
                        pc.ImageInfo.Hmax,
                        pc.ImageInfo.H,
                        stopwatch.ElapsedMilliseconds));
                }
                File.AppendAllText("hill.csv", hcs.ToString());
                File.AppendAllText("gamma.csv", gcs.ToString());
                File.AppendAllText("1permutation.csv", pcs.ToString());
            }
            MessageBox.Show("Done");
        }
    }
}