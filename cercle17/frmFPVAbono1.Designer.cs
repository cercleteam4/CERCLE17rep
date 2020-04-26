namespace cercle17
{
    partial class frmFPVAbono1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPVAbono1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Grabar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.button_Grabar);
            this.panel2.Controls.Add(this.button_Salir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 64);
            this.panel2.TabIndex = 23;
            // 
            // button_Grabar
            // 
            this.button_Grabar.BackColor = System.Drawing.Color.Beige;
            this.button_Grabar.Font = new System.Drawing.Font("Arial", 12F);
            this.button_Grabar.Location = new System.Drawing.Point(134, 2);
            this.button_Grabar.Name = "button_Grabar";
            this.button_Grabar.Size = new System.Drawing.Size(174, 59);
            this.button_Grabar.TabIndex = 31;
            this.button_Grabar.Text = "GRABAR ABONO";
            this.button_Grabar.UseVisualStyleBackColor = false;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(12, 2);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(116, 59);
            this.button_Salir.TabIndex = 32;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.dGV1);
            this.panel1.Location = new System.Drawing.Point(24, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 276);
            this.panel1.TabIndex = 24;
            this.panel1.Visible = false;
            // 
            // dGV1
            // 
            this.dGV1.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV1.Location = new System.Drawing.Point(27, 52);
            this.dGV1.Name = "dGV1";
            this.dGV1.Size = new System.Drawing.Size(714, 199);
            this.dGV1.TabIndex = 0;
            this.dGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV1_CellContentClick);
            // 
            // frmFPVAbono1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 625);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPVAbono1";
            this.Text = "frmFPVAbono1";
            this.Load += new System.EventHandler(this.frmFPVAbono1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Grabar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGV1;
    }
}