namespace cercle17
{
    partial class frmEmpr03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpr03));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.button_ExportarExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.button_CUADRE = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(23, 100);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(129, 26);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // button_ExportarExcel
            // 
            this.button_ExportarExcel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ExportarExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button_ExportarExcel.Location = new System.Drawing.Point(23, 150);
            this.button_ExportarExcel.Name = "button_ExportarExcel";
            this.button_ExportarExcel.Size = new System.Drawing.Size(385, 39);
            this.button_ExportarExcel.TabIndex = 1;
            this.button_ExportarExcel.Text = "EXPORTAR A EXCEL COMPRAS Y VENTAS DÍA";
            this.button_ExportarExcel.UseVisualStyleBackColor = true;
            this.button_ExportarExcel.Click += new System.EventHandler(this.button_ExportarExcel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 71);
            this.panel1.TabIndex = 2;
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
            // button_CUADRE
            // 
            this.button_CUADRE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button_CUADRE.Location = new System.Drawing.Point(23, 195);
            this.button_CUADRE.Name = "button_CUADRE";
            this.button_CUADRE.Size = new System.Drawing.Size(384, 31);
            this.button_CUADRE.TabIndex = 3;
            this.button_CUADRE.Text = "CUADRE";
            this.button_CUADRE.UseVisualStyleBackColor = true;
            this.button_CUADRE.Click += new System.EventHandler(this.button_CUADRE_Click);
            // 
            // frmEmpr03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(553, 367);
            this.Controls.Add(this.button_CUADRE);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_ExportarExcel);
            this.Controls.Add(this.dtpFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpr03";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exportar a excel";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button button_ExportarExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button button_CUADRE;
    }
}