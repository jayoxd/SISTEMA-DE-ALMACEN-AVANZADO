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

        public partial class frmProductos : Form
        {
            N_Productoss objNegocio = new N_Productoss();
            private bool mostrandoActivos = true; // Indica si estamos mostrando productos activos
         N_Clientes indicadores = new N_Clientes();

        public frmProductos()
            {
                InitializeComponent();
            TablaPRODUCTOS.CellDoubleClick += TablaPRODUCTOS_CellDoubleClick;

            TablaPRODUCTOS.DataBindingComplete += TablaPRODUCTOS_DataBindingComplete;
                TablaPRODUCTOS.DefaultCellStyle.Font = new Font("Arial", 9); // Tamaño 10, fuente Arial
                TablaPRODUCTOS.DefaultCellStyle.Font = new Font("Arial", 9); // Tamaño 10, fuente Arial
                TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold); // Encabezados en negrita
            CargarIndicadores();
                MostrarProductosActivos(); // Carga inicial de productos activos

        }

        private void TablaPRODUCTOS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                // Configurar las columnas solo cuando las columnas están listas
                ConfigurarTablaProductos();
            }

        private void TablaPRODUCTOS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el índice de la fila sea válido
            if (e.RowIndex >= 0)
            {
                // Restaurar el color de todas las filas al color predeterminado
                foreach (DataGridViewRow row in TablaPRODUCTOS.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White; // Color predeterminado
                    row.DefaultCellStyle.ForeColor = Color.Gray; // Color del texto
                }

                // Cambiar el color de fondo de la fila seleccionada
                DataGridViewRow selectedRow = TablaPRODUCTOS.Rows[e.RowIndex];
                selectedRow.DefaultCellStyle.BackColor = Color.LightBlue; // Color de fondo para la selección
                selectedRow.DefaultCellStyle.ForeColor = Color.Gray;    // Color del texto
            }
        }


        private void CargarIndicadores()
        {

            try
            {
                lblUltimoProducto.Text =  objNegocio.ObtenerUltimoProductoRegistrado();
                lblProductosHabilitados.Text = objNegocio.ContarProductosHabilitados().ToString();
                lblProductosInhabilitados.Text =  objNegocio.ContarProductosInhabilitados().ToString();
                lblproducbajostock.Text = indicadores.ObtenerProductosBajoStock(10).ToString(); // Stock mínimo = 10

                MostrarProductoConMasSalidas();
                MostrarProductoConMasEntradas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la información de los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarProductoConMasSalidas()
        {
            DataTable dt = objNegocio.ObtenerProductoConMasSalidas();

            if (dt.Rows.Count > 0)
            {
                lblMasSalidas.Text = dt.Rows[0]["CodigoProducto"].ToString() +
                                     " (Cantidad: " + dt.Rows[0]["TotalCantidad"].ToString() + ")";
            }
            else
            {
                lblMasSalidas.Text = "No hay datos disponibles.";
            }
        }

        private void MostrarProductoConMasEntradas()
        {
            DataTable dt = objNegocio.ObtenerProductoConMasEntradas();

            if (dt.Rows.Count > 0)
            {
                lblMasEntradas.Text = dt.Rows[0]["CodigoProducto"].ToString() +
                                      " (Cantidad: " + dt.Rows[0]["TotalCantidad"].ToString() + ")";
            }
            else
            {
                lblMasEntradas.Text = "No hay datos disponibles.";
            }
        }


        private void TablaPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el índice de columna sea válido
            if (e.RowIndex >= 0)
            {
                // Verificar que la fila no esté vacía
                if (TablaPRODUCTOS.Rows[e.RowIndex].IsNewRow)
                {
                    return; // No hacer nada si la fila es una nueva fila
                }

                if (TablaPRODUCTOS.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    string codigoProducto = TablaPRODUCTOS.Rows[e.RowIndex].Cells["CodigoProducto"].Value.ToString();
                    bool estadoActual = Convert.ToBoolean(TablaPRODUCTOS.Rows[e.RowIndex].Cells["Estado"].Value);

                    string mensaje = estadoActual ? "¿Estás seguro de deshabilitar este producto?" : "¿Estás seguro de habilitar este producto?";
                    DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        objNegocio.CambiarEstadoProducto(codigoProducto, !estadoActual); // Cambia el estado
                        objNegocio.GenerarScriptOcultarProducto(codigoProducto, !estadoActual); // Genera el script SQL
                        MessageBox.Show(estadoActual ? "Producto deshabilitado exitosamente." : "Producto habilitado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Solo actualizar la tabla, no cambiar la vista
                        if (mostrandoActivos)
                        {
                            MostrarProductosActivos(); // Actualizar productos activos si estábamos en esa vista
                        }
                        else
                        {
                            MostrarProductosInactivos(); // Actualizar productos inactivos si estábamos en esa vista
                        }

                        CargarIndicadores();
                    }
                }
                else if (TablaPRODUCTOS.Columns[e.ColumnIndex].Name == "EDITAR")
                {
                    FrmAgregarProducto frm = new FrmAgregarProducto
                    {
                        Update = true
                    };
                    frm.txtCodigox.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["CodigoProducto"].Value.ToString();
                    frm.txtNombreProducto.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["DescripcionProducto"].Value.ToString();
                    frm.txtPrecio.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.ToString();
                    frm.txtStocP.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["StockActual"].Value.ToString();
                    // Asignación de los precios de venta
                    frm.txbbasico.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["BASICO"].Value.ToString();
                    frm.txbSaga.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Saga"].Value.ToString();
                    frm.txbagora.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Agora"].Value.ToString();
                    frm.txbRipley.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Ripley"].Value.ToString();
                    frm.txbMayorista3x5.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Mayorista_3_5"].Value.ToString();
                    frm.txbmayoristaxcaja.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Mayorista_X_Caja"].Value.ToString();
                    frm.txbPrecioAnt.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Precio_Inicial"].Value.ToString();
                    // Seleccionar el valor correspondiente en el combo box "estado"
                    bool estadoProducto = Convert.ToBoolean(TablaPRODUCTOS.Rows[e.RowIndex].Cells["Estado"].Value);
                    frm.cmbestado.SelectedItem = estadoProducto ? "Activo" : "Inactivo";

                    // Asignar la categoría si existe
                    string categoria = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                    frm.categoria.Text = categoria;

                    frm.ShowDialog();

                    // Después de editar, recargar la vista correcta (activos o inactivos)
                    if (mostrandoActivos)
                    {
                        MostrarProductosActivos();
                    }
                    else
                    {
                        MostrarProductosInactivos();
                    }

                    CargarIndicadores();
                }
            }
        }

            public void MostrarProductosActivos()
            {
            mostrandoActivos = true;
            var productosActivos = objNegocio.listandoProductos1(true);

            if (productosActivos != null && productosActivos.Rows.Count > 0)
            {
                TablaPRODUCTOS.DataSource = productosActivos;
            }
            else
            {
                TablaPRODUCTOS.DataSource = null;
                MessageBox.Show("No hay productos activos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lblEstadoProductos.Text = "Mostrando: Activos";
            CargarIndicadores();
        }



        public void MostrarProductosInactivos() 
            {
            mostrandoActivos = false;
            var productosInactivos = objNegocio.listandoProductos1(false);

            if (productosInactivos != null && productosInactivos.Rows.Count > 0)
            {
                TablaPRODUCTOS.DataSource = productosInactivos;
            }
            else
            {
                TablaPRODUCTOS.DataSource = null;
                MessageBox.Show("No hay productos inactivos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lblEstadoProductos.Text = "Mostrando: Inactivos";
            CargarIndicadores();

        }

        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
            {
                BuscarProducto(txbBuscarProducto.Text);
            }



        public void ConfigurarTablaProductos()
        {
            if (TablaPRODUCTOS.Columns.Count == 0) return;

            // Configuración de estilos para la cabecera
            TablaPRODUCTOS.EnableHeadersVisualStyles = false;
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11);

            // Configuración de las columnas con nombres y anchura
            if (TablaPRODUCTOS.Columns.Contains("CodigoProducto"))
            {
                TablaPRODUCTOS.Columns["CodigoProducto"].HeaderText = "Código del Producto";
                TablaPRODUCTOS.Columns["CodigoProducto"].Width = 150;
                TablaPRODUCTOS.Columns["CodigoProducto"].DisplayIndex = 0;
            }

            if (TablaPRODUCTOS.Columns.Contains("DescripcionProducto"))
            {
                TablaPRODUCTOS.Columns["DescripcionProducto"].HeaderText = "Descripción";
                TablaPRODUCTOS.Columns["DescripcionProducto"].Width = 300;
                TablaPRODUCTOS.Columns["DescripcionProducto"].DisplayIndex = 1;
            }

            if (TablaPRODUCTOS.Columns.Contains("StockActual"))
            {
                TablaPRODUCTOS.Columns["StockActual"].HeaderText = "Stock Actual";
                TablaPRODUCTOS.Columns["StockActual"].Width = 100;
                TablaPRODUCTOS.Columns["StockActual"].DisplayIndex = 2;
            }

            if (TablaPRODUCTOS.Columns.Contains("Precio_Inicial"))
            {
                TablaPRODUCTOS.Columns["Precio_Inicial"].HeaderText = "Precio Compra Anterior";
                TablaPRODUCTOS.Columns["Precio_Inicial"].Width = 100;
                TablaPRODUCTOS.Columns["Precio_Inicial"].DisplayIndex = 3;
            }

            if (TablaPRODUCTOS.Columns.Contains("PrecioUnitario"))
            {
                TablaPRODUCTOS.Columns["PrecioUnitario"].HeaderText = "Precio Compra Actual";
                TablaPRODUCTOS.Columns["PrecioUnitario"].Width = 100;
                TablaPRODUCTOS.Columns["PrecioUnitario"].DisplayIndex = 4;
            }

            if (TablaPRODUCTOS.Columns.Contains("BASICO"))
            {
                TablaPRODUCTOS.Columns["BASICO"].HeaderText = "Precio V. Básico";
                TablaPRODUCTOS.Columns["BASICO"].Width = 100;
                TablaPRODUCTOS.Columns["BASICO"].DisplayIndex = 5;
            }

            if (TablaPRODUCTOS.Columns.Contains("Saga"))
            {
                TablaPRODUCTOS.Columns["Saga"].HeaderText = "Precio V. Saga";
                TablaPRODUCTOS.Columns["Saga"].Width = 100;
                TablaPRODUCTOS.Columns["Saga"].DisplayIndex = 6;
            }

            if (TablaPRODUCTOS.Columns.Contains("Agora"))
            {
                TablaPRODUCTOS.Columns["Agora"].HeaderText = "Precio V. Ágora";
                TablaPRODUCTOS.Columns["Agora"].Width = 100;
                TablaPRODUCTOS.Columns["Agora"].DisplayIndex = 7;
            }

            if (TablaPRODUCTOS.Columns.Contains("Ripley"))
            {
                TablaPRODUCTOS.Columns["Ripley"].HeaderText = "Precio V. Ripley";
                TablaPRODUCTOS.Columns["Ripley"].Width = 100;
                TablaPRODUCTOS.Columns["Ripley"].DisplayIndex = 8;
            }

            if (TablaPRODUCTOS.Columns.Contains("Mayorista_3_5"))
            {
                TablaPRODUCTOS.Columns["Mayorista_3_5"].HeaderText = "Precio V. Mayorista 3x5";
                TablaPRODUCTOS.Columns["Mayorista_3_5"].Width = 100;
                TablaPRODUCTOS.Columns["Mayorista_3_5"].DisplayIndex = 9;
            }

            if (TablaPRODUCTOS.Columns.Contains("Mayorista_X_Caja"))
            {
                TablaPRODUCTOS.Columns["Mayorista_X_Caja"].HeaderText = "Precio V. Mayorista x Caja";
                TablaPRODUCTOS.Columns["Mayorista_X_Caja"].Width = 120;
                TablaPRODUCTOS.Columns["Mayorista_X_Caja"].DisplayIndex = 10;
            }

            if (TablaPRODUCTOS.Columns.Contains("Categoria"))
            {
                TablaPRODUCTOS.Columns["Categoria"].HeaderText = "Categoría";
                TablaPRODUCTOS.Columns["Categoria"].Width = 120;
                TablaPRODUCTOS.Columns["Categoria"].DisplayIndex = 11;
            }

            // Ocultar la columna "Estado" si existe
            if (TablaPRODUCTOS.Columns.Contains("Estado"))
            {
                TablaPRODUCTOS.Columns["Estado"].HeaderText = "Estado";
                TablaPRODUCTOS.Columns["Estado"].Visible = false; // Ocultar columna Estado
            }


            // Agregar columna de edición si no existe
            if (!TablaPRODUCTOS.Columns.Contains("EDITAR"))
            {
                DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn
                {
                    Name = "EDITAR",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                TablaPRODUCTOS.Columns.Add(editarColumna);
            }

            // Agregar columna de eliminación si no existe
            if (!TablaPRODUCTOS.Columns.Contains("ELIMINAR"))
            {
                DataGridViewButtonColumn eliminarColumna = new DataGridViewButtonColumn
                {
                    Name = "ELIMINAR",
                    HeaderText = mostrandoActivos ? "Ocultar" : "Desocultar", // Cambia el encabezado dinámicamente
                    Text = mostrandoActivos ? "Ocultar" : "Desocultar", // Cambia el texto dinámicamente
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                TablaPRODUCTOS.Columns.Add(eliminarColumna);
            }
            else
            {
                // Si la columna ya existe, solo actualiza el encabezado
                TablaPRODUCTOS.Columns["ELIMINAR"].HeaderText = mostrandoActivos ? "Ocultar" : "Desocultar";
                TablaPRODUCTOS.Columns["ELIMINAR"].DefaultCellStyle.NullValue = mostrandoActivos ? "Ocultar" : "Desocultar";
            }

            // Ajustar posición de las columnas de botones
            if (TablaPRODUCTOS.Columns.Contains("EDITAR"))
                TablaPRODUCTOS.Columns["EDITAR"].DisplayIndex = TablaPRODUCTOS.Columns.Count - 2;

            if (TablaPRODUCTOS.Columns.Contains("ELIMINAR"))
                TablaPRODUCTOS.Columns["ELIMINAR"].DisplayIndex = TablaPRODUCTOS.Columns.Count - 1;
        }




        public void BuscarProducto(string valor)
            {
                TablaPRODUCTOS.DataSource = objNegocio.BuscarProductoPorCodigoODescripcion(valor, mostrandoActivos);
            }

            private void Btnoinhabilitados_Click(object sender, EventArgs e)
            {
                if (mostrandoActivos)
                {
                    MostrarProductosInactivos();
                }
                else
                {
                    MostrarProductosActivos();
                }
            }

            private void btnAgregarProducto_Click(object sender, EventArgs e)
            {
                FrmAgregarProducto frm = new FrmAgregarProducto
                {
                    Update = false
                };
                frm.ShowDialog();
                MostrarProductosActivos();
            }

       

            private void panel9_Paint(object sender, PaintEventArgs e)
            {
            }
            private void bunifuThinButton24_Click(object sender, EventArgs e)
            {
                // Crear una instancia del formulario FrmAgregarProducto
                FrmAgregarProducto frm = new FrmAgregarProducto
                {
                    Update = false // Indica que es para agregar un nuevo producto
                };

                // Mostrar el formulario
                frm.ShowDialog();

                // Actualizar la lista de productos activos después de agregar un producto
                MostrarProductosActivos();
            CargarIndicadores();
            }

            private void Btnoinahbilitados_Click(object sender, EventArgs e)
            {
                if (mostrandoActivos)
                {
                    MostrarProductosInactivos(); // Cambiar a mostrar productos inhabilitados
                    Btnoinahbilitados.ButtonText = "MOSTRAR PRODUCTOS HABILITADOS"; // Cambiar texto del botón
                }
                else
                {
                    MostrarProductosActivos(); // Cambiar a mostrar productos activos
                    Btnoinahbilitados.ButtonText = "MOSTRAR PRODUCTOS INHABILITADOS"; // Cambiar texto del botón
                }
            }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblEstadoProductos_Click(object sender, EventArgs e)
        {

        }

        private void ExportarExcelClosedXML(DataGridView dataGridView, string rutaArchivo)
        {
            // Crear un libro de Excel
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                // Crear una hoja
                var worksheet = workbook.Worksheets.Add("Productos");

                // Eliminar las columnas "EDITAR" y "ELIMINAR" si existen
                List<string> columnasExcluidas = new List<string> { "EDITAR", "ELIMINAR" };
                List<int> columnasAExcluir = new List<int>();

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (columnasExcluidas.Contains(dataGridView.Columns[i].Name))
                    {
                        columnasAExcluir.Add(i);
                    }
                }

                // Escribir encabezados (excluyendo columnas no deseadas)
                int columnaExcel = 1;
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (!columnasAExcluir.Contains(i))
                    {
                        worksheet.Cell(1, columnaExcel).Value = dataGridView.Columns[i].HeaderText;
                        columnaExcel++;
                    }
                }

                // Escribir datos (excluyendo columnas no deseadas)
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    columnaExcel = 1;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (!columnasAExcluir.Contains(j))
                        {
                            worksheet.Cell(i + 2, columnaExcel).Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                            columnaExcel++;
                        }
                    }
                }

                // Aplicar estilo
                var range = worksheet.RangeUsed();
                range.Style.Font.FontName = "Arial";
                range.Style.Font.FontSize = 11;
                range.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                range.Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;
                range.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                range.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;

                // Ajustar columnas automáticamente
                worksheet.Columns().AdjustToContents();

                // Guardar el archivo en la ubicación seleccionada por el usuario
                workbook.SaveAs(rutaArchivo);
            }
        }


        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TablaPRODUCTOS.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determinar el estado actual (activos o inactivos)
                string estado = mostrandoActivos ? "Activos" : "Inactivos";

                // Permitir al usuario elegir dónde guardar el archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = $"Report_Prod_{estado}_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Llamar al método para exportar y pasar la ruta seleccionada
                        ExportarExcelClosedXML(TablaPRODUCTOS, saveFileDialog.FileName);
                        MessageBox.Show($"Reporte generado exitosamente: {saveFileDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
