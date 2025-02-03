using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Clientes//  para que se comunique con otras clases lo ponemos el metodo publico
    {
        private int _idcliente;
        private String _nombre;
        private string _dni;
        private String _direccion;
        private String _telefono;
        private String _email;
        private string _buscarcli;
        private string _totalcliente;

        private String _origencliente;
        private String _departamento;
        private String _provincia;
        private String _distrito;
        private String _googlemaps;
        private bool _estado; // Nuevo atributo


        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string dni { get => _dni; set => _dni = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Buscarcli { get => _buscarcli; set => _buscarcli = value; }
        public string Totalcliente { get => _totalcliente; set => _totalcliente = value; }

        public String origencliente { get => _origencliente; set => _origencliente = value; }

        public String departamento { get => _departamento; set => _departamento = value; }
        public String provincia { get => _provincia; set => _provincia = value; }   
        public String distrito { get => _distrito; set => _distrito = value; }
        public String googlemaps { get => _googlemaps; set => _googlemaps = value; }    
        public bool Estado { get => _estado; set => _estado = value; } // Nuevo getter y setter


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