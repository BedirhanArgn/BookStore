using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace BookStore
{
    /// <summary>
    /// Müsterilerin kayit oldugu formdur.
    /// </summary>
    public partial class MusteriKayit : Form
    {
        SqlCommand komut;
        Connection cn = Connection.getInstance();
        public MusteriKayit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Butuna basildinda insert sorgusuyla textboxtaki verileri sql'e kayit edildigi yerdir. 
        /// </summary>
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            cn.SqlConnetion.Open();

            if (cn.SqlConnetion.State == ConnectionState.Open)
            {
                if (txtBoxAd.Text != "" && txtBoxMusteriKul.Text != "" && txtBoxParola.Text != "" && txtBoxMusteriEmail.Text != "" && mTxtBoxMusteriTel.Text != "" && txtBoxMusteriAdres.Text != "")
                {
                    string sorgu = ("INSERT INTO MusteriTable(Musteri_Isroot,Musteri_Ad,Musteri_Soyad,Musteri_KullaniciAdi,Musteri_Parola,Musteri_Email,Musteri_Telefon,Musteri_Adres) Values(0,'" + txtBoxAd.Text + "','" +txtboxMusteriSoyad.Text+"','"+ txtBoxMusteriKul.Text + "','" + txtBoxParola.Text + "','" + txtBoxMusteriEmail.Text + "','" + mTxtBoxMusteriTel.Text + "','" + txtBoxMusteriAdres.Text + "'  )");
                    komut.Connection = cn.SqlConnetion;
                    komut.CommandText = sorgu;
                    try
                    {
                        komut.ExecuteNonQuery();
                        cn.SqlConnetion.Close();
                        MessageBox.Show("KAYIT BAŞARILI");
                    }
                    catch
                    {
                        MessageBox.Show("KAYIT BAŞARISIZ");
                    }

                }
                else
                {
                    cn.SqlConnetion.Close();
                    MessageBox.Show("Bos Alanlar var");
                  

                }

            }
            else
            {
                MessageBox.Show("Hata");
            }

        }
        ///<summary>
        /// Giris Formuna geri doner
        ///</summary>
        private void btnKayıtGeri_Click(object sender, EventArgs e)
        {
            Giris frm1 = new Giris();
            this.Opacity = 0;
            frm1.Show();
        }

        private void txtboxMusteriSoyad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
