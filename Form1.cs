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
        private string[] distribuciones1 = new string[] { "exponencial", "normal", "uniforme" };
        private string[] distribuciones2 = new string[] { "exponencial", "normal", "uniforme" };
        private string[] distribuciones3 = new string[] { "exponencial", "normal", "uniforme" };
        private string[] distribuciones4 = new string[] { "exponencial", "normal", "uniforme" };
        private string[] distribuciones5 = new string[] { "exponencial", "normal", "uniforme" };
        private string distribucionActividad1;
        private string distribucionActividad2;
        private string distribucionActividad3;
        private string distribucionActividad4;
        private string distribucionActividad5;

        int cant;
        int desde;
        int hasta;

        double limInferiorAct1;
        double limSuperiorAct1;
        double limInferiorAct2;
        double limSuperiorAct2;
        double limInferiorAct3;
        double limSuperiorAct3;
        double limInferiorAct4;
        double limSuperiorAct4;
        double limInferiorAct5;
        double limSuperiorAct5;

        double mediaExponencialAct1;
        double mediaExponencialAct2;
        double mediaExponencialAct3;
        double mediaExponencialAct4;
        double mediaExponencialAct5;

        double mediaNormalAct1;
        double desvAct1;
        double mediaNormalAct2;
        double desvAct2;
        double mediaNormalAct3;
        double desvAct3;
        double mediaNormalAct4;
        double desvAct4;
        double mediaNormalAct5;
        double desvAct5;

        public Form1()
        {
            InitializeComponent();
        }

        private void tomarDatos()
        {
            cant = int.Parse(cantidad.Text);
            desde = int.Parse(mostrarDesde.Text);
            hasta = int.Parse(mostrarHasta.Text);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            tomarDatos();
            if (desde < 0 || desde >= hasta || cant <=0) { return; }
            gestor = new GestorProyectos(this);
            this.tomarDistribucionActividad1();
            this.tomarDistribucionActividad2();
            this.tomarDistribucionActividad3();
            this.tomarDistribucionActividad4();
            this.tomarDistribucionActividad5();
            gestor.simular(cant, desde, hasta);
        }

        public void mostrarRango(DataTable tablaRango,DataTable tablaUltimosProyectos)
        {
            ResultadosTablaRango resultados = new ResultadosTablaRango();
            resultados.mostrarRango(tablaRango,tablaUltimosProyectos);
            resultados.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbActividad1.DataSource = distribuciones1;
            cbActividad2.DataSource = distribuciones2;
            cbActividad3.DataSource = distribuciones3;
            cbActividad4.DataSource = distribuciones4;
            cbActividad5.DataSource = distribuciones5;

            cbActividad1.SelectedItem = distribuciones1[2].ToString();
            cbActividad2.SelectedItem = distribuciones2[2].ToString();
            cbActividad3.SelectedItem = distribuciones3[0].ToString();
            cbActividad4.SelectedItem = distribuciones4[2].ToString();
            cbActividad5.SelectedItem = distribuciones5[0].ToString();
        }

        

        private void cbActividad1_SelectedValueChanged(object sender, EventArgs e)
        {
            distribucionActividad1 = cbActividad1.SelectedItem.ToString();
            switch (distribucionActividad1)
            {
                case "uniforme":
                    mostrarUniforme1();
                    break;
                case "normal":
                    mostrarNormal1();
                    break;
                case "exponencial":
                    mostrarExponencial1();
                    break;
            }
        }

        private void cbActividad2_SelectedValueChanged(object sender, EventArgs e)
        {
            distribucionActividad2 = cbActividad2.SelectedItem.ToString();

            switch (distribucionActividad2)
            {
                case "uniforme":
                    mostrarUniforme2();
                    break;
                case "normal":
                    mostrarNormal2();
                    break;
                case "exponencial":
                    mostrarExponencial2();
                    break;
            }
        }

        private void cbActividad3_SelectedValueChanged(object sender, EventArgs e)
        {
            distribucionActividad3 = cbActividad3.SelectedItem.ToString();

            switch (distribucionActividad3)
            {
                case "uniforme":
                    mostrarUniforme3();
                    break;
                case "normal":
                    mostrarNormal3();
                    break;
                case "exponencial":
                    mostrarExponencial3();
                    break;
            }
        }

        private void cbActividad4_SelectedValueChanged(object sender, EventArgs e)
        {
            distribucionActividad4 = cbActividad4.SelectedItem.ToString();
            switch (distribucionActividad4)
            {
                case "uniforme":
                    mostrarUniforme4();
                    break;
                case "normal":
                    mostrarNormal4();
                    break;
                case "exponencial":
                    mostrarExponencial4();
                    break;
            }
        }

        private void cbActividad5_SelectedValueChanged(object sender, EventArgs e)
        {
            distribucionActividad5 = cbActividad5.SelectedItem.ToString();
            switch (distribucionActividad5)
            {
                case "uniforme":
                    mostrarUniforme5();
                    break;
                case "normal":
                    mostrarNormal5();
                    break;
                case "exponencial":
                    mostrarExponencial5();
                    break;
            }
        }
        
        private void mostrarUniforme1()
        {
            gbUniformeActividad1.Visible = true;
            gbExponencialActividad1.Visible = false;
            gbNormalActividad1.Visible = false;
            return;
        }

        private void mostrarNormal1()
        {
            gbNormalActividad1.Visible = true;
            gbUniformeActividad1.Visible = false;
            gbExponencialActividad1.Visible = false;
            return;
        }

        private void mostrarExponencial1()
        {
            gbExponencialActividad1.Visible = true;
            gbNormalActividad1.Visible = false;
            gbUniformeActividad1.Visible = false;
            return;
        }
        private void mostrarUniforme2()
        {
            gbUniformeActividad2.Visible = true;
            gbExponencialActividad2.Visible = false;
            gbNormalActividad2.Visible = false;
            return;
        }

        private void mostrarNormal2()
        {
            gbNormalActividad2.Visible = true;
            gbUniformeActividad2.Visible = false;
            gbExponencialActividad2.Visible = false;
            return;
        }

        private void mostrarExponencial2()
        {
            gbExponencialActividad2.Visible = true;
            gbNormalActividad2.Visible = false;
            gbUniformeActividad2.Visible = false;
            return;
        }
        private void mostrarUniforme3()
        {
            gbUniformeActividad3.Visible = true;
            gbExponencialActividad3.Visible = false;
            gbNormalActividad3.Visible = false;
            return;
        }

        private void mostrarNormal3()
        {
            gbNormalActividad3.Visible = true;
            gbUniformeActividad3.Visible = false;
            gbExponencialActividad3.Visible = false;
            return;
        }

        private void mostrarExponencial3()
        {
            gbExponencialActividad3.Visible = true;
            gbNormalActividad3.Visible = false;
            gbUniformeActividad3.Visible = false;
            return;
        }

        private void mostrarUniforme4()
        {
            gbUniformeActividad4.Visible = true;
            gbExponencialActividad4.Visible = false;
            gbNormalActividad4.Visible = false;
            return;
        }

        private void mostrarNormal4()
        {
            gbNormalActividad4.Visible = true;
            gbUniformeActividad4.Visible = false;
            gbExponencialActividad4.Visible = false;
            return;
        }

        private void mostrarExponencial4()
        {
            gbExponencialActividad4.Visible = true;
            gbNormalActividad4.Visible = false;
            gbUniformeActividad4.Visible = false;
            return;
        }

        private void mostrarUniforme5()
        {
            gbUniformeActividad5.Visible = true;
            gbExponencialActividad5.Visible = false;
            gbNormalActividad5.Visible = false;
            return;
        }

        private void mostrarNormal5()
        {
            gbNormalActividad5.Visible = true;
            gbUniformeActividad5.Visible = false;
            gbExponencialActividad5.Visible = false;
            return;
        }

        private void mostrarExponencial5()
        {
            gbExponencialActividad5.Visible = true;
            gbNormalActividad5.Visible = false;
            gbUniformeActividad5.Visible = false;
            return;
        }

        private void tomarDistribucionActividad1()
        {
            switch (distribucionActividad1)
            {
                case "uniforme":
                    this.tomarParametrosUniformeActividad1();
                    gestor.tomarDistribucionUniformeActividad1(limInferiorAct1, limSuperiorAct1);
                break;
                case "exponencial":
                    this.tomarParametrosExponencialActividad1();
                    gestor.tomarDistribucionExponencialActividad1(mediaExponencialAct1);
                    break;
                case "normal":
                    this.tomarParametrosNormalActividad1();
                    gestor.tomarDistribucionNormalActividad1(mediaNormalAct1,desvAct1);
                break;
            }
        }
        private void tomarDistribucionActividad2()
        {
            switch (distribucionActividad2)
            {
                case "uniforme":
                    this.tomarParametrosUniformeActividad2();
                    gestor.tomarDistribucionUniformeActividad2(limInferiorAct2, limSuperiorAct2);
                    break;
                case "exponencial":
                    this.tomarParametrosExponencialActividad2();
                    gestor.tomarDistribucionExponencialActividad2(mediaExponencialAct2);
                    break;
                case "normal":
                    this.tomarParametrosNormalActividad2();
                    gestor.tomarDistribucionNormalActividad2(mediaNormalAct2,desvAct2);
                break;
            }
        }
        private void tomarDistribucionActividad3()
        {
            switch (distribucionActividad3)
            {
                case "uniforme":
                    this.tomarParametrosUniformeActividad3();
                    gestor.tomarDistribucionUniformeActividad3(limInferiorAct3, limSuperiorAct3);
                    break;
                case "exponencial":
                    this.tomarParametrosExponencialActividad3();
                    gestor.tomarDistribucionExponencialActividad3(mediaExponencialAct3);
                    break;
                case "normal":
                    this.tomarParametrosNormalActividad3();
                    gestor.tomarDistribucionNormalActividad3(mediaNormalAct3,desvAct3);
                break;
            }
        }
        private void tomarDistribucionActividad4()
        {
            switch (distribucionActividad4)
            {
                case "uniforme":
                    this.tomarParametrosUniformeActividad4();
                    gestor.tomarDistribucionUniformeActividad4(limInferiorAct4, limSuperiorAct4);
                    break;
                case "exponencial":
                    this.tomarParametrosExponencialActividad4();
                    gestor.tomarDistribucionExponencialActividad4(mediaExponencialAct4);
                    break;
                case "normal":
                    this.tomarParametrosNormalActividad4();
                    gestor.tomarDistribucionNormalActividad4(mediaNormalAct4,desvAct4);
                break;
            }
        }
        private void tomarDistribucionActividad5()
        {
            switch (distribucionActividad5)
            {
                case "uniforme":
                    this.tomarParametrosUniformeActividad5();
                    gestor.tomarDistribucionUniformeActividad5(limInferiorAct5, limSuperiorAct5);
                    break;
                case "exponencial":
                    this.tomarParametrosExponencialActividad5();
                    gestor.tomarDistribucionExponencialActividad5(mediaExponencialAct5);
                    break;
                case "normal":
                    this.tomarParametrosNormalActividad5();
                    gestor.tomarDistribucionNormalActividad5(mediaNormalAct5,desvAct5);
                break;
            }
        }

        private void tomarParametrosUniformeActividad1()
        {
            if (double.Parse(limInferiorActividad1.Text) < 0 || double.Parse(limSuperiorActividad1.Text) <= 0 || double.Parse(limInferiorActividad1.Text) >= double.Parse(limSuperiorActividad1.Text)) { return; }
            limInferiorAct1 = double.Parse(limInferiorActividad1.Text);
            limSuperiorAct1 = double.Parse(limSuperiorActividad1.Text);
            
        }
        private void tomarParametrosUniformeActividad2()
        {
            if (double.Parse(limInferiorActividad2.Text) < 0 || double.Parse(limSuperiorActividad2.Text) <= 0 || double.Parse(limInferiorActividad2.Text) >= double.Parse(limSuperiorActividad2.Text)) { return; }
            limInferiorAct2 = double.Parse(limInferiorActividad2.Text);
            limSuperiorAct2 = double.Parse(limSuperiorActividad2.Text);
        }
        private void tomarParametrosUniformeActividad3()
        {
            if (double.Parse(limInferiorActividad3.Text) < 0 || double.Parse(limSuperiorActividad3.Text) <= 0 || double.Parse(limInferiorActividad3.Text) >= double.Parse(limSuperiorActividad3.Text)) { return; }
            limInferiorAct3 = double.Parse(limInferiorActividad3.Text);
            limSuperiorAct3 = double.Parse(limSuperiorActividad3.Text);
        }
        private void tomarParametrosUniformeActividad4()
        {
            if (double.Parse(limInferiorActividad4.Text) < 0 || double.Parse(limSuperiorActividad4.Text) <= 0 || double.Parse(limInferiorActividad4.Text) >= double.Parse(limSuperiorActividad4.Text)) { return; }
            limInferiorAct4 = double.Parse(limInferiorActividad4.Text);
            limSuperiorAct4 = double.Parse(limSuperiorActividad4.Text);
        }
        private void tomarParametrosUniformeActividad5()
        {
            if (double.Parse(limInferiorActividad5.Text) < 0 || double.Parse(limSuperiorActividad5.Text) <= 0 || double.Parse(limInferiorActividad5.Text) >= double.Parse(limSuperiorActividad5.Text)) { return; }
            limInferiorAct5 = double.Parse(limInferiorActividad5.Text);
            limSuperiorAct5 = double.Parse(limSuperiorActividad5.Text);
        }


        private void tomarParametrosExponencialActividad1()
        {
            if (double.Parse(mediaExponencialActividad1.Text) <= 0) { return; }
            mediaExponencialAct1 = double.Parse(mediaExponencialActividad1.Text);
        }
        private void tomarParametrosExponencialActividad2()
        {
            if (double.Parse(mediaExponencialActividad2.Text) <= 0) { return; }
            mediaExponencialAct2 = double.Parse(mediaExponencialActividad2.Text);
        }
        private void tomarParametrosExponencialActividad3()
        {
            if (double.Parse(mediaExponencialActividad3.Text) <= 0) { return; }
            mediaExponencialAct3 = double.Parse(mediaExponencialActividad3.Text);
        }
        private void tomarParametrosExponencialActividad4()
        {
            if (double.Parse(mediaExponencialActividad4.Text) <= 0) { return; }
            mediaExponencialAct4 = double.Parse(mediaExponencialActividad4.Text);
        }
        private void tomarParametrosExponencialActividad5()
        {
            if (double.Parse(mediaExponencialActividad5.Text) <= 0) { return; }
            mediaExponencialAct5 = double.Parse(mediaExponencialActividad5.Text);
        }


        private void tomarParametrosNormalActividad1()
        {
            if (double.Parse(mediaNormalActividad1.Text) <= 0 || double.Parse(desvActividad1.Text) <= 0) { return; }
            mediaNormalAct1 = double.Parse(mediaNormalActividad1.Text);
            desvAct1 = double.Parse(desvActividad1.Text);
        
        }
        private void tomarParametrosNormalActividad2()
        {
            if (double.Parse(mediaNormalActividad2.Text) <= 0 || double.Parse(desvActividad2.Text) <= 0) { return; }
            mediaNormalAct2 = double.Parse(mediaNormalActividad2.Text);
            desvAct2 = double.Parse(desvActividad2.Text);
        }
        private void tomarParametrosNormalActividad3()
        {
            if (double.Parse(mediaNormalActividad3.Text) <= 0 || double.Parse(desvActividad3.Text) <= 0) { return; }
            mediaNormalAct3 = double.Parse(mediaNormalActividad3.Text);
            desvAct3 = double.Parse(desvActividad3.Text);
        }
        private void tomarParametrosNormalActividad4()
        {
            if (double.Parse(mediaNormalActividad4.Text) <= 0 || double.Parse(desvActividad4.Text) <= 0) { return; }
            mediaNormalAct4 = double.Parse(mediaNormalActividad4.Text);
            desvAct4 = double.Parse(desvActividad4.Text);
        }
        private void tomarParametrosNormalActividad5()
        {
            if (double.Parse(mediaNormalActividad5.Text) <= 0 || double.Parse(desvActividad5.Text) <= 0) { return; }
            mediaNormalAct5 = double.Parse(mediaNormalActividad5.Text);
            desvAct5 = double.Parse(desvActividad5.Text);
        }
    }
}