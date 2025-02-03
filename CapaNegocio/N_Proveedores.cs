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
   public class N_Proveedores
    {

        D_proveedores objDatos = new D_proveedores();
        E_proveedores entidades = new E_proveedores();

        public DataTable listarproveedor()
        {
            return objDatos.ListarProveedores();
        }

        public DataTable ConsultarProveedores(string filtroGeneral = null, bool? estado = null)
        {
            return objDatos.ConsultarProveedores(filtroGeneral, estado);
        }

        public void insertandoProveedor(E_proveedores Proveedor)
        {
            objDatos.InsertarProveedor(Proveedor);
        }

        public void actualizarproveedor(E_proveedores Proveedor)
        {
            objDatos.ActualizarProveedor(Proveedor);
        }

        public void ocultarProveedor(int id)
        {
            objDatos.OcultarProveedor(id);
        }
        public void CambiarEstadoProveedor(int clienteID, bool estado)
        {
            try
            {
                objDatos.CambiarEstadoProve(clienteID, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente: " + ex.Message);
            }
        }
        public bool ExisteProveedorRUC(string RUC)
        {
            return objDatos.ExisteProveedor(RUC);
        }

        public int ContarProveedoresActivos()
        {
            return (int)objDatos.EjecutarOpcionProveedores(1);
        }

        public DataTable ObtenerUltimoProveedorRegistrado()
        {
            return (DataTable)objDatos.EjecutarOpcionProveedores(2);
        }

        public int ContarProveedoresInactivos()
        {
            return (int)objDatos.EjecutarOpcionProveedores(3);
        }

        public DataTable ObtenerProveedorConMasEntradas()
        {
            return (DataTable)objDatos.EjecutarOpcionProveedores(4);
        }
    }
}
//LLAMAMOS A LA CAPA DE DATOS 
//insertamos los procedimientos almacenados que se volvieron metodos
