using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Montecarlo.Soporte.Graficador
{
    public partial class Graficador : Form
    {
        public double[] tiemposPromedios { get; set; }
        public int[] proyectos { get; set; }

        public Graficador()
        {
            InitializeComponent();
        }
        private void Graficador_Load(object sender, EventArgs e)
        {
            List<double> tempObservada = new List<double>();
            List<string> tempLabels = new List<string>();

            var plt = new ScottPlot.Plot(800, 600);

            for (int i = 0; i < proyectos.Length; i++)
            {
                double duracion = tiemposPromedios[i];
                tempObservada.Add(duracion);
            }

            // generate random data to plot
            int pointCount = proyectos.Length;
            double[] xs = DataGen.Consecutive(pointCount);
            double[] y1 = tempObservada.ToArray();
            //double[] yError = new double[pointCount];

            // make the bar plot
            plt.PlotScatter(xs, y1,color:Color.Magenta);
            plt.XLabel("Proyecto");
            plt.YLabel("Duración promedio del proyecto(días)");
            plt.Legend(location: Alignment.UpperLeft);
            // customize the plot to make it look nicer
            plt.AxisAutoX();
            plt.AxisAutoY();
            plt.Grid(false, lineStyle: ScottPlot.LineStyle.Dot);


            //string imagePath = "C:\\\\Users\\" + Environment.UserName.ToString() + "\\histograma" + ".png";
            //plt.SaveFig(imagePath);
            //pictureBox1.Image = new Bitmap(imagePath);

            Random random = new Random();
            string rand = random.Next().ToString();
            string imagePath = "C:\\\\Users\\" + Environment.UserName.ToString() + "\\histograma" + rand + ".png";
            plt.SaveFig(imagePath);
            pictureBox1.Image = new Bitmap(imagePath);
        }
    }
}
