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
    public partial class FrmVerVehiculo : Form
    {
        N_Vehiculo objNegocio = new N_Vehiculo();
        N_Cliente objNegocioC = new N_Cliente();
        E_Vehiculo entidades = new E_Vehiculo();
        public bool Update = false;
        

        public FrmVerVehiculo()
        {
            InitializeComponent();
            //  accionestabla();
            // mostrarVehiculo(); 
            txtNumerodocumento.Enabled = true;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    



        public int  mostrarVehiculo(int efe)
        {
             
            
              

                N_Vehiculo objNegocio = new N_Vehiculo();
      
                N_Cliente clientene = new N_Cliente();
            FrmCliente frmx = new FrmCliente();

            cmbClienxxxxx.ValueMember = "idcliente";
                cmbClienxxxxx.DisplayMember = "nombre_cli";

             entidades.Idcliente=Convert.ToInt32( cmbClienxxxxx.SelectedValue);

            entidades.Idcliente = frmx.cam;
                TablaVehiculo.DataSource = objNegocio.buscandoVehiculo(efe) ;

            txtvehiculos.Text = Convert.ToString(TablaVehiculo.RowCount);
            return efe;

        }

        

        private void TablaVehiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( TablaVehiculo.Rows[e.RowIndex].Cells["ELIMINARVE"].Selected)
            {

                    Form mensaje = new FrmInformation("¿ESTAS SEGURO DE ELIMINAR EL CLIENTE?");
                    DialogResult resultado = mensaje.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        entidades.Idvehiculo = Convert.ToInt32(TablaVehiculo.Rows[e.RowIndex].Cells[2].Value.ToString());
                        objNegocio.eliminandoVehiculo(entidades);
                        FrmSuccess.confimarcionForm("ELIMINADO");
                    //mostrarVehiculo();
                    entidades.Idcliente = Convert.ToInt32(TablaVehiculo.Rows[e.RowIndex].Cells[3].Value.ToString());
                     
                    mostrarVehiculo(entidades.Idcliente);
                    FrmCliente ca = new FrmCliente();
                    ca.totalVehiculo();

                 
                
                    }
                
            }
           

            else if (TablaVehiculo.Rows[e.RowIndex].Cells["EDITARVE"].Selected)
            {
                FrmAgregarVehiculos frm = new FrmAgregarVehiculos();
               frm.cmbClientesvehiculo.Enabled = false;

                frm.Update = true;
                frm.txidVehiculo.Text = TablaVehiculo.Rows[e.RowIndex].Cells["idvehiculo"].Value.ToString();
                frm.txtidClienteVehiculo.Text = TablaVehiculo.Rows[e.RowIndex].Cells["idcliente"].Value.ToString();
                frm.txtPlaca.Text = TablaVehiculo.Rows[e.RowIndex].Cells["placa_veh"].Value.ToString();
                frm.txtModelo.Text = TablaVehiculo.Rows[e.RowIndex].Cells["modelo_veh"].Value.ToString();
                frm.txtMarca.Text = TablaVehiculo.Rows[e.RowIndex].Cells["marca_veh"].Value.ToString();
                frm.txtAño.Text = TablaVehiculo.Rows[e.RowIndex].Cells["año_veh"].Value.ToString();
                entidades.Idcliente = Convert.ToInt32(TablaVehiculo.Rows[e.RowIndex].Cells[3].Value.ToString());
                frm.ShowDialog();
                mostrarVehiculo(entidades.Idcliente);
               

            }
        }

   
        private void FrmVerVehiculo_Load(object sender, EventArgs e)
        {
             
        }
        public void accionestabla()
        {
            TablaVehiculo.Columns[2].Visible = false;
            TablaVehiculo.Columns[3].Visible = false;
            TablaVehiculo.Columns[4].Visible = false;
            TablaVehiculo.Columns[0].DisplayIndex = 8;
            TablaVehiculo.Columns[1].DisplayIndex = 8;
            TablaVehiculo.ClearSelection();
      
        }

        private void cmbClienxxxxx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtvehiculos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
