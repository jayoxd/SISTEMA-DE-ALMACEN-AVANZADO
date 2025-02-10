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
    public partial class FrmAgregarClientes : Form
    {
        FrmRolesver frm = new FrmRolesver();
        N_Clientes negocio = new N_Clientes();

        public bool Update = false; // Indica si estamos en modo edición
        public string txtClienteID = "";

        public FrmAgregarClientes()
        {
            InitializeComponent();
            InicializarCombos(); // Inicializa los ComboBox al cargar el formulario


        }
        private void InicializarCombos()
        {
            // Configurar cmbtipocliente
            cmbtipocliente.Items.Clear();
            cmbtipocliente.Items.Add("INTERNO");
            cmbtipocliente.Items.Add("EXTERNO");
            cmbtipocliente.SelectedIndex = 0; // Seleccionar la primera opción por defecto

            
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void listar_rol()
        {
           
        }
 
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtdniruc.Text))
            {
                MessageBox.Show("El campo DNI/RUC es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            // Crear entidad cliente
            E_Clientes cliente = new E_Clientes
            {
                dni = txtdniruc.Text.Trim(),
                Nombre = txtnombre.Text.Trim(),
                Direccion = txtdireccionx.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Email = txtemail.Text.Trim(),
                origencliente = cmbtipocliente.SelectedItem.ToString(),
                departamento = txtdepart.Text.Trim(),
                provincia = txtprovincia.Text.Trim(),
                distrito = txtdistrito.Text.Trim(),
                googlemaps = txtlinkgoogle.Text.Trim(),
            };

            try
            {
                string scriptSQL;

                if (!Update)
                {
                    if (negocio.ExisteClienteRUC(cliente.dni) && cliente.Idcliente.ToString() != txtClienteID)
                {
                    MessageBox.Show("El Dni ingresado ya está registrado en otro Cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                    // Insertar cliente
                    scriptSQL = negocio.GenerarScriptInsertar(cliente);
                    // Insertar cliente
                    negocio.insertandoCliente(cliente);
                    MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Cliente agregado exitosamente.\n\n" + scriptSQL, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    // Actualizar cliente
                    // Validar si el RUC ya existe y pertenece a otro proveedor
                    // Actualizar cliente
                    cliente.Idcliente = int.Parse(txtClienteID);
                    scriptSQL = negocio.GenerarScriptActualizar(cliente);
                    cliente.Idcliente = int.Parse(txtClienteID);
                    negocio.editandoCliente(cliente);
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Cliente actualizado exitosamente.\n\n" + scriptSQL, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



     
        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbROLES_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void txtNmrDocemp_TextChanged(object sender, EventArgs e)
        {

        }



        private void cmbTipoDocumentoEM_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txtClave_Enter(object sender, EventArgs e)
        {
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }


      

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtdniruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento si no es un número
                return;
            }

            // Validar longitud máxima para DNI (8 dígitos)
            if (txtdniruc.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento si la longitud máxima se excede
            }
        }
    }
}
