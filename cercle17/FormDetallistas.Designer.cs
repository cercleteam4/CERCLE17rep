namespace cercle17
{
    partial class FormDetallistas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DetCod = new System.Windows.Forms.TextBox();
            this.textBox_DetNom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 116);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(500, 269);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_DetCod);
            this.panel1.Controls.Add(this.textBox_DetNom);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 90);
            this.panel1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nombre Detallista";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Código Detallista";
            // 
            // textBox_DetCod
            // 
            this.textBox_DetCod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DetCod.Location = new System.Drawing.Point(203, 46);
            this.textBox_DetCod.Name = "textBox_DetCod";
            this.textBox_DetCod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_DetCod.Size = new System.Drawing.Size(62, 22);
            this.textBox_DetCod.TabIndex = 11;
            this.textBox_DetCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DetCod_KeyPress);
            this.textBox_DetCod.Enter += new System.EventHandler(this.textBox_DetCod_Enter);
            // 
            // textBox_DetNom
            // 
            this.textBox_DetNom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DetNom.Location = new System.Drawing.Point(202, 11);
            this.textBox_DetNom.Name = "textBox_DetNom";
            this.textBox_DetNom.Size = new System.Drawing.Size(439, 22);
            this.textBox_DetNom.TabIndex = 12;
            this.textBox_DetNom.TextChanged += new System.EventHandler(this.textBox_DetNom_TextChanged);
            this.textBox_DetNom.Enter += new System.EventHandler(this.textBox_DetNom_Enter);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(562, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 67);
            this.button1.TabIndex = 39;
            this.button1.Text = "SELECCIONAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Salir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Location = new System.Drawing.Point(562, 238);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(154, 67);
            this.button_Salir.TabIndex = 38;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.UseVisualStyleBackColor = true;
            // 
            // FormDetallistas
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
            this.Name = "FormDetallistas";
            this.Text = "    CONSULTA DE DETALLISTAS";
            this.Load += new System.EventHandler(this.FormDetallistas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_DetCod;
        private System.Windows.Forms.TextBox textBox_DetNom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Salir;
    }
}