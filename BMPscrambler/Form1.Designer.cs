
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
            this.btnplus = new System.Windows.Forms.Button();
            this.btnmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnd = new System.Windows.Forms.Button();
            this.btne = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox2.InitialImage = global::BMPscrambler.Properties.Resources.GokuSSBlue;
            this.pictureBox2.Location = new System.Drawing.Point(118, 12);
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnplus
            // 
            this.btnplus.Location = new System.Drawing.Point(44, 121);
            this.btnplus.Name = "btnplus";
            this.btnplus.Size = new System.Drawing.Size(26, 23);
            this.btnplus.TabIndex = 2;
            this.btnplus.Text = "+";
            this.btnplus.UseVisualStyleBackColor = true;
            this.btnplus.Click += new System.EventHandler(this.Btnplus_Click);
            // 
            // btnmin
            // 
            this.btnmin.Location = new System.Drawing.Point(12, 121);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(26, 23);
            this.btnmin.TabIndex = 3;
            this.btnmin.Text = "-";
            this.btnmin.UseVisualStyleBackColor = true;
            this.btnmin.Click += new System.EventHandler(this.Btnmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnd
            // 
            this.btnd.Location = new System.Drawing.Point(118, 150);
            this.btnd.Name = "btnd";
            this.btnd.Size = new System.Drawing.Size(99, 23);
            this.btnd.TabIndex = 5;
            this.btnd.Text = "decr";
            this.btnd.UseVisualStyleBackColor = true;
            this.btnd.Click += new System.EventHandler(this.Btnd_Click);
            // 
            // btne
            // 
            this.btne.Location = new System.Drawing.Point(12, 150);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(100, 23);
            this.btne.TabIndex = 6;
            this.btne.Text = "encr";
            this.btne.UseVisualStyleBackColor = true;
            this.btne.Click += new System.EventHandler(this.Btne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 181);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnplus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnplus;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnd;
        private System.Windows.Forms.Button btne;
    }
}

