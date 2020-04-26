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
    public partial class FormPassword : Form
    {
        public FormPassword()
        {
            InitializeComponent();
        }

        public string paswd;

        private void button1_Click(object sender, EventArgs e)
        {
            paswd = textBox1.Text;
        }

        private void FormPassword_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                button1_Click(this, null);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
