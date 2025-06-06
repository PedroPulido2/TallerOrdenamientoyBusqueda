using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TallerOrdenamientoyBusqueda
{
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            GraficoComparacionOrdenamiento();
            GraficoComparacionBusqueda();
        }

        private void GraficoComparacionBusqueda()
        {
            // Configura el gráfico
            chtBusqueda.Series.Clear(); // Limpiar las series anteriores

            // Crea una serie para los tiempos de búsqueda
            Series serie = new Series("Tiempos de Búsqueda")
            {
                ChartType = SeriesChartType.Bar, // Tipo de gráfico de barras
                BorderWidth = 2, // Ancho del borde de las barras
                IsValueShownAsLabel = true // Mostrar los valores en las barras
            };

            // Agrega los puntos de datos a la serie
            serie.Points.AddXY("Binaria1", DatosGlobales.TiempoBBusq1);
            serie.Points.AddXY("Jump1", DatosGlobales.TiempoJBusq1);
            serie.Points.AddXY("BinariaLOA", DatosGlobales.TiempoBBusqLOA);
            serie.Points.AddXY("JumpLOA", DatosGlobales.TiempoJBusqLOA);
            serie.Points.AddXY("BinariaLOD", DatosGlobales.TiempoBBusqLOD);
            serie.Points.AddXY("JumpLOD", DatosGlobales.TiempoJBusqLOD);
            serie.Points.AddXY("Binaria2", DatosGlobales.TiempoBBusq2);
            serie.Points.AddXY("Jump2", DatosGlobales.TiempoJBusq2);

            // Agrega la serie al gráfico
            chtBusqueda.Series.Add(serie);

            // Configura el eje X (métodos de búsqueda)
            chtBusqueda.ChartAreas[0].AxisX.Title = "Métodos de Búsqueda";

            // Configura el eje Y (tiempo en milisegundos)
            chtBusqueda.ChartAreas[0].AxisY.Title = "Tiempo (ms)";

            // Establecer el tamaño fijo del gráfico
            chtBusqueda.Width = 600;  // Establecer un ancho fijo
            chtBusqueda.Height = 350; // Establecer una altura fija

            // Configurar la escala para que todo se vea bien
            chtBusqueda.ChartAreas[0].AxisX.Minimum = 0; // Asegura que el eje X empiece desde 0
            chtBusqueda.ChartAreas[0].AxisY.Minimum = 0; // Asegura que el eje Y empiece desde 0

            // Configurar el espacio entre las barras (si las barras se superponen)
            chtBusqueda.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90); // Asegura un margen dentro del gráfico
        }


        private void GraficoComparacionOrdenamiento()
        {
            // Configura el gráfico
            chtOrdenamiento.Series.Clear(); // Limpiar las series anteriores

            // Crea una serie para los tiempos de ordenamiento
            Series serie = new Series("Tiempos de Ordenamiento")
            {
                ChartType = SeriesChartType.Bar, // Tipo de gráfico de barras
                BorderWidth = 2, // Ancho del borde de las barras
                IsValueShownAsLabel = true // Mostrar los valores en las barras
            };

            // Agrega los puntos de datos a la serie
            serie.Points.AddXY("Bubble1", DatosGlobales.TiempoBOrd1);
            serie.Points.AddXY("Quick1", DatosGlobales.TiempoQOrd1);
            serie.Points.AddXY("BubbleLOA", DatosGlobales.TiempoBOrdLOA);
            serie.Points.AddXY("QuickLOA", DatosGlobales.TiempoQOrdLOA);
            serie.Points.AddXY("BubbleLOD", DatosGlobales.TiempoBOrdLOD);
            serie.Points.AddXY("QuickLOD", DatosGlobales.TiempoQOrdLOD);
            serie.Points.AddXY("Bubble2", DatosGlobales.TiempoBOrd2);
            serie.Points.AddXY("Quick2", DatosGlobales.TiempoQOrd2);

            // Agrega la serie al gráfico
            chtOrdenamiento.Series.Add(serie);

            // Configura el eje X (métodos de ordenamiento)
            chtOrdenamiento.ChartAreas[0].AxisX.Title = "Métodos de Ordenamiento";

            // Configura el eje Y (tiempo en milisegundos)
            chtOrdenamiento.ChartAreas[0].AxisY.Title = "Tiempo (ms)";

            // Establecer el tamaño fijo del gráfico
            chtOrdenamiento.Width = 600;  // Establecer un ancho fijo
            chtOrdenamiento.Height = 350;

            // Configurar la escala para que todo se vea bien
            chtOrdenamiento.ChartAreas[0].AxisX.Minimum = 0; // Asegura que el eje X empiece desde 0
            chtOrdenamiento.ChartAreas[0].AxisY.Minimum = 0; // Asegura que el eje Y empiece desde 0

            // Configurar el espacio entre las barras (si las barras se superponen)
            chtOrdenamiento.ChartAreas[0].InnerPlotPosition = new ElementPosition(5, 5, 90, 90); // Asegura un margen dentro del gráfico
        }
    }
}
