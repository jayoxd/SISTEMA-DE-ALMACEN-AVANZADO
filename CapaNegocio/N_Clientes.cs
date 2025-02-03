using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_Clientes
    {

        D_Clientes objDatos = new D_Clientes();

        public DataTable listandoClientes()
        {
            return objDatos.ListarClientes();
        }

        public DataTable ConsultarClientes(string filtro = null, bool? estado = null)
        {
            return objDatos.ConsultarClientes(filtro, estado);
        }


        public void insertandoCliente(E_Clientes Clientez)
        {
            objDatos.InsertarCliente(Clientez);
        }

        public void editandoCliente(E_Clientes Clientez)
        {
            objDatos.ActualizarCliente(Clientez);
        }




        public int ObtenerClientesActivos()
        {
            return objDatos.ObtenerClientesActivos();
        }

        public int ObtenerProveedoresActivos()
        {
            return objDatos.ObtenerProveedoresActivos();
        }
        public int ObtenerProductosBajoStock(int stockMinimo)
        {
            return objDatos.ObtenerProductosBajoStock(stockMinimo);
        }
        public int ObtenerProductosActivos()
        {
            return objDatos.ObtenerProductosActivos();
        }


        public decimal ObtenerIngresosDiarios(DateTime fecha)
        {
            return objDatos.ObtenerIngresosDiarios(fecha);
        }
        public int ObtenerEntradasRecientes()
        {
            return objDatos.ObtenerEntradasRecientes();
        }
        public int ObtenerSalidaRecientes()
        {
            return objDatos.ObtenerSalidasRecientes();
        }


        public void CambiarEstadoCliente(int clienteID, bool estado)
        {
            try
            {
                objDatos.CambiarEstadoCliente(clienteID, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente: " + ex.Message);
            }
        }

        public bool ExisteClienteRUC(string RUC)
        {
            return objDatos.ExisteCliente(RUC);
        }

        public DataTable ObtenerUltimoClienteRegistrado()
        {
            return (DataTable)objDatos.EjecutarOpcionClientes(2);
        }

        public int ContarClientesActivos()
        {
            return (int)objDatos.EjecutarOpcionClientes(1);
        }

        public int ContarClientesInactivos()
        {
            return (int)objDatos.EjecutarOpcionClientes(3);
        }

        public DataTable ObtenerClienteConMasSalidas()
        {
            return (DataTable)objDatos.EjecutarOpcionClientes(4);
        }

    }
}
//LLAMAMOS A LA CAPA DE DATOS 
//insertamos los procedimientos almacenados que se volvieron metodos
