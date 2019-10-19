using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace BookStore
{
    /// <summary>
    /// UrunPanel'in degiskenlerini icerir.
    /// </summary>
    abstract class UrunPanel : Panel
    {
        public Label isim;
        public Label fiyat; 
        public PictureBox resimekle;
        public Button incele;

      
      
    }
}
