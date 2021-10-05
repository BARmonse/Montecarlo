using Montecarlo.Soporte;
using Montecarlo.Soporte.Graficador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private DataTable tablaRango;
        private DataTable tablaUltimosProyectos;

        public GestorProyectos(Form1 pantalla)
        {
            this.pantalla = pantalla;
            this.lineaAnterior = new double[80];
            this.lineaActual = new double[80];
            this.truncador = new Truncador(2);
            this.generadorAleatorios = new GeneradorLenguaje(truncador);
            this.tablaRango = new DataTable();
            this.tablaUltimosProyectos = new DataTable();
            this.proyectos = new List<int>();
            this.tiemposPromiedos = new List<double>();
            crearTabla(tablaRango);
            crearTabla(tablaUltimosProyectos);
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("Proyecto");//lineaActual[0]
            tabla.Columns.Add("RND 1");//lineaActual[1]
            tabla.Columns.Add("Duración actividad 1");//lineaActual[2]
            tabla.Columns.Add("RND 2");//lineaActual[3]
            tabla.Columns.Add("Duración actividad 2");//lineaActual[4]
            tabla.Columns.Add("RND 3");//lineaActual[5]
            tabla.Columns.Add("Duración actividad 3");//lineaActual[6]
            tabla.Columns.Add("RND 4");//lineaActual[7]
            tabla.Columns.Add("Duración actividad 4");//lineaActual[8]
            tabla.Columns.Add("RND 5");//lineaActual[9]
            tabla.Columns.Add("Duración actividad5");//lineaActual[10]
            tabla.Columns.Add("Camino 1 (A1-A4-A5");//lineaActual[11]
            tabla.Columns.Add("Camino 2 (A2-A5)");//lineaActual[12]
            tabla.Columns.Add("Camino 3 (A3)");//lineaActual[13]
            tabla.Columns.Add("Duración Camino Crítico");//lineaActual[14]
            tabla.Columns.Add("Tiempo acumulado");//lineaActual[15]
            tabla.Columns.Add("Promedio");//lineaActual[16]
            tabla.Columns.Add("Varianza");//lineaActual[17]
            tabla.Columns.Add("Desviación");//lineaActual[18]
            tabla.Columns.Add("Maxima duración");//lineaActual[19]
            tabla.Columns.Add("Minima duración");//lineaActual[20]
            tabla.Columns.Add("Contador proyectos < 45");//lineaActual[21]
            tabla.Columns.Add("Probabilidad (%)");//lineaActual[22]
            tabla.Columns.Add("T De student");//lineaActual[23]
            tabla.Columns.Add("Inicio más tardio A5");//lineaActual[24]
            tabla.Columns.Add("Inicio más tardio A4");//lineaActual[25]
            tabla.Columns.Add("Inicio más tardio A3");//lineaActual[26]
            tabla.Columns.Add("Inicio más tardio A2");//lineaActual[27]
            tabla.Columns.Add("Inicio más tardio A1");//lineaActual[28]
            tabla.Columns.Add("Prob. A1 Crítica");//lineaActual[29]
            tabla.Columns.Add("Prob. A2 Crítica");//lineaActual[30]
            tabla.Columns.Add("Prob. A3 Crítica");//lineaActual[31]
            tabla.Columns.Add("Prob. A4 Crítica");//lineaActual[32]
            tabla.Columns.Add("Prob. A5 Crítica");//lineaActual[33]
            tabla.Columns.Add("Inicio Intervalo 1");//lineaActual[34]
            tabla.Columns.Add("Inicio Intervalo 2");//lineaActual[35]
            tabla.Columns.Add("Inicio Intervalo 3");//lineaActual[36]
            tabla.Columns.Add("Inicio Intervalo 4");//lineaActual[37]
            tabla.Columns.Add("Inicio Intervalo 5");//lineaActual[38]
            tabla.Columns.Add("Inicio Intervalo 6");//lineaActual[39]
            tabla.Columns.Add("Inicio Intervalo 7");//lineaActual[40]
            tabla.Columns.Add("Inicio Intervalo 8");//lineaActual[41]
            tabla.Columns.Add("Inicio Intervalo 9");//lineaActual[42]
            tabla.Columns.Add("Inicio Intervalo 10");//lineaActual[43]
            tabla.Columns.Add("Inicio Intervalo 11");//lineaActual[44]
            tabla.Columns.Add("Inicio Intervalo 12");//lineaActual[45]
            tabla.Columns.Add("Inicio Intervalo 13");//lineaActual[46]
            tabla.Columns.Add("Inicio Intervalo 14");//lineaActual[47]
            tabla.Columns.Add("Inicio Intervalo 15");//lineaActual[48]
            tabla.Columns.Add("Fin");//lineaActual[49]

            tabla.Columns.Add("Prob Intervalo 1");//lineaActual[50]
            tabla.Columns.Add("Prob Intervalo 2");//lineaActual[51]
            tabla.Columns.Add("Prob Intervalo 3");//lineaActual[52]
            tabla.Columns.Add("Prob Intervalo 4");//lineaActual[53]
            tabla.Columns.Add("Prob Intervalo 5");//lineaActual[54]
            tabla.Columns.Add("Prob Intervalo 6");//lineaActual[55]
            tabla.Columns.Add("Prob Intervalo 7");//lineaActual[56]
            tabla.Columns.Add("Prob Intervalo 8");//lineaActual[57]
            tabla.Columns.Add("Prob Intervalo 9");//lineaActual[58]
            tabla.Columns.Add("Prob Intervalo 10");//lineaActual[59]
            tabla.Columns.Add("Prob Intervalo 11");//lineaActual[60]
            tabla.Columns.Add("Prob Intervalo 12");//lineaActual[61]
            tabla.Columns.Add("Prob Intervalo 13");//lineaActual[62]
            tabla.Columns.Add("Prob Intervalo 14");//lineaActual[63]
            tabla.Columns.Add("Prob Intervalo 15");//lineaActual[64]

            tabla.Columns.Add("Acum Intervalo 1");//lineaActual[65]
            tabla.Columns.Add("Acum Intervalo 2");//lineaActual[66]
            tabla.Columns.Add("Acum Intervalo 3");//lineaActual[67]
            tabla.Columns.Add("Acum Intervalo 4");//lineaActual[68]
            tabla.Columns.Add("Acum Intervalo 5");//lineaActual[69]
            tabla.Columns.Add("Acum Intervalo 6");//lineaActual[70]
            tabla.Columns.Add("Acum Intervalo 7");//lineaActual[71]
            tabla.Columns.Add("Acum Intervalo 8");//lineaActual[72]
            tabla.Columns.Add("Acum Intervalo 9");//lineaActual[73]
            tabla.Columns.Add("Acum Intervalo 10");//lineaActual[74]
            tabla.Columns.Add("Acum Intervalo 11");//lineaActual[75]
            tabla.Columns.Add("Acum Intervalo 12");//lineaActual[76]
            tabla.Columns.Add("Acum Intervalo 13");//lineaActual[77]
            tabla.Columns.Add("Acum Intervalo 14");//lineaActual[78]
            tabla.Columns.Add("Acum Intervalo 15");//lineaActual[79]
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
            double duracionActividad5;
            double camino1;
            double camino2;
            double camino3;
            double caminoCritico;
            double tiempoAcumulado;
            double tiempoPromedio;
            double varianza;
            double desviacion;

            int contador = 0;
            double probabilidad;
            double max;
            double min;

            double inicioTardioA1;
            double inicioTardioA2;
            double inicioTardioA3;
            double inicioTardioA4;
            double inicioTardioA5;

            double contadorA1 = 0;
            double contadorA2 = 0;
            double contadorA3 = 0;
            double contadorA4 = 0;
            double contadorA5 = 0;

            List<double> intervalos = new List<double>();

            double contadorIntervalo1 = 0;
            double contadorIntervalo2 = 0;
            double contadorIntervalo3 = 0;
            double contadorIntervalo4 = 0;
            double contadorIntervalo5 = 0;
            double contadorIntervalo6 = 0;
            double contadorIntervalo7 = 0;
            double contadorIntervalo8 = 0;
            double contadorIntervalo9 = 0;
            double contadorIntervalo10 = 0;
            double contadorIntervalo11 = 0;
            double contadorIntervalo12 = 0;
            double contadorIntervalo13 = 0;
            double contadorIntervalo14 = 0;
            double contadorIntervalo15 = 0;

            double acumuladoIntervalo1 = 0;
            double acumuladoIntervalo2 = 0;
            double acumuladoIntervalo3 = 0;
            double acumuladoIntervalo4 = 0;
            double acumuladoIntervalo5 = 0;
            double acumuladoIntervalo6 = 0;
            double acumuladoIntervalo7 = 0;
            double acumuladoIntervalo8 = 0;
            double acumuladoIntervalo9 = 0;
            double acumuladoIntervalo10 = 0;
            double acumuladoIntervalo11 = 0;
            double acumuladoIntervalo12 = 0;
            double acumuladoIntervalo13 = 0;
            double acumuladoIntervalo14 = 0;
            double acumuladoIntervalo15 = 0;


            DataRow row;

            for (int i = 1; i <= cantidad; i++)
            {
                // Número de proyecto
                proyecto = i;
                lineaActual[0] = proyecto;
                proyectos.Add(proyecto);

                //RND de la actividad 1
                rnd1 = generadorAleatorios.obtenerAleatorio();
                lineaActual[1] = rnd1;
                //Duración de la actividad 1
                duracionActividad1 = limInferiorAct1 + (limSuperiorAct1 - limInferiorAct1) * rnd1;
                lineaActual[2] = duracionActividad1;

                //RND de la actividad 2
                rnd2 = generadorAleatorios.obtenerAleatorio();
                lineaActual[3] = rnd2;
                //Duración de la actividad 2
                duracionActividad2 = limInferiorAct2 + (limSuperiorAct2 - limInferiorAct2) * rnd2;
                lineaActual[4] = duracionActividad2;

                //RND de la actividad 3
                rnd3 = generadorAleatorios.obtenerAleatorio();
                lineaActual[5] = rnd3;
                //Duración  de la actividad 3
                duracionActividad3 = -mediaAct3 * Math.Log(1 - rnd3);
                lineaActual[6] = duracionActividad3;

                //RND de la actividad 4
                rnd4 = generadorAleatorios.obtenerAleatorio();
                lineaActual[7] = rnd4;
                //Duración de la actividad 4
                duracionActividad4 = limInferiorAct4 + (limSuperiorAct4 - limInferiorAct4) * rnd4;
                lineaActual[8] = duracionActividad4;

                //RND de la actividad 5
                rnd5 = generadorAleatorios.obtenerAleatorio();
                lineaActual[9] = rnd5;

                //Duración de la actividad 5
                duracionActividad5 = -mediaAct5 * Math.Log(1 - rnd5);
                lineaActual[10] = duracionActividad5;

                //Duración de caminos
                camino1 = duracionActividad1 + duracionActividad4 + duracionActividad5;
                camino2 = duracionActividad2 + duracionActividad5;
                camino3 = duracionActividad3;

                lineaActual[11] = camino1;
                lineaActual[12] = camino2;
                lineaActual[13] = camino3;

                //Duración del camino crítico
                caminoCritico = obtenerMaximo(camino1, camino2, camino3);
                lineaActual[14] = caminoCritico;

                //Tiempo acumulado de caminos críticos
                if (i == 1)
                {
                    tiempoAcumulado = caminoCritico;
                    lineaActual[15] = tiempoAcumulado;
                }
                else
                {
                    tiempoAcumulado = lineaAnterior[15] + caminoCritico;
                    lineaActual[15] = tiempoAcumulado;
                }

                //Tiempo promedio
                tiempoPromedio = ((i-1) * lineaAnterior[16] + caminoCritico)/i;
                lineaActual[16] = tiempoPromedio;
                tiemposPromiedos.Add(tiempoPromedio);

                //Varianza
                if (i == 1) { varianza = 0; }
                else { varianza = ((i - 2) * lineaAnterior[17] + i * Math.Pow(tiempoPromedio - caminoCritico, 2) / (i - 1)) / (i - 1); }
                lineaActual[17] = varianza;

                //Desviacion
                desviacion = Math.Sqrt(varianza);
                lineaActual[18] = desviacion;

                //Máximo y Minimo
                if (i == 1)
                {
                    min = caminoCritico;
                    max = caminoCritico;
                }
                else
                {
                    max = obtenerMaximo(lineaAnterior[19], caminoCritico);
                    min = obtenerMinimo(lineaAnterior[20], caminoCritico);
                }

                lineaActual[19] = max;
                lineaActual[20] = min;

                //Contador de proyectos que duren menos de 45 días
                if (caminoCritico < 45)
                {
                    contador += 1;
                }
                lineaActual[21] = contador;

                //Probabilidad de que el proyecto dure menos de 45 días
                probabilidad = contador * 100 / i;
                lineaActual[22] = probabilidad;


                //Fecha a fijar con una confianza del 90%
                lineaActual[23] = TablaStudent.obtenerFechaAFijar(i,tiempoPromedio,desviacion);//HACER

                //Inicios más tardios de las actividades
                inicioTardioA5 = caminoCritico - duracionActividad5;
                inicioTardioA4 = caminoCritico - (duracionActividad5 + duracionActividad4);
                inicioTardioA3 = caminoCritico - duracionActividad3;
                inicioTardioA2 = caminoCritico - (duracionActividad5 + duracionActividad2);
                inicioTardioA1 = caminoCritico - (duracionActividad5 + duracionActividad4 + duracionActividad1);

                lineaActual[24] = inicioTardioA5;
                lineaActual[25] = inicioTardioA4;
                lineaActual[26] = inicioTardioA3;
                lineaActual[27] = inicioTardioA2;
                lineaActual[28] = inicioTardioA1;
                
                //Probabilidades que las actividades sean críticas
                if (caminoCritico == camino1)
                {
                    contadorA1 += 1;
                    contadorA4 += 1;
                    contadorA5 += 1;
                }
                if (caminoCritico == camino2)
                {
                    contadorA2 += 1;
                    contadorA5 += 1;
                }
                if (caminoCritico == camino3)
                {
                    contadorA3 += 1;
                }
                lineaActual[29] = contadorA1 * 100 / i;
                lineaActual[30] = contadorA2 * 100 / i;
                lineaActual[31] = contadorA3 * 100 / i;
                lineaActual[32] = contadorA4 * 100 / i;
                lineaActual[33] = contadorA5 * 100 / i;

                //Formación de intervalos,Actualización de contadores y cálculo de probabilidades
                if (i < 15) { intervalos.Add(caminoCritico); }
                if (i==14) { intervalos.Sort(); }
                if (i > 14)
                {
                    lineaActual[34] = 0;
                    lineaActual[35] = intervalos[0];
                    lineaActual[36] = intervalos[1];
                    lineaActual[37] = intervalos[2];
                    lineaActual[38] = intervalos[3];
                    lineaActual[39] = intervalos[4];
                    lineaActual[40] = intervalos[5];
                    lineaActual[41] = intervalos[6];
                    lineaActual[42] = intervalos[7];
                    lineaActual[43] = intervalos[8];
                    lineaActual[44] = intervalos[9];
                    lineaActual[45] = intervalos[10];
                    lineaActual[46] = intervalos[11];
                    lineaActual[47] = intervalos[12];
                    lineaActual[48] = intervalos[13];
                    lineaActual[49] = 99999;

                    contadorIntervalo1 = contar(caminoCritico,lineaActual[34],lineaActual[35],contadorIntervalo1);
                    contadorIntervalo2 = contar(caminoCritico, lineaActual[35], lineaActual[36], contadorIntervalo2);
                    contadorIntervalo3 = contar(caminoCritico, lineaActual[36], lineaActual[37], contadorIntervalo3);
                    contadorIntervalo4 = contar(caminoCritico, lineaActual[37], lineaActual[38], contadorIntervalo4);
                    contadorIntervalo5 = contar(caminoCritico, lineaActual[38], lineaActual[39], contadorIntervalo5);
                    contadorIntervalo6 = contar(caminoCritico, lineaActual[39], lineaActual[40], contadorIntervalo6);
                    contadorIntervalo7 = contar(caminoCritico, lineaActual[40], lineaActual[41], contadorIntervalo7);
                    contadorIntervalo8 = contar(caminoCritico, lineaActual[41], lineaActual[42], contadorIntervalo8);
                    contadorIntervalo9 = contar(caminoCritico, lineaActual[42], lineaActual[43], contadorIntervalo9);
                    contadorIntervalo10 = contar(caminoCritico, lineaActual[43], lineaActual[44], contadorIntervalo10);
                    contadorIntervalo11 = contar(caminoCritico, lineaActual[44], lineaActual[45], contadorIntervalo11);
                    contadorIntervalo12 = contar(caminoCritico, lineaActual[45], lineaActual[46], contadorIntervalo12);
                    contadorIntervalo13 = contar(caminoCritico, lineaActual[46], lineaActual[47], contadorIntervalo13);
                    contadorIntervalo14 = contar(caminoCritico, lineaActual[47], lineaActual[48], contadorIntervalo14);
                    contadorIntervalo15 = contar(caminoCritico, lineaActual[48], lineaActual[49], contadorIntervalo15);

                    lineaActual[50] = contadorIntervalo1 / (i - 14);
                    lineaActual[51] = contadorIntervalo2 / (i - 14);
                    lineaActual[52] = contadorIntervalo3 / (i - 14);
                    lineaActual[53] = contadorIntervalo4 / (i - 14);
                    lineaActual[54] = contadorIntervalo5 / (i - 14);
                    lineaActual[55] = contadorIntervalo6 / (i - 14);
                    lineaActual[56] = contadorIntervalo7 / (i - 14);
                    lineaActual[57] = contadorIntervalo8 / (i - 14);
                    lineaActual[58] = contadorIntervalo9 / (i - 14);
                    lineaActual[59] = contadorIntervalo10 / (i - 14);
                    lineaActual[60] = contadorIntervalo11 / (i - 14);
                    lineaActual[61] = contadorIntervalo12 / (i - 14);
                    lineaActual[62] = contadorIntervalo13 / (i - 14);
                    lineaActual[63] = contadorIntervalo14 / (i - 14);
                    lineaActual[64] = contadorIntervalo15 / (i - 14);

                    acumuladoIntervalo1 = lineaActual[50];
                    acumuladoIntervalo2 = lineaActual[51] + acumuladoIntervalo1;
                    acumuladoIntervalo3 = lineaActual[52] + acumuladoIntervalo2;
                    acumuladoIntervalo4 = lineaActual[53] + acumuladoIntervalo3;
                    acumuladoIntervalo5 = lineaActual[54] + acumuladoIntervalo4;
                    acumuladoIntervalo6 = lineaActual[55] + acumuladoIntervalo5;
                    acumuladoIntervalo7 = lineaActual[56] + acumuladoIntervalo6;
                    acumuladoIntervalo8 = lineaActual[57] + acumuladoIntervalo7;
                    acumuladoIntervalo9 = lineaActual[58] + acumuladoIntervalo8;
                    acumuladoIntervalo10 = lineaActual[59] + acumuladoIntervalo9;
                    acumuladoIntervalo11 = lineaActual[60] + acumuladoIntervalo10;
                    acumuladoIntervalo12 = lineaActual[61] + acumuladoIntervalo11;
                    acumuladoIntervalo13 = lineaActual[62] + acumuladoIntervalo12;
                    acumuladoIntervalo14 = lineaActual[63] + acumuladoIntervalo13;
                    acumuladoIntervalo15 = lineaActual[64] + acumuladoIntervalo14;

                    lineaActual[65] = acumuladoIntervalo1;
                    lineaActual[66] = acumuladoIntervalo2;
                    lineaActual[67] = acumuladoIntervalo3;
                    lineaActual[68] = acumuladoIntervalo4;
                    lineaActual[69] = acumuladoIntervalo5;
                    lineaActual[70] = acumuladoIntervalo6;
                    lineaActual[71] = acumuladoIntervalo7;
                    lineaActual[72] = acumuladoIntervalo8;
                    lineaActual[73] = acumuladoIntervalo9;
                    lineaActual[74] = acumuladoIntervalo10;
                    lineaActual[75] = acumuladoIntervalo11;
                    lineaActual[76] = acumuladoIntervalo12;
                    lineaActual[77] = acumuladoIntervalo13;
                    lineaActual[78] = acumuladoIntervalo14;
                    lineaActual[79] = acumuladoIntervalo15;
                }

                //Guardamos la linea actual antes de pasar a la siguiente iteración
                lineaAnterior = lineaActual;


                //Arma la tabla con rangos Desde y Hasta
                if (i >= desde && i <= hasta)
                {
                    row = tablaRango.NewRow();
                    for (int j = 0; j < lineaActual.Length; j++)
                    {
                        row[j] = truncador.truncar(lineaActual[j]);
                    }
                    tablaRango.Rows.Add(row);
                }


                //Arma la tabla que tiene los 2 últimos proyectos
                if (i >= cantidad-1)
                {
                    row = tablaUltimosProyectos.NewRow();
                    for (int j = 0; j < lineaActual.Length; j++)
                    {
                        row[j] = truncador.truncar(lineaActual[j]);
                    }
                    tablaUltimosProyectos.Rows.Add(row);
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
        private double obtenerMaximo(double a, double b, double c)
        {
            if (a >= b && a >= c) { return a; }
            if (b >= a && b >= c) { return b; }
            return c;
        }
        private void mostrarRango()
        {
            pantalla.mostrarRango(tablaRango,tablaUltimosProyectos);
        }


        private double contar(double num, double limInferior, double limSuperior, double contador)
        {
            if(num < limSuperior && num >= limInferior) { return contador + 1; }
            return contador;
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