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
    public partial class frmCR1 : Form
    {
        public string fechaDesde = "";
        public string fechaHasta = "";
        public string artCodDesde = "";
        public string artCodHasta = "";


        public frmCR1()
        {
            InitializeComponent();
        }
        
        private void frmCR1_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA A " + this.GetType().FullName);
            CrystalDecisions.CrystalReports.Engine.ReportDocument  myCR=new CR001();
            //myCR.Dispose();

            GloblaVar.gUTIL.ATraza("Tipo de Report " + GloblaVar.TIPO_REPORT);

            CrystalDecisions.Shared.TableLogOnInfo tliActual;

            switch (GloblaVar.TIPO_REPORT)
            {
                case 1:         //LISTADO DE RENTABILIDAD DE PROVEEDORES
                    myCR = new CR001();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER ;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD ;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = "LISTADO DE RENTABILIDAD DE PROVEEDORES " + GloblaVar.VERSION;
                    break;
                case 2: //Listado de Ventas por Fecha,Detallistas y Artículos
                    myCR = new CR002();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = "Listado de Ventas por Fecha,Detallistas y Artículos " + GloblaVar.VERSION;
                    break;
                case 3:
                    myCR = new CR003();
                    //CrystalDecisions.Shared.TableLogOnInfo tliActual;

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER ;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD ;       //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = " " + GloblaVar.VERSION;
                    break;
                case 4:
                    break;
                case 5: //Listado de Compras: Fecha, Artículos Proveedores
                    myCR = new CR005();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = "Listado de Compras: Fecha, Artículos Proveedores " + GloblaVar.VERSION;
                    break;                  
                case 6: //Listado de Cuadre para los que hacen cuadre Manual
                    myCR = new CR006();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = "Listado de Cuadre  Manual " + GloblaVar.VERSION;
                    break;
                case 7:
                    break;
                case 8:
                    myCR = new CR008();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = " " + GloblaVar.VERSION;
                    break;
                case 9: //Listado de Albaranes de Compras
                    myCR = new CR009();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = " " + GloblaVar.VERSION;
                    break;
                case 10: //Listado de Albaranes de Compras
                    myCR = new CR010();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = "Listado de Albaranes de Compras " + GloblaVar.VERSION;
                    break;
                case 11:
                    {//Listado de Ventas por detallista
                        myCR = new CR011();

                        //myCR.SetParameterValue("fechaDesde", fechaDesde);
                        //myCR.SetParameterValue("fechaHasta", fechaHasta);

                        foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                        {
                            tliActual = tbA.LogOnInfo;
                            tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                            tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                            tliActual.ConnectionInfo.UserID = "";
                            tliActual.ConnectionInfo.Password = "";
                            tliActual.ConnectionInfo.IntegratedSecurity = true;
                            tbA.ApplyLogOnInfo(tliActual);
                        }

                        // Create parameter objects
                        ParameterFields myParams = new ParameterFields();
                        ParameterField myParam1 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam1.ParameterFieldName = "fechaDesde";

                        // Add first country
                        myDiscreteValue1.Value = fechaDesde;
                        myParam1.CurrentValues.Add(myDiscreteValue1);

                        ParameterField myParam2 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue2 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam2.ParameterFieldName = "fechaHasta";

                        // Add first country
                        myDiscreteValue2.Value = fechaHasta;
                        myParam2.CurrentValues.Add(myDiscreteValue2);

                        // Add param object to params collection
                        myParams.Add(myParam1);
                        myParams.Add(myParam2);

                        // Assign the params collection to the report viewer
                        crystalReportViewer1.ParameterFieldInfo = myParams;

                    }
                    this.Text = "Listado de Ventas por detallista " + GloblaVar.VERSION;

                    break;

                case 12:
                    {//Listado de Compras por Proveedor
                        myCR = new CR012();

                        //myCR.SetParameterValue("fechaDesde", fechaDesde);
                        //myCR.SetParameterValue("fechaHasta", fechaHasta);

                        foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                        {
                            tliActual = tbA.LogOnInfo;
                            tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                            tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                            tliActual.ConnectionInfo.UserID = "";
                            tliActual.ConnectionInfo.Password = "";
                            tliActual.ConnectionInfo.IntegratedSecurity = true;
                            tbA.ApplyLogOnInfo(tliActual);
                        }

                        // Create parameter objects
                        ParameterFields myParams = new ParameterFields();
                        ParameterField myParam1 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam1.ParameterFieldName = "fechaDesde";

                        // Add first country
                        myDiscreteValue1.Value = fechaDesde;
                        myParam1.CurrentValues.Add(myDiscreteValue1);

                        ParameterField myParam2 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue2 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam2.ParameterFieldName = "fechaHasta";

                        // Add first country
                        myDiscreteValue2.Value = fechaHasta;
                        myParam2.CurrentValues.Add(myDiscreteValue2);

                        // Add param object to params collection
                        myParams.Add(myParam1);
                        myParams.Add(myParam2);

                        // Assign the params collection to the report viewer
                        crystalReportViewer1.ParameterFieldInfo = myParams;
                    }
                    this.Text = "Listado de Compras por Proveedor " + GloblaVar.VERSION;
                    break;
                case 13:
                    myCR = new CR013();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = " " + GloblaVar.VERSION;
                    break;
                case 14:
                    myCR = new CR014();

                    foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                    {
                        tliActual = tbA.LogOnInfo;
                        tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                        tliActual.ConnectionInfo.DatabaseName = "OREMAPEREMdb";          //"OREMAPEREMdb";
                        tliActual.ConnectionInfo.UserID = "";
                        tliActual.ConnectionInfo.Password = "";
                        tliActual.ConnectionInfo.IntegratedSecurity = true;
                        tbA.ApplyLogOnInfo(tliActual);
                    }
                    this.Text = " " + GloblaVar.VERSION;
                    break;
                case 15:         //LISTADO DE RENTABILIDAD DE PROVEEDORES
                    {
                        myCR = new CR015();

                        foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myCR.Database.Tables)
                        {
                            tliActual = tbA.LogOnInfo;
                            tliActual.ConnectionInfo.ServerName = GloblaVar.gREMOTO_SERVER;         //"localhost\\SQLEXPRESS";
                            tliActual.ConnectionInfo.DatabaseName = GloblaVar.gREMOTO_BD;          //"OREMAPEREMdb";
                            tliActual.ConnectionInfo.UserID = "";
                            tliActual.ConnectionInfo.Password = "";
                            tliActual.ConnectionInfo.IntegratedSecurity = true;
                            tbA.ApplyLogOnInfo(tliActual);
                        }

                        // Create parameter objects
                        ParameterFields myParams = new ParameterFields();
                        ParameterField myParam1 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam1.ParameterFieldName = "fechaDesde";

                        // Add first country
                        myDiscreteValue1.Value = fechaDesde;
                        myParam1.CurrentValues.Add(myDiscreteValue1);

                        ParameterField myParam2 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue2 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam2.ParameterFieldName = "fechaHasta";

                        // Add first country
                        myDiscreteValue2.Value = fechaHasta;
                        myParam2.CurrentValues.Add(myDiscreteValue2);

                        ParameterField myParam3 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue3 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam3.ParameterFieldName = "artCodDesde";

                        // Add first country
                        myDiscreteValue3.Value = artCodDesde;
                        myParam3.CurrentValues.Add(myDiscreteValue3);

                        ParameterField myParam4 = new ParameterField();
                        ParameterDiscreteValue myDiscreteValue4 = new ParameterDiscreteValue();

                        // Set the ParameterFieldName to the name of the parameter
                        // created in the Field Explorer
                        myParam4.ParameterFieldName = "artCodHasta";

                        // Add first country
                        myDiscreteValue4.Value = artCodHasta;
                        myParam4.CurrentValues.Add(myDiscreteValue4);

                        // Add param object to params collection
                        myParams.Add(myParam1);
                        myParams.Add(myParam2);
                        myParams.Add(myParam3);
                        myParams.Add(myParam4);

                        // Assign the params collection to the report viewer
                        crystalReportViewer1.ParameterFieldInfo = myParams;

                    }
                    this.Text = "LISTADO DE RENTABILIDAD DE PROVEEDORES " + GloblaVar.VERSION;
                    break;

            }  //switch (GloblaVar.TIPO_REPORT)

            crystalReportViewer1.SelectionFormula = GloblaVar.sQReport; 
            
            myCR.Refresh();
            crystalReportViewer1.ReportSource = myCR;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
           // myCR.Dispose();
        }

        private void frmCR1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

    }
}
