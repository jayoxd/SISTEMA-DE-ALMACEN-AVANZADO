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
using System.Net;
namespace CapaPresentacion
{
    public partial class FRMProveedor : Form
    {
        N_Proveedores objNegocio = new N_Proveedores();
        N_Proveedores entidad = new N_Proveedores();
        public FRMProveedor()
        {
            InitializeComponent();

            // Configurar el DataGridView para desactivar el ajuste automático y el redimensionamiento manual
            tablaReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Desactiva el ajuste automático de ancho
            tablaReporte.AllowUserToResizeColumns = false; // Evita que el usuario redimensione las columnas

            // Desactiva la generación automática de columnas
            tablaReporte.AutoGenerateColumns = false;
            // Desactiva la generación automática de columnas
            tablaReporte.AutoGenerateColumns = false;

            // Configura las columnas una vez al inicio
            ConfigurarColumnas();

            // Carga los datos
            MostrarProveedores();
        }

          public void MostrarProveedores()
        {
            try
            {
                var dataTable = objNegocio.ConsultarProveedores(estado:true);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    tablaReporte.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarColumnas()
        {
            // Limpia las columnas existentes
            tablaReporte.Columns.Clear();

            // Configuración de las columnas visibles
            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RUC",
                HeaderText = "RUC",
                DataPropertyName = "RUC",
                Width = 140 // Ajustar el ancho
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Razón Social",
                DataPropertyName = "Nombre",
                Width = 200 // Ajustar el ancho
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Direccion",
                HeaderText = "Ubicación",
                DataPropertyName = "Direccion",
                Width = 150 // Ajustar el ancho
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                Width = 100 // Ajustar el ancho
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Correo",
                DataPropertyName = "Email",
                Width = 300 // Ajustar el ancho

            });

            // Configuración de las columnas ocultas
            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProveedorID",
                DataPropertyName = "ProveedorID",
                Visible = false
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                DataPropertyName = "Estado",
                Visible = false
            });
        }



        public void BuscarProveedor(string filtrox)
        {
            try
            {
                var dataTable = objNegocio.ConsultarProveedores(filtroGeneral:filtrox,estado:true);
                tablaReporte.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            BuscarProveedor(txbBreport.Text);
        }

        private void tablaReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tablaReporte.CurrentRow != null)
                {
                    F_Variables.RUC = Convert.ToString(tablaReporte.CurrentRow.Cells["RUC"].Value ?? string.Empty);
                    F_Variables.empresa = Convert.ToString(tablaReporte.CurrentRow.Cells["Nombre"].Value ?? string.Empty);
                    F_Variables.direccionEmp = Convert.ToString(tablaReporte.CurrentRow.Cells["Direccion"].Value ?? string.Empty);

                    // Validar que el valor no sea nulo o vacío antes de asignarlo
                    var celdaPrueba = Convert.ToString(tablaReporte.CurrentRow.Cells["ProveedorID"].Value ?? string.Empty);
                    if (celdaPrueba != null && int.TryParse(celdaPrueba.ToString(), out int id))
                    {
                        F_Variables.pruebatodox = id.ToString();
                    }
                    else
                    {
                        MessageBox.Show("El valor de la celda no es válido. Asegúrese de que sea un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No hay una fila seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al procesar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tablaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
