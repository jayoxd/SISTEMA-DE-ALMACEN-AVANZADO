using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class N_Vehiculo
    {
        D_Vehiculo objDatos = new D_Vehiculo();
        E_Vehiculo entidades = new E_Vehiculo();

        public DataTable listandoVehiculo()
        {
            return objDatos.ListarVehiculo();
        }


        public DataTable buscandoVehiculo(int vehiculobus)
        {
           
            entidades.Buscar_vehiculo=vehiculobus;
            return objDatos.buscarVehiculo(entidades);
        }

        public void insertandoVehiculo(E_Vehiculo vehiculo)
        {
            objDatos.insertarVehiculo(vehiculo);
        }

        public void editandoVehiculo(E_Vehiculo vehiculo)
        {
            objDatos.EditarVehiculo(vehiculo);
        }

        public void eliminandoVehiculo(E_Vehiculo vehiculo)
        {
            objDatos.EliminarVehiculo(vehiculo);
        }

     

        public void sumarVehiculos(E_Vehiculo vehiculo)
        {
            objDatos.totalclientesveh(vehiculo);
        }


    }
}
