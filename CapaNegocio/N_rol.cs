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
    public class N_rol
    {
        D_rol objDatos = new D_rol();
        E_Rol entidades = new E_Rol();
        public  DataTable listarrol()
        {
            return objDatos.ListarRoles();
        }
        public DataTable buscandoroles(string buscar)
        {
            entidades.Buscar_rol= buscar;
            return objDatos.BuscarRol(entidades);
        }
    }   
}
