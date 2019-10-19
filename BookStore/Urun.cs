using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BookStore
{
    /// <summary>
    /// Urun tipinde abstract classtir.                                  
    /// </summary>
    public abstract class Urun
    {
        public String isim;
        public double ucret;
        public int urunID;
        public int urunsayisi;
        public string kategori;
        public Image resim;
        public abstract void DetayGoster();
    }
}
