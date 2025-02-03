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

        // Método para listar empleados activos o inactivos
        public DataTable ListarEmpleados(bool activo)
        {
            return objDatos.ListarEmpleados(activo);
        }

        // Método para buscar empleados activos o inactivos
        public DataTable BuscarEmpleado(string valor, bool activo)
        {
            return objDatos.BuscarEmpleado(valor, activo);
        }

        // Método para cambiar estado (activar/desactivar) de un empleado
        public void CambiarEstadoEmpleado(int id, bool activo)
        {
            objDatos.CambiarEstadoEmpleado(id, activo);
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

        public string obtenerClaveEmpleado(int idEmpleado)
        {
            return objDatos.ObtenerClaveEmpleado(idEmpleado);
        }

        public bool VerificarEmailExistente(string email, int? idEmpleado = null)
        {
            return objDatos.VerificarEmailExistente(email, idEmpleado);
        }
    }
}
