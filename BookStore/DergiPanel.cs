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
    class DergiPanel:UrunPanel
    {
        public Label Issue;
        public Label tur;
        public Label Ucret;
        public Dergi dergi;
        public Button detay;
        int nesnelerinsayisi = 0;
        public Button ekle;
        /// <summary>
        /// Her dergi icin panel olusur.
        /// </summary>
        /// <param name="item">Her item icin ayri ayri DergiPanel calisir.</param>
        /// <param name="sayac2">X kordinatinin kontroludur</param>
        /// <param name="ykontrol">Y kordinatinin kontorludur.</param>
        public DergiPanel(Dergi item,int sayac2,int ykontrol)
        {
            MusteriLog.kaydet("DergiPanel");
            dergi = item;
            this.BackColor = Color.Transparent;
            this.Size = new Size(290, 190);
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
            resimekle.Size = new Size(105, 135);
            resimekle.BackgroundImage = item.resim;
            resimekle.BackgroundImageLayout = ImageLayout.Zoom;

            this.Controls.Add(resimekle);
            isim = new Label();
            isim.AutoSize = true;
            isim.Text = item.isim;
            isim.TextAlign = ContentAlignment.MiddleLeft;
            isim.Font = new Font("Microsoft Sans Serif", (float)9.75, FontStyle.Italic);
            this.Controls.Add(isim);

            Issue = new Label();
            Issue.AutoSize = true;
            Issue.Text = item.sayi;
            Issue.Font = new Font("Microsoft Sans Serif", (float)8.25);
            this.Controls.Add(Issue);

            tur = new Label();
            tur.AutoSize = true;
            tur.Text = item.kategori;
            tur.Font = new Font("Microsoft Sans Serif", (float)10.25);
            //tur.ForeColor = Color.DarkGray;
            this.Controls.Add(tur);

            Ucret = new Label();
            Ucret.AutoSize = true;
            Ucret.Text = item.ucret + " TL";
            Ucret.Font = new Font("Microsoft Sans Serif", (float)11.25, FontStyle.Bold);
            this.Controls.Add(Ucret);

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

            this.Controls[1].Location = new Point(125, 10); 
            this.Controls[1].BringToFront();
            this.Controls[2].Location = new Point(125, 60);
            this.Controls[2].BringToFront();

            this.Controls[3].Location = new Point(125, 40);
            this.Controls[3].BringToFront();

            this.Controls[4].Location = new Point(125, 80);
            this.Controls[4].BringToFront();

            this.Controls[5].Location = new Point(180, 150);
            this.Controls[6].Location = new Point(50, 140);
            detay.Click += new EventHandler(detay_Click);
            ekle.Click += new EventHandler(ekle_Click);


        }
        /// <summary>
        /// Detay butonuna tiklandiginda dergi sinifinin detaygoster metodunu cagirir.
        /// </summary>
       
        private void detay_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("DergiDetay");
            dergi.DetayGoster();

        }
        /// <summary>
        /// Dergi ekle butonuna tiklandiginda derginin alisveris sepetine eklendigi kisimdir.
        /// </summary>
        private void ekle_Click(object sender,EventArgs e)
        {
            MusteriLog.kaydet("Sepete Ekle");
            SqlCommand kmt;
            SqlCommand kmt2;
            ArrayList veriler = new ArrayList();
            Connection cn = Connection.getInstance();
            nesnelerinsayisi++; ///Her ekle butonuna basildiginda urunsayisini kontrol eder.
            if (dergi.urunsayisi > nesnelerinsayisi) //Eger urun sayisindan fazla urun ekleye basildiysa uyarı verir.
            {
                cn.SqlConnetion.Open();
                SatinalinacakNesneler nesne = new SatinalinacakNesneler();
                nesne.Urun = dergi;
                nesne.Sayisi = nesnelerinsayisi;
                AlisverisSayfa.sepet.urun.Add(nesne);
                int sayi = dergi.urunsayisi - 1;
                veriler.Add(dergi.urunID);
                veriler.Add(sayi);

               ///Dergi sayisini database kisminda urunId kullanarak update eder.
                string komut = "UPDATE DergiTable SET Dergi_Stok=@1 WHERE Dergi_ID=@0";
                kmt = new SqlCommand(komut, cn.SqlConnetion);
                kmt.Parameters.AddWithValue("0", veriler[0]);
                kmt.Parameters.AddWithValue("1", veriler[1]);
                kmt.ExecuteNonQuery();
                ///Select sorgusuyla dergi stogunu database kismindan ceker.
                String komut2 = "SELECT Dergi_Stok FROM DergiTable WHERE Dergi_ID=@0";
                kmt2 = new SqlCommand(komut2, cn.SqlConnetion);
                kmt2.Parameters.AddWithValue("0", veriler[0]);
                SqlDataReader reader = kmt2.ExecuteReader();
                reader.Read();
                dergi.urunsayisi = (int)reader["Dergi_Stok"];
                cn.SqlConnetion.Close();               
            }
            else
            {
                MessageBox.Show("Ürün Alınamaz Stok Bitti...");

            }











        }


    }
}
