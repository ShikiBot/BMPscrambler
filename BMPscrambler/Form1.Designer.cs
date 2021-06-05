
namespace BMPscrambler
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnplus100 = new System.Windows.Forms.Button();
            this.btnmin100 = new System.Windows.Forms.Button();
            this.Horig = new System.Windows.Forms.Label();
            this.btnd = new System.Windows.Forms.Button();
            this.btne = new System.Windows.Forms.Button();
            this.keyLen = new System.Windows.Forms.Label();
            this.btnmin10 = new System.Windows.Forms.Button();
            this.btnplus10 = new System.Windows.Forms.Button();
            this.btnmin1 = new System.Windows.Forms.Button();
            this.btnplus1 = new System.Windows.Forms.Button();
            this.Hcypher = new System.Windows.Forms.Label();
            this.Hmax = new System.Windows.Forms.Label();
            this.radioPermut = new System.Windows.Forms.RadioButton();
            this.radioHill = new System.Windows.Forms.RadioButton();
            this.radioGamm = new System.Windows.Forms.RadioButton();
            this.btnAuto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox2.InitialImage = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox2.Location = new System.Drawing.Point(146, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox1.InitialImage = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox1.Location = new System.Drawing.Point(15, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnplus100
            // 
            this.btnplus100.Location = new System.Drawing.Point(220, 146);
            this.btnplus100.Name = "btnplus100";
            this.btnplus100.Size = new System.Drawing.Size(26, 23);
            this.btnplus100.TabIndex = 2;
            this.btnplus100.Text = "+";
            this.btnplus100.UseVisualStyleBackColor = true;
            this.btnplus100.Click += new System.EventHandler(this.Btnplus100_Click);
            // 
            // btnmin100
            // 
            this.btnmin100.Location = new System.Drawing.Point(15, 146);
            this.btnmin100.Name = "btnmin100";
            this.btnmin100.Size = new System.Drawing.Size(26, 23);
            this.btnmin100.TabIndex = 3;
            this.btnmin100.Text = "-";
            this.btnmin100.UseVisualStyleBackColor = true;
            this.btnmin100.Click += new System.EventHandler(this.Btnmin100_Click);
            // 
            // Horig
            // 
            this.Horig.AutoSize = true;
            this.Horig.Location = new System.Drawing.Point(38, 128);
            this.Horig.Name = "Horig";
            this.Horig.Size = new System.Drawing.Size(54, 13);
            this.Horig.TabIndex = 4;
            this.Horig.Text = "H = 2.021";
            // 
            // btnd
            // 
            this.btnd.Location = new System.Drawing.Point(146, 209);
            this.btnd.Name = "btnd";
            this.btnd.Size = new System.Drawing.Size(100, 23);
            this.btnd.TabIndex = 5;
            this.btnd.Text = "Расшифровать";
            this.btnd.UseVisualStyleBackColor = true;
            this.btnd.Click += new System.EventHandler(this.Btnd_Click);
            // 
            // btne
            // 
            this.btne.Location = new System.Drawing.Point(146, 187);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(100, 23);
            this.btne.TabIndex = 6;
            this.btne.Text = "Зашифровать";
            this.btne.UseVisualStyleBackColor = true;
            this.btne.Click += new System.EventHandler(this.Btne_Click);
            // 
            // keyLen
            // 
            this.keyLen.AutoSize = true;
            this.keyLen.Location = new System.Drawing.Point(86, 173);
            this.keyLen.Name = "keyLen";
            this.keyLen.Size = new System.Drawing.Size(92, 13);
            this.keyLen.TabIndex = 7;
            this.keyLen.Text = "Длинна ключа: 2";
            // 
            // btnmin10
            // 
            this.btnmin10.Location = new System.Drawing.Point(52, 146);
            this.btnmin10.Name = "btnmin10";
            this.btnmin10.Size = new System.Drawing.Size(26, 23);
            this.btnmin10.TabIndex = 8;
            this.btnmin10.Text = "-";
            this.btnmin10.UseVisualStyleBackColor = true;
            this.btnmin10.Click += new System.EventHandler(this.Btnmin10_Click);
            // 
            // btnplus10
            // 
            this.btnplus10.Location = new System.Drawing.Point(183, 146);
            this.btnplus10.Name = "btnplus10";
            this.btnplus10.Size = new System.Drawing.Size(26, 23);
            this.btnplus10.TabIndex = 9;
            this.btnplus10.Text = "+";
            this.btnplus10.UseVisualStyleBackColor = true;
            this.btnplus10.Click += new System.EventHandler(this.Btnplus10_Click);
            // 
            // btnmin1
            // 
            this.btnmin1.Location = new System.Drawing.Point(89, 146);
            this.btnmin1.Name = "btnmin1";
            this.btnmin1.Size = new System.Drawing.Size(26, 23);
            this.btnmin1.TabIndex = 10;
            this.btnmin1.Text = "-";
            this.btnmin1.UseVisualStyleBackColor = true;
            this.btnmin1.Click += new System.EventHandler(this.Btnmin1_Click);
            // 
            // btnplus1
            // 
            this.btnplus1.Location = new System.Drawing.Point(146, 146);
            this.btnplus1.Name = "btnplus1";
            this.btnplus1.Size = new System.Drawing.Size(26, 23);
            this.btnplus1.TabIndex = 11;
            this.btnplus1.Text = "+";
            this.btnplus1.UseVisualStyleBackColor = true;
            this.btnplus1.Click += new System.EventHandler(this.Btnplus1_Click);
            // 
            // Hcypher
            // 
            this.Hcypher.AutoSize = true;
            this.Hcypher.Location = new System.Drawing.Point(169, 128);
            this.Hcypher.Name = "Hcypher";
            this.Hcypher.Size = new System.Drawing.Size(54, 13);
            this.Hcypher.TabIndex = 12;
            this.Hcypher.Text = "H = 2.021";
            // 
            // Hmax
            // 
            this.Hmax.AutoSize = true;
            this.Hmax.Location = new System.Drawing.Point(95, 9);
            this.Hmax.Name = "Hmax";
            this.Hmax.Size = new System.Drawing.Size(73, 13);
            this.Hmax.TabIndex = 13;
            this.Hmax.Text = "Hmax = 7.021";
            // 
            // radioPermut
            // 
            this.radioPermut.AutoSize = true;
            this.radioPermut.Location = new System.Drawing.Point(15, 187);
            this.radioPermut.Name = "radioPermut";
            this.radioPermut.Size = new System.Drawing.Size(128, 17);
            this.radioPermut.TabIndex = 14;
            this.radioPermut.TabStop = true;
            this.radioPermut.Text = "Шифр перестановки";
            this.radioPermut.UseVisualStyleBackColor = true;
            // 
            // radioHill
            // 
            this.radioHill.AutoSize = true;
            this.radioHill.Location = new System.Drawing.Point(15, 232);
            this.radioHill.Name = "radioHill";
            this.radioHill.Size = new System.Drawing.Size(88, 17);
            this.radioHill.TabIndex = 15;
            this.radioHill.TabStop = true;
            this.radioHill.Text = "Шифр Хилла";
            this.radioHill.UseVisualStyleBackColor = true;
            // 
            // radioGamm
            // 
            this.radioGamm.AutoSize = true;
            this.radioGamm.Location = new System.Drawing.Point(15, 209);
            this.radioGamm.Name = "radioGamm";
            this.radioGamm.Size = new System.Drawing.Size(101, 17);
            this.radioGamm.TabIndex = 16;
            this.radioGamm.TabStop = true;
            this.radioGamm.Text = "Гаммирование";
            this.radioGamm.UseVisualStyleBackColor = true;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(146, 267);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(100, 23);
            this.btnAuto.TabIndex = 17;
            this.btnAuto.Text = "Авто";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 254);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.radioGamm);
            this.Controls.Add(this.radioHill);
            this.Controls.Add(this.radioPermut);
            this.Controls.Add(this.Hmax);
            this.Controls.Add(this.Hcypher);
            this.Controls.Add(this.btnplus1);
            this.Controls.Add(this.btnmin1);
            this.Controls.Add(this.btnplus10);
            this.Controls.Add(this.btnmin10);
            this.Controls.Add(this.keyLen);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btnd);
            this.Controls.Add(this.Horig);
            this.Controls.Add(this.btnmin100);
            this.Controls.Add(this.btnplus100);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "АШИ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnplus100;
        private System.Windows.Forms.Button btnmin100;
        private System.Windows.Forms.Label Horig;
        private System.Windows.Forms.Button btnd;
        private System.Windows.Forms.Button btne;
        private System.Windows.Forms.Label keyLen;
        private System.Windows.Forms.Button btnmin10;
        private System.Windows.Forms.Button btnplus10;
        private System.Windows.Forms.Button btnmin1;
        private System.Windows.Forms.Button btnplus1;
        private System.Windows.Forms.Label Hcypher;
        private System.Windows.Forms.Label Hmax;
        private System.Windows.Forms.RadioButton radioPermut;
        private System.Windows.Forms.RadioButton radioHill;
        private System.Windows.Forms.RadioButton radioGamm;
        private System.Windows.Forms.Button btnAuto;
    }
}

