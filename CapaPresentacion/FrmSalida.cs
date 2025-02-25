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
using System.Security.Cryptography;

namespace CapaPresentacion
{
    public partial class FrmSalida : Form
    {
        private DataTable DtDetalle = new DataTable();

        N_Salida objNegocio = new N_Salida();
        N_Productoss objProductos = new N_Productoss();
        N_Entrada objServicio = new N_Entrada();
        N_Salida objeto = new N_Salida();
        N_Clientes clienen = new N_Clientes();

        public int cam = 0;
        private string tipoComprobanteSeleccionado = ""; // Variable para almacenar el tipo de comprobante seleccionado
        public int Idusuario { get; set; } // Recibe el Idusuario desde FrmPrincipal


        public FrmSalida()
        {
            ;
            InitializeComponent();
            InicializarComboBoxTipoComprobante();

            //  lblclient.Text = F_Variables.nombre_empleado;
            dgvDetalle.CellEndEdit += dgvDetalle_CellEndEdit; // Evento para validar edición
            dgvDetalle.CellValidating += dgvDetalle_CellValidating; // Evento para validar datos
            DepurarComboBoxMedio();
            // Inicializar ComboBox de Tipo Comprobante
            // Asociar el evento UserDeletingRow
            dgvDetalle.UserDeletingRow += dataGridViewDetalle_UserDeletingRow;
            ConfigurarDateTimePickerFechaDespacho();



            // Configurar el campo de tipo de venta
            tipoventa.Text = "Venta Interna"; // Valor inicial predeterminado
            tipoventa.ReadOnly = true; // Hacer que el campo sea de solo lectura

            CargarIndicadores();
            ConfigurarTextBox();
            InicializarComboBoxMedio();

            dgvDetalle.DataError += dgvDetalle_DataError; // Asocia el evento de error
            crear_tabla();
            ConfigurarFuenteTabla(); // Aumentar el tamaño de la fuente en la tabla
            acciones_tabla();
            AsociarEventoTipoComprobante(); // Asociar evento para capturar el valor seleccionado
            cmbTipCompr.Font = new Font("Arial", 12, FontStyle.Regular); // Cambia "Arial" y 14 según tus preferencias
            cmb_medio.Font = new Font("Arial", 12, FontStyle.Regular); // Cambia "Arial" y 14 según tus preferencias
            txbBuscarCliente.Text = "BUSCAR POR CÓDIGO DE PRODUCTO";
            txbBuscarCliente.ForeColor = Color.Gray;
            // Asociar eventos de validación
            txbNumCom.KeyPress += txbNumCom_KeyPress;

            // Asocia los eventos
            txbBuscarCliente.Enter += txbBuscarCliente_Enter;
            txbBuscarCliente.Leave += txbBuscarCliente_Leave;
            var DateAndTime = DateTime.Now;
            var Date = DateAndTime.Date.ToString("dd-MM-yyyy");
            txbFecha.Text = Date.ToString();
            Button invisibleButton = new Button();
            invisibleButton.Size = new Size(1650, 850); // Tamaño grande para forzar el scroll
            invisibleButton.FlatStyle = FlatStyle.Flat;
            invisibleButton.FlatAppearance.BorderSize = 0;
            invisibleButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            invisibleButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            invisibleButton.BackColor = Color.Transparent;
            invisibleButton.Enabled = false; // Deshabilitar el botón


            // Agregar el botón al panel
            panel9.Controls.Add(invisibleButton);

            // Configurar el Panel
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.AutoScroll = true;

            panel9.Size = new Size(1650, 850); // Tamaño del Panel más pequeño


        }
        



