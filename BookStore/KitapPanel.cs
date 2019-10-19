using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace BookStore
{
    /// <summary>
    /// Kitaplarin panel seklinde gosterildigi kisimdir.
    /// </summary>
    class KitapPanel:UrunPanel
    {
        public Label Yazar;
        public Label Yayimci;
        public Label Fiyat;        
        public Kitap nesne;
        public Button detay;
        public Button ekle;
        public static Musteri musteri = Musteri.getInstance();
        int nesnelerinsayisi = 0;
        /// <summary>
        /// Her kitap icin panel olusur.
        /// </summary>
        /// <param name="item">Her item icin ayri ayri KitapPanel calisir.</param>
        /// <param name="sayac2">X kordinatinin kontroludur</param>
        /// <param name="ykontrol">Y kordinatinin kontorludur.</param>
        public KitapPanel(Kitap item,int sayac2,int ykontrol)
        {
            MusteriLog.kaydet("KitapPanel");
            nesne= item;
            this.BackColor = Color.Transparent;
            this.Size = new Size(290, 190);
            this.BorderStyle = BorderStyle.FixedSingle;
       
            if(sayac2%4==0)
            {
                this.Location = new Point(0,ykontrol);
                
            }
            else
            {
                this.Location = new Point((sayac2-1)*300 ,ykontrol-200);  
            }          
            resimekle = new PictureBox();
            resimekle.Size = new Size(105,135 );
            resimekle.BackgroundImage = item.resim;
            resimekle.BackgroundImageLayout = ImageLayout.Zoom;
            this.Controls.Add(resimekle);

            isim = new Label();
            isim.AutoSize = true;
            isim.Text = item.isim;
            isim.TextAlign = ContentAlignment.MiddleLeft;
            isim.Font = new Font("Microsoft Sans Serif", (float)9.75, FontStyle.Italic);
            this.Controls.Add(isim);

            Yazar = new Label();
            Yazar.AutoSize = true;
            Yazar.Text = item.Yazar;
            Yazar.Font = new Font("Microsoft Sans Serif", (float)8.25);
            this.Controls.Add(Yazar);

            Yayimci = new Label();
            Yayimci.AutoSize = true;
            Yayimci.Text = item.Yayımcı;
            Yayimci.Font = new Font("Microsoft Sans Serif", (float)8.25);
            Yayimci.ForeColor = Color.Black;
            this.Controls.Add(Yayimci);

            Fiyat = new Label();
            Fiyat.AutoSize = true;
            Fiyat.Text = item.ucret + " TL";
            Fiyat.Font = new Font("Microsoft Sans Serif", (float)11.25, FontStyle.Bold);
            this.Controls.Add(Fiyat);

            detay = new Button();
            detay.Text = "Detay";
            detay.Font = new Font("Microsoft Sans Serif", (float)10.5, FontStyle.Bold);
            detay.Size = new Size(80, 30);
            this.Controls.Add(detay);

            ekle = new Button();
            ekle.Text = "Sepete Ekle";
            ekle.Font = new Font("Microsoft Sans Serif", (float)10.5, FontStyle.Bold);
            ekle.Size = new Size(80, 50);
            this.Controls.Add(ekle);
          

            this.Controls[0].Location = new Point(0, 0); //Resim
            this.Controls[1].Location = new Point(125, 30 );// Name label 
            this.Controls[1].BringToFront();

            this.Controls[2].Location = new Point(125, 60);// Yazar label
            this.Controls[2].BringToFront();

            this.Controls[3].Location = new Point(125, 90 );// Tur 
            this.Controls[3].BringToFront();      
            this.Controls[4].Location = new Point(150, 120);   //Fiyat
            this.Controls[4].BringToFront();
            this.Controls[5].Location = new Point(180, 150);
            this.Controls[6].Location = new Point(50, 140);
            detay.Click += new EventHandler(detay_Click);
            ekle.Click += new EventHandler(ekle_Click);
        }
        /// <summary>
        /// Tiklandiginda kitap detaylarini gosterir.
        /// </summary>
        private void detay_Click(object sender,EventArgs e)
        {
            MusteriLog.kaydet("Kitap Detay");
            nesne.DetayGoster();            

        }
        /// <summary>
        /// Kitap ekle butonuna tiklandiginda kitabin alisveris sepetine eklendigi kisimdir.
        /// </summary>
        private void ekle_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Sepete Ekle");
            SqlCommand kmt;
            SqlCommand kmt2;
            ArrayList veriler = new ArrayList();
            Connection cn = Connection.getInstance();
            nesnelerinsayisi++;
            if (nesne.urunsayisi > nesnelerinsayisi)
            {
                cn.SqlConnetion.Open();
                SatinalinacakNesneler kitap = new SatinalinacakNesneler();
                kitap.Urun = nesne;
                kitap.Sayisi = nesnelerinsayisi;
                AlisverisSayfa.sepet.urun.Add(kitap);
                int sayi = nesne.urunsayisi - 1;
                veriler.Add(nesne.urunID);
                veriler.Add(sayi);


                string komut = "UPDATE KitapTable SET Kitap_StokSayisi=@1 WHERE Kitap_ID=@0";
                kmt = new SqlCommand(komut, cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0", veriler[0]);
                kmt.Parameters.AddWithValue("1", veriler[1]);
                kmt.ExecuteNonQuery();

                String komut2 = "SELECT Kitap_StokSayisi FROM KitapTable WHERE Kitap_ID=@0";
                kmt2 = new SqlCommand(komut2, cn.SqlConnetion);
                kmt2.Parameters.AddWithValue("0", veriler[0]);
                SqlDataReader reader = kmt2.ExecuteReader();
                reader.Read();
                nesne.urunsayisi = (int)reader["Kitap_StokSayisi"];
                cn.SqlConnetion.Close();

                musteri.urunliste.Add(nesne);


            }
            else
            {
                MessageBox.Show("Ürün Alınamaz Stok Bitti...");

            }



        }





    }


}
