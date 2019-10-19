using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace BookStore
{
    public class MusteriLog
    {
        /// <summary>
        /// Gelen kayit verisini bir txt tarih ve saat ile birlikte txt dosyasina yazdirir.
        /// </summary>
        /// <param name="kayitverisi">Alisveris Sayfasinda basilan butonların verisidir.</param>
        public static void kaydet(string kayitverisi)
        {
            Musteri musteri = Musteri.getInstance();
            string kayit = musteri.Adi +musteri.Soyadi+ "\t\t" + kayitverisi + " Button\t\t" + DateTime.Now.ToShortDateString() + "\t" + DateTime.Now.ToLongTimeString();
            string yol = Application.StartupPath + @"/Log.txt";
            if (!File.Exists(yol))
            {

                using (StreamWriter sw = File.CreateText(yol))
                {
                   
                    sw.WriteLine(string.Format("{0,-25} {1,-50} {2,-15} {3,-15}", "Username", "Button Info", "Date", "Time"));
                    sw.WriteLine(string.Format("{0,-25} {1,-50} {2,-15} {3,-15}", musteri.Kullaniciadi, kayitverisi, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                }
            }
            else
            {
            using (StreamWriter sw = File.AppendText(yol))
            {
                sw.WriteLine(string.Format("{0,-25} {1,-50} {2,-15} {3,-15}", musteri.Kullaniciadi, kayitverisi, DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
            }
            }
            
        }






    }
}
