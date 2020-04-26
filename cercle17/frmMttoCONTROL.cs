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
    public partial class frmMttoCONTROL : Form
    {
        public frmMttoCONTROL()
        {
            InitializeComponent();
        }

        public string ivm51;

        private void frmMttoCONTROL_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            if (ivm51 != null)
            {
                textBox1.Text = ivm51;
            }
            textBox1.Focus();
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            ivm51 = Funciones.numerales(textBox1.Text);
        }
    }
}
