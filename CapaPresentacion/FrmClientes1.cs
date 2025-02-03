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
    public partial class FrmClientes1 : Form
    {
        N_Clientes objNegocio = new N_Clientes();
        public FrmClientes1()
        {
            InitializeComponent();


            // Configurar el DataGridView para desactivar el ajuste automático y el redimensionamiento manual
            tablaReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Desactiva el ajuste automático de ancho
            tablaReporte.AllowUserToResizeColumns = false; // Evita que el usuario redimensione las columnas

            // Desactiva la generación automática de columnas
            tablaReporte.AutoGenerateColumns = false;
            // Desactiva la generación automática de columnas
            tablaReporte.AutoGenerateColumns = false;

            // Configura las columnas manualmente
            ConfigurarColumnas();

            // Carga los datos
            mostrarDiagnostico();
        }

        private void ConfigurarColumnas()
        {
            // Limpia las columnas existentes
            tablaReporte.Columns.Clear();

            // Columna ClienteID (oculta pero necesaria para lógica)
            var clienteIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "ClienteID",
                HeaderText = "ClienteID",
                DataPropertyName = "ClienteID",
                Visible = false // Oculta la columna
            };
            tablaReporte.Columns.Add(clienteIdColumn);

            // Configuración de columnas visibles
            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DNI",
                HeaderText = "DNI/RUC",
                DataPropertyName = "DNI",
                Width = 100, // Ancho explícito
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactiva el ajuste automático
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Razón Social",
                DataPropertyName = "Nombre",
                Width = 200, // Ancho extendido
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactiva el ajuste automático
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "origencliente",
                HeaderText = "Origen Cliente",
                DataPropertyName = "origencliente",
                Width = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactiva el ajuste automático
            });
            // Mantener las columnas originales en el DataTable, pero ocultarlas
            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Departamento",
                HeaderText = "Departamento",
                DataPropertyName = "Departamento",
                Visible = false // Ocultar
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Provincia",
                HeaderText = "Provincia",
                DataPropertyName = "Provincia",
                Visible = false // Ocultar
            });

            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Distrito",
                HeaderText = "Distrito",
                DataPropertyName = "Distrito",
                Visible = false // Ocultar
            });

            // Columna de Ubigeo (combinación de Departamento/Provincia/Distrito)
            tablaReporte.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Ubigeo",
                HeaderText = "Ubigeo",
                Width = 390,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactiva el ajuste automático
            });

            // Configurar el evento CellFormatting para combinar los valores
            tablaReporte.CellFormatting += tablaReporte_CellFormatting;

        }

        private void tablaReporte_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tablaReporte.Columns[e.ColumnIndex].Name == "Ubigeo")
            {
                // Accede a la fila actual
                var row = tablaReporte.Rows[e.RowIndex];

                // Recupera los valores de las columnas ocultas
                string departamento = row.Cells["Departamento"].Value?.ToString() ?? "";
                string provincia = row.Cells["Provincia"].Value?.ToString() ?? "";
                string distrito = row.Cells["Distrito"].Value?.ToString() ?? "";

                // Combina los valores en una sola celda
                e.Value = $"{departamento}/{provincia}/{distrito}";
                e.FormattingApplied = true;
            }
        }

        public void mostrarDiagnostico()
        {
            try
            {
                N_Clientes objNegocio = new N_Clientes();
                var dataTable = objNegocio.ConsultarClientes(estado:true);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    // Desactivar la generación automática de columnas
                    tablaReporte.AutoGenerateColumns = false;

                    // Configurar columnas manualmente
            
                    // Asignar los datos al DataGridView
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

   


      


        public void buscardiagnostico(string buscardiag)
        {
            try
            {
                var dataTable = objNegocio.ConsultarClientes(filtro:buscardiag,estado:true);
               
                    tablaReporte.DataSource = dataTable;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            buscardiagnostico(txbBreport.Text);

        }
      


        private void tablaReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                F_Variables.ClienteID = Convert.ToInt32(tablaReporte.CurrentRow.Cells["ClienteID"].Value); // ClienteID
                F_Variables.DNI = Convert.ToString(tablaReporte.CurrentRow.Cells["DNI"].Value);
                F_Variables.Nombre = Convert.ToString(tablaReporte.CurrentRow.Cells["Nombre"].Value);
                F_Variables.Ubigeo = $"{tablaReporte.CurrentRow.Cells["Departamento"].Value}/{tablaReporte.CurrentRow.Cells["Provincia"].Value}/{tablaReporte.CurrentRow.Cells["Distrito"].Value}";
                F_Variables.OrigenCliente = Convert.ToString(tablaReporte.CurrentRow.Cells["origencliente"].Value);

                // Cierra el formulario una vez asignados los valores
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
