using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Cliente//  para que se comunique con otras clases lo ponemos el metodo publico
    {
        private int _idcliente;
        private String _nombre_cli;
        private String _tipo_documento_cli;
        private string _num_documento_cli;
        private String _direccion_clii;
        private String _telefono_cli;
        private String _email_cli;
        private string _buscarcli;



    
        private string _totalcliente;
        private string _totaldni;
        private string _totalempresas;


        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Nombre_cli { get => _nombre_cli; set => _nombre_cli = value; }
        public string Tipo_documento_cli { get => _tipo_documento_cli; set => _tipo_documento_cli = value; }
        public string Direccion_clii { get => _direccion_clii; set => _direccion_clii = value; }
        public string Telefono_cli { get => _telefono_cli; set => _telefono_cli = value; }
        public string Email_cli { get => _email_cli; set => _email_cli = value; }
        public string Buscarcli { get => _buscarcli; set => _buscarcli = value; }
        public string Num_documento_cli { get => _num_documento_cli; set => _num_documento_cli = value; }
        public string Totalcliente { get => _totalcliente; set => _totalcliente = value; }
        public string Totaldni { get => _totaldni; set => _totaldni = value; }
        public string Totalempresas { get => _totalempresas; set => _totalempresas = value; }
    }
}
//ingresamos las columnas de nuestra tabla cliente
/*@idcliente int,




despues encapsulamos los campos
y asi creamos la entidad cliente para que tenga una mejor comunicacion con las otras capaz
 * 
 * 
 * 
 * 
 */