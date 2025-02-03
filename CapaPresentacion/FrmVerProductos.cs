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
    public partial class FrmVerProductos : Form
    {
        // Propiedad para almacenar el producto seleccionado
        public F_Variables ProductoSeleccionado { get; private set; }
        private bool esSalida; // Indica si el formulario se usa para salidas

        public FrmVerProductos(bool esSalida)
        {
            InitializeComponent();
            this.esSalida = esSalida; // Asignar el contexto al abrir el formulario

            ConfigurarFuenteTabla();
            mostrarDiagnostico();
            accionestabla();

            // Asociar evento de doble clic a la tabla
            tablaReporte.CellDoubleClick += tablaReporte_CellDoubleClick;
        }

        // Método para mostrar los productos en el DataGridView
        public void mostrarDiagnostico()
        {
            N_Productoss objNegocio = new N_Productoss();
            try
            {
                var productos = objNegocio.listandoProductos(true); // Método que devuelve una lista o DataTable
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
            // Configuración de estilos para la cabecera
            tablaReporte.EnableHeadersVisualStyles = false;
            tablaReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
            tablaReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tablaReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

            // Configuración de las columnas con nombres y anchura
            if (tablaReporte.Columns.Contains("CodigoProducto"))
            {
                tablaReporte.Columns["CodigoProducto"].HeaderText = "Código del Producto";
                tablaReporte.Columns["CodigoProducto"].Width = 150;
                tablaReporte.Columns["CodigoProducto"].DisplayIndex = 0;
            }

            if (tablaReporte.Columns.Contains("DescripcionProducto"))
            {
                tablaReporte.Columns["DescripcionProducto"].HeaderText = "Descripción";
                tablaReporte.Columns["DescripcionProducto"].Width = 300;
                tablaReporte.Columns["DescripcionProducto"].DisplayIndex = 1;
            }

            if (tablaReporte.Columns.Contains("StockActual"))
            {
                tablaReporte.Columns["StockActual"].HeaderText = "Stock Actual";
                tablaReporte.Columns["StockActual"].Width = 100;
                tablaReporte.Columns["StockActual"].DisplayIndex = 2;
            }

            if (tablaReporte.Columns.Contains("Precio_Inicial"))
            {
                tablaReporte.Columns["Precio_Inicial"].HeaderText = "Precio Compra Anterior";
                tablaReporte.Columns["Precio_Inicial"].Width = 100;
                tablaReporte.Columns["Precio_Inicial"].DisplayIndex = 3;
            }

            if (tablaReporte.Columns.Contains("PrecioUnitario"))
            {
                tablaReporte.Columns["PrecioUnitario"].HeaderText = "Precio Compra Actual";
                tablaReporte.Columns["PrecioUnitario"].Width = 100;
                tablaReporte.Columns["PrecioUnitario"].DisplayIndex = 4;
            }

            if (tablaReporte.Columns.Contains("BASICO"))
            {
                tablaReporte.Columns["BASICO"].HeaderText = "Precio V. Básico";
                tablaReporte.Columns["BASICO"].Width = 100;
                tablaReporte.Columns["BASICO"].DisplayIndex = 5;
            }

            if (tablaReporte.Columns.Contains("Saga"))
            {
                tablaReporte.Columns["Saga"].HeaderText = "Precio V. Saga";
                tablaReporte.Columns["Saga"].Width = 100;
                tablaReporte.Columns["Saga"].DisplayIndex = 6;
            }

            if (tablaReporte.Columns.Contains("Agora"))
            {
                tablaReporte.Columns["Agora"].HeaderText = "Precio V. Ágora";
                tablaReporte.Columns["Agora"].Width = 100;
                tablaReporte.Columns["Agora"].DisplayIndex = 7;
            }

            if (tablaReporte.Columns.Contains("Ripley"))
            {
                tablaReporte.Columns["Ripley"].HeaderText = "Precio V. Ripley";
                tablaReporte.Columns["Ripley"].Width = 100;
                tablaReporte.Columns["Ripley"].DisplayIndex = 8;
            }

            if (tablaReporte.Columns.Contains("Mayorista_3_5"))
            {
                tablaReporte.Columns["Mayorista_3_5"].HeaderText = "Precio V. Mayorista 3x5";
                tablaReporte.Columns["Mayorista_3_5"].Width = 100;
                tablaReporte.Columns["Mayorista_3_5"].DisplayIndex = 9;
            }

            if (tablaReporte.Columns.Contains("Mayorista_X_Caja"))
            {
                tablaReporte.Columns["Mayorista_X_Caja"].HeaderText = "Precio V. Mayorista x Caja";
                tablaReporte.Columns["Mayorista_X_Caja"].Width = 120;
                tablaReporte.Columns["Mayorista_X_Caja"].DisplayIndex = 10;
            }

            if (tablaReporte.Columns.Contains("Categoria"))
            {
                tablaReporte.Columns["Categoria"].HeaderText = "Categoría";
                tablaReporte.Columns["Categoria"].Width = 120;
                tablaReporte.Columns["Categoria"].DisplayIndex = 11; // Mover después de las columnas de precios
            }

            if (tablaReporte.Columns.Contains("Estado"))
            {
                tablaReporte.Columns["Estado"].HeaderText = "Estado";
                tablaReporte.Columns["Estado"].Visible = false; // Ocultar columna Estado
            }


            // Configuración adicional para mejorar la apariencia de la tabla
            foreach (DataGridViewColumn column in tablaReporte.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar encabezados
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar contenido
            }

            // Opcional: Alinear la columna "Descripción" a la izquierda
            if (tablaReporte.Columns.Contains("DescripcionProducto"))
            {
                tablaReporte.Columns["DescripcionProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // Ajustar la altura de las filas
            tablaReporte.RowTemplate.Height = 30; // Asegura filas uniformes

            // Configuración de bordes y selección
            tablaReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tablaReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            tablaReporte.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Fondo azul claro
            tablaReporte.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro

            // Configuración de lectura y selección
            tablaReporte.ReadOnly = true; // Deshabilita la edición en todo el DataGridView
            tablaReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de fila completa
            tablaReporte.MultiSelect = false; // Evita seleccionar múltiples filas
        }


        // Evento para cerrar el formulario
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para buscar productos según un criterio
        public void buscardiagnostico(string buscardiag)
        {
            N_Productoss objNegocio = new N_Productoss();
            tablaReporte.DataSource = objNegocio.BuscarProductoPorCodigoODescripcion(buscardiag,true);
        }

        // Evento para actualizar la tabla al escribir en el campo de búsqueda
        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            buscardiagnostico(txbBreport.Text);
        }

        // Evento para manejar el doble clic en una fila
        private void tablaReporte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no sea el encabezado
            {

                int stockActual = Convert.ToInt32(tablaReporte.Rows[e.RowIndex].Cells["StockActual"].Value);

                // Validar que el stock sea mayor a 0 si es una salida
                if (esSalida && stockActual == 0)
                {
                    MessageBox.Show("El producto seleccionado tiene un stock de 0. Por favor, elija otro producto.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir sin cerrar el formulario ni seleccionar el producto
                }

                ProductoSeleccionado = new F_Variables
                {
                    Codigo = tablaReporte.Rows[e.RowIndex].Cells["CodigoProducto"].Value.ToString(),
                    Descripcion = tablaReporte.Rows[e.RowIndex].Cells["DescripcionProducto"].Value.ToString(),
                    Categoria = tablaReporte.Rows[e.RowIndex].Cells["Categoria"].Value.ToString(),
                    PrecioUnitario = Convert.ToDecimal(tablaReporte.Rows[e.RowIndex].Cells["PrecioUnitario"].Value),
                    StockActual = Convert.ToInt32(tablaReporte.Rows[e.RowIndex].Cells["StockActual"].Value)
                };

                this.Close(); // Cerrar el formulario después de seleccionar el producto
            }
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

        private void tablaReporte_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
