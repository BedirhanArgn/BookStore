using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{

    public class AlisverisSepeti
    {
        public List<SatinalinacakNesneler> urun;
        AlisverisSepetiForm sepet;
        public Musteri m;
        public double toplamucret;
        List<SatilacakUrunPanel> liste;
        int Y = 0;
        public AlisverisSepeti()
        {
            urun = new List<SatinalinacakNesneler>();
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nesne">Silinecek urun buraya gelir ve urun silinir.</param>
        public void UrunSil(SatinalinacakNesneler nesne)
        {
            try
            {
           urun.Remove(nesne);
            foreach (var item in liste)
            {
                if(item.urun==nesne)
                {
                    liste.Remove(item);
                    break;
                }

            }
            paneliyenile();
            }
            catch
            {
                Console.WriteLine("Liste Boş");

            }         
        }
        /// <summary>
        /// panel yenilenerek silinen urun kaldiriliyor.
        /// </summary>
        public void paneliyenile()
        {
            sepet.panelidoldur();

        }
        /// <summary>
        /// Listenin icindeki urunler panelde gosteriliyor.
        /// </summary>
        public void urungoster()
        {
            liste = new List<SatilacakUrunPanel>();

            foreach (var item in urun)
            {
                SatilacakUrunPanel pnl = new SatilacakUrunPanel(item,Y);
                liste.Add(pnl);
                Y = Y + 80;
            }
            Y = 0;
            sepet = new AlisverisSepetiForm(liste);

            try
            {
                sepet.Show();

            }
            catch
            {
               
            }
           

        }
    }
}
