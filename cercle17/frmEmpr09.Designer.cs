namespace cercle17
{
    partial class frmEmpr09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpr09));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.btnExportarArticulos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnExportarVentas = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 71);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(320, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 67);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(122, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // btnExportarArticulos
            // 
            this.btnExportarArticulos.Location = new System.Drawing.Point(259, 170);
            this.btnExportarArticulos.Name = "btnExportarArticulos";
            this.btnExportarArticulos.Size = new System.Drawing.Size(148, 44);
            this.btnExportarArticulos.TabIndex = 4;
            this.btnExportarArticulos.Text = "Exportar Artículos";
            this.btnExportarArticulos.UseVisualStyleBackColor = true;
            this.btnExportarArticulos.Click += new System.EventHandler(this.btnExportarArticulos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(300, 110);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaHasta.TabIndex = 2;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(91, 110);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaDesde.TabIndex = 1;
            // 
            // btnExportarVentas
            // 
            this.btnExportarVentas.Location = new System.Drawing.Point(47, 170);
            this.btnExportarVentas.Name = "btnExportarVentas";
            this.btnExportarVentas.Size = new System.Drawing.Size(151, 44);
            this.btnExportarVentas.TabIndex = 3;
            this.btnExportarVentas.Text = "Exportar Ventas";
            this.btnExportarVentas.UseVisualStyleBackColor = true;
            this.btnExportarVentas.Click += new System.EventHandler(this.btnExportarVentas_Click);
            // 
            // frmEmpr09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(460, 352);
            this.Controls.Add(this.btnExportarVentas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.btnExportarArticulos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpr09";
            this.Text = "Exportación a excel";
            this.Load += new System.EventHandler(this.frmEmpr09_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button btnExportarArticulos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Button btnExportarVentas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}