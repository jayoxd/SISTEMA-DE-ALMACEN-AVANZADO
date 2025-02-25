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
    public class N_Usuario
    {
        D_Usuario objDatos = new D_Usuario();
        E_Usuario entidades = new E_Usuario();

        // Método para listar empleados activos o inactivos
        public DataTable ListarEmpleados(bool activo)
        {
            return objDatos.ListarEmpleados(activo);
        }

        // Método para buscar empleados activos o inactivos
        public DataTable BuscarEmpleado(string valor, bool activo)
        {
            return objDatos.BuscarEmpleado(valor, activo);
        }

        // Método para cambiar estado (activar/desactivar) de un empleado
        public void CambiarEstadoEmpleado(int id, bool activo)
        {
            objDatos.CambiarEstadoEmpleado(id, activo);
        }

        public DataTable login(string Email,string Clave)
        {
            return objDatos.Login(Email,Clave);
        }



        public void insertandoEmpleado(E_Usuario usuario)
        {
            objDatos.insertarEmpleado(usuario);
        }

        public void editandoEmpleado(E_Usuario usuario)
        {
            objDatos.EditarEmpleado(usuario);
        }

        public void eliminandoEmpleado(int id)
        {
            objDatos.EliminarEmpleado(id);
        }
        public  string Activar(int Id)
        {
            return objDatos.Activar(Id);
        }

        public string Desactivar(int Id)
        {
            return objDatos.Desactivar(Id);
        }

        public string obtenerClaveEmpleado(int idEmpleado)
        {
            return objDatos.ObtenerClaveEmpleado(idEmpleado);
        }

        public bool VerificarEmailExistente(string email, int? idEmpleado = null)
        {
            return objDatos.VerificarEmailExistente(email, idEmpleado);
        }

        string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

        public string GenerarScriptInsertar(E_Usuario usuario)
        {
            string script = $@"
        EXEC usuario_insertar 
            @idrol = {usuario.Id_rol}, 
            @nombre = {FormatearValor(usuario.Nombre_emp)}, 
            @tipo_documento = {FormatearValor(usuario.Tipo_documento_emp)}, 
            @num_documento = {FormatearValor(usuario.Num_documento_emp)}, 
            @direccion = {FormatearValor(usuario.Direccion_emp)}, 
            @telefono = {FormatearValor(usuario.Telefono_emp)}, 
            @email = {FormatearValor(usuario.Email)}, 
            @clave ={FormatearValor(usuario.Clave)};";

            GuardarScriptEnArchivo(script, "InsertarUsuario");
            return script;
        }

        public string GenerarScriptActualizar(E_Usuario usuario, bool contraseñaModificada)
        {
            string script = $@"
        EXEC empleado_actualizar 
            @idusuario = {usuario.Id_empleado}, 
            @idrol = {usuario.Id_rol}, 
            @nombre = {FormatearValor(usuario.Nombre_emp)}, 
            @tipo_documento = {FormatearValor(usuario.Tipo_documento_emp)}, 
            @num_documento = {FormatearValor(usuario.Num_documento_emp)}, 
            @direccion = {FormatearValor(usuario.Direccion_emp)}, 
            @telefono = {FormatearValor(usuario.Telefono_emp)}, 
            @email = {FormatearValor(usuario.Email)}";

            // Solo incluir la contraseña si fue modificada
            if (contraseñaModificada && !string.IsNullOrWhiteSpace(usuario.Clave))
            {
                script += $",\n            @clave = {FormatearValor(usuario.Clave)}";

            }

            script += ";"; // Cierra la instrucción SQL

            GuardarScriptEnArchivo(script, "ActualizarUsuario");
            return script;
        }

        private void GuardarScriptEnArchivo(string script, string tipoOperacion)
        {
            try
            {
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                string nombreArchivo = $"{tipoOperacion}_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

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

        public string GenerarScriptOcultarEmpleado(int idUsuario, bool estado)
        {
        string script = $@"
        EXEC empleado_ocultarydescoultar 
            @idusuario = {idUsuario}, 
            @activo = {(estado ? 1 : 0)};";

            GuardarScriptEnArchivo(script, estado ? "HabilitarEmpleado" : "OcultarEmpleado");
            return script;
        }

    }
}
