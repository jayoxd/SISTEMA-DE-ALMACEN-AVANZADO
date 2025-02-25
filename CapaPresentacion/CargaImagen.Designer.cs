
namespace CapaPresentacion
{
    partial class CargaImagen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargaImagen));
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.codigopr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.MoverCliente = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Movervehiculo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtnrEMPLEADO = new System.Windows.Forms.TextBox();
            this.txtnroRol = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnguardarimg = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAgregararchivo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.precioventa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // PanelCliente
            // 
            this.PanelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.PanelCliente.Controls.Add(this.label3);
            this.PanelCliente.Controls.Add(this.pictureBox14);
            this.PanelCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCliente.Location = new System.Drawing.Point(0, 0);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Size = new System.Drawing.Size(796, 39);
            this.PanelCliente.TabIndex = 137;
            // 
            // codigopr
            // 
            this.codigopr.AutoSize = true;
            this.codigopr.ForeColor = System.Drawing.Color.Black;
            this.codigopr.Location = new System.Drawing.Point(167, 56);
            this.codigopr.Name = "codigopr";
            this.codigopr.Size = new System.Drawing.Size(128, 13);
            this.codigopr.TabIndex = 2;
            this.codigopr.Text = "CARGA DE SCRIPT SQL";
            this.codigopr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CODIGO DE PRODUCTO";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox14.Location = new System.Drawing.Point(757, 4);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(34, 36);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 1;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // MoverCliente
            // 
            this.MoverCliente.Fixed = true;
            this.MoverCliente.Horizontal = true;
            this.MoverCliente.TargetControl = this.PanelCliente;
            this.MoverCliente.Vertical = true;
            // 
            // Movervehiculo
            // 
            this.Movervehiculo.Fixed = true;
            this.Movervehiculo.Horizontal = true;
            this.Movervehiculo.TargetControl = null;
            this.Movervehiculo.Vertical = true;
            // 
            // txtnrEMPLEADO
            // 
            this.txtnrEMPLEADO.BackColor = System.Drawing.Color.White;
            this.txtnrEMPLEADO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnrEMPLEADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrEMPLEADO.ForeColor = System.Drawing.Color.White;
            this.txtnrEMPLEADO.Location = new System.Drawing.Point(891, 45);
            this.txtnrEMPLEADO.Name = "txtnrEMPLEADO";
            this.txtnrEMPLEADO.Size = new System.Drawing.Size(96, 13);
            this.txtnrEMPLEADO.TabIndex = 162;
            // 
            // txtnroRol
            // 
            this.txtnroRol.BackColor = System.Drawing.Color.White;
            this.txtnroRol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnroRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnroRol.ForeColor = System.Drawing.Color.White;
            this.txtnroRol.Location = new System.Drawing.Point(727, 46);
            this.txtnroRol.Name = "txtnroRol";
            this.txtnroRol.Size = new System.Drawing.Size(96, 13);
            this.txtnroRol.TabIndex = 166;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalle.Location = new System.Drawing.Point(8, 116);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 92;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(776, 326);
            this.dgvDetalle.TabIndex = 217;
            // 
            // btnguardarimg
            // 
            this.btnguardarimg.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnguardarimg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnguardarimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnguardarimg.BorderRadius = 7;
            this.btnguardarimg.ButtonText = " GUARDAR";
            this.btnguardarimg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarimg.DisabledColor = System.Drawing.Color.Gray;
            this.btnguardarimg.Iconcolor = System.Drawing.Color.Transparent;
            this.btnguardarimg.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnguardarimg.Iconimage")));
            this.btnguardarimg.Iconimage_right = null;
            this.btnguardarimg.Iconimage_right_Selected = null;
            this.btnguardarimg.Iconimage_Selected = null;
            this.btnguardarimg.IconMarginLeft = 0;
            this.btnguardarimg.IconMarginRight = 0;
            this.btnguardarimg.IconRightVisible = true;
            this.btnguardarimg.IconRightZoom = 0D;
            this.btnguardarimg.IconVisible = true;
            this.btnguardarimg.IconZoom = 60D;
            this.btnguardarimg.IsTab = false;
            this.btnguardarimg.Location = new System.Drawing.Point(483, 459);
            this.btnguardarimg.Name = "btnguardarimg";
            this.btnguardarimg.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnguardarimg.OnHovercolor = System.Drawing.Color.RosyBrown;
            this.btnguardarimg.OnHoverTextColor = System.Drawing.Color.White;
            this.btnguardarimg.selected = false;
            this.btnguardarimg.Size = new System.Drawing.Size(204, 49);
            this.btnguardarimg.TabIndex = 167;
            this.btnguardarimg.Text = " GUARDAR";
            this.btnguardarimg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnguardarimg.Textcolor = System.Drawing.Color.White;
            this.btnguardarimg.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarimg.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // btnAgregararchivo
            // 
            this.btnAgregararchivo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregararchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregararchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregararchivo.BorderRadius = 7;
            this.btnAgregararchivo.ButtonText = " SELECCIONAR IMAGEN";
            this.btnAgregararchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregararchivo.DisabledColor = System.Drawing.Color.Gray;
            this.btnAgregararchivo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAgregararchivo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAgregararchivo.Iconimage")));
            this.btnAgregararchivo.Iconimage_right = null;
            this.btnAgregararchivo.Iconimage_right_Selected = null;
            this.btnAgregararchivo.Iconimage_Selected = null;
            this.btnAgregararchivo.IconMarginLeft = 0;
            this.btnAgregararchivo.IconMarginRight = 0;
            this.btnAgregararchivo.IconRightVisible = true;
            this.btnAgregararchivo.IconRightZoom = 0D;
            this.btnAgregararchivo.IconVisible = true;
            this.btnAgregararchivo.IconZoom = 60D;
            this.btnAgregararchivo.IsTab = false;
            this.btnAgregararchivo.Location = new System.Drawing.Point(144, 459);
            this.btnAgregararchivo.Name = "btnAgregararchivo";
            this.btnAgregararchivo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregararchivo.OnHovercolor = System.Drawing.Color.DarkSeaGreen;
            this.btnAgregararchivo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAgregararchivo.selected = false;
            this.btnAgregararchivo.Size = new System.Drawing.Size(204, 49);
            this.btnAgregararchivo.TabIndex = 136;
            this.btnAgregararchivo.Text = " SELECCIONAR IMAGEN";
            this.btnAgregararchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregararchivo.Textcolor = System.Drawing.Color.White;
            this.btnAgregararchivo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregararchivo.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(350, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "IMAGENES";
            // 
            // precioventa
            // 
            this.precioventa.AutoSize = true;
            this.precioventa.ForeColor = System.Drawing.Color.Black;
            this.precioventa.Location = new System.Drawing.Point(167, 84);
            this.precioventa.Name = "precioventa";
            this.precioventa.Size = new System.Drawing.Size(128, 13);
            this.precioventa.TabIndex = 219;
            this.precioventa.Text = "CARGA DE SCRIPT SQL";
            this.precioventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 218;
            this.label4.Text = "PRECIO VENTA BASICO";
            // 
            // descripcion
            // 
            this.descripcion.AutoSize = true;
            this.descripcion.ForeColor = System.Drawing.Color.Black;
            this.descripcion.Location = new System.Drawing.Point(457, 56);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(128, 13);
            this.descripcion.TabIndex = 221;
            this.descripcion.Text = "CARGA DE SCRIPT SQL";
            this.descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(350, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 220;
            this.label5.Text = "DESCRIPCIÓN";
            // 
            // stock
            // 
            this.stock.AutoSize = true;
            this.stock.ForeColor = System.Drawing.Color.Black;
            this.stock.Location = new System.Drawing.Point(457, 84);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(128, 13);
            this.stock.TabIndex = 223;
            this.stock.Text = "CARGA DE SCRIPT SQL";
            this.stock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(350, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 222;
            this.label6.Text = "STOCK ACTUAL";
            // 
            // CargaImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 520);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.precioventa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnguardarimg);
            this.Controls.Add(this.codigopr);
            this.Controls.Add(this.txtnroRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnrEMPLEADO);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.btnAgregararchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargaImagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarEmpleado";
            this.Load += new System.EventHandler(this.frmAgregarEmpleado_Load);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        private System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private Bunifu.Framework.UI.BunifuFlatButton btnAgregararchivo;
        private Bunifu.Framework.UI.BunifuDragControl MoverCliente;
        private Bunifu.Framework.UI.BunifuDragControl Movervehiculo;
        public System.Windows.Forms.TextBox txtiidrol;
        public System.Windows.Forms.TextBox txtnrEMPLEADO;
        public System.Windows.Forms.TextBox txtnroRol;
        private Bunifu.Framework.UI.BunifuFlatButton btnguardarimg;
        private System.Windows.Forms.DataGridView dgvDetalle;
        public System.Windows.Forms.Label codigopr;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label precioventa;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label descripcion;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label stock;
        private System.Windows.Forms.Label label6;
    }
}