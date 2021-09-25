using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo.Soporte.GeneradorAleatorios
{
    class GeneradorExponencialNegativa : IGenerador
    {
        private GeneradorLenguaje generadorLenguaje;
        private double aleatorio;
        private double media;

        public GeneradorExponencialNegativa(GeneradorLenguaje generadorLenguaje,double media)
        {
            this.generadorLenguaje = generadorLenguaje;
            this.media = media;
        }

        public double obtenerAleatorio()
        {
            aleatorio = generadorLenguaje.obtenerAleatorio();
            return -media * Math.Log(1 - aleatorio);
        }
    }
}
