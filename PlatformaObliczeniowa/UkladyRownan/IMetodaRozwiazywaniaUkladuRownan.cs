using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaObliczeniowa.UkladyRownan
{
    interface IMetodaRozwiazywaniaUkladuRownan
    {
        void PobierzA(double[,] macierzA);
        void PobierzB(double[] wektorB);
        double[] ZwrocX();
        void RozwiazUklad();
        string WypiszX();
    }
}
