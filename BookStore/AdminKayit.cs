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
    public partial class AdminKayit : Form
    {
        /// <summary>
        /// Admin kayit formudur.Textboxtan alinan degerler insert sorgusu ile sql'e yazdirilir.
        /// </summary>
        SqlCommand komut;
        SqlConnection conn;
        Connection cn = Connection.getInstance();
        public AdminKayit()
        {
            InitializeComponent();
        }

        private void btnKaydetAdmin_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            cn.SqlConnetion.Open();
            if (txtBoxAdminAd.Text != "" && txtBoxAdminKulAdi.Text != "" && txtBoxParola.Text != "" && txtBoxAdminEmail.Text != "" && mTxtBoxAdminTel.Text != "" && txtBoxAdminAdres.Text != "")
            {
                if (cn.SqlConnetion.State == ConnectionState.Open)
                {
                    string sorgu = ("INSERT INTO MusteriTable(Musteri_Isroot,Musteri_Ad,Musteri_Soyad,Musteri_KullaniciAdi,Musteri_Parola,Musteri_Email,Musteri_Telefon,Musteri_Adres) Values(1,'" + txtBoxAdminAd.Text + "','" +txtBoxAdminSoyad.Text+"','"+ txtBoxAdminKulAdi.Text + "','" + txtBoxParola.Text + "','" + txtBoxAdminEmail.Text + "','" + mTxtBoxAdminTel.Text + "','" + txtBoxAdminAdres.Text + "')");
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
                    MessageBox.Show("Hata");
                }

            }
            else
            {
                cn.SqlConnetion.Close();
                MessageBox.Show("Boş Alanlar Var");
            }

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Giris frm1 = new Giris();
            this.Opacity = 0;
            frm1.Show();
        }
    }
}

