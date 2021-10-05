
namespace Montecarlo
{
    partial class ResultadosTablaRango
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdRangoResultados = new System.Windows.Forms.DataGridView();
            this.grdUltimosProyectos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdRangoResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltimosProyectos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRangoResultados
            // 
            this.grdRangoResultados.AllowUserToAddRows = false;
            this.grdRangoResultados.AllowUserToDeleteRows = false;
            this.grdRangoResultados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdRangoResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRangoResultados.Location = new System.Drawing.Point(3, 52);
            this.grdRangoResultados.Name = "grdRangoResultados";
            this.grdRangoResultados.ReadOnly = true;
            this.grdRangoResultados.RowTemplate.Height = 25;
            this.grdRangoResultados.Size = new System.Drawing.Size(1160, 363);
            this.grdRangoResultados.TabIndex = 0;
            // 
            // grdUltimosProyectos
            // 
            this.grdUltimosProyectos.AllowUserToAddRows = false;
            this.grdUltimosProyectos.AllowUserToDeleteRows = false;
            this.grdUltimosProyectos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdUltimosProyectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUltimosProyectos.Location = new System.Drawing.Point(3, 444);
            this.grdUltimosProyectos.Name = "grdUltimosProyectos";
            this.grdUltimosProyectos.ReadOnly = true;
            this.grdUltimosProyectos.RowTemplate.Height = 25;
            this.grdUltimosProyectos.Size = new System.Drawing.Size(1160, 104);
            this.grdUltimosProyectos.TabIndex = 1;
            // 
            // ResultadosTablaRango
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 560);
            this.Controls.Add(this.grdUltimosProyectos);
            this.Controls.Add(this.grdRangoResultados);
            this.Name = "ResultadosTablaRango";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultadosTablaRango";
            ((System.ComponentModel.ISupportInitialize)(this.grdRangoResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltimosProyectos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdRangoResultados;
        private System.Windows.Forms.DataGridView grdUltimosProyectos;
    }
}