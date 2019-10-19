namespace BookStore
{
    partial class AdminGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminGiris));
            this.btnAdminGiris = new System.Windows.Forms.Button();
            this.txtBoxAdmID = new System.Windows.Forms.TextBox();
            this.txtBoxAdmParola = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnadmingeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdminGiris
            // 
            this.btnAdminGiris.Location = new System.Drawing.Point(429, 238);
            this.btnAdminGiris.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdminGiris.Name = "btnAdminGiris";
            this.btnAdminGiris.Size = new System.Drawing.Size(105, 28);
            this.btnAdminGiris.TabIndex = 2;
            this.btnAdminGiris.Text = "GİRİŞ";
            this.btnAdminGiris.UseVisualStyleBackColor = true;
            this.btnAdminGiris.Click += new System.EventHandler(this.btnAdminGiris_Click);
            // 
            // txtBoxAdmID
            // 
            this.txtBoxAdmID.Location = new System.Drawing.Point(416, 134);
            this.txtBoxAdmID.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxAdmID.Name = "txtBoxAdmID";
            this.txtBoxAdmID.Size = new System.Drawing.Size(132, 22);
            this.txtBoxAdmID.TabIndex = 0;
            // 
            // txtBoxAdmParola
            // 
            this.txtBoxAdmParola.Location = new System.Drawing.Point(416, 182);
            this.txtBoxAdmParola.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxAdmParola.Name = "txtBoxAdmParola";
            this.txtBoxAdmParola.PasswordChar = '*';
            this.txtBoxAdmParola.Size = new System.Drawing.Size(132, 22);
            this.txtBoxAdmParola.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(347, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Parola : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(316, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Kullanıcı Adı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADMİN GİRİŞ EKRANI";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 99);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnadmingeri
            // 
            this.btnadmingeri.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnadmingeri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnadmingeri.BackgroundImage")));
            this.btnadmingeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnadmingeri.ImageIndex = 0;
            this.btnadmingeri.Location = new System.Drawing.Point(528, 315);
            this.btnadmingeri.Name = "btnadmingeri";
            this.btnadmingeri.Size = new System.Drawing.Size(54, 50);
            this.btnadmingeri.TabIndex = 20;
            this.btnadmingeri.UseVisualStyleBackColor = false;
            this.btnadmingeri.Click += new System.EventHandler(this.btnadmingeri_Click);
            // 
            // AdminGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.btnadmingeri);
            this.Controls.Add(this.btnAdminGiris);
            this.Controls.Add(this.txtBoxAdmID);
            this.Controls.Add(this.txtBoxAdmParola);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yönetici Girişi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdminGiris;
        private System.Windows.Forms.TextBox txtBoxAdmID;
        private System.Windows.Forms.TextBox txtBoxAdmParola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnadmingeri;
    }
}