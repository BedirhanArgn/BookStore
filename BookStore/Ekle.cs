using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace BookStore
{
    /// <summary>
    /// Adminin Kitap Dergi Muzik ekledigi kisimdir.Ayni zamanda kullanici da eklenebilir.
    /// </summary>
    public partial class Ekle : Form
    {
        String[] KitapDizi;
        String[] DergiDizi;
        String[] Cddizi;
        DataSet dataset = new DataSet();
        SqlDataAdapter adapter;
        SqlCommand komut;
        Boolean durum;
        Connection cn = Connection.getInstance();
        string resimadi;
        public Ekle()
        {
            InitializeComponent();
        }
        public bool boslukkontrol(String[] dizi)
        {
            foreach (var item in dizi)
            {
                if (item == "")
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Textboxtakilerin bir string dizisinde toplandigi yerdir.
        /// </summary>
        public void doldur()
        {
            KitapDizi = new String[] { txtBoxKitapAdi.Text, txtBoxYazar.Text, txtBoxIsbn.Text, txtBoxSayfaSayisi.Text, txtBoxStok.Text, cmbboxTuru.Text, txtBoxYayinevi.Text, txtBoxUcreti.Text, resimadi };
            DergiDizi = new String[] { txtBoxDergiAdi.Text, txtBoxDergiYayinci.Text, cmbBoxDergiTur.Text, txtBoxDergiUcret.Text, txtBoxDergiStok.Text, resimadi, txtBoxSayi.Text, };
            Cddizi = new String[] { txtBoxCdAdi.Text, txtBoxSanatci.Text, cmbBoxCdTuru.Text, txtBoxCdYapimci.Text, txtBoxCdStok.Text, txtBoxCdUcreti.Text, resimadi };
        }
        /// <summary>
        /// Butona basildiginda eklenecek kitabin sql'e kayit edildigi yerdir.
        /// </summary>

        private void btnKitapKaydet_Click(object sender, EventArgs e)
        {
            string kayitstring;
            string[] veriler;
            doldur();
            if (!boslukkontrol(KitapDizi))
            {
                MessageBox.Show("Boş Alanalar Var.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                kayitstring = "INSERT INTO KitapTable (Kitap_Adi,Kitap_Yazari,Kitap_ISBN,Kitap_SayfaSayisi,Kitap_StokSayisi, Kitap_Turu, Kitap_Yayinevi, Kitap_Ucreti,Kitap_ResimIsmi) VALUES (@0, @1, @2, @3,@4, @5, @6,@7,@8)";
                veriler = new string[KitapDizi.Length];
                for (int i = 0; i < KitapDizi.Length; i++)
                {
                    veriler[i] = KitapDizi[i];
                }
                MessageBox.Show("Kayit Başarılı");

            }
            SqlRead read = new SqlRead();
            read.Yaz(kayitstring, veriler);
            kitapyukle();

        }
        private void pictureBoxFotograf_Click(object sender, EventArgs e)
        {
            fotografismioku();
        }
        /// <summary>
        /// Eklenecek olan urunun bir openfiledialog tarafindan acilarak picturebox'a aktarilip kaydedildigi kisimdir.
        /// </summary>
        public void fotografismioku()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "JPEG (*.jpg; *jpeg; *jpe)|*.jpg; *jpeg; *jpe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            foreach (string s in openFileDialog1.FileNames)
                            {
                                pictureBoxFotograf.ImageLocation = s;
                                pictureBoxCdfoto.ImageLocation = s;
                                pictureBoxDergiFotograf.ImageLocation = s;
                                string resimyolu = pictureBoxFotograf.ImageLocation;
                                resimyolu = pictureBoxCdfoto.ImageLocation;
                                resimyolu = pictureBoxDergiFotograf.ImageLocation;
                                string[] bolunen = resimyolu.Split('\\');
                                resimadi = bolunen[bolunen.Length - 1];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: Dosya okunamadı!" + ex.Message);
                }

            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Eklenen Muzigin sql'e yazdirildigi yerdir.
        /// </summary>

        private void btnCDKaydet_Click(object sender, EventArgs e)
        {
            string kayitstring;
            string[] veriler;
            doldur();
            if (!boslukkontrol(Cddizi))
            {
                MessageBox.Show("Boş Alanalar Var.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                kayitstring = "INSERT INTO MuzikTable (Muzik_CDAd,Muzik_Sanatci,Muzik_Turu,Muzik_Yapimci,Muzik_Stok, Muzik_Ucreti, Muzik_Fotograf) VALUES (@0, @1, @2, @3,@4, @5, @6)";
                veriler = new string[Cddizi.Length];
                for (int i = 0; i < Cddizi.Length; i++)
                {
                    veriler[i] = Cddizi[i];
                }
                MessageBox.Show("Kayıt Başarılı");
            }
            SqlRead read = new SqlRead();
            read.Yaz(kayitstring, veriler);
            muzikyukle();
        }
        /// <summary>
        /// Ekle Formu acildiginda ekrana ekli olan urunlerin ve kisilerin yazdirildigi fonksiyonlarin cagrildigi yerdir.
        /// </summary>     
        private void EkleKitapMuzik_Load(object sender, EventArgs e)
        {
            insanyukle();
            kitapyukle();
            dergiyukle();
            muzikyukle();
        }
        /// <summary>
        /// Sql sorgusu ile kayitli olan kisilerin ekrana yazdirildigi bolumdur.
        /// </summary>
        public void insanyukle()
        {
            komut = new SqlCommand();
            komut.Connection = cn.SqlConnetion;
            komut.CommandText = "SELECT * FROM MusteriTable";
            adapter = new SqlDataAdapter(komut);

            cn.SqlConnetion.Open();
            DataTable dtRecord = new DataTable();
            adapter.Fill(dtRecord);
            datagridmusteri.DataSource = dtRecord;
            cn.SqlConnetion.Close();
        }
        /// <summary>
        /// Sql sorgusu ile kayitli olan kitaplarin ekrana yazdirildigi bolumdur.
        /// </summary>
        public void kitapyukle()
        {
            komut = new SqlCommand();
            komut.Connection = cn.SqlConnetion;
            komut.CommandText = "SELECT * FROM KitapTable";
            adapter = new SqlDataAdapter(komut);

            cn.SqlConnetion.Open();
            DataTable dtkitap = new DataTable();
            adapter.Fill(dtkitap);
            datagridkitap.DataSource = dtkitap;
            cn.SqlConnetion.Close();
        }
        /// <summary>
        /// Sql sorgusu ile kayitli olan dergilerin ekrana yazdirildigi bolumdur.
        /// </summary>
        public void dergiyukle()
        {
            komut = new SqlCommand();
            komut.Connection = cn.SqlConnetion;
            komut.CommandText = "SELECT * FROM DergiTable";
            adapter = new SqlDataAdapter(komut);
            cn.SqlConnetion.Open();
            DataTable dtdergi = new DataTable();
            adapter.Fill(dtdergi);
            datagriddergi.DataSource = dtdergi;
            cn.SqlConnetion.Close();
        }
        /// <summary>
        /// Sql sorgusu ile kayitli olan muziklerin ekrana yazdirildigi bolumdur.
        /// </summary>
        public void muzikyukle()
        {
            komut = new SqlCommand();
            komut.Connection = cn.SqlConnetion;
            komut.CommandText = "SELECT * FROM MuzikTable";
            adapter = new SqlDataAdapter(komut);
            DataTable dtmuzik = new DataTable();
            cn.SqlConnetion.Open();

            adapter.Fill(dtmuzik);
            datagridcd.DataSource = dtmuzik;
            cn.SqlConnetion.Close();
        }
        /// <summary>
        /// fotograf isminin alindigi fonksiyonun cagrildigi yerdir. 
        /// </summary>

        private void pictureBoxCdfoto_Click(object sender, EventArgs e)
        {
            fotografismioku();
        }
        /// <summary>
        /// Derginin sql'e kaydedildigi yerdir.
        /// </summary>

        private void btnDergiKaydet_Click(object sender, EventArgs e)
        {
            string kayitstring;
            string[] veriler;
            doldur();
            if (!boslukkontrol(DergiDizi))
            {
                MessageBox.Show("Boş Alanalar Var.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                kayitstring = "INSERT INTO DergiTable (Dergi_Ad,Dergi_Yayinci,Dergi_Turu,Dergi_Ucreti,Dergi_Stok, Dergi_Fotograf,Dergi_Sayi) VALUES (@0, @1, @2, @3,@4, @5,@6)";
                veriler = new string[DergiDizi.Length];
                for (int i = 0; i < DergiDizi.Length; i++)
                {
                    veriler[i] = DergiDizi[i];
                }
                MessageBox.Show("Kayit Başarılı");

            }
            SqlRead read = new SqlRead();
            read.Yaz(kayitstring, veriler);
            dergiyukle();
        }


        private void pictureBoxDergiFotograf_Click(object sender, EventArgs e)
        {
            fotografismioku();

        }

        private void datagridmusteri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Musterinin sql'e kaydedildigi yerdir.
        /// </summary>
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string sorgu;
            komut = new SqlCommand();
            cn.SqlConnetion.Open();
            if (cn.SqlConnetion.State == ConnectionState.Open)
            {
                if (durum == true)
                {
                    sorgu = ("INSERT INTO MusteriTable(Musteri_Isroot,Musteri_Ad,Musteri_Soyad,Musteri_KullaniciAdi,Musteri_Parola,Musteri_Email,Musteri_Telefon,Musteri_Adres) Values(1,'" + txtboxmusteriadi.Text + "','" + txtmusterisoyad.Text+"','"+ txtboxmusterikullaniciadi.Text + "','" + txtboxmusteripassword.Text + "','" + txtboxemail.Text + "','" + txtboxmusteritelefon.Text + "','" + txtboxmusteriadres.Text + "')");

                }
                else
                {
                    sorgu = ("INSERT INTO MusteriTable(Musteri_Isroot,Musteri_Ad,Musteri_Soyad,Musteri_KullaniciAdi,Musteri_Parola,Musteri_Email,Musteri_Telefon,Musteri_Adres) Values(0,'" + txtboxmusteriadi.Text + "','" + txtmusterisoyad.Text + "','" + txtboxmusterikullaniciadi.Text + "','" + txtboxmusteripassword.Text + "','" + txtboxemail.Text + "','" + txtboxmusteritelefon.Text + "','" + txtboxmusteriadres.Text + "')");

                }
                komut.Connection = cn.SqlConnetion;
                komut.CommandText = sorgu;
                try
                {
                    komut.ExecuteNonQuery();
                    cn.SqlConnetion.Close();
                    MessageBox.Show("KAYIT BAŞARILI");
                    insanyukle();

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
        private void chcyonetici_CheckedChanged(object sender, EventArgs e)
        {

            if (chcyonetici.Checked == true)
            {
                durum = true;
            }
            else
            {
                durum = false;
            }

        }
        /// <summary>
        /// Datagridview'deki bilgiler sutunlar secildiginde textboxlara bilgiler dolar.
        /// </summary>
        private void datagridkitap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxKitapAdi.Text = datagridkitap.CurrentRow.Cells[1].Value.ToString();
                txtBoxYazar.Text = datagridkitap.CurrentRow.Cells[2].Value.ToString();
                txtBoxIsbn.Text = datagridkitap.CurrentRow.Cells[3].Value.ToString();
                txtBoxSayfaSayisi.Text = datagridkitap.CurrentRow.Cells[4].Value.ToString();
                txtBoxStok.Text = datagridkitap.CurrentRow.Cells[5].Value.ToString();
                cmbboxTuru.Text = datagridkitap.CurrentRow.Cells[6].Value.ToString();
                txtBoxYayinevi.Text = datagridkitap.CurrentRow.Cells[7].Value.ToString();
                txtBoxUcreti.Text = datagridkitap.CurrentRow.Cells[8].Value.ToString();
                resimadi = datagridkitap.CurrentRow.Cells[9].Value.ToString();
                pictureBoxFotograf.Image = Image.FromFile(Application.StartupPath + @"\Resources\KitapResimleri\" + resimadi);
            }
            catch
            {
                MessageBox.Show("Veri Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        /// <summary>
        /// Verileri textboxlardan alarak update sorgusu ile databaseye iletir. 
        /// </summary>
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string kayit = "UPDATE KitapTable SET Kitap_Adi=@Kitap_Adi,Kitap_Yazari=@Kitap_Yazari,Kitap_ISBN=@Kitap_ISBN,Kitap_SayfaSayisi=@Kitap_SayfaSayisi,Kitap_StokSayisi=@Kitap_StokSayisi,Kitap_Turu=@Kitap_Turu,Kitap_Yayinevi = @Kitap_Yayinevi,Kitap_Ucreti=@Kitap_Ucreti,Kitap_ResimIsmi=@Kitap_ResimIsmi where Kitap_ID=@Kitap_ID";
            cn.SqlConnetion.Open();
            SqlCommand komut = new SqlCommand(kayit, cn.SqlConnetion);
            komut.Parameters.AddWithValue("Kitap_ID", Convert.ToInt32(datagridkitap.CurrentRow.Cells[0].Value));
            komut.Parameters.AddWithValue("Kitap_Adi", txtBoxKitapAdi.Text);
            komut.Parameters.AddWithValue("Kitap_Yazari", txtBoxYazar.Text);
            komut.Parameters.AddWithValue("Kitap_ISBN", txtBoxIsbn.Text);
            komut.Parameters.AddWithValue("Kitap_SayfaSayisi", (txtBoxSayfaSayisi.Text));
            komut.Parameters.AddWithValue("Kitap_StokSayisi", Convert.ToInt32(txtBoxStok.Text));
            komut.Parameters.AddWithValue("Kitap_Turu", cmbboxTuru.Text);
            komut.Parameters.AddWithValue("Kitap_Yayinevi", txtBoxYayinevi.Text);

            komut.Parameters.AddWithValue("Kitap_Ucreti", txtBoxUcreti.Text);
            if (pictureBoxFotograf.ImageLocation == null)
            {
                komut.Parameters.AddWithValue("Kitap_ResimIsmi", datagridkitap.CurrentRow.Cells[9].Value.ToString());
            }
            else
            {
                komut.Parameters.AddWithValue("Kitap_ResimIsmi", pictureBoxFotograf.ImageLocation.Substring(pictureBoxFotograf.ImageLocation.LastIndexOf("\\") + 1));

            }

            komut.ExecuteNonQuery();
            if (komut.Connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            cn.SqlConnetion.Close();
            kitapyukle();



        }

        private void txtBoxUcreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }

        }
        /// <summary>
        /// Verileri textboxlardan alarak update sorgusu ile databaseye iletir. 
        /// </summary>
        private void btncdguncelle_Click(object sender, EventArgs e)
        {
            string kayit = "UPDATE MuzikTable SET Muzik_CDAd=@Muzik_CDAd,Muzik_Sanatci=@Muzik_Sanatci,Muzik_Turu=@Muzik_Turu,Muzik_Yapimci=@Muzik_Yapimci,Muzik_Stok=@Muzik_Stok,Muzik_Ucreti = @Muzik_Ucreti,Muzik_Fotograf=@Muzik_Fotograf where Muzik_ID=@Muzik_ID";
            cn.SqlConnetion.Open();
            SqlCommand komut = new SqlCommand(kayit, cn.SqlConnetion);
            komut.Parameters.AddWithValue("Muzik_ID", Convert.ToInt32(datagridcd.CurrentRow.Cells[0].Value));
            komut.Parameters.AddWithValue("Muzik_CDAd", txtBoxCdAdi.Text);
            komut.Parameters.AddWithValue("Muzik_Sanatci", txtBoxSanatci.Text);
            komut.Parameters.AddWithValue("Muzik_Turu", cmbBoxCdTuru.Text);
            komut.Parameters.AddWithValue("Muzik_Yapimci", (txtBoxCdYapimci.Text));
            komut.Parameters.AddWithValue("Muzik_Stok", Convert.ToInt32(txtBoxCdStok.Text));
            komut.Parameters.AddWithValue("Muzik_Ucreti", txtBoxCdUcreti.Text);

            if (pictureBoxCdfoto.ImageLocation == null)
            {
                komut.Parameters.AddWithValue("Muzik_Fotograf", datagridcd.CurrentRow.Cells[7].Value.ToString());
            }
            else
            {
                komut.Parameters.AddWithValue("Muzik_Fotograf", pictureBoxCdfoto.ImageLocation.Substring(pictureBoxCdfoto.ImageLocation.LastIndexOf("\\") + 1));

            }
            komut.ExecuteNonQuery();
            if (komut.Connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            cn.SqlConnetion.Close();
            muzikyukle();
        }
        /// <summary>
        /// Datagridview'deki bilgiler sutunlar secildiginde textboxlara bilgiler dolar.
        /// </summary>
        private void datagridcd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxCdAdi.Text = datagridcd.CurrentRow.Cells[1].Value.ToString();
                txtBoxSanatci.Text = datagridcd.CurrentRow.Cells[2].Value.ToString();
                cmbBoxCdTuru.Text = datagridcd.CurrentRow.Cells[3].Value.ToString();
                txtBoxCdYapimci.Text = datagridcd.CurrentRow.Cells[4].Value.ToString();
                txtBoxCdStok.Text = datagridcd.CurrentRow.Cells[5].Value.ToString();
                txtBoxCdUcreti.Text = datagridcd.CurrentRow.Cells[6].Value.ToString();
                resimadi = datagridcd.CurrentRow.Cells[7].Value.ToString();
                pictureBoxCdfoto.Image = Image.FromFile(Application.StartupPath + @"\Resources\MuzikResimleri\" + resimadi);
            }
            catch
            {
                MessageBox.Show("Veri Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// Verileri textboxlardan alarak update sorgusu ile databaseye iletir. 
        /// </summary>
        private void btndergiguncelle_Click(object sender, EventArgs e)
        {
            string kayit = "UPDATE DergiTable SET Dergi_Ad=@Dergi_Ad,Dergi_Yayinci=@Dergi_Yayinci,Dergi_Turu=@Dergi_Turu,Dergi_Ucreti=@Dergi_Ucreti,Dergi_Stok=@Dergi_Stok,Dergi_Fotograf = @Dergi_Fotograf,Dergi_Sayi=@Dergi_Sayi where Dergi_ID=@Dergi_ID";
            cn.SqlConnetion.Open();
            SqlCommand komut = new SqlCommand(kayit, cn.SqlConnetion);
            komut.Parameters.AddWithValue("Dergi_ID", Convert.ToInt32(datagriddergi.CurrentRow.Cells[0].Value));
            komut.Parameters.AddWithValue("Dergi_Ad", txtBoxDergiAdi.Text);
            komut.Parameters.AddWithValue("Dergi_Yayinci", txtBoxDergiYayinci.Text);
            komut.Parameters.AddWithValue("Dergi_Turu", cmbBoxDergiTur.Text);
            komut.Parameters.AddWithValue("Dergi_Ucreti", (txtBoxDergiUcret.Text));
            komut.Parameters.AddWithValue("Dergi_Stok", Convert.ToInt32(txtBoxDergiStok.Text));
            if (pictureBoxCdfoto.ImageLocation == null)
            {
                komut.Parameters.AddWithValue("Dergi_Fotograf", datagriddergi.CurrentRow.Cells[6].Value.ToString());
            }
            else
            {
                komut.Parameters.AddWithValue("Dergi_Fotograf", pictureBoxDergiFotograf.ImageLocation.Substring(pictureBoxDergiFotograf.ImageLocation.LastIndexOf("\\") + 1));

            }
            komut.Parameters.AddWithValue("Dergi_Sayi", txtBoxSayi.Text);
            komut.ExecuteNonQuery();
            if (komut.Connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            cn.SqlConnetion.Close();
            dergiyukle();
        }
        /// <summary>
        /// Datagridview'deki bilgiler sutunlar secildiginde textboxlara bilgiler dolar.
        /// </summary>
        private void datagriddergi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxDergiAdi.Text = datagriddergi.CurrentRow.Cells[1].Value.ToString();
                txtBoxDergiYayinci.Text = datagriddergi.CurrentRow.Cells[2].Value.ToString();
                cmbBoxDergiTur.Text = datagriddergi.CurrentRow.Cells[3].Value.ToString();
                txtBoxDergiUcret.Text = datagriddergi.CurrentRow.Cells[4].Value.ToString();
                txtBoxDergiStok.Text = datagriddergi.CurrentRow.Cells[5].Value.ToString();
                resimadi = datagriddergi.CurrentRow.Cells[6].Value.ToString();
                pictureBoxDergiFotograf.Image = Image.FromFile(Application.StartupPath + @"\Resources\DergiResimleri\" + resimadi);
                txtBoxSayi.Text = datagriddergi.CurrentRow.Cells[7].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Veri Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
        /// <summary>
        /// Verileri textboxlardan alarak update sorgusu ile databaseye iletir. 
        /// </summary>
        private void btnmusteriguncelle_Click(object sender, EventArgs e)
        {
            string kayit = "UPDATE MusteriTable SET Musteri_Ad=@Musteri_Ad,Musteri_Soyad=@Musteri_Soyad,Musteri_KullaniciAdi=@Musteri_KullaniciAdi,Musteri_Parola=@Musteri_Parola,Musteri_Email=@Musteri_Email,Musteri_Telefon = @Musteri_Telefon,Musteri_Adres=@Musteri_Adres,Musteri_Isroot=@Musteri_Isroot where Musteri_ID=@Musteri_ID";
            cn.SqlConnetion.Open();
            SqlCommand komut = new SqlCommand(kayit, cn.SqlConnetion);
            komut.Parameters.AddWithValue("Musteri_ID", Convert.ToInt32(datagridmusteri.CurrentRow.Cells[0].Value));
            komut.Parameters.AddWithValue("Musteri_Ad", txtboxmusteriadi.Text);
            komut.Parameters.AddWithValue("Musteri_Soyad", txtmusterisoyad.Text);
            komut.Parameters.AddWithValue("Musteri_KullaniciAdi", txtboxmusterikullaniciadi.Text);
            komut.Parameters.AddWithValue("Musteri_Parola", txtboxmusteripassword.Text);
            komut.Parameters.AddWithValue("Musteri_Email", txtboxemail.Text);
            komut.Parameters.AddWithValue("Musteri_Telefon", txtboxmusteritelefon.Text);
            komut.Parameters.AddWithValue("Musteri_Adres", txtboxmusteriadres.Text);
            if (chcyonetici.Checked == true)
            {
                komut.Parameters.AddWithValue("Musteri_Isroot", 1);
            }
            else
            {
                komut.Parameters.AddWithValue("Musteri_Isroot", 0);
            }


            komut.ExecuteNonQuery();
            if (komut.Connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Güncelleme Tamamlandı");
            }
            cn.SqlConnetion.Close();
            insanyukle();

        }
        /// <summary>
        /// Datagridview'deki bilgiler sutunlar secildiginde textboxlara bilgiler dolar.
        /// </summary>
        private void datagridmusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtboxmusteriadi.Text = datagridmusteri.CurrentRow.Cells[1].Value.ToString();
                txtmusterisoyad.Text = datagridmusteri.CurrentRow.Cells[2].Value.ToString();
                txtboxmusterikullaniciadi.Text = datagridmusteri.CurrentRow.Cells[3].Value.ToString();
                txtboxmusteripassword.Text = datagridmusteri.CurrentRow.Cells[4].Value.ToString();
                txtboxemail.Text = datagridmusteri.CurrentRow.Cells[5].Value.ToString();
                txtboxmusteritelefon.Text = datagridmusteri.CurrentRow.Cells[6].Value.ToString();
                txtboxmusteriadres.Text = datagridmusteri.CurrentRow.Cells[7].Value.ToString();
                if (datagridmusteri.CurrentRow.Cells[8].Value.ToString() == "1")
                {
                    chcyonetici.Checked = true;
                }
                else
                {
                    chcyonetici.Checked = false;
                }
            }
            catch
            {
                MessageBox.Show("Veri Yok", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


    }
}
