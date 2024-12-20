    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class E_Rol
    {

        private int _idrol;
        private string _nombre_rol;
        private string _descripcion_rol;
        private bool _estado_rol;
        private string _buscar_rol;

        public int Idrol { get => _idrol; set => _idrol = value; }
        public string Nombre_rol { get => _nombre_rol; set => _nombre_rol = value; }
        public string Descripcion_rol { get => _descripcion_rol; set => _descripcion_rol = value; }
        public bool Estado_rol { get => _estado_rol; set => _estado_rol = value; }
        public string Buscar_rol { get => _buscar_rol; set => _buscar_rol = value; }
    }
}
