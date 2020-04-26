namespace cercle17
{
    partial class frmHojaCaja2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHojaCaja2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CONTABILIZAR = new System.Windows.Forms.Button();
            this.btnGRABAR = new System.Windows.Forms.Button();
            this.btnListadoXLS = new System.Windows.Forms.Button();
            this.btn_Add_Pagos_CAJA = new System.Windows.Forms.Button();
            this.btn_Add_Pagos = new System.Windows.Forms.Button();
            this.btn_PresentaDAtos = new System.Windows.Forms.Button();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.dGIngr = new System.Windows.Forms.DataGridView();
            this.ColConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGGast = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_CambioDA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dTP_Fecha = new System.Windows.Forms.DateTimePicker();
            this.lFecha = new System.Windows.Forms.Label();
            this.lTotalCobros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lTotalPagos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dGTalo = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEFECTIVO = new System.Windows.Forms.TextBox();
            this.txtTALONES = new System.Windows.Forms.TextBox();
            this.txtCAMBIODS = new System.Windows.Forms.TextBox();
            this.txtINGRESOB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResto = new System.Windows.Forms.TextBox();
            this.lDescuadre = new System.Windows.Forms.Label();
            this.lTotalTalones = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGIngr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGGast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGTalo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btn_CONTABILIZAR);
            this.panel1.Controls.Add(this.btnGRABAR);
            this.panel1.Controls.Add(this.btnListadoXLS);
            this.panel1.Controls.Add(this.btn_Add_Pagos_CAJA);
            this.panel1.Controls.Add(this.btn_Add_Pagos);
            this.panel1.Controls.Add(this.btn_PresentaDAtos);
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 71);
            this.panel1.TabIndex = 7;
            // 
            // btn_CONTABILIZAR
            // 
            this.btn_CONTABILIZAR.BackColor = System.Drawing.Color.Beige;
            this.btn_CONTABILIZAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CONTABILIZAR.Image = global::cercle17.Properties.Resources.contabilidad_euro02;
            this.btn_CONTABILIZAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CONTABILIZAR.Location = new System.Drawing.Point(567, 3);
            this.btn_CONTABILIZAR.Name = "btn_CONTABILIZAR";
            this.btn_CONTABILIZAR.Size = new System.Drawing.Size(143, 65);
            this.btn_CONTABILIZAR.TabIndex = 30;
            this.btn_CONTABILIZAR.Text = "Contabilizar";
            this.btn_CONTABILIZAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CONTABILIZAR.UseVisualStyleBackColor = false;
            this.btn_CONTABILIZAR.Visible = false;
            this.btn_CONTABILIZAR.Click += new System.EventHandler(this.btn_CONTABILIZAR_Click);
            // 
            // btnGRABAR
            // 
            this.btnGRABAR.BackColor = System.Drawing.Color.Beige;
            this.btnGRABAR.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGRABAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGRABAR.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGRABAR.Image = global::cercle17.Properties.Resources.Guardar2;
            this.btnGRABAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGRABAR.Location = new System.Drawing.Point(1055, 4);
            this.btnGRABAR.Name = "btnGRABAR";
            this.btnGRABAR.Size = new System.Drawing.Size(135, 64);
            this.btnGRABAR.TabIndex = 29;
            this.btnGRABAR.Text = "Grabar";
            this.btnGRABAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGRABAR.UseVisualStyleBackColor = false;
            this.btnGRABAR.Click += new System.EventHandler(this.btnGRABAR_Click);
            // 
            // btnListadoXLS
            // 
            this.btnListadoXLS.BackColor = System.Drawing.Color.Beige;
            this.btnListadoXLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListadoXLS.Image = global::cercle17.Properties.Resources.excell01;
            this.btnListadoXLS.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnListadoXLS.Location = new System.Drawing.Point(431, 3);
            this.btnListadoXLS.Name = "btnListadoXLS";
            this.btnListadoXLS.Size = new System.Drawing.Size(130, 65);
            this.btnListadoXLS.TabIndex = 9;
            this.btnListadoXLS.Text = "Generar EXCELL";
            this.btnListadoXLS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListadoXLS.UseVisualStyleBackColor = false;
            this.btnListadoXLS.Visible = false;
            this.btnListadoXLS.Click += new System.EventHandler(this.btnListadoXLS_Click);
            // 
            // btn_Add_Pagos_CAJA
            // 
            this.btn_Add_Pagos_CAJA.BackColor = System.Drawing.Color.Beige;
            this.btn_Add_Pagos_CAJA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Pagos_CAJA.Image = global::cercle17.Properties.Resources.Cobrar3;
            this.btn_Add_Pagos_CAJA.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_Add_Pagos_CAJA.Location = new System.Drawing.Point(280, 3);
            this.btn_Add_Pagos_CAJA.Name = "btn_Add_Pagos_CAJA";
            this.btn_Add_Pagos_CAJA.Size = new System.Drawing.Size(145, 65);
            this.btn_Add_Pagos_CAJA.TabIndex = 8;
            this.btn_Add_Pagos_CAJA.Text = "Añadir PAGOS CAJA";
            this.btn_Add_Pagos_CAJA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Add_Pagos_CAJA.UseVisualStyleBackColor = false;
            this.btn_Add_Pagos_CAJA.Click += new System.EventHandler(this.btn_Add_Pagos_CAJA_Click);
            // 
            // btn_Add_Pagos
            // 
            this.btn_Add_Pagos.BackColor = System.Drawing.Color.Beige;
            this.btn_Add_Pagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Pagos.Image = global::cercle17.Properties.Resources.Cobrar3;
            this.btn_Add_Pagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add_Pagos.Location = new System.Drawing.Point(129, 3);
            this.btn_Add_Pagos.Name = "btn_Add_Pagos";
            this.btn_Add_Pagos.Size = new System.Drawing.Size(145, 65);
            this.btn_Add_Pagos.TabIndex = 7;
            this.btn_Add_Pagos.Text = "Añadir PAGOS";
            this.btn_Add_Pagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Add_Pagos.UseVisualStyleBackColor = false;
            this.btn_Add_Pagos.Visible = false;
            this.btn_Add_Pagos.Click += new System.EventHandler(this.btn_Add_Pagos_Click);
            // 
            // btn_PresentaDAtos
            // 
            this.btn_PresentaDAtos.BackColor = System.Drawing.Color.Beige;
            this.btn_PresentaDAtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PresentaDAtos.Image = global::cercle17.Properties.Resources.ComputaForm03;
            this.btn_PresentaDAtos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PresentaDAtos.Location = new System.Drawing.Point(921, 3);
            this.btn_PresentaDAtos.Name = "btn_PresentaDAtos";
            this.btn_PresentaDAtos.Size = new System.Drawing.Size(128, 65);
            this.btn_PresentaDAtos.TabIndex = 6;
            this.btn_PresentaDAtos.Text = "Ver Caja";
            this.btn_PresentaDAtos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PresentaDAtos.UseVisualStyleBackColor = false;
            this.btn_PresentaDAtos.Click += new System.EventHandler(this.btn_PresentaDAtos_Click);
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(111, 65);
            this.btnSALIR.TabIndex = 5;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // dGIngr
            // 
            this.dGIngr.BackgroundColor = System.Drawing.Color.Wheat;
            this.dGIngr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGIngr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColConcepto,
            this.ColCantidad});
            this.dGIngr.Location = new System.Drawing.Point(41, 138);
            this.dGIngr.Name = "dGIngr";
            this.dGIngr.Size = new System.Drawing.Size(544, 320);
            this.dGIngr.TabIndex = 8;
            // 
            // ColConcepto
            // 
            this.ColConcepto.HeaderText = "C O N C E P T O";
            this.ColConcepto.Name = "ColConcepto";
            this.ColConcepto.Width = 400;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "CANTIDAD";
            this.ColCantidad.Name = "ColCantidad";
            // 
            // dGGast
            // 
            this.dGGast.BackgroundColor = System.Drawing.Color.Wheat;
            this.dGGast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGGast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dGGast.Location = new System.Drawing.Point(613, 138);
            this.dGGast.Name = "dGGast";
            this.dGGast.Size = new System.Drawing.Size(548, 320);
            this.dGGast.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Prov/Acr";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "C O N C E P T O";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Cantidad";
            this.Column3.Name = "Column3";
            // 
            // txt_CambioDA
            // 
            this.txt_CambioDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CambioDA.Location = new System.Drawing.Point(484, 93);
            this.txt_CambioDA.Name = "txt_CambioDA";
            this.txt_CambioDA.Size = new System.Drawing.Size(101, 22);
            this.txt_CambioDA.TabIndex = 14;
            this.txt_CambioDA.Text = "0.00";
            this.txt_CambioDA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(354, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cambio Dia Anterior";
            // 
            // dTP_Fecha
            // 
            this.dTP_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTP_Fecha.Location = new System.Drawing.Point(87, 88);
            this.dTP_Fecha.Name = "dTP_Fecha";
            this.dTP_Fecha.Size = new System.Drawing.Size(87, 20);
            this.dTP_Fecha.TabIndex = 16;
            this.dTP_Fecha.ValueChanged += new System.EventHandler(this.dTP_Fecha_ValueChanged);
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Location = new System.Drawing.Point(39, 94);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(42, 13);
            this.lFecha.TabIndex = 15;
            this.lFecha.Text = "FECHA";
            // 
            // lTotalCobros
            // 
            this.lTotalCobros.AutoSize = true;
            this.lTotalCobros.BackColor = System.Drawing.Color.Goldenrod;
            this.lTotalCobros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lTotalCobros.Location = new System.Drawing.Point(538, 474);
            this.lTotalCobros.Name = "lTotalCobros";
            this.lTotalCobros.Size = new System.Drawing.Size(0, 13);
            this.lTotalCobros.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "TOTAL COBROS ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkKhaki;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(596, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 21;
            // 
            // lTotalPagos
            // 
            this.lTotalPagos.AutoSize = true;
            this.lTotalPagos.Location = new System.Drawing.Point(1111, 474);
            this.lTotalPagos.Name = "lTotalPagos";
            this.lTotalPagos.Size = new System.Drawing.Size(0, 13);
            this.lTotalPagos.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(996, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "TOTAL  PAGOS";
            // 
            // dGTalo
            // 
            this.dGTalo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGTalo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dGTalo.Location = new System.Drawing.Point(41, 510);
            this.dGTalo.Name = "dGTalo";
            this.dGTalo.Size = new System.Drawing.Size(543, 92);
            this.dGTalo.TabIndex = 24;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cod_Clte";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DATOS TALON";
            this.Column5.Name = "Column5";
            this.Column5.Width = 280;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Importe";
            this.Column6.Name = "Column6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(239, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "TALONES";
            // 
            // txtEFECTIVO
            // 
            this.txtEFECTIVO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEFECTIVO.Location = new System.Drawing.Point(727, 580);
            this.txtEFECTIVO.Name = "txtEFECTIVO";
            this.txtEFECTIVO.Size = new System.Drawing.Size(86, 22);
            this.txtEFECTIVO.TabIndex = 26;
            this.txtEFECTIVO.Text = "0.00";
            this.txtEFECTIVO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEFECTIVO_KeyPress);
            // 
            // txtTALONES
            // 
            this.txtTALONES.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTALONES.Enabled = false;
            this.txtTALONES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTALONES.Location = new System.Drawing.Point(842, 580);
            this.txtTALONES.Name = "txtTALONES";
            this.txtTALONES.Size = new System.Drawing.Size(86, 22);
            this.txtTALONES.TabIndex = 27;
            this.txtTALONES.Text = "0.00";
            // 
            // txtCAMBIODS
            // 
            this.txtCAMBIODS.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCAMBIODS.Enabled = false;
            this.txtCAMBIODS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAMBIODS.Location = new System.Drawing.Point(956, 580);
            this.txtCAMBIODS.Name = "txtCAMBIODS";
            this.txtCAMBIODS.Size = new System.Drawing.Size(85, 22);
            this.txtCAMBIODS.TabIndex = 28;
            this.txtCAMBIODS.Text = "0.00";
            // 
            // txtINGRESOB
            // 
            this.txtINGRESOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtINGRESOB.Location = new System.Drawing.Point(1072, 580);
            this.txtINGRESOB.Name = "txtINGRESOB";
            this.txtINGRESOB.Size = new System.Drawing.Size(88, 22);
            this.txtINGRESOB.TabIndex = 29;
            this.txtINGRESOB.Text = "0.00";
            this.txtINGRESOB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtINGRESOB_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(516, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "RESTO                     EFECTIVO                   TALONES                     " +
    "  CAMB. DIA STE.          INGR. BANCO";
            // 
            // txtResto
            // 
            this.txtResto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResto.Location = new System.Drawing.Point(612, 580);
            this.txtResto.Name = "txtResto";
            this.txtResto.Size = new System.Drawing.Size(88, 22);
            this.txtResto.TabIndex = 31;
            this.txtResto.Text = "0.00";
            // 
            // lDescuadre
            // 
            this.lDescuadre.AutoSize = true;
            this.lDescuadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescuadre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lDescuadre.Location = new System.Drawing.Point(617, 510);
            this.lDescuadre.Name = "lDescuadre";
            this.lDescuadre.Size = new System.Drawing.Size(0, 31);
            this.lDescuadre.TabIndex = 32;
            // 
            // lTotalTalones
            // 
            this.lTotalTalones.AutoSize = true;
            this.lTotalTalones.Location = new System.Drawing.Point(491, 605);
            this.lTotalTalones.Name = "lTotalTalones";
            this.lTotalTalones.Size = new System.Drawing.Size(35, 13);
            this.lTotalTalones.TabIndex = 33;
            this.lTotalTalones.Text = "label7";
            // 
            // frmHojaCaja2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1193, 621);
            this.Controls.Add(this.lTotalTalones);
            this.Controls.Add(this.lDescuadre);
            this.Controls.Add(this.txtResto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtINGRESOB);
            this.Controls.Add(this.txtCAMBIODS);
            this.Controls.Add(this.txtTALONES);
            this.Controls.Add(this.txtEFECTIVO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dGTalo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lTotalPagos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lTotalCobros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CambioDA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTP_Fecha);
            this.Controls.Add(this.lFecha);
            this.Controls.Add(this.dGGast);
            this.Controls.Add(this.dGIngr);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHojaCaja2";
            this.Text = "frmHojaCaja2";
            this.Load += new System.EventHandler(this.frmHojaCaja2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGIngr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGGast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGTalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.DataGridView dGIngr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridView dGGast;
        private System.Windows.Forms.TextBox txt_CambioDA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTP_Fecha;
        private System.Windows.Forms.Label lFecha;
        private System.Windows.Forms.Label lTotalCobros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_PresentaDAtos;
        private System.Windows.Forms.Button btn_Add_Pagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lTotalPagos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Add_Pagos_CAJA;
        private System.Windows.Forms.Button btnListadoXLS;
        private System.Windows.Forms.DataGridView dGTalo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEFECTIVO;
        private System.Windows.Forms.TextBox txtTALONES;
        private System.Windows.Forms.TextBox txtCAMBIODS;
        private System.Windows.Forms.TextBox txtINGRESOB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox txtResto;
        private System.Windows.Forms.Label lDescuadre;
        private System.Windows.Forms.Label lTotalTalones;
        private System.Windows.Forms.Button btnGRABAR;
        private System.Windows.Forms.Button btn_CONTABILIZAR;
    }
}