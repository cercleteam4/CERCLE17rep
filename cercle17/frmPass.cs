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
    public partial class frmPass : Form
    {
        public frmPass()
        {
            InitializeComponent();
        }

        public string user, pass;

        private void button1_Click(object sender, EventArgs e)
        {
            //se devuelven los textos al programa principal

            user = textBox_User.Text;
            pass = textBox_Pass.Text;
        }

        private void textBox_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button1_Click(this, null);
                this.DialogResult = DialogResult.OK;
                //text
            }
        }

        private void frmPass_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);
            label3.Text = GloblaVar.VERSION;
            textBox_User.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void textBox_User_Enter(object sender, EventArgs e)
        {
            textBox_User.BackColor = Color.Yellow;
        }
        private void textBox_User_Leave(object sender, EventArgs e)
        {
            textBox_User.BackColor = Color.White;
        }
        private void textBox_User_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Return))
            {
                textBox_Pass.Focus();
            }
        }

        private void textBox_Pass_Enter(object sender, EventArgs e)
        {
            textBox_Pass.BackColor = Color.Yellow;
        }

        private void textBox_Pass_Leave(object sender, EventArgs e)
        {
            textBox_Pass.BackColor = Color.White;
        }
    }
}
