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
    public partial class FrmDiagnostico : Form
    {


        N_Diagnostico objNegocio = new N_Diagnostico();
        E_diagonostico objEntidad = new E_diagonostico();
        public FrmDiagnostico()
        {
            InitializeComponent();
            mostrarDiagnostico();
            accionestabla();
            listar_vehiculo();

       


        }

        public void mostrarDiagnostico()
        {
            N_Diagnostico objNegocio = new N_Diagnostico();
            tabladiagnostico.DataSource = objNegocio.listandodiagnostico();
            lblDiagnosticos.Text = Convert.ToString(tabladiagnostico.RowCount);
            FrmRolesver frm = new FrmRolesver();
            lbltrabajadores.Text = F_Variables.sumaremple;



        }

        public void listar_vehiculo( )
        {
            N_Vehiculo objeto = new N_Vehiculo();
            cmbPlaca.DataSource = objeto.listandoVehiculo();
            cmbPlaca.ValueMember = "idvehiculo";
            cmbPlaca.DisplayMember = "placa_veh";
     


            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach(DataRow row in objeto.listandoVehiculo().Rows)
            {
                coleccion.Add(Convert.ToString(row["placa_veh"]));
            }
            cmbPlaca.AutoCompleteCustomSource = coleccion;
            cmbPlaca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPlaca.AutoCompleteSource = AutoCompleteSource.CustomSource;

            
        }

        public  void mostrarcliente()
        {
           
        }


        public void accionestabla()
        {
            tabladiagnostico.Columns[1].Visible = false;
            tabladiagnostico.Columns[2].Visible = false;
             tabladiagnostico.Columns[0].DisplayIndex = 6;
           

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarDiagnostico_Click(object sender, EventArgs e)
        {
            int ver = Convert.ToInt32(tabladiagnostico.RowCount);
            if (ver==0) 
            {
                FrmSuccess.confimarcionForm("FALTA ENVIAR DIAGNOSTICOS");
            }
            else
            {
                FrmAgregarDiagnostico frm = new FrmAgregarDiagnostico();

                frm.ShowDialog();
            }
         
        }

        public void buscardiagnostico(string buscardiag)
        {
            N_Diagnostico objNegocio = new N_Diagnostico();
            tabladiagnostico.DataSource = objNegocio.buscandoDiagnostico(buscardiag);
       
        }


     

        private void txbBuscarempleado_TextChanged(object sender, EventArgs e)
        {
            buscardiagnostico(txbBuscarempleado.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNorden.Text == string.Empty ||cmbPlaca.ValueMember ==string.Empty)
                {
                    FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                }
                else
                {
                    objEntidad.Idempleado = F_Variables.idEmpleado;
                    objEntidad.Idvehiculo = Convert.ToInt32(cmbPlaca.SelectedValue);
                    objEntidad.Orden = Convert.ToInt32(txtNorden.Text);
                  

                    objNegocio.insertandodiagnostico(objEntidad);
                    FrmSuccess.confimarcionForm("DIAGNOSTICO AGREGADO");
                    txtNorden.Text = "";
                    mostrarDiagnostico();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el registro" + ex);
            }
        }

 

        private void tabladiagnostico_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (tabladiagnostico.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {


                Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL DIAGNOSTICO?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    objEntidad.Iddiagnostico = Convert.ToInt32(tabladiagnostico.Rows[e.RowIndex].Cells[1].Value.ToString());
                    objNegocio.eliminandodiagnostico(objEntidad);
                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrarDiagnostico();

                    
                }
            }
            //else if (tabladiagnostico.Rows[e.RowIndex].Cells["DOCUMENTO"].Selected)
            //{


            //    Form mensaje = new frmReportes("¿ELIJE UNA OPCIÓN?");
            //    DialogResult resultado = mensaje.ShowDialog();

            //    if (resultado == DialogResult.OK)
            //    {
            //       // objEntidad.Iddiagnostico = Convert.ToInt32(tabladiagnostico.Rows[e.RowIndex].Cells[2].Value.ToString());
            //        //objNegocio.eliminandodiagnostico(objEntidad);
            //        frmVisualisarReporte frm = new frmVisualisarReporte();
            //        frm.ShowDialog();
            //        // mostrarDiagnostico();


            //    }
                
            //}



        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmVisualisarReporte frm = new frmVisualisarReporte();
            frm.ShowDialog();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
