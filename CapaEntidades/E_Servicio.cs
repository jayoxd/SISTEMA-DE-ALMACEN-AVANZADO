using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Servicio
    {
        private int _idservicio;
        private int _idReporte;
        private int _idusuario;
        private string _nroComprobante;
        private DateTime _fecha;
        private decimal _precioservicio;
        private decimal _total;
        private string _estado;
        public DataTable detalles { get; set; }
        private string _buscar;

        private string _buscar_product;


        public int Idservicio { get => _idservicio; set => _idservicio = value; }
        public int IdReporte { get => _idReporte; set => _idReporte = value; }
        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public string NroComprobante { get => _nroComprobante; set => _nroComprobante = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public decimal Precioservicio { get => _precioservicio; set => _precioservicio = value; }
        public decimal Total { get => _total; set => _total = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Buscar { get => _buscar; set => _buscar = value; }
        public string Buscar_product { get => _buscar_product; set => _buscar_product = value; }
    }
}
