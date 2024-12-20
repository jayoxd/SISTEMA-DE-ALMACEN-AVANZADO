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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FrmRolesver : Form
    {
        
        N_rol objnegocio = new N_rol();
        N_Usuario objuser = new N_Usuario();

        public FrmRolesver()
        {
            InitializeComponent();
            mostrarempleado();
        accionestabla();
            

        }



        public void mostrarempleado()
        {
            N_Usuario objNegocio = new N_Usuario();
            TablaUsuarios.DataSource = objNegocio.listandoEmpleados();
            lbltrabajadores.Text =  Convert.ToString(TablaUsuarios.RowCount);
            F_Variables.sumaremple = lbltrabajadores.Text;
        }


        public void accionestabla()
        {


            //

            //
            TablaUsuarios.Columns[3].Visible = false;

            TablaUsuarios.Columns[2].Visible = false;
            TablaUsuarios.Columns[0].DisplayIndex = 10;
            TablaUsuarios.Columns[1].DisplayIndex = 10;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado frm = new frmAgregarEmpleado();
            frm.ShowDialog();
            frm.Update = false;
            mostrarempleado();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FrmVerrolesCOmpletos frm = new FrmVerrolesCOmpletos();
            frm.ShowDialog();
        }

        public void buscarUsuario(string buscaremp)
        {
            N_Usuario objNegocio = new N_Usuario();
            TablaUsuarios.DataSource = objNegocio.buscandoEmpleado(buscaremp);
        }

        private void txbBuscarempleado_TextChanged(object sender, EventArgs e)
        {
            buscarUsuario(txbBuscarempleado.Text);
        }

        private void TablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TablaUsuarios.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {


                Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL UN EMPLEADO?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(TablaUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objuser.eliminandoEmpleado(eliminar);
                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrarempleado();

                    //totalclientestodo();
                }
            }

            else if (TablaUsuarios.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                frmAgregarEmpleado frm = new frmAgregarEmpleado();
                frm.Update = true;
                frm.txtIdEmpleado.Text = TablaUsuarios.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString();
                frm.cmbROLES.Text= TablaUsuarios.Rows[e.RowIndex].Cells["nombre_rol"].Value.ToString();
                frm.txtNombreEM.Text = TablaUsuarios.Rows[e.RowIndex].Cells["nombre_emp"].Value.ToString();
                frm.txtTipoDocumen.Text = TablaUsuarios.Rows[e.RowIndex].Cells["tipo_documento_emp"].Value.ToString();
                frm.txtNmrDocemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["num_documento_emp"].Value.ToString();
                frm.txtDireccionemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["direccion_emp"].Value.ToString();
                frm.txtTelefonoEM.Text = TablaUsuarios.Rows[e.RowIndex].Cells["telefono_emp"].Value.ToString();
                frm.txtEmailemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["email"].Value.ToString();
                frm.ShowDialog();
                mostrarempleado();



            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
