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
    public partial class frmCOMPRAS : Form
    {
        public frmCOMPRAS()
        {
            InitializeComponent();
        }

        private void button_Compras_Entradas_Click(object sender, EventArgs e)
        {
            string gIdent = "";
            switch (button_Compras_Entradas.Text)
            {
                case "Entrada Compras ENDUMAR":
                    gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
                    GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCOMPRAS_Entrada_ENDU ");
                    frmCOMPRAS_Entrada_ENDU frmCENDU = new frmCOMPRAS_Entrada_ENDU();
                    frmCENDU.Show();
                    //frmCENDU.tbProCod.Focus();
                    break;
                default:
                    gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
                    GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCOMPRAS_Entrada");
                    frmCOMPRAS_Entrada frmC = new frmCOMPRAS_Entrada();
                    frmC.Show();
                    break;
            }
        }  // private void button_Compras_Entradas_Click(object sender, EventArgs e)

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        }  //private void button_Salir_Click(object sender, EventArgs e)

        private void btn_Ver_Alb_Compra_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCOMPRAS_Ver_Albs");
            frmCOMPRAS_Ver_Albs  frmC = new frmCOMPRAS_Ver_Albs();
            frmC.Show();
        }
        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1": //llorens
                    
                    break;
                case "2":  //Carabal
                    break;
                case "3":       //ENDUMAR
                    button_Compras_Entradas.Visible = true;
                    button_Compras_Entradas.Text = "Entrada Compras ENDUMAR";
                    break;
                case "5": //Dialpesca
                    button_Compras_Entradas.Visible = true;
                    btn_Ver_Alb_Compra.Visible = true;
                    break;
                case "6":  //ABT
                    break;
                case "8": //VALPEIX
                    button_Compras_Entradas.Visible = true;
                    btn_Ver_Alb_Compra.Visible = true;
                    break;
            }
        } //private void Seguridad()

        private void frmCOMPRAS_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCOMPRAS");
            this.Text = "Entrada de COMPRAS " + GloblaVar.VERSION;
            Seguridad();
        }
    }
}
