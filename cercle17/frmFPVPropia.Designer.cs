namespace cercle17
{
    partial class frmFPVPropia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPVPropia));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.btn_Selecc_Todas = new System.Windows.Forms.Button();
            this.btn_Grabar_Facturas = new System.Windows.Forms.Button();
            this.panelFec = new System.Windows.Forms.Panel();
            this.lFechaIni = new System.Windows.Forms.Label();
            this.lFechaFin = new System.Windows.Forms.Label();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panelDet = new System.Windows.Forms.Panel();
            this.llDetFin = new System.Windows.Forms.LinkLabel();
            this.llDetIni = new System.Windows.Forms.LinkLabel();
            this.lDetFin = new System.Windows.Forms.Label();
            this.lDetIni = new System.Windows.Forms.Label();
            this.tDetFin = new System.Windows.Forms.TextBox();
            this.tDetIni = new System.Windows.Forms.TextBox();
            this.lFechaFactura = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaFactura = new System.Windows.Forms.DateTimePicker();
            this.panelPeriodicidad = new System.Windows.Forms.Panel();
            this.lblPeriodicidad = new System.Windows.Forms.Label();
            this.cbPeriodicidad = new System.Windows.Forms.ComboBox();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.panelFec.SuspendLayout();
            this.panelDet.SuspendLayout();
            this.panelPeriodicidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnSALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1055, 73);
            this.panel2.TabIndex = 5;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(3, 5);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(112, 65);
            this.btnSALIR.TabIndex = 4;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // dGV1
            // 
            this.dGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV1.Location = new System.Drawing.Point(12, 184);
            this.dGV1.Name = "dGV1";
            this.dGV1.Size = new System.Drawing.Size(1030, 450);
            this.dGV1.TabIndex = 6;
            // 
            // btn_Selecc_Todas
            // 
            this.btn_Selecc_Todas.Location = new System.Drawing.Point(12, 139);
            this.btn_Selecc_Todas.Name = "btn_Selecc_Todas";
            this.btn_Selecc_Todas.Size = new System.Drawing.Size(60, 39);
            this.btn_Selecc_Todas.TabIndex = 8;
            this.btn_Selecc_Todas.Text = "Todas";
            this.btn_Selecc_Todas.UseVisualStyleBackColor = true;
            this.btn_Selecc_Todas.Click += new System.EventHandler(this.btn_Selecc_Todas_Click);
            // 
            // btn_Grabar_Facturas
            // 
            this.btn_Grabar_Facturas.Location = new System.Drawing.Point(910, 139);
            this.btn_Grabar_Facturas.Name = "btn_Grabar_Facturas";
            this.btn_Grabar_Facturas.Size = new System.Drawing.Size(132, 38);
            this.btn_Grabar_Facturas.TabIndex = 9;
            this.btn_Grabar_Facturas.Text = "EMITIR FACTURAS";
            this.btn_Grabar_Facturas.UseVisualStyleBackColor = true;
            this.btn_Grabar_Facturas.Click += new System.EventHandler(this.btn_Grabar_Facturas_Click);
            // 
            // panelFec
            // 
            this.panelFec.BackColor = System.Drawing.Color.Lavender;
            this.panelFec.Controls.Add(this.lFechaIni);
            this.panelFec.Controls.Add(this.lFechaFin);
            this.panelFec.Controls.Add(this.dateTimePicker_Fin);
            this.panelFec.Controls.Add(this.dateTimePicker_Inicio);
            this.panelFec.Location = new System.Drawing.Point(12, 81);
            this.panelFec.Name = "panelFec";
            this.panelFec.Size = new System.Drawing.Size(325, 52);
            this.panelFec.TabIndex = 12;
            // 
            // lFechaIni
            // 
            this.lFechaIni.AutoSize = true;
            this.lFechaIni.Location = new System.Drawing.Point(13, 20);
            this.lFechaIni.Name = "lFechaIni";
            this.lFechaIni.Size = new System.Drawing.Size(38, 13);
            this.lFechaIni.TabIndex = 7;
            this.lFechaIni.Text = "Desde";
            // 
            // lFechaFin
            // 
            this.lFechaFin.AutoSize = true;
            this.lFechaFin.Location = new System.Drawing.Point(167, 20);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(35, 13);
            this.lFechaFin.TabIndex = 4;
            this.lFechaFin.Text = "Hasta";
            this.lFechaFin.Visible = false;
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(218, 17);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 1;
            this.dateTimePicker_Fin.Visible = false;
            this.dateTimePicker_Fin.ValueChanged += new System.EventHandler(this.dateTimePicker_Fin_ValueChanged);
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(64, 17);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // panelDet
            // 
            this.panelDet.BackColor = System.Drawing.Color.Lavender;
            this.panelDet.Controls.Add(this.llDetFin);
            this.panelDet.Controls.Add(this.llDetIni);
            this.panelDet.Controls.Add(this.lDetFin);
            this.panelDet.Controls.Add(this.lDetIni);
            this.panelDet.Controls.Add(this.tDetFin);
            this.panelDet.Controls.Add(this.tDetIni);
            this.panelDet.Location = new System.Drawing.Point(343, 81);
            this.panelDet.Name = "panelDet";
            this.panelDet.Size = new System.Drawing.Size(699, 52);
            this.panelDet.TabIndex = 13;
            // 
            // llDetFin
            // 
            this.llDetFin.AutoSize = true;
            this.llDetFin.Location = new System.Drawing.Point(349, 10);
            this.llDetFin.Name = "llDetFin";
            this.llDetFin.Size = new System.Drawing.Size(75, 13);
            this.llDetFin.TabIndex = 5;
            this.llDetFin.TabStop = true;
            this.llDetFin.Text = "Detallista Final";
            this.llDetFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDetFin_LinkClicked);
            // 
            // llDetIni
            // 
            this.llDetIni.AutoSize = true;
            this.llDetIni.Location = new System.Drawing.Point(14, 10);
            this.llDetIni.Name = "llDetIni";
            this.llDetIni.Size = new System.Drawing.Size(80, 13);
            this.llDetIni.TabIndex = 4;
            this.llDetIni.TabStop = true;
            this.llDetIni.Text = "Detallista Inicial";
            this.llDetIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDetIni_LinkClicked);
            // 
            // lDetFin
            // 
            this.lDetFin.AutoSize = true;
            this.lDetFin.Location = new System.Drawing.Point(412, 29);
            this.lDetFin.Name = "lDetFin";
            this.lDetFin.Size = new System.Drawing.Size(0, 13);
            this.lDetFin.TabIndex = 3;
            // 
            // lDetIni
            // 
            this.lDetIni.AutoSize = true;
            this.lDetIni.Location = new System.Drawing.Point(77, 29);
            this.lDetIni.Name = "lDetIni";
            this.lDetIni.Size = new System.Drawing.Size(0, 13);
            this.lDetIni.TabIndex = 2;
            // 
            // tDetFin
            // 
            this.tDetFin.Location = new System.Drawing.Point(352, 26);
            this.tDetFin.Name = "tDetFin";
            this.tDetFin.Size = new System.Drawing.Size(54, 20);
            this.tDetFin.TabIndex = 1;
            this.tDetFin.TextChanged += new System.EventHandler(this.tDetFin_TextChanged);
            this.tDetFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetFin_KeyPress);
            // 
            // tDetIni
            // 
            this.tDetIni.Location = new System.Drawing.Point(17, 26);
            this.tDetIni.Name = "tDetIni";
            this.tDetIni.Size = new System.Drawing.Size(54, 20);
            this.tDetIni.TabIndex = 0;
            this.tDetIni.TextChanged += new System.EventHandler(this.tDetIni_TextChanged);
            this.tDetIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetIni_KeyPress);
            // 
            // lFechaFactura
            // 
            this.lFechaFactura.AutoSize = true;
            this.lFechaFactura.Location = new System.Drawing.Point(717, 153);
            this.lFechaFactura.Name = "lFechaFactura";
            this.lFechaFactura.Size = new System.Drawing.Size(76, 13);
            this.lFechaFactura.TabIndex = 9;
            this.lFechaFactura.Text = "Fecha Factura";
            this.lFechaFactura.Visible = false;
            // 
            // dateTimePicker_FechaFactura
            // 
            this.dateTimePicker_FechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FechaFactura.Location = new System.Drawing.Point(798, 150);
            this.dateTimePicker_FechaFactura.Name = "dateTimePicker_FechaFactura";
            this.dateTimePicker_FechaFactura.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_FechaFactura.TabIndex = 8;
            this.dateTimePicker_FechaFactura.Visible = false;
            // 
            // panelPeriodicidad
            // 
            this.panelPeriodicidad.BackColor = System.Drawing.Color.Lavender;
            this.panelPeriodicidad.Controls.Add(this.lblPeriodicidad);
            this.panelPeriodicidad.Controls.Add(this.cbPeriodicidad);
            this.panelPeriodicidad.Location = new System.Drawing.Point(99, 135);
            this.panelPeriodicidad.Name = "panelPeriodicidad";
            this.panelPeriodicidad.Size = new System.Drawing.Size(237, 46);
            this.panelPeriodicidad.TabIndex = 14;
            this.panelPeriodicidad.Visible = false;
            // 
            // lblPeriodicidad
            // 
            this.lblPeriodicidad.AutoSize = true;
            this.lblPeriodicidad.Location = new System.Drawing.Point(16, 18);
            this.lblPeriodicidad.Name = "lblPeriodicidad";
            this.lblPeriodicidad.Size = new System.Drawing.Size(65, 13);
            this.lblPeriodicidad.TabIndex = 1;
            this.lblPeriodicidad.Text = "Periodicidad";
            // 
            // cbPeriodicidad
            // 
            this.cbPeriodicidad.FormattingEnabled = true;
            this.cbPeriodicidad.Location = new System.Drawing.Point(97, 12);
            this.cbPeriodicidad.Name = "cbPeriodicidad";
            this.cbPeriodicidad.Size = new System.Drawing.Size(121, 21);
            this.cbPeriodicidad.TabIndex = 3;
            this.cbPeriodicidad.SelectedIndexChanged += new System.EventHandler(this.cbPeriodicidad_SelectedIndexChanged);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(900, 647);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(108, 13);
            this.lblTotalRegistros.TabIndex = 15;
            this.lblTotalRegistros.Text = "Total Registros: 0";
            // 
            // frmFPVPropia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1055, 670);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.panelPeriodicidad);
            this.Controls.Add(this.dateTimePicker_FechaFactura);
            this.Controls.Add(this.lFechaFactura);
            this.Controls.Add(this.panelDet);
            this.Controls.Add(this.panelFec);
            this.Controls.Add(this.btn_Grabar_Facturas);
            this.Controls.Add(this.btn_Selecc_Todas);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPVPropia";
            this.Text = "    Facturación Propia";
            this.Load += new System.EventHandler(this.frmFPVPropia_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.panelFec.ResumeLayout(false);
            this.panelFec.PerformLayout();
            this.panelDet.ResumeLayout(false);
            this.panelDet.PerformLayout();
            this.panelPeriodicidad.ResumeLayout(false);
            this.panelPeriodicidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.Button btn_Selecc_Todas;
        private System.Windows.Forms.Button btn_Grabar_Facturas;
        private System.Windows.Forms.Panel panelFec;
        private System.Windows.Forms.Label lFechaIni;
        private System.Windows.Forms.Label lFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Panel panelDet;
        private System.Windows.Forms.LinkLabel llDetFin;
        private System.Windows.Forms.LinkLabel llDetIni;
        private System.Windows.Forms.Label lDetFin;
        private System.Windows.Forms.Label lDetIni;
        private System.Windows.Forms.TextBox tDetFin;
        private System.Windows.Forms.TextBox tDetIni;
        private System.Windows.Forms.Label lFechaFactura;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaFactura;
        private System.Windows.Forms.Panel panelPeriodicidad;
        private System.Windows.Forms.Label lblPeriodicidad;
        private System.Windows.Forms.ComboBox cbPeriodicidad;
        private System.Windows.Forms.Label lblTotalRegistros;
    }
}