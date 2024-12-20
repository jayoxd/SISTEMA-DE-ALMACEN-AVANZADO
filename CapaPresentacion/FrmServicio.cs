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
using System.Security.Cryptography;

namespace CapaPresentacion
{
    public partial class FrmServicio : Form
    {
        private DataTable DtDetalle = new DataTable();

        N_ReporteDiagnostico  objNegocio = new N_ReporteDiagnostico();
        E_ReporteDiagnostico objEntidad = new E_ReporteDiagnostico();
        N_Productos objProductos = new N_Productos();
        N_Servicio objServicio = new N_Servicio();
        public int cam = 0;


        public FrmServicio()
        {;
            InitializeComponent();
          //  lblclient.Text = F_Variables.nombre_empleado;
          
            crear_tabla();
        
            acciones_tabla();
            
        }

        private void Listar()
        {
            try
            {
                dgvDetalle.DataSource = objServicio.listandoServicios();
              
                this.Limpiar();
               // LblTotal.Text = "Total registros: " + Convert.ToString(dgvDetalle.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpiar()
        {

            txbCliente.Clear();
            txtPlaca.Clear();
            txbFecha.Clear();
            txbNumCom.Clear();
            txbServicio.Clear();
            txtDescripcion.Clear();
            lblSubtotalnumer.Text= "0.00";
            lblServicionumer.Text= "0.00";
            lblTotalnumer.Text = "0.00";

            dgvDetalle.Columns[0].Visible = false;
           

        }



        public void crear_tabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("stock", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));

            dgvDetalle.DataSource = this.DtDetalle;
        }
        public void acciones_tabla()
        {
            
            dgvDetalle.Columns[0].Visible = false;
           dgvDetalle.Columns[1].HeaderText = "";
          
            dgvDetalle.Columns[1].Width = 103;
            dgvDetalle.Columns[2].HeaderText = "";
            dgvDetalle.Columns[2].Width = 203;
            dgvDetalle.Columns[3].HeaderText = "";
            dgvDetalle.Columns[3].Width = 83;
            dgvDetalle.Columns[4].HeaderText = "";
            dgvDetalle.Columns[4].Width = 123;
            dgvDetalle.Columns[5].HeaderText = "";
            dgvDetalle.Columns[5].Width = 108;
            dgvDetalle.Columns[6].HeaderText = "";
            dgvDetalle.Columns[6].Width = 116;

            dgvDetalle.Columns[1].ReadOnly = true;
            dgvDetalle.Columns[2].ReadOnly = true;
            dgvDetalle.Columns[3].ReadOnly = true;
            dgvDetalle.Columns[6].ReadOnly = true;

        }

       
      
        
        private void btnverServicios_Click(object sender, EventArgs e)
        {
            FrmVerSevicios frm = new FrmVerSevicios();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmComporclien frm = new FrmComporclien();
            frm.ShowDialog();
            txbCliente.Text = F_Variables.nombre_clientereport;
            txtPlaca.Text = F_Variables.carro;
            txtDescripcion.Text = F_Variables.reporte;
            txbReporteServicio.Text =F_Variables.pruebatodo;
            var DateAndTime = DateTime.Now;
            var Date = DateAndTime.Date.ToString("dd-MM-yyyy");
            txbFecha.Text = Date.ToString();



        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txbBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = objProductos.buscandoProductosventa(txbBuscarCliente.Text.Trim());
                    if (Tabla.Rows.Count <= 0)
                    {
                        FrmSuccess.confimarcionForm("Error al ingresar codigo", "revise el codigo de los producto solicitado");

                    }
                    else
                    {
                        this.AgregarDetalle(Convert.ToInt32(Tabla.Rows[0][0]), Convert.ToString(Tabla.Rows[0][1]), Convert.ToString(Tabla.Rows[0][2]), Convert.ToInt32(Tabla.Rows[0][4]), Convert.ToDecimal(Tabla.Rows[0][3]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void AgregarDetalle(int IdArticulo, string Codigo, string Nombre, int Stock, decimal Precio)
        {
            bool Agregar = true;
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"]).Equals(IdArticulo) )
                {
                    Agregar = false;
                    FrmSuccess.confimarcionForm("Ya se ingreso este producto", "Ingrese nuevamente otro producto");
                }
            }

            if (Agregar)
            {
                DataRow Fila = DtDetalle.NewRow();
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["stock"] = Stock;
                Fila["cantidad"] = 1;
                Fila["precio"] = Precio;
                Fila["importe"] = Precio;
                this.DtDetalle.Rows.Add(Fila);
                this.CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            decimal Total = 0;
            decimal SubTotal = 0;
         
            if (dgvDetalle.Rows.Count == 0)
            {
                Total = 0;
            }
            else
            {
                foreach (DataRow FilaTemp in DtDetalle.Rows)
                {
                    Total = Total + Convert.ToDecimal(FilaTemp["importe"]);
                }
            }

            SubTotal = Total;
            if (txbServicio.Text.Equals("")){

                lblTotalnumer.Text = (SubTotal + Convert.ToDecimal(00)).ToString("#0.00#");
                lblSubtotalnumer.Text = SubTotal.ToString("#0.00#");
                lblServicionumer.Text = "0.00";
            }
            else 
            {
                lblTotalnumer.Text = (SubTotal + Convert.ToDecimal(txbServicio.Text)).ToString("#0.00#");
                lblSubtotalnumer.Text = SubTotal.ToString("#0.00#");
                lblServicionumer.Text = txbServicio.Text;
            }
           
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            string Articulo = Convert.ToString(Fila["articulo"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
                int Stock = Convert.ToInt32(Fila["stock"]);
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            if (Cantidad > Stock)
            {
                Cantidad = 0;
                FrmSuccess.confimarcionForm("SOBREPASASTE EL LIMITE DEL STOCK","vuelve a ingresar la cantidad del producto");
               

                Fila["cantidad"] = 0;
            }
            Fila["importe"] = (Precio * Cantidad) ;
            this.CalcularTotales();
        }

        private void txbServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txbReporteServicio.Text == string.Empty )
                {
                    FrmSuccess.confimarcionForm("Falta ingresar Datos", "Ingrese el reporte de servicio");

                }
                if (txbServicio.Text == string.Empty) { FrmSuccess.confimarcionForm("Falta ingresar Datos", "Ingrese precio del servicio"); }
                if (txbNumCom.Text == string.Empty) { FrmSuccess.confimarcionForm("Falta ingresar Datos", "Ingrese el Nro de comprobante"); }
                if (DtDetalle.Rows.Count == 0) { FrmSuccess.confimarcionForm("Falta ingresar Datos", "Debe tener al menos un detalle."); }


                else
                {
                    Rpta = N_Servicio.insertarServicio(
                        Convert.ToInt32(F_Variables.idEmpleado),
                        Convert.ToInt32(txbReporteServicio.Text),
                        Convert.ToString(txbNumCom.Text.Trim()),
                        Convert.ToDecimal(txbServicio.Text),
                        Convert.ToDecimal(lblTotalnumer.Text),
                        DtDetalle);

                    if (Rpta.Equals("OK"))
                    {
                        FrmSuccess.confimarcionForm("Servicio  AGREGADO");
                        this.Limpiar();
                        DtDetalle.Clear();
                    }
                    else {
                        FrmSuccess.confimarcionForm("Servicio  No agregado");

                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvDetalle_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.CalcularTotales();
        }

        private void lblTotalnumer_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
