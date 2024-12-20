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
    public class N_ReporteDiagnostico
    {
        D_ReporteDiagnostico objDatos = new D_ReporteDiagnostico();
        E_ReporteDiagnostico entidades = new E_ReporteDiagnostico();

        public DataTable listandoReportDiagnotic()
        {
            return objDatos.ListarReporteDiagnostico();


        }
        public DataTable buscandoreportdiag(string buscar)
        {
            entidades.Buscar = buscar;
            return objDatos.BuscarReportDiag(entidades);
        }

        public void insertandoReporDiagnostic(E_ReporteDiagnostico reportdiag)
        {
            objDatos.insertarReporteDiagnostico(reportdiag);
        }
        
        public void eliminandoReportdiag(int id)
        {
            objDatos.EliminarReportdiag(id);
        }

      
    }
}
