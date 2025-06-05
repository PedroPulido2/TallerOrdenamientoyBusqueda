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
            dtgResultados.Columns.Add("Resultado", "Resultado");
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

                // Comparar el valor buscado con el valor en la posición medio
                if (lista[medio] == valorBuscado)
                {
                    return medio; // Devuelve el índice si lo encuentra
                }

                // Si el valor buscado es mayor, busca en la mitad derecha
                else if (lista[medio] < valorBuscado)
                {
                    izquierda = medio + 1;
                }
                // Si el valor buscado es menor, busca en la mitad izquierda
                else
                {
                    derecha = medio - 1;
                }
            }

            return -1; // Si no lo encuentra, devuelve -1
        }
        public int BusquedaJump(int[] lista, int valorBuscado)
        {
            int n = lista.Length;
            int salto = (int)Math.Floor(Math.Sqrt(n)); // Establecer el tamaño del salto
            int prev = 0;

            // Avanzar en los saltos
            while (lista[Math.Min(salto, n) - 1] < valorBuscado)
            {
                prev = salto;
                salto += (int)Math.Floor(Math.Sqrt(n));
                if (prev >= n) return -1; // Si se excede el límite, el valor no se encuentra
            }

            // Realizar búsqueda lineal en el bloque encontrado
            for (int i = prev; i < Math.Min(salto, n); i++)
            {
                if (lista[i] == valorBuscado)
                {
                    return i;
                }
            }

            return -1; // Si no lo encuentra
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar que el valor ingresado sea un número
            if (!int.TryParse(txtSearch.Text, out var valorBuscado))
            {
                MessageBox.Show("Por favor ingresa un número válido.");
                return;
            }

            // Verificar si el valor ingresado está en los datos
            if (!DatosGlobales.DatosBOrd.Contains(valorBuscado) &&
                !DatosGlobales.DatosQOrd.Contains(valorBuscado))
            {
                MessageBox.Show("El valor no se encuentra en los datos.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();

            // Limpiar el DataGridView antes de agregar nuevos resultados
            dtgResultados.Rows.Clear();
            // Procedemos con las búsquedas y mostramos los resultados de las búsquedas.

            // Buscar en los datos ordenados por BubbleSort (DatosBOrd)
            stopwatch.Start();
            int resultadoBinarioBOrd = busquedaBinaria(DatosGlobales.DatosBOrd, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioBOrd = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpBOrd = BusquedaJump(DatosGlobales.DatosBOrd, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpBOrd = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de BubbleSort en el DataGridView
            dtgResultados.Rows.Add("BubbleSort", "Binaria", resultadoBinarioBOrd == -1 ? "No encontrado" : resultadoBinarioBOrd.ToString(), tiempoBinarioBOrd);
            dtgResultados.Rows.Add("BubbleSort", "Jump", resultadoJumpBOrd == -1 ? "No encontrado" : resultadoJumpBOrd.ToString(), tiempoJumpBOrd);

            // Buscar en los datos levemente ordenados de forma ascendente (DatosBLOA)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioBLOA = busquedaBinaria(DatosGlobales.DatosBLOA, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioBLOA = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpBLOA = BusquedaJump(DatosGlobales.DatosBLOA, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpBLOA = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de BubbleSort en el DataGridView para BLOA
            dtgResultados.Rows.Add("BubbleSort", "Binaria (LOA)", resultadoBinarioBLOA == -1 ? "No encontrado" : resultadoBinarioBLOA.ToString(), tiempoBinarioBLOA);
            dtgResultados.Rows.Add("BubbleSort", "Jump (LOA)", resultadoJumpBLOA == -1 ? "No encontrado" : resultadoJumpBLOA.ToString(), tiempoJumpBLOA);

            // Buscar en los datos levemente ordenados de forma descendente (DatosBLOD)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioBLOD = busquedaBinaria(DatosGlobales.DatosBLOD, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioBLOD = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpBLOD = BusquedaJump(DatosGlobales.DatosBLOD, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpBLOD = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de BubbleSort en el DataGridView para BLOD
            dtgResultados.Rows.Add("BubbleSort", "Binaria (LOD)", resultadoBinarioBLOD == -1 ? "No encontrado" : resultadoBinarioBLOD.ToString(), tiempoBinarioBLOD);
            dtgResultados.Rows.Add("BubbleSort", "Jump (LOD)", resultadoJumpBLOD == -1 ? "No encontrado" : resultadoJumpBLOD.ToString(), tiempoJumpBLOD);

            // Buscar en los datos completamente ordenados (DatosBOA)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioBOA = busquedaBinaria(DatosGlobales.DatosBOA, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioBOA = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpBOA = BusquedaJump(DatosGlobales.DatosBOA, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpBOA = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de BubbleSort en el DataGridView para BOA
            dtgResultados.Rows.Add("BubbleSort", "Binaria (OA)", resultadoBinarioBOA == -1 ? "No encontrado" : resultadoBinarioBOA.ToString(), tiempoBinarioBOA);
            dtgResultados.Rows.Add("BubbleSort", "Jump (OA)", resultadoJumpBOA == -1 ? "No encontrado" : resultadoJumpBOA.ToString(), tiempoJumpBOA);

            // QuickSort
            // Buscar en los datos ordenados por QuickSort (DatosQOrd)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioQOrd = busquedaBinaria(DatosGlobales.DatosQOrd, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioQOrd = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpQOrd = BusquedaJump(DatosGlobales.DatosQOrd, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpQOrd = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de QuickSort en el DataGridView
            dtgResultados.Rows.Add("QuickSort", "Binaria", resultadoBinarioQOrd == -1 ? "No encontrado" : resultadoBinarioQOrd.ToString(), tiempoBinarioQOrd);
            dtgResultados.Rows.Add("QuickSort", "Jump", resultadoJumpQOrd == -1 ? "No encontrado" : resultadoJumpQOrd.ToString(), tiempoJumpQOrd);

            // Buscar en los datos levemente ordenados de forma ascendente (DatosQLOA)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioQLOA = busquedaBinaria(DatosGlobales.DatosQLOA, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioQLOA = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpQLOA = BusquedaJump(DatosGlobales.DatosQLOA, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpQLOA = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de QuickSort en el DataGridView para QLOA
            dtgResultados.Rows.Add("QuickSort", "Binaria (LOA)", resultadoBinarioQLOA == -1 ? "No encontrado" : resultadoBinarioQLOA.ToString(), tiempoBinarioQLOA);
            dtgResultados.Rows.Add("QuickSort", "Jump (LOA)", resultadoJumpQLOA == -1 ? "No encontrado" : resultadoJumpQLOA.ToString(), tiempoJumpQLOA);

            // Buscar en los datos levemente ordenados de forma descendente (DatosQLOD)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioQLOD = busquedaBinaria(DatosGlobales.DatosQLOD, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioQLOD = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpQLOD = BusquedaJump(DatosGlobales.DatosQLOD, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpQLOD = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de QuickSort en el DataGridView para QLOD
            dtgResultados.Rows.Add("QuickSort", "Binaria (LOD)", resultadoBinarioQLOD == -1 ? "No encontrado" : resultadoBinarioQLOD.ToString(), tiempoBinarioQLOD);
            dtgResultados.Rows.Add("QuickSort", "Jump (LOD)", resultadoJumpQLOD == -1 ? "No encontrado" : resultadoJumpQLOD.ToString(), tiempoJumpQLOD);

            // Buscar en los datos completamente ordenados (DatosQOA)
            stopwatch.Reset();
            stopwatch.Start();
            int resultadoBinarioQOA = busquedaBinaria(DatosGlobales.DatosQOA, valorBuscado);
            stopwatch.Stop();
            var tiempoBinarioQOA = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();
            stopwatch.Start();
            int resultadoJumpQOA = BusquedaJump(DatosGlobales.DatosQOA, valorBuscado);
            stopwatch.Stop();
            var tiempoJumpQOA = stopwatch.ElapsedMilliseconds;

            // Mostrar los resultados de QuickSort en el DataGridView para QOA
            dtgResultados.Rows.Add("QuickSort", "Binaria (OA)", resultadoBinarioQOA == -1 ? "No encontrado" : resultadoBinarioQOA.ToString(), tiempoBinarioQOA);
            dtgResultados.Rows.Add("QuickSort", "Jump (OA)", resultadoJumpQOA == -1 ? "No encontrado" : resultadoJumpQOA.ToString(), tiempoJumpQOA);

            // Graficar los tiempos de las búsquedas por tipo de datos y búsqueda
            chtResultados.Series[0].Points.Clear();
            chtResultados.Series[0].Points.AddXY("Binaria BubbleSort", tiempoBinarioBOrd);
            chtResultados.Series[0].Points.AddXY("Jump BubbleSort", tiempoJumpBOrd);
            chtResultados.Series[0].Points.AddXY("Binaria BubbleSort (LOA)", tiempoBinarioBLOA);
            chtResultados.Series[0].Points.AddXY("Jump BubbleSort (LOA)", tiempoJumpBLOA);
            chtResultados.Series[0].Points.AddXY("Binaria BubbleSort (LOD)", tiempoBinarioBLOD);
            chtResultados.Series[0].Points.AddXY("Jump BubbleSort (LOD)", tiempoJumpBLOD);
            chtResultados.Series[0].Points.AddXY("Binaria BubbleSort (OA)", tiempoBinarioBOA);
            chtResultados.Series[0].Points.AddXY("Jump BubbleSort (OA)", tiempoJumpBOA);

            chtResultados.Series[0].Points.AddXY("Binaria QuickSort", tiempoBinarioQOrd);
            chtResultados.Series[0].Points.AddXY("Jump QuickSort", tiempoJumpQOrd);
            chtResultados.Series[0].Points.AddXY("Binaria QuickSort (LOA)", tiempoBinarioQLOA);
            chtResultados.Series[0].Points.AddXY("Jump QuickSort (LOA)", tiempoJumpQLOA);
            chtResultados.Series[0].Points.AddXY("Binaria QuickSort (LOD)", tiempoBinarioQLOD);
            chtResultados.Series[0].Points.AddXY("Jump QuickSort (LOD)", tiempoJumpQLOD);
            chtResultados.Series[0].Points.AddXY("Binaria QuickSort (OA)", tiempoBinarioQOA);
            chtResultados.Series[0].Points.AddXY("Jump QuickSort (OA)", tiempoJumpQOA);
        }


    }
}
