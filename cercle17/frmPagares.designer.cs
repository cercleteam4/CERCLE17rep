namespace cercle17
{
    partial class frmPagares
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gPagares = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox_CodCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Crear = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).BeginInit();
            this.SuspendLayout();
            // 
            // gPagares
            // 
            this.gPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPagares.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gPagares.DefaultCellStyle = dataGridViewCellStyle1;
            this.gPagares.Location = new System.Drawing.Point(12, 66);
            this.gPagares.MultiSelect = false;
            this.gPagares.Name = "gPagares";
            this.gPagares.ReadOnly = true;
            this.gPagares.RowHeadersVisible = false;
            this.gPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gPagares.Size = new System.Drawing.Size(753, 296);
            this.gPagares.TabIndex = 3;
//            this.gPagares.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gPagares_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // textBox_CodCliente
            // 
            this.textBox_CodCliente.Location = new System.Drawing.Point(107, 40);
            this.textBox_CodCliente.Name = "textBox_CodCliente";
            this.textBox_CodCliente.Size = new System.Drawing.Size(58, 20);
            this.textBox_CodCliente.TabIndex = 5;
            this.textBox_CodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CodCliente_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "CLIENTE";
            // 
            // button_Crear
            // 
            this.button_Crear.Location = new System.Drawing.Point(465, 12);
            this.button_Crear.Name = "button_Crear";
            this.button_Crear.Size = new System.Drawing.Size(147, 45);
            this.button_Crear.TabIndex = 6;
            this.button_Crear.Text = "CREAR PAGARÉ";
            this.button_Crear.UseVisualStyleBackColor = true;
            this.button_Crear.Click += new System.EventHandler(this.button_Crear_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmPagares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(792, 390);
            this.Controls.Add(this.button_Crear);
            this.Controls.Add(this.textBox_CodCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gPagares);
            this.Name = "frmPagares";
            this.Text = "    Gestión de Pagarés";
            this.Load += new System.EventHandler(this.frmPagares_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gPagares;
        private System.Windows.Forms.TextBox textBox_CodCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Crear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}