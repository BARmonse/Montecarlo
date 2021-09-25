using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo.Soporte.GeneradorAleatorios
{
    class GeneradorUniformeAB : IGenerador
    {
        private GeneradorLenguaje generadorLenguaje;
        private double aleatorio;

        private double a;
        private double b;

        public GeneradorUniformeAB(GeneradorLenguaje generadorLenguaje, double a, double b)
        {
            this.a = a;
            this.b = b;
            this.generadorLenguaje = generadorLenguaje;
        }

        public double obtenerAleatorio()
        {
            aleatorio = generadorLenguaje.obtenerAleatorio();
            return a + (b - a) * aleatorio;
        }
    }
}
