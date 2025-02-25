using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;
using System.IO;

namespace CapaNegocio
{
    public class N_Clientes
    {

        D_Clientes objDatos = new D_Clientes();
        string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

        public DataTable listandoClientes()
        {
            return objDatos.ListarClientes();
        }

        public DataTable ConsultarClientes(string filtro = null, bool? estado = null)
        {
            return objDatos.ConsultarClientes(filtro, estado);
        }


        public void insertandoCliente(E_Clientes Clientez)
        {
            objDatos.InsertarCliente(Clientez);
        }

        public void editandoCliente(E_Clientes Clientez)
        {
            objDatos.ActualizarCliente(Clientez);
        }

        public string GenerarScriptInsertar(E_Clientes cliente)
        {
            string script = $@"
        EXEC InsertarClientes 
        @DNI = {FormatearValor(cliente.dni)}, 
        @Nombre = {FormatearValor(cliente.Nombre)}, 
        @Direccion = {FormatearValor(cliente.Direccion)}, 
        @Telefono = {FormatearValor(cliente.Telefono)}, 
        @Email = {FormatearValor(cliente.Email)}, 
        @OrigenCliente = {FormatearValor(cliente.origencliente)}, 
        @Departamento = {FormatearValor(cliente.departamento)}, 
        @Provincia = {FormatearValor(cliente.provincia)}, 
        @Distrito = {FormatearValor(cliente.distrito)}, 
        @GoogleMaps = {FormatearValor(cliente.googlemaps)};";
            GuardarScriptEnArchivo(script, "InsertarCliente");
            return script;
        }
            
        public string GenerarScriptActualizar(E_Clientes cliente)
        {
            string script = $@"
        EXEC ActualizarCliente 
        @ClienteID = {cliente.Idcliente}, 
        @DNI = {FormatearValor(cliente.dni)}, 
        @Nombre = {FormatearValor(cliente.Nombre)}, 
        @Direccion = {FormatearValor(cliente.Direccion)}, 
        @Telefono = {FormatearValor(cliente.Telefono)}, 
        @Email = {FormatearValor(cliente.Email)}, 
        @OrigenCliente = {FormatearValor(cliente.origencliente)}, 
        @Departamento = {FormatearValor(cliente.departamento)}, 
        @Provincia = {FormatearValor(cliente.provincia)}, 
        @Distrito = {FormatearValor(cliente.distrito)}, 
        @GoogleMaps = {FormatearValor(cliente.googlemaps)};";
            GuardarScriptEnArchivo(script, "ActualizarCliente");
            return script;
        }

        // Función para formatear valores, reemplazando valores vacíos con NULL
        private string FormatearValor(string valor)
        {
            return string.IsNullOrEmpty(valor) ? "NULL" : $"'{valor.Replace("'", "''")}'";
        }
        private void GuardarScriptEnArchivo(string script, string tipoOperacion)
        {
            try
            {
                // Crear la carpeta si no existe
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                // Nombre del archivo con fecha y hora
                string nombreArchivo = $"{tipoOperacion}_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

                // Escribir el script en el archivo
                File.WriteAllText(rutaArchivo, script);

                Console.WriteLine($"Script guardado en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
        }

        public int ObtenerClientesActivos()
        {
            return objDatos.ObtenerClientesActivos();
        }

        public int ObtenerProveedoresActivos()
        {
            return objDatos.ObtenerProveedoresActivos();
        }
        public int ObtenerProductosBajoStock(int stockMinimo)
        {
            return objDatos.ObtenerProductosBajoStock(stockMinimo);
        }
        public int ObtenerProductosActivos()
        {
            return objDatos.ObtenerProductosActivos();
        }


        public decimal ObtenerIngresosDiarios(DateTime fecha)
        {
            return objDatos.ObtenerIngresosDiarios(fecha);
        }
        public int ObtenerEntradasRecientes()
        {
            return objDatos.ObtenerEntradasRecientes();
        }
        public int ObtenerSalidaRecientes()
        {
            return objDatos.ObtenerSalidasRecientes();
        }


        public void CambiarEstadoCliente(int clienteID, bool estado)
        {
            try
            {
                objDatos.CambiarEstadoCliente(clienteID, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente: " + ex.Message);
            }
        }

        public bool ExisteClienteRUC(string RUC)
        {
            return objDatos.ExisteCliente(RUC);
        }

        public DataTable ObtenerUltimoClienteRegistrado()
        {
            return (DataTable)objDatos.EjecutarOpcionClientes(2);
        }

        public int ContarClientesActivos()
        {
            return (int)objDatos.EjecutarOpcionClientes(1);
        }

        public int ContarClientesInactivos()
        {
            return (int)objDatos.EjecutarOpcionClientes(3);
        }

        public DataTable ObtenerClienteConMasSalidas()
        {
            return (DataTable)objDatos.EjecutarOpcionClientes(4);
        }

        public string GenerarScriptOcultarCliente(int clienteID, bool estado)
        {
        string script = $@"
            EXEC sp_OcultarCliente 
            @ClienteID = {clienteID}, 
            @Estado = {(estado ? 1 : 0)};";

            GuardarScriptEnArchivo(script, estado ? "HabilitarCliente" : "OcultarCliente");
            return script;
        }


    }
}
//LLAMAMOS A LA CAPA DE DATOS 
//insertamos los procedimientos almacenados que se volvieron metodos
