using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo.Soporte.GeneradorAleatorios
{
    class GeneradorNormal : IGenerador
    {
        private GeneradorLenguaje generadorLenguaje;
        double aleatorio1;
        double aleatorio2;
        double media;
        double desviacion;

        public GeneradorNormal(GeneradorLenguaje generadorLenguaje, double media, double desviacion)
        {
            this.generadorLenguaje = generadorLenguaje;
            this.media = media;
            this.desviacion = desviacion;
        }

        public double obtenerAleatorio()
        {
            aleatorio1 = generadorLenguaje.obtenerAleatorio();
            aleatorio2 = generadorLenguaje.obtenerAleatorio();
            return Math.Sqrt(-2 * Math.Log(aleatorio1)) * Math.Cos(2 * Math.PI * aleatorio2) * desviacion + media;
        }
    }
}

