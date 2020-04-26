namespace cercle17
{
    partial class frmMttoDETALLISTAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMttoDETALLISTAS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_ID = new System.Windows.Forms.Label();
            this.panel_Datos = new System.Windows.Forms.Panel();
            this.label_DetCod = new System.Windows.Forms.Label();
            this.textBox_DetCod = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.comboBox_DetRec = new System.Windows.Forms.ComboBox();
            this.textBox_DetNom = new System.Windows.Forms.TextBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label_DetRec = new System.Windows.Forms.Label();
            this.label_DetNom = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_grid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel_Datos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.label_ID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 17);
            this.panel1.TabIndex = 0;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(34, -1);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(0, 15);
            this.label_ID.TabIndex = 9;
            // 
            // panel_Datos
            // 
            this.panel_Datos.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel_Datos.Controls.Add(this.label_DetCod);
            this.panel_Datos.Controls.Add(this.textBox_DetCod);
            this.panel_Datos.Controls.Add(this.button_Cancelar);
            this.panel_Datos.Controls.Add(this.comboBox_DetRec);
            this.panel_Datos.Controls.Add(this.textBox_DetNom);
            this.panel_Datos.Controls.Add(this.button_Aceptar);
            this.panel_Datos.Controls.Add(this.label_DetRec);
            this.panel_Datos.Controls.Add(this.label_DetNom);
            this.panel_Datos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Datos.Location = new System.Drawing.Point(0, 317);
            this.panel_Datos.Name = "panel_Datos";
            this.panel_Datos.Size = new System.Drawing.Size(783, 140);
            this.panel_Datos.TabIndex = 1;
            // 
            // label_DetCod
            // 
            this.label_DetCod.AutoSize = true;
            this.label_DetCod.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DetCod.Location = new System.Drawing.Point(19, 16);
            this.label_DetCod.Name = "label_DetCod";
            this.label_DetCod.Size = new System.Drawing.Size(52, 15);
            this.label_DetCod.TabIndex = 12;
            this.label_DetCod.Text = "Código :";
            // 
            // textBox_DetCod
            // 
            this.textBox_DetCod.Location = new System.Drawing.Point(83, 13);
            this.textBox_DetCod.Name = "textBox_DetCod";
            this.textBox_DetCod.Size = new System.Drawing.Size(90, 21);
            this.textBox_DetCod.TabIndex = 11;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(653, 13);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(108, 35);
            this.button_Cancelar.TabIndex = 10;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // comboBox_DetRec
            // 
            this.comboBox_DetRec.FormattingEnabled = true;
            this.comboBox_DetRec.Items.AddRange(new object[] {
            "I",
            "N",
            "S"});
            this.comboBox_DetRec.Location = new System.Drawing.Point(83, 73);
            this.comboBox_DetRec.Name = "comboBox_DetRec";
            this.comboBox_DetRec.Size = new System.Drawing.Size(90, 23);
            this.comboBox_DetRec.TabIndex = 7;
            // 
            // textBox_DetNom
            // 
            this.textBox_DetNom.Location = new System.Drawing.Point(83, 43);
            this.textBox_DetNom.Name = "textBox_DetNom";
            this.textBox_DetNom.Size = new System.Drawing.Size(426, 21);
            this.textBox_DetNom.TabIndex = 5;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(529, 13);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(108, 35);
            this.button_Aceptar.TabIndex = 4;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label_DetRec
            // 
            this.label_DetRec.AutoSize = true;
            this.label_DetRec.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DetRec.Location = new System.Drawing.Point(34, 76);
            this.label_DetRec.Name = "label_DetRec";
            this.label_DetRec.Size = new System.Drawing.Size(37, 15);
            this.label_DetRec.TabIndex = 2;
            this.label_DetRec.Text = "Tipo :";
            // 
            // label_DetNom
            // 
            this.label_DetNom.AutoSize = true;
            this.label_DetNom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DetNom.Location = new System.Drawing.Point(19, 45);
            this.label_DetNom.Name = "label_DetNom";
            this.label_DetNom.Size = new System.Drawing.Size(58, 15);
            this.label_DetNom.TabIndex = 0;
            this.label_DetNom.Text = "Nombre :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel_grid);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(783, 300);
            this.panel3.TabIndex = 2;
            // 
            // panel_grid
            // 
            this.panel_grid.Controls.Add(this.dataGridView1);
            this.panel_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_grid.Location = new System.Drawing.Point(22, 0);
            this.panel_grid.Name = "panel_grid";
            this.panel_grid.Size = new System.Drawing.Size(739, 300);
            this.panel_grid.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(761, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 300);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(22, 300);
            this.panel4.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmMttoDETALLISTAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 457);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_Datos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMttoDETALLISTAS";
            this.Text = "    DETALLISTAS";
            this.Load += new System.EventHandler(this.frmMttoDETALLISTAS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Datos.ResumeLayout(false);
            this.panel_Datos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel_grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Datos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel_grid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Label label_DetRec;
        private System.Windows.Forms.Label label_DetNom;
        private System.Windows.Forms.ComboBox comboBox_DetRec;
        private System.Windows.Forms.TextBox textBox_DetNom;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_DetCod;
        private System.Windows.Forms.TextBox textBox_DetCod;
    }
}