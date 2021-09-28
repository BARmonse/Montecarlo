using Montecarlo.Soporte;
using Montecarlo.Soporte.Graficador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montecarlo
{
    class GestorProyectos
    {
        private double[] lineaAnterior;
        private double[] lineaActual;
        private List<int> proyectos;
        private List<double> tiemposPromiedos;

        Form1 pantalla;
        private Truncador truncador;
        private GeneradorLenguaje generadorAleatorios;
        private DataTable tablaResultados;
        private DataTable tablaRango;

        public GestorProyectos(Form1 pantalla)
        {
            this.pantalla = pantalla;
            this.lineaAnterior = new double[24];
            this.lineaActual = new double[24];
            this.truncador = new Truncador(2);
            this.generadorAleatorios = new GeneradorLenguaje(truncador);
            this.tablaResultados = new DataTable();
            this.tablaRango = new DataTable();
            this.proyectos = new List<int>();
            this.tiemposPromiedos = new List<double>();
            crearTabla(tablaRango);
            //crearTabla(tablaResultados);
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("Proyecto");
            tabla.Columns.Add("RND 1");
            tabla.Columns.Add("Duración actividad 1");
            tabla.Columns.Add("Fin actividad 1");
            tabla.Columns.Add("RND 2");//lineaActual[5]
            tabla.Columns.Add("Duración actividad 2");
            tabla.Columns.Add("Fin actividad 2");
            tabla.Columns.Add("RND 3");
            tabla.Columns.Add("Duración actividad 3");
            tabla.Columns.Add("Fin actividad 3");//lineaActual[10]
            tabla.Columns.Add("RND 4");
            tabla.Columns.Add("Duración actividad 4");
            tabla.Columns.Add("Fin actividad 4");
            tabla.Columns.Add("Inicio más temprano A5");
            tabla.Columns.Add("RND 5");
            tabla.Columns.Add("Duración actividad5");//lineaActual[16]
            tabla.Columns.Add("Fin actividad5");
            tabla.Columns.Add("Duración de la tarea de ensamble");
            tabla.Columns.Add("Tiempo acumulado");
            tabla.Columns.Add("Tiempo promedio");
            tabla.Columns.Add("Maxima duración");//lineaActual[21]
            tabla.Columns.Add("Minima duración");
            tabla.Columns.Add("Contador proyectos < 45");
            tabla.Columns.Add("Probabilidad (%)");
        }

        public void simular(int cantidad,double limInferiorAct1,double limSuperiorAct1,double limInferiorAct2,double limSuperiorAct2,double mediaAct3,double limInferiorAct4,double limSuperiorAct4,double mediaAct5, int desde,int hasta)
        {
            procesar(cantidad, limInferiorAct1, limSuperiorAct1, limInferiorAct2, limSuperiorAct2, mediaAct3, limInferiorAct4, limSuperiorAct4, mediaAct5, desde,hasta);
            mostrarRango();
            graficarTiempoPromedio();
        }

        private void procesar(int cantidad, double limInferiorAct1, double limSuperiorAct1, double limInferiorAct2, double limSuperiorAct2, double mediaAct3, double limInferiorAct4, double limSuperiorAct4, double mediaAct5, int desde, int hasta)
        {
            int proyecto;
            double rnd1;
            double rnd2;
            double rnd3;
            double rnd4;
            double rnd5;

            double duracionActividad1;
            double duracionActividad2;
            double duracionActividad3;
            double duracionActividad4;
            double finActividad4;
            double duracionActividad5;
            double finActividad5;
            double inicioTemprano;
            double tiempoTotal;
            double tiempoAcumulado;
            double tiempoPromedio;
            int contador = 0;
            double probabilidad;
            double max;
            double min;

            DataRow row;

            for (int i = 1; i < cantidad; i++)
            {
                // Número de proyecto
                proyecto = i;
                lineaActual[0] = proyecto;
                proyectos.Add(proyecto);

                //RND de la actividad 1
                rnd1 = generadorAleatorios.obtenerAleatorio();
                lineaActual[1] = rnd1;
                //Duración y fin de la actividad 1
                duracionActividad1 = limInferiorAct1 + (limSuperiorAct1 - limInferiorAct1) * rnd1;
                lineaActual[2] = duracionActividad1;
                lineaActual[3] = duracionActividad1;

                //RND de la actividad 2
                rnd2 = generadorAleatorios.obtenerAleatorio();
                lineaActual[4] = rnd2;
                //Duración y fin de la actividad 2
                duracionActividad2 = limInferiorAct2 + (limSuperiorAct2 - limInferiorAct2) * rnd2;
                lineaActual[5] = duracionActividad2;
                lineaActual[6] = duracionActividad2;

                //RND de la actividad 3
                rnd3 = generadorAleatorios.obtenerAleatorio();
                lineaActual[7] = rnd3;
                //Duración y fin de la actividad 3
                duracionActividad3 = -mediaAct3 * Math.Log(1 - rnd3);
                lineaActual[8] = duracionActividad3;
                lineaActual[9] = duracionActividad3;

                //RND de la actividad 4
                rnd4 = generadorAleatorios.obtenerAleatorio();
                lineaActual[10] = rnd4;
                //Duración y fin de la actividad 4
                duracionActividad4 = limInferiorAct4 + (limSuperiorAct4 - limInferiorAct4) * rnd4;
                finActividad4 = duracionActividad1 + duracionActividad4;
                lineaActual[11] = duracionActividad4;
                lineaActual[12] = finActividad4;

                //Inicio más temprano de actividad 5
                inicioTemprano = obtenerMaximo(finActividad4, duracionActividad2);
                lineaActual[13] = inicioTemprano;

                //RND de la actividad 5
                rnd5 = generadorAleatorios.obtenerAleatorio();
                lineaActual[14] = rnd5;

                //Duración y fin de la actividad 5
                duracionActividad5 = -mediaAct5 * Math.Log(1 - rnd5);
                finActividad5 = inicioTemprano + duracionActividad5;
                lineaActual[15] = duracionActividad5;
                lineaActual[16] = finActividad5;

                //Tiempo total de tarea de ensamble
                tiempoTotal = finActividad5;
                lineaActual[17] = tiempoTotal;

                //Tiempo acumulado de tarea de ensamble
                if (i == 1)
                {
                    tiempoAcumulado = finActividad5;
                    lineaActual[18] = tiempoAcumulado;
                }
                else
                {
                    tiempoAcumulado = lineaAnterior[18] + tiempoTotal;
                    lineaActual[18] = tiempoAcumulado;
                }

                //Tiempo promedio de tarea de ensamble
                tiempoPromedio = tiempoAcumulado / i;
                lineaActual[19] = tiempoPromedio;
                tiemposPromiedos.Add(tiempoPromedio);

                //Máximo y Minimo
                if (i == 1)
                {
                    min = tiempoTotal;
                    max = tiempoTotal;
                }
                else
                {
                    max = obtenerMaximo(lineaAnterior[20], tiempoTotal);
                    min = obtenerMinimo(lineaAnterior[21], tiempoTotal);
                }

                lineaActual[20] = max;
                lineaActual[21] = min;

                //Contador de proyectos que duren menos de 45 días
                if (tiempoTotal < 45)
                {
                    contador += 1;
                }
                lineaActual[22] = contador;

                //Probabilidad de que el proyecto dure menos de 45 días
                probabilidad = contador * 100 / i;
                lineaActual[23] = probabilidad;

                //Guardamos la linea actual antes de pasar a la siguiente iteración
                lineaAnterior = lineaActual;


                if (i >= desde && i <= hasta)
                {
                    row = tablaRango.NewRow();
                    for (int j = 0; j < lineaActual.Length; j++)
                    {
                        row[j] = truncador.truncar(lineaActual[j]);
                    }
                    tablaRango.Rows.Add(row);
                }
            }
        }

        private double obtenerMinimo(double a, double b)
        {
            if (a <= b)
            {
                return a;
            }
            return b;
        }
        private double obtenerMaximo(double a, double b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }
        private void mostrarRango()
        {
            pantalla.mostrarRango(tablaRango);
        }

        private void graficarTiempoPromedio()
        {
            Graficador graficador = new Graficador();
            graficador.proyectos = this.proyectos.ToArray();
            graficador.tiemposPromedios = this.tiemposPromiedos.ToArray();
            graficador.Show();
        }
    }
}