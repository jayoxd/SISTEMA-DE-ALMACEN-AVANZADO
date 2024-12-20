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
    public partial class FrmAcceso : Form
    {
        E_Usuario entidades = new E_Usuario();
        N_Usuario negocio = new N_Usuario();

        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

          
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tabla = new DataTable();
                tabla = negocio.login(txtEmail.Text.Trim(), txtClave.Text.Trim());
                if (tabla.Rows.Count <= 0)
                {
                    Form mensaje = new FrmInformation("INGRESA EL CORREO/CONTRASEÑA CORRECTA");
                    DialogResult resultado = mensaje.ShowDialog();


                }
                else
                {
                    if (Convert.ToBoolean(tabla.Rows[0][4]) == false)
                    {
                        Form mensaje = new FrmInformation("CONTRASEÑA CORRECTA");
                        DialogResult resultado = mensaje.ShowDialog();
                    }
                    else
                    {
                        
                        FrmPrincipal frm = new FrmPrincipal();
                        
                        F_Variables.idEmpleado= Convert.ToInt32(tabla.Rows[0][0]);
                        frm.Idusuario = Convert.ToInt32(tabla.Rows[0][0]);
                        frm.Idrol = Convert.ToInt32(tabla.Rows[0][1]);
                        frm.rol = Convert.ToString(tabla.Rows[0][2]);
                        frm.nombre = Convert.ToString(tabla.Rows[0][3]);
                        F_Variables.nombre_empleado = Convert.ToString(tabla.Rows[0][3]);
                        frm.estado = Convert.ToBoolean(tabla.Rows[0][4]);
                        FrmSuccess.confimarcionForm("BIENVENIDO");
                        frm.Show();
                        this.Hide();
               





                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "CORREO")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
                
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text=="")
            {
                txtEmail.Text = "CORREO";
                txtEmail.ForeColor = Color.DimGray;
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "CONTRASEÑA")
            {
                txtClave.Text = "";
                txtClave   .ForeColor = Color.LightGray;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {

            if (txtClave.Text =="")
            {
                txtClave.Text = "CONTRASEÑA";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
