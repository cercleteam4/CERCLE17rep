namespace cercle17
{
    partial class frmMtto
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
            this.button_Usuarios = new System.Windows.Forms.Button();
            this.button_Control = new System.Windows.Forms.Button();
            this.button_Barcos = new System.Windows.Forms.Button();
            this.button_EXPORT_Sbta_Det = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Salir = new System.Windows.Forms.Button();
            this.button_EXPORT_Sbta_Prov = new System.Windows.Forms.Button();
            this.button_Detallistas = new System.Windows.Forms.Button();
            this.button_Articulos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Usuarios
            // 
            this.button_Usuarios.Location = new System.Drawing.Point(96, 237);
            this.button_Usuarios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Usuarios.Name = "button_Usuarios";
            this.button_Usuarios.Size = new System.Drawing.Size(289, 53);
            this.button_Usuarios.TabIndex = 1;
            this.button_Usuarios.Text = "USUARIOS";
            this.button_Usuarios.UseVisualStyleBackColor = true;
            this.button_Usuarios.Visible = false;
            this.button_Usuarios.Click += new System.EventHandler(this.button_Usuarios_Click);
            // 
            // button_Control
            // 
            this.button_Control.Location = new System.Drawing.Point(96, 311);
            this.button_Control.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Control.Name = "button_Control";
            this.button_Control.Size = new System.Drawing.Size(289, 53);
            this.button_Control.TabIndex = 2;
            this.button_Control.Text = "CONTROL";
            this.button_Control.UseVisualStyleBackColor = true;
            this.button_Control.Visible = false;
            this.button_Control.Click += new System.EventHandler(this.button_Control_Click);
            // 
            // button_Barcos
            // 
            this.button_Barcos.Location = new System.Drawing.Point(96, 162);
            this.button_Barcos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Barcos.Name = "button_Barcos";
            this.button_Barcos.Size = new System.Drawing.Size(289, 53);
            this.button_Barcos.TabIndex = 3;
            this.button_Barcos.Text = "BARCOS";
            this.button_Barcos.UseVisualStyleBackColor = true;
            this.button_Barcos.Visible = false;
            this.button_Barcos.Click += new System.EventHandler(this.button_Barcos_Click);
            // 
            // button_EXPORT_Sbta_Det
            // 
            this.button_EXPORT_Sbta_Det.Location = new System.Drawing.Point(96, 384);
            this.button_EXPORT_Sbta_Det.Name = "button_EXPORT_Sbta_Det";
            this.button_EXPORT_Sbta_Det.Size = new System.Drawing.Size(289, 49);
            this.button_EXPORT_Sbta_Det.TabIndex = 4;
            this.button_EXPORT_Sbta_Det.Text = "Generar Fichero SubCta Detallistas para ContaPLUS";
            this.button_EXPORT_Sbta_Det.UseVisualStyleBackColor = true;
            this.button_EXPORT_Sbta_Det.Visible = false;
            this.button_EXPORT_Sbta_Det.Click += new System.EventHandler(this.button_EXPORT_Sbta_Det_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 66);
            this.panel1.TabIndex = 5;
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(109, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // button_EXPORT_Sbta_Prov
            // 
            this.button_EXPORT_Sbta_Prov.Location = new System.Drawing.Point(499, 387);
            this.button_EXPORT_Sbta_Prov.Name = "button_EXPORT_Sbta_Prov";
            this.button_EXPORT_Sbta_Prov.Size = new System.Drawing.Size(300, 45);
            this.button_EXPORT_Sbta_Prov.TabIndex = 6;
            this.button_EXPORT_Sbta_Prov.Text = "Generar Fichero Sucta Proveedores para ContaPLUS";
            this.button_EXPORT_Sbta_Prov.UseVisualStyleBackColor = true;
            this.button_EXPORT_Sbta_Prov.Visible = false;
            this.button_EXPORT_Sbta_Prov.Click += new System.EventHandler(this.button_EXPORT_Sbta_Prov_Click);
            // 
            // button_Detallistas
            // 
            this.button_Detallistas.Location = new System.Drawing.Point(499, 237);
            this.button_Detallistas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Detallistas.Name = "button_Detallistas";
            this.button_Detallistas.Size = new System.Drawing.Size(289, 53);
            this.button_Detallistas.TabIndex = 8;
            this.button_Detallistas.Text = "DETALLISTAS";
            this.button_Detallistas.UseVisualStyleBackColor = true;
            this.button_Detallistas.Visible = false;
            this.button_Detallistas.Click += new System.EventHandler(this.button_Detallistas_Click);
            // 
            // button_Articulos
            // 
            this.button_Articulos.Location = new System.Drawing.Point(499, 162);
            this.button_Articulos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Articulos.Name = "button_Articulos";
            this.button_Articulos.Size = new System.Drawing.Size(289, 53);
            this.button_Articulos.TabIndex = 9;
            this.button_Articulos.Text = "ARTÍCULOS";
            this.button_Articulos.UseVisualStyleBackColor = true;
            this.button_Articulos.Visible = false;
            this.button_Articulos.Click += new System.EventHandler(this.button_Articulos_Click);
            // 
            // frmMtto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1118, 497);
            this.Controls.Add(this.button_Articulos);
            this.Controls.Add(this.button_Detallistas);
            this.Controls.Add(this.button_EXPORT_Sbta_Prov);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_EXPORT_Sbta_Det);
            this.Controls.Add(this.button_Barcos);
            this.Controls.Add(this.button_Control);
            this.Controls.Add(this.button_Usuarios);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMtto";
            this.Text = "    Mantenimiento";
            this.Load += new System.EventHandler(this.frmMtto_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Usuarios;
        private System.Windows.Forms.Button button_Control;
        private System.Windows.Forms.Button button_Barcos;
        private System.Windows.Forms.Button button_EXPORT_Sbta_Det;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Button button_EXPORT_Sbta_Prov;
        private System.Windows.Forms.Button button_Detallistas;
        private System.Windows.Forms.Button button_Articulos;
    }
}