using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaNegocio;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
namespace CapaPresentacion
{
    public partial class CargarScript : Form
    {
        private readonly SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        N_Proveedores negocio = new N_Proveedores();



        public CargarScript()
        {
            InitializeComponent();
            txtRutaScript.ReadOnly = true; // Hacer que el campo sea de solo lectura


        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
 
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {

            // Usar un OpenFileDialog para seleccionar el archivo SQL
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mostrar la ruta del archivo seleccionado en el TextBox
                txtRutaScript.Text = openFileDialog.FileName;
            }

        }


        // Método para ejecutar el script en la base de datos
        private void EjecutarScriptEnBaseDeDatos(string script)
        {

            try
            {
                // Usamos la conexión configurada en el archivo de configuración (App.config o Web.config)
                using (SqlCommand cmd = new SqlCommand(script, conexion))
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Script ejecutado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el script: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }
        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Leer el contenido del archivo
                string script = File.ReadAllText(txtRutaScript.Text);

                // Ejecutar el script en la base de datos
                EjecutarScriptEnBaseDeDatos(script);

                // Modificar el nombre del archivo y agregar el sufijo "_compilado"
                string directory = Path.GetDirectoryName(txtRutaScript.Text);  // Obtiene la carpeta donde se encuentra el archivo
                string fileName = Path.GetFileNameWithoutExtension(txtRutaScript.Text);  // Nombre del archivo sin extensión
                string newFileName = fileName + "_compilado" + Path.GetExtension(txtRutaScript.Text);  // Agrega el sufijo "_compilado"
                string newFilePath = Path.Combine(directory, newFileName);  // Combina la carpeta con el nuevo nombre del archivo

                // Renombrar el archivo para marcar que ha sido compilado
                File.Move(txtRutaScript.Text, newFilePath);

                // Mostrar mensaje de éxito
                MessageBox.Show($"El script fue ejecutado y el archivo fue renombrado a: {newFileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el script o renombrar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
