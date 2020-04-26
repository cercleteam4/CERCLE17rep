namespace cercle17
{
    partial class frmEmpr05_CUADRE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpr05_CUADRE));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_SI_Seleccionadas = new System.Windows.Forms.Button();
            this.button_Marcar_Menor_1 = new System.Windows.Forms.Button();
            this.btnLISTAR = new System.Windows.Forms.Button();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.button_Si_Cuadre_Partida = new System.Windows.Forms.Button();
            this.dG1 = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.GBPB = new System.Windows.Forms.GroupBox();
            this.pB1 = new System.Windows.Forms.ProgressBar();
            this.LPB = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LArtDes = new System.Windows.Forms.Label();
            this.lProNom = new System.Windows.Forms.Label();
            this.lArtCod = new System.Windows.Forms.Label();
            this.lProCod = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tObservaciones = new System.Windows.Forms.TextBox();
            this.lStock = new System.Windows.Forms.Label();
            this.lStockInicial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lPartida = new System.Windows.Forms.Label();
            this.lAño = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lAlmacen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dG1)).BeginInit();
            this.GBPB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_SI_Seleccionadas);
            this.panel1.Controls.Add(this.button_Marcar_Menor_1);
            this.panel1.Controls.Add(this.btnLISTAR);
            this.panel1.Controls.Add(this.btnSALIR);
            this.panel1.Controls.Add(this.button_Si_Cuadre_Partida);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 71);
            this.panel1.TabIndex = 4;
            // 
            // button_SI_Seleccionadas
            // 
            this.button_SI_Seleccionadas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button_SI_Seleccionadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SI_Seleccionadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_SI_Seleccionadas.Location = new System.Drawing.Point(378, 3);
            this.button_SI_Seleccionadas.Name = "button_SI_Seleccionadas";
            this.button_SI_Seleccionadas.Size = new System.Drawing.Size(143, 65);
            this.button_SI_Seleccionadas.TabIndex = 22;
            this.button_SI_Seleccionadas.Text = "CUADRAR SELECCIONADAS";
            this.button_SI_Seleccionadas.UseVisualStyleBackColor = false;
            this.button_SI_Seleccionadas.Click += new System.EventHandler(this.button_SI_Seleccionadas_Click);
            // 
            // button_Marcar_Menor_1
            // 
            this.button_Marcar_Menor_1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button_Marcar_Menor_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Marcar_Menor_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Marcar_Menor_1.Location = new System.Drawing.Point(628, 3);
            this.button_Marcar_Menor_1.Name = "button_Marcar_Menor_1";
            this.button_Marcar_Menor_1.Size = new System.Drawing.Size(83, 65);
            this.button_Marcar_Menor_1.TabIndex = 23;
            this.button_Marcar_Menor_1.Text = "Marcar <1K";
            this.button_Marcar_Menor_1.UseVisualStyleBackColor = false;
            this.button_Marcar_Menor_1.Click += new System.EventHandler(this.button_Marcar_Menor_1_Click);
            // 
            // btnLISTAR
            // 
            this.btnLISTAR.BackColor = System.Drawing.Color.Beige;
            this.btnLISTAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLISTAR.Image = global::cercle17.Properties.Resources.printer21;
            this.btnLISTAR.Location = new System.Drawing.Point(144, 3);
            this.btnLISTAR.Name = "btnLISTAR";
            this.btnLISTAR.Size = new System.Drawing.Size(225, 65);
            this.btnLISTAR.TabIndex = 1;
            this.btnLISTAR.Text = "LISTAR CUADRE DIA";
            this.btnLISTAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLISTAR.UseVisualStyleBackColor = false;
            this.btnLISTAR.Click += new System.EventHandler(this.btnLISTAR_Click);
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(122, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // button_Si_Cuadre_Partida
            // 
            this.button_Si_Cuadre_Partida.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button_Si_Cuadre_Partida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Si_Cuadre_Partida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Si_Cuadre_Partida.Location = new System.Drawing.Point(527, 4);
            this.button_Si_Cuadre_Partida.Name = "button_Si_Cuadre_Partida";
            this.button_Si_Cuadre_Partida.Size = new System.Drawing.Size(95, 65);
            this.button_Si_Cuadre_Partida.TabIndex = 6;
            this.button_Si_Cuadre_Partida.Text = "CUADRAR PARTIDA";
            this.button_Si_Cuadre_Partida.UseVisualStyleBackColor = false;
            this.button_Si_Cuadre_Partida.Click += new System.EventHandler(this.button_Si_Cuadre_Partida_Click);
            // 
            // dG1
            // 
            this.dG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG1.Location = new System.Drawing.Point(12, 117);
            this.dG1.Name = "dG1";
            this.dG1.Size = new System.Drawing.Size(1050, 421);
            this.dG1.TabIndex = 5;
            this.dG1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dG1_CellContentClick);
            this.dG1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dG1_CellValueChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 85);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(129, 26);
            this.dtpFecha.TabIndex = 8;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // GBPB
            // 
            this.GBPB.Controls.Add(this.pB1);
            this.GBPB.Controls.Add(this.LPB);
            this.GBPB.Location = new System.Drawing.Point(25, 270);
            this.GBPB.Name = "GBPB";
            this.GBPB.Size = new System.Drawing.Size(1018, 108);
            this.GBPB.TabIndex = 9;
            this.GBPB.TabStop = false;
            this.GBPB.Visible = false;
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(6, 39);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(1006, 42);
            this.pB1.TabIndex = 1;
            // 
            // LPB
            // 
            this.LPB.AutoSize = true;
            this.LPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPB.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LPB.Location = new System.Drawing.Point(12, 16);
            this.LPB.Name = "LPB";
            this.LPB.Size = new System.Drawing.Size(51, 20);
            this.LPB.TabIndex = 0;
            this.LPB.Text = "label9";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 560);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Panel1.Controls.Add(this.LArtDes);
            this.splitContainer1.Panel1.Controls.Add(this.lProNom);
            this.splitContainer1.Panel1.Controls.Add(this.lArtCod);
            this.splitContainer1.Panel1.Controls.Add(this.lProCod);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tObservaciones);
            this.splitContainer1.Panel1.Controls.Add(this.lStock);
            this.splitContainer1.Panel1.Controls.Add(this.lStockInicial);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Khaki;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lPartida);
            this.splitContainer1.Panel2.Controls.Add(this.lAño);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.lAlmacen);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 150);
            this.splitContainer1.SplitterDistance = 850;
            this.splitContainer1.TabIndex = 10;
            // 
            // LArtDes
            // 
            this.LArtDes.AutoSize = true;
            this.LArtDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LArtDes.ForeColor = System.Drawing.Color.Gray;
            this.LArtDes.Location = new System.Drawing.Point(139, 19);
            this.LArtDes.Name = "LArtDes";
            this.LArtDes.Size = new System.Drawing.Size(56, 16);
            this.LArtDes.TabIndex = 39;
            this.LArtDes.Text = "LArtDes";
            // 
            // lProNom
            // 
            this.lProNom.AutoSize = true;
            this.lProNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProNom.ForeColor = System.Drawing.Color.Gray;
            this.lProNom.Location = new System.Drawing.Point(139, 35);
            this.lProNom.Name = "lProNom";
            this.lProNom.Size = new System.Drawing.Size(61, 16);
            this.lProNom.TabIndex = 38;
            this.lProNom.Text = "lProNom";
            // 
            // lArtCod
            // 
            this.lArtCod.AutoSize = true;
            this.lArtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lArtCod.ForeColor = System.Drawing.Color.Black;
            this.lArtCod.Location = new System.Drawing.Point(85, 19);
            this.lArtCod.Name = "lArtCod";
            this.lArtCod.Size = new System.Drawing.Size(59, 16);
            this.lArtCod.TabIndex = 37;
            this.lArtCod.Text = "lArtCod";
            this.lArtCod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lProCod
            // 
            this.lProCod.AutoSize = true;
            this.lProCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProCod.ForeColor = System.Drawing.Color.Black;
            this.lProCod.Location = new System.Drawing.Point(85, 35);
            this.lProCod.Name = "lProCod";
            this.lProCod.Size = new System.Drawing.Size(64, 16);
            this.lProCod.TabIndex = 36;
            this.lProCod.Text = "lProCod";
            this.lProCod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Artículo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Observaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(359, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Stock Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(359, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Stock";
            // 
            // tObservaciones
            // 
            this.tObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tObservaciones.Location = new System.Drawing.Point(15, 82);
            this.tObservaciones.MaxLength = 50;
            this.tObservaciones.Multiline = true;
            this.tObservaciones.Name = "tObservaciones";
            this.tObservaciones.Size = new System.Drawing.Size(805, 65);
            this.tObservaciones.TabIndex = 25;
            this.tObservaciones.Text = "tObservaciones";
            // 
            // lStock
            // 
            this.lStock.AutoSize = true;
            this.lStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lStock.Location = new System.Drawing.Point(463, 35);
            this.lStock.Name = "lStock";
            this.lStock.Size = new System.Drawing.Size(51, 16);
            this.lStock.TabIndex = 24;
            this.lStock.Text = "lStock";
            // 
            // lStockInicial
            // 
            this.lStockInicial.AutoSize = true;
            this.lStockInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lStockInicial.ForeColor = System.Drawing.Color.Black;
            this.lStockInicial.Location = new System.Drawing.Point(422, 19);
            this.lStockInicial.Name = "lStockInicial";
            this.lStockInicial.Size = new System.Drawing.Size(92, 16);
            this.lStockInicial.TabIndex = 23;
            this.lStockInicial.Text = "lStockInicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Partida/año";
            // 
            // lPartida
            // 
            this.lPartida.AutoSize = true;
            this.lPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPartida.ForeColor = System.Drawing.Color.Black;
            this.lPartida.Location = new System.Drawing.Point(78, 16);
            this.lPartida.Name = "lPartida";
            this.lPartida.Size = new System.Drawing.Size(62, 16);
            this.lPartida.TabIndex = 22;
            this.lPartida.Text = "lPartida";
            this.lPartida.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lAño
            // 
            this.lAño.AutoSize = true;
            this.lAño.Location = new System.Drawing.Point(155, 16);
            this.lAño.Name = "lAño";
            this.lAño.Size = new System.Drawing.Size(28, 13);
            this.lAño.TabIndex = 26;
            this.lAño.Text = "lAño";
            this.lAño.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(145, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Almacén";
            // 
            // lAlmacen
            // 
            this.lAlmacen.AutoSize = true;
            this.lAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAlmacen.ForeColor = System.Drawing.Color.Black;
            this.lAlmacen.Location = new System.Drawing.Point(61, 60);
            this.lAlmacen.Name = "lAlmacen";
            this.lAlmacen.Size = new System.Drawing.Size(72, 16);
            this.lAlmacen.TabIndex = 32;
            this.lAlmacen.Text = "lAlmacen";
            this.lAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmEmpr05_CUADRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1075, 722);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.GBPB);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dG1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpr05_CUADRE";
            this.Text = "frmEmpr05_CUADRE";
            this.Load += new System.EventHandler(this.frmEmpr05_CUADRE_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dG1)).EndInit();
            this.GBPB.ResumeLayout(false);
            this.GBPB.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_SI_Seleccionadas;
        private System.Windows.Forms.Button button_Marcar_Menor_1;
        private System.Windows.Forms.Button btnLISTAR;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button button_Si_Cuadre_Partida;
        private System.Windows.Forms.DataGridView dG1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox GBPB;
        private System.Windows.Forms.ProgressBar pB1;
        private System.Windows.Forms.Label LPB;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LArtDes;
        private System.Windows.Forms.Label lProNom;
        private System.Windows.Forms.Label lArtCod;
        private System.Windows.Forms.Label lProCod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tObservaciones;
        private System.Windows.Forms.Label lStock;
        private System.Windows.Forms.Label lStockInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lPartida;
        private System.Windows.Forms.Label lAño;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lAlmacen;
    }
}