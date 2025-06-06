using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TallerOrdenamientoyBusqueda
{
    public partial class OrdenamientoQuickSort : Form
    {
        public OrdenamientoQuickSort()
        {
            InitializeComponent();
        }

        public void MostrarDatosEnChart()
        {
            // Asegúrate de que los datos existan
            if (DatosGlobales.DatosGenerados != null && DatosGlobales.DatosGenerados.Length > 0)
            {
                LlenarCharter(chtData, DatosGlobales.DatosGenerados);
            }

            if (DatosGlobales.DatosLOA != null && DatosGlobales.DatosLOA.Length > 0)
            {
                LlenarCharter(chtLOA, DatosGlobales.DatosLOA);
            }

            if (DatosGlobales.DatosLOD != null && DatosGlobales.DatosLOD.Length > 0)
            {
                LlenarCharter(chtLOD, DatosGlobales.DatosLOD);
            }

            if (DatosGlobales.DatosOA != null && DatosGlobales.DatosOA.Length > 0)
            {
                LlenarCharter(chtOA, DatosGlobales.DatosOA);
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

        private void LlenarCharter(Chart chart, int[] datos)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < datos.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, datos[i]);
            }
        }

        public int[] ordenarQuick(int[] lista)
        {
            return QuickSort(lista, 0, lista.Length - 1);
        }

        private int[] QuickSort(int[] lista, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int indiceParticion = Partition(lista, izquierda, derecha);

                // Recursión sobre la sublista de la izquierda
                QuickSort(lista, izquierda, indiceParticion - 1);

                // Recursión sobre la sublista de la derecha
                QuickSort(lista, indiceParticion + 1, derecha);
            }
            return lista;
        }

        private int Partition(int[] lista, int izquierda, int derecha)
        {
            int pivote = lista[derecha];
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                // Cambio para ordenar de forma descendente (mayor a menor)
                if (lista[j] > pivote)
                {
                    i++;
                    // Intercambiar
                    int temp = lista[i];
                    lista[i] = lista[j];
                    lista[j] = temp;
                }
            }

            // Intercambiar el pivote con el elemento en la posición correcta
            int temp2 = lista[i + 1];
            lista[i + 1] = lista[derecha];
            lista[derecha] = temp2;

            return i + 1;
        }
        private void btnGenerar2_Click(object sender, EventArgs e)
        {
            dtgResultados.Rows.Clear();

            // 1. Datos aleatorios
            var (listQOrd, tiempoQOrd) = MedirTiempoOrdenamiento(ordenarQuick, DatosGlobales.DatosGenerados);
            DatosGlobales.DatosQOrd = listQOrd;
            LlenarCharter(chtQDA, listQOrd);
            dtgResultados.Rows.Add("QuickSort (Aleatorio)", tiempoQOrd.ToString("F4"));
            DatosGlobales.TiempoQOrd1 = tiempoQOrd;

            // 2. Levemente ordenados ascendente
            var (listQLOA, tiempoQLOA) = MedirTiempoOrdenamiento(ordenarQuick, DatosGlobales.DatosLOA);
            DatosGlobales.DatosQLOA = listQLOA;
            LlenarCharter(chtQDLOA, listQLOA);
            dtgResultados.Rows.Add("QuickSort (LOA)", tiempoQLOA.ToString("F4"));
            DatosGlobales.TiempoQOrdLOA = tiempoQLOA;

            // 3. Levemente ordenados descendente
            var (listQLOD, tiempoQLOD) = MedirTiempoOrdenamiento(ordenarQuick, DatosGlobales.DatosLOD);
            DatosGlobales.DatosQLOD = listQLOD;
            LlenarCharter(chtQLOD, listQLOD);
            dtgResultados.Rows.Add("QuickSort (LOD)", tiempoQLOD.ToString("F4"));
            DatosGlobales.TiempoQOrdLOD = tiempoQLOD;

            // 4. Completamente ordenados ascendente
            var (listQOA, tiempoQOA) = MedirTiempoOrdenamiento(ordenarQuick, DatosGlobales.DatosOA);
            DatosGlobales.DatosQOA = listQOA;
            LlenarCharter(chtQO, listQOA);
            dtgResultados.Rows.Add("QuickSort (OA)", tiempoQOA.ToString("F4"));
            DatosGlobales.TiempoQOrd2 = tiempoQOA;
        }

        private void dtgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private (int[] resultado, double tiempoMs) MedirTiempoOrdenamiento(Func<int[], int[]> metodo, int[] datos)
        {
            var copia = (int[])datos.Clone();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            int[] resultado = metodo(copia);
            sw.Stop();
            return (resultado, sw.Elapsed.TotalMilliseconds);
        }

        private void OrdenamientoQuickSort_Load(object sender, EventArgs e)
        {
            dtgResultados.Columns.Add("Metodo", "Método de Ordenamiento");
            dtgResultados.Columns.Add("Tiempo", "Tiempo (ms)");

            MostrarDatosEnChart();
        }
    }

}
