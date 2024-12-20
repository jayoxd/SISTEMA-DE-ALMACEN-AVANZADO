using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
     public class E_diagonostico
    {
        private int _iddiagnostico;
        private int _idempleado;
        private int _idvehiculo;
        private int _orden;
        private string _buscar_diagnostico;

        public int Idempleado { get => _idempleado; set => _idempleado = value; }
        public int Idvehiculo { get => _idvehiculo; set => _idvehiculo = value; }
        public int Orden { get => _orden; set => _orden = value; }
        public string Buscar_diagnostico { get => _buscar_diagnostico; set => _buscar_diagnostico = value; }
        public int Iddiagnostico { get => _iddiagnostico; set => _iddiagnostico = value; }
    }
}
