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
    public class D_Vehiculo
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);


        public DataTable ListarVehiculo()
        {
            DataTable table = new DataTable();
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("sp_listar_vehiculo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            leerfilas = cmd.ExecuteReader();
            table.Load(leerfilas);

            leerfilas.Close();
            conexion.Close();

            return table;

        }


        public DataTable buscarVehiculo(E_Vehiculo vehiculo )
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_ver_vehiculo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscarvehiculo",vehiculo.Buscar_vehiculo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            return tabla;
        }

        public void totalclientesveh(E_Vehiculo vehiculo)
        {
            SqlCommand cmd = new SqlCommand("sp_cliente_vehi", conexion);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter totalVehiculo = new SqlParameter("@totalVehiculo", 0);
            totalVehiculo.Direction = ParameterDirection.Output;


            cmd.Parameters.Add(totalVehiculo);
      
            conexion.Open();

            cmd.ExecuteNonQuery();

            vehiculo.Totalvehiculo = cmd.Parameters["@totalVehiculo"].Value.ToString();

            conexion.Close();
        }






        public void insertarVehiculo(E_Vehiculo vehiculo)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar_vehiculo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idcliente",vehiculo.Idcliente);
            cmd.Parameters.AddWithValue("@placa_veh", vehiculo.Placa_veh);
            cmd.Parameters.AddWithValue("@modelo_veh",vehiculo.Modelo_veh);
            cmd.Parameters.AddWithValue("@marca_veh",vehiculo.Marca_veh);
            cmd.Parameters.AddWithValue("@año_veh", vehiculo.Año_veh);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarVehiculo(E_Vehiculo vehiculo)
        {
            SqlCommand cmd = new SqlCommand("sp_editar_vehiculo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idvehiculo", vehiculo.Idvehiculo);
            cmd.Parameters.AddWithValue("@idcliente", vehiculo.Idcliente);
            cmd.Parameters.AddWithValue("@placa_veh", vehiculo.Placa_veh);
            cmd.Parameters.AddWithValue("@modelo_veh", vehiculo.Modelo_veh);
            cmd.Parameters.AddWithValue("@marca_veh", vehiculo.Marca_veh);
            cmd.Parameters.AddWithValue("@año_veh", vehiculo.Año_veh);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public void EliminarVehiculo(E_Vehiculo vehiculo)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_vehiculo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idvehiculo",vehiculo.Idvehiculo);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
