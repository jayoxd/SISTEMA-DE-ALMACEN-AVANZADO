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
    public class N_Productos
    {
        D_Productos objDatos = new D_Productos();
        E_Productos entidades = new E_Productos();

        public DataTable listandoproductos()
        {
            return objDatos.listaProductos();
        }

        public DataTable buscandoproductos(string buscar)
        {
            entidades.Buscar_prod = buscar;
            return objDatos.buscarProductos(entidades);
        }

        public void insertandoproductos(E_Productos productos)
        {
            objDatos.insertarProducto(productos);
        }

        public void editandoProducto(E_Productos productos)
        {
            objDatos.EditarProductos(productos);
        }

        public void eliminandoProductos(int id)
        {
            objDatos.EliminarProductos(id);
        }

        public void sumarTotal(E_Productos productos)
        {
            objDatos.totalproducos(productos);
        }


        public DataTable buscandoProductosventa(string buscar)
        {
            entidades.Buscar_prod = buscar;
            return objDatos.buscarProductosventa(entidades);
        }
    }
}
