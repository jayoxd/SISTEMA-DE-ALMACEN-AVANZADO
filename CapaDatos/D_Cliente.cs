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
    public class D_Cliente
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de buscar y listar los  objetos como los atributos en la entidad cliente
            public DataTable ListarClientes()
            {
                DataTable table = new DataTable();
                SqlDataReader leerfilas;
                SqlCommand cmd = new SqlCommand("sp_verclientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                leerfilas = cmd.ExecuteReader();
                table.Load(leerfilas);

                leerfilas.Close();
                conexion.Close();

                return table;

            }

        public DataTable BuscarCliente(E_Cliente clientes)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_buscar_cliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", clientes.Buscarcli);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public void totalclientes(E_Cliente clientes)
        {
            SqlCommand cmd = new SqlCommand("sp_total_clientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter totalCliente = new SqlParameter("@totalCliente", 0);
            totalCliente.Direction = ParameterDirection.Output;


            SqlParameter totalDni = new SqlParameter("@totaldni", 0);
            totalDni.Direction = ParameterDirection.Output;

            SqlParameter totalEmpresas = new SqlParameter("@totalEmpresas", 0);
            totalEmpresas.Direction = ParameterDirection.Output;

     
            cmd.Parameters.Add(totalCliente);
            cmd.Parameters.Add(totalDni);
            cmd.Parameters.Add(totalEmpresas);
            conexion.Open();

            cmd.ExecuteNonQuery();

            clientes.Totalcliente = cmd.Parameters["@totalCliente"].Value.ToString();
            clientes.Totaldni = cmd.Parameters["@totaldni"].Value.ToString();
            clientes.Totalempresas = cmd.Parameters["@totalEmpresas"].Value.ToString();

            conexion.Close();
        }


        public void insertarCliente(E_Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("spInsertar_clientes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre_cli);
            cmd.Parameters.AddWithValue("@tip_documen_cli", cliente.Tipo_documento_cli);
            cmd.Parameters.AddWithValue("@num_docum_cli", cliente.Num_documento_cli);
            cmd.Parameters.AddWithValue("@direc_cli", cliente.Direccion_clii);
            cmd.Parameters.AddWithValue("@telef_cli", cliente.Telefono_cli);
            cmd.Parameters.AddWithValue("@email_cli", cliente.Email_cli);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarCliente(E_Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_editar_cliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();


            cmd.Parameters.AddWithValue("@idcliente", cliente.Idcliente);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre_cli);
            cmd.Parameters.AddWithValue("@tip_documen_cli", cliente.Tipo_documento_cli);
            cmd.Parameters.AddWithValue("@num_docum_cli", cliente.Num_documento_cli);
            cmd.Parameters.AddWithValue("@direc_cli", cliente.Direccion_clii);
            cmd.Parameters.AddWithValue("@telef_cli", cliente.Telefono_cli);
            cmd.Parameters.AddWithValue("@email_cli", cliente.Email_cli);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCliente(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_cliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idcliente", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }



    }
}
