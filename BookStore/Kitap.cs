using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
   public class Kitap:Urun
    {
        /// <summary>
        /// Kitap sinifidir.Urun sinifindaki DetayGoster fonksiyonunu implemente eder.
        /// </summary>
        public String Yazar;
        public String Yayımcı;
        public String Sayfa;
        public String Isbn;
        public override void DetayGoster()
        {
            KitapTanim frm = new KitapTanim(this);
            frm.Show();
        }
    }
}
