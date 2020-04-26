namespace cercle17
{
    partial class frmExportaContaplus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportaContaplus));
            this.button_Exporta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Fichero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_Final = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Exporta
            // 
            this.button_Exporta.Location = new System.Drawing.Point(43, 266);
            this.button_Exporta.Name = "button_Exporta";
            this.button_Exporta.Size = new System.Drawing.Size(163, 48);
            this.button_Exporta.TabIndex = 0;
            this.button_Exporta.Text = "EXPORTAR";
            this.button_Exporta.UseVisualStyleBackColor = true;
            this.button_Exporta.Click += new System.EventHandler(this.button_Exporta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "FACTURAS";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_Fichero);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker_Final);
            this.panel1.Controls.Add(this.dateTimePicker_Inicio);
            this.panel1.Location = new System.Drawing.Point(28, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 190);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Fichero
            // 
            this.textBox_Fichero.Location = new System.Drawing.Point(96, 129);
            this.textBox_Fichero.Name = "textBox_Fichero";
            this.textBox_Fichero.Size = new System.Drawing.Size(399, 20);
            this.textBox_Fichero.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fichero :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde";
            // 
            // dateTimePicker_Final
            // 
            this.dateTimePicker_Final.Location = new System.Drawing.Point(96, 76);
            this.dateTimePicker_Final.Name = "dateTimePicker_Final";
            this.dateTimePicker_Final.Size = new System.Drawing.Size(224, 20);
            this.dateTimePicker_Final.TabIndex = 1;
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(96, 22);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(224, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            // 
            // frmExportaContaplus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(647, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Exporta);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportaContaplus";
            this.Text = "    Exportación Contaplus";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exporta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Fichero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Final;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
    }
}