using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
namespace BookStore
{
    /// <summary>
    /// Musteri sinifidir.Singleton pattern ile musteri uretilir. 
    /// </summary>
    public class Musteri
    {
        private long id;
        private string adi;
        private string soyadi;
        private string adres;
        private string email;
        private string kullaniciadi;
        private string parola;
        private string telefon;
        private Image resim;
        private int urunsayisi;
        private static Musteri instance;
        private int isroot;
        public ArrayList urunliste=new ArrayList();
        private Musteri() { }
        public static Musteri getInstance()
        {
            if (instance == null)
                instance = new Musteri();
            return instance;
        }
        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Adi
        {
            get
            {
                return adi;
            }

            set
            {
                adi = value;
            }
        }
        public string Adres
        {
            get
            {
                return adres;
            }

            set
            {
                adres = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Kullaniciadi
        {
            get
            {
                return kullaniciadi;
            }

            set
            {
                kullaniciadi = value;
            }
        }
        public string Parola
        {
            get
            {
                return parola;
            }

            set
            {
                parola = value;
            }
        }
        public Image Resim
        {
            get
            {
                return resim;
            }

            set
            {
                resim = value;
            }
        }
        public int Urunsayisi
        {
            get
            {
                return urunsayisi;
            }

            set
            {
                urunsayisi = value;
            }
        }
        public string Telefon
        {
            get
            {
                return telefon;
            }

            set
            {
                telefon = value;
            }
        }
        public int Isroot
        {
            get
            {
                return isroot;
            }

            set
            {
                isroot = value;
            }
        }

        public string Soyadi
        {
            get
            {
                return soyadi;
            }

            set
            {
                soyadi = value;
            }
        }
    }
}
