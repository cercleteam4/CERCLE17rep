using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmDatosFactOremape : Form
    {
        public frmDatosFactOremape()
        {
            InitializeComponent();
        }

        public string OremapeFactura, OremapeAñoFact, OremapeSerieFact;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtFactura.Text != "" && txtAñoFact.Text != "" && txtSerieFact.Text != "")
            {
                OremapeFactura = txtFactura.Text;
                OremapeAñoFact = txtAñoFact.Text;
                OremapeSerieFact = txtSerieFact.Text;

                this.Close();
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }

        }
    }
}
