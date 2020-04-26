namespace cercle17
{
    partial class frmListaTerminales
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
            this.textBox_Listado = new System.Windows.Forms.TextBox();
            this.button_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Listado
            // 
            this.textBox_Listado.Location = new System.Drawing.Point(32, 13);
            this.textBox_Listado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Listado.Multiline = true;
            this.textBox_Listado.Name = "textBox_Listado";
            this.textBox_Listado.Size = new System.Drawing.Size(546, 216);
            this.textBox_Listado.TabIndex = 0;
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(473, 250);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(105, 65);
            this.button_Salir.TabIndex = 3;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // frmListaTerminales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 329);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.textBox_Listado);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaTerminales";
            this.Text = "    Consulta Terminales-Vendedores";
            this.Load += new System.EventHandler(this.frmListaTerminales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Listado;
        private System.Windows.Forms.Button button_Salir;

    }
}