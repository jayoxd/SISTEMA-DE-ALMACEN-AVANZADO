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
    public partial class FrmEntrada : Form
    {
        private DataTable DtDetalle = new DataTable();

        N_Entrada objNegocio = new N_Entrada();
        N_Productoss objProductos = new N_Productoss();
        N_Entrada objServicio = new N_Entrada();
        N_Clientes clienen = new N_Clientes();  
        public int cam = 0;
        private string tipoComprobanteSeleccionado = ""; // Variable para almacenar el tipo de comprobante seleccionado
        public int Idusuario { get; set; } // Recibe el Idusuario desde FrmPrincipal


        public FrmEntrada()
        {
            ;
            InitializeComponent();
            //  lblclient.Text = F_Variables.nombre_empleado;
            dgvDetalle.CellEndEdit += dgvDetalle_CellEndEdit; // Evento para validar edición
            dgvDetalle.CellValidating += dgvDetalle_CellValidating; // Evento para validar datos

            // Asociar el evento UserDeletingRow
            dgvDetalle.UserDeletingRow += dataGridViewDetalle_UserDeletingRow;

            CargarIndicadores();
            dgvDetalle.DataError += dgvDetalle_DataError; // Asocia el evento de error
            crear_tabla();
            ConfigurarFuenteTabla(); // Aumentar el tamaño de la fuente en la tabla
            acciones_tabla();
            InicializarTipoComprobante(); // Inicializar el ComboBox
            AsociarEventoTipoComprobante(); // Asociar evento para capturar el valor seleccionado
            cmbTipCompr.Font = new Font("Arial", 12, FontStyle.Regular); // Cambia "Arial" y 14 según tus preferencias
            txbBuscarCliente.Text = "BUSCAR POR CÓDIGO DE PRODUCTO";
            txbBuscarCliente.ForeColor = Color.Gray;
            // Asociar eventos de validación
            txbNumCom.KeyPress += txbNumCom_KeyPress;
            tipoDecambio.KeyPress += tipoDecambio_KeyPress;

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
            //panel9.AutoScroll = true;

          //  panel9.Size = new Size(1650, 850); // Tamaño del Panel más pequeño
            panel9.Size = new Size(1530, 700); // Tamaño del Panel más pequeño


        }
        private void CargarIndicadores()
        {
            try
            {
                // Obtener y asignar valores a los labels
                frmentrada1.Text = objServicio.ContarEntradasSinProveedor3y7().ToString();
                frmentrada2.Text = objServicio.ContarEntradasConProveedor3().ToString();
                frmentrada3.Text = objServicio.ContarEntradasConProveedor7().ToString();
                frmentrada4.Text = objServicio.ObtenerUltimaEntradaRegistrada();
                frmentrada5.Text = objServicio.ObtenerUltimaEntradaModificada();
                frmentrada6.Text = clienen.ObtenerEntradasRecientes().ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los indicadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Listar()
        {
            try
            {
                /* dgvDetalle.DataSource = objServicio.listandoServicios();*/
                dgvDetalle.DataSource = objServicio.ListarEntradas();
                this.Limpiar();
                // LblTotal.Text = "Total registros: " + Convert.ToString(dgvDetalle.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpiar()
        {
            // Limpia los campos de texto
            txbNumCom.Clear();
            tipoDecambio.Clear();
            txbReporteServicio.Clear();
            txbBuscarCliente.Clear();
            razonsocial.Text = "---------------";
            ruc.Text = "---------------";
            observaciontxb.Clear();
            // Mantén el contenido del ComboBox
            cmbTipCompr.SelectedIndex = 0; // Selecciona la opción predeterminada en lugar de limpiar
            nrodcomuento.Clear();
            // Limpia la tabla de detalles
            DtDetalle.Clear();
            LBLtotalprod.Text = "0"; // Reinicia el contador de productos
        }
        private void RestablecerFormulario()
        {
            Limpiar();
            InicializarTipoComprobante(); // Reconfigura el ComboBox
            ConfigurarFuenteTabla(); // Reaplica configuraciones a la tabla
        }



        public void crear_tabla()
        {
            this.DtDetalle.Columns.Add("CodigoProducto", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("DescripcionProducto", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("Lote", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("PrecioCompra", System.Type.GetType("System.Decimal")); // Cambiado a decimal
            this.DtDetalle.Columns.Add("Observacion", System.Type.GetType("System.String"));

            dgvDetalle.DataSource = this.DtDetalle;
        }
        public void acciones_tabla()
        {
            // Configuración de la columna Código
            dgvDetalle.Columns[0].HeaderText = "Código";
            dgvDetalle.Columns[0].Width = 200; // Ajusta el ancho
            dgvDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado
            dgvDetalle.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[0].ReadOnly = true; // Solo lectura

            // Configuración de la columna Descripción
            dgvDetalle.Columns[1].HeaderText = "Descripción";
            dgvDetalle.Columns[1].Width = 300; // Ajusta el ancho
            dgvDetalle.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alineado a la izquierda
            dgvDetalle.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[1].ReadOnly = true; // Solo lectura

            // Configuración de la columna Lote
            dgvDetalle.Columns[2].HeaderText = "Lote";
            dgvDetalle.Columns[2].Width = 85; // Ajusta el ancho
            dgvDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado
            dgvDetalle.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[2].ReadOnly = false; // Editable

            // Configuración de la columna Cantidad
            dgvDetalle.Columns[3].HeaderText = "Cantidad";
            dgvDetalle.Columns[3].Width = 70; // Ajusta el ancho
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado
            dgvDetalle.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[3].ReadOnly = false; // Editable


            // Configuración de la columna PrecioCompra
            dgvDetalle.Columns[4].HeaderText = "PrecioCompra";
            dgvDetalle.Columns[4].Width = 85; // Ajusta el ancho
            dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrado
            dgvDetalle.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[4].ReadOnly = false; // Editable

            // Configuración de la columna Observación
            dgvDetalle.Columns[5].HeaderText = "Observación";
            dgvDetalle.Columns[5].Width = 240; // Ajusta el ancho
            dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alineado a la izquierda
            dgvDetalle.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezado centrado
            dgvDetalle.Columns[5].ReadOnly = false; // Editable
        }






        private void btnverServicios_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FRMProveedor frm = new FRMProveedor();
            frm.ShowDialog();
            ruc.Text = F_Variables.RUC;
            razonsocial.Text = F_Variables.empresa;
            // txtDescripcion.Text = F_Variables.direccionEmp;
            txbReporteServicio.Text = F_Variables.pruebatodox;//proveeodr id 
            



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
                        return; // No continúa si no hay un código válido
                    }

                    // Buscar el producto
                    DataTable Tabla = objProductos.buscandoproductosxproduc(textoBusqueda);
                    if (Tabla.Rows.Count <= 0)
                    {
                        MessageBox.Show("El código de producto no existe. Revise el código ingresado.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Verificar si ya existe antes de intentar agregar
                        string codigoProducto = Convert.ToString(Tabla.Rows[0][0]);

                        foreach (DataRow FilaTemp in DtDetalle.Rows)
                        {
                            if (FilaTemp["CodigoProducto"].ToString() == codigoProducto)
                            {
                                MessageBox.Show("Ya se ingresó este producto. Por favor, ingrese otro producto.", "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Salir si el producto ya existe
                            }
                        }

                        // Si no es duplicado, agregarlo
                        try
                        {
                            this.AgregarDetalle(
                                codigoProducto,
                                Convert.ToString(Tabla.Rows[0][1]),
                                Convert.ToDecimal(Tabla.Rows[0][3])
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
                MessageBox.Show($"Error en la búsqueda: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AgregarDetalle(string CodigoProducto, string DescripcionProducto, decimal PrecioUnitario)
        {
            // Verificar si el producto ya existe en el detalle
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (FilaTemp["CodigoProducto"].ToString() == CodigoProducto)
                {
                    // Mostrar advertencia y salir del método
                    MessageBox.Show("Ya se ingresó este producto. Por favor, ingrese otro producto.", "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método si el producto ya existe
                }
            }

            // Si no es duplicado, crear una nueva fila
            DataRow Fila = DtDetalle.NewRow();
            Fila["CodigoProducto"] = CodigoProducto;
            Fila["DescripcionProducto"] = DescripcionProducto;
            Fila["Lote"] = "LT-XXXX"; // Valor predeterminado para Lote
            Fila["Cantidad"] = 1; // Valor inicial predeterminado para Cantidad
            Fila["PrecioCompra"] = PrecioUnitario; // Inicializado con el precio unitario
            Fila["Observacion"] = "Sin observación del producto"; // Valor predeterminado para Observación

            DtDetalle.Rows.Add(Fila);

            // Mostrar mensaje de éxito
            MessageBox.Show("El producto se agregó correctamente al detalle.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        // Validación en CellValidating
        private void dgvDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // Verifica si estamos en la columna "Cantidad"
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "Cantidad")
                {
                    string valorCelda = e.FormattedValue.ToString();

                    // Validación de cantidad
                    if (int.TryParse(valorCelda, out int cantidad))
                    {
                        if (cantidad <= 0)
                        {
                            MessageBox.Show("La cantidad debe ser un número mayor a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true; // Evita salir de la celda
                        }
                        else if (cantidad > 1000)
                        {
                            MessageBox.Show("La cantidad ingresada es demasiado alta.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true; // Evita salir de la celda
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor numérico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true; // Evita salir de la celda
                    }
                }
                string columnName = dgvDetalle.Columns[e.ColumnIndex].Name;

                if (columnName == "PrecioCompra")
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
                MessageBox.Show($"Error durante la validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela la edición en caso de error
            }
        }
        // Configuración del DataGridView
        private void ConfigurarDataGridView()
        {
            dgvDetalle.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvDetalle.AllowUserToAddRows = false; // Opcional, según el caso
            dgvDetalle.Columns["Cantidad"].ValueType = typeof(int); // Asegura que sea tipo entero
        }

        // Método para validar la cantidad
        private string ValidarCantidad(string valorCelda)
        {
            if (int.TryParse(valorCelda, out int cantidad))
            {
                if (cantidad <= 0) return "La cantidad debe ser un número mayor a cero.";
                if (cantidad > 1000) return "La cantidad ingresada es demasiado alta.";
            }
            else
            {
                return "Ingrese un valor numérico válido para la cantidad.";
            }
            return string.Empty; // Sin errores
        }

        // Evento para restaurar valores en caso de error
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = dgvDetalle.Columns[e.ColumnIndex].Name;

                if (columnName == "Cantidad")
                {
                    string valorCelda = dgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    // Validación adicional al finalizar la edición
                    if (!string.IsNullOrEmpty(ValidarCantidad(valorCelda)))
                    {
                        dgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Restaurar valor predeterminado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la celda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1; // Restaurar a un valor predeterminado
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que la tabla de detalles tenga al menos un producto registrado
                if (DtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("Debe registrar al menos un producto en la entrada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar si los productos seleccionados tienen stock disponible
                if (!ValidarStockProductos())
                {
                    return; // Si la validación falla, no continuar con el registro
                }

                // Validar que el número de reporte sea válido
                if (string.IsNullOrWhiteSpace(txbReporteServicio.Text) || !int.TryParse(F_Variables.pruebatodox, out int reporteId) || reporteId <= 0)
                {
                    MessageBox.Show("Debe Seleccionar un Proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar que el tipo de cambio sea válido
                if (string.IsNullOrWhiteSpace(tipoDecambio.Text) || !decimal.TryParse(tipoDecambio.Text, out decimal tipoCambio) || tipoCambio <= 0)
                {
                    MessageBox.Show("Debe ingresar un tipo de cambio válido (mayor a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya seleccionado un tipo de comprobante
                if (string.IsNullOrWhiteSpace(tipoComprobanteSeleccionado))
                {
                    MessageBox.Show("Debe seleccionar un tipo de comprobante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                }
                if(string.IsNullOrWhiteSpace(observaciontxb.Text))
                {
                    MessageBox.Show("Debe ingresar un número de comprobante válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Validar el número de comprobante
                if (string.IsNullOrWhiteSpace(txbNumCom.Text))
                {
                    MessageBox.Show("Debe ingresar un número de comprobante válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                // Validar los datos en cada fila de la tabla de detalles
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

                if (string.IsNullOrWhiteSpace(nrodcomuento.Text))
                {
                    // Si no hay valor en el NroDocumento, se realiza un registro nuevo

                    E_Entrada entidades = new E_Entrada();
                    entidades.NroDocumento = nrodcomuento.Text;
                    entidades.ProveedorID = Convert.ToInt32(txbReporteServicio.Text);
                    entidades.TipoComprobante = tipoComprobanteSeleccionado;
                    entidades.TipoCambio = tipoCambio;
                    entidades.NroComprobante = txbNumCom.Text.Trim();
                    entidades.observacion = observaciontxb.Text;
                    entidades.Detalles = DtDetalle;
                    entidades.UserCreate = Idusuario.ToString();
                    DateTime fechaEntrada = txbFecha.Value;  // Obtiene el valor del DateTimePicker
                    entidades.Fecha = fechaEntrada;
                    // Asumimos que el usuario que edita es 'user2' (puedes cambiarlo a la variable correspondiente)
               

                    N_Entrada objDatos = new N_Entrada();

                    // Llamada a la capa de negocio para insertar la entrada
                    string nroDocumentoGenerado = objDatos.InsertarEntrada(entidades);

                    // 🔹 Asignarlo a la entidad
                    entidades.NroDocumento = nroDocumentoGenerado;

                    // 🔹 Generar el script SQL con el `NroDocumento` correcto
                    objDatos.GenerarScriptInsertar(entidades);

                    MessageBox.Show("La entrada se registró correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestablecerFormulario();
                    btnGuardarServicio.ButtonText = "Registrar Entrada";



                }
                else
                {
                    // Si el NroDocumento tiene valor, se realiza una edición
                    E_Entrada entidades = new E_Entrada();
                    entidades.NroDocumento = nrodcomuento.Text;
                    entidades.ProveedorID = Convert.ToInt32(txbReporteServicio.Text);
                    entidades.TipoComprobante = tipoComprobanteSeleccionado;
                    entidades.TipoCambio = tipoCambio;
                    entidades.NroComprobante = txbNumCom.Text.Trim();
                    entidades.observacion = observaciontxb.Text;
                    entidades.Detalles = DtDetalle;
                    DateTime fechaEntrada = txbFecha.Value;  // Obtiene el valor del DateTimePicker
                    entidades.Fecha = fechaEntrada;
                    // Asumimos que el usuario que edita es 'user2' (puedes cambiarlo a la variable correspondiente)
                    entidades.UserUpdate = Idusuario.ToString();;

                    N_Entrada objDatos = new N_Entrada();

                    // Llamada a la capa de negocio para editar la entrada
                    objDatos.EditarEntrada(entidades);
                    objDatos.GenerarScriptEditar(entidades);
                    
                    MessageBox.Show("La entrada se editó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestablecerFormulario();
                    btnGuardarServicio.ButtonText = "Registrar Entrada";

                }



            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error en el formato de los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void EditarEntrada(E_Entrada entrada)
        {
            N_Entrada objDatos = new N_Entrada();

            objDatos.EditarEntrada(entrada); // Llamada al método de la capa de datos
        }
        private void txbNumCom_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void tipoDecambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal, coma decimal y teclas de control
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números decimales y comas en este campo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Asegurarse de que solo haya un punto o una coma decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (tipoDecambio.Text.Contains('.') || tipoDecambio.Text.Contains(',')))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permite un punto o una coma decimal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

       

        private void InicializarTipoComprobante()
        {
            // Llenar el ComboBox con valores
            cmbTipCompr.Items.Clear(); // Limpia cualquier valor existente
            cmbTipCompr.Items.Add("Seleccionar"); // Texto inicial
            cmbTipCompr.Items.Add("GUIA");
            cmbTipCompr.Items.Add("BOLETA");
            cmbTipCompr.Items.Add("FACTURA");
            cmbTipCompr.Items.Add("NOTA DE CREDITO");

            cmbTipCompr.SelectedIndex = 0; // Seleccionar el valor inicial "Seleccionar"
        }

        private void AsociarEventoTipoComprobante()
        {
            cmbTipCompr.SelectedIndexChanged += cmbTipCompr_SelectedIndexChanged;
        }

        private void cmbTipCompr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipCompr.SelectedIndex > 0) // Verifica que no sea la opción "Seleccionar"
            {
                tipoComprobanteSeleccionado = cmbTipCompr.SelectedItem.ToString();
            }
            else
            {
                tipoComprobanteSeleccionado = ""; // Si es "Seleccionar", limpia el valor
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
            FrmVerProductos frm = new FrmVerProductos(false);
            frm.FormClosed += (s, args) =>
            {
                if (frm.ProductoSeleccionado != null)
                {
                    AgregarProductoDesdeOtroFormulario(frm.ProductoSeleccionado.Codigo,
                        frm.ProductoSeleccionado.Descripcion,frm.ProductoSeleccionado.PrecioUnitario);

                }
            };
            frm.ShowDialog();
        }
        public void AgregarProductoDesdeOtroFormulario(string codigoProducto, string descripcionProducto, decimal preciounitario)
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
                DataRow Fila = DtDetalle.NewRow();
                Fila["CodigoProducto"] = codigoProducto;
                Fila["DescripcionProducto"] = descripcionProducto;
                Fila["Lote"] = "LT-XXXX"; // Valor predeterminado
                Fila["Cantidad"] = 1; // Valor predeterminado
                Fila["PrecioCompra"] = preciounitario; // Valor predeterminado
                Fila["Observacion"] = "Sin observación"; // Valor predeterminado

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

        private void editarEntrada_Click(object sender, EventArgs e)
        {
            FrmEntradasver frm = new FrmEntradasver();
            frm.ShowDialog();
            nrodcomuento.Text = F_Variables.NroDocumento;
            txbReporteServicio.Text = F_Variables.ProveedorID.ToString();
            F_Variables.pruebatodox = F_Variables.ProveedorID.ToString();
            if (!string.IsNullOrWhiteSpace(nrodcomuento.Text))
            {
                CargarEntrada(nrodcomuento.Text);
                // Cambiar el texto del botón
                btnGuardarServicio.ButtonText = "Editar Entrada";
            }
            else
            {
                MessageBox.Show("Ingrese un número de documento válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CargarEntrada(string nroDocumento)
        {
            try
            {
                // Llama al método de negocio para obtener la entrada con sus detalles
                DataSet ds = objNegocio.ObtenerEntradaConDetalles(nroDocumento);

                if (ds.Tables.Count >= 2)
                {
                    // Tabla 0: Información principal de la entrada
                    DataTable entradaInfo = ds.Tables[0];
                    if (entradaInfo.Rows.Count > 0)
                    {
                        DataRow row = entradaInfo.Rows[0];
                        razonsocial.Text = row["Nombre"].ToString(); // Nombre del proveedor
                        ruc.Text = row["RUC"].ToString(); // RUC del proveedor
                        txbFecha.Text = Convert.ToDateTime(row["Fecha"]).ToString("dd-MM-yyyy"); // Fecha
                        cmbTipCompr.SelectedItem = row["Tipo_Comprobante"].ToString(); // Tipo de comprobante
                        txbNumCom.Text = row["Nro_Comprobante"].ToString(); // Número de comprobante
                        tipoDecambio.Text = row["TipoCambio"].ToString(); // Tipo de cambio
                        observaciontxb.Text = row["observacion"].ToString(); // Tipo de cambio

                    }

                    // Tabla 1: Detalles de la entrada
                    DataTable detalles = ds.Tables[1];
                    DtDetalle.Clear(); // Limpia la tabla de detalles
                    foreach (DataRow detalle in detalles.Rows)
                    {
                        DataRow fila = DtDetalle.NewRow();
                        fila["CodigoProducto"] = detalle["CodigoProducto"].ToString();
                        fila["DescripcionProducto"] = detalle["DescripcionProducto"].ToString();
                        fila["Lote"] = detalle["Lote"].ToString();
                        fila["Cantidad"] = Convert.ToInt32(detalle["Cantidad"]);
                        fila["PrecioCompra"] = Convert.ToDecimal(detalle["PrecioCompra"]);
                        fila["Observacion"] = detalle["Observacion"].ToString();
                        DtDetalle.Rows.Add(fila);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la entrada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void razonsocial_Click(object sender, EventArgs e)
        {

        }


        private bool ValidarStockProductos()
        {
            // Verificar si el proveedor es "Traslado Interno" o "Devolución a Proveedor"
            string proveedorSeleccionado = F_Variables.RUC;
            if (proveedorSeleccionado == "00000000000" || proveedorSeleccionado == "00000000007")
            {
                foreach (DataRow fila in DtDetalle.Rows)
                {
                    string codigoProducto = fila["CodigoProducto"].ToString();
                    // Obtener el stock actual del producto
                    int stockActual = objProductos.ObtenerStockActual(codigoProducto);

                    // Si el stock es 0, mostrar un mensaje de error
                    if (stockActual == 0)
                    {
                        MessageBox.Show($"El producto con código '{codigoProducto}' tiene stock 0, no se puede registrar un traslado interno o devolucion", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Indicar que la validación falló
                    }
                }
            }

            return true; // Si todos los productos tienen stock disponible, la validación pasa
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmAgregarProducto
            FrmAgregarProducto frm = new FrmAgregarProducto
            { 
                imagen = true,
                Update = false // Indica que es para agregar un nuevo producto
            };

            // Mostrar el formulario
            frm.ShowDialog();
        }
    }
}
