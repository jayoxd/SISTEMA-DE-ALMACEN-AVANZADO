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

    public partial class FrmStock : Form
    {
        N_Productoss objNegocio = new N_Productoss();
        private bool mostrandoActivos = true; // Indica si estamos mostrando productos activos

        public FrmStock()
        {
            InitializeComponent();

            TablaPRODUCTOS.DataBindingComplete += TablaPRODUCTOS_DataBindingComplete;
            TablaPRODUCTOS.DefaultCellStyle.Font = new Font("Arial", 9); // Tamaño 10, fuente Arial
            TablaPRODUCTOS.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 80); // Encabezados en negrita

            MostrarProductosActivos(); // Carga inicial de productos activos
        }

        private void TablaPRODUCTOS_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Configurar las columnas solo cuando las columnas están listas
            ConfigurarTablaProductos();
        }

        private void TablaPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TablaPRODUCTOS.Columns[e.ColumnIndex].Name == "ELIMINAR")
            {
                Form mensaje = new FrmInformation("¿ESTÁS SEGURO DE OCULTAR EL PRODUCTO?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    string codigoProducto = TablaPRODUCTOS.Rows[e.RowIndex].Cells["CodigoProducto"].Value.ToString();
                    objNegocio.OcultarProducto(codigoProducto);
                    FrmSuccess.confimarcionForm("OCULTADO");
                    MostrarProductosActivos();
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


                // Seleccionar el valor correspondiente en el combo box "estado"
                bool estadoProducto = Convert.ToBoolean(TablaPRODUCTOS.Rows[e.RowIndex].Cells["Estado"].Value);
                frm.cmbestado.SelectedItem = estadoProducto ? "Activo" : "Inactivo";

                // Asignar la categoría si existe
                string categoria = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                frm.categoria.Text = categoria;

                frm.ShowDialog();
                MostrarProductosActivos();
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
        }

        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto(txbBuscarProducto.Text);
        }

        public void ConfigurarTablaProductos()
        {
            if (TablaPRODUCTOS.Columns.Count == 0) return;

            if (TablaPRODUCTOS.Columns.Contains("CodigoProducto"))
            {
                TablaPRODUCTOS.Columns["CodigoProducto"].Width = 170;
                TablaPRODUCTOS.Columns["CodigoProducto"].DisplayIndex = 0;
            }
            if (TablaPRODUCTOS.Columns.Contains("DescripcionProducto"))
            {
                TablaPRODUCTOS.Columns["DescripcionProducto"].Width = 550;
                TablaPRODUCTOS.Columns["DescripcionProducto"].DisplayIndex = 1;
            }
            if (TablaPRODUCTOS.Columns.Contains("Categoria"))
            {
                TablaPRODUCTOS.Columns["Categoria"].Width = 100;
                TablaPRODUCTOS.Columns["Categoria"].DisplayIndex = 2;
            }
            if (TablaPRODUCTOS.Columns.Contains("PrecioUnitario"))
            {
                TablaPRODUCTOS.Columns["PrecioUnitario"].Width = 90;
                TablaPRODUCTOS.Columns["PrecioUnitario"].DisplayIndex = 3;
            }
            if (TablaPRODUCTOS.Columns.Contains("StockActual"))
            {
                TablaPRODUCTOS.Columns["StockActual"].Width = 80;
                TablaPRODUCTOS.Columns["StockActual"].DisplayIndex = 4;
            }

            if (TablaPRODUCTOS.Columns.Contains("Estado"))
            {
                TablaPRODUCTOS.Columns["Estado"].Visible = false;
            }

            if (!TablaPRODUCTOS.Columns.Contains("EDITAR"))
            {
                DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn
                {
                    Name = "EDITAR",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactivar ajuste automático
                };
                TablaPRODUCTOS.Columns.Add(editarColumna);
            }

            if (!TablaPRODUCTOS.Columns.Contains("ELIMINAR"))
            {
                DataGridViewButtonColumn eliminarColumna = new DataGridViewButtonColumn
                {
                    Name = "ELIMINAR",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None // Desactivar ajuste automático
                };
                TablaPRODUCTOS.Columns.Add(eliminarColumna);
            }


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
    }
}
