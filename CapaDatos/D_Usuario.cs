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
     public class D_Usuario
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de buscar y listar los  objetos como los atributos en la entidad cliente
        public DataTable ListarEmpleados()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("empleado_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }

        public DataTable BuscarEmpleado(E_Usuario usuario)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("empleado_buscar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@valor", usuario.Buscaremp);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public DataTable Login(string email, string clave)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("usuario_login", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@clave", clave);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }















        public void insertarEmpleado(E_Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand("usuario_insertar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idrol", usuario.Id_rol);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre_emp);
            cmd.Parameters.AddWithValue("@tipo_documento", usuario.Tipo_documento_emp);
            cmd.Parameters.AddWithValue("@num_documento", usuario.Num_documento_emp);
            cmd.Parameters.AddWithValue("@direccion", usuario.Direccion_emp);
            cmd.Parameters.AddWithValue("@telefono", usuario.Telefono_emp);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@clave", usuario.Clave);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarEmpleado(E_Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand("empleado_actualizar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idusuario", usuario.Id_empleado);
            cmd.Parameters.AddWithValue("@idrol", usuario.Id_rol);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre_emp);
            cmd.Parameters.AddWithValue("@tipo_documento", usuario.Tipo_documento_emp);
            cmd.Parameters.AddWithValue("@num_documento", usuario.Num_documento_emp);
            cmd.Parameters.AddWithValue("@direccion", usuario.Direccion_emp);
            cmd.Parameters.AddWithValue("@telefono", usuario.Telefono_emp);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@clave", usuario.Clave);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarEmpleado(int id)
        {
            SqlCommand cmd = new SqlCommand("empleado_eliminar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idusuario", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        
        public string Activar(int Id)
        {
            string Rpta = "";
           
            try
            {
               
                SqlCommand Comando = new SqlCommand("usuario_activar",conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                conexion.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); ;
            }
            return Rpta;
        }

        public string Desactivar(int Id)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                
                SqlCommand Comando = new SqlCommand("usuario_desactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
                conexion.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close(); 
            }
            return Rpta;
        }



    }
}
