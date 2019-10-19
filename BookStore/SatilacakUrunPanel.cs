using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;
namespace BookStore
{
    public class SatilacakUrunPanel : Panel
    {   
       
        Label lblAd;
        Label lblFiyat;
        PictureBox pbResim;
        Button btnSil;
        SqlCommand kmt;
        Connection cn=Connection.getInstance();
        public SatinalinacakNesneler urun;
        /// <summary>
        /// Alisveris Sepeti icinde gosterilecek urunlerin panelleri olusur.
        /// </summary>
        /// <param name="_urun">Olusacak olan urunun paneli</param>
        /// <param name="Y">Y konumu</param>
        public SatilacakUrunPanel(SatinalinacakNesneler _urun, int Y) //Her seferinde olusacak paneller
        {
            this.urun = _urun;
            this.Size = new Size(480, 86);
            this.Location = new Point(0, 0 + Y);
            this.BorderStyle = BorderStyle.FixedSingle;

            lblAd = new Label();
            lblAd.AutoSize = false;
            lblAd.Size = new Size(200, 20);
            lblAd.Text = urun.Urun.isim;
            lblAd.BackColor = Color.Transparent;
            this.Controls.Add(lblAd);

            lblFiyat = new Label();
            lblFiyat.AutoSize = false;
            lblFiyat.Size = new Size(200, 20);
            lblFiyat.Text = urun.Urun.ucret + " TL";
            lblFiyat.Font = new Font("Microsoft Sans Serif", (float)10.25, FontStyle.Regular);
            lblFiyat.BackColor = Color.Transparent;
            this.Controls.Add(lblFiyat);

            pbResim = new PictureBox();
            pbResim.Image = urun.Urun.resim;
            pbResim.SizeMode = PictureBoxSizeMode.Zoom;
            pbResim.Size = new Size(60, 80);
            this.Controls.Add(pbResim);

            btnSil = new Button();
            btnSil.Text = "Sil";
            btnSil.TextAlign = ContentAlignment.MiddleRight;
            btnSil.Click += new EventHandler(btnSil_Click);
            this.Controls.Add(btnSil);

            this.Controls[0].Location = new Point(65, 25);
            this.Controls[0].BringToFront();
            this.Controls[1].Location = new Point(390, 27);
            this.Controls[1].BringToFront();
            this.Controls[2].Location = new Point(3, 3);
            this.Controls[2].BringToFront();
            this.Controls[3].Location = new Point(275, 25);
            this.Controls[3].BringToFront();

        }
        /// <summary>
        /// Panelin icindeki urunlerin silindigi yerdir.
        /// </summary>
        private void btnSil_Click(object sender, EventArgs e)
        {
            ArrayList veriler = new ArrayList();
            int urunid = urun.Urun.urunID;
            int urunsayisi2 = (urun.Urun.urunsayisi)+1; 
            urun.Urun.urunsayisi = urunsayisi2;
            veriler.Add(urunid);
            veriler.Add(urunsayisi2);
            if (urunid >= 1000 && urunid < 2000) 
            {
                string komut = "UPDATE KitapTable SET Kitap_StokSayisi=@1 WHERE Kitap_ID=@0";
                cn.SqlConnetion.Open();
                kmt = new SqlCommand(komut, cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0",urunid);
                kmt.Parameters.AddWithValue("1", urunsayisi2);
                kmt.ExecuteNonQuery();
                cn.SqlConnetion.Close();
                AlisverisSayfa.sepet.UrunSil(this.urun);
           }
            else if(urunid>=2000&&urunid<3000)
            {
                string komut = "UPDATE MuzikTable SET Muzik_Stok=@1 WHERE Muzik_ID=@0";
                cn.SqlConnetion.Open();
                kmt = new SqlCommand(komut, cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0", urunid);
                kmt.Parameters.AddWithValue("1", urunsayisi2);
                kmt.ExecuteNonQuery();
                cn.SqlConnetion.Close();

                AlisverisSayfa.sepet.UrunSil(this.urun);
            }
            else if (urunid >= 3000)
            {
                string komut = "UPDATE DergiTable SET Dergi_Stok=@1 WHERE Dergi_ID=@0";
                cn.SqlConnetion.Open();
                kmt = new SqlCommand(komut, cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0", urunid);
                kmt.Parameters.AddWithValue("1", urunsayisi2);
                kmt.ExecuteNonQuery();
                cn.SqlConnetion.Close();

                AlisverisSayfa.sepet.UrunSil(this.urun);
            }

        }
    }
}
