namespace cercle17
{
    partial class frmMttoBARCOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMttoBARCOS));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Cerrar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.textBox_Proveedor = new System.Windows.Forms.TextBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.button_MismoBarco = new System.Windows.Forms.Button();
            this.button_MismoProv = new System.Windows.Forms.Button();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.textBox_ProCod = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Matricula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(699, 275);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrícula Barco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Barco";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.label_ID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 17);
            this.panel1.TabIndex = 3;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(34, -1);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(0, 16);
            this.label_ID.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.button_Cerrar);
            this.panel2.Controls.Add(this.button_Eliminar);
            this.panel2.Controls.Add(this.button_Cancelar);
            this.panel2.Controls.Add(this.textBox_Proveedor);
            this.panel2.Controls.Add(this.button_Buscar);
            this.panel2.Controls.Add(this.button_MismoBarco);
            this.panel2.Controls.Add(this.button_MismoProv);
            this.panel2.Controls.Add(this.button_Agregar);
            this.panel2.Controls.Add(this.textBox_ProCod);
            this.panel2.Controls.Add(this.textBox_Nombre);
            this.panel2.Controls.Add(this.textBox_Matricula);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 165);
            this.panel2.TabIndex = 4;
            // 
            // button_Cerrar
            // 
            this.button_Cerrar.Location = new System.Drawing.Point(652, 104);
            this.button_Cerrar.Name = "button_Cerrar";
            this.button_Cerrar.Size = new System.Drawing.Size(79, 51);
            this.button_Cerrar.TabIndex = 14;
            this.button_Cerrar.Text = "Cerrar";
            this.button_Cerrar.UseVisualStyleBackColor = true;
            this.button_Cerrar.Click += new System.EventHandler(this.button_Cerrar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(567, 104);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(79, 51);
            this.button_Eliminar.TabIndex = 13;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(482, 104);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(79, 51);
            this.button_Cancelar.TabIndex = 12;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // textBox_Proveedor
            // 
            this.textBox_Proveedor.Location = new System.Drawing.Point(254, 73);
            this.textBox_Proveedor.Name = "textBox_Proveedor";
            this.textBox_Proveedor.ReadOnly = true;
            this.textBox_Proveedor.Size = new System.Drawing.Size(250, 22);
            this.textBox_Proveedor.TabIndex = 11;
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(207, 70);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(41, 26);
            this.button_Buscar.TabIndex = 10;
            this.button_Buscar.Text = "...";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // button_MismoBarco
            // 
            this.button_MismoBarco.Location = new System.Drawing.Point(316, 104);
            this.button_MismoBarco.Name = "button_MismoBarco";
            this.button_MismoBarco.Size = new System.Drawing.Size(143, 51);
            this.button_MismoBarco.TabIndex = 9;
            this.button_MismoBarco.Text = "Agregar proveedor al mismo Barco";
            this.button_MismoBarco.UseVisualStyleBackColor = true;
            this.button_MismoBarco.Visible = false;
            this.button_MismoBarco.Click += new System.EventHandler(this.button_MismoBarco_Click);
            // 
            // button_MismoProv
            // 
            this.button_MismoProv.Location = new System.Drawing.Point(148, 104);
            this.button_MismoProv.Name = "button_MismoProv";
            this.button_MismoProv.Size = new System.Drawing.Size(143, 51);
            this.button_MismoProv.TabIndex = 8;
            this.button_MismoProv.Text = "Agregar Barco al mismo proveedor";
            this.button_MismoProv.UseVisualStyleBackColor = true;
            this.button_MismoProv.Visible = false;
            this.button_MismoProv.Click += new System.EventHandler(this.button_MismoProv_Click);
            // 
            // button_Agregar
            // 
            this.button_Agregar.Location = new System.Drawing.Point(20, 104);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(106, 51);
            this.button_Agregar.TabIndex = 7;
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // textBox_ProCod
            // 
            this.textBox_ProCod.Location = new System.Drawing.Point(148, 73);
            this.textBox_ProCod.Name = "textBox_ProCod";
            this.textBox_ProCod.Size = new System.Drawing.Size(53, 22);
            this.textBox_ProCod.TabIndex = 6;
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(148, 42);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(356, 22);
            this.textBox_Nombre.TabIndex = 5;
            // 
            // textBox_Matricula
            // 
            this.textBox_Matricula.Location = new System.Drawing.Point(148, 12);
            this.textBox_Matricula.Name = "textBox_Matricula";
            this.textBox_Matricula.Size = new System.Drawing.Size(166, 22);
            this.textBox_Matricula.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cod. Proveedor";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 275);
            this.panel3.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(20, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(699, 275);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(719, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 275);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 275);
            this.panel4.TabIndex = 0;
            // 
            // frmMttoBARCOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 457);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMttoBARCOS";
            this.Text = "    BARCOS";
            this.Load += new System.EventHandler(this.frmMttoBARCOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Matricula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ProCod;
        private System.Windows.Forms.Button button_MismoBarco;
        private System.Windows.Forms.Button button_MismoProv;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.TextBox textBox_Proveedor;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Button button_Cerrar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Cancelar;
    }
}