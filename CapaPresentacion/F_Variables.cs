using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
     public class F_Variables
    {

        public static int idEmpleado;
        public static int idClienterepor;
        public static string nombre_clientereport;
        public static string nombre_empleado;
        public static string sumaremple;
        public static string carro;
        public static string reporte;
        public static string iddiagnostico;

        public static string pruebatodo;

        public static string RUC;

        public static string empresa;

        public static string direccionEmp;

        public static string pruebatodox;

        public static int ClienteID { get; set; } // ID del cliente
        public static string DNI { get; set; } // DNI del cliente
        public static string Nombre { get; set; } // Nombre del cliente
        public static string Ubigeo { get; set; } // Departamento/Provincia/Distrito
        public static string OrigenCliente { get; set; } // Dirección o origen del cliente

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int StockActual { get; set; }


        // Propiedades de búsqueda (si son necesarias como estáticas)
        public static string NroDocumentoBusqueda { get; set; }
        public static int? ProveedorIDBusqueda { get; set; }
        public static DateTime? FechaInicioBusqueda { get; set; }
        public static DateTime? FechaFinBusqueda { get; set; }

        // Propiedades de entrada seleccionada (como instancia)
        public static string NroDocumento { get; set; }
        public static int ProveedorID { get; set; }
        public string TipoComprobante { get; set; }
        public string NroComprobante { get; set; }
        public decimal TipoCambio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
