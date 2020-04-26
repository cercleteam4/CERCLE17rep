namespace cercle17
{
    partial class frmCONSULTA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCONSULTA));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Codigo = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Codigo);
            this.panel1.Controls.Add(this.textBox_Nombre);
            this.panel1.Location = new System.Drawing.Point(22, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 90);
            this.panel1.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre Proveedor";
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
            // textBox_Codigo
            // 
            this.textBox_Codigo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Codigo.Location = new System.Drawing.Point(203, 46);
            this.textBox_Codigo.Name = "textBox_Codigo";
            this.textBox_Codigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Codigo.Size = new System.Drawing.Size(62, 22);
            this.textBox_Codigo.TabIndex = 12;
            this.textBox_Codigo.TextChanged += new System.EventHandler(this.textBox_Codigo_TextChanged_1);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nombre.Location = new System.Drawing.Point(202, 11);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(439, 22);
            this.textBox_Nombre.TabIndex = 11;
            this.textBox_Nombre.TextChanged += new System.EventHandler(this.textBox_Nombre_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 219);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(678, 440);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(172, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 67);
            this.button1.TabIndex = 39;
            this.button1.Text = "SELECCIONAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button_Salir);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 75);
            this.panel2.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(577, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 67);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // button_Salir
            // 
            this.button_Salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Location = new System.Drawing.Point(12, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(154, 67);
            this.button_Salir.TabIndex = 40;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.UseVisualStyleBackColor = true;
            // 
            // frmCONSULTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(712, 689);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCONSULTA";
            this.Load += new System.EventHandler(this.frmCONSULTA_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Codigo;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}