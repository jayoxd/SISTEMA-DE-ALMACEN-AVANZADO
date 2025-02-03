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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FrmRolesver : Form
    {
        
        N_rol objnegocio = new N_rol();
        N_Usuario objuser = new N_Usuario();
         N_Clientes objNegocioss = new N_Clientes();
         N_Proveedores objNegocios = new N_Proveedores();
        N_Productoss objNegocioxd = new N_Productoss();
        private bool mostrandoActivos = true; // Indica si estamos mostrando empleados activos
        public string txtxiidrol = "";

        public FrmRolesver()
        {
            InitializeComponent();
            ConfigurarTablaEmpleados(); // Configuración inicial de la tabla
            TablaUsuarios.DataBindingComplete += TablaUsuarios_DataBindingComplete; // Asociar el evento

            MostrarEmpleadosActivos(); // Carga inicial de empleados activos

            mostrarempleado();


        }
        private void TablaUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Llama al método que actualiza los botones
            ActualizarTextoBotones();
        }



        public void mostrarempleado()
        {
            N_Usuario objNegocio = new N_Usuario();
            lbltrabajadores.Text =  Convert.ToString(TablaUsuarios.RowCount);
            F_Variables.sumaremple = lbltrabajadores.Text;
            int totalProveedoresActivos = objNegocios.ContarProveedoresActivos();
            lblProveedoresActivos.Text = totalProveedoresActivos.ToString();
            lblProductosHabilitados.Text = objNegocioxd.ContarProductosHabilitados().ToString();
            lblProductosInhabilitados.Text = objNegocioxd.ContarProductosInhabilitados().ToString();
            lblproducbajostock.Text = objNegocioss.ObtenerProductosBajoStock(10).ToString(); // Stock mínimo = 10
            int totalClientesActivos = objNegocioss.ContarClientesActivos();
            lblclientesactivos.Text = totalClientesActivos.ToString();
        }
        private void MostrarEmpleadosActivos()
        {
            mostrandoActivos = true;
            var empleadosActivos = objuser.ListarEmpleados(true); // Listar solo empleados activos

            if (empleadosActivos != null && empleadosActivos.Rows.Count > 0)
            {
                TablaUsuarios.DataSource = empleadosActivos;
                lbltrabajadores.Text = Convert.ToString(TablaUsuarios.RowCount);

            }
            else
            {
                TablaUsuarios.DataSource = null;
                MessageBox.Show("No hay empleados activos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ConfigurarTablaEmpleados(); // Configurar columnas
            TablaUsuarios.Refresh();   // Refrescar la tabla para asegurarse de que las celdas estén disponibles
            ActualizarTextoBotones();  // Ahora actualiza los botones
            lblEstadoEmpleados.Text = "Mostrando: Activos";
        }

        private void MostrarEmpleadosInactivos()
        {
            mostrandoActivos = false;
            var empleadosInactivos = objuser.ListarEmpleados(false); // Listar solo empleados inactivos

            if (empleadosInactivos != null && empleadosInactivos.Rows.Count > 0)
            {
                TablaUsuarios.DataSource = empleadosInactivos;
                lbltrabajadores.Text = Convert.ToString(TablaUsuarios.RowCount);

            }
            else
            {
                TablaUsuarios.DataSource = null;
                MessageBox.Show("No hay empleados inactivos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ConfigurarTablaEmpleados(); // Configurar columnas
            TablaUsuarios.Refresh();   // Refrescar la tabla para asegurarse de que las celdas estén disponibles
            ActualizarTextoBotones();  // Ahora actualiza los botones
            lblEstadoEmpleados.Text = "Mostrando: Inactivos";
        }

        private void ActualizarTextoBotones()
        {
             foreach (DataGridViewRow row in TablaUsuarios.Rows)
            {
                if (row.Cells["estado_emp"] != null && row.Cells["CAMBIAR_ESTADO"] != null &&
                    row.Cells["estado_emp"].Value != null)
                {
                    bool estadoActual = Convert.ToBoolean(row.Cells["estado_emp"].Value);
                    row.Cells["CAMBIAR_ESTADO"].Value = estadoActual ? "Desactivar" : "Activar";
                }
            }
        }


        private void ConfigurarTablaEmpleados()
        {
            if (TablaUsuarios.Columns.Count == 0) return;

            // Configuración de estilos para la cabecera
            TablaUsuarios.EnableHeadersVisualStyles = false;
            TablaUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64); // Gris oscuro
            TablaUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TablaUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11);

            // Ocultar columnas innecesarias
            if (TablaUsuarios.Columns.Contains("id_empleado"))
                TablaUsuarios.Columns["id_empleado"].Visible = false;

            if (TablaUsuarios.Columns.Contains("idrol"))
                TablaUsuarios.Columns["idrol"].Visible = false;

            if (TablaUsuarios.Columns.Contains("estado_emp"))
                TablaUsuarios.Columns["estado_emp"].Visible = false;

            // Agregar columna de edición si no existe
            if (!TablaUsuarios.Columns.Contains("EDITAR"))
            {
                DataGridViewButtonColumn editarColumna = new DataGridViewButtonColumn
                {
                    Name = "EDITAR",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                TablaUsuarios.Columns.Add(editarColumna);
            }

            // Agregar columna de activación/desactivación si no existe
            if (!TablaUsuarios.Columns.Contains("CAMBIAR_ESTADO"))
            {
                DataGridViewButtonColumn cambiarEstadoColumna = new DataGridViewButtonColumn
                {
                    Name = "CAMBIAR_ESTADO",
                    HeaderText = "Acción",
                    UseColumnTextForButtonValue = false, // Para configurar el texto dinámicamente
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                TablaUsuarios.Columns.Add(cambiarEstadoColumna);
            }

            // Ajustar posición de las columnas de botones
            if (TablaUsuarios.Columns.Contains("EDITAR"))
                TablaUsuarios.Columns["EDITAR"].DisplayIndex = TablaUsuarios.Columns.Count - 2;

            if (TablaUsuarios.Columns.Contains("CAMBIAR_ESTADO"))
                TablaUsuarios.Columns["CAMBIAR_ESTADO"].DisplayIndex = TablaUsuarios.Columns.Count - 1;
        }





        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {// Abrir el formulario para agregar empleado
            frmAgregarEmpleado frm = new frmAgregarEmpleado
            {
                Update = false
            };

            // Mostrar el formulario y esperar hasta que se cierre
            frm.ShowDialog();

            // Actualizar la lista de empleados según el estado actual
            if (frm.EmpleadoAgregado) // Si se agregó un empleado
            {
                if (mostrandoActivos)
                {
                    MostrarEmpleadosActivos();
                }
                else
                {
                    MostrarEmpleadosInactivos();
                }

                // Llamar al método mostrarempleado para actualizar indicadores
                mostrarempleado();
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FrmVerrolesCOmpletos frm = new FrmVerrolesCOmpletos();
            frm.ShowDialog();
        }

        public void buscarUsuario(string buscaremp)
        {
            N_Usuario objNegocio = new N_Usuario();
            TablaUsuarios.DataSource = objNegocio.BuscarEmpleado(buscaremp, mostrandoActivos);
        }

        private void txbBuscarempleado_TextChanged(object sender, EventArgs e)
        {
            buscarUsuario(txbBuscarempleado.Text);
        }

        private void TablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TablaUsuarios.Rows[e.RowIndex].Cells["CAMBIAR_ESTADO"].Selected)
            {

                // Cambiar el estado del empleado
                int empleadoId = Convert.ToInt32(TablaUsuarios.Rows[e.RowIndex].Cells["id_empleado"].Value);
                bool estadoActual = Convert.ToBoolean(TablaUsuarios.Rows[e.RowIndex].Cells["estado_emp"].Value);

                string mensaje = estadoActual ? "¿Estás seguro de desactivar este empleado?" : "¿Estás seguro de activar este empleado?";
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             

                if (resultado == DialogResult.Yes)
                {
                    objuser.CambiarEstadoEmpleado(empleadoId, !estadoActual); // Cambiar el estado en la base de datos
                    MessageBox.Show(estadoActual ? "Empleado desactivado exitosamente." : "Empleado activado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (mostrandoActivos) MostrarEmpleadosActivos();
                    else MostrarEmpleadosInactivos();
                    mostrarempleado();
                }
            }
            else if (TablaUsuarios.Rows[e.RowIndex].Cells["EDITAR"].Selected)
            {
                // Editar el empleado
                frmAgregarEmpleado frm = new frmAgregarEmpleado
                {
                    Update = true,
                    txtIdEmpleado = TablaUsuarios.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString(),
                    txtxiidrol = TablaUsuarios.Rows[e.RowIndex].Cells["idrol"].Value.ToString() // Asigna el ID del rol correctamente

                };
                frm.txtIdEmpleado = TablaUsuarios.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString();
                frm.txtNombreEM.Text = TablaUsuarios.Rows[e.RowIndex].Cells["nombre_emp"].Value.ToString();
                frm.txtTelefonoEM.Text = TablaUsuarios.Rows[e.RowIndex].Cells["telefono_emp"].Value.ToString();
                frm.txtEmailemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["email"].Value.ToString();
                frm.txtNmrDocemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["num_documento_emp"].Value.ToString();
                frm.txtDireccionemp.Text = TablaUsuarios.Rows[e.RowIndex].Cells["direccion_emp"].Value.ToString();

                frm.ShowDialog();
                mostrarempleado();

                if (mostrandoActivos) MostrarEmpleadosActivos();
                else MostrarEmpleadosInactivos();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btnoinahbilitados_Click(object sender, EventArgs e)
        {
            if (mostrandoActivos)
            {
                MostrarEmpleadosInactivos();
                Btnoinahbilitados.ButtonText = "Mostrar Activos";
            }
            else
            {
                MostrarEmpleadosActivos();
                Btnoinahbilitados.ButtonText = "Mostrar Inactivos";}

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
    
}
