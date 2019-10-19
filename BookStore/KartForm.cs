using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using BookStore;

namespace KartFormu
{
    /// <summary>
    /// Alisverisin tamamlanmasi icin kullanici bilgilerinin alindigi kisimdir.
    /// </summary>
    public partial class KartForm : Form
    {
        public KartForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (rbKart.Checked == false)
                panel1.Visible = true;
        }

        private void rbNakit_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rbKart_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rbNakit_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbNakit.Checked == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblucret.Text = AlisverisSepetiForm.toplamfiyat.ToString();
        }

        /// <summary>
        ///Butuna tiklandiginda alisverisi tamamlar ve e posta gonderir.
        /// </summary>

        private void btnalisveris_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtadsoyad.Text == "" || txtemail.Text == "" || mTxtBoxTel.Text == "" || txtadres.Text == "")
                {
                    MessageBox.Show("Boş Alanlar Var","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                else
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.yandex.com");

                    mail.From = new MailAddress("evikitap@yandex.com");
                    mail.To.Add(txtemail.Text);
                    mail.Subject = "Satın Alma Başarılı";
                    mail.Body = "Bizi tercih ettiginiz icin tesekkur ederiz.";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("evikitap", "bafgku98");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    MessageBox.Show("Siparişiniz alınmıştır.En kısa sürede tarafınıza gönderilecektir.Bizi tercih ettiğiniz için teşekkür ederiz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
