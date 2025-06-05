using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerOrdenamientoyBusqueda
{
    public static class DatosGlobales
    {
        public static int[] DatosGenerados { get; set; }
        public static int[] DatosLOA { get; set; }
        public static int[] DatosLOD { get; set; }
        public static int[] DatosOA { get; set; }

        //Propiedades para almacenar los datos ordenados por QuickSort
        public static int[] DatosQOrd { get; set; }
        public static int[] DatosQLOA { get; set; }
        public static int[] DatosQLOD { get; set; }
        public static int[] DatosQOA { get; set; }

        //Propiedades para almacenar los datos ordenados por QuickSort
        public static int[] DatosBOrd { get; set; }
        public static int[] DatosBLOA { get; set; }
        public static int[] DatosBLOD { get; set; }
        public static int[] DatosBOA { get; set; }
    }
}
