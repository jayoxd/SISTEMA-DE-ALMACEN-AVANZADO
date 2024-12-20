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
    public class D_ReporteDiagnostico
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable ListarReporteDiagnostico()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_ver_reportes_diagnostico_todos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }

        public DataTable BuscarReportDiag(E_ReporteDiagnostico report)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_reportdiag_buscar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@repordiagnostico", report.Buscar);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public void insertarReporteDiagnostico(E_ReporteDiagnostico reportediagnostico)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_reporte_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@iddiagnostico", reportediagnostico.Iddiagnostico);
            cmd.Parameters.AddWithValue("@empleado", reportediagnostico.Idempleado);
            cmd.Parameters.AddWithValue("@descripcion", reportediagnostico.Descripcion_rep_dia);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }



     
        public void EliminarReportdiag(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_reportediag", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@eliminar", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
     
    }
}