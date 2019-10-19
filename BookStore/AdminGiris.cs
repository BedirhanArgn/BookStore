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
using System.Collections;
namespace BookStore
{
    /// <summary>
    /// Admin Giris panelidir.Kullanici adi ve parola kontolu yapilir.
    /// </summary>
    public partial class AdminGiris : Form
    {
        SqlRead sqlr = new SqlRead();
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnAdminGiris_Click(object sender, EventArgs e)
        {
            
            Connection cn = Connection.getInstance();
            
            cn.SqlConnetion.Open();
            string komut = "SELECT * FROM MusteriTable WHERE  Musteri_KullaniciAdi = '" + txtBoxAdmID.Text + "' AND Musteri_Parola = '" + txtBoxAdmParola.Text+ "' AND Musteri_Isroot = 1";
            sqlr.Komut = komut;         
                if (sqlr.Oku().Equals(true))
                {
                    MessageBox.Show("Giris Başarili");
                Ekle frm = new Ekle();
                this.Opacity = 0;
                frm.Show();
                }
                else
                {
                    MessageBox.Show("Giris Başarısız");
                }         
            cn.SqlConnetion.Close();
        }

        private void btnadmingeri_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Opacity = 0;
            giris.Show();
        }
    }
}

