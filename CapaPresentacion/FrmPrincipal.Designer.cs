
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
            this.Wrapper = new System.Windows.Forms.Panel();
            this.lblUSER = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcreador = new System.Windows.Forms.Label();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnclientes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnproveedores = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReportes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.flecha = new System.Windows.Forms.PictureBox();
            this.btnAcceso = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnServicio = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDiagnostico = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPRoductos = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnKardex = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Header.SuspendLayout();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.Header.Size = new System.Drawing.Size(324, 60);
            this.Header.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROYECT V02";
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(270, 60);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(324, 293);
            this.Wrapper.TabIndex = 2;
            // 
            // lblUSER
            // 
            this.lblUSER.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSER.ForeColor = System.Drawing.Color.White;
            this.lblUSER.Location = new System.Drawing.Point(52, 260);
            this.lblUSER.Name = "lblUSER";
            this.lblUSER.Size = new System.Drawing.Size(152, 26);
            this.lblUSER.TabIndex = 5;
            this.lblUSER.Text = "ADMIN";
            this.lblUSER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUSER.Click += new System.EventHandler(this.lblUSER_Click);
            // 
            // sidebar
            // 
            this.sidebar.AutoScroll = true;
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(62)))), ((int)(((byte)(92)))));
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.btnclientes);
            this.sidebar.Controls.Add(this.btnproveedores);
            this.sidebar.Controls.Add(this.btnReportes);
            this.sidebar.Controls.Add(this.label3);
            this.sidebar.Controls.Add(this.txtcreador);
            this.sidebar.Controls.Add(this.flecha);
            this.sidebar.Controls.Add(this.btnAcceso);
            this.sidebar.Controls.Add(this.btnServicio);
            this.sidebar.Controls.Add(this.btnDiagnostico);
            this.sidebar.Controls.Add(this.btnPRoductos);
            this.sidebar.Controls.Add(this.pictureBox4);
            this.sidebar.Controls.Add(this.lblUSER);
            this.sidebar.Controls.Add(this.pictureBox3);
            this.sidebar.Controls.Add(this.pictureBox2);
            this.sidebar.Controls.Add(this.btnKardex);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(270, 353);
            this.sidebar.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "DISEÑO WEB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(63, 863);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 33);
            this.label3.TabIndex = 15;
            this.label3.Text = "BIENVENIDO";
            // 
            // txtcreador
            // 
            this.txtcreador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcreador.ForeColor = System.Drawing.Color.White;
            this.txtcreador.Location = new System.Drawing.Point(11, 877);
            this.txtcreador.Name = "txtcreador";
            this.txtcreador.Size = new System.Drawing.Size(243, 58);
            this.txtcreador.TabIndex = 14;
            this.txtcreador.Text = "LUBRICENTRO";
            this.txtcreador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Image = global::CapaPresentacion.Properties.Resources.SalirSistema;
            this.Salir.Location = new System.Drawing.Point(277, 12);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(35, 34);
            this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Salir.TabIndex = 0;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.LANMEITRANSP;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnclientes
            // 
            this.btnclientes.Activecolor = System.Drawing.Color.Transparent;
            this.btnclientes.BackColor = System.Drawing.Color.Transparent;
            this.btnclientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclientes.BorderRadius = 0;
            this.btnclientes.ButtonText = "        CLIENTES";
            this.btnclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclientes.DisabledColor = System.Drawing.Color.Gray;
            this.btnclientes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnclientes.Iconimage = global::CapaPresentacion.Properties.Resources.clientesssss;
            this.btnclientes.Iconimage_right = null;
            this.btnclientes.Iconimage_right_Selected = null;
            this.btnclientes.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnclientes.Iconimage_Selected")));
            this.btnclientes.IconMarginLeft = 0;
            this.btnclientes.IconMarginRight = 0;
            this.btnclientes.IconRightVisible = true;
            this.btnclientes.IconRightZoom = 0D;
            this.btnclientes.IconVisible = true;
            this.btnclientes.IconZoom = 90D;
            this.btnclientes.IsTab = true;
            this.btnclientes.Location = new System.Drawing.Point(15, 449);
            this.btnclientes.Margin = new System.Windows.Forms.Padding(7);
            this.btnclientes.Name = "btnclientes";
            this.btnclientes.Normalcolor = System.Drawing.Color.Transparent;
            this.btnclientes.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnclientes.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnclientes.selected = false;
            this.btnclientes.Size = new System.Drawing.Size(255, 48);
            this.btnclientes.TabIndex = 19;
            this.btnclientes.Text = "        CLIENTES";
            this.btnclientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclientes.Textcolor = System.Drawing.Color.White;
            this.btnclientes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclientes.Click += new System.EventHandler(this.btnclientes_Click_1);
            // 
            // btnproveedores
            // 
            this.btnproveedores.Activecolor = System.Drawing.Color.Transparent;
            this.btnproveedores.BackColor = System.Drawing.Color.Transparent;
            this.btnproveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnproveedores.BorderRadius = 0;
            this.btnproveedores.ButtonText = "        PROVEEDORES";
            this.btnproveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnproveedores.DisabledColor = System.Drawing.Color.Gray;
            this.btnproveedores.Iconcolor = System.Drawing.Color.Transparent;
            this.btnproveedores.Iconimage = global::CapaPresentacion.Properties.Resources.clientesssss;
            this.btnproveedores.Iconimage_right = null;
            this.btnproveedores.Iconimage_right_Selected = null;
            this.btnproveedores.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnproveedores.Iconimage_Selected")));
            this.btnproveedores.IconMarginLeft = 0;
            this.btnproveedores.IconMarginRight = 0;
            this.btnproveedores.IconRightVisible = true;
            this.btnproveedores.IconRightZoom = 0D;
            this.btnproveedores.IconVisible = true;
            this.btnproveedores.IconZoom = 90D;
            this.btnproveedores.IsTab = true;
            this.btnproveedores.Location = new System.Drawing.Point(15, 514);
            this.btnproveedores.Margin = new System.Windows.Forms.Padding(7);
            this.btnproveedores.Name = "btnproveedores";
            this.btnproveedores.Normalcolor = System.Drawing.Color.Transparent;
            this.btnproveedores.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnproveedores.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnproveedores.selected = false;
            this.btnproveedores.Size = new System.Drawing.Size(255, 48);
            this.btnproveedores.TabIndex = 18;
            this.btnproveedores.Text = "        PROVEEDORES";
            this.btnproveedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproveedores.Textcolor = System.Drawing.Color.White;
            this.btnproveedores.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproveedores.Click += new System.EventHandler(this.btnproveedores_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Activecolor = System.Drawing.Color.Transparent;
            this.btnReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportes.BorderRadius = 0;
            this.btnReportes.ButtonText = "        REPORTES";
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.DisabledColor = System.Drawing.Color.Gray;
            this.btnReportes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReportes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnReportes.Iconimage")));
            this.btnReportes.Iconimage_right = null;
            this.btnReportes.Iconimage_right_Selected = null;
            this.btnReportes.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.VENTAPRODUCTOSVERDES;
            this.btnReportes.IconMarginLeft = 0;
            this.btnReportes.IconMarginRight = 0;
            this.btnReportes.IconRightVisible = true;
            this.btnReportes.IconRightZoom = 0D;
            this.btnReportes.IconVisible = true;
            this.btnReportes.IconZoom = 90D;
            this.btnReportes.IsTab = true;
            this.btnReportes.Location = new System.Drawing.Point(15, 379);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(7);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Normalcolor = System.Drawing.Color.Transparent;
            this.btnReportes.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnReportes.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnReportes.selected = false;
            this.btnReportes.Size = new System.Drawing.Size(255, 48);
            this.btnReportes.TabIndex = 17;
            this.btnReportes.Text = "        REPORTES";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Textcolor = System.Drawing.Color.White;
            this.btnReportes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Click += new System.EventHandler(this.bunifuFlatButton1_Click_1);
            // 
            // flecha
            // 
            this.flecha.Image = global::CapaPresentacion.Properties.Resources.Flecha;
            this.flecha.Location = new System.Drawing.Point(221, 308);
            this.flecha.Name = "flecha";
            this.flecha.Size = new System.Drawing.Size(49, 50);
            this.flecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flecha.TabIndex = 13;
            this.flecha.TabStop = false;
            this.flecha.Click += new System.EventHandler(this.flecha_Click);
            // 
            // btnAcceso
            // 
            this.btnAcceso.Activecolor = System.Drawing.Color.Transparent;
            this.btnAcceso.BackColor = System.Drawing.Color.Transparent;
            this.btnAcceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAcceso.BorderRadius = 0;
            this.btnAcceso.ButtonText = "        ACCESO";
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
            this.btnAcceso.Location = new System.Drawing.Point(15, 785);
            this.btnAcceso.Margin = new System.Windows.Forms.Padding(7);
            this.btnAcceso.Name = "btnAcceso";
            this.btnAcceso.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAcceso.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnAcceso.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnAcceso.selected = false;
            this.btnAcceso.Size = new System.Drawing.Size(255, 48);
            this.btnAcceso.TabIndex = 12;
            this.btnAcceso.Text = "        ACCESO";
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
            this.btnServicio.ButtonText = "        SALIDA";
            this.btnServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicio.DisabledColor = System.Drawing.Color.Gray;
            this.btnServicio.Iconcolor = System.Drawing.Color.Transparent;
            this.btnServicio.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnServicio.Iconimage")));
            this.btnServicio.Iconimage_right = null;
            this.btnServicio.Iconimage_right_Selected = null;
            this.btnServicio.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnServicio.Iconimage_Selected")));
            this.btnServicio.IconMarginLeft = 0;
            this.btnServicio.IconMarginRight = 0;
            this.btnServicio.IconRightVisible = true;
            this.btnServicio.IconRightZoom = 0D;
            this.btnServicio.IconVisible = true;
            this.btnServicio.IconZoom = 90D;
            this.btnServicio.IsTab = true;
            this.btnServicio.Location = new System.Drawing.Point(13, 651);
            this.btnServicio.Margin = new System.Windows.Forms.Padding(7);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Normalcolor = System.Drawing.Color.Transparent;
            this.btnServicio.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnServicio.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnServicio.selected = false;
            this.btnServicio.Size = new System.Drawing.Size(255, 48);
            this.btnServicio.TabIndex = 11;
            this.btnServicio.Text = "        SALIDA";
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
            this.btnDiagnostico.ButtonText = "        ENTRADA";
            this.btnDiagnostico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiagnostico.DisabledColor = System.Drawing.Color.Gray;
            this.btnDiagnostico.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDiagnostico.Iconimage")));
            this.btnDiagnostico.Iconimage_right = null;
            this.btnDiagnostico.Iconimage_right_Selected = null;
            this.btnDiagnostico.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnDiagnostico.Iconimage_Selected")));
            this.btnDiagnostico.IconMarginLeft = 0;
            this.btnDiagnostico.IconMarginRight = 0;
            this.btnDiagnostico.IconRightVisible = true;
            this.btnDiagnostico.IconRightZoom = 0D;
            this.btnDiagnostico.IconVisible = true;
            this.btnDiagnostico.IconZoom = 90D;
            this.btnDiagnostico.IsTab = true;
            this.btnDiagnostico.Location = new System.Drawing.Point(15, 583);
            this.btnDiagnostico.Margin = new System.Windows.Forms.Padding(7);
            this.btnDiagnostico.Name = "btnDiagnostico";
            this.btnDiagnostico.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnDiagnostico.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnDiagnostico.selected = false;
            this.btnDiagnostico.Size = new System.Drawing.Size(255, 48);
            this.btnDiagnostico.TabIndex = 10;
            this.btnDiagnostico.Text = "        ENTRADA";
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
            this.btnPRoductos.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btnPRoductos.Iconimage_Selected")));
            this.btnPRoductos.IconMarginLeft = 0;
            this.btnPRoductos.IconMarginRight = 0;
            this.btnPRoductos.IconRightVisible = true;
            this.btnPRoductos.IconRightZoom = 0D;
            this.btnPRoductos.IconVisible = true;
            this.btnPRoductos.IconZoom = 90D;
            this.btnPRoductos.IsTab = true;
            this.btnPRoductos.Location = new System.Drawing.Point(15, 718);
            this.btnPRoductos.Margin = new System.Windows.Forms.Padding(7);
            this.btnPRoductos.Name = "btnPRoductos";
            this.btnPRoductos.Normalcolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnPRoductos.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnPRoductos.selected = false;
            this.btnPRoductos.Size = new System.Drawing.Size(255, 48);
            this.btnPRoductos.TabIndex = 9;
            this.btnPRoductos.Text = "       PRODUCTOS";
            this.btnPRoductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPRoductos.Textcolor = System.Drawing.Color.White;
            this.btnPRoductos.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPRoductos.Click += new System.EventHandler(this.btnPRoductos_Click);
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
            this.pictureBox3.Location = new System.Drawing.Point(66, 137);
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
            this.pictureBox2.Location = new System.Drawing.Point(10, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnKardex
            // 
            this.btnKardex.Activecolor = System.Drawing.Color.Transparent;
            this.btnKardex.BackColor = System.Drawing.Color.Transparent;
            this.btnKardex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKardex.BorderRadius = 0;
            this.btnKardex.ButtonText = "        KARDEX";
            this.btnKardex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKardex.DisabledColor = System.Drawing.Color.Gray;
            this.btnKardex.Iconcolor = System.Drawing.Color.Transparent;
            this.btnKardex.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnKardex.Iconimage")));
            this.btnKardex.Iconimage_right = null;
            this.btnKardex.Iconimage_right_Selected = null;
            this.btnKardex.Iconimage_Selected = global::CapaPresentacion.Properties.Resources.VENTAPRODUCTOSVERDES;
            this.btnKardex.IconMarginLeft = 0;
            this.btnKardex.IconMarginRight = 0;
            this.btnKardex.IconRightVisible = true;
            this.btnKardex.IconRightZoom = 0D;
            this.btnKardex.IconVisible = true;
            this.btnKardex.IconZoom = 90D;
            this.btnKardex.IsTab = true;
            this.btnKardex.Location = new System.Drawing.Point(15, 308);
            this.btnKardex.Margin = new System.Windows.Forms.Padding(7);
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.Normalcolor = System.Drawing.Color.Transparent;
            this.btnKardex.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnKardex.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnKardex.selected = false;
            this.btnKardex.Size = new System.Drawing.Size(255, 48);
            this.btnKardex.TabIndex = 16;
            this.btnKardex.Text = "        KARDEX";
            this.btnKardex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKardex.Textcolor = System.Drawing.Color.White;
            this.btnKardex.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKardex.Click += new System.EventHandler(this.btnKardex_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(55, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 100);
            this.panel1.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 353);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.sidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANMEI";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel sidebar;
        private Bunifu.Framework.UI.BunifuFlatButton btnPRoductos;
        private Bunifu.Framework.UI.BunifuFlatButton btnServicio;
        private Bunifu.Framework.UI.BunifuFlatButton btnDiagnostico;
        private Bunifu.Framework.UI.BunifuFlatButton btnAcceso;
        private System.Windows.Forms.PictureBox flecha;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblUSER;
        public System.Windows.Forms.Label txtcreador;
        private Bunifu.Framework.UI.BunifuFlatButton btnKardex;
        private Bunifu.Framework.UI.BunifuFlatButton btnReportes;
        private Bunifu.Framework.UI.BunifuFlatButton btnproveedores;
        private Bunifu.Framework.UI.BunifuFlatButton btnclientes;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}