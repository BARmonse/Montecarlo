using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo.Soporte
{
    class GeneradorLenguaje
    {
        Random random;
        Truncador truncador;

        public GeneradorLenguaje(Truncador truncador)
        {
            this.truncador = truncador;
            this.random = new Random();
        }

        public double obtenerAleatorio()
        {
            return truncador.truncar(random.NextDouble());
        }
    }
}
