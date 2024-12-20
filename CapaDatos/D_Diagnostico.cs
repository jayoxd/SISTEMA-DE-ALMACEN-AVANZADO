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
    public class D_Diagnostico
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        //metodo encargado de buscar y listar los  objetos como los atributos en la entidad cliente
        public DataTable ListarDignostico()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_listar_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();


            return table;

        }
        

        public DataTable rellenar_campo(object cam,TextBox nombre,string xTbox,string Campo)
        {
            DataTable table = new DataTable("relenar");
            SqlCommand cmd = new SqlCommand("sp_buscar_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarpro", xTbox);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                nombre.Text = row[Campo].ToString();
            }
            conexion.Close();
            return table;

        }


        public void insertarDiagnostico(E_diagonostico diagnostico)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@empleado",diagnostico.Idempleado);
            cmd.Parameters.AddWithValue("@vehiculo",diagnostico.Idvehiculo);
            cmd.Parameters.AddWithValue("@orden",diagnostico.Orden);
          
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

  

        public void EliminarDiagnostico(E_diagonostico diagnostico)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idservicio", diagnostico.Iddiagnostico);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }












        public DataTable BuscarDiagnostico(E_diagonostico diagnostico)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_buscar_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarpro", diagnostico.Buscar_diagnostico);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

    }
}
