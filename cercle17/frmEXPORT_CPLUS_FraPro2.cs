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
    public partial class frmEXPORT_CPLUS_FraPro2 : Form
    {
        public frmEXPORT_CPLUS_FraPro2()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        public string Tipo;
        private string Digitos, SubCtaIVA, SubCtaREQ, SubCtaVentas, SubCtaIVAconReq;

        private void Cargar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            ArrayList Lista_Facturas = new ArrayList();

            //creamos la sentencia SQL que cruza factura con detallista (para tener nombre de detallista)

            string strQ = "SELECT FC.*, D.DetNom FROM FACTV_CABE FC, DETALLISTAS D WHERE (FC.DetCod=D.DetCod) ";


            if (checkBox_Fecha.Checked == true)
            {
                //filtro por fecha
                strQ += " and (FC.FechaEmision BETWEEN '" + dateTimePicker_Inicio.Text + "' AND '" + dateTimePicker_Fin.Text + "') ";
            }

            //Particularizaciones por tipo
            switch (Tipo)
            {
                case "8000_Resumen":
                    strQ += " and FC.DetCod=8000 ";
                    break;
                default:
                    break;
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
                Calcula_Totales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }   //Cargar

        private void Carga_datos()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            string strQ = "select * FROM CONTROL_CONTAB";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Digitos = myReader["DigitosSubCta"].ToString();
                    SubCtaIVA = myReader["SubCtaIVA1"].ToString();
                    SubCtaREQ = myReader["SubCtaReq1"].ToString();
                    SubCtaVentas = myReader["SubCtaVentas"].ToString();
                    SubCtaIVAconReq = myReader["SubCtaIVAconReq"].ToString();
                }
                myReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmExportacion_Load(object sender, EventArgs e)
        {
            //iniciar filtros por defecto
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            switch (Tipo)
            {
                case "8000_Resumen":
                    GloblaVar.gUTIL.CartelTraza("EXPORTACIÓN DE FACTURAS de 8000 PARA ContaPLUS " + GloblaVar.VERSION);
                    this.Text = "EXPORTACIÓN DE FACTURAS PROPIAS de 8000 " + GloblaVar.VERSION; break;
                default:
                    this.Text = "EXPORTACIÓN DE FACTURAS PROPIAS 2 " + GloblaVar.VERSION;
                    GloblaVar.gUTIL.CartelTraza("EXPORTACIÓN DE FACTURAS PROPIAS 2 PARA ContaPLUS " + GloblaVar.VERSION);
                    break;
            }


            checkBox_Fecha.Checked = true;
            Seguridad();
            Carga_datos();

            //cargar facturas
            Cargar();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            this.Close();
        }
        private void button_Exportar_xBase_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Click en EXPORTAR Facturas Propias xBASE ");

            int asiento = 1;
            xBase();
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\FRAS_PROP_xBASE_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";

            TextWriter tw = new StreamWriter(fichero);

            for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
            {

            }  //for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)

        }  // private void button_Exportar_xBase_Click(object sender, EventArgs e)

        private void button_Exportar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Click en EXPORTAR Facturas Propias ");

            int asiento = 1;

            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\FACTURAS_PROPIAS_DIARIO_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter tw = new StreamWriter(fichero);

            //Aquí guardamos el fichero SUBCUENTAS, de momento sólo pasamos los datos de la subcuenta del detallista
            string ficheroSubcuentas = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\FACTURAS_PROPIAS_SUBCUENTAS_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter twSubcuentas = new StreamWriter(ficheroSubcuentas);

            for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
            {
                if (dataGridView_Facturado.Rows[x].Cells[8].Value.ToString().ToLower() == "true")
                {
                    string Factura = dataGridView_Facturado.Rows[x].Cells[0].Value.ToString();
                    string Anyo = dataGridView_Facturado.Rows[x].Cells[1].Value.ToString();
                    string Serie = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString();
                    string DetCod = dataGridView_Facturado.Rows[x].Cells[3].Value.ToString();
                    string FechaEmision = dataGridView_Facturado.Rows[x].Cells[5].Value.ToString();
                    string Importe = dataGridView_Facturado.Rows[x].Cells[6].Value.ToString();
                    string BI1 = "";
                    string IVA1 = "";
                    string RE1 = "";

                    string strQ = "SELECT BI1, IVA1, RE1 FROM FACTV_CABE WHERE Factura=" + Factura + " AND Anyo=" + Anyo + " AND Serie='" + Serie + "'";
                    Serie = Serie.Substring(1, 1);
                    GloblaVar.gUTIL.ATraza(gIdent + " Serie=" + Serie);

                    try
                    {
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand(strQ, CnO);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            //queremos los valores formateados con dos decimales y un punto en vez de coma

                            BI1 = Funciones.Formatea(myReader["BI1"].ToString()).Replace(',', '.');
                            IVA1 = Funciones.Formatea(myReader["IVA1"].ToString()).Replace(',', '.');
                            RE1 = Funciones.Formatea(myReader["RE1"].ToString()).Replace(',', '.');

                            //lo mismo para el importe

                            Importe = Funciones.Formatea(Importe).Replace(',', '.');
                        }
                        myReader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    string subcuenta = "";
                    string NIF_Cliente = "";
                    string Nombre_Cliente = "";
                    string Via_Cliente = "";
                    string Municipio_Cliente = "";
                    string Provincia_Cliente = "";
                    string CP_Cliente = "";

                    string select_subcuenta = "SELECT SubCta, DetNom, DetNIF, detvia, DetMun, detpro, DetCop FROM DETALLISTAS WHERE DetCod=" + DetCod;

                    try
                    {
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand(select_subcuenta, CnO);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            subcuenta = Convert.ToString(myReader["SubCta"]);
                            Nombre_Cliente = Convert.ToString(myReader["DetNom"]);
                            NIF_Cliente = Convert.ToString(myReader["DetNif"]);
                            Via_Cliente = Convert.ToString(myReader["detvia"]);
                            Municipio_Cliente = Convert.ToString(myReader["DetMun"]);
                            Provincia_Cliente = Convert.ToString(myReader["detpro"]);
                            CP_Cliente = Convert.ToString(myReader["DetCop"]);
                        }
                        myReader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    string blanco = " ";

                    //Añadimos al fichero de SUBCUENTAS los detallistas para pasar a Contaplus
                    string linea_subcuenta = "";

                    linea_subcuenta += subcuenta.PadRight(12, ' ');
                    linea_subcuenta += Nombre_Cliente.PadRight(40, ' ');
                    linea_subcuenta += NIF_Cliente.PadRight(15, ' ');
                    linea_subcuenta += Via_Cliente.PadRight(35, ' ');
                    linea_subcuenta += Municipio_Cliente.PadRight(25, ' ');
                    linea_subcuenta += Provincia_Cliente.PadRight(20, ' ');
                    linea_subcuenta += CP_Cliente.PadRight(5, ' ');
                    linea_subcuenta += "F" + blanco.PadRight(5, ' ') + "FF" + blanco.PadRight(34, ' ') + "F" + blanco.PadRight(12, ' ') + blanco.PadRight(259, ' ');

                    twSubcuentas.WriteLine(linea_subcuenta);

                    //ya tenemos los datos

                    string linea_det = "";
                    string linea_venta = "";
                    string linea_iva = "";

                    //asiento

                    linea_det += asiento.ToString().PadLeft(6, ' ');
                    linea_venta += asiento.ToString().PadLeft(6, ' ');
                    linea_iva += asiento.ToString().PadLeft(6, ' ');

                    //fecha

                    DateTime fecha_emision = new DateTime();
                    string fecha_formateada = "";

                    if (DateTime.TryParse(FechaEmision, out fecha_emision))
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
                    //string blanco = " ";
                    string num_factura = "FTRA. " + Factura + "-" + Serie;

                    if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
                    {
                        num_factura = "VENTA MERC. FRA. " + Factura + "-" + Serie;
                    }

                    string valor_IVA = "10.00";                         //el 10% de momento
                    string valor_RE = "1.40";                           //recargo del 1,40 (hay que usar dos decimales y el punto)
                    string nombre_cliente = Nombre_Cliente;            //si hubiera que cambiarlo por el DetNom, aquí está la variable. Ocupará máximo 40 caracteres                    
                    string NIF_Contrapartida = Regex.Replace(NIF_Cliente,"-", string.Empty);             //NIF de la contrapartida para IVA son 15 caracteres máximo       
                    string SerieFra = Serie;                            //Serie de la factura que en las propias siempre será la A y nos vemos limitados por un dígito que soporta el ContaPlus

                    linea_det += subcuenta.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                    linea_det += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                    linea_det += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_det += Importe.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ');
                    //linea_det += subcuenta.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                    //linea_det += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    //linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco + blanco + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    //linea_det += Importe.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    //linea_det += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    //linea_det += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                    //linea_det += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                    string insert = "INSERT INTO xDIARIO ( ASIEN,FECHA,SUBCTA,CONTRA,PTADEBE,CONCEPTO,PTAHABER,FACTURA,BASEIMPO,IVA,RECEQUIV,NCASADO,TCASADO,TRANS,CAMBIO,DEBEME,HABERME,SERIE,SUCURSAL,IMPAUXME,MONEDAUSO,EURODEBE,EUROHABER,BASEEURO,NOCONV,NUMEROINV)";
                    insert += " VALUES (";
                    insert += asiento.ToString() + ",";
                    insert += "'" + FechaEmision + "',";
                    insert += subcuenta.ToString() + ",";
                    insert += ",";                              //contrapartida
                    insert += "0,";                              //PtaDebe
                    insert += "'" + num_factura + "',";            //Concepto
                    insert += "0,";                              //PtaHaber
                    insert += Factura.ToString() + ",";           //Numero de Factura
                    insert += "0,";                              //BASEIMPO
                    insert += "0,";              //IVA
                    insert += "0,";               //RECARGO Equivalencia
                    insert += "0,";                              //NCASADO
                    insert += "0,";                              //TCASADO
                    insert += "0,";                              //TRANS
                    insert += "0,";                              //CAMBIO
                    insert += "0,";                              //DEBEME
                    insert += "0";                               //HABERME
                    insert += "'" + Serie + "',";                  //SERIE
                    insert += "0,";                              //IMPAUXME
                    insert += "'2',";                            //MONEDAUSO
                    insert += "" + Importe + ",";                  //EURODEBE
                    insert += "0,";                             //EUROHABER
                    insert += "0,";                             //BASEEURO
                    insert += "0,";                             //NOCONV
                    insert += "0,";                              //NUMEROINV
                    insert += ")";

                    //linea_venta

                    linea_venta += SubCtaVentas.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                    linea_venta += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_venta += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                    linea_venta += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_venta += cero_cero.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ');
                    
                    //grabar

                    tw.WriteLine(linea_det);
                    tw.WriteLine(linea_venta);

                    //comprobar si tiene recargo

                    if (RE1 == "0.00")
                    {
                        //no tiene recargo, 3 lineas
                        //no hay que hacer nada más
                        //linea_iva

                        linea_iva += SubCtaIVA.PadRight(12, ' ') + subcuenta.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                        linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                        linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                        linea_iva += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                        linea_iva += cero_cero.PadLeft(16, ' ') + IVA1.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ');
                        //grabar linea de IVA sin recargo
                        tw.WriteLine(linea_iva);
                    }
                    else
                    {
                        //tiene recargo, 4 lineas y la Subcuenta de IVA cambia entonces

                        linea_iva += SubCtaIVAconReq.PadRight(12, ' ') + subcuenta.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                        linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + valor_RE.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                        linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                        linea_iva += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                        linea_iva += cero_cero.PadLeft(16, ' ') + IVA1.PadLeft(16, ' ') + BI1.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ');

                        string linea_rec = asiento.ToString().PadLeft(6, ' ') + fecha_formateada;

                        linea_rec += SubCtaREQ.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                        linea_rec += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                        linea_rec += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                        linea_rec += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                        linea_rec += cero_cero.PadLeft(16, ' ') + RE1.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ');

                        tw.WriteLine(linea_iva);
                        tw.WriteLine(linea_rec);
                    }



                    //incrementamos asiento

                    asiento++;

                }
            }

            //cerrar el fichero

            tw.Close();
            twSubcuentas.Close();

            asiento = asiento - 1;

            MessageBox.Show("FICHEROS EXPORTADOS: \n\n" + fichero + " ( " + asiento + " asientos )\n" + ficheroSubcuentas);           

        }

        private void checkBox_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Cargar();
        }

        private void dataGridView_Facturado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

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
                    Calcula_Totales();
                }
            }
        }


        private void Calcula_Totales()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                int Col_Selecc = 8;
                decimal Total = 0;
                decimal TotalSel = 0;
                decimal TotalFila = 0;
                decimal BI = 0;
                decimal IVA = 0;

                foreach (DataGridViewRow Fila in dataGridView_Facturado.Rows)
                {
                    DataGridViewCheckBoxCell CelChk;
                    if ((dataGridView_Facturado.RowCount > 1) && (Fila.Index < dataGridView_Facturado.RowCount))
                    {
                        TotalFila = Convert.ToDecimal(Fila.Cells["Importe"].Value.ToString());
                        CelChk = Fila.Cells[Col_Selecc] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(CelChk.EditedFormattedValue) == false)
                        {
                            Total = Total + TotalFila;

                        }
                        else
                        {
                            Total = Total + TotalFila;
                            TotalSel = TotalSel + TotalFila;
                        }
                    }

                }
                //BI = (Total / 1.1);
                lTotal.Text = Total.ToString();
                lTotalSelecc.Text = TotalSel.ToString();
                lTotal_Sel.Text = TotalSel.ToString();
                BI = Math.Round(TotalSel / 1.1m, 2);
                IVA = TotalSel - BI;
                lBI_Sel.Text = BI.ToString();
                lIVA_Sel.Text = IVA.ToString();
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
            }

        }  //private void Calcula_Totales()

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;


            if (button1.Text == "Ninguno")
            {

                for (int i = 0; i < dataGridView_Facturado.Rows.Count; i++)
                {
                    dataGridView_Facturado.Rows[i].Cells[8].Value = false;
                }
                button1.Text = "Todos";
            }
            else
            {
                for (int i = 0; i < dataGridView_Facturado.Rows.Count; i++)
                {
                    dataGridView_Facturado.Rows[i].Cells[8].Value = true;
                }
                button1.Text = "Ninguno";
            }

            Calcula_Totales();



        }

        private void button_Exportar_ASCII_8000_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Click en EXPORTAR Facturas 8000s ");


            //Si no están todas las facturas seleccionadas no se ha de permitir exportar, ya que es un asiento resumen y hemos de poner la factura de Inicio y la Final

            bool selecTodas = true;
            string facturaInicio = "";
            string facturaFin = "";

            for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
            {
                if (dataGridView_Facturado.Rows[x].Cells[8].Value.ToString().ToLower() == "false")
                {
                    selecTodas = false;
                }

                if (x == 0)
                {
                    facturaInicio = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString() + "" + dataGridView_Facturado.Rows[x].Cells[0].Value.ToString();
                }

                if(x == dataGridView_Facturado.Rows.Count-1)
                {
                    facturaFin = dataGridView_Facturado.Rows[x].Cells[2].Value.ToString() + "" + dataGridView_Facturado.Rows[x].Cells[0].Value.ToString();
                }
            }

            if(!selecTodas)
            {
                MessageBox.Show("Para exportar el asiento resumen deben estar todas las facturas seleccionadas");
            }
            else
            {
                int asiento = 1;

                string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\FACTURAS_8000s_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";

                TextWriter tw = new StreamWriter(fichero);

                string BImponible = "";
                string IVA = "";
                string REq = "";
                string Total = "";    
               
                BImponible = Funciones.Formatea(lBI_Sel.Text).Replace(',', '.');
                IVA = Funciones.Formatea(lIVA_Sel.Text).Replace(',', '.');
                REq = "0.00"; //Las facturas de los 8000 no tienen recargo
                Total = Funciones.Formatea(lTotal_Sel.Text).Replace(',', '.');              

                string Factura = "";               

                //string DetCod = tDetCod_Inicio.Text;

                string Nombre_Mayorista = "";
                string NIF_Mayorista = "";
                string subcuentaMayorista = "430008000";

                //string select_subcuenta = "select SubCuenta,DetNIF,DetNom FROM DETALLISTAS WHERE DetCod=" + DetCod;

                string select_subcuenta = "select ConNom, connif FROM CONTROL";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(select_subcuenta, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Nombre_Mayorista = myReader["ConNom"].ToString();
                        NIF_Mayorista = Regex.Replace(myReader["connif"].ToString(), "-", string.Empty);
                        //subcuentaMayorista = myReader["SubCuenta"].ToString();
                    }
                    myReader.Close();
                    myCommand.Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //ya tenemos los datos


                string linea_det = "";
                string linea_venta = "";
                string linea_iva = "";

                //asiento

                linea_det += asiento.ToString().PadLeft(6, ' ');
                linea_venta += asiento.ToString().PadLeft(6, ' ');
                linea_iva += asiento.ToString().PadLeft(6, ' ');

                //fecha

                DateTime fecha_emision = new DateTime();
                string fecha_formateada = "";
                string fecha_dd_mm_yy = "";
                string FechaEmision = dateTimePicker_Inicio.Text;

                if (DateTime.TryParse(FechaEmision, out fecha_emision))
                {
                    fecha_formateada = fecha_emision.Year.ToString() + fecha_emision.Month.ToString().PadLeft(2, '0') + fecha_emision.Day.ToString().PadLeft(2, '0');
                    fecha_dd_mm_yy = fecha_emision.Day.ToString().PadLeft(2, '0') + fecha_emision.Month.ToString().PadLeft(2, '0');
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
                string num_factura = "Resu. Fras Simp. " + fecha_dd_mm_yy;
                string valor_IVA = "10.00";                         //el 10% de momento
                string valor_RE = "1.40";                           //recargo del 1,40 (hay que usar dos decimales y el punto)
                //string nombre_cliente = Nombre_Cliente;            //si hubiera que cambiarlo por el DetNom, aquí está la variable. Ocupará máximo 40 caracteres
                //string NIF_Contrapartida = NIF_Mayorista;             //NIF de la contrapartida para IVA son 15 caracteres máximo       
                string SerieFra = "A";                            //Serie de la factura que en las propias siempre será la A y nos vemos limitados por un dígito que soporta el ContaPlus

                linea_det += subcuentaMayorista.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ');
                linea_det += num_factura.PadRight(25, ' ');          //campo 6  Concepto del asiento               
                linea_det += cero_cero.PadLeft(16, ' ');
                linea_det += cero.PadLeft(8, ' ');
                linea_det += cero_cero.PadLeft(16, ' ');                //campo 9. Base Imponible del IVA en pesetas
                linea_det += cero_cero.PadLeft(5, ' ');
                linea_det += cero_cero.PadLeft(5, ' ');
                linea_det += blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_det += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                linea_det += SerieFra;                          // Campo23 .Serie de la factura
                linea_det += blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ');
                linea_det += "2";                               //Campo 27   1.- Ptas.; 2.- Euros
                linea_det += Total.PadLeft(16, ' ');            //Campo 28  Importe al debe en euros
                linea_det += cero_cero.PadLeft(16, ' ');        //Campo29. Importe al haber en euros
                linea_det += cero_cero.PadLeft(16, ' ');        //Campo 30. BI del IVA en euros
                linea_det += "F" + blanco.PadLeft(10, ' ');
                linea_det += blanco;                            //Campo 33 Serie de factura rectificada
                linea_det += cero.PadLeft(8, ' ');              //Campo 34 /Numero de Factura rectificada
                linea_det += cero_cero.PadLeft(16, ' ');        //Campo 35 Base Imponible de factura rectificada
                linea_det += cero_cero.PadLeft(16, ' ');        //Campo36  Base Imponible de Factura rectificativa
                linea_det += "F";                               //Campo 37  (.T.) En caso de factura rectificativa
                linea_det += blanco.PadLeft(8, ' ');            //Campo 38 . Fecha Factura rectificada
                linea_det += "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_det += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_det += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_det += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                
                //linea_venta

                linea_venta += SubCtaVentas.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                linea_venta += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                linea_venta += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                linea_venta += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                linea_venta += cero_cero.PadLeft(16, ' ') + BImponible.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                linea_venta += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                linea_venta += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                linea_venta += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                
                //grabar

                tw.WriteLine(linea_det);
                tw.WriteLine(linea_venta);

                //comprobar si tiene recargo

                if (REq == "0.00")
                {
                    //no tiene recargo, 3 lineas
                    //no hay que hacer nada más
                    //linea_iva

                    linea_iva += SubCtaIVA.PadRight(12, ' ') + subcuentaMayorista.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                    linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                    linea_iva += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_iva += cero_cero.PadLeft(16, ' ') + IVA.PadLeft(16, ' ') + BImponible.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_iva += blanco.PadLeft(8, ' ') + fecha_formateada + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_iva += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + facturaInicio.PadRight(40, ' ') + facturaFin.PadRight(40, ' ') + "1" + NIF_Mayorista.PadRight(15, ' ') + Nombre_Mayorista.PadRight(40, ' ');
                    linea_iva += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                        EG                                        T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";
                    //grabar linea de IVA sin recargo
                    tw.WriteLine(linea_iva);
                }
                else
                {
                    //tiene recargo, 4 lineas y la Subcuenta de IVA cambia entonces

                    linea_iva += SubCtaIVAconReq.PadRight(12, ' ');
                    linea_iva += subcuentaMayorista.PadRight(12, ' ') + cero_cero.PadLeft(16, ' ') + num_factura.PadRight(25, ' ');
                    linea_iva += cero_cero.PadLeft(16, ' ') + Factura.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + valor_IVA.PadLeft(5, ' ') + valor_RE.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_iva += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                    linea_iva += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";

                    linea_iva += cero_cero.PadLeft(16, ' ') + IVA.PadLeft(16, ' ') + BImponible.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_iva += blanco.PadLeft(8, ' ') + fecha_formateada + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_iva += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + facturaInicio.PadRight(40, ' ') + facturaFin.PadRight(40, ' ') + "1" + NIF_Mayorista.PadRight(15, ' ') + Nombre_Mayorista.PadRight(40, ' ');
                    linea_iva += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                        EG                                        T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                    string linea_rec = asiento.ToString().PadLeft(6, ' ') + fecha_formateada;

                    linea_rec += SubCtaREQ.PadRight(12, ' ') + cero_cero.PadLeft(28, ' ') + num_factura.PadRight(25, ' ');
                    linea_rec += cero_cero.PadLeft(16, ' ') + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + blanco.PadLeft(3, ' ') + blanco.PadLeft(6, ' ') + blanco;
                    linea_rec += cero.PadLeft(6, ' ') + cero + cero.PadLeft(6, ' ') + cero_seis.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + blanco;
                    linea_rec += SerieFra + blanco.PadLeft(4, ' ') + blanco.PadLeft(5, ' ') + cero_cero.PadLeft(16, ' ') + "2";
                    linea_rec += cero_cero.PadLeft(16, ' ') + REq.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(10, ' ') + blanco + cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
                    linea_rec += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
                    linea_rec += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
                    linea_rec += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

                    tw.WriteLine(linea_iva);
                    tw.WriteLine(linea_rec);
                }



                //incrementamos asiento

                asiento++;




                //cerrar el fichero

                tw.Close();
                asiento = asiento - 1;
                MessageBox.Show("FICHERO EXPORTADO a " + fichero + ".     " + asiento + " asientos");



            }           
           




        }  //   private void button_Exportar_ASCII_8000_Click(object sender, EventArgs e)


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
            } //switch(frmPpal.USUARIO )
            switch (Tipo)
            {
                case "8000_Resumen":
                    button_Exportar_ASCII_8000.Visible = true;
                    button_Exportar_ASCII.Visible = false;
                    button_Exportar_xBase.Visible = false;
                    tDetCod_Inicio.Text = "8000";
                    panel7.Visible = true;
                    break;
                default:
                    button_Exportar_ASCII.Visible = true;
                    break;
            }
        }//private void Seguridad

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        } //  private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)

        private void dateTimePicker_Fin_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void xBase()
        {
            string sBase = "C:\\OREMAPE\\XDIARIO.dbf";
            string sSelect = "SELECT * FROM  XDIARIO";
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
                    //button5.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                    GloblaVar.gUTIL.ATraza(ex.Message);
                    return;
                }
            }
        }

       
    }
}
