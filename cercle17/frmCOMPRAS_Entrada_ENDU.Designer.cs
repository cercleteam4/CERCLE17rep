using System.Windows.Forms;

namespace cercle17
{
    partial class frmCOMPRAS_Entrada_ENDU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCOMPRAS_Entrada_ENDU));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBorrarAlb = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.button_Listado = new System.Windows.Forms.Button();
            this.button_Salir = new System.Windows.Forms.Button();
            this.dgvAlbLineas = new System.Windows.Forms.DataGridView();
            this.gbLineas = new System.Windows.Forms.GroupBox();
            this.lblTotalconGastos = new System.Windows.Forms.Label();
            this.lblTotalKilos = new System.Windows.Forms.Label();
            this.lblTotalCajas = new System.Windows.Forms.Label();
            this.lblTotalAlbaran = new System.Windows.Forms.Label();
            this.gbDetalleLinea = new System.Windows.Forms.GroupBox();
            this.lBarco = new System.Windows.Forms.Label();
            this.lImpteLinea = new System.Windows.Forms.Label();
            this.lCondEsps = new System.Windows.Forms.Label();
            this.tbPExpedidor2 = new System.Windows.Forms.TextBox();
            this.cbPais = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFCaptura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbZonaCaptura = new System.Windows.Forms.ComboBox();
            this.tbFCaducidad = new System.Windows.Forms.TextBox();
            this.tbFElaboracion = new System.Windows.Forms.TextBox();
            this.cbPresentacion = new System.Windows.Forms.ComboBox();
            this.cbObtencion = new System.Windows.Forms.ComboBox();
            this.lblArtePesca = new System.Windows.Forms.Label();
            this.cbArtePesca = new System.Windows.Forms.ComboBox();
            this.lblFCaducidad = new System.Windows.Forms.Label();
            this.lblFElaboracion = new System.Windows.Forms.Label();
            this.lblFDesembarco = new System.Windows.Forms.Label();
            this.dtpFCaducidad = new System.Windows.Forms.DateTimePicker();
            this.dtpFElaboracion = new System.Windows.Forms.DateTimePicker();
            this.dtpFDesembarco = new System.Windows.Forms.DateTimePicker();
            this.lblPtoDbco = new System.Windows.Forms.Label();
            this.cbPtoDbco = new System.Windows.Forms.ComboBox();
            this.lblBarco = new System.Windows.Forms.Label();
            this.cbBarco = new System.Windows.Forms.ComboBox();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.lblObtencion = new System.Windows.Forms.Label();
            this.btnAceptarLinea = new System.Windows.Forms.Button();
            this.lblComLpr = new System.Windows.Forms.Label();
            this.tbComLnl = new System.Windows.Forms.TextBox();
            this.btnCancelarLinea = new System.Windows.Forms.Button();
            this.tbComLim = new System.Windows.Forms.TextBox();
            this.lblComLki = new System.Windows.Forms.Label();
            this.lbalArticulo = new System.Windows.Forms.Label();
            this.lblComLca = new System.Windows.Forms.Label();
            this.tbArtCod = new System.Windows.Forms.TextBox();
            this.tbArtDes = new System.Windows.Forms.TextBox();
            this.btnArtBuscar = new System.Windows.Forms.Button();
            this.tbComLca = new System.Windows.Forms.TextBox();
            this.tbComLki = new System.Windows.Forms.TextBox();
            this.tbComLpr = new System.Windows.Forms.TextBox();
            this.btnEliminarLinea = new System.Windows.Forms.Button();
            this.gbEncabezado = new System.Windows.Forms.GroupBox();
            this.lblGastos = new System.Windows.Forms.Label();
            this.lCExped3 = new System.Windows.Forms.Label();
            this.lCExped2 = new System.Windows.Forms.Label();
            this.lCExped1 = new System.Windows.Forms.Label();
            this.btnBuscarAlbaran = new System.Windows.Forms.Button();
            this.tbAnyo = new System.Windows.Forms.TextBox();
            this.lblColla = new System.Windows.Forms.Label();
            this.lblPortes = new System.Windows.Forms.Label();
            this.tbColla = new System.Windows.Forms.TextBox();
            this.tbPortes = new System.Windows.Forms.TextBox();
            this.tbProNom = new System.Windows.Forms.TextBox();
            this.btnProvBuscar = new System.Windows.Forms.Button();
            this.tbProCod = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.tbComCpa = new System.Windows.Forms.TextBox();
            this.lblAlbNumero = new System.Windows.Forms.Label();
            this.lblAlbFecha = new System.Windows.Forms.Label();
            this.dtpComCfa = new System.Windows.Forms.DateTimePicker();
            this.lblLote = new System.Windows.Forms.Label();
            this.tbRef = new System.Windows.Forms.TextBox();
            this.ComLnl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComLim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtePesca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDesembarco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDesembarco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FElaboracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPartida = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbLineas)).BeginInit();
            this.gbLineas.SuspendLayout();
            this.gbDetalleLinea.SuspendLayout();
            this.gbEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.btnBorrarAlb);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.button_Listado);
            this.panel1.Controls.Add(this.button_Salir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1380, 76);
            this.panel1.TabIndex = 1;
            // 
            // btnBorrarAlb
            // 
            this.btnBorrarAlb.Image = global::cercle17.Properties.Resources.Papelera40x40;
            this.btnBorrarAlb.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBorrarAlb.Location = new System.Drawing.Point(426, 4);
            this.btnBorrarAlb.Name = "btnBorrarAlb";
            this.btnBorrarAlb.Size = new System.Drawing.Size(129, 69);
            this.btnBorrarAlb.TabIndex = 5;
            this.btnBorrarAlb.Text = "BORRAR ALB.";
            this.btnBorrarAlb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrarAlb.UseVisualStyleBackColor = true;
            this.btnBorrarAlb.Visible = false;
            this.btnBorrarAlb.Click += new System.EventHandler(this.btnBorrarAlb_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1159, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 68);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::cercle17.Properties.Resources.Guardar2;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(1018, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 69);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(169, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(118, 69);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // button_Listado
            // 
            this.button_Listado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Listado.Image = global::cercle17.Properties.Resources.printer21;
            this.button_Listado.Location = new System.Drawing.Point(293, 3);
            this.button_Listado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Listado.Name = "button_Listado";
            this.button_Listado.Size = new System.Drawing.Size(127, 70);
            this.button_Listado.TabIndex = 1;
            this.button_Listado.Text = "LISTAR";
            this.button_Listado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Listado.UseVisualStyleBackColor = true;
            this.button_Listado.Visible = false;
            this.button_Listado.Click += new System.EventHandler(this.button_Listado_Click);
            // 
            // button_Salir
            // 
            this.button_Salir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Salir.Image = global::cercle17.Properties.Resources.exit2;
            this.button_Salir.Location = new System.Drawing.Point(16, 4);
            this.button_Salir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(147, 70);
            this.button_Salir.TabIndex = 0;
            this.button_Salir.Text = "SALIR";
            this.button_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // dgvAlbLineas
            // 
            this.dgvAlbLineas.AllowUserToAddRows = false;
            this.dgvAlbLineas.AllowUserToDeleteRows = false;
            this.dgvAlbLineas.AllowUserToOrderColumns = true;
            this.dgvAlbLineas.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgvAlbLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComLnl,
            this.ArtCod,
            this.ArtDes,
            this.ComLca,
            this.ComLki,
            this.ComLpr,
            this.ComLim,
            this.Ref,
            this.ArtePesca,
            this.Obtencion,
            this.Presentacion,
            this.Matricula,
            this.PDesembarco,
            this.FDesembarco,
            this.FElaboracion,
            this.FCaducidad,
            this.Partida});
            this.dgvAlbLineas.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvAlbLineas.Location = new System.Drawing.Point(14, 20);
            this.dgvAlbLineas.Name = "dgvAlbLineas";
            this.dgvAlbLineas.ReadOnly = true;
            this.dgvAlbLineas.Size = new System.Drawing.Size(1275, 280);
            this.dgvAlbLineas.TabIndex = 9;
            this.dgvAlbLineas.DoubleClick += new System.EventHandler(this.dgvAlbLineas_DoubleClick);
            // 
            // gbLineas
            // 
            this.gbLineas.Controls.Add(this.lblTotalconGastos);
            this.gbLineas.Controls.Add(this.lblTotalKilos);
            this.gbLineas.Controls.Add(this.lblTotalCajas);
            this.gbLineas.Controls.Add(this.lblTotalAlbaran);
            this.gbLineas.Controls.Add(this.gbDetalleLinea);
            this.gbLineas.Controls.Add(this.btnEliminarLinea);
            this.gbLineas.Controls.Add(this.dgvAlbLineas);
            this.gbLineas.Location = new System.Drawing.Point(16, 188);
            this.gbLineas.Name = "gbLineas";
            this.gbLineas.Size = new System.Drawing.Size(1342, 492);
            this.gbLineas.TabIndex = 20;
            this.gbLineas.TabStop = false;
            this.gbLineas.Text = "LÍNEAS DE ALBARÁN";
            // 
            // lblTotalconGastos
            // 
            this.lblTotalconGastos.AutoSize = true;
            this.lblTotalconGastos.BackColor = System.Drawing.Color.White;
            this.lblTotalconGastos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalconGastos.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblTotalconGastos.Location = new System.Drawing.Point(1090, 319);
            this.lblTotalconGastos.Name = "lblTotalconGastos";
            this.lblTotalconGastos.Size = new System.Drawing.Size(146, 16);
            this.lblTotalconGastos.TabIndex = 38;
            this.lblTotalconGastos.Text = "TOTAL+GASTOS  0,00";
            // 
            // lblTotalKilos
            // 
            this.lblTotalKilos.AutoSize = true;
            this.lblTotalKilos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKilos.Location = new System.Drawing.Point(323, 318);
            this.lblTotalKilos.Name = "lblTotalKilos";
            this.lblTotalKilos.Size = new System.Drawing.Size(149, 16);
            this.lblTotalKilos.TabIndex = 37;
            this.lblTotalKilos.Text = "TOTAL KILOS:     0,00";
            this.lblTotalKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCajas
            // 
            this.lblTotalCajas.AutoSize = true;
            this.lblTotalCajas.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCajas.Location = new System.Drawing.Point(174, 318);
            this.lblTotalCajas.Name = "lblTotalCajas";
            this.lblTotalCajas.Size = new System.Drawing.Size(132, 16);
            this.lblTotalCajas.TabIndex = 36;
            this.lblTotalCajas.Text = "TOTAL CAJAS:     0";
            this.lblTotalCajas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAlbaran
            // 
            this.lblTotalAlbaran.AutoSize = true;
            this.lblTotalAlbaran.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAlbaran.Location = new System.Drawing.Point(1090, 303);
            this.lblTotalAlbaran.Name = "lblTotalAlbaran";
            this.lblTotalAlbaran.Size = new System.Drawing.Size(160, 16);
            this.lblTotalAlbaran.TabIndex = 35;
            this.lblTotalAlbaran.Text = "TOTAL ALBARÁN:     0,00";
            this.lblTotalAlbaran.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDetalleLinea
            // 
            this.gbDetalleLinea.Controls.Add(this.tbPartida);
            this.gbDetalleLinea.Controls.Add(this.lblLote);
            this.gbDetalleLinea.Controls.Add(this.tbRef);
            this.gbDetalleLinea.Controls.Add(this.lBarco);
            this.gbDetalleLinea.Controls.Add(this.lImpteLinea);
            this.gbDetalleLinea.Controls.Add(this.lCondEsps);
            this.gbDetalleLinea.Controls.Add(this.tbPExpedidor2);
            this.gbDetalleLinea.Controls.Add(this.cbPais);
            this.gbDetalleLinea.Controls.Add(this.label3);
            this.gbDetalleLinea.Controls.Add(this.label2);
            this.gbDetalleLinea.Controls.Add(this.dtpFCaptura);
            this.gbDetalleLinea.Controls.Add(this.label1);
            this.gbDetalleLinea.Controls.Add(this.cbZonaCaptura);
            this.gbDetalleLinea.Controls.Add(this.tbFCaducidad);
            this.gbDetalleLinea.Controls.Add(this.tbFElaboracion);
            this.gbDetalleLinea.Controls.Add(this.cbPresentacion);
            this.gbDetalleLinea.Controls.Add(this.cbObtencion);
            this.gbDetalleLinea.Controls.Add(this.lblArtePesca);
            this.gbDetalleLinea.Controls.Add(this.cbArtePesca);
            this.gbDetalleLinea.Controls.Add(this.lblFCaducidad);
            this.gbDetalleLinea.Controls.Add(this.lblFElaboracion);
            this.gbDetalleLinea.Controls.Add(this.lblFDesembarco);
            this.gbDetalleLinea.Controls.Add(this.dtpFCaducidad);
            this.gbDetalleLinea.Controls.Add(this.dtpFElaboracion);
            this.gbDetalleLinea.Controls.Add(this.dtpFDesembarco);
            this.gbDetalleLinea.Controls.Add(this.lblPtoDbco);
            this.gbDetalleLinea.Controls.Add(this.cbPtoDbco);
            this.gbDetalleLinea.Controls.Add(this.lblBarco);
            this.gbDetalleLinea.Controls.Add(this.cbBarco);
            this.gbDetalleLinea.Controls.Add(this.lblPresentacion);
            this.gbDetalleLinea.Controls.Add(this.lblObtencion);
            this.gbDetalleLinea.Controls.Add(this.btnAceptarLinea);
            this.gbDetalleLinea.Controls.Add(this.lblComLpr);
            this.gbDetalleLinea.Controls.Add(this.tbComLnl);
            this.gbDetalleLinea.Controls.Add(this.btnCancelarLinea);
            this.gbDetalleLinea.Controls.Add(this.tbComLim);
            this.gbDetalleLinea.Controls.Add(this.lblComLki);
            this.gbDetalleLinea.Controls.Add(this.lbalArticulo);
            this.gbDetalleLinea.Controls.Add(this.lblComLca);
            this.gbDetalleLinea.Controls.Add(this.tbArtCod);
            this.gbDetalleLinea.Controls.Add(this.tbArtDes);
            this.gbDetalleLinea.Controls.Add(this.btnArtBuscar);
            this.gbDetalleLinea.Controls.Add(this.tbComLca);
            this.gbDetalleLinea.Controls.Add(this.tbComLki);
            this.gbDetalleLinea.Controls.Add(this.tbComLpr);
            this.gbDetalleLinea.Location = new System.Drawing.Point(14, 337);
            this.gbDetalleLinea.Name = "gbDetalleLinea";
            this.gbDetalleLinea.Size = new System.Drawing.Size(1313, 149);
            this.gbDetalleLinea.TabIndex = 34;
            this.gbDetalleLinea.TabStop = false;
            this.gbDetalleLinea.Text = "DETALLE LÍNEA";
            // 
            // lBarco
            // 
            this.lBarco.AutoSize = true;
            this.lBarco.Location = new System.Drawing.Point(484, 120);
            this.lBarco.Name = "lBarco";
            this.lBarco.Size = new System.Drawing.Size(41, 15);
            this.lBarco.TabIndex = 126;
            this.lBarco.Text = "label4";
            this.lBarco.Visible = false;
            // 
            // lImpteLinea
            // 
            this.lImpteLinea.AutoSize = true;
            this.lImpteLinea.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lImpteLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lImpteLinea.Location = new System.Drawing.Point(490, 69);
            this.lImpteLinea.Name = "lImpteLinea";
            this.lImpteLinea.Size = new System.Drawing.Size(0, 14);
            this.lImpteLinea.TabIndex = 125;
            // 
            // lCondEsps
            // 
            this.lCondEsps.AutoSize = true;
            this.lCondEsps.Location = new System.Drawing.Point(837, 9);
            this.lCondEsps.Name = "lCondEsps";
            this.lCondEsps.Size = new System.Drawing.Size(157, 15);
            this.lCondEsps.TabIndex = 124;
            this.lCondEsps.Text = "CONSERVAR ENTRE 0 y 5º";
            this.lCondEsps.Visible = false;
            // 
            // tbPExpedidor2
            // 
            this.tbPExpedidor2.Location = new System.Drawing.Point(214, 19);
            this.tbPExpedidor2.Name = "tbPExpedidor2";
            this.tbPExpedidor2.Size = new System.Drawing.Size(85, 21);
            this.tbPExpedidor2.TabIndex = 123;
            this.tbPExpedidor2.Visible = false;
            // 
            // cbPais
            // 
            this.cbPais.FormattingEnabled = true;
            this.cbPais.Items.AddRange(new object[] {
            "BULGARIA",
            "CHILE",
            "DINAMARCA",
            "EEUU",
            "ESCOCIA",
            "ESPAÑA",
            "FRANCIA",
            "GRECIA",
            "HOLANDA",
            "INGLATERRA",
            "IRLANDA",
            "ISLANDIA",
            "ITALIA",
            "JAPON",
            "MARRUECOS",
            "NORUEGA",
            "PERU",
            "PORTUGAL",
            "SUDAFRICA",
            "TURQUIA"});
            this.cbPais.Location = new System.Drawing.Point(20, 94);
            this.cbPais.Name = "cbPais";
            this.cbPais.Size = new System.Drawing.Size(125, 23);
            this.cbPais.TabIndex = 11;
            this.cbPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPais_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 122;
            this.label3.Text = "PAÍS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 121;
            this.label2.Text = "F. CAPTURA";
            // 
            // dtpFCaptura
            // 
            this.dtpFCaptura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFCaptura.Location = new System.Drawing.Point(349, 96);
            this.dtpFCaptura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFCaptura.Name = "dtpFCaptura";
            this.dtpFCaptura.Size = new System.Drawing.Size(110, 21);
            this.dtpFCaptura.TabIndex = 13;
            this.dtpFCaptura.ValueChanged += new System.EventHandler(this.dtpFCaptura_ValueChanged);
            this.dtpFCaptura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFCaptura_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 119;
            this.label1.Text = "ZONA CAPTURA";
            // 
            // cbZonaCaptura
            // 
            this.cbZonaCaptura.FormattingEnabled = true;
            this.cbZonaCaptura.Location = new System.Drawing.Point(151, 94);
            this.cbZonaCaptura.Name = "cbZonaCaptura";
            this.cbZonaCaptura.Size = new System.Drawing.Size(190, 23);
            this.cbZonaCaptura.TabIndex = 12;
            this.cbZonaCaptura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbZonaCaptura_KeyDown);
            // 
            // tbFCaducidad
            // 
            this.tbFCaducidad.Location = new System.Drawing.Point(1072, 96);
            this.tbFCaducidad.Name = "tbFCaducidad";
            this.tbFCaducidad.Size = new System.Drawing.Size(82, 21);
            this.tbFCaducidad.TabIndex = 18;
            this.tbFCaducidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFCaducidad_KeyDown);
            // 
            // tbFElaboracion
            // 
            this.tbFElaboracion.Location = new System.Drawing.Point(954, 96);
            this.tbFElaboracion.Name = "tbFElaboracion";
            this.tbFElaboracion.Size = new System.Drawing.Size(82, 21);
            this.tbFElaboracion.TabIndex = 17;
            this.tbFElaboracion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFElaboracion_KeyDown);
            // 
            // cbPresentacion
            // 
            this.cbPresentacion.FormattingEnabled = true;
            this.cbPresentacion.Items.AddRange(new object[] {
            "Cocido",
            "Con cabeza",
            "Descongelado",
            "Eviscerado",
            "Fileteado",
            "Otros",
            "Sin cabeza"});
            this.cbPresentacion.Location = new System.Drawing.Point(1062, 43);
            this.cbPresentacion.Name = "cbPresentacion";
            this.cbPresentacion.Size = new System.Drawing.Size(120, 23);
            this.cbPresentacion.Sorted = true;
            this.cbPresentacion.TabIndex = 10;
            this.cbPresentacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPresentacion_KeyDown);
            // 
            // cbObtencion
            // 
            this.cbObtencion.FormattingEnabled = true;
            this.cbObtencion.Items.AddRange(new object[] {
            "Capturado",
            "Capturado en agua dulce",
            "De cría"});
            this.cbObtencion.Location = new System.Drawing.Point(869, 43);
            this.cbObtencion.Name = "cbObtencion";
            this.cbObtencion.Size = new System.Drawing.Size(187, 23);
            this.cbObtencion.Sorted = true;
            this.cbObtencion.TabIndex = 9;
            this.cbObtencion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbObtencion_KeyDown);
            // 
            // lblArtePesca
            // 
            this.lblArtePesca.AutoSize = true;
            this.lblArtePesca.Location = new System.Drawing.Point(675, 25);
            this.lblArtePesca.Name = "lblArtePesca";
            this.lblArtePesca.Size = new System.Drawing.Size(81, 15);
            this.lblArtePesca.TabIndex = 117;
            this.lblArtePesca.Text = "ARTE PESCA";
            // 
            // cbArtePesca
            // 
            this.cbArtePesca.FormattingEnabled = true;
            this.cbArtePesca.Items.AddRange(new object[] {
            "Nasas y trampas",
            "Rastras",
            "Redes de arrastre",
            "Redes de cerco y redes izadas",
            "Redes de enmalle y similares",
            "Redes de tiro",
            "Sedales y anzuelos"});
            this.cbArtePesca.Location = new System.Drawing.Point(673, 43);
            this.cbArtePesca.Name = "cbArtePesca";
            this.cbArtePesca.Size = new System.Drawing.Size(190, 23);
            this.cbArtePesca.Sorted = true;
            this.cbArtePesca.TabIndex = 8;
            this.cbArtePesca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbArtePesca_KeyDown);
            // 
            // lblFCaducidad
            // 
            this.lblFCaducidad.AutoSize = true;
            this.lblFCaducidad.Location = new System.Drawing.Point(1073, 76);
            this.lblFCaducidad.Name = "lblFCaducidad";
            this.lblFCaducidad.Size = new System.Drawing.Size(90, 15);
            this.lblFCaducidad.TabIndex = 115;
            this.lblFCaducidad.Text = "F. CADUCIDAD";
            // 
            // lblFElaboracion
            // 
            this.lblFElaboracion.AutoSize = true;
            this.lblFElaboracion.Location = new System.Drawing.Point(956, 76);
            this.lblFElaboracion.Name = "lblFElaboracion";
            this.lblFElaboracion.Size = new System.Drawing.Size(104, 15);
            this.lblFElaboracion.TabIndex = 114;
            this.lblFElaboracion.Text = "F. ELABORACIÓN";
            // 
            // lblFDesembarco
            // 
            this.lblFDesembarco.AutoSize = true;
            this.lblFDesembarco.Location = new System.Drawing.Point(837, 76);
            this.lblFDesembarco.Name = "lblFDesembarco";
            this.lblFDesembarco.Size = new System.Drawing.Size(103, 15);
            this.lblFDesembarco.TabIndex = 113;
            this.lblFDesembarco.Text = "F. DESEMBARCO";
            // 
            // dtpFCaducidad
            // 
            this.dtpFCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFCaducidad.Location = new System.Drawing.Point(1072, 96);
            this.dtpFCaducidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFCaducidad.Name = "dtpFCaducidad";
            this.dtpFCaducidad.Size = new System.Drawing.Size(110, 21);
            this.dtpFCaducidad.TabIndex = 33;
            this.dtpFCaducidad.ValueChanged += new System.EventHandler(this.dtpFCaducidad_ValueChanged);
            // 
            // dtpFElaboracion
            // 
            this.dtpFElaboracion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFElaboracion.Location = new System.Drawing.Point(954, 96);
            this.dtpFElaboracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFElaboracion.Name = "dtpFElaboracion";
            this.dtpFElaboracion.Size = new System.Drawing.Size(110, 21);
            this.dtpFElaboracion.TabIndex = 32;
            this.dtpFElaboracion.ValueChanged += new System.EventHandler(this.dtpFElaboracion_ValueChanged);
            // 
            // dtpFDesembarco
            // 
            this.dtpFDesembarco.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFDesembarco.Location = new System.Drawing.Point(837, 96);
            this.dtpFDesembarco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFDesembarco.Name = "dtpFDesembarco";
            this.dtpFDesembarco.Size = new System.Drawing.Size(110, 21);
            this.dtpFDesembarco.TabIndex = 16;
            this.dtpFDesembarco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFDesembarco_KeyDown);
            // 
            // lblPtoDbco
            // 
            this.lblPtoDbco.AutoSize = true;
            this.lblPtoDbco.Location = new System.Drawing.Point(648, 74);
            this.lblPtoDbco.Name = "lblPtoDbco";
            this.lblPtoDbco.Size = new System.Drawing.Size(144, 15);
            this.lblPtoDbco.TabIndex = 110;
            this.lblPtoDbco.Text = "PUERTO DESEMBARCO";
            // 
            // cbPtoDbco
            // 
            this.cbPtoDbco.FormattingEnabled = true;
            this.cbPtoDbco.Location = new System.Drawing.Point(651, 94);
            this.cbPtoDbco.Name = "cbPtoDbco";
            this.cbPtoDbco.Size = new System.Drawing.Size(180, 23);
            this.cbPtoDbco.TabIndex = 15;
            this.cbPtoDbco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPtoDbco_KeyDown);
            // 
            // lblBarco
            // 
            this.lblBarco.AutoSize = true;
            this.lblBarco.Location = new System.Drawing.Point(466, 76);
            this.lblBarco.Name = "lblBarco";
            this.lblBarco.Size = new System.Drawing.Size(49, 15);
            this.lblBarco.TabIndex = 108;
            this.lblBarco.Text = "BARCO";
            // 
            // cbBarco
            // 
            this.cbBarco.FormattingEnabled = true;
            this.cbBarco.Location = new System.Drawing.Point(465, 94);
            this.cbBarco.Name = "cbBarco";
            this.cbBarco.Size = new System.Drawing.Size(180, 23);
            this.cbBarco.TabIndex = 14;
            this.cbBarco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBarco_KeyDown);
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Location = new System.Drawing.Point(1062, 25);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(100, 15);
            this.lblPresentacion.TabIndex = 106;
            this.lblPresentacion.Text = "PRESENTACIÓN";
            // 
            // lblObtencion
            // 
            this.lblObtencion.AutoSize = true;
            this.lblObtencion.Location = new System.Drawing.Point(871, 25);
            this.lblObtencion.Name = "lblObtencion";
            this.lblObtencion.Size = new System.Drawing.Size(78, 15);
            this.lblObtencion.TabIndex = 105;
            this.lblObtencion.Text = "OBTENCIÓN";
            // 
            // btnAceptarLinea
            // 
            this.btnAceptarLinea.Location = new System.Drawing.Point(1197, 41);
            this.btnAceptarLinea.Name = "btnAceptarLinea";
            this.btnAceptarLinea.Size = new System.Drawing.Size(90, 29);
            this.btnAceptarLinea.TabIndex = 19;
            this.btnAceptarLinea.Text = "ACEPTAR";
            this.btnAceptarLinea.UseVisualStyleBackColor = true;
            this.btnAceptarLinea.Click += new System.EventHandler(this.btnAceptarLinea_Click);
            // 
            // lblComLpr
            // 
            this.lblComLpr.AutoSize = true;
            this.lblComLpr.Location = new System.Drawing.Point(485, 25);
            this.lblComLpr.Name = "lblComLpr";
            this.lblComLpr.Size = new System.Drawing.Size(53, 15);
            this.lblComLpr.TabIndex = 33;
            this.lblComLpr.Text = "PRECIO";
            // 
            // tbComLnl
            // 
            this.tbComLnl.Location = new System.Drawing.Point(89, 18);
            this.tbComLnl.Name = "tbComLnl";
            this.tbComLnl.Size = new System.Drawing.Size(28, 21);
            this.tbComLnl.TabIndex = 101;
            this.tbComLnl.Visible = false;
            this.tbComLnl.Enter += new System.EventHandler(this.tb_Enter);
            // 
            // btnCancelarLinea
            // 
            this.btnCancelarLinea.Location = new System.Drawing.Point(1197, 85);
            this.btnCancelarLinea.Name = "btnCancelarLinea";
            this.btnCancelarLinea.Size = new System.Drawing.Size(90, 29);
            this.btnCancelarLinea.TabIndex = 28;
            this.btnCancelarLinea.Text = "CANCELAR";
            this.btnCancelarLinea.UseVisualStyleBackColor = true;
            this.btnCancelarLinea.Click += new System.EventHandler(this.btnCancelarLinea_Click);
            // 
            // tbComLim
            // 
            this.tbComLim.Location = new System.Drawing.Point(123, 18);
            this.tbComLim.Name = "tbComLim";
            this.tbComLim.Size = new System.Drawing.Size(85, 21);
            this.tbComLim.TabIndex = 102;
            this.tbComLim.Visible = false;
            this.tbComLim.Enter += new System.EventHandler(this.tb_Enter);
            // 
            // lblComLki
            // 
            this.lblComLki.AutoSize = true;
            this.lblComLki.Location = new System.Drawing.Point(429, 25);
            this.lblComLki.Name = "lblComLki";
            this.lblComLki.Size = new System.Drawing.Size(42, 15);
            this.lblComLki.TabIndex = 32;
            this.lblComLki.Text = "KILOS";
            // 
            // lbalArticulo
            // 
            this.lbalArticulo.AutoSize = true;
            this.lbalArticulo.Location = new System.Drawing.Point(20, 25);
            this.lbalArticulo.Name = "lbalArticulo";
            this.lbalArticulo.Size = new System.Drawing.Size(67, 15);
            this.lbalArticulo.TabIndex = 30;
            this.lbalArticulo.Text = "ARTÍCULO";
            // 
            // lblComLca
            // 
            this.lblComLca.AutoSize = true;
            this.lblComLca.Location = new System.Drawing.Point(373, 25);
            this.lblComLca.Name = "lblComLca";
            this.lblComLca.Size = new System.Drawing.Size(44, 15);
            this.lblComLca.TabIndex = 31;
            this.lblComLca.Text = "CAJAS";
            // 
            // tbArtCod
            // 
            this.tbArtCod.Location = new System.Drawing.Point(20, 45);
            this.tbArtCod.Name = "tbArtCod";
            this.tbArtCod.Size = new System.Drawing.Size(53, 21);
            this.tbArtCod.TabIndex = 4;
            this.tbArtCod.Enter += new System.EventHandler(this.tb_Enter);
            this.tbArtCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbArtCod_KeyDown);
            this.tbArtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbArtCod_KeyPress);
            this.tbArtCod.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // tbArtDes
            // 
            this.tbArtDes.Location = new System.Drawing.Point(108, 45);
            this.tbArtDes.Name = "tbArtDes";
            this.tbArtDes.ReadOnly = true;
            this.tbArtDes.Size = new System.Drawing.Size(258, 21);
            this.tbArtDes.TabIndex = 23;
            // 
            // btnArtBuscar
            // 
            this.btnArtBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnArtBuscar.Image")));
            this.btnArtBuscar.Location = new System.Drawing.Point(79, 44);
            this.btnArtBuscar.Name = "btnArtBuscar";
            this.btnArtBuscar.Size = new System.Drawing.Size(23, 23);
            this.btnArtBuscar.TabIndex = 22;
            this.btnArtBuscar.UseVisualStyleBackColor = true;
            this.btnArtBuscar.Click += new System.EventHandler(this.btnArtBuscar_Click);
            // 
            // tbComLca
            // 
            this.tbComLca.Location = new System.Drawing.Point(372, 45);
            this.tbComLca.Name = "tbComLca";
            this.tbComLca.Size = new System.Drawing.Size(50, 21);
            this.tbComLca.TabIndex = 5;
            this.tbComLca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbComLca.Enter += new System.EventHandler(this.tb_Enter);
            this.tbComLca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbComLca_KeyDown);
            this.tbComLca.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // tbComLki
            // 
            this.tbComLki.Location = new System.Drawing.Point(428, 45);
            this.tbComLki.Name = "tbComLki";
            this.tbComLki.Size = new System.Drawing.Size(50, 21);
            this.tbComLki.TabIndex = 6;
            this.tbComLki.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbComLki.Enter += new System.EventHandler(this.tb_Enter);
            this.tbComLki.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbComLki_KeyDown);
            this.tbComLki.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // tbComLpr
            // 
            this.tbComLpr.Location = new System.Drawing.Point(484, 45);
            this.tbComLpr.Name = "tbComLpr";
            this.tbComLpr.Size = new System.Drawing.Size(50, 21);
            this.tbComLpr.TabIndex = 7;
            this.tbComLpr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbComLpr.Enter += new System.EventHandler(this.tb_Enter);
            this.tbComLpr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbComLpr_KeyDown);
            this.tbComLpr.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // btnEliminarLinea
            // 
            this.btnEliminarLinea.Image = global::cercle17.Properties.Resources.menos;
            this.btnEliminarLinea.Location = new System.Drawing.Point(1295, 20);
            this.btnEliminarLinea.Name = "btnEliminarLinea";
            this.btnEliminarLinea.Size = new System.Drawing.Size(32, 31);
            this.btnEliminarLinea.TabIndex = 29;
            this.btnEliminarLinea.UseVisualStyleBackColor = true;
            this.btnEliminarLinea.Click += new System.EventHandler(this.btnEliminarLinea_Click);
            // 
            // gbEncabezado
            // 
            this.gbEncabezado.Controls.Add(this.lblGastos);
            this.gbEncabezado.Controls.Add(this.lCExped3);
            this.gbEncabezado.Controls.Add(this.lCExped2);
            this.gbEncabezado.Controls.Add(this.lCExped1);
            this.gbEncabezado.Controls.Add(this.btnBuscarAlbaran);
            this.gbEncabezado.Controls.Add(this.tbAnyo);
            this.gbEncabezado.Controls.Add(this.lblColla);
            this.gbEncabezado.Controls.Add(this.lblPortes);
            this.gbEncabezado.Controls.Add(this.tbColla);
            this.gbEncabezado.Controls.Add(this.tbPortes);
            this.gbEncabezado.Controls.Add(this.tbProNom);
            this.gbEncabezado.Controls.Add(this.btnProvBuscar);
            this.gbEncabezado.Controls.Add(this.tbProCod);
            this.gbEncabezado.Controls.Add(this.lblProveedor);
            this.gbEncabezado.Controls.Add(this.tbComCpa);
            this.gbEncabezado.Controls.Add(this.lblAlbNumero);
            this.gbEncabezado.Controls.Add(this.lblAlbFecha);
            this.gbEncabezado.Controls.Add(this.dtpComCfa);
            this.gbEncabezado.Location = new System.Drawing.Point(16, 83);
            this.gbEncabezado.Name = "gbEncabezado";
            this.gbEncabezado.Size = new System.Drawing.Size(1342, 100);
            this.gbEncabezado.TabIndex = 21;
            this.gbEncabezado.TabStop = false;
            // 
            // lblGastos
            // 
            this.lblGastos.AutoSize = true;
            this.lblGastos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastos.Location = new System.Drawing.Point(859, 61);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(117, 16);
            this.lblGastos.TabIndex = 38;
            this.lblGastos.Text = "GASTOS:     0,00";
            this.lblGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCExped3
            // 
            this.lCExped3.AutoSize = true;
            this.lCExped3.Location = new System.Drawing.Point(1090, 68);
            this.lCExped3.Name = "lCExped3";
            this.lCExped3.Size = new System.Drawing.Size(101, 15);
            this.lCExped3.TabIndex = 107;
            this.lCExped3.Text = "46013 VALENCIA";
            this.lCExped3.Visible = false;
            // 
            // lCExped2
            // 
            this.lCExped2.AutoSize = true;
            this.lCExped2.Location = new System.Drawing.Point(1090, 44);
            this.lCExped2.Name = "lCExped2";
            this.lCExped2.Size = new System.Drawing.Size(113, 15);
            this.lCExped2.TabIndex = 106;
            this.lCExped2.Text = "Ctra. EN Corts, 231";
            this.lCExped2.Visible = false;
            // 
            // lCExped1
            // 
            this.lCExped1.AutoSize = true;
            this.lCExped1.Location = new System.Drawing.Point(1090, 17);
            this.lCExped1.Name = "lCExped1";
            this.lCExped1.Size = new System.Drawing.Size(67, 15);
            this.lCExped1.TabIndex = 105;
            this.lCExped1.Text = "ENDUMAR";
            this.lCExped1.Visible = false;
            // 
            // btnBuscarAlbaran
            // 
            this.btnBuscarAlbaran.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarAlbaran.Image")));
            this.btnBuscarAlbaran.Location = new System.Drawing.Point(410, 26);
            this.btnBuscarAlbaran.Name = "btnBuscarAlbaran";
            this.btnBuscarAlbaran.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarAlbaran.TabIndex = 104;
            this.btnBuscarAlbaran.UseVisualStyleBackColor = true;
            this.btnBuscarAlbaran.Click += new System.EventHandler(this.btnBuscarAlbaran_Click);
            // 
            // tbAnyo
            // 
            this.tbAnyo.Location = new System.Drawing.Point(478, 23);
            this.tbAnyo.Name = "tbAnyo";
            this.tbAnyo.Size = new System.Drawing.Size(61, 21);
            this.tbAnyo.TabIndex = 103;
            this.tbAnyo.Visible = false;
            // 
            // lblColla
            // 
            this.lblColla.AutoSize = true;
            this.lblColla.Location = new System.Drawing.Point(677, 62);
            this.lblColla.Name = "lblColla";
            this.lblColla.Size = new System.Drawing.Size(51, 15);
            this.lblColla.TabIndex = 24;
            this.lblColla.Text = "COLLA :";
            // 
            // lblPortes
            // 
            this.lblPortes.AutoSize = true;
            this.lblPortes.Location = new System.Drawing.Point(492, 62);
            this.lblPortes.Name = "lblPortes";
            this.lblPortes.Size = new System.Drawing.Size(62, 15);
            this.lblPortes.TabIndex = 23;
            this.lblPortes.Text = "PORTES :";
            // 
            // tbColla
            // 
            this.tbColla.Location = new System.Drawing.Point(734, 58);
            this.tbColla.Name = "tbColla";
            this.tbColla.Size = new System.Drawing.Size(100, 21);
            this.tbColla.TabIndex = 3;
            this.tbColla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbColla.Enter += new System.EventHandler(this.tb_Enter);
            this.tbColla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbColla_KeyDown);
            this.tbColla.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // tbPortes
            // 
            this.tbPortes.Location = new System.Drawing.Point(560, 58);
            this.tbPortes.Name = "tbPortes";
            this.tbPortes.Size = new System.Drawing.Size(100, 21);
            this.tbPortes.TabIndex = 2;
            this.tbPortes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPortes.Enter += new System.EventHandler(this.tb_Enter);
            this.tbPortes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPortes_KeyDown);
            this.tbPortes.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // tbProNom
            // 
            this.tbProNom.Location = new System.Drawing.Point(204, 58);
            this.tbProNom.Name = "tbProNom";
            this.tbProNom.ReadOnly = true;
            this.tbProNom.Size = new System.Drawing.Size(269, 21);
            this.tbProNom.TabIndex = 20;
            // 
            // btnProvBuscar
            // 
            this.btnProvBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnProvBuscar.Image")));
            this.btnProvBuscar.Location = new System.Drawing.Point(175, 58);
            this.btnProvBuscar.Name = "btnProvBuscar";
            this.btnProvBuscar.Size = new System.Drawing.Size(23, 23);
            this.btnProvBuscar.TabIndex = 19;
            this.btnProvBuscar.UseVisualStyleBackColor = true;
            this.btnProvBuscar.Click += new System.EventHandler(this.btnProvBuscar_Click);
            // 
            // tbProCod
            // 
            this.tbProCod.Location = new System.Drawing.Point(116, 58);
            this.tbProCod.Name = "tbProCod";
            this.tbProCod.Size = new System.Drawing.Size(53, 21);
            this.tbProCod.TabIndex = 1;
            this.tbProCod.Enter += new System.EventHandler(this.tb_Enter);
            this.tbProCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProCod_KeyDown);
            this.tbProCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProCod_KeyPress);
            this.tbProCod.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(21, 62);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(89, 15);
            this.lblProveedor.TabIndex = 17;
            this.lblProveedor.Text = "PROVEEDOR :";
            // 
            // tbComCpa
            // 
            this.tbComCpa.Location = new System.Drawing.Point(304, 26);
            this.tbComCpa.Name = "tbComCpa";
            this.tbComCpa.ReadOnly = true;
            this.tbComCpa.Size = new System.Drawing.Size(100, 21);
            this.tbComCpa.TabIndex = 16;
            // 
            // lblAlbNumero
            // 
            this.lblAlbNumero.AutoSize = true;
            this.lblAlbNumero.Location = new System.Drawing.Point(231, 29);
            this.lblAlbNumero.Name = "lblAlbNumero";
            this.lblAlbNumero.Size = new System.Drawing.Size(67, 15);
            this.lblAlbNumero.TabIndex = 15;
            this.lblAlbNumero.Text = "ALBARÁN :";
            // 
            // lblAlbFecha
            // 
            this.lblAlbFecha.AutoSize = true;
            this.lblAlbFecha.Location = new System.Drawing.Point(21, 29);
            this.lblAlbFecha.Name = "lblAlbFecha";
            this.lblAlbFecha.Size = new System.Drawing.Size(52, 15);
            this.lblAlbFecha.TabIndex = 14;
            this.lblAlbFecha.Text = "FECHA :";
            // 
            // dtpComCfa
            // 
            this.dtpComCfa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpComCfa.Location = new System.Drawing.Point(116, 26);
            this.dtpComCfa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpComCfa.Name = "dtpComCfa";
            this.dtpComCfa.Size = new System.Drawing.Size(100, 21);
            this.dtpComCfa.TabIndex = 13;
            this.dtpComCfa.ValueChanged += new System.EventHandler(this.dtpComCfa_ValueChanged);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(543, 25);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(38, 15);
            this.lblLote.TabIndex = 128;
            this.lblLote.Text = "LOTE";
            // 
            // tbRef
            // 
            this.tbRef.Location = new System.Drawing.Point(540, 45);
            this.tbRef.MaxLength = 15;
            this.tbRef.Name = "tbRef";
            this.tbRef.Size = new System.Drawing.Size(127, 21);
            this.tbRef.TabIndex = 8;
            this.tbRef.Enter += new System.EventHandler(this.tb_Enter);
            this.tbRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRef_KeyDown);
            this.tbRef.Leave += new System.EventHandler(this.tb_Leave);
            // 
            // ComLnl
            // 
            this.ComLnl.DataPropertyName = "ComLnl";
            this.ComLnl.HeaderText = "Lin";
            this.ComLnl.Name = "ComLnl";
            this.ComLnl.ReadOnly = true;
            this.ComLnl.Width = 30;
            // 
            // ArtCod
            // 
            this.ArtCod.DataPropertyName = "ArtCod";
            this.ArtCod.HeaderText = "Cod.Art.";
            this.ArtCod.Name = "ArtCod";
            this.ArtCod.ReadOnly = true;
            this.ArtCod.Width = 70;
            // 
            // ArtDes
            // 
            this.ArtDes.DataPropertyName = "ArtDes";
            this.ArtDes.HeaderText = "Desc. Art.";
            this.ArtDes.Name = "ArtDes";
            this.ArtDes.ReadOnly = true;
            this.ArtDes.Width = 150;
            // 
            // ComLca
            // 
            this.ComLca.DataPropertyName = "ComLca";
            this.ComLca.HeaderText = "Cajas";
            this.ComLca.Name = "ComLca";
            this.ComLca.ReadOnly = true;
            this.ComLca.Width = 50;
            // 
            // ComLki
            // 
            this.ComLki.DataPropertyName = "ComLki";
            this.ComLki.HeaderText = "Kilos";
            this.ComLki.Name = "ComLki";
            this.ComLki.ReadOnly = true;
            this.ComLki.Width = 70;
            // 
            // ComLpr
            // 
            this.ComLpr.DataPropertyName = "ComLpr";
            this.ComLpr.HeaderText = "Precio";
            this.ComLpr.Name = "ComLpr";
            this.ComLpr.ReadOnly = true;
            this.ComLpr.Width = 70;
            // 
            // ComLim
            // 
            this.ComLim.DataPropertyName = "ComLim";
            this.ComLim.HeaderText = "Importe";
            this.ComLim.Name = "ComLim";
            this.ComLim.ReadOnly = true;
            this.ComLim.Width = 70;
            // 
            // Ref
            // 
            this.Ref.DataPropertyName = "Ref";
            this.Ref.HeaderText = "Lote";
            this.Ref.Name = "Ref";
            this.Ref.ReadOnly = true;
            this.Ref.Width = 80;
            // 
            // ArtePesca
            // 
            this.ArtePesca.DataPropertyName = "ArtePesca";
            this.ArtePesca.HeaderText = "Arte Pesca";
            this.ArtePesca.Name = "ArtePesca";
            this.ArtePesca.ReadOnly = true;
            // 
            // Obtencion
            // 
            this.Obtencion.DataPropertyName = "Obtencion";
            this.Obtencion.HeaderText = "Obtención";
            this.Obtencion.Name = "Obtencion";
            this.Obtencion.ReadOnly = true;
            // 
            // Presentacion
            // 
            this.Presentacion.DataPropertyName = "Presentacion";
            this.Presentacion.HeaderText = "Presentación";
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.ReadOnly = true;
            // 
            // Matricula
            // 
            this.Matricula.DataPropertyName = "Matricula";
            this.Matricula.HeaderText = "Barco";
            this.Matricula.Name = "Matricula";
            this.Matricula.ReadOnly = true;
            this.Matricula.Width = 110;
            // 
            // PDesembarco
            // 
            this.PDesembarco.DataPropertyName = "PDesembarco";
            this.PDesembarco.HeaderText = "Pto. Dbco.";
            this.PDesembarco.Name = "PDesembarco";
            this.PDesembarco.ReadOnly = true;
            this.PDesembarco.Width = 120;
            // 
            // FDesembarco
            // 
            this.FDesembarco.DataPropertyName = "FDesembarco";
            this.FDesembarco.HeaderText = "F.Dbco.";
            this.FDesembarco.Name = "FDesembarco";
            this.FDesembarco.ReadOnly = true;
            this.FDesembarco.Width = 70;
            // 
            // FElaboracion
            // 
            this.FElaboracion.DataPropertyName = "FElaboracion";
            this.FElaboracion.HeaderText = "F.Elab.";
            this.FElaboracion.Name = "FElaboracion";
            this.FElaboracion.ReadOnly = true;
            this.FElaboracion.Width = 70;
            // 
            // FCaducidad
            // 
            this.FCaducidad.DataPropertyName = "FCaducidad";
            this.FCaducidad.HeaderText = "F.Caduc.";
            this.FCaducidad.Name = "FCaducidad";
            this.FCaducidad.ReadOnly = true;
            this.FCaducidad.Width = 70;
            // 
            // Partida
            // 
            this.Partida.DataPropertyName = "Partida";
            this.Partida.HeaderText = "Partida";
            this.Partida.Name = "Partida";
            this.Partida.ReadOnly = true;
            // 
            // tbPartida
            // 
            this.tbPartida.Location = new System.Drawing.Point(303, 19);
            this.tbPartida.Name = "tbPartida";
            this.tbPartida.Size = new System.Drawing.Size(64, 21);
            this.tbPartida.TabIndex = 129;
            this.tbPartida.Visible = false;
            // 
            // frmCOMPRAS_Entrada_ENDU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1380, 695);
            this.Controls.Add(this.gbEncabezado);
            this.Controls.Add(this.gbLineas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCOMPRAS_Entrada_ENDU";
            this.Text = "    Albarán de compras";
            this.Activated += new System.EventHandler(this.frmCOMPRAS_Entrada_ENDU_Activated);
            this.Load += new System.EventHandler(this.frmCOMPRAS_Entrada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCOMPRAS_Entrada_ENDU_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbLineas)).EndInit();
            this.gbLineas.ResumeLayout(false);
            this.gbLineas.PerformLayout();
            this.gbDetalleLinea.ResumeLayout(false);
            this.gbDetalleLinea.PerformLayout();
            this.gbEncabezado.ResumeLayout(false);
            this.gbEncabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Listado;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.DataGridView dgvAlbLineas;
        private System.Windows.Forms.GroupBox gbLineas;
        private System.Windows.Forms.Button btnEliminarLinea;
        private System.Windows.Forms.Button btnCancelarLinea;
        private System.Windows.Forms.TextBox tbComLnl;
        private System.Windows.Forms.TextBox tbComLim;
        private System.Windows.Forms.TextBox tbComLpr;
        private System.Windows.Forms.TextBox tbComLki;
        private System.Windows.Forms.TextBox tbComLca;
        private System.Windows.Forms.Button btnAceptarLinea;
        private System.Windows.Forms.GroupBox gbEncabezado;
        private System.Windows.Forms.Label lblColla;
        private System.Windows.Forms.Label lblPortes;
        private System.Windows.Forms.TextBox tbColla;
        private System.Windows.Forms.TextBox tbPortes;
        private System.Windows.Forms.TextBox tbProNom;
        private System.Windows.Forms.Button btnProvBuscar;
        private System.Windows.Forms.TextBox tbProCod;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox tbComCpa;
        private System.Windows.Forms.Label lblAlbNumero;
        private System.Windows.Forms.Label lblAlbFecha;
        private System.Windows.Forms.DateTimePicker dtpComCfa;
        private System.Windows.Forms.Label lblComLpr;
        private System.Windows.Forms.Label lblComLki;
        private System.Windows.Forms.Label lblComLca;
        private System.Windows.Forms.Label lbalArticulo;
        private System.Windows.Forms.Button btnArtBuscar;
        private System.Windows.Forms.TextBox tbArtDes;
        private System.Windows.Forms.TextBox tbArtCod;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox tbAnyo;
        private System.Windows.Forms.Label lblTotalAlbaran;
        private System.Windows.Forms.GroupBox gbDetalleLinea;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.Label lblObtencion;
        private System.Windows.Forms.Label lblBarco;
        private System.Windows.Forms.ComboBox cbBarco;
        private System.Windows.Forms.Label lblPtoDbco;
        private System.Windows.Forms.ComboBox cbPtoDbco;
        private System.Windows.Forms.Label lblFCaducidad;
        private System.Windows.Forms.Label lblFElaboracion;
        private System.Windows.Forms.Label lblFDesembarco;
        private System.Windows.Forms.DateTimePicker dtpFCaducidad;
        private System.Windows.Forms.DateTimePicker dtpFElaboracion;
        private System.Windows.Forms.DateTimePicker dtpFDesembarco;
        private System.Windows.Forms.Button btnBuscarAlbaran;
        private System.Windows.Forms.Label lblArtePesca;
        private System.Windows.Forms.ComboBox cbArtePesca;
        private System.Windows.Forms.ComboBox cbObtencion;
        private System.Windows.Forms.ComboBox cbPresentacion;
        private System.Windows.Forms.TextBox tbFElaboracion;
        private System.Windows.Forms.TextBox tbFCaducidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFCaptura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbZonaCaptura;
        private ComboBox cbPais;
        private Label label3;
        private TextBox tbPExpedidor2;
        private Label lCExped3;
        private Label lCExped2;
        private Label lCExped1;
        private Label lCondEsps;
        private Label lblTotalKilos;
        private Label lblTotalCajas;
        private Label lblGastos;
        private Label lblTotalconGastos;
        private Label lImpteLinea;
        private Button btnBorrarAlb;
        private Label lBarco;
        private Label lblLote;
        private TextBox tbRef;
        private DataGridViewTextBoxColumn ComLnl;
        private DataGridViewTextBoxColumn ArtCod;
        private DataGridViewTextBoxColumn ArtDes;
        private DataGridViewTextBoxColumn ComLca;
        private DataGridViewTextBoxColumn ComLki;
        private DataGridViewTextBoxColumn ComLpr;
        private DataGridViewTextBoxColumn ComLim;
        private DataGridViewTextBoxColumn Ref;
        private DataGridViewTextBoxColumn ArtePesca;
        private DataGridViewTextBoxColumn Obtencion;
        private DataGridViewTextBoxColumn Presentacion;
        private DataGridViewTextBoxColumn Matricula;
        private DataGridViewTextBoxColumn PDesembarco;
        private DataGridViewTextBoxColumn FDesembarco;
        private DataGridViewTextBoxColumn FElaboracion;
        private DataGridViewTextBoxColumn FCaducidad;
        private DataGridViewTextBoxColumn Partida;
        private TextBox tbPartida;

        public TextBox TbComLim { get => TbComLim1; set => TbComLim1 = value; }
        public TextBox TbComLim1 { get => tbComLim; set => tbComLim = value; }
    }
}