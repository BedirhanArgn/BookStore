using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BookStore
{
    class PanelUret
    {
        /// <summary>
        /// Panelin uretildigi classtir.
        /// </summary>
        /// <param name="nesne">Urun tipidir.</param>
        /// <param name="Xkontrol">X'in kontroludur. </param>
        /// <param name="ykontol">Y'nin kontroludur.</param>
        /// <returns></returns>
        public UrunPanel PanelOlustur(Urun nesne,int Xkontrol, int ykontol)
        {
            UrunPanel panel = null;
            if (nesne is Kitap)
            {
                panel = new KitapPanel((Kitap)nesne, Xkontrol, ykontol);
            }
            else if (nesne is Dergi)
            {
                panel = new DergiPanel((Dergi)nesne, Xkontrol, ykontol);
            }
            else
                panel = new MuzikPanel((Muzik)nesne, Xkontrol, ykontol);

            return panel;
        }


    }
}
