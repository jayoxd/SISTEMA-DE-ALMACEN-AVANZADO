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
    public partial class FrmCliente : Form
    {
        N_Cliente objNegocio =new  N_Cliente();
        N_Vehiculo objNegocioVe = new N_Vehiculo();
        E_Cliente entiddadesve = new E_Cliente();
        public int cam = 0;
        
        public FrmCliente()
        {
            InitializeComponent();
            mostrarClientes();
            accionestabla();
            totalclientestodo();
            totalVehiculo();

            Button invisibleButton = new Button();
            invisibleButton.Size = new Size(1650, 2000); // Tamaño grande para forzar el scroll
            invisibleButton.FlatStyle = FlatStyle.Flat;
            invisibleButton.FlatAppearance.BorderSize = 0;
            invisibleButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            invisibleButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            invisibleButton.BackColor = Color.Transparent;
            invisibleButton.Enabled = false; // Deshabilitar el botón

            // Agregar el botón al panel
            panel9.Controls.Add(invisibleButton);

            // Configurar el Panel
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.AutoScroll = true;

            panel9.Size = new Size(1325, 825); // Tamaño del Panel más pequeño


        }

        public void mostrarClientes()
        {
            N_Cliente objNegocio = new N_Cliente();
            TablaClientes.DataSource = objNegocio.listandoClientes();
           
        }


        public void accionestabla()
        {
            TablaClientes.Columns[2].Visible = false;
    

            TablaClientes.Columns[0].DisplayIndex = 8;
            TablaClientes.Columns[1].DisplayIndex = 8;
            TablaClientes.Columns[2].DisplayIndex = 8;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frm = new FrmAgregarCliente();
       
            frm.ShowDialog();
            frm.Update = false;
            mostrarClientes();
            totalclientestodo();
            totalVehiculo();
            
        }

      

        public void totalVehiculo()
        {
            E_Vehiculo entidades = new E_Vehiculo();
            N_Vehiculo negocio = new N_Vehiculo();
            negocio.sumarVehiculos(entidades);

            lblvehiculoNumero.Text = entidades.Totalvehiculo;

        }


        public void totalclientestodo()
        {
            E_Cliente entidades = new E_Cliente();
            N_Cliente negocio = new N_Cliente();
            negocio.sumarClientestodo(entidades);
            lblDniNumero.Text = entidades.Totaldni;
            lblEmpresasNumero.Text = entidades.Totalempresas;
            lblClienteNumero.Text = entidades.Totalcliente;
        }


        public void buscarCliente(string buscarcli)
        {
            N_Cliente objNegocio = new N_Cliente();
            TablaClientes.DataSource = objNegocio.buscandoclientes(buscarcli);
        }

        private void txbBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            buscarCliente(txbBuscarCliente.Text);
        }

        private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
            if (TablaClientes.Rows[e.RowIndex].Cells["ELIMINAR"].Selected)
            {


                Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL CLIENTE?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int eliminar = Convert.ToInt32(TablaClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objNegocio.eliminandoCliente(eliminar);
                    FrmSuccess.confimarcionForm("ELIMINADO");
                    mostrarClientes();
               
                    totalclientestodo();
                }
            }

            else if (TablaClientes.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                FrmAgregarCliente frm = new FrmAgregarCliente();
                frm.Update = true;
                frm.txtIdCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["idcliente"].Value.ToString();
                frm.txtNombrecl.Text = TablaClientes.Rows[e.RowIndex].Cells["nombre_cli"].Value.ToString();
                frm.txbTipoDocumento.Text = TablaClientes.Rows[e.RowIndex].Cells["tipo_documento_cli"].Value.ToString();
                frm.txtNmrDocCliente.Text = TablaClientes.Rows[e.RowIndex].Cells["num_documento_cli"].Value.ToString();
                frm.txtDireccion.Text = TablaClientes.Rows[e.RowIndex].Cells["direccion_cli"].Value.ToString();
                frm.txtTelefono.Text = TablaClientes.Rows[e.RowIndex].Cells["telefono_cli"].Value.ToString();
                frm.txtEmail.Text = TablaClientes.Rows[e.RowIndex].Cells["email_cli"].Value.ToString();
                
                frm.ShowDialog();
                mostrarClientes();
           
                totalclientestodo();

            }
            /*else if (TablaClientes.Rows[e.RowIndex].Cells["VEHICULO"].Selected)
            {
                FrmVerVehiculo frm = new FrmVerVehiculo();
              
               
               
                frm.Update = true;
                 int cam =entiddadesve.Idcliente = Convert.ToInt32( TablaClientes.Rows[e.RowIndex].Cells[3].Value.ToString());
                frm.cmbClienxxxxx.Text = TablaClientes.Rows[e.RowIndex].Cells["nombre_cli"].Value.ToString();
                frm.mostrarVehiculo(cam);
             

                // frm.cmbClienxxxxx.DataSource = cliche.listandoClientes();


                frm.accionestabla();
                totalVehiculo();
                frm.ShowDialog();
            
              

            }*/
        }

     
           
        
       

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
           FrmAgregarVehiculos frm = new FrmAgregarVehiculos();
            frm.ShowDialog();
            frm.Update = false;
            mostrarClientes();
            totalVehiculo();
            totalclientestodo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblClienteNumero_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblclient_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblvehiculoNumero_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void lblVehiculo_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDniNumero_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void lblDni_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEmpresasNumero_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void lblEmpresas_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

            Console.WriteLine($"Scroll Horizontal: {panel9.HorizontalScroll.Visible}");
            Console.WriteLine($"Scroll Vertical: {panel9.VerticalScroll.Visible}");

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
} 
