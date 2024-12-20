
namespace CapaPresentacion
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.Header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUSER = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcreador = new System.Windows.Forms.Label();
            this.flecha = new System.Windows.Forms.PictureBox();
            this.btnAcceso = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnServicio = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDiagnostico = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPRoductos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClientes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Header.Controls.Add(this.label1);
            this.Header.Controls.Add(this.Salir);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(270, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1170, 60);
            this.Header.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "INTEGRATING PROJECT";
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Image = global::CapaPresentacion.Properties.Resources.SalirSistema;
            this.Salir.Location = new System.Drawing.Point(1123, 12);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(35, 34);
            this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Salir.TabIndex = 0;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(270, 60);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(1170, 840);
            this.Wrapper.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "LUBRICENTRO";
            // 
            // lblUSER
            // 
            this.lblUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSER.ForeColor = System.Drawing.Color.White;
            this.lblUSER.Location = new System.Drawing.Point(52, 229);
            this.lblUSER.Name = "lblUSER";
            this.lblUSER.Size = new System.Drawing.Size(152, 26);
            this.lblUSER.TabIndex = 5;
            this.lblUSER.Text = "ADMIN";
            this.lblUSER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUSER.Click += new System.EventHandler(this.lblUSER_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(32)))));
            this.sidebar.Controls.Add(this.label3);
            this.sidebar.Controls.Add(this.txtcreador);
            this.sidebar.Controls.Add(this.flecha);
            this.sidebar.Controls.Add(this.btnAcceso);
            this.sidebar.Controls.Add(this.btnServicio);
            this.sidebar.Controls.Add(this.btnDiagnostico);
            this.sidebar.Controls.Add(this.btnPRoductos);
            this.sidebar.Controls.Add(this.btnClientes);
            this.sidebar.Controls.Add(this.pictureBox4);
            this.sidebar.Controls.Add(this.lblUSER);
            this.sidebar.Controls.Add(this.pictureBox3);
            this.sidebar.Controls.Add(this.pictureBox2);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.pictureBox1);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(270, 900);
            this.sidebar.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 842);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 33);
            this.label3.TabIndex = 15;
            this.label3.Text = "BIENVENIDO";
            // 
            // txtcreador
            // 
            this.txtcreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreador.ForeColor = System.Drawing.Color.White;
            this.txtcreador.Location = new System.Drawing.Point(12, 875);
            this.txtcreador.Name = "txtcreador";
            this.txtcreador.Size = new System.Drawing.Size(243, 58);
            this.txtcreador.TabIndex = 14;
            this.txtcreador.Text = "LUBRICENTRO";
            this.txtcreador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flecha
            // 
            this.flecha.Image = global::CapaPresentacion.Properties.Resources.Flecha;
            this.flecha.Location = new System.Drawing.Point(221, 323);
            this.flecha.Name = "flecha";
            this.flecha.Size = new System.Drawing.Size(49, 50);
            this.flecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flecha.TabIndex = 13;
            this.flecha.TabStop = false;
            // 
            // btnAcceso
            // 
            this.btnAcceso.Activecolor = System.Drawing.Color.Transparent;
            this.btnAcceso.BackColor = System.Drawing.Color.Transparent;
            this.btnAcceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAcceso.BorderRadius = 0;
            this.btnAcceso.ButtonText = "         ACCESO";
            this.btnAcceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceso.DisabledColor = System.Drawing.Color.Gray;
            this.btnAcceso.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAcceso.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAcceso.Iconimage")));
            this.btnAcceso.Iconimage_right = null;
            this.btnAcceso.Iconimage_right_Selected = null;
            this.btnAcceso.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.acceso_verde;
            this.btnAcceso.IconMarginLeft = 0;
            this.btnAcceso.IconMarginRight = 0;
            this.btnAcceso.IconRightVisible = true;
            this.btnAcceso.IconRightZoom = 0D;
            this.btnAcceso.IconVisible = true;
            this.btnAcceso.IconZoom = 90D;
            this.btnAcceso.IsTab = true;
            this.btnAcceso.Location = new System.Drawing.Point(12, 685);
            this.btnAcceso.Name = "btnAcceso";
            this.btnAcceso.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAcceso.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnAcceso.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnAcceso.selected = false;
            this.btnAcceso.Size = new System.Drawing.Size(255, 48);
            this.btnAcceso.TabIndex = 12;
            this.btnAcceso.Text = "         ACCESO";
            this.btnAcceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcceso.Textcolor = System.Drawing.Color.White;
            this.btnAcceso.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceso.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Activecolor = System.Drawing.Color.Transparent;
            this.btnServicio.BackColor = System.Drawing.Color.Transparent;
            this.btnServicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnServicio.BorderRadius = 0;
            this.btnServicio.ButtonText = "         SERVICIO";
            this.btnServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicio.DisabledColor = System.Drawing.Color.Gray;
            this.btnServicio.Iconcolor = System.Drawing.Color.Transparent;
            this.btnServicio.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnServicio.Iconimage")));
            this.btnServicio.Iconimage_right = null;
            this.btnServicio.Iconimage_right_Selected = null;
            this.btnServicio.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.comprobante_verde;
            this.btnServicio.IconMarginLeft = 0;
            this.btnServicio.IconMarginRight = 0;
            this.btnServicio.IconRightVisible = true;
            this.btnServicio.IconRightZoom = 0D;
            this.btnServicio.IconVisible = true;
            this.btnServicio.IconZoom = 90D;
            this.btnServicio.IsTab = true;
            this.btnServicio.Location = new System.Drawing.Point(12, 508);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Normalcolor = System.Drawing.Color.Transparent;
            this.btnServicio.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnServicio.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnServicio.selected = false;
            this.btnServicio.Size = new System.Drawing.Size(255, 48);
            this.btnServicio.TabIndex = 11;
            this.btnServicio.Text = "         SERVICIO";
            this.btnServicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicio.Textcolor = System.Drawing.Color.White;
            this.btnServicio.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicio.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // btnDiagnostico
            // 
            this.btnDiagnostico.Activecolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.BackColor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiagnostico.BorderRadius = 0;
            this.btnDiagnostico.ButtonText = "      MOVIMIENTO";
            this.btnDiagnostico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiagnostico.DisabledColor = System.Drawing.Color.Gray;
            this.btnDiagnostico.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.Iconimage = global::CapaPresentacion.Properties.Resources.clientesssss;
            this.btnDiagnostico.Iconimage_right = null;
            this.btnDiagnostico.Iconimage_right_Selected = null;
            this.btnDiagnostico.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.servicio_verde1;
            this.btnDiagnostico.IconMarginLeft = 0;
            this.btnDiagnostico.IconMarginRight = 0;
            this.btnDiagnostico.IconRightVisible = true;
            this.btnDiagnostico.IconRightZoom = 0D;
            this.btnDiagnostico.IconVisible = true;
            this.btnDiagnostico.IconZoom = 90D;
            this.btnDiagnostico.IsTab = true;
            this.btnDiagnostico.Location = new System.Drawing.Point(12, 422);
            this.btnDiagnostico.Name = "btnDiagnostico";
            this.btnDiagnostico.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnDiagnostico.selected = false;
            this.btnDiagnostico.Size = new System.Drawing.Size(258, 48);
            this.btnDiagnostico.TabIndex = 10;
            this.btnDiagnostico.Text = "      MOVIMIENTO";
            this.btnDiagnostico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiagnostico.Textcolor = System.Drawing.Color.White;
            this.btnDiagnostico.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiagnostico.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // btnPRoductos
            // 
            this.btnPRoductos.Activecolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.BackColor = System.Drawing.Color.Transparent;
            this.btnPRoductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPRoductos.BorderRadius = 0;
            this.btnPRoductos.ButtonText = "       PRODUCTOS";
            this.btnPRoductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPRoductos.DisabledColor = System.Drawing.Color.Gray;
            this.btnPRoductos.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnPRoductos.Iconimage")));
            this.btnPRoductos.Iconimage_right = null;
            this.btnPRoductos.Iconimage_right_Selected = null;
            this.btnPRoductos.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.VENTAPRODUCTOSVERDES;
            this.btnPRoductos.IconMarginLeft = 0;
            this.btnPRoductos.IconMarginRight = 0;
            this.btnPRoductos.IconRightVisible = true;
            this.btnPRoductos.IconRightZoom = 0D;
            this.btnPRoductos.IconVisible = true;
            this.btnPRoductos.IconZoom = 90D;
            this.btnPRoductos.IsTab = true;
            this.btnPRoductos.Location = new System.Drawing.Point(12, 593);
            this.btnPRoductos.Name = "btnPRoductos";
            this.btnPRoductos.Normalcolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnPRoductos.selected = false;
            this.btnPRoductos.Size = new System.Drawing.Size(255, 48);
            this.btnPRoductos.TabIndex = 9;
            this.btnPRoductos.Text = "       PRODUCTOS";
            this.btnPRoductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPRoductos.Textcolor = System.Drawing.Color.White;
            this.btnPRoductos.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPRoductos.Click += new System.EventHandler(this.btnPRoductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Activecolor = System.Drawing.Color.Transparent;
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClientes.BorderRadius = 0;
            this.btnClientes.ButtonText = "         CLIENTES";
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.DisabledColor = System.Drawing.Color.Gray;
            this.btnClientes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClientes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnClientes.Iconimage")));
            this.btnClientes.Iconimage_right = null;
            this.btnClientes.Iconimage_right_Selected = null;
            this.btnClientes.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.CXLIENTEEEEEE_VERDFFEEEEEEEEEEE;
            this.btnClientes.IconMarginLeft = 0;
            this.btnClientes.IconMarginRight = 0;
            this.btnClientes.IconRightVisible = true;
            this.btnClientes.IconRightZoom = 0D;
            this.btnClientes.IconVisible = true;
            this.btnClientes.IconZoom = 90D;
            this.btnClientes.IsTab = true;
            this.btnClientes.Location = new System.Drawing.Point(12, 323);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Normalcolor = System.Drawing.Color.Transparent;
            this.btnClientes.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnClientes.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(195)))), ((int)(((byte)(140)))));
            this.btnClientes.selected = false;
            this.btnClientes.Size = new System.Drawing.Size(258, 48);
            this.btnClientes.TabIndex = 7;
            this.btnClientes.Text = "         CLIENTES";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Textcolor = System.Drawing.Color.White;
            this.btnClientes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.icons8_línea_horizontal_50;
            this.pictureBox4.Location = new System.Drawing.Point(12, 280);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(243, 10);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.Administrador;
            this.pictureBox3.Location = new System.Drawing.Point(71, 92);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 120);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.icons8_línea_horizontal_50;
            this.pictureBox2.Location = new System.Drawing.Point(12, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.cat;
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel sidebar;
        private Bunifu.Framework.UI.BunifuFlatButton btnClientes;
        private Bunifu.Framework.UI.BunifuFlatButton btnPRoductos;
        private Bunifu.Framework.UI.BunifuFlatButton btnServicio;
        private Bunifu.Framework.UI.BunifuFlatButton btnDiagnostico;
        private Bunifu.Framework.UI.BunifuFlatButton btnAcceso;
        private System.Windows.Forms.PictureBox flecha;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblUSER;
        public System.Windows.Forms.Label txtcreador;
    }
}