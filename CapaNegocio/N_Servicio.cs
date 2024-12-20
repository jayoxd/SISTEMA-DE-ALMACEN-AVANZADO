using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
   public  class N_Servicio
    {
        D_Servicio objDatos = new D_Servicio();
        E_Servicio entidades = new E_Servicio();

        public DataTable listandoServicios()
        {
            return objDatos.ListarServicio();
        }

        public DataTable buscandoServicios(string buscar)
        {
            entidades.Buscar = buscar;
            return objDatos.BuscarServicio(entidades);
        }




        public static string insertarServicio(int Idusuario, int IdReporte,string NroComprobante,decimal Precioservicio,decimal Total, DataTable Detalles)
        {
            D_Servicio Servicio = new D_Servicio();
            E_Servicio Obj = new E_Servicio();
            Obj.Idusuario = Idusuario;
            Obj.IdReporte = IdReporte;
            Obj.NroComprobante = NroComprobante;
            Obj.Precioservicio = Precioservicio;
            Obj.Total = Total;
            Obj.detalles = Detalles;
            return Servicio.insertarServicio(Obj);
        }
        public static string Anular(int Id)
        {
            D_Servicio objDatos = new D_Servicio();
             return objDatos.Anular(Id);
        }

        public DataTable buscandoServiciosudetalle(int servicio)
        {

            entidades.Idservicio = servicio;
            return objDatos.buscarDetalledeUnaVenta(entidades);
        }


    }
}
