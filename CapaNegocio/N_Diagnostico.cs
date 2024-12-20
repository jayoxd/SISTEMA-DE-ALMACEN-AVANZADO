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
    public class N_Diagnostico
    {
        D_Diagnostico objDatos = new D_Diagnostico();
        E_diagonostico entidades = new E_diagonostico();

        public DataTable listandodiagnostico()
        {
            return objDatos.ListarDignostico();
        }
        public DataTable buscandoDiagnostico(string buscardiag)
        {
            entidades.Buscar_diagnostico = buscardiag;
            return objDatos.BuscarDiagnostico(entidades);
        }

        public void insertandodiagnostico(E_diagonostico diagnostico)
        {
            objDatos.insertarDiagnostico(diagnostico);
        }

    
        public void eliminandodiagnostico(E_diagonostico diagnostico)
        {
            objDatos.EliminarDiagnostico(diagnostico);
        }

        public void RellenarCampos(object cam,TextBox nombre,string xTbox,string Campo)
        {
            objDatos.rellenar_campo(cam,nombre,xTbox,Campo);
        }


    }
}
