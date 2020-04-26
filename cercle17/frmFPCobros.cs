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
    public partial class frmFPCobros : Form
    {
        public frmFPCobros()
        {
            InitializeComponent();
        }


        public SqlConnection CnO;
        public clase_cabecera_factura factura;
        public string DetCod, importe_cobrado, subserie;
        public bool COBRO_AGRUPADO;
        public ArrayList Lista_Facturas;


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
                MessageBox.Show(NonQuery + "\r\n" + ex.ToString());
            }

            return res;
        }

        private void Carga_Pagares()
        {
            //rellenar el grid con los pagarés que tenga el detallista

            if (CnO != null)
            {

                ArrayList Lista_Pagares = new ArrayList();
                string select = "SELECT * FROM PAGARES WHERE Cobrado='N' and DetCod=" + DetCod + " ORDER BY FVencto, IdPagare";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(select, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_pagare pagare = new clase_pagare();
                        
                        pagare.IdPagare = myReader["IdPagare"].ToString();
                        pagare.Detallista = myReader["DetCod"].ToString();
                        pagare.Fecha = myReader["Fecha"].ToString(); if (pagare.Fecha.Contains(' ')) { pagare.Fecha = pagare.Fecha.Substring(0, pagare.Fecha.IndexOf(' ')); }
                        pagare.Vencimiento = myReader["FVencto"].ToString(); if (pagare.Vencimiento.Contains(' ')) { pagare.Vencimiento = pagare.Vencimiento.Substring(0, pagare.Vencimiento.IndexOf(' ')); }
                        pagare.Cobrado = myReader["Cobrado"].ToString();
                        pagare.Importe = Funciones.Formatea(myReader["Importe"].ToString());
                        pagare.Observaciones = myReader["Observaciones"].ToString();

                        Lista_Pagares.Add(pagare);

                    }
                    myReader.Close();

                    gPagares.DataSource = Lista_Pagares;

                    if (gPagares.Rows.Count > 0)
                    {
                        //si hay rows les daremos formato, ocultando unas y ajustando anchura de otras

                        gPagares.Columns[0].Visible = false;
                        gPagares.Columns[1].Visible = false;
                        gPagares.Columns[2].Visible = false;
                        gPagares.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        gPagares.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        gPagares.Columns[5].Visible = false;
                        gPagares.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        gPagares.Columns[7].Visible = false;
                        gPagares.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        gPagares.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Cargar_Datos()
        {
            //leemos los datos de la cabecera de factura y los escribimos en el formulario (detallista, importe...)
            //para filtrar facturas hay que poner el Where tanto el número de factura como la serie y el año

            string strQ = "SELECT * FROM FACTV_CABE WHERE Factura=" + factura.Factura + " AND Anyo=" + factura.Anyo + " AND Serie='" + factura.Serie + "'";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    DetCod = myReader["DetCod"].ToString();
                    textBox_ImpteFactura.Text = Funciones.Formatea(myReader["ImpteFactura"].ToString());
                    textBox_ImptePendiente.Text = Funciones.Formatea(myReader["ImptePendiente"].ToString());
                    importe_cobrado = Funciones.Formatea(myReader["ImpteCobrado"].ToString());
                    subserie = myReader["SubSerie"].ToString();
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar_Listado_Facturas()
        {
            textBox_ImpteFactura.Text = "0,00";
            textBox_ImptePendiente.Text = "0,00";

            for (int x = 0; x < Lista_Facturas.Count; x++)
            {
                clase_cabecera_factura esta_factura = (clase_cabecera_factura)Lista_Facturas[x];

                string strQ = "SELECT * FROM FACTV_CABE WHERE Factura=" + esta_factura.Factura + " AND Anyo=" + esta_factura.Anyo + " AND Serie='" + esta_factura.Serie + "'";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //se supone que todos tienen el mismo detcod, aquí se almacenará el último valor
                        DetCod = myReader["DetCod"].ToString();
                        subserie = myReader["SubSerie"].ToString();

                        //sumar datos de cada factura

                        textBox_ImpteFactura.Text = Funciones.Suma(textBox_ImpteFactura.Text, Funciones.Formatea(myReader["ImpteFactura"].ToString()));
                        textBox_ImptePendiente.Text = Funciones.Suma(textBox_ImptePendiente.Text, Funciones.Formatea(myReader["ImptePendiente"].ToString()));
                        importe_cobrado = Funciones.Suma(importe_cobrado, Funciones.Formatea(myReader["ImpteCobrado"].ToString()));
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void frmFPCobros_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            DetCod = "0"; importe_cobrado = "0,00"; subserie = "";

            textBox_Transferencia.Text = "0,00";
            textBox_Talon.Text = "0,00";
            textBox_Tarjeta.Text = "0,00";
            textBox_Pagare.Text = "0,00";

            if (COBRO_AGRUPADO == true)
            {
                Cargar_Listado_Facturas();

                //si es agrupado se carga el valor en talón y se impide cobrar en efectivo
                //button_Nuevo_Pagare.Enabled = false;
                //gPagares.Enabled = false;
                //textBox_Tarjeta.Enabled = false;
                //textBox_Obs_Tarjeta.Enabled = false;
                //textBox_Transferencia.Enabled = false;
                //textBox_Obs_Transferencia.Enabled = false;
                textBox_Efectivo.Enabled = false;
                textBox_Efectivo.Text = "0,00";
                textBox_Talon.Text = textBox_ImptePendiente.Text;
                textBox_Observaciones.Text = "COBRO AGRUPADO";
                textBox_Observaciones.ReadOnly = true;
            }
            else
            {

                //lectura de datos
                Cargar_Datos();

                //haremos que el importe pendiente se escriba por defecto en Efectivo, para ahorrar tiempo al usuario, ya que la mayoría de cobros son así

                textBox_Efectivo.Text = textBox_ImptePendiente.Text;

                //el resto a 0,00
            }

            //se supone que ya hemos cargado DetCod y podemos cargar pagarés
            Carga_Pagares();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
        }

        private void Totalizar()
        {
            //se calculan los importes
            string total = Funciones.Resta(textBox_ImpteFactura.Text, importe_cobrado);
            decimal auxiliar = 0;

            //se van restando las cifras que el usuario haya puesto en las casillas

            if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Efectivo.Text);
            }

            if (Decimal.TryParse(textBox_Transferencia.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Transferencia.Text);
            }

            if (Decimal.TryParse(textBox_Talon.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Talon.Text);
            }

            if (Decimal.TryParse(textBox_Tarjeta.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Tarjeta.Text);
            }

            //lectura de Pagarés marcados
            textBox_Pagare.Text = "0,00";

            for (int x = 0; x < gPagares.Rows.Count; x++)
            {
                if (gPagares.Rows[x].Cells[8].EditedFormattedValue.ToString().ToLower() == "true")
                {
                    string importe_pagare = gPagares.Rows[x].Cells[6].Value.ToString();

                    textBox_Pagare.Text = Funciones.Suma(textBox_Pagare.Text, importe_pagare);
                }
            }

            if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Pagare.Text);
            }

            textBox_ImptePendiente.Text = total; 
            
            //si el total es negativo se advertirá coloreando en rojo
            
            if (total.StartsWith("-")) { textBox_ImptePendiente.BackColor = Color.Red; } else { textBox_ImptePendiente.BackColor = Color.LightGray; }
        }

        private string Nuevo_Cobro()
        {
            //esta función devuelve el identificador del nuevo cobro, lee el máximo actual y le suma 1

            string resultado = "0";

            string consulta = "SELECT MAX(IdCobroFact) FROM FACTV_COBROS";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int auxiliar = 0;
                    string idcobro = myReader[0].ToString();
                    if (System.Int32.TryParse(idcobro, out auxiliar) == true)
                    {
                        auxiliar++;
                        resultado = auxiliar.ToString();
                    }
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private string Recortar(string uno, string dos)
        {
            //si 'uno' es 0 se devuelve 0
            //si 'uno' es más que 'dos', se devuelve 'dos'

            string resultado = uno;

            decimal primero = 0;
            decimal segundo = 0;
            uno = uno.Replace('.', ',');
            dos = dos.Replace('.', ',');
            Decimal.TryParse(uno, out primero);
            Decimal.TryParse(dos, out segundo);

            if (primero > segundo)
            {
                resultado = dos;
            }

            return resultado.Replace(',', '.');
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            //escribir los cambios
            if (factura != null || Lista_Facturas != null)
            {
                //comprobar si el resultado es negativo, y en ese caso impedir el cobro

                if (textBox_ImptePendiente.Text.StartsWith("-") == true)
                {
                    MessageBox.Show("No puede efectuarse el cobro por excederse la cantidad del importe");
                }
                else
                {
                    bool adelante = true;

                    if (COBRO_AGRUPADO == false)
                    {
                        //si no estamos haciendo un cobro agrupado, crearemos uno que tenga solo una entrada de factura
                        Lista_Facturas = new ArrayList();
                        Lista_Facturas.Add(factura);
                    }
                    else
                    {
                        //comprobar que se están cobrando las facturas completas, de lo contrario no seguiremos
                        if (textBox_ImptePendiente.Text != "0,00")
                        {
                            adelante = false;
                            MessageBox.Show("No se puede hacer un cobro agrupado si queda importe pendiente");
                        }
                    }

                    //Cobro del albarán
                    string idCobro = "";
                    string fechaCobro = DateTime.Today.ToShortDateString();
                    bool generadoVenAlbCobro = false;

                    if (adelante == true)
                    {
                        for (int n = 0; n < Lista_Facturas.Count; n++)
                        {
                            factura = (clase_cabecera_factura)Lista_Facturas[n];

                            string IdCobroFact = Nuevo_Cobro();

                            string efectivo_money = "0";
                            string transferencia_money = "0";
                            string tarjeta_money = "0";
                            string talon_money = "0";
                            string pagare_money = "0";
                            string cobrado = importe_cobrado;
                            string importeVenAlbCobro = "0";

                            //para cobros agrupados
                            // Abel. lo comento para que no de error--> string importe_agrupado = "0";

                            //texto efectivo
                            if (textBox_Efectivo.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
                                {
                                    //if (auxiliar > 0) //comentamos este if para permitir que se cobren abonos (efectivo en negativo)
                                    //{
                                    efectivo_money = Funciones.Formatea(textBox_Efectivo.Text).Replace(",", ".");
                                    cobrado = Funciones.Suma(cobrado, efectivo_money);
                                    importeVenAlbCobro = Funciones.Suma(importeVenAlbCobro, efectivo_money);
                                    //}
                                }
                            }

                            //generar transferencia
                            if (textBox_Transferencia.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_Transferencia.Text, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        transferencia_money = Funciones.Formatea(textBox_Transferencia.Text).Replace(",", ".");
                                        cobrado = Funciones.Suma(cobrado, transferencia_money);
                                        importeVenAlbCobro = Funciones.Suma(importeVenAlbCobro, transferencia_money);

                                        if (n == 0) //solo entrará una vez
                                        {
                                            string observaciones = textBox_Obs_Transferencia.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                                            string insert_transfer = "INSERT INTO TRANSFERENCIAS(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobroFact) ";
                                            insert_transfer += " VALUES(" + DetCod + ", '" + DateTime.Today.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + transferencia_money + ", '" + observaciones + "', " + IdCobroFact + ")";

                                            int res = EjecutaNonQuery(insert_transfer);
                                        }
                                    }
                                }
                            }

                            //generar talones
                            if (textBox_Talon.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_Talon.Text, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        talon_money = Funciones.Formatea(textBox_Talon.Text).Replace(",", ".");
                                        cobrado = Funciones.Suma(cobrado, talon_money);
                                        importeVenAlbCobro = Funciones.Suma(importeVenAlbCobro, talon_money);

                                        if (n == 0) //solo entrará una vez
                                        {
                                            string observaciones = textBox_Obs_Talon.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                                            string insert_talon = "INSERT INTO TALONES(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobroFact) ";
                                            insert_talon += " VALUES(" + DetCod + ", '" + dateTimePicker1.Value.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + talon_money + ", '" + observaciones + "', " + IdCobroFact + ")";

                                            int res = EjecutaNonQuery(insert_talon);
                                        }
                                    }
                                }
                            }

                            //generar pago tarjeta
                            if (textBox_Tarjeta.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_Tarjeta.Text, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        tarjeta_money = Funciones.Formatea(textBox_Tarjeta.Text).Replace(",", ".");
                                        cobrado = Funciones.Suma(cobrado, tarjeta_money);
                                        importeVenAlbCobro = Funciones.Suma(importeVenAlbCobro, tarjeta_money);

                                        if (n == 0) //solo entrará una vez
                                        {
                                            string observaciones = textBox_Obs_Tarjeta.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                                            string insert_tarjeta = "INSERT INTO CREDIT_CARDS(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobroFact) ";
                                            insert_tarjeta += " VALUES(" + DetCod + ", '" + DateTime.Today.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + tarjeta_money + ", '" + observaciones + "', " + IdCobroFact + ")";

                                            int res = EjecutaNonQuery(insert_tarjeta);
                                        }
                                    }
                                }
                            }

                            //cobrar pagarés
                            if (textBox_Pagare.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        if (n == 0) //solo entrará una vez
                                        {
                                            for (int x = 0; x < gPagares.Rows.Count; x++)
                                            {
                                                if (gPagares.Rows[x].Cells[8].EditedFormattedValue.ToString().ToLower() == "true")
                                                {
                                                    string idpagare = gPagares.Rows[x].Cells[0].Value.ToString();
                                                    string importe_pagare = gPagares.Rows[x].Cells[6].Value.ToString();
                                                    string observaciones = gPagares.Rows[x].Cells[9].Value.ToString();
                                                    string vencimiento = gPagares.Rows[x].Cells[4].Value.ToString();

                                                    string update_pagare = "UPDATE PAGARES SET Cobrado='S', FechaCobro='" + DateTime.Today.ToShortDateString() + "', IdCobroFact=" + IdCobroFact;
                                                    update_pagare += "  WHERE IdPagare=" + idpagare;

                                                    int res = EjecutaNonQuery(update_pagare);
                                                }
                                            }
                                        }

                                        pagare_money = Funciones.Formatea(textBox_Pagare.Text).Replace(",", ".");
                                        cobrado = Funciones.Suma(cobrado, pagare_money);
                                        importeVenAlbCobro = Funciones.Suma(importeVenAlbCobro, pagare_money);

                                    }
                                }
                            }

                            string observaciones_cobro = textBox_Observaciones.Text.Replace("'", "''"); if (observaciones_cobro.Length > 99) { observaciones_cobro = observaciones_cobro.Substring(0, 99); }

                            //controlar importes en caso de cobro agrupado
                            if (COBRO_AGRUPADO == true)
                            {
                                talon_money = Recortar(talon_money, factura.Importe);
                                pagare_money = Recortar(pagare_money, factura.Importe);
                                tarjeta_money = Recortar(tarjeta_money, factura.Importe);
                                transferencia_money = Recortar(transferencia_money, factura.Importe);
                                cobrado = Recortar(cobrado, factura.Importe);
                            }

                            //crear la sentencia INSERT

                            string insert = "INSERT INTO FACTV_COBROS(IdCobroFact, Factura, Anyo, Serie, SubSerie, Fecha, Efectivo, Talon, Pagare, Tarjeta, Transferencia, Observaciones, Cobrado) ";
                            insert += " VALUES(" + IdCobroFact + ", " + factura.Factura + ", " + factura.Anyo + ", '" + factura.Serie + "', '" + subserie + "', '" + DateTime.Today.ToShortDateString() + "', " + efectivo_money + ", " + talon_money + ", " + pagare_money + ", " + tarjeta_money + ", " + transferencia_money + ", '" + observaciones_cobro + "', 0) ";

                            int res_cobro = EjecutaNonQuery(insert);

                            if (res_cobro == 1)
                            {
                                //cobro insertado con éxito, se actualiza factura

                                string update = "UPDATE FACTV_CABE SET ImpteCobrado=" + cobrado.Replace(",", ".") + ", ImptePendiente=" + textBox_ImptePendiente.Text.Replace(",", ".") + ", FechaCobro='" + DateTime.Today.ToShortDateString() + "' WHERE  Factura=" + factura.Factura + " AND Anyo=" + factura.Anyo + " AND Serie='" + factura.Serie + "'";

                                int res_update = EjecutaNonQuery(update);

                                switch (frmPpal.USUARIO)
                                {
                                    case "1":
                                        string update_VenTve = "UPDATE VENALB_CABE SET VenTve=4 WHERE VenTve=1 AND VenNfp=" + factura.Factura + " AND AnyoFra=" + factura.Anyo + " AND SerieFra='" + factura.Serie + "'";
                                        int res_ventve = EjecutaNonQuery(update_VenTve);

                                        break;

                                    case "5": //DIALPESCA
                                        //Al cobrar una factura completa creamos el cobro en VENALB_COBRO y ponemos el IdCobro y FechaCobro 
                                        //en todos los albaranes de esa factura donde IdCobro=null y FechaCobro=null
                                        if (textBox_ImptePendiente.Text == "0,00")
                                        { 
                                            if(!generadoVenAlbCobro)
                                            {
                                                idCobro = Funciones.Nuevo_Cobro_Albaran(CnO);

                                                string insertVenalbCobros = @"INSERT INTO VENALB_COBROS(IdCobro, DetCod, Cantidad, IdVendedor, IdTipoCobro, Fecha, Efectivo, Tarjeta, Talon, Pagare, Transferencia, Deuda)";
                                                insertVenalbCobros += " VALUES (" + idCobro + ", " + DetCod + ", " + importeVenAlbCobro.Replace(",", ".") + ", " + GloblaVar.gIdVendedor.ToString() + ",";
                                                insertVenalbCobros += GloblaVar.gIdTipoCobro.ToString() + ", '" + fechaCobro + "', " + efectivo_money + ", " + tarjeta_money + ", " + talon_money + ", " + pagare_money + ", " + transferencia_money + ", 0.00)";

                                                int resVenalbCobros = Funciones.EjecutaNonQuery(insertVenalbCobros, CnO);

                                                generadoVenAlbCobro = true;

                                            }   
                                            
                                            //Modificamos IdCobro y FechaCobro de todos los albaranes de esa factura donde IdCobro=null y FechaCobro=null
                                            string updateVenalbCabe = @"UPDATE VENALB_CABE SET IdCobro=" + idCobro + ", FechaCobro='" + fechaCobro + "' WHERE VenNfp=" + factura.Factura + " AND AnyoFra=" + factura.Anyo + " AND SerieFra='" + factura.Serie + "' AND IdCobro is null";

                                            int resVenalbCabe = Funciones.EjecutaNonQuery(updateVenalbCabe, CnO);

                                        }

                                        break;

                                    case "8": //VALPEIX
                                        //Al cobrar una factura completa creamos el cobro en VENALB_COBRO y ponemos el IdCobro y FechaCobro 
                                        //en todos los albaranes de esa factura donde IdCobro=null y FechaCobro=null
                                        if (textBox_ImptePendiente.Text == "0,00")
                                        {
                                            if (!generadoVenAlbCobro)
                                            {
                                                idCobro = Funciones.Nuevo_Cobro_Albaran(CnO);

                                                string insertVenalbCobros = @"INSERT INTO VENALB_COBROS(IdCobro, DetCod, Cantidad, IdVendedor, IdTipoCobro, Fecha, Efectivo, Tarjeta, Talon, Pagare, Transferencia, Deuda)";
                                                insertVenalbCobros += " VALUES (" + idCobro + ", " + DetCod + ", " + importeVenAlbCobro.Replace(",", ".") + ", " + GloblaVar.gIdVendedor.ToString() + ",";
                                                insertVenalbCobros += GloblaVar.gIdTipoCobro.ToString() + ", '" + fechaCobro + "', " + efectivo_money + ", " + tarjeta_money + ", " + talon_money + ", " + pagare_money + ", " + transferencia_money + ", 0.00)";

                                                int resVenalbCobros = Funciones.EjecutaNonQuery(insertVenalbCobros, CnO);

                                                generadoVenAlbCobro = true;

                                            }

                                            //Modificamos IdCobro y FechaCobro de todos los albaranes de esa factura donde IdCobro=null y FechaCobro=null
                                            string updateVenalbCabe = @"UPDATE VENALB_CABE SET IdCobro=" + idCobro + ", FechaCobro='" + fechaCobro + "' WHERE VenNfp=" + factura.Factura + " AND AnyoFra=" + factura.Anyo + " AND SerieFra='" + factura.Serie + "' AND IdCobro is null";

                                            int resVenalbCabe = Funciones.EjecutaNonQuery(updateVenalbCabe, CnO);

                                        }

                                        break;

                                    default:
                                        break;
                                }

                                MessageBox.Show("Cobro realizado");
                            }
                            else
                            {
                                MessageBox.Show("Hubo un problema en base de datos al cobrar la factura");
                            }
                        }//for recorre ListaFacturas
                    }

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //el temporizador hace que se recalculen las cifras según la función Totalizar

            Totalizar();
        }

        private void button_Nuevo_Pagare_Click(object sender, EventArgs e)
        {
            //abrir nuevo pagaré

            frmNuevoPagare NuevoPagare = new frmNuevoPagare();
            NuevoPagare.codcliente = DetCod;
            NuevoPagare.adosado = false;
            NuevoPagare.myConnection = CnO;

            if (NuevoPagare.ShowDialog() == DialogResult.OK)
            {
                //creación del nuevo pagaré
                if (NuevoPagare.codcliente != "")
                {
                    if (NuevoPagare.cliente_valido == true)
                    {
                        if (NuevoPagare.importe_pagare != "")
                        {
                            if (NuevoPagare.fecha_vto != "")
                            {
                                //insert
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(NuevoPagare.importe_pagare, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        string observaciones = NuevoPagare.observaciones.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                                        string insert_pagare = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones) ";
                                        insert_pagare += " VALUES(" + NuevoPagare.codcliente + ", '" + DateTime.Today.ToShortDateString() + "', '" + NuevoPagare.fecha_vto.Replace("'", "''") + "', " + NuevoPagare.importe_pagare.Replace(",", ".") + ", '" + observaciones + "')";

                                        int res = EjecutaNonQuery(insert_pagare);

                                        if (res == 1)
                                        {
                                            MessageBox.Show("El nuevo pagaré se ha grabado con éxito");
                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se ha dado fecha de vencimiento");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha dado importe de pagaré");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente no es válido");
                    }
                }

                //recarga
                Carga_Pagares();
            }
        }
    }
}
