using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace BookStore
{
    /// <summary>
    /// Uygulamamizin bu bolumunde kullaniciya alisveris yapmasi icin arayuz saglanir.
    /// </summary>
    public partial class AlisverisSayfa : Form
    {        
        Musteri kullanici;   
        List<Urun> kitapliste;
        List<Urun> muzikliste;
        List<Urun> dergiliste;
        List<Urun> SuankiUrunliste;
        SqlRead sq = new SqlRead();
        PanelUret panelcreator;
        public static AlisverisSepeti sepet;
        /// <summary>
        /// kullanici ve alisveris sepeti nesneleri olusturulur.
        /// </summary>
        public AlisverisSayfa()
        {
            InitializeComponent();
            SuankiUrunliste = new List<Urun>();
            kullanici = Musteri.getInstance();
            sepet = new AlisverisSepeti();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.HorizontalScroll.Enabled = true;
            panel2.VerticalScroll.Enabled = true;
        }
       /// <summary>
       /// Urunler sqlread class'indan cekilip ayri ayri listelere konur.
       /// </summary>
      
        private void AlisverisSayafa_Load(object sender, EventArgs e)
        {
           
            panel2.HorizontalScroll.Enabled = true;
            panel2.VerticalScroll.Enabled = true;
            panelcreator = new PanelUret();
            Connection cn = Connection.getInstance();
            kitapliste = sq.KitapYukle();
            dergiliste = sq.DergiYukle();
            muzikliste = sq.MuzikYukle();
         }
        /// <summary>
        /// Suankiurunlistesine kitaplistesindeki urunler aktarilir ve Panel uret sinifinin panel olustur metodu cagirilarak kitappanel olusumu saglanir.
        /// </summary>
       
        private void btnKitap_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Kitap Göster");
            panel2.Controls.Clear();
            SuankiUrunliste.Clear();
            int sayac2 = 0;
            int kontrol = 0;
            int ykontrol = 0;
            foreach (var item in (List<Urun>)kitapliste)
            {

                SuankiUrunliste.Add(item);
                sayac2++;

                if (kontrol % 4 == 0)
                {
                    sayac2 = 1;
                    ykontrol += 200;
                }
                UrunPanel pnl = panelcreator.PanelOlustur(item, sayac2, ykontrol);
                panel2.Controls.Add(pnl);
                kontrol++;
            }
        }
        /// <summary>
        /// Suankiurunlistesine muziklistesindeki urunler aktarilir ve Panel uret sinifinin panel olustur metodu cagirilarak muzikpanel olusumu saglanir.
        /// </summary>
        private void btnCD_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("CD Göster");

            panel2.Controls.Clear();
            SuankiUrunliste.Clear();
            int kontrol = 0;
            int ykontrol = 0;
            int sayac2 = 0;
            foreach (var item in (List<Urun>)muzikliste)
            {

                SuankiUrunliste.Add(item);
                sayac2++;

                if (kontrol % 4 == 0)
                {
                    sayac2 = 1;
                    ykontrol += 200;
                }
                UrunPanel pnl = panelcreator.PanelOlustur(item, sayac2, ykontrol);

                panel2.Controls.Add(pnl);
                kontrol++;
            }

        }
        /// <summary>
        /// Suankiurunlistesine dergilistesindeki urunler aktarilir ve Panel uret sinifinin panel olustur metodu cagirilarak dergipanel olusumu saglanir.
        /// </summary>
        private void btnDergi_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Dergi Göster");

            panel2.Controls.Clear();
            SuankiUrunliste.Clear();
            int kontrol = 0;
            int ykontrol = 0;
            int sayac2 = 0;
            foreach (var item in (List<Urun>)dergiliste)
            {

                SuankiUrunliste.Add(item);
                sayac2++;

                if (kontrol % 4 == 0)
                {
                    sayac2 = 1;
                    ykontrol += 200;
                }
                UrunPanel pnl = panelcreator.PanelOlustur(item, sayac2, ykontrol);

                panel2.Controls.Add(pnl);
                kontrol++;
            }
        }
        /// <summary>
        /// Musterinin profilini gosterir.
        /// </summary>
       
        private void btnProfil_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Profil");
            MusteriBilgi musteriBilgi = new MusteriBilgi();           
            musteriBilgi.Show();
           
        }
        /// <summary>
        /// Alisveris Sepetini acar.
        /// </summary>
       
        private void button2_Click(object sender, EventArgs e)
        {
            MusteriLog.kaydet("Alişveriş Sepeti");

            sepet.urungoster();
           if(sepet.urun.Count==0)
            {
                MessageBox.Show("Sepetiniz Boş","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Cikis yapar.
        /// </summary>
     
        private void btncikisyap_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(0);

            }
            catch
            {
                Console.WriteLine("Sorun");
            }
        }
    }
}
