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
        public bool EmpleadoAgregado { get; private set; } = false;

        public bool Update = false; // Indica si estamos en modo edición
       public String txtIdEmpleado = "";
        public string txtxiidrol { get; set; } = "";
        private bool contraseñaModificada = false; // Indica si el usuario modificó la contraseña
        public string txtnroRol= "";
        public string txtNombreRol = "";
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            listar_rol();
            cargarTipoDocumento();
            txtClave.Enter += txtClave_Enter;
            txtClave.Leave += txtClave_Leave;
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
        private void cargarTipoDocumento()
        {
            cmbTipoDocumentoEM.Items.Add("DNI");
            cmbTipoDocumentoEM.Items.Add("PASAPORTE");
            cmbTipoDocumentoEM.SelectedIndex = 0; // Seleccionar "DNI" como predeterminado
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    // Asignar valores comunes
                    entidades.Nombre_emp = txtNombreEM.Text;
                    entidades.Tipo_documento_emp = txtTipoDocumen.Text;
                    entidades.Id_rol = Convert.ToInt32(cmbROLES.SelectedValue);
                    entidades.Num_documento_emp = txtNmrDocemp.Text;
                    entidades.Direccion_emp = txtDireccionemp.Text;
                    entidades.Telefono_emp = txtTelefonoEM.Text;
                    entidades.Email = txtEmailemp.Text;


                    // Validar correo duplicado
                    if (negocio.VerificarEmailExistente(entidades.Email, Update ? Convert.ToInt32(txtIdEmpleado) : (int?)null))
                    {
                        MessageBox.Show("El correo ingresado ya está registrado en otro empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Update) // Modo inserción
                    {
                       
                        entidades.Clave = txtClave.Text; // Nueva contraseña
                        negocio.insertandoEmpleado(entidades);
                        MessageBox.Show("El empleado ha sido agregado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EmpleadoAgregado = true;
                        this.Close();
                    }
                    else // Modo edición
                    {
                        entidades.Id_empleado = Convert.ToInt32(txtIdEmpleado);
                     
                        // Actualizar contraseña solo si fue modificada
                        if (contraseñaModificada && !string.IsNullOrWhiteSpace(txtClave.Text) && txtClave.Text != "CONTRASEÑA")
                        {
                            entidades.Clave = txtClave.Text; // Actualizar contraseña
                        }
                        else
                        {
                            entidades.Clave = null; // No actualizar la contraseña
                        }

                        negocio.editandoEmpleado(entidades); // Llamar al método de edición
                        MessageBox.Show("El empleado ha sido actualizado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Update = false;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }



        private bool validarCampos()
        {
            // Validar que todos los campos requeridos estén completos
            if (string.IsNullOrWhiteSpace(txtNombreEM.Text) || string.IsNullOrWhiteSpace(txtTipoDocumen.Text) ||
                string.IsNullOrWhiteSpace(txtEmailemp.Text) || cmbROLES.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtTelefonoEM.Text) || string.IsNullOrWhiteSpace(txtDireccionemp.Text) ||
                (!Update && string.IsNullOrWhiteSpace(txtClave.Text)))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            if (Update)
            {
                txtClave.Text = "CONTRASEÑA"; // Mostrar marcador de contraseña
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false; // Desactivar ocultar caracteres
                                                        // Establecer el rol actual en el ComboBox
                                                        // Seleccionar el rol actual en el ComboBox
                if (!string.IsNullOrEmpty(txtxiidrol))
                {
                    cmbROLES.SelectedValue = Convert.ToInt32(txtxiidrol); // Establece el rol
                }
            }
        }

        private void cmbROLES_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void txtNmrDocemp_TextChanged(object sender, EventArgs e)
        {

        }



        private void cmbTipoDocumentoEM_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoDocumen.Text = cmbTipoDocumentoEM.SelectedItem.ToString();
        }
        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "CONTRASEÑA")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = true; // Activar ocultar caracteres
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                txtClave.Text = "CONTRASEÑA";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false; // Desactivar ocultar caracteres
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            contraseñaModificada = true; // Marcar que la contraseña fue modificada
            Console.WriteLine("Contraseña modificada: " + contraseñaModificada);
        }




        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }
    }
}
