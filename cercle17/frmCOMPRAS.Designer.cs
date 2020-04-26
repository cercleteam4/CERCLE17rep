namespace cercle17
{
    partial class frmCOMPRAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCOMPRAS));
            this.button_Compras_Entradas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Salir = new System.Windows.Forms.Button();
            this.btn_Ver_Alb_Compra = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Compras_Entradas
            // 
            this.button_Compras_Entradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Compras_Entradas.Location = new System.Drawing.Point(12, 114);
            this.button_Compras_Entradas.Name = "button_Compras_Entradas";
            this.button_Compras_Entradas.Size = new System.Drawing.Size(208, 65);
            this.button_Compras_Entradas.TabIndex = 0;
            this.button_Compras_Entradas.Text = "Entrada de Albaranes de Compras";
            this.button_Compras_Entradas.UseVisualStyleBackColor = true;
            this.button_Compras_Entradas.Visible = false;
            this.button_Compras_Entradas.Click += new System.EventHandler(this.button_Compras_Entradas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 76);
            this.panel1.TabIndex = 2;
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(12, 4);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(138, 70);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // btn_Ver_Alb_Compra
            // 
            this.btn_Ver_Alb_Compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ver_Alb_Compra.Location = new System.Drawing.Point(239, 112);
            this.btn_Ver_Alb_Compra.Name = "btn_Ver_Alb_Compra";
            this.btn_Ver_Alb_Compra.Size = new System.Drawing.Size(185, 67);
            this.btn_Ver_Alb_Compra.TabIndex = 3;
            this.btn_Ver_Alb_Compra.Text = "Albaranes de Compras. Ver";
            this.btn_Ver_Alb_Compra.UseVisualStyleBackColor = true;
            this.btn_Ver_Alb_Compra.Visible = false;
            this.btn_Ver_Alb_Compra.Click += new System.EventHandler(this.btn_Ver_Alb_Compra_Click);
            // 
            // frmCOMPRAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(985, 358);
            this.Controls.Add(this.btn_Ver_Alb_Compra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Compras_Entradas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCOMPRAS";
            this.Text = "ceptar o rechazar ";
            this.Load += new System.EventHandler(this.frmCOMPRAS_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Compras_Entradas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button btn_Ver_Alb_Compra;
    }
}