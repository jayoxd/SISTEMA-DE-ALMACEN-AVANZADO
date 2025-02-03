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
    public partial class FrmEntradasver : Form
    {
        // Propiedad para almacenar el producto seleccionado
        public F_Variables EntradaSeleccionada { get; private set; }

        public FrmEntradasver()
        {
            InitializeComponent();
            ConfigurarFuenteTabla();
            mostrarDiagnostico();
            accionestabla();

            // Asociar evento de doble clic a la tabla
            tablaReporte.CellDoubleClick += tablaReporte_CellDoubleClick;
        }

        // Método para mostrar los productos en el DataGridView
        public void mostrarDiagnostico()
        {
            N_Entrada objNegocio = new N_Entrada();
            try
            {
                var productos = objNegocio.ListarEntradas(); // Método que devuelve una lista o DataTable
                tablaReporte.DataSource = productos; // Asignar los datos al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Método para ajustar las propiedades visuales de la tabla

        public void accionestabla()
        {
            if (tablaReporte.Columns.Count == 0) return;

            // Configuración de estilos para la cabecera
            tablaReporte.EnableHeadersVisualStyles = false;
            tablaReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
            tablaReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tablaReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Configuración de columnas con nombres, anchura y alineación
            if (tablaReporte.Columns.Contains("NroDocumento"))
            {
                tablaReporte.Columns["NroDocumento"].HeaderText = "Número de Documento";
                tablaReporte.Columns["NroDocumento"].Width = 180;
                tablaReporte.Columns["NroDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("ProveedorNombre"))
            {
                tablaReporte.Columns["ProveedorNombre"].HeaderText = "Nombre del Proveedor";
                tablaReporte.Columns["ProveedorNombre"].Width = 220;
                tablaReporte.Columns["ProveedorNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alineado a la izquierda
            }
            if (tablaReporte.Columns.Contains("FechaHoraSys"))
            {
                tablaReporte.Columns["FechaHoraSys"].HeaderText = "Fecha/Hora Sys";
                tablaReporte.Columns["FechaHoraSys"].Width = 130;
                tablaReporte.Columns["FechaHoraSys"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            if (tablaReporte.Columns.Contains("TipoCambio"))
            {
                tablaReporte.Columns["TipoCambio"].HeaderText = "Tipo de Cambio";
                tablaReporte.Columns["TipoCambio"].Width = 80;
                tablaReporte.Columns["TipoCambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            } 



            if (tablaReporte.Columns.Contains("Tipo_Comprobante"))
            {
                tablaReporte.Columns["Tipo_Comprobante"].HeaderText = "Tipo de Comprobante";
                tablaReporte.Columns["Tipo_Comprobante"].Width = 110;
                tablaReporte.Columns["Tipo_Comprobante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("Nro_Comprobante"))
            {
                tablaReporte.Columns["Nro_Comprobante"].HeaderText = "Número de Comprobante";
                tablaReporte.Columns["Nro_Comprobante"].Width = 180;
                tablaReporte.Columns["Nro_Comprobante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("Fecha"))
            {
                tablaReporte.Columns["Fecha"].HeaderText = "Fecha de Entrada";
                tablaReporte.Columns["Fecha"].Width = 110;
                tablaReporte.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("ProveedorID"))
            {
                tablaReporte.Columns["ProveedorID"].Visible = false; // Ocultar la columna ProveedorID
            }

            // Centrar encabezados y contenido de todas las columnas
            foreach (DataGridViewColumn column in tablaReporte.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar encabezados
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar contenido
            }

            // Ajustar la altura de las filas
            tablaReporte.RowTemplate.Height = 30; // Asegura filas uniformes

            // Configuración de la fuente
            tablaReporte.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);
            tablaReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Cambiar color de la fila seleccionada
            tablaReporte.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Fondo azul claro
            tablaReporte.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro

            // Deshabilitar edición
            tablaReporte.ReadOnly = true; // Deshabilita la edición en todo el DataGridView

            // Habilitar selección de fila completa
            tablaReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            tablaReporte.MultiSelect = false; // Evita seleccionar múltiples filas
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            // Verifica si no se seleccionó ninguna entrada (si F_Variables.NroDocumento no se asignó)
            if (string.IsNullOrWhiteSpace(F_Variables.NroDocumento))
            {
                MessageBox.Show("No seleccionaste ninguna entrada. Cerrando sin cargar datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Opcional: puedes limpiar los valores si lo deseas
                F_Variables.NroDocumento = null;
                F_Variables.ProveedorID = 0;
            }

            // Cierra el formulario
            this.Close();
        }

        public void BuscarporNrdoNroComp(string valor)
        {
            N_Entrada objNegocio = new N_Entrada();

            tablaReporte.DataSource = objNegocio.buscarporNrodoandnrocompro(valor);
            accionestabla();
        }

        // Evento para actualizar la tabla al escribir en el campo de búsqueda
        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            BuscarporNrdoNroComp(txbBreport.Text);
        }


        // Evento para manejar el doble clic en una fila
        private void tablaReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que no sea el encabezado
            {
                F_Variables.NroDocumento = tablaReporte.Rows[e.RowIndex].Cells["NroDocumento"].Value.ToString();

                F_Variables.ProveedorID = (tablaReporte.CurrentRow.Cells["ProveedorID"].Value != DBNull.Value)
                    ? Convert.ToInt32(tablaReporte.CurrentRow.Cells["ProveedorID"].Value)
                    : 0;

                // Cierra el formulario después de seleccionar la entrada
                this.Close();
            }
        }


        private void tablaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ConfigurarFuenteTabla()
        {
            // Cambiar la fuente de las celdas
            tablaReporte.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);

            // Cambiar la fuente de los encabezados
            tablaReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Opcional: ajustar el tamaño de las filas para que se adapten a la nueva fuente
            tablaReporte.RowTemplate.Height = 30;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void tablaReporte_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
