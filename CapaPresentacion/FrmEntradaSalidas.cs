using CapaNegocio;
using ClosedXML.Excel;
using iText.IO.Font;
using iText.IO.Font.Constants; //excepta esta
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Color = System.Drawing.Color;


namespace CapaPresentacion
{

    public partial class FrmEntradaSalida : Form
    {
        N_Productoss objNegocio = new N_Productoss();
        N_Clientes indicadores = new N_Clientes();
        private bool esEntrada = true; // Control para alternar entre Entrada y Salida
        N_Entrada Entrada = new N_Entrada();
        N_Salida Salida = new N_Salida();
        N_Proveedores proveedores = new N_Proveedores();

        public FrmEntradaSalida()
        {
            InitializeComponent();
            var fontBold = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            var fontRegular = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

            CargarIndicadores();
            ConfigurarTabla();

            CargarEntradas(); // Cargar por defecto las entradas al iniciar el formulario

            TablaPRODUCTOS.CellDoubleClick += TablaPRODUCTOS_CellDoubleClick;
            TablaPRODUCTOS.CellFormatting += TablaPRODUCTOS_CellFormatting;

        }





        private void TablaPRODUCTOS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic sea en una fila válida
            if (e.RowIndex >= 0 && TablaPRODUCTOS.Rows.Count > 0)
            {
                try
                {
                    // Obtén el NroDocumento de la fila seleccionada
                    string nroDocumento = TablaPRODUCTOS.Rows[e.RowIndex].Cells["NroDocumento"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(nroDocumento))
                    {
                        MessageBox.Show("El número de documento seleccionado es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (esEntrada)

                    {
                        if (!TablaPRODUCTOS.Columns.Contains("ProveedorID"))
                        {
                            TablaPRODUCTOS.Columns.Add("ProveedorID", "Proveedor ID");
                            TablaPRODUCTOS.Columns["ProveedorID"].DataPropertyName = "ProveedorID";
                            TablaPRODUCTOS.Columns["ProveedorID"].Visible = false; // Si no quieres mostrarla
                        }
                        // Si estamos en Entradas, abre el formulario FrmVerDetalleEntrada
                        FrmVerDetalleEntrada frmEntrada = new FrmVerDetalleEntrada();
                        frmEntrada.CargarDetallesEntrada(nroDocumento); // Envía el NroDocumento
                        frmEntrada.ShowDialog();
                    }
                    else
                    {
                        if (!TablaPRODUCTOS.Columns.Contains("ClienteID"))
                        {
                            TablaPRODUCTOS.Columns.Add("ClienteID", "Cliente ID");
                            TablaPRODUCTOS.Columns["ClienteID"].DataPropertyName = "ClienteID";
                            TablaPRODUCTOS.Columns["ClienteID"].Visible = false; // Si no quieres mostrarla
                        }
                        // Si estamos en Salidas, abre el formulario FrmVerDetalleSalida
                        FrmVerDetalleSalida frmSalida = new FrmVerDetalleSalida();
                        frmSalida.CargarDetallesSalida(nroDocumento); // Envía el NroDocumento
                        frmSalida.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el formulario de detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void ConfigurarTabla()
        {
            TablaPRODUCTOS.AutoGenerateColumns = false;
            TablaPRODUCTOS.Columns.Clear();
            TablaPRODUCTOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Registrar el evento CellFormatting
            TablaPRODUCTOS.CellFormatting += TablaPRODUCTOS_CellFormatting;

            // Configuración de estilos para la cabecera
            TablaPRODUCTOS.EnableHeadersVisualStyles = false;
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(64, 64, 64); // Gris oscuro
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; // Texto blanco

            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11); // Fuente

            // Configuración de las columnas
            TablaPRODUCTOS.Columns.Add("NroDocumento", "Nro Documento");
            TablaPRODUCTOS.Columns["NroDocumento"].DataPropertyName = "NroDocumento";

            TablaPRODUCTOS.Columns.Add("EntidadNombre", esEntrada ? "Proveedor" : "Cliente");
            TablaPRODUCTOS.Columns["EntidadNombre"].DataPropertyName = esEntrada ? "ProveedorNombre" : "ClienteNombre";

            if (!esEntrada) // Configuración exclusiva para salidas
            {
                if (!TablaPRODUCTOS.Columns.Contains("ProveedorID"))
                {
                    var col = new DataGridViewTextBoxColumn
                    {
                        Name = "ClienteID",
                        DataPropertyName = "ClienteID",
                        Visible = false // Hazla invisible si no quieres mostrarla
                    };
                    TablaPRODUCTOS.Columns.Add(col);
                }
                TablaPRODUCTOS.Columns.Add("DNI", "DNI");
                TablaPRODUCTOS.Columns["DNI"].DataPropertyName = "DNI";

                TablaPRODUCTOS.Columns.Add("Ubigeo", "Ubigeo");
                TablaPRODUCTOS.Columns["Ubigeo"].DataPropertyName = "Ubigeo";

                TablaPRODUCTOS.Columns.Add("Medio", "Medio");
                TablaPRODUCTOS.Columns["Medio"].DataPropertyName = "Medio";

                // Agregar columnas adicionales para salidas
                TablaPRODUCTOS.Columns.Add("Codigo_Pedido", "Código de Pedido");
                TablaPRODUCTOS.Columns["Codigo_Pedido"].DataPropertyName = "Codigo_Pedido";

                TablaPRODUCTOS.Columns.Add("Transporte", "Transporte");
                TablaPRODUCTOS.Columns["Transporte"].DataPropertyName = "Transporte";

                TablaPRODUCTOS.Columns.Add("FechaDespacho", "Fecha Despacho");
                TablaPRODUCTOS.Columns["FechaDespacho"].DataPropertyName = "FechaDespacho";
                TablaPRODUCTOS.Columns["FechaDespacho"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Agregar la columna "Observación" solo en salidas
                var colObservacion = new DataGridViewTextBoxColumn
                {
                    Name = "Observacion",
                    HeaderText = "Observación",
                    DataPropertyName = "Observacion",
                    Width = 200 // Puedes ajustar el ancho según tus necesidades
                };
                TablaPRODUCTOS.Columns.Add(colObservacion);
            }
            else // Configuración exclusiva para entradas
            {
                TablaPRODUCTOS.Columns.Add("RUC", "RUC");
                TablaPRODUCTOS.Columns["RUC"].DataPropertyName = "RUC";


                TablaPRODUCTOS.Columns.Add("TipoCambio", "TipoCambio");
                TablaPRODUCTOS.Columns["TipoCambio"].DataPropertyName = "TipoCambio";
            }
            if (!TablaPRODUCTOS.Columns.Contains("ProveedorID"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "ProveedorID",
                    DataPropertyName = "ProveedorID",
                    Visible = false // Hazla invisible si no quieres mostrarla
                };
                TablaPRODUCTOS.Columns.Add(col);
            }
            // Columnas comunes a entradas y salidas
            TablaPRODUCTOS.Columns.Add("Tipo_Comprobante", "Tipo Comprobante");
            TablaPRODUCTOS.Columns["Tipo_Comprobante"].DataPropertyName = "Tipo_Comprobante";

            TablaPRODUCTOS.Columns.Add("Nro_Comprobante", "Nro Comprobante");
            TablaPRODUCTOS.Columns["Nro_Comprobante"].DataPropertyName = "Nro_Comprobante";

            TablaPRODUCTOS.Columns.Add("Fecha", "Fecha");
            TablaPRODUCTOS.Columns["Fecha"].DataPropertyName = "Fecha";
            TablaPRODUCTOS.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";


            // Agregar la nueva columna FechaHoraSys
            TablaPRODUCTOS.Columns.Add("FechaHoraSys", "Fecha y Hora Sistema");
            TablaPRODUCTOS.Columns["FechaHoraSys"].DataPropertyName = "FechaHoraSys";
            TablaPRODUCTOS.Columns["FechaHoraSys"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; // Formato de fecha y hora

            // Configuración adicional de las columnas
            foreach (DataGridViewColumn column in TablaPRODUCTOS.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Arial", 10); // Fuente de las celdas
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar contenido
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar encabezado
            }

            // Configuración de fila seleccionada
            // Configuración de fila seleccionada
            TablaPRODUCTOS.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue; // Fondo azul claro
            TablaPRODUCTOS.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black; // Texto negro


            // Configuración de la tabla
            TablaPRODUCTOS.RowTemplate.Height = 30; // Altura de las filas
            TablaPRODUCTOS.ReadOnly = true; // Hacer la tabla de solo lectura
            TablaPRODUCTOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección completa por fila
            TablaPRODUCTOS.MultiSelect = false; // Evitar selección múltiple
        }


        private void CargarEntradas()
        {

            try
            {
                DataTable dt = Entrada.ObtenerEntradasPorFechas(null, null, null);

                if (!dt.Columns.Contains("ProveedorID"))
                {
                    dt.Columns.Add("ProveedorID", typeof(int)); // Añade la columna si no existe

                    // Opcional: Asigna valores de ejemplo si el proveedorID no está presente en los datos
                    foreach (DataRow row in dt.Rows)
                    {
                        row["ProveedorID"] = 3; // Valor de prueba (puedes cambiarlo)
                    }
                }

                TablaPRODUCTOS.DataSource = dt;
                ConfigurarColumnas();

                // Forzar el refresco para aplicar el CellFormatting
                TablaPRODUCTOS.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entradas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CargarSalidas()
        {
            try
            {
                DataTable dt = Salida.ObtenerSalidasPorFechas(null, null, null);
                GenerarColumnaUbigeo(dt);
                TablaPRODUCTOS.DataSource = dt;
                ConfigurarColumnas();

                // Forzar el refresco para aplicar el CellFormatting
                TablaPRODUCTOS.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salidas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void panel9_Paint(object sender, PaintEventArgs e)
        {
       
        }





        private void TablaPRODUCTOS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica que el índice de la fila es válido
            if (e.RowIndex < 0 || e.RowIndex >= TablaPRODUCTOS.Rows.Count)
                return;

            // Obtén la fila actual
            var fila = TablaPRODUCTOS.Rows[e.RowIndex];

            // Cambia el color de la letra en función del ProveedorID o ClienteID
            if (esEntrada && TablaPRODUCTOS.Columns.Contains("ProveedorID"))
            {
                if (int.TryParse(fila.Cells["ProveedorID"].Value?.ToString(), out int proveedorID))
                {
                    if (proveedorID == 3)
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Blue; // Letra azul para ProveedorID 3
                    }
                    else if (proveedorID == 7)
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Red; // Letra roja para ProveedorID 7
                    }
                    else
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Gray; // Color por defecto (gris)
                    }
                }
                else
                {
                    fila.DefaultCellStyle.ForeColor = Color.Gray; // Color por defecto si no es un número válido
                }
            }
            else if (!esEntrada && TablaPRODUCTOS.Columns.Contains("ClienteID"))
            {
                if (int.TryParse(fila.Cells["ClienteID"].Value?.ToString(), out int clienteID))
                {
                    if (clienteID == 6)
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Blue; // Letra azul para ClienteID 6
                    }
                    else if (clienteID == 7)
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Red; // Letra roja para ClienteID 7
                    }
                    else
                    {
                        fila.DefaultCellStyle.ForeColor = Color.Gray; // Color por defecto (gris)
                    }
                }
                else
                {
                    fila.DefaultCellStyle.ForeColor = Color.Gray; // Color por defecto si no es un número válido
                }
            }
            else
            {
                // Color por defecto si no aplica ninguna condición
                fila.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }





        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string valor = txbBuscarProducto.Text.Trim();
                DateTime? fechaInicio = dtpFechaInicio.Value;
                DateTime? fechaFin = dtpFechaFin.Value;

                DataTable dt;
                if (esEntrada)
                {
                    dt = Entrada.ObtenerEntradasPorFechas(valor, fechaInicio, fechaFin);
                }
                else
                {
                    dt = Salida.ObtenerSalidasPorFechas(valor, fechaInicio, fechaFin);
                    GenerarColumnaUbigeo(dt);
                }

                TablaPRODUCTOS.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar con fechas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lbltotaldeldia_Click(object sender, EventArgs e)
        {

        }


        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string valor = txbBuscarProducto.Text.Trim();

                DataTable dt;
                if (esEntrada)
                {
                    dt = Entrada.ObtenerEntradasPorFechas(valor, null, null);
                }
                else
                {
                    dt = Salida.ObtenerSalidasPorFechas(valor, null, null);
                    GenerarColumnaUbigeo(dt);
                }

                TablaPRODUCTOS.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarColumnaUbigeo(DataTable dt)
        {
            if (!dt.Columns.Contains("Ubigeo"))
            {
                dt.Columns.Add("Ubigeo", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    string departamento = row["Departamento"]?.ToString() ?? string.Empty;
                    string distrito = row["Distrito"]?.ToString() ?? string.Empty;
                    string provincia = row["Provincia"]?.ToString() ?? string.Empty;

                    row["Ubigeo"] = $"{departamento}/{provincia}/{distrito}";
                }
            }
        }


        private void btnSalidaEntrada_Click(object sender, EventArgs e)
        {
            esEntrada = !esEntrada; // Alternar entre entradas y salidas
            ConfigurarTabla();

            if (esEntrada)
            {
                CargarEntradas();
                btnSalidaEntrada.ButtonText = "MOSTRAR SALIDAS"; // Cambiar texto del botón
            }
            else
            {
                CargarSalidas();
                btnSalidaEntrada.ButtonText = "MOSTRAR ENTRADAS"; // Cambiar texto del botón
            }
        }

        private void ConfigurarColumnas()
        {
            if (TablaPRODUCTOS.Columns["EntidadNombre"] != null)
            {
                TablaPRODUCTOS.Columns["EntidadNombre"].HeaderText = esEntrada ? "Proveedor" : "Cliente";
                TablaPRODUCTOS.Columns["EntidadNombre"].DataPropertyName = esEntrada ? "ProveedorNombre" : "ClienteNombre";
            }

        }


        private void btnExportarPDF_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = TablaPRODUCTOS.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{(esEntrada ? "Entradas" : "Salidas")}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (var writer = new PdfWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
                {
                    var pdfDoc = new PdfDocument(writer);
                    var document = new Document(pdfDoc, PageSize.A4.Rotate());
                    document.SetMargins(20, 20, 20, 20);

                    PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD, PdfEncodings.WINANSI);
                    PdfFont fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.WINANSI);

                    var titulo = new Paragraph($"Reporte de {(esEntrada ? "Entradas" : "Salidas")}")
                        .SetFont(fontBold)
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER);
                    document.Add(titulo);

                    document.Add(new Paragraph("\n"));

                    var table = new Table(UnitValue.CreatePercentArray(dt.Columns.Count)).UseAllAvailableWidth();

                    foreach (DataColumn col in dt.Columns)
                    {
                        table.AddHeaderCell(new Cell()
                            .Add(new Paragraph(col.ColumnName).SetFont(fontBold).SetBackgroundColor(ColorConstants.LIGHT_GRAY))
                            .SetTextAlignment(TextAlignment.CENTER));
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(new Cell()
                                .Add(new Paragraph(item?.ToString() ?? "").SetFont(fontRegular))
                                .SetTextAlignment(TextAlignment.CENTER));
                        }
                    }

                    document.Add(table);
                    document.Close();
                }

                MessageBox.Show($"Reporte exportado exitosamente: {path}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error de archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}\nStackTrace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = TablaPRODUCTOS.DataSource as DataTable;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una copia del DataTable sin las columnas 'ClienteID' y 'ProveedorID'
                DataTable dtFiltered = dt.Copy();
                if (dtFiltered.Columns.Contains("ClienteID"))
                    dtFiltered.Columns.Remove("ClienteID");
                if (dtFiltered.Columns.Contains("ProveedorID"))
                    dtFiltered.Columns.Remove("ProveedorID");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(esEntrada ? "Entradas" : "Salidas");
                    worksheet.Cell(1, 1).Value = esEntrada ? "Reporte de Entradas" : "Reporte de Salidas";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 14;

                    // Insertar la tabla y ajustar automáticamente
                    worksheet.Cell(3, 1).InsertTable(dtFiltered);

                    // Ajustar automáticamente el ancho de las columnas según el contenido y encabezados
                    worksheet.ColumnsUsed().AdjustToContents(); // Asegura que tanto celdas como encabezados se ajusten


                    // Ajustar manualmente la columna 'Fecha' para un poco más de espacio
                    var fechaColumn = worksheet.Column(dtFiltered.Columns["Fecha"].Ordinal + 1); // Obtiene el índice de la columna 'Fecha'
                    fechaColumn.Width += 10; // Añade 3 unidades al ancho actual

                    // Colorea filas según condiciones (opcional)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var proveedorOClienteID = esEntrada
                            ? dt.Rows[i]["ProveedorID"]?.ToString()
                            : dt.Rows[i]["ClienteID"]?.ToString();

                        if (esEntrada && proveedorOClienteID == "3")
                        {
                            worksheet.Row(i + 4).Style.Font.FontColor = XLColor.Blue; // Ajusta el índice
                        }
                        else if (esEntrada && proveedorOClienteID == "7")
                        {
                            worksheet.Row(i + 4).Style.Font.FontColor = XLColor.Red;
                        }
                        else if (!esEntrada && proveedorOClienteID == "6")
                        {
                            worksheet.Row(i + 4).Style.Font.FontColor = XLColor.Blue;
                        }
                        else if (!esEntrada && proveedorOClienteID == "7")
                        {
                            worksheet.Row(i + 4).Style.Font.FontColor = XLColor.Red;
                        }
                    }

                    // Usar SaveFileDialog para que el usuario elija dónde guardar el archivo
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Guardar Reporte";
                        saveFileDialog.FileName = $"{(esEntrada ? "ReporteEntradas" : "ReporteSalidas")}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Cambiar el tamaño del panel a un ancho de 800 y una altura de 600
            panel9.Width = 1230;
            panel9.Height = 600;
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha seleccionado una fila válida
                if (TablaPRODUCTOS.SelectedRows.Count > 0)
                {
                    // Obtén el NroDocumento de la fila seleccionada
                    string nroDocumento = TablaPRODUCTOS.SelectedRows[0].Cells["NroDocumento"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(nroDocumento))
                    {
                        MessageBox.Show("El número de documento seleccionado es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Abre el cuadro de diálogo para seleccionar la ubicación del archivo PDF
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos PDF|*.pdf";
                    saveFileDialog.FileName = $"comprobante_{nroDocumento}.pdf"; // Nombre predeterminado del archivo
                    saveFileDialog.Title = esEntrada ? "Guardar Comprobante de Entrada" : "Guardar Comprobante de Salida"; // Cambiar título dependiendo de la entrada o salida

                    // Si el usuario selecciona una ubicación y hace clic en "Guardar"
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Ruta seleccionada por el usuario
                        string rutaArchivo = saveFileDialog.FileName;

                        // Verifica si es una entrada o salida y llama al generador adecuado
                        if (esEntrada)
                        {
                            // Llama al método para generar el comprobante de entrada en PDF
                            PDFGenerator pdfGenerator = new PDFGenerator();
                            pdfGenerator.GenerarComprobanteEntrada(nroDocumento, rutaArchivo); // Pasa el NroDocumento y la ruta seleccionada
                        }
                        else
                        {
                            // Llama al método para generar el comprobante de salida en PDF
                            PDFGenerator2 pdfGenerator2 = new PDFGenerator2();
                            pdfGenerator2.GenerarComprobanteSalida(nroDocumento, rutaArchivo); // Pasa el NroDocumento y la ruta seleccionada
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un registro en la tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el comprobante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncargarscript_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmCargarScript
            CargarScript formularioScript = new CargarScript();

            // Mostrar el formulario para cargar y ejecutar el script
            formularioScript.ShowDialog();
        }
    }

}
