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
    public partial class FrmAgregarProducto : Form
    {
        frmProductos frm = new frmProductos();
        E_productoss entidades = new E_productoss();
        N_Productoss negocio = new N_Productoss();

        public  bool Update = false;
         

        public FrmAgregarProducto()
        {
            InitializeComponent();
            ConfigurarEstadoComboBox();
            txtStocP.KeyPress += txtStocP_KeyPress;
            txtStocP.Leave += txtStocP_Leave;

            txtPrecio.KeyPress += txtPrecio_KeyPress;
            txtPrecio.Leave += txtPrecio_Leave;
           
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            txtCodigox.ReadOnly = false; // Permitir edición
            txtCodigox.Enabled = true;   // Asegurar que esté habilitado 
            if (Update) // Si es modo edición
            {
                // Deshabilitar los campos que no se deben editar
                txtPrecio.Enabled = false;
                txtCodigox.Enabled = false;
                txtStocP.Enabled = false;
            }
            else
            {
                // Si es un nuevo registro, permitir la edición
                txtPrecio.Enabled = true;
                txtCodigox.Enabled = true;
                txtStocP.Enabled = true;
            }
        }

        private void ConfigurarEstadoComboBox()
        {
            // Configura el combo box con las opciones "Activo" e "Inactivo"
            cmbestado.Items.Clear();
            cmbestado.Items.Add("Activo");
            cmbestado.Items.Add("Inactivo");
            cmbestado.SelectedIndex = 0; // Selecciona "Activo" por defecto
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarProductosx_Click(object sender, EventArgs e)
        {


            try
            {
                // Validar que todos los campos obligatorios estén completos
                if (string.IsNullOrEmpty(txtCodigox.Text) ||
                    string.IsNullOrEmpty(txtNombreProducto.Text) ||
                    string.IsNullOrEmpty(categoria.Text) ||
                    string.IsNullOrEmpty(cmbestado.Text) ||
                    string.IsNullOrEmpty(txbbasico.Text) ||
                    string.IsNullOrEmpty(txbSaga.Text) ||
                    string.IsNullOrEmpty(txbagora.Text) ||
                    string.IsNullOrEmpty(txbRipley.Text) ||
                    string.IsNullOrEmpty(txbMayorista3x5.Text) ||
                    string.IsNullOrEmpty(txbmayoristaxcaja.Text)||
                    string.IsNullOrEmpty(txbPrecioAnt.Text)) 
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que los precios sean valores decimales válidos
                if (!decimal.TryParse(txbbasico.Text, out decimal basico) ||
                    !decimal.TryParse(txbSaga.Text, out decimal saga) ||
                    !decimal.TryParse(txbagora.Text, out decimal agora) ||
                    !decimal.TryParse(txbRipley.Text, out decimal ripley) ||
                    !decimal.TryParse(txbMayorista3x5.Text, out decimal mayorista3x5) ||
                    !decimal.TryParse(txbmayoristaxcaja.Text, out decimal mayoristaXcaja))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para los precios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Configurar entidad para el producto
                entidades.CodigoProducto = txtCodigox.Text;
                entidades.DescripcionProducto = txtNombreProducto.Text;
                entidades.Categoria = categoria.Text;
                entidades.estado = cmbestado.SelectedItem.ToString() == "Activo";

                // Configurar precios de venta en la entidad
                entidades.BASICO = basico;
                entidades.Saga = saga;
                entidades.Agora = agora;
                entidades.Ripley = ripley;
                entidades.Mayorista_3_5 = mayorista3x5;
                entidades.Mayorista_X_Caja = mayoristaXcaja;

                if (Update == false) // Inserción
                {
                    // Llamar al método para insertar el producto
                    negocio.insertandoproductos(entidades);
                    negocio.GenerarScriptInsertar(entidades);

                    MessageBox.Show("Producto y precios agregados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Actualización
                {
                    // Llamar al método para actualizar el producto
                    entidades.PrecioUnitario = Convert.ToDecimal(txbPrecioAnt.Text); 
                        entidades.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                        entidades.StockActual = Convert.ToInt32(txtStocP.Text);
                    negocio.editandoProducto(entidades);
                    negocio.GenerarScriptActualizar(entidades);

                    MessageBox.Show("Producto y precios actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cerrar el formulario después de guardar
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigox_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtStocP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear la tecla
            }

            // Permitir un solo punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true; // Bloquear si ya hay un punto decimal
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            // Validar que el precio no sea negativo ni esté vacío al salir de la caja
            

        }

       

        private void txtStocP_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtStocP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
