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
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace cercle17
{
    public partial class frmFCompras : Form
    {
        public frmFCompras()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        public string ConEMail, ConEDNSSMTP, ConAutPwd;
        //private bool SerieANG = false;                  //Será true si es un abono sin devol. con lo cual se usa CR007
        private string SubSerie = "";                     //Será ASG para los abonos sin devolución de género  

        private void Cargar()
        {
            ArrayList Lista_Facturas = new ArrayList();

            string total_importes = "0";
            string Total_BIs = "0";
            string Total_IVAs="0";
            //string Total_Reqs="0";
            string total_pendientes = "0";

            //creamos la sentencia SQL que cruza factura con proveedores (para tener nombre de proveedores)
                        
            string strQ = "SELECT FC.Factura, FC.Anyo, FC.Serie, FC.FechaEmision, FC.ProCod, FC.ImpteFactura, FC.BI1, FC.IVA1, FC.ImptePagado, FC.ImptePendiente, P.ProNom, FC.ProNumFact, FC.ProFechaFact ";
            strQ += "FROM FACTC_CABE FC, PROVEEDORES P WHERE (FC.ProCod=P.ProCod) ";

            if (checkBox_Fecha.Checked == true)
            {
                //filtro por fecha
                strQ += " and (FC.ProFechaFact BETWEEN '" + dateTimePicker_Inicio.Text + "' AND '" + dateTimePicker_Fin.Text + "') ";
            }

            //ordenar
            strQ += " order by FC.Anyo, FC.Factura, FC.Serie";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_factcom factura = new clase_factcom();

                    factura.Factura = myReader["Factura"].ToString();
                    factura.Anyo = myReader["Anyo"].ToString();
                    factura.Serie = myReader["Serie"].ToString();
                    factura.FechaEmision = myReader["FechaEmision"].ToString(); if (factura.FechaEmision.Length > 10) { factura.FechaEmision = factura.FechaEmision.Substring(0, 10); }
                    factura.ProCod = myReader["ProCod"].ToString();
                    factura.ImpteFactura = Funciones.Formatea(myReader["ImpteFactura"].ToString());
                    factura.BI1=Funciones.Formatea(myReader["BI1"].ToString());
                    factura.IVA1=Funciones.Formatea(myReader["IVA1"].ToString());                    
                    factura.ImptePagado = Funciones.Formatea(myReader["ImptePagado"].ToString());
                    factura.ImptePendiente = Funciones.Formatea(myReader["ImptePendiente"].ToString());
                    factura.ProNom = myReader["ProNom"].ToString();
                    factura.ProNumFact = myReader["ProNumFact"].ToString();
                    factura.ProFechaFact = myReader["ProFechaFact"].ToString(); if (factura.ProFechaFact.Length > 10) { factura.ProFechaFact = factura.ProFechaFact.Substring(0, 10); }
                    //factura.Seleccion = false;

                    //filtros
                    bool agregar = true;

                    if (textBox_Factura.Text != "FACTURA")
                    {
                        if (factura.ProNumFact.Contains(textBox_Factura.Text) == false) { agregar = false; }
                    }

                    if (textBox_Anyo.Text != "AÑO")
                    {
                        if (factura.Anyo.Contains(textBox_Anyo.Text) == false) { agregar = false; }
                    }

                    if (textBox_Serie.Text != "SERIE")
                    {
                        if (factura.Serie.ToUpper().Contains(textBox_Serie.Text.ToUpper()) == false) { agregar = false; }
                    }

                    if (textBox_ProCod.Text != "PROCOD")
                    {
                        if (factura.ProCod.Contains(textBox_ProCod.Text) == false) { agregar = false; }
                    }

                    if (textBox_ProNom.Text != "PRONOM")
                    {
                        if (factura.ProNom.ToUpper().Contains(textBox_ProNom.Text.ToUpper()) == false) { agregar = false; }
                    }

                    if (radioButton_SinPagar.Checked == true)
                    {
                        if (factura.ImptePendiente == "0,00") { agregar = false; }
                    }

                    if (agregar == true)    //si no incumple el filtro se agrega al array Lista_Facturas
                    {
                        Lista_Facturas.Add(factura);
                        total_importes = Funciones.Suma(total_importes, factura.ImpteFactura);
                        Total_BIs=Funciones.Suma(Total_BIs, factura.BI1 );
                        Total_IVAs =Funciones.Suma(Total_IVAs, factura.IVA1 );                        

                        total_pendientes = Funciones.Suma(total_pendientes, factura.ImptePendiente);
                    }

                }
                myReader.Close();

                dataGridView_Facturado.AutoGenerateColumns = false;
                dataGridView_Facturado.DataSource = Lista_Facturas;     //el array se agrega al grid

                if (dataGridView_Facturado.Rows.Count > 0)
                {
                    label_BIs.Text = Total_BIs ;
                    label_IVAs.Text = Total_IVAs ;                    
                    label_importes.Text = total_importes;
                    label_Pendiente.Text = total_pendientes;
                }
                else
                {
                    label_importes.Text = "0";
                    label_BIs.Text = "0";
                    label_IVAs.Text = "0";                    
                    label_Pendiente.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }       

        private void frmFCompras_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName); 
            
            //cargar facturas
            Cargar();

        }   //private void frmFCompras_Load(object sender, EventArgs e)       

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Aquí comienzan los filtros

        private void textBox_Factura_Enter(object sender, EventArgs e)
        {
            if (textBox_Factura.Text == "FACTURA")
            {
                textBox_Factura.Text = "";
            }
            textBox_Factura.ForeColor = Color.Black;
        }

        private void textBox_Factura_Leave(object sender, EventArgs e)
        {
            if (textBox_Factura.Text == "")
            {
                textBox_Factura.Text = "FACTURA";
                textBox_Factura.ForeColor = Color.Silver;
            }
        }

        private void textBox_Factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void textBox_Anyo_Enter(object sender, EventArgs e)
        {
            if (textBox_Anyo.Text == "AÑO")
            {
                textBox_Anyo.Text = "";
            }
            textBox_Anyo.ForeColor = Color.Black;
        }

        private void textBox_Anyo_Leave(object sender, EventArgs e)
        {
            if (textBox_Anyo.Text == "")
            {
                textBox_Anyo.Text = "AÑO";
                textBox_Anyo.ForeColor = Color.Silver;
            }
        }

        private void textBox_Anyo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void textBox_ProCod_Enter(object sender, EventArgs e)
        {
            if (textBox_ProCod.Text == "PROCOD")
            {
                textBox_ProCod.Text = "";
            }
            textBox_ProCod.ForeColor = Color.Black;
        }

        private void textBox_ProCod_Leave(object sender, EventArgs e)
        {
            if (textBox_ProCod.Text == "")
            {
                textBox_ProCod.Text = "PROCOD";
                textBox_ProCod.ForeColor = Color.Silver;
            }
        }

        private void textBox_ProCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void textBox_ProNom_Enter(object sender, EventArgs e)
        {
            if (textBox_ProNom.Text == "PRONOM")
            {
                textBox_ProNom.Text = "";
            }
            textBox_ProNom.ForeColor = Color.Black;
        }

        private void textBox_ProNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void textBox_ProNom_Leave(object sender, EventArgs e)
        {
            if (textBox_ProNom.Text == "")
            {
                textBox_ProNom.Text = "PRONOM";
                textBox_ProNom.ForeColor = Color.Silver;
            }
        }

        private void textBox_Serie_Enter(object sender, EventArgs e)
        {
            if (textBox_Serie.Text == "SERIE")
            {
                textBox_Serie.Text = "";
            }
            textBox_Serie.ForeColor = Color.Black;
        }

        private void textBox_Serie_Leave(object sender, EventArgs e)
        {
            if (textBox_Serie.Text == "")
            {
                textBox_Serie.Text = "SERIE";
                textBox_Serie.ForeColor = Color.Silver;
            }
        }

        private void textBox_Serie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void checkBox_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Fecha.Checked == true)
            {
                Cargar();
            }
        }

        private void dateTimePicker_Fin_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Fecha.Checked == true)
            {
                Cargar();
            }
        }

        private void radioButton_SinPagar_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void radioButton_Todas_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Invocar_Pago(clase_factcom factura)
        {
            ////invocamos el formulario de cobros y le pasamos la conexión CnO y el tipo factura
            //frmFPCobros Cobros = new frmFPCobros();
            //Cobros.CnO = CnO;
            //Cobros.COBRO_AGRUPADO = false;
            //Cobros.factura = factura;

            ////si el formulario de diálogo devuelve OK se hace una recarga del grid
            //if (Cobros.ShowDialog() == DialogResult.OK)
            //{
            //    Cargar();
            //}
        }

        private void Cobrar(object sender, EventArgs e)
        {
            //cuando se elige la opción "Cobrar" del menú contextual se activa esta función
            //primero recuperamos el tipo de datos "factura"

            clase_factcom factura = (clase_factcom)((ToolStripMenuItem)sender).Tag;
            Invocar_Pago(factura);
        }

        private void Modificar(object sender, EventArgs e)
        {
            //cuando se elige la opción "Modificar" del menú contextual se activa esta función

            //clase_factcom factura = (clase_factcom)((ToolStripMenuItem)sender).Tag;

            //frmModificarFactura ModificaFactura = new frmModificarFactura();
            //ModificaFactura.CnO = CnO;
            //ModificaFactura.factura = factura;

            ////si el formulario de diálogo devuelve OK se hace una recarga del grid

            //if (ModificaFactura.ShowDialog() == DialogResult.OK)
            //{
            //    Cargar();
            //}
        }

        private void Mostrar(object sender, EventArgs e)
        {
            ////función que crea y muestra el report de la factura
            //string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name+" ";
            //GloblaVar.gUTIL.ATraza(gIdent+" Mostrar factura ");  

            //clase_factcom factura = (clase_factcom)((ToolStripMenuItem)sender).Tag;

            //this.Cursor = Cursors.WaitCursor;

            //string base_imponible = "";
            //string iva = "";
            //string recargo = "";
            //string total_importe = "";
            //string detnom = ""; string detcod = ""; string detvia = ""; string detmun = ""; string detnif = "";
            //string texto_cabecera = ""; string observaciones = ""; string texto_pie = "";
            //string serie = "";

            //string strQ = "SELECT * FROM FACTV_CABE WHERE Factura=" + factura.Factura + " AND Anyo=" + factura.Anyo + " AND Serie='" + factura.Serie + "'";

            //try
            //{
            //    SqlDataReader myReader = null;
            //    SqlCommand myCommand = new SqlCommand(strQ, CnO);
            //    myReader = myCommand.ExecuteReader();
            //    while (myReader.Read())
            //    {
            //        serie = myReader["Serie"].ToString();
            //        base_imponible = myReader["BI1"].ToString();
            //        iva = myReader["IVA1"].ToString();
            //        recargo = myReader["RE1"].ToString();
            //        total_importe = myReader["ImpteFactura"].ToString();

            //        texto_cabecera = myReader["TextoCabe"].ToString();
            //        observaciones = myReader["Observaciones"].ToString();
            //        texto_pie = myReader["TextoPie"].ToString();
            //        if (myReader["SubSerie"] != DBNull.Value) { SubSerie = myReader["SubSerie"].ToString(); }
            //    }
            //    myReader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    GloblaVar.gUTIL.ATraza(gIdent+ ex.ToString());
            //}

            ////datos del detallista
            //strQ = "SELECT DetCod, DetNom, detvia, DetCop, DetMun, DetNif  FROM  DETALLISTAS WHERE DetCod=" + factura.DetCod;
            
            //try
            //{
            //    SqlDataReader myReader = null;
            //    SqlCommand myCommand = new SqlCommand(strQ, CnO);
            //    myReader = myCommand.ExecuteReader();
            //    while (myReader.Read())
            //    {
            //        detnom = myReader["DetNom"].ToString();
            //        detcod = myReader["DetCod"].ToString();
            //        if (GloblaVar.gCERCLE_105 == true) { detnom = "(" +myReader["DetCod"].ToString() + ") " + myReader["DetNom"].ToString(); }
            //        detvia = myReader["detvia"].ToString();
            //        detmun = myReader["DetCop"].ToString() + "  " + myReader["DetMun"].ToString();
            //        detnif = myReader["DetNif"].ToString();
            //    }
            //    myReader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            //}

            ////ya tenemos los datos y ahora creamos el report

            //Report_Factura_code Reporte = new Report_Factura_code();//
            ////if (SerieANG) { Reporte = new CR007(); } else { Reporte = new Report_Factura_code(); }
            //Reporte.factura = factura;
            //Reporte.serie = serie;
            //Reporte.base_imponible = Funciones.Formatea(base_imponible);
            //Reporte.iva = Funciones.Formatea(iva);
            //Reporte.recargo = Funciones.Formatea(recargo);
            //Reporte.total_importe = Funciones.Formatea(total_importe);
            //Reporte.detnom = detnom;
            //Reporte.detcod = detcod;
            //Reporte.detvia = detvia;
            //Reporte.detmun = detmun;
            //Reporte.detnif = detnif;
            //Reporte.datos_mayorista = frmPpal.DATOS_MAYORISTA;
            //Reporte.texto_cabecera = texto_cabecera;
            //Reporte.observaciones = observaciones;
            //Reporte.texto_pie = texto_pie;
            //Reporte.SubSerie  = SubSerie ;        // Si es abono sin devol. genero lo indicamos
            //Reporte.Show();

            //SubSerie = "";    //Para que no guarde la variablke si se muestra otra factura
            //this.Cursor = Cursors.Default;
        }   // private void Mostrar(object sender, EventArgs e)

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

        private void CrearPDF(object sender, EventArgs e)
        {
            //función que crea el PDF de la factura

            clase_factcom factura = (clase_factcom)((ToolStripMenuItem)sender).Tag;

            this.Cursor = Cursors.WaitCursor;

            string base_imponible = "";
            string iva = "";
            string recargo = "";
            string total_importe = "";
            string detcod = "", detnom = "", detvia = "", detmun = "", detnif = "", detEMail = "";
            string texto_cabecera = ""; string observaciones = ""; string texto_pie = "";
            string serie = "";

            string strQ = "SELECT * FROM FACTV_CABE WHERE Factura=" + factura.Factura + " AND Anyo=" + factura.Anyo + " AND Serie='" + factura.Serie + "'";
            
            SqlDataReader myReader = null;

            try
            {
                //SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    serie = myReader["Serie"].ToString();
                    base_imponible = myReader["BI1"].ToString();
                    iva = myReader["IVA1"].ToString();
                    recargo = myReader["RE1"].ToString();
                    total_importe = myReader["ImpteFactura"].ToString();

                    texto_cabecera = myReader["TextoCabe"].ToString();
                    observaciones = myReader["Observaciones"].ToString();
                    texto_pie = myReader["TextoPie"].ToString();
                    if (myReader["SubSerie"] != DBNull.Value) { SubSerie  = myReader["SubSerie"].ToString(); }
                }
                //myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                myReader.Close();
            }

            //datos del detallista
            strQ = "SELECT ProCod, ProNom, ProDom, ProPob, ProCop, ProCif, ProEMail FROM PROVEEDORES WHERE ProCod=" + factura.ProCod;
            
            try
            {
                
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    detcod = myReader["ProCod"].ToString();
                    detnom = myReader["ProNom"].ToString();
                    detvia = myReader["ProDom"].ToString();
                    detmun = myReader["ProCop"].ToString() + "  " + myReader["ProPob"].ToString();
                    detnif = myReader["ProCif"].ToString();
                    detEMail = myReader["ProEMail"].ToString();                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
                return;
            }
            finally
            {
                myReader.Close();
            }

            ///////

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

            myReport.DataDefinition.RecordSelectionFormula = "{command.Factura}=" + factura.Factura + " and {command.Serie}='" + factura.Serie + "' and {command.Anyo}=" + factura.Anyo;
            
            myReport.SetParameterValue("idfactura", factura.Anyo + "/" + factura.Factura);
            myReport.SetParameterValue("serie", serie);
            myReport.SetParameterValue("base_imponible", Funciones.Formatea(base_imponible));
            myReport.SetParameterValue("iva", Funciones.Formatea(iva));
            myReport.SetParameterValue("recargo", Funciones.Formatea(recargo));
            myReport.SetParameterValue("importe_total", Funciones.Formatea(total_importe));
            myReport.SetParameterValue("datos_mayorista", frmPpal.DATOS_MAYORISTA);
            myReport.SetParameterValue("detnom", detnom);
            myReport.SetParameterValue("detcod", detcod);
            myReport.SetParameterValue("detvia", detvia);
            myReport.SetParameterValue("detmun", detmun);
            myReport.SetParameterValue("detnif", detnif);
            myReport.SetParameterValue("fecha", factura.FechaEmision);

            myReport.SetParameterValue("texto_cabecera", texto_cabecera);
            myReport.SetParameterValue("observaciones", observaciones);
            myReport.SetParameterValue("texto_pie", texto_pie);


            //crear factura en PDF

            string nomFactura = "", directorio = "", diskFileName = "", fecha = "", directorioFacturasPDF = "";
            DateTime fechaEmision = Convert.ToDateTime(factura.FechaEmision);

            try
            {
                //damos formato a la fecha de emision de la factura
                fecha = fechaEmision.Year.ToString() + fechaEmision.Month.ToString().PadLeft(2, '0') + fechaEmision.Day.ToString().PadLeft(2, '0');

                nomFactura = "Factura_" + fecha + "_" + factura.Factura.PadLeft(5, '0') + "_" + factura.Serie + ".pdf";
                
                //comprueba si existe el directorio y si no lo crea
                directorioFacturasPDF = GloblaVar.gCERCLE_103;
                directorio = CrearDirectorio(@directorioFacturasPDF, detcod.PadLeft(5, '0'));
                diskFileName = directorio + "\\" + nomFactura; 
           
                myReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, diskFileName);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la factura en PDF:\n\n" + ex.ToString());
                return;
            }      

            if(((ToolStripMenuItem)sender).Name == "Crear")
            {
                MessageBox.Show(nomFactura + " ha sido creada correctamente");
            }
            else
            {
                //enviar factura por email
                if(!detEMail.Contains('@'))
                {
                    MessageBox.Show("El detallista " + detnom + " con el código " + detcod + " no tiene un correo válido.");
                }
                else
                {
                    if (CnO != null)
                    {
                        ConEDNSSMTP = "";
                        ConEMail = "";
                        ConAutPwd = "";

                        CargarDatosControlMayorista();
                    }

                    if (!string.IsNullOrEmpty(ConEDNSSMTP) && !string.IsNullOrEmpty(ConEMail) && !string.IsNullOrEmpty(ConAutPwd))
                    {

                        SmtpClient clienteCorreo = new SmtpClient(ConEDNSSMTP, 587);

                        clienteCorreo.EnableSsl = true;
                        clienteCorreo.DeliveryMethod = SmtpDeliveryMethod.Network;
                        clienteCorreo.UseDefaultCredentials = false;
                        clienteCorreo.Credentials = new NetworkCredential(ConEMail, ConAutPwd);
                        
                        try
                        {

                            MailMessage mensaje = new MailMessage();
                            
                            mensaje.From = new MailAddress(ConEMail);
                            mensaje.To.Add(detEMail.Trim());
                            mensaje.Subject = nomFactura;
                            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                            mensaje.Body = "Factura adjunta";
                            mensaje.BodyEncoding = System.Text.Encoding.UTF8;

                            using (Attachment adjunto = new Attachment(diskFileName))
                            {
                                ContentDisposition contentDisposition = adjunto.ContentDisposition;
                                contentDisposition.CreationDate = File.GetCreationTime(diskFileName);
                                contentDisposition.ModificationDate = File.GetLastWriteTime(diskFileName);
                                contentDisposition.ReadDate = File.GetLastAccessTime(diskFileName);

                                mensaje.Attachments.Add(adjunto);

                                clienteCorreo.Send(mensaje);

                                mensaje = null;                            
                            
                            }                          
                        
                            MessageBox.Show(nomFactura + " enviada correctamente");

                        }
                        catch (Exception ex)
                        {                        
                           MessageBox.Show("Error al enviar la factura:\n\n" + ex.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("El mayorista no tiene configurados los datos para enviar correos");
                    }

                }

            }               

            this.Cursor = Cursors.Default;

        }

        private void dataGridView_Facturado_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
            if(e.Button == MouseButtons.Right)
            {
                //primero se comprueba si se ha seleccionado una celda del grid
                if (dataGridView_Facturado.SelectedCells.Count > 0)
                {
                    int x = dataGridView_Facturado.SelectedCells[0].RowIndex;

                    clase_factcom factura = new clase_factcom();

                    
                    factura.ProCod = dataGridView_Facturado.Rows[x].Cells[1].Value.ToString();
                    factura.ProNom = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString();
                    factura.FechaEmision = dataGridView_Facturado.Rows[x].Cells[13].Value.ToString();
                    factura.ImpteFactura = dataGridView_Facturado.Rows[x].Cells[4].Value.ToString();
                    factura.ImptePendiente = dataGridView_Facturado.Rows[x].Cells[5].Value.ToString();
                    factura.Factura = dataGridView_Facturado.Rows[x].Cells[10].Value.ToString();
                    factura.Anyo = dataGridView_Facturado.Rows[x].Cells[11].Value.ToString();
                    factura.Serie = dataGridView_Facturado.Rows[x].Cells[12].Value.ToString();

                    ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();    

                    ToolStripMenuItem item1 = new ToolStripMenuItem("Pagar", null, Cobrar);
                    item1.Tag = factura;

                    ToolStripMenuItem item2 = new ToolStripMenuItem("Modificar", null, Modificar);
                    item2.Tag = factura;

                    ToolStripMenuItem item3 = new ToolStripMenuItem("Ver factura", null, Mostrar);
                    item3.Tag = factura;

                    ToolStripMenuItem item4 = new ToolStripMenuItem("Factura PDF", null, CrearPDF, "Crear");
                    item4.Tag = factura;

                    ToolStripMenuItem item5 = new ToolStripMenuItem("Enviar factura", null, CrearPDF, "CrearEnviar");
                    item5.Tag = factura; 

                    //si las facturas están cobradas (no hay nada pendiente) no se incluyen las opciones 1 y 2
                    if (factura.ImptePendiente != "0,00") { contextMenuStrip1.Items.Add(item1); }
                    if (factura.ImptePendiente == factura.ImpteFactura) { contextMenuStrip1.Items.Add(item2); }
                    contextMenuStrip1.Items.Add(item3);
                    contextMenuStrip1.Items.Add(item4);
                    contextMenuStrip1.Items.Add(item5);

                    contextMenuStrip1.Show(dataGridView_Facturado, new Point(e.X, e.Y));

                }
            }
        }

 
        private void dataGridView_Facturado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //código necesario para marcar Selección
            if (e.RowIndex >= 0)
            {
                //la columna 6 es la que se puede marcar
                if (e.ColumnIndex == 6)
                {
                    bool marcada = false;

                    if (dataGridView_Facturado.Rows[e.RowIndex].Cells[6].Value.ToString().ToLower() == "true")
                    {
                        marcada = true;
                    }

                    if (marcada)
                    {
                        //si está marcada se va a desmarcar
                        dataGridView_Facturado.Rows[e.RowIndex].Cells[6].Value = false;
                    }
                    else
                    {
                        //y a la inversa
                        dataGridView_Facturado.Rows[e.RowIndex].Cells[6].Value = true;
                    }
                }
            }
        }

        private void button_Listado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea imprimir las facturas seleccionadas?", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ArrayList Lista_Facturas = new ArrayList();

                //listar facturas marcadas en el grid
                for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                {
                    if (dataGridView_Facturado.Rows[x].Cells[6].Value.ToString().ToLower() == "true")
                    {
                        //se incluye en el listado
                        clase_factcom factura = new clase_factcom();

                        factura.Factura = dataGridView_Facturado.Rows[x].Cells[0].Value.ToString();
                        factura.Anyo = dataGridView_Facturado.Rows[x].Cells[1].Value.ToString();
                        factura.Serie = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString();
                        factura.ProCod = dataGridView_Facturado.Rows[x].Cells[3].Value.ToString();
                        factura.FechaEmision = dataGridView_Facturado.Rows[x].Cells[5].Value.ToString();
                        factura.ImpteFactura = dataGridView_Facturado.Rows[x].Cells[6].Value.ToString();
                        factura.ImptePendiente = dataGridView_Facturado.Rows[x].Cells[7].Value.ToString();

                        Lista_Facturas.Add(factura);

                        //hay que hacer un vector con los id año serie de las filas seleccionadas
                    }
                }

                if (Lista_Facturas.Count > 0)
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int x = 0; x < Lista_Facturas.Count; x++)
                    {
                        clase_factcom factura = (clase_factcom)Lista_Facturas[x];

                        Imprimir_Factura(factura);

                    }

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar alguna factura");

                }
            }
        }

        private void Imprimir_Factura(clase_factcom factura)
        {

            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza ("Ejecutando " + this.GetType().FullName);

            string base_imponible = "";
            string iva = "";
            string recargo = "";
            string total_importe = "";
            string detcod = "", detnom = "", detvia = "", detmun = "", detnif = "", detEMail = "";
            string texto_cabecera = ""; string observaciones = ""; string texto_pie = "";

            string strQ = "SELECT * FROM FACTC_CABE WHERE Factura=" + factura.Factura + " AND Anyo=" + factura.Anyo + " AND Serie='" + factura.Serie + "'";

            GloblaVar.gUTIL.ATraza("Se va a imprimir la factura " +factura.Factura +"-" + factura.Serie +"/"+ factura.Anyo );
            SqlDataReader myReader = null;

            try
            {
                //SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    base_imponible = myReader["BI1"].ToString();
                    iva = myReader["IVA1"].ToString();
                    recargo = myReader["RE1"].ToString();
                    total_importe = myReader["ImpteFactura"].ToString();

                    texto_cabecera = myReader["TextoCabe"].ToString();
                    observaciones = myReader["Observaciones"].ToString();
                    texto_pie = myReader["TextoPie"].ToString();
                    if (myReader["SubSerie"] != DBNull.Value) { SubSerie = myReader["SubSerie"].ToString(); }
                }
                //myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                myReader.Close();
            }

            //datos del detallista
            strQ = "SELECT DetCod, DetNom, detvia, DetCop, DetMun, DetNif, DetEMail FROM DETALLISTAS WHERE DetCod=" + factura.ProCod;

            try
            {

                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    detcod = myReader["DetCod"].ToString();
                    detnom = myReader["DetNom"].ToString();
                    detvia = myReader["detvia"].ToString();
                    detmun = myReader["DetCop"].ToString() + "  " + myReader["DetMun"].ToString();
                    detnif = myReader["DetNif"].ToString();
                    detEMail = myReader["DetEMail"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                myReader.Close();
            }

            ///////

            GloblaVar.gUTIL.ATraza("Leidos datos de cabecera y detallista");

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;
            if (SubSerie=="ASG")    {myReport = new CR007();} else { myReport = new Report_Factura_Carabal();}
            GloblaVar.gUTIL.ATraza(" Usuario " + frmPpal.USUARIO);

            switch (frmPpal.USUARIO)
            {
                case "1": 
                    myReport = new Report_Factura_Llorens();
                    break;
                case "2": 
                    if (SubSerie == "ASG") 
                    { 
                        myReport = new CR007(); 
                    } 
                    else 
                    { 
                        myReport = new Report_Factura_Carabal(); 
                    }
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

            foreach (CrystalDecisions.CrystalReports.Engine.Table tbA in myReport.Database.Tables)
            {
                GloblaVar.gUTIL.ATraza("El report se conecta al server  " + server +" Base datos "+ database );
                tliActual = tbA.LogOnInfo;
                tliActual.ConnectionInfo.ServerName = server;         //"localhost\\SQLEXPRESS";
                tliActual.ConnectionInfo.DatabaseName = database;       //"OREMAPEREMdb";
                tliActual.ConnectionInfo.UserID = "";
                tliActual.ConnectionInfo.Password = "";
                tliActual.ConnectionInfo.IntegratedSecurity = true;
                tbA.ApplyLogOnInfo(tliActual);
            }

            myReport.DataDefinition.RecordSelectionFormula = "{command.Factura}=" + factura.Factura + " and {command.Serie}='" + factura.Serie + "' and {command.Anyo}=" + factura.Anyo;

            myReport.SetParameterValue("idfactura", factura.Anyo + "/" + factura.Factura);
            myReport.SetParameterValue("serie", factura.Serie);
            myReport.SetParameterValue("base_imponible", Funciones.Formatea(base_imponible));
            myReport.SetParameterValue("iva", Funciones.Formatea(iva));
            myReport.SetParameterValue("recargo", Funciones.Formatea(recargo));
            myReport.SetParameterValue("importe_total", Funciones.Formatea(total_importe));
            myReport.SetParameterValue("datos_mayorista", frmPpal.DATOS_MAYORISTA);
            myReport.SetParameterValue("detcod", detcod);
            myReport.SetParameterValue("detnom", detnom);
            myReport.SetParameterValue("detvia", detvia);
            myReport.SetParameterValue("detmun", detmun);
            myReport.SetParameterValue("detnif", detnif);
            myReport.SetParameterValue("fecha", factura.FechaEmision);

            myReport.SetParameterValue("texto_cabecera", texto_cabecera);
            myReport.SetParameterValue("observaciones", observaciones);
            myReport.SetParameterValue("texto_pie", texto_pie);

            myReport.PrintToPrinter(1, false,0, 0);    //primera copia
          


        }

       


        private void button_Pago_Click(object sender, EventArgs e)
        {
            //Pago agrupado

            ArrayList Lista_Facturas = new ArrayList();
            string proveedor = "";

            for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
            {
                if (dataGridView_Facturado.Rows[x].Cells[8].Value.ToString().ToLower() == "true")
                {
                    //se incluye en el listado
                    clase_factcom factura = new clase_factcom();

                    factura.Factura = dataGridView_Facturado.Rows[x].Cells[0].Value.ToString();
                    factura.Anyo = dataGridView_Facturado.Rows[x].Cells[1].Value.ToString();
                    factura.Serie = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString();
                    factura.ProCod = dataGridView_Facturado.Rows[x].Cells[3].Value.ToString();
                    factura.FechaEmision = dataGridView_Facturado.Rows[x].Cells[5].Value.ToString();
                    factura.ImpteFactura = dataGridView_Facturado.Rows[x].Cells[6].Value.ToString();
                    factura.ImptePendiente = dataGridView_Facturado.Rows[x].Cells[7].Value.ToString();

                    Lista_Facturas.Add(factura);

                    if (proveedor == "") { proveedor = factura.ProCod; }  //guardamos el primer detallista
                }
            }

            if (Lista_Facturas.Count > 0)
            {
                if (Lista_Facturas.Count == 1)
                {
                    //se hace un cobro normal

                    clase_factcom esta_factura = (clase_factcom)Lista_Facturas[0];

                    Invocar_Pago(esta_factura);
                }
                else
                {
                    //se hace un cobro agrupado de varias facturas

                    //primero comprobar que todas sean del mismo detallista

                    bool seguir = true;

                    for (int x = 0; x < Lista_Facturas.Count; x++)
                    {
                        clase_factcom factura = (clase_factcom)Lista_Facturas[x];

                        if (proveedor != factura.ProCod)
                        {
                            seguir = false;
                        }
                    }

                    if (seguir == true)
                    {
                        //se llama al formulario de cobro

                        frmFPCobros Cobros = new frmFPCobros();
                        Cobros.CnO = CnO;
                        Cobros.COBRO_AGRUPADO = true;
                        Cobros.Lista_Facturas = Lista_Facturas;

                        //si el formulario de diálogo devuelve OK se hace una recarga del grid

                        if (Cobros.ShowDialog() == DialogResult.OK)
                        {
                            Cargar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se han seleccionado facturas de detallistas diferentes");
                    }
                }
            }
        }

        private void ckbMarcarTodo_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ckbMarcarTodo.Checked == true)
            {
                for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                {
                    dataGridView_Facturado.Rows[x].Cells[6].Value = "True";
                }
            }
            else
            {
                for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                {
                    dataGridView_Facturado.Rows[x].Cells[6].Value = "False";
                }
            }

            this.Cursor = Cursors.Default;
        }        
    }
}

