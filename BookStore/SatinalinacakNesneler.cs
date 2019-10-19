using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    /// <summary>
    /// Satin alinacak urunlerin class'idir.Sayisi ve Urun sayisi ve Urun degiskenleri tutar.   
    /// </summary>
   public class SatinalinacakNesneler
    {
        private Urun urun;
        private int sayisi;

        public int Sayisi
        {
            get { return sayisi; }
            set { sayisi = value; }
        }
        public Urun Urun
        {
            get { return urun; }
            set { urun = value; }
        }




    }
}
