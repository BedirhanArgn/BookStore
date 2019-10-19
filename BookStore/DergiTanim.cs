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
    public partial class DergiTanim : Form
    {
        /// <summary>
        /// Secilen derginin detaylarini gosteren sinifir.
        /// </summary>
        Dergi dergi;
        public DergiTanim(Dergi dergi)
        {
            this.dergi = dergi;
            InitializeComponent();
            lblname.Text = dergi.isim;
            lbldergiissue.Text = dergi.sayi;
            lbldergikatagori.Text = dergi.kategori;
            lbldergifiyat.Text = dergi.ucret.ToString();
            pictureboxdergiresim.Image = dergi.resim;

        }

       
    }
}
