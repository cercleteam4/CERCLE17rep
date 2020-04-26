namespace cercle17
{
    partial class frmEmpr04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpr04));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Listar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.btn_Prepara_File_FP_OMP = new System.Windows.Forms.Button();
            this.dGv1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pD1 = new System.Drawing.Printing.PrintDocument();
            this.btnExportExcel1 = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnExportFacturas = new System.Windows.Forms.Button();
            this.BtnExportCobros = new System.Windows.Forms.Button();
            this.BtnExportFacturasCobrosOremape = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.btn_Listar);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.btnSALIR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(950, 73);
            this.panel4.TabIndex = 7;
            // 
            // btn_Listar
            // 
            this.btn_Listar.BackColor = System.Drawing.Color.Beige;
            this.btn_Listar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Listar.Image = global::cercle17.Properties.Resources.printer21;
            this.btn_Listar.Location = new System.Drawing.Point(132, 5);
            this.btn_Listar.Name = "btn_Listar";
            this.btn_Listar.Size = new System.Drawing.Size(131, 63);
            this.btn_Listar.TabIndex = 7;
            this.btn_Listar.Text = "Imprimir";
            this.btn_Listar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Listar.UseVisualStyleBackColor = false;
            this.btn_Listar.Visible = false;
            this.btn_Listar.Click += new System.EventHandler(this.btn_Listar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(816, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 67);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(114, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // btn_Prepara_File_FP_OMP
            // 
            this.btn_Prepara_File_FP_OMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Prepara_File_FP_OMP.Location = new System.Drawing.Point(12, 122);
            this.btn_Prepara_File_FP_OMP.Name = "btn_Prepara_File_FP_OMP";
            this.btn_Prepara_File_FP_OMP.Size = new System.Drawing.Size(266, 55);
            this.btn_Prepara_File_FP_OMP.TabIndex = 8;
            this.btn_Prepara_File_FP_OMP.Text = "Preparar Fichero FP para OREMAPE";
            this.btn_Prepara_File_FP_OMP.UseVisualStyleBackColor = true;
            this.btn_Prepara_File_FP_OMP.Click += new System.EventHandler(this.btn_Prepara_File_FP_OMP_Click);
            // 
            // dGv1
            // 
            this.dGv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv1.Location = new System.Drawing.Point(12, 252);
            this.dGv1.Name = "dGv1";
            this.dGv1.Size = new System.Drawing.Size(926, 234);
            this.dGv1.TabIndex = 9;
            this.dGv1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // pD1
            // 
            this.pD1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pD1_PrintPage);
            // 
            // btnExportExcel1
            // 
            this.btnExportExcel1.Location = new System.Drawing.Point(322, 80);
            this.btnExportExcel1.Name = "btnExportExcel1";
            this.btnExportExcel1.Size = new System.Drawing.Size(89, 35);
            this.btnExportExcel1.TabIndex = 11;
            this.btnExportExcel1.Text = "Exportar Excel1";
            this.btnExportExcel1.UseVisualStyleBackColor = true;
            this.btnExportExcel1.Visible = false;
            this.btnExportExcel1.Click += new System.EventHandler(this.btnExportExcel1_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(656, 85);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 20);
            this.dtpFecha.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(828, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 54);
            this.button3.TabIndex = 17;
            this.button3.Text = "Detallistas 79000";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnExportFacturas
            // 
            this.BtnExportFacturas.Location = new System.Drawing.Point(448, 122);
            this.BtnExportFacturas.Name = "BtnExportFacturas";
            this.BtnExportFacturas.Size = new System.Drawing.Size(89, 55);
            this.BtnExportFacturas.TabIndex = 18;
            this.BtnExportFacturas.Text = "EXCEL FACTURAS PROPIAS";
            this.BtnExportFacturas.UseVisualStyleBackColor = true;
            this.BtnExportFacturas.Click += new System.EventHandler(this.BtnExportFacturas_Click);
            // 
            // BtnExportCobros
            // 
            this.BtnExportCobros.Location = new System.Drawing.Point(543, 122);
            this.BtnExportCobros.Name = "BtnExportCobros";
            this.BtnExportCobros.Size = new System.Drawing.Size(89, 55);
            this.BtnExportCobros.TabIndex = 19;
            this.BtnExportCobros.Text = "EXCEL COBROS F. PROPIAS";
            this.BtnExportCobros.UseVisualStyleBackColor = true;
            this.BtnExportCobros.Click += new System.EventHandler(this.BtnExportCobros_Click);
            // 
            // BtnExportFacturasCobrosOremape
            // 
            this.BtnExportFacturasCobrosOremape.Location = new System.Drawing.Point(638, 122);
            this.BtnExportFacturasCobrosOremape.Name = "BtnExportFacturasCobrosOremape";
            this.BtnExportFacturasCobrosOremape.Size = new System.Drawing.Size(184, 55);
            this.BtnExportFacturasCobrosOremape.TabIndex = 20;
            this.BtnExportFacturasCobrosOremape.Text = "EXCEL FACTURAS Y COBROS OREMAPE";
            this.BtnExportFacturasCobrosOremape.UseVisualStyleBackColor = true;
            this.BtnExportFacturasCobrosOremape.Click += new System.EventHandler(this.BtnExportFacturasCobrosOremape_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(817, 85);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaHasta.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(773, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Hasta:";
            // 
            // frmEmpr04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(950, 622);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.BtnExportFacturasCobrosOremape);
            this.Controls.Add(this.BtnExportCobros);
            this.Controls.Add(this.BtnExportFacturas);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnExportExcel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGv1);
            this.Controls.Add(this.btn_Prepara_File_FP_OMP);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpr04";
            this.Text = "frmEmpr04";
            this.Load += new System.EventHandler(this.frmEmpr04_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button btn_Prepara_File_FP_OMP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dGv1;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument pD1;
        private System.Windows.Forms.Button btn_Listar;
        private System.Windows.Forms.Button btnExportExcel1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtnExportFacturas;
        private System.Windows.Forms.Button BtnExportCobros;
        private System.Windows.Forms.Button BtnExportFacturasCobrosOremape;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}