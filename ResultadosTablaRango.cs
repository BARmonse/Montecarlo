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
    public partial class ResultadosTablaRango : Form
    {
        public ResultadosTablaRango()
        {
            InitializeComponent();
        }

        public void mostrarRango(DataTable tablaRango,DataTable tablaUltimosProyectos)
        {
            this.grdRangoResultados.DataSource = tablaRango;
            this.grdUltimosProyectos.DataSource = tablaUltimosProyectos;
        }
    }
}
