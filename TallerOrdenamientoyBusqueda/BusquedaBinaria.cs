using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace TallerOrdenamientoyBusqueda
{
    public partial class BusquedaBinaria : Form
    {
        public BusquedaBinaria()
        {
            InitializeComponent();
        }

        // Agregar las columnas en el DataGridView al cargar el formulario
        private void BusquedaBinaria_Load(object sender, EventArgs e)
        {
            dtgResultados.Columns.Add("Algoritmo", "Algoritmo");
            dtgResultados.Columns.Add("TipoBusqueda", "Tipo de Búsqueda");
            dtgResultados.Columns.Add("Resultado", "Indice");
            dtgResultados.Columns.Add("Tiempo", "Tiempo (ms)");

            MostrarDatosEnChart();
        }

        private void LlenarCharter(Chart chart, int[] datos)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < datos.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, datos[i]);
            }
        }

        public void MostrarDatosEnChart()
        {
            // Mostrar los datos ordenados por BubbleSort
            if (DatosGlobales.DatosBOrd != null && DatosGlobales.DatosBOrd.Length > 0)
            {
                LlenarCharter(chtBDA, DatosGlobales.DatosBOrd);
            }

            if (DatosGlobales.DatosBLOA != null && DatosGlobales.DatosBLOA.Length > 0)
            {
                LlenarCharter(chtBDLOA, DatosGlobales.DatosBLOA);
            }

            if (DatosGlobales.DatosBLOD != null && DatosGlobales.DatosBLOD.Length > 0)
            {
                LlenarCharter(chtBLOD, DatosGlobales.DatosBLOD);
            }

            if (DatosGlobales.DatosBOA != null && DatosGlobales.DatosBOA.Length > 0)
            {
                LlenarCharter(chtBO, DatosGlobales.DatosBOA);
            }

            // Mostrar los datos ordenados por QuickSort
            if (DatosGlobales.DatosQOrd != null && DatosGlobales.DatosQOrd.Length > 0)
            {
                LlenarCharter(chtQDA, DatosGlobales.DatosQOrd);
            }

            if (DatosGlobales.DatosQLOA != null && DatosGlobales.DatosQLOA.Length > 0)
            {
                LlenarCharter(chtQDLOA, DatosGlobales.DatosQLOA);
            }

            if (DatosGlobales.DatosQLOD != null && DatosGlobales.DatosQLOD.Length > 0)
            {
                LlenarCharter(chtQLOD, DatosGlobales.DatosQLOD);
            }

            if (DatosGlobales.DatosQOA != null && DatosGlobales.DatosQOA.Length > 0)
            {
                LlenarCharter(chtQO, DatosGlobales.DatosQOA);
            }
        }

        public int busquedaBinaria(int[] lista, int valorBuscado)
        {
            int izquierda = 0;
            int derecha = lista.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;

                if (lista[medio] == valorBuscado)
                {
                    return medio;
                }

                // En orden descendente: cambiar las comparaciones
                else if (lista[medio] < valorBuscado)
                {
                    // Buscar en la mitad izquierda
                    derecha = medio - 1;
                }
                else
                {
                    // Buscar en la mitad derecha
                    izquierda = medio + 1;
                }
            }

            return -1;
        }


        public int BusquedaJump(int[] lista, int valorBuscado)
        {
            int n = lista.Length;
            int salto = (int)Math.Floor(Math.Sqrt(n)); // Tamaño del salto
            int prev = 0;

            // En lista descendente: avanzar mientras el valor sea mayor que el buscado
            while (lista[Math.Min(salto, n) - 1] > valorBuscado)
            {
                prev = salto;
                salto += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n) return -1;
            }

            // Búsqueda lineal en el bloque correspondiente
            for (int i = prev; i < Math.Min(salto, n); i++)
            {
                if (lista[i] == valorBuscado)
                {
                    return i;
                }
            }

            return -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out var valorBuscado))
            {
                MessageBox.Show("Por favor ingresa un número válido.");
                return;
            }

            if (!DatosGlobales.DatosBOrd.Contains(valorBuscado) && !DatosGlobales.DatosQOrd.Contains(valorBuscado))
            {
                MessageBox.Show("El valor no se encuentra en los datos.");
                return;
            }

            dtgResultados.Rows.Clear();
            chtResultados.Series[0].Points.Clear();

            // Datos y configuraciones
            var datasets = new (string Algoritmo, string Variante, int[] Datos)[]
{
    ("BubbleSort", "", DatosGlobales.DatosBOrd),
    ("BubbleSort", "LOA", DatosGlobales.DatosBLOA),
    ("BubbleSort", "LOD", DatosGlobales.DatosBLOD),
    ("BubbleSort", "OA", DatosGlobales.DatosBOA),
    ("QuickSort", "", DatosGlobales.DatosQOrd),
    ("QuickSort", "LOA", DatosGlobales.DatosQLOA),
    ("QuickSort", "LOD", DatosGlobales.DatosQLOD),
    ("QuickSort", "OA", DatosGlobales.DatosQOA)
};

            foreach (var (algoritmo, variante, datos) in datasets)
            {

                EjecutarBusquedaYMostrar(algoritmo, "Binaria", variante, datos, valorBuscado, busquedaBinaria);
                EjecutarBusquedaYMostrar(algoritmo, "Jump", variante, datos, valorBuscado, BusquedaJump);
            }
        }

        private void EjecutarBusquedaYMostrar(string algoritmo, string tipoBusqueda, string variante, int[] datos, int valorBuscado, Func<int[], int, int> metodoBusqueda)
        {
            var stopwatch = Stopwatch.StartNew();
            int resultado = metodoBusqueda(datos, valorBuscado);
            stopwatch.Stop();

            string nombre = $"{tipoBusqueda} {(string.IsNullOrEmpty(variante) ? "" : $"({variante})")}".Trim();
            string resultadoTexto = resultado == -1 ? "No encontrado" : resultado.ToString();

            dtgResultados.Rows.Add(algoritmo, nombre, resultadoTexto, stopwatch.Elapsed.TotalMilliseconds.ToString("F4"));

            chtResultados.Series[0].Points.AddXY($"{nombre} {algoritmo}", stopwatch.Elapsed.TotalMilliseconds);
        }



    }
}
