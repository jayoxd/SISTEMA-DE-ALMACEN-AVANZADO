using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Productos
    {

        private int _idproducto;
        private int _idcategoria;
        private string _codigo_pro;
        private string _nombre_pro;
        private string _marca_pro;
        private decimal _precio_venta;
        private int _stock_pro;
        private string _descripcion_pro;
        private string _imagen_pro;
        private bool _estado_pro;
        private string _buscar_prod;


        private string _totalCategoria;
        private string _totalProductos;
        private string _totalstock;

        public int Idproducto { get => _idproducto; set => _idproducto = value; }
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public string Codigo_pro { get => _codigo_pro; set => _codigo_pro = value; }
        public string Nombre_pro { get => _nombre_pro; set => _nombre_pro = value; }
        public string Marca_pro { get => _marca_pro; set => _marca_pro = value; }
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }
        public int Stock_pro { get => _stock_pro; set => _stock_pro = value; }
        public string Descripcion_pro { get => _descripcion_pro; set => _descripcion_pro = value; }
        public string Imagen_pro { get => _imagen_pro; set => _imagen_pro = value; }
        public bool Estado_pro { get => _estado_pro; set => _estado_pro = value; }
        public string Buscar_prod { get => _buscar_prod; set => _buscar_prod = value; }
        public string TotalCategoria { get => _totalCategoria; set => _totalCategoria = value; }
        public string TotalProductos { get => _totalProductos; set => _totalProductos = value; }
        public string Totalstock { get => _totalstock; set => _totalstock = value; }
    }
}

