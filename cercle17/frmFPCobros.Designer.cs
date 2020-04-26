namespace cercle17
{
    partial class frmFPCobros
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPCobros));
            this.gPagares = new System.Windows.Forms.DataGridView();
            this.textBox_Transferencia = new System.Windows.Forms.TextBox();
            this.textBox_Observaciones = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_Pagare = new System.Windows.Forms.TextBox();
            this.textBox_Tarjeta = new System.Windows.Forms.TextBox();
            this.textBox_Talon = new System.Windows.Forms.TextBox();
            this.textBox_Efectivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ImpteFactura = new System.Windows.Forms.TextBox();
            this.textBox_ImptePendiente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Obs_Talon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Nuevo_Pagare = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_Obs_Transferencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Obs_Tarjeta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).BeginInit();
            this.SuspendLayout();
            // 
            // gPagares
            // 
            this.gPagares.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gPagares.DefaultCellStyle = dataGridViewCellStyle1;
            this.gPagares.Location = new System.Drawing.Point(219, 237);
            this.gPagares.MultiSelect = false;
            this.gPagares.Name = "gPagares";
            this.gPagares.RowHeadersVisible = false;
            this.gPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gPagares.Size = new System.Drawing.Size(521, 73);
            this.gPagares.TabIndex = 76;
            // 
            // textBox_Transferencia
            // 
            this.textBox_Transferencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Transferencia.Location = new System.Drawing.Point(123, 118);
            this.textBox_Transferencia.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Transferencia.Name = "textBox_Transferencia";
            this.textBox_Transferencia.Size = new System.Drawing.Size(81, 26);
            this.textBox_Transferencia.TabIndex = 43;
            // 
            // textBox_Observaciones
            // 
            this.textBox_Observaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Observaciones.Location = new System.Drawing.Point(219, 326);
            this.textBox_Observaciones.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Observaciones.Name = "textBox_Observaciones";
            this.textBox_Observaciones.Size = new System.Drawing.Size(521, 26);
            this.textBox_Observaciones.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(43, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 18);
            this.label13.TabIndex = 75;
            this.label13.Text = "Observaciones cobro";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 18);
            this.label14.TabIndex = 74;
            this.label14.Text = "Transferencia";
            // 
            // textBox_Pagare
            // 
            this.textBox_Pagare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pagare.Location = new System.Drawing.Point(123, 237);
            this.textBox_Pagare.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Pagare.Name = "textBox_Pagare";
            this.textBox_Pagare.ReadOnly = true;
            this.textBox_Pagare.Size = new System.Drawing.Size(81, 26);
            this.textBox_Pagare.TabIndex = 48;
            // 
            // textBox_Tarjeta
            // 
            this.textBox_Tarjeta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Tarjeta.Location = new System.Drawing.Point(123, 198);
            this.textBox_Tarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tarjeta.Name = "textBox_Tarjeta";
            this.textBox_Tarjeta.Size = new System.Drawing.Size(81, 26);
            this.textBox_Tarjeta.TabIndex = 46;
            // 
            // textBox_Talon
            // 
            this.textBox_Talon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Talon.Location = new System.Drawing.Point(123, 156);
            this.textBox_Talon.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Talon.Name = "textBox_Talon";
            this.textBox_Talon.Size = new System.Drawing.Size(81, 26);
            this.textBox_Talon.TabIndex = 45;
            // 
            // textBox_Efectivo
            // 
            this.textBox_Efectivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Efectivo.Location = new System.Drawing.Point(123, 76);
            this.textBox_Efectivo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Efectivo.Name = "textBox_Efectivo";
            this.textBox_Efectivo.Size = new System.Drawing.Size(81, 26);
            this.textBox_Efectivo.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 51;
            this.label5.Text = "Pagaré";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "Tarjeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "Talón";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "Efectivo";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancelar.Location = new System.Drawing.Point(38, 371);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(107, 51);
            this.button_Cancelar.TabIndex = 52;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Aceptar.Location = new System.Drawing.Point(745, 371);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(144, 51);
            this.button_Aceptar.TabIndex = 50;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "IMPORTE FACTURA";
            // 
            // textBox_ImpteFactura
            // 
            this.textBox_ImpteFactura.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ImpteFactura.Location = new System.Drawing.Point(260, 10);
            this.textBox_ImpteFactura.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ImpteFactura.Name = "textBox_ImpteFactura";
            this.textBox_ImpteFactura.ReadOnly = true;
            this.textBox_ImpteFactura.Size = new System.Drawing.Size(81, 26);
            this.textBox_ImpteFactura.TabIndex = 77;
            // 
            // textBox_ImptePendiente
            // 
            this.textBox_ImptePendiente.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ImptePendiente.Location = new System.Drawing.Point(579, 10);
            this.textBox_ImptePendiente.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ImptePendiente.Name = "textBox_ImptePendiente";
            this.textBox_ImptePendiente.ReadOnly = true;
            this.textBox_ImptePendiente.Size = new System.Drawing.Size(81, 26);
            this.textBox_ImptePendiente.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(378, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 19);
            this.label6.TabIndex = 78;
            this.label6.Text = "IMPORTE PENDIENTE";
            // 
            // textBox_Obs_Talon
            // 
            this.textBox_Obs_Talon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Talon.Location = new System.Drawing.Point(500, 157);
            this.textBox_Obs_Talon.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Talon.Name = "textBox_Obs_Talon";
            this.textBox_Obs_Talon.Size = new System.Drawing.Size(389, 26);
            this.textBox_Obs_Talon.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 81;
            this.label7.Text = "Observaciones";
            // 
            // button_Nuevo_Pagare
            // 
            this.button_Nuevo_Pagare.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Nuevo_Pagare.Location = new System.Drawing.Point(745, 237);
            this.button_Nuevo_Pagare.Margin = new System.Windows.Forms.Padding(2);
            this.button_Nuevo_Pagare.Name = "button_Nuevo_Pagare";
            this.button_Nuevo_Pagare.Size = new System.Drawing.Size(144, 38);
            this.button_Nuevo_Pagare.TabIndex = 82;
            this.button_Nuevo_Pagare.Text = "NUEVO PAGARÉ";
            this.button_Nuevo_Pagare.UseVisualStyleBackColor = true;
            this.button_Nuevo_Pagare.Click += new System.EventHandler(this.button_Nuevo_Pagare_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(239, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 26);
            this.dateTimePicker1.TabIndex = 83;
            // 
            // textBox_Obs_Transferencia
            // 
            this.textBox_Obs_Transferencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Transferencia.Location = new System.Drawing.Point(351, 118);
            this.textBox_Obs_Transferencia.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Transferencia.Name = "textBox_Obs_Transferencia";
            this.textBox_Obs_Transferencia.Size = new System.Drawing.Size(389, 26);
            this.textBox_Obs_Transferencia.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(230, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 85;
            this.label8.Text = "Observaciones";
            // 
            // textBox_Obs_Tarjeta
            // 
            this.textBox_Obs_Tarjeta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Tarjeta.Location = new System.Drawing.Point(351, 202);
            this.textBox_Obs_Tarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Tarjeta.Name = "textBox_Obs_Tarjeta";
            this.textBox_Obs_Tarjeta.Size = new System.Drawing.Size(389, 26);
            this.textBox_Obs_Tarjeta.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 87;
            this.label9.Text = "Observaciones";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFPCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(903, 433);
            this.Controls.Add(this.textBox_Obs_Tarjeta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_Obs_Transferencia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button_Nuevo_Pagare);
            this.Controls.Add(this.textBox_Obs_Talon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_ImptePendiente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_ImpteFactura);
            this.Controls.Add(this.gPagares);
            this.Controls.Add(this.textBox_Transferencia);
            this.Controls.Add(this.textBox_Observaciones);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_Pagare);
            this.Controls.Add(this.textBox_Tarjeta);
            this.Controls.Add(this.textBox_Talon);
            this.Controls.Add(this.textBox_Efectivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPCobros";
            this.Text = "    Cobrar factura";
            this.Load += new System.EventHandler(this.frmFPCobros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gPagares;
        private System.Windows.Forms.TextBox textBox_Transferencia;
        private System.Windows.Forms.TextBox textBox_Observaciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_Pagare;
        private System.Windows.Forms.TextBox textBox_Tarjeta;
        private System.Windows.Forms.TextBox textBox_Talon;
        private System.Windows.Forms.TextBox textBox_Efectivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ImpteFactura;
        private System.Windows.Forms.TextBox textBox_ImptePendiente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Obs_Talon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Nuevo_Pagare;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox_Obs_Transferencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Obs_Tarjeta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
    }
}