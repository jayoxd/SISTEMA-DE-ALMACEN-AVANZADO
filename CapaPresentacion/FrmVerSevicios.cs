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
    public partial class FrmVerSevicios : Form
    {

        N_Servicio objNegocio = new N_Servicio();
        E_Servicio entidad = new E_Servicio();
        public int cam = 0;

        public FrmVerSevicios()
        {
            InitializeComponent();
            mostrarServicio();
            accionestabla();
        }

        public void mostrarServicio()
        {
            tablaServicios.DataSource = objNegocio.listandoServicios();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void accionestabla()
        {
            tablaServicios.Columns[12].Visible = false;
            //tablaServicios.Columns[1].Visible = false;
            //tablaServicios.Columns[1].Visible = false;
            tablaServicios.Columns[2].Visible = false;
            tablaServicios.Columns[3].Visible = false;



            tablaServicios.Columns[0].DisplayIndex = 11;
            tablaServicios.Columns[1].DisplayIndex = 12;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void buscar(string buscar)
        {
            tablaServicios.DataSource = objNegocio.buscandoServicios(buscar);
        }
        private void txbBreport_TextChanged(object sender, EventArgs e)
        {
            buscar(txbBreport.Text);
        }

        private void tablaServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaServicios.Rows[e.RowIndex].Cells["REPORTE"].Selected)
            {
                FrmVerVehiculo frm = new FrmVerVehiculo();


                FrmSuccess.confimarcionForm("Ingresaste a ver reportes");


                //frm.Update = true;
                //int cam = entiddadesve.Idcliente = Convert.ToInt32(TablaClientes.Rows[e.RowIndex].Cells[3].Value.ToString());
                //frm.cmbClienxxxxx.Text = TablaClientes.Rows[e.RowIndex].Cells["nombre_cli"].Value.ToString();
                //frm.mostrarVehiculo(cam);


                //// frm.cmbClienxxxxx.DataSource = cliche.listandoClientes();


                //frm.accionestabla();
                //totalVehiculo();
                //frm.ShowDialog();



            }
            else if (tablaServicios.Rows[e.RowIndex].Cells["DOCUMENTO"].Selected)
            {
                FrmVerDetalleDeVentas frm = new FrmVerDetalleDeVentas();

                frm.Update = true;
                int cam = entidad.Idservicio = Convert.ToInt32(tablaServicios.Rows[e.RowIndex].Cells[2].Value.ToString());
               // frm.cmbClienxxxxx.Text = TablaClientes.Rows[e.RowIndex].Cells["nombre_cli"].Value.ToString();
                frm.mostrarVehiculo(cam);
                //PASAR DATOS COMO SUB TOTAL TOTAL  SERVICIO Y CUANTAS REGISTRO TIENE NADA MAS Y ORDFENAR
                frm.accionesTabladetalle();

                frm.ShowDialog();

            


            }

        }
    }
}
