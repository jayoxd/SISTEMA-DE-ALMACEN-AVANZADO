﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_Productoss
    {
        D_Productoss objDatos = new D_Productoss();
        E_productoss entidades = new E_productoss();

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
    }
}
