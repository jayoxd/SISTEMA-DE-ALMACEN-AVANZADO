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

    public partial class FrmInventario : Form
    {
        N_Productoss objNegocio = new N_Productoss();
        N_Clientes indicadores = new N_Clientes ();
        N_Proveedores proveedores = new N_Proveedores();

        public FrmInventario()
        {
            InitializeComponent();
            CargarIndicadores();
            this.Load += FrmInventario_Load;
            TablaPRODUCTOS.DataBindingComplete += TablaPRODUCTOS_DataBindingComplete;
            TablaPRODUCTOS.CellFormatting += TablaPRODUCTOS_CellFormatting;

            // Configurar AutoGenerateColumns según prefieras
            TablaPRODUCTOS.AutoGenerateColumns = true; // O false si defines columnas manualmente
            TablaPRODUCTOS.DefaultCellStyle.Font = new Font("Arial", 9); // Tamaño 10, fuente Arial
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10); // Encabezados en negrita        
            TablaPRODUCTOS.DefaultCellStyle.ForeColor = Color.Gray; // Texto gris
        }







     
        private void TablaPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarIndicadores()
        {
            try

            {
                // Obtener y asignar valores a los labels
                int totalClientesActivos = indicadores.ContarClientesActivos();

                lblclientesactivos.Text = totalClientesActivos.ToString();
                lblproveeodreactivos.Text = proveedores.ContarProveedoresActivos().ToString();

                // Obtener y asignar valores a los labels
                lblproducbajostock.Text = indicadores.ObtenerProductosBajoStock(10).ToString(); // Stock mínimo = 10
                lblproductoactivos.Text = indicadores.ObtenerProductosActivos().ToString();
                lblentradasreciente.Text = indicadores.ObtenerEntradasRecientes().ToString();
                lbltotaldeldia.Text = indicadores.ObtenerSalidaRecientes().ToString();

              

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los indicadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {

        }









        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }
     
        private void Btnoinahbilitados_Click(object sender, EventArgs e)
        {
           
        }



        public void MostrarReporteInventario(string codigoProducto = null, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                // Llama al método ObtenerReporteInventario de la capa de negocio
                var reporteInventario = objNegocio.ObtenerReporteInventario(codigoProducto, fechaInicio, fechaFin);
                if (reporteInventario != null && reporteInventario.Rows.Count > 0)
                {
                    // Asigna el DataTable al DataGridView
                    TablaPRODUCTOS.DataSource = reporteInventario;
                }
                else
                {
                    // Si no hay datos, muestra un mensaje
                    TablaPRODUCTOS.DataSource = null;
                    MessageBox.Show("No hay datos para mostrar en el reporte de inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void TablaPRODUCTOS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigurarColumnasReporteInventario();
        }

        private void TablaPRODUCTOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Obtener el nombre de la columna actual
            string columnName = TablaPRODUCTOS.Columns[e.ColumnIndex].Name;

            // Definir los colores
            Color colorEntradas = Color.FromArgb(210, 230, 255); // Azul claro
            Color colorSalidas = Color.FromArgb(255, 210, 210);  // Rojo claro
            Color colorSaldos = Color.FromArgb(210, 255, 210);   // Verde claro

            // Asignar colores según la columna
            if (columnName == "EntradaCantidad" || columnName == "EntradaValorUnitario" || columnName == "EntradaValorTotal")
            {
                e.CellStyle.BackColor = colorEntradas;
                e.CellStyle.ForeColor = Color.Black;
            }
            else if (columnName == "SalidaCantidad" || columnName == "SalidaValorUnitario" || columnName == "SalidaValorTotal")
            {
                e.CellStyle.BackColor = colorSalidas;
                e.CellStyle.ForeColor = Color.Black;
            }
            else if (columnName == "SaldoCantidad" || columnName == "SaldoValorUnitario" || columnName == "SaldoValorTotal")
            {
                e.CellStyle.BackColor = colorSaldos;
                e.CellStyle.ForeColor = Color.Black;
            }
            else
            {
                // Para otras columnas, mantener el fondo blanco
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
            }

            // Mantener la selección coherente
            if (TablaPRODUCTOS.Rows[e.RowIndex].Selected)
            {
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }


            if ((columnName == "EntradaValorUnitario" || columnName == "SalidaValorUnitario" || columnName == "SaldoValorUnitario"
                || columnName == "EntradaCantidad" || columnName == "SalidaCantidad" || columnName == "SaldoCantidad" ||
                columnName == "EntradaValorTotal" || columnName == "SalidaValorTotal" || columnName == "SaldoValorTotal"
                )
                && e.Value != null)
            {
                // Convierte el valor de la celda a decimal
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Si el valor es 0.0, muestra una cadena vacía
                    if (value == 0.0m)
                    {
                        e.Value = ""; // Mostrar como vacío
                        e.FormattingApplied = true; // Indica que ya se aplicó el formato
                    }
                }
            }
        }

        private void ConfigurarColumnasReporteInventario()
        {
            if (TablaPRODUCTOS == null)
            {
                throw new InvalidOperationException("La tabla de productos no está inicializada.");
            }

            // Verificar si hay columnas en el DataGridView
            if (TablaPRODUCTOS.Columns.Count == 0)
            {
                MessageBox.Show("No hay columnas en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // **Depuración: Listar columnas para confirmar existencia**
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Columnas disponibles en ConfigurarColumnasReporteInventario:");
            foreach (DataGridViewColumn column in TablaPRODUCTOS.Columns)
            {
                sb.AppendLine($"Nombre: {column.Name}, HeaderText: {column.HeaderText}");
            }
            Console.WriteLine(sb.ToString()); // Puedes ver esto en la ventana de salida del depurador

            // 1. Desactivar estilos visuales de encabezados para permitir personalización completa
            TablaPRODUCTOS.EnableHeadersVisualStyles = false;

            // 2. Configurar estilo general de los encabezados
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Fondo gris
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Texto blanco
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Texto centrado
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Fuente Arial, 10pt, negrita
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 2, 0, 2); // Espaciado reducido

            // 3. Ajustar la altura de los encabezados para reducir el espacio
            TablaPRODUCTOS.ColumnHeadersHeight = 25; // Altura fija más baja

            // 4. Configurar estilo general de las celdas
            TablaPRODUCTOS.DefaultCellStyle.Font = new Font("Arial", 9); // Fuente Arial, 9pt
            TablaPRODUCTOS.DefaultCellStyle.ForeColor = Color.Gray; // Texto gris en celdas

            // 5. Desactivar filas alternadas
            TablaPRODUCTOS.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            TablaPRODUCTOS.RowsDefaultCellStyle.BackColor = Color.White;

            // 6. Configurar encabezados básicos para las columnas principales
            var encabezados = new Dictionary<string, string>
            {
                { "Numero", "Nro" }, // Cambiar "Numero" a "Nro"
                { "Fecha", "Fecha" },
                { "Operacion", "Operación" },
                { "TipoDocumento", "T.D." },
                { "Documento", "DNI/RUC" },
                { "Medio", "Medio" },
                { "TipoCambio", "Dolar $" }
            };

            foreach (var encabezado in encabezados)
            {
                if (TablaPRODUCTOS.Columns.Contains(encabezado.Key))
                {
                    TablaPRODUCTOS.Columns[encabezado.Key].HeaderText = encabezado.Value;
                }
                else
                {
                    // **Depuración: Informar si una columna no existe**
                    MessageBox.Show($"La columna '{encabezado.Key}' no se encontró en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 7. Definir los colores para las columnas específicas
            Color colorEntradas = Color.FromArgb(210, 230, 255); // Azul claro
            Color colorSalidas = Color.FromArgb(255, 210, 210);  // Rojo claro
            Color colorSaldos = Color.FromArgb(210, 255, 210);   // Verde claro

            // 8. Configuración de colores y encabezados para las columnas de "Entradas"
            var columnasEntradas = new Dictionary<string, string>
            {
                { "EntradaCantidad", "Cantidad" },
                { "EntradaValorUnitario", "Valor Unitario" },
                { "EntradaValorTotal", "Valor Total" }
            };
            foreach (var columna in columnasEntradas)
            {
                if (TablaPRODUCTOS.Columns.Contains(columna.Key))
                {
                    var dataGridViewColumn = TablaPRODUCTOS.Columns[columna.Key];
                    dataGridViewColumn.DefaultCellStyle.BackColor = colorEntradas;
                    dataGridViewColumn.DefaultCellStyle.ForeColor = Color.Black; // Texto negro para mejor contraste
                    dataGridViewColumn.DefaultCellStyle.SelectionBackColor = colorEntradas; // Mantiene el color al seleccionar
                    dataGridViewColumn.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto negro al seleccionar
                    dataGridViewColumn.HeaderText = columna.Value; // Asignar encabezado específico
                }
            }

            // 9. Configuración de colores y encabezados para las columnas de "Salidas"
            var columnasSalidas = new Dictionary<string, string>
            {
                { "SalidaCantidad", "Cantidad" },
                { "SalidaValorUnitario", "Valor Unitario" },
                { "SalidaValorTotal", "Valor Total" }
            };
            foreach (var columna in columnasSalidas)
            {
                if (TablaPRODUCTOS.Columns.Contains(columna.Key))
                {
                    var dataGridViewColumn = TablaPRODUCTOS.Columns[columna.Key];
                    dataGridViewColumn.DefaultCellStyle.BackColor = colorSalidas;
                    dataGridViewColumn.DefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewColumn.DefaultCellStyle.SelectionBackColor = colorSalidas;
                    dataGridViewColumn.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridViewColumn.HeaderText = columna.Value;
                }
            }

            // 10. Configuración de colores y encabezados para las columnas de "Saldos"
            var columnasSaldos = new Dictionary<string, string>
            {
                { "SaldoCantidad", "Cantidad" },
                { "SaldoValorUnitario", "Valor Unitario" },
                { "SaldoValorTotal", "Valor Total" }
            };
            foreach (var columna in columnasSaldos)
            {
                if (TablaPRODUCTOS.Columns.Contains(columna.Key))
                {
                    var dataGridViewColumn = TablaPRODUCTOS.Columns[columna.Key];
                    dataGridViewColumn.DefaultCellStyle.BackColor = colorSaldos;
                    dataGridViewColumn.DefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewColumn.DefaultCellStyle.SelectionBackColor = colorSaldos;
                    dataGridViewColumn.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridViewColumn.HeaderText = columna.Value;
                }
            }

            // 11. Configuración general para todas las columnas restantes
            foreach (DataGridViewColumn column in TablaPRODUCTOS.Columns)
            {
                // Centrar texto en celdas
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ajustar ancho automático
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Fondo blanco por defecto si no tiene color asignado
                if (column.DefaultCellStyle.BackColor == Color.Empty)
                    column.DefaultCellStyle.BackColor = Color.White;
            }

            // 12. Configurar bordes y fondo blanco general
            TablaPRODUCTOS.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TablaPRODUCTOS.GridColor = Color.LightGray;
            TablaPRODUCTOS.RowHeadersVisible = false;
            TablaPRODUCTOS.AllowUserToAddRows = false;
            TablaPRODUCTOS.RowTemplate.Height = 30;

            // 13. Cambiar el modo de selección para evitar selección de filas completas
            TablaPRODUCTOS.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 14. Personalizar específicamente el encabezado "Numero" (que ahora es "Nro")
            if (TablaPRODUCTOS.Columns.Contains("Numero"))
            {
                var nroColumn = TablaPRODUCTOS.Columns["Numero"];
                var fechahora= TablaPRODUCTOS.Columns["FechaHora"];

                // Verificar si nroColumn no es null
                if (nroColumn != null)
                {

                    fechahora.Visible = false;
                    nroColumn.Visible = false;
                    // Establecer una fuente más pequeña para el encabezado "Nro"
                    nroColumn.HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold); // Fuente Arial, 8pt, negrita

                    // Ajustar el espaciado interno del encabezado "Nro" para reducir el espacio
                    nroColumn.HeaderCell.Style.Padding = new Padding(0, 1, 0, 1); // Espaciado reducido

                    // Ajustar el ancho de la columna "Numero"
                    nroColumn.Width = 30; // Ajusta este valor según tus necesidades

                    // Desactivar el ajuste automático de ancho para esta columna
                    nroColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    // Alinear el texto de las celdas "Numero" al centro (ya está centrado, pero se reafirma)
                    nroColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
                else
                {
                    MessageBox.Show("La columna 'Numero' no se encontró en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            
          

        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
           
        }

        public DataTable ObtenerReporteInventariotodo()
        {
            return new N_Productoss().ObtenerReporteInventariotodo();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string codigoProducto = txbBuscarProducto.Text.Trim();
            DateTime? fechaInicio = dtpFechaInicio.Value;
            DateTime? fechaFin = dtpFechaFin.Value;
            TablaPRODUCTOS.CellFormatting += TablaPRODUCTOS_CellFormatting;

            MostrarReporteInventario(codigoProducto, fechaInicio, fechaFin);
        }

        private void lbltotaldeldia_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
