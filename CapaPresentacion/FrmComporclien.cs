using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;
namespace CapaPresentacion
{
    public partial class FrmComporclien : Form
    {
        N_ReporteDiagnostico objNegocio = new N_ReporteDiagnostico();
        E_ReporteDiagnostico entidad = new E_ReporteDiagnostico();
        public FrmComporclien()
        {
            InitializeComponent();
            mostrarDiagnostico();
            accionestabla();
        }

        public void mostrarDiagnostico()
        {

            N_ReporteDiagnostico objNegocio = new N_ReporteDiagnostico();
            tablaReporte.DataSource = objNegocio.listandoReportDiagnotic();
            //lblDiagnosticos.Text = Convert.ToString(tabladiagnostico.RowCount);
            // FrmRolesver frm = new FrmRolesver();
            //lbltrabajadores.Text = F_Variables.sumaremple;

        }
        public void accionestabla()
        {
            tablaReporte.Columns[0].Visible = false;
            tablaReporte.Columns[1].Visible = false;
            tablaReporte.Columns[8].Visible = false;
        

        }

       
        public void buscardiagnostico(string buscardiag)
        {
            N_ReporteDiagnostico objNegocio = new N_ReporteDiagnostico();
            tablaReporte.DataSource = objNegocio.buscandoreportdiag(buscardiag);

        }

        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            buscardiagnostico(txbBreport.Text);

        }

        private void tablaReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            F_Variables.nombre_clientereport = Convert.ToString(tablaReporte.CurrentRow.Cells["cliente"].Value);
            F_Variables.carro = Convert.ToString(tablaReporte.CurrentRow.Cells["placa"].Value);
            F_Variables.reporte = Convert.ToString(tablaReporte.CurrentRow.Cells["Diagnostico"].Value);

            F_Variables.pruebatodo = Convert.ToString(tablaReporte.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Close();

        }

        private void tablaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
