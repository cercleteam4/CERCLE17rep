namespace cercle17
{
    partial class FormConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsulta));
            this.textBox_Pronom = new System.Windows.Forms.TextBox();
            this.textBox_ProCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Salir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Pronom
            // 
            this.textBox_Pronom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pronom.Location = new System.Drawing.Point(202, 11);
            this.textBox_Pronom.Name = "textBox_Pronom";
            this.textBox_Pronom.Size = new System.Drawing.Size(439, 22);
            this.textBox_Pronom.TabIndex = 12;
            this.textBox_Pronom.TextChanged += new System.EventHandler(this.textBox_Pronom_TextChanged);
            this.textBox_Pronom.Enter += new System.EventHandler(this.textBox_Pronom_Enter);
            // 
            // textBox_ProCod
            // 
            this.textBox_ProCod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ProCod.Location = new System.Drawing.Point(203, 46);
            this.textBox_ProCod.Name = "textBox_ProCod";
            this.textBox_ProCod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ProCod.Size = new System.Drawing.Size(62, 22);
            this.textBox_ProCod.TabIndex = 11;
            this.textBox_ProCod.Enter += new System.EventHandler(this.textBox_ProCod_Enter);
            this.textBox_ProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ProCod_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Código Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre Proveedor";
            // 
            // button_Salir
            // 
            this.button_Salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(562, 236);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(154, 67);
            this.button_Salir.TabIndex = 34;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(562, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 67);
            this.button1.TabIndex = 35;
            this.button1.Text = "SELECCIONAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_ProCod);
            this.panel1.Controls.Add(this.textBox_Pronom);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 90);
            this.panel1.TabIndex = 36;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 114);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(500, 269);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // FormConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(730, 438);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Salir);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsulta";
            this.Text = "    CONSULTA DE PROVEEDORES";
            this.Load += new System.EventHandler(this.FormConsulta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Pronom;
        private System.Windows.Forms.TextBox textBox_ProCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}