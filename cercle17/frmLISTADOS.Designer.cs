namespace cercle17
{
    partial class frmLISTADOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLISTADOS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnListadoCompras = new System.Windows.Forms.Button();
            this.BtnListadoVentas = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 66);
            this.panel1.TabIndex = 2;
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(122, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 177);
            this.panel2.TabIndex = 3;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(15, 41);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(271, 29);
            this.button9.TabIndex = 1;
            this.button9.Text = "Estadisticas de Compras por Artículos";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(14, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(272, 29);
            this.button8.TabIndex = 0;
            this.button8.Text = "Listado de Ventas por Proveedor ENDUMAR";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 288);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 165);
            this.panel3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(285, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Listado de Facturas de clientes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel4.Controls.Add(this.BtnListadoCompras);
            this.panel4.Controls.Add(this.BtnListadoVentas);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1053, 222);
            this.panel4.TabIndex = 5;
            // 
            // BtnListadoCompras
            // 
            this.BtnListadoCompras.Location = new System.Drawing.Point(320, 162);
            this.BtnListadoCompras.Name = "BtnListadoCompras";
            this.BtnListadoCompras.Size = new System.Drawing.Size(285, 35);
            this.BtnListadoCompras.TabIndex = 4;
            this.BtnListadoCompras.Text = "Listado de Compras por Proveedor";
            this.BtnListadoCompras.UseVisualStyleBackColor = true;
            this.BtnListadoCompras.Visible = false;
            this.BtnListadoCompras.Click += new System.EventHandler(this.BtnListadoCompras_Click);
            // 
            // BtnListadoVentas
            // 
            this.BtnListadoVentas.Location = new System.Drawing.Point(320, 123);
            this.BtnListadoVentas.Name = "BtnListadoVentas";
            this.BtnListadoVentas.Size = new System.Drawing.Size(285, 35);
            this.BtnListadoVentas.TabIndex = 3;
            this.BtnListadoVentas.Text = "Listado de Ventas por Detallista";
            this.BtnListadoVentas.UseVisualStyleBackColor = true;
            this.BtnListadoVentas.Visible = false;
            this.BtnListadoVentas.Click += new System.EventHandler(this.BtnListadoVentas_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 164);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(284, 33);
            this.button5.TabIndex = 2;
            this.button5.Text = "Listado de Compras: Fecha, Artículos Proveedores";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "C O N T A B I L I D A D";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "Listado de Venta: Fecha, Articulos, Detallistas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1053, 104);
            this.panel5.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(259, 52);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(222, 31);
            this.button7.TabIndex = 3;
            this.button7.Text = "Listado de Diferencias Stock";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(257, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(225, 36);
            this.button6.TabIndex = 2;
            this.button6.Text = "Listado De Stock por Artículos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(225, 36);
            this.button4.TabIndex = 1;
            this.button4.Text = "Listado De Rentabilidad de Vendedores 06";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Listado De Rentabilidad de Vendedores 01";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLISTADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 630);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLISTADOS";
            this.Text = "LISTADOS";
            this.Load += new System.EventHandler(this.frmLISTADOS_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button BtnListadoVentas;
        private System.Windows.Forms.Button BtnListadoCompras;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}