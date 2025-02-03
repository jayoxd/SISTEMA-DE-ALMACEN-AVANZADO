namespace CapaPresentacion
{
    partial class FrmVerDetalleEntrada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerDetalleEntrada));
            this.panelvervehiculo = new System.Windows.Forms.Panel();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Moverpanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TablaDetalle = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUsuarioCreacion = new System.Windows.Forms.Label();
            this.lblUsuarioEdicion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFechaHoraSys = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnexportar = new Bunifu.Framework.UI.BunifuImageButton();
            this.label14 = new System.Windows.Forms.Label();
            this.panelvervehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexportar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelvervehiculo
            // 
            this.panelvervehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panelvervehiculo.Controls.Add(this.lblNroDocumento);
            this.panelvervehiculo.Controls.Add(this.label1);
            this.panelvervehiculo.Controls.Add(this.pictureBox2);
            this.panelvervehiculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelvervehiculo.Location = new System.Drawing.Point(0, 0);
            this.panelvervehiculo.Name = "panelvervehiculo";
            this.panelvervehiculo.Size = new System.Drawing.Size(1093, 42);
            this.panelvervehiculo.TabIndex = 54;
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroDocumento.ForeColor = System.Drawing.Color.White;
            this.lblNroDocumento.Location = new System.Drawing.Point(195, 9);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(0, 20);
            this.lblNroDocumento.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Detalle de la entrada";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox2.Location = new System.Drawing.Point(1047, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Moverpanel
            // 
            this.Moverpanel.Fixed = true;
            this.Moverpanel.Horizontal = true;
            this.Moverpanel.TargetControl = this.panelvervehiculo;
            this.Moverpanel.Vertical = true;
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(622, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 127;
            this.label9.Text = "PRECIO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(66, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 126;
            this.label8.Text = "CODIGO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(424, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 18);
            this.label7.TabIndex = 125;
            this.label7.Text = "LOTE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(521, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 18);
            this.label5.TabIndex = 123;
            this.label5.Text = "CANTIDAD";
            // 
            // TablaDetalle
            // 
            this.TablaDetalle.AllowUserToAddRows = false;
            this.TablaDetalle.AllowUserToDeleteRows = false;
            this.TablaDetalle.AllowUserToOrderColumns = true;
            this.TablaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablaDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablaDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.TablaDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablaDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.TablaDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaDetalle.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaDetalle.DefaultCellStyle = dataGridViewCellStyle4;
            this.TablaDetalle.Location = new System.Drawing.Point(10, 162);
            this.TablaDetalle.Name = "TablaDetalle";
            this.TablaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablaDetalle.RowHeadersVisible = false;
            this.TablaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TablaDetalle.Size = new System.Drawing.Size(1071, 279);
            this.TablaDetalle.TabIndex = 122;
            this.TablaDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDetalle_CellContentClick);
            this.TablaDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDetalle_CellEndEdit);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(715, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 187;
            this.label2.Text = "IMPORTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(38, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 188;
            this.label3.Text = "Creado por";
            // 
            // lblUsuarioCreacion
            // 
            this.lblUsuarioCreacion.AutoSize = true;
            this.lblUsuarioCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblUsuarioCreacion.ForeColor = System.Drawing.Color.Gray;
            this.lblUsuarioCreacion.Location = new System.Drawing.Point(129, 60);
            this.lblUsuarioCreacion.Name = "lblUsuarioCreacion";
            this.lblUsuarioCreacion.Size = new System.Drawing.Size(69, 18);
            this.lblUsuarioCreacion.TabIndex = 189;
            this.lblUsuarioCreacion.Text = "CODIGO";
            // 
            // lblUsuarioEdicion
            // 
            this.lblUsuarioEdicion.AutoSize = true;
            this.lblUsuarioEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblUsuarioEdicion.ForeColor = System.Drawing.Color.Gray;
            this.lblUsuarioEdicion.Location = new System.Drawing.Point(372, 60);
            this.lblUsuarioEdicion.Name = "lblUsuarioEdicion";
            this.lblUsuarioEdicion.Size = new System.Drawing.Size(69, 18);
            this.lblUsuarioEdicion.TabIndex = 191;
            this.lblUsuarioEdicion.Text = "CODIGO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(257, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 18);
            this.label10.TabIndex = 190;
            this.label10.Text = "Actualizado por";
            // 
            // lblFechaHoraSys
            // 
            this.lblFechaHoraSys.AutoSize = true;
            this.lblFechaHoraSys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaHoraSys.ForeColor = System.Drawing.Color.Gray;
            this.lblFechaHoraSys.Location = new System.Drawing.Point(735, 60);
            this.lblFechaHoraSys.Name = "lblFechaHoraSys";
            this.lblFechaHoraSys.Size = new System.Drawing.Size(69, 18);
            this.lblFechaHoraSys.TabIndex = 193;
            this.lblFechaHoraSys.Text = "CODIGO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(588, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 18);
            this.label12.TabIndex = 192;
            this.label12.Text = "Última Actualización";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(820, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 196;
            this.label4.Text = "OBSEVACION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(632, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 197;
            this.label6.Text = "TOTAL";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbltotal.ForeColor = System.Drawing.Color.Gray;
            this.lbltotal.Location = new System.Drawing.Point(715, 444);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(60, 18);
            this.lbltotal.TabIndex = 198;
            this.lbltotal.Text = "1500.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(225, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 18);
            this.label11.TabIndex = 200;
            this.label11.Text = "DESCRIPCIÓN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(1018, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 18);
            this.label13.TabIndex = 203;
            this.label13.Text = "excel";
            // 
            // btnexportar
            // 
            this.btnexportar.BackColor = System.Drawing.Color.Transparent;
            this.btnexportar.Image = ((System.Drawing.Image)(resources.GetObject("btnexportar.Image")));
            this.btnexportar.ImageActive = null;
            this.btnexportar.Location = new System.Drawing.Point(1012, 48);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(55, 65);
            this.btnexportar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnexportar.TabIndex = 202;
            this.btnexportar.TabStop = false;
            this.btnexportar.Zoom = 10;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(1009, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 201;
            this.label14.Text = "Generar";
            // 
            // FrmVerDetalleEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1093, 471);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnexportar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFechaHoraSys);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblUsuarioEdicion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblUsuarioCreacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TablaDetalle);
            this.Controls.Add(this.panelvervehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVerDetalleEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerDetalleDeVentas";
            this.panelvervehiculo.ResumeLayout(false);
            this.panelvervehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexportar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelvervehiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuDragControl Moverpanel;
        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView TablaDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaHoraSys;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblUsuarioEdicion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUsuarioCreacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuImageButton btnexportar;
        private System.Windows.Forms.Label label14;
    }
}