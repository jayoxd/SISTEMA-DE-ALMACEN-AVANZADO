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
    public partial class FrmAgregarProve : Form
    {
        N_Proveedores negocio = new N_Proveedores();

        public bool Update = false; // Indica si estamos en modo edición
        public string txtProveedorID = "";

        public FrmAgregarProve()
        {
            InitializeComponent();

            txtdniruc.KeyPress += txtdniruc_KeyPress;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (string.IsNullOrWhiteSpace(txtdireccionx.Text))
            {
                MessageBox.Show("El campo Dirección es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                MessageBox.Show("El campo Teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            // Crear entidad cliente
            E_proveedores proveedor = new E_proveedores
            {
                Ruc = txtdniruc.Text.Trim(),
                Nombre = txtnombre.Text.Trim(),
                Direccion = txtdireccionx.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Email = txtemail.Text.Trim(),
     
            };

            try
            {
                
                if (!Update)
                {
                    // Validar si el RUC ya existe y pertenece a otro proveedor
                    if (negocio.ExisteProveedorRUC(proveedor.Ruc) && proveedor.idProveedor.ToString() != txtProveedorID)
                    {
                        MessageBox.Show("El RUC ingresado ya está registrado en otro proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Insertar cliente
                    negocio.insertandoProveedor(proveedor);
                    MessageBox.Show("Proveedor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Actualizar cliente
                    proveedor.idProveedor = int.Parse(txtProveedorID);
                    negocio.actualizarproveedor(proveedor);
                    MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el Proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtdniruc_KeyDown(object sender, KeyEventArgs e)
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
            if (txtdniruc.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento si la longitud máxima se excede
            }
        }
    }
}
