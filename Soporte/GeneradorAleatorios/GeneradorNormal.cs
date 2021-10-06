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
        double aleatorioNormal;

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
            
            aleatorioNormal = Math.Sqrt(-2 * Math.Log(aleatorio1)) * Math.Cos(2 * Math.PI * aleatorio2) * desviacion + media;
            while (double.IsInfinity(aleatorioNormal)) {
                aleatorio1 = generadorLenguaje.obtenerAleatorio();
                aleatorio2 = generadorLenguaje.obtenerAleatorio();
                aleatorioNormal = Math.Sqrt(-2 * Math.Log(aleatorio1)) * Math.Cos(2 * Math.PI * aleatorio2) * desviacion + media;
                if (double.IsFinite(aleatorioNormal)) { break; }
            }
            if (aleatorioNormal < 0) { return Math.Abs(aleatorioNormal); }
            return aleatorioNormal;
        }
    }
}