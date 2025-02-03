using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;
using System.Windows.Forms;


namespace CapaDatos
{
    public class D_EntradaProductos
    {
        private readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        // método para listar todas las entradas
        public DataTable ListarEntradas()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarEntradas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader leerFilas = cmd.ExecuteReader())
                    {
                        tabla.Load(leerFilas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar entradas: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }

        // método para buscar entradas con filtros
        public DataTable BuscarEntradas(E_Entrada entrada)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarEntradas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros con validación para fechas
                    cmd.Parameters.AddWithValue("@NroDocumento", (object)entrada.NroDocumento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProveedorID", entrada.ProveedorID == 0 ? DBNull.Value : (object)entrada.ProveedorID);
                    cmd.Parameters.AddWithValue("@FechaInicio", entrada.FechaInicio < new DateTime(1753, 1, 1) ? DBNull.Value : (object)entrada.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", entrada.FechaFin < new DateTime(1753, 1, 1) ? DBNull.Value : (object)entrada.FechaFin);
                    cmd.Parameters.AddWithValue("@Tipo_Comprobante", (object)entrada.TipoComprobante ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nro_Comprobante", (object)entrada.NroComprobante ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar entradas: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }


      

        // método para eliminar una entrada
        public string EliminarEntrada(string nroDocumento)
        {
            string respuesta = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarEntrada", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return respuesta;
        }

        // método para consultar detalles específicos de una entrada
        public DataTable ConsultarDetallesEntrada(string nroDocumento, string codigoProducto = null, string lote = null)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarDetalleEntradaProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroDocumento", (object)nroDocumento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoProducto", (object)codigoProducto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lote", (object)lote ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar detalles de entrada: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }


        public void EditarEntrada(E_Entrada entrada)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarEntradaConDetalles", conexion); // Procedimiento almacenado para editar
            cmd.CommandType = CommandType.StoredProcedure;

            // Se asegura de que la conexión esté correctamente abierta
            conexion.Open();

            // Agregar los parámetros necesarios
            cmd.Parameters.AddWithValue("@NroDocumento", entrada.NroDocumento);
            cmd.Parameters.AddWithValue("@ProveedorID", entrada.ProveedorID);
            cmd.Parameters.AddWithValue("@TipoCambio", entrada.TipoCambio);
            cmd.Parameters.AddWithValue("@Tipo_Comprobante", entrada.TipoComprobante);
            cmd.Parameters.AddWithValue("@Nro_Comprobante", entrada.NroComprobante);

            // Aquí pasamos el valor de "UserEdit", "FechaHoraSys" y "Fecha" (proporcionada por el usuario)
            cmd.Parameters.AddWithValue("@UserEdit", entrada.UserUpdate);         // Usuario que edita
            cmd.Parameters.AddWithValue("@FechaHoraSys", DateTime.Now);        // Fecha y hora actual (del sistema)
            cmd.Parameters.AddWithValue("@Fecha", entrada.Fecha);              // Fecha proporcionada por el usuario

            cmd.Parameters.AddWithValue("@Detalles", entrada.Detalles); // Tabla de detalles

            cmd.ExecuteNonQuery(); // Ejecutar el procedimiento
            conexion.Close(); // Cerrar la conexión
        }
        // método para insertar una entrada con sus detalles
        // Método para insertar una entrada con sus detalles
        public void InsertarEntrada(E_Entrada entrada)
        {
            SqlConnection SqlCon = new SqlConnection();

           
                    SqlCommand cmd = new SqlCommand("sp_InsertarEntradaConDetalles", conexion); // Procedimiento almacenado para editar
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                        conexion.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorID", entrada.ProveedorID);
                    cmd.Parameters.AddWithValue("@TipoCambio", entrada.TipoCambio);
                    cmd.Parameters.AddWithValue("@Tipo_Comprobante", entrada.TipoComprobante);
                    cmd.Parameters.AddWithValue("@Nro_Comprobante", entrada.NroComprobante);

                    // Aquí pasamos el valor de "UserCreate", "FechaHoraSys" y "Fecha" (proporcionada por el usuario)
                    cmd.Parameters.AddWithValue("@UserCreate", entrada.UserCreate);    // Usuario que crea
                    cmd.Parameters.AddWithValue("@FechaHoraSys", DateTime.Now);       // Fecha y hora actual (del sistema)
                    cmd.Parameters.AddWithValue("@Fecha", entrada.Fecha); // Fecha de prueba

                    cmd.Parameters.AddWithValue("@Detalles", entrada.Detalles); // Detalles enviados como tabla

            cmd.ExecuteNonQuery(); // Ejecutar el procedimiento
            conexion.Close(); // Cerrar la conexión

        }



        public DataSet ObtenerEntradaConDetalles(string nroDocumento)
        {
            DataSet ds = new DataSet();
            try
            {
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ConsultarEntradaConDetalles", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds); // Llena el DataSet con los datos
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la entrada: " + ex.Message);
            }
            return ds;
        }

        public DataTable BuscarPoEntradanrodoc(string valor)
        {
            DataTable table = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("buscar_entradas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del SP
                        cmd.Parameters.AddWithValue("@valor", valor);

                        // Ejecutar el comando
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar productos: " + ex.Message);
                }
            }
            return table;
        }
        public DataTable ObtenerEntradasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            using (SqlCommand comando = new SqlCommand("buscar_entradas_por_fechas", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@valor", (object)valor ?? DBNull.Value);
                comando.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                comando.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dtEntradas = new DataTable();
                adaptador.Fill(dtEntradas);

                return dtEntradas;
            }
        }

        
        public DataSet ConsultarEntradaConDetallesCompleto(string nroDocumento)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("sp_ConsultarEntradaConDetallesCompleto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los detalles de la entrada: " + ex.Message);
            }
        }

        public object EjecutarSpListarEntradas(int opcion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ListarEntradas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Opcion", opcion);

                    conexion.Open();

                    if (opcion == 5 || opcion == 6) // Devuelve un NroDocumento
                    {
                        var resultado = cmd.ExecuteScalar();
                        return resultado != DBNull.Value && resultado != null ? resultado.ToString() : "Sin datos disponibles";
                    }
                    else // Devuelve la cantidad de registros
                    {
                        var resultado = cmd.ExecuteScalar();
                        return resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de datos: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }


    }
}
