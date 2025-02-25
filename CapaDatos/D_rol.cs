using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
     public class D_rol
    {
        private readonly SqlConnection conexion = new SqlConnection(ConexionManager.ConnectionString);


        public DataTable ListarRoles()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_listar_roles", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }


        public DataTable BuscarRol(E_Rol rol)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_buscar_Rol", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarrol", rol.Buscar_rol);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

    }
}
