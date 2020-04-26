namespace cercle17
{
    partial class frmNuevoPagare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoPagare));
            this.textBox_Vencimiento = new System.Windows.Forms.TextBox();
            this.textBox_Pagare = new System.Windows.Forms.TextBox();
            this.textBox_Obs_Pagare = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.textBox_DetNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_CodCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Vencimiento
            // 
            this.textBox_Vencimiento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Vencimiento.Location = new System.Drawing.Point(286, 144);
            this.textBox_Vencimiento.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Vencimiento.Name = "textBox_Vencimiento";
            this.textBox_Vencimiento.ReadOnly = true;
            this.textBox_Vencimiento.Size = new System.Drawing.Size(86, 26);
            this.textBox_Vencimiento.TabIndex = 4;
            this.textBox_Vencimiento.TextChanged += new System.EventHandler(this.textBox_Vencimiento_TextChanged);
            this.textBox_Vencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Vencimiento_KeyPress);
            // 
            // textBox_Pagare
            // 
            this.textBox_Pagare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pagare.Location = new System.Drawing.Point(92, 97);
            this.textBox_Pagare.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Pagare.Name = "textBox_Pagare";
            this.textBox_Pagare.Size = new System.Drawing.Size(81, 26);
            this.textBox_Pagare.TabIndex = 2;
            this.textBox_Pagare.TextChanged += new System.EventHandler(this.textBox_Pagare_TextChanged);
            this.textBox_Pagare.Enter += new System.EventHandler(this.textBox_Pagare_Enter);
            this.textBox_Pagare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Pagare_KeyPress);
            this.textBox_Pagare.Leave += new System.EventHandler(this.textBox_Pagare_Leave);
            // 
            // textBox_Obs_Pagare
            // 
            this.textBox_Obs_Pagare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Pagare.Location = new System.Drawing.Point(316, 97);
            this.textBox_Obs_Pagare.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Pagare.Name = "textBox_Obs_Pagare";
            this.textBox_Obs_Pagare.Size = new System.Drawing.Size(399, 26);
            this.textBox_Obs_Pagare.TabIndex = 3;
            this.textBox_Obs_Pagare.Enter += new System.EventHandler(this.textBox_Obs_Pagare_Enter);
            this.textBox_Obs_Pagare.Leave += new System.EventHandler(this.textBox_Obs_Pagare_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(184, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 34;
            this.label10.Text = "Observaciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(178, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 33;
            this.label6.Text = "Vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Importe";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancelar.Location = new System.Drawing.Point(32, 220);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(107, 38);
            this.button_Cancelar.TabIndex = 6;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Aceptar.Location = new System.Drawing.Point(573, 220);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(107, 38);
            this.button_Aceptar.TabIndex = 5;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // textBox_DetNom
            // 
            this.textBox_DetNom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DetNom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DetNom.Location = new System.Drawing.Point(343, 21);
            this.textBox_DetNom.Name = "textBox_DetNom";
            this.textBox_DetNom.ReadOnly = true;
            this.textBox_DetNom.Size = new System.Drawing.Size(248, 19);
            this.textBox_DetNom.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 48;
            this.label2.Text = "Nombre";
            // 
            // textBox_CodCliente
            // 
            this.textBox_CodCliente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CodCliente.Location = new System.Drawing.Point(192, 18);
            this.textBox_CodCliente.Name = "textBox_CodCliente";
            this.textBox_CodCliente.Size = new System.Drawing.Size(53, 26);
            this.textBox_CodCliente.TabIndex = 1;
            this.textBox_CodCliente.Enter += new System.EventHandler(this.textBox_CodCliente_Enter);
            this.textBox_CodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CodCliente_KeyPress);
            this.textBox_CodCliente.Leave += new System.EventHandler(this.textBox_CodCliente_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 46;
            this.label1.Text = " CLIENTE";
            // 
            // frmNuevoPagare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(730, 286);
            this.Controls.Add(this.textBox_DetNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_CodCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.textBox_Vencimiento);
            this.Controls.Add(this.textBox_Pagare);
            this.Controls.Add(this.textBox_Obs_Pagare);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNuevoPagare";
            this.Text = "    Nuevo Pagaré";
            this.Load += new System.EventHandler(this.frmNuevoPagare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Vencimiento;
        private System.Windows.Forms.TextBox textBox_Pagare;
        private System.Windows.Forms.TextBox textBox_Obs_Pagare;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.TextBox textBox_DetNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_CodCliente;
        private System.Windows.Forms.Label label1;
    }
}