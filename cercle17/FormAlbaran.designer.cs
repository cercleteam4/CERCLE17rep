namespace cercle17
{
    partial class FormAlbaran
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
            this.pictureBox_ticket = new System.Windows.Forms.PictureBox();
            this.button_Imprimir = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ticket)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ticket
            // 
            this.pictureBox_ticket.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_ticket.Name = "pictureBox_ticket";
            this.pictureBox_ticket.Size = new System.Drawing.Size(668, 252);
            this.pictureBox_ticket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ticket.TabIndex = 0;
            this.pictureBox_ticket.TabStop = false;
            // 
            // button_Imprimir
            // 
            this.button_Imprimir.Location = new System.Drawing.Point(469, 275);
            this.button_Imprimir.Name = "button_Imprimir";
            this.button_Imprimir.Size = new System.Drawing.Size(211, 41);
            this.button_Imprimir.TabIndex = 1;
            this.button_Imprimir.Text = "IMPRIMIR";
            this.button_Imprimir.UseVisualStyleBackColor = true;
            this.button_Imprimir.Click += new System.EventHandler(this.button_Imprimir_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(12, 275);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(211, 41);
            this.button_Cancelar.TabIndex = 2;
            this.button_Cancelar.Text = "CERRAR";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // FormAlbaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(698, 324);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Imprimir);
            this.Controls.Add(this.pictureBox_ticket);
            this.Name = "FormAlbaran";
            this.Text = "    Albarán";
            this.Load += new System.EventHandler(this.FormAlbaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ticket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ticket;
        private System.Windows.Forms.Button button_Imprimir;
        private System.Windows.Forms.Button button_Cancelar;
    }
}