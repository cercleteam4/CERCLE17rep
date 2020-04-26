namespace cercle17
{
    partial class frmEXPORT_CPLUS_FraORE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEXPORT_CPLUS_FraORE));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Exportar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.lFF = new System.Windows.Forms.Label();
            this.lFI = new System.Windows.Forms.Label();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDiarios = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView_Facturado = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTodos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_Exportar);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 66);
            this.panel1.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(704, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 42);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(604, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 47);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(440, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 52);
            this.button4.TabIndex = 4;
            this.button4.Text = "Generar Fichero de COBROS de Facturas seleccionadas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 54);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generar Fichero de COBROS de Facturas Propias";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "Abrir Archivo recibido de OREMAPE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Exportar
            // 
            this.button_Exportar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exportar.Location = new System.Drawing.Point(129, 2);
            this.button_Exportar.Name = "button_Exportar";
            this.button_Exportar.Size = new System.Drawing.Size(164, 61);
            this.button_Exportar.TabIndex = 1;
            this.button_Exportar.Text = "EXPORTAR";
            this.button_Exportar.UseVisualStyleBackColor = true;
            this.button_Exportar.Visible = false;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(109, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.lFF);
            this.panel2.Controls.Add(this.lFI);
            this.panel2.Controls.Add(this.dateTimePicker_Fin);
            this.panel2.Controls.Add(this.dateTimePicker_Inicio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 67);
            this.panel2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(227, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "Cargar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lFF
            // 
            this.lFF.AutoSize = true;
            this.lFF.Location = new System.Drawing.Point(12, 50);
            this.lFF.Name = "lFF";
            this.lFF.Size = new System.Drawing.Size(62, 13);
            this.lFF.TabIndex = 5;
            this.lFF.Text = "Fecha Final";
            // 
            // lFI
            // 
            this.lFI.AutoSize = true;
            this.lFI.Location = new System.Drawing.Point(11, 21);
            this.lFI.Name = "lFI";
            this.lFI.Size = new System.Drawing.Size(67, 13);
            this.lFI.TabIndex = 4;
            this.lFI.Text = "Fecha Inicial";
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(97, 44);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 3;
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(97, 18);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel3.Controls.Add(this.btnTodos);
            this.panel3.Controls.Add(this.dgvDiarios);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(839, 370);
            this.panel3.TabIndex = 4;
            // 
            // dgvDiarios
            // 
            this.dgvDiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiarios.Location = new System.Drawing.Point(12, 55);
            this.dgvDiarios.Name = "dgvDiarios";
            this.dgvDiarios.Size = new System.Drawing.Size(815, 74);
            this.dgvDiarios.TabIndex = 1;
            this.dgvDiarios.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(361, 33);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Controls.Add(this.dataGridView_Facturado);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 268);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(839, 235);
            this.panel4.TabIndex = 5;
            // 
            // dataGridView_Facturado
            // 
            this.dataGridView_Facturado.AllowUserToAddRows = false;
            this.dataGridView_Facturado.AllowUserToDeleteRows = false;
            this.dataGridView_Facturado.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGridView_Facturado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Facturado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Facturado.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Facturado.MultiSelect = false;
            this.dataGridView_Facturado.Name = "dataGridView_Facturado";
            this.dataGridView_Facturado.ReadOnly = true;
            this.dataGridView_Facturado.RowHeadersVisible = false;
            this.dataGridView_Facturado.Size = new System.Drawing.Size(839, 235);
            this.dataGridView_Facturado.TabIndex = 2;
            this.dataGridView_Facturado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Facturado_CellClick);
            this.dataGridView_Facturado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Facturado_CellContentClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(738, 105);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(89, 24);
            this.btnTodos.TabIndex = 7;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Visible = false;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // frmEXPORT_CPLUS_FraORE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 503);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEXPORT_CPLUS_FraORE";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmEXPORT_CPLUS_FraORE_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiarios)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exportar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lFF;
        private System.Windows.Forms.Label lFI;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.DataGridView dataGridView_Facturado;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgvDiarios;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnTodos;
    }
}