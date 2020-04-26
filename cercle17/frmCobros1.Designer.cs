namespace cercle17
{
    partial class frmCobros1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobros1));
            this.label1 = new System.Windows.Forms.Label();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Obs_Talon = new System.Windows.Forms.TextBox();
            this.textBox_Obs_Tarjeta = new System.Windows.Forms.TextBox();
            this.textBox_Obs_Deuda = new System.Windows.Forms.TextBox();
            this.textBox_Efectivo = new System.Windows.Forms.TextBox();
            this.textBox_Talon = new System.Windows.Forms.TextBox();
            this.textBox_Tarjeta = new System.Windows.Forms.TextBox();
            this.textBox_Pagare = new System.Windows.Forms.TextBox();
            this.textBox_Deuda = new System.Windows.Forms.TextBox();
            this.label_Importe_Total = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.textBox_Cambio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Recargo = new System.Windows.Forms.TextBox();
            this.textBox_IVA = new System.Windows.Forms.TextBox();
            this.textBox_BI = new System.Windows.Forms.TextBox();
            this.label_Recargo = new System.Windows.Forms.Label();
            this.label_IVA = new System.Windows.Forms.Label();
            this.label_BI = new System.Windows.Forms.Label();
            this.textBox_ACuenta = new System.Windows.Forms.TextBox();
            this.label_ACuenta = new System.Windows.Forms.Label();
            this.textBox_Transferencia = new System.Windows.Forms.TextBox();
            this.textBox_Obs_Transferencia = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gPagares = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMPORTE A COBRAR";
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Aceptar.Location = new System.Drawing.Point(574, 380);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(107, 38);
            this.button_Aceptar.TabIndex = 6;
            this.button_Aceptar.Text = "ACEPTAR";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancelar.Location = new System.Drawing.Point(33, 380);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(107, 38);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "CANCELAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Efectivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Talón";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tarjeta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pagaré";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Deuda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(214, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Observaciones";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(214, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Observaciones";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(207, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "Observaciones";
            // 
            // textBox_Obs_Talon
            // 
            this.textBox_Obs_Talon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Talon.Location = new System.Drawing.Point(339, 152);
            this.textBox_Obs_Talon.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Talon.Name = "textBox_Obs_Talon";
            this.textBox_Obs_Talon.Size = new System.Drawing.Size(399, 26);
            this.textBox_Obs_Talon.TabIndex = 9;
            this.textBox_Obs_Talon.Enter += new System.EventHandler(this.textBox_Obs_Talon_Enter);
            this.textBox_Obs_Talon.Leave += new System.EventHandler(this.textBox_Obs_Talon_Leave);
            // 
            // textBox_Obs_Tarjeta
            // 
            this.textBox_Obs_Tarjeta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Tarjeta.Location = new System.Drawing.Point(339, 194);
            this.textBox_Obs_Tarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Tarjeta.Name = "textBox_Obs_Tarjeta";
            this.textBox_Obs_Tarjeta.Size = new System.Drawing.Size(399, 26);
            this.textBox_Obs_Tarjeta.TabIndex = 10;
            this.textBox_Obs_Tarjeta.Enter += new System.EventHandler(this.textBox_Obs_Tarjeta_Enter);
            this.textBox_Obs_Tarjeta.Leave += new System.EventHandler(this.textBox_Obs_Tarjeta_Leave);
            // 
            // textBox_Obs_Deuda
            // 
            this.textBox_Obs_Deuda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Deuda.Location = new System.Drawing.Point(339, 321);
            this.textBox_Obs_Deuda.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Deuda.Name = "textBox_Obs_Deuda";
            this.textBox_Obs_Deuda.Size = new System.Drawing.Size(399, 26);
            this.textBox_Obs_Deuda.TabIndex = 16;
            this.textBox_Obs_Deuda.Enter += new System.EventHandler(this.textBox_Obs_Deuda_Enter);
            this.textBox_Obs_Deuda.Leave += new System.EventHandler(this.textBox_Obs_Deuda_Leave);
            // 
            // textBox_Efectivo
            // 
            this.textBox_Efectivo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Efectivo.Location = new System.Drawing.Point(121, 72);
            this.textBox_Efectivo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Efectivo.Name = "textBox_Efectivo";
            this.textBox_Efectivo.Size = new System.Drawing.Size(81, 26);
            this.textBox_Efectivo.TabIndex = 1;
            this.textBox_Efectivo.Enter += new System.EventHandler(this.textBox_Efectivo_Enter);
            this.textBox_Efectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Efectivo_KeyPress);
            this.textBox_Efectivo.Leave += new System.EventHandler(this.textBox_Efectivo_Leave);
            // 
            // textBox_Talon
            // 
            this.textBox_Talon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Talon.Location = new System.Drawing.Point(121, 152);
            this.textBox_Talon.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Talon.Name = "textBox_Talon";
            this.textBox_Talon.Size = new System.Drawing.Size(81, 26);
            this.textBox_Talon.TabIndex = 3;
            this.textBox_Talon.Enter += new System.EventHandler(this.textBox_Talon_Enter);
            this.textBox_Talon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Talon_KeyPress);
            this.textBox_Talon.Leave += new System.EventHandler(this.textBox_Talon_Leave);
            // 
            // textBox_Tarjeta
            // 
            this.textBox_Tarjeta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Tarjeta.Location = new System.Drawing.Point(121, 194);
            this.textBox_Tarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tarjeta.Name = "textBox_Tarjeta";
            this.textBox_Tarjeta.Size = new System.Drawing.Size(81, 26);
            this.textBox_Tarjeta.TabIndex = 4;
            this.textBox_Tarjeta.Enter += new System.EventHandler(this.textBox_Tarjeta_Enter);
            this.textBox_Tarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Tarjeta_KeyPress);
            this.textBox_Tarjeta.Leave += new System.EventHandler(this.textBox_Tarjeta_Leave);
            // 
            // textBox_Pagare
            // 
            this.textBox_Pagare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pagare.Location = new System.Drawing.Point(121, 233);
            this.textBox_Pagare.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Pagare.Name = "textBox_Pagare";
            this.textBox_Pagare.ReadOnly = true;
            this.textBox_Pagare.Size = new System.Drawing.Size(81, 26);
            this.textBox_Pagare.TabIndex = 5;
            this.textBox_Pagare.TextChanged += new System.EventHandler(this.textBox_Pagare_TextChanged);
            this.textBox_Pagare.Enter += new System.EventHandler(this.textBox_Pagare_Enter);
            this.textBox_Pagare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Pagare_KeyPress);
            this.textBox_Pagare.Leave += new System.EventHandler(this.textBox_Pagare_Leave);
            // 
            // textBox_Deuda
            // 
            this.textBox_Deuda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Deuda.Location = new System.Drawing.Point(115, 321);
            this.textBox_Deuda.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Deuda.Name = "textBox_Deuda";
            this.textBox_Deuda.ReadOnly = true;
            this.textBox_Deuda.Size = new System.Drawing.Size(81, 26);
            this.textBox_Deuda.TabIndex = 21;
            // 
            // label_Importe_Total
            // 
            this.label_Importe_Total.AutoSize = true;
            this.label_Importe_Total.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Importe_Total.Location = new System.Drawing.Point(292, 9);
            this.label_Importe_Total.Name = "label_Importe_Total";
            this.label_Importe_Total.Size = new System.Drawing.Size(18, 19);
            this.label_Importe_Total.TabIndex = 22;
            this.label_Importe_Total.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 380);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 16);
            this.textBox1.TabIndex = 24;
            this.textBox1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // textBox_Cambio
            // 
            this.textBox_Cambio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cambio.Location = new System.Drawing.Point(295, 72);
            this.textBox_Cambio.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Cambio.Name = "textBox_Cambio";
            this.textBox_Cambio.ReadOnly = true;
            this.textBox_Cambio.Size = new System.Drawing.Size(86, 26);
            this.textBox_Cambio.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(221, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 18);
            this.label12.TabIndex = 25;
            this.label12.Text = "Cambio";
            // 
            // textBox_Recargo
            // 
            this.textBox_Recargo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Recargo.Location = new System.Drawing.Point(644, 66);
            this.textBox_Recargo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Recargo.Name = "textBox_Recargo";
            this.textBox_Recargo.Size = new System.Drawing.Size(81, 26);
            this.textBox_Recargo.TabIndex = 30;
            // 
            // textBox_IVA
            // 
            this.textBox_IVA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IVA.Location = new System.Drawing.Point(644, 36);
            this.textBox_IVA.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_IVA.Name = "textBox_IVA";
            this.textBox_IVA.Size = new System.Drawing.Size(81, 26);
            this.textBox_IVA.TabIndex = 28;
            // 
            // textBox_BI
            // 
            this.textBox_BI.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BI.Location = new System.Drawing.Point(644, 6);
            this.textBox_BI.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_BI.Name = "textBox_BI";
            this.textBox_BI.Size = new System.Drawing.Size(81, 26);
            this.textBox_BI.TabIndex = 27;
            // 
            // label_Recargo
            // 
            this.label_Recargo.AutoSize = true;
            this.label_Recargo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Recargo.Location = new System.Drawing.Point(571, 70);
            this.label_Recargo.Name = "label_Recargo";
            this.label_Recargo.Size = new System.Drawing.Size(68, 18);
            this.label_Recargo.TabIndex = 32;
            this.label_Recargo.Text = "Recargo";
            // 
            // label_IVA
            // 
            this.label_IVA.AutoSize = true;
            this.label_IVA.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IVA.Location = new System.Drawing.Point(609, 40);
            this.label_IVA.Name = "label_IVA";
            this.label_IVA.Size = new System.Drawing.Size(29, 18);
            this.label_IVA.TabIndex = 31;
            this.label_IVA.Text = "IVA";
            // 
            // label_BI
            // 
            this.label_BI.AutoSize = true;
            this.label_BI.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BI.Location = new System.Drawing.Point(522, 10);
            this.label_BI.Name = "label_BI";
            this.label_BI.Size = new System.Drawing.Size(117, 18);
            this.label_BI.TabIndex = 29;
            this.label_BI.Text = "Base Imponible";
            // 
            // textBox_ACuenta
            // 
            this.textBox_ACuenta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ACuenta.Location = new System.Drawing.Point(470, 72);
            this.textBox_ACuenta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ACuenta.Name = "textBox_ACuenta";
            this.textBox_ACuenta.Size = new System.Drawing.Size(81, 26);
            this.textBox_ACuenta.TabIndex = 34;
            this.textBox_ACuenta.TextChanged += new System.EventHandler(this.textBox_ACuenta_TextChanged);
            // 
            // label_ACuenta
            // 
            this.label_ACuenta.AutoSize = true;
            this.label_ACuenta.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ACuenta.Location = new System.Drawing.Point(391, 76);
            this.label_ACuenta.Name = "label_ACuenta";
            this.label_ACuenta.Size = new System.Drawing.Size(71, 18);
            this.label_ACuenta.TabIndex = 35;
            this.label_ACuenta.Text = "A Cuenta";
            // 
            // textBox_Transferencia
            // 
            this.textBox_Transferencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Transferencia.Location = new System.Drawing.Point(121, 114);
            this.textBox_Transferencia.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Transferencia.Name = "textBox_Transferencia";
            this.textBox_Transferencia.Size = new System.Drawing.Size(81, 26);
            this.textBox_Transferencia.TabIndex = 2;
            this.textBox_Transferencia.Enter += new System.EventHandler(this.textBox_Transferencia_Enter);
            this.textBox_Transferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Transferencia_KeyPress);
            this.textBox_Transferencia.Leave += new System.EventHandler(this.textBox_Transferencia_Leave);
            // 
            // textBox_Obs_Transferencia
            // 
            this.textBox_Obs_Transferencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Obs_Transferencia.Location = new System.Drawing.Point(339, 114);
            this.textBox_Obs_Transferencia.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Obs_Transferencia.Name = "textBox_Obs_Transferencia";
            this.textBox_Obs_Transferencia.Size = new System.Drawing.Size(399, 26);
            this.textBox_Obs_Transferencia.TabIndex = 8;
            this.textBox_Obs_Transferencia.Enter += new System.EventHandler(this.textBox_Obs_Transferencia_Enter);
            this.textBox_Obs_Transferencia.Leave += new System.EventHandler(this.textBox_Obs_Transferencia_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(214, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 39;
            this.label13.Text = "Observaciones";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 18);
            this.label14.TabIndex = 37;
            this.label14.Text = "Transferencia";
            // 
            // gPagares
            // 
            this.gPagares.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gPagares.DefaultCellStyle = dataGridViewCellStyle1;
            this.gPagares.Location = new System.Drawing.Point(217, 233);
            this.gPagares.MultiSelect = false;
            this.gPagares.Name = "gPagares";
            this.gPagares.RowHeadersVisible = false;
            this.gPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gPagares.Size = new System.Drawing.Size(521, 73);
            this.gPagares.TabIndex = 40;
            this.gPagares.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gPagares_CellContentClick);
            // 
            // frmCobros1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(757, 433);
            this.Controls.Add(this.gPagares);
            this.Controls.Add(this.textBox_Transferencia);
            this.Controls.Add(this.textBox_Obs_Transferencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_ACuenta);
            this.Controls.Add(this.label_ACuenta);
            this.Controls.Add(this.textBox_Recargo);
            this.Controls.Add(this.textBox_IVA);
            this.Controls.Add(this.textBox_BI);
            this.Controls.Add(this.label_Recargo);
            this.Controls.Add(this.label_IVA);
            this.Controls.Add(this.label_BI);
            this.Controls.Add(this.textBox_Cambio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Importe_Total);
            this.Controls.Add(this.textBox_Deuda);
            this.Controls.Add(this.textBox_Pagare);
            this.Controls.Add(this.textBox_Tarjeta);
            this.Controls.Add(this.textBox_Talon);
            this.Controls.Add(this.textBox_Efectivo);
            this.Controls.Add(this.textBox_Obs_Deuda);
            this.Controls.Add(this.textBox_Obs_Tarjeta);
            this.Controls.Add(this.textBox_Obs_Talon);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCobros1";
            this.Text = "    IMPORTE COBRO";
            this.Load += new System.EventHandler(this.frmCobros1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gPagares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Obs_Talon;
        private System.Windows.Forms.TextBox textBox_Obs_Tarjeta;
        private System.Windows.Forms.TextBox textBox_Obs_Deuda;
        private System.Windows.Forms.TextBox textBox_Efectivo;
        private System.Windows.Forms.TextBox textBox_Talon;
        private System.Windows.Forms.TextBox textBox_Tarjeta;
        private System.Windows.Forms.TextBox textBox_Pagare;
        private System.Windows.Forms.TextBox textBox_Deuda;
        private System.Windows.Forms.Label label_Importe_Total;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox textBox_Cambio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Recargo;
        private System.Windows.Forms.TextBox textBox_IVA;
        private System.Windows.Forms.TextBox textBox_BI;
        private System.Windows.Forms.Label label_Recargo;
        private System.Windows.Forms.Label label_IVA;
        private System.Windows.Forms.Label label_BI;
        private System.Windows.Forms.TextBox textBox_ACuenta;
        private System.Windows.Forms.Label label_ACuenta;
        private System.Windows.Forms.TextBox textBox_Transferencia;
        private System.Windows.Forms.TextBox textBox_Obs_Transferencia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView gPagares;
    }
}