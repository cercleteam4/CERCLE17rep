using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace cercle17
{
    public partial class FormAlbaran : Form
    {
        public FormAlbaran()
        {
            InitializeComponent();
        }

        public string ticket;

        private void FormAlbaran_Load(object sender, EventArgs e)
        {
            pictureBox_ticket.Load(ticket);
        }

        private void button_Imprimir_Click(object sender, EventArgs e)
        {
            //primero comprobamos IMPRE_RECIBOS, que debe estar en el fichero OrelessCFG

            if (frmInicioCaja.IMPRE_RECIBOS != "")
            {
                string new_file = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\ImpAlbs.txt";
                string impresora = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\ImprimeAlbsNet.exe";
                try
                {
                    if (File.Exists(new_file))
                    {
                        File.Delete(new_file);
                    }

                    using (FileStream fs = File.Create(new_file))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(frmInicioCaja.IMPRE_RECIBOS + "\r\n");
                        fs.Write(info, 0, info.Length);

                        Byte[] texto = new UTF8Encoding(true).GetBytes(ticket);
                        fs.Write(texto, 0, texto.Length);
                    }

                    Process.Start(impresora);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("No tiene impresora Configurada");
            }

            this.Close();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
