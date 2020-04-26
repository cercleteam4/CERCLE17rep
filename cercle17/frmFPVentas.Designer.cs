namespace cercle17
{
    partial class frmFPVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPVentas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Reqs = new System.Windows.Forms.Label();
            this.label_IVAs = new System.Windows.Forms.Label();
            this.label_BIs = new System.Windows.Forms.Label();
            this.label_Pendiente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_importes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView_Facturado = new System.Windows.Forms.DataGridView();
            this.panel_Filtros = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ckbMarcarTodo = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Todas = new System.Windows.Forms.RadioButton();
            this.radioButton_SinCobrar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Fecha = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox_Serie = new System.Windows.Forms.TextBox();
            this.textBox_Factura = new System.Windows.Forms.TextBox();
            this.textBox_Anyo = new System.Windows.Forms.TextBox();
            this.textBox_DetCod = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Cobro = new System.Windows.Forms.Button();
            this.button_Listado = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).BeginInit();
            this.panel_Filtros.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_Cobro);
            this.panel1.Controls.Add(this.button_Listado);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 66);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.label_Reqs);
            this.panel2.Controls.Add(this.label_IVAs);
            this.panel2.Controls.Add(this.label_BIs);
            this.panel2.Controls.Add(this.label_Pendiente);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label_importes);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 511);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 50);
            this.panel2.TabIndex = 1;
            // 
            // label_Reqs
            // 
            this.label_Reqs.AutoSize = true;
            this.label_Reqs.Location = new System.Drawing.Point(422, 9);
            this.label_Reqs.Name = "label_Reqs";
            this.label_Reqs.Size = new System.Drawing.Size(13, 14);
            this.label_Reqs.TabIndex = 6;
            this.label_Reqs.Text = "0";
            // 
            // label_IVAs
            // 
            this.label_IVAs.AutoSize = true;
            this.label_IVAs.Location = new System.Drawing.Point(351, 9);
            this.label_IVAs.Name = "label_IVAs";
            this.label_IVAs.Size = new System.Drawing.Size(13, 14);
            this.label_IVAs.TabIndex = 5;
            this.label_IVAs.Text = "0";
            // 
            // label_BIs
            // 
            this.label_BIs.AutoSize = true;
            this.label_BIs.Location = new System.Drawing.Point(260, 9);
            this.label_BIs.Name = "label_BIs";
            this.label_BIs.Size = new System.Drawing.Size(13, 14);
            this.label_BIs.TabIndex = 4;
            this.label_BIs.Text = "0";
            // 
            // label_Pendiente
            // 
            this.label_Pendiente.AutoSize = true;
            this.label_Pendiente.Location = new System.Drawing.Point(711, 30);
            this.label_Pendiente.Name = "label_Pendiente";
            this.label_Pendiente.Size = new System.Drawing.Size(13, 14);
            this.label_Pendiente.TabIndex = 3;
            this.label_Pendiente.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Pendiente :";
            // 
            // label_importes
            // 
            this.label_importes.AutoSize = true;
            this.label_importes.Location = new System.Drawing.Point(711, 9);
            this.label_importes.Name = "label_importes";
            this.label_importes.Size = new System.Drawing.Size(13, 14);
            this.label_importes.TabIndex = 1;
            this.label_importes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Importes :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel_Filtros);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(854, 445);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView_Facturado);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(14, 62);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(817, 383);
            this.panel6.TabIndex = 3;
            // 
            // dataGridView_Facturado
            // 
            this.dataGridView_Facturado.AllowUserToAddRows = false;
            this.dataGridView_Facturado.AllowUserToDeleteRows = false;
            this.dataGridView_Facturado.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView_Facturado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Facturado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Facturado.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Facturado.MultiSelect = false;
            this.dataGridView_Facturado.Name = "dataGridView_Facturado";
            this.dataGridView_Facturado.ReadOnly = true;
            this.dataGridView_Facturado.RowHeadersVisible = false;
            this.dataGridView_Facturado.Size = new System.Drawing.Size(817, 383);
            this.dataGridView_Facturado.TabIndex = 1;
            this.dataGridView_Facturado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Facturado_CellClick);
            this.dataGridView_Facturado.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Facturado_CellMouseClick);
            // 
            // panel_Filtros
            // 
            this.panel_Filtros.Controls.Add(this.panel9);
            this.panel_Filtros.Controls.Add(this.panel8);
            this.panel_Filtros.Controls.Add(this.panel7);
            this.panel_Filtros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Filtros.Location = new System.Drawing.Point(14, 0);
            this.panel_Filtros.Name = "panel_Filtros";
            this.panel_Filtros.Size = new System.Drawing.Size(817, 62);
            this.panel_Filtros.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel9.Controls.Add(this.ckbMarcarTodo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(279, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(179, 62);
            this.panel9.TabIndex = 2;
            // 
            // ckbMarcarTodo
            // 
            this.ckbMarcarTodo.AutoSize = true;
            this.ckbMarcarTodo.Location = new System.Drawing.Point(7, 31);
            this.ckbMarcarTodo.Name = "ckbMarcarTodo";
            this.ckbMarcarTodo.Size = new System.Drawing.Size(86, 18);
            this.ckbMarcarTodo.TabIndex = 0;
            this.ckbMarcarTodo.Text = "Marcar Todo";
            this.ckbMarcarTodo.UseVisualStyleBackColor = true;
            this.ckbMarcarTodo.CheckedChanged += new System.EventHandler(this.ckbMarcarTodo_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel8.Controls.Add(this.groupBox1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.checkBox_Fecha);
            this.panel8.Controls.Add(this.dateTimePicker_Fin);
            this.panel8.Controls.Add(this.dateTimePicker_Inicio);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(458, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(359, 62);
            this.panel8.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox1.Controls.Add(this.radioButton_Todas);
            this.groupBox1.Controls.Add(this.radioButton_SinCobrar);
            this.groupBox1.Location = new System.Drawing.Point(186, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 57);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // radioButton_Todas
            // 
            this.radioButton_Todas.AutoSize = true;
            this.radioButton_Todas.Location = new System.Drawing.Point(19, 33);
            this.radioButton_Todas.Name = "radioButton_Todas";
            this.radioButton_Todas.Size = new System.Drawing.Size(54, 18);
            this.radioButton_Todas.TabIndex = 6;
            this.radioButton_Todas.TabStop = true;
            this.radioButton_Todas.Text = "Todas";
            this.radioButton_Todas.UseVisualStyleBackColor = true;
            this.radioButton_Todas.CheckedChanged += new System.EventHandler(this.radioButton_Todas_CheckedChanged);
            // 
            // radioButton_SinCobrar
            // 
            this.radioButton_SinCobrar.AutoSize = true;
            this.radioButton_SinCobrar.Location = new System.Drawing.Point(19, 6);
            this.radioButton_SinCobrar.Name = "radioButton_SinCobrar";
            this.radioButton_SinCobrar.Size = new System.Drawing.Size(76, 18);
            this.radioButton_SinCobrar.TabIndex = 5;
            this.radioButton_SinCobrar.TabStop = true;
            this.radioButton_SinCobrar.Text = "Sin Cobrar";
            this.radioButton_SinCobrar.UseVisualStyleBackColor = true;
            this.radioButton_SinCobrar.CheckedChanged += new System.EventHandler(this.radioButton_SinCobrar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "hasta";
            // 
            // checkBox_Fecha
            // 
            this.checkBox_Fecha.AutoSize = true;
            this.checkBox_Fecha.Location = new System.Drawing.Point(30, 8);
            this.checkBox_Fecha.Name = "checkBox_Fecha";
            this.checkBox_Fecha.Size = new System.Drawing.Size(57, 18);
            this.checkBox_Fecha.TabIndex = 3;
            this.checkBox_Fecha.Text = "Desde";
            this.checkBox_Fecha.UseVisualStyleBackColor = true;
            this.checkBox_Fecha.CheckedChanged += new System.EventHandler(this.checkBox_Fecha_CheckedChanged);
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(93, 32);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 1;
            this.dateTimePicker_Fin.ValueChanged += new System.EventHandler(this.dateTimePicker_Fin_ValueChanged);
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(93, 6);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel7.Controls.Add(this.textBox_Serie);
            this.panel7.Controls.Add(this.textBox_Factura);
            this.panel7.Controls.Add(this.textBox_Anyo);
            this.panel7.Controls.Add(this.textBox_DetCod);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(279, 62);
            this.panel7.TabIndex = 0;
            // 
            // textBox_Serie
            // 
            this.textBox_Serie.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Serie.Location = new System.Drawing.Point(132, 32);
            this.textBox_Serie.Name = "textBox_Serie";
            this.textBox_Serie.Size = new System.Drawing.Size(49, 20);
            this.textBox_Serie.TabIndex = 3;
            this.textBox_Serie.Text = "SERIE";
            this.textBox_Serie.Enter += new System.EventHandler(this.textBox_Serie_Enter);
            this.textBox_Serie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Serie_KeyPress);
            this.textBox_Serie.Leave += new System.EventHandler(this.textBox_Serie_Leave);
            // 
            // textBox_Factura
            // 
            this.textBox_Factura.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Factura.Location = new System.Drawing.Point(6, 32);
            this.textBox_Factura.Name = "textBox_Factura";
            this.textBox_Factura.Size = new System.Drawing.Size(65, 20);
            this.textBox_Factura.TabIndex = 0;
            this.textBox_Factura.Text = "FACTURA";
            this.textBox_Factura.Enter += new System.EventHandler(this.textBox_Factura_Enter);
            this.textBox_Factura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Factura_KeyPress);
            this.textBox_Factura.Leave += new System.EventHandler(this.textBox_Factura_Leave);
            // 
            // textBox_Anyo
            // 
            this.textBox_Anyo.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Anyo.Location = new System.Drawing.Point(77, 32);
            this.textBox_Anyo.Name = "textBox_Anyo";
            this.textBox_Anyo.Size = new System.Drawing.Size(49, 20);
            this.textBox_Anyo.TabIndex = 1;
            this.textBox_Anyo.Text = "AÑO";
            this.textBox_Anyo.Enter += new System.EventHandler(this.textBox_Anyo_Enter);
            this.textBox_Anyo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Anyo_KeyPress);
            this.textBox_Anyo.Leave += new System.EventHandler(this.textBox_Anyo_Leave);
            // 
            // textBox_DetCod
            // 
            this.textBox_DetCod.ForeColor = System.Drawing.Color.Silver;
            this.textBox_DetCod.Location = new System.Drawing.Point(187, 32);
            this.textBox_DetCod.Name = "textBox_DetCod";
            this.textBox_DetCod.Size = new System.Drawing.Size(49, 20);
            this.textBox_DetCod.TabIndex = 2;
            this.textBox_DetCod.Text = "DETCOD";
            this.textBox_DetCod.Enter += new System.EventHandler(this.textBox_DetCod_Enter);
            this.textBox_DetCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DetCod_KeyPress);
            this.textBox_DetCod.Leave += new System.EventHandler(this.textBox_DetCod_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(831, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(23, 445);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 445);
            this.panel4.TabIndex = 0;
            // 
            // button_Cobro
            // 
            this.button_Cobro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cobro.Image = global::cercle17.Properties.Resources.Cobrar3;
            this.button_Cobro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cobro.Location = new System.Drawing.Point(277, 2);
            this.button_Cobro.Name = "button_Cobro";
            this.button_Cobro.Size = new System.Drawing.Size(109, 61);
            this.button_Cobro.TabIndex = 2;
            this.button_Cobro.Text = "COBRAR";
            this.button_Cobro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cobro.UseVisualStyleBackColor = true;
            this.button_Cobro.Click += new System.EventHandler(this.button_Cobro_Click);
            // 
            // button_Listado
            // 
            this.button_Listado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Listado.Image = global::cercle17.Properties.Resources.printer21;
            this.button_Listado.Location = new System.Drawing.Point(155, 3);
            this.button_Listado.Name = "button_Listado";
            this.button_Listado.Size = new System.Drawing.Size(109, 61);
            this.button_Listado.TabIndex = 1;
            this.button_Listado.Text = "LISTAR";
            this.button_Listado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Listado.UseVisualStyleBackColor = true;
            this.button_Listado.Click += new System.EventHandler(this.button_Listado_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(126, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // frmFPVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(854, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPVentas";
            this.Text = "    Facturas Ventas";
            this.Load += new System.EventHandler(this.frmFPVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).EndInit();
            this.panel_Filtros.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel_Filtros;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView_Facturado;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button_Listado;
        private System.Windows.Forms.TextBox textBox_Factura;
        private System.Windows.Forms.TextBox textBox_Anyo;
        private System.Windows.Forms.TextBox textBox_DetCod;
        private System.Windows.Forms.TextBox textBox_Serie;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_Fecha;
        private System.Windows.Forms.Label label_importes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Pendiente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Todas;
        private System.Windows.Forms.RadioButton radioButton_SinCobrar;
        private System.Windows.Forms.Button button_Cobro;
        private System.Windows.Forms.Label label_Reqs;
        private System.Windows.Forms.Label label_IVAs;
        private System.Windows.Forms.Label label_BIs;
        private System.Windows.Forms.CheckBox ckbMarcarTodo;
    }
}