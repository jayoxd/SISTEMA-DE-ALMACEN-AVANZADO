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
    public class N_Usuario
    {
        D_Usuario objDatos = new D_Usuario();
        E_Usuario entidades = new E_Usuario();

        public DataTable listandoEmpleados()
        {
            return objDatos.ListarEmpleados();
        }

        public DataTable buscandoEmpleado(string buscar)
        {
            entidades.Buscaremp = buscar;
            return objDatos.BuscarEmpleado(entidades);
        }

        public DataTable login(string Email,string Clave)
        {
            return objDatos.Login(Email,Clave);
        }



        public void insertandoEmpleado(E_Usuario usuario)
        {
            objDatos.insertarEmpleado(usuario);
        }

        public void editandoEmpleado(E_Usuario usuario)
        {
            objDatos.EditarEmpleado(usuario);
        }

        public void eliminandoEmpleado(int id)
        {
            objDatos.EliminarEmpleado(id);
        }
        public  string Activar(int Id)
        {
            return objDatos.Activar(Id);
        }

        public string Desactivar(int Id)
        {
            return objDatos.Desactivar(Id);
        }

    }
}
