using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class ConexionManager
    {
        private static string _connectionString;

        // Propiedad para obtener o establecer la cadena de conexión
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    // Valor por defecto (puede ser el primero del App.config)
                    _connectionString = ConfigurationManager.ConnectionStrings["Servidor2"].ConnectionString;
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
    }
}
