using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Montecarlo
{
    public partial class Form1 : Form
    {
        GestorProyectos gestor;

        int cant;
        int desde;
        int hasta;

        double limInferiorAct1;
        double limSuperiorAct1;
        double limInferiorAct2;
        double limSuperiorAct2;
        double mediaAct3;
        double limInferiorAct4;
        double limSuperiorAct4;
        double mediaAct5;

        public Form1()
        {
            InitializeComponent();
        }

        private void tomarDatos()
        {
            cant = int.Parse(cantidad.Text);
            desde = int.Parse(mostrarDesde.Text);
            hasta = int.Parse(mostrarHasta.Text);

            limInferiorAct1 = double.Parse(limInferiorActividad1.Text);
            limSuperiorAct1 = double.Parse(limSuperiorActividad1.Text);
            limInferiorAct2 = double.Parse(limInferiorActividad2.Text);
            limSuperiorAct2 = double.Parse(limSuperiorActividad2.Text);
            mediaAct3 = double.Parse(mediaActividad3.Text);
            limInferiorAct4 = double.Parse(limInferiorActividad4.Text);
            limSuperiorAct4 = double.Parse(limSuperiorActividad4.Text);
            mediaAct5 = double.Parse(mediaActividad5.Text);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            tomarDatos();
            if (limInferiorAct1 < 0 || limSuperiorAct1 < 0 || limInferiorAct1 >= limSuperiorAct1 ||
                limInferiorAct2 < 0 || limSuperiorAct2 < 0 || limInferiorAct2 >= limSuperiorAct2 ||
                limInferiorAct4 < 0 || limSuperiorAct4 < 0 || limInferiorAct4 >= limSuperiorAct4 || 
                mediaAct3 <= 0 || mediaAct5 <= 0 || desde < 0 || desde >= hasta) { return; }

            gestor = new GestorProyectos(this);
            gestor.simular(cant, limInferiorAct1, limSuperiorAct1, limInferiorAct2, limSuperiorAct2, mediaAct3, limInferiorAct4, limSuperiorAct4, mediaAct5, desde, hasta);
        }

        public void mostrarRango(DataTable tablaRango)
        {
            ResultadosTablaRango resultados = new ResultadosTablaRango();
            resultados.mostrarRango(tablaRango);
            resultados.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}