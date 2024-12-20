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
        N_Productos objNegocio = new N_Productos();

        public frmProductos()

        {

            InitializeComponent();
            mostrartablaProductos();
            accionestabla();
            totalproductos();
        }

        public void totalproductos()
        {
            E_Productos entidades = new E_Productos();
            N_Productos negocio = new N_Productos();
            negocio.sumarTotal(entidades);
            lblCategoria.Text = entidades.TotalCategoria;
            lblProductos.Text = entidades.TotalProductos;
            lblStock.Text = entidades.Totalstock;
        }


        private void TablaPRODUCTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TablaPRODUCTOS.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {


                Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL PRODUCTO?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(TablaPRODUCTOS.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objNegocio.eliminandoProductos(eliminar);
                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrartablaProductos();
                    totalproductos();
                }
            }

            else if (TablaPRODUCTOS.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmAgregarProducto frm = new FrmAgregarProducto();
                frm.Update = true;
                frm.txtIdProducto.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                frm.txtCodigox.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                frm.txtNombreProducto.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                frm.txtPrecio.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                frm.txtStocP.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                frm.txtMarca.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["nombre_marca"].Value.ToString();
                frm.txtImagen.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["imagen_pro"].Value.ToString();
                frm.txtDescripcion.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["descripcion_pro"].Value.ToString();
                frm.cmbCategoria.Text = TablaPRODUCTOS.Rows[e.RowIndex].Cells["nombrecat"].Value.ToString();
                frm.ShowDialog();
                mostrartablaProductos();
                totalproductos();

            }

        }
        public void mostrartablaProductos()
        {
            N_Productos objNegocio = new N_Productos();
            TablaPRODUCTOS.DataSource = objNegocio.listandoproductos();
        }

        private void txbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            buscarProducto(txbBuscarProducto.Text);
        }

        public void accionestabla()
        {
            TablaPRODUCTOS.Columns[2].Visible = false;
            TablaPRODUCTOS.Columns[5].Visible = false;
            TablaPRODUCTOS.Columns[8].Visible = false;
            TablaPRODUCTOS.Columns[9].Visible = false;

            TablaPRODUCTOS.Columns[0].DisplayIndex = 11;
            TablaPRODUCTOS.Columns[1].DisplayIndex =11;
        }

        public void buscarProducto(string buscarpro)
        {
            N_Productos objNegocio = new N_Productos();
            TablaPRODUCTOS.DataSource = objNegocio.buscandoproductos(buscarpro);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frm = new FrmAgregarProducto();
            frm.ShowDialog();
            frm.Update = false;
            mostrartablaProductos();
            totalproductos();
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.ShowDialog();
            totalproductos();
        }
    }
}
