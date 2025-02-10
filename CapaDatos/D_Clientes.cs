using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos

{
    public class D_Clientes
    {

        private readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        // Método para listar clientes
        public DataTable ListarClientes()
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("ConsultarClientes", conexion)
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


        // método para consultar clientes con filtros
        public DataTable ConsultarClientes(string filtro = null, bool? estado = null)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarClientes", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FiltroGeneral", (object)filtro ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar clientes: " + ex.Message);
            }
            return tabla;
        }


        // Método para insertar un cliente
        public void InsertarCliente(E_Clientes cliente)
        {
            SqlCommand cmd = new SqlCommand("InsertarClientes", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            cmd.Parameters.AddWithValue("@DNI", cliente.dni);
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@OrigenCliente", cliente.origencliente);
            cmd.Parameters.AddWithValue("@Departamento", cliente.departamento);
            cmd.Parameters.AddWithValue("@Provincia", cliente.provincia);
            cmd.Parameters.AddWithValue("@Distrito", cliente.distrito);
            cmd.Parameters.AddWithValue("@GoogleMaps", cliente.googlemaps);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // Método para actualizar un cliente
        public void ActualizarCliente(E_Clientes cliente)
        {
            SqlCommand cmd = new SqlCommand("ActualizarCliente", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            conexion.Open();

            cmd.Parameters.AddWithValue("@ClienteID", cliente.Idcliente);
            cmd.Parameters.AddWithValue("@DNI", cliente.dni);
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@OrigenCliente", cliente.origencliente);
            cmd.Parameters.AddWithValue("@Departamento", cliente.departamento);
            cmd.Parameters.AddWithValue("@Provincia", cliente.provincia);
            cmd.Parameters.AddWithValue("@Distrito", cliente.distrito);
            cmd.Parameters.AddWithValue("@GoogleMaps", cliente.googlemaps);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

     

        public int ObtenerClientesActivos()
        {
            int totalClientesActivos = 0;
            SqlCommand cmd = new SqlCommand("sp_ClientesActivos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                totalClientesActivos = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return totalClientesActivos;
        }
        public int ObtenerProveedoresActivos()
        {
            int totalProveedoresActivos = 0;
            SqlCommand cmd = new SqlCommand("sp_ProveedoresActivos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                totalProveedoresActivos = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return totalProveedoresActivos;
        }

        public int ObtenerProductosBajoStock(int stockMinimo)
        {
            int productosBajoStock = 0;
            SqlCommand cmd = new SqlCommand("sp_ProductosBajoStock", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                productosBajoStock = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return productosBajoStock;
        }
        public int ObtenerProductosActivos()
        {
            int totalProductosActivos = 0;
            SqlCommand cmd = new SqlCommand("sp_ProductosActivos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                totalProductosActivos = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return totalProductosActivos;
        }
        public decimal ObtenerIngresosDiarios(DateTime fecha)
        {
            decimal ingresosTotales = 0;
            SqlCommand cmd = new SqlCommand("sp_IngresosDiarios", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parámetro para la fecha
            cmd.Parameters.AddWithValue("@Fecha", fecha);

            conexion.Open();

            var resultado = cmd.ExecuteScalar(); // Ejecuta el SP y obtiene un valor único

            if (resultado != DBNull.Value && resultado != null)
            {
                ingresosTotales = Convert.ToDecimal(resultado); // Convierte el resultado
            }

            conexion.Close();

            return ingresosTotales; // Devuelve el valor
        }

        public int ObtenerEntradasRecientes()
        {
            int totalEntradas = 0;
            SqlCommand cmd = new SqlCommand("sp_EntradasRecientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                totalEntradas = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return totalEntradas;
        }

        public int ObtenerSalidasRecientes()
        {
            int totalEntradas = 0;
            SqlCommand cmd = new SqlCommand("sp_SalidasRecientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            var resultado = cmd.ExecuteScalar();
            if (resultado != DBNull.Value && resultado != null)
            {
                totalEntradas = Convert.ToInt32(resultado);
            }

            conexion.Close();
            return totalEntradas;
        }

        public void CambiarEstadoCliente(int clienteID, bool estado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_OcultarCliente", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Pasar parámetros al procedimiento almacenado
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
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
                throw new Exception("Error al cambiar el estado del cliente: " + ex.Message);
            }
        }

        public bool ExisteCliente(string RUC)
        {
           
            
                SqlCommand cmd = new SqlCommand("sp_ExisteClienteRUC", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Pasar parámetros al procedimiento almacenado
                cmd.Parameters.AddWithValue("@dni", RUC);


                // Abrir conexión
                conexion.Open();
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
                conexion.Close();
            return resultado > 0;

        }

        public object EjecutarOpcionClientes(int opcion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_IndicadoresClientes", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Opcion", opcion);

                conexion.Open();

                if (opcion == 2 || opcion == 4) // Opciones que devuelven datos (nombre o cliente más activo)
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
