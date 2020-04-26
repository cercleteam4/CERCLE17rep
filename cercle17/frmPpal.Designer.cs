namespace cercle17
{
    partial class frmPpal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPpal));
            this.button_Mantenimiento = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.button_Facturas = new System.Windows.Forms.Button();
            this.label_Version = new System.Windows.Forms.Label();
            this.button_LISTADOS = new System.Windows.Forms.Button();
            this.button_Usos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_COMPRAS = new System.Windows.Forms.Button();
            this.button_COBROS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Mantenimiento
            // 
            this.button_Mantenimiento.Location = new System.Drawing.Point(60, 135);
            this.button_Mantenimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Mantenimiento.Name = "button_Mantenimiento";
            this.button_Mantenimiento.Size = new System.Drawing.Size(151, 53);
            this.button_Mantenimiento.TabIndex = 0;
            this.button_Mantenimiento.Text = "MANTENIMIENTO";
            this.button_Mantenimiento.UseVisualStyleBackColor = true;
            this.button_Mantenimiento.Visible = false;
            this.button_Mantenimiento.Click += new System.EventHandler(this.button_Mantenimiento_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(60, 13);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(151, 53);
            this.button_Salir.TabIndex = 1;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // button_Facturas
            // 
            this.button_Facturas.Location = new System.Drawing.Point(234, 74);
            this.button_Facturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Facturas.Name = "button_Facturas";
            this.button_Facturas.Size = new System.Drawing.Size(150, 53);
            this.button_Facturas.TabIndex = 2;
            this.button_Facturas.Text = "FACTURACIÓN";
            this.button_Facturas.UseVisualStyleBackColor = true;
            this.button_Facturas.Visible = false;
            this.button_Facturas.Click += new System.EventHandler(this.button_Facturas_Click);
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Location = new System.Drawing.Point(593, 442);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(73, 16);
            this.label_Version.TabIndex = 3;
            this.label_Version.Text = "Versión 1.3";
            // 
            // button_LISTADOS
            // 
            this.button_LISTADOS.Location = new System.Drawing.Point(60, 74);
            this.button_LISTADOS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LISTADOS.Name = "button_LISTADOS";
            this.button_LISTADOS.Size = new System.Drawing.Size(151, 53);
            this.button_LISTADOS.TabIndex = 4;
            this.button_LISTADOS.Text = "LISTADOS";
            this.button_LISTADOS.UseVisualStyleBackColor = true;
            this.button_LISTADOS.Visible = false;
            this.button_LISTADOS.Click += new System.EventHandler(this.button_LISTADOS_Click);
            // 
            // button_Usos
            // 
            this.button_Usos.Location = new System.Drawing.Point(234, 13);
            this.button_Usos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Usos.Name = "button_Usos";
            this.button_Usos.Size = new System.Drawing.Size(150, 53);
            this.button_Usos.TabIndex = 6;
            this.button_Usos.Text = "USOS";
            this.button_Usos.UseVisualStyleBackColor = true;
            this.button_Usos.Visible = false;
            this.button_Usos.Click += new System.EventHandler(this.button_Usos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(554, 364);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 70);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button_COMPRAS
            // 
            this.button_COMPRAS.Location = new System.Drawing.Point(236, 134);
            this.button_COMPRAS.Name = "button_COMPRAS";
            this.button_COMPRAS.Size = new System.Drawing.Size(147, 53);
            this.button_COMPRAS.TabIndex = 7;
            this.button_COMPRAS.Text = "COMPRAS";
            this.button_COMPRAS.UseVisualStyleBackColor = true;
            this.button_COMPRAS.Visible = false;
            this.button_COMPRAS.Click += new System.EventHandler(this.button_COMPRAS_Click);
            // 
            // button_COBROS
            // 
            this.button_COBROS.Location = new System.Drawing.Point(60, 195);
            this.button_COBROS.Name = "button_COBROS";
            this.button_COBROS.Size = new System.Drawing.Size(148, 52);
            this.button_COBROS.TabIndex = 8;
            this.button_COBROS.Text = "COBROS";
            this.button_COBROS.UseVisualStyleBackColor = true;
            this.button_COBROS.Visible = false;
            this.button_COBROS.Click += new System.EventHandler(this.button_COBROS_Click);
            // 
            // frmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(697, 467);
            this.Controls.Add(this.button_COBROS);
            this.Controls.Add(this.button_COMPRAS);
            this.Controls.Add(this.button_Usos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_LISTADOS);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.button_Facturas);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.button_Mantenimiento);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPpal";
            this.Text = "CERCLE17";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPpal_FormClosing);
            this.Load += new System.EventHandler(this.frmPpal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Mantenimiento;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button_Facturas;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.Button button_LISTADOS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Usos;
        private System.Windows.Forms.Button button_COMPRAS;
        private System.Windows.Forms.Button button_COBROS;
    }
}

