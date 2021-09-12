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
        DataTable table;

        int cant;
        int limInferiorAct1;
        int limSuperiorAct1;
        int limInferiorAct2;
        int limSuperiorAct2;
        int mediaAct3;
        int limInferiorAct4;
        int limSuperiorAct4;
        int mediaAct5;

        public Form1()
        {
            InitializeComponent();
        }

        private void tomarDatos()
        {
            cant = int.Parse(cantidad.Text);
            limInferiorAct1 = int.Parse(limInferiorActividad1.Text);
            limSuperiorAct1 = int.Parse(limSuperiorActividad1.Text);
            limInferiorAct2 = int.Parse(limInferiorActividad2.Text);
            limSuperiorAct2 = int.Parse(limSuperiorActividad2.Text);
            mediaAct3 = int.Parse(mediaActividad3.Text);
            limInferiorAct4 = int.Parse(limInferiorActividad4.Text);
            limSuperiorAct4 = int.Parse(limSuperiorActividad4.Text);
            mediaAct5 = int.Parse(mediaActividad5.Text);
        }

        private void crearTabla()
        {
            table = new DataTable();
            table.Clear();

            table.Columns.Add("Proyecto");
            table.Columns.Add("RND");
            table.Columns.Add("Duración actividad1");
            table.Columns.Add("RND");
            table.Columns.Add("Duración actividad2");
            table.Columns.Add("RND");
            table.Columns.Add("Duración actividad3");
            table.Columns.Add("RND");
            table.Columns.Add("Duración actividad4");
            table.Columns.Add("Finalización actividad4");
            table.Columns.Add("RND");
            table.Columns.Add("Duración actividad5");
            table.Columns.Add("Finalización actividad5");
            table.Columns.Add("Tiempo Total");
            table.Columns.Add("Tiempo promedio");
            table.Columns.Add("Maximo tiempo total");
            table.Columns.Add("Minimo tiempo total");
        }
    }
}
