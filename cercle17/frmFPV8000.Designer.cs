namespace cercle17
{
    partial class frmFPV8000
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPV8000));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.dTP1 = new System.Windows.Forms.DateTimePicker();
            this.btn_Selecc_Todas = new System.Windows.Forms.Button();
            this.btn_Grabar_Facturas = new System.Windows.Forms.Button();
            this.lTotal = new System.Windows.Forms.Label();
            this.lTotalSelecc = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnSALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 73);
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
            this.dGV1.Location = new System.Drawing.Point(12, 124);
            this.dGV1.Name = "dGV1";
            this.dGV1.Size = new System.Drawing.Size(1030, 447);
            this.dGV1.TabIndex = 6;
            this.dGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV1_CellContentClick);
            // 
            // dTP1
            // 
            this.dTP1.Location = new System.Drawing.Point(894, 85);
            this.dTP1.Name = "dTP1";
            this.dTP1.Size = new System.Drawing.Size(147, 20);
            this.dTP1.TabIndex = 7;
            this.dTP1.ValueChanged += new System.EventHandler(this.dTP1_ValueChanged);
            // 
            // btn_Selecc_Todas
            // 
            this.btn_Selecc_Todas.Location = new System.Drawing.Point(12, 79);
            this.btn_Selecc_Todas.Name = "btn_Selecc_Todas";
            this.btn_Selecc_Todas.Size = new System.Drawing.Size(60, 39);
            this.btn_Selecc_Todas.TabIndex = 8;
            this.btn_Selecc_Todas.Text = "Todas";
            this.btn_Selecc_Todas.UseVisualStyleBackColor = true;
            this.btn_Selecc_Todas.Click += new System.EventHandler(this.btn_Selecc_Todas_Click);
            // 
            // btn_Grabar_Facturas
            // 
            this.btn_Grabar_Facturas.Location = new System.Drawing.Point(12, 577);
            this.btn_Grabar_Facturas.Name = "btn_Grabar_Facturas";
            this.btn_Grabar_Facturas.Size = new System.Drawing.Size(188, 57);
            this.btn_Grabar_Facturas.TabIndex = 9;
            this.btn_Grabar_Facturas.Text = "Grabar las Facturas seleccionadas";
            this.btn_Grabar_Facturas.UseVisualStyleBackColor = true;
            this.btn_Grabar_Facturas.Visible = false;
            this.btn_Grabar_Facturas.Click += new System.EventHandler(this.btn_Grabar_Facturas_Click);
            // 
            // lTotal
            // 
            this.lTotal.AutoSize = true;
            this.lTotal.Location = new System.Drawing.Point(1006, 599);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(35, 13);
            this.lTotal.TabIndex = 10;
            this.lTotal.Text = "label1";
            // 
            // lTotalSelecc
            // 
            this.lTotalSelecc.AutoSize = true;
            this.lTotalSelecc.Location = new System.Drawing.Point(1006, 577);
            this.lTotalSelecc.Name = "lTotalSelecc";
            this.lTotalSelecc.Size = new System.Drawing.Size(35, 13);
            this.lTotalSelecc.TabIndex = 11;
            this.lTotalSelecc.Text = "label1";
            // 
            // frmFPV8000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1067, 646);
            this.Controls.Add(this.lTotalSelecc);
            this.Controls.Add(this.lTotal);
            this.Controls.Add(this.btn_Grabar_Facturas);
            this.Controls.Add(this.btn_Selecc_Todas);
            this.Controls.Add(this.dTP1);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPV8000";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmFPV8000_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.DateTimePicker dTP1;
        private System.Windows.Forms.Button btn_Selecc_Todas;
        private System.Windows.Forms.Button btn_Grabar_Facturas;
        private System.Windows.Forms.Label lTotal;
        private System.Windows.Forms.Label lTotalSelecc;
    }
}