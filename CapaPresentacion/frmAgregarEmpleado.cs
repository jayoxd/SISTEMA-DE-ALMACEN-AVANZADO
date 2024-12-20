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
    public partial class frmAgregarEmpleado : Form
    {
        FrmRolesver frm = new FrmRolesver();
        E_Usuario entidades = new E_Usuario();
        N_Usuario negocio = new N_Usuario();

        public bool Update = false;
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            listar_rol();
            if (cmbTipoDocumentoEM.Enabled ==true) { }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void listar_rol()
        {
            N_rol objeto = new N_rol();
            cmbROLES.DataSource = objeto.listarrol();
            cmbROLES.ValueMember = "Idrol";
            cmbROLES.DisplayMember = "Nombre_rol";
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            
            
            if (Update == false)
            {
                try
                {
                    if (txtNombreEM.Text == string.Empty || txtTipoDocumen.Text == string.Empty || txtEmailemp.Text == string.Empty || cmbROLES.ValueMember == string.Empty ||
                        txtClave.Text == string.Empty || txtTelefonoEM.Text == string.Empty || txtDireccionemp.Text == string.Empty)
                    {
                        FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                    }
                    else
                    {
                        entidades.Nombre_emp = txtNombreEM.Text;
                        entidades.Tipo_documento_emp = txtTipoDocumen.Text;
                        entidades.Id_rol = Convert.ToInt32(cmbROLES.SelectedValue);
                        entidades.Tipo_documento_emp = txtTipoDocumen.Text;
                        entidades.Num_documento_emp = txtNmrDocemp.Text;
                        entidades.Direccion_emp = txtDireccionemp.Text;
                        entidades.Telefono_emp = txtTelefonoEM.Text;
                        entidades.Email = txtEmailemp.Text;
                        entidades.Clave = txtClave.Text;

                        negocio.insertandoEmpleado(entidades);
                        FrmSuccess.confimarcionForm("EMPLEADO AGREGADO");
                        Close();
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
                    entidades.Id_empleado =Convert.ToInt32(txtIdEmpleado.Text);
                    entidades.Nombre_emp = txtNombreEM.Text;
                    entidades.Tipo_documento_emp = txtTipoDocumen.Text;
                    entidades.Id_rol = Convert.ToInt32(cmbROLES.SelectedValue);
                    entidades.Num_documento_emp = txtNmrDocemp.Text;
                    entidades.Direccion_emp = txtDireccionemp.Text;
                    entidades.Telefono_emp = txtTelefonoEM.Text;
                    entidades.Email = txtEmailemp.Text;
                    entidades.Clave = txtClave.Text;

                    negocio.editandoEmpleado(entidades);
                    FrmSuccess.confimarcionForm("EMPLEADO EDITADO");
                    Close();
                    Update = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el producto" + ex);
                }
            }
        }

        private void cmbROLES_SelectedIndexChanged(object sender, EventArgs e)
        {
          //int indice = cmbROLES.SelectedIndex;
           // txtnroRol.Text = cmbROLES.Items[indice].ToString();
        }

        private void txtNmrDocemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            cmbTipoDocumentoEM.Items.Add("DNI");
            cmbTipoDocumentoEM.Items.Add("PASAPORTE");
        }

        private void cmbTipoDocumentoEM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice =cmbTipoDocumentoEM.SelectedIndex;
            txtTipoDocumen.Text = cmbTipoDocumentoEM.Items[indice].ToString();
           

        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "CONTRASEÑA")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.LightGray;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "CONTRASEÑA";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
