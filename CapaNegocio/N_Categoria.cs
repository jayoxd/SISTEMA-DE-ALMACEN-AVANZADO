using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
      public class N_Categoria
    {
        D_Categoria objDatos = new D_Categoria();

        public List<E_Categoria> ListandoCategoria(string buscarc)
        { 
            return objDatos.ListarCategoria(buscarc);
        }


        public void insertandoCategoria(E_Categoria Categoria)
        {
            objDatos.insertarCategoria(Categoria);
        }

        public void editandoCategoria(E_Categoria categoria)
        {
            objDatos.EditarCategoria(categoria);
        }

        public void eliminandoCategoria(E_Categoria categoria)
        {
            objDatos.EliminarCategoria(categoria);
        }


    }
}
