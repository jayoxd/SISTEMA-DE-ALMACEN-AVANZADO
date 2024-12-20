
namespace CapaPresentacion
{
    partial class FrmAgregarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarCliente));
            this.Movervehiculo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MoverCliente = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtNombrecl = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNmrDocCliente = new System.Windows.Forms.TextBox();
            this.txtTipoDocumen = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnAgregarCliente = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txbTipoDocumento = new System.Windows.Forms.TextBox();
            this.PanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // Movervehiculo
            // 
            this.Movervehiculo.Fixed = true;
            this.Movervehiculo.Horizontal = true;
            this.Movervehiculo.TargetControl = null;
            this.Movervehiculo.Vertical = true;
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
            this.PanelCliente.Size = new System.Drawing.Size(559, 39);
            this.PanelCliente.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTRAR CLIENTE";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox14.Location = new System.Drawing.Point(513, 3);
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
            this.pictureBox2.Location = new System.Drawing.Point(164, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(275, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "EMAIL";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(275, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 55;
            this.label6.Text = "TELEFONO";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(284, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 54;
            this.label5.Text = "DIRECCION";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(7, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 18);
            this.label4.TabIndex = 53;
            this.label4.Text = "NUMERO DE DOCUMENTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 18);
            this.label3.TabIndex = 52;
            this.label3.Text = "TIPO DE DOCUMENTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "NOMBRE";
            // 
            // MoverCliente
            // 
            this.MoverCliente.Fixed = true;
            this.MoverCliente.Horizontal = true;
            this.MoverCliente.TargetControl = this.PanelCliente;
            this.MoverCliente.Vertical = true;
            // 
            // txtNombrecl
            // 
            this.txtNombrecl.BackColor = System.Drawing.Color.White;
            this.txtNombrecl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombrecl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNombrecl.Location = new System.Drawing.Point(23, 132);
            this.txtNombrecl.Name = "txtNombrecl";
            this.txtNombrecl.Size = new System.Drawing.Size(218, 17);
            this.txtNombrecl.TabIndex = 82;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtTelefono.Location = new System.Drawing.Point(289, 132);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(218, 17);
            this.txtTelefono.TabIndex = 84;
            // 
            // txtNmrDocCliente
            // 
            this.txtNmrDocCliente.BackColor = System.Drawing.Color.White;
            this.txtNmrDocCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNmrDocCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNmrDocCliente.Location = new System.Drawing.Point(17, 306);
            this.txtNmrDocCliente.Name = "txtNmrDocCliente";
            this.txtNmrDocCliente.Size = new System.Drawing.Size(218, 17);
            this.txtNmrDocCliente.TabIndex = 86;
            // 
            // txtTipoDocumen
            // 
            this.txtTipoDocumen.BackColor = System.Drawing.Color.White;
            this.txtTipoDocumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoDocumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtTipoDocumen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTipoDocumen.Location = new System.Drawing.Point(506, 438);
            this.txtTipoDocumen.Multiline = true;
            this.txtTipoDocumen.Name = "txtTipoDocumen";
            this.txtTipoDocumen.Size = new System.Drawing.Size(41, 18);
            this.txtTipoDocumen.TabIndex = 88;
            this.txtTipoDocumen.TextChanged += new System.EventHandler(this.txtTipoDocumen_TextChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDireccion.Location = new System.Drawing.Point(289, 217);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(218, 17);
            this.txtDireccion.TabIndex = 90;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtEmail.Location = new System.Drawing.Point(283, 306);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(218, 17);
            this.txtEmail.TabIndex = 92;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.White;
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtIdCliente.ForeColor = System.Drawing.Color.White;
            this.txtIdCliente.Location = new System.Drawing.Point(469, 45);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(50, 17);
            this.txtIdCliente.TabIndex = 104;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.BackColor = System.Drawing.Color.White;
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.ForeColor = System.Drawing.Color.Gray;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(12, 204);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(229, 23);
            this.cmbTipoDocumento.TabIndex = 105;
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox6.Location = new System.Drawing.Point(278, 293);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(241, 44);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 91;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(278, 204);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(241, 44);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 89;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(7, 198);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(242, 44);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 87;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(6, 293);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(248, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 85;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(278, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox7.Location = new System.Drawing.Point(12, 119);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(242, 44);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 81;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarCliente.BorderRadius = 7;
            this.btnAgregarCliente.ButtonText = "      GUARDAR";
            this.btnAgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCliente.DisabledColor = System.Drawing.Color.Gray;
            this.btnAgregarCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarCliente.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAgregarCliente.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.Iconimage")));
            this.btnAgregarCliente.Iconimage_right = null;
            this.btnAgregarCliente.Iconimage_right_Selected = null;
            this.btnAgregarCliente.Iconimage_Selected = null;
            this.btnAgregarCliente.IconMarginLeft = 0;
            this.btnAgregarCliente.IconMarginRight = 0;
            this.btnAgregarCliente.IconRightVisible = true;
            this.btnAgregarCliente.IconRightZoom = 0D;
            this.btnAgregarCliente.IconVisible = true;
            this.btnAgregarCliente.IconZoom = 60D;
            this.btnAgregarCliente.IsTab = false;
            this.btnAgregarCliente.Location = new System.Drawing.Point(189, 379);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAgregarCliente.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAgregarCliente.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAgregarCliente.selected = false;
            this.btnAgregarCliente.Size = new System.Drawing.Size(152, 39);
            this.btnAgregarCliente.TabIndex = 63;
            this.btnAgregarCliente.Text = "      GUARDAR";
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Textcolor = System.Drawing.Color.White;
            this.btnAgregarCliente.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txbTipoDocumento
            // 
            this.txbTipoDocumento.BackColor = System.Drawing.Color.White;
            this.txbTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txbTipoDocumento.ForeColor = System.Drawing.Color.Gray;
            this.txbTipoDocumento.Location = new System.Drawing.Point(17, 207);
            this.txbTipoDocumento.Multiline = true;
            this.txbTipoDocumento.Name = "txbTipoDocumento";
            this.txbTipoDocumento.ReadOnly = true;
            this.txbTipoDocumento.Size = new System.Drawing.Size(206, 20);
            this.txbTipoDocumento.TabIndex = 146;
            // 
            // FrmAgregarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 468);
            this.Controls.Add(this.txbTipoDocumento);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtTipoDocumen);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtNmrDocCliente);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNombrecl);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarCliente";
            this.Load += new System.EventHandler(this.FrmAgregarCliente_Load);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuDragControl Movervehiculo;
        private System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuFlatButton btnAgregarCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDragControl MoverCliente;
        public System.Windows.Forms.TextBox txtNombrecl;
        private System.Windows.Forms.PictureBox pictureBox7;
        public System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtNmrDocCliente;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox txtTipoDocumen;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pictureBox6;
        public System.Windows.Forms.TextBox txtIdCliente;
        public System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.PictureBox pictureBox14;
        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        public System.Windows.Forms.TextBox txbTipoDocumento;
    }
}