        private void DepurarComboBoxMedio()
        {
            if (cmb_medio.DataSource is DataTable dt)
            {
                Console.WriteLine("Datos disponibles en el ComboBox (cmb_medio):");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"ID: {row["IDtipoventa"]}, Descripción: {row["Descripcion"]}");
                }
            }
            else
            {
                Console.WriteLine("El ComboBox (cmb_medio) no tiene una fuente de datos asignada.");
            }
        }


        private void Limpiar()
        {
            txbNumCom.Clear();
            txbReporteServicio.Clear();
            txbBuscarCliente.Clear();
            nombrecli.Text = "---------------";
            dni.Text = "---------------";
            ubigeo.Text = "---------------";
            origencliente.Text = "---------------";
            observaciontxb.Clear();
            LBLtotalprod.Text = "0";


            F_Variables.DNI = "---------------";
            DtDetalle.Clear();

            // Restablece el ComboBox de Tipo Comprobante al primer elemento
            if (cmbTipCompr.Items.Count > 0)
            {
                cmbTipCompr.SelectedIndex = 0; // Selecciona el primer elemento
                tipoComprobanteSeleccionado = cmbTipCompr.SelectedItem.ToString(); // Actualiza la variable
            }
            else
            {
                cmbTipCompr.SelectedIndex = -1;
                tipoComprobanteSeleccionado = string.Empty;
            }

            // Limpieza de los nuevos campos
            txbcodigope.Clear(); // Limpia el campo de Código de Pedido
            txbtransporte.Clear(); // Limpia el campo de Transporte
            txbfechaDespacho.Value = DateTime.Now; // Restablece la Fecha de Despacho al valor actual
        }



        private void CargarIndicadores()
        {
            try
            {
                // Obtener y asignar valores a los labels
                frmsalida1.Text = objeto.ObtenerTotalSalidasSinCliente67().ToString();
                frmsalida2.Text = objeto.ObtenerTotalSalidasCliente6().ToString();
                frmsalida3.Text = objeto.ObtenerTotalSalidasCliente7().ToString();
                // Obtener el DataTable
                DataTable ultimaSalidaRegistrada = objeto.ObtenerUltimaSalidaRegistrada();

                // Validar que el DataTable tenga datos
                if (ultimaSalidaRegistrada.Rows.Count > 0)
                {
                    // Extraer el valor de la columna "NroDocumento" de la primera fila
                    string nroDocumento = ultimaSalidaRegistrada.Rows[0]["NroDocumento"].ToString();
                    frmsalida4.Text = nroDocumento;
                }
                else
                {
                    frmsalida4.Text = "Sin datos disponibles";
                }

                // Obtener el DataTable
                DataTable ultimaSalidaActualizada = objeto.ObtenerUltimaSalidaActualizada();

                // Validar que el DataTable tenga datos
                if (ultimaSalidaActualizada.Rows.Count > 0)
                {
                    // Extraer el valor de la columna "NroDocumento" de la primera fila
                    string nroDocumento = ultimaSalidaActualizada.Rows[0]["NroDocumento"].ToString();
                    frmsalida5.Text = nroDocumento;
                }
                else
                {
                    frmsalida5.Text = "Sin datos disponibles";
                }

                frmsalida6.Text = clienen.ObtenerSalidaRecientes().ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los indicadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crear_tabla()
        {
            DtDetalle.Columns.Add("CodigoProducto", typeof(string));
            DtDetalle.Columns.Add("Lote", typeof(string));
            DtDetalle.Columns.Add("Cantidad", typeof(int));
            DtDetalle.Columns.Add("Precio", typeof(decimal));
            DtDetalle.Columns.Add("Comision", typeof(decimal));
            DtDetalle.Columns.Add("PrecioVendido", typeof(decimal));
            DtDetalle.Columns.Add("Ganancia", typeof(decimal));
            DtDetalle.Columns.Add("Observacion", typeof(string)); // Observación incluida según el SP


            this.DtDetalle.Columns.Add("StockActual", System.Type.GetType("System.Int32")); // Nueva columna para StockActual

            dgvDetalle.DataSource = DtDetalle;

            // Ocultar la columna StockActual en el DataGridView
            if (dgvDetalle.Columns.Contains("StockActual"))
            {
                dgvDetalle.Columns["StockActual"].Visible = false;
            }
        }

        public void acciones_tabla()
        {
            // Configuración de la columna Código
            dgvDetalle.Columns["CodigoProducto"].HeaderText = "Código";
            dgvDetalle.Columns["CodigoProducto"].Width = 200;
            dgvDetalle.Columns["CodigoProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["CodigoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["CodigoProducto"].ReadOnly = true;

            // Configuración de la columna Lote
            dgvDetalle.Columns["Lote"].HeaderText = "Lote";
            dgvDetalle.Columns["Lote"].Width = 100;
            dgvDetalle.Columns["Lote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Lote"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Lote"].ReadOnly = false;

            // Configuración de la columna Cantidad
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalle.Columns["Cantidad"].Width = 70;
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Cantidad"].ReadOnly = false;

            // Configuración de la columna Precio
            dgvDetalle.Columns["Precio"].HeaderText = "Precio";
            dgvDetalle.Columns["Precio"].Width = 90;
            dgvDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Precio"].ReadOnly = false;

            
            // Configuración de la columna Precio Vendido
            dgvDetalle.Columns["PrecioVendido"].HeaderText = "Vendido";
            dgvDetalle.Columns["PrecioVendido"].Width = 90;
            dgvDetalle.Columns["PrecioVendido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["PrecioVendido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["PrecioVendido"].ReadOnly = false;

            // Configuración de la columna Comisión
            dgvDetalle.Columns["Comision"].HeaderText = "Comisión";
            dgvDetalle.Columns["Comision"].Width = 90;
            dgvDetalle.Columns["Comision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Comision"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Comision"].ReadOnly = false;

          
            // Configuración de la columna Ganancia
            dgvDetalle.Columns["Ganancia"].HeaderText = "Ganancia";
            dgvDetalle.Columns["Ganancia"].Width = 100;
            dgvDetalle.Columns["Ganancia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Ganancia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Ganancia"].ReadOnly = true; // Hacer que no sea editable

            // Configuración de la columna Observación
            dgvDetalle.Columns["Observacion"].HeaderText = "Observación";
            dgvDetalle.Columns["Observacion"].Width = 215;
            dgvDetalle.Columns["Observacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetalle.Columns["Observacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["Observacion"].ReadOnly = false;
            // Intercambiar las posiciones visibles de las columnas en el DataGridView
            dgvDetalle.Columns["PrecioVendido"].DisplayIndex = 3; // Mueve "Precio Vendido" a la posición actual de "Comisión"
            dgvDetalle.Columns["Comision"].DisplayIndex = 4;     // Mueve "Comisión" después de "Precio Vendido"

        }



        private void ConfigurarTextBox()
        {
            observaciontxb.ReadOnly = false;          // Permitir escritura
            observaciontxb.Enabled = true;           // Habilitar el control
            observaciontxb.Multiline = true;         // Permitir múltiples líneas
          
        }



        private void btnverServicios_Click(object sender, EventArgs e)
        {
        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            FrmClientes1 frm = new FrmClientes1();
            frm.ShowDialog(); // Muestra el formulario de selección de cliente

            // Asignamos los datos seleccionados en el formulario de cliente
            dni.Text = F_Variables.DNI;
            nombrecli.Text = F_Variables.Nombre;
            ubigeo.Text = F_Variables.Ubigeo;
            origencliente.Text = F_Variables.OrigenCliente;

            // Verifica que F_Variables esté actualizando correctamente
           // MessageBox.Show($"OrigenCliente: {F_Variables.OrigenCliente}");

            // Asignamos la lógica de tipo de venta según el origen del cliente
            if (F_Variables.OrigenCliente == "INTERNO")
            {
                configurarTipoVenta(true); // Venta Interna
                configurarMedio(true); // Medios Internos
            }
            else
            {
                configurarTipoVenta(false); // Venta Externa
                configurarMedio(false); // Medios Externos
            }

        }

        private void configurarTipoVenta(bool esInterno)
        {
            // Solo asignar el valor una vez
            if (tipoventa.Text != (esInterno ? "Venta Interna" : "Venta Externa"))
            {
                tipoventa.Text = esInterno ? "Venta Interna" : "Venta Externa";
            }

            // Verifica que el valor haya sido asignado correctamente
           // MessageBox.Show($"Después de asignar el valor: {tipoventa.Text}");
        }


        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LBLtotalprod.Text = DtDetalle.Rows.Count.ToString();

        }

        private void txbBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validar que el usuario haya ingresado un código
                    string textoBusqueda = txbBuscarCliente.Text.Trim();

                    if (string.IsNullOrEmpty(textoBusqueda) || textoBusqueda == "BUSCAR POR CÓDIGO DE PRODUCTO")
                    {
                        MessageBox.Show("Debe ingresar un código de producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // No continuar si el texto es inválido
                    }

                    DataTable Tabla = objProductos.buscandoproductosxproduc(textoBusqueda);
                    if (Tabla.Rows.Count <= 0)
                    {
                        MessageBox.Show("El código de producto no existe. Revise el código ingresado.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        try
                        {
                            // Obtener información del producto
                            string codigoProducto = Convert.ToString(Tabla.Rows[0]["CodigoProducto"]);
                            int stockActual = Convert.ToInt32(Tabla.Rows[0]["StockActual"]); // Obtener el stock actual del producto

                            // Verificar si el producto ya existe en el detalle
                            if (DtDetalle.Rows.Cast<DataRow>().Any(row => row["CodigoProducto"].ToString() == codigoProducto))
                            {
                                MessageBox.Show("El producto ya está en la lista.", "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Validar si el stock es 0
                            if (stockActual == 0)
                            {
                                MessageBox.Show($"El producto '{codigoProducto}' no tiene stock. Por favor, seleccione otro producto.",
                                                "Sin stock disponible",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                                return; // No permitir agregar productos con stock 0
                            }

                            // Validar si el stock es bajo (opcional, ≤ 1)
                            if (stockActual == 1)
                            {
                                MessageBox.Show($"El producto '{codigoProducto}' tiene un stock muy bajo ({stockActual}). Considere verificar el inventario.",
                                                "Advertencia de stock bajo",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
                            }

                            // Agregar detalles del producto
                            AgregarDetalle(
                                codigoProducto,
                                "LT-XXXX", // Lote predeterminado
                                1, // Cantidad inicial
                                Convert.ToDecimal(Tabla.Rows[0]["PrecioUnitario"]), // Precio del producto
                                0.0m, // Comisión predeterminada
                                0.0m, // Precio vendido inicial
                                0.0m, // Ganancia inicial
                                "Sin observación" // Observación predeterminada
                            );
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show($"Error en el formato de los datos: {ex.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la búsqueda: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


 



        private void AgregarDetalle(string codigoProducto , string lote, int cantidad, decimal precio, decimal comision, decimal precioVendido, decimal ganancia, string observacion)
        {
            // Verificar si el producto ya existe en el detalle
            if (DtDetalle.Rows.Cast<DataRow>().Any(row => row["CodigoProducto"].ToString() == codigoProducto))
            {
                MessageBox.Show("El producto ya está en la lista.", "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Crear una nueva fila con los valores del producto
            DataRow fila = DtDetalle.NewRow();
            fila["CodigoProducto"] = codigoProducto;
            fila["Lote"] = lote; // Valor predeterminado para Lote
            fila["Cantidad"] = cantidad; // Cantidad inicial predeterminada
            fila["Precio"] = precio; // Precio unitario
            fila["Comision"] = comision; // Comision
            fila["PrecioVendido"] = precioVendido; // Precio vendido
            fila["Ganancia"] = ganancia; // Ganancia
            fila["Observacion"] = observacion; // Observación personalizada


            // Agregar la fila al DataTable
            DtDetalle.Rows.Add(fila);

            // Actualizar la interfaz
            LBLtotalprod.Text = DtDetalle.Rows.Count.ToString();
            MessageBox.Show("Producto agregado correctamente al detalle.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }






        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // Obtener el nombre de la columna que se está validando
                string columnName = dgvDetalle.Columns[e.ColumnIndex].Name;

                // Validar solo las columnas relevantes
                if (columnName == "PrecioVendido" || columnName == "Comision" || columnName == "Precio")
                {
                    string valor = e.FormattedValue.ToString();

                    // Verificar si el valor es un número válido
                    if (!decimal.TryParse(valor, out decimal numero) || numero < 0)
                    {
                        MessageBox.Show("Solo se permiten números positivos en este campo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true; // Evitar que el usuario salga de la celda
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Evitar que el usuario salga de la celda
            }
        }
        // Configuración del DataGridView
        private void ConfigurarDataGridView()
        {
            dgvDetalle.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvDetalle.AllowUserToAddRows = false; // Opcional, según el caso
            dgvDetalle.Columns["Cantidad"].ValueType = typeof(int); // Asegura que sea tipo entero
        }

      

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtener el nombre de la columna editada
                string columnName = dgvDetalle.Columns[e.ColumnIndex].Name;

                if (columnName == "PrecioVendido" || columnName == "Comision" || columnName == "Precio" || columnName == "Cantidad")
                {
                    // Validar si los valores necesarios están presentes
                    var fila = dgvDetalle.Rows[e.RowIndex];

                    // Usar operadores nulos para evitar errores al convertir
                    decimal precioVendido = Convert.ToDecimal(fila.Cells["PrecioVendido"].Value ?? 0);
                    decimal comision = Convert.ToDecimal(fila.Cells["Comision"].Value ?? 0);
                    decimal precioCosto = Convert.ToDecimal(fila.Cells["Precio"].Value ?? 0);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value ?? 0);

                    // Calcular la ganancia total
                    decimal gananciaTotal = (precioVendido - precioCosto - comision) * cantidad;

                    // Evitar valores negativos en la ganancia
                    if (gananciaTotal < 0)
                    {
                        MessageBox.Show("La ganancia no puede ser negativa. Verifique los valores ingresados.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fila.Cells["Ganancia"].Value = 0.00M; // Asignar valor predeterminado
                    }
                    else
                    {
                        fila.Cells["Ganancia"].Value = gananciaTotal; // Asignar la ganancia total calculada
                    }
                }

                if (columnName == "Cantidad")
                {
                    // Obtener la cantidad ingresada
                    int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value ?? 0);

                    // Obtener el stock actual de la fila correspondiente
                    int stockActual = Convert.ToInt32(DtDetalle.Rows[e.RowIndex]["StockActual"] ?? 0);

                    // Validar si la cantidad supera el stock disponible
                    if (cantidad > stockActual)
                    {
                        MessageBox.Show($"La cantidad ingresada supera el stock disponible. Stock actual: {stockActual}.",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        // Restaurar la cantidad al valor máximo permitido (stock actual)
                        dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = stockActual;
                    }
                    else if (cantidad <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = 1; // Restaurar a un valor predeterminado
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }




        private void dgvDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error en el formato del dato ingresado. Por favor, verifique e intente nuevamente.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false; // Evita que se lance la excepción
        }



        private void txbServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbFecha_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un cliente
                if (string.IsNullOrWhiteSpace(F_Variables.DNI) || F_Variables.DNI == "---------------")
                {
                    MessageBox.Show("Debe seleccionar un cliente antes de registrar la salida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el detalle no esté vacío
                if (DtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Debe registrar al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tipoComprobanteSeleccionado))
                {
                    MessageBox.Show("Debe seleccionar un tipo de comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txbcodigope.Text))
                {
                    MessageBox.Show("Debe ingresar un Código de Pedido válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txbtransporte.Text) || Convert.ToDecimal(txbtransporte.Text) < 0)
                {
                    MessageBox.Show("El valor del Transporte no puede ser negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txbfechaDespacho.Value < txbFecha.Value)
                {
                    MessageBox.Show("La Fecha de Despacho no puede ser anterior a la fecha indicada en el campo Fecha.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txbNumCom.Text))
                {
                    MessageBox.Show("Debe ingresar un número de comprobante válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar que todos los productos tengan un PrecioVendido válido
                foreach (DataRow fila in DtDetalle.Rows)
                {
                    if (fila["PrecioVendido"] == DBNull.Value || Convert.ToDecimal(fila["PrecioVendido"]) <= 0)
                    {
                        MessageBox.Show($"El producto con código '{fila["CodigoProducto"]}' no tiene un precio válido para la venta. Por favor, revise los datos.",
                                        "Error de validación",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return; // Detener el proceso de guardado
                    }
                }
                foreach (DataRow fila in DtDetalle.Rows)
                {
                    if (string.IsNullOrWhiteSpace(fila["Lote"].ToString()))
                    {
                        MessageBox.Show("Debe completar el lote para todos los productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (fila["Cantidad"] == DBNull.Value || Convert.ToInt32(fila["Cantidad"]) <= 0)
                    {
                        MessageBox.Show("Debe ingresar una cantidad válida para todos los productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(fila["Observacion"].ToString()))
                    {
                        MessageBox.Show("Debe completar la observación para todos los productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (cmb_medio.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmb_medio.Text))
                {
                    MessageBox.Show("Debe seleccionar un medio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaEntrada = txbFecha.Value;  // Obtiene el valor del DateTimePicker
                DateTime fechadespacho = txbfechaDespacho.Value;  // Obtiene el valor del DateTimePicker

                // Crear la entidad E_Salida
                var salida = new E_salida
                {
                    NroDocumento = string.IsNullOrWhiteSpace(nrodcomuento.Text) ? null : nrodcomuento.Text.Trim(),
                    clienteid = Convert.ToInt32(F_Variables.ClienteID),
                    medio = cmb_medio.Text.Trim(),
                    observacion = observaciontxb.Text.Trim(),
                    tipoVenta = tipoventa.Text.Trim(),
                    TipoComprobante = tipoComprobanteSeleccionado,
                    NroComprobante = txbNumCom.Text.Trim(),
                    Detallessalida = DtDetalle,
                    Fecha = fechaEntrada,
                    CodigoPedido = txbcodigope.Text.Trim(),
                    Transporte = string.IsNullOrEmpty(txbtransporte.Text) ? 0 : Convert.ToDecimal(txbtransporte.Text),
                    FechaDespacho = txbfechaDespacho.Value // Fecha y hora seleccionadas
                };

                if (string.IsNullOrWhiteSpace(salida.NroDocumento)) // Registro nuevo
                {
                    salida.UserCreate = Idusuario.ToString();
                    // 🔹 Insertar la salida y obtener el `NroDocumento` generado
                    salida.NroDocumento = objNegocio.InsertarSalida(salida);

                    // 🔹 Generar el script SQL con el `NroDocumento` correcto
                    objNegocio.GenerarScriptInsertar(salida);
                    MessageBox.Show("La salida se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarServicio.Text = "Registrar Salida";

                }
                else // Edición
                {
                    // 🔹 Generamos el script SQL con los cambios
                    objNegocio.GenerarScriptEditar(salida);
                    salida.UserUpdate = Idusuario.ToString();
                    objNegocio.EditarSalida(salida);

                    MessageBox.Show("La salida se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardarServicio.Text = "Registrar Salida";

                }

                Limpiar();
                DtDetalle.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txbNumCom_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void tipoDecambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y teclas de control
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números decimales en este campo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void dgvDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void lblTotalnumer_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

       


        private void AsociarEventoTipoComprobante()
        {
            cmbTipCompr.SelectedIndexChanged += cmbTipCompr_SelectedIndexChanged;
        }

        private void cmbTipCompr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipCompr.SelectedItem != null)
            {
                tipoComprobanteSeleccionado = cmbTipCompr.SelectedItem.ToString();
            }
            else
            {
                tipoComprobanteSeleccionado = string.Empty;
            }
        }
        private void txbBuscarCliente_Enter(object sender, EventArgs e)
        {
            // Si el texto actual es igual al placeholder, lo limpia
            if (txbBuscarCliente.Text == "BUSCAR POR CÓDIGO DE PRODUCTO")
            {
                txbBuscarCliente.Text = "";
                txbBuscarCliente.ForeColor = Color.Black; // Cambia el color del texto al habitual
            }
        }

        private void txbBuscarCliente_Leave(object sender, EventArgs e)
        {
            // Si el usuario no escribe nada, vuelve a mostrar el placeholder
            if (string.IsNullOrWhiteSpace(txbBuscarCliente.Text))
            {
                txbBuscarCliente.Text = "BUSCAR POR CÓDIGO DE PRODUCTO";
                txbBuscarCliente.ForeColor = Color.Gray; // Usa un color gris para el placeholder
            }
        }
        private void ConfigurarFuenteTabla()
        {
            // Cambiar la fuente de las celdas
            dgvDetalle.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);

            // Cambiar la fuente de los encabezados
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            // Opcional: ajustar el tamaño de las filas para que se adapten a la nueva fuente
            dgvDetalle.RowTemplate.Height = 30;

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            FrmVerProductos frm = new FrmVerProductos(true);
            frm.FormClosed += (s, args) =>
            {
                if (frm.ProductoSeleccionado != null)
                {
                    AgregarProductoDesdeOtroFormulario(frm.ProductoSeleccionado.Codigo, frm.ProductoSeleccionado.Descripcion);

                }
            };
            frm.ShowDialog();
        }
        public void AgregarProductoDesdeOtroFormulario(string codigoProducto, string descripcionProducto)
        {
            bool Agregar = true;

            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (FilaTemp["CodigoProducto"].ToString() == codigoProducto)
                {
                    Agregar = false;
                    MessageBox.Show("Ya se ingresó este producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }

            if (Agregar)
            {
                // Consultar el precio y stock desde la tabla de productos
                decimal precioProducto = 0.00M;
                int stockActual = 0;
                try
                {
                    DataTable Tabla = objProductos.buscandoproductosxproduc(codigoProducto); // Método para obtener datos del producto
                    if (Tabla.Rows.Count > 0)
                    {
                        precioProducto = Convert.ToDecimal(Tabla.Rows[0]["PrecioUnitario"]); // Asegúrate de que el nombre de la columna coincida
                        stockActual = Convert.ToInt32(Tabla.Rows[0]["StockActual"]);

                    }
                    else
                    {
                        MessageBox.Show("No se encontró información  del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la información  del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear la fila con los valores obtenidos
                DataRow Fila = DtDetalle.NewRow();
                Fila["CodigoProducto"] = codigoProducto;
                Fila["Lote"] = "LT-XXXX"; // Valor predeterminado
                Fila["Cantidad"] = 1; // Valor predeterminado
                Fila["Precio"] = precioProducto; // Asignar el precio obtenido
                Fila["Comision"] = 0.00M; // Valor predeterminado
                Fila["PrecioVendido"] = 0.00M; // Inicialmente igual al precio del producto
                Fila["Ganancia"] = 0.00M; // Valor predeterminado
                Fila["Observacion"] = "Sin observación"; // Valor predeterminado
                Fila["StockActual"] = stockActual; // Asignar el stock actual (interno)

                // Agregar la fila al DataTable
                DtDetalle.Rows.Add(Fila);
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LBLtotalprod.Text = DtDetalle.Rows.Count.ToString();
            }
        }

        private void LBLtotalprod_Click(object sender, EventArgs e)
        {

        }

       


       
        private void dataGridViewDetalle_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Verifica si hay filas en la tabla
            if (DtDetalle.Rows.Count > 0)
            {
                // Actualiza el contador de productos
                LBLtotalprod.Text = (DtDetalle.Rows.Count - 1).ToString();
            }
            else
            {
                LBLtotalprod.Text = "0"; // Si no hay productos, establece el contador en 0
            }
            // Refresca el DataGridView para reflejar cambios
            dgvDetalle.Refresh();
        }



        private void configurarVentaInterna()
        {
            try
            {
                DataTable dtMedioInterno = objNegocio.ListaSalidamedioint(); // Obtener medios para clientes internos

                if (dtMedioInterno == null || dtMedioInterno.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron medios para clientes internos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_medio.DataSource = null;
                    cmb_medio.Enabled = false;
                    return;
                }

                cmb_medio.DataSource = dtMedioInterno;
                cmb_medio.DisplayMember = "Descripcion";
                cmb_medio.ValueMember = "IDtipoventa";
                cmb_medio.SelectedIndex = -1; // No seleccionar nada por defecto
                cmb_medio.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar medios internos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarVentaExterna()
        {
            try
            {
                DataTable dtMedioExterno = objNegocio.ListaSalidamedio(false); // Obtener medios para clientes externos

                if (dtMedioExterno == null || dtMedioExterno.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron medios para clientes externos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_medio.DataSource = null;
                    cmb_medio.Enabled = false;
                    return;
                }

                cmb_medio.DataSource = dtMedioExterno;
                cmb_medio.DisplayMember = "Descripcion";
                cmb_medio.ValueMember = "IDtipoventa";
                cmb_medio.SelectedIndex = -1; // No seleccionar nada por defecto
                cmb_medio.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar medios externos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarMedio(bool esInterno)
        {
            if (esInterno)
            {
                configurarVentaInterna();
            }
            else
            {
                configurarVentaExterna();
            }
        }



        private void InicializarComboBoxMedio()
        {
            try
            {
                DataTable dtMedio = objNegocio.ListaSalidamedio(false); // Cargar todos los registros iniciales

                if (dtMedio == null || dtMedio.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para inicializar el ComboBox.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_medio.DataSource = null;
                    cmb_medio.Enabled = false;
                    return;
                }

                cmb_medio.DataSource = dtMedio;
                cmb_medio.DisplayMember = "Descripcion";
                cmb_medio.ValueMember = "IDtipoventa";
                cmb_medio.SelectedIndex = -1; // Sin selección inicial
                cmb_medio.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el ComboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmb_medio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editarSalida_Click(object sender, EventArgs e)
        {
            FrmSalidaVer frm = new FrmSalidaVer();
            frm.ShowDialog();
            nrodcomuento.Text = F_Variables.NroDocumento;
            txbReporteServicio.Text = F_Variables.ClienteID.ToString();
            F_Variables.pruebatodox = F_Variables.ClienteID.ToString();

            dni.Text = F_Variables.DNI;
            nombrecli.Text = F_Variables.Nombre; // nombre del cliente
            ubigeo.Text = F_Variables.Ubigeo;
            origencliente.Text = F_Variables.OrigenCliente;

            if (!string.IsNullOrWhiteSpace(nrodcomuento.Text))
            {
                CargarSalida(nrodcomuento.Text);
                btnGuardarServicio.ButtonText = "Editar Salida";

            }
            else
            {
                MessageBox.Show("Ingrese un número de documento válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void CargarSalida(string nroDocumento)
        {
            try
            {
                DataSet ds = objNegocio.ObtenerSalidaConDetalles(nroDocumento);

                if (ds.Tables.Count >= 2)
                {
                    // Información principal de la salida
                    DataTable salidaInfo = ds.Tables[0];
                    if (salidaInfo.Rows.Count > 0)
                    {
                        DataRow row = salidaInfo.Rows[0];

                        // Asignar valores a los controles
                        nombrecli.Text = row["ClienteNombre"].ToString();
                        txbFecha.Text = Convert.ToDateTime(row["Fecha"]).ToString("dd-MM-yyyy");
                        txbNumCom.Text = row["Nro_Comprobante"].ToString();
                        tipoventa.Text = row["TipoVenta"].ToString();
                        observaciontxb.Text = row["Observacion"].ToString();
                        txbFecha.Text = Convert.ToDateTime(row["Fecha"]).ToString("dd-MM-yyyy"); // Fecha
                        txbcodigope.Text = row["Codigo_Pedido"]?.ToString();
                        txbtransporte.Text = Convert.ToString(row["Transporte"]); // Asigna el valor desde la tabla
                        txbfechaDespacho.Value = Convert.ToDateTime(row["FechaDespacho"]);

                        // Configurar el ComboBox de medios según el cliente
                        bool clienteEsInterno = row["TipoVenta"].ToString().ToLower() == "venta interna";
                        configurarMedio(clienteEsInterno);

                        // Configurar y seleccionar el tipo de comprobante
                        string tipoComprobante = row["Tipo_Comprobante"].ToString();
                        if (!string.IsNullOrEmpty(tipoComprobante))
                        {
                            cmbTipCompr.SelectedItem = tipoComprobante;
                            tipoComprobanteSeleccionado = tipoComprobante; // Actualiza la variable
                        }
                        else
                        {
                            cmbTipCompr.SelectedIndex = -1; // Sin selección si no hay tipo definido
                            tipoComprobanteSeleccionado = string.Empty;
                        }

                        // Cargar el medio de pago si existe
                        string medio = row["Medio"].ToString();
                        if (!string.IsNullOrEmpty(medio) && cmb_medio.DataSource != null)
                        {
                            DataTable dtMedio = (DataTable)cmb_medio.DataSource;
                            DataRow[] filas = dtMedio.Select($"Descripcion = '{medio}'");

                            if (filas.Length > 0)
                            {
                                cmb_medio.SelectedValue = filas[0]["IDtipoventa"];
                            }
                            else
                            {
                                MessageBox.Show($"El medio '{medio}' no está disponible para el tipo de cliente seleccionado. Ajuste manualmente.",
                                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cmb_medio.SelectedIndex = -1; // Deseleccionar si no se encuentra
                            }
                        }
                        else
                        {
                            cmb_medio.SelectedIndex = -1;
                            cmb_medio.Enabled = false; // Deshabilitar si no hay medio asignado
                        }
                    }

                    // Detalles de la salida
                    DataTable detalles = ds.Tables[1];
                    DtDetalle.Clear();
                    foreach (DataRow detalle in detalles.Rows)
                    {
                        DataRow fila = DtDetalle.NewRow();
                        fila["CodigoProducto"] = detalle["CodigoProducto"].ToString();
                        fila["Lote"] = detalle["Lote"].ToString();
                        fila["Cantidad"] = Convert.ToInt32(detalle["Cantidad"]);
                        fila["Precio"] = Convert.ToDecimal(detalle["Precio"]);
                        fila["Comision"] = Convert.ToDecimal(detalle["Comision"]);
                        fila["PrecioVendido"] = Convert.ToDecimal(detalle["PrecioVendido"]);
                        fila["Ganancia"] = Convert.ToDecimal(detalle["Ganancia"]);
                        fila["Observacion"] = detalle["Observacion"].ToString();


                        string codigoProducto = detalle["CodigoProducto"].ToString();
                        int stockActual = objProductos.ObtenerStockActual(codigoProducto); // Llamamos a la capa de negocio


                        fila["StockActual"] = stockActual;
                        DtDetalle.Rows.Add(fila);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la salida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void InicializarComboBoxTipoComprobante()
        {
            // Limpiar items previos si existieran
            cmbTipCompr.Items.Clear();

            // Agregar valores fijos al ComboBox
            cmbTipCompr.Items.Add("GUIA");
            cmbTipCompr.Items.Add("BOLETA");
            cmbTipCompr.Items.Add("FACTURA");
            cmbTipCompr.Items.Add("NOTA DE CREDITO");

            // Seleccionar la primera opción por defecto (opcional)
            cmbTipCompr.SelectedIndex = -1; // Sin selección inicial
        }

        private void txbcodigope_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txbtransporte_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Permitir números, un punto decimal, una coma decimal, y teclas de control como retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la entrada
                return;
            }

            TextBox txtBox = sender as TextBox;

            // Verificar si ya existe un punto o coma decimal y no permitir otro
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtBox.Text.Contains(".") || txtBox.Text.Contains(",")))
            {
                e.Handled = true; // Ignorar la entrada si ya existe un punto o coma
            }

            // Opcional: Restringir la entrada de caracteres al principio
            if ((e.KeyChar == '.' || e.KeyChar == ',') && string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Text = "0"; // Preceder con un cero si empieza con un punto o coma
                txtBox.SelectionStart = txtBox.Text.Length; // Colocar el cursor al final
            }

        }
        private void ConfigurarDateTimePickerFechaDespacho()
        {
            txbfechaDespacho.Format = DateTimePickerFormat.Custom; // Usar formato personalizado
            txbfechaDespacho.CustomFormat = "dd/MM/yyyy HH:mm";    // Mostrar fecha y hora
            txbfechaDespacho.ShowUpDown = true;                   // Usar flechas para ajustar tiempo
        }

        private void txbfechaDespacho_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
