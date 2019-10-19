using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    /// <summary>
    /// Dergi sinifidir.Derginin Sayisi'ni tutan bir degisken icerir.
    /// </summary>
    public class Dergi : Urun
    {
        public String sayi;
       /// <summary>
       /// DetayGoster abstract fonksiyonu Urun sinifindan implemente edilmistir derginin detayini gosterir.
       /// </summary>

        public override void DetayGoster()
        {
           DergiTanim dergi = new DergiTanim(this);
            dergi.Show();



        }

    }
}
