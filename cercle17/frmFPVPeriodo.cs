using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace cercle17
{
    public partial class frmFPVPeriodo : Form
    {
        public frmFPVPeriodo()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        public ArrayList Lista_detallistas;
        public string ConEMail, ConEDNSSMTP, ConAutPwd, Serie;


        private string CrearDirectorio(string ruta, string DetCod)
        {
            string directorio = ruta + "\\" + DetCod;

            if (Directory.Exists(directorio) == false)
            {
                Directory.CreateDirectory(directorio);
            }

            return directorio;
        }

        private void CargarDatosControlMayorista()
        {
            //datos de mayorista necesarios para enviar correos, no confundir con los que se cargan en frmPpal

            string strQ = "SELECT * FROM CONTROL";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ConEMail = myReader["ConEMail"].ToString();
                    ConEDNSSMTP = myReader["ConEDNSSMTP"].ToString();                    
                    ConAutPwd = myReader["ConAutPwd"].ToString();
                }
                myReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmFPVPeriodo_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            cbPeriodicidad.Items.Add("<Seleccione>");
            cbPeriodicidad.Items.Add("Diaria");
            cbPeriodicidad.Items.Add("Semanal");
            cbPeriodicidad.Items.Add("Quincenal");
            cbPeriodicidad.Items.Add("Mensual");

            cbPeriodicidad.SelectedIndex = 0;

            if (CnO != null)
            {               
                ConEDNSSMTP = "";
                ConEMail = "";
                ConAutPwd = "";

                CargarDatosControlMayorista();
                //Serie = "AA";
            }

            if (frmPpal.USUARIO == "8")
            {
                panelFechaFactura.Visible = true;
                lFechaFactura.Visible = true;
                dateTimePicker_FechaFactura.Visible = true;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            switch (cbPeriodicidad.SelectedItem.ToString())
            {
                case "Diaria": 
                    Proceso("D"); 
                    break;
                case "Semanal":
                    Proceso("S");
                    break;
                case "Quincenal":
                    Proceso("Q");
                    break;
                case "Mensual":
                    Proceso("M");
                    break;
                default:
                    MessageBox.Show("Para facturar debe seleccionar una periodicidad");
                    break;
            }
        }

        private ArrayList Obtener_Detallistas(string DetCPM)
        {
            //devuelve listado de todos los detallistas que cumplan la condición DetCPM

            ArrayList resultado = new ArrayList();

            string strQ = "SELECT * FROM DETALLISTAS WHERE DetCod>8999 ";

            if (frmPpal.USUARIO == "8") //VALPEIX
            {
                strQ = "SELECT * FROM DETALLISTAS WHERE DetTve=4 ";
            }            
          
            if (DetCPM != "")
            {
                strQ += " AND DetCpm='" + DetCPM + "'";
            }             

            strQ += " ORDER BY DetCod";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    clase_detallista detal = new clase_detallista();

                    detal.DetCod = myReader["DetCod"].ToString();
                    detal.DetNom = myReader["DetNom"].ToString();
                    detal.DetCpm = myReader["detcpm"].ToString(); ;
                    detal.DetEMail = myReader["DetEMail"].ToString();
                    detal.detvia = myReader["detvia"].ToString();
                    detal.DetCop = myReader["DetCop"].ToString();
                    detal.detmun = myReader["DetMun"].ToString();
                    detal.DetNif = myReader["DetNif"].ToString();
                    detal.FPVImpresion = myReader["DetFPVImpresion"].ToString();
                    detal.FPVCorreo = myReader["DetFPVCorreo"].ToString();

                    resultado.Add(detal);
                }

                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }



        private ArrayList Obtener_Lista_Albaranes(string DetCod)
        {
            //devuelve array de datos, con todos los albaranes sin facturar del detallista

            ArrayList resultado = new ArrayList();

            string strQ = "SELECT * FROM VENALB_CABE WHERE (DetCod=" + DetCod + ") AND (VenNfp IS NULL) AND (AnyoFra IS NULL) AND (SerieFra IS NULL) AND (Anulado<>1) AND (VenTve<>51) AND (VenTve<>43)";

            if (ckbFechaDesde.Checked == true)
            {
                //filtro por fecha
                strQ += " AND (VenFec BETWEEN '" + dateTimePicker_Inicio.Text + "' AND '" + dateTimePicker_Fin.Text + "') ";
            }

            strQ += " ORDER BY VenFec, VenAlb";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    dato_albaran albaran = new dato_albaran();

                    albaran.VenAlb = myReader["VenAlb"].ToString();
                    albaran.Anyo = myReader["Anyo"].ToString();

                    resultado.Add(albaran);
                }

                myReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }
       

        private void Proceso(string DetCPM)
        {
            ArrayList Detallistas = Obtener_Detallistas(DetCPM);           

            //lectura de la lista

            if (Detallistas.Count == 0)
            {
                MessageBox.Show("No existen detallistas con la periodicidad de facturación seleccionada");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;

                int facturas_creadas = 0;
                //int facturas_impresas = 0;
                //int facturas_correo = 0;

                string MEMORIA = "";    //aquí se almacenan los detalles del proceso para mostrar luego al usuario

                for (int x = 0; x < Detallistas.Count; x++)
                {
                    clase_detallista prove = (clase_detallista)Detallistas[x];

                    string DetCod = prove.DetCod;

                    //obtener lista de todos los albaranes sin facturar de este detallista x
                    
                    ArrayList Lista_albaranes = Obtener_Lista_Albaranes(DetCod);
                    
                    if (Lista_albaranes.Count == 0)
                    {
                        //MEMORIA += "No hay albaranes por facturar para el detallista " + DetCod + " - " + prove.DetNom + " \r\n";
                        //textBox_Memoria.Text  = "No hay albaranes por facturar para el detallista " + DetCod + " - " + prove.DetNom + " \r\n";
                        //GloblaVar.gUTIL.ATraza(MEMORIA);

                    }
                    else
                    {
                        switch (DetCPM)
                        {
                            case "S":
                                Serie = "AS";
                                if(frmPpal.USUARIO=="2")
                                {
                                    Serie = "AW";
                                }                                
                                break;
                            case "Q":
                                Serie = "AQ";
                                break;
                            case "M":
                                Serie = "AM";
                                if(frmPpal.USUARIO=="2")
                                {
                                    Serie = "AN";
                                }                                
                                break;
                            case "D":
                                Serie = "AD";
                                break;
                            default:
                                Serie = "AA";
                                break;
                        }

                        //1. Facturar
                        string idFactura = "";

                        if (frmPpal.USUARIO == "8")
                        {
                            idFactura = Funciones.Facturar(DetCod, Serie, true, Lista_albaranes, CnO, dateTimePicker_FechaFactura.Text);
                        }
                        else
                        {
                            idFactura = Funciones.Facturar(DetCod, Serie, true, Lista_albaranes, CnO);
                        }

                        //string nomFactura = "";

                        //string fecha = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0');

                        //nomFactura = "Factura_" + fecha + "_" + idFactura.PadLeft(5, '0') + "_" + Serie;

                        //MEMORIA += "Se ha creado la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + nomFactura + " \r\n";
                        //textBox_Memoria.Text = "Se ha creado la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + nomFactura + " \r\n";
                        //GloblaVar.gUTIL.ATraza(MEMORIA);
                        //facturas_creadas++;



                        //directorio
                        string directorio = "";

                        //creación de PDF
                        //2. Recopilar datos de factura, cliente, etc
                        string anyo = DateTime.Today.Year.ToString();
                        string base_imponible = "";
                        string iva = "";
                        string recargo = "";
                        string total_importe = "";
                        string detcod="", detnom = ""; string detvia = ""; string detmun = ""; string detnif = "";
                        string texto_cabecera = ""; string observaciones = ""; string texto_pie = "";
                        DateTime fechaEmision = DateTime.Today;


                        string strQ = "SELECT * FROM FACTV_CABE WHERE Factura=" + idFactura + " AND Anyo=" + anyo + " AND Serie='" + Serie + "'";

                        SqlDataReader myReader = null;

                        try
                        {

                            SqlCommand myCommand = new SqlCommand(strQ, CnO);
                            myReader = myCommand.ExecuteReader();
                            while (myReader.Read())
                            {
                                fechaEmision = Convert.ToDateTime(myReader["FechaEmision"].ToString());
                                base_imponible = myReader["BI1"].ToString();
                                iva = myReader["IVA1"].ToString();
                                recargo = myReader["RE1"].ToString();
                                total_importe = myReader["ImpteFactura"].ToString();

                                texto_cabecera = myReader["TextoCabe"].ToString();
                                observaciones = myReader["Observaciones"].ToString();
                                texto_pie = myReader["TextoPie"].ToString();
                            }
                            //myReader.Close();
                        }
                        catch (Exception ex)
                        {
                            MEMORIA += "Error al cargar los datos de la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                            textBox_Memoria.Text = "Error al cargar los datos de la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                            GloblaVar.gUTIL.ATraza(MEMORIA);

                            //Vamos al siguiente detallista 

                        }
                        finally
                        {
                            myReader.Close();
                        }

                        base_imponible = Funciones.Formatea(base_imponible);
                        iva = Funciones.Formatea(iva);
                        recargo = Funciones.Formatea(recargo);
                        total_importe = Funciones.Formatea(total_importe);

                        //datos del detallista

                        detcod = DetCod;
                        detnom = prove.DetNom;
                        detvia = prove.detvia;
                        detmun = prove.DetCop + "  " + prove.detmun;
                        detnif = prove.DetNif;

                        //Comenzamos a crear el Report
                        CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;
                        myReport = new Report_Factura_Carabal();

                        switch (frmPpal.USUARIO)
                        {
                            case "1": myReport = new Report_Factura_Llorens();
                                break;
                            case "2": myReport = new Report_Factura_Carabal();
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
                        string server = GloblaVar.gREMOTO_SERVER;
                        string database = GloblaVar.gREMOTO_BD;

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

                        myReport.DataDefinition.RecordSelectionFormula = "{command.Factura}=" + idFactura + " and {command.Serie}='" + Serie + "' and {command.Anyo}=" + anyo;

                        myReport.SetParameterValue("idfactura", anyo + "/" + idFactura);
                        myReport.SetParameterValue("serie", Serie);
                        myReport.SetParameterValue("base_imponible", base_imponible);
                        myReport.SetParameterValue("iva", iva);
                        myReport.SetParameterValue("recargo", recargo);
                        myReport.SetParameterValue("importe_total", total_importe);
                        myReport.SetParameterValue("datos_mayorista", frmPpal.DATOS_MAYORISTA);
                        myReport.SetParameterValue("detnom", detnom);
                        myReport.SetParameterValue("detcod", detcod);
                        myReport.SetParameterValue("detvia", detvia);
                        myReport.SetParameterValue("detmun", detmun);
                        myReport.SetParameterValue("detnif", detnif);
                        //myReport.SetParameterValue("fecha", DateTime.Today.ToShortDateString());
                        myReport.SetParameterValue("fecha", fechaEmision.ToShortDateString());

                        myReport.SetParameterValue("texto_cabecera", texto_cabecera);
                        myReport.SetParameterValue("observaciones", observaciones);
                        myReport.SetParameterValue("texto_pie", texto_pie);

                        //myReport.SetParameterValue("total_pagina", "1");

                        //crystalReportViewer1.ReportSource = myReport;
                        //crystalReportViewer1.ShowLastPage();
                        //int total_paginas = crystalReportViewer1.GetCurrentPageNumber();
                        ////string TotalPage = total_paginas.ToString();
                        //crystalReportViewer1.ShowFirstPage();

                        ////recargar el total páginas
                        //// myReport.SetParameterValue("total_pagina", "/" + TotalPage);


                        //string nombre_factura = "Factura_" + fecha + "_" + idFactura + "_" + SERIE + ".pdf";

                        //string DiskFileName = directorio + "\\" + nombre_factura;
                        //myReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, DiskFileName);

                        string nomFactura = "", diskFileName = "", directorioFacturasPDF = "";
                        string fecha = fechaEmision.Year.ToString() + fechaEmision.Month.ToString().PadLeft(2, '0') + fechaEmision.Day.ToString().PadLeft(2, '0');

                        try
                        {
                            nomFactura = "Factura_" + fecha + "_" + idFactura.PadLeft(5, '0') + "_" + Serie + ".pdf";

                            //comprueba si existe el directorio y si no lo crea
                            directorioFacturasPDF = GloblaVar.gCERCLE_103;
                            directorio = CrearDirectorio(@directorioFacturasPDF, DetCod.PadLeft(5, '0'));
                            diskFileName = directorio + "\\" + nomFactura;

                            myReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, diskFileName);

                            myReport.Close();
                            myReport.Dispose();
                            GC.Collect();
                        }
                        catch (Exception ex)
                        {
                            MEMORIA += "Error al crear la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                            textBox_Memoria.Text = "Error al crear la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                            GloblaVar.gUTIL.ATraza(MEMORIA);                          
                        }

                        MEMORIA += "Se ha creado la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + nomFactura + " \r\n";
                        textBox_Memoria.Text = "Se ha creado la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + nomFactura + " \r\n";
                        GloblaVar.gUTIL.ATraza(MEMORIA);
                        facturas_creadas++;

                        //comprobamos si este detallista tiene marcada la impresión

                        if (prove.FPVImpresion.ToLower() == "true")
                        {
                            //    myReport.PrintToPrinter(1, false, 0, total_paginas);
                            //    facturas_impresas++;
                        }

                        //comprobamos si tiene marcado el enviar correo

                        //if (prove.FPVCorreo.ToLower() == "true")
                        //{
                        //    //comprobar si el e-mail del detallista tiene al menos una @

                        //    if (prove.DetEMail.Contains('@') == false)
                        //    {
                        //        //MEMORIA += "El detallista " + prove.DetCod + " - " + prove.DetNom + " no tiene un correo válido. \r\n";
                        //        //textBox_Memoria.Text = "El detallista " + prove.DetCod + " - " + prove.DetNom + " no tiene un correo válido. \r\n";
                        //        //GloblaVar.gUTIL.ATraza(MEMORIA);
                        //    }
                        //    else
                        //    {
                        //        try
                        //        {
                        //            ////enviar correo
                        //            //SmtpClient Cliente = new SmtpClient();

                        //            //Cliente.Host = ConEDNSSMTP;  //"smtp.gmail.com";
                        //            //Cliente.Port = 587;
                        //            //Cliente.Credentials = new NetworkCredential(ConEMail, ConAutPwd);
                        //            //Cliente.EnableSsl = true;

                        //            //string from = ConEMail;   //nosotros
                        //            //string to = prove.DetEMail;     //destino

                        //            //MailMessage Mensaje = new MailMessage(from, to);

                        //            //Mensaje.Body = "Adjuntamos factura.";
                        //            //Mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                        //            //Mensaje.Subject = nomFactura;
                        //            //Mensaje.SubjectEncoding = System.Text.Encoding.UTF8;


                        //            //Attachment Adjunto = new Attachment(diskFileName);
                        //            //ContentDisposition disposition = Adjunto.ContentDisposition;
                        //            //disposition.CreationDate = File.GetCreationTime(diskFileName);
                        //            //disposition.ModificationDate = File.GetLastWriteTime(diskFileName);
                        //            //disposition.ReadDate = File.GetLastAccessTime(diskFileName);

                        //            //Mensaje.Attachments.Add(Adjunto);

                        //            //Cliente.Send(Mensaje);

                        //            facturas_correo++;

                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            MEMORIA += "Error al enviar la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                        //            textBox_Memoria.Text = "Error al enviar la factura del detallista " + DetCod + " - " + prove.DetNom + " :  " + ex.ToString() + " \r\n";
                        //            GloblaVar.gUTIL.ATraza(MEMORIA);

                                    
                        //        }
                        //    }

                        //}



                   }


                }

                MEMORIA += "Facturas creadas: " + facturas_creadas.ToString() + "\r\n";
                //MEMORIA += "Facturas impresas: " + facturas_impresas.ToString() + "\r\n";
                //MEMORIA += "Facturas enviadas por correo: " + facturas_correo.ToString() + "\r\n";

                textBox_Memoria.Text = MEMORIA;

            }

            //fin de proceso
            this.Cursor = Cursors.Default;
        }       

        private void button_Salir_Click(object sender, EventArgs e)
        {

        }
        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
