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
    public partial class frmExportaContaplus : Form
    {
        public frmExportaContaplus()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void button_Exporta_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //crear fichero de exportación de facturas

            string strQ = "SELECT * FROM FACTV_CABE WHERE FechaEmision BETWEEN '" + dateTimePicker_Inicio.Value.ToShortDateString() + "' AND '" + dateTimePicker_Final.Value.ToShortDateString() + "' ORDER BY FechaEmision, Factura";




        }
    }
}
