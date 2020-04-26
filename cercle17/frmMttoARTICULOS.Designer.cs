namespace cercle17
{
    partial class frmMttoARTICULOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMttoARTICULOS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.label_ID = new System.Windows.Forms.Label();
            this.panel_Datos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Tipo2 = new System.Windows.Forms.ComboBox();
            this.label_ArtCod = new System.Windows.Forms.Label();
            this.textBox_ArtCod = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.comboBox_Tipo1 = new System.Windows.Forms.ComboBox();
            this.textBox_ArtDes = new System.Windows.Forms.TextBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label_Tipo1 = new System.Windows.Forms.Label();
            this.label_ArtDes = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_grid = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ckbEtiquetaObligatoria = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_Datos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label_ID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 85);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.btnSALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 71);
            this.panel2.TabIndex = 10;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(148, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
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
            this.panel_Datos.Controls.Add(this.label2);
            this.panel_Datos.Controls.Add(this.ckbEtiquetaObligatoria);
            this.panel_Datos.Controls.Add(this.label1);
            this.panel_Datos.Controls.Add(this.comboBox_Tipo2);
            this.panel_Datos.Controls.Add(this.label_ArtCod);
            this.panel_Datos.Controls.Add(this.textBox_ArtCod);
            this.panel_Datos.Controls.Add(this.button_Cancelar);
            this.panel_Datos.Controls.Add(this.comboBox_Tipo1);
            this.panel_Datos.Controls.Add(this.textBox_ArtDes);
            this.panel_Datos.Controls.Add(this.button_Aceptar);
            this.panel_Datos.Controls.Add(this.label_Tipo1);
            this.panel_Datos.Controls.Add(this.label_ArtDes);
            this.panel_Datos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Datos.Location = new System.Drawing.Point(0, 402);
            this.panel_Datos.Name = "panel_Datos";
            this.panel_Datos.Size = new System.Drawing.Size(783, 170);
            this.panel_Datos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Crz./Salv :";
            // 
            // comboBox_Tipo2
            // 
            this.comboBox_Tipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo2.FormattingEnabled = true;
            this.comboBox_Tipo2.Location = new System.Drawing.Point(104, 102);
            this.comboBox_Tipo2.Name = "comboBox_Tipo2";
            this.comboBox_Tipo2.Size = new System.Drawing.Size(99, 23);
            this.comboBox_Tipo2.TabIndex = 15;
            // 
            // label_ArtCod
            // 
            this.label_ArtCod.AutoSize = true;
            this.label_ArtCod.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ArtCod.Location = new System.Drawing.Point(25, 16);
            this.label_ArtCod.Name = "label_ArtCod";
            this.label_ArtCod.Size = new System.Drawing.Size(52, 15);
            this.label_ArtCod.TabIndex = 5;
            this.label_ArtCod.Text = "Código :";
            // 
            // textBox_ArtCod
            // 
            this.textBox_ArtCod.Location = new System.Drawing.Point(104, 13);
            this.textBox_ArtCod.Name = "textBox_ArtCod";
            this.textBox_ArtCod.Size = new System.Drawing.Size(99, 21);
            this.textBox_ArtCod.TabIndex = 11;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(653, 113);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(108, 35);
            this.button_Cancelar.TabIndex = 10;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // comboBox_Tipo1
            // 
            this.comboBox_Tipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo1.FormattingEnabled = true;
            this.comboBox_Tipo1.Location = new System.Drawing.Point(104, 71);
            this.comboBox_Tipo1.Name = "comboBox_Tipo1";
            this.comboBox_Tipo1.Size = new System.Drawing.Size(99, 23);
            this.comboBox_Tipo1.TabIndex = 13;
            // 
            // textBox_ArtDes
            // 
            this.textBox_ArtDes.Location = new System.Drawing.Point(104, 42);
            this.textBox_ArtDes.Name = "textBox_ArtDes";
            this.textBox_ArtDes.Size = new System.Drawing.Size(426, 21);
            this.textBox_ArtDes.TabIndex = 12;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(539, 114);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(108, 35);
            this.button_Aceptar.TabIndex = 14;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label_Tipo1
            // 
            this.label_Tipo1.AutoSize = true;
            this.label_Tipo1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tipo1.Location = new System.Drawing.Point(25, 74);
            this.label_Tipo1.Name = "label_Tipo1";
            this.label_Tipo1.Size = new System.Drawing.Size(37, 15);
            this.label_Tipo1.TabIndex = 2;
            this.label_Tipo1.Text = "Tipo :";
            // 
            // label_ArtDes
            // 
            this.label_ArtDes.AutoSize = true;
            this.label_ArtDes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ArtDes.Location = new System.Drawing.Point(25, 45);
            this.label_ArtDes.Name = "label_ArtDes";
            this.label_ArtDes.Size = new System.Drawing.Size(58, 15);
            this.label_ArtDes.TabIndex = 0;
            this.label_ArtDes.Text = "Nombre :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel_grid);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(783, 317);
            this.panel3.TabIndex = 2;
            // 
            // panel_grid
            // 
            this.panel_grid.Controls.Add(this.dataGridView1);
            this.panel_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_grid.Location = new System.Drawing.Point(22, 0);
            this.panel_grid.Name = "panel_grid";
            this.panel_grid.Size = new System.Drawing.Size(739, 317);
            this.panel_grid.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 317);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(761, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 317);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(22, 317);
            this.panel4.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ckbEtiquetaObligatoria
            // 
            this.ckbEtiquetaObligatoria.AutoSize = true;
            this.ckbEtiquetaObligatoria.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEtiquetaObligatoria.Location = new System.Drawing.Point(104, 134);
            this.ckbEtiquetaObligatoria.Name = "ckbEtiquetaObligatoria";
            this.ckbEtiquetaObligatoria.Size = new System.Drawing.Size(15, 14);
            this.ckbEtiquetaObligatoria.TabIndex = 17;
            this.ckbEtiquetaObligatoria.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Etiq. Oblig. :";
            // 
            // frmMttoARTICULOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 572);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_Datos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMttoARTICULOS";
            this.Text = "    ARTÍCULOS";
            this.Load += new System.EventHandler(this.frmMttoARTICULOS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label_Tipo1;
        private System.Windows.Forms.Label label_ArtDes;
        private System.Windows.Forms.ComboBox comboBox_Tipo1;
        private System.Windows.Forms.TextBox textBox_ArtDes;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_ArtCod;
        private System.Windows.Forms.TextBox textBox_ArtCod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Tipo2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbEtiquetaObligatoria;
    }
}