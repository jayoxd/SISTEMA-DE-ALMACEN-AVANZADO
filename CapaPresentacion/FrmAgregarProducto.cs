using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class FrmAgregarProducto : Form
    {
        frmProductos frm = new frmProductos();
        E_Productos entidades = new E_Productos();
        N_Productos negocio = new N_Productos();

        public  bool Update = false;
         

        public FrmAgregarProducto()
        {
            InitializeComponent();
            listar_categoriass();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        public void listar_categoriass()
        { 
            N_Categoria objeto = new N_Categoria();
            cmbCategoria.DataSource = objeto.ListandoCategoria("");
            cmbCategoria.ValueMember = "Idcategoria";
            cmbCategoria.DisplayMember = "Nombre_cat";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarProductosx_Click(object sender, EventArgs e)
        {
             if (Update == false)
            {
                try
                {

                    if (txtNombreProducto.Text==string.Empty||txtPrecio.Text==string.Empty||txtStocP.Text==string.Empty||cmbCategoria.ValueMember==string.Empty||
                        txtDescripcion.Text==string.Empty||txtMarca.Text==string.Empty||txtImagen.Text==string.Empty)
                    {
                        FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                    }
                    else
                    {
                        entidades.Nombre_pro = txtNombreProducto.Text;
                        entidades.Precio_venta = Convert.ToDecimal(txtPrecio.Text);
                        entidades.Stock_pro = Convert.ToInt32(txtStocP.Text);
                        entidades.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                        entidades.Descripcion_pro = txtDescripcion.Text;
                        entidades.Marca_pro = txtMarca.Text;
                        entidades.Imagen_pro = txtImagen.Text;

                        negocio.insertandoproductos(entidades);
                        FrmSuccess.confimarcionForm("PRODUCTO AGREGADO");
                        Close();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            if (Update == true)
            {
                try
                {
                    entidades.Idproducto = Convert.ToInt32(txtIdProducto.Text);
                    entidades.Nombre_pro = txtNombreProducto.Text;
                    entidades.Precio_venta = Convert.ToDecimal(txtPrecio.Text);
                    entidades.Stock_pro = Convert.ToInt32(txtStocP.Text);
                    entidades.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    entidades.Descripcion_pro = txtDescripcion.Text;
                    entidades.Marca_pro = txtMarca.Text;
                    entidades.Imagen_pro = txtImagen.Text;

                    negocio.editandoProducto(entidades);
                    FrmSuccess.confimarcionForm("PRODUCTO EDITADO");
                    Close();
                    Update = false;
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el producto" + ex);
                } 
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
