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
    public partial class frmVisualisarReporte : Form
    {
      
        public frmVisualisarReporte()
        {
            InitializeComponent();
            mostrarDiagnostico();
            accionestabla();
        }

        public void mostrarDiagnostico()
        {

            //lblDiagnosticos.Text = Convert.ToString(tabladiagnostico.RowCount);
           // FrmRolesver frm = new FrmRolesver();
            //lbltrabajadores.Text = F_Variables.sumaremple;

        }
        public void accionestabla()
        {
            tablaReporte.Columns[2].Visible = false;
            tablaReporte.Columns[3].Visible = false;
            tablaReporte.Columns[10].Visible = false;
            tablaReporte.Columns[0].DisplayIndex = 10;
            tablaReporte.Columns[1].DisplayIndex = 10;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void buscardiagnostico(string buscardiag)
        {

        }

        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            buscardiagnostico(txbBreport.Text);
        }

        private void tablaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (tablaReporte.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {


                Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL REPORTE?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int cam = Convert.ToInt32(tablaReporte.Rows[e.RowIndex].Cells[2].Value.ToString());
                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrarDiagnostico();


                }
            }
        }

        private void frmVisualisarReporte_Load(object sender, EventArgs e)
        {

        }
    }
}
