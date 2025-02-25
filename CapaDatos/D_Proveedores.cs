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
    public class D_proveedores
    {

        private readonly SqlConnection conexion = new SqlConnection(ConexionManager.ConnectionString);

        // Método para listar proveedores
        public DataTable ListarProveedores()
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("ConsultarProveedores", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            SqlDataReader leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);

            leerFilas.Close();
            conexion.Close();

            return tabla;
        }

        public DataTable ConsultarProveedores(string filtroGeneral = null, bool? estado = null)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarProveedores", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FiltroGeneral", (object)filtroGeneral ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar proveedores: " + ex.Message);
            }
            return tabla;
        }


        // Método para insertar un proveedor
        public void InsertarProveedor(E_proveedores proveedor)
        {
            SqlCommand cmd = new SqlCommand("InsertarProveedor", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            cmd.Parameters.AddWithValue("@RUC", proveedor.Ruc);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
            cmd.Parameters.AddWithValue("@Email", proveedor.Email);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // Método para actualizar un proveedor
        public void ActualizarProveedor(E_proveedores proveedor)
        {
            SqlCommand cmd = new SqlCommand("ActualizarProveedor", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            cmd.Parameters.AddWithValue("@ProveedorID", proveedor.idProveedor);
            cmd.Parameters.AddWithValue("@RUC", proveedor.Ruc);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
            cmd.Parameters.AddWithValue("@Email", proveedor.Email);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // Método para ocultar un proveedor
        public void OcultarProveedor(int proveedorID)
        {
            SqlCommand cmd = new SqlCommand("OcultarProveedor", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void CambiarEstadoProve(int clienteID, bool estado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_OcultarProveedor", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Pasar parámetros al procedimiento almacenado
                cmd.Parameters.AddWithValue("@ProveedorID", clienteID);
                cmd.Parameters.AddWithValue("@Estado", estado);

                // Abrir conexión
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                throw new Exception("Error al cambiar el estado del proveedor: " + ex.Message);
            }
        }
        public bool ExisteProveedor(string RUC)
        {


            SqlCommand cmd = new SqlCommand("sp_ExisteProveedorRUC", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Pasar parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@RUC", RUC);


            // Abrir conexión
            conexion.Open();
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
            conexion.Close();
            return resultado > 0;

        }
        public object EjecutarOpcionProveedores(int opcion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_IndicadoresProveedores", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Opcion", opcion);

                conexion.Open();

                if (opcion == 2 || opcion == 4) // Opciones que devuelven datos (nombre o proveedor más activo)
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                else // Opciones que devuelven conteos
                {
                    object resultado = cmd.ExecuteScalar();
                    return (resultado != DBNull.Value) ? Convert.ToInt32(resultado) : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
