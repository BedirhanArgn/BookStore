namespace BookStore
{
    partial class AlisverisSepetiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlisverisSepetiForm));
            this.pnlurun = new System.Windows.Forms.Panel();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsatinal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlurun
            // 
            this.pnlurun.AutoScroll = true;
            this.pnlurun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlurun.BackgroundImage")));
            this.pnlurun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlurun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlurun.Location = new System.Drawing.Point(58, 83);
            this.pnlurun.Name = "pnlurun";
            this.pnlurun.Size = new System.Drawing.Size(744, 409);
            this.pnlurun.TabIndex = 0;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.BackColor = System.Drawing.Color.Transparent;
            this.lblFiyat.Location = new System.Drawing.Point(724, 528);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(46, 17);
            this.lblFiyat.TabIndex = 0;
            this.lblFiyat.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(625, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toplam Fiyat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(756, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "TL";
            // 
            // btnsatinal
            // 
            this.btnsatinal.Location = new System.Drawing.Point(715, 565);
            this.btnsatinal.Name = "btnsatinal";
            this.btnsatinal.Size = new System.Drawing.Size(87, 39);
            this.btnsatinal.TabIndex = 3;
            this.btnsatinal.Text = "Satın Al";
            this.btnsatinal.UseVisualStyleBackColor = true;
            this.btnsatinal.Click += new System.EventHandler(this.btnsatinal_Click);
            // 
            // AlisverisSepetiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(916, 647);
            this.Controls.Add(this.btnsatinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFiyat);
            this.Controls.Add(this.pnlurun);
            this.Name = "AlisverisSepetiForm";
            this.Text = "Alışveriş Sepeti";
            this.Load += new System.EventHandler(this.AlisverisSepetiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlurun;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsatinal;
    }
}