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
    public partial class GenerarDatos : Form
    {
        int[] listRamdom, listDataLOrdAsc, listDataLOrdDsc, listOrd;
        int size;
        int minValue, maxValue;

        public GenerarDatos()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            minValue = Convert.ToInt32(txtMinValue.Text);
            maxValue = Convert.ToInt32(txtMaxValue.Text);
            size = Convert.ToInt32(txtSize.Text);

            // 1. Datos aleatorios:
            listRamdom = GenerarDatosAleatorios(size, minValue, maxValue);
            DatosGlobales.DatosGenerados = listRamdom; // Copiar datos generados
            LlenarCharter(chtData, listRamdom);

            // 2. Datos levemente ordenados de forma ascendente en 5 grupos.
            listDataLOrdAsc = GenerarDatosLOrdAsc(size, minValue, maxValue, listRamdom);
            DatosGlobales.DatosLOA = listDataLOrdAsc; // Copiar datos levemente ordenados
            LlenarCharter(chtLOA, listDataLOrdAsc);

            // 3. Datos levemente ordenados de forma descendente
            listDataLOrdDsc = GenerarDatosLOrdDsc(size, minValue, maxValue, listRamdom);
            DatosGlobales.DatosLOD = listDataLOrdDsc; // Copiar datos levemente ordenados descendente
            LlenarCharter(chtLOD, listDataLOrdDsc);

            // 4. Datos completamente ordenados ascendente a partir de listRamdom
            listOrd = GenerarDatosOrdenadosAsc(listRamdom);
            DatosGlobales.DatosOA = listOrd; // Copiar datos ordenados ascendentemente
            LlenarCharter(chtOA, listOrd);

            // Mostrar estadísticas en el DataGridView
            MostrarEstadisticas(listRamdom);
        }

        private int[] GenerarDatosLOrdAsc(int size, int minValue, int maxValue, int[] lisRamdom)
        {
            int[] datos = new int[size];

            int grupoSize = size / 5; // Dividir en 5 grupos

            listRamdom.CopyTo(datos, 0);

            for (int i = 0; i < 5; i++)
            {
                int startIndex = i * grupoSize;
                int endIndex = (i + 1) * grupoSize;

                if (i == 4) // Asegurar que el último grupo incluya todos los elementos restantes
                {
                    endIndex = size;
                }

                Array.Sort(datos, startIndex, endIndex - startIndex);
            }

            return datos;
        }

        private int[] GenerarDatosLOrdDsc(int size, int minValue, int maxValue, int[] listRamdom)
        {
            int[] datos = new int[size];

            int groupSize = size / 5;

            listRamdom.CopyTo(datos, 0);

            for (int i = 0; i < 5; i++)
            {
                int startIndex = i * groupSize;
                int endIndex = (i + 1) * groupSize;

                if (i == 4)
                {
                    endIndex = size;
                }

                // Ordena cada grupo de manera ascendente
                Array.Sort(datos, startIndex, endIndex - startIndex);

                // Luego, invierte cada grupo para que quede en orden descendente
                Array.Reverse(datos, startIndex, endIndex - startIndex);
            }

            return datos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        }

        private int[] GenerarDatosAleatorios(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] datos = new int[size];
            for (int i = 0; i < size; i++)
            {
                datos[i] = random.Next(minValue, maxValue);
            }
            return datos;
        }

        private int[] GenerarDatosOrdenadosAsc(int[] baseDatos)
        {
            int[] resultado = (int[])baseDatos.Clone();
            Array.Sort(resultado);
            return resultado;
        }

        private void MostrarEstadisticas(int[] datos)
        {
            int min = datos.Min();
            int max = datos.Max();
            int freqMin = datos.Count(x => x == min);
            int freqMax = datos.Count(x => x == max);
            double promedio = datos.Average();
            int suma = datos.Sum();

            double mediana;
            int[] ordenados = (int[])datos.Clone();
            Array.Sort(ordenados);
            int medio = ordenados.Length / 2;
            if (ordenados.Length % 2 == 0)
                mediana = (ordenados[medio - 1] + ordenados[medio]) / 2.0;
            else
                mediana = ordenados[medio];

            // Calcular moda
            var grupos = datos.GroupBy(x => x)
                              .Select(g => new { Valor = g.Key, Frecuencia = g.Count() });
            int maxFrecuencia = grupos.Max(g => g.Frecuencia);
            var modas = grupos.Where(g => g.Frecuencia == maxFrecuencia)
                              .Select(g => g.Valor)
                              .ToList();
            string modaStr = string.Join(", ", modas);

            // Limpiar y agregar filas al DataGridView
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Concepto", "Concepto");
            dataGridView1.Columns.Add("Valor", "Valor");

            dataGridView1.Rows.Add("Valor mínimo", min);
            dataGridView1.Rows.Add("Valor máximo", max);
            dataGridView1.Rows.Add("Frecuencia mínimo", freqMin);
            dataGridView1.Rows.Add("Frecuencia máximo", freqMax);
            dataGridView1.Rows.Add("Promedio", promedio.ToString("F2"));
            dataGridView1.Rows.Add("Mediana", mediana.ToString("F2"));
            dataGridView1.Rows.Add("Suma total", suma);
            dataGridView1.Rows.Add("Moda", modaStr);
        }

    }
}
