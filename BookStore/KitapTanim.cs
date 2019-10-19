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
    public partial class KitapTanim : Form
    {
        /// <summary>
        /// Kitaplarin detaylarinin gosterildigi kisimdir.
        /// </summary>
         Kitap kitap;
        public KitapTanim(Kitap kitap)
        {
            this.kitap = kitap;
            this.Text = kitap.isim;
            InitializeComponent();
            lblname.Text= kitap.isim;
            yazar.Text = kitap.Yazar;
            yayinevi.Text = kitap.Yayımcı;
            sayfasayisi.Text = kitap.Sayfa;
            kategori.Text = kitap.kategori;
            fiyat.Text = kitap.ucret.ToString();
            pictureboxkitap.Image = kitap.resim;
            isbn.Text = (kitap.Isbn).ToString();
           
        }

        private void KitapTanim_Load(object sender, EventArgs e)
        {

        }
    }
}
