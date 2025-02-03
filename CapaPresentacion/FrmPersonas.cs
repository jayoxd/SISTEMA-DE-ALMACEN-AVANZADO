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

    public partial class FrmPersonas : Form
    {
        private N_Clientes objNegocio = new N_Clientes();
        private bool mostrandoActivos = true; // Indica si estamos mostrando clientes activos
        N_Clientes indicadores = new N_Clientes();
        N_Productoss objNegocios = new N_Productoss();

        public FrmPersonas()
        {
            InitializeComponent();
            TablaCLIENTES.DataBindingComplete += TablaCLIENTES_DataBindingComplete;
            TablaCLIENTES.DefaultCellStyle.Font = new Font("Arial", 9);
            TablaCLIENTES.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 19);
            lblsestado.Text = "Clientes Activos"; // Inicializar el estado
            ConfigurarCabeceraTabla(TablaCLIENTES); // Aplica la configuración de la cabecera
            CargarIndicadores();

            MostrarClientesActivos(); // Carga inicial de clientes activos
        }

        private void TablaCLIENTES_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigurarTablaClientes();
        }




        public void MostrarClientesActivos()
        {
            mostrandoActivos = true; // Cambia el estado a mostrando activos
            lblsestado.Text = "Clientes Activos"; // Actualiza el texto del estado

            var clientesActivos = objNegocio.ConsultarClientes(estado: true);

            if (clientesActivos != null && clientesActivos.Rows.Count > 0)
            {
                TablaCLIENTES.DataSource = clientesActivos;
            }
            else
            {
                TablaCLIENTES.DataSource = null;
                MessageBox.Show("No hay clientes activos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ConfigurarTablaClientes();

            Btnoinahbilitados.ButtonText = "Mostrar Inhabilitados"; // Cambiar texto del botón
        }




        public void MostrarClientesInactivos()
        {
            mostrandoActivos = false; // Cambia el estado a mostrando inactivos
            lblsestado.Text = "Clientes Inactivos"; // Actualiza el texto del estado

            var clientesInactivos = objNegocio.ConsultarClientes(estado: false);

            if (clientesInactivos != null && clientesInactivos.Rows.Count > 0)
            {
                TablaCLIENTES.DataSource = clientesInactivos;
            }
            else
            {
                TablaCLIENTES.DataSource = null;
                MessageBox.Show("No hay clientes inactivos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ConfigurarTablaClientes();

            Btnoinahbilitados.ButtonText = "Mostrar Habilitados"; // Cambiar texto del botón
        }
        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente(txbBuscarProducto.Text);
        }





        public void BuscarCliente(string valor)
        {
            // Si la caja de texto está vacía, no aplica ningún filtro, muestra todos los registros según el estado (activos/inactivos)
            if (string.IsNullOrEmpty(valor))
            {
                TablaCLIENTES.DataSource = objNegocio.ConsultarClientes(estado: mostrandoActivos);
            }
            else
            {
                // Si hay texto, buscar por nombre, DNI y teléfono (o cualquier otro campo relevante)
                TablaCLIENTES.DataSource = objNegocio.ConsultarClientes(
                    filtro: valor,    // Filtrar por nombre
                    estado: mostrandoActivos // Filtrar por el estado (activo/inactivo)
                );
            }

            ConfigurarTablaClientes(); // Reconfigurar después de la búsqueda
        }

        private void CargarIndicadores()
        {
            try
            {
                // Opción 1: Total de clientes activos
                int totalClientesActivos = objNegocio.ContarClientesActivos();
                lblClientesActivos.Text = totalClientesActivos.ToString();
                // Opción 2: Último cliente registrado
                DataTable dtUltimoCliente = objNegocio.ObtenerUltimoClienteRegistrado();
                if (dtUltimoCliente.Rows.Count > 0)
                {
                    string ultimoClienteRegistrado = dtUltimoCliente.Rows[0]["UltimoClienteRegistrado"].ToString();
                    lblUltimoClienteRegistrado.Text =ultimoClienteRegistrado;
                }
                else
                {
                    lblUltimoClienteRegistrado.Text = "Sin datos disponibles";
                }
                lblproducbajostock.Text = indicadores.ObtenerProductosBajoStock(10).ToString(); // Stock mínimo = 10
                lblProductosHabilitados.Text = objNegocios.ContarProductosHabilitados().ToString();
                // Opción 3: Total de clientes inactivos
                int totalClientesInactivos = objNegocio.ContarClientesInactivos();
                lblClientesInactivos.Text = totalClientesInactivos.ToString();

                // Opción 4: Cliente con más salidas
                DataTable dtClienteMasSalidas = objNegocio.ObtenerClienteConMasSalidas();
                if (dtClienteMasSalidas.Rows.Count > 0)
                {
                    string nombreCliente = dtClienteMasSalidas.Rows[0]["ClienteConMasSalidas"].ToString();
                    string totalProductos = dtClienteMasSalidas.Rows[0]["TotalProductos"].ToString();
                    lblClienteMasSalidas.Text = $"{nombreCliente} ({totalProductos} productos)";
                }
                else
                {
                    lblClienteMasSalidas.Text = "Sin datos disponibles";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar indicadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void ConfigurarTablaClientes()
        {
            if (TablaCLIENTES.Columns.Count == 0) return;
            // Configurar la tabla para ajustarse al tamaño del contenedor
            TablaCLIENTES.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta automáticamente el tamaño de las columnas
            TablaCLIENTES.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; // Ajusta las filas automáticamente

            // Configurar columnas existentes
            if (TablaCLIENTES.Columns.Contains("ClienteID"))
                TablaCLIENTES.Columns["ClienteID"].Visible = false; // Ocultar ClienteID

            if (TablaCLIENTES.Columns.Contains("Estado"))
                TablaCLIENTES.Columns["Estado"].Visible = false; // Ocultar Estado

            if (TablaCLIENTES.Columns.Contains("DNI"))
            {
                TablaCLIENTES.Columns["DNI"].HeaderText = "DNI/RUC"; // Cambiar el nombre de la cabecera
                TablaCLIENTES.Columns["DNI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("Nombre"))
            {
                TablaCLIENTES.Columns["Nombre"].HeaderText = "Nombre";
                TablaCLIENTES.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("Direccion"))
            {
                TablaCLIENTES.Columns["Direccion"].HeaderText = "Dirección";
                TablaCLIENTES.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("origencliente"))
            {
                TablaCLIENTES.Columns["origencliente"].HeaderText = "Tipo"; // Cambiar el nombre de la cabecera
                TablaCLIENTES.Columns["origencliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("departamento"))
            {
                TablaCLIENTES.Columns["departamento"].HeaderText = "Departamento";
                TablaCLIENTES.Columns["departamento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("provincia"))
            {
                TablaCLIENTES.Columns["provincia"].HeaderText = "Provincia";
                TablaCLIENTES.Columns["provincia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            if (TablaCLIENTES.Columns.Contains("distrito"))
            {
                TablaCLIENTES.Columns["distrito"].HeaderText = "Distrito";
                TablaCLIENTES.Columns["distrito"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            // Configurar la columna de Google Maps como hipervínculo
            if (TablaCLIENTES.Columns.Contains("GoogleMaps"))
            {
                TablaCLIENTES.Columns.Remove("GoogleMaps"); // Eliminar la columna existente si está
            }

            DataGridViewLinkColumn linkColumna = new DataGridViewLinkColumn
            {
                Name = "GoogleMaps",
                HeaderText = "Google Maps",
                DataPropertyName = "GoogleMaps",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                LinkColor = Color.Blue, // Color del enlace
                ActiveLinkColor = Color.Red, // Color al hacer clic
                VisitedLinkColor = Color.Purple, // Color después de visitar
                UseColumnTextForLinkValue = false // Mostrar el valor de la celda como enlace
            };
            TablaCLIENTES.Columns.Add(linkColumna);

            // Agregar columna de "Editar" si no existe
            if (!TablaCLIENTES.Columns.Contains("EDITAR"))
            {
                DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn
                {
                    Name = "EDITAR",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 60
                };
                TablaCLIENTES.Columns.Add(editarColumna);
            }

            // Agregar columna de "Estado" (Ocultar/Desocultar)
            if (!TablaCLIENTES.Columns.Contains("ELIMINAR"))
            {
                DataGridViewButtonColumn eliminarColumna = new DataGridViewButtonColumn
                {
                    Name = "ELIMINAR",
                    HeaderText = "Estado", // Cambiar el encabezado a "Estado"
                    Text = mostrandoActivos ? "Ocultar" : "Desocultar", // Cambiar dinámicamente el texto
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 80
                };
                TablaCLIENTES.Columns.Add(eliminarColumna);
            }
            else
            {
                // Cambiar dinámicamente el texto del botón existente
                ((DataGridViewButtonColumn)TablaCLIENTES.Columns["ELIMINAR"]).Text = mostrandoActivos ? "Ocultar" : "Desocultar";
            }

            // Configurar posición de columnas
            if (TablaCLIENTES.Columns.Contains("GoogleMaps"))
                TablaCLIENTES.Columns["GoogleMaps"].DisplayIndex = TablaCLIENTES.Columns.Count - 3;

            if (TablaCLIENTES.Columns.Contains("EDITAR"))
                TablaCLIENTES.Columns["EDITAR"].DisplayIndex = TablaCLIENTES.Columns.Count - 2;

            if (TablaCLIENTES.Columns.Contains("ELIMINAR"))
                TablaCLIENTES.Columns["ELIMINAR"].DisplayIndex = TablaCLIENTES.Columns.Count - 1;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            // Cambiar el tamaño del panel a un ancho de 800 y una altura de 600
            panel9.Width = 1300;
            panel9.Height = 600;
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            FrmAgregarClientes frm = new FrmAgregarClientes
            {
                Update = false // Indica que es para agregar un cliente nuevo
            };
            frm.ShowDialog();
            MostrarClientesActivos(); // Actualiza la lista después de agregar
            CargarIndicadores();

        }

        private void Btnoinahbilitados_Click(object sender, EventArgs e)
        {


            if (mostrandoActivos)
            {
                MostrarClientesInactivos(); // Cambiar a mostrar clientes inhabilitados
            }
            else
            {
                MostrarClientesActivos(); // Cambiar a mostrar clientes activos
            }
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


        private void TablaCLIENTES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0) // Verificar que no sea el encabezado
                {
                    // Deshabilitar el desplazamiento horizontal temporalmente
                    panel9.HorizontalScroll.Enabled = false;

                    string url = TablaCLIENTES.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    if (!string.IsNullOrEmpty(url))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true // Abrir en el navegador predeterminado
                            });
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (TablaCLIENTES.Columns[e.ColumnIndex].Name == "ELIMINAR")
                    {
                        int clienteID = Convert.ToInt32(TablaCLIENTES.Rows[e.RowIndex].Cells["ClienteID"].Value);
                        bool nuevoEstado = mostrandoActivos ? false : true; // Alterna entre habilitar y deshabilitar

                        DialogResult resultado = MessageBox.Show(
                            nuevoEstado ? "¿Estás seguro de habilitar este cliente?" : "¿Estás seguro de deshabilitar este cliente?",
                            "Confirmación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question

                        );
                        CargarIndicadores();
                        if (resultado == DialogResult.Yes)
                        {
                            objNegocio.CambiarEstadoCliente(clienteID, nuevoEstado);
                            MessageBox.Show(
                                nuevoEstado ? "Cliente habilitado exitosamente." : "Cliente deshabilitado exitosamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            CargarIndicadores();
                            if (mostrandoActivos)
                                MostrarClientesActivos();
                            else
                                MostrarClientesInactivos();
                        }
                    }
                    else if (TablaCLIENTES.Columns[e.ColumnIndex].Name == "EDITAR")
                    {
                        FrmAgregarClientes frm = new FrmAgregarClientes
                        {
                            Update = true
                        };
                        frm.txtClienteID = TablaCLIENTES.Rows[e.RowIndex].Cells["ClienteID"].Value.ToString();
                        frm.txtdniruc.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                        frm.txtnombre.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                        frm.txtdireccionx.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                        frm.txttelefono.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                        frm.txtemail.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        frm.cmbtipocliente.SelectedItem = TablaCLIENTES.Rows[e.RowIndex].Cells["origencliente"].Value.ToString();
                        frm.txtdepart.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Departamento"].Value.ToString();
                        frm.txtprovincia.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Provincia"].Value.ToString();
                        frm.txtdistrito.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["Distrito"].Value.ToString();
                        frm.txtlinkgoogle.Text = TablaCLIENTES.Rows[e.RowIndex].Cells["GoogleMaps"].Value.ToString();
                        frm.ShowDialog();

                        if (mostrandoActivos)
                            MostrarClientesActivos();

                        else
                            MostrarClientesInactivos();
                        CargarIndicadores();
                    }
                    // Habilitar el scroll nuevamente después de la acción
                    panel9.HorizontalScroll.Enabled = true;
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblProductosHabilitados_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          
       //     flowLayoutPanel1.Width = 1545;
        }

        private void FrmPersonas_Load(object sender, EventArgs e)
        {

        }
    }
}
