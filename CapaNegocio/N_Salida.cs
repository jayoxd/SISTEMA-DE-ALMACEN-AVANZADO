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
    public class N_Salida
    {
        // instancia de la capa de datos
        private readonly D_salida objDatos = new D_salida();

      

        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedio(bool esInterno)
        {
            return objDatos.ListaSalidamedio(esInterno);
        }
        // Método para obtener los tipos de venta según si el cliente es interno o externo
        public DataTable ListaSalidamedioint()
        {
            return objDatos.ListaSalidamedioint();
        }

        // Método para listar salidas
        public DataTable ListarSalidas()
        {
            return objDatos.ListaSalida();
        }


        // Método para editar una salida
        public void EditarSalida(E_salida salida)
        {

            // Llamamos al método de la capa de datos para editar la salida
            objDatos.EditarSalida(salida);
        }

        // Método para insertar una nueva salida
        public string InsertarSalida(E_salida salida)
        {
            return objDatos.InsertarSalida(salida);  // 🔹 Devuelve el `NroDocumento` generado
        }


        // Método para obtener los detalles de una salida específica
        public DataSet ObtenerSalidaConDetalles(string nroDocumento)
        {
            return objDatos.ObtenerSalidaConDetalles(nroDocumento);
        }

        // Método para buscar salidas por número de documento o comprobante
        public DataTable BuscarPorNroDocOComprobante(string valor)
        {
            return objDatos.BuscarPorSalidaNroDoc(valor);
        }

        // Método para buscar salidas con filtros opcionales
        public DataTable BuscarSalidas(E_salida salida)
        {
            return objDatos.BuscarSalidas(salida);
        }

        public DataTable ObtenerSalidasPorFechas(string valor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new D_salida().ObtenerSalidasPorFechas(valor, fechaInicio, fechaFin);
        }
       
        public DataSet ObtenerSalidaConDetallesCompleto(string nroDocumento)
        {
            D_salida datos = new D_salida();
            return datos.ConsultarSalidaConDetallesCompleto(nroDocumento);
        }

        // Método para obtener el conteo de salidas excluyendo ClienteID 6 y 7
        public int ObtenerTotalSalidasSinCliente67()
        {
            return (int)objDatos.EjecutarOpcionSalidas(1);
        }

        // Método para obtener el conteo de salidas con ClienteID 7
        public int ObtenerTotalSalidasCliente7()
        {
            return (int)objDatos.EjecutarOpcionSalidas(2);
        }

        // Método para obtener el conteo de salidas con ClienteID 6
        public int ObtenerTotalSalidasCliente6()
        {
            return (int)objDatos.EjecutarOpcionSalidas(3);
        }

        // Método para obtener el NroDocumento de la última salida registrada
        public DataTable ObtenerUltimaSalidaRegistrada()
        {
            return (DataTable)objDatos.EjecutarOpcionSalidas(4);
        }

        // Método para obtener el NroDocumento de la última salida actualizada
        public DataTable ObtenerUltimaSalidaActualizada()
        {
            return (DataTable)objDatos.EjecutarOpcionSalidas(5);
        }

        public string GenerarScriptInsertar(E_salida salida)
        {
            string script = "DECLARE @Detalles type_Detalle_Salida;\n";

            foreach (DataRow fila in salida.Detallessalida.Rows)
            {
                script += $@"
            INSERT INTO @Detalles (CodigoProducto, Lote, Cantidad, Precio, Comision, PrecioVendido, Ganancia, Observacion)
            VALUES ({FormatearValor(fila["CodigoProducto"].ToString())}, 
                    {FormatearValor(fila["Lote"].ToString())}, 
                    {fila["Cantidad"]}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Precio"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Comision"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["PrecioVendido"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Ganancia"]))}, 
                    {FormatearValor(fila["Observacion"].ToString())});";
                        }

                        script += $@"

            EXEC sp_InsertarSalidaConDetalles 
                @ClienteID = {salida.clienteid}, 
                @Medio = {FormatearValor(salida.medio)}, 
                @Observacion = {FormatearValor(salida.observacion)}, 
                @Tipo_venta = {FormatearValor(salida.tipoVenta)}, 
                @Tipo_Comprobante = {FormatearValor(salida.TipoComprobante)}, 
                @Nro_Comprobante = {FormatearValor(salida.NroComprobante)}, 
                @Codigo_Pedido = {FormatearValor(salida.CodigoPedido)}, 
                @Transporte = {FormatearDecimal(salida.Transporte)}, 
                @FechaDespacho = '{salida.FechaDespacho:yyyy-MM-dd HH:mm:ss}', 
                @Fecha = '{salida.Fecha:yyyy-MM-dd}', 
                @UserCreate = {FormatearValor(salida.UserCreate)}, 
                @FechaHoraSys = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
                @NroDocumento = '{salida.NroDocumento}', 
                @Detalles = @Detalles;";

                        GuardarScriptEnArchivo(script, "InsertarSalida");
                        return script;
        }
        private string FormatearValor(string valor)
        {
            return string.IsNullOrEmpty(valor) ? "NULL" : $"'{valor.Replace("'", "''")}'";
        }

        private string FormatearDecimal(decimal valor)
        {
            return valor.ToString(CultureInfo.InvariantCulture);
        }
        private void GuardarScriptEnArchivo(string script, string tipoOperacion)
        {
            try
            {
                // Definir la ruta donde se guardará el archivo
                string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

                // Verificar si la carpeta existe, si no, crearla
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                // Nombre del archivo con timestamp
                string nombreArchivo = $"{tipoOperacion}_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

                // Guardar el script en el archivo
                File.WriteAllText(rutaArchivo, script);

                Console.WriteLine($"Script guardado correctamente en: {rutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el script: {ex.Message}");
            }
        }
        public string GenerarScriptEditar(E_salida salida)
        {
            // Declaramos la tabla @Detalles en SQL
            string script = "DECLARE @Detalles type_Detalle_Salida;\n";

            // Insertamos los datos en la tabla temporal @Detalles
            foreach (DataRow fila in salida.Detallessalida.Rows)
            {
                script += $@"
            INSERT INTO @Detalles (CodigoProducto, Lote, Cantidad, Precio, Comision, PrecioVendido, Ganancia, Observacion)
            VALUES ({FormatearValor(fila["CodigoProducto"].ToString())}, 
                    {FormatearValor(fila["Lote"].ToString())}, 
                    {fila["Cantidad"]}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Precio"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Comision"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["PrecioVendido"]))}, 
                    {FormatearDecimal(Convert.ToDecimal(fila["Ganancia"]))}, 
                    {FormatearValor(fila["Observacion"].ToString())});";
                        }

                        // Ejecutamos el procedimiento almacenado con la tabla @Detalles
                        script += $@"

            EXEC sp_EditarSalidaConDetalles 
                @NroDocumento = '{salida.NroDocumento}', 
                @ClienteID = {salida.clienteid}, 
                @Medio = {FormatearValor(salida.medio)}, 
                @Observacion = {FormatearValor(salida.observacion)}, 
                @TipoVenta = {FormatearValor(salida.tipoVenta)}, 
                @Tipo_Comprobante = {FormatearValor(salida.TipoComprobante)}, 
                @Nro_Comprobante = {FormatearValor(salida.NroComprobante)}, 
                @Codigo_Pedido = {FormatearValor(salida.CodigoPedido)}, 
                @Transporte = {FormatearDecimal(salida.Transporte)}, 
                @FechaDespacho = '{salida.FechaDespacho:yyyy-MM-dd HH:mm:ss}', 
                @Fecha = '{salida.Fecha:yyyy-MM-dd}', 
                @UserEdit = {FormatearValor(salida.UserUpdate)}, 
                @FechaHoraSys = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
                @Detalles = @Detalles;";

            // Guardar el script en un archivo
            GuardarScriptEnArchivo(script, "EditarSalida");

            return script;
        }

    }

}
