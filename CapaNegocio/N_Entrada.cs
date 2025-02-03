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
    public class N_Entrada
    {
        // instancia de la capa de datos
        private readonly D_EntradaProductos objDatos = new D_EntradaProductos();

        // método para listar entradas
        public DataTable ListarEntradas()
        {
            return objDatos.ListarEntradas();
        }

    


        public void EditarEntrada(E_Entrada entrada)
        {
            D_EntradaProductos servicio = new D_EntradaProductos();

            // Llamamos al método de la capa de datos para editar la entrada
            servicio.EditarEntrada(entrada);
        }

        public void InsertarEntrada(E_Entrada entrada)
        {
            D_EntradaProductos servicio = new D_EntradaProductos();

            // Llamamos al método de la capa de datos para editar la entrada
            servicio.InsertarEntrada(entrada);
        }



        public DataSet ObtenerEntradaConDetalles(string nroDocumento)
        {
            return objDatos.ObtenerEntradaConDetalles(nroDocumento);
        }
        public DataTable buscarporNrodoandnrocompro(string valor)
        {
            return objDatos.BuscarPoEntradanrodoc(valor);
        }

        public DataTable ObtenerEntradasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new D_EntradaProductos().ObtenerEntradasPorFechas(valor, fechaInicio, fechaFin);
        }
        public DataSet ObtenerEntradaConDetallesCompleto(string nroDocumento)
        {
            D_EntradaProductos datos = new D_EntradaProductos();
            return datos.ConsultarEntradaConDetallesCompleto(nroDocumento);
        }


        public string ObtenerUltimaEntradaRegistrada()
        {
            var resultado = objDatos.EjecutarSpListarEntradas(5);
            return resultado != null ? resultado.ToString() : "No se encontró ninguna entrada registrada.";
        }

        public string ObtenerUltimaEntradaModificada()
        {
            var resultado = objDatos.EjecutarSpListarEntradas(6);
            return resultado != null ? resultado.ToString() : "No se encontró ninguna entrada modificada.";
        }

        public int ContarEntradasSinProveedor3y7()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(1));
        }

        public int ContarEntradasConProveedor3()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(2));
        }

        public int ContarEntradasConProveedor7()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(3));
        }

    }

}
