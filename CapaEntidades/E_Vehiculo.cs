using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class E_Vehiculo
    {

        private int _idvehiculo;
        private int _idcliente;
        private String _placa_veh;
        private String _modelo_veh;
        private String _marca_veh;
        private String _año_veh;
        private int _buscar_vehiculo;

        private string _totalvehiculo;
     

      
        public string Totalvehiculo { get => _totalvehiculo; set => _totalvehiculo = value; }
        public int Buscar_vehiculo { get => _buscar_vehiculo; set => _buscar_vehiculo = value; }
        public int Idvehiculo { get => _idvehiculo; set => _idvehiculo = value; }
        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Placa_veh { get => _placa_veh; set => _placa_veh = value; }
        public string Modelo_veh { get => _modelo_veh; set => _modelo_veh = value; }
        public string Marca_veh { get => _marca_veh; set => _marca_veh = value; }
        public string Año_veh { get => _año_veh; set => _año_veh = value; }
    }
}
