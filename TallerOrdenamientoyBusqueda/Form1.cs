using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerOrdenamientoyBusqueda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrdenamiento_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible=true;
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
            AbrirFormOrdenaQuickSort(new OrdenamientoQuickSort());
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
            AbrirFormOrdenaBubblekSort(new OrdenamientoBubbleSort());
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
            AbrirFormBusquedaBinaria(new BusquedaBinaria());
        }

        private void AbrirFormGenerarDatos(object formGDatos)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form fhGDatos = formGDatos as Form;
            fhGDatos.TopLevel = false;
            fhGDatos.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fhGDatos);
            this.panelContainer.Tag = formGDatos;
            fhGDatos.Show();

            (fhGDatos as GenerarDatos)?.MostrarDatosEnChart();

            SubmenuOrd.BringToFront();
        }

        private void AbrirFormOrdenaQuickSort(object formOrdQuickS)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form fhOrdQuick = formOrdQuickS as Form;
            fhOrdQuick.TopLevel = false;
            fhOrdQuick.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fhOrdQuick);
            this.panelContainer.Tag = formOrdQuickS;
            fhOrdQuick.Show();

            // Llamar al método para mostrar los datos en los gráficos
            (fhOrdQuick as OrdenamientoQuickSort)?.MostrarDatosEnChart();
        }

        private void AbrirFormOrdenaBubblekSort(object formOrdBubbleS)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form fhOrdBubble = formOrdBubbleS as Form;
            fhOrdBubble.TopLevel = false;
            fhOrdBubble.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fhOrdBubble);
            this.panelContainer.Tag = formOrdBubbleS;
            fhOrdBubble.Show();

            // Llamar al método para mostrar los datos en los gráficos
            (fhOrdBubble as OrdenamientoBubbleSort)?.MostrarDatosEnChart();
        }

        private void AbrirFormBusquedaBinaria(object formBusquedaBinaria)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);

            Form fhBusquedaBinaria = formBusquedaBinaria as Form;
            fhBusquedaBinaria.TopLevel = false;
            fhBusquedaBinaria.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fhBusquedaBinaria);
            this.panelContainer.Tag = formBusquedaBinaria;
            fhBusquedaBinaria.Show();

            // Llamar al método para mostrar los datos en los gráficos
            (fhBusquedaBinaria as OrdenamientoBubbleSort)?.MostrarDatosEnChart();
        }

        private void btnGenerarDatos_Click(object sender, EventArgs e)
        {
            AbrirFormGenerarDatos(new GenerarDatos());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormGenerarDatos(new GenerarDatos());
        }
    }
}
