using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
    class AddingVertex
    {
        public void Send( int ile)
        {
          

                   UIGlobal.MainPage.wybierz.Items.Clear();
            UIGlobal.MainPage.wybierz2.Items.Clear();
            for (int i = 0; i < ile; i++)
            {
                UIGlobal.MainPage.wybierz.Items.Add(i);
                UIGlobal.MainPage.wybierz2.Items.Add(i);
            }
        }
    }
}
