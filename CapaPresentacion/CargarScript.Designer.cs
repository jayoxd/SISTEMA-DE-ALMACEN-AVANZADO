
namespace CapaPresentacion
{
    partial class CargarScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarScript));
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtRutaScript = new System.Windows.Forms.TextBox();
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.MoverCliente = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Movervehiculo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtnrEMPLEADO = new System.Windows.Forms.TextBox();
            this.txtnroRol = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnAgregarEmpleado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEjecutarScript = new Bunifu.Framework.UI.BunifuFlatButton();
            this.PanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // txtRutaScript
            // 
            this.txtRutaScript.BackColor = System.Drawing.Color.White;
            this.txtRutaScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRutaScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtRutaScript.ForeColor = System.Drawing.Color.Gray;
            this.txtRutaScript.Location = new System.Drawing.Point(26, 86);
            this.txtRutaScript.Name = "txtRutaScript";
            this.txtRutaScript.Size = new System.Drawing.Size(475, 17);
            this.txtRutaScript.TabIndex = 139;
            // 
            // PanelCliente
            // 
            this.PanelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.PanelCliente.Controls.Add(this.label1);
            this.PanelCliente.Controls.Add(this.pictureBox14);
            this.PanelCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCliente.Location = new System.Drawing.Point(0, 0);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Size = new System.Drawing.Size(523, 39);
            this.PanelCliente.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CARGA DE SCRIPT SQL";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox14.Location = new System.Drawing.Point(486, 3);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 130;
            this.label2.Text = "RUTA";
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
            // pictureBox7
            // 
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox7.Location = new System.Drawing.Point(15, 73);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(499, 44);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 138;
            this.pictureBox7.TabStop = false;
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarEmpleado.BorderRadius = 7;
            this.btnAgregarEmpleado.ButtonText = " SELECCIONAR ARHIVO";
            this.btnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpleado.DisabledColor = System.Drawing.Color.Gray;
            this.btnAgregarEmpleado.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAgregarEmpleado.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAgregarEmpleado.Iconimage")));
            this.btnAgregarEmpleado.Iconimage_right = null;
            this.btnAgregarEmpleado.Iconimage_right_Selected = null;
            this.btnAgregarEmpleado.Iconimage_Selected = null;
            this.btnAgregarEmpleado.IconMarginLeft = 0;
            this.btnAgregarEmpleado.IconMarginRight = 0;
            this.btnAgregarEmpleado.IconRightVisible = true;
            this.btnAgregarEmpleado.IconRightZoom = 0D;
            this.btnAgregarEmpleado.IconVisible = true;
            this.btnAgregarEmpleado.IconZoom = 60D;
            this.btnAgregarEmpleado.IsTab = false;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(160, 131);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.OnHovercolor = System.Drawing.Color.DarkSeaGreen;
            this.btnAgregarEmpleado.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.selected = false;
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(204, 49);
            this.btnAgregarEmpleado.TabIndex = 136;
            this.btnAgregarEmpleado.Text = " SELECCIONAR ARHIVO";
            this.btnAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarEmpleado.Textcolor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // btnEjecutarScript
            // 
            this.btnEjecutarScript.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnEjecutarScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnEjecutarScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEjecutarScript.BorderRadius = 7;
            this.btnEjecutarScript.ButtonText = "  EJECUTAR SCRIPT";
            this.btnEjecutarScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjecutarScript.DisabledColor = System.Drawing.Color.Gray;
            this.btnEjecutarScript.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEjecutarScript.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEjecutarScript.Iconimage")));
            this.btnEjecutarScript.Iconimage_right = null;
            this.btnEjecutarScript.Iconimage_right_Selected = null;
            this.btnEjecutarScript.Iconimage_Selected = null;
            this.btnEjecutarScript.IconMarginLeft = 0;
            this.btnEjecutarScript.IconMarginRight = 0;
            this.btnEjecutarScript.IconRightVisible = true;
            this.btnEjecutarScript.IconRightZoom = 0D;
            this.btnEjecutarScript.IconVisible = true;
            this.btnEjecutarScript.IconZoom = 60D;
            this.btnEjecutarScript.IsTab = false;
            this.btnEjecutarScript.Location = new System.Drawing.Point(160, 200);
            this.btnEjecutarScript.Name = "btnEjecutarScript";
            this.btnEjecutarScript.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.btnEjecutarScript.OnHovercolor = System.Drawing.Color.RosyBrown;
            this.btnEjecutarScript.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEjecutarScript.selected = false;
            this.btnEjecutarScript.Size = new System.Drawing.Size(204, 49);
            this.btnEjecutarScript.TabIndex = 167;
            this.btnEjecutarScript.Text = "  EJECUTAR SCRIPT";
            this.btnEjecutarScript.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEjecutarScript.Textcolor = System.Drawing.Color.White;
            this.btnEjecutarScript.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutarScript.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // CargarScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(523, 272);
            this.Controls.Add(this.btnEjecutarScript);
            this.Controls.Add(this.txtnroRol);
            this.Controls.Add(this.txtnrEMPLEADO);
            this.Controls.Add(this.txtRutaScript);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CargarScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarEmpleado";
            this.Load += new System.EventHandler(this.frmAgregarEmpleado_Load);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        public System.Windows.Forms.TextBox txtRutaScript;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuFlatButton btnAgregarEmpleado;
        private Bunifu.Framework.UI.BunifuDragControl MoverCliente;
        private Bunifu.Framework.UI.BunifuDragControl Movervehiculo;
        public System.Windows.Forms.TextBox txtiidrol;
        public System.Windows.Forms.TextBox txtnrEMPLEADO;
        public System.Windows.Forms.TextBox txtnroRol;
        private Bunifu.Framework.UI.BunifuFlatButton btnEjecutarScript;
    }
}