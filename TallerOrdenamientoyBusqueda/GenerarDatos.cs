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
        int[] listRamdom;
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

            //1. Datos aleatorios:
            listRamdom = GenerarDatosAleatorios(size, minValue, maxValue);
            LlenarCharter(chtData, listRamdom);

            //2. Datos levemente ordenados de forma ascendente en 5 grupos.
            var grupoAsc = GenerarDatosLevementeOrdenadosAsc(listRamdom, 5);
            int[] datosLOA = grupoAsc.SelectMany(x => x).ToArray();
            LlenarCharter(chtLOA, datosLOA);

            //3. Datos levemente ordenados de forma descendente
            var gruposDesc = GenerarDatosLevementeOrdenadosDesc(listRamdom, 5);
            int[] datosLOD = gruposDesc.SelectMany(x => x).ToArray();

            Array.Sort(datosLOD);
            Array.Reverse(datosLOD);
            LlenarCharter(chtLOD, datosLOD);

            // 4. Datos completamente ordenados ascendente a partir de listRamdom
            int[] datosOA = GenerarDatosOrdenadosAsc(listRamdom);
            LlenarCharter(chtOA, datosOA);
        }
        private void LlenarCharter(Chart chart, int[] datos)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < datos.Length; i++)
            {
                chart.Series[0].Points.AddXY(i, datos[i]);
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

        private List<int[]> GenerarDatosLevementeOrdenadosAsc(int[] baseDatos, int grupos)
        {
            List<int[]> resultado = new List<int[]>();
            int size = baseDatos.Length;
            int tamañoxGrupo = size / grupos;

            //Ordenar baseDatos para facilitar la division en rangos
            int[] baseOrdenada = (int[])baseDatos.Clone();
            Array.Sort(baseOrdenada);

            for (int i = 0; i < grupos; i++)
            {
                //rango del grupo g
                int inicio = i * tamañoxGrupo;
                int fin = (i == grupos - 1) ? size : inicio + tamañoxGrupo;

                int[] grupoDatos = new int[fin - inicio];
                Array.Copy(baseOrdenada, inicio, grupoDatos, 0, fin - inicio);

                //perturbar ligeramente para que sea levemente ordenado ascendentemente
                grupoDatos = PerturbarDatos(grupoDatos, leve: true);

                //Asegura orden ascendente (con perturbacion)
                Array.Sort(grupoDatos);

                resultado.Add(grupoDatos);
            }
            return resultado;
        }
        private int[] PerturbarDatos(int[] datos, bool leve)
        {
            // Perturba un poco los datos para que no estén completamente ordenados
            Random rnd = new Random();
            int n = datos.Length;

            // Número de swaps dependiendo si es leve o no
            int numSwaps = leve ? n / 10 : n / 3;

            for (int i = 0; i < numSwaps; i++)
            {
                int idx1 = rnd.Next(n);
                int idx2 = rnd.Next(n);
                // Intercambia dos valores para perturbar el orden
                int temp = datos[idx1];
                datos[idx1] = datos[idx2];
                datos[idx2] = temp;
            }
            return datos;
        }

        private List<int[]> GenerarDatosLevementeOrdenadosDesc(int[] baseDatos, int grupos)
        {
            List<int[]> resultado = new List<int[]>();
            int size = baseDatos.Length;
            int tamañoPorGrupo = size / grupos;

            int[] baseOrdenada = (int[])baseDatos.Clone();
            Array.Sort(baseOrdenada);

            for (int g = 0; g < grupos; g++)
            {
                int inicio = g * tamañoPorGrupo;
                int fin = (g == grupos - 1) ? size : inicio + tamañoPorGrupo;

                int[] grupoDatos = new int[fin - inicio];
                Array.Copy(baseOrdenada, inicio, grupoDatos, 0, fin - inicio);

                // Perturbar ligeramente
                grupoDatos = PerturbarDatos(grupoDatos, leve: true);

                // Orden descendente
                Array.Sort(grupoDatos);
                Array.Reverse(grupoDatos);

                resultado.Add(grupoDatos);
            }

            return resultado;
        }

        private int[] GenerarDatosOrdenadosAsc(int[] baseDatos)
        {
            int[] resultado = (int[])baseDatos.Clone();
            Array.Sort(resultado);
            return resultado;
        }
    }
}
