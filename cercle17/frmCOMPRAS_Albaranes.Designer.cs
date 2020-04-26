namespace cercle17
{
    partial class frmCOMPRAS_Albaranes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCOMPRAS_Albaranes));
            this.dgvAlbaranes = new System.Windows.Forms.DataGridView();
            this.ComCpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComCfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbProNom = new System.Windows.Forms.TextBox();
            this.btnProvBuscar = new System.Windows.Forms.Button();
            this.tbProCod = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbaranes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlbaranes
            // 
            this.dgvAlbaranes.AllowUserToAddRows = false;
            this.dgvAlbaranes.AllowUserToDeleteRows = false;
            this.dgvAlbaranes.AllowUserToOrderColumns = true;
            this.dgvAlbaranes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAlbaranes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbaranes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComCpa,
            this.Anyo,
            this.ComCfa,
            this.ProNom,
            this.Total});
            this.dgvAlbaranes.Location = new System.Drawing.Point(15, 125);
            this.dgvAlbaranes.Name = "dgvAlbaranes";
            this.dgvAlbaranes.ReadOnly = true;
            this.dgvAlbaranes.Size = new System.Drawing.Size(623, 285);
            this.dgvAlbaranes.TabIndex = 0;
            this.dgvAlbaranes.DoubleClick += new System.EventHandler(this.dgvAlbaranes_DoubleClick);
            // 
            // ComCpa
            // 
            this.ComCpa.DataPropertyName = "ComCpa";
            this.ComCpa.HeaderText = "Albarán";
            this.ComCpa.Name = "ComCpa";
            this.ComCpa.ReadOnly = true;
            this.ComCpa.Width = 80;
            // 
            // Anyo
            // 
            this.Anyo.DataPropertyName = "Anyo";
            this.Anyo.HeaderText = "Año";
            this.Anyo.Name = "Anyo";
            this.Anyo.ReadOnly = true;
            this.Anyo.Width = 80;
            // 
            // ComCfa
            // 
            this.ComCfa.DataPropertyName = "ComCfa";
            this.ComCfa.HeaderText = "Fecha";
            this.ComCfa.Name = "ComCfa";
            this.ComCfa.ReadOnly = true;
            // 
            // ProNom
            // 
            this.ProNom.DataPropertyName = "ProNom";
            this.ProNom.HeaderText = "Proveedor";
            this.ProNom.Name = "ProNom";
            this.ProNom.ReadOnly = true;
            this.ProNom.Width = 200;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(252, 23);
            this.lblFechaFin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(74, 15);
            this.lblFechaFin.TabIndex = 14;
            this.lblFechaFin.Text = "FECHA FIN :";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(330, 19);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(93, 21);
            this.dtpFechaFin.TabIndex = 13;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(110, 19);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(93, 21);
            this.dtpFechaInicio.TabIndex = 12;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(14, 23);
            this.lblFechaInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(91, 15);
            this.lblFechaInicio.TabIndex = 11;
            this.lblFechaInicio.Text = "FECHA INICIO :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(520, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 27);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(551, 416);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 27);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.tbProNom);
            this.groupBox1.Controls.Add(this.btnProvBuscar);
            this.groupBox1.Controls.Add(this.tbProCod);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 88);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(520, 48);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 27);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tbProNom
            // 
            this.tbProNom.Location = new System.Drawing.Point(198, 54);
            this.tbProNom.Name = "tbProNom";
            this.tbProNom.ReadOnly = true;
            this.tbProNom.Size = new System.Drawing.Size(269, 21);
            this.tbProNom.TabIndex = 23;
            // 
            // btnProvBuscar
            // 
            this.btnProvBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnProvBuscar.Image")));
            this.btnProvBuscar.Location = new System.Drawing.Point(169, 54);
            this.btnProvBuscar.Name = "btnProvBuscar";
            this.btnProvBuscar.Size = new System.Drawing.Size(23, 23);
            this.btnProvBuscar.TabIndex = 22;
            this.btnProvBuscar.UseVisualStyleBackColor = true;
            this.btnProvBuscar.Click += new System.EventHandler(this.btnProvBuscar_Click);
            // 
            // tbProCod
            // 
            this.tbProCod.Location = new System.Drawing.Point(110, 54);
            this.tbProCod.Name = "tbProCod";
            this.tbProCod.Size = new System.Drawing.Size(53, 21);
            this.tbProCod.TabIndex = 21;
            this.tbProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProCod_KeyPress);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(14, 57);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(89, 15);
            this.lblProveedor.TabIndex = 24;
            this.lblProveedor.Text = "PROVEEDOR :";
            // 
            // frmCOMPRAS_Albaranes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(653, 452);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvAlbaranes);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCOMPRAS_Albaranes";
            this.Text = "Albaranes de compras";
            this.Load += new System.EventHandler(this.frmALBARANES_COMPRAS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbaranes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlbaranes;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anyo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox tbProNom;
        private System.Windows.Forms.Button btnProvBuscar;
        private System.Windows.Forms.TextBox tbProCod;
    }
}