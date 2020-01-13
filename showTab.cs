using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy
{
   public static class showTab
    {
        public static string Show(int [,] Tablica,int ile)
        {
            string tabTemp;
            tabTemp = string.Join("\n", Tablica.OfType<int>()
            .Select((value, index) => new { value, index })
            .GroupBy(x => x.index / Tablica.GetLength(1), x => x.value,
            (i, ints) => $"{string.Join(" ", ints)}"));
            return tabTemp;
            //System.Windows.MessageBox.Show(tabTemp);
        }
    }
}
