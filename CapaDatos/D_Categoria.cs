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
     public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Categoria> ListarCategoria(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("sp_buscar_categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarc", buscar);


            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    Idcategoria = LeerFilas.GetInt32(0),
                    Nombre_cat = LeerFilas.GetString(1),
                    Descripcion_cat = LeerFilas.GetString(2),

                });
            }

            conexion.Close();
            LeerFilas.Close();

            return Listar;

        }


        public void insertarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre_cat", categoria.Nombre_cat);
            cmd.Parameters.AddWithValue("@descripcion_cat", categoria.Descripcion_cat);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_editar_categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();


            cmd.Parameters.AddWithValue("@idcategoria_cat", categoria.Idcategoria);
            cmd.Parameters.AddWithValue("@nombre_cat", categoria.Nombre_cat);
            cmd.Parameters.AddWithValue("@descripcion_cat", categoria.Descripcion_cat);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void EliminarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idcategoria_cat", categoria.Idcategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }







    }
}
