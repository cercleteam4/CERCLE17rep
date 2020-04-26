namespace cercle17
{
    partial class FormDescobro
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
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Factura = new System.Windows.Forms.TextBox();
            this.textBox_Anyo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Serie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancelar.Location = new System.Drawing.Point(21, 145);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(107, 51);
            this.button_Cancelar.TabIndex = 54;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Aceptar.Location = new System.Drawing.Point(556, 145);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(144, 51);
            this.button_Aceptar.TabIndex = 53;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Nº FACTURA A DESCOBRAR :";
            // 
            // textBox_Factura
            // 
            this.textBox_Factura.Location = new System.Drawing.Point(363, 27);
            this.textBox_Factura.Name = "textBox_Factura";
            this.textBox_Factura.Size = new System.Drawing.Size(85, 20);
            this.textBox_Factura.TabIndex = 56;
            // 
            // textBox_Anyo
            // 
            this.textBox_Anyo.Location = new System.Drawing.Point(363, 62);
            this.textBox_Anyo.Name = "textBox_Anyo";
            this.textBox_Anyo.Size = new System.Drawing.Size(85, 20);
            this.textBox_Anyo.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "AÑO :";
            // 
            // textBox_Serie
            // 
            this.textBox_Serie.Location = new System.Drawing.Point(363, 95);
            this.textBox_Serie.Name = "textBox_Serie";
            this.textBox_Serie.Size = new System.Drawing.Size(85, 20);
            this.textBox_Serie.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 59;
            this.label3.Text = "SERIE :";
            // 
            // FormDescobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(711, 207);
            this.Controls.Add(this.textBox_Serie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Anyo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Factura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDescobro";
            this.Text = "    Descobro";
            this.Load += new System.EventHandler(this.FormDescobro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Factura;
        private System.Windows.Forms.TextBox textBox_Anyo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Serie;
        private System.Windows.Forms.Label label3;
    }
}