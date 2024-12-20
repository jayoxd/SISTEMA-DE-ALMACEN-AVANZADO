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
    public class D_Servicio
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de buscar y listar los  objetos como los atributos en la entidad cliente
        public DataTable ListarServicio()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_servicio_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }

        public DataTable BuscarServicio(E_Servicio servicio)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_buscar_servcio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarservicio", servicio.Buscar);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();   
            return tabla;
        }


     

        public string insertarServicio(E_Servicio servicio)
        {

            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_servicio_insertar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
              

                cmd.Parameters.AddWithValue("@idempleado", SqlDbType.Int).Value = servicio.Idusuario;
            cmd.Parameters.AddWithValue("@idreporter", SqlDbType.Int).Value = servicio.IdReporte;
            cmd.Parameters.AddWithValue("@num_compro", SqlDbType.VarChar).Value = servicio.NroComprobante;
            cmd.Parameters.AddWithValue("@precio_servicio_comp", SqlDbType.Decimal).Value = servicio.Precioservicio;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Decimal).Value = servicio.Total;
            cmd.Parameters.AddWithValue("@detalle", SqlDbType.Structured).Value = servicio.detalles;
            conexion.Open();
            cmd.ExecuteNonQuery();
            Rpta = "OK";
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
        public  string Anular(int Id)
        {
            string Rpta = "";
            try
            {
             
                SqlCommand Comando = new SqlCommand("venta_anular",conexion);
                Comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                Comando.Parameters.Add("@idventa", SqlDbType.Int).Value = Id;
                Comando.ExecuteNonQuery();
                Rpta = "OK";
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

        public DataTable buscarDetalledeUnaVenta(E_Servicio servicio)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("detalle_de_una_venta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idservicio", servicio.Idservicio);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }



    }
}
