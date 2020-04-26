using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmFPVManual : Form
    {
        public frmFPVManual()
        {
            InitializeComponent();
        }


        public SqlConnection CnO;
        public ArrayList Lista_detallistas;


        //definimos el binding del primer grid, donde pondremos los albaranes

        private BindingList<clase_albaran> dataSource1 = new BindingList<clase_albaran>();
        private BindingSource bs1 = new BindingSource();

        //y el binding del segundo grid, donde pondremos las lineas de factura

        private BindingList<clase_linea_factura> dataSource2 = new BindingList<clase_linea_factura>();
        private BindingSource bs2 = new BindingSource();

        private void Cargar()
        {
            //select de cabeceras albaranes de venta (no facturados) por detallista
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);

            //string strQ = "SELECT * FROM VENALB_CABE WHERE (DetCod=" + textBox_DetCod.Text + ") AND (VenNfp IS NULL) AND (AnyoFra IS NULL) AND (SerieFra IS NULL) AND (Anulado<>1) order by VenFec, VenAlb";
            string strQ = "SELECT * FROM VENALB_CABE ";
            strQ +=" WHERE ";
            strQ +=" (DetCod=" + textBox_DetCod.Text + ") ";
            strQ += " AND (VenNfp IS NULL) ";
            strQ += " AND (AnyoFra IS NULL)";
            strQ +=" AND (SerieFra IS NULL)";
            strQ += " AND (Anulado<>1) ";
            if (GloblaVar.gCERCLE_105==true) { strQ += " AND (VenTve NOT IN (3,51,43)) "; } else { strQ += " AND (VenTve NOT IN (51,43)) "; }  //DIALPESCA no QUIERE Factura de CONTADOS DE OREMAPE
            strQ += " ORDER by VenFec, VenAlb";
            
            this.Cursor = Cursors.WaitCursor;
            
            //limpiamos ambos grids por el binding
            dataSource1.Clear();
            dataSource2.Clear();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ,GloblaVar.gConRem );
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_albaran alba = new clase_albaran();

                    alba.Albaran = myReader["VenAlb"].ToString();
                    alba.Año = myReader["Anyo"].ToString();
                    alba.Facturar = false;
                    alba.Fecha = myReader["VenFec"].ToString(); if (alba.Fecha.Length > 10) { alba.Fecha = alba.Fecha.Substring(0, 10); }
                    alba.TV = myReader["VenTve"].ToString();
                    alba.Total = Funciones.Formatea(myReader["VenTot"].ToString());
                    alba.BI = myReader["VenBru"].ToString();
                    alba.IVA = myReader["VenIva"].ToString();
                    alba.Recargo = myReader["VenRec"].ToString();

                    dataSource1.Add(alba);
                }
                myReader.Close();

                //como usamos binding esta línea no es necesaria:
                //dataGridView_Albaranes.DataSource = Albaranes;

                if (dataGridView_Albaranes.Rows.Count > 0)
                {
                    dataGridView_Albaranes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Albaranes.Columns[6].Visible = false;
                    dataGridView_Albaranes.Columns[7].Visible = false;
                    dataGridView_Albaranes.Columns[8].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

            this.Cursor = Cursors.Default;

        }

        private int EjecutaNonQuery(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, CnO);
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

        private void frmFPVManual_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            //se ejecuta al cargar el formulario

            if (CnO != null)
            {
                clase_UTILESdb cla=new clase_UTILESdb() ;
                if (GloblaVar.gMayCod!="13") {cla.SP1();}
                
                //array de detallistas
                Lista_detallistas = new ArrayList();
                string strQ = "SELECT * FROM DETALLISTAS order by DetCod";

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
                        detal.DetCpf = "";
                        detal.DetEMail = myReader["DetEMail"].ToString();
                        detal.detvia = myReader["detvia"].ToString();
                        detal.DetCop = myReader["DetCop"].ToString();
                        detal.detmun = myReader["DetMun"].ToString();
                        detal.DetNif = myReader["DetNif"].ToString();

                        Lista_detallistas.Add(detal);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                }

            }

            //cargar datos factura nueva
            textBox_Anyo.Text = DateTime.Today.Year.ToString();
            //textBox_Factura.Text = Nuevo_Factura();
            comboBox_Serie.Text = "AA";

            //limpiamos los datagrid y hacemos binding
            dataSource1.Clear();
            bs1.DataSource = dataSource1;
            dataGridView_Albaranes.DataSource = bs1;

            dataSource2.Clear();
            bs2.DataSource = dataSource2;
            dataGridView_Facturado.DataSource = bs2;

            textBox_DetCod.Focus();
        }

        private void Limpieza_Factura()
        {
            //Limpia datos tras una grabación

            textBox_TextoCabecera.Text = "";
            textBox_Observaciones.Text = "";
            textBox_TextoPie.Text = "";
            dataSource2.Clear();
        }

        private void button_Consulta_Click(object sender, EventArgs e)
        {
            //abrir formulario para consulta de Detallista
            FormDetallistas Consulta = new FormDetallistas();
            Consulta.Lista_detallistas = Lista_detallistas;
            if (Consulta.ShowDialog() == DialogResult.OK)
            {
                if (Consulta.DetCod != "")
                {
                    textBox_DetCod.Text = Consulta.DetCod;
                    textBox_DetNom.Text = Consulta.Nombre_Det;
                    Cargar();
                }
            }
        }

        private void textBox_DetCod_Enter(object sender, EventArgs e)
        {
            textBox_DetCod.BackColor = Color.Yellow;
        }

        private void textBox_DetCod_Leave(object sender, EventArgs e)
        {
            textBox_DetCod.BackColor = Color.White;
        }

        private void textBox_DetCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {

                if (textBox_DetCod.Text != "") 
                {
                    textBox_DetNom.Text = Funciones.DameNomDet(textBox_DetCod.Text);
                    Cargar(); 
                } 
                else
                { 
                    textBox_DetCod.Text = ""; 
                }

                
            }
        }

        private void Cobrar_factura(string IdFactura)
        {
            //abrir un formulario de cobro sobre IdFactura
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);

            try 
            {
                clase_cabecera_factura factura = new clase_cabecera_factura();

                factura.Factura = IdFactura;
                factura.Anyo = textBox_Anyo.Text;
                factura.Serie = comboBox_Serie.Text;
                factura.DetCod = textBox_DetCod.Text;
                factura.FechaEmision = DateTime.Today.ToShortDateString();
                factura.ImportePendiente = textBox_Importe.Text;

                frmFPCobros Cobros = new frmFPCobros();
                Cobros.CnO = CnO;
                Cobros.COBRO_AGRUPADO = false;
                Cobros.factura = factura;

                Cobros.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

        }

        private void Imprimir_factura(string IdFactura)
        {
            //dos copias a impresora

            string detnom = ""; string detvia = ""; string detmun = ""; string detnif = "";

            for (int x = 0; x < Lista_detallistas.Count; x++)
            {
                clase_detallista detallista = (clase_detallista)Lista_detallistas[x];

                if (detallista.DetCod == textBox_DetCod.Text)
                {
                    detnom = detallista.DetNom;
                    detvia = detallista.detvia;
                    detmun = detallista.detmun;
                    detnif = detallista.DetNif;
                }
            }


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
            string server =GloblaVar.gREMOTO_SERVER  ;
            //server=frmPpal.LOCAL;
            string database = GloblaVar.gREMOTO_BD;  // frmPpal.DATABASE;
            

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
            myReport.DataDefinition.RecordSelectionFormula = "{command.Factura}=" + IdFactura + " and {command.Serie}='" + comboBox_Serie.Text + "' and {command.Anyo}=" + textBox_Anyo.Text;

            myReport.SetParameterValue("idfactura", textBox_Anyo.Text + "/" + IdFactura);
            myReport.SetParameterValue("serie", comboBox_Serie.Text);
            myReport.SetParameterValue("base_imponible", textBox_BI.Text);
            myReport.SetParameterValue("iva", textBox_IVA.Text);
            myReport.SetParameterValue("recargo", textBox_Recargo.Text);
            myReport.SetParameterValue("importe_total", textBox_Importe.Text);
            myReport.SetParameterValue("datos_mayorista", frmPpal.DATOS_MAYORISTA);
            myReport.SetParameterValue("detnom", detnom);
            myReport.SetParameterValue("detvia", detvia);
            myReport.SetParameterValue("detmun", detmun);
            myReport.SetParameterValue("detnif", detnif);
            myReport.SetParameterValue("fecha", DateTime.Today.ToShortDateString());

            myReport.SetParameterValue("texto_cabecera", textBox_TextoCabecera.Text);
            myReport.SetParameterValue("observaciones", textBox_Observaciones.Text);
            myReport.SetParameterValue("texto_pie", textBox_TextoPie.Text);

            //myReport.SetParameterValue("total_pagina", "1");

            crystalReportViewer1.ReportSource = myReport;
            crystalReportViewer1.SelectionFormula = "{command.Factura}=" + IdFactura + " and {command.Serie}='" + comboBox_Serie.Text + "' and {command.Anyo}=" + textBox_Anyo.Text;
            crystalReportViewer1.ShowLastPage();
            int total_paginas = crystalReportViewer1.GetCurrentPageNumber();
            //string TotalPage = total_paginas.ToString();
            crystalReportViewer1.ShowFirstPage();

            //recargar el total páginas
            //myReport.SetParameterValue("total_pagina", "/" + TotalPage);
            //crystalReportViewer1.ReportSource = myReport;

            //crystalReportViewer1.Zoom(75);
            myReport.PrintToPrinter(1, false, 0, total_paginas);    //primera copia
            myReport.PrintToPrinter(1, false, 0, total_paginas);    //segunda copia

        }

        private void button_Grabar_Click(object sender, EventArgs e)
        {
            //GRABAR LA FACTURA
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Click en Grabar Factura Manual");
 
            //grabar las líneas
            ArrayList Lista_Albaranes = new ArrayList();

            for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
            {
                if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                {
                    dato_albaran dato = new dato_albaran();

                    dato.VenAlb = dataGridView_Albaranes.Rows[x].Cells[1].Value.ToString();
                    dato.Anyo = dataGridView_Albaranes.Rows[x].Cells[3].Value.ToString();                    

                    Lista_Albaranes.Add(dato);
                }
            }
            GloblaVar.gUTIL.ATraza(gIdent + " Recopiladas lineas que formarán parte de la factura");
            //comprobamos que al menos haya un albarán marcado por el usuario antes de seguir
            //si no lo que pasaría es que se haría una factura vacía, sin líneas

            if (Lista_Albaranes.Count > 0)
            {
                //introducimos una comprobación de albaranes facturados para que no se facturen dos veces
                //así sabemos si se les ha aplicado Marcar_Ventas
                //en ese caso IdFactura devolverá cadena vacía

                string IdFactura = Funciones.Facturar(textBox_DetCod.Text, comboBox_Serie.Text, false, Lista_Albaranes, CnO);

                GloblaVar.gUTIL.ATraza(gIdent + " Obtenido numero de Factura " + IdFactura + "/" + comboBox_Serie.Text +"-");

                if (IdFactura != "")
                {
                    //cabecera

                    string observaciones = textBox_Observaciones.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }
                    string textopie = textBox_TextoPie.Text.Replace("'", "''"); if (textopie.Length > 199) { textopie = textopie.Substring(0, 199); }
                    string textocabe = textBox_TextoCabecera.Text.Replace("'", "''"); if (textocabe.Length > 199) { textocabe = textocabe.Substring(0, 199); }

                    string insert_cabecera = "INSERT INTO FACTV_CABE(Factura, Anyo, Serie, FechaEmision, DetCod, BI1, IVA1, RE1, ImpteFactura, ImpteCobrado, ImptePendiente, Observaciones, TextoPie, TextoCabe) ";
                    insert_cabecera += " VALUES(" + IdFactura + "," + textBox_Anyo.Text + ", '" + comboBox_Serie.Text + "', '" + DateTime.Today.ToShortDateString() + "', " + textBox_DetCod.Text + ", " + textBox_BI.Text.Replace(",", ".") + ", " + textBox_IVA.Text.Replace(",", ".") + ", " + textBox_Recargo.Text.Replace(",", ".") + ", " + textBox_Importe.Text.Replace(",", ".") + ", 0, " + textBox_Importe.Text.Replace(",", ".") + ", '" + observaciones + "', '" + textopie + "', '" + textocabe + "')";

                    int res_cabecera = EjecutaNonQuery(insert_cabecera);

                    if (res_cabecera == 1)
                    {
                        //ahora hay que marcar los albaranes de venta como facturados
                        Funciones.Marcar_Ventas(IdFactura, textBox_Anyo.Text, comboBox_Serie.Text, Lista_Albaranes, CnO);

                        switch (frmPpal.USUARIO)
                        {
                            case "1":
                                Imprimir_factura(IdFactura);
                                Cobrar_factura(IdFactura);
                                break;

                            case "2":
                                break;
                            default:
                                break;
                        }
                        GloblaVar.gUTIL.ATraza(gIdent + " Se ajustará el cobro de la factura Introducida: " + IdFactura + "/" + textBox_Anyo.Text+"-"+ comboBox_Serie.Text);
                        GloblaVar.gUTIL.SP3(IdFactura, textBox_Anyo.Text, comboBox_Serie.Text  );
                        Cargar();
                        Limpieza_Factura();
                        MessageBox.Show("Factura " + IdFactura.ToString() + " ha sido grabada");
                        GloblaVar.gUTIL.ATraza(gIdent + "Factura " + IdFactura + " ha sido grabada");
                    }
                    else
                    {
                        MessageBox.Show("Problema al grabar la factura");
                        GloblaVar.gUTIL.ATraza(gIdent + "Factura " + IdFactura + " ha sido grabada");
                    }
                }
                else
                {
                    //posible albarán ya facturado, recargar
                    Cargar();
                    Limpieza_Factura();
                }
            }
        }

        private void Renumerar_Grid()
        {
            //esta función es necesaria porque se pueden marcar y desmarcar muchos albaranes
            //y es mejor renumerar las líneas de factura para que sean correlativas

            if (dataGridView_Facturado.Rows.Count > 0)
            {
                for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                {
                    int contador = x + 1;
                    dataGridView_Facturado.Rows[x].Cells[1].Value = contador.ToString(); //la celda 1 es Pos
                }
            }
        }

        private void Formato_Facturado()
        {
            //esta función ajusta las columnas de lineas de factura

            if (dataGridView_Facturado.Rows.Count > 0)
            {
                dataGridView_Facturado.Columns[0].Visible = false;
                dataGridView_Facturado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[2].Visible = false;
                dataGridView_Facturado.Columns[3].Visible = false;
                dataGridView_Facturado.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[5].Visible = false;
                dataGridView_Facturado.Columns[6].Visible = false;
                dataGridView_Facturado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[13].Visible = false;
                dataGridView_Facturado.Columns[14].Visible = false;
                dataGridView_Facturado.Columns[15].Visible = false;
            }
        }

        private void Marcaciones(int indice)
        {
            //esta función se activa cuando se marca un albarán

            string VenAlb = dataGridView_Albaranes.Rows[indice].Cells[1].Value.ToString();
            string Anyo = dataGridView_Albaranes.Rows[indice].Cells[3].Value.ToString();
            //string VenFec = dataGridView_Albaranes.Rows[indice].Cells[4].Value.ToString();

            //string VenBru = dataGridView_Albaranes.Rows[indice].Cells[6].Value.ToString();
            //string VenIva = dataGridView_Albaranes.Rows[indice].Cells[7].Value.ToString();
            //string VenRec = dataGridView_Albaranes.Rows[indice].Cells[8].Value.ToString();


            //comprobar si estaba marcada
            bool marcada = false;

            if (dataGridView_Albaranes.Rows[indice].Cells[0].Value.ToString().ToLower() == "true")
            {
                marcada = true;
            }

            if (marcada)
            {
                //si esta marcada se va a desmarcar
                dataGridView_Albaranes.Rows[indice].Cells[0].Value = false;

                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                    {
                        int row = 0; bool encontrada = false;

                        if (dataGridView_Facturado.Rows[x].Cells[4].Value.ToString() == VenAlb)
                        {
                            encontrada = true;
                            row = x;
                        }

                        if (encontrada == true)
                        {
                            dataGridView_Facturado.Rows.Remove(dataGridView_Facturado.Rows[row]);
                            Renumerar_Grid();
                            x--;
                        }
                    }
                }

            }
            else
            {
                dataGridView_Albaranes.Rows[indice].Cells[0].Value = true;
                int contador = dataGridView_Facturado.Rows.Count + 1;

                //lectura de lineas de albarán
                ArrayList Lineas = Funciones.Lineas_Albaran(VenAlb, Anyo, CnO);

                for (int x = 0; x < Lineas.Count; x++)
                {
                    detalle_linea_albaran linea_albaran = (detalle_linea_albaran)Lineas[x];

                    clase_linea_factura linea_factura = new clase_linea_factura();

                    linea_factura.Albaran = VenAlb;
                    linea_factura.Anyo = textBox_Anyo.Text;
                    linea_factura.AnyoAlb = Anyo;
                    linea_factura.ArtCod = linea_albaran.ArtCod;
                    linea_factura.Cajas = linea_albaran.VelBul;
                    linea_factura.Factura = "";
                    linea_factura.Importe = Funciones.Formatea(linea_albaran.VelImp);
                    linea_factura.Kilos = linea_albaran.VelKil;
                    linea_factura.Linea = contador.ToString();
                    linea_factura.LineaAlbaran = linea_albaran.VelLin;
                    linea_factura.PartAnyo = linea_albaran.PartAnyo;
                    linea_factura.Partida = linea_albaran.Partida;
                    linea_factura.Precio = linea_albaran.VelPre;
                    linea_factura.Serie = comboBox_Serie.Text;
                    linea_factura.Traza = linea_albaran.VelTrz;
                    linea_factura.PartAlm = linea_albaran.PartAlm;

                    //se ha creado una línea de factura a partir de las lineas del albarán y ahora se agrega por binding

                    dataSource2.Add(linea_factura);

                    contador++;
                }

            }

        }

        private void dataGridView_Albaranes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //comprobar que se ha pulsado la primera columna
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    Marcaciones(e.RowIndex);
                    Formato_Facturado();
                }
            }
        }

        private void Recuento_Importes_Albaranes()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);

            try
            {
                if (dataGridView_Albaranes.Rows.Count > 0)
                {
                    string base_imponible = "0";
                    string iva = "0";
                    string recargo = "0";
                    string importe_total = "0";

                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                        {
                            string VenTot = dataGridView_Albaranes.Rows[x].Cells[5].Value.ToString();
                            string VenBru = dataGridView_Albaranes.Rows[x].Cells[6].Value.ToString();
                            string VenIva = dataGridView_Albaranes.Rows[x].Cells[7].Value.ToString();
                            string VenRec = dataGridView_Albaranes.Rows[x].Cells[8].Value.ToString();

                            base_imponible = Funciones.Suma(base_imponible, VenBru);
                            iva = Funciones.Suma(iva, VenIva);
                            recargo = Funciones.Suma(recargo, VenRec);
                            importe_total = Funciones.Suma(importe_total, VenTot);
                        }
                    }

                    textBox_BI.Text = Funciones.Formatea(base_imponible);
                    textBox_IVA.Text = Funciones.Formatea(iva);
                    textBox_Recargo.Text = Funciones.Formatea(recargo);
                    textBox_Importe.Text = Funciones.Formatea(importe_total);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //temporizador para recuento
            Recuento_Importes_Albaranes();
        }

        private void checkBox_Marcar_CheckedChanged(object sender, EventArgs e)
        {
            //marcar todos los albaranes para facturar

            if (dataGridView_Albaranes.Rows.Count > 100)
            {
                MessageBox.Show("Hay más de 100 albaranes, el proceso llevaría demasiado tiempo");
            }
            else
            {

                this.Cursor = Cursors.WaitCursor;

                dataSource2.Clear();
                if (checkBox_Marcar.Checked == true)
                {
                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        dataGridView_Albaranes.Rows[x].Cells[0].Value = "False";
                        Marcaciones(x);
                    }
                    Formato_Facturado();
                }
                else
                {
                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        dataGridView_Albaranes.Rows[x].Cells[0].Value = "True";
                        Marcaciones(x);
                    }
                    Formato_Facturado();
                }

                this.Cursor = Cursors.Default;
            }
        }


        private void textBox_DetCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
