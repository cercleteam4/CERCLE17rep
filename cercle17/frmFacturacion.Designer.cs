namespace cercle17
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_FPVPropia = new System.Windows.Forms.Button();
            this.btn_FPV8000 = new System.Windows.Forms.Button();
            this.button_FPVAbono1 = new System.Windows.Forms.Button();
            this.button_FPVAbono = new System.Windows.Forms.Button();
            this.button_Descobro = new System.Windows.Forms.Button();
            this.button_Periodos = new System.Windows.Forms.Button();
            this.button_FVentas = new System.Windows.Forms.Button();
            this.button_FPVManual = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_FCompras = new System.Windows.Forms.Button();
            this.button_FCManual = new System.Windows.Forms.Button();
            this.button_FCProveedor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_Exportar = new System.Windows.Forms.Button();
            this.button_Cuadre = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSALIR = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_FPVPropia);
            this.panel1.Controls.Add(this.btn_FPV8000);
            this.panel1.Controls.Add(this.button_FPVAbono1);
            this.panel1.Controls.Add(this.button_FPVAbono);
            this.panel1.Controls.Add(this.button_Descobro);
            this.panel1.Controls.Add(this.button_Periodos);
            this.panel1.Controls.Add(this.button_FVentas);
            this.panel1.Controls.Add(this.button_FPVManual);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 200);
            this.panel1.TabIndex = 0;
            // 
            // button_FPVPropia
            // 
            this.button_FPVPropia.Location = new System.Drawing.Point(414, 14);
            this.button_FPVPropia.Name = "button_FPVPropia";
            this.button_FPVPropia.Size = new System.Drawing.Size(138, 56);
            this.button_FPVPropia.TabIndex = 9;
            this.button_FPVPropia.Text = "FACTURACIÓN PROPIA";
            this.button_FPVPropia.UseVisualStyleBackColor = true;
            this.button_FPVPropia.Click += new System.EventHandler(this.button_FPVPropia_Click);
            // 
            // btn_FPV8000
            // 
            this.btn_FPV8000.Location = new System.Drawing.Point(261, 76);
            this.btn_FPV8000.Name = "btn_FPV8000";
            this.btn_FPV8000.Size = new System.Drawing.Size(138, 51);
            this.btn_FPV8000.TabIndex = 8;
            this.btn_FPV8000.Text = "FACTURAS 8000";
            this.btn_FPV8000.UseVisualStyleBackColor = true;
            this.btn_FPV8000.Visible = false;
            this.btn_FPV8000.Click += new System.EventHandler(this.btn_FPV8000_Click);
            // 
            // button_FPVAbono1
            // 
            this.button_FPVAbono1.Location = new System.Drawing.Point(261, 136);
            this.button_FPVAbono1.Name = "button_FPVAbono1";
            this.button_FPVAbono1.Size = new System.Drawing.Size(138, 52);
            this.button_FPVAbono1.TabIndex = 7;
            this.button_FPVAbono1.Text = "FACTURACION DE ABONOS SG";
            this.button_FPVAbono1.UseVisualStyleBackColor = true;
            this.button_FPVAbono1.Visible = false;
            this.button_FPVAbono1.Click += new System.EventHandler(this.button_FPVAbono1_Click);
            // 
            // button_FPVAbono
            // 
            this.button_FPVAbono.Location = new System.Drawing.Point(107, 136);
            this.button_FPVAbono.Name = "button_FPVAbono";
            this.button_FPVAbono.Size = new System.Drawing.Size(138, 56);
            this.button_FPVAbono.TabIndex = 6;
            this.button_FPVAbono.Text = "FACTURACIÓN ABONOS";
            this.button_FPVAbono.UseVisualStyleBackColor = true;
            this.button_FPVAbono.Visible = false;
            this.button_FPVAbono.Click += new System.EventHandler(this.button_FPVAbono_Click);
            // 
            // button_Descobro
            // 
            this.button_Descobro.Location = new System.Drawing.Point(656, 12);
            this.button_Descobro.Name = "button_Descobro";
            this.button_Descobro.Size = new System.Drawing.Size(104, 56);
            this.button_Descobro.TabIndex = 5;
            this.button_Descobro.Text = "DESCOBRAR";
            this.button_Descobro.UseVisualStyleBackColor = true;
            this.button_Descobro.Visible = false;
            this.button_Descobro.Click += new System.EventHandler(this.button_Descobro_Click);
            // 
            // button_Periodos
            // 
            this.button_Periodos.Location = new System.Drawing.Point(106, 74);
            this.button_Periodos.Name = "button_Periodos";
            this.button_Periodos.Size = new System.Drawing.Size(139, 56);
            this.button_Periodos.TabIndex = 4;
            this.button_Periodos.Text = "FACTURACIÓN PERIÓDICA";
            this.button_Periodos.UseVisualStyleBackColor = true;
            this.button_Periodos.Click += new System.EventHandler(this.button_Periodos_Click);
            // 
            // button_FVentas
            // 
            this.button_FVentas.Location = new System.Drawing.Point(106, 12);
            this.button_FVentas.Name = "button_FVentas";
            this.button_FVentas.Size = new System.Drawing.Size(139, 56);
            this.button_FVentas.TabIndex = 3;
            this.button_FVentas.Text = "FACTURAS VENTAS";
            this.button_FVentas.UseVisualStyleBackColor = true;
            this.button_FVentas.Click += new System.EventHandler(this.button_FVentas_Click);
            // 
            // button_FPVManual
            // 
            this.button_FPVManual.Location = new System.Drawing.Point(261, 14);
            this.button_FPVManual.Name = "button_FPVManual";
            this.button_FPVManual.Size = new System.Drawing.Size(138, 56);
            this.button_FPVManual.TabIndex = 2;
            this.button_FPVManual.Text = "FACTURACIÓN MANUAL";
            this.button_FPVManual.UseVisualStyleBackColor = true;
            this.button_FPVManual.Click += new System.EventHandler(this.button_FPVManual_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "VENTAS";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_FCompras);
            this.panel2.Controls.Add(this.button_FCManual);
            this.panel2.Controls.Add(this.button_FCProveedor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(23, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 114);
            this.panel2.TabIndex = 1;
            // 
            // button_FCompras
            // 
            this.button_FCompras.Location = new System.Drawing.Point(107, 12);
            this.button_FCompras.Name = "button_FCompras";
            this.button_FCompras.Size = new System.Drawing.Size(139, 56);
            this.button_FCompras.TabIndex = 7;
            this.button_FCompras.Text = "FACTURAS COMPRAS";
            this.button_FCompras.UseVisualStyleBackColor = true;
            this.button_FCompras.Visible = false;
            this.button_FCompras.Click += new System.EventHandler(this.button_FCompras_Click);
            // 
            // button_FCManual
            // 
            this.button_FCManual.Location = new System.Drawing.Point(261, 12);
            this.button_FCManual.Name = "button_FCManual";
            this.button_FCManual.Size = new System.Drawing.Size(139, 56);
            this.button_FCManual.TabIndex = 6;
            this.button_FCManual.Text = "FACTURACIÓN MANUAL";
            this.button_FCManual.UseVisualStyleBackColor = true;
            this.button_FCManual.Visible = false;
            this.button_FCManual.Click += new System.EventHandler(this.button_FCManual_Click);
            // 
            // button_FCProveedor
            // 
            this.button_FCProveedor.Location = new System.Drawing.Point(414, 12);
            this.button_FCProveedor.Name = "button_FCProveedor";
            this.button_FCProveedor.Size = new System.Drawing.Size(139, 56);
            this.button_FCProveedor.TabIndex = 5;
            this.button_FCProveedor.Text = "FACTURACIÓN PROVEEDOR";
            this.button_FCProveedor.UseVisualStyleBackColor = true;
            this.button_FCProveedor.Click += new System.EventHandler(this.button_FCProveedor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "COMPRAS";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_Exportar);
            this.panel3.Controls.Add(this.button_Cuadre);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(23, 405);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 114);
            this.panel3.TabIndex = 2;
            // 
            // button_Exportar
            // 
            this.button_Exportar.Location = new System.Drawing.Point(383, 42);
            this.button_Exportar.Name = "button_Exportar";
            this.button_Exportar.Size = new System.Drawing.Size(179, 56);
            this.button_Exportar.TabIndex = 6;
            this.button_Exportar.Text = "EXPORTAR CONTAPLUS";
            this.button_Exportar.UseVisualStyleBackColor = true;
            this.button_Exportar.Click += new System.EventHandler(this.button_Exportar_Click);
            // 
            // button_Cuadre
            // 
            this.button_Cuadre.Location = new System.Drawing.Point(581, 42);
            this.button_Cuadre.Name = "button_Cuadre";
            this.button_Cuadre.Size = new System.Drawing.Size(179, 56);
            this.button_Cuadre.TabIndex = 5;
            this.button_Cuadre.Text = "CUADRE CAJA";
            this.button_Cuadre.UseVisualStyleBackColor = true;
            this.button_Cuadre.Click += new System.EventHandler(this.button_Cuadre_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "CONTABILIDAD";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.btnSALIR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(848, 73);
            this.panel4.TabIndex = 6;
            // 
            // btnSALIR
            // 
            this.btnSALIR.BackColor = System.Drawing.Color.Beige;
            this.btnSALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSALIR.Image = global::cercle17.Properties.Resources.exit2;
            this.btnSALIR.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSALIR.Location = new System.Drawing.Point(12, 3);
            this.btnSALIR.Name = "btnSALIR";
            this.btnSALIR.Size = new System.Drawing.Size(111, 65);
            this.btnSALIR.TabIndex = 0;
            this.btnSALIR.Text = "SALIR";
            this.btnSALIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSALIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSALIR.UseVisualStyleBackColor = false;
            this.btnSALIR.Click += new System.EventHandler(this.btnSALIR_Click);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(848, 531);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFacturacion";
            this.Text = "    Facturación";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_FPVManual;
        private System.Windows.Forms.Button button_FVentas;
        private System.Windows.Forms.Button button_Periodos;
        private System.Windows.Forms.Button button_Cuadre;
        private System.Windows.Forms.Button button_Exportar;
        private System.Windows.Forms.Button button_Descobro;
        private System.Windows.Forms.Button button_FCProveedor;
        private System.Windows.Forms.Button button_FPVAbono;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSALIR;
        private System.Windows.Forms.Button button_FPVAbono1;
        private System.Windows.Forms.Button btn_FPV8000;
        private System.Windows.Forms.Button button_FPVPropia;
        private System.Windows.Forms.Button button_FCManual;
        private System.Windows.Forms.Button button_FCompras;
    }
}