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
    public partial class FrmSuccess : Form
    {
        public FrmSuccess(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        public FrmSuccess(string mensaje,string problem)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
            labelmensajito.Text = problem;
        }


        private void FrmSuccess_Load(object sender, EventArgs e)
        {
            esclarecerFrom.ShowAsyc(this);
        }

        public static void confimarcionForm(string mensaje)
        {
            FrmSuccess frm = new FrmSuccess(mensaje);
            frm.ShowDialog();
            
        }

        public static void confimarcionForm(string mensaje,string mensajito)
        {
            FrmSuccess frm = new FrmSuccess(mensaje,mensajito);
            frm.ShowDialog();

        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
