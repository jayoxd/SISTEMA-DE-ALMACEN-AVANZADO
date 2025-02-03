using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Salida
    {
        // instancia de la capa de datos
        private readonly D_salida objDatos = new D_salida();

      

        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedio(bool esInterno)
        {
            return objDatos.ListaSalidamedio(esInterno);
        }
        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedioint()
        {
            return objDatos.ListaSalidamedioint();
        }

        // Método para listar salidas
        public DataTable ListarSalidas()
        {
            return objDatos.ListaSalida();
        }


        // Método para editar una salida
        public void EditarSalida(E_salida salida)
        {

            // Llamamos al método de la capa de datos para editar la salida
            objDatos.EditarSalida(salida);
        }

        // Método para insertar una nueva salida
        public void InsertarSalida(E_salida salida)
        {

            // Llamamos al método de la capa de datos para insertar la salida
            objDatos.InsertarSalida(salida);
        }

        // Método para obtener los detalles de una salida específica
        public DataSet ObtenerSalidaConDetalles(string nroDocumento)
        {
            return objDatos.ObtenerSalidaConDetalles(nroDocumento);
        }

        // Método para buscar salidas por número de documento o comprobante
        public DataTable BuscarPorNroDocOComprobante(string valor)
        {
            return objDatos.BuscarPorSalidaNroDoc(valor);
        }

        // Método para buscar salidas con filtros opcionales
        public DataTable BuscarSalidas(E_salida salida)
        {
            return objDatos.BuscarSalidas(salida);
        }

        public DataTable ObtenerSalidasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new D_salida().ObtenerSalidasPorFechas(valor, fechaInicio, fechaFin);
        }
       
        public DataSet ObtenerSalidaConDetallesCompleto(string nroDocumento)
        {
            D_salida datos = new D_salida();
            return datos.ConsultarSalidaConDetallesCompleto(nroDocumento);
        }

        // Método para obtener el conteo de salidas excluyendo ClienteID 6 y 7
        public int ObtenerTotalSalidasSinCliente67()
        {
            return (int)objDatos.EjecutarOpcionSalidas(1);
        }

        // Método para obtener el conteo de salidas con ClienteID 7
        public int ObtenerTotalSalidasCliente7()
        {
            return (int)objDatos.EjecutarOpcionSalidas(2);
        }

        // Método para obtener el conteo de salidas con ClienteID 6
        public int ObtenerTotalSalidasCliente6()
        {
            return (int)objDatos.EjecutarOpcionSalidas(3);
        }

        // Método para obtener el NroDocumento de la última salida registrada
        public DataTable ObtenerUltimaSalidaRegistrada()
        {
            return (DataTable)objDatos.EjecutarOpcionSalidas(4);
        }

        // Método para obtener el NroDocumento de la última salida actualizada
        public DataTable ObtenerUltimaSalidaActualizada()
        {
            return (DataTable)objDatos.EjecutarOpcionSalidas(5);
        }
    }

}
