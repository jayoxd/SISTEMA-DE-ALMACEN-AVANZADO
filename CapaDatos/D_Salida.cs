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
    public class D_salida
    {
        private readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        // método para listar todas las entradas
        public DataTable ListaSalida()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarSalidas", conexion))
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


        public DataTable BuscarSalidas(E_salida salida)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarSalidas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros con validación para fechas y valores nulos
                    cmd.Parameters.AddWithValue("@NroDocumento", (object)salida.NroDocumento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClienteID", salida.clienteid == 0 ? DBNull.Value : (object)salida.clienteid);
                    cmd.Parameters.AddWithValue("@FechaInicio", salida.FechaInicio < new DateTime(1753, 1, 1) ? DBNull.Value : (object)salida.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", salida.FechaFin < new DateTime(1753, 1, 1) ? DBNull.Value : (object)salida.FechaFin);
                    cmd.Parameters.AddWithValue("@Tipo_Comprobante", (object)salida.TipoComprobante ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nro_Comprobante", (object)salida.NroComprobante ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar salidas: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }



        // método para insertar una salida con sus detalles
    public string InsertarSalida(E_salida salida)
{
    string nroDocumentoGenerado = "";

    try
    {
        using (SqlCommand cmd = new SqlCommand("sp_InsertarSalidaConDetalles", conexion))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClienteID", salida.clienteid);
            cmd.Parameters.AddWithValue("@Medio", salida.medio);
            cmd.Parameters.AddWithValue("@Observacion", salida.observacion ?? (object)DBNull.Value); 
            cmd.Parameters.AddWithValue("@Tipo_venta", salida.tipoVenta);
            cmd.Parameters.AddWithValue("@Tipo_Comprobante", salida.TipoComprobante);
            cmd.Parameters.AddWithValue("@Nro_Comprobante", salida.NroComprobante);
            cmd.Parameters.AddWithValue("@Detalles", salida.Detallessalida);
            cmd.Parameters.AddWithValue("@Codigo_Pedido", salida.CodigoPedido ?? (object)DBNull.Value); 
            cmd.Parameters.AddWithValue("@Transporte", salida.Transporte);
            cmd.Parameters.AddWithValue("@FechaDespacho", salida.FechaDespacho);
            cmd.Parameters.AddWithValue("@UserCreate", salida.UserCreate);
            cmd.Parameters.AddWithValue("@FechaHoraSys", DateTime.Now);
            cmd.Parameters.AddWithValue("@Fecha", salida.Fecha); 

            // 🔹 Parámetro de salida para capturar el `NroDocumento` generado
            SqlParameter outputParam = new SqlParameter("@NroDocumento", SqlDbType.VarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            conexion.Open();
            cmd.ExecuteNonQuery();

            // 🔹 Capturar el `NroDocumento` generado después de la ejecución del SP
            nroDocumentoGenerado = outputParam.Value.ToString();
        }
    }
    catch (Exception ex)
    {
        nroDocumentoGenerado = "Error: " + ex.Message;
    }
    finally
    {
        if (conexion.State == ConnectionState.Open) conexion.Close();
    }

    return nroDocumentoGenerado;  // 🔹 Devolvemos el `NroDocumento` generado
}

        public void EditarSalida(E_salida salida)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarSalidaConDetalles", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            // Agregar los parámetros necesarios
            cmd.Parameters.AddWithValue("@NroDocumento", salida.NroDocumento);
            cmd.Parameters.AddWithValue("@ClienteID", salida.clienteid);
            cmd.Parameters.AddWithValue("@Medio", salida.medio);
            cmd.Parameters.AddWithValue("@Observacion", salida.observacion);
            cmd.Parameters.AddWithValue("@TipoVenta", salida.tipoVenta);
            cmd.Parameters.AddWithValue("@Tipo_Comprobante", salida.TipoComprobante);
            cmd.Parameters.AddWithValue("@Nro_Comprobante", salida.NroComprobante);

            // Nuevos campos
            cmd.Parameters.AddWithValue("@Codigo_Pedido", salida.CodigoPedido ?? (object)DBNull.Value); // Validar nulo
            cmd.Parameters.AddWithValue("@Transporte", salida.Transporte);
            cmd.Parameters.AddWithValue("@FechaDespacho", salida.FechaDespacho);

            // Agregar parámetros de auditoría
            cmd.Parameters.AddWithValue("@UserEdit", salida.UserUpdate);         // Usuario que edita
            cmd.Parameters.AddWithValue("@FechaHoraSys", DateTime.Now);        // Fecha y hora actual (del sistema)
            cmd.Parameters.AddWithValue("@Fecha", salida.Fecha);              // Fecha proporcionada por el usuario

            // Tabla de detalles
            cmd.Parameters.AddWithValue("@Detalles", salida.Detallessalida);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        // método para eliminar una entrada
        public string EliminarSalida(string nroDocumento)
        {
            string respuesta = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarSalidaProducto", conexion))
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


        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedio(bool esInterno)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarTipoVenta", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro para diferenciar entre interno y externo
                    cmd.Parameters.AddWithValue("@EsInterno", esInterno);

                    conexion.Open();

                    using (SqlDataReader leerFilas = cmd.ExecuteReader())
                    {
                        tabla.Load(leerFilas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los tipos de venta: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }


        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedioint()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarTipoVentaint", conexion))
                {
                    conexion.Open();

                    using (SqlDataReader leerFilas = cmd.ExecuteReader())
                    {
                        tabla.Load(leerFilas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los tipos de venta: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return tabla;
        }


        public DataSet ObtenerSalidaConDetalles(string nroDocumento)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarSalidaConDetalles", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NroDocumento", nroDocumento);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds); // Llena el DataSet con los datos
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la salida: " + ex.Message);
            }
            return ds;
        }

        public DataTable BuscarPorSalidaNroDoc(string valor)
        {
            DataTable table = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("buscar_salidas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetro del SP
                        cmd.Parameters.AddWithValue("@valor", valor);

                        // Ejecutar el comando
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar salidas: " + ex.Message);
                }
            }
            return table;
        }
        public DataTable ObtenerSalidasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            using (SqlCommand comando = new SqlCommand("buscar_salidas_por_fechas", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@valor", (object)valor ?? DBNull.Value);
                comando.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                comando.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dtSalidas = new DataTable();
                adaptador.Fill(dtSalidas);

                return dtSalidas;
            }
        }


        public DataSet ConsultarSalidaConDetallesCompleto(string nroDocumento)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("sp_ConsultarSalidaConDetallesCompleto", conexion))
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


        // Método para ejecutar las opciones del procedimiento almacenado
        public object EjecutarOpcionSalidas(int opcion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Salidas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", opcion);

                conexion.Open();

                if (opcion == 4 || opcion == 5) // Opciones que devuelven un NroDocumento
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                else // Opciones que devuelven un conteo
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
