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

    public partial class FrmProveedores : Form
    {
        private N_Proveedores objNegocio = new N_Proveedores();
        private bool mostrandoActivos = true; // Indica si estamos mostrando proveedores activos
        N_Productoss objNegocios = new N_Productoss();
        N_Clientes indicadores = new N_Clientes();
        public FrmProveedores()
        {
            InitializeComponent();
      

            TablaPROVEEDORES.DataBindingComplete += TablaPROVEEDORES_DataBindingComplete;
            TablaPROVEEDORES.DefaultCellStyle.Font = new Font("Arial", 9);
            TablaPROVEEDORES.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            ConfigurarCabeceraTabla(TablaPROVEEDORES); // Aplica la configuración de la cabecera

            lblsestado.Text = "Proveedores Activos";
            MostrarProveedoresActivos();
            CargarIndicadores();

    }

        private void TablaCLIENTES_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigurarTablaProveedore();
            Console.WriteLine("ConfigurarTablaProveedore ejecutado");

        }


        public void ConfigurarCabeceraTabla(DataGridView tabla)
        {
            tabla.EnableHeadersVisualStyles = false; // Permite personalizar el estilo de las cabeceras
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Color de fondo de la cabecera
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color del texto de la cabecera
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11); // Fuente de la cabecera
            tabla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Alineación del texto
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Permitir redimensionar la altura
            tabla.ColumnHeadersHeight = 35; // Altura de la cabecera
        }


        public void MostrarProveedoresActivos()
        {
            mostrandoActivos = true;
            lblsestado.Text = "Proveedores Activos";

            var proveedoresActivos = objNegocio.ConsultarProveedores(estado: true);

            if (proveedoresActivos != null && proveedoresActivos.Rows.Count > 0)
            {
                TablaPROVEEDORES.DataSource = proveedoresActivos;
                ConfigurarTablaProveedore(); // Asegúrate de llamar al método aquí
            }
            else
            {
                TablaPROVEEDORES.DataSource = null;
                MessageBox.Show("No hay proveedores activos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Btnoinahbilitados.ButtonText = "Mostrar Inhabilitados";
        }

        public void MostrarProveedoresInactivos()
        {
            mostrandoActivos = false;
            lblsestado.Text = "Proveedores Inactivos";

            var proveedoresInactivos = objNegocio.ConsultarProveedores(estado: false);

            if (proveedoresInactivos != null && proveedoresInactivos.Rows.Count > 0)
            {
                TablaPROVEEDORES.DataSource = proveedoresInactivos;
                ConfigurarTablaProveedore(); // Llama aquí también
            }
            else
            {
                TablaPROVEEDORES.DataSource = null;
                MessageBox.Show("No hay proveedores inactivos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Btnoinahbilitados.ButtonText = "Mostrar Habilitados";
        }

        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarProveedor(txbBuscarProducto.Text);
        }





        public void BuscarProveedor(string valor)
        {
            // Si la caja de texto está vacía, no aplica ningún filtro, muestra todos los registros según el estado (activos/inactivos)
            if (string.IsNullOrEmpty(valor))
            {
                TablaPROVEEDORES.DataSource = objNegocio.ConsultarProveedores(estado: mostrandoActivos);
            }
            else
            {
                // Si hay texto, buscar por RUC, Nombre y Dirección (o cualquier otro campo relevante)
                TablaPROVEEDORES.DataSource = objNegocio.ConsultarProveedores(
                    filtroGeneral: valor,    // Filtrar por RUC, Nombre o Dirección
                    estado: mostrandoActivos // Filtrar por el estado (activo/inactivo)
                );
            }

            ConfigurarTablaProveedore(); // Reconfigurar después de la búsqueda
        }
        public void ConfigurarTablaProveedore()
        {
            if (TablaPROVEEDORES.Columns.Count == 0) return;

            // Configurar columnas existentes
            if (TablaPROVEEDORES.Columns.Contains("ProveedorID"))
                TablaPROVEEDORES.Columns["ProveedorID"].Visible = false; // Ocultar ProveedorID

            if (TablaPROVEEDORES.Columns.Contains("Estado"))
                TablaPROVEEDORES.Columns["Estado"].Visible = false; // Ocultar Estado

            if (TablaPROVEEDORES.Columns.Contains("RUC"))
            {
                TablaPROVEEDORES.Columns["RUC"].HeaderText = "RUC";
                TablaPROVEEDORES.Columns["RUC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Llenar espacio disponible
            }

            if (TablaPROVEEDORES.Columns.Contains("Nombre"))
            {
                TablaPROVEEDORES.Columns["Nombre"].HeaderText = "Nombre";
                TablaPROVEEDORES.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (TablaPROVEEDORES.Columns.Contains("Direccion"))
            {
                TablaPROVEEDORES.Columns["Direccion"].HeaderText = "Dirección";
                TablaPROVEEDORES.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (TablaPROVEEDORES.Columns.Contains("Telefono"))
            {
                TablaPROVEEDORES.Columns["Telefono"].HeaderText = "Teléfono";
                TablaPROVEEDORES.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Ajustar al contenido
            }

            if (TablaPROVEEDORES.Columns.Contains("Email"))
            {
                TablaPROVEEDORES.Columns["Email"].HeaderText = "Email";
                TablaPROVEEDORES.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Agregar columna de "Editar" si no existe
            if (!TablaPROVEEDORES.Columns.Contains("EDITAR"))
            {
                DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn
                {
                    Name = "EDITAR",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 80 // Ancho fijo
                };
                TablaPROVEEDORES.Columns.Add(editarColumna);
            }

            // Agregar columna de "Estado" (Ocultar/Desocultar)
            if (!TablaPROVEEDORES.Columns.Contains("ELIMINAR"))
            {
                DataGridViewButtonColumn eliminarColumna = new DataGridViewButtonColumn
                {
                    Name = "ELIMINAR",
                    HeaderText = "Estado",
                    Text = mostrandoActivos ? "Ocultar" : "Desocultar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 100 // Ancho fijo
                };
                TablaPROVEEDORES.Columns.Add(eliminarColumna);
            }
            else
            {
                // Cambiar dinámicamente el texto del botón existente
                ((DataGridViewButtonColumn)TablaPROVEEDORES.Columns["ELIMINAR"]).Text = mostrandoActivos ? "Ocultar" : "Desocultar";
            }

            // Configurar posición de columnas
            if (TablaPROVEEDORES.Columns.Contains("EDITAR"))
                TablaPROVEEDORES.Columns["EDITAR"].DisplayIndex = TablaPROVEEDORES.Columns.Count - 2;

            if (TablaPROVEEDORES.Columns.Contains("ELIMINAR"))
                TablaPROVEEDORES.Columns["ELIMINAR"].DisplayIndex = TablaPROVEEDORES.Columns.Count - 1;

            // Configurar modo de ajuste automático de todas las columnas
            TablaPROVEEDORES.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarIndicadores()
        {

            try
            {

                // Opción 1: Total de proveedores activos sin ID 3 y 7
                int totalProveedoresActivos = objNegocio.ContarProveedoresActivos();
                lblProveedoresActivos.Text = totalProveedoresActivos.ToString();
                MostrarProductoConMasEntradas();
                // Opción 2: Último proveedor registrado
                DataTable ultimoProveedorRegistrado = objNegocio.ObtenerUltimoProveedorRegistrado();
                if (ultimoProveedorRegistrado.Rows.Count > 0)
                {
                    string nombreProveedor = ultimoProveedorRegistrado.Rows[0]["UltimoProveedorRegistrado"].ToString();
                    lblUltimoProveedorRegistrado.Text =nombreProveedor.ToString();
                }
                else
                {
                    lblUltimoProveedorRegistrado.Text = "Sin datos disponibles";
                }
                lblproducbajostock.Text = indicadores.ObtenerProductosBajoStock(10).ToString(); // Stock mínimo = 10

                // Opción 3: Total de proveedores inactivos sin ID 3 y 7
                int totalProveedoresInactivos = objNegocio.ContarProveedoresInactivos();
                lblProveedoresInactivos.Text = totalProveedoresInactivos.ToString();

                // Opción 4: Proveedor con más entradas durante este mes
                DataTable dtProveedorMasEntradas = objNegocio.ObtenerProveedorConMasEntradas();
                if (dtProveedorMasEntradas.Rows.Count > 0)
                {
                    string nombreProveedor = dtProveedorMasEntradas.Rows[0]["ProveedorConMasEntradas"].ToString();
                    string totalEntradas = dtProveedorMasEntradas.Rows[0]["TotalProductos"].ToString();
                    lblProveedorMasEntradas.Text = $"{nombreProveedor} ({totalEntradas} productos)";
                }
                else
                {
                    lblProveedorMasEntradas.Text = " Sin datos disponibles";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar indicadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarProductoConMasEntradas()
        {
            DataTable dt = objNegocios.ObtenerProductoConMasEntradas();

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


        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            // Cambiar el tamaño del panel a un ancho de 800 y una altura de 600
            panel9.Width = 1300;
            panel9.Height = 600;
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            FrmAgregarProve frm = new FrmAgregarProve
            {
                Update = false // Indica que es para agregar un proveedor nuevo
            };
            frm.ShowDialog();
            MostrarProveedoresActivos(); // Actualiza la lista después de agregar
            CargarIndicadores();
        }

        private void Btnoinahbilitados_Click(object sender, EventArgs e)
        {
            if (mostrandoActivos)
            {
                MostrarProveedoresInactivos(); // Cambiar a mostrar proveedores inhabilitados
            }
            else
            {
                MostrarProveedoresActivos(); // Cambiar a mostrar proveedores activos
            }
        }
        private void TablaPROVEEDORES_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigurarTablaProveedore();
        }

        private void TablaPROVEEDORES_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no sea el encabezado
            {
                if (TablaPROVEEDORES.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    int proveedorID = Convert.ToInt32(TablaPROVEEDORES.Rows[e.RowIndex].Cells["ProveedorID"].Value);
                    bool nuevoEstado = mostrandoActivos ? false : true; // Alterna entre habilitar y deshabilitar

                    DialogResult resultado = MessageBox.Show(
                        nuevoEstado ? "¿Estás seguro de habilitar este proveedor?" : "¿Estás seguro de deshabilitar este proveedor?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    CargarIndicadores();
                    if (resultado == DialogResult.Yes)
                    {
                        objNegocio.CambiarEstadoProveedor(proveedorID, nuevoEstado);
                        objNegocio.GenerarScriptOcultarProveedor(proveedorID, nuevoEstado);
                        MessageBox.Show(
                            nuevoEstado ? "Proveedor habilitado exitosamente." : "Proveedor deshabilitado exitosamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information

                        );

                        if (mostrandoActivos)
                            MostrarProveedoresActivos();
                        else
                            MostrarProveedoresInactivos();
                        CargarIndicadores();
                    }
                }
                else if (TablaPROVEEDORES.Columns[e.ColumnIndex].Name == "EDITAR")
                {
                    if (!mostrandoActivos) // Si estamos mostrando inactivos
                    {
                        MessageBox.Show("No se puede editar un proveedor inactivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir del método para no realizar ninguna acción
                    }

                    FrmAgregarProve frm = new FrmAgregarProve
                    {
                        Update = true
                    };

                    // Rellenar los campos del formulario con la fila seleccionada
                    frm.txtProveedorID = TablaPROVEEDORES.Rows[e.RowIndex].Cells["ProveedorID"].Value.ToString();
                    frm.txtdniruc.Text = TablaPROVEEDORES.Rows[e.RowIndex].Cells["RUC"].Value.ToString();
                    frm.txtnombre.Text = TablaPROVEEDORES.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    frm.txtdireccionx.Text = TablaPROVEEDORES.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                    frm.txttelefono.Text = TablaPROVEEDORES.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    frm.txtemail.Text = TablaPROVEEDORES.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                    frm.ShowDialog();

                    if (mostrandoActivos)
                        MostrarProveedoresActivos();
                    else
                        MostrarProveedoresInactivos();
                    CargarIndicadores();
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    
}

