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

        private readonly SqlConnection conexion = new SqlConnection(ConexionManager.ConnectionString);

        //metodo encargado de buscar y listar los  objetos como los atributos en la entidad cliente


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


        // Método para listar empleados activos o inactivos
        public DataTable ListarEmpleados(bool activo)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("empleado_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@activo", activo); // Pasa el estado como parámetro

            conexion.Open();
            SqlDataReader leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;
        }

        // Método para buscar empleados activos o inactivos según valor de búsqueda
        public DataTable BuscarEmpleado(string valor, bool activo)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("empleado_buscar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@activo", activo); // Pasa el estado como parámetro

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            return table;
        }

        // Método para activar/desactivar un empleado
        public void CambiarEstadoEmpleado(int id, bool activo)
        {
            SqlCommand cmd = new SqlCommand("empleado_ocultarydescoultar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idusuario", id);
            cmd.Parameters.AddWithValue("@activo", activo); // Define si es activar o desactivar

            conexion.Open();
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

        public string ObtenerClaveEmpleado(int idEmpleado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("obtener_clave_empleado", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetro
                    cmd.Parameters.AddWithValue("@idusuario", idEmpleado);

                    // Abrir conexión
                    if (conexion.State != ConnectionState.Open)
                        conexion.Open();

                    // Ejecutar el comando y leer la respuesta
                    var resultado = cmd.ExecuteScalar();

                    // Retornar la contraseña si se encuentra
                    return resultado != null ? resultado.ToString() : null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la clave del empleado: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        public bool VerificarEmailExistente(string email, int? idEmpleado = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("VerificarEmailExistente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del SP
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado.HasValue ? (object)idEmpleado.Value : DBNull.Value);

                // Abrir conexión
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                // Ejecutar el SP y obtener el resultado
                int existe = Convert.ToInt32(cmd.ExecuteScalar());

                // Retornar true si el correo ya existe
                return existe > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el email existente: " + ex.Message);
            }
            finally
            {
                // Cerrar conexión si está abierta
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }


    }
}
