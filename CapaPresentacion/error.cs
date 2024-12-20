using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class error : Form
    {
        public error(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;

        }

        private void error_Load(object sender, EventArgs e)
        {
            esclarecerFrom.ShowAsyc(this);

        }

        public static void fallas(string mensaje)
        {
            error frmfalla = new error(mensaje);
            frmfalla.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarPOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
