using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_productoss
    {
        private string _codigoProducto;
        private string _descripcionProducto;
        private string _categoria;
        private decimal _precioUnitario;
        private int _stockActual;
        private decimal _preciominimo;
        private decimal _preciomaximo;
        private string _buscar_producto;
        private int stockminimo;
        private bool _estado;
        private decimal? basico;
        private decimal? saga;
        private decimal? agora;
        private decimal? ripley;
        private decimal? mayorista_3_5;
        private decimal? mayorista_x_caja;


        public decimal? BASICO { get => basico; set => basico = value; }
        public decimal? Saga { get => saga; set => saga = value; }
        public decimal? Agora { get => agora; set => agora = value; }
        public decimal? Ripley { get => ripley; set => ripley = value; }
        public decimal? Mayorista_3_5 { get => mayorista_3_5; set => mayorista_3_5 = value; }
        public decimal? Mayorista_X_Caja { get => mayorista_x_caja; set => mayorista_x_caja = value; }

        public bool estado { get => _estado; set => _estado = value; }
        public int Stockminimo { get => stockminimo; set => stockminimo = value; }
        public string Buscar_producto { get => _buscar_producto; set => _buscar_producto = value; }

        public string CodigoProducto { get => _codigoProducto; set => _codigoProducto = value; }
        public string DescripcionProducto { get => _descripcionProducto; set => _descripcionProducto = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public decimal Preciominimo { get => _preciominimo; set => _preciominimo = value; }

        public decimal Preciomaximo { get => _preciomaximo; set => _preciomaximo = value; }

        public int StockActual { get => _stockActual; set => _stockActual = value; }





    }
}