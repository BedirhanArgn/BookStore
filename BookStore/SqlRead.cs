using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace BookStore
{
    /// <summary>
    /// Sql'deki dergi,muzik,kitap listelerinin verileri dolar.
    /// </summary>
    class SqlRead
    {
        private bool durum = false;
        private SqlDataReader dr;
        private SqlCommand komut;
        Connection cn = Connection.getInstance();
        public String Komut
        {
            set
            {
                cn.SqlConnetion.Close();
                komut = new SqlCommand();
                komut.CommandText = value.ToString();
                komut.Connection = cn.SqlConnetion;
                cn.SqlConnetion.Open();
            }
        }
        /// <summary>
        /// Musteri bilgileri musteri ye yuklenir.
        /// </summary>
        /// <returns></returns>
        public bool Oku()
        {
            Musteri musteri;
            try
            {
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    durum = true;
                    musteri = Musteri.getInstance();
                    musteri.Id = Convert.ToInt64(dr["Musteri_ID"]);
                    musteri.Adi = dr["Musteri_Ad"].ToString();
                    musteri.Soyadi = dr["Musteri_Soyad"].ToString();
                    musteri.Kullaniciadi = dr["Musteri_KullaniciAdi"].ToString();
                    musteri.Parola = dr["Musteri_Parola"].ToString();
                    musteri.Email = dr["Musteri_Email"].ToString();
                    musteri.Telefon = dr["Musteri_Telefon"].ToString();
                    musteri.Adres = dr["Musteri_Adres"].ToString();
                    musteri.Isroot = Convert.ToInt32(dr["Musteri_Isadmin"]);
                    return durum;
                }
                else
                {
                    durum = false;
                    return durum;
                }
            }
            catch
            {
                return durum;
                Console.WriteLine("Hata");
                cn.SqlConnetion.Close();
            }
        }
        /// <summary>
        /// Parametre olarak gelen sorguyu ve string dizisi icindeki veriyi sql'e yazdirir
        /// </summary>
        /// <param name="query">Sql sorgusudur</param>
        /// <param name="dizi">Gelen verilerdir</param>
        public void Yaz(String query, String[] dizi)
        {
            cn.SqlConnetion.Open();
            SqlCommand cmd = new SqlCommand(query, cn.SqlConnetion);
            for (int i = 0; i < dizi.Length; i++)
            {
                cmd.Parameters.AddWithValue("" + i, dizi[i]);
            }

            cmd.ExecuteNonQuery();
            cn.SqlConnetion.Close();           
        }
        /// <summary>
        /// Sql'deki verileri kitaba yukler
        /// </summary>
        /// <returns>List<urun> tipinde kitapliste dondurur. </returns>
        public List<Urun>KitapYukle()
        {
            List<Urun> kitapliste = new List<Urun>();
            cn.SqlConnetion.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM KitapTable", cn.SqlConnetion);
            SqlDataReader oku = kmt.ExecuteReader();
            Kitap kt;
            while (oku.Read())
            {
                kt = new Kitap();
                kt.urunID = (int)oku["Kitap_ID"];
                kt.isim = (string)oku["Kitap_Adi"];
                kt.Yazar = (string)oku["Kitap_Yazari"];
                kt.Yayımcı = (string)oku["Kitap_Yayinevi"];
                kt.ucret= (double)oku["Kitap_Ucreti"];
                kt.Sayfa = (string)oku["Kitap_SayfaSayisi"];
                kt.Isbn = (string)oku["Kitap_ISBN"];
                kt.kategori = (string)oku["Kitap_Turu"];
                kt.urunsayisi = (int)oku["Kitap_StokSayisi"];
                try
                {
                    kt.resim = Image.FromFile(Application.StartupPath + @"\Resources\KitapResimleri\" + (string)oku["Kitap_ResimIsmi"]);
                }
                catch
                {

                }
                kitapliste.Add(kt);
            }
            cn.SqlConnetion.Close();
            return kitapliste;
        }
        /// <summary>
        /// Sql'deki verileri dergiye yukler
        /// </summary>
        /// <returns>List<urun> tipinde dergiliste dondurur</returns>
        public List<Urun>DergiYukle()
        {
            List<Urun> dergiliste = new List<Urun>();
            cn.SqlConnetion.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM DergiTable", cn.SqlConnetion);
            SqlDataReader reader = command.ExecuteReader();
            Dergi dergi;
            while (reader.Read())
            {
                dergi = new Dergi();
                dergi.urunID = (int)reader["Dergi_ID"];
                dergi.isim = (string)reader["Dergi_Ad"];             
                dergi.sayi = (string)reader["Dergi_Sayi"];
                dergi.ucret = (double)reader["Dergi_Ucreti"];
                dergi.urunsayisi = (int)reader["Dergi_Stok"];
                dergi.kategori = (string)reader["Dergi_Turu"];
                try
                {
                    dergi.resim = Image.FromFile(Application.StartupPath + @"\Resources\DergiResimleri\" + (string)reader["Dergi_Fotograf"]);
                }
                catch (Exception)
                {
                }

                dergiliste.Add(dergi);
            }

            cn.SqlConnetion.Close();
            return dergiliste;
        }
        /// <summary>
        /// Sql'deki verileri muzige yukler
        /// </summary>
        /// <returns>List<urun> tipinde muzikliste dondurur</returns>
        public List<Urun>MuzikYukle()
        {
            List<Urun> muzikliste = new List<Urun>();
            cn.SqlConnetion.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM MuzikTable", cn.SqlConnetion);
            SqlDataReader reader = command.ExecuteReader();
            Muzik muzik;
            while (reader.Read())
            {
                muzik = new Muzik();
                muzik.urunID = (int)reader["Muzik_ID"];
                muzik.isim = (string)reader["Muzik_CDAd"];
                muzik.Sarkici = (string)reader["Muzik_Sanatci"];
                muzik.kategori = (string)reader["Muzik_Turu"];
                muzik.ucret = (double)reader["Muzik_Ucreti"];
                muzik.urunsayisi = (int)reader["Muzik_Stok"];
            
                try
                {
                    muzik.resim = Image.FromFile(Application.StartupPath + @"\Resources\MuzikResimleri\" + (string)reader["Muzik_Fotograf"]);
                }
                catch (Exception)
                {
                    //dergi.image = Properties.Resources.noimage;
                }

                muzikliste.Add(muzik);
            }
            cn.SqlConnetion.Close();
            return muzikliste;
        }
                      
    }
}
