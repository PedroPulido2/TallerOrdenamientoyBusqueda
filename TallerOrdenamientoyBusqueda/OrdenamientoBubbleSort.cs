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
    public partial class OrdenamientoBubbleSort : Form
    {
        public OrdenamientoBubbleSort()
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
        }

        private void LlenarCharter(Chart chart, int[] datos)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < datos.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, datos[i]);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dtgResultados.Rows.Clear(); // Limpiar resultados anteriores

            // 1. Aleatorios
            var (listBOrd, tiempoBOrd) = MedirTiempoOrdenamiento(ordenarBubble, (int[])DatosGlobales.DatosGenerados.Clone());
            DatosGlobales.DatosBOrd = listBOrd;
            LlenarCharter(chtBDA, listBOrd);
            dtgResultados.Rows.Add("BubbleSort - Aleatorios", tiempoBOrd.ToString("F4"));
            DatosGlobales.TiempoBOrd1 = tiempoBOrd;

            // 2. Levemente ordenados ascendente
            var (listBLOA, tiempoBLOA) = MedirTiempoOrdenamiento(ordenarBubble, (int[])DatosGlobales.DatosLOA.Clone());
            DatosGlobales.DatosBLOA = listBLOA;
            LlenarCharter(chtBDLOA, listBLOA);
            dtgResultados.Rows.Add("BubbleSort - LO Ascendente", tiempoBLOA.ToString("F4"));
            DatosGlobales.TiempoBOrdLOA = tiempoBLOA;

            // 3. Levemente ordenados descendente
            var (listBLOD, tiempoBLOD) = MedirTiempoOrdenamiento(ordenarBubble, (int[])DatosGlobales.DatosLOD.Clone());
            DatosGlobales.DatosBLOD = listBLOD;
            LlenarCharter(chtBLOD, listBLOD);
            dtgResultados.Rows.Add("BubbleSort - LO Descendente", tiempoBLOD.ToString("F4"));
            DatosGlobales.TiempoBOrdLOD = tiempoBLOD;

            // 4. Ordenados ascendente
            var (listBOA, tiempoBOA) = MedirTiempoOrdenamiento(ordenarBubble, (int[])DatosGlobales.DatosOA.Clone());
            DatosGlobales.DatosBOA = listBOA;
            LlenarCharter(chtBO, listBOA);
            dtgResultados.Rows.Add("BubbleSort - Ordenados Asc.", tiempoBOA.ToString("F4"));
            DatosGlobales.TiempoBOrd2 = tiempoBOA;
        }

        private int[] ordenarBubble(int[] lista)
        {
            int n = lista.Length;
            bool intercambio;

            // Bucle para recorrer la lista
            for (int i = 0; i < n - 1; i++)
            {
                intercambio = false;

                // Bucle interno para comparar elementos consecutivos
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Si el elemento es mayor que el siguiente, los intercambiamos
                    if (lista[j] < lista[j + 1])
                    {
                        // Intercambiar los elementos
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;

                        intercambio = true;
                    }
                }

                // Si no hubo intercambio, la lista ya está ordenada
                if (!intercambio)
                    break;
            }

            return lista;
        }

        private (int[] resultado, long tiempoMs) MedirTiempoOrdenamiento(Func<int[], int[]> metodoOrdenamiento, int[] datos)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            int[] resultado = metodoOrdenamiento(datos);
            stopwatch.Stop();
            return (resultado, stopwatch.ElapsedMilliseconds);
        }

        private void dtgResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrdenamientoBubbleSort_Load(object sender, EventArgs e)
        {
            // Agrega columnas al DataGridView si aún no existen
            if (dtgResultados.Columns.Count == 0)
            {
                dtgResultados.Columns.Add("Metodo", "Método de Ordenamiento");
                dtgResultados.Columns.Add("Tiempo", "Tiempo (ms)");
            }

            MostrarDatosEnChart();
        }
    }
}
