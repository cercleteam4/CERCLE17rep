namespace cercle17
{
    partial class frmCOMPRAS_Ver_Albs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCOMPRAS_Ver_Albs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Listar_Albaranes_Separ = new System.Windows.Forms.Button();
            this.btn_Listar_Albaranes = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_ProCod = new System.Windows.Forms.TextBox();
            this.checkBox_Fecha = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgVC = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btn_Listar_Albaranes_Separ);
            this.panel1.Controls.Add(this.btn_Listar_Albaranes);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 76);
            this.panel1.TabIndex = 3;
            // 
            // btn_Listar_Albaranes_Separ
            // 
            this.btn_Listar_Albaranes_Separ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Listar_Albaranes_Separ.Location = new System.Drawing.Point(299, 4);
            this.btn_Listar_Albaranes_Separ.Name = "btn_Listar_Albaranes_Separ";
            this.btn_Listar_Albaranes_Separ.Size = new System.Drawing.Size(144, 67);
            this.btn_Listar_Albaranes_Separ.TabIndex = 2;
            this.btn_Listar_Albaranes_Separ.Text = "LISTAR ALBARANES HOJAS SEPARADAS";
            this.btn_Listar_Albaranes_Separ.UseVisualStyleBackColor = true;
            this.btn_Listar_Albaranes_Separ.Click += new System.EventHandler(this.btn_Listar_Albaranes_Separ_Click);
            // 
            // btn_Listar_Albaranes
            // 
            this.btn_Listar_Albaranes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Listar_Albaranes.Location = new System.Drawing.Point(147, 4);
            this.btn_Listar_Albaranes.Name = "btn_Listar_Albaranes";
            this.btn_Listar_Albaranes.Size = new System.Drawing.Size(146, 68);
            this.btn_Listar_Albaranes.TabIndex = 1;
            this.btn_Listar_Albaranes.Text = "LISTAR ALBARANES AGRUPADOS";
            this.btn_Listar_Albaranes.UseVisualStyleBackColor = true;
            this.btn_Listar_Albaranes.Click += new System.EventHandler(this.btn_Listar_Albaranes_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(3, 4);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(138, 70);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_ProCod);
            this.panel2.Controls.Add(this.checkBox_Fecha);
            this.panel2.Controls.Add(this.dateTimePicker_Fin);
            this.panel2.Controls.Add(this.dateTimePicker_Inicio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 82);
            this.panel2.TabIndex = 4;
            // 
            // tb_ProCod
            // 
            this.tb_ProCod.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tb_ProCod.Location = new System.Drawing.Point(220, 43);
            this.tb_ProCod.Name = "tb_ProCod";
            this.tb_ProCod.Size = new System.Drawing.Size(119, 20);
            this.tb_ProCod.TabIndex = 7;
            this.tb_ProCod.Text = "Cod_Proveedor";
            this.tb_ProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ProCod_KeyPress);
            // 
            // checkBox_Fecha
            // 
            this.checkBox_Fecha.AutoSize = true;
            this.checkBox_Fecha.Location = new System.Drawing.Point(18, 19);
            this.checkBox_Fecha.Name = "checkBox_Fecha";
            this.checkBox_Fecha.Size = new System.Drawing.Size(57, 17);
            this.checkBox_Fecha.TabIndex = 6;
            this.checkBox_Fecha.Text = "Desde";
            this.checkBox_Fecha.UseVisualStyleBackColor = true;
            this.checkBox_Fecha.CheckedChanged += new System.EventHandler(this.checkBox_Fecha_CheckedChanged);
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(81, 43);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 5;
            this.dateTimePicker_Fin.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(81, 17);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 4;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(979, 56);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(917, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(62, 404);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 158);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(71, 404);
            this.panel5.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgVC);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(71, 158);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(846, 404);
            this.panel6.TabIndex = 8;
            // 
            // dgVC
            // 
            this.dgVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVC.Location = new System.Drawing.Point(19, 51);
            this.dgVC.Name = "dgVC";
            this.dgVC.Size = new System.Drawing.Size(821, 329);
            this.dgVC.TabIndex = 0;
            // 
            // frmCOMPRAS_Ver_Albs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(979, 618);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCOMPRAS_Ver_Albs";
            this.Text = "frmCOMPRAS_Ver_Albs";
            this.Load += new System.EventHandler(this.frmCOMPRAS_Ver_Albs_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgVC;
        private System.Windows.Forms.CheckBox checkBox_Fecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.TextBox tb_ProCod;
        private System.Windows.Forms.Button btn_Listar_Albaranes;
        private System.Windows.Forms.Button btn_Listar_Albaranes_Separ;
    }
}