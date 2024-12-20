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
    public partial class FrmCategoria : Form
    {
        private string idcategoria;
        private bool editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close ();
        }

        private void Panelfrom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Paneltop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            mostrarbuscarTabla("");
            accionesTabla();
        }

        public void accionesTabla()
        {
            TablaCateogria.Columns[0].Width = 9;
            TablaCateogria.Columns[1].Width = 25;
            TablaCateogria.Columns[2].Width = 360;

            TablaCateogria.ClearSelection();
        }

        public void mostrarbuscarTabla(String buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            TablaCateogria.DataSource = objNegocio.ListandoCategoria(buscar);
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            mostrarbuscarTabla(txbBuscarCategoria.Text);
        }

        private void limpiarcajas()
        {
            editarse = false;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarcajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (TablaCateogria.SelectedRows.Count>0)
            {
                editarse = true;
                idcategoria = TablaCateogria.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = TablaCateogria.CurrentRow.Cells[1].Value.ToString();
                txtDescripcion.Text= TablaCateogria.CurrentRow.Cells[2].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editarse==false)
            {
                try
                {
                    objEntidad.Nombre_cat = txtNombre.Text.ToUpper();
                    objEntidad.Descripcion_cat = txtDescripcion.Text.ToUpper();
                    objNegocio.insertandoCategoria(objEntidad);

                    FrmSuccess.confimarcionForm("GUARDADO");
                    mostrarbuscarTabla("");
                    limpiarcajas();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro"+ ex);
                }
            }
            if (editarse == true)
            {
                try
                {
                    objEntidad.Idcategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombre_cat = txtNombre.Text.ToUpper();
                    objEntidad.Descripcion_cat = txtDescripcion.Text.ToUpper();

                    objNegocio.editandoCategoria(objEntidad);
                    FrmSuccess.confimarcionForm("EDITADO");
                    mostrarbuscarTabla("");
                    limpiarcajas();
                    editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resutlado = new DialogResult();
                FrmInformation frm = new FrmInformation("¿ESTAS SEGURO QUE DESEAS ELIMINAR EL REGISTRO?");
                 resutlado=frm.ShowDialog();

                if (resutlado==DialogResult.OK)
                {
                    objEntidad.Idcategoria = Convert.ToInt32(TablaCateogria.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.eliminandoCategoria(objEntidad);

                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrarbuscarTabla("");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Seleccione la fila que deseas eliminar"+ex);
            }

        }

        private void TablaCateogria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
