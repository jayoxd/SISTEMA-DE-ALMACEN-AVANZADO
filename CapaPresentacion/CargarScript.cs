using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapaNegocio;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using CapaDatos;
namespace CapaPresentacion
{
    public partial class CargarScript : Form
    {
        private readonly SqlConnection conexion = new SqlConnection(ConexionManager.ConnectionString);

        N_Proveedores negocio = new N_Proveedores();



        public CargarScript()
        {
            InitializeComponent();
           // txtRutaScript.ReadOnly = true; // Hacer que el campo sea de solo lectura


        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
 
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {

            // Usar un OpenFileDialog para seleccionar múltiples archivos SQL
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*";
            openFileDialog.Multiselect = true; // Habilitar selección múltiple

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mostrar las rutas de los archivos seleccionados en el TextBox
                txtRutaScript.Text = string.Join(Environment.NewLine, openFileDialog.FileNames);
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
                 //   MessageBox.Show("Script ejecutado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Obtener las rutas de los archivos seleccionados
                string[] rutasArchivos = txtRutaScript.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Lista para almacenar los nombres de los archivos procesados
                List<string> archivosProcesados = new List<string>();

                // Variable para verificar si algún archivo ya está compilado
                bool archivoYaCompilado = false;

                // Lista para almacenar los archivos ordenados por fecha y hora
                var archivosOrdenados = new List<(string Ruta, DateTime FechaHora)>();

                // Procesar cada archivo
                foreach (var ruta in rutasArchivos)
                {
                    try
                    {
                        // Obtener el nombre del archivo sin la extensión
                        string nombreArchivo = Path.GetFileNameWithoutExtension(ruta);

                        // Verificar si el archivo ya está compilado
                        if (nombreArchivo.EndsWith("_compilado"))
                        {
                            archivoYaCompilado = true;
                            MessageBox.Show($"El archivo {nombreArchivo} ya ha sido compilado. No se puede ejecutar nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break; // Detener el proceso si se encuentra un archivo ya compilado
                        }

                        // Extraer la fecha y hora del nombre del archivo
                        DateTime fechaHora = ExtraerFechaHoraDesdeNombre(nombreArchivo);

                        // Agregar el archivo a la lista de archivos ordenados
                        archivosOrdenados.Add((ruta, fechaHora));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar el archivo {ruta}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Si no hay archivos ya compilados, continuar con la ejecución
                if (!archivoYaCompilado)
                {
                    // Ordenar los archivos por fecha y hora
                    archivosOrdenados = archivosOrdenados.OrderBy(archivo => archivo.FechaHora).ToList();

                    // Ejecutar cada script en orden
                    foreach (var archivo in archivosOrdenados)
                    {
                        try
                        {
                            // Leer el contenido del archivo
                            string script = File.ReadAllText(archivo.Ruta);

                            // Ejecutar el script en la base de datos
                            EjecutarScriptEnBaseDeDatos(script);

                            // Modificar el nombre del archivo y agregar el sufijo "_compilado"
                            string directory = Path.GetDirectoryName(archivo.Ruta);  // Obtiene la carpeta donde se encuentra el archivo
                            string fileName = Path.GetFileNameWithoutExtension(archivo.Ruta);  // Nombre del archivo sin extensión
                            string newFileName = fileName + "_compilado" + Path.GetExtension(archivo.Ruta);  // Agrega el sufijo "_compilado"
                            string newFilePath = Path.Combine(directory, newFileName);  // Combina la carpeta con el nuevo nombre del archivo

                            // Renombrar el archivo para marcar que ha sido compilado
                            File.Move(archivo.Ruta, newFilePath);

                            // Agregar el nombre del archivo procesado a la lista
                            archivosProcesados.Add(newFileName);
                        }
                        catch (Exception ex)
                        {
                            // Mostrar mensaje de error para el archivo actual
                            MessageBox.Show($"Error al procesar el archivo {archivo.Ruta}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Mostrar un solo mensaje con todos los archivos procesados
                    if (archivosProcesados.Count > 0)
                    {
                        string mensajeFinal = "Los siguientes scripts fueron ejecutados y renombrados correctamente:\n\n";
                        mensajeFinal += string.Join("\n", archivosProcesados);
                        MessageBox.Show(mensajeFinal, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se procesaron archivos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DateTime ExtraerFechaHoraDesdeNombre(string nombreArchivo)
        {
            Console.WriteLine($"Procesando archivo: {nombreArchivo}"); // Depuración

            // Buscar el último guion bajo en el nombre del archivo
            int indiceUltimoGuion = nombreArchivo.LastIndexOf('_');

            if (indiceUltimoGuion == -1)
            {
                throw new FormatException($"El nombre del archivo {nombreArchivo} no contiene un guion bajo para extraer la fecha y hora.");
            }

            // Extraer la parte del nombre que contiene la fecha y hora
            string fechaHoraStr = nombreArchivo.Substring(indiceUltimoGuion - 8, 15); // Extraer "20250212_112752"
            Console.WriteLine($"Cadena extraída: {fechaHoraStr}"); // Depuración

            // Verificar que la cadena extraída tenga el formato correcto (yyyyMMdd_HHmmss)
            if (fechaHoraStr.Length != 15 || !fechaHoraStr.Contains("_"))
            {
                throw new FormatException($"El nombre del archivo {nombreArchivo} no contiene una fecha y hora válida. Cadena extraída: {fechaHoraStr}");
            }

            // Convertir a DateTime
            if (DateTime.TryParseExact(fechaHoraStr, "yyyyMMdd_HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaHora))
            {
                Console.WriteLine($"Fecha y hora convertida: {fechaHora}"); // Depuración
                return fechaHora;
            }
            else
            {
                throw new FormatException($"El nombre del archivo {nombreArchivo} no contiene una fecha y hora válida. Cadena extraída: {fechaHoraStr}");
            }
        }

        private void txtRutaScript_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
