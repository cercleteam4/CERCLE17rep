namespace cercle17
{
    partial class frmFCProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFCProveedor));
            this.panelFec = new System.Windows.Forms.Panel();
            this.lFechaIni = new System.Windows.Forms.Label();
            this.lFechaFin = new System.Windows.Forms.Label();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panelDet = new System.Windows.Forms.Panel();
            this.checkTodosProv = new System.Windows.Forms.CheckBox();
            this.llblProvIni = new System.Windows.Forms.LinkLabel();
            this.lProvIni = new System.Windows.Forms.Label();
            this.tProvIni = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_ComAlbLineas = new System.Windows.Forms.DataGridView();
            this.ComLpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLnl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_ComAlb = new System.Windows.Forms.DataGridView();
            this.ComLpa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anyo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Facturado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label_importes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Facturar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Salir = new System.Windows.Forms.Button();
            this.label_Importes_Sel = new System.Windows.Forms.Label();
            this.panelFec.SuspendLayout();
            this.panelDet.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ComAlbLineas)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ComAlb)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFec
            // 
            this.panelFec.BackColor = System.Drawing.Color.Lavender;
            this.panelFec.Controls.Add(this.lFechaIni);
            this.panelFec.Controls.Add(this.lFechaFin);
            this.panelFec.Controls.Add(this.dateTimePicker_Fin);
            this.panelFec.Controls.Add(this.dateTimePicker_Inicio);
            this.panelFec.Location = new System.Drawing.Point(12, 79);
            this.panelFec.Name = "panelFec";
            this.panelFec.Size = new System.Drawing.Size(170, 83);
            this.panelFec.TabIndex = 5;
            // 
            // lFechaIni
            // 
            this.lFechaIni.AutoSize = true;
            this.lFechaIni.Location = new System.Drawing.Point(13, 16);
            this.lFechaIni.Name = "lFechaIni";
            this.lFechaIni.Size = new System.Drawing.Size(38, 13);
            this.lFechaIni.TabIndex = 7;
            this.lFechaIni.Text = "Desde";
            // 
            // lFechaFin
            // 
            this.lFechaFin.AutoSize = true;
            this.lFechaFin.Location = new System.Drawing.Point(13, 49);
            this.lFechaFin.Name = "lFechaFin";
            this.lFechaFin.Size = new System.Drawing.Size(35, 13);
            this.lFechaFin.TabIndex = 4;
            this.lFechaFin.Text = "Hasta";
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(64, 46);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 1;
            this.dateTimePicker_Fin.ValueChanged += new System.EventHandler(this.dateTimePicker_Fin_ValueChanged);
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(64, 13);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // panelDet
            // 
            this.panelDet.BackColor = System.Drawing.Color.Lavender;
            this.panelDet.Controls.Add(this.checkTodosProv);
            this.panelDet.Controls.Add(this.llblProvIni);
            this.panelDet.Controls.Add(this.lProvIni);
            this.panelDet.Controls.Add(this.tProvIni);
            this.panelDet.Location = new System.Drawing.Point(200, 79);
            this.panelDet.Name = "panelDet";
            this.panelDet.Size = new System.Drawing.Size(375, 83);
            this.panelDet.TabIndex = 6;
            // 
            // checkTodosProv
            // 
            this.checkTodosProv.AutoSize = true;
            this.checkTodosProv.Location = new System.Drawing.Point(85, 49);
            this.checkTodosProv.Name = "checkTodosProv";
            this.checkTodosProv.Size = new System.Drawing.Size(157, 17);
            this.checkTodosProv.TabIndex = 10;
            this.checkTodosProv.Text = "Todos los PROVEEDORES";
            this.checkTodosProv.UseVisualStyleBackColor = true;
            this.checkTodosProv.CheckedChanged += new System.EventHandler(this.checkTodosProv_CheckedChanged);
            // 
            // llblProvIni
            // 
            this.llblProvIni.AutoSize = true;
            this.llblProvIni.Location = new System.Drawing.Point(17, 16);
            this.llblProvIni.Name = "llblProvIni";
            this.llblProvIni.Size = new System.Drawing.Size(56, 13);
            this.llblProvIni.TabIndex = 9;
            this.llblProvIni.TabStop = true;
            this.llblProvIni.Text = "Proveedor";
            this.llblProvIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblProvIni_LinkClicked);
            // 
            // lProvIni
            // 
            this.lProvIni.AutoSize = true;
            this.lProvIni.Location = new System.Drawing.Point(139, 18);
            this.lProvIni.Name = "lProvIni";
            this.lProvIni.Size = new System.Drawing.Size(0, 13);
            this.lProvIni.TabIndex = 2;
            // 
            // tProvIni
            // 
            this.tProvIni.Location = new System.Drawing.Point(85, 13);
            this.tProvIni.Name = "tProvIni";
            this.tProvIni.Size = new System.Drawing.Size(54, 20);
            this.tProvIni.TabIndex = 0;
            this.tProvIni.TextChanged += new System.EventHandler(this.tProvIni_TextChanged);
            this.tProvIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tProvIni_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_ComAlbLineas);
            this.panel1.Location = new System.Drawing.Point(12, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 502);
            this.panel1.TabIndex = 8;
            // 
            // dataGridView_ComAlbLineas
            // 
            this.dataGridView_ComAlbLineas.AllowUserToAddRows = false;
            this.dataGridView_ComAlbLineas.AllowUserToDeleteRows = false;
            this.dataGridView_ComAlbLineas.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView_ComAlbLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ComAlbLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComLpa,
            this.ComLnl,
            this.comcfa,
            this.ArtDes,
            this.ComLca,
            this.ComLki,
            this.ComLpr,
            this.ComLim});
            this.dataGridView_ComAlbLineas.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ComAlbLineas.MultiSelect = false;
            this.dataGridView_ComAlbLineas.Name = "dataGridView_ComAlbLineas";
            this.dataGridView_ComAlbLineas.ReadOnly = true;
            this.dataGridView_ComAlbLineas.RowHeadersVisible = false;
            this.dataGridView_ComAlbLineas.Size = new System.Drawing.Size(652, 502);
            this.dataGridView_ComAlbLineas.TabIndex = 2;
            // 
            // ComLpa
            // 
            this.ComLpa.DataPropertyName = "ComLpa";
            this.ComLpa.HeaderText = "Albarán";
            this.ComLpa.Name = "ComLpa";
            this.ComLpa.ReadOnly = true;
            this.ComLpa.Width = 80;
            // 
            // ComLnl
            // 
            this.ComLnl.DataPropertyName = "ComLnl";
            this.ComLnl.HeaderText = "Línea";
            this.ComLnl.Name = "ComLnl";
            this.ComLnl.ReadOnly = true;
            this.ComLnl.Width = 45;
            // 
            // comcfa
            // 
            this.comcfa.DataPropertyName = "comcfa";
            this.comcfa.HeaderText = "Fecha";
            this.comcfa.Name = "comcfa";
            this.comcfa.ReadOnly = true;
            // 
            // ArtDes
            // 
            this.ArtDes.DataPropertyName = "ArtDes";
            this.ArtDes.HeaderText = "Artículo";
            this.ArtDes.Name = "ArtDes";
            this.ArtDes.ReadOnly = true;
            this.ArtDes.Width = 205;
            // 
            // ComLca
            // 
            this.ComLca.DataPropertyName = "ComLca";
            this.ComLca.HeaderText = "Cajas";
            this.ComLca.Name = "ComLca";
            this.ComLca.ReadOnly = true;
            this.ComLca.Width = 40;
            // 
            // ComLki
            // 
            this.ComLki.DataPropertyName = "ComLki";
            this.ComLki.HeaderText = "Kilos";
            this.ComLki.Name = "ComLki";
            this.ComLki.ReadOnly = true;
            this.ComLki.Width = 80;
            // 
            // ComLpr
            // 
            this.ComLpr.DataPropertyName = "ComLpr";
            this.ComLpr.HeaderText = "Precio";
            this.ComLpr.Name = "ComLpr";
            this.ComLpr.ReadOnly = true;
            this.ComLpr.Width = 80;
            // 
            // ComLim
            // 
            this.ComLim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ComLim.DataPropertyName = "ComLim";
            this.ComLim.HeaderText = "Importe";
            this.ComLim.Name = "ComLim";
            this.ComLim.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_ComAlb);
            this.panel2.Location = new System.Drawing.Point(724, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 502);
            this.panel2.TabIndex = 10;
            // 
            // dataGridView_ComAlb
            // 
            this.dataGridView_ComAlb.AllowUserToAddRows = false;
            this.dataGridView_ComAlb.AllowUserToDeleteRows = false;
            this.dataGridView_ComAlb.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView_ComAlb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ComAlb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComLpa1,
            this.Anyo1,
            this.Facturado});
            this.dataGridView_ComAlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ComAlb.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ComAlb.MultiSelect = false;
            this.dataGridView_ComAlb.Name = "dataGridView_ComAlb";
            this.dataGridView_ComAlb.ReadOnly = true;
            this.dataGridView_ComAlb.RowHeadersVisible = false;
            this.dataGridView_ComAlb.Size = new System.Drawing.Size(197, 502);
            this.dataGridView_ComAlb.TabIndex = 2;
            this.dataGridView_ComAlb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ComAlb_CellClick);
            this.dataGridView_ComAlb.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ComAlb_CellContentClick);
            // 
            // ComLpa1
            // 
            this.ComLpa1.DataPropertyName = "ComLpa";
            this.ComLpa1.HeaderText = "Albarán";
            this.ComLpa1.Name = "ComLpa1";
            this.ComLpa1.ReadOnly = true;
            this.ComLpa1.Width = 80;
            // 
            // Anyo1
            // 
            this.Anyo1.DataPropertyName = "Anyo";
            this.Anyo1.HeaderText = "Año";
            this.Anyo1.Name = "Anyo1";
            this.Anyo1.ReadOnly = true;
            this.Anyo1.Width = 50;
            // 
            // Facturado
            // 
            this.Facturado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Facturado.DataPropertyName = "Facturado";
            this.Facturado.HeaderText = "Facturar";
            this.Facturado.Name = "Facturado";
            this.Facturado.ReadOnly = true;
            this.Facturado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label_importes
            // 
            this.label_importes.AutoSize = true;
            this.label_importes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_importes.Location = new System.Drawing.Point(606, 699);
            this.label_importes.Name = "label_importes";
            this.label_importes.Size = new System.Drawing.Size(16, 17);
            this.label_importes.TabIndex = 12;
            this.label_importes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 699);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total Importe :";
            // 
            // button_Facturar
            // 
            this.button_Facturar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Facturar.Location = new System.Drawing.Point(724, 681);
            this.button_Facturar.Name = "button_Facturar";
            this.button_Facturar.Size = new System.Drawing.Size(197, 46);
            this.button_Facturar.TabIndex = 13;
            this.button_Facturar.Text = "FACTURAR";
            this.button_Facturar.UseVisualStyleBackColor = true;
            this.button_Facturar.Click += new System.EventHandler(this.button_Facturar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.button_Salir);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(956, 73);
            this.panel4.TabIndex = 14;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = ((System.Drawing.Image)(resources.GetObject("button_Salir.Image")));
            this.button_Salir.Location = new System.Drawing.Point(12, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(130, 67);
            this.button_Salir.TabIndex = 8;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click_1);
            // 
            // label_Importes_Sel
            // 
            this.label_Importes_Sel.AutoSize = true;
            this.label_Importes_Sel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Importes_Sel.ForeColor = System.Drawing.Color.Blue;
            this.label_Importes_Sel.Location = new System.Drawing.Point(606, 681);
            this.label_Importes_Sel.Name = "label_Importes_Sel";
            this.label_Importes_Sel.Size = new System.Drawing.Size(17, 18);
            this.label_Importes_Sel.TabIndex = 15;
            this.label_Importes_Sel.Text = "0";
            // 
            // frmFCProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(956, 730);
            this.Controls.Add(this.label_Importes_Sel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button_Facturar);
            this.Controls.Add(this.label_importes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDet);
            this.Controls.Add(this.panelFec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFCProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFCProveedor_FormClosing);
            this.Load += new System.EventHandler(this.frmFCProveedor_Load);
            this.SizeChanged += new System.EventHandler(this.frmFCProveedor_SizeChanged);
            this.panelFec.ResumeLayout(false);
            this.panelFec.PerformLayout();
            this.panelDet.ResumeLayout(false);
            this.panelDet.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ComAlbLineas)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ComAlb)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFec;
        private System.Windows.Forms.Label lFechaIni;
        private System.Windows.Forms.Label lFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Panel panelDet;
        private System.Windows.Forms.Label lProvIni;
        private System.Windows.Forms.TextBox tProvIni;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_ComAlbLineas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_ComAlb;
        private System.Windows.Forms.Label label_importes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Facturar;
        private System.Windows.Forms.LinkLabel llblProvIni;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.CheckBox checkTodosProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLpa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anyo1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Facturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn comcfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLca;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLki;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComLim;
        private System.Windows.Forms.Label label_Importes_Sel;
    }
}