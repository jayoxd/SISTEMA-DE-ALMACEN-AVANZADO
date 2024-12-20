using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
     public class E_Usuario
    {

        private int _id_empleado;
        private int _id_rol;
        private string _nombre_emp;
        private string _tipo_documento_emp;
        private string _num_documento_emp;
        private string _direccion_emp;
        private string _telefono_emp;
        private string _email;
        private string _clave;
        private bool _estado_emp;
        private string _buscaremp;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public int Id_rol { get => _id_rol; set => _id_rol = value; }
        public string Nombre_emp { get => _nombre_emp; set => _nombre_emp = value; }
        public string Tipo_documento_emp { get => _tipo_documento_emp; set => _tipo_documento_emp = value; }
        public string Num_documento_emp { get => _num_documento_emp; set => _num_documento_emp = value; }
        public string Direccion_emp { get => _direccion_emp; set => _direccion_emp = value; }
        public string Telefono_emp { get => _telefono_emp; set => _telefono_emp = value; }
        public string Email { get => _email; set => _email = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public bool Estado_emp { get => _estado_emp; set => _estado_emp = value; }
        public string Buscaremp { get => _buscaremp; set => _buscaremp = value; }




        // public string Buscaremp { get => _buscaremp; set => _buscaremp = value; }
    }
}
/*
 * 
 *  id_empleado integer primary key identity,
 idrol integer not null,
 nombre_emp varchar(50)null,
 tipo_documento_emp varchar(20)null,
 num_documento_emp varchar(20)null,
 direccion_emp varchar(50)null,
 telefono_emp varchar(20)null,
 clave_emp varbinary(MAX)not null,
 estado_emp bit default(1),
 * */