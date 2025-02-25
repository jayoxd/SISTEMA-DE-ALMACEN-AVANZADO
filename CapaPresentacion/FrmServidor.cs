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
using System.Configuration;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmServidor : Form
    {
        E_Usuario entidades = new E_Usuario();
        N_Usuario negocio = new N_Usuario();

        public FrmServidor()
        {
   InitializeComponent();
            CargarServidores();        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarServidores()
        {  // Obtener las cadenas de conexión del App.config
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings connectionString in connectionStrings)
            {
                if (connectionString.Name != "LocalSqlServer") // Excluir la cadena de conexión por defecto
                {
                    comboBoxServidores.Items.Add(connectionString.Name);
                }
            }

            if (comboBoxServidores.Items.Count > 0)
            {
                comboBoxServidores.SelectedIndex = 0;
            }
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el nombre del servidor seleccionado
                string selectedServer = comboBoxServidores.SelectedItem.ToString();

                // Obtener la cadena de conexión correspondiente
                string connectionString = ConfigurationManager.ConnectionStrings[selectedServer].ConnectionString;



                // Actualizar la cadena de conexión en ConexionManager
                ConexionManager.ConnectionString = connectionString;

                MessageBox.Show("Conexión exitosa al servidor: " + selectedServer);
                FrmAcceso frmAcceso = new FrmAcceso();
                frmAcceso.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }


        }

    

      
    }
}
