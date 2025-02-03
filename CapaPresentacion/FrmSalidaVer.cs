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
    public partial class FrmSalidaVer : Form
    {
        // Propiedad para almacenar el producto seleccionado
        public F_Variables EntradaSeleccionada { get; private set; }

        public FrmSalidaVer()
        {
            InitializeComponent();
            ConfigurarFuenteTabla();
            MostrarSalidas();
            accionestabla();

            // Asociar evento de doble clic a la tabla
            tablaReporte.CellDoubleClick += tablaReporte_CellDoubleClick;
        }

        public void MostrarSalidas()
        {
            N_Salida objNegocio = new N_Salida();
            try
            {
                var salidas = objNegocio.ListarSalidas(); // Método que devuelve una lista o DataTable
                tablaReporte.DataSource = salidas; // Asignar los datos al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las salidas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (tablaReporte.Columns.Contains("ClienteNombre"))
            {
                tablaReporte.Columns["ClienteNombre"].HeaderText = "Nombre del Cliente";
                tablaReporte.Columns["ClienteNombre"].Width = 220;
                tablaReporte.Columns["ClienteNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alineado a la izquierda
            }

            if (tablaReporte.Columns.Contains("TipoVenta"))
            {
                tablaReporte.Columns["TipoVenta"].HeaderText = "Tipo de Venta";
                tablaReporte.Columns["TipoVenta"].Width = 120;
                tablaReporte.Columns["TipoVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (tablaReporte.Columns.Contains("FechaHoraSys"))
            {
                tablaReporte.Columns["FechaHoraSys"].HeaderText = "Fecha/Hora Sys";
                tablaReporte.Columns["FechaHoraSys"].Width = 130;
                tablaReporte.Columns["FechaHoraSys"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                tablaReporte.Columns["Fecha"].HeaderText = "Fecha de Salida";
                tablaReporte.Columns["Fecha"].Width = 110;
                tablaReporte.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("origencliente"))
            {
                tablaReporte.Columns["origencliente"].HeaderText = "Origen Cliente";
                tablaReporte.Columns["origencliente"].Width = 150;
                tablaReporte.Columns["origencliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (tablaReporte.Columns.Contains("Codigo_Pedido"))
            {
                tablaReporte.Columns["Codigo_Pedido"].HeaderText = "Código de Pedido";
                tablaReporte.Columns["Codigo_Pedido"].Width = 150;
                tablaReporte.Columns["Codigo_Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (tablaReporte.Columns.Contains("FechaDespacho"))
            {
                tablaReporte.Columns["FechaDespacho"].HeaderText = "Fecha de Despacho";
                tablaReporte.Columns["FechaDespacho"].Width = 150;
                tablaReporte.Columns["FechaDespacho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ocultar columnas innecesarias
            if (tablaReporte.Columns.Contains("ClienteID")) tablaReporte.Columns["ClienteID"].Visible = false;
            if (tablaReporte.Columns.Contains("Departamento")) tablaReporte.Columns["Departamento"].Visible = false;
            if (tablaReporte.Columns.Contains("Distrito")) tablaReporte.Columns["Distrito"].Visible = false;
            if (tablaReporte.Columns.Contains("Provincia")) tablaReporte.Columns["Provincia"].Visible = false;

            // Configuración de fuente y diseño
            tablaReporte.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);
            tablaReporte.RowTemplate.Height = 30; // Altura uniforme para las filas

            // Cambiar color de selección de fila
            tablaReporte.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Fondo azul claro
            tablaReporte.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro

            // Deshabilitar edición
            tablaReporte.ReadOnly = true;

            // Habilitar selección de fila completa
            tablaReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablaReporte.MultiSelect = false; // Evita seleccionar múltiples filas

            // Centrar encabezados de todas las columnas
            foreach (DataGridViewColumn column in tablaReporte.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        // Evento para cerrar el formulario
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            // Verifica si no se seleccionó ninguna salida (si F_Variables.NroDocumento no se asignó)
            if (string.IsNullOrWhiteSpace(F_Variables.NroDocumento))
            {
                MessageBox.Show("No seleccionaste ninguna salida. Cerrando sin cargar datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Opcional: puedes limpiar los valores si lo deseas
                F_Variables.NroDocumento = null;
                F_Variables.ClienteID = 0;
                F_Variables.Ubigeo = null;
                F_Variables.Nombre = null;
                F_Variables.DNI = null;
                F_Variables.OrigenCliente = null;
            }

            // Cierra el formulario
            this.Close();
        }

        public void BuscarporNrdoNroComp(string valor)
        {
            N_Salida objNegocio = new N_Salida();

            tablaReporte.DataSource = objNegocio.BuscarPorNroDocOComprobante(valor);
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
            if (e.RowIndex >= 0) // Asegurarse de que no sea el encabezado
            {
                // Asignar valores a F_Variables
                F_Variables.NroDocumento = tablaReporte.Rows[e.RowIndex].Cells["NroDocumento"].Value.ToString();
                F_Variables.ClienteID = (tablaReporte.CurrentRow.Cells["ClienteID"].Value != DBNull.Value)
                    ? Convert.ToInt32(tablaReporte.CurrentRow.Cells["ClienteID"].Value)
                    : 0; // Valor predeterminado si la celda es nula

                F_Variables.Ubigeo = $"{tablaReporte.Rows[e.RowIndex].Cells["Departamento"].Value}, " +
                                     $"{tablaReporte.Rows[e.RowIndex].Cells["Provincia"].Value}, " +
                                     $"{tablaReporte.Rows[e.RowIndex].Cells["Distrito"].Value}";
                F_Variables.Nombre = tablaReporte.Rows[e.RowIndex].Cells["ClienteNombre"].Value.ToString();
                F_Variables.DNI = tablaReporte.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                F_Variables.OrigenCliente = tablaReporte.Rows[e.RowIndex].Cells["origencliente"].Value.ToString();

                // Cerrar el formulario después de seleccionar la salida
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
