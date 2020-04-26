namespace cercle17
{
    partial class frmFCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFCompras));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Pago = new System.Windows.Forms.Button();
            this.button_Listado = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_IVAs = new System.Windows.Forms.Label();
            this.label_BIs = new System.Windows.Forms.Label();
            this.label_Pendiente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_importes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView_Facturado = new System.Windows.Forms.DataGridView();
            this.ProNumFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProFechaFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpteFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImptePendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ImptePagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BI1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Filtros = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ckbMarcarTodo = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Todas = new System.Windows.Forms.RadioButton();
            this.radioButton_SinPagar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Fecha = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox_ProNom = new System.Windows.Forms.TextBox();
            this.textBox_Serie = new System.Windows.Forms.TextBox();
            this.textBox_Factura = new System.Windows.Forms.TextBox();
            this.textBox_Anyo = new System.Windows.Forms.TextBox();
            this.textBox_ProCod = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.button_Pago);
            this.panel1.Controls.Add(this.button_Listado);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 66);
            this.panel1.TabIndex = 0;
            // 
            // button_Pago
            // 
            this.button_Pago.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pago.Image = global::cercle17.Properties.Resources.Cobrar3;
            this.button_Pago.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Pago.Location = new System.Drawing.Point(277, 2);
            this.button_Pago.Name = "button_Pago";
            this.button_Pago.Size = new System.Drawing.Size(109, 61);
            this.button_Pago.TabIndex = 2;
            this.button_Pago.Text = "PAGAR";
            this.button_Pago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Pago.UseVisualStyleBackColor = true;
            this.button_Pago.Click += new System.EventHandler(this.button_Pago_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
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
            // label_IVAs
            // 
            this.label_IVAs.AutoSize = true;
            this.label_IVAs.Location = new System.Drawing.Point(351, 9);
            this.label_IVAs.Name = "label_IVAs";
            this.label_IVAs.Size = new System.Drawing.Size(16, 16);
            this.label_IVAs.TabIndex = 5;
            this.label_IVAs.Text = "0";
            // 
            // label_BIs
            // 
            this.label_BIs.AutoSize = true;
            this.label_BIs.Location = new System.Drawing.Point(260, 9);
            this.label_BIs.Name = "label_BIs";
            this.label_BIs.Size = new System.Drawing.Size(16, 16);
            this.label_BIs.TabIndex = 4;
            this.label_BIs.Text = "0";
            // 
            // label_Pendiente
            // 
            this.label_Pendiente.AutoSize = true;
            this.label_Pendiente.Location = new System.Drawing.Point(711, 30);
            this.label_Pendiente.Name = "label_Pendiente";
            this.label_Pendiente.Size = new System.Drawing.Size(16, 16);
            this.label_Pendiente.TabIndex = 3;
            this.label_Pendiente.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Pendiente :";
            // 
            // label_importes
            // 
            this.label_importes.AutoSize = true;
            this.label_importes.Location = new System.Drawing.Point(711, 9);
            this.label_importes.Name = "label_importes";
            this.label_importes.Size = new System.Drawing.Size(16, 16);
            this.label_importes.TabIndex = 1;
            this.label_importes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
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
            this.dataGridView_Facturado.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridView_Facturado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Facturado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProNumFact,
            this.ProCod,
            this.ProNom,
            this.ProFechaFact,
            this.ImpteFactura,
            this.ImptePendiente,
            this.Selec,
            this.ImptePagado,
            this.BI1,
            this.IVA1,
            this.Factura,
            this.Anyo,
            this.Serie,
            this.FechaEmision});
            this.dataGridView_Facturado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Facturado.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Facturado.MultiSelect = false;
            this.dataGridView_Facturado.Name = "dataGridView_Facturado";
            this.dataGridView_Facturado.ReadOnly = true;
            this.dataGridView_Facturado.RowHeadersVisible = false;
            this.dataGridView_Facturado.RowHeadersWidth = 51;
            this.dataGridView_Facturado.Size = new System.Drawing.Size(817, 383);
            this.dataGridView_Facturado.TabIndex = 1;
            this.dataGridView_Facturado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Facturado_CellClick);
            this.dataGridView_Facturado.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Facturado_CellMouseClick);
            // 
            // ProNumFact
            // 
            this.ProNumFact.DataPropertyName = "ProNumFact";
            this.ProNumFact.HeaderText = "Fact.Prov.";
            this.ProNumFact.MinimumWidth = 6;
            this.ProNumFact.Name = "ProNumFact";
            this.ProNumFact.ReadOnly = true;
            this.ProNumFact.Width = 70;
            // 
            // ProCod
            // 
            this.ProCod.DataPropertyName = "ProCod";
            this.ProCod.HeaderText = "Cod.Prov.";
            this.ProCod.MinimumWidth = 6;
            this.ProCod.Name = "ProCod";
            this.ProCod.ReadOnly = true;
            this.ProCod.Width = 60;
            // 
            // ProNom
            // 
            this.ProNom.DataPropertyName = "ProNom";
            this.ProNom.HeaderText = "Proveedor";
            this.ProNom.MinimumWidth = 6;
            this.ProNom.Name = "ProNom";
            this.ProNom.ReadOnly = true;
            this.ProNom.Width = 200;
            // 
            // ProFechaFact
            // 
            this.ProFechaFact.DataPropertyName = "ProFechaFact";
            this.ProFechaFact.HeaderText = "Fecha Prov.";
            this.ProFechaFact.MinimumWidth = 6;
            this.ProFechaFact.Name = "ProFechaFact";
            this.ProFechaFact.ReadOnly = true;
            this.ProFechaFact.Width = 90;
            // 
            // ImpteFactura
            // 
            this.ImpteFactura.DataPropertyName = "ImpteFactura";
            this.ImpteFactura.HeaderText = "Importe";
            this.ImpteFactura.MinimumWidth = 6;
            this.ImpteFactura.Name = "ImpteFactura";
            this.ImpteFactura.ReadOnly = true;
            this.ImpteFactura.Width = 70;
            // 
            // ImptePendiente
            // 
            this.ImptePendiente.DataPropertyName = "ImptePendiente";
            this.ImptePendiente.HeaderText = "Pendiente";
            this.ImptePendiente.MinimumWidth = 6;
            this.ImptePendiente.Name = "ImptePendiente";
            this.ImptePendiente.ReadOnly = true;
            this.ImptePendiente.Width = 70;
            // 
            // Selec
            // 
            this.Selec.HeaderText = "Selección";
            this.Selec.MinimumWidth = 6;
            this.Selec.Name = "Selec";
            this.Selec.ReadOnly = true;
            this.Selec.Width = 70;
            // 
            // ImptePagado
            // 
            this.ImptePagado.DataPropertyName = "ImptePagado";
            this.ImptePagado.HeaderText = "Pagado";
            this.ImptePagado.MinimumWidth = 6;
            this.ImptePagado.Name = "ImptePagado";
            this.ImptePagado.ReadOnly = true;
            this.ImptePagado.Width = 70;
            // 
            // BI1
            // 
            this.BI1.DataPropertyName = "BI1";
            this.BI1.HeaderText = "BI";
            this.BI1.MinimumWidth = 6;
            this.BI1.Name = "BI1";
            this.BI1.ReadOnly = true;
            this.BI1.Width = 70;
            // 
            // IVA1
            // 
            this.IVA1.DataPropertyName = "IVA1";
            this.IVA1.HeaderText = "IVA";
            this.IVA1.MinimumWidth = 6;
            this.IVA1.Name = "IVA1";
            this.IVA1.ReadOnly = true;
            this.IVA1.Width = 70;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "Factura";
            this.Factura.MinimumWidth = 6;
            this.Factura.Name = "Factura";
            this.Factura.ReadOnly = true;
            this.Factura.Width = 70;
            // 
            // Anyo
            // 
            this.Anyo.DataPropertyName = "Anyo";
            this.Anyo.HeaderText = "Año";
            this.Anyo.MinimumWidth = 6;
            this.Anyo.Name = "Anyo";
            this.Anyo.ReadOnly = true;
            this.Anyo.Width = 50;
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "Serie";
            this.Serie.HeaderText = "Serie";
            this.Serie.MinimumWidth = 6;
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Width = 50;
            // 
            // FechaEmision
            // 
            this.FechaEmision.DataPropertyName = "FechaEmision";
            this.FechaEmision.HeaderText = "Fecha";
            this.FechaEmision.MinimumWidth = 6;
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.ReadOnly = true;
            this.FechaEmision.Width = 125;
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
            this.panel9.BackColor = System.Drawing.Color.Lavender;
            this.panel9.Controls.Add(this.ckbMarcarTodo);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(350, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(108, 62);
            this.panel9.TabIndex = 2;
            // 
            // ckbMarcarTodo
            // 
            this.ckbMarcarTodo.AutoSize = true;
            this.ckbMarcarTodo.Location = new System.Drawing.Point(6, 8);
            this.ckbMarcarTodo.Name = "ckbMarcarTodo";
            this.ckbMarcarTodo.Size = new System.Drawing.Size(109, 20);
            this.ckbMarcarTodo.TabIndex = 0;
            this.ckbMarcarTodo.Text = "Marcar Todo";
            this.ckbMarcarTodo.UseVisualStyleBackColor = true;
            this.ckbMarcarTodo.CheckedChanged += new System.EventHandler(this.ckbMarcarTodo_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Lavender;
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
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.radioButton_Todas);
            this.groupBox1.Controls.Add(this.radioButton_SinPagar);
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
            this.radioButton_Todas.Size = new System.Drawing.Size(67, 20);
            this.radioButton_Todas.TabIndex = 6;
            this.radioButton_Todas.Text = "Todas";
            this.radioButton_Todas.UseVisualStyleBackColor = true;
            this.radioButton_Todas.CheckedChanged += new System.EventHandler(this.radioButton_Todas_CheckedChanged);
            // 
            // radioButton_SinPagar
            // 
            this.radioButton_SinPagar.AutoSize = true;
            this.radioButton_SinPagar.Checked = true;
            this.radioButton_SinPagar.Location = new System.Drawing.Point(19, 6);
            this.radioButton_SinPagar.Name = "radioButton_SinPagar";
            this.radioButton_SinPagar.Size = new System.Drawing.Size(91, 20);
            this.radioButton_SinPagar.TabIndex = 5;
            this.radioButton_SinPagar.TabStop = true;
            this.radioButton_SinPagar.Text = "Sin Pagar";
            this.radioButton_SinPagar.UseVisualStyleBackColor = true;
            this.radioButton_SinPagar.CheckedChanged += new System.EventHandler(this.radioButton_SinPagar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "hasta";
            // 
            // checkBox_Fecha
            // 
            this.checkBox_Fecha.AutoSize = true;
            this.checkBox_Fecha.Location = new System.Drawing.Point(30, 8);
            this.checkBox_Fecha.Name = "checkBox_Fecha";
            this.checkBox_Fecha.Size = new System.Drawing.Size(71, 20);
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
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker_Fin.TabIndex = 1;
            this.dateTimePicker_Fin.ValueChanged += new System.EventHandler(this.dateTimePicker_Fin_ValueChanged);
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(93, 6);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 23);
            this.dateTimePicker_Inicio.TabIndex = 0;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Lavender;
            this.panel7.Controls.Add(this.textBox_ProNom);
            this.panel7.Controls.Add(this.textBox_Serie);
            this.panel7.Controls.Add(this.textBox_Factura);
            this.panel7.Controls.Add(this.textBox_Anyo);
            this.panel7.Controls.Add(this.textBox_ProCod);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 62);
            this.panel7.TabIndex = 0;
            // 
            // textBox_ProNom
            // 
            this.textBox_ProNom.ForeColor = System.Drawing.Color.Silver;
            this.textBox_ProNom.Location = new System.Drawing.Point(132, 33);
            this.textBox_ProNom.Name = "textBox_ProNom";
            this.textBox_ProNom.Size = new System.Drawing.Size(196, 23);
            this.textBox_ProNom.TabIndex = 4;
            this.textBox_ProNom.Text = "PRONOM";
            this.textBox_ProNom.Enter += new System.EventHandler(this.textBox_ProNom_Enter);
            this.textBox_ProNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ProNom_KeyPress);
            this.textBox_ProNom.Leave += new System.EventHandler(this.textBox_ProNom_Leave);
            // 
            // textBox_Serie
            // 
            this.textBox_Serie.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Serie.Location = new System.Drawing.Point(113, 6);
            this.textBox_Serie.Name = "textBox_Serie";
            this.textBox_Serie.Size = new System.Drawing.Size(49, 23);
            this.textBox_Serie.TabIndex = 3;
            this.textBox_Serie.Text = "SERIE";
            this.textBox_Serie.Visible = false;
            this.textBox_Serie.Enter += new System.EventHandler(this.textBox_Serie_Enter);
            this.textBox_Serie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Serie_KeyPress);
            this.textBox_Serie.Leave += new System.EventHandler(this.textBox_Serie_Leave);
            // 
            // textBox_Factura
            // 
            this.textBox_Factura.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Factura.Location = new System.Drawing.Point(6, 33);
            this.textBox_Factura.Name = "textBox_Factura";
            this.textBox_Factura.Size = new System.Drawing.Size(65, 23);
            this.textBox_Factura.TabIndex = 0;
            this.textBox_Factura.Text = "FACTURA";
            this.textBox_Factura.Enter += new System.EventHandler(this.textBox_Factura_Enter);
            this.textBox_Factura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Factura_KeyPress);
            this.textBox_Factura.Leave += new System.EventHandler(this.textBox_Factura_Leave);
            // 
            // textBox_Anyo
            // 
            this.textBox_Anyo.ForeColor = System.Drawing.Color.Silver;
            this.textBox_Anyo.Location = new System.Drawing.Point(58, 6);
            this.textBox_Anyo.Name = "textBox_Anyo";
            this.textBox_Anyo.Size = new System.Drawing.Size(49, 23);
            this.textBox_Anyo.TabIndex = 1;
            this.textBox_Anyo.Text = "AÑO";
            this.textBox_Anyo.Visible = false;
            this.textBox_Anyo.Enter += new System.EventHandler(this.textBox_Anyo_Enter);
            this.textBox_Anyo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Anyo_KeyPress);
            this.textBox_Anyo.Leave += new System.EventHandler(this.textBox_Anyo_Leave);
            // 
            // textBox_ProCod
            // 
            this.textBox_ProCod.ForeColor = System.Drawing.Color.Silver;
            this.textBox_ProCod.Location = new System.Drawing.Point(77, 33);
            this.textBox_ProCod.Name = "textBox_ProCod";
            this.textBox_ProCod.Size = new System.Drawing.Size(49, 23);
            this.textBox_ProCod.TabIndex = 2;
            this.textBox_ProCod.Text = "PROCOD";
            this.textBox_ProCod.Enter += new System.EventHandler(this.textBox_ProCod_Enter);
            this.textBox_ProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ProCod_KeyPress);
            this.textBox_ProCod.Leave += new System.EventHandler(this.textBox_ProCod_Leave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Lavender;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(831, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(23, 445);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 445);
            this.panel4.TabIndex = 0;
            // 
            // frmFCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(854, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFCompras";
            this.Text = "    Facturas Compras";
            this.Load += new System.EventHandler(this.frmFCompras_Load);
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
        private System.Windows.Forms.TextBox textBox_ProCod;
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
        private System.Windows.Forms.RadioButton radioButton_SinPagar;
        private System.Windows.Forms.Button button_Pago;
        private System.Windows.Forms.Label label_IVAs;
        private System.Windows.Forms.Label label_BIs;
        private System.Windows.Forms.CheckBox ckbMarcarTodo;
        private System.Windows.Forms.TextBox textBox_ProNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProNumFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProFechaFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImpteFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImptePendiente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImptePagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn BI1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anyo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
    }
}