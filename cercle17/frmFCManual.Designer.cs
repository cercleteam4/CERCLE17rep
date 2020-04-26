namespace cercle17
{
    partial class frmFCManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFCManual));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Consulta = new System.Windows.Forms.Button();
            this.textBox_ProCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ProNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Albaranes = new System.Windows.Forms.Panel();
            this.dataGridView_Albaranes = new System.Windows.Forms.DataGridView();
            this.Facturar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComCpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComCfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.Selec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Factura = new System.Windows.Forms.Panel();
            this.lblPortes = new System.Windows.Forms.Label();
            this.tbProNumFact = new System.Windows.Forms.TextBox();
            this.lblProFechaFact = new System.Windows.Forms.Label();
            this.dtpProFechaFact = new System.Windows.Forms.DateTimePicker();
            this.panel_report = new System.Windows.Forms.Panel();
            this.button_Grabar = new System.Windows.Forms.Button();
            this.textBox_Importe = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_Serie = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IVA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_BI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TextoCabecera = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_TextoPie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Observaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_Facturado = new System.Windows.Forms.DataGridView();
            this.LinF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComTrz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_Marcar = new System.Windows.Forms.CheckBox();
            this.textBox_Anyo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.btnAñadirProveedores = new System.Windows.Forms.Button();
            this.panelProveedores = new System.Windows.Forms.Panel();
            this.btnAceptarProveedores = new System.Windows.Forms.Button();
            this.lblOtrosProveedores = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_Albaranes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.panel_Factura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelProveedores.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Consulta);
            this.panel1.Controls.Add(this.textBox_ProCod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_ProNom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 45);
            this.panel1.TabIndex = 0;
            // 
            // button_Consulta
            // 
            this.button_Consulta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Consulta.Location = new System.Drawing.Point(699, 5);
            this.button_Consulta.Name = "button_Consulta";
            this.button_Consulta.Size = new System.Drawing.Size(109, 31);
            this.button_Consulta.TabIndex = 4;
            this.button_Consulta.Text = "CONSULTA";
            this.button_Consulta.UseVisualStyleBackColor = true;
            this.button_Consulta.Click += new System.EventHandler(this.button_Consulta_Click);
            // 
            // textBox_ProCod
            // 
            this.textBox_ProCod.Location = new System.Drawing.Point(161, 10);
            this.textBox_ProCod.Name = "textBox_ProCod";
            this.textBox_ProCod.Size = new System.Drawing.Size(62, 20);
            this.textBox_ProCod.TabIndex = 1;
            this.textBox_ProCod.Enter += new System.EventHandler(this.textBox_ProCod_Enter);
            this.textBox_ProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ProCod_KeyPress);
            this.textBox_ProCod.Leave += new System.EventHandler(this.textBox_ProCod_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "CÓDIGO PROVEEDOR :";
            // 
            // textBox_ProNom
            // 
            this.textBox_ProNom.Location = new System.Drawing.Point(389, 10);
            this.textBox_ProNom.Name = "textBox_ProNom";
            this.textBox_ProNom.ReadOnly = true;
            this.textBox_ProNom.Size = new System.Drawing.Size(288, 20);
            this.textBox_ProNom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE PROVEEDOR :";
            // 
            // panel_Albaranes
            // 
            this.panel_Albaranes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Albaranes.Controls.Add(this.dataGridView_Albaranes);
            this.panel_Albaranes.Location = new System.Drawing.Point(14, 167);
            this.panel_Albaranes.Name = "panel_Albaranes";
            this.panel_Albaranes.Size = new System.Drawing.Size(827, 182);
            this.panel_Albaranes.TabIndex = 1;
            // 
            // dataGridView_Albaranes
            // 
            this.dataGridView_Albaranes.AllowUserToAddRows = false;
            this.dataGridView_Albaranes.AllowUserToDeleteRows = false;
            this.dataGridView_Albaranes.AllowUserToResizeColumns = false;
            this.dataGridView_Albaranes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_Albaranes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Albaranes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Facturar,
            this.ComCpa,
            this.Anyo,
            this.ComCfa,
            this.ProCod,
            this.ProNom,
            this.comcim});
            this.dataGridView_Albaranes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Albaranes.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Albaranes.MultiSelect = false;
            this.dataGridView_Albaranes.Name = "dataGridView_Albaranes";
            this.dataGridView_Albaranes.ReadOnly = true;
            this.dataGridView_Albaranes.RowHeadersVisible = false;
            this.dataGridView_Albaranes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Albaranes.Size = new System.Drawing.Size(825, 180);
            this.dataGridView_Albaranes.TabIndex = 0;
            this.dataGridView_Albaranes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Albaranes_CellClick);
            // 
            // Facturar
            // 
            this.Facturar.DataPropertyName = "Facturar";
            this.Facturar.HeaderText = "Facturar";
            this.Facturar.Name = "Facturar";
            this.Facturar.ReadOnly = true;
            this.Facturar.Width = 60;
            // 
            // ComCpa
            // 
            this.ComCpa.DataPropertyName = "ComCpa";
            this.ComCpa.HeaderText = "Albarán";
            this.ComCpa.Name = "ComCpa";
            this.ComCpa.ReadOnly = true;
            this.ComCpa.Width = 70;
            // 
            // Anyo
            // 
            this.Anyo.DataPropertyName = "Anyo";
            this.Anyo.HeaderText = "Año";
            this.Anyo.Name = "Anyo";
            this.Anyo.ReadOnly = true;
            this.Anyo.Width = 50;
            // 
            // ComCfa
            // 
            this.ComCfa.DataPropertyName = "ComCfa";
            this.ComCfa.HeaderText = "Fecha";
            this.ComCfa.Name = "ComCfa";
            this.ComCfa.ReadOnly = true;
            // 
            // ProCod
            // 
            this.ProCod.DataPropertyName = "ProCod";
            this.ProCod.HeaderText = "Cod.Prov.";
            this.ProCod.Name = "ProCod";
            this.ProCod.ReadOnly = true;
            this.ProCod.Width = 60;
            // 
            // ProNom
            // 
            this.ProNom.DataPropertyName = "Proveedor";
            this.ProNom.HeaderText = "Proveedor";
            this.ProNom.Name = "ProNom";
            this.ProNom.ReadOnly = true;
            this.ProNom.Width = 250;
            // 
            // comcim
            // 
            this.comcim.DataPropertyName = "comcim";
            this.comcim.HeaderText = "Importe";
            this.comcim.Name = "comcim";
            this.comcim.ReadOnly = true;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToResizeColumns = false;
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selec,
            this.ProCodigo,
            this.ProNombre});
            this.dgvProveedores.Location = new System.Drawing.Point(3, 3);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(341, 240);
            this.dgvProveedores.TabIndex = 1;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);
            // 
            // Selec
            // 
            this.Selec.FalseValue = "";
            this.Selec.HeaderText = "";
            this.Selec.Name = "Selec";
            this.Selec.ReadOnly = true;
            this.Selec.TrueValue = "";
            this.Selec.Width = 50;
            // 
            // ProCodigo
            // 
            this.ProCodigo.DataPropertyName = "ProCod";
            this.ProCodigo.HeaderText = "Código";
            this.ProCodigo.Name = "ProCodigo";
            this.ProCodigo.ReadOnly = true;
            this.ProCodigo.Width = 70;
            // 
            // ProNombre
            // 
            this.ProNombre.DataPropertyName = "ProNom";
            this.ProNombre.HeaderText = "Proveedor";
            this.ProNombre.Name = "ProNombre";
            this.ProNombre.ReadOnly = true;
            this.ProNombre.Width = 200;
            // 
            // panel_Factura
            // 
            this.panel_Factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Factura.Controls.Add(this.lblPortes);
            this.panel_Factura.Controls.Add(this.tbProNumFact);
            this.panel_Factura.Controls.Add(this.lblProFechaFact);
            this.panel_Factura.Controls.Add(this.dtpProFechaFact);
            this.panel_Factura.Controls.Add(this.panel_report);
            this.panel_Factura.Controls.Add(this.button_Grabar);
            this.panel_Factura.Controls.Add(this.textBox_Importe);
            this.panel_Factura.Controls.Add(this.label12);
            this.panel_Factura.Controls.Add(this.comboBox_Serie);
            this.panel_Factura.Controls.Add(this.label5);
            this.panel_Factura.Controls.Add(this.textBox_IVA);
            this.panel_Factura.Controls.Add(this.label10);
            this.panel_Factura.Controls.Add(this.textBox_BI);
            this.panel_Factura.Controls.Add(this.label9);
            this.panel_Factura.Controls.Add(this.textBox_TextoCabecera);
            this.panel_Factura.Controls.Add(this.label8);
            this.panel_Factura.Controls.Add(this.textBox_TextoPie);
            this.panel_Factura.Controls.Add(this.label7);
            this.panel_Factura.Controls.Add(this.textBox_Observaciones);
            this.panel_Factura.Controls.Add(this.label6);
            this.panel_Factura.Controls.Add(this.dataGridView_Facturado);
            this.panel_Factura.Location = new System.Drawing.Point(14, 380);
            this.panel_Factura.Name = "panel_Factura";
            this.panel_Factura.Size = new System.Drawing.Size(827, 257);
            this.panel_Factura.TabIndex = 2;
            // 
            // lblPortes
            // 
            this.lblPortes.AutoSize = true;
            this.lblPortes.Location = new System.Drawing.Point(233, 13);
            this.lblPortes.Name = "lblPortes";
            this.lblPortes.Size = new System.Drawing.Size(80, 14);
            this.lblPortes.TabIndex = 27;
            this.lblPortes.Text = "Nº FAC. PROV:";
            // 
            // tbProNumFact
            // 
            this.tbProNumFact.Location = new System.Drawing.Point(319, 9);
            this.tbProNumFact.MaxLength = 20;
            this.tbProNumFact.Name = "tbProNumFact";
            this.tbProNumFact.Size = new System.Drawing.Size(100, 20);
            this.tbProNumFact.TabIndex = 5;
            // 
            // lblProFechaFact
            // 
            this.lblProFechaFact.AutoSize = true;
            this.lblProFechaFact.Location = new System.Drawing.Point(25, 13);
            this.lblProFechaFact.Name = "lblProFechaFact";
            this.lblProFechaFact.Size = new System.Drawing.Size(106, 14);
            this.lblProFechaFact.TabIndex = 25;
            this.lblProFechaFact.Text = "FECHA FAC. PROV. :";
            // 
            // dtpProFechaFact
            // 
            this.dtpProFechaFact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProFechaFact.Location = new System.Drawing.Point(137, 9);
            this.dtpProFechaFact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpProFechaFact.Name = "dtpProFechaFact";
            this.dtpProFechaFact.Size = new System.Drawing.Size(86, 20);
            this.dtpProFechaFact.TabIndex = 4;
            // 
            // panel_report
            // 
            this.panel_report.Location = new System.Drawing.Point(509, 207);
            this.panel_report.Name = "panel_report";
            this.panel_report.Size = new System.Drawing.Size(73, 42);
            this.panel_report.TabIndex = 23;
            this.panel_report.Visible = false;
            // 
            // button_Grabar
            // 
            this.button_Grabar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Grabar.Location = new System.Drawing.Point(651, 209);
            this.button_Grabar.Name = "button_Grabar";
            this.button_Grabar.Size = new System.Drawing.Size(142, 38);
            this.button_Grabar.TabIndex = 21;
            this.button_Grabar.Text = "GRABAR FACTURA";
            this.button_Grabar.UseVisualStyleBackColor = true;
            this.button_Grabar.Click += new System.EventHandler(this.button_Grabar_Click);
            // 
            // textBox_Importe
            // 
            this.textBox_Importe.Location = new System.Drawing.Point(713, 9);
            this.textBox_Importe.Name = "textBox_Importe";
            this.textBox_Importe.ReadOnly = true;
            this.textBox_Importe.Size = new System.Drawing.Size(80, 20);
            this.textBox_Importe.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(651, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "IMPORTE :";
            // 
            // comboBox_Serie
            // 
            this.comboBox_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Serie.FormattingEnabled = true;
            this.comboBox_Serie.Items.AddRange(new object[] {
            "AA",
            "AB",
            "AC",
            "AD"});
            this.comboBox_Serie.Location = new System.Drawing.Point(137, 39);
            this.comboBox_Serie.Name = "comboBox_Serie";
            this.comboBox_Serie.Size = new System.Drawing.Size(72, 22);
            this.comboBox_Serie.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "SERIE :";
            // 
            // textBox_IVA
            // 
            this.textBox_IVA.Location = new System.Drawing.Point(589, 9);
            this.textBox_IVA.Name = "textBox_IVA";
            this.textBox_IVA.ReadOnly = true;
            this.textBox_IVA.Size = new System.Drawing.Size(56, 20);
            this.textBox_IVA.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(554, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "IVA :";
            // 
            // textBox_BI
            // 
            this.textBox_BI.Location = new System.Drawing.Point(468, 9);
            this.textBox_BI.Name = "textBox_BI";
            this.textBox_BI.ReadOnly = true;
            this.textBox_BI.Size = new System.Drawing.Size(80, 20);
            this.textBox_BI.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "BI :";
            // 
            // textBox_TextoCabecera
            // 
            this.textBox_TextoCabecera.Location = new System.Drawing.Point(343, 39);
            this.textBox_TextoCabecera.Name = "textBox_TextoCabecera";
            this.textBox_TextoCabecera.Size = new System.Drawing.Size(450, 20);
            this.textBox_TextoCabecera.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(233, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "TEXTO CABECERA :";
            // 
            // textBox_TextoPie
            // 
            this.textBox_TextoPie.Location = new System.Drawing.Point(127, 230);
            this.textBox_TextoPie.Name = "textBox_TextoPie";
            this.textBox_TextoPie.Size = new System.Drawing.Size(325, 20);
            this.textBox_TextoPie.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "TEXTO PIE :";
            // 
            // textBox_Observaciones
            // 
            this.textBox_Observaciones.Location = new System.Drawing.Point(127, 207);
            this.textBox_Observaciones.Name = "textBox_Observaciones";
            this.textBox_Observaciones.Size = new System.Drawing.Size(325, 20);
            this.textBox_Observaciones.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "OBSERVACIONES :";
            // 
            // dataGridView_Facturado
            // 
            this.dataGridView_Facturado.AllowUserToAddRows = false;
            this.dataGridView_Facturado.AllowUserToDeleteRows = false;
            this.dataGridView_Facturado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Facturado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LinF,
            this.ComLpa,
            this.ArtCod,
            this.ArtDes,
            this.ComLca,
            this.ComLki,
            this.ComLpr,
            this.ComLim,
            this.ComTrz});
            this.dataGridView_Facturado.Location = new System.Drawing.Point(24, 66);
            this.dataGridView_Facturado.Name = "dataGridView_Facturado";
            this.dataGridView_Facturado.ReadOnly = true;
            this.dataGridView_Facturado.RowHeadersVisible = false;
            this.dataGridView_Facturado.Size = new System.Drawing.Size(769, 135);
            this.dataGridView_Facturado.TabIndex = 0;
            // 
            // LinF
            // 
            this.LinF.DataPropertyName = "LinF";
            this.LinF.HeaderText = "Línea";
            this.LinF.Name = "LinF";
            this.LinF.ReadOnly = true;
            this.LinF.Width = 50;
            // 
            // ComLpa
            // 
            this.ComLpa.DataPropertyName = "ComLpa";
            this.ComLpa.HeaderText = "Albarán";
            this.ComLpa.Name = "ComLpa";
            this.ComLpa.ReadOnly = true;
            this.ComLpa.Width = 70;
            // 
            // ArtCod
            // 
            this.ArtCod.DataPropertyName = "ArtCod";
            this.ArtCod.HeaderText = "Cod.Art.";
            this.ArtCod.Name = "ArtCod";
            this.ArtCod.ReadOnly = true;
            this.ArtCod.Width = 70;
            // 
            // ArtDes
            // 
            this.ArtDes.DataPropertyName = "ArtDes";
            this.ArtDes.HeaderText = "Artículo";
            this.ArtDes.Name = "ArtDes";
            this.ArtDes.ReadOnly = true;
            this.ArtDes.Width = 200;
            // 
            // ComLca
            // 
            this.ComLca.DataPropertyName = "ComLca";
            this.ComLca.HeaderText = "Cajas";
            this.ComLca.Name = "ComLca";
            this.ComLca.ReadOnly = true;
            this.ComLca.Width = 50;
            // 
            // ComLki
            // 
            this.ComLki.DataPropertyName = "ComLki";
            this.ComLki.HeaderText = "Kilos";
            this.ComLki.Name = "ComLki";
            this.ComLki.ReadOnly = true;
            this.ComLki.Width = 70;
            // 
            // ComLpr
            // 
            this.ComLpr.DataPropertyName = "ComLpr";
            this.ComLpr.HeaderText = "Precio";
            this.ComLpr.Name = "ComLpr";
            this.ComLpr.ReadOnly = true;
            this.ComLpr.Width = 70;
            // 
            // ComLim
            // 
            this.ComLim.DataPropertyName = "ComLim";
            this.ComLim.HeaderText = "Importe";
            this.ComLim.Name = "ComLim";
            this.ComLim.ReadOnly = true;
            this.ComLim.Width = 70;
            // 
            // ComTrz
            // 
            this.ComTrz.DataPropertyName = "ComTrz";
            this.ComTrz.HeaderText = "Lote";
            this.ComTrz.Name = "ComTrz";
            this.ComTrz.ReadOnly = true;
            this.ComTrz.Width = 115;
            // 
            // checkBox_Marcar
            // 
            this.checkBox_Marcar.AutoSize = true;
            this.checkBox_Marcar.BackColor = System.Drawing.Color.Lavender;
            this.checkBox_Marcar.Location = new System.Drawing.Point(23, 143);
            this.checkBox_Marcar.Name = "checkBox_Marcar";
            this.checkBox_Marcar.Size = new System.Drawing.Size(86, 18);
            this.checkBox_Marcar.TabIndex = 22;
            this.checkBox_Marcar.Text = "Marcar Todo";
            this.checkBox_Marcar.UseVisualStyleBackColor = false;
            this.checkBox_Marcar.CheckedChanged += new System.EventHandler(this.checkBox_Marcar_CheckedChanged);
            // 
            // textBox_Anyo
            // 
            this.textBox_Anyo.Location = new System.Drawing.Point(182, 355);
            this.textBox_Anyo.Name = "textBox_Anyo";
            this.textBox_Anyo.ReadOnly = true;
            this.textBox_Anyo.Size = new System.Drawing.Size(56, 20);
            this.textBox_Anyo.TabIndex = 5;
            this.textBox_Anyo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "FACTURA :";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateBlue;
            this.panel2.Controls.Add(this.btnSALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 73);
            this.panel2.TabIndex = 4;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.GhostWhite;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(3, 5);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(112, 65);
            this.btnSALIR.TabIndex = 4;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // btnAñadirProveedores
            // 
            this.btnAñadirProveedores.Location = new System.Drawing.Point(123, 139);
            this.btnAñadirProveedores.Name = "btnAñadirProveedores";
            this.btnAñadirProveedores.Size = new System.Drawing.Size(125, 23);
            this.btnAñadirProveedores.TabIndex = 23;
            this.btnAñadirProveedores.Text = "Otros Proveedores";
            this.btnAñadirProveedores.UseVisualStyleBackColor = true;
            this.btnAñadirProveedores.Click += new System.EventHandler(this.btnAñadirProveedores_Click);
            // 
            // panelProveedores
            // 
            this.panelProveedores.BackColor = System.Drawing.Color.SlateBlue;
            this.panelProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProveedores.Controls.Add(this.btnAceptarProveedores);
            this.panelProveedores.Controls.Add(this.dgvProveedores);
            this.panelProveedores.Location = new System.Drawing.Point(474, 163);
            this.panelProveedores.Name = "panelProveedores";
            this.panelProveedores.Size = new System.Drawing.Size(349, 291);
            this.panelProveedores.TabIndex = 2;
            this.panelProveedores.Visible = false;
            // 
            // btnAceptarProveedores
            // 
            this.btnAceptarProveedores.Location = new System.Drawing.Point(138, 253);
            this.btnAceptarProveedores.Name = "btnAceptarProveedores";
            this.btnAceptarProveedores.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarProveedores.TabIndex = 2;
            this.btnAceptarProveedores.Text = "Aceptar";
            this.btnAceptarProveedores.UseVisualStyleBackColor = true;
            this.btnAceptarProveedores.Click += new System.EventHandler(this.btnAceptarProveedores_Click);
            // 
            // lblOtrosProveedores
            // 
            this.lblOtrosProveedores.AutoSize = true;
            this.lblOtrosProveedores.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtrosProveedores.Location = new System.Drawing.Point(262, 143);
            this.lblOtrosProveedores.Name = "lblOtrosProveedores";
            this.lblOtrosProveedores.Size = new System.Drawing.Size(0, 15);
            this.lblOtrosProveedores.TabIndex = 24;
            // 
            // frmFCManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(853, 648);
            this.Controls.Add(this.lblOtrosProveedores);
            this.Controls.Add(this.panelProveedores);
            this.Controls.Add(this.btnAñadirProveedores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkBox_Marcar);
            this.Controls.Add(this.panel_Albaranes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Factura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Anyo);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFCManual";
            this.Text = "    Facturación Compras Manual";
            this.Load += new System.EventHandler(this.frmFCManual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Albaranes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.panel_Factura.ResumeLayout(false);
            this.panel_Factura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelProveedores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ProCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ProNom;
        private System.Windows.Forms.Button button_Consulta;
        private System.Windows.Forms.Panel panel_Albaranes;
        private System.Windows.Forms.DataGridView dataGridView_Albaranes;
        private System.Windows.Forms.Panel panel_Factura;
        private System.Windows.Forms.ComboBox comboBox_Serie;
        private System.Windows.Forms.TextBox textBox_Anyo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_Facturado;
        private System.Windows.Forms.TextBox textBox_Observaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_TextoPie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_TextoCabecera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Grabar;
        private System.Windows.Forms.TextBox textBox_Importe;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_IVA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_BI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_Marcar;
        private System.Windows.Forms.Panel panel_report;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Label lblProFechaFact;
        private System.Windows.Forms.DateTimePicker dtpProFechaFact;
        private System.Windows.Forms.Label lblPortes;
        private System.Windows.Forms.TextBox tbProNumFact;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Facturar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anyo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComCfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn comcim;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLca;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLki;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLim;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComTrz;
        private System.Windows.Forms.Button btnAñadirProveedores;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProNombre;
        private System.Windows.Forms.Panel panelProveedores;
        private System.Windows.Forms.Button btnAceptarProveedores;
        private System.Windows.Forms.Label lblOtrosProveedores;
    }
}