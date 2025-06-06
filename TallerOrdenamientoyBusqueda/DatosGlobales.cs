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

        //Propiedades para almacenar los datos ordenados por BubbleSort
        public static int[] DatosBOrd { get; set; }
        public static int[] DatosBLOA { get; set; }
        public static int[] DatosBLOD { get; set; }
        public static int[] DatosBOA { get; set; }


        //Propiedades para almacenar tiempos de ordenamiento del BubbleSort

        public static double TiempoBOrd1 { get; set; }
        public static double TiempoBOrdLOA { get; set; }
        public static double TiempoBOrdLOD { get; set; }
        public static double TiempoBOrd2 { get; set; }

        //Propiedades para almacenar tiempos de ordenamiento del QuickSort

        public static double TiempoQOrd1 { get; set; }
        public static double TiempoQOrdLOA { get; set; }
        public static double TiempoQOrdLOD { get; set; }
        public static double TiempoQOrd2 { get; set; }

        //Propiedades para almacenar tiempos de busqueda Binaria
        public static double TiempoBBusq1 { get; set; }
        public static double TiempoBBusqLOA { get; set; }
        public static double TiempoBBusqLOD { get; set; }
        public static double TiempoBBusq2 { get; set; }
        //Propiedades para almacenar tiempos de busqueda Jump
        public static double TiempoJBusq1 { get; set; }
        public static double TiempoJBusqLOA { get; set; }
        public static double TiempoJBusqLOD { get; set; }
        public static double TiempoJBusq2 { get; set; }

    }
}
