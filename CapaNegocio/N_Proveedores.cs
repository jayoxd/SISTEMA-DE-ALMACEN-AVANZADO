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
   public class N_Proveedores
    {
        string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

        D_proveedores objDatos = new D_proveedores();
        E_proveedores entidades = new E_proveedores();

        public DataTable listarproveedor()
        {
            return objDatos.ListarProveedores();
        }

        public DataTable ConsultarProveedores(string filtroGeneral = null, bool? estado = null)
        {
            return objDatos.ConsultarProveedores(filtroGeneral, estado);
        }

        public void insertandoProveedor(E_proveedores Proveedor)
        {
            objDatos.InsertarProveedor(Proveedor);
        }

        public void actualizarproveedor(E_proveedores Proveedor)
        {
            objDatos.ActualizarProveedor(Proveedor);
        }

        public void ocultarProveedor(int id)
        {
            objDatos.OcultarProveedor(id);
        }
        public void CambiarEstadoProveedor(int clienteID, bool estado)
        {
            try
            {
                objDatos.CambiarEstadoProve(clienteID, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente: " + ex.Message);
            }
        }
        public bool ExisteProveedorRUC(string RUC)
        {
            return objDatos.ExisteProveedor(RUC);
        }

        public int ContarProveedoresActivos()
        {
            return (int)objDatos.EjecutarOpcionProveedores(1);
        }

        public DataTable ObtenerUltimoProveedorRegistrado()
        {
            return (DataTable)objDatos.EjecutarOpcionProveedores(2);
        }

        public int ContarProveedoresInactivos()
        {
            return (int)objDatos.EjecutarOpcionProveedores(3);
        }

        public DataTable ObtenerProveedorConMasEntradas()
        {
            return (DataTable)objDatos.EjecutarOpcionProveedores(4);
        }
        public string GenerarScriptInsertar(E_proveedores proveedor)
        {
            string script = $@"
        EXEC InsertarProveedor 
            @RUC = {FormatearValor(proveedor.Ruc)}, 
            @Nombre = {FormatearValor(proveedor.Nombre)}, 
            @Direccion = {FormatearValor(proveedor.Direccion)}, 
            @Telefono = {FormatearValor(proveedor.Telefono)}, 
            @Email = {FormatearValor(proveedor.Email)};";

            GuardarScriptEnArchivo(script, "InsertarProveedor");
            return script;
        }

        public string GenerarScriptActualizar(E_proveedores proveedor)
        {
            string script = $@"
        EXEC ActualizarProveedor 
            @ProveedorID = {proveedor.idProveedor}, 
            @RUC = {FormatearValor(proveedor.Ruc)}, 
            @Nombre = {FormatearValor(proveedor.Nombre)}, 
            @Direccion = {FormatearValor(proveedor.Direccion)}, 
            @Telefono = {FormatearValor(proveedor.Telefono)}, 
            @Email = {FormatearValor(proveedor.Email)};";

            GuardarScriptEnArchivo(script, "ActualizarProveedor");
            return script;
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

        private string FormatearValor(string valor)
        {
            return string.IsNullOrEmpty(valor) ? "NULL" : $"'{valor.Replace("'", "''")}'";
        }
        public string GenerarScriptOcultarProveedor(int proveedorID, bool estado)
        {
            string script = $@"
            EXEC sp_OcultarProveedor 
                @ProveedorID = {proveedorID}, 
                @Estado = {(estado ? 1 : 0)};";

            GuardarScriptEnArchivo(script, estado ? "HabilitarProveedor" : "OcultarProveedor");
            return script;
        }

    }
}
//LLAMAMOS A LA CAPA DE DATOS 
//insertamos los procedimientos almacenados que se volvieron metodos
