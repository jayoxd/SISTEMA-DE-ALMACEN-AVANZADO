using CapaEntidades;
using CapaNegocio;
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
    public partial class FrmVerDetalleDeVentas : Form
    {
        N_Servicio objNegocio = new N_Servicio();
        E_Servicio entidades = new E_Servicio();
        public bool Update = false;
        int numero;

        public int Idusuario;
        public int Idrol;
        public string nombre;
        public string rol;
        public bool estado;

        public FrmVerDetalleDeVentas()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void accionesTabladetalle()
        {
            TablaDetalle.Columns[0].Visible = false;
       



        }


        public int mostrarVehiculo(int efe)
        {




            N_Servicio objNegocio = new N_Servicio();

            FrmVerSevicios frmx = new FrmVerSevicios();

            //cmbClienxxxxx.ValueMember = "idcliente";
            //cmbClienxxxxx.DisplayMember = "nombre_cli";

          //  entidades.Idservicio = Convert.ToInt32(cmbClienxxxxx.SelectedValue);

            entidades.Idservicio = frmx.cam;
            TablaDetalle.DataSource = objNegocio.buscandoServiciosudetalle(efe);

            txtvehiculos.Text = Convert.ToString(TablaDetalle.RowCount);
            return efe;

        }

        private void txtvehiculos_TextChanged(object sender, EventArgs e)
        {

        }

        private void TablaDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void TablaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
    }



}
