namespace cercle17
{
    partial class frmEXPORT_CPLUS_CAJA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEXPORT_CPLUS_CAJA));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Exportar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel_Albaranes = new System.Windows.Forms.Panel();
            this.dataGridView_Albaranes = new System.Windows.Forms.DataGridView();
            this.Albaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodDetallista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomDetallista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFichero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel_Albaranes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_Exportar);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 66);
            this.panel1.TabIndex = 4;
            // 
            // button_Exportar
            // 
            this.button_Exportar.BackColor = System.Drawing.Color.Beige;
            this.button_Exportar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exportar.Location = new System.Drawing.Point(137, 3);
            this.button_Exportar.Name = "button_Exportar";
            this.button_Exportar.Size = new System.Drawing.Size(164, 61);
            this.button_Exportar.TabIndex = 1;
            this.button_Exportar.Text = "EXPORTAR";
            this.button_Exportar.UseVisualStyleBackColor = false;
            this.button_Exportar.Visible = false;
            this.button_Exportar.Click += new System.EventHandler(this.button_Exportar_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(117, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(88, 92);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(129, 26);
            this.dtpFecha.TabIndex = 5;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(14, 97);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(57, 20);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "FECHA:";
            // 
            // panel_Albaranes
            // 
            this.panel_Albaranes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Albaranes.Controls.Add(this.dataGridView_Albaranes);
            this.panel_Albaranes.Location = new System.Drawing.Point(14, 142);
            this.panel_Albaranes.Name = "panel_Albaranes";
            this.panel_Albaranes.Size = new System.Drawing.Size(944, 445);
            this.panel_Albaranes.TabIndex = 7;
            // 
            // dataGridView_Albaranes
            // 
            this.dataGridView_Albaranes.AllowUserToAddRows = false;
            this.dataGridView_Albaranes.AllowUserToDeleteRows = false;
            this.dataGridView_Albaranes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Albaranes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Albaranes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Albaran,
            this.Fecha,
            this.CodDetallista,
            this.NomDetallista,
            this.Tv,
            this.NumCobro,
            this.FecCobro,
            this.Total});
            this.dataGridView_Albaranes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Albaranes.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Albaranes.MultiSelect = false;
            this.dataGridView_Albaranes.Name = "dataGridView_Albaranes";
            this.dataGridView_Albaranes.ReadOnly = true;
            this.dataGridView_Albaranes.RowHeadersVisible = false;
            this.dataGridView_Albaranes.Size = new System.Drawing.Size(942, 443);
            this.dataGridView_Albaranes.TabIndex = 0;
            // 
            // Albaran
            // 
            this.Albaran.DataPropertyName = "Albaran";
            this.Albaran.HeaderText = "Nº Albarán";
            this.Albaran.Name = "Albaran";
            this.Albaran.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha Albarán";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 120;
            // 
            // CodDetallista
            // 
            this.CodDetallista.DataPropertyName = "CodDetallista";
            this.CodDetallista.HeaderText = "Cód. Detallista";
            this.CodDetallista.Name = "CodDetallista";
            this.CodDetallista.ReadOnly = true;
            // 
            // NomDetallista
            // 
            this.NomDetallista.DataPropertyName = "NomDetallista";
            this.NomDetallista.HeaderText = "Nom. Detallista";
            this.NomDetallista.Name = "NomDetallista";
            this.NomDetallista.ReadOnly = true;
            this.NomDetallista.Width = 150;
            // 
            // Tv
            // 
            this.Tv.DataPropertyName = "Tv";
            this.Tv.HeaderText = "Tipo Venta";
            this.Tv.Name = "Tv";
            this.Tv.ReadOnly = true;
            // 
            // NumCobro
            // 
            this.NumCobro.DataPropertyName = "NumCobro";
            this.NumCobro.HeaderText = "Nº Recibo";
            this.NumCobro.Name = "NumCobro";
            this.NumCobro.ReadOnly = true;
            // 
            // FecCobro
            // 
            this.FecCobro.DataPropertyName = "FecCobro";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FecCobro.DefaultCellStyle = dataGridViewCellStyle1;
            this.FecCobro.HeaderText = "Fecha Recibo";
            this.FecCobro.Name = "FecCobro";
            this.FecCobro.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Importe Total Albarán";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 150;
            // 
            // lFichero
            // 
            this.lFichero.AutoSize = true;
            this.lFichero.ForeColor = System.Drawing.Color.Navy;
            this.lFichero.Location = new System.Drawing.Point(30, 12);
            this.lFichero.Name = "lFichero";
            this.lFichero.Size = new System.Drawing.Size(0, 13);
            this.lFichero.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(830, 597);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.lFichero);
            this.groupBox1.Location = new System.Drawing.Point(396, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 60);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar por";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "Cliente";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Albaran";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frmEXPORT_CPLUS_CAJA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(969, 630);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_Albaranes);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEXPORT_CPLUS_CAJA";
            this.Text = "frmEXPORT_CPLUS_CAJA";
            this.Load += new System.EventHandler(this.frmEXPORT_CPLUS_CAJA_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Albaranes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exportar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel_Albaranes;
        private System.Windows.Forms.DataGridView dataGridView_Albaranes;
        private System.Windows.Forms.Label lFichero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Albaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodDetallista;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomDetallista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tv;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}