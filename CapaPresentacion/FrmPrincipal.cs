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
            AbrirFormularioEnWrapper(new FrmInventario());

            // Ocultar botones según el rol
            btnAcceso.Visible = this.rol.Equals("Administrador");
            btnKardex.Visible = true; // Siempre visible
            btnDiagnostico.Visible = this.rol.Equals("Administrador") || this.rol.Equals("Jefe de Almacen");
            btnServicio.Visible = this.rol.Equals("Administrador") || this.rol.Equals("Jefe de Almacen");
            btnPRoductos.Visible = this.rol.Equals("Administrador") || this.rol.Equals("Jefe de Almacen");
            btnReportes.Visible = true; // Siempre visible
            btnclientes.Visible = this.rol.Equals("Administrador") || this.rol.Equals("Jefe de Almacen");
            btnproveedores.Visible = this.rol.Equals("Administrador") || this.rol.Equals("Jefe de Almacen");

            txtcreador.Text = this.nombre;
            lblUSER.Text = this.rol;
            if (this.rol.Equals("Administrador"))
            {
                btnAcceso.Enabled = true;
                btnKardex.Enabled = true;
                btnDiagnostico.Enabled = true;
                btnServicio.Enabled = true;
                btnPRoductos.Enabled = true;
                btnAcceso.Enabled = true;
                btnReportes.Enabled = true;
                btnclientes.Enabled = true;
                btnDiagnostico.Enabled = true;
                btnproveedores.Enabled = true;

            }
            else
            {
                if (this.rol.Equals("Jefe de Almacen"))
                {

                    btnAcceso.Enabled = true;
                    btnKardex.Enabled = true;
                    btnDiagnostico.Enabled = true;
                    btnServicio.Enabled = true;
                    btnPRoductos.Enabled = true;
                    btnAcceso.Enabled = false;
                    btnReportes.Enabled = true;
                    btnclientes.Enabled = true;
                    btnDiagnostico.Enabled = true;
                    btnproveedores.Enabled = true;
                }
                else
                {
                    if (this.rol.Equals("Rol de Visualización"))
                    {
                        btnAcceso.Enabled = false;
                        btnKardex.Enabled = true;
                        btnDiagnostico.Enabled = true;
                        btnServicio.Enabled = false;
                        btnPRoductos.Enabled = false;
                        btnAcceso.Enabled = false;
                        btnReportes.Enabled = true;
                        btnclientes.Enabled = false;
                        btnDiagnostico.Enabled = false;
                        btnproveedores.Enabled = false;
                    }
                   
                }

            }


        }



        public void seleccionandoBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnKardex.Textcolor = Color.White;
            btnPRoductos.Textcolor = Color.White;
            btnServicio.Textcolor = Color.White;
            btnDiagnostico.Textcolor = Color.White;
            btnAcceso.Textcolor = Color.White;
            btnReportes.Textcolor = Color.White;
            btnclientes.Textcolor  = Color.White;
            btnproveedores.Textcolor = Color.White;

            sender.selected = true;
            if (sender.selected)
            {
                sender.Textcolor = Color.Black;
            }
        }

        private void Seguirboton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            flecha.Top = sender.Top + (sender.Height - flecha.Height) / 2; // Asegurar que esté alineada verticalmente
            flecha.BringToFront(); // Forzar que la flecha esté encima de todos los botones
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
          //  AbrirFormularioEnWrapper(new FrmCliente());

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
            FrmEntrada frmEntrada = new FrmEntrada();
            frmEntrada.Idusuario = this.Idusuario; // Pasar el Idusuario al formulario

            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(frmEntrada); // Abrir el mismo formulario al que se asignó el Idusuario
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            FrmSalida frmSalida = new FrmSalida();
            frmSalida.Idusuario = this.Idusuario; // Pasar el Idusuario al formulario

            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(frmSalida); // Abrir el mismo formulario al que se asignó el Idusuario
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

     

        private void btnKardex_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);

            AbrirFormularioEnWrapper(new FrmInventario());
        }

        private void flecha_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmEntradaSalida());
        }

        private void btnclientes_Click_1(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmPersonas());
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            seleccionandoBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            Seguirboton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioEnWrapper(new FrmProveedores());
        }
    }
}
