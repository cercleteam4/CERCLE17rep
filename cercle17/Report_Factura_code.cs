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
using CrystalDecisions.Shared;

namespace cercle17
{
    public partial class Report_Factura_code : Form
    {
        public Report_Factura_code()
        {
            InitializeComponent();
        }

        public clase_cabecera_factura factura;
        public string serie, base_imponible, iva, recargo, total_importe, detnom, detcod, detvia, detmun, detnif, datos_mayorista, texto_cabecera, observaciones, texto_pie;
        public bool SerieANG;
        public string SubSerie;

        private void Report_Factura_code_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;
            myReport = new Report_Factura_Carabal();
            GloblaVar.gUTIL.ATraza(" Usuario " + frmPpal.USUARIO);

            switch (frmPpal.USUARIO)
            {
                case "1": myReport = new Report_Factura_Llorens();
                    break;
                case "2": 
                    if (SubSerie=="ASG") { myReport = new CR007(); } else { myReport = new Report_Factura_Carabal(); }
                    SubSerie = "";
                    break;
                case "5":
                    myReport = new Report_Factura_Dialpesca();
                    break;
                case "8":
                    myReport = new Report_Factura_Valpeix();
                    break;
                default:
                    break;
            }
                        
            CrystalDecisions.Shared.TableLogOnInfo tliActual;

            //leer cadena de conexión
            string server = GloblaVar.gREMOTO_SERVER  ; 
            string database = GloblaVar.gREMOTO_BD ;

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
                GloblaVar.gUTIL.ATraza(gIdent + " Conectando a servidor " + server + " Base de datos " + database);
            }

            myReport.DataDefinition.RecordSelectionFormula = "{command.Factura}=" + factura.Factura + " and {command.Serie}='" + factura.Serie + "' and {command.Anyo}=" + factura.Anyo;
            
            myReport.SetParameterValue("idfactura", factura.Anyo + "/" + factura.Factura);
            myReport.SetParameterValue("serie", serie);
            myReport.SetParameterValue("base_imponible", base_imponible);
            myReport.SetParameterValue("iva", iva);
            myReport.SetParameterValue("recargo", recargo);
            myReport.SetParameterValue("importe_total", total_importe);
            myReport.SetParameterValue("datos_mayorista", datos_mayorista);
            myReport.SetParameterValue("detnom", detnom);
            myReport.SetParameterValue("detcod", detcod);
            myReport.SetParameterValue("detvia", detvia);
            myReport.SetParameterValue("detmun", detmun);
            myReport.SetParameterValue("detnif", detnif);
            myReport.SetParameterValue("fecha", factura.FechaEmision);

            myReport.SetParameterValue("texto_cabecera", texto_cabecera);
            myReport.SetParameterValue("observaciones", observaciones);
            myReport.SetParameterValue("texto_pie", texto_pie);

            //myReport.SetParameterValue("total_pagina", "1");

            crystalReportViewer1.ReportSource = myReport;
            crystalReportViewer1.SelectionFormula = "{command.Factura}=" + factura.Factura + " and {command.Serie}='" + factura.Serie + "' and {command.Anyo}=" + factura.Anyo;
            //crystalReportViewer1.ShowLastPage();
            //string TotalPage = crystalReportViewer1.GetCurrentPageNumber().ToString();
            //crystalReportViewer1.ShowFirstPage();

            //recargar el total páginas
            //myReport.SetParameterValue("total_pagina", "/" + TotalPage);
            //crystalReportViewer1.ReportSource = myReport;

            crystalReportViewer1.Zoom(75);
           
        }
    }
}
