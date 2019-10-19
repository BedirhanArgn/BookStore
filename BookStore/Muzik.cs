using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    /// <summary>
    /// Muzik sinifidir.Urun sinifindaki DetayGoster fonksiyonunu implemente eder.
    /// </summary>
    public class Muzik:Urun
    {
        public String Sarkici;
        public override void DetayGoster()
        {
            MuzikTanim mzk = new MuzikTanim(this);
            mzk.Show();
        }
    }
}
