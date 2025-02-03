
namespace CapaPresentacion
{
    partial class FrmVerProductos
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
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.RadiusElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.MoverCliente = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Movervehiculo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txbBreport = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.tablaReporte = new System.Windows.Forms.DataGridView();
            this.PanelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCliente
            // 
            this.PanelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.PanelCliente.Controls.Add(this.label1);
            this.PanelCliente.Controls.Add(this.pictureBox14);
            this.PanelCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCliente.Location = new System.Drawing.Point(0, 0);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Size = new System.Drawing.Size(1030, 39);
            this.PanelCliente.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PRODUCTOS";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.CerrarForm;
            this.pictureBox14.Location = new System.Drawing.Point(993, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(34, 36);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 1;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // RadiusElipse
            // 
            this.RadiusElipse.ElipseRadius = 7;
            this.RadiusElipse.TargetControl = this;
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
            // txbBreport
            // 
            this.txbBreport.BackColor = System.Drawing.Color.White;
            this.txbBreport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbBreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txbBreport.Location = new System.Drawing.Point(81, 102);
            this.txbBreport.Name = "txbBreport";
            this.txbBreport.Size = new System.Drawing.Size(360, 17);
            this.txbBreport.TabIndex = 182;
            this.txbBreport.TextChanged += new System.EventHandler(this.txbBreport_TextChanged);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.Buscar;
            this.pictureBox7.Location = new System.Drawing.Point(42, 96);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 29);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 181;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox10.Location = new System.Drawing.Point(33, 88);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(415, 44);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 180;
            this.pictureBox10.TabStop = false;
            // 
            // tablaReporte
            // 
            this.tablaReporte.AllowUserToAddRows = false;
            this.tablaReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tablaReporte.BackgroundColor = System.Drawing.Color.White;
            this.tablaReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaReporte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tablaReporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaReporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.tablaReporte.Location = new System.Drawing.Point(12, 157);
            this.tablaReporte.Name = "tablaReporte";
            this.tablaReporte.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablaReporte.RowHeadersVisible = false;
            this.tablaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaReporte.Size = new System.Drawing.Size(1006, 445);
            this.tablaReporte.TabIndex = 202;
            this.tablaReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaReporte_CellContentClick_1);
            // 
            // FrmVerProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 626);
            this.Controls.Add(this.tablaReporte);
            this.Controls.Add(this.txbBreport);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.PanelCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVerProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisualisarReporte";
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private Bunifu.Framework.UI.BunifuElipse RadiusElipse;
        private Bunifu.Framework.UI.BunifuDragControl MoverCliente;
        private Bunifu.Framework.UI.BunifuDragControl Movervehiculo;
        private System.Windows.Forms.TextBox txbBreport;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.DataGridView tablaReporte;
    }
}