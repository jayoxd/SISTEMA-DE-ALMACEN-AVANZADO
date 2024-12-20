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
    public class D_Productos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable listaProductos()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_ver_productos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }
        public DataTable buscarProductosventa(E_Productos productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("producto_codigo_buscar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@valor", productos.Buscar_prod);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }


        public DataTable buscarProductos(E_Productos productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_buscar_producto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarpro", productos.Buscar_prod);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }


        public void totalproducos(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("sp_sumarpc", conexion);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter totalCategorias = new SqlParameter("@totalCategoria", 0);
            totalCategorias.Direction = ParameterDirection.Output;


            SqlParameter totalProductos = new SqlParameter("@totalProducto", 0);
              totalProductos.Direction = ParameterDirection.Output;


            SqlParameter totalStock = new SqlParameter("@totalstock", 0);
            totalStock.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(totalCategorias);
            cmd.Parameters.Add(totalProductos);
            cmd.Parameters.Add(totalStock);
            conexion.Open();

            cmd.ExecuteNonQuery();

            productos.TotalCategoria = cmd.Parameters["@totalCategoria"].Value.ToString();
            productos.TotalProductos = cmd.Parameters["@totalProducto"].Value.ToString();
            productos.Totalstock = cmd.Parameters["@totalstock"].Value.ToString();

            conexion.Close();
        }



        public void insertarProducto(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_productos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idcategoria", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@nombre_pro", productos.Nombre_pro);
            cmd.Parameters.AddWithValue("@marca_pro", productos.Marca_pro);
            cmd.Parameters.AddWithValue("@precio_venta_pro", productos.Precio_venta);
            cmd.Parameters.AddWithValue("@stock_pro", productos.Stock_pro);
            cmd.Parameters.AddWithValue("@descripcion_pro", productos.Descripcion_pro);
            cmd.Parameters.AddWithValue("@imagen_pro", productos.Imagen_pro);


            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarProductos(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("sp_editar_productos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idproducto", productos.Idproducto);
            cmd.Parameters.AddWithValue("@idcategoria", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@nombre_pro", productos.Nombre_pro);
            cmd.Parameters.AddWithValue("@marca_pro", productos.Marca_pro);
            cmd.Parameters.AddWithValue("@precio_venta_pro", productos.Precio_venta);
            cmd.Parameters.AddWithValue("@stock_pro", productos.Stock_pro);
            cmd.Parameters.AddWithValue("@descripcion_pro", productos.Descripcion_pro);
            cmd.Parameters.AddWithValue("@imagen_pro", productos.Imagen_pro);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void EliminarProductos(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_producto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idproducto", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
