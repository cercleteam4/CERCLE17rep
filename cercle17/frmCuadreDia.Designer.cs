namespace cercle17
{
    partial class frmCuadreDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuadreDia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Fecha = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Imprimir = new System.Windows.Forms.Button();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Transferencia = new System.Windows.Forms.TextBox();
            this.textBox_Tarjeta = new System.Windows.Forms.TextBox();
            this.textBox_Pagares = new System.Windows.Forms.TextBox();
            this.textBox_Talones = new System.Windows.Forms.TextBox();
            this.textBox_Efectivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Fecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 46);
            this.panel1.TabIndex = 0;
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Location = new System.Drawing.Point(21, 6);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(109, 34);
            this.button_Salir.TabIndex = 4;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "FECHA :";
            // 
            // textBox_Fecha
            // 
            this.textBox_Fecha.Location = new System.Drawing.Point(256, 13);
            this.textBox_Fecha.Name = "textBox_Fecha";
            this.textBox_Fecha.Size = new System.Drawing.Size(100, 20);
            this.textBox_Fecha.TabIndex = 0;
            this.textBox_Fecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Fecha_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.button_Imprimir);
            this.panel2.Controls.Add(this.textBox_Total);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox_Transferencia);
            this.panel2.Controls.Add(this.textBox_Tarjeta);
            this.panel2.Controls.Add(this.textBox_Pagares);
            this.panel2.Controls.Add(this.textBox_Talones);
            this.panel2.Controls.Add(this.textBox_Efectivo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 338);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 171);
            this.panel2.TabIndex = 1;
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Imprimir.Location = new System.Drawing.Point(648, 58);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(152, 34);
            this.button_Imprimir.TabIndex = 14;
            this.button_Imprimir.Text = "IMPRIMIR";
            this.button_Imprimir.UseVisualStyleBackColor = true;
            this.button_Imprimir.Click += new System.EventHandler(this.button_Imprimir_Click);
            // 
            // textBox_Total
            // 
            this.textBox_Total.Location = new System.Drawing.Point(701, 14);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.ReadOnly = true;
            this.textBox_Total.Size = new System.Drawing.Size(100, 20);
            this.textBox_Total.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(645, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "TOTAL :";
            // 
            // textBox_Transferencia
            // 
            this.textBox_Transferencia.Location = new System.Drawing.Point(140, 128);
            this.textBox_Transferencia.Name = "textBox_Transferencia";
            this.textBox_Transferencia.ReadOnly = true;
            this.textBox_Transferencia.Size = new System.Drawing.Size(100, 20);
            this.textBox_Transferencia.TabIndex = 11;
            // 
            // textBox_Tarjeta
            // 
            this.textBox_Tarjeta.Location = new System.Drawing.Point(140, 100);
            this.textBox_Tarjeta.Name = "textBox_Tarjeta";
            this.textBox_Tarjeta.ReadOnly = true;
            this.textBox_Tarjeta.Size = new System.Drawing.Size(100, 20);
            this.textBox_Tarjeta.TabIndex = 10;
            // 
            // textBox_Pagares
            // 
            this.textBox_Pagares.Location = new System.Drawing.Point(140, 72);
            this.textBox_Pagares.Name = "textBox_Pagares";
            this.textBox_Pagares.ReadOnly = true;
            this.textBox_Pagares.Size = new System.Drawing.Size(100, 20);
            this.textBox_Pagares.TabIndex = 9;
            // 
            // textBox_Talones
            // 
            this.textBox_Talones.Location = new System.Drawing.Point(140, 45);
            this.textBox_Talones.Name = "textBox_Talones";
            this.textBox_Talones.ReadOnly = true;
            this.textBox_Talones.Size = new System.Drawing.Size(100, 20);
            this.textBox_Talones.TabIndex = 8;
            // 
            // textBox_Efectivo
            // 
            this.textBox_Efectivo.Location = new System.Drawing.Point(140, 17);
            this.textBox_Efectivo.Name = "textBox_Efectivo";
            this.textBox_Efectivo.ReadOnly = true;
            this.textBox_Efectivo.Size = new System.Drawing.Size(100, 20);
            this.textBox_Efectivo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "TRANSFERENCIA :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "TARJETA :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "PAGARÉS :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "TALONES :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "EFECTIVO :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 292);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(21, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(779, 292);
            this.panel6.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(779, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(800, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(21, 292);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(21, 292);
            this.panel4.TabIndex = 0;
            // 
            // frmCuadreDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 509);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCuadreDia";
            this.Text = "    Cuadre Día";
            this.Load += new System.EventHandler(this.frmCuadreDia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Fecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_Transferencia;
        private System.Windows.Forms.TextBox textBox_Tarjeta;
        private System.Windows.Forms.TextBox textBox_Pagares;
        private System.Windows.Forms.TextBox textBox_Talones;
        private System.Windows.Forms.TextBox textBox_Efectivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Total;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button_Imprimir;
    }
}