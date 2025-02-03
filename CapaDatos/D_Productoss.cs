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
    public class D_Productoss
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable listaProductos(bool? estado = null)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ConsultarProductos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoProducto", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Categoria", DBNull.Value);
                        cmd.Parameters.AddWithValue("@PrecioMin", DBNull.Value);
                        cmd.Parameters.AddWithValue("@PrecioMax", DBNull.Value);
                        cmd.Parameters.AddWithValue("@DescripcionProducto", DBNull.Value);
                        cmd.Parameters.AddWithValue("@StockMin", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader leerfilas = cmd.ExecuteReader())
                        {
                            table.Load(leerfilas);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: " + ex.Message);
            }
            return table;
        }


        public DataTable listaProductos1(bool? estado = null)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarProductos1", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodigoProducto", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Categoria", DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioMin", DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrecioMax", DBNull.Value);
                    cmd.Parameters.AddWithValue("@DescripcionProducto", DBNull.Value);
                    cmd.Parameters.AddWithValue("@StockMin", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", (object)estado ?? DBNull.Value);

                    conexion.Open();
                    using (SqlDataReader leerfilas = cmd.ExecuteReader())
                    {
                        table.Load(leerfilas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return table;
        }



        public DataTable buscarProductosCategoria(E_productoss productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ConsultarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Categoria", productos.Buscar_producto);
     

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }
        public DataTable BuscarProductoPorCodigoODescripcion(string valor, bool activo)
        {
            DataTable table = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("producto_codigo_o_descripcion_buscar", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del SP
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@activo", activo);

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


        public DataTable buscarProductosporProduct(E_productoss productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ConsultarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@CodigoProducto", productos.Buscar_producto);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public DataTable buscarProductosPrecioMinMax(E_productoss productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ConsultarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@PrecioMin", productos.Preciominimo);
            cmd.Parameters.AddWithValue("@PrecioMax", productos.Preciomaximo);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public DataTable buscarProductoStockMin(E_productoss productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ConsultarProductos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@StockMin", productos.Stockminimo);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }



        public void OcultarProducto(string codigoProducto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_OcultarProducto", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                throw new Exception("Error al ocultar el producto: " + ex.Message);
            }
        }

     
        public bool VerificarCodigoProducto(string codigoProducto)
        {
            {
                SqlCommand cmd = new SqlCommand("sp_VerificarCodigoProducto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);

                conexion.Open();
                int existe = Convert.ToInt32(cmd.ExecuteScalar());
                return existe == 1; // Devuelve true si existe
            }
        }

        public void EditarProductos(E_productoss productos)
        {
            SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@CodigoProducto", productos.CodigoProducto);
            cmd.Parameters.AddWithValue("@DescripcionProducto", productos.DescripcionProducto);
            cmd.Parameters.AddWithValue("@Categoria", productos.Categoria);
            cmd.Parameters.AddWithValue("@PrecioUnitario", productos.PrecioUnitario);
            cmd.Parameters.AddWithValue("@StockActual", productos.StockActual);
            cmd.Parameters.AddWithValue("@Estado", productos.estado);
            // Agregar parámetros de precios de venta
            cmd.Parameters.AddWithValue("@BASICO", productos.BASICO != null ? productos.BASICO : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Saga", productos.Saga != null ? productos.Saga : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Agora", productos.Agora != null ? productos.Agora : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Ripley", productos.Ripley != null ? productos.Ripley : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Mayorista_3_5", productos.Mayorista_3_5 != null ? productos.Mayorista_3_5 : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Mayorista_X_Caja", productos.Mayorista_X_Caja != null ? productos.Mayorista_X_Caja : (object)DBNull.Value);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void insertarProducto(E_productoss productos)
        {
            SqlCommand cmd = new SqlCommand("sp_AgregarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@CodigoProducto", productos.CodigoProducto);
            cmd.Parameters.AddWithValue("@DescripcionProducto", productos.DescripcionProducto);
            cmd.Parameters.AddWithValue("@Categoria", productos.Categoria);
            cmd.Parameters.AddWithValue("@PrecioUnitario", productos.PrecioUnitario);
            cmd.Parameters.AddWithValue("@StockActual", productos.StockActual);
            cmd.Parameters.AddWithValue("@Estado", productos.estado);
            // Agregar parámetros de precios de venta
            cmd.Parameters.AddWithValue("@BASICO", productos.BASICO);
            cmd.Parameters.AddWithValue("@Saga", productos.Saga);
            cmd.Parameters.AddWithValue("@Agora", productos.Agora);
            cmd.Parameters.AddWithValue("@Ripley", productos.Ripley);
            cmd.Parameters.AddWithValue("@Mayorista_3_5", productos.Mayorista_3_5);
            cmd.Parameters.AddWithValue("@Mayorista_X_Caja", productos.Mayorista_X_Caja);


            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public DataTable ObtenerReporteInventario(string codigoProducto, DateTime? fechaInicio, DateTime? fechaFin)
        {
            {
                using (SqlCommand comando = new SqlCommand("sp_ReporteInventario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodigoProducto", (object)codigoProducto ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable dtReporte = new DataTable();
                    adaptador.Fill(dtReporte);

                    return dtReporte;
                }
            }
        }

        public DataTable ObtenerReporteInventariotodo()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_ReporteInventario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }
        public void CambiarEstadoProducto(string codigoProducto, bool estado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CambiarEstadoProducto", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Pasar parámetros al procedimiento almacenado
                cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);
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
                throw new Exception("Error al cambiar el estado del producto: " + ex.Message);
            }
        }

        public string ObtenerUltimoProductoRegistrado()
        {
            string ultimoProducto = "Sin datos disponibles";
            try
            {
                // Comando para obtener los productos
                SqlCommand cmd = new SqlCommand("SELECT p.CodigoProducto FROM Productoss p INNER JOIN PRECIO_Venta pv ON p.CodigoProducto = pv.CodigoProducto", conexion);

                conexion.Open();

                // Ejecutar la consulta y obtener los datos
                SqlDataReader reader = cmd.ExecuteReader();

                // Lista para almacenar los productos
                List<string> productos = new List<string>();

                // Leer todos los registros
                while (reader.Read())
                {
                    productos.Add(reader["CodigoProducto"].ToString());
                }

                // Verificar si hay productos y tomar el último
                if (productos.Count > 0)
                {
                    ultimoProducto = productos[productos.Count - 1]; // Tomar el último producto
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último producto registrado: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return ultimoProducto;
        }

        public int ContarProductosPorEstado(bool estado)
        {
            int total = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Productoss WHERE Estado = @Estado", conexion);
                cmd.Parameters.AddWithValue("@Estado", estado);
                conexion.Open();
                total = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los productos por estado: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return total;
        }
        public DataTable ObtenerProductoConMasMovimientos(int opcion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ProductoConMasMovimientos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opcion", opcion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conexion.Open();
                da.Fill(dt);

                return dt;
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
        public int ObtenerStockActual(string codigoProducto)
        {
            int stockActual = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerStockActualProducto", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoProducto", codigoProducto);

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
                    {
                        conn.Open(); // Abre la conexión
                        cmd.Connection = conn;

                        // Ejecutar el comando y asignar el valor devuelto a stockActual
                        var result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            stockActual = Convert.ToInt32(result); // Asigna el valor de stock si existe
                        }
                        else
                        {
                            // Si el resultado es DBNull, asigna 0 o maneja el caso de acuerdo a tu lógica
                            stockActual = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones con detalle
                throw new Exception("Error al obtener el stock del producto: " + ex.Message);
            }

            return stockActual;
        }



    }
}
