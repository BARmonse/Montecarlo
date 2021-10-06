using Montecarlo.Soporte;
using Montecarlo.Soporte.GeneradorAleatorios;
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
        private GeneradorLenguaje generadorUniformeDelLenguaje;
        private IGenerador generadorActividad1;
        private IGenerador generadorActividad2;
        private IGenerador generadorActividad3;
        private IGenerador generadorActividad4;
        private IGenerador generadorActividad5;
        private DataTable tablaRango;
        private DataTable tablaUltimosProyectos;

        public GestorProyectos(Form1 pantalla)
        {
            this.pantalla = pantalla;
            this.lineaAnterior = new double[74];
            this.lineaActual = new double[74];
            this.truncador = new Truncador(2);
            this.generadorUniformeDelLenguaje = new GeneradorLenguaje(truncador);
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
            tabla.Columns.Add("Duración actividad 1");//lineaActual[1]
            tabla.Columns.Add("Duración actividad 2");//lineaActual[2]
            tabla.Columns.Add("Duración actividad 3");//lineaActual[3]
            tabla.Columns.Add("Duración actividad 4");//lineaActual[4]
            tabla.Columns.Add("Duración actividad5");//lineaActual[5]
            tabla.Columns.Add("Camino 1 (A1-A4-A5");//lineaActual[6]
            tabla.Columns.Add("Camino 2 (A2-A5)");//lineaActual[7]
            tabla.Columns.Add("Camino 3 (A3)");//lineaActual[8]
            tabla.Columns.Add("Duración Camino Crítico");//lineaActual[9]
            tabla.Columns.Add("Promedio");//lineaActual[10]
            tabla.Columns.Add("Varianza");//lineaActual[11]
            tabla.Columns.Add("Desviación");//lineaActual[12]
            tabla.Columns.Add("Maxima duración");//lineaActual[13]
            tabla.Columns.Add("Minima duración");//lineaActual[14]
            tabla.Columns.Add("Contador proyectos < 45");//lineaActual[15]
            tabla.Columns.Add("Probabilidad (%)");//lineaActual[16]
            tabla.Columns.Add("Días a fijar con 90% de confianza");//lineaActual[17]
            tabla.Columns.Add("Inicio más tardio A5");//lineaActual[18]
            tabla.Columns.Add("Inicio más tardio A4");//lineaActual[19]
            tabla.Columns.Add("Inicio más tardio A3");//lineaActual[20]
            tabla.Columns.Add("Inicio más tardio A2");//lineaActual[21]
            tabla.Columns.Add("Inicio más tardio A1");//lineaActual[22]
            tabla.Columns.Add("Prob. A1 Crítica");//lineaActual[23]
            tabla.Columns.Add("Prob. A2 Crítica");//lineaActual[24]
            tabla.Columns.Add("Prob. A3 Crítica");//lineaActual[25]
            tabla.Columns.Add("Prob. A4 Crítica");//lineaActual[26]
            tabla.Columns.Add("Prob. A5 Crítica");//lineaActual[27]
            tabla.Columns.Add("Inicio Intervalo 1");//lineaActual[28]
            tabla.Columns.Add("Inicio Intervalo 2");//lineaActual[29]
            tabla.Columns.Add("Inicio Intervalo 3");//lineaActual[30]
            tabla.Columns.Add("Inicio Intervalo 4");//lineaActual[31]
            tabla.Columns.Add("Inicio Intervalo 5");//lineaActual[32]
            tabla.Columns.Add("Inicio Intervalo 6");//lineaActual[33]
            tabla.Columns.Add("Inicio Intervalo 7");//lineaActual[34]
            tabla.Columns.Add("Inicio Intervalo 8");//lineaActual[35]
            tabla.Columns.Add("Inicio Intervalo 9");//lineaActual[36]
            tabla.Columns.Add("Inicio Intervalo 10");//lineaActual[37]
            tabla.Columns.Add("Inicio Intervalo 11");//lineaActual[38]
            tabla.Columns.Add("Inicio Intervalo 12");//lineaActual[39]
            tabla.Columns.Add("Inicio Intervalo 13");//lineaActual[40]
            tabla.Columns.Add("Inicio Intervalo 14");//lineaActual[41]
            tabla.Columns.Add("Inicio Intervalo 15");//lineaActual[42]
            tabla.Columns.Add("Fin");//lineaActual[43]

            tabla.Columns.Add("Prob Intervalo 1");//lineaActual[44]
            tabla.Columns.Add("Prob Intervalo 2");//lineaActual[45]
            tabla.Columns.Add("Prob Intervalo 3");//lineaActual[46]
            tabla.Columns.Add("Prob Intervalo 4");//lineaActual[47]
            tabla.Columns.Add("Prob Intervalo 5");//lineaActual[48]
            tabla.Columns.Add("Prob Intervalo 6");//lineaActual[49]
            tabla.Columns.Add("Prob Intervalo 7");//lineaActual[50]
            tabla.Columns.Add("Prob Intervalo 8");//lineaActual[51]
            tabla.Columns.Add("Prob Intervalo 9");//lineaActual[52]
            tabla.Columns.Add("Prob Intervalo 10");//lineaActual[53]
            tabla.Columns.Add("Prob Intervalo 11");//lineaActual[54]
            tabla.Columns.Add("Prob Intervalo 12");//lineaActual[55]
            tabla.Columns.Add("Prob Intervalo 13");//lineaActual[56]
            tabla.Columns.Add("Prob Intervalo 14");//lineaActual[57]
            tabla.Columns.Add("Prob Intervalo 15");//lineaActual[58]

            tabla.Columns.Add("Acum Intervalo 1");//lineaActual[59]
            tabla.Columns.Add("Acum Intervalo 2");//lineaActual[60]
            tabla.Columns.Add("Acum Intervalo 3");//lineaActual[61]
            tabla.Columns.Add("Acum Intervalo 4");//lineaActual[62]
            tabla.Columns.Add("Acum Intervalo 5");//lineaActual[63]
            tabla.Columns.Add("Acum Intervalo 6");//lineaActual[64]
            tabla.Columns.Add("Acum Intervalo 7");//lineaActual[65]
            tabla.Columns.Add("Acum Intervalo 8");//lineaActual[66]
            tabla.Columns.Add("Acum Intervalo 9");//lineaActual[67]
            tabla.Columns.Add("Acum Intervalo 10");//lineaActual[68]
            tabla.Columns.Add("Acum Intervalo 11");//lineaActual[69]
            tabla.Columns.Add("Acum Intervalo 12");//lineaActual[70]
            tabla.Columns.Add("Acum Intervalo 13");//lineaActual[71]
            tabla.Columns.Add("Acum Intervalo 14");//lineaActual[72]
            tabla.Columns.Add("Acum Intervalo 15");//lineaActual[73]
        }

        public void simular(int cantidad, int desde, int hasta)
        {
            procesar(cantidad, desde, hasta);
            mostrarRango();
            graficarTiempoPromedio();
        }

        private void procesar(int cantidad, int desde, int hasta)
        {
            int proyecto;

            double duracionActividad1;
            double duracionActividad2;
            double duracionActividad3;
            double duracionActividad4;
            double duracionActividad5;
            double camino1;
            double camino2;
            double camino3;
            double caminoCritico;
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

                //Duración de la actividad 1
                duracionActividad1 = generadorActividad1.obtenerAleatorio();
                lineaActual[1] = duracionActividad1;

                //Duración de la actividad 2
                duracionActividad2 = generadorActividad2.obtenerAleatorio();
                lineaActual[2] = duracionActividad2;

                //Duración de la actividad 3
                duracionActividad3 = generadorActividad3.obtenerAleatorio();
                lineaActual[3] = duracionActividad3;

                //Duración de la actividad 4
                duracionActividad4 = generadorActividad4.obtenerAleatorio();
                lineaActual[4] = duracionActividad4;

                //Duración de la actividad 5
                duracionActividad5 = generadorActividad5.obtenerAleatorio();
                lineaActual[5] = duracionActividad5;

                //Duración de caminos
                camino1 = duracionActividad1 + duracionActividad4 + duracionActividad5;
                camino2 = duracionActividad2 + duracionActividad5;
                camino3 = duracionActividad3;

                lineaActual[6] = camino1;
                lineaActual[7] = camino2;
                lineaActual[8] = camino3;

                //Duración del camino crítico
                caminoCritico = obtenerMaximo(camino1, camino2, camino3);
                lineaActual[9] = caminoCritico;
                
                //Tiempo promedio
                tiempoPromedio = ((i - 1) * lineaAnterior[10] + caminoCritico) / i;
                lineaActual[10] = tiempoPromedio;
                tiemposPromiedos.Add(tiempoPromedio);

                //Varianza
                if (i == 1) { varianza = 0; }
                else { varianza = ((i - 2) * lineaAnterior[11] + i * Math.Pow(tiempoPromedio - caminoCritico, 2) / (i - 1)) / (i - 1); }
                lineaActual[11] = varianza;

                //Desviacion
                desviacion = Math.Sqrt(varianza);
                lineaActual[12] = desviacion;

                //Máximo y Minimo
                if (i == 1)
                {
                    min = caminoCritico;
                    max = caminoCritico;
                }
                else
                {
                    max = obtenerMaximo(lineaAnterior[13], caminoCritico);
                    min = obtenerMinimo(lineaAnterior[14], caminoCritico);
                }

                lineaActual[13] = max;
                lineaActual[14] = min;

                //Contador de proyectos que duren menos de 45 días
                if (caminoCritico < 45)
                {
                    contador += 1;
                }
                lineaActual[15] = contador;

                //Probabilidad de que el proyecto dure menos de 45 días
                probabilidad = contador * 100 / i;
                lineaActual[16] = probabilidad;


                //Fecha a fijar con una confianza del 90%
                lineaActual[17] = TablaStudent.obtenerFechaAFijar(i, tiempoPromedio, desviacion);

                //Inicios más tardios de las actividades
                inicioTardioA5 = caminoCritico - duracionActividad5;
                inicioTardioA4 = caminoCritico - (duracionActividad5 + duracionActividad4);
                inicioTardioA3 = caminoCritico - duracionActividad3;
                inicioTardioA2 = caminoCritico - (duracionActividad5 + duracionActividad2);
                inicioTardioA1 = caminoCritico - (duracionActividad5 + duracionActividad4 + duracionActividad1);

                lineaActual[18] = inicioTardioA5;
                lineaActual[19] = inicioTardioA4;
                lineaActual[20] = inicioTardioA3;
                lineaActual[21] = inicioTardioA2;
                lineaActual[22] = inicioTardioA1;

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
                lineaActual[23] = contadorA1 * 100 / i;
                lineaActual[24] = contadorA2 * 100 / i;
                lineaActual[25] = contadorA3 * 100 / i;
                lineaActual[26] = contadorA4 * 100 / i;
                lineaActual[27] = contadorA5 * 100 / i;

                //Formación de intervalos,Actualización de contadores y cálculo de probabilidades
                if (i < 15) { intervalos.Add(caminoCritico); }
                if (i == 14) { intervalos.Sort(); }
                if (i > 14)
                {
                    lineaActual[28] = 0;
                    lineaActual[29] = intervalos[0];
                    lineaActual[30] = intervalos[1];
                    lineaActual[31] = intervalos[2];
                    lineaActual[32] = intervalos[3];
                    lineaActual[33] = intervalos[4];
                    lineaActual[34] = intervalos[5];
                    lineaActual[35] = intervalos[6];
                    lineaActual[36] = intervalos[7];
                    lineaActual[37] = intervalos[8];
                    lineaActual[38] = intervalos[9];
                    lineaActual[39] = intervalos[10];
                    lineaActual[40] = intervalos[11];
                    lineaActual[41] = intervalos[12];
                    lineaActual[42] = intervalos[13];
                    lineaActual[43] = 99999;

                    contadorIntervalo1 = contar(caminoCritico, lineaActual[28], lineaActual[29], contadorIntervalo1);
                    contadorIntervalo2 = contar(caminoCritico, lineaActual[29], lineaActual[30], contadorIntervalo2);
                    contadorIntervalo3 = contar(caminoCritico, lineaActual[30], lineaActual[31], contadorIntervalo3);
                    contadorIntervalo4 = contar(caminoCritico, lineaActual[31], lineaActual[32], contadorIntervalo4);
                    contadorIntervalo5 = contar(caminoCritico, lineaActual[32], lineaActual[33], contadorIntervalo5);
                    contadorIntervalo6 = contar(caminoCritico, lineaActual[33], lineaActual[34], contadorIntervalo6);
                    contadorIntervalo7 = contar(caminoCritico, lineaActual[34], lineaActual[35], contadorIntervalo7);
                    contadorIntervalo8 = contar(caminoCritico, lineaActual[35], lineaActual[36], contadorIntervalo8);
                    contadorIntervalo9 = contar(caminoCritico, lineaActual[36], lineaActual[37], contadorIntervalo9);
                    contadorIntervalo10 = contar(caminoCritico, lineaActual[37], lineaActual[38], contadorIntervalo10);
                    contadorIntervalo11 = contar(caminoCritico, lineaActual[38], lineaActual[39], contadorIntervalo11);
                    contadorIntervalo12 = contar(caminoCritico, lineaActual[39], lineaActual[40], contadorIntervalo12);
                    contadorIntervalo13 = contar(caminoCritico, lineaActual[40], lineaActual[41], contadorIntervalo13);
                    contadorIntervalo14 = contar(caminoCritico, lineaActual[41], lineaActual[42], contadorIntervalo14);
                    contadorIntervalo15 = contar(caminoCritico, lineaActual[42], lineaActual[43], contadorIntervalo15);

                    lineaActual[44] = contadorIntervalo1 / (i - 14);
                    lineaActual[45] = contadorIntervalo2 / (i - 14);
                    lineaActual[46] = contadorIntervalo3 / (i - 14);
                    lineaActual[47] = contadorIntervalo4 / (i - 14);
                    lineaActual[48] = contadorIntervalo5 / (i - 14);
                    lineaActual[49] = contadorIntervalo6 / (i - 14);
                    lineaActual[50] = contadorIntervalo7 / (i - 14);
                    lineaActual[51] = contadorIntervalo8 / (i - 14);
                    lineaActual[52] = contadorIntervalo9 / (i - 14);
                    lineaActual[53] = contadorIntervalo10 / (i - 14);
                    lineaActual[54] = contadorIntervalo11 / (i - 14);
                    lineaActual[55] = contadorIntervalo12 / (i - 14);
                    lineaActual[56] = contadorIntervalo13 / (i - 14);
                    lineaActual[57] = contadorIntervalo14 / (i - 14);
                    lineaActual[58] = contadorIntervalo15 / (i - 14);

                    acumuladoIntervalo1 = lineaActual[44];
                    acumuladoIntervalo2 = lineaActual[45] + acumuladoIntervalo1;
                    acumuladoIntervalo3 = lineaActual[46] + acumuladoIntervalo2;
                    acumuladoIntervalo4 = lineaActual[47] + acumuladoIntervalo3;
                    acumuladoIntervalo5 = lineaActual[48] + acumuladoIntervalo4;
                    acumuladoIntervalo6 = lineaActual[49] + acumuladoIntervalo5;
                    acumuladoIntervalo7 = lineaActual[50] + acumuladoIntervalo6;
                    acumuladoIntervalo8 = lineaActual[51] + acumuladoIntervalo7;
                    acumuladoIntervalo9 = lineaActual[52] + acumuladoIntervalo8;
                    acumuladoIntervalo10 = lineaActual[53] + acumuladoIntervalo9;
                    acumuladoIntervalo11 = lineaActual[54] + acumuladoIntervalo10;
                    acumuladoIntervalo12 = lineaActual[55] + acumuladoIntervalo11;
                    acumuladoIntervalo13 = lineaActual[56] + acumuladoIntervalo12;
                    acumuladoIntervalo14 = lineaActual[57] + acumuladoIntervalo13;
                    acumuladoIntervalo15 = lineaActual[58] + acumuladoIntervalo14;

                    lineaActual[59] = acumuladoIntervalo1;
                    lineaActual[60] = acumuladoIntervalo2;
                    lineaActual[61] = acumuladoIntervalo3;
                    lineaActual[62] = acumuladoIntervalo4;
                    lineaActual[63] = acumuladoIntervalo5;
                    lineaActual[64] = acumuladoIntervalo6;
                    lineaActual[65] = acumuladoIntervalo7;
                    lineaActual[66] = acumuladoIntervalo8;
                    lineaActual[67] = acumuladoIntervalo9;
                    lineaActual[68] = acumuladoIntervalo10;
                    lineaActual[69] = acumuladoIntervalo11;
                    lineaActual[70] = acumuladoIntervalo12;
                    lineaActual[71] = acumuladoIntervalo13;
                    lineaActual[72] = acumuladoIntervalo14;
                    lineaActual[73] = acumuladoIntervalo15;
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
                if (i >= cantidad - 1)
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
            pantalla.mostrarRango(tablaRango, tablaUltimosProyectos);
        }


        private double contar(double num, double limInferior, double limSuperior, double contador)
        {
            if (num < limSuperior && num >= limInferior) { return contador + 1; }
            return contador;
        }

        private void graficarTiempoPromedio()
        {
            Graficador graficador = new Graficador();
            graficador.proyectos = this.proyectos.ToArray();
            graficador.tiemposPromedios = this.tiemposPromiedos.ToArray();
            graficador.Show();
        }

        // actividad 1
        public void tomarDistribucionUniformeActividad1(double extremoInferior, double extremoSuperior)
        {
            this.generadorActividad1 = new GeneradorUniformeAB(generadorUniformeDelLenguaje, extremoInferior, extremoSuperior);
        }

        public void tomarDistribucionExponencialActividad1(double mediaExponencial)
        {
            this.generadorActividad1 = new GeneradorExponencialNegativa(generadorUniformeDelLenguaje, mediaExponencial);
        }

        public void tomarDistribucionNormalActividad1(double mediaNormal, double desviacionNormal)
        {
            this.generadorActividad1 = new GeneradorNormal(generadorUniformeDelLenguaje, mediaNormal, desviacionNormal);
        }

        // actividad 2 

        public void tomarDistribucionUniformeActividad2(double extremoInferior, double extremoSuperior)
        {
            this.generadorActividad2 = new GeneradorUniformeAB(generadorUniformeDelLenguaje, extremoInferior, extremoSuperior);
        }

        public void tomarDistribucionExponencialActividad2(double mediaExponencial)
        {
            this.generadorActividad2 = new GeneradorExponencialNegativa(generadorUniformeDelLenguaje, mediaExponencial);
        }

        public void tomarDistribucionNormalActividad2(double mediaNormal, double desviacionNormal)
        {
            this.generadorActividad2 = new GeneradorNormal(generadorUniformeDelLenguaje, mediaNormal, desviacionNormal);
        }


        // actividad 3

        public void tomarDistribucionUniformeActividad3(double extremoInferior, double  extremoSuperior)
        {
            this.generadorActividad3 = new GeneradorUniformeAB(generadorUniformeDelLenguaje, extremoInferior, extremoSuperior);
        }

        public void tomarDistribucionExponencialActividad3(double mediaExponencial)
        {
            this.generadorActividad3 = new GeneradorExponencialNegativa(generadorUniformeDelLenguaje, mediaExponencial);
        }

        public void tomarDistribucionNormalActividad3(double mediaNormal, double desviacionNormal)
        {
            this.generadorActividad3 = new GeneradorNormal(generadorUniformeDelLenguaje, mediaNormal, desviacionNormal);
        }

        // actividad 4

        public void tomarDistribucionUniformeActividad4(double extremoInferior, double extremoSuperior)
        {
            this.generadorActividad4 = new GeneradorUniformeAB(generadorUniformeDelLenguaje, extremoInferior, extremoSuperior);
        }

        public void tomarDistribucionExponencialActividad4(double mediaExponencial)
        {
            this.generadorActividad4 = new GeneradorExponencialNegativa(generadorUniformeDelLenguaje, mediaExponencial);
        }

        public void tomarDistribucionNormalActividad4(double mediaNormal, double desviacionNormal)
        {
            this.generadorActividad4 = new GeneradorNormal(generadorUniformeDelLenguaje, mediaNormal, desviacionNormal);
        }

        // actividad 5

        public void tomarDistribucionUniformeActividad5(double extremoInferior, double extremoSuperior)
        {
            this.generadorActividad5 = new GeneradorUniformeAB(generadorUniformeDelLenguaje, extremoInferior, extremoSuperior);
        }

        public void tomarDistribucionExponencialActividad5(double mediaExponencial)
        {
            this.generadorActividad5 = new GeneradorExponencialNegativa(generadorUniformeDelLenguaje, mediaExponencial);
        }

        public void tomarDistribucionNormalActividad5(double mediaNormal, double desviacionNormal)
        {
            this.generadorActividad5 = new GeneradorNormal(generadorUniformeDelLenguaje, mediaNormal, desviacionNormal);
        }
    }
}