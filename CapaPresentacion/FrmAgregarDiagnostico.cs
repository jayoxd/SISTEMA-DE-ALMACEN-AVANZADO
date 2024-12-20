using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmAgregarDiagnostico : Form
    {

        N_Diagnostico objNegocio = new N_Diagnostico();
        E_diagonostico objEntidad = new E_diagonostico();
        N_ReporteDiagnostico report = new N_ReporteDiagnostico();
        E_ReporteDiagnostico entidadrepor = new E_ReporteDiagnostico();
        public FrmAgregarDiagnostico()
        {
            InitializeComponent();
            mostrarcodigo();
            lblMecanico.Text = F_Variables.nombre_empleado;
            rellenarCampo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProductosx_Click(object sender, EventArgs e)
        {
           
        }
        public void mostrarcodigo()
        {
            N_Diagnostico objeto = new N_Diagnostico();
            cmbCODIGO.DataSource = objeto.listandodiagnostico();
            cmbCODIGO.ValueMember = "id_diagonistco";
            cmbCODIGO.DisplayMember = "codigo_Servicio";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in objeto.listandodiagnostico().Rows)
            {
                coleccion.Add(Convert.ToString(row["codigo_Servicio"]));
            }
            cmbCODIGO.AutoCompleteCustomSource = coleccion;
            cmbCODIGO.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCODIGO.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }


    
        private void rellenarCampo()
        {

            N_Diagnostico objeto = new N_Diagnostico();
           objNegocio.RellenarCampos(objeto.listandodiagnostico(), txtPlacax, cmbCODIGO.SelectedValue.ToString(), "placa");

        }

        private void cmbCODIGO_Leave(object sender, EventArgs e)
        {
            if (cmbCODIGO.Text != "")
            {
                rellenarCampo();
            }
            else
            {
                FrmSuccess.confimarcionForm("NO HAY DIAGNOSTICOS");
            }
        }

        private void cmbCODIGO_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            rellenarCampo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtDescripcion.Text == string.Empty || cmbCODIGO.ValueMember == string.Empty)
                {
                    FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                }
                else
                {
                    entidadrepor.Idempleado = F_Variables.idEmpleado;
                    entidadrepor.Iddiagnostico = Convert.ToInt32(cmbCODIGO.SelectedValue);
                    entidadrepor.Descripcion_rep_dia =txtDescripcion.Text;


                    report.insertandoReporDiagnostic(entidadrepor);
                    FrmSuccess.confimarcionForm("DIAGNOSTICO REGISTRADO");
                    txtDescripcion.Text = "";
            
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el registro" + ex);
            }

        }

        private void txtPlacax_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAgregarDiagnostico_Load(object sender, EventArgs e)
        {

        }
    }
}
