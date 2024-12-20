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
   public class N_Cliente
    {

        D_Cliente objDatos = new D_Cliente();
        E_Cliente entidades = new E_Cliente();

        public DataTable listandoClientes()
        {
            return objDatos.ListarClientes();
        }

        public DataTable buscandoclientes(string buscar)
        {
            entidades.Buscarcli = buscar;
            return objDatos.BuscarCliente(entidades);
        }


        public void insertandoCliente(E_Cliente Clientez)
        {
            objDatos.insertarCliente(Clientez);
        }

        public void editandoCliente(E_Cliente Clientez)
        {
            objDatos.EditarCliente(Clientez);
        }

        public void eliminandoCliente(int id)
        {
            objDatos.EliminarCliente(id);
        }
        public void sumarClientestodo(E_Cliente cliente)
        {
            objDatos.totalclientes(cliente);
        }


    }
}
//LLAMAMOS A LA CAPA DE DATOS 
//insertamos los procedimientos almacenados que se volvieron metodos
