using KartFormu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class AlisverisSepetiForm : Form
    {
        List<SatilacakUrunPanel> liste;
        public static double toplamfiyat;
        /// <summary>
        /// Satin alinacak urunler alisveris sepetinde gosterilir.
        /// </summary>
        /// <param name="liste">Eklenen urunler liste parametresiyle AlisverisSepetiFormun constructor'ına gelir ve burada olusturmdugumuz liste doldurulur.</param>
        public AlisverisSepetiForm(List<SatilacakUrunPanel> liste)
        {
            InitializeComponent();
            this.liste = liste;
            panelidoldur();
           
        }
        /// <summary>
        /// Paneli SatilacakUrunPanel Cinsi ile doldurulur.
        /// </summary>
        public void panelidoldur()
        {
            toplamfiyat = 0;
            pnlurun.Controls.Clear();
            if(liste.Count==0)
            {
                this.Close();
            }
            foreach (var nesne in liste)
            {
                toplamfiyat += Convert.ToDouble((nesne.urun.Urun.ucret));
                pnlurun.Controls.Add(nesne);
                
            }
            lblFiyat.Text = toplamfiyat.ToString();
            AlisverisSayfa.sepet.toplamucret = toplamfiyat;
        }

      
        /// <summary>
        /// Satin Al butonu Kartformun acilmasini saglar.
        /// </summary>
      
        private void btnsatinal_Click(object sender, EventArgs e)
        {
            KartForm form = new KartForm();
            this.Opacity = 0;
            form.Show();

        }

        private void AlisverisSepetiForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
