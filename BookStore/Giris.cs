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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Kullanici adi ve parola sayfasinin acildigi yerdir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdminGiris_Click(object sender, EventArgs e)
        {
            AdminGiris f3 = new AdminGiris();
            this.Opacity = 0;
            f3.Show();

        }
        /// <summary>
        ///Admin kayit sayfasinin acildigi yerdir. 
        /// </summary>
        
        private void btnAdminKayit_Click(object sender, EventArgs e)
        {
            AdminKayit f5 = new AdminKayit();
            this.Opacity = 0;
            f5.Show();
        }
        /// <summary>
        /// Musteri giris sayfasinin acildigi fonksiyondur.
        /// </summary>
        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            MusteriGiris f2 = new MusteriGiris();
            this.Opacity = 0;
            f2.Show();
        }
        /// <summary>
        /// Musteri kayit formunun acildigi fonksiyondur.
        /// </summary>
        private void btnMusteriKayit_Click(object sender, EventArgs e)
        {
            MusteriKayit f4 = new MusteriKayit();
            this.Opacity = 0;
            f4.Show();
        }
        
    }
}
