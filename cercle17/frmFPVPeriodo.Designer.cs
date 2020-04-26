namespace cercle17
{
    partial class frmFPVPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPVPeriodo));
            this.cbPeriodicidad = new System.Windows.Forms.ComboBox();
            this.textBox_Memoria = new System.Windows.Forms.TextBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.ckbFechaDesde = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDet = new System.Windows.Forms.Panel();
            this.lblPeriodicidad = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.dateTimePicker_FechaFactura = new System.Windows.Forms.DateTimePicker();
            this.lFechaFactura = new System.Windows.Forms.Label();
            this.panelFechaFactura = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelDet.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelFechaFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPeriodicidad
            // 
            this.cbPeriodicidad.FormattingEnabled = true;
            this.cbPeriodicidad.Location = new System.Drawing.Point(97, 12);
            this.cbPeriodicidad.Name = "cbPeriodicidad";
            this.cbPeriodicidad.Size = new System.Drawing.Size(121, 22);
            this.cbPeriodicidad.TabIndex = 3;
            // 
            // textBox_Memoria
            // 
            this.textBox_Memoria.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Memoria.Location = new System.Drawing.Point(12, 147);
            this.textBox_Memoria.Multiline = true;
            this.textBox_Memoria.Name = "textBox_Memoria";
            this.textBox_Memoria.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Memoria.Size = new System.Drawing.Size(900, 327);
            this.textBox_Memoria.TabIndex = 7;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(167, 18);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(34, 14);
            this.lblFechaHasta.TabIndex = 11;
            this.lblFechaHasta.Text = "hasta";
            // 
            // ckbFechaDesde
            // 
            this.ckbFechaDesde.AutoSize = true;
            this.ckbFechaDesde.Checked = true;
            this.ckbFechaDesde.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFechaDesde.Location = new System.Drawing.Point(9, 17);
            this.ckbFechaDesde.Name = "ckbFechaDesde";
            this.ckbFechaDesde.Size = new System.Drawing.Size(57, 18);
            this.ckbFechaDesde.TabIndex = 10;
            this.ckbFechaDesde.Text = "Desde";
            this.ckbFechaDesde.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(207, 13);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 2;
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(72, 13);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.dateTimePicker_Fin);
            this.panel1.Controls.Add(this.dateTimePicker_Inicio);
            this.panel1.Controls.Add(this.lblFechaHasta);
            this.panel1.Controls.Add(this.ckbFechaDesde);
            this.panel1.Location = new System.Drawing.Point(12, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 46);
            this.panel1.TabIndex = 13;
            // 
            // panelDet
            // 
            this.panelDet.BackColor = System.Drawing.Color.Lavender;
            this.panelDet.Controls.Add(this.lblPeriodicidad);
            this.panelDet.Controls.Add(this.cbPeriodicidad);
            this.panelDet.Location = new System.Drawing.Point(328, 85);
            this.panelDet.Name = "panelDet";
            this.panelDet.Size = new System.Drawing.Size(237, 46);
            this.panelDet.TabIndex = 12;
            // 
            // lblPeriodicidad
            // 
            this.lblPeriodicidad.AutoSize = true;
            this.lblPeriodicidad.Location = new System.Drawing.Point(16, 18);
            this.lblPeriodicidad.Name = "lblPeriodicidad";
            this.lblPeriodicidad.Size = new System.Drawing.Size(65, 14);
            this.lblPeriodicidad.TabIndex = 1;
            this.lblPeriodicidad.Text = "Periodicidad";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(783, 83);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(129, 48);
            this.btnFacturar.TabIndex = 4;
            this.btnFacturar.Text = "FACTURAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.btnSALIR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(924, 73);
            this.panel4.TabIndex = 14;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(112, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // dateTimePicker_FechaFactura
            // 
            this.dateTimePicker_FechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FechaFactura.Location = new System.Drawing.Point(95, 14);
            this.dateTimePicker_FechaFactura.Name = "dateTimePicker_FechaFactura";
            this.dateTimePicker_FechaFactura.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_FechaFactura.TabIndex = 10;
            this.dateTimePicker_FechaFactura.Visible = false;
            // 
            // lFechaFactura
            // 
            this.lFechaFactura.AutoSize = true;
            this.lFechaFactura.Location = new System.Drawing.Point(14, 17);
            this.lFechaFactura.Name = "lFechaFactura";
            this.lFechaFactura.Size = new System.Drawing.Size(77, 14);
            this.lFechaFactura.TabIndex = 11;
            this.lFechaFactura.Text = "Fecha Factura";
            this.lFechaFactura.Visible = false;
            // 
            // panelFechaFactura
            // 
            this.panelFechaFactura.BackColor = System.Drawing.Color.Lavender;
            this.panelFechaFactura.Controls.Add(this.dateTimePicker_FechaFactura);
            this.panelFechaFactura.Controls.Add(this.lFechaFactura);
            this.panelFechaFactura.Location = new System.Drawing.Point(576, 85);
            this.panelFechaFactura.Name = "panelFechaFactura";
            this.panelFechaFactura.Size = new System.Drawing.Size(199, 46);
            this.panelFechaFactura.TabIndex = 13;
            this.panelFechaFactura.Visible = false;
            // 
            // frmFPVPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(924, 487);
            this.Controls.Add(this.panelFechaFactura);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDet);
            this.Controls.Add(this.textBox_Memoria);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPVPeriodo";
            this.Text = "    Facturación Periódica";
            this.Load += new System.EventHandler(this.frmFPVPeriodo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDet.ResumeLayout(false);
            this.panelDet.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panelFechaFactura.ResumeLayout(false);
            this.panelFechaFactura.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Memoria;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.CheckBox ckbFechaDesde;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDet;
        private System.Windows.Forms.Label lblPeriodicidad;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.ComboBox cbPeriodicidad;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaFactura;
        private System.Windows.Forms.Label lFechaFactura;
        private System.Windows.Forms.Panel panelFechaFactura;
    }
}