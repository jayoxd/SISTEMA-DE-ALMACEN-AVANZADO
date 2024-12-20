using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmAgregarVehiculos : Form
    {
      
        E_Vehiculo entidadesv = new E_Vehiculo();
        N_Vehiculo negociov = new N_Vehiculo();
        public bool Update = false;

        public FrmAgregarVehiculos()
        {
            InitializeComponent();
            listar_cliente(cmbClientesvehiculo.ValueMember);
        }   

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void listar_cliente(string buscarcli)
        {
            N_Cliente objeto = new N_Cliente();
            cmbClientesvehiculo.DataSource = objeto.buscandoclientes(buscarcli);
            cmbClientesvehiculo.ValueMember = "Idcliente";
            cmbClientesvehiculo.DisplayMember = "Num_documento_cli";
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {

            if (Update == false)
            {
                try
                {

                    if (txtPlaca.Text == string.Empty || txtModelo.Text == string.Empty || txtMarca.Text == string.Empty || cmbClientesvehiculo.ValueMember == string.Empty ||
                        txtAño.Text == string.Empty)
                    {
                        FrmSuccess.confimarcionForm("FALTA INGRESAR DATOS");
                    }
                    else
                    {
                        entidadesv.Idcliente = Convert.ToInt32(cmbClientesvehiculo.SelectedValue);
                        entidadesv.Placa_veh = txtPlaca.Text;
                        entidadesv.Modelo_veh = txtModelo.Text;
                        entidadesv.Marca_veh = txtMarca.Text;
                        entidadesv.Año_veh = txtAño.Text;
                        negociov.insertandoVehiculo(entidadesv);
                        FrmSuccess.confimarcionForm("VEHICULO AGREGADO");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
             if (Update == true)
             {

                try
                {
                    
                    entidadesv.Idcliente = Convert.ToInt32(txtidClienteVehiculo.Text);
                    entidadesv.Idvehiculo = Convert.ToInt32(txidVehiculo.Text);
                     entidadesv.Placa_veh = txtPlaca.Text;
                     entidadesv.Modelo_veh = txtModelo.Text;
                    entidadesv.Año_veh = txtAño.Text;
                    entidadesv.Marca_veh = txtMarca.Text;
                     

                     negociov.editandoVehiculo(entidadesv);
                     FrmSuccess.confimarcionForm("VEHICULO ACTUALIZADO");
                     Close();
                     Update = false;

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("No se pudo editar el cliente" + ex);
                 }
             }
        }

        private void cmbClientesvehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbClientesvehiculo.SelectedIndex;
            txtNrm_Clienteveh.Text = cmbClientesvehiculo.Items[indice].ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmAgregarVehiculos_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
