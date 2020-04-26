using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace cercle17
{
    public partial class Report_Cuadre_code : Form
    {
        public Report_Cuadre_code()
        {
            InitializeComponent();
        }


        public string fecha;

        private void Report_Cuadre_code_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;
            myReport = new Report_Cuadre();

            CrystalDecisions.Shared.TableLogOnInfo tliActual;

            //leer cadena de conexión
            string server = frmPpal.LOCAL;
            string database = frmPpal.DATABASE;

            //string userid = "reports";
            //string paswd = "crystal";

            foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myReport.Database.Tables)
            {
                tliActual = tbA.LogOnInfo;
                tliActual.ConnectionInfo.ServerName = server;         //"localhost\\SQLEXPRESS";
                tliActual.ConnectionInfo.DatabaseName = database;       //"OREMAPEREMdb";
                tliActual.ConnectionInfo.UserID = "";
                tliActual.ConnectionInfo.Password = "";
                tliActual.ConnectionInfo.IntegratedSecurity = true;
                tbA.ApplyLogOnInfo(tliActual);
            }
            DateTime dt = Convert.ToDateTime(fecha);

            myReport.DataDefinition.RecordSelectionFormula = "{command.Fecha}= Date(" + dt.Year.ToString() + ", " + dt.Month.ToString() + ", " + dt.Day.ToString() + ")";


            crystalReportViewer1.ReportSource = myReport;

            crystalReportViewer1.Zoom(75);
        }
    }
}
