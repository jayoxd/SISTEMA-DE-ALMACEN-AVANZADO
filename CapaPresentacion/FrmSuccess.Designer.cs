
namespace CapaPresentacion
{
    partial class FrmSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSuccess));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.esclarecerFrom = new Bunifu.Framework.UI.BunifuFormFadeTransition(this.components);
            this.lblMensaje = new System.Windows.Forms.Label();
            this.labelmensajito = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAceptarPOK = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptarPOK)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this;
            // 
            // esclarecerFrom
            // 
            this.esclarecerFrom.Delay = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Location = new System.Drawing.Point(12, 252);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(346, 36);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "MENSAJE";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.Click += new System.EventHandler(this.lblMensaje_Click);
            // 
            // labelmensajito
            // 
            this.labelmensajito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelmensajito.ForeColor = System.Drawing.Color.Gray;
            this.labelmensajito.Location = new System.Drawing.Point(12, 332);
            this.labelmensajito.Name = "labelmensajito";
            this.labelmensajito.Size = new System.Drawing.Size(346, 36);
            this.labelmensajito.TabIndex = 1;
            this.labelmensajito.Text = "Acción completada correctamente";
            this.labelmensajito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelmensajito.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(194)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 232);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Check;
            this.pictureBox1.Location = new System.Drawing.Point(124, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAceptarPOK
            // 
            this.btnAceptarPOK.BackColor = System.Drawing.Color.White;
            this.btnAceptarPOK.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptarPOK.Image")));
            this.btnAceptarPOK.ImageActive = null;
            this.btnAceptarPOK.Location = new System.Drawing.Point(141, 384);
            this.btnAceptarPOK.Name = "btnAceptarPOK";
            this.btnAceptarPOK.Size = new System.Drawing.Size(77, 71);
            this.btnAceptarPOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAceptarPOK.TabIndex = 4;
            this.btnAceptarPOK.TabStop = false;
            this.btnAceptarPOK.Zoom = 10;
            this.btnAceptarPOK.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // FrmSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.Shadow_Notificaciones;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(370, 500);
            this.Controls.Add(this.btnAceptarPOK);
            this.Controls.Add(this.labelmensajito);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSuccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSuccess";
            this.Load += new System.EventHandler(this.FrmSuccess_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptarPOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuFormFadeTransition esclarecerFrom;
        private System.Windows.Forms.Label labelmensajito;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuImageButton btnAceptarPOK;
    }
}