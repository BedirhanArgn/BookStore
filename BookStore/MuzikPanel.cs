using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace BookStore
{
    /// <summary>
    /// Kitaplarin panel seklinde gosterildigi kisimdir.
    /// </summary>
    class MuzikPanel : UrunPanel
    {

        public Label Sarkici;
        public Label Tur;
        public Label Fiyat;
        private Muzik muzik;
        public Button detay;
        public Button ekle;
        int nesnelerinsayisi = 0;
        /// <summary>
        /// Her kitap icin panel olusur.
        /// </summary>
        /// <param name="item">Her item icin ayri ayri muzikpanel calisir.</param>
        /// <param name="sayac2">X kordinatinin kontroludur</param>
        /// <param name="ykontrol">Y kordinatinin kontorludur.</param>
        public MuzikPanel(Muzik item, int sayac2, int ykontrol)
        {
            MusteriLog.kaydet("MuzikPanel");
            this.muzik = item;
            this.BackColor = Color.Transparent;
            this.Size = new Size(290, 200);
            this.BorderStyle = BorderStyle.FixedSingle;
            if (sayac2 % 4 == 0)
            {
                this.Location = new Point(0, ykontrol);

            }
            else
            {
                this.Location = new Point((sayac2 - 1) * 300, ykontrol - 200);
            }
            resimekle = new PictureBox();
            resimekle.Size = new Size(120, 140);
            resimekle.BackgroundImage = item.resim;
            resimekle.BackgroundImageLayout = ImageLayout.Zoom;
            this.Controls.Add(resimekle);


            isim = new Label();
            isim.AutoSize = true;
            isim.Text = item.isim;
            isim.TextAlign = ContentAlignment.MiddleLeft;
            isim.Font = new Font("Microsoft Sans Serif", (float)9.75, FontStyle.Italic);
            this.Controls.Add(isim);

            Sarkici = new Label();
            Sarkici.AutoSize = true;
            Sarkici.Text = item.Sarkici;
            Sarkici.Font = new Font("Microsoft Sans Serif", (float)8.25);
            this.Controls.Add(Sarkici);

            Tur = new Label();
            Tur.AutoSize = true;
            Tur.Text = item.kategori;
            Tur.ForeColor = Color.Black;
            Tur.Font = new Font("Microsoft Sans Serif", (float)8.50);
            this.Controls.Add(Tur);


            Fiyat = new Label();
            Fiyat.AutoSize = true;
            Fiyat.Text = item.ucret + " TL";
            Fiyat.Font = new Font("Microsoft Sans Serif", (float)11.25, FontStyle.Bold);
            this.Controls.Add(Fiyat);

            detay = new Button();
            detay.Text = "Detay";
            detay.Size = new Size(80, 30);
            detay.Font = new Font("Microsoft Sans Serif", (float)10.5, FontStyle.Bold);
            this.Controls.Add(detay);

            ekle = new Button();
            ekle.Text = "Sepete Ekle";
            ekle.Size = new Size(80, 53);
            ekle.Font = new Font("Microsoft Sans Serif", (float)10.5, FontStyle.Bold);
            this.Controls.Add(ekle);


            this.Controls[1].Location = new Point(125, 10);// Name label 
            this.Controls[1].BringToFront();

            this.Controls[2].Location = new Point(125, 50);// Singer label
            this.Controls[2].BringToFront();

            this.Controls[3].Location = new Point(125, 30);// Type label
            this.Controls[3].BringToFront();

            this.Controls[4].Location = new Point(125, 110);//  Price1 label
            this.Controls[4].BringToFront();

            this.Controls[0].Location = new Point(180, 100); //Fiyat

            this.Controls[5].Location = new Point(180, 150);

            this.Controls[6].Location = new Point(50, 140);
            ekle.Click += new EventHandler(ekle_Click);

            this.Controls[6].Location = new Point(50, 150);
            detay.Click += new EventHandler(detay_Click);

        }
        /// <summary>
        /// Tiklandiginda muzik detaylarini gosterir.
        /// </summary>
        private void detay_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Muzik detay");
            muzik.DetayGoster();
        }
        /// <summary>
        /// Muzik ekle butonuna tiklandiginda secilen muzigin alisveris sepetine eklendigi kisimdir.
        /// </summary>

        private void ekle_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Sepete ekle");
            SqlCommand kmt;
            SqlCommand kmt2;
            ArrayList veriler=new ArrayList();
            Connection cn=Connection.getInstance();
            nesnelerinsayisi++;
            if (muzik.urunsayisi > nesnelerinsayisi)
            {
                cn.SqlConnetion.Open();
                SatinalinacakNesneler nesne = new SatinalinacakNesneler();
                nesne.Urun = muzik;
                nesne.Sayisi = nesnelerinsayisi;
                AlisverisSayfa.sepet.urun.Add(nesne);
                int sayi = muzik.urunsayisi - 1;
                veriler.Add(muzik.urunID);
                veriler.Add(sayi);

                
                string komut = "UPDATE MuzikTable SET Muzik_Stok=@1 WHERE Muzik_ID=@0";
                kmt = new SqlCommand(komut,cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0",veriler[0]);
                kmt.Parameters.AddWithValue("1", veriler[1]);
                kmt.ExecuteNonQuery();
               
                String komut2="SELECT Muzik_Stok FROM MuzikTable WHERE Muzik_ID=@0";
                kmt2 = new SqlCommand(komut2, cn.SqlConnetion);
                kmt2.Parameters.AddWithValue("0", veriler[0]);
                SqlDataReader reader = kmt2.ExecuteReader();
                reader.Read();
                muzik.urunsayisi = (int)reader["Muzik_Stok"];
                cn.SqlConnetion.Close();
                KitapPanel.musteri.urunliste.Add(muzik);
            }
            else
            {
                MessageBox.Show("Ürün Alınamaz Stok Bitti...");

            }



        }
    }
}
