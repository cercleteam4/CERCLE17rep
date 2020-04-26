namespace cercle17
{
    partial class frmEXPORT_CPLUS_CobORE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEXPORT_CPLUS_CobORE));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Exportar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lRD = new System.Windows.Forms.Label();
            this.lRR = new System.Windows.Forms.Label();
            this.lRV = new System.Windows.Forms.Label();
            this.lFichero = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_Exportar);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 66);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Beige;
            this.button4.Location = new System.Drawing.Point(540, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 58);
            this.button4.TabIndex = 4;
            this.button4.Text = "Generar Fichero de COBROS de Facturas seleccionadas";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Beige;
            this.button2.Location = new System.Drawing.Point(401, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generar Fichero de COBROS de Facturas Propias";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Beige;
            this.button1.Location = new System.Drawing.Point(129, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Abrir Archivo recibido de OREMAPE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Exportar
            // 
            this.button_Exportar.BackColor = System.Drawing.Color.Beige;
            this.button_Exportar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exportar.Location = new System.Drawing.Point(269, 5);
            this.button_Exportar.Name = "button_Exportar";
            this.button_Exportar.Size = new System.Drawing.Size(126, 58);
            this.button_Exportar.TabIndex = 1;
            this.button_Exportar.Text = "EXPORTAR";
            this.button_Exportar.UseVisualStyleBackColor = false;
            this.button_Exportar.Visible = false;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Salir.Location = new System.Drawing.Point(12, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(111, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 69);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(828, 18);
            this.progressBar1.TabIndex = 4;
            // 
            // lRD
            // 
            this.lRD.AutoSize = true;
            this.lRD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRD.Location = new System.Drawing.Point(37, 122);
            this.lRD.Name = "lRD";
            this.lRD.Size = new System.Drawing.Size(51, 20);
            this.lRD.TabIndex = 5;
            this.lRD.Text = "label1";
            // 
            // lRR
            // 
            this.lRR.AutoSize = true;
            this.lRR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRR.Location = new System.Drawing.Point(37, 152);
            this.lRR.Name = "lRR";
            this.lRR.Size = new System.Drawing.Size(51, 20);
            this.lRR.TabIndex = 6;
            this.lRR.Text = "label1";
            // 
            // lRV
            // 
            this.lRV.AutoSize = true;
            this.lRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRV.Location = new System.Drawing.Point(37, 184);
            this.lRV.Name = "lRV";
            this.lRV.Size = new System.Drawing.Size(57, 20);
            this.lRV.TabIndex = 7;
            this.lRV.Text = "label1";
            // 
            // lFichero
            // 
            this.lFichero.AutoSize = true;
            this.lFichero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lFichero.Location = new System.Drawing.Point(26, 440);
            this.lFichero.Name = "lFichero";
            this.lFichero.Size = new System.Drawing.Size(35, 13);
            this.lFichero.TabIndex = 8;
            this.lFichero.Text = "label1";
            // 
            // frmEXPORT_CPLUS_CobORE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(854, 462);
            this.Controls.Add(this.lFichero);
            this.Controls.Add(this.lRV);
            this.Controls.Add(this.lRR);
            this.Controls.Add(this.lRD);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEXPORT_CPLUS_CobORE";
            this.Text = "Exportacion de Cobros recibidos de Oremape";
            this.Load += new System.EventHandler(this.frmEXPORT_CPLUS_CobORE_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Exportar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lRD;
        private System.Windows.Forms.Label lRR;
        private System.Windows.Forms.Label lRV;
        private System.Windows.Forms.Label lFichero;
    }
}