using CapaEntidades;
using CapaNegocio;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVerDetalleSalida: Form
    {
       // N_Servicio objNegocio = new N_Servicio();
       // E_Servicio entidades = new E_Servicio();
        public bool Update = false;
        int numero;

        public int Idusuario;
        public int Idrol;
        public string nombre;
        public string rol;
        public bool estado;

        public FrmVerDetalleSalida()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void accionesTabladetalle()
        {
            TablaDetalle.Columns[0].Visible = false;
       



        }

        public void CargarDetallesSalida(string nroDocumento)
        {
            try
            {
                N_Salida negocio = new N_Salida();
                DataSet ds = negocio.ObtenerSalidaConDetallesCompleto(nroDocumento);

                if (ds == null || ds.Tables.Count < 2)
                {
                    MessageBox.Show("No se encontraron datos para la salida seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Información principal de la salida
                DataTable salidaInfo = ds.Tables[0];
                if (salidaInfo.Rows.Count > 0)
                {
                    DataRow row = salidaInfo.Rows[0];
                    lblsalida.Text = row["NroDocumento"].ToString();

                    lblUsuarioCreacion.Text = row["UsuarioCreacion"]?.ToString() ?? "Sin usuario";
                    lblUsuarioEdicion.Text = row["UsuarioEdicion"]?.ToString() ?? "Sin usuario";
                    lblFechaHoraSys.Text = Convert.ToDateTime(row["FechaHoraSys"]).ToString("dd/MM/yyyy HH:mm:ss");
                }

                // Detalles de la salida
                DataTable detalles = ds.Tables[1];

                if (detalles.Rows.Count > 0)
                {
                    // Asignar datos a la tabla
                    TablaDetalle.DataSource = detalles;

                    // Configurar columnas
                    ConfigurarTablaDetalles();
                }
                else
                {
                    MessageBox.Show("No se encontraron detalles para la salida seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles de la salida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTablaDetalles()
        {
            // Deshabilitar la generación automática de columnas
            TablaDetalle.AutoGenerateColumns = false;
            TablaDetalle.Columns.Clear();

            // Configurar el estilo de fuente más pequeña
            Font smallFont = new Font("Arial", 10); // Cambia el tamaño de la fuente según tus necesidades
            TablaDetalle.DefaultCellStyle.Font = smallFont;
            // Deshabilitar la generación automática de columnas
            TablaDetalle.AutoGenerateColumns = false;
            TablaDetalle.Columns.Clear();

            // Configurar la columna "Código"
            DataGridViewColumn colCodigo = new DataGridViewTextBoxColumn
            {
                Name = "CodigoProducto",
                HeaderText = "Código",
                DataPropertyName = "CodigoProducto",
                Width = 160 // Ancho estándar
            };
            TablaDetalle.Columns.Add(colCodigo);

            // Configurar la columna "Descripción"
            DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn
            {
                Name = "DescripcionProducto",
                HeaderText = "Descripción",
                DataPropertyName = "DescripcionProducto",
                Width = 190, // Ancho superior
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft } // Alineación a la izquierda
            };
            TablaDetalle.Columns.Add(colDescripcion);

            // Configurar la columna "Lote"
            DataGridViewColumn colLote = new DataGridViewTextBoxColumn
            {
                Name = "Lote",
                HeaderText = "Lote",
                DataPropertyName = "Lote",
                Width = 80
            };
            TablaDetalle.Columns.Add(colLote);

            // Configurar la columna "Cantidad"
            DataGridViewColumn colCantidad = new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80
            };
            TablaDetalle.Columns.Add(colCantidad);

            // Configurar la columna "Precio Compra"
            DataGridViewColumn colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio Compra",
                DataPropertyName = "Precio",
                Width = 80
            };
            TablaDetalle.Columns.Add(colPrecio);

            // Configurar la columna "Precio Vendido"
            DataGridViewColumn colPrecioVendido = new DataGridViewTextBoxColumn
            {
                Name = "PrecioVendido",
                HeaderText = "Precio Vendido",
                DataPropertyName = "PrecioVendido",
                Width = 130
            };
            TablaDetalle.Columns.Add(colPrecioVendido);

            // Configurar la columna "Importe"
            DataGridViewColumn colImporte = new DataGridViewTextBoxColumn
            {
                Name = "Importe",
                HeaderText = "Importe",
                DataPropertyName = "Importe",
                Width = 80
            };
            TablaDetalle.Columns.Add(colImporte);

            // Configurar la columna "Comisión"
            DataGridViewColumn colComision = new DataGridViewTextBoxColumn
            {
                Name = "Comision",
                HeaderText = "Comisión",
                DataPropertyName = "Comision",
                Width = 80
            };
            TablaDetalle.Columns.Add(colComision);

            // Configurar la columna "Ganancia"
            DataGridViewColumn colGanancia = new DataGridViewTextBoxColumn
            {
                Name = "Ganancia",
                HeaderText = "Ganancia",
                DataPropertyName = "Ganancia",
                Width = 80
            };
            TablaDetalle.Columns.Add(colGanancia);

            // Configurar la columna "Observación"
            DataGridViewColumn colObservacion = new DataGridViewTextBoxColumn
            {
                Name = "Observacion",
                HeaderText = "Observación",
                DataPropertyName = "Observacion",
                Width = 210,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            };
            TablaDetalle.Columns.Add(colObservacion);

            // Asegurar que las columnas tengan un tamaño fijo
            TablaDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            TablaDetalle.AllowUserToResizeColumns = false;

            // Calcular los importes al asignar los datos
            CalcularImportes();

        }

        private void CalcularImportes()
        {
            if (TablaDetalle.DataSource is DataTable detalles)
            {
                // Agregar columna "Importe" si no existe
                if (!detalles.Columns.Contains("Importe"))
                {
                    detalles.Columns.Add("Importe", typeof(decimal));
                }

                decimal totalImporte = 0;
                decimal totalGanancia = 0;

                foreach (DataRow row in detalles.Rows)
                {
                    decimal precioVendido = Convert.ToDecimal(row["PrecioVendido"] ?? 0);
                    int cantidad = Convert.ToInt32(row["Cantidad"] ?? 0);
                    decimal importe = precioVendido * cantidad;
                    decimal ganancia = Convert.ToDecimal(row["Ganancia"] ?? 0); // Ya existe la columna "Ganancia"

                    row["Importe"] = importe; // Calcular importe
                    totalImporte += importe; // Sumar al total
                    totalGanancia += ganancia;

                }

                // Asignar el total al lbltotal
                lbltotal.Text = $"{totalImporte:F2}"; // Formato de 2 decimales
                lblganancia.Text = $"{totalGanancia:F2}"; // Total ganancia en formato de 2 decimales

            }
        }

        private void TablaDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void TablaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {

            
        }

        private void FrmVerDetalleSalida_Load(object sender, EventArgs e)
        {

        }

        private void btnexportar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!(TablaDetalle.DataSource is DataTable detalles) || detalles.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var workbook = new XLWorkbook())
                {
                    // Crear una hoja para los datos de la salida
                    var worksheet = workbook.Worksheets.Add("Reporte de Salidas");
                    worksheet.Cell(1, 1).Value = "Reporte de Salidas"; // Título
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                    // Insertar tabla en el Excel
                    worksheet.Cell(3, 1).InsertTable(detalles);

                    // Ajustar automáticamente el ancho de las columnas según su contenido
                    worksheet.Columns().AdjustToContents();

                    // Calcular el total de los importes
                    decimal totalImporte = detalles.AsEnumerable().Sum(row => row.Field<decimal>("Importe"));
                    // Calcular el total de la ganancia
                    decimal totalGanancia = detalles.AsEnumerable().Sum(row => row.Field<decimal>("Ganancia"));

                    // Añadir el total al final del reporte
                    int totalRow = detalles.Rows.Count + 5;
                    worksheet.Cell(totalRow, 1).Value = "TOTAL IMPORTE:";
                    worksheet.Cell(totalRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(totalRow, 2).Value = $"{totalImporte:F2}";
                    worksheet.Cell(totalRow, 2).Style.Font.Bold = true;

                    // Añadir el total de la ganancia al final del reporte
                    worksheet.Cell(totalRow + 1, 1).Value = "TOTAL GANANCIA:";
                    worksheet.Cell(totalRow + 1, 1).Style.Font.Bold = true;
                    worksheet.Cell(totalRow + 1, 2).Value = $"{totalGanancia:F2}";
                    worksheet.Cell(totalRow + 1, 2).Style.Font.Bold = true;

                    // Usar SaveFileDialog para que el usuario elija dónde guardar el archivo
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Guardar Reporte";
                        saveFileDialog.FileName = $"DetalleSalida_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}
