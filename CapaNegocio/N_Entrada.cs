using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace CapaNegocio
{
    public class N_Entrada
    {
        // instancia de la capa de datos
        private readonly D_EntradaProductos objDatos = new D_EntradaProductos();
        string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

        // método para listar entradas
        public DataTable ListarEntradas()
        {
            return objDatos.ListarEntradas();
        }

    


        public void EditarEntrada(E_Entrada entrada)
        {
            D_EntradaProductos servicio = new D_EntradaProductos();

            // Llamamos al método de la capa de datos para editar la entrada
            servicio.EditarEntrada(entrada);
        }

        public string InsertarEntrada(E_Entrada entrada)
        {
            D_EntradaProductos servicio = new D_EntradaProductos();
            return servicio.InsertarEntrada(entrada);  // Devuelve el NroDocumento generado
        }



        public DataSet ObtenerEntradaConDetalles(string nroDocumento)
        {
            return objDatos.ObtenerEntradaConDetalles(nroDocumento);
        }
        public DataTable buscarporNrodoandnrocompro(string valor)
        {
            return objDatos.BuscarPoEntradanrodoc(valor);
        }

        public DataTable ObtenerEntradasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new D_EntradaProductos().ObtenerEntradasPorFechas(valor, fechaInicio, fechaFin);
        }
        public DataSet ObtenerEntradaConDetallesCompleto(string nroDocumento)
        {
            D_EntradaProductos datos = new D_EntradaProductos();
            return datos.ConsultarEntradaConDetallesCompleto(nroDocumento);
        }


        public string ObtenerUltimaEntradaRegistrada()
        {
            var resultado = objDatos.EjecutarSpListarEntradas(5);
            return resultado != null ? resultado.ToString() : "No se encontró ninguna entrada registrada.";
        }

        public string ObtenerUltimaEntradaModificada()
        {
            var resultado = objDatos.EjecutarSpListarEntradas(6);
            return resultado != null ? resultado.ToString() : "No se encontró ninguna entrada modificada.";
        }

        public int ContarEntradasSinProveedor3y7()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(1));
        }

        public int ContarEntradasConProveedor3()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(2));
        }

        public int ContarEntradasConProveedor7()
        {
            return Convert.ToInt32(objDatos.EjecutarSpListarEntradas(3));
        }





        public string GenerarScriptInsertar(E_Entrada entrada)
        {
            // Crear la estructura de la tabla @Detalles en SQL
            string script = "DECLARE @Detalles type_Detalle_Entrada;\n";

            // Agregar cada fila de detalles a la tabla de tipo @Detalles
            foreach (DataRow fila in entrada.Detalles.Rows)
            {
                script += $@"
        INSERT INTO @Detalles (CodigoProducto, Lote, Cantidad, PrecioCompra, Observacion)
        VALUES ({FormatearValor(fila["CodigoProducto"].ToString())}, 
        {FormatearValor(fila["Lote"].ToString())}, 
        {fila["Cantidad"]}, 
        {FormatearDecimal(Convert.ToDecimal(fila["PrecioCompra"]))}, 
        {FormatearValor(fila["Observacion"].ToString())});";
            }

            // Ejecutar el SP con el parámetro @Detalles
            script += $@"

        EXEC sp_InsertarEntradaConDetalles 
        @ProveedorID = {entrada.ProveedorID}, 
        @TipoCambio = {FormatearDecimal(entrada.TipoCambio)}, 
        @Tipo_Comprobante = {FormatearValor(entrada.TipoComprobante)}, 
        @Nro_Comprobante = {FormatearValor(entrada.NroComprobante)}, 
        @Fecha = '{entrada.Fecha:yyyy-MM-dd HH:mm:ss}', 
        @FechaHoraSys = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
        @UserCreate = {FormatearValor(entrada.UserCreate)}, 
        @NroDocumento = '{entrada.NroDocumento}', 
        @Detalles = @Detalles;";

            GuardarScriptEnArchivo(script, "InsertarEntrada");
            return script;
        }


        public string GenerarScriptActualizar(E_Entrada entrada)
        {
            string script = $@"
        EXEC sp_EditarEntradaConDetalles 
            @NroDocumento = {FormatearValor(entrada.NroDocumento)}, 
            @ProveedorID = {entrada.ProveedorID}, 
            @TipoCambio = {FormatearDecimal(entrada.TipoCambio)}, 
            @Tipo_Comprobante = {FormatearValor(entrada.TipoComprobante)}, 
            @Nro_Comprobante = {FormatearValor(entrada.NroComprobante)}, 
            @Fecha = '{entrada.Fecha:yyyy-MM-dd HH:mm:ss}', 
            @FechaHoraSys = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
            @UserEdit = {FormatearValor(entrada.UserUpdate)};";

            script += "\n\n-- Actualizar Detalles de Entrada\n";

            foreach (DataRow fila in entrada.Detalles.Rows)
            {
                script += $@"
        INSERT INTO DetalleEntradaProductos (NroDocumento, CodigoProducto, Lote, Cantidad, PrecioCompra, Observacion)
        VALUES ('{entrada.NroDocumento}', 
                {FormatearValor(fila["CodigoProducto"].ToString())}, 
                {FormatearValor(fila["Lote"].ToString())}, 
                {fila["Cantidad"]}, 
                {FormatearDecimal(Convert.ToDecimal(fila["PrecioCompra"]))}, 
                {FormatearValor(fila["Observacion"].ToString())});";
            }

            GuardarScriptEnArchivo(script, "ActualizarEntrada");
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

        private string FormatearDecimal(decimal valor)
        {
            return valor.ToString(CultureInfo.InvariantCulture);
        }

        public string GenerarScriptEditar(E_Entrada entrada)
        {
            // Declaramos la tabla @Detalles en SQL
            string script = "DECLARE @Detalles type_Detalle_Entrada;\n";

            // Insertamos los datos en la tabla temporal @Detalles
            foreach (DataRow fila in entrada.Detalles.Rows)
            {
                script += $@"
            INSERT INTO @Detalles (CodigoProducto, Lote, Cantidad, PrecioCompra, Observacion)
            VALUES ({FormatearValor(fila["CodigoProducto"].ToString())}, 
        {FormatearValor(fila["Lote"].ToString())}, 
        {fila["Cantidad"]}, 
        {FormatearDecimal(Convert.ToDecimal(fila["PrecioCompra"]))}, 
        {FormatearValor(fila["Observacion"].ToString())});";
            }

            // Ejecutamos el procedimiento almacenado con la tabla @Detalles
            script += $@"

            EXEC sp_EditarEntradaConDetalles 
            @NroDocumento = '{entrada.NroDocumento}', 
            @ProveedorID = {entrada.ProveedorID}, 
            @TipoCambio = {FormatearDecimal(entrada.TipoCambio)}, 
            @Tipo_Comprobante = {FormatearValor(entrada.TipoComprobante)}, 
            @Nro_Comprobante = {FormatearValor(entrada.NroComprobante)}, 
            @Fecha = '{entrada.Fecha:yyyy-MM-dd HH:mm:ss}', 
            @FechaHoraSys = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
            @UserEdit = {FormatearValor(entrada.UserUpdate)}, 
            @Detalles = @Detalles;";

            GuardarScriptEnArchivo(script, "EditarEntrada");
            return script;
        }


    }

}
