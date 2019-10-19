using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BookStore
{
    /// <summary>
    /// Musteri girisinin yapildigi yerdir.
    /// </summary>
    public partial class MusteriGiris : Form
    {
        SqlRead sqlr=new SqlRead();
        public MusteriGiris()
        {
            InitializeComponent();
        }
        /// <summary>
        ///sql sorgusu ile textboxa girilen kullanici adi ve parolayı kontrol eder. 
        /// </summary>
      
        private void btnMusteriGrs_Click(object sender, EventArgs e)
        {
            string komut = "SELECT * FROM MusteriTable WHERE Musteri_KullaniciAdi = '" + txtBoxKulAdi.Text + "' AND Musteri_Parola = '" + txtBoxParola.Text + "'"; ;
         
                sqlr.Komut = komut;
                if (sqlr.Oku().Equals(true))
                {
                    MusteriLog.kaydet("Giris");
                    MessageBox.Show("Giris Başarili");
                    AlisverisSayfa f9 = new AlisverisSayfa();
                    this.Opacity = 0;
                    f9.Show();
                }
                else
                {
                    MessageBox.Show("Giris Başarısız");
                }
            }
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btngirisgeri_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Opacity = 0;
            giris.Show();
        }
    }
}
