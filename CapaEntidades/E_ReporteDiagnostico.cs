using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_ReporteDiagnostico
    {
        private int _idrepoter_diagnostico;
        private int _iddiagnostico;
        private int _idempleado;
        private string _descripcion_rep_dia;
        private string _buscar;

        public int Idrepoter_diagnostico { get => _idrepoter_diagnostico; set => _idrepoter_diagnostico = value; }
        public int Iddiagnostico { get => _iddiagnostico; set => _iddiagnostico = value; }
        public int Idempleado { get => _idempleado; set => _idempleado = value; }
        public string Descripcion_rep_dia { get => _descripcion_rep_dia; set => _descripcion_rep_dia = value; }
        public string Buscar { get => _buscar; set => _buscar = value; }
    }
}
