using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Entrada
    {
        private string _nroDocumento;
        private int _proveedorID;
        private decimal _tipoCambio;
        private string _tipoComprobante;

        private string _nroComprobante;

        private DateTime _fecha;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private DateTime _fechaHora;
        public DataTable Detalles { get; set; }

        private string _CodigoProducto;

        private string _Lote;
        private string _UserCreate;
        private string _UserUpdate;

        public string UserCreate { get => _UserCreate; set => _UserCreate = value; }
        public string UserUpdate { get => _UserUpdate; set => _UserUpdate = value; }

        public string NroDocumento { get => _nroDocumento; set => _nroDocumento = value; }
        public int ProveedorID { get => _proveedorID; set => _proveedorID = value; }
        public decimal TipoCambio { get => _tipoCambio; set => _tipoCambio = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public DateTime FechaHoraSys { get => _fecha; set => _fecha = value; }

        public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }

        public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }
        public string CodigoProducto { get => _CodigoProducto; set => _CodigoProducto = value; }
        public string Lote { get => _Lote; set => _Lote = value; }
        public string TipoComprobante { get => _tipoComprobante; set => _tipoComprobante = value; }
        public string NroComprobante { get => _nroComprobante; set => _nroComprobante = value; }



    }
}