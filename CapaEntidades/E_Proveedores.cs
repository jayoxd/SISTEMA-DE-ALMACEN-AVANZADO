using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_proveedores//  para que se comunique con otras clases lo ponemos el metodo publico
    {
        private int _ProveedorID;
        private String _nombre;
        private string _ruc;
        private String _direccion;
        private String _telefono;
        private String _email;
        private string _buscarprov;
        private string _totalprov;
        private bool _estado; // Nuevo atributo

        public int idProveedor { get => _ProveedorID; set => _ProveedorID = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Ruc { get => _ruc; set => _ruc = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string BuscarProv { get => _buscarprov; set => _buscarprov = value; }
        public string TotalProv { get => _totalprov; set => _totalprov = value; }
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