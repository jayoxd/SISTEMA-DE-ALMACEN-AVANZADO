namespace CapaPresentacion
{
    partial class FrmVerDetalleDeVentas
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
            this.panelvervehiculo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Moverpanel = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TablaDetalle = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalnumer = new System.Windows.Forms.Label();
            this.lblServicionumer = new System.Windows.Forms.Label();
            this.lblSubtotalnumer = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.txtvehiculos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelvervehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // panelvervehiculo
            // 
            this.panelvervehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.panelvervehiculo.Controls.Add(this.label1);
            this.panelvervehiculo.Controls.Add(this.pictureBox14);
            this.panelvervehiculo.Controls.Add(this.pictureBox2);
            this.panelvervehiculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelvervehiculo.Location = new System.Drawing.Point(0, 0);
            this.panelvervehiculo.Name = "panelvervehiculo";
            this.panelvervehiculo.Size = new System.Drawing.Size(942, 42);
            this.panelvervehiculo.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Detalle de una Venta";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.vehiculo;
            this.pictureBox14.Location = new System.Drawing.Point(12, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(34, 36);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 2;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox2.Location = new System.Drawing.Point(896, 6);
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
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(450, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 127;
            this.label9.Text = "PRECIO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(38, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 126;
            this.label8.Text = "CODIGO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(160, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 18);
            this.label7.TabIndex = 125;
            this.label7.Text = "PRODUCTO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(306, 152);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaDetalle.DefaultCellStyle = dataGridViewCellStyle1;
            this.TablaDetalle.Location = new System.Drawing.Point(10, 182);
            this.TablaDetalle.Name = "TablaDetalle";
            this.TablaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablaDetalle.RowHeadersVisible = false;
            this.TablaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TablaDetalle.Size = new System.Drawing.Size(675, 223);
            this.TablaDetalle.TabIndex = 122;
            this.TablaDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDetalle_CellContentClick);
            this.TablaDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaDetalle_CellEndEdit);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(137, 76);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(88, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 120;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(40, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 119;
            this.label4.Text = "REGISTROS:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblTotalnumer
            // 
            this.lblTotalnumer.AutoSize = true;
            this.lblTotalnumer.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalnumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalnumer.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalnumer.Location = new System.Drawing.Point(844, 330);
            this.lblTotalnumer.Name = "lblTotalnumer";
            this.lblTotalnumer.Size = new System.Drawing.Size(36, 18);
            this.lblTotalnumer.TabIndex = 184;
            this.lblTotalnumer.Text = "0.00";
            this.lblTotalnumer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblServicionumer
            // 
            this.lblServicionumer.AutoSize = true;
            this.lblServicionumer.BackColor = System.Drawing.Color.Transparent;
            this.lblServicionumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicionumer.ForeColor = System.Drawing.Color.Gray;
            this.lblServicionumer.Location = new System.Drawing.Point(844, 271);
            this.lblServicionumer.Name = "lblServicionumer";
            this.lblServicionumer.Size = new System.Drawing.Size(36, 18);
            this.lblServicionumer.TabIndex = 183;
            this.lblServicionumer.Text = "0.00";
            this.lblServicionumer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSubtotalnumer
            // 
            this.lblSubtotalnumer.AutoSize = true;
            this.lblSubtotalnumer.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtotalnumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalnumer.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtotalnumer.Location = new System.Drawing.Point(844, 217);
            this.lblSubtotalnumer.Name = "lblSubtotalnumer";
            this.lblSubtotalnumer.Size = new System.Drawing.Size(36, 18);
            this.lblSubtotalnumer.TabIndex = 182;
            this.lblSubtotalnumer.Text = "0.00";
            this.lblSubtotalnumer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblTotal.Location = new System.Drawing.Point(725, 330);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(55, 18);
            this.lblTotal.TabIndex = 181;
            this.lblTotal.Text = "TOTAL";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.BackColor = System.Drawing.Color.Transparent;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Gray;
            this.lblServicio.Location = new System.Drawing.Point(715, 271);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(77, 18);
            this.lblServicio.TabIndex = 180;
            this.lblServicio.Text = "SERVICIO";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTotal.Location = new System.Drawing.Point(710, 217);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(86, 18);
            this.lblSubTotal.TabIndex = 179;
            this.lblSubTotal.Text = "SUBTOTAL";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox13.Location = new System.Drawing.Point(692, 149);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(238, 20);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 178;
            this.pictureBox13.TabStop = false;
            // 
            // txtvehiculos
            // 
            this.txtvehiculos.AutoSize = true;
            this.txtvehiculos.BackColor = System.Drawing.Color.Transparent;
            this.txtvehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvehiculos.ForeColor = System.Drawing.Color.Gray;
            this.txtvehiculos.Location = new System.Drawing.Point(162, 82);
            this.txtvehiculos.Name = "txtvehiculos";
            this.txtvehiculos.Size = new System.Drawing.Size(32, 18);
            this.txtvehiculos.TabIndex = 185;
            this.txtvehiculos.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(576, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 187;
            this.label2.Text = "IMPORTE";
            // 
            // FrmVerDetalleDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(942, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtvehiculos);
            this.Controls.Add(this.lblTotalnumer);
            this.Controls.Add(this.lblServicionumer);
            this.Controls.Add(this.lblSubtotalnumer);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TablaDetalle);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panelvervehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVerDetalleDeVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVerDetalleDeVentas";
            this.panelvervehiculo.ResumeLayout(false);
            this.panelvervehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelvervehiculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuDragControl Moverpanel;
        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView TablaDetalle;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalnumer;
        private System.Windows.Forms.Label lblServicionumer;
        private System.Windows.Forms.Label lblSubtotalnumer;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label txtvehiculos;
        private System.Windows.Forms.Label label2;
    }
}