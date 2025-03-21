﻿
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class FrmPersonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblsestado = new System.Windows.Forms.Label();
            this.Btnoinahbilitados = new Bunifu.Framework.UI.BunifuThinButton2();
            this.TablaCLIENTES = new System.Windows.Forms.DataGridView();
            this.EDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.txbBuscarProducto = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.btnProductos = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblUltimoClienteRegistrado = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblClientesInactivos = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblClientesActivos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblproducbajostock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductosHabilitados = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblClienteMasSalidas = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCLIENTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::CapaPresentacion.Properties.Resources.SombraPanelProductos;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Controls.Add(this.lblsestado);
            this.panel9.Controls.Add(this.Btnoinahbilitados);
            this.panel9.Controls.Add(this.TablaCLIENTES);
            this.panel9.Controls.Add(this.txbBuscarProducto);
            this.panel9.Controls.Add(this.pictureBox9);
            this.panel9.Controls.Add(this.pictureBox10);
            this.panel9.Controls.Add(this.btnProductos);
            this.panel9.Location = new System.Drawing.Point(3, 275);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1638, 863);
            this.panel9.TabIndex = 4;
            this.panel9.Paint += new System.Windows.Forms.PaintEventHandler(this.panel9_Paint);
            // 
            // lblsestado
            // 
            this.lblsestado.AutoSize = true;
            this.lblsestado.BackColor = System.Drawing.Color.Transparent;
            this.lblsestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsestado.ForeColor = System.Drawing.Color.Gray;
            this.lblsestado.Location = new System.Drawing.Point(41, 45);
            this.lblsestado.Name = "lblsestado";
            this.lblsestado.Size = new System.Drawing.Size(105, 18);
            this.lblsestado.TabIndex = 19;
            this.lblsestado.Text = "PRODUCTOS";
            // 
            // Btnoinahbilitados
            // 
            this.Btnoinahbilitados.ActiveBorderThickness = 1;
            this.Btnoinahbilitados.ActiveCornerRadius = 20;
            this.Btnoinahbilitados.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.Btnoinahbilitados.ActiveForecolor = System.Drawing.Color.White;
            this.Btnoinahbilitados.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.Btnoinahbilitados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.Btnoinahbilitados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btnoinahbilitados.BackgroundImage")));
            this.Btnoinahbilitados.ButtonText = "MOSTRAR CLIENTES INHABILITADOS";
            this.Btnoinahbilitados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnoinahbilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Btnoinahbilitados.ForeColor = System.Drawing.Color.White;
            this.Btnoinahbilitados.IdleBorderThickness = 1;
            this.Btnoinahbilitados.IdleCornerRadius = 20;
            this.Btnoinahbilitados.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.Btnoinahbilitados.IdleForecolor = System.Drawing.Color.White;
            this.Btnoinahbilitados.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.Btnoinahbilitados.Location = new System.Drawing.Point(911, 89);
            this.Btnoinahbilitados.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Btnoinahbilitados.Name = "Btnoinahbilitados";
            this.Btnoinahbilitados.Size = new System.Drawing.Size(303, 55);
            this.Btnoinahbilitados.TabIndex = 18;
            this.Btnoinahbilitados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btnoinahbilitados.Click += new System.EventHandler(this.Btnoinahbilitados_Click);
            // 
            // TablaCLIENTES
            // 
            this.TablaCLIENTES.AllowUserToAddRows = false;
            this.TablaCLIENTES.AllowUserToDeleteRows = false;
            this.TablaCLIENTES.AllowUserToOrderColumns = true;
            this.TablaCLIENTES.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablaCLIENTES.BackgroundColor = System.Drawing.Color.White;
            this.TablaCLIENTES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablaCLIENTES.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.TablaCLIENTES.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablaCLIENTES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaCLIENTES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDITAR});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaCLIENTES.DefaultCellStyle = dataGridViewCellStyle1;
            this.TablaCLIENTES.GridColor = System.Drawing.SystemColors.ControlLight;
            this.TablaCLIENTES.Location = new System.Drawing.Point(25, 165);
            this.TablaCLIENTES.Name = "TablaCLIENTES";
            this.TablaCLIENTES.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablaCLIENTES.RowHeadersVisible = false;
            this.TablaCLIENTES.RowHeadersWidth = 92;
            this.TablaCLIENTES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TablaCLIENTES.Size = new System.Drawing.Size(1234, 405);
            this.TablaCLIENTES.TabIndex = 8;
            this.TablaCLIENTES.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaCLIENTES_CellContentClick);
            // 
            // EDITAR
            // 
            this.EDITAR.FillWeight = 169.5432F;
            this.EDITAR.HeaderText = "EDITAR";
            this.EDITAR.Image = global::CapaPresentacion.Properties.Resources.EditarProducto;
            this.EDITAR.MinimumWidth = 11;
            this.EDITAR.Name = "EDITAR";
            this.EDITAR.Width = 80;
            // 
            // txbBuscarProducto
            // 
            this.txbBuscarProducto.BackColor = System.Drawing.Color.White;
            this.txbBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txbBuscarProducto.Location = new System.Drawing.Point(98, 89);
            this.txbBuscarProducto.Name = "txbBuscarProducto";
            this.txbBuscarProducto.Size = new System.Drawing.Size(360, 17);
            this.txbBuscarProducto.TabIndex = 7;
            this.txbBuscarProducto.TextChanged += new System.EventHandler(this.txbBuscarProducto_TextChanged);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::CapaPresentacion.Properties.Resources.Buscar;
            this.pictureBox9.Location = new System.Drawing.Point(59, 83);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(33, 29);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 6;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::CapaPresentacion.Properties.Resources.CajaTexto;
            this.pictureBox10.Location = new System.Drawing.Point(50, 75);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(415, 44);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 5;
            this.pictureBox10.TabStop = false;
            // 
            // btnProductos
            // 
            this.btnProductos.ActiveBorderThickness = 1;
            this.btnProductos.ActiveCornerRadius = 20;
            this.btnProductos.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(110)))), ((int)(((byte)(230)))));
            this.btnProductos.ActiveForecolor = System.Drawing.Color.White;
            this.btnProductos.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(110)))), ((int)(((byte)(230)))));
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.btnProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductos.BackgroundImage")));
            this.btnProductos.ButtonText = "NUEVO CLIENTE";
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.IdleBorderThickness = 1;
            this.btnProductos.IdleCornerRadius = 20;
            this.btnProductos.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.btnProductos.IdleForecolor = System.Drawing.Color.White;
            this.btnProductos.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.btnProductos.Location = new System.Drawing.Point(647, 89);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(210, 55);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProductos.Click += new System.EventHandler(this.bunifuThinButton24_Click);
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Controls.Add(this.lblUltimoClienteRegistrado);
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Controls.Add(this.pictureBox6);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(885, 137);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(405, 132);
            this.panel7.TabIndex = 5;
            // 
            // lblUltimoClienteRegistrado
            // 
            this.lblUltimoClienteRegistrado.BackColor = System.Drawing.Color.Transparent;
            this.lblUltimoClienteRegistrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoClienteRegistrado.ForeColor = System.Drawing.Color.Gray;
            this.lblUltimoClienteRegistrado.Location = new System.Drawing.Point(134, 15);
            this.lblUltimoClienteRegistrado.Name = "lblUltimoClienteRegistrado";
            this.lblUltimoClienteRegistrado.Size = new System.Drawing.Size(233, 46);
            this.lblUltimoClienteRegistrado.TabIndex = 5;
            this.lblUltimoClienteRegistrado.Text = "10";
            this.lblUltimoClienteRegistrado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::CapaPresentacion.Properties.Resources.Totales;
            this.pictureBox5.Location = new System.Drawing.Point(16, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox6.Location = new System.Drawing.Point(16, 58);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(351, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(13, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "ULTIMO CLIENTE REGISTRADO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(414, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 128);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lblClientesInactivos);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(465, 128);
            this.panel6.TabIndex = 5;
            // 
            // lblClientesInactivos
            // 
            this.lblClientesInactivos.BackColor = System.Drawing.Color.Transparent;
            this.lblClientesInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientesInactivos.ForeColor = System.Drawing.Color.Gray;
            this.lblClientesInactivos.Location = new System.Drawing.Point(263, 15);
            this.lblClientesInactivos.Name = "lblClientesInactivos";
            this.lblClientesInactivos.Size = new System.Drawing.Size(104, 46);
            this.lblClientesInactivos.TabIndex = 5;
            this.lblClientesInactivos.Text = "10";
            this.lblClientesInactivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.Categorias;
            this.pictureBox3.Location = new System.Drawing.Point(16, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox4.Location = new System.Drawing.Point(16, 58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(351, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "CLIENTES INACTIVOS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 128);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.lblClientesActivos);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(405, 128);
            this.panel5.TabIndex = 4;
            // 
            // lblClientesActivos
            // 
            this.lblClientesActivos.AccessibleDescription = "";
            this.lblClientesActivos.BackColor = System.Drawing.Color.Transparent;
            this.lblClientesActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientesActivos.ForeColor = System.Drawing.Color.Gray;
            this.lblClientesActivos.Location = new System.Drawing.Point(263, 15);
            this.lblClientesActivos.Name = "lblClientesActivos";
            this.lblClientesActivos.Size = new System.Drawing.Size(104, 46);
            this.lblClientesActivos.TabIndex = 5;
            this.lblClientesActivos.Text = "10";
            this.lblClientesActivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Productos;
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox2.Location = new System.Drawing.Point(16, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(351, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(13, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "CANTIDAD DE CLIENTES ACTIVOS";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel9);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1281, 701);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel8
            // 
            this.panel8.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.lblproducbajostock);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.pictureBox13);
            this.panel8.Controls.Add(this.pictureBox14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(885, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(405, 128);
            this.panel8.TabIndex = 6;
            // 
            // lblproducbajostock
            // 
            this.lblproducbajostock.BackColor = System.Drawing.Color.Transparent;
            this.lblproducbajostock.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproducbajostock.ForeColor = System.Drawing.Color.Gray;
            this.lblproducbajostock.Location = new System.Drawing.Point(270, 8);
            this.lblproducbajostock.Name = "lblproducbajostock";
            this.lblproducbajostock.Size = new System.Drawing.Size(104, 46);
            this.lblproducbajostock.TabIndex = 21;
            this.lblproducbajostock.Text = "10";
            this.lblproducbajostock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "PRODUCTOS CON BAJO STOCK >3";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Image = global::CapaPresentacion.Properties.Resources.Totales;
            this.pictureBox13.Location = new System.Drawing.Point(16, 15);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(50, 50);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 0;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox14.Location = new System.Drawing.Point(16, 58);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(351, 20);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 1;
            this.pictureBox14.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1296, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 128);
            this.panel3.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.lblProductosHabilitados);
            this.panel10.Controls.Add(this.pictureBox7);
            this.panel10.Controls.Add(this.pictureBox11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 137);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(405, 132);
            this.panel10.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "CANTIDAD  DE PRODUCTO HABILITADOS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblProductosHabilitados
            // 
            this.lblProductosHabilitados.BackColor = System.Drawing.Color.Transparent;
            this.lblProductosHabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosHabilitados.ForeColor = System.Drawing.Color.Gray;
            this.lblProductosHabilitados.Location = new System.Drawing.Point(263, 9);
            this.lblProductosHabilitados.Name = "lblProductosHabilitados";
            this.lblProductosHabilitados.Size = new System.Drawing.Size(104, 46);
            this.lblProductosHabilitados.TabIndex = 21;
            this.lblProductosHabilitados.Text = "10";
            this.lblProductosHabilitados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProductosHabilitados.Click += new System.EventHandler(this.lblProductosHabilitados_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::CapaPresentacion.Properties.Resources.Categorias;
            this.pictureBox7.Location = new System.Drawing.Point(16, 15);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox11.Location = new System.Drawing.Point(16, 58);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(351, 20);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 1;
            this.pictureBox11.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::CapaPresentacion.Properties.Resources.SobraCajasTotales;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.pictureBox8);
            this.panel4.Controls.Add(this.lblClienteMasSalidas);
            this.panel4.Controls.Add(this.pictureBox12);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(414, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(465, 132);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::CapaPresentacion.Properties.Resources.Productos;
            this.pictureBox8.Location = new System.Drawing.Point(16, 15);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // lblClienteMasSalidas
            // 
            this.lblClienteMasSalidas.BackColor = System.Drawing.Color.Transparent;
            this.lblClienteMasSalidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteMasSalidas.ForeColor = System.Drawing.Color.Gray;
            this.lblClienteMasSalidas.Location = new System.Drawing.Point(72, 15);
            this.lblClienteMasSalidas.Name = "lblClienteMasSalidas";
            this.lblClienteMasSalidas.Size = new System.Drawing.Size(374, 46);
            this.lblClienteMasSalidas.TabIndex = 5;
            this.lblClienteMasSalidas.Text = "10";
            this.lblClienteMasSalidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::CapaPresentacion.Properties.Resources.linea_negra;
            this.pictureBox12.Location = new System.Drawing.Point(16, 58);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(351, 20);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 1;
            this.pictureBox12.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(13, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "CLIENTE CON MAS SALIDAS DE ESTE MES";
            // 
            // FrmPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1281, 701);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPersonas";
            this.Text = "frmProductos";
            this.Load += new System.EventHandler(this.FrmPersonas_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCLIENTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView TablaCLIENTES;
        private System.Windows.Forms.TextBox txbBuscarProducto;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private Bunifu.Framework.UI.BunifuThinButton2 btnProductos;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblUltimoClienteRegistrado;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblClientesInactivos;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblClientesActivos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuThinButton2 Btnoinahbilitados;

        private System.Windows.Forms.Label lblsestado;
        private Panel panel10;
        private Label lblClienteMasSalidas;
        private PictureBox pictureBox7;
        private PictureBox pictureBox11;
        private Label label7;
        private Panel panel4;
        private PictureBox pictureBox8;
        private PictureBox pictureBox12;
        private Panel panel8;
        private PictureBox pictureBox13;
        private PictureBox pictureBox14;
        private DataGridViewImageColumn EDITAR;
        private Label lblproducbajostock;
        private Label label2;
        private Label lblProductosHabilitados;
        private Label label3;
        private Panel panel3;
    }
}