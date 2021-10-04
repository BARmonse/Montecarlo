using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo.Soporte
{
    class TablaStudent
    {
        public static double obtenerFechaAFijar(int gradosLibertad,double media,double desviacion)
        {
            Dictionary<int, double> areas = new Dictionary<int, double>()
        {
            {1 , 3.078},
            {2 , 1.886},
            {3 , 1.638},
            {4 , 1.533},
            {5 , 1.476},
            {6 , 1.440},
            {7 , 1.415},
            {8 , 1.397},
            {9 , 1.383},
            {10 , 1.372},
            {11 , 1.363},
            {12 , 1.356},
            {13 , 1.350},
            {14 , 1.345},
            {15 , 1.341},
            {16 , 1.337},
            {17 , 1.333},
            {18 , 1.330},
            {19 , 1.328},
            {20 , 1.325},
            {21 , 1.323},
            {22 , 1.321},
            {23 , 1.319},
            {24 , 1.318},
            {25 , 1.316},
            {26 , 1.315},
            {27 , 1.314},
            {28 , 1.313},
            {29 , 1.311},
            {30 , 1.310},
            {5000, 1.282}
        };
            if (gradosLibertad <= 30) { return media + areas[gradosLibertad] * desviacion / Math.Sqrt(gradosLibertad); }
            return media + areas[5000] * desviacion / Math.Sqrt(gradosLibertad);
        }
    }
}
