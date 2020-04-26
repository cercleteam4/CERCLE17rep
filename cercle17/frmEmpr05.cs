using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmEmpr05 : Form
    {
        public SqlConnection CnO;
        public frmEmpr05()
        {
            InitializeComponent();
        }
        private void button_CUADRE_Click(object sender, EventArgs e)
        {
            frmEmpr05_CUADRE frmE5C = new frmEmpr05_CUADRE();
            frmE5C.Show();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("SALIENDO de " + gIdent);
            this.Close();
        }


    }
}
