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
            SubmenuBusqueda.Visible=false;
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible = true;
            SubmenuOrd.Visible = false;
        }

        private void btnBinaria_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible=false;
        }

        private void btnJumpSearch_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible=false;
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

            SubmenuBusqueda.BringToFront();
            SubmenuOrd.BringToFront();
        }

        private void btnGenerarDatos_Click(object sender, EventArgs e)
        {
            AbrirFormGenerarDatos(new GenerarDatos());
        }
    }
}
