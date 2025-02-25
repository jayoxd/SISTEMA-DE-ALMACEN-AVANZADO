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
    public partial class FrmVerDetalleEntrada : Form
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

        public FrmVerDetalleEntrada()
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

        public void CargarDetallesEntrada(string nroDocumento)
        {
            try
            {
                N_Entrada negocio = new N_Entrada();
                DataSet ds = negocio.ObtenerEntradaConDetallesCompleto(nroDocumento);

                if (ds == null || ds.Tables.Count < 2)
                {
                    MessageBox.Show("No se encontraron datos para la entrada seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Información principal de la entrada
                DataTable entradaInfo = ds.Tables[0];
                if (entradaInfo.Rows.Count > 0)
                {
                    DataRow row = entradaInfo.Rows[0];
                    lblNroDocumento.Text = row["NroDocumento"].ToString();
                    lblUsuarioCreacion.Text = row["UsuarioCreacion"]?.ToString() ?? "Sin usuario";
                    lblUsuarioEdicion.Text = row["UsuarioEdicion"]?.ToString() ?? "Sin usuario";
                    lblFechaHoraSys.Text = Convert.ToDateTime(row["FechaHoraSys"]).ToString("dd/MM/yyyy HH:mm:ss");
                }

                // Detalles de la entrada
                DataTable detalles = ds.Tables[1];

                // Añadir columna "Importe" al DataTable de detalles
                if (!detalles.Columns.Contains("Importe"))
                {
                    detalles.Columns.Add("Importe", typeof(decimal));

                    foreach (DataRow row in detalles.Rows)
                    {
                        decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                        decimal precio = Convert.ToDecimal(row["PrecioCompra"]);
                        row["Importe"] = cantidad * precio; // Calcular el importe
                    }
                }

                // Asignar datos a la tabla y configurar columnas
                TablaDetalle.DataSource = detalles;
                ConfigurarTablaDetalles(); // Reordenar y ocultar columnas

                // Calcular el total de los importes
                decimal totalImporte = detalles.AsEnumerable().Sum(row => row.Field<decimal>("Importe"));
                lbltotal.Text = totalImporte.ToString("F2"); // Mostrar el total en el label con formato
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles de la entrada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarTablaDetalles()
        {// Detener la generación automática de columnas
            TablaDetalle.AutoGenerateColumns = false;
            TablaDetalle.Columns.Clear();

            // Configurar la columna "Código"
            DataGridViewColumn colCodigo = new DataGridViewTextBoxColumn
            {
                Name = "CodigoProducto",
                HeaderText = "Código",
                DataPropertyName = "CodigoProducto",
                Width = 190 // Ancho estándar
            };
            TablaDetalle.Columns.Add(colCodigo);

            // Configurar la columna "Descripción"
            DataGridViewColumn colDescripcion = new DataGridViewTextBoxColumn
            {
                Name = "DescripcionProducto",
                HeaderText = "Descripción",
                DataPropertyName = "DescripcionProducto",
                Width = 210, // Doble del ancho de CódigoProducto
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft } // Alineación a la izquierda
            };
            TablaDetalle.Columns.Add(colDescripcion);

            // Configurar las demás columnas
            DataGridViewColumn colLote = new DataGridViewTextBoxColumn
            {
                Name = "Lote",
                HeaderText = "Lote",
                DataPropertyName = "Lote",
                Width = 100
            };
            TablaDetalle.Columns.Add(colLote);

            DataGridViewColumn colCantidad = new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 100
            };
            TablaDetalle.Columns.Add(colCantidad);

            DataGridViewColumn colPrecio = new DataGridViewTextBoxColumn
            {
                Name = "PrecioCompra",
                HeaderText = "Precio",
                DataPropertyName = "PrecioCompra",
                Width = 100
            };
            TablaDetalle.Columns.Add(colPrecio);

            DataGridViewColumn colImporte = new DataGridViewTextBoxColumn
            {
                Name = "Importe",
                HeaderText = "Importe",
                DataPropertyName = "Importe",
                Width = 100
            };
            TablaDetalle.Columns.Add(colImporte);

            DataGridViewColumn colObservacion = new DataGridViewTextBoxColumn
            {
                Name = "Observacion",
                HeaderText = "Observación",
                DataPropertyName = "Observacion",
                Width = 250,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            };
            TablaDetalle.Columns.Add(colObservacion);

            // Configurar opciones generales de la tabla
            TablaDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Columnas de tamaño fijo
            TablaDetalle.AllowUserToResizeColumns = false; // Deshabilitar redimensionado de columnas
        }




        private void txtvehiculos_TextChanged(object sender, EventArgs e)
        {

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

        private void btnexportar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo libro de Excel
                using (var workbook = new XLWorkbook())
                {
                    // Crear una hoja
                    var worksheet = workbook.Worksheets.Add("Detalle Entrada");

                    // Agregar encabezados
                    for (int i = 0; i < TablaDetalle.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = TablaDetalle.Columns[i].HeaderText;
                    }

                    // Llenar datos de la tabla
                    for (int i = 0; i < TablaDetalle.Rows.Count; i++)
                    {
                        for (int j = 0; j < TablaDetalle.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = TablaDetalle.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Agregar el total del importe al final
                    int totalRow = TablaDetalle.Rows.Count + 2; // Fila donde se colocará el total
                    worksheet.Cell(totalRow, TablaDetalle.Columns.Count - 1).Value = "Total:";
                    worksheet.Cell(totalRow, TablaDetalle.Columns.Count).Value = lbltotal.Text;
                    worksheet.Cell(totalRow, TablaDetalle.Columns.Count).Style.Font.Bold = true;

                    // Ajustar el ancho de las columnas
                    worksheet.Columns().AdjustToContents();

                    // Guardar el archivo en una ubicación elegida por el usuario
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Guardar Detalle en Excel";
                        saveFileDialog.FileName = $"DetalleEntrada_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Datos exportados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Abrir el archivo Excel automáticamente
                            System.Diagnostics.Process.Start(saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}
