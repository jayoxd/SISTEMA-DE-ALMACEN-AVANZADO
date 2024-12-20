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
    public partial class FrmAgregarCliente : Form
    {

        FrmCliente frm = new FrmCliente();
        E_Cliente entidades = new E_Cliente();
        N_Cliente negocio = new N_Cliente();
      
        
        public bool Update = false;
        


        public FrmAgregarCliente()
        {
            InitializeComponent();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            cmbTipoDocumento.Items.Add("RUC");
            cmbTipoDocumento.Items.Add("DNI");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
              Close();
        }
        
        public void listarclienttt()
        {
            FrmCliente frm = new FrmCliente();
            frm.mostrarClientes();
        }
        

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
             

            if (Update == false)
            {

                try
                {
                    // txtTipoDocumen.Text == string.Empty || se quito
                    if (txtNombrecl.Text == string.Empty ||  txtNmrDocCliente.Text == string.Empty || txtDireccion.Text == string.Empty ||
                        txtTelefono.Text == string.Empty || txtEmail.Text == string.Empty )
                    {
                        FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                    }
                    else
                    {
                        entidades.Nombre_cli = txtNombrecl.Text;
                        entidades.Tipo_documento_cli = txbTipoDocumento.Text;
                        entidades.Num_documento_cli = txtNmrDocCliente.Text;
                        entidades.Direccion_clii = txtDireccion.Text;
                        entidades.Telefono_cli = txtTelefono.Text;
                        entidades.Email_cli = txtEmail.Text;
                        negocio.insertandoCliente(entidades);
                        listarclienttt();
                        limpiarcajas();
                        FrmSuccess.confimarcionForm("CLIENTE AGREGADO");
                    }
                      
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
          

            if (Update == true)
            {
                try
                {
                    entidades.Idcliente = Convert.ToInt32(txtIdCliente.Text);
                    entidades.Nombre_cli = txtNombrecl.Text;
                    entidades.Tipo_documento_cli = txbTipoDocumento.Text;
                    entidades.Num_documento_cli = txtNmrDocCliente.Text;
                    entidades.Direccion_clii = txtDireccion.Text;
                    entidades.Telefono_cli = txtTelefono.Text;
                    entidades.Email_cli = txtEmail.Text;


                    negocio.editandoCliente(entidades);
                    FrmSuccess.confimarcionForm("CLIENTE EDITADO");
                    Close();
                    Update = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el cliente" + ex);
                }
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbTipoDocumento.SelectedIndex;
            txbTipoDocumento.Text = cmbTipoDocumento.Items[indice].ToString();
         
        }

        public void limpiarcajas()
        {
            txtNombrecl.Text = "";
        //    txtTipoDocumen.Text = "";
            txtNombrecl.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNmrDocCliente.Text = "";
            txtDireccion.Text = "";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            limpiarcajas();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtTipoDocumen_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
