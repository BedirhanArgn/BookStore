namespace BookStore
{
    partial class MusteriGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriGiris));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxParola = new System.Windows.Forms.TextBox();
            this.txtBoxKulAdi = new System.Windows.Forms.TextBox();
            this.btnMusteriGrs = new System.Windows.Forms.Button();
            this.btngirisgeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 91);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 252);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(94, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÜŞTERİ GİRİŞ EKRANI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(273, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(309, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Parola : ";
            // 
            // txtBoxParola
            // 
            this.txtBoxParola.Location = new System.Drawing.Point(378, 201);
            this.txtBoxParola.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxParola.Name = "txtBoxParola";
            this.txtBoxParola.PasswordChar = '*';
            this.txtBoxParola.Size = new System.Drawing.Size(132, 22);
            this.txtBoxParola.TabIndex = 1;
            // 
            // txtBoxKulAdi
            // 
            this.txtBoxKulAdi.Location = new System.Drawing.Point(378, 153);
            this.txtBoxKulAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxKulAdi.Name = "txtBoxKulAdi";
            this.txtBoxKulAdi.Size = new System.Drawing.Size(132, 22);
            this.txtBoxKulAdi.TabIndex = 0;
            // 
            // btnMusteriGrs
            // 
            this.btnMusteriGrs.Location = new System.Drawing.Point(399, 253);
            this.btnMusteriGrs.Name = "btnMusteriGrs";
            this.btnMusteriGrs.Size = new System.Drawing.Size(84, 31);
            this.btnMusteriGrs.TabIndex = 2;
            this.btnMusteriGrs.Text = "Giriş";
            this.btnMusteriGrs.UseVisualStyleBackColor = true;
            this.btnMusteriGrs.Click += new System.EventHandler(this.btnMusteriGrs_Click);
            // 
            // btngirisgeri
            // 
            this.btngirisgeri.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btngirisgeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btngirisgeri.BackgroundImage")));
            this.btngirisgeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btngirisgeri.ImageIndex = 0;
            this.btngirisgeri.Location = new System.Drawing.Point(474, 303);
            this.btngirisgeri.Name = "btngirisgeri";
            this.btngirisgeri.Size = new System.Drawing.Size(56, 54);
            this.btngirisgeri.TabIndex = 20;
            this.btngirisgeri.UseVisualStyleBackColor = false;
            this.btngirisgeri.Click += new System.EventHandler(this.btngirisgeri_Click);
            // 
            // MusteriGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(560, 369);
            this.Controls.Add(this.btngirisgeri);
            this.Controls.Add(this.btnMusteriGrs);
            this.Controls.Add(this.txtBoxKulAdi);
            this.Controls.Add(this.txtBoxParola);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MusteriGiris";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxParola;
        private System.Windows.Forms.TextBox txtBoxKulAdi;
        private System.Windows.Forms.Button btnMusteriGiris;
        private System.Windows.Forms.Button btnMusteriGrs;
        private System.Windows.Forms.Button btngirisgeri;
    }
}