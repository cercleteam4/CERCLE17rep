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
    public partial class frmDescobro : Form
    {
        public frmDescobro()
        {
            InitializeComponent();
        }

        public string num_recibo, tipo51;

        private void button1_Click(object sender, EventArgs e)
        {
            num_recibo = textBox1.Text;
        }

        private void frmDescobro_Load(object sender, EventArgs e)
        {
            if (tipo51 == "51")
            {
                this.Text = "     Descobro 51";
            }
        }
    }
}
