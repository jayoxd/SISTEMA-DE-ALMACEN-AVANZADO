using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{




    public class E_Indicadores
    {

        // Variables privadas
        private int _idindicador;
        private string _nombre_indicador;
        private string _descripcion_indicador;
        private int _valor_indicador; // Valor numérico del indicador
        private DateTime _fecha_consulta; // Fecha en la que se obtiene el valor del indicador

        // Propiedades públicas
        public int Idindicador { get => _idindicador; set => _idindicador = value; }
        public string Nombre_indicador { get => _nombre_indicador; set => _nombre_indicador = value; }
        public string Descripcion_indicador { get => _descripcion_indicador; set => _descripcion_indicador = value; }
        public int Valor_indicador { get => _valor_indicador; set => _valor_indicador = value; }
        public DateTime Fecha_consulta { get => _fecha_consulta; set => _fecha_consulta = value; }
    }
}
