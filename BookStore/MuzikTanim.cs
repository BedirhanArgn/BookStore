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
    /// Muzigin detaylarinin gosterildigi formdur.
    /// </summary>
    public partial class MuzikTanim : Form
    {
        Muzik muzik;
        public MuzikTanim(Muzik muzik)
        {
            this.muzik = muzik;
            this.Text = muzik.isim;
            InitializeComponent();
            lblname.Text = muzik.isim;
            lblsarkici.Text = muzik.Sarkici;
            lbltur.Text = muzik.kategori;
            lblucret.Text = muzik.ucret.ToString();
            pictureboxmuzik.Image = muzik.resim;
        }

        private void MuzikTanim_Load(object sender, EventArgs e)
        {

        }
    }
}
