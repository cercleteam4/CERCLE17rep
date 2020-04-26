namespace cercle17
{
    partial class FormAbonos
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
            this.label_Cliente = new System.Windows.Forms.Label();
            this.textBox_Observaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Fecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DetCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // label_Cliente
            // 
            this.label_Cliente.AutoSize = true;
            this.label_Cliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cliente.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Cliente.Location = new System.Drawing.Point(222, 71);
            this.label_Cliente.Name = "label_Cliente";
            this.label_Cliente.Size = new System.Drawing.Size(169, 19);
            this.label_Cliente.TabIndex = 28;
            this.label_Cliente.Text = "CLIENTE NO EXISTE";
            this.label_Cliente.Visible = false;
            // 
            // textBox_Observaciones
            // 
            this.textBox_Observaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Observaciones.Location = new System.Drawing.Point(172, 185);
            this.textBox_Observaciones.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Observaciones.Name = "textBox_Observaciones";
            this.textBox_Observaciones.Size = new System.Drawing.Size(523, 26);
            this.textBox_Observaciones.TabIndex = 21;
            this.textBox_Observaciones.Leave += new System.EventHandler(this.textBox_Observaciones_Leave);
            this.textBox_Observaciones.Enter += new System.EventHandler(this.textBox_Observaciones_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Observaciones";
            // 
            // textBox_Fecha
            // 
            this.textBox_Fecha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Fecha.Location = new System.Drawing.Point(427, 30);
            this.textBox_Fecha.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fecha.Name = "textBox_Fecha";
            this.textBox_Fecha.Size = new System.Drawing.Size(120, 29);
            this.textBox_Fecha.TabIndex = 19;
            this.textBox_Fecha.Leave += new System.EventHandler(this.textBox_Fecha_Leave);
            this.textBox_Fecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Fecha_KeyPress);
            this.textBox_Fecha.Enter += new System.EventHandler(this.textBox_Fecha_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fecha";
            // 
            // textBox_DetCod
            // 
            this.textBox_DetCod.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DetCod.Location = new System.Drawing.Point(235, 30);
            this.textBox_DetCod.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DetCod.Name = "textBox_DetCod";
            this.textBox_DetCod.Size = new System.Drawing.Size(83, 29);
            this.textBox_DetCod.TabIndex = 18;
            this.textBox_DetCod.Leave += new System.EventHandler(this.textBox_DetCod_Leave);
            this.textBox_DetCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DetCod_KeyPress);
            this.textBox_DetCod.Enter += new System.EventHandler(this.textBox_DetCod_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "CLIENTE";
            // 
            // textBox_Importe
            // 
            this.textBox_Importe.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Importe.Location = new System.Drawing.Point(127, 131);
            this.textBox_Importe.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Importe.Name = "textBox_Importe";
            this.textBox_Importe.Size = new System.Drawing.Size(120, 29);
            this.textBox_Importe.TabIndex = 20;
            this.textBox_Importe.Leave += new System.EventHandler(this.textBox_Importe_Leave);
            this.textBox_Importe.Enter += new System.EventHandler(this.textBox_Importe_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 24;
            this.label2.Text = "Importe";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancelar.Location = new System.Drawing.Point(47, 338);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(107, 38);
            this.button_Cancelar.TabIndex = 23;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Aceptar.Location = new System.Drawing.Point(588, 338);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(107, 38);
            this.button_Aceptar.TabIndex = 22;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FormAbonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(738, 406);
            this.Controls.Add(this.label_Cliente);
            this.Controls.Add(this.textBox_Observaciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Fecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_DetCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Importe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Name = "FormAbonos";
            this.Text = "    CREAR ABONO";
            this.Load += new System.EventHandler(this.FormAbonos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Cliente;
        private System.Windows.Forms.TextBox textBox_Observaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DetCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}