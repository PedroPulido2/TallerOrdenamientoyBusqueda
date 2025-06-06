namespace TallerOrdenamientoyBusqueda
{
    partial class Resultados
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtOrdenamiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.chtBusqueda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chtOrdenamiento)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // chtOrdenamiento
            // 
            chartArea1.Name = "ChartArea1";
            this.chtOrdenamiento.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtOrdenamiento.Legends.Add(legend1);
            this.chtOrdenamiento.Location = new System.Drawing.Point(45, 192);
            this.chtOrdenamiento.Name = "chtOrdenamiento";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtOrdenamiento.Series.Add(series1);
            this.chtOrdenamiento.Size = new System.Drawing.Size(600, 400);
            this.chtOrdenamiento.TabIndex = 0;
            this.chtOrdenamiento.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Location = new System.Drawing.Point(23, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 95);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resultados y Comparaciones";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI Historic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(1174, 30);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(115, 46);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // chtBusqueda
            // 
            chartArea2.Name = "ChartArea1";
            this.chtBusqueda.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtBusqueda.Legends.Add(legend2);
            this.chtBusqueda.Location = new System.Drawing.Point(748, 192);
            this.chtBusqueda.Name = "chtBusqueda";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtBusqueda.Series.Add(series2);
            this.chtBusqueda.Size = new System.Drawing.Size(600, 400);
            this.chtBusqueda.TabIndex = 12;
            this.chtBusqueda.Text = "chart2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Metodos de Ordenamiento ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(750, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 38);
            this.label3.TabIndex = 13;
            this.label3.Text = "Metodos de Busqueda";
            // 
            // Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chtBusqueda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chtOrdenamiento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Resultados";
            this.Text = "Resultados";
            ((System.ComponentModel.ISupportInitialize)(this.chtOrdenamiento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtOrdenamiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}