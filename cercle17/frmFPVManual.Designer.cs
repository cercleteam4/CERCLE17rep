namespace cercle17
{
    partial class frmFPVManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFPVManual));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Consulta = new System.Windows.Forms.Button();
            this.textBox_DetCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DetNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Albaranes = new System.Windows.Forms.Panel();
            this.dataGridView_Albaranes = new System.Windows.Forms.DataGridView();
            this.panel_Factura = new System.Windows.Forms.Panel();
            this.panel_report = new System.Windows.Forms.Panel();
            this.checkBox_Marcar = new System.Windows.Forms.CheckBox();
            this.button_Grabar = new System.Windows.Forms.Button();
            this.textBox_Importe = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Recargo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.comboBox_Serie = new System.Windows.Forms.ComboBox();
            this.textBox_Anyo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_Facturado = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel_Albaranes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).BeginInit();
            this.panel_Factura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Consulta);
            this.panel1.Controls.Add(this.textBox_DetCod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_DetNom);
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
            // textBox_DetCod
            // 
            this.textBox_DetCod.Location = new System.Drawing.Point(161, 10);
            this.textBox_DetCod.Name = "textBox_DetCod";
            this.textBox_DetCod.Size = new System.Drawing.Size(62, 20);
            this.textBox_DetCod.TabIndex = 1;
            this.textBox_DetCod.TextChanged += new System.EventHandler(this.textBox_DetCod_TextChanged);
            this.textBox_DetCod.Enter += new System.EventHandler(this.textBox_DetCod_Enter);
            this.textBox_DetCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DetCod_KeyPress);
            this.textBox_DetCod.Leave += new System.EventHandler(this.textBox_DetCod_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "CÓDIGO DETALLISTA :";
            // 
            // textBox_DetNom
            // 
            this.textBox_DetNom.Location = new System.Drawing.Point(389, 10);
            this.textBox_DetNom.Name = "textBox_DetNom";
            this.textBox_DetNom.ReadOnly = true;
            this.textBox_DetNom.Size = new System.Drawing.Size(288, 20);
            this.textBox_DetNom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DETALLISTA :";
            // 
            // panel_Albaranes
            // 
            this.panel_Albaranes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Albaranes.Controls.Add(this.dataGridView_Albaranes);
            this.panel_Albaranes.Location = new System.Drawing.Point(14, 142);
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
            // panel_Factura
            // 
            this.panel_Factura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Factura.Controls.Add(this.panel_report);
            this.panel_Factura.Controls.Add(this.checkBox_Marcar);
            this.panel_Factura.Controls.Add(this.button_Grabar);
            this.panel_Factura.Controls.Add(this.textBox_Importe);
            this.panel_Factura.Controls.Add(this.label12);
            this.panel_Factura.Controls.Add(this.textBox_Recargo);
            this.panel_Factura.Controls.Add(this.label11);
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
            this.panel_Factura.Controls.Add(this.comboBox_Serie);
            this.panel_Factura.Controls.Add(this.textBox_Anyo);
            this.panel_Factura.Controls.Add(this.label5);
            this.panel_Factura.Controls.Add(this.label4);
            this.panel_Factura.Controls.Add(this.label3);
            this.panel_Factura.Controls.Add(this.dataGridView_Facturado);
            this.panel_Factura.Location = new System.Drawing.Point(14, 332);
            this.panel_Factura.Name = "panel_Factura";
            this.panel_Factura.Size = new System.Drawing.Size(827, 257);
            this.panel_Factura.TabIndex = 2;
            // 
            // panel_report
            // 
            this.panel_report.Location = new System.Drawing.Point(509, 207);
            this.panel_report.Name = "panel_report";
            this.panel_report.Size = new System.Drawing.Size(73, 42);
            this.panel_report.TabIndex = 23;
            this.panel_report.Visible = false;
            // 
            // checkBox_Marcar
            // 
            this.checkBox_Marcar.AutoSize = true;
            this.checkBox_Marcar.Location = new System.Drawing.Point(14, 9);
            this.checkBox_Marcar.Name = "checkBox_Marcar";
            this.checkBox_Marcar.Size = new System.Drawing.Size(86, 18);
            this.checkBox_Marcar.TabIndex = 22;
            this.checkBox_Marcar.Text = "Marcar Todo";
            this.checkBox_Marcar.UseVisualStyleBackColor = true;
            this.checkBox_Marcar.CheckedChanged += new System.EventHandler(this.checkBox_Marcar_CheckedChanged);
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
            this.textBox_Importe.Location = new System.Drawing.Point(703, 10);
            this.textBox_Importe.Name = "textBox_Importe";
            this.textBox_Importe.ReadOnly = true;
            this.textBox_Importe.Size = new System.Drawing.Size(90, 20);
            this.textBox_Importe.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(633, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "IMPORTE :";
            // 
            // textBox_Recargo
            // 
            this.textBox_Recargo.Location = new System.Drawing.Point(560, 10);
            this.textBox_Recargo.Name = "textBox_Recargo";
            this.textBox_Recargo.ReadOnly = true;
            this.textBox_Recargo.Size = new System.Drawing.Size(56, 20);
            this.textBox_Recargo.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(490, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "RECARGO :";
            // 
            // textBox_IVA
            // 
            this.textBox_IVA.Location = new System.Drawing.Point(428, 10);
            this.textBox_IVA.Name = "textBox_IVA";
            this.textBox_IVA.ReadOnly = true;
            this.textBox_IVA.Size = new System.Drawing.Size(56, 20);
            this.textBox_IVA.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(391, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "IVA :";
            // 
            // textBox_BI
            // 
            this.textBox_BI.Location = new System.Drawing.Point(297, 9);
            this.textBox_BI.Name = "textBox_BI";
            this.textBox_BI.ReadOnly = true;
            this.textBox_BI.Size = new System.Drawing.Size(86, 20);
            this.textBox_BI.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "BI :";
            // 
            // textBox_TextoCabecera
            // 
            this.textBox_TextoCabecera.Location = new System.Drawing.Point(394, 39);
            this.textBox_TextoCabecera.Name = "textBox_TextoCabecera";
            this.textBox_TextoCabecera.Size = new System.Drawing.Size(399, 20);
            this.textBox_TextoCabecera.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(269, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "TEXTO CABECERA :";
            // 
            // textBox_TextoPie
            // 
            this.textBox_TextoPie.Location = new System.Drawing.Point(142, 230);
            this.textBox_TextoPie.Name = "textBox_TextoPie";
            this.textBox_TextoPie.Size = new System.Drawing.Size(310, 20);
            this.textBox_TextoPie.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "TEXTO PIE :";
            // 
            // textBox_Observaciones
            // 
            this.textBox_Observaciones.Location = new System.Drawing.Point(142, 207);
            this.textBox_Observaciones.Name = "textBox_Observaciones";
            this.textBox_Observaciones.Size = new System.Drawing.Size(310, 20);
            this.textBox_Observaciones.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "OBSERVACIONES :";
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
            this.comboBox_Serie.Location = new System.Drawing.Point(182, 36);
            this.comboBox_Serie.Name = "comboBox_Serie";
            this.comboBox_Serie.Size = new System.Drawing.Size(72, 22);
            this.comboBox_Serie.TabIndex = 6;
            // 
            // textBox_Anyo
            // 
            this.textBox_Anyo.Location = new System.Drawing.Point(63, 36);
            this.textBox_Anyo.Name = "textBox_Anyo";
            this.textBox_Anyo.ReadOnly = true;
            this.textBox_Anyo.Size = new System.Drawing.Size(56, 20);
            this.textBox_Anyo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "SERIE :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "AÑO :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "FACTURA :";
            // 
            // dataGridView_Facturado
            // 
            this.dataGridView_Facturado.AllowUserToAddRows = false;
            this.dataGridView_Facturado.AllowUserToDeleteRows = false;
            this.dataGridView_Facturado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Facturado.Location = new System.Drawing.Point(24, 66);
            this.dataGridView_Facturado.Name = "dataGridView_Facturado";
            this.dataGridView_Facturado.ReadOnly = true;
            this.dataGridView_Facturado.RowHeadersVisible = false;
            this.dataGridView_Facturado.Size = new System.Drawing.Size(769, 135);
            this.dataGridView_Facturado.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnSALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 73);
            this.panel2.TabIndex = 4;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
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
            // frmFPVManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(853, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Factura);
            this.Controls.Add(this.panel_Albaranes);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFPVManual";
            this.Text = "    Facturación Ventas Manual";
            this.Load += new System.EventHandler(this.frmFPVManual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Albaranes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Albaranes)).EndInit();
            this.panel_Factura.ResumeLayout(false);
            this.panel_Factura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Facturado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_DetCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DetNom;
        private System.Windows.Forms.Button button_Consulta;
        private System.Windows.Forms.Panel panel_Albaranes;
        private System.Windows.Forms.DataGridView dataGridView_Albaranes;
        private System.Windows.Forms.Panel panel_Factura;
        private System.Windows.Forms.ComboBox comboBox_Serie;
        private System.Windows.Forms.TextBox textBox_Anyo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.TextBox textBox_Recargo;
        private System.Windows.Forms.Label label11;
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
    }
}