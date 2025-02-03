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
    public partial class FrmVerrolesCOmpletos : Form
    {
        N_rol objnegocio = new N_rol();
        public FrmVerrolesCOmpletos()
        {
            InitializeComponent();
            
            mostrarrole();

            accionestabla();
        }


        public void mostrarrole()
        {
            N_rol objNegocio = new N_rol();
            TablaRoles.DataSource = objNegocio.listarrol();
            lbltotales.Text = "Total Registros:" + Convert.ToString(TablaRoles.RowCount);

        }
        public void accionestabla()
        {
          TablaRoles.Columns[0].Visible = false;
            TablaRoles.Columns[3].Visible = false;



            TablaRoles.ClearSelection();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
