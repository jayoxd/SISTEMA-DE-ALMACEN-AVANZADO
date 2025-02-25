using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;
using System.IO;
using System.Globalization;

namespace CapaNegocio
{
    public class N_Productoss
    {
        D_Productoss objDatos = new D_Productoss();
        E_productoss entidades = new E_productoss();
        string rutaCarpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ScriptLanmei", "RegistrosSQL");

        public DataTable listandoProductos(bool? estado = null)
        {
            return objDatos.listaProductos(estado);
        }

        public DataTable listandoProductos1(bool? estado = null)
        {
            return objDatos.listaProductos1(estado);
        }
        public DataTable BuscarProductoPorCodigoODescripcion(string valor, bool activo)
        {
            return objDatos.BuscarProductoPorCodigoODescripcion(valor, activo);
        }

        public DataTable buscandoproductosxproduc(string buscar)
        {
            entidades.Buscar_producto = buscar;
            return objDatos.buscarProductosporProduct(entidades);
        }

     

            public int ObtenerStockActual(string codigoProducto)
            {
                return objDatos.ObtenerStockActual(codigoProducto);
            }
     


        public void insertandoproductos(E_productoss productos)
        {
            objDatos.insertarProducto(productos);
        }

        public void editandoProducto(E_productoss productos)
        {
            objDatos.EditarProductos(productos);
        }

        public void OcultarProducto(string codigoProducto)
        {
            try
            {
                objDatos.OcultarProducto(codigoProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio al ocultar el producto: " + ex.Message);
            }
        }

        public DataTable ObtenerReporteInventario(string codigoProducto, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return new D_Productoss().ObtenerReporteInventario(codigoProducto, fechaInicio, fechaFin);
        }
        public DataTable ObtenerReporteInventariotodo()
        {
            return new D_Productoss().ObtenerReporteInventariotodo();
        }

        public void CambiarEstadoProducto(string codigoProducto, bool estado)
        {
            try
            {
                objDatos.CambiarEstadoProducto(codigoProducto, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del producto: " + ex.Message);
            }
        }

        public string ObtenerUltimoProductoRegistrado()
        {
            return objDatos.ObtenerUltimoProductoRegistrado();
        }

        public int ContarProductosHabilitados()
        {
            return objDatos.ContarProductosPorEstado(true);
        }

        public int ContarProductosInhabilitados()
        {
            return objDatos.ContarProductosPorEstado(false);
        }

        public DataTable ObtenerProductoConMasSalidas()
        {
            return objDatos.ObtenerProductoConMasMovimientos(1); // Opción 1: Producto con más salidas
        }

        public DataTable ObtenerProductoConMasEntradas()
        {
            return objDatos.ObtenerProductoConMasMovimientos(2); // Opción 2: Producto con más entradas
        }


        public string GenerarScriptInsertar(E_productoss producto)
        {
            string script = $@"
        EXEC sp_AgregarProducto 
            @CodigoProducto = {FormatearValor(producto.CodigoProducto)}, 
            @DescripcionProducto = {FormatearValor(producto.DescripcionProducto)}, 
            @Categoria = {FormatearValor(producto.Categoria)}, 
            @PrecioUnitario = {FormatearDecimal(producto.PrecioUnitario)}, 
            @StockActual = {producto.StockActual}, 
            @Estado = {(producto.estado ? "1" : "0")}, 
            @BASICO = {FormatearDecimal(producto.BASICO)}, 
            @Saga = {FormatearDecimal(producto.Saga)}, 
            @Agora = {FormatearDecimal(producto.Agora)}, 
            @Ripley = {FormatearDecimal(producto.Ripley)}, 
            @Mayorista_3_5 = {FormatearDecimal(producto.Mayorista_3_5)}, 
            @Mayorista_X_Caja = {FormatearDecimal(producto.Mayorista_X_Caja)};";

            GuardarScriptEnArchivo(script, "InsertarProducto");
            return script;
        }

        public string GenerarScriptActualizar(E_productoss producto)
        {
            string script = $@"
        EXEC sp_ActualizarProducto 
            @CodigoProducto = {FormatearValor(producto.CodigoProducto)}, 
            @DescripcionProducto = {FormatearValor(producto.DescripcionProducto)}, 
            @Categoria = {FormatearValor(producto.Categoria)}, 
            @PrecioUnitario = {FormatearDecimal(producto.PrecioUnitario)}, 
            @StockActual = {producto.StockActual}, 
            @Estado = {(producto.estado ? "1" : "0")}, 
            @BASICO = {FormatearDecimal(producto.BASICO)}, 
            @Saga = {FormatearDecimal(producto.Saga)}, 
            @Agora = {FormatearDecimal(producto.Agora)}, 
            @Ripley = {FormatearDecimal(producto.Ripley)}, 
            @Mayorista_3_5 = {FormatearDecimal(producto.Mayorista_3_5)}, 
            @Mayorista_X_Caja = {FormatearDecimal(producto.Mayorista_X_Caja)};";

            GuardarScriptEnArchivo(script, "ActualizarProducto");
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
        private string FormatearDecimal(decimal? valor)
        {
            return valor.HasValue ? valor.Value.ToString(CultureInfo.InvariantCulture) : "NULL";
        }


        public string GenerarScriptOcultarProducto(string codigoProducto, bool estado)
        {
            string script = $@"
            EXEC sp_CambiarEstadoProducto 
                @CodigoProducto = '{codigoProducto}', 
                @Estado = {(estado ? 1 : 0)};";

            GuardarScriptEnArchivo(script, estado ? "HabilitarProducto" : "OcultarProducto");
            return script;
        }


        public int InsertarImagen(string codigoProducto, string rutaImagen, int orden)
        {
            try
            {
                // Llamar al método de la capa de datos
                return objDatos.InsertarImagenProducto(codigoProducto, rutaImagen, orden);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio: " + ex.Message);
            }
        }
        

        public DataTable obtenerImgproducto(string codigoProducto)
        {
            return new D_Productoss().obtenerimgsxproducto(codigoProducto);
        }

        public void EditarPRODUCTOimg(String productoId, DataTable imagenesProducto)
        {
            try
            {
                objDatos.EditarProductosIMG(productoId,imagenesProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar imagenes: " + ex.Message);
            }
        }
        public int ContarImagenesProducto(string codigoProducto)
        {
            try
            {
                return objDatos.ContarImagenesProducto(codigoProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio: " + ex.Message);
            }
        }

        public bool VerificarCodigoProducto(string codigoProducto)
        {
            return objDatos.VerificarCodigoProducto(codigoProducto);
        }

    }
}
