using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    /// <summary>
    /// Musterilerin Profilinin Gosterildigi siniftir.
    /// </summary>
    public partial class MusteriBilgi : Form
    {
        public MusteriBilgi()
        {
            InitializeComponent();
        }
        private void MusteriBilgi_Load(object sender, EventArgs e)
        {
            Musteri kullanici;
            kullanici = Musteri.getInstance();
            label5.Text = kullanici.Adi ;
            label11.Text=kullanici.Soyadi;
            label6.Text = kullanici.Kullaniciadi;
            label7.Text = kullanici.Email;
            label8.Text = kullanici.Telefon;
            label9.Text = kullanici.Adres;
        }
        /// <summary>
        /// Alisveris Sayfasina geri doner.
        /// </summary>
        private void btnGeri_Click(object sender, EventArgs e)
        {
            AlisverisSayfa frm = new AlisverisSayfa();
            this.Opacity = 0;
            frm.Show();
        }
    }
}
