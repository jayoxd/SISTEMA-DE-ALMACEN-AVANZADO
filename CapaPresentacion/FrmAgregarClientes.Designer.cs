﻿
namespace CapaPresentacion
{
    partial class FrmAgregarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarClientes));
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtdepart = new System.Windows.Forms.TextBox();
            this.txtdniruc = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MoverCliente = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Movervehiculo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtprovincia = new System.Windows.Forms.TextBox();
            this.txtnrEMPLEADO = new System.Windows.Forms.TextBox();
            this.txtnroRol = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAgregarEmpleado = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtdistrito = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtdireccionx = new System.Windows.Forms.TextBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtlinkgoogle = new System.Windows.Forms.TextBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbtipocliente = new System.Windows.Forms.ComboBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // txtdepart
            // 
            this.txtdepart.BackColor = System.Drawing.Color.White;
            this.txtdepart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtdepart.ForeColor = System.Drawing.Color.Gray;
            this.txtdepart.Location = new System.Drawing.Point(23, 307);
            this.txtdepart.Name = "txtdepart";
            this.txtdepart.Size = new System.Drawing.Size(196, 17);
            this.txtdepart.TabIndex = 143;
            this.txtdepart.TextChanged += new System.EventHandler(this.txtNmrDocemp_TextChanged);
            // 
            // txtdniruc
            // 
            this.txtdniruc.BackColor = System.Drawing.Color.White;
            this.txtdniruc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdniruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtdniruc.ForeColor = System.Drawing.Color.Gray;
            this.txtdniruc.Location = new System.Drawing.Point(280, 133);
            this.txtdniruc.Name = "txtdniruc";
            this.txtdniruc.Size = new System.Drawing.Size(202, 17);
            this.txtdniruc.TabIndex = 141;
            this.txtdniruc.TextChanged += new System.EventHandler(this.txtdniruc_TextChanged);
            this.txtdniruc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdniruc_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.BackColor = System.Drawing.Color.White;
            this.txtnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtnombre.ForeColor = System.Drawing.Color.Gray;
            this.txtnombre.Location = new System.Drawing.Point(23, 133);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(202, 17);
            this.txtnombre.TabIndex = 139;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDireccion.Location = new System.Drawing.Point(280, 218);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(202, 17);
            this.txtDireccion.TabIndex = 147;
            // 
            // PanelCliente
            // 
            this.PanelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.PanelCliente.Controls.Add(this.label1);
            this.PanelCliente.Controls.Add(this.pictureBox14);
            this.PanelCliente.Controls.Add(this.pictureBox2);
            this.PanelCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCliente.Location = new System.Drawing.Point(0, 0);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Size = new System.Drawing.Size(791, 39);
            this.PanelCliente.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CLIENTE";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox14.Location = new System.Drawing.Point(750, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(34, 36);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 1;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.cliente_xdddddddddddd;
            this.pictureBox2.Location = new System.Drawing.Point(78, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // MoverCliente
            // 
            this.MoverCliente.Fixed = true;
            this.MoverCliente.Horizontal = true;
            this.MoverCliente.TargetControl = this.PanelCliente;
            this.MoverCliente.Vertical = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(275, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 18);
            this.label7.TabIndex = 135;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(266, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 134;
            this.label6.Text = "DNI/RUC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 131;
            this.label3.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 130;
            this.label2.Text = "Nombre";
            // 
            // Movervehiculo
            // 
            this.Movervehiculo.Fixed = true;
            this.Movervehiculo.Horizontal = true;
            this.Movervehiculo.TargetControl = null;
            this.Movervehiculo.Vertical = true;
            // 
            // txtprovincia
            // 
            this.txtprovincia.BackColor = System.Drawing.Color.White;
            this.txtprovincia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtprovincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtprovincia.ForeColor = System.Drawing.Color.Gray;
            this.txtprovincia.Location = new System.Drawing.Point(274, 307);
            this.txtprovincia.Name = "txtprovincia";
            this.txtprovincia.Size = new System.Drawing.Size(202, 17);
            this.txtprovincia.TabIndex = 152;
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
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox6.Location = new System.Drawing.Point(269, 294);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(225, 44);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 148;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(269, 199);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(225, 44);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 146;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(12, 294);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(226, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 142;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox7.Location = new System.Drawing.Point(12, 120);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(226, 44);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 138;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(269, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 140;
            this.pictureBox1.TabStop = false;
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarEmpleado.BorderRadius = 7;
            this.btnAgregarEmpleado.ButtonText = "             GUARDAR";
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
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(291, 447);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarEmpleado.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAgregarEmpleado.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.selected = false;
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(204, 49);
            this.btnAgregarEmpleado.TabIndex = 136;
            this.btnAgregarEmpleado.Text = "             GUARDAR";
            this.btnAgregarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpleado.Textcolor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.Color.White;
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtemail.ForeColor = System.Drawing.Color.Gray;
            this.txtemail.Location = new System.Drawing.Point(278, 211);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(202, 17);
            this.txtemail.TabIndex = 167;
            // 
            // txtdistrito
            // 
            this.txtdistrito.BackColor = System.Drawing.Color.White;
            this.txtdistrito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtdistrito.ForeColor = System.Drawing.Color.Gray;
            this.txtdistrito.Location = new System.Drawing.Point(543, 307);
            this.txtdistrito.Name = "txtdistrito";
            this.txtdistrito.Size = new System.Drawing.Size(202, 17);
            this.txtdistrito.TabIndex = 186;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox8.Location = new System.Drawing.Point(538, 294);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(225, 44);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 184;
            this.pictureBox8.TabStop = false;
            // 
            // txtdireccionx
            // 
            this.txtdireccionx.BackColor = System.Drawing.Color.White;
            this.txtdireccionx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdireccionx.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtdireccionx.ForeColor = System.Drawing.Color.Gray;
            this.txtdireccionx.Location = new System.Drawing.Point(549, 133);
            this.txtdireccionx.Name = "txtdireccionx";
            this.txtdireccionx.Size = new System.Drawing.Size(202, 17);
            this.txtdireccionx.TabIndex = 177;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox13.Location = new System.Drawing.Point(538, 120);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(226, 44);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 176;
            this.pictureBox13.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(535, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 172;
            this.label9.Text = "Direccion";
            // 
            // txtlinkgoogle
            // 
            this.txtlinkgoogle.BackColor = System.Drawing.Color.White;
            this.txtlinkgoogle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtlinkgoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtlinkgoogle.ForeColor = System.Drawing.Color.Gray;
            this.txtlinkgoogle.Location = new System.Drawing.Point(20, 392);
            this.txtlinkgoogle.Name = "txtlinkgoogle";
            this.txtlinkgoogle.Size = new System.Drawing.Size(731, 17);
            this.txtlinkgoogle.TabIndex = 190;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox10.Location = new System.Drawing.Point(15, 379);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(754, 44);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 189;
            this.pictureBox10.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(15, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 18);
            this.label11.TabIndex = 188;
            this.label11.Text = "Ubicacion(Link Google Maps)";
            // 
            // cmbtipocliente
            // 
            this.cmbtipocliente.BackColor = System.Drawing.Color.White;
            this.cmbtipocliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipocliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbtipocliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtipocliente.ForeColor = System.Drawing.Color.Gray;
            this.cmbtipocliente.FormattingEnabled = true;
            this.cmbtipocliente.Location = new System.Drawing.Point(543, 211);
            this.cmbtipocliente.Name = "cmbtipocliente";
            this.cmbtipocliente.Size = new System.Drawing.Size(213, 23);
            this.cmbtipocliente.TabIndex = 193;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox11.Location = new System.Drawing.Point(538, 199);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(226, 44);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 191;
            this.pictureBox11.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(535, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 18);
            this.label8.TabIndex = 194;
            this.label8.Text = "Tipo de Cliente";
            // 
            // txttelefono
            // 
            this.txttelefono.BackColor = System.Drawing.Color.White;
            this.txttelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txttelefono.ForeColor = System.Drawing.Color.Gray;
            this.txttelefono.Location = new System.Drawing.Point(21, 212);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(202, 17);
            this.txttelefono.TabIndex = 196;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(10, 199);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(226, 44);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 195;
            this.pictureBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(538, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 171;
            this.label10.Text = "Distrito";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(269, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 133;
            this.label5.Text = "Provincia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(14, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 132;
            this.label4.Text = "Departamento";
            // 
            // FrmAgregarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 533);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbtipocliente);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.txtlinkgoogle);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtdistrito);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.txtdireccionx);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtnroRol);
            this.Controls.Add(this.txtnrEMPLEADO);
            this.Controls.Add(this.txtprovincia);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtdepart);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtdniruc);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarEmpleado";
            this.Load += new System.EventHandler(this.frmAgregarEmpleado_Load);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.TextBox txtdepart;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox txtdniruc;
        public System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.PictureBox pictureBox7;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuFlatButton btnAgregarEmpleado;
        private Bunifu.Framework.UI.BunifuDragControl MoverCliente;
        private Bunifu.Framework.UI.BunifuDragControl Movervehiculo;
        public System.Windows.Forms.TextBox txtprovincia;
        public System.Windows.Forms.TextBox txtiidrol;
        public System.Windows.Forms.TextBox txtnrEMPLEADO;
        public System.Windows.Forms.TextBox txtnroRol;
        public System.Windows.Forms.TextBox txtdistrito;
        private System.Windows.Forms.PictureBox pictureBox8;
        public System.Windows.Forms.TextBox txtdireccionx;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtemail;
        public System.Windows.Forms.TextBox txtlinkgoogle;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cmbtipocliente;
        private System.Windows.Forms.PictureBox pictureBox11;
        public System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}