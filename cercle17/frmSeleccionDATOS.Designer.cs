namespace cercle17
{
    partial class frmSeleccionDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionDatos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnF5 = new System.Windows.Forms.Button();
            this.button_Exportar = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.panelDet = new System.Windows.Forms.Panel();
            this.llDetFin = new System.Windows.Forms.LinkLabel();
            this.llDetIni = new System.Windows.Forms.LinkLabel();
            this.lDetFin = new System.Windows.Forms.Label();
            this.lDetIni = new System.Windows.Forms.Label();
            this.tDetFin = new System.Windows.Forms.TextBox();
            this.tDetIni = new System.Windows.Forms.TextBox();
            this.panelFec = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.tVendedIni = new System.Windows.Forms.TextBox();
            this.tVendedFin = new System.Windows.Forms.TextBox();
            this.llVendedIni = new System.Windows.Forms.LinkLabel();
            this.llVendedFin = new System.Windows.Forms.LinkLabel();
            this.lVendedIni = new System.Windows.Forms.Label();
            this.lVendedFin = new System.Windows.Forms.Label();
            this.panelVended = new System.Windows.Forms.Panel();
            this.panelArt = new System.Windows.Forms.Panel();
            this.llArtFin = new System.Windows.Forms.LinkLabel();
            this.llArtIni = new System.Windows.Forms.LinkLabel();
            this.lArtFin = new System.Windows.Forms.Label();
            this.lArtIni = new System.Windows.Forms.Label();
            this.tArtFin = new System.Windows.Forms.TextBox();
            this.tArtIni = new System.Windows.Forms.TextBox();
            this.panelExclDet = new System.Windows.Forms.Panel();
            this.L1 = new System.Windows.Forms.ListView();
            this.tDetExc = new System.Windows.Forms.TextBox();
            this.ListDetExc = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelProv = new System.Windows.Forms.Panel();
            this.llProvFin = new System.Windows.Forms.LinkLabel();
            this.llProvIni = new System.Windows.Forms.LinkLabel();
            this.lProvFin = new System.Windows.Forms.Label();
            this.lProvIni = new System.Windows.Forms.Label();
            this.tProvFin = new System.Windows.Forms.TextBox();
            this.tProvIni = new System.Windows.Forms.TextBox();
            this.panelInclDet = new System.Windows.Forms.Panel();
            this.L2 = new System.Windows.Forms.ListView();
            this.tDetInc = new System.Windows.Forms.TextBox();
            this.ListDetInc = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelFact1 = new System.Windows.Forms.Panel();
            this.OptFactPendientes = new System.Windows.Forms.RadioButton();
            this.OptFacturasCobradas = new System.Windows.Forms.RadioButton();
            this.OptFactTodas = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDet.SuspendLayout();
            this.panelFec.SuspendLayout();
            this.panelVended.SuspendLayout();
            this.panelArt.SuspendLayout();
            this.panelExclDet.SuspendLayout();
            this.panelProv.SuspendLayout();
            this.panelInclDet.SuspendLayout();
            this.panelFact1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnF5);
            this.panel1.Controls.Add(this.button_Exportar);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 66);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(809, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 62);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnF5
            // 
            this.btnF5.BackColor = System.Drawing.Color.Beige;
            this.btnF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.Image = global::cercle17.Properties.Resources.printer2;
            this.btnF5.Location = new System.Drawing.Point(336, 3);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(163, 59);
            this.btnF5.TabIndex = 2;
            this.btnF5.Text = "LISTAR";
            this.btnF5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnF5.UseVisualStyleBackColor = false;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // button_Exportar
            // 
            this.button_Exportar.BackColor = System.Drawing.Color.Beige;
            this.button_Exportar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exportar.Image = global::cercle17.Properties.Resources.exportar_carpeta_64x64;
            this.button_Exportar.Location = new System.Drawing.Point(153, 2);
            this.button_Exportar.Name = "button_Exportar";
            this.button_Exportar.Size = new System.Drawing.Size(177, 61);
            this.button_Exportar.TabIndex = 1;
            this.button_Exportar.Text = "EXPORTAR";
            this.button_Exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Exportar.UseVisualStyleBackColor = false;
            this.button_Exportar.Click += new System.EventHandler(this.button_Exportar_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.BackColor = System.Drawing.Color.Beige;
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(14, 3);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(133, 61);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Salir.UseVisualStyleBackColor = false;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // panelDet
            // 
            this.panelDet.BackColor = System.Drawing.Color.Lavender;
            this.panelDet.Controls.Add(this.llDetFin);
            this.panelDet.Controls.Add(this.llDetIni);
            this.panelDet.Controls.Add(this.lDetFin);
            this.panelDet.Controls.Add(this.lDetIni);
            this.panelDet.Controls.Add(this.tDetFin);
            this.panelDet.Controls.Add(this.tDetIni);
            this.panelDet.Location = new System.Drawing.Point(539, 315);
            this.panelDet.Name = "panelDet";
            this.panelDet.Size = new System.Drawing.Size(313, 104);
            this.panelDet.TabIndex = 0;
            this.panelDet.Visible = false;
            // 
            // llDetFin
            // 
            this.llDetFin.AutoSize = true;
            this.llDetFin.Location = new System.Drawing.Point(14, 50);
            this.llDetFin.Name = "llDetFin";
            this.llDetFin.Size = new System.Drawing.Size(75, 13);
            this.llDetFin.TabIndex = 5;
            this.llDetFin.TabStop = true;
            this.llDetFin.Text = "Detallista Final";
            this.llDetFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDetFin_LinkClicked);
            // 
            // llDetIni
            // 
            this.llDetIni.AutoSize = true;
            this.llDetIni.Location = new System.Drawing.Point(14, 10);
            this.llDetIni.Name = "llDetIni";
            this.llDetIni.Size = new System.Drawing.Size(80, 13);
            this.llDetIni.TabIndex = 4;
            this.llDetIni.TabStop = true;
            this.llDetIni.Text = "Detallista Inicial";
            this.llDetIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDetIni_LinkClicked);
            // 
            // lDetFin
            // 
            this.lDetFin.AutoSize = true;
            this.lDetFin.Location = new System.Drawing.Point(77, 69);
            this.lDetFin.Name = "lDetFin";
            this.lDetFin.Size = new System.Drawing.Size(35, 13);
            this.lDetFin.TabIndex = 3;
            this.lDetFin.Text = "label1";
            // 
            // lDetIni
            // 
            this.lDetIni.AutoSize = true;
            this.lDetIni.Location = new System.Drawing.Point(77, 29);
            this.lDetIni.Name = "lDetIni";
            this.lDetIni.Size = new System.Drawing.Size(35, 13);
            this.lDetIni.TabIndex = 2;
            this.lDetIni.Text = "label1";
            // 
            // tDetFin
            // 
            this.tDetFin.Location = new System.Drawing.Point(17, 66);
            this.tDetFin.Name = "tDetFin";
            this.tDetFin.Size = new System.Drawing.Size(54, 20);
            this.tDetFin.TabIndex = 1;
            this.tDetFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetFin_KeyPress);
            // 
            // tDetIni
            // 
            this.tDetIni.Location = new System.Drawing.Point(17, 26);
            this.tDetIni.Name = "tDetIni";
            this.tDetIni.Size = new System.Drawing.Size(54, 20);
            this.tDetIni.TabIndex = 0;
            this.tDetIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetIni_KeyPress);
            // 
            // panelFec
            // 
            this.panelFec.BackColor = System.Drawing.Color.Lavender;
            this.panelFec.Controls.Add(this.label2);
            this.panelFec.Controls.Add(this.label1);
            this.panelFec.Controls.Add(this.dateTimePicker_Fin);
            this.panelFec.Controls.Add(this.dateTimePicker_Inicio);
            this.panelFec.Location = new System.Drawing.Point(14, 93);
            this.panelFec.Name = "panelFec";
            this.panelFec.Size = new System.Drawing.Size(187, 104);
            this.panelFec.TabIndex = 4;
            this.panelFec.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hasta";
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(64, 69);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Fin.TabIndex = 1;
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(64, 26);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(87, 20);
            this.dateTimePicker_Inicio.TabIndex = 0;
            this.dateTimePicker_Inicio.ValueChanged += new System.EventHandler(this.dateTimePicker_Inicio_ValueChanged);
            // 
            // tVendedIni
            // 
            this.tVendedIni.Location = new System.Drawing.Point(17, 24);
            this.tVendedIni.Name = "tVendedIni";
            this.tVendedIni.Size = new System.Drawing.Size(41, 20);
            this.tVendedIni.TabIndex = 0;
            this.tVendedIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tVendedIni_KeyPress);
            // 
            // tVendedFin
            // 
            this.tVendedFin.Location = new System.Drawing.Point(17, 69);
            this.tVendedFin.Name = "tVendedFin";
            this.tVendedFin.Size = new System.Drawing.Size(39, 20);
            this.tVendedFin.TabIndex = 1;
            this.tVendedFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tVendedFin_KeyPress);
            // 
            // llVendedIni
            // 
            this.llVendedIni.AutoSize = true;
            this.llVendedIni.Location = new System.Drawing.Point(14, 8);
            this.llVendedIni.Name = "llVendedIni";
            this.llVendedIni.Size = new System.Drawing.Size(87, 13);
            this.llVendedIni.TabIndex = 2;
            this.llVendedIni.TabStop = true;
            this.llVendedIni.Text = "Desde Vendedor";
            this.llVendedIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVendedIni_LinkClicked);
            // 
            // llVendedFin
            // 
            this.llVendedFin.AutoSize = true;
            this.llVendedFin.Location = new System.Drawing.Point(14, 53);
            this.llVendedFin.Name = "llVendedFin";
            this.llVendedFin.Size = new System.Drawing.Size(84, 13);
            this.llVendedFin.TabIndex = 3;
            this.llVendedFin.TabStop = true;
            this.llVendedFin.Text = "Hasta Vendedor";
            this.llVendedFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llVendedFin_LinkClicked);
            // 
            // lVendedIni
            // 
            this.lVendedIni.AutoSize = true;
            this.lVendedIni.Location = new System.Drawing.Point(101, 27);
            this.lVendedIni.Name = "lVendedIni";
            this.lVendedIni.Size = new System.Drawing.Size(0, 13);
            this.lVendedIni.TabIndex = 4;
            // 
            // lVendedFin
            // 
            this.lVendedFin.AutoSize = true;
            this.lVendedFin.Location = new System.Drawing.Point(97, 76);
            this.lVendedFin.Name = "lVendedFin";
            this.lVendedFin.Size = new System.Drawing.Size(0, 13);
            this.lVendedFin.TabIndex = 5;
            // 
            // panelVended
            // 
            this.panelVended.BackColor = System.Drawing.Color.Lavender;
            this.panelVended.Controls.Add(this.lVendedFin);
            this.panelVended.Controls.Add(this.lVendedIni);
            this.panelVended.Controls.Add(this.llVendedFin);
            this.panelVended.Controls.Add(this.llVendedIni);
            this.panelVended.Controls.Add(this.tVendedFin);
            this.panelVended.Controls.Add(this.tVendedIni);
            this.panelVended.Location = new System.Drawing.Point(539, 425);
            this.panelVended.Name = "panelVended";
            this.panelVended.Size = new System.Drawing.Size(313, 102);
            this.panelVended.TabIndex = 5;
            this.panelVended.Visible = false;
            // 
            // panelArt
            // 
            this.panelArt.BackColor = System.Drawing.Color.Lavender;
            this.panelArt.Controls.Add(this.llArtFin);
            this.panelArt.Controls.Add(this.llArtIni);
            this.panelArt.Controls.Add(this.lArtFin);
            this.panelArt.Controls.Add(this.lArtIni);
            this.panelArt.Controls.Add(this.tArtFin);
            this.panelArt.Controls.Add(this.tArtIni);
            this.panelArt.Location = new System.Drawing.Point(539, 93);
            this.panelArt.Name = "panelArt";
            this.panelArt.Size = new System.Drawing.Size(313, 104);
            this.panelArt.TabIndex = 6;
            this.panelArt.Visible = false;
            // 
            // llArtFin
            // 
            this.llArtFin.AutoSize = true;
            this.llArtFin.Location = new System.Drawing.Point(14, 56);
            this.llArtFin.Name = "llArtFin";
            this.llArtFin.Size = new System.Drawing.Size(69, 13);
            this.llArtFin.TabIndex = 5;
            this.llArtFin.TabStop = true;
            this.llArtFin.Text = "Artículo Final";
            this.llArtFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llArtFin_LinkClicked);
            // 
            // llArtIni
            // 
            this.llArtIni.AutoSize = true;
            this.llArtIni.Location = new System.Drawing.Point(14, 10);
            this.llArtIni.Name = "llArtIni";
            this.llArtIni.Size = new System.Drawing.Size(74, 13);
            this.llArtIni.TabIndex = 4;
            this.llArtIni.TabStop = true;
            this.llArtIni.Text = "Artículo Inicial";
            this.llArtIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llArtIni_LinkClicked);
            // 
            // lArtFin
            // 
            this.lArtFin.AutoSize = true;
            this.lArtFin.Location = new System.Drawing.Point(77, 76);
            this.lArtFin.Name = "lArtFin";
            this.lArtFin.Size = new System.Drawing.Size(35, 13);
            this.lArtFin.TabIndex = 3;
            this.lArtFin.Text = "label1";
            // 
            // lArtIni
            // 
            this.lArtIni.AutoSize = true;
            this.lArtIni.Location = new System.Drawing.Point(77, 29);
            this.lArtIni.Name = "lArtIni";
            this.lArtIni.Size = new System.Drawing.Size(35, 13);
            this.lArtIni.TabIndex = 2;
            this.lArtIni.Text = "label1";
            // 
            // tArtFin
            // 
            this.tArtFin.Location = new System.Drawing.Point(17, 72);
            this.tArtFin.Name = "tArtFin";
            this.tArtFin.Size = new System.Drawing.Size(54, 20);
            this.tArtFin.TabIndex = 1;
            this.tArtFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tArtFin_KeyPress);
            // 
            // tArtIni
            // 
            this.tArtIni.Location = new System.Drawing.Point(17, 26);
            this.tArtIni.Name = "tArtIni";
            this.tArtIni.Size = new System.Drawing.Size(54, 20);
            this.tArtIni.TabIndex = 0;
            this.tArtIni.TextChanged += new System.EventHandler(this.tArtIni_TextChanged);
            this.tArtIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tArtIni_KeyPress);
            // 
            // panelExclDet
            // 
            this.panelExclDet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelExclDet.Controls.Add(this.L1);
            this.panelExclDet.Controls.Add(this.tDetExc);
            this.panelExclDet.Controls.Add(this.ListDetExc);
            this.panelExclDet.Controls.Add(this.label3);
            this.panelExclDet.Location = new System.Drawing.Point(14, 205);
            this.panelExclDet.Name = "panelExclDet";
            this.panelExclDet.Size = new System.Drawing.Size(246, 395);
            this.panelExclDet.TabIndex = 7;
            this.panelExclDet.Visible = false;
            // 
            // L1
            // 
            this.L1.Location = new System.Drawing.Point(84, 102);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(153, 290);
            this.L1.TabIndex = 3;
            this.L1.UseCompatibleStateImageBehavior = false;
            // 
            // tDetExc
            // 
            this.tDetExc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDetExc.Location = new System.Drawing.Point(16, 59);
            this.tDetExc.Name = "tDetExc";
            this.tDetExc.Size = new System.Drawing.Size(62, 22);
            this.tDetExc.TabIndex = 2;
            this.tDetExc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetExc_KeyPress);
            // 
            // ListDetExc
            // 
            this.ListDetExc.FormattingEnabled = true;
            this.ListDetExc.Location = new System.Drawing.Point(16, 102);
            this.ListDetExc.Name = "ListDetExc";
            this.ListDetExc.Size = new System.Drawing.Size(62, 290);
            this.ListDetExc.TabIndex = 1;
            this.ListDetExc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListDetExc_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "EXCLUIR DETALLISTAS";
            // 
            // panelProv
            // 
            this.panelProv.BackColor = System.Drawing.Color.Lavender;
            this.panelProv.Controls.Add(this.llProvFin);
            this.panelProv.Controls.Add(this.llProvIni);
            this.panelProv.Controls.Add(this.lProvFin);
            this.panelProv.Controls.Add(this.lProvIni);
            this.panelProv.Controls.Add(this.tProvFin);
            this.panelProv.Controls.Add(this.tProvIni);
            this.panelProv.Location = new System.Drawing.Point(539, 205);
            this.panelProv.Name = "panelProv";
            this.panelProv.Size = new System.Drawing.Size(313, 104);
            this.panelProv.TabIndex = 8;
            this.panelProv.Visible = false;
            // 
            // llProvFin
            // 
            this.llProvFin.AutoSize = true;
            this.llProvFin.Location = new System.Drawing.Point(14, 50);
            this.llProvFin.Name = "llProvFin";
            this.llProvFin.Size = new System.Drawing.Size(81, 13);
            this.llProvFin.TabIndex = 5;
            this.llProvFin.TabStop = true;
            this.llProvFin.Text = "Proveedor Final";
            this.llProvFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llProvFin_LinkClicked);
            // 
            // llProvIni
            // 
            this.llProvIni.AutoSize = true;
            this.llProvIni.Location = new System.Drawing.Point(14, 10);
            this.llProvIni.Name = "llProvIni";
            this.llProvIni.Size = new System.Drawing.Size(86, 13);
            this.llProvIni.TabIndex = 4;
            this.llProvIni.TabStop = true;
            this.llProvIni.Text = "Proveedor Inicial";
            this.llProvIni.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llProvIni_LinkClicked);
            // 
            // lProvFin
            // 
            this.lProvFin.AutoSize = true;
            this.lProvFin.Location = new System.Drawing.Point(77, 69);
            this.lProvFin.Name = "lProvFin";
            this.lProvFin.Size = new System.Drawing.Size(35, 13);
            this.lProvFin.TabIndex = 3;
            this.lProvFin.Text = "label1";
            // 
            // lProvIni
            // 
            this.lProvIni.AutoSize = true;
            this.lProvIni.Location = new System.Drawing.Point(77, 29);
            this.lProvIni.Name = "lProvIni";
            this.lProvIni.Size = new System.Drawing.Size(35, 13);
            this.lProvIni.TabIndex = 2;
            this.lProvIni.Text = "label1";
            // 
            // tProvFin
            // 
            this.tProvFin.Location = new System.Drawing.Point(17, 66);
            this.tProvFin.Name = "tProvFin";
            this.tProvFin.Size = new System.Drawing.Size(54, 20);
            this.tProvFin.TabIndex = 1;
            // 
            // tProvIni
            // 
            this.tProvIni.Location = new System.Drawing.Point(17, 26);
            this.tProvIni.Name = "tProvIni";
            this.tProvIni.Size = new System.Drawing.Size(54, 20);
            this.tProvIni.TabIndex = 0;
            // 
            // panelInclDet
            // 
            this.panelInclDet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelInclDet.Controls.Add(this.L2);
            this.panelInclDet.Controls.Add(this.tDetInc);
            this.panelInclDet.Controls.Add(this.ListDetInc);
            this.panelInclDet.Controls.Add(this.label4);
            this.panelInclDet.Location = new System.Drawing.Point(266, 205);
            this.panelInclDet.Name = "panelInclDet";
            this.panelInclDet.Size = new System.Drawing.Size(246, 395);
            this.panelInclDet.TabIndex = 9;
            this.panelInclDet.Visible = false;
            // 
            // L2
            // 
            this.L2.Location = new System.Drawing.Point(84, 102);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(153, 290);
            this.L2.TabIndex = 3;
            this.L2.UseCompatibleStateImageBehavior = false;
            // 
            // tDetInc
            // 
            this.tDetInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDetInc.Location = new System.Drawing.Point(16, 59);
            this.tDetInc.Name = "tDetInc";
            this.tDetInc.Size = new System.Drawing.Size(62, 22);
            this.tDetInc.TabIndex = 2;
            this.tDetInc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDetInc_KeyPress);
            // 
            // ListDetInc
            // 
            this.ListDetInc.FormattingEnabled = true;
            this.ListDetInc.Location = new System.Drawing.Point(16, 102);
            this.ListDetInc.Name = "ListDetInc";
            this.ListDetInc.Size = new System.Drawing.Size(62, 290);
            this.ListDetInc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "INCLUIR DETALLISTAS";
            // 
            // panelFact1
            // 
            this.panelFact1.BackColor = System.Drawing.Color.Lavender;
            this.panelFact1.Controls.Add(this.OptFactPendientes);
            this.panelFact1.Controls.Add(this.OptFacturasCobradas);
            this.panelFact1.Controls.Add(this.OptFactTodas);
            this.panelFact1.Location = new System.Drawing.Point(539, 520);
            this.panelFact1.Name = "panelFact1";
            this.panelFact1.Size = new System.Drawing.Size(312, 92);
            this.panelFact1.TabIndex = 10;
            this.panelFact1.Visible = false;
            // 
            // OptFactPendientes
            // 
            this.OptFactPendientes.AutoSize = true;
            this.OptFactPendientes.Location = new System.Drawing.Point(41, 50);
            this.OptFactPendientes.Name = "OptFactPendientes";
            this.OptFactPendientes.Size = new System.Drawing.Size(210, 17);
            this.OptFactPendientes.TabIndex = 4;
            this.OptFactPendientes.TabStop = true;
            this.OptFactPendientes.Text = "Solo Facturas No cobradas Totalmente";
            this.OptFactPendientes.UseVisualStyleBackColor = true;
            // 
            // OptFacturasCobradas
            // 
            this.OptFacturasCobradas.AutoSize = true;
            this.OptFacturasCobradas.Location = new System.Drawing.Point(41, 27);
            this.OptFacturasCobradas.Name = "OptFacturasCobradas";
            this.OptFacturasCobradas.Size = new System.Drawing.Size(138, 17);
            this.OptFacturasCobradas.TabIndex = 3;
            this.OptFacturasCobradas.TabStop = true;
            this.OptFacturasCobradas.Text = "Solo Facturas Cobradas";
            this.OptFacturasCobradas.UseVisualStyleBackColor = true;
            // 
            // OptFactTodas
            // 
            this.OptFactTodas.AutoSize = true;
            this.OptFactTodas.Checked = true;
            this.OptFactTodas.Location = new System.Drawing.Point(41, 7);
            this.OptFactTodas.Name = "OptFactTodas";
            this.OptFactTodas.Size = new System.Drawing.Size(115, 17);
            this.OptFactTodas.TabIndex = 2;
            this.OptFactTodas.TabStop = true;
            this.OptFactTodas.Text = "Todas las Facturas";
            this.OptFactTodas.UseVisualStyleBackColor = true;
            // 
            // frmSeleccionDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(943, 612);
            this.Controls.Add(this.panelFact1);
            this.Controls.Add(this.panelInclDet);
            this.Controls.Add(this.panelProv);
            this.Controls.Add(this.panelExclDet);
            this.Controls.Add(this.panelVended);
            this.Controls.Add(this.panelArt);
            this.Controls.Add(this.panelFec);
            this.Controls.Add(this.panelDet);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeleccionDatos";
            this.Text = "SELECCIÓN DE DATOS ";
            this.Load += new System.EventHandler(this.frmSeleccionDatos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDet.ResumeLayout(false);
            this.panelDet.PerformLayout();
            this.panelFec.ResumeLayout(false);
            this.panelFec.PerformLayout();
            this.panelVended.ResumeLayout(false);
            this.panelVended.PerformLayout();
            this.panelArt.ResumeLayout(false);
            this.panelArt.PerformLayout();
            this.panelExclDet.ResumeLayout(false);
            this.panelExclDet.PerformLayout();
            this.panelProv.ResumeLayout(false);
            this.panelProv.PerformLayout();
            this.panelInclDet.ResumeLayout(false);
            this.panelInclDet.PerformLayout();
            this.panelFact1.ResumeLayout(false);
            this.panelFact1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Exportar;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.Panel panelDet;
        private System.Windows.Forms.Label lDetFin;
        private System.Windows.Forms.Label lDetIni;
        private System.Windows.Forms.TextBox tDetFin;
        private System.Windows.Forms.TextBox tDetIni;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.LinkLabel llDetIni;
        private System.Windows.Forms.LinkLabel llDetFin;
        private System.Windows.Forms.Panel panelFec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tVendedIni;
        private System.Windows.Forms.TextBox tVendedFin;
        private System.Windows.Forms.LinkLabel llVendedIni;
        private System.Windows.Forms.LinkLabel llVendedFin;
        private System.Windows.Forms.Label lVendedIni;
        private System.Windows.Forms.Label lVendedFin;
        private System.Windows.Forms.Panel panelVended;
        private System.Windows.Forms.Panel panelArt;
        private System.Windows.Forms.LinkLabel llArtFin;
        private System.Windows.Forms.LinkLabel llArtIni;
        private System.Windows.Forms.Label lArtFin;
        private System.Windows.Forms.Label lArtIni;
        private System.Windows.Forms.TextBox tArtFin;
        private System.Windows.Forms.TextBox tArtIni;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelExclDet;
        private System.Windows.Forms.TextBox tDetExc;
        private System.Windows.Forms.ListBox ListDetExc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView L1;
        private System.Windows.Forms.Panel panelProv;
        private System.Windows.Forms.LinkLabel llProvFin;
        private System.Windows.Forms.LinkLabel llProvIni;
        private System.Windows.Forms.Label lProvFin;
        private System.Windows.Forms.Label lProvIni;
        private System.Windows.Forms.TextBox tProvFin;
        private System.Windows.Forms.TextBox tProvIni;
        private System.Windows.Forms.Panel panelInclDet;
        private System.Windows.Forms.ListView L2;
        private System.Windows.Forms.TextBox tDetInc;
        private System.Windows.Forms.ListBox ListDetInc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelFact1;
        private System.Windows.Forms.RadioButton OptFactPendientes;
        private System.Windows.Forms.RadioButton OptFacturasCobradas;
        private System.Windows.Forms.RadioButton OptFactTodas;
    }
}