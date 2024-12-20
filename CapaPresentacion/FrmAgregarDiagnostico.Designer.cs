
namespace CapaPresentacion
{
    partial class FrmAgregarDiagnostico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarDiagnostico));
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Moverpanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.PanelProductos = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMecanico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCODIGO = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtCLIENTEX = new System.Windows.Forms.TextBox();
            this.txtPlacax = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.PanelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(38, 225);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(735, 192);
            this.txtDescripcion.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(33, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 26);
            this.label4.TabIndex = 69;
            this.label4.Text = "DESCRIPCION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(509, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 67;
            this.label2.Text = "CODIGO";
            // 
            // Moverpanel
            // 
            this.Moverpanel.Fixed = true;
            this.Moverpanel.Horizontal = true;
            this.Moverpanel.TargetControl = this.PanelProductos;
            this.Moverpanel.Vertical = true;
            // 
            // PanelProductos
            // 
            this.PanelProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(42)))), ((int)(((byte)(22)))));
            this.PanelProductos.Controls.Add(this.pictureBox2);
            this.PanelProductos.Controls.Add(this.pictureBox1);
            this.PanelProductos.Controls.Add(this.lblMecanico);
            this.PanelProductos.Controls.Add(this.label3);
            this.PanelProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelProductos.Location = new System.Drawing.Point(0, 0);
            this.PanelProductos.Name = "PanelProductos";
            this.PanelProductos.Size = new System.Drawing.Size(815, 37);
            this.PanelProductos.TabIndex = 66;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.mecanico;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox1.Location = new System.Drawing.Point(769, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblMecanico
            // 
            this.lblMecanico.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.lblMecanico.ForeColor = System.Drawing.Color.White;
            this.lblMecanico.Location = new System.Drawing.Point(131, 9);
            this.lblMecanico.Name = "lblMecanico";
            this.lblMecanico.Size = new System.Drawing.Size(106, 26);
            this.lblMecanico.TabIndex = 169;
            this.lblMecanico.Text = "......................";
            this.lblMecanico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 87;
            this.label3.Text = "MECANICO";
            // 
            // cmbCODIGO
            // 
            this.cmbCODIGO.BackColor = System.Drawing.Color.White;
            this.cmbCODIGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCODIGO.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCODIGO.ForeColor = System.Drawing.Color.Gray;
            this.cmbCODIGO.FormattingEnabled = true;
            this.cmbCODIGO.Location = new System.Drawing.Point(611, 104);
            this.cmbCODIGO.Name = "cmbCODIGO";
            this.cmbCODIGO.Size = new System.Drawing.Size(142, 30);
            this.cmbCODIGO.TabIndex = 168;
            this.cmbCODIGO.SelectedIndexChanged += new System.EventHandler(this.cmbCODIGO_SelectedIndexChanged_1);
            this.cmbCODIGO.Leave += new System.EventHandler(this.cmbCODIGO_Leave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(598, 99);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(166, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 167;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::CapaPresentacion.Properties.Resources.mechanic;
            this.pictureBox9.Location = new System.Drawing.Point(45, 56);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(101, 91);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 164;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CapaPresentacion.Properties.Resources.CajaDescripcion;
            this.pictureBox6.Location = new System.Drawing.Point(22, 210);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(770, 227);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 85;
            this.pictureBox6.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.BorderRadius = 7;
            this.btnGuardar.ButtonText = "      GUARDAR";
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.DisabledColor = System.Drawing.Color.Gray;
            this.btnGuardar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnGuardar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Iconimage")));
            this.btnGuardar.Iconimage_right = null;
            this.btnGuardar.Iconimage_right_Selected = null;
            this.btnGuardar.Iconimage_Selected = null;
            this.btnGuardar.IconMarginLeft = 0;
            this.btnGuardar.IconMarginRight = 0;
            this.btnGuardar.IconRightVisible = true;
            this.btnGuardar.IconRightZoom = 0D;
            this.btnGuardar.IconVisible = true;
            this.btnGuardar.IconZoom = 60D;
            this.btnGuardar.IsTab = false;
            this.btnGuardar.Location = new System.Drawing.Point(616, 978);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnGuardar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnGuardar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnGuardar.selected = false;
            this.btnGuardar.Size = new System.Drawing.Size(279, 84);
            this.btnGuardar.TabIndex = 74;
            this.btnGuardar.Text = "      GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Textcolor = System.Drawing.Color.White;
            this.btnGuardar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Click += new System.EventHandler(this.btnAgregarProductosx_Click);
            // 
            // txtCLIENTEX
            // 
            this.txtCLIENTEX.BackColor = System.Drawing.Color.White;
            this.txtCLIENTEX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCLIENTEX.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.txtCLIENTEX.ForeColor = System.Drawing.Color.Gray;
            this.txtCLIENTEX.Location = new System.Drawing.Point(249, 110);
            this.txtCLIENTEX.Name = "txtCLIENTEX";
            this.txtCLIENTEX.ReadOnly = true;
            this.txtCLIENTEX.Size = new System.Drawing.Size(83, 23);
            this.txtCLIENTEX.TabIndex = 172;
            this.txtCLIENTEX.Text = "PLACA";
            this.txtCLIENTEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlacax
            // 
            this.txtPlacax.BackColor = System.Drawing.Color.White;
            this.txtPlacax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlacax.Font = new System.Drawing.Font("Poppins", 11.25F);
            this.txtPlacax.ForeColor = System.Drawing.Color.Gray;
            this.txtPlacax.Location = new System.Drawing.Point(338, 101);
            this.txtPlacax.Name = "txtPlacax";
            this.txtPlacax.ReadOnly = true;
            this.txtPlacax.Size = new System.Drawing.Size(142, 23);
            this.txtPlacax.TabIndex = 173;
            this.txtPlacax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlacax.TextChanged += new System.EventHandler(this.txtPlacax_TextChanged);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox7.Location = new System.Drawing.Point(338, 117);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(142, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 175;
            this.pictureBox7.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.ActiveBorderThickness = 1;
            this.btnAgregar.ActiveCornerRadius = 20;
            this.btnAgregar.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.btnAgregar.ActiveForecolor = System.Drawing.Color.White;
            this.btnAgregar.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.ButtonText = "AGREGAR";
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Poppins", 11F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.IdleBorderThickness = 1;
            this.btnAgregar.IdleCornerRadius = 20;
            this.btnAgregar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.btnAgregar.IdleForecolor = System.Drawing.Color.White;
            this.btnAgregar.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.btnAgregar.Location = new System.Drawing.Point(280, 440);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(231, 55);
            this.btnAgregar.TabIndex = 176;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FrmAgregarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 511);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPlacax);
            this.Controls.Add(this.txtCLIENTEX);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.cmbCODIGO);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PanelProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarDiagnostico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarDiagnostico";
            this.Load += new System.EventHandler(this.FrmAgregarDiagnostico_Load);
            this.PanelProductos.ResumeLayout(false);
            this.PanelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        public System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.PictureBox pictureBox6;
        public Bunifu.Framework.UI.BunifuFlatButton btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelProductos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuDragControl Moverpanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox9;
        public System.Windows.Forms.ComboBox cmbCODIGO;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblMecanico;
        private System.Windows.Forms.TextBox txtPlacax;
        private System.Windows.Forms.TextBox txtCLIENTEX;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAgregar;
    }
}