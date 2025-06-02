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
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            SubmenuOrd.Visible = false;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible = true;
        }

        private void btnBinaria_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible=false;
        }

        private void btnJumpSearch_Click(object sender, EventArgs e)
        {
            SubmenuBusqueda.Visible=false;
        }
    }
}
