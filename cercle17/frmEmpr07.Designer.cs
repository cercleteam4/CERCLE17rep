namespace cercle17
{
    partial class frmEmpr07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpr07));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.btn_Imp_Arts = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 4;
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
            // 
            // btn_Imp_Arts
            // 
            this.btn_Imp_Arts.Location = new System.Drawing.Point(41, 114);
            this.btn_Imp_Arts.Name = "btn_Imp_Arts";
            this.btn_Imp_Arts.Size = new System.Drawing.Size(136, 44);
            this.btn_Imp_Arts.TabIndex = 5;
            this.btn_Imp_Arts.Text = "Importar Artículos";
            this.btn_Imp_Arts.UseVisualStyleBackColor = true;
            this.btn_Imp_Arts.Click += new System.EventHandler(this.btn_Imp_Arts_Click);
            // 
            // frmEmpr07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Imp_Arts);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpr07";
            this.Text = "frmEmpr07";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button btn_Imp_Arts;
    }
}