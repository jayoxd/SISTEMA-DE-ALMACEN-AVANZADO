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
    public partial class FrmPrincipal : Form
    {
        public int Idusuario;
        public int Idrol;
        public string nombre;
        public string rol;
        public bool estado;


        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public void pantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FrmInformation("¿SEGURO DESEA SALIR DEL SISTEMA?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
                //this.Hide();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
           pantallaOK();

            txtcreador.Text = this.nombre;
            lblUSER.Text = this.rol;
            if (this.rol.Equals("Administrador"))
            {
                btnAcceso.Enabled = true;
                btnClientes.Enabled = true;
                btnDiagnostico.Enabled = true;
                btnPRoductos.Enabled = true;
                btnAcceso.Enabled = true;
                btnServicio.Enabled = true;

            }
            else
            {
                if (this.rol.Equals("Secretaria"))
                {

                    btnAcceso.Enabled = false;
                    btnClientes.Enabled = true;
                    btnDiagnostico.Enabled = true;
                    btnPRoductos.Enabled = false;
                    btnAcceso.Enabled = false;
                    btnServicio.Enabled = true;
                }
                else
                {
                    if (this.rol.Equals("Mecanico"))
                    {
                        btnAcceso.Enabled = false;
                        btnClientes.Enabled = false;
                        btnDiagnostico.Enabled = true;
                        btnServicio.Enabled = false;
                        btnPRoductos.Enabled = false;
                        btnAcceso.Enabled = false;
                    }
                    else
                    {
                        if (this.rol.Equals("Almacenero"))
                        {
                            btnAcceso.Enabled = false;
                            btnClientes.Enabled = false;
                            btnDiagnostico.Enabled = false;
                            btnPRoductos.Enabled = true;
                            btnAcceso.Enabled = false;
                            btnServicio.Enabled = false;
                        }
                    }
                }

            }


        }



        public void seleccionandoBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnClientes.Textcolor = Color.White;
            btnPRoductos.Textcolor = Color.White;
            btnServicio.Textcolor = Color.White;
            btnDiagnostico.Textcolor = Color.White;
            btnAcceso.Textcolor = Color.White;

            sender.selected = true;
            if (sender.selected)
            {
                sender.Textcolor = Color.FromArgb(98, 195, 140);
            }
        }

        private void Seguirboton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            flecha.Top = sender.Top;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmCliente());

        }

        private void btnPRoductos_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new frmProductos());

        }

        private Form formActivo = null;

        private void AbrirFormularioEnWrapper(Form formhijo)
        {
            if (formActivo != null)
                formActivo.Close();
            formActivo = formhijo;
            formhijo.TopLevel = false;
            formhijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(formhijo);
            formhijo.Show();
       
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmDiagnostico());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmServicio());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmRolesver());
        }

        private void lblUSER_Click(object sender, EventArgs e)
        {

        }
    }
}
