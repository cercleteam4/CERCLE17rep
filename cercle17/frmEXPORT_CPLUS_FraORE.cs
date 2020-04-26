using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace cercle17
{
    public partial class frmEXPORT_CPLUS_FraORE : Form
    {
        public frmEXPORT_CPLUS_FraORE()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        //private string Cadena="";

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        }

        private int EjecutaNonQuery(string NonQuery)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Se ejecutará " + NonQuery);
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, CnO);
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(NonQuery + "\r\n" + ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + " ERROR " + ex.ToString());
            }

            GloblaVar.gUTIL.ATraza(gIdent + " Retorno de EjecutaNonQuery " + res);
            return res;
        }

        private void Cargar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            ArrayList Lista_Facturas = new ArrayList();

            //creamos la sentencia SQL que cruza factura con detallista (para tener nombre de detallista)

            string strQ = "SELECT FC.*, D.DetNom FROM FACTV_CABE FC, DETALLISTAS D WHERE (FC.DetCod=D.DetCod) ";

            //if (checkBox_Fecha.Checked == true)
            //{
            //    //filtro por fecha
            strQ += " and (FC.FechaEmision BETWEEN '" + dateTimePicker_Inicio.Text + "' AND '" + dateTimePicker_Fin.Text + "') ";
            //}

            //ordenar
            strQ += " order by FC.Anyo, FC.Factura, FC.Serie";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, GloblaVar.gcnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_cabecera_factura factura = new clase_cabecera_factura();

                    factura.Anyo = myReader["Anyo"].ToString();
                    factura.DetCod = myReader["DetCod"].ToString();
                    factura.DetNom = myReader["DetNom"].ToString();
                    factura.Factura = myReader["Factura"].ToString();
                    factura.FechaEmision = myReader["FechaEmision"].ToString(); if (factura.FechaEmision.Length > 10) { factura.FechaEmision = factura.FechaEmision.Substring(0, 10); }
                    factura.Importe = Funciones.Formatea(myReader["ImpteFactura"].ToString());
                    factura.ImporteCobrado = Funciones.Formatea(myReader["ImpteCobrado"].ToString());
                    factura.ImportePendiente = Funciones.Formatea(myReader["ImptePendiente"].ToString());
                    factura.Seleccion = false;
                    factura.Serie = myReader["Serie"].ToString();


                    Lista_Facturas.Add(factura);

                }
                myReader.Close();

                dataGridView_Facturado.DataSource = Lista_Facturas;     //el array se agrega al grid

                if (dataGridView_Facturado.Rows.Count > 0)
                {
                    //aprovechamos para cambiar los nombres de algunas columnas

                    dataGridView_Facturado.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[1].HeaderText = "Año";
                    dataGridView_Facturado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[3].HeaderText = "Código Det";
                    dataGridView_Facturado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[4].HeaderText = "Nombre Det";
                    dataGridView_Facturado.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView_Facturado.Columns[5].HeaderText = "Fecha Emisión";
                    dataGridView_Facturado.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[7].HeaderText = "Pendiente";
                    dataGridView_Facturado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[8].HeaderText = "Selección";
                    dataGridView_Facturado.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Facturado.Columns[9].Visible = false;

                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
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
            string SubCtaCli;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //1.- LEEMOS EL FICHERO QUE NOS PASA OREMAPE, lo tenemos en sr
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());

                //2.- Borramos la tabla en la que vamos a insertar los registros
                int res = EjecutaNonQuery("DELETE FROM CONTAB_FACTV_CABE");

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
                        SubCtaCli = Funciones.DameSubctaDet(DetCod, CnO);

                        if (Signo == "-")
                        {
                            BI = "-" + BI;
                            IVA = "-" + IVA;
                            Req = "-" + Req;
                            Importe = "-" + Importe;

                        }

                        string sQ = "INSERT INTO CONTAB_FACTV_CABE (";
                        sQ += "Factura,Anyo,Serie,FechaEmision,DetCod,SubCta,BI1,IVA1,RE1,ImpteFactura";
                        sQ += ") VALUES (";
                        sQ += Factura + ",";
                        sQ += Año + ",";
                        sQ += "'" + Serie + "',";
                        sQ += "'" + FechaFact + "',";
                        sQ += DetCod + ",";
                        sQ += "'" + SubCtaCli + "',";
                        sQ += BI + ",";
                        sQ += IVA + ",";
                        sQ += Req + ",";
                        sQ += Importe;
                        sQ += ")";

                        //INSERTAMOS LINEA A LINEA EN LA TABLA
                        res = EjecutaNonQuery(sQ);
                    }
                } // while ((linea = sr.ReadLine()) != null)
                sr.Close();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = NumFras;
                progressBar1.Value = 0;
                Exportar_Facturas_Oremape();
                //4.- YA TENEMOS LA TABLA CON LAS FACTURAS LEÍDAS. AHORA DEBEMOS PREPARAR EL FICHERO PARA CONTAPLUS

            }
        }

        private void Exportar_Facturas_Oremape()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            int ASiento = 1; //Inicializamos el nº de asiento
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\FACTURAS_OREMAPE_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";


            TextWriter tw = new StreamWriter(fichero);


            //1.- LEEMOS LAS FACTURAS DE LA TABLA CONTAB_FACTV_CABE
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT F.*, D.DetNif, D.DetNom FROM CONTAB_FACTV_CABE F LEFT JOIN DETALLISTAS D ON F.DetCod=D.DetCod ", CnO);
            myReader = myCommand.ExecuteReader();

            string Factura;
            string Año;
            string Serie;
            string DetCod;
            string SubCtaDet;
            string BI1;
            string IVA1;
            string RE1;
            string ImporteFact;
            string FechaFact;
            string DetNif;
            string DetNom;     //si hubiera que cambiarlo por el DetNom, aquí está la variable

            while (myReader.Read())
            {
                Factura = myReader["Factura"].ToString();
                Año = myReader["Anyo"].ToString();
                Serie = myReader["Serie"].ToString().Substring(0, 1);
                DetCod = myReader["DetCod"].ToString();
                SubCtaDet = myReader["SubCta"].ToString();
                BI1 = Funciones.Formatea(myReader["BI1"].ToString()).Replace(',', '.');
                IVA1 = Funciones.Formatea(myReader["IVA1"].ToString()).Replace(',', '.');
                RE1 = Funciones.Formatea(myReader["RE1"].ToString()).Replace(',', '.');
                ImporteFact = Funciones.Formatea(myReader["ImpteFactura"].ToString()).Replace(',', '.');
                FechaFact = myReader["FechaEmision"].ToString();
                if (FechaFact.Length > 10) { FechaFact = FechaFact.Substring(0, 10); }
                //FechaFact = FechaFact.Substring(6, 4) + FechaFact.Substring(3, 2) + FechaFact.Substring(0, 2);
                DetNif = Regex.Replace(myReader["DetNif"].ToString(), "-", string.Empty); 
                DetNom = myReader["DetNom"].ToString();



                //**********************************************************************************
                //**********************************************************************************
                //*************************************************************************************
                //*************************************************************************************
                //ya tenemos los datos

                string linea_det = "";
                string linea_venta = "";
                string linea_iva = "";

                //asiento

                linea_det += ASiento.ToString().PadLeft(6, ' ');
                linea_venta += ASiento.ToString().PadLeft(6, ' ');
                linea_iva += ASiento.ToString().PadLeft(6, ' ');

                //fecha

                DateTime fecha_emision = new DateTime();
                string fecha_formateada = "";

                if (DateTime.TryParse(FechaFact, out fecha_emision))
                {
                    fecha_formateada = fecha_emision.Year.ToString() + fecha_emision.Month.ToString().PadLeft(2, '0') + fecha_emision.Day.ToString().PadLeft(2, '0');
                }

                linea_det += fecha_formateada;
                linea_venta += fecha_formateada;
                linea_iva += fecha_formateada;


                //nos centramos en linea_det

                string cero_cero = "0.00";
                string cero_seis = "0.000000";
                string cero = "0";
                string uno = "1";
                string blanco = " ";
                string num_factura = "FRA. " + Factura+" "+Serie ;

                if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
                {
                    num_factura = "VENTA MERC. FRA. " + Factura + "-" + Serie;
                }

                string valor_IVA = "10.00";    //el 10% de momento
                string valor_RE = "1.40";       //recargo del 1,40 (hay que usar dos decimales y el punto)
               

                linea_det += SubCtaDet.PadRight(12, ' ');
                linea_det += cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                linea_det += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ');
                linea_det += blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ');

                linea_det += cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                linea_det += ImporteFact.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_det += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_det += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_det += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                //linea_venta

                linea_venta += GloblaVar.gSubCtaVENTAS.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                linea_venta += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_venta += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                linea_venta += cero_cero.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_venta += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_venta += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_venta += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";




                //grabar

                tw.WriteLine(linea_det);
                tw.WriteLine(linea_venta);
                //tw.WriteLine(linea_iva);


                //comprobar si tiene recargo

                if (RE1 == "0.00")
                {
                    //no tiene recargo, 3 lineas
                    //linea_iva

                    linea_iva += GloblaVar.gSubCtaIVA1.PadRight(12, ' ') + SubCtaDet.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                    linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_iva += cero_cero.PadLeft(16, ' ') + IVA1.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_iva += blanco.PadLeft(8, ' ') + fecha_formateada + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_iva += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "1" + DetNif.PadRight(15, ' ') + DetNom.PadRight(40, ' ');
                    linea_iva += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                        EG                                        T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                    //no hay que hacer nada más
                    tw.WriteLine(linea_iva);
                }
                else
                {
                    //tiene recargo, 4 lineas

                    //linea_iva

                    linea_iva += GloblaVar.gSubCtaIVAconReq.PadRight(12, ' ') + SubCtaDet.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                    linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + valor_RE.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_iva += cero_cero.PadLeft(16, ' ') + IVA1.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_iva += blanco.PadLeft(8, ' ') + fecha_formateada + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_iva += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "1" + DetNif.PadRight(15, ' ') + DetNom.PadRight(40, ' ');
                    linea_iva += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                        EG                                        T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                    string linea_rec = ASiento.ToString().PadLeft(6, ' ') + fecha_formateada;

                    linea_rec += GloblaVar.gSubCtaREQ1.PadRight(12, ' ') + SubCtaDet.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                    linea_rec += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_rec += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_rec += cero_cero.PadLeft(16, ' ') + RE1.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_rec += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_rec += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                    linea_rec += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                    tw.WriteLine(linea_iva);
                    tw.WriteLine(linea_rec);
                    progressBar1.Increment(1);
                }



                //incrementamos asiento

                ASiento++;

                //**********************************************************************************
                //**********************************************************************************
                //**********************************************************************************
                //**********************************************************************************

            } //While myreader.Read
            ASiento = ASiento - 1;
            MessageBox.Show(ASiento.ToString() + " Facturas de OREMAPE EXPORTADAS en " + fichero);

            tw.Close();
            //2.- ABRIMOS EL FICHERO DE DESTINO


            //2.1.- INTRODUCIMOS LINEA A LÍNEA en el DESTINO
        }

        private void frmEXPORT_CPLUS_FraORE_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            switch (GloblaVar.TeMp)
            {
                case "EXPORTACIÓN FACTURAS DE OREMAPE":
                    button1.Visible = true;
                    button2.Visible = false;
                    lFI.Visible = lFF.Visible = dateTimePicker_Inicio.Visible = dateTimePicker_Fin.Visible = false;
                    break;

                case "EXPORTACIÓN COBROS PROPIOS":
                    button1.Visible = false;
                    button2.Visible = true;
                    break;
            }
            Seguridad();
            this.Text = GloblaVar.TeMp + " PARA CONTAPLUS  " + GloblaVar.VERSION;
        }  //frmEXPORT_CPLUS_FraORE_Load

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2":
                    button3.Visible = false;
                    button4.Visible = false;
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
                case "5": //Dialpesca
                    btnTodos.Visible = true;
                    break;
                case "8": //VALPEIX
                    btnTodos.Visible = true;
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad


        private void button2_Click(object sender, EventArgs e)
        {
            Exportar_Cobros_Facturas_Propias();
        }

        private void Exportar_Cobros_Facturas_Propias()
        //Exportará facturas propias (Serie AA a Contaplús, Es decir preparará el fichero COBROS_FACTURAS_PROPIAS
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            int ASiento = 1; //Inicializamos el nº de asiento
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\COBROS_FACTURAS_PROPIAS_DIARIO_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter tw = new StreamWriter(fichero);

            //Aquí guardamos el fichero SUBCUENTAS, de momento sólo pasamos los datos de la subcuenta del detallista
            string ficheroSubcuentas = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\COBROS_FACTURAS_PROPIAS_SUBCUENTAS_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter twSubcuentas = new StreamWriter(ficheroSubcuentas);


            //1.- LEEMOS LAS FACTURAS DE LA TABLA FACTV_CABE
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT FC.*, D.SubCta, D.DetNom, D.DetNIF, D.detvia, D.DetMun, D.detpro, D.DetCop FROM FACTV_CABE  as FC INNER JOIN DETALLISTAS as D on FC.DetCod=D.DetCod  WHERE ImptePendiente<=0 AND FechaCobro BETWEEN '" + dateTimePicker_Inicio.Text + "'  AND  '" + dateTimePicker_Fin.Text + "'", GloblaVar.gcnO);
            myReader = myCommand.ExecuteReader();

            string Factura;
            string Año;
            string Serie;
            string DetCod;
            string SubCtaDet;
            string BI1;
            string IVA1;
            string RE1;
            string ImporteFact;
            string FechaFact;

            //string subcuenta = "";
            string NIF_Cliente = "";
            string Nombre_Cliente = "";
            string Via_Cliente = "";
            string Municipio_Cliente = "";
            string Provincia_Cliente = "";
            string CP_Cliente = "";

            while (myReader.Read())
            {
                Factura = myReader["Factura"].ToString();
                Año = myReader["Anyo"].ToString();
                Serie = myReader["Serie"].ToString().Substring(0, 1);
                DetCod = myReader["DetCod"].ToString();
                SubCtaDet = myReader["SubCta"].ToString();
                BI1 = Funciones.Formatea(myReader["BI1"].ToString()).Replace(',', '.');
                IVA1 = Funciones.Formatea(myReader["IVA1"].ToString()).Replace(',', '.');
                RE1 = Funciones.Formatea(myReader["RE1"].ToString()).Replace(',', '.');
                ImporteFact = Funciones.Formatea(myReader["ImpteFactura"].ToString()).Replace(',', '.');
                FechaFact = myReader["FechaEmision"].ToString();
                if (FechaFact.Length > 10) { FechaFact = FechaFact.Substring(0, 10); }
                //FechaFact = FechaFact.Substring(6, 4) + FechaFact.Substring(3, 2) + FechaFact.Substring(0, 2);

                Nombre_Cliente = Convert.ToString(myReader["DetNom"]);
                NIF_Cliente = Convert.ToString(myReader["DetNif"]);
                Via_Cliente = Convert.ToString(myReader["detvia"]);
                Municipio_Cliente = Convert.ToString(myReader["DetMun"]);
                Provincia_Cliente = Convert.ToString(myReader["detpro"]);
                CP_Cliente = Convert.ToString(myReader["DetCop"]);

                //**********************************************************************************
                //**********************************************************************************
                //*************************************************************************************
                //*************************************************************************************
                //ya tenemos los datos

                string blanco = " ";

                //Añadimos al fichero de SUBCUENTAS los detallistas para pasar a Contaplus
                string linea_subcuenta = "";

                linea_subcuenta += SubCtaDet.PadRight(12, ' ');
                linea_subcuenta += Nombre_Cliente.PadRight(40, ' ');
                linea_subcuenta += NIF_Cliente.PadRight(15, ' ');
                linea_subcuenta += Via_Cliente.PadRight(35, ' ');
                linea_subcuenta += Municipio_Cliente.PadRight(25, ' ');
                linea_subcuenta += Provincia_Cliente.PadRight(20, ' ');
                linea_subcuenta += CP_Cliente.PadRight(5, ' ');
                linea_subcuenta += "F" + blanco.PadRight(5, ' ') + "FF" + blanco.PadRight(34, ' ') + "F" + blanco.PadRight(12, ' ') + blanco.PadRight(259, ' ');
                                

                string linea_det = "";
                string linea_caja = "";
                //string linea_venta = "";
                //string linea_iva = "";

                //asiento

                linea_caja += ASiento.ToString().PadLeft(6, ' ');
                linea_det += ASiento.ToString().PadLeft(6, ' ');

                //linea_venta += ASiento.ToString().PadLeft(6, ' ');
                //linea_iva += ASiento.ToString().PadLeft(6, ' ');

                //fecha

                DateTime fecha_emision = new DateTime();
                string fecha_formateada = "";

                if (DateTime.TryParse(FechaFact, out fecha_emision))
                {
                    fecha_formateada = fecha_emision.Year.ToString() + fecha_emision.Month.ToString().PadLeft(2, '0') + fecha_emision.Day.ToString().PadLeft(2, '0');
                }

                linea_caja += fecha_formateada;
                linea_det += fecha_formateada;
                //linea_venta += fecha_formateada;
                //linea_iva += fecha_formateada;


                //nos centramos en linea_det

                string cero_cero = "0.00";
                string cero_seis = "0.000000";
                string cero = "0";
                string uno = "1";
                //string blanco = " ";
                string num_factura = "COBRO FRA. " + Factura + "-" + Serie;
                //string valor_IVA = "10.00";    //el 10% de momento
                //string valor_RE = "1.40";       //recargo del 1,40 (hay que usar dos decimales y el punto)
                //string nombre_cliente = "Clientes";     //si hubiera que cambiarlo por el DetNom, aquí está la variable

                linea_caja += GloblaVar.gSubCtaCAJA.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                linea_caja += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_caja += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                linea_caja += ImporteFact.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_caja += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_caja += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_caja += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";


                // string cero_cero = "0.00";
                //string cero_seis = "0.000000";
                //string cero = "0";
                //string uno = "1";
                //string blanco = " ";
                //string num_factura = "FRA. " + Factura;
                //string valor_IVA = "10.00";    //el 10% de momento
                //string valor_RE = "1.40";       //recargo del 1,40 (hay que usar dos decimales y el punto)
                //string nombre_cliente = "Clientes";     //si hubiera que cambiarlo por el DetNom, aquí está la variable

                linea_det += SubCtaDet.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                linea_det += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                linea_det += cero_cero.PadLeft(16, ' ') + ImporteFact.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_det += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_det += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_det += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                                

                //grabar
                
                tw.WriteLine(linea_caja);
                tw.WriteLine(linea_det);
                twSubcuentas.WriteLine(linea_subcuenta);

                progressBar1.Increment(1);

                //incrementamos asiento

                ASiento++;

                //**********************************************************************************
                //**********************************************************************************
                //**********************************************************************************
                //**********************************************************************************

            } //While myreader.Read
            tw.Close();
            twSubcuentas.Close();

            ASiento = ASiento - 1;
            //MessageBox.Show(ASiento.ToString() + " COBROS de Facturas PROPIAS EXPORTADAS en " + fichero);
            MessageBox.Show("FICHEROS EXPORTADOS: \n\n" + fichero + " ( " + ASiento + " asientos )\n" + ficheroSubcuentas);

            //2.- ABRIMOS EL FICHERO DE DESTINO


            //2.1.- INTRODUCIMOS LINEA A LÍNEA en el DESTINO
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            int Asiento = 1;
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\COBROS_FACTURAS_PROPIAS_DIARIO_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter tw = new StreamWriter(fichero);

            //Aquí guardamos el fichero SUBCUENTAS, de momento sólo pasamos los datos de la subcuenta del detallista
            string ficheroSubcuentas = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\COBROS_FACTURAS_PROPIAS_SUBCUENTAS_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter twSubcuentas = new StreamWriter(ficheroSubcuentas);

            foreach (DataGridViewRow row in dataGridView_Facturado.Rows)
            {
                if (dataGridView_Facturado.Rows[row.Index].Cells[8].Value.ToString().ToLower() == "true")
                {
                    String FacturaBuscada = dataGridView_Facturado.Rows[row.Index].Cells[0].Value.ToString();
                    string AñoFact = dataGridView_Facturado.Rows[row.Index].Cells[1].Value.ToString();

                    //Tenemos localizada una factura a exportar. Ahora procedemos a procesarla e incorporarla al fichero con el asiento correspondiente.

                    SqlDataReader myReader = null;
                    //myReader.Close();
                    SqlCommand myCommand = new SqlCommand("SELECT FC.*, D.SubCta, D.DetNom, D.DetNIF, D.detvia, D.DetMun, D.detpro, D.DetCop FROM FACTV_CABE  as FC INNER JOIN DETALLISTAS as D on FC.DetCod=D.DetCod  WHERE Factura=" + FacturaBuscada + " AND  Anyo=" + AñoFact, GloblaVar.gcnO);
                    myReader = myCommand.ExecuteReader();

                    string Factura;
                    string Año;
                    string Serie;
                    string DetCod;
                    string SubCtaDet;
                    string BI1;
                    string IVA1;
                    string RE1;
                    string ImporteFact;
                    string FechaFact;

                    //string subcuenta = "";
                    string NIF_Cliente = "";
                    string Nombre_Cliente = "";
                    string Via_Cliente = "";
                    string Municipio_Cliente = "";
                    string Provincia_Cliente = "";
                    string CP_Cliente = "";

                    while (myReader.Read())
                    {
                        Factura = myReader["Factura"].ToString();
                        Año = myReader["Anyo"].ToString();
                        Serie = myReader["Serie"].ToString().Substring(0, 1);
                        DetCod = myReader["DetCod"].ToString();
                        SubCtaDet = myReader["SubCta"].ToString();
                        BI1 = Funciones.Formatea(myReader["BI1"].ToString()).Replace(',', '.');
                        IVA1 = Funciones.Formatea(myReader["IVA1"].ToString()).Replace(',', '.');
                        RE1 = Funciones.Formatea(myReader["RE1"].ToString()).Replace(',', '.');
                        ImporteFact = Funciones.Formatea(myReader["ImpteFactura"].ToString()).Replace(',', '.');
                        FechaFact = myReader["FechaEmision"].ToString();
                        if (FechaFact.Length > 10) { FechaFact = FechaFact.Substring(0, 10); }
                        //FechaFact = FechaFact.Substring(6, 4) + FechaFact.Substring(3, 2) + FechaFact.Substring(0, 2);

                        Nombre_Cliente = Convert.ToString(myReader["DetNom"]);
                        NIF_Cliente = Convert.ToString(myReader["DetNif"]);
                        Via_Cliente = Convert.ToString(myReader["detvia"]);
                        Municipio_Cliente = Convert.ToString(myReader["DetMun"]);
                        Provincia_Cliente = Convert.ToString(myReader["detpro"]);
                        CP_Cliente = Convert.ToString(myReader["DetCop"]);

                        //**********************************************************************************
                        //**********************************************************************************
                        //*************************************************************************************
                        //*************************************************************************************
                        //ya tenemos los datos

                        string blanco = " ";

                        //Añadimos al fichero de SUBCUENTAS los detallistas para pasar a Contaplus
                        string linea_subcuenta = "";

                        linea_subcuenta += SubCtaDet.PadRight(12, ' ');
                        linea_subcuenta += Nombre_Cliente.PadRight(40, ' ');
                        linea_subcuenta += NIF_Cliente.PadRight(15, ' ');
                        linea_subcuenta += Via_Cliente.PadRight(35, ' ');
                        linea_subcuenta += Municipio_Cliente.PadRight(25, ' ');
                        linea_subcuenta += Provincia_Cliente.PadRight(20, ' ');
                        linea_subcuenta += CP_Cliente.PadRight(5, ' ');
                        linea_subcuenta += "F" + blanco.PadRight(5, ' ') + "FF" + blanco.PadRight(34, ' ') + "F" + blanco.PadRight(12, ' ') + blanco.PadRight(259, ' ');


                        string linea_det = "";
                        string linea_caja = "";
                        //string linea_venta = "";
                        //string linea_iva = "";

                        //asiento

                        linea_caja += Asiento.ToString().PadLeft(6, ' ');
                        linea_det += Asiento.ToString().PadLeft(6, ' ');

                        //linea_venta += ASiento.ToString().PadLeft(6, ' ');
                        //linea_iva += ASiento.ToString().PadLeft(6, ' ');

                        //fecha

                        DateTime fecha_emision = new DateTime();
                        string fecha_formateada = "";

                        if (DateTime.TryParse(FechaFact, out fecha_emision))
                        {
                            fecha_formateada = fecha_emision.Year.ToString() + fecha_emision.Month.ToString().PadLeft(2, '0') + fecha_emision.Day.ToString().PadLeft(2, '0');
                        }

                        linea_caja += fecha_formateada;
                        linea_det += fecha_formateada;
                        //linea_venta += fecha_formateada;
                        //linea_iva += fecha_formateada;

                        //nos centramos en linea_det

                        string cero_cero = "0.00";
                        string cero_seis = "0.000000";
                        string cero = "0";
                        string uno = "1";
                        //string blanco = " ";
                        string num_factura = "COBRO FRA. " + Factura + "-" + Serie;
                        //string valor_IVA = "10.00";    //el 10% de momento
                        //string valor_RE = "1.40";       //recargo del 1,40 (hay que usar dos decimales y el punto)
                        //string nombre_cliente = "Clientes";     //si hubiera que cambiarlo por el DetNom, aquí está la variable

                        linea_caja += GloblaVar.gSubCtaCAJA.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                        linea_caja += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                        linea_caja += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                        linea_caja += ImporteFact.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                        linea_caja += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                        linea_caja += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                        linea_caja += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                        
                        // string cero_cero = "0.00";
                        //string cero_seis = "0.000000";
                        //string cero = "0";
                        //string uno = "1";
                        //string blanco = " ";
                        //string num_factura = "FRA. " + Factura;
                        //string valor_IVA = "10.00";    //el 10% de momento
                        //string valor_RE = "1.40";       //recargo del 1,40 (hay que usar dos decimales y el punto)
                        //string nombre_cliente = "Clientes";     //si hubiera que cambiarlo por el DetNom, aquí está la variable

                        linea_det += SubCtaDet.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                        linea_det += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                        linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + Serie + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                        linea_det += cero_cero.PadLeft(16, ' ') + ImporteFact.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                        linea_det += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                        linea_det += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                        linea_det += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                        
                        //grabar

                        tw.WriteLine(linea_caja);
                        tw.WriteLine(linea_det);
                        twSubcuentas.WriteLine(linea_subcuenta);
                        
                        progressBar1.Increment(1);
                        
                        //incrementamos asiento                 

                        Asiento++;

                    }
                    myReader.Close();
                }//if la factura está marcada
            }// del foreach fila del datagrid

            tw.Close();
            twSubcuentas.Close();

            Asiento = Asiento - 1;

            //MessageBox.Show("Fichero generado " + fichero);
            MessageBox.Show("FICHEROS EXPORTADOS: \n\n" + fichero + " ( " + Asiento + " asientos )\n" + ficheroSubcuentas);

        }//Fin de button 4

        private void button3_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dataGridView_Facturado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Facturado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                //código necesario para marcar Selección
                if (e.RowIndex >= 0)
                {
                    //la columna 8 es la que se puede marcar

                    if (e.ColumnIndex == 8)
                    {
                        bool marcada = false;

                        if (dataGridView_Facturado.Rows[e.RowIndex].Cells[8].Value.ToString().ToLower() == "true")
                        {
                            marcada = true;
                        }

                        if (marcada)
                        {
                            //si está marcada se va a desmarcar
                            dataGridView_Facturado.Rows[e.RowIndex].Cells[8].Value = false;
                        }
                        else
                        {
                            //y a la inversa
                            dataGridView_Facturado.Rows[e.RowIndex].Cells[8].Value = true;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        { // boton para generar ficheros xbase
            string sBase = "C:\\OREMAPE\\XDIARIO.dbf";
            string sSelect = "SELECT * FROM  XDIARIO";
            string sConn;

            sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(sBase) + ";Extended Properties=dBASE IV;";

            using (System.Data.OleDb.OleDbConnection dbConn = new System.Data.OleDb.OleDbConnection(sConn))
            {
                try
                {
                    dbConn.Open();

                    //System.Data.Odbc.OdbcDataAdapter da = new System.Data.Odbc.OdbcDataAdapter(sSelect, dbConn);
                    System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sSelect, dbConn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDiarios.DataSource = dt;

                    dbConn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la base de datos\n" + ex.Message);
                    GloblaVar.gUTIL.ATraza(ex.Message);
                    return;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sBase = "C:\\OREMAPE\\XDIARIO.dbf";
            //string sSelect = "SELECT * FROM  XDIARIO";
            string sConn;

            sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(sBase) + ";Extended Properties=dBASE IV;";

            using (System.Data.OleDb.OleDbConnection dbConn = new System.Data.OleDb.OleDbConnection(sConn))
            {
                try
                {
                    dbConn.Open();
                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("DELETE FROM XDIARIO", dbConn);
                    cmd.ExecuteNonQuery();
                    dbConn.Close();
                    button5.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                    GloblaVar.gUTIL.ATraza(ex.Message);
                    return;
                }
            }  //private void button5_Click(object sender, EventArgs e)



            //private void LLFI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            //{
            //    dateTimePicker1.Visible = true;
            //    Cadena = "LLFI";
            //}

            //private void LLFF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            //{
            //    dateTimePicker1.Visible = true;
            //    Cadena = "LLFF";

            //}

            //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            //{
            //}

            //private void dateTimePicker1_Validated(object sender, EventArgs e)
            //{
            //    switch (Cadena)
            //    {
            //        case "LLFI":
            //            LFI.Text = dateTimePicker1.Value.ToShortDateString();
            //            break;
            //        case "LLFF":
            //            LFF.Text = dateTimePicker1.Value.ToShortDateString();
            //            break;
            //    }
            //    dateTimePicker1.Visible = false;

            //}


            //private void Cargar()
            //{
            //    ArrayList Lista_Facturas = new ArrayList();

            //    //creamos la sentencia SQL que cruza factura con detallista (para tener nombre de detallista)

            //    string strQ = "SELECT FC.*, D.DetNom FROM FACTV_CABE FC, DETALLISTAS D WHERE (FC.DetCod=D.DetCod) ";

            //    if (checkBox_Fecha.Checked == true)
            //    {
            //        //filtro por fecha
            //        strQ += " and (FC.FechaEmision BETWEEN '" + dateTimePicker_Inicio.Text + "' AND '" + dateTimePicker_Fin.Text + "') ";
            //    }

            //    //ordenar
            //    strQ += " order by FC.Anyo, FC.Factura, FC.Serie";

            //    try
            //    {
            //        SqlDataReader myReader = null;
            //        SqlCommand myCommand = new SqlCommand(strQ, CnO);
            //        myReader = myCommand.ExecuteReader();
            //        while (myReader.Read())
            //        {
            //            clase_cabecera_factura factura = new clase_cabecera_factura();

            //            factura.Anyo = myReader["Anyo"].ToString();
            //            factura.DetCod = myReader["DetCod"].ToString();
            //            factura.DetNom = myReader["DetNom"].ToString();
            //            factura.Factura = myReader["Factura"].ToString();
            //            factura.FechaEmision = myReader["FechaEmision"].ToString(); if (factura.FechaEmision.Length > 10) { factura.FechaEmision = factura.FechaEmision.Substring(0, 10); }
            //            factura.Importe = Funciones.Formatea(myReader["ImpteFactura"].ToString());
            //            factura.ImporteCobrado = Funciones.Formatea(myReader["ImpteCobrado"].ToString());
            //            factura.ImportePendiente = Funciones.Formatea(myReader["ImptePendiente"].ToString());
            //            factura.Seleccion = false;
            //            factura.Serie = myReader["Serie"].ToString();


            //            Lista_Facturas.Add(factura);

            //        }
            //        myReader.Close();

            //        dataGridView_Facturado.DataSource = Lista_Facturas;     //el array se agrega al grid

            //        if (dataGridView_Facturado.Rows.Count > 0)
            //        {
            //            //aprovechamos para cambiar los nombres de algunas columnas

            //            dataGridView_Facturado.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[1].HeaderText = "Año";
            //            dataGridView_Facturado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[3].HeaderText = "Código Det";
            //            dataGridView_Facturado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[4].HeaderText = "Nombre Det";
            //            dataGridView_Facturado.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //            dataGridView_Facturado.Columns[5].HeaderText = "Fecha Emisión";
            //            dataGridView_Facturado.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[7].HeaderText = "Pendiente";
            //            dataGridView_Facturado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[8].HeaderText = "Selección";
            //            dataGridView_Facturado.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //            dataGridView_Facturado.Columns[9].Visible = false;

            //        }
            //        else
            //        {
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;


            if (btnTodos.Text == "Ninguno")
            {

                for (int i = 0; i < dataGridView_Facturado.Rows.Count; i++)
                {
                    dataGridView_Facturado.Rows[i].Cells[8].Value = false;
                }
                btnTodos.Text = "Todos";
            }
            else
            {
                for (int i = 0; i < dataGridView_Facturado.Rows.Count; i++)
                {
                    dataGridView_Facturado.Rows[i].Cells[8].Value = true;
                }
                btnTodos.Text = "Ninguno";
            }

            //Calcula_Totales();

        }
    }
}
