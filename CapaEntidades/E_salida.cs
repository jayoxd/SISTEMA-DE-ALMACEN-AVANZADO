using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_salida
    {
        private string _nroDocumento;
        private int _clienteID;
        private string _medio;

        private string _observacion;

        private DateTime _fecha;
        private string _tipoVenta;

        private string _tipoComprobante;

        private string _nroComprobante;

        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        public DataTable Detallessalida { get; set; }

        private string _CodigoProducto;

        private string _Lote;
        private string _UserCreate;
        private string _UserUpdate;
        private string _CodigoPedido;
        private decimal _Transporte;
        private DateTime _FechaDespacho;

        // Propiedades públicas
        public string CodigoPedido
        {
            get => _CodigoPedido;
            set => _CodigoPedido = value;
        }

        public decimal Transporte
        {
            get => _Transporte;
            set => _Transporte = value;
        }

        public DateTime FechaDespacho
        {
            get => _FechaDespacho;
            set => _FechaDespacho = value;
        }

        public string UserCreate { get => _UserCreate; set => _UserCreate = value; }
        public string UserUpdate { get => _UserUpdate; set => _UserUpdate = value; }

        public int IDtipoventa { get; set; } // Identificador del tipo de venta
        public string Descripcion { get; set; } // Descripción del tipo de venta

        public string NroDocumento { get => _nroDocumento; set => _nroDocumento = value; }
        public int clienteid { get => _clienteID; set => _clienteID = value; }

        public string observacion { get => _observacion; set => _observacion = value; }

        public string medio { get => _medio; set => _medio = value; }

        public DateTime Fecha { get => _fecha; set => _fecha = value; }

        public string tipoVenta { get => _tipoVenta; set => _tipoVenta = value; }

        public string TipoComprobante { get => _tipoComprobante; set => _tipoComprobante = value; }
        public string NroComprobante { get => _nroComprobante; set => _nroComprobante = value; }

        public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }

        public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }
        public string CodigoProducto { get => _CodigoProducto; set => _CodigoProducto = value; }
        public string Lote { get => _Lote; set => _Lote = value; }
       



    }
}