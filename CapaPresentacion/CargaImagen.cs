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
using System.Data;
using CapaDatos;
using System.Drawing;
using DocumentFormat.OpenXml.VariantTypes;
namespace CapaPresentacion
{
    public partial class CargaImagen : Form
    {
        public bool Update = false;

        private List<string> _rutasImagenes = new List<string>(); // Lista para almacenar las rutas de las imágenes


        public CargaImagen()
        {
            InitializeComponent();
            // txtRutaScript.ReadOnly = true; // Hacer que el campo sea de solo lectura
            ConfigurarDataGridView(); // Configurar las columnas del DataGridView
            ConfigurarAnchoColumnas(); // Ajustar el ancho de las columnas

        }
        private void ConfigurarAnchoColumnas()
        {
            // Configurar el modo de ajuste de columnas
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Asignar el 70% del ancho a la columna de la imagen
            dgvDetalle.Columns["Imagen"].FillWeight = 70;

            // Asignar el 30% del ancho a la columna del nombre
            dgvDetalle.Columns["Nombre"].FillWeight = 30;
        }
        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes (por si acaso)
            dgvDetalle.Columns.Clear();

            // Configurar el estilo de la cabecera
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Fondo negro
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Letras blancas
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Fuente en negrita (opcional)
            dgvDetalle.EnableHeadersVisualStyles = false; // Deshabilitar estilos visuales predeterminados


            // Agregar columna para la imagen
            DataGridViewImageColumn colImagen = new DataGridViewImageColumn();
            colImagen.Name = "Imagen";
            colImagen.HeaderText = "Imagen";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ajustar la imagen al tamaño de la celda
            dgvDetalle.Columns.Add(colImagen);

            // Agregar columna para el nombre de la imagen
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Nombre de la Imagen";
            colNombre.ReadOnly = true;
            dgvDetalle.Columns.Add(colNombre);

            // Agregar columna para la ruta de la imagen
            DataGridViewTextBoxColumn colRuta = new DataGridViewTextBoxColumn();
            colRuta.Name = "Ruta";
            colRuta.HeaderText = "Ruta de la Imagen";
            colRuta.ReadOnly = true;
            dgvDetalle.Columns.Add(colRuta);

            // Opcional: Ocultar la columna de la ruta si no quieres que sea visible
            colRuta.Visible = false;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Image RedimensionarImagen(Image imagen, int ancho, int alto)
        {
            // Crear un nuevo bitmap con el tamaño deseado
            Bitmap nuevaImagen = new Bitmap(ancho, alto);

            // Dibujar la imagen original en el nuevo bitmap (redimensionada)
            using (Graphics g = Graphics.FromImage(nuevaImagen))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagen, 0, 0, ancho, alto);
            }

            return nuevaImagen;
        }

        private void AjustarAlturaFilas(int altura)
        {
            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                fila.Height = altura; // Asignar la altura específica a la fila
            }
        }



        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Configurar el cuadro de diálogo para seleccionar imágenes
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp"; // Filtro para imágenes
                openFileDialog.Multiselect = true; // Permitir selección múltiple

                // Si el usuario selecciona imágenes
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Limpiar la lista y el DataGridView antes de agregar nuevas imágenes
                    _rutasImagenes.Clear();
                    dgvDetalle.Rows.Clear();

                    // Definir el tamaño deseado para las imágenes
                    int anchoDeseado = 280; // Ancho deseado (puedes ajustarlo)
                    int altoDeseado = 280;  // Alto deseado (puedes ajustarlo)

                    // Agregar las rutas de las imágenes seleccionadas a la lista y al DataGridView
                    foreach (string ruta in openFileDialog.FileNames)
                    {
                        _rutasImagenes.Add(ruta);

                        // Cargar la imagen desde la ruta
                        Image imagenOriginal = Image.FromFile(ruta);

                        // Redimensionar la imagen al tamaño deseado
                        Image imagenRedimensionada = RedimensionarImagen(imagenOriginal, anchoDeseado, altoDeseado);

                        // Agregar la imagen redimensionada y el nombre al DataGridView
                        dgvDetalle.Rows.Add(imagenRedimensionada, Path.GetFileName(ruta), ruta);
                    }

                    // Ajustar la altura de las filas al alto deseado
                    AjustarAlturaFilas(altoDeseado);
                }
            }

        }
            

        

      



        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

            if (Update) // Si es modo edición
            {
                N_Productoss objNegocio = new N_Productoss();
                DataTable dtImagenes = objNegocio.obtenerImgproducto(codigopr.Text); // Obtener imágenes del producto

                // Limpiar el DataGridView antes de cargar las imágenes
                dgvDetalle.Rows.Clear();

                // Definir el tamaño deseado para las imágenes
                int anchoDeseado = 280; // Ancho deseado (puedes ajustarlo)
                int altoDeseado = 280;  // Alto deseado (puedes ajustarlo)

                // Cargar las imágenes en el DataGridView
                foreach (DataRow row in dtImagenes.Rows)
                {
                    string rutaImagen = row["RutaImagen"].ToString(); // Obtener la ruta de la imagen
                    Image img = Image.FromFile(rutaImagen); // Cargar la imagen desde la ruta

                    // Redimensionar la imagen al tamaño deseado
                    Image imagenRedimensionada = RedimensionarImagen(img, anchoDeseado, altoDeseado);

                    // Agregar la imagen redimensionada y el nombre al DataGridView
                    dgvDetalle.Rows.Add(imagenRedimensionada, Path.GetFileName(rutaImagen), rutaImagen);
                }

                // Ajustar la altura de las filas
                AjustarAlturaFilas(altoDeseado);
            }

        }

        private DataTable CrearDataTableDeImagenes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ImagenID", typeof(int)); // ID de la imagen (puede ser null para nuevas imágenes)
            dt.Columns.Add("RutaImagen", typeof(string)); // Ruta de la imagen
            dt.Columns.Add("Orden", typeof(int)); // Orden de la imagen

            // Recorrer las filas del DataGridView para agregar las imágenes a la DataTable
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                string rutaImagen = fila.Cells["Ruta"].Value?.ToString();
                if (!string.IsNullOrEmpty(rutaImagen))
                {
                    dt.Rows.Add(null, rutaImagen, fila.Index + 1); // Orden = índice + 1
                }
            }

            return dt;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            // Verificar si hay imágenes para guardar
            if (_rutasImagenes.Count == 0 && dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay imágenes para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que el código del producto no esté vacío
            if (string.IsNullOrEmpty(codigopr.Text))
            {
                MessageBox.Show("El código del producto no está definido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                N_Productoss objNegocio = new N_Productoss();

                if (Update) // Modo edición
                {
                    // Crear la DataTable con las imágenes actuales
                    DataTable imagenesProducto = CrearDataTableDeImagenes();

                    // Llamar al método de actualización
                    objNegocio.EditarPRODUCTOimg(codigopr.Text, imagenesProducto);
                    MessageBox.Show("Imágenes actualizadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Modo inserción
                {
                    // Llamar al método de inserción para cada imagen
                    for (int i = 0; i < _rutasImagenes.Count; i++)
                    {
                        objNegocio.InsertarImagen(codigopr.Text, _rutasImagenes[i], i + 1); // Orden = índice + 1
                    }
                    MessageBox.Show("Imágenes guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar las imágenes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}


