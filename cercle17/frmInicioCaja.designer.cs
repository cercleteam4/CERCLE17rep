namespace cercle17
{
    partial class frmInicioCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioCaja));
            this.button_Gestion = new System.Windows.Forms.Button();
            this.button_Cobros = new System.Windows.Forms.Button();
            this.button_Caja = new System.Windows.Forms.Button();
            this.label_Debug = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.btn_PAGOS = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Gestion
            // 
            this.button_Gestion.Location = new System.Drawing.Point(339, 98);
            this.button_Gestion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Gestion.Name = "button_Gestion";
            this.button_Gestion.Size = new System.Drawing.Size(223, 64);
            this.button_Gestion.TabIndex = 0;
            this.button_Gestion.Text = "GESTIÓN PAGARÉS";
            this.button_Gestion.UseVisualStyleBackColor = true;
            this.button_Gestion.Visible = false;
            this.button_Gestion.Click += new System.EventHandler(this.button_Gestion_Click);
            // 
            // button_Cobros
            // 
            this.button_Cobros.Location = new System.Drawing.Point(33, 98);
            this.button_Cobros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Cobros.Name = "button_Cobros";
            this.button_Cobros.Size = new System.Drawing.Size(223, 44);
            this.button_Cobros.TabIndex = 1;
            this.button_Cobros.Text = "COBROS";
            this.button_Cobros.UseVisualStyleBackColor = true;
            this.button_Cobros.Visible = false;
            this.button_Cobros.Click += new System.EventHandler(this.button_Cobros_Click);
            // 
            // button_Caja
            // 
            this.button_Caja.Location = new System.Drawing.Point(33, 152);
            this.button_Caja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Caja.Name = "button_Caja";
            this.button_Caja.Size = new System.Drawing.Size(223, 44);
            this.button_Caja.TabIndex = 2;
            this.button_Caja.Text = "CAJA / DÍA";
            this.button_Caja.UseVisualStyleBackColor = true;
            this.button_Caja.Visible = false;
            this.button_Caja.Click += new System.EventHandler(this.button_Caja_Click);
            // 
            // label_Debug
            // 
            this.label_Debug.AutoSize = true;
            this.label_Debug.Location = new System.Drawing.Point(204, -2);
            this.label_Debug.Name = "label_Debug";
            this.label_Debug.Size = new System.Drawing.Size(0, 20);
            this.label_Debug.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 71);
            this.panel1.TabIndex = 5;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSALIR.Location = new System.Drawing.Point(12, 0);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(111, 65);
            this.btnSALIR.TabIndex = 5;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // btn_PAGOS
            // 
            this.btn_PAGOS.Location = new System.Drawing.Point(33, 204);
            this.btn_PAGOS.Name = "btn_PAGOS";
            this.btn_PAGOS.Size = new System.Drawing.Size(223, 44);
            this.btn_PAGOS.TabIndex = 6;
            this.btn_PAGOS.Text = "PAGOS NO CAJA";
            this.btn_PAGOS.UseVisualStyleBackColor = true;
            this.btn_PAGOS.Visible = false;
            this.btn_PAGOS.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInicioCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(611, 301);
            this.Controls.Add(this.btn_PAGOS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_Debug);
            this.Controls.Add(this.button_Caja);
            this.Controls.Add(this.button_Cobros);
            this.Controls.Add(this.button_Gestion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmInicioCaja";
            this.Text = "COBROS Y CAJA  v 3.79 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicioCaja_FormClosing);
            this.Load += new System.EventHandler(this.frmInicioCaja_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Gestion;
        private System.Windows.Forms.Button button_Cobros;
        private System.Windows.Forms.Button button_Caja;
        private System.Windows.Forms.Label label_Debug;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button btn_PAGOS;
    }
}

