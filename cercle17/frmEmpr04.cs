using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cercle17
{
    
    public partial class frmEmpr04 : Form
    {
        DataGridViewPrinter MyDataGridViewPrinter;
        public frmEmpr04()
        {
            InitializeComponent();
        }

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2":
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "4":    //Botella'
                    this.Text = "Utilidades para J.B.BOTELLA " + GloblaVar.VERSION;
                    break;
            } //switch(frmPpal.USUARIO )
        }  //Seguridad
        

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            if ( GloblaVar.TeMp=="INFORME ENVIO OREMAPE 1")
            {
                this.Close();
                frmSeleccionDatos frmSelDat=new frmSeleccionDatos();
                frmSelDat.Show();

            }
            else 
            {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------SALIENDO de " + this.GetType().FullName);
            this.Hide();
            }
        }

        private void btn_Prepara_File_FP_OMP_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_REPORT = 4;
            GloblaVar.gUTIL.ATraza(gIdent + "Listado Tipo " + GloblaVar.TIPO_REPORT);
            this.Close();
            frmSeleccionDatos frm = new frmSeleccionDatos();
            frm.Show();

        }

        private void frmEmpr04_Load(object sender, EventArgs e)
        {
            switch (GloblaVar.TeMp)
            {
                case "INFORME ENVIO OREMAPE 1":
                    GloblaVar.gUTIL.CartelTraza(" ENTRADA A " + this.GetType().FullName + " INFORME ENVIO OREMAPE 1");
                    btn_Prepara_File_FP_OMP.Visible = false;
                    dGv1.Visible = true;
                    Genera_File_FP_OMP();
                    dGv1.Columns[12].Width = 200;
                    dGv1.Columns[12].DisplayIndex = 3;
                    dGv1.Columns[0].HeaderText = "ALBARÁN";
                    dGv1.Columns[0].Width = 70;
                    dGv1.Columns[1].HeaderText = "FECHA";
                    dGv1.Columns[1].Width = 80;
                    dGv1.Columns[2].HeaderText = "Cod.Det";
                    dGv1.Columns[2].Width = 60;
                    dGv1.Columns[3].HeaderText = "Detallista";
                    
                    dGv1.Columns[3].Visible=false;
                    dGv1.Columns[4].HeaderText = "Bruto";
                    dGv1.Columns[5].HeaderText = "IVA";
                    dGv1.Columns[6].HeaderText = "Recargo";
                    dGv1.Columns[6].Width = 60;
                    dGv1.Columns[7].HeaderText = "TOTAL";
                    //dGv1.Columns[7].AutoSizeMode = true;
                   

                    dGv1.Columns[8].Visible = false;
                    dGv1.Columns[9].Visible = false;
                    dGv1.Columns[10].Visible = false;
                    dGv1.Columns[11].Visible = false;   //FechaCobro
                    //dGv1.Columns[12].Visible = false; //DetNom
                    dGv1.Columns[13].Visible = false;   //DetMay

                    btn_Listar.Visible = true;

                    MessageBox.Show("Generado fichero C:\\OREMAPE\\NF_Botella.txt para envio a Oremape");
                    break;
                default:
                    GloblaVar.gUTIL.CartelTraza(" ENTRADA A " + this.GetType().FullName );
                    Seguridad();
                    break;
            }

            //this.reportViewer1.RefreshReport();
        } //

        public void Genera_File_FP_OMP()
        {
            //Generaremos el fichero para ORemape de Botella, con los albranes de FP que tengan un detallista con CodMay 
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;



            try
            {
                SqlCommand cmd = new SqlCommand(GloblaVar.sQReport, GloblaVar.gConRem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                dGv1.DataSource = dt;
                SqlDataReader Lector = cmd.ExecuteReader();
                if (Lector.HasRows)
                {
                    TextWriter tw = new StreamWriter("C:\\OREMAPE\\NF_Botella.txt");
                    double Tot_BI = 0; double Tot_IVA = 0; double Tot_Re = 0; double Tot_Tot = 0;
                    string Linea = "";
                    while (Lector.Read())
                    {
                        Linea = "R" + GloblaVar.gMayCod.PadLeft(3, '0');
                        Linea += Lector["DetMay"].ToString().Substring(0,5).PadLeft(5, '0');
                        Linea += Lector["VenAlb"].ToString().PadLeft(7, '0');
                        Linea += Convert.ToDateTime(Lector["VenFec"]).ToString("ddMMyy");
                        Linea += Funciones.Format_Num_Cadena(Lector["VenBru"].ToString(), 7, 2);
                        Linea += Funciones.Format_Num_Cadena(Lector["VenIVA"].ToString(), 7, 2);
                        Linea += Funciones.Format_Num_Cadena(Lector["VenRec"].ToString(), 7, 2);
                        Linea += Funciones.Format_Num_Cadena(Lector["VenTot"].ToString(), 7, 2);

                        if (Lector["ValidacionTarjeta"] != null) 
                        {
                            Linea += "D01";            //No validado (N99) o Validado (D01) 
                        } 
                        else 
                        {
                            Linea += "N99";         //No validado (N99) o Validado (D01) 
                        }
                        Linea += "000";             //Dias
                        Linea += "000000000";      //Base Imponible
                        Linea += "0000";            //Tipo Impositivo IVA superreducido
                        Linea += "0000";            //Recargo Equiv IVA superred.
                        Linea += "000000000";      //Base Imponible
                        Linea += "0000";            //Tipo Impositivo IVA reducido
                        Linea += "0000";            //Recargo Equiv IVA reducido.
                        Linea += "000000000";      //Base Imponible
                        Linea += "0000";            //Tipo Impositivo IVA general
                        Linea += "0000";            //Recargo Equiv IVA general.
                        Linea += "00000000000000000000000000000000000";      //Filler

                        
                        Tot_BI += Convert.ToDouble(Lector["VenBru"]);
                        Tot_IVA += Convert.ToDouble(Lector["VenIVA"]);
                        Tot_Re += Convert.ToDouble(Lector["VenRec"]);
                        Tot_Tot += Convert.ToDouble(Lector["VenTot"]);

                        tw.WriteLine(Linea);
                    } //while (Lector.Read())
                    //tw.WriteLine("");tw.WriteLine("");tw.WriteLine("");
                    //tw.WriteLine("TOTAL BASE IMPONIBLE ......"+Tot_BI.ToString().PadLeft(10,' '));
                    //tw.WriteLine("TOTAL IVA ................."+Tot_IVA.ToString().PadLeft(10,' '));
                    //tw.WriteLine("TOTAL RECARGO ............."+Tot_Re.ToString().PadLeft(10,' '));
                    //tw.WriteLine("TOTAL ....................."+Tot_Tot.ToString().PadLeft(10,' '));
                    label1.Text = "TOTAL BASE IMPONIBLE ......" + Tot_BI.ToString().PadLeft(10, ' ') + "\n";
                    label1.Text += "TOTAL IVA ......................." + Tot_IVA.ToString().PadLeft(10, ' ') + "\n";
                    label1.Text += "TOTAL RECARGO ................" + Tot_Re.ToString().PadLeft(10, ' ') + "\n";
                    label1.Text += "TOTAL ................................" + Tot_Tot.ToString().PadLeft(10, ' ') + "\n";
                    tw.Close();
                } // if (Lector.HasRows )
                Lector.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex2)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex2.ToString());
                MessageBox.Show(ex2.ToString());

            }

        }   //public void Genera_File_FP_OMP

        private void pD1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.PreferredSize));
            //this.InvokePaint(dGv1, myPaintArgs);
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void btn_Listar_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting("Listado de Albaranes para Oremape"))
            {
                pD1.Print();

            }
        }   //private void pD1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        private bool SetupThePrinting(string Titulo)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            pD1.DocumentName =Titulo;
            pD1.PrinterSettings = MyPrintDialog.PrinterSettings;
            pD1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            pD1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("¿Quieres el listado centrado en la página?", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dGv1 , pD1, true, true, Titulo, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dGv1, pD1, false, true, Titulo, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void btnExportExcel1_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            string  sql = "SELECT VENALB_CABE.venalb as Albaran, VENALB_CABE.venfec as FVenta, ";
            sql+="'430' + RIGHT('0000' + Ltrim(Rtrim(VENALB_CABE.detcod)),4) as [Cod.Det], "; 
            sql+="VENALB_CABE.venbru as BI, 10 as [%IVA], VENALB_CABE.veniva as IVA, 1.4 as [%RE], ";
            sql+="VENALB_CABE.VenRec as RE, VENALB_CABE.VenTot as Total ";
            sql+="FROM VENALB_CABE INNER JOIN DETALLISTAS ON VENALB_CABE.detcod = DETALLISTAS.detcod ";
            sql+="WHERE ";
            sql+="((VENALB_CABE.VenFec='" + dtpFecha.Text + "' AND VENALB_CABE.Anulado=0) OR ";
            sql+="(VENALB_CABE.VenFec<='" + dtpFecha.Text + "' AND VENALB_CABE.VenCoe='Z' AND VENALB_CABE.Anulado=0)) "; 
            sql+="ORDER BY VENALB_CABE.venfec asc";

            string path = obtenerPath();
            
            if(!string.IsNullOrEmpty(path))
            {
                clase_excel excel = new clase_excel();

                excel.CnO = GloblaVar.gConRem;
                excel.Query = sql;                
                excel.Path = path;
                excel.NombreFichero = "Fichero1";

                mensaje = excel.exportarExcel(dtpFecha.Value);

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("La exportación a excel se ha realizado correctamente");
                }
            }
            else
            {
                MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
            }
            
        }       

        private string obtenerPath()
        {
            string path = "";

            using(SqlCommand cmd = new SqlCommand("SELECT ConPathExcell FROM CONTROL", GloblaVar.gConRem))
            {
                path = Convert.ToString(cmd.ExecuteScalar());
            }
            
            return path;
        }  

        private void button3_Click(object sender, EventArgs e)
        {           
            string mensaje = "";

            mensaje = Funciones.PreparaListado(dtpFecha.Value, dtpFechaHasta.Value, GloblaVar.gConRem);

            if (mensaje == "")
            {
                string sql = "SELECT  ";
                sql += "'430' + RIGHT('0000' + Ltrim(Rtrim(DetCod)),4) as [Cod.Det], ";
                sql += "DetNom as NOMBRE, DetNif as NIF, DetCon,DetRec as RE, ";
                sql += "DetCoc as SG, DetVia as Direcc,DetCop as CP, DetTel as Tfno ";
                sql += "FROM DETALLISTAS ";
                sql += "WHERE ";
                sql += "DetCod>=79000 ";
                //sql += "(VENALB_CABE.AUX1='01 CREDITO' ";
                //sql += " OR VENALB_CABE.AUX1='07 FACT. PROPIA CREDITO' ";
                //sql += " OR VENALB_CABE.AUX1='011 SERIE L AL BANCO' ";
                //sql += " OR VENALB_CABE.AUX1='02 CONTADO PENDIENTE' ";
                //sql += " OR VENALB_CABE.AUX1='03 CONTADO PAGADO'";
                //sql+=" OR VENALB_CABE.AUX1='04 F.PROPIA PAGADO'";
                //sql+=" OR VENALB_CABE.AUX1='011 SERIE L AL BANCO'";
                //sql+=" OR VENALB_CABE.AUX1='020 SERIE M RETENIDOS') ";
                //sql += ")";
                sql += " ORDER BY DetCod asc";

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "DETALLISTAS_79000";

                    mensaje = excel.exportarExcel(dtpFechaHasta.Value);

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show("La exportación de "+ excel.NombreFichero +" a excel se ha realizado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }

            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }  // private void button3_Click(object sender, EventArgs e) detallistas 79000

        private void BtnExportFacturas_Click(object sender, EventArgs e)
        {
            //Botón de exportar EXCEL FACTURAS PROPIAS
            string mensaje = "";

            mensaje = Funciones.PreparaListado(dtpFecha.Value, dtpFechaHasta.Value, GloblaVar.gConRem);

            if (mensaje == "")
            {
                string sql = "SELECT FacNfp as Factura, CONVERT(Date,FacFfp,103) as Fecha, ";
                sql += "'' as Column1, '430' + RIGHT('0000' + Ltrim(Rtrim(DetCod)),4) as [Cod.Det], ";
                sql += "'' as Column2, '' as Column3, '' as Column4, FacBru as BI, ";
                //sql += "10 as [%IVA], FacIva as IVA, 1.4 as [%RE], FacRec as RE, ";
                sql += "10 as [%IVA], FacIva as IVA, CASE WHEN FacRec=0.00 THEN null ELSE 1.4 END as [%RE], CASE WHEN FacRec=0.00 THEN null ELSE FacRec END as RE, ";
                sql += "'' as Column5, '' as Column6, 7000000 as SubCuenta, FacTot as TOTAL ";
                sql += "FROM FACTURAS ";
                sql += "WHERE FacFfp>='" + dtpFecha.Text + "' and FacFfp<='" + dtpFechaHasta.Text + "'";
                sql += "ORDER BY FacNfp asc";

                string sqlTotal = "SELECT SUM(FacTot) ";
                sqlTotal += "FROM FACTURAS ";
                sqlTotal += "WHERE FacFfp>='" + dtpFecha.Text + "' and FacFfp<='" + dtpFechaHasta.Text + "'";

                decimal totalFacturas = Funciones.EjecutaScalar(sqlTotal, GloblaVar.gConRem) == DBNull.Value ? 0 :Convert.ToDecimal(Funciones.EjecutaScalar(sqlTotal, GloblaVar.gConRem));
                
                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "Facturas_Propias";

                    mensaje = excel.exportarExcel(dtpFechaHasta.Value, "", (decimal) totalFacturas);

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show("La exportación a excel se ha realizado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }

            }
            else
            {
                MessageBox.Show(mensaje);
            }

        }

        private void BtnExportCobros_Click(object sender, EventArgs e)
        {
            //Botón de exportar EXCEL COBROS FACTURAS PROPIAS
            string mensaje = "";

            mensaje = Funciones.PreparaListado(dtpFecha.Value, dtpFechaHasta.Value, GloblaVar.gConRem);

            if (mensaje == "")
            {
                string sql = "SELECT Fecha, Cuenta, Nombre, Descripcion, Referencia, DEBE, HABER FROM (";
                sql += "SELECT CONVERT(Date,C.Fecha,103) as Fecha, ";
                sql += "'430' + RIGHT('0000' + Ltrim(Rtrim(F.DetCod)),4) as Cuenta, '' as Nombre, CONVERT(VARCHAR(50), F.FacNfp) as Descripcion, ";
                sql += "'' as Referencia, '' as DEBE, F.FacTot as HABER, '1' as Tipo ";
                sql += "FROM FACTURAS as F INNER JOIN VENALB_COBROS as C ON F.IdCobro=C.IdCobro LEFT JOIN DETALLISTAS as D ON F.DetCod=D.DetCod ";
                sql += "WHERE C.Fecha>='" + dtpFecha.Text + "' AND C.Fecha<='" + dtpFechaHasta.Text + "' AND D.DetMay is not null ";
                sql += "UNION ";
                sql += "SELECT CONVERT(Date,C.Fecha,103) as Fecha, '5720025' as Cuenta, '' as Nombre, 'ABONO CREDITO' as Descripcion, ";
                sql += "'' as Referencia, SUM(F.FacTot) as DEBE,'' as HABER, '1' as Tipo ";
                sql += "FROM FACTURAS as F INNER JOIN VENALB_COBROS as C ON F.IdCobro=C.IdCobro LEFT JOIN DETALLISTAS as D ON F.DetCod=D.DetCod ";
                sql += "WHERE C.Fecha>='" + dtpFecha.Text + "' AND C.Fecha<='" + dtpFechaHasta.Text + "' AND D.DetMay is not null ";
                sql += "GROUP BY C.Fecha ";
                sql += "UNION ";
                sql += "SELECT CONVERT(Date,C.Fecha,103) as Fecha, ";
                sql += "'430' + RIGHT('0000' + Ltrim(Rtrim(F.DetCod)),4) as Cuenta, '' as Nombre, CONVERT(VARCHAR(50), F.FacNfp) as Descripcion, ";
                sql += "'' as Referencia, '' as DEBE, F.FacTot as HABER, '0' as Tipo ";
                sql += "FROM FACTURAS as F INNER JOIN VENALB_COBROS as C ON F.IdCobro=C.IdCobro LEFT JOIN DETALLISTAS as D ON F.DetCod=D.DetCod ";
                sql += "WHERE C.Fecha>='" + dtpFecha.Text + "' AND C.Fecha<='" + dtpFechaHasta.Text + "' AND D.DetMay is null ";
                sql += "UNION ";
                sql += "SELECT CONVERT(Date,C.Fecha,103) as Fecha, '5700000' as Cuenta, '' as Nombre, 'COBRO CAJA' as Descripcion, ";
                sql += "'' as Referencia, SUM(F.FacTot) as DEBE,'' as HABER, '0' as Tipo ";
                sql += "FROM FACTURAS as F INNER JOIN VENALB_COBROS as C ON F.IdCobro=C.IdCobro LEFT JOIN DETALLISTAS as D ON F.DetCod=D.DetCod ";
                sql += "WHERE C.Fecha>='" + dtpFecha.Text + "' AND C.Fecha<='" + dtpFechaHasta.Text + "' AND D.DetMay is null ";
                sql += "GROUP BY C.Fecha) as tabla ";
                sql += "ORDER BY tabla.Fecha, tabla.Tipo ";

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "Cobros_Facturas_Propias";

                    mensaje = excel.exportarExcel(dtpFechaHasta.Value);

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show("La exportación a excel se ha realizado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void BtnExportFacturasCobrosOremape_Click(object sender, EventArgs e)
        {
            //Abrir fichero de Facturas recibido de Oremape
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string linea;
            string Mayorista;
            string FechaFact;
            string Serie;
            string Factura;
            string Año;
            string DetCod;
            string BI;
            string IVA;
            string Req;
            string Importe;
            string Signo;
            string Observaciones;
            DateTime FechaFichero = DateTime.Now;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //1.- LEEMOS EL FICHERO QUE NOS PASA OREMAPE, lo tenemos en sr
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);               

                //2.- Borramos la tabla en la que vamos a insertar los registros
                int res = Funciones.EjecutaNonQuery("DELETE FROM CONTAB_FACTV_CABE", GloblaVar.gConRem);

                int NumFras = 0;
                while ((linea = sr.ReadLine()) != null)
                {
                    //LEEMOS LINEA a LINEA  y miramos si la longitud es >67
                    if (linea.Length > 67)
                    {
                        NumFras++;
                        Mayorista = linea.Substring(0, 2);
                        //linea=linea.PadLeft(linea.Length -2);
                        FechaFact = linea.Substring(2, 8);
                        Año = FechaFact.Substring(4, 4);
                        FechaFact = FechaFact.Substring(0, 2) + "/" + FechaFact.Substring(2, 2) + "/" + FechaFact.Substring(4, 4);
                        Serie = linea.Substring(10, 2);
                        Factura = linea.Substring(12, 7);
                        DetCod = linea.Substring(19, 5);
                        BI = linea.Substring(24, 9) + "." + linea.Substring(33, 2);
                        IVA = linea.Substring(35, 9) + "." + linea.Substring(44, 2);
                        Req = linea.Substring(46, 9) + "." + linea.Substring(55, 2);
                        Importe = linea.Substring(57, 9) + "." + linea.Substring(66, 2);
                        Signo = linea.Substring(68, 1);
                        Observaciones = Serie.Trim() + "" + Factura;

                        if (Signo == "-")
                        {
                            BI = "-" + BI;
                            IVA = "-" + IVA;
                            Req = "-" + Req;
                            Importe = "-" + Importe;
                        }

                        string sQ = "INSERT INTO CONTAB_FACTV_CABE (";
                        sQ += "Factura,Anyo,Serie,FechaEmision,DetCod,BI1,IVA1,RE1,ImpteFactura,Observaciones";
                        sQ += ") VALUES (";
                        sQ += Factura + ",";
                        sQ += Año + ",";
                        sQ += "'" + Serie.Trim() + "',";
                        sQ += "'" + FechaFact + "',";
                        sQ += DetCod + ",";
                        //sQ += "'" + SubCtaCli + "',";
                        sQ += BI + ",";
                        sQ += IVA + ",";
                        sQ += Req + ",";
                        sQ += Importe + ",";
                        sQ += "'" + Observaciones + "'";
                        sQ += ")";

                        //INSERTAMOS LINEA A LINEA EN LA TABLA
                        res = Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);

                        if(NumFras==1)
                        {
                            FechaFichero = Convert.ToDateTime(FechaFact);                            
                        }
                    }
                    
                } // while ((linea = sr.ReadLine()) != null)

                sr.Close();


                //3.- YA TENEMOS LA TABLA CON LAS FACTURAS LEÍDAS. AHORA EXPORTAMOS A EXCEL LA FACTURA.

                string mensaje = "";               

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    string sqlFacturas = "SELECT Observaciones as [Factura], CONVERT(Date,FechaEmision,103) as Fecha, ";
                    sqlFacturas += "'' as Column1, '430' + RIGHT('0000' + Ltrim(Rtrim(DetCod)),4) as [Cod.Det], ";
                    sqlFacturas += "'' as Column2, '' as Column3, '' as Column4, BI1 as BI, ";
                    //sqlFacturas += "10 as [%IVA], IVA1 as IVA, 1.4 as [%RE], RE1 as RE, ";
                    sqlFacturas += "10 as [%IVA], IVA1 as IVA, CASE WHEN RE1=0.00 THEN null ELSE 1.4 END as [%RE], CASE WHEN RE1=0.00 THEN null ELSE RE1 END as RE, ";
                    sqlFacturas += "'' as Column5, '' as Column6, 7000000 as SubCuenta, ImpteFactura as TOTAL ";
                    sqlFacturas += "FROM CONTAB_FACTV_CABE ";                   
                    sqlFacturas += "ORDER BY FechaEmision asc, Observaciones asc";

                    string sqlFacturasTotal = "SELECT SUM(ImpteFactura) ";
                    sqlFacturasTotal += "FROM CONTAB_FACTV_CABE ";

                    string sqlCobros = "SELECT Fecha, Cuenta, Nombre, Descripcion, Referencia, DEBE, HABER FROM (";
                    sqlCobros += "SELECT CONVERT(Date, FechaEmision, 103) as Fecha, ";
                    sqlCobros += "'430' + RIGHT('0000' + Ltrim(Rtrim(DetCod)),4) as Cuenta, '' as Nombre, Observaciones as Descripcion, ";
                    sqlCobros += "'' as Referencia, '' as DEBE, ImpteFactura as HABER, Serie ";
                    sqlCobros += "FROM CONTAB_FACTV_CABE ";
                    sqlCobros += "WHERE Serie<>'C' ";
                    sqlCobros += "UNION ";
                    sqlCobros += "SELECT CONVERT(Date, FechaEmision, 103) as Fecha, '5720025' as Cuenta, '' as Nombre, 'ABONO CREDITO' as Descripcion, ";
                    sqlCobros += "'' as Referencia, SUM(ImpteFactura) as DEBE,'' as HABER, Serie ";
                    sqlCobros += "FROM CONTAB_FACTV_CABE ";
                    sqlCobros += "WHERE Serie<>'C' ";
                    sqlCobros += "GROUP BY FechaEmision, Serie ";
                    sqlCobros += "UNION ";
                    sqlCobros += "SELECT CONVERT(Date, FechaEmision, 103) as Fecha, ";
                    sqlCobros += "'430' + RIGHT('0000' + Ltrim(Rtrim(DetCod)),4) as Cuenta, '' as Nombre, Observaciones as Descripcion, ";
                    sqlCobros += "'' as Referencia, '' as DEBE, ImpteFactura as HABER, Serie ";
                    sqlCobros += "FROM CONTAB_FACTV_CABE ";
                    sqlCobros += "WHERE Serie='C' ";
                    sqlCobros += "UNION ";
                    sqlCobros += "SELECT CONVERT(Date, FechaEmision, 103) as Fecha, '5700000' as Cuenta, '' as Nombre, 'COBRO CAJA' as Descripcion, ";
                    sqlCobros += "'' as Referencia, SUM(ImpteFactura) as DEBE,'' as HABER, Serie ";
                    sqlCobros += "FROM CONTAB_FACTV_CABE ";
                    sqlCobros += "WHERE Serie='C' ";
                    sqlCobros += "GROUP BY FechaEmision, Serie) as tabla " ;
                    sqlCobros += "ORDER BY tabla.Fecha, tabla.Serie";

                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sqlFacturas;
                    excel.Path = path;
                    excel.NombreFichero = "Facturas_OREMAPE";
                                        
                    decimal totalFacturas = Funciones.EjecutaScalar(sqlFacturasTotal, GloblaVar.gConRem) == DBNull.Value ? 0 : Convert.ToDecimal(Funciones.EjecutaScalar(sqlFacturasTotal, GloblaVar.gConRem));

                    mensaje = excel.exportarExcel(FechaFichero, "", totalFacturas);

                    if(mensaje == "")
                    {
                        excel.Query = sqlCobros;                        
                        excel.NombreFichero = "Cobros_Facturas_OREMAPE";

                        mensaje = excel.exportarExcel(FechaFichero);

                        if (mensaje != "")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("La exportación a excel se ha realizado correctamente");
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }                   
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }

            }
        }

        
    } //public partial class frmEmpr04 : Form
}  //namespace
