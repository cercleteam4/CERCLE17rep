using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmCobros : Form
    {
        public frmCobros()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public bool mensajes, Filtrado;
        private string IVA, RECARGO;
        public string IdVendedor;

        private void Mostrar(string texto)
        {
            if (mensajes)
            {
                MessageBox.Show(texto);
            }
        }
        
        private void Leer_IVA()
        {
            DateTime fecha_texto = new DateTime(2000, 1, 1);
            if (DateTime.TryParse(textBox_Fecha.Text, out fecha_texto) == true)
            {
                //lectura de IVA y Recargo
                DateTime fecha_bd = new DateTime(2000, 1, 1);
                string consulta_IVA = "SELECT Fecha, IVA, Recargo FROM TIPOS_IVA order by Fecha";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta_IVA,myConnection );
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        string fecha = myReader["Fecha"].ToString();

                        if (DateTime.TryParse(fecha, out fecha_bd) == true)
                        {
                            if (fecha_texto.CompareTo(fecha_bd) >= 0)
                            {
                                IVA = myReader["IVA"].ToString();
                                RECARGO = myReader["Recargo"].ToString(); if (label_Recargo.Text != "") { label_Recargo.Text = RECARGO; }
                            }
                        }
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void Avisa_Pagares()
        {
            if (GloblaVar.gConRem  != null)
            {
                bool existen = false;

                string select = "Select * From Pagares WHERE FVencto='" + textBox_Fecha.Text + "'";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(select,myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        existen = true;
                    }
                    myReader.Close();

                    if (existen == true)
                    {
                        MessageBox.Show("Existen pagarés que vencen en la fecha actual: " + textBox_Fecha.Text);
                    }

                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------------------ENTRANDO A " + this.GetType().FullName);

            textBox_Fecha.Text = DateTime.Today.ToShortDateString();
            label_Cliente.Visible = false;
            //textBox_Recargo.Text = "0,00";
            RECARGO = "0";
            IVA = "0";
            Leer_IVA();
            //preparar el filtro para el mes actual
            dateTimePicker_Inicio.Text = "01/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            dateTimePicker_Final.Text = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            Filtrado = false;
            label_Recargo.ForeColor = panel1.BackColor;

            //comprobar pagarés vencimiento
            Avisa_Pagares();
            Seguridad();
            textBox_CodCliente.Focus();
        }

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1": //llorens

                    break;
                case "2":  //Carabal
                    break;
                case "3":       //ENDUMAR
                    //button_Compras_Entradas.Visible = true;
                    //button_Compras_Entradas.Text = "Entrada Compras ENDUMAR";
                    break;
                case "5": //Dialpesca
                    break;
                case "6":  //ABT
                    break;
                case "8": //VALPEIX
                    break;
            }
        } //private void Seguridad()

        private void Carga_Albaranes()
        {
            string consulta = "SELECT * FROM VENALB_CABE WHERE DetCod=" + textBox_CodCliente.Text + " and IdCobro IS NULL and (Anulado <> 1) and VenTve IN (1,3,4) order by Anyo, VenFec";
            ArrayList Albaranes = new ArrayList();
            string total = "0";

            if (textBox_CodCliente.Text.Contains("**") == true)
            {
                consulta = "SELECT * FROM VENALB_CABE WHERE DetCod=" + textBox_CodCliente.Text.Replace("**", "") + " and IdCobro IS NULL and (Anulado <> 1) and VenTve=51 order by Anyo, VenFec";
            }


            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta,myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_venalb venalb = new clase_venalb();
                    venalb.Anyo = myReader["Anyo"].ToString();
                    venalb.Nuevo = myReader["DetNuevo"].ToString();
                    venalb.Albaran = myReader["VenAlb"].ToString();
                    venalb.Fecha = myReader["VenFec"].ToString(); if (venalb.Fecha.Contains(' ')) { venalb.Fecha = venalb.Fecha.Substring(0, venalb.Fecha.IndexOf(' ')); }
                    venalb.Total = Funciones.Formatea(myReader["VenTot"].ToString());
                    venalb.TipoVenta = myReader["VenTve"].ToString();
                    venalb.Cobrar = false;
                    venalb.Pagare = myReader["IdPagare"].ToString();

                    bool agregar = true;
#if !DEBUG
                    //tipo venta
                    if (venalb.TipoVenta == "1")
                    {
                        if (venalb.Fecha != DateTime.Today.ToShortDateString())
                        {
                            agregar = false;
                        }
                    }
#endif
                    if (Filtrado == true)
                    {
                        //comprobar fecha
                        DateTime fecha_albaran = new DateTime(2000, 1, 1);
                        if (DateTime.TryParse(venalb.Fecha, out fecha_albaran) == true)
                        {
                            if (fecha_albaran.CompareTo(dateTimePicker_Final.Value) > 0) { agregar = false; }
                            if (fecha_albaran.CompareTo(dateTimePicker_Inicio.Value) < 0) { agregar = false; }
                        }
                    }

                    if (agregar == true)
                    {
                        if (venalb.Pagare == "")
                        {
                            total = Funciones.Suma(total, venalb.Total);
                        }
                        Albaranes.Add(venalb);
                    }

                }
                myReader.Close();

                gAlbV.DataSource = Albaranes;

                if (gAlbV.Rows.Count > 0)
                {

                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new Font("Arial", 11, FontStyle.Regular);

                    foreach (DataGridViewRow row in gAlbV.Rows)
                    {
                        style.BackColor = Color.White;

                        if (row.Cells[7].Value.ToString() != "")
                        {
                            style.BackColor = this.BackColor;
                        }

                        foreach (DataGridViewCell cell in row.Cells)
                            cell.Style.ApplyStyle(style);
                    }

                    gAlbV.Columns[0].Visible = false;
                    gAlbV.Columns[1].ReadOnly = true; gAlbV.Columns[1].Width = 170;
                    gAlbV.Columns[2].ReadOnly = true; gAlbV.Columns[2].Width = 75;
                    gAlbV.Columns[3].ReadOnly = true; gAlbV.Columns[3].Width = 90;
                    gAlbV.Columns[4].ReadOnly = true; gAlbV.Columns[4].Width = 70;
                    gAlbV.Columns[5].Visible = false;
                    gAlbV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gAlbV.Columns[7].Visible = false;
                }

                textBox_Saldos_Albaranes.Text = Funciones.Formatea(total);
            }
            catch (Exception ex)
            {
                Mostrar(ex.ToString());
            }
        }

        private void Carga_Deudas()
        {
            if (textBox_CodCliente.Text.Contains("**") == false)
            {
                string consulta = "SELECT * FROM DEUDA WHERE DetCod=" + textBox_CodCliente.Text + " and FechaCobro IS NULL order by Fecha";
                ArrayList Deudas = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta,myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_deuda deuda = new clase_deuda();

                        deuda.Codigo = myReader["IdDeuda"].ToString();
                        deuda.Fecha = myReader["Fecha"].ToString(); if (deuda.Fecha.Contains(' ')) { deuda.Fecha = deuda.Fecha.Substring(0, deuda.Fecha.IndexOf(' ')); }
                        deuda.Importe = Funciones.Formatea(myReader["Importe"].ToString());
                        deuda.Cobrar = false;

                        Deudas.Add(deuda);
                    }
                    myReader.Close();

                    gDeuda.DataSource = Deudas;

                    if (gDeuda.Rows.Count > 0)
                    {
                        gDeuda.Columns[0].Visible = false;
                        gDeuda.Columns[1].ReadOnly = true; gDeuda.Columns[1].Width = 70;
                        gDeuda.Columns[2].ReadOnly = true; gDeuda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gDeuda.Columns[3].Visible = false;
                        gDeuda.Columns[4].Width = 40;
                        gDeuda.Columns[5].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void Carga_Cobros_Cuenta()
        {
            if (textBox_CodCliente.Text.Contains("**") == false)
            {
                string consulta = "SELECT IdAbono AS ident, Fecha, Importe, Importe AS Saldo, 'AB' AS Tipo FROM ABONOS WHERE  (DetCod = " + textBox_CodCliente.Text + ") AND (IdPagare IS NULL) AND (IdCobro IS NULL) UNION ALL SELECT IdCC AS ident, FechaRecibido AS Fecha, Importe, Saldo, 'CC' AS Tipo FROM COBROS_CUENTA WHERE (DetCod=" + textBox_CodCliente.Text + ") and (Saldo > 0) order by Fecha";
                ArrayList Cobros = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta,myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_deuda cobro_cuenta = new clase_deuda();

                        cobro_cuenta.Codigo = myReader["ident"].ToString();
                        cobro_cuenta.Fecha = myReader["Fecha"].ToString(); if (cobro_cuenta.Fecha.Contains(' ')) { cobro_cuenta.Fecha = cobro_cuenta.Fecha.Substring(0, cobro_cuenta.Fecha.IndexOf(' ')); }
                        cobro_cuenta.Importe = Funciones.Formatea(myReader["Importe"].ToString());
                        cobro_cuenta.Saldo = Funciones.Formatea(myReader["Saldo"].ToString());
                        cobro_cuenta.Cobrar = false;
                        cobro_cuenta.Tipo = myReader["Tipo"].ToString();

                        Cobros.Add(cobro_cuenta);
                    }
                    myReader.Close();

                    gCCta.DataSource = Cobros;

                    if (gCCta.Rows.Count > 0)
                    {
                        gCCta.Columns[0].Visible = false;
                        gCCta.Columns[1].ReadOnly = true; gCCta.Columns[1].Width = 75;
                        gCCta.Columns[2].ReadOnly = true; gCCta.Columns[2].Width = 60;
                        gCCta.Columns[3].ReadOnly = true; gCCta.Columns[3].Width = 60;
                        gCCta.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gCCta.Columns[5].Visible = false;

                        DataGridViewCellStyle style = new DataGridViewCellStyle();

                        foreach (DataGridViewRow row in gCCta.Rows)
                        {
                            style.BackColor = Color.White;

                            if (row.Cells[5].Value.ToString() == "AB")
                            {
                                style.BackColor = Color.LightGreen;
                            }

                            foreach (DataGridViewCell cell in row.Cells)
                                cell.Style.ApplyStyle(style);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }
            }
        }

        private void Carga_Cliente()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent  + this.GetType().FullName);

            this.Cursor = Cursors.WaitCursor;
            bool encontrado = false;
            textBox_DetNom.Text = "";
            textBox_DetPob.Text = "";
            textBox_DetNif.Text = "";
            button_Todos.Text = "TODOS";
            bool detrec = false;
            label_Recargo.Text = "";

            if (textBox_CodCliente.Text != "")
            {
                string consulta = "SELECT * FROM DETALLISTAS WHERE DetCod=" + textBox_CodCliente.Text.Replace("**", "");

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta,myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        encontrado = true;
                        textBox_DetNom.Text = myReader["DetNom"].ToString();
                        textBox_DetPob.Text = myReader["DetMun"].ToString();
                        textBox_DetNif.Text = myReader["DetNif"].ToString();
                        if (myReader["DetRec"].ToString() == "S") { detrec = true; }
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                }

                if (encontrado == true)
                {
                    if (detrec == true)
                    {
                        //agregamos valor Recargo
                        label_Recargo.Text = RECARGO;
                    }
                    label_Cliente.Visible = false;
                    Carga_Albaranes();
                    //Carga_Deudas();
                    //Carga_Cobros_Cuenta();
                    //Totalizar();
                }
                else
                {
                    label_Cliente.Visible = true;
                    ArrayList vacio = new ArrayList();
                    gAlbV.DataSource = vacio;
                    gCCta.DataSource = vacio;
                    gDeuda.DataSource = vacio;
                    //gCuenta.DataSource = vacio;
                    Totalizar();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void textBox_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se ha introducido código de cliente
            if (e.KeyChar.ToString() == "\r")
            {
                Carga_Cliente();
            }
        }

        private void Totalizar()
        {
            //lee ticks en albaranes, cobros, deudas
               
            string total = "0";
            ArrayList Cuentas = new ArrayList();

            if (label_Cliente.Visible == false)
            {
                if (gAlbV.Rows.Count > 0)
                {
                    for (int x = 0; x < gAlbV.Rows.Count; x++)
                    {
                        if (gAlbV.Rows[x].Cells[6].Value != null)
                        {
                            if (gAlbV.Rows[x].Cells[6].EditedFormattedValue.ToString().ToLower() == "true")
                            {
                                if (gAlbV.Rows[x].Cells[7].Value.ToString() == "")  //solo si no tienen pagaré
                                {
                                    clase_cuenta contante = new clase_cuenta();
                                    contante.Tipo = "AL";
                                    contante.Codigo = gAlbV.Rows[x].Cells[2].Value.ToString();
                                    contante.Fecha = gAlbV.Rows[x].Cells[3].Value.ToString();
                                    contante.Concepto = "Albarán " + contante.Codigo;
                                    contante.Importe = gAlbV.Rows[x].Cells[4].Value.ToString();
                                    contante.Anyo = gAlbV.Rows[x].Cells[0].Value.ToString();
                                    total = Funciones.Suma(total, contante.Importe);

                                    Cuentas.Add(contante);
                                }
                            }
                        }
                    }
                }

                if (gDeuda.Rows.Count > 0)
                {
                    for (int x = 0; x < gDeuda.Rows.Count; x++)
                    {
                        if (gDeuda.Rows[x].Cells[4].Value != null)
                        {
                            if (gDeuda.Rows[x].Cells[4].EditedFormattedValue.ToString().ToLower() == "true")
                            {
                                clase_cuenta contante = new clase_cuenta();

                                contante.Tipo = "DE";
                                contante.Codigo = gDeuda.Rows[x].Cells[0].Value.ToString();
                                contante.Fecha = gDeuda.Rows[x].Cells[1].Value.ToString();
                                contante.Concepto = "Deuda";
                                contante.Importe = gDeuda.Rows[x].Cells[2].Value.ToString();
                                total = Funciones.Suma(total, contante.Importe);

                                Cuentas.Add(contante);
                            }
                        }
                    }
                }

                if (gCCta.Rows.Count > 0)
                {
                    for (int x = 0; x < gCCta.Rows.Count; x++)
                    {
                        if (gCCta.Rows[x].Cells[4].Value != null)
                        {
                            if (gCCta.Rows[x].Cells[4].EditedFormattedValue.ToString().ToLower() == "true")
                            {
                                clase_cuenta contante = new clase_cuenta();

                                contante.Tipo = gCCta.Rows[x].Cells[5].Value.ToString();
                                contante.Codigo = gCCta.Rows[x].Cells[0].Value.ToString();
                                contante.Fecha = gCCta.Rows[x].Cells[1].Value.ToString();
                                contante.Importe = gCCta.Rows[x].Cells[3].Value.ToString();

                                if (contante.Tipo == "CC")
                                {
                                    contante.Concepto = "Cobro Cuenta " + contante.Fecha;
                                }
                                else
                                {
                                    contante.Concepto = "Abono " + contante.Fecha;
                                }

                                //los cobros a cuenta se contabilizan como negativos
                                contante.Importe = "-" + contante.Importe;

                                total = Funciones.Suma(total, contante.Importe);

                                Cuentas.Add(contante);
                            }
                        }
                    }
                }


            }

            gCuenta.DataSource = Cuentas;

            if (gCuenta.Rows.Count > 0)
            {
                gCuenta.Columns[0].Visible = false;
                gCuenta.Columns[1].Visible = false;
                gCuenta.Columns[2].Visible = false;
                gCuenta.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                gCuenta.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gCuenta.Columns[5].Visible = false;

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font("Arial", 12, FontStyle.Regular);
                foreach (DataGridViewRow row in gCuenta.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.Style.ApplyStyle(style);
                }


            }

            textBox_TOTAL.Text = total;

            //calcular BI, IVA, Recargo
            string percen_iva = Funciones.Divide(IVA, "100");
            string multiplicador_iva = Funciones.Suma("1", percen_iva);

            if (label_Recargo.Text != "")
            {
                string percen_recargo = Funciones.Divide(RECARGO, "100");
                multiplicador_iva = Funciones.Suma(multiplicador_iva, percen_recargo);
                string base_imponible = Funciones.Divide(total, multiplicador_iva);
                textBox_BI.Text = Funciones.Formatea(base_imponible);
                textBox_IVA.Text = Funciones.Formatea(Funciones.Multiplica(textBox_BI.Text, percen_iva));
                textBox_Recargo.Text = Funciones.Resta(textBox_TOTAL.Text, textBox_BI.Text);
                textBox_Recargo.Text = Funciones.Formatea(Funciones.Resta(textBox_Recargo.Text, textBox_IVA.Text));
            }
            else
            {
                //este cliente no tiene recargo
                textBox_Recargo.Text = "0,00";

                //BI=Total/(1+IVA)
                string base_imponible = Funciones.Divide(total, multiplicador_iva);
                textBox_BI.Text = Funciones.Formatea(base_imponible);
                textBox_IVA.Text = Funciones.Resta(textBox_TOTAL.Text, textBox_BI.Text);
            }

            //calcular Recargo
            /*decimal auxiliar = 0;
            if (Decimal.TryParse(textBox_Recargo.Text, out auxiliar) == true)
            {
                total = Funciones.Suma(total, textBox_Recargo.Text);
            }*/
        }

        private void gAlbV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    Totalizar();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void gCCta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Totalizar();
            this.Cursor = Cursors.Default;
        }

        private void gDeuda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Totalizar();
            this.Cursor = Cursors.Default;
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Borrador_Click(object sender, EventArgs e)
        {
            //Imprimir albaranes del grid + cobro cuenta si lo hay
            if (gAlbV.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Desea imprimir un borrador con los albaranes seleccionados de este detallista?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //procedemos
                    try
                    {
                        string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\RECIBOS\\temporal.txt";

                        TextWriter tw = new StreamWriter(fichero);

                        string linea = "JOSE CARABAL, S.L.";
                        tw.WriteLine(linea);
                        linea = "Mercavalencia, Modulos 12-13";
                        tw.WriteLine(linea); 
                        linea = "46013 VALENCIA";
                        tw.WriteLine(linea); tw.WriteLine(""); 

                        linea = "Borrador albaranes  " + DateTime.Today.ToShortDateString();
                        tw.WriteLine(linea); tw.WriteLine(""); 

                        linea = "Cliente " + textBox_CodCliente.Text.Replace("**", "");
                        tw.WriteLine(linea); 

                        linea = "        " + textBox_DetNom.Text;
                        tw.WriteLine(linea); tw.WriteLine(""); 

                        linea = " FECHA          ALBARAN   IMPORTE";
                        tw.WriteLine(linea); 

                        linea = "=================================";
                        tw.WriteLine(linea);

                        for (int x = 0; x < gAlbV.Rows.Count; x++)
                        {
                            if (gAlbV.Rows[x].Cells[6].Value != null)
                            {
                                if (gAlbV.Rows[x].Cells[6].EditedFormattedValue.ToString().ToLower() == "true")
                                {
                                    linea = gAlbV.Rows[x].Cells[3].Value.ToString() + "      " + gAlbV.Rows[x].Cells[2].Value.ToString() + "  " + gAlbV.Rows[x].Cells[4].Value.ToString().PadLeft(8, ' ');

                                    tw.WriteLine(linea);
                                }
                            }
                        }

                        string textos_cuenta = "";

                        for (int x = 0; x < gCCta.Rows.Count; x++)
                        {
                            if (gCCta.Rows[x].Cells[4].Value != null)
                            {
                                if (gCCta.Rows[x].Cells[4].EditedFormattedValue.ToString().ToLower() == "true")
                                {
                                    string importe = "-" + gCCta.Rows[x].Cells[3].Value.ToString();
                                    textos_cuenta += gCCta.Rows[x].Cells[1].Value.ToString() + "  Cobro Cuenta  " + importe.PadLeft(8, ' ');
                                }
                            }
                        }

                        if (textos_cuenta != "")
                        {
                            tw.WriteLine(""); tw.WriteLine("");

                            linea = " FECHA      CONCEPTO       IMPORTE";
                            tw.WriteLine(linea);

                            linea = "==================================";
                            tw.WriteLine(linea);
                            
                            tw.WriteLine(textos_cuenta);
                        }

                        linea = "\r\nTotal.....     " + Funciones.Formatea(textBox_TOTAL.Text).PadLeft(14, ' '); //24 de anchura
                        tw.WriteLine(linea);

                        //Añadir 6 líneas en blanco
#if !DEBUG
                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
#endif
                        tw.Close();


                        //Imprimir RECIBO

                        printDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                        string impresora = frmInicioCaja.RUTA_RECIBOS;
                        if (impresora == "") { impresora = printDialog1.PrinterSettings.PrinterName; }

                        AbreCajon(impresora);
                        RawPrinterHelper.SendFileToPrinter(impresora, fichero);
                        CortaTicket(impresora);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }          
                }
            }
            else
            {
                MessageBox.Show("No se han cargado albaranes de detallista");
            }
        }

        private void toolStripButton_Cobrar_Click(object sender, EventArgs e)
        {
            //pantalla de cobrar
            if (gCuenta.Rows.Count > 0)
            {
                frmCobros1 Importe_Cobros = new frmCobros1();
                Importe_Cobros.Albaranes = false;
                Importe_Cobros.Cuentas = (ArrayList)gCuenta.DataSource;
                Importe_Cobros.myConnection =myConnection ;
                Importe_Cobros.Importe_Total = textBox_TOTAL.Text;
                Importe_Cobros.detcod = textBox_CodCliente.Text.Replace("**", "");
                Importe_Cobros.IdVendedor = IdVendedor;
                Importe_Cobros.fecha_cobro = textBox_Fecha.Text;
                Importe_Cobros.nombre_cliente = textBox_DetNom.Text;
                Importe_Cobros.TIPO51 = false; if (textBox_CodCliente.Text.Contains("**")) { Importe_Cobros.TIPO51 = true; }
                Importe_Cobros.base_imponible = textBox_BI.Text;
                Importe_Cobros.iva = textBox_IVA.Text;
                Importe_Cobros.recargo = textBox_Recargo.Text;
                if (Importe_Cobros.ShowDialog() == DialogResult.OK)
                {
                    //recargar detcod
                    Carga_Cliente();
                }
            }
            else
            {
                MessageBox.Show("No hay cuenta para cobrar");
            }
        }

        private void toolStripButton_Cobro_Albaran_Click(object sender, EventArgs e)
        {
            //cobros + albaranes
            if (gCuenta.Rows.Count > 0)
            {
                frmCobros1 Importe_Cobros = new frmCobros1();
                Importe_Cobros.Albaranes = true;
                Importe_Cobros.Cuentas = (ArrayList)gCuenta.DataSource;
                Importe_Cobros.myConnection =myConnection ;
                Importe_Cobros.Importe_Total = textBox_TOTAL.Text;
                Importe_Cobros.detcod = textBox_CodCliente.Text.Replace("**", "");
                Importe_Cobros.IdVendedor = IdVendedor;
                Importe_Cobros.fecha_cobro = textBox_Fecha.Text;
                Importe_Cobros.nombre_cliente = textBox_DetNom.Text;
                Importe_Cobros.TIPO51 = false; if (textBox_CodCliente.Text.Contains("**")) { Importe_Cobros.TIPO51 = true; }
                Importe_Cobros.base_imponible = textBox_BI.Text;
                Importe_Cobros.iva = textBox_IVA.Text;
                Importe_Cobros.recargo = textBox_Recargo.Text;
                if (Importe_Cobros.ShowDialog() == DialogResult.OK)
                {
                    //recargar detcod
                    Carga_Cliente();
                }
            }
            else
            {
                MessageBox.Show("No hay cuenta para cobrar");
            }
        }

        private void button_Todos_Click(object sender, EventArgs e)
        {
            //marcar o desmarcar flag de cobrar en albaranes
            this.Cursor = Cursors.WaitCursor;
            if (button_Todos.Text == "TODOS")
            {
                //marcar todos
                for (int x = 0; x < gAlbV.Rows.Count; x++)
                {
                    gAlbV.Rows[x].Cells[6].Value = "True";
                }

                //cambiar texto
                button_Todos.Text = "NINGUNO";
            }
            else
            {
                if (button_Todos.Text == "NINGUNO")
                {
                    //desmarcar todos
                    for (int x = 0; x < gAlbV.Rows.Count; x++)
                    {
                        gAlbV.Rows[x].Cells[6].Value = "False";
                    }

                    //cambiar texto
                    button_Todos.Text = "TODOS";
                }
            }

            Totalizar();

            this.Cursor = Cursors.Default;
        }

        private void textBox_Fecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //podría cambiar el valor del IVA
            if (e.KeyChar.ToString() == "\r")
            {
                Leer_IVA();
            }
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Filtrado = true;
            label_Filtro.Text = "Filtro Activado";
            Carga_Albaranes();
            Totalizar();
            this.Cursor = Cursors.Default;
        }

        private void button_Desfiltrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Filtrado = false;
            label_Filtro.Text = "";
            Carga_Albaranes();
            Totalizar();
            this.Cursor = Cursors.Default;
        }

        private string Devuelve_ruta(string path, string fecha, string CodCliente, string id_albaran)
        {
            string resultado = "";
            string ruta_directorio = path + "\\" + fecha;
            if (Directory.Exists(ruta_directorio))
            {
                string comienzo = fecha + "+" + CodCliente + "+" + id_albaran + "_";
                string[] ficheros = Directory.GetFiles(ruta_directorio, comienzo + "*.gif");
                if (ficheros.Length > 0)
                {
                    if (ficheros.Length == 1)
                    {
                        resultado = ficheros[0];
                    }
                    else
                    {
                        FileInfo fi1 = new FileInfo(ficheros[0]);
                        FileInfo fi2 = new FileInfo(ficheros[1]);

                        if (fi1.LastWriteTime.CompareTo(fi2.LastWriteTime) > 0)
                        {
                            resultado = ficheros[0];
                        }
                        else
                        {
                            resultado = ficheros[1];
                        }
                    }
                }
            }
            return resultado;
        }

        private void gAlbV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    bool encontrado = false;

                    string num_albaran = gAlbV.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string fecha_albaran = gAlbV.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string importe = gAlbV.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string path_images = frmInicioCaja.PATH_IMAGES_LOCAL;

                    if (path_images != "")
                    {
                        string fecha_formateada = "";
                        DateTime resultado = new DateTime(2000, 1, 1);
                        if (DateTime.TryParse(fecha_albaran, out resultado) == true)
                        {
                            if (resultado.Year > 2000)
                            {
                                fecha_formateada = resultado.Year.ToString() + "-" + resultado.Month.ToString().PadLeft(2, '0') + "-" + resultado.Day.ToString().PadLeft(2, '0');
                            }
                        }

                        if (fecha_formateada != "")
                        {
                            string ruta_inicial = path_images + "\\" + fecha_formateada + "\\" + fecha_formateada + "+" + textBox_CodCliente.Text.Replace("**", "") + "+" + num_albaran + "_ticket_" + importe + ".gif";
                            string ruta = Devuelve_ruta(path_images, fecha_formateada, textBox_CodCliente.Text.Replace("**", ""), num_albaran);

                            if (ruta != "")
                            {
                                //comprobar si tenemos el ticket
                                if (File.Exists(ruta) == true)
                                {
                                    encontrado = true;
                                    FormAlbaran FAlba = new FormAlbaran();
                                    FAlba.ticket = ruta;
                                    FAlba.Show();
                                }
                                else
                                {
                                    MessageBox.Show(ruta_inicial);
                                }
                            }
                        }
                    }

                    if (encontrado == false)
                    {
                        MessageBox.Show("No se ha encontrado ticket");
                    }

                }
            }
        }


        public void AbreCajon(string impresora)
        {
            string cajon = "\x1B" + "p" + "\x00" + "\x0F" + "\x96";
            RawPrinterHelper.SendStringToPrinter(impresora, cajon);
        }

        public void CortaTicket(string impresora)
        {
            string corte = "\x1B" + "m";                //caracteres de corte
            string avance = "\x1B" + "d" + "\x09";      //avanza 9 renglones
            RawPrinterHelper.SendStringToPrinter(impresora, avance);
            RawPrinterHelper.SendStringToPrinter(impresora, corte);
        }

        private void toolStripButton_Cobro_Cuenta_Click(object sender, EventArgs e)
        {
            //abrir formulario para hacer un cobro a cuenta
            FormCobroCuenta FCuenta = new FormCobroCuenta();
            FCuenta.fecha_actual = textBox_Fecha.Text;
            FCuenta.detcod = textBox_CodCliente.Text.Replace("**", "");
            FCuenta.detnom = textBox_DetNom.Text;
            FCuenta.myConnection =myConnection ;
            if (FCuenta.ShowDialog() == DialogResult.OK)
            {
                Carga_Cobros_Cuenta();
            }
        }
        
        private void toolStripButton_Abonos_Click(object sender, EventArgs e)
        {
            FormAbonos FAbono = new FormAbonos();
            FAbono.fecha_actual = textBox_Fecha.Text;
            FAbono.detcod = textBox_CodCliente.Text.Replace("**", "");
            FAbono.detnom = textBox_DetNom.Text;
            FAbono.myConnection =myConnection ;
            if (FAbono.ShowDialog() == DialogResult.OK)
            {
                Carga_Cobros_Cuenta();
            }
        }

        private int EjecutaNonQuery(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery,myConnection );
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

        private void Descobro_Normal()
        {
            //contraseña
            FormPassword FPass = new FormPassword();
            if (FPass.ShowDialog() == DialogResult.OK)
            {
                if (FPass.paswd == "administrador")
                {
                    frmDescobro FDescobro = new frmDescobro();
                    if (FDescobro.ShowDialog() == DialogResult.OK)
                    {
                        string Id_Cobro = FDescobro.num_recibo;

                        if (Id_Cobro != "")
                        {
                            //comprobar que el cobro es de fecha actual
                            string select = "SELECT * FROM VENALB_COBROS WHERE IdCobro=" + Id_Cobro + " AND Fecha='" + DateTime.Today.ToShortDateString() + "'";
                            bool stop = true;
                            string id_cc = "";
                            string cc = "";

                            try
                            {
                                SqlDataReader myReader = null;
                                SqlCommand myCommand = new SqlCommand(select,myConnection );
                                myReader = myCommand.ExecuteReader();
                                while (myReader.Read())
                                {
                                    stop = false;
                                    id_cc = myReader["IdCC"].ToString();
                                    cc = myReader["CC"].ToString();
                                }
                                myReader.Close();
                            }
                            catch (Exception ex)
                            {
                                Mostrar(ex.ToString());
                            }

                            if (stop == false)
                            {
                                //actualizamos los albaranes
                                string update_albaranes = "UPDATE VENALB_CABE SET IdCobro=NULL, FechaCobro=NULL WHERE IdCobro=" + Id_Cobro;
                                int res = EjecutaNonQuery(update_albaranes);

                                if (res > 0)
                                {
                                    MessageBox.Show("Descobro efectuado");
                                }
                                else
                                {
                                    MessageBox.Show("No se ha encontrado");
                                }

                                //borramos deuda
                                string delete_deuda = "DELETE FROM DEUDA WHERE IdCobro=" + Id_Cobro;
                                res = EjecutaNonQuery(delete_deuda);

                                //borramos talones
                                string delete_talon = "DELETE FROM TALONES WHERE IdCobro=" + Id_Cobro;
                                res = EjecutaNonQuery(delete_talon);

                                //borramos pagarés
                                string delete_pagares = "DELETE FROM PAGARES WHERE IdCobro=" + Id_Cobro;
                                res = EjecutaNonQuery(delete_pagares);

                                //actualizamos cobros a cuenta
                                if (id_cc != "")
                                {
                                    string update_cuenta = "UPDATE COBROS_CUENTA SET Saldo=Saldo+" + Funciones.Formatea(cc).Replace(",", ".") + " WHERE IdCC=" + id_cc;
                                    int res2 = EjecutaNonQuery(update_cuenta);
                                }

                                //borramos el cobro
                                string delete_cobro = "DELETE FROM VENALB_COBROS WHERE IdCobro=" + Id_Cobro;
                                res = EjecutaNonQuery(delete_cobro);

                                Carga_Cliente();
                            }
                            else
                            {
                                MessageBox.Show("Cobro no es de la fecha actual");
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se introdujo número de recibo");
                        }

                    }
                }
            }
        }

        private void Descobro51()
        {
            //contraseña
            FormPassword FPass = new FormPassword();
            if (FPass.ShowDialog() == DialogResult.OK)
            {
                if (FPass.paswd == "administrador")
                {
                    frmDescobro FDescobro = new frmDescobro();
                    FDescobro.tipo51 = "51";
                    if (FDescobro.ShowDialog() == DialogResult.OK)
                    {
                        string Id_Cobro = FDescobro.num_recibo;

                        if (Id_Cobro != "")
                        {
                            //comprobar que el cobro es de fecha actual
                            string select = "SELECT * FROM VENALB_COBROS51 WHERE IdCobro=" + Id_Cobro + " AND Fecha='" + DateTime.Today.ToShortDateString() + "'";
                            bool stop = true;

                            try
                            {
                                SqlDataReader myReader = null;
                                SqlCommand myCommand = new SqlCommand(select,myConnection );
                                myReader = myCommand.ExecuteReader();
                                while (myReader.Read())
                                {
                                    stop = false;
                                }
                                myReader.Close();
                            }
                            catch (Exception ex)
                            {
                                Mostrar(ex.ToString());
                            }

                            if (stop == false)
                            {
                                //actualizamos los albaranes
                                string update_albaranes = "UPDATE VENALB_CABE SET IdCobro=NULL, FechaCobro=NULL WHERE IdCobro=" + Id_Cobro;
                                int res = EjecutaNonQuery(update_albaranes);

                                if (res > 0)
                                {
                                    MessageBox.Show("Descobro efectuado");
                                }
                                else
                                {
                                    MessageBox.Show("No se ha encontrado");
                                }


                                //borramos el cobro
                                string delete_cobro = "DELETE FROM VENALB_COBROS51 WHERE IdCobro=" + Id_Cobro;
                                res = EjecutaNonQuery(delete_cobro);

                                Carga_Cliente();
                            }
                            else
                            {
                                MessageBox.Show("Cobro no es de la fecha actual");
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se introdujo número de recibo");
                        }

                    }
                }
            }
        }

        private void toolStripButton_Descobro_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Descobro.BackColor == Color.GreenYellow)
            {
                Descobro51();
            }
            else
            {
                Descobro_Normal();
            }
        }

        private string MaxPagare()
        {
            string resultado = "0";

            string consulta = "SELECT MAX(IdPagare) FROM PAGARES";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta,myConnection );
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado = myReader[0].ToString();
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        //private void textBox_CodCliente_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void toolStripButton_Pagare_Click(object sender, EventArgs e)
        {
            //adosar pagaré a los albaranes seleccionados
            if (gCuenta.Rows.Count > 0)
            {
                //calcular el importe solo de los albaranes
                string importe_albaranes = "0";
                for (int x = 0; x < gAlbV.Rows.Count; x++)
                {
                    if (gAlbV.Rows[x].Cells[6].Value != null)
                    {
                        if (gAlbV.Rows[x].Cells[6].EditedFormattedValue.ToString().ToLower() == "true")
                        {
                            string Importe = gAlbV.Rows[x].Cells[4].Value.ToString();
                            importe_albaranes = Funciones.Suma(importe_albaranes, Importe);
                        }
                    }
                }

                for (int x = 0; x < gCCta.Rows.Count; x++)
                {
                    if (gCCta.Rows[x].Cells[5].Value.ToString() == "AB")
                    {
                        if (gCCta.Rows[x].Cells[4].Value != null)
                        {
                            if (gCCta.Rows[x].Cells[4].EditedFormattedValue.ToString().ToLower() == "true")
                            {
                                string Saldo = gCCta.Rows[x].Cells[3].Value.ToString();
                                importe_albaranes = Funciones.Resta(importe_albaranes, Saldo);
                            }
                        }
                    }
                }

                frmNuevoPagare NuevoPagare = new frmNuevoPagare();
                NuevoPagare.importe_pagare = importe_albaranes;
                NuevoPagare.myConnection =myConnection ;
                NuevoPagare.codcliente = textBox_CodCliente.Text.Replace("**", "");
                NuevoPagare.adosado = true;

                if (NuevoPagare.ShowDialog() == DialogResult.OK)
                {
                    //adosarlo
                    if (NuevoPagare.fecha_vto != "")
                    {
                        //insert
                        decimal auxiliar = 0;
                        if (Decimal.TryParse(NuevoPagare.importe_pagare, out auxiliar) == true)
                        {
                            if (auxiliar > 0)
                            {
                                string observaciones = NuevoPagare.observaciones.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                                string insert_pagare = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones, Cobrado) ";
                                insert_pagare += " VALUES(" + NuevoPagare.codcliente + ", '" + DateTime.Today.ToShortDateString() + "', '" + NuevoPagare.fecha_vto.Replace("'", "''") + "', " + NuevoPagare.importe_pagare.Replace(",", ".") + ", '" + observaciones + "', 'N')";

                                int res = EjecutaNonQuery(insert_pagare);

                                if (res == 1)
                                {
                                    MessageBox.Show("El nuevo pagaré se ha grabado con éxito");
                                    string idpagare = MaxPagare();

                                    //para los albaranes seleccionados
                                    for (int x = 0; x < gAlbV.Rows.Count; x++)
                                    {
                                        if (gAlbV.Rows[x].Cells[6].Value != null)
                                        {
                                            if (gAlbV.Rows[x].Cells[6].EditedFormattedValue.ToString().ToLower() == "true")
                                            {
                                                string Codigo = gAlbV.Rows[x].Cells[2].Value.ToString();
                                                string Anyo = gAlbV.Rows[x].Cells[0].Value.ToString();

                                                string update_albaran = "UPDATE VENALB_CABE SET IdPagare=" + idpagare + " WHERE Anyo=" + Anyo + " AND VenAlb=" + Codigo;

                                                int res2 = EjecutaNonQuery(update_albaran);
                                            }
                                        }
                                    }

                                    //para los abonos seleccionados
                                    for (int x = 0; x < gCCta.Rows.Count; x++)
                                    {
                                        if (gCCta.Rows[x].Cells[5].Value.ToString() == "AB")
                                        {
                                            if (gCCta.Rows[x].Cells[4].Value != null)
                                            {
                                                if (gCCta.Rows[x].Cells[4].EditedFormattedValue.ToString().ToLower() == "true")
                                                {
                                                    string Codigo = gCCta.Rows[x].Cells[0].Value.ToString();

                                                    string update_abono = "UPDATE ABONOS SET IdPagare=" + idpagare + " WHERE IdAbono=" + Codigo;

                                                    int res3 = EjecutaNonQuery(update_abono);
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se ha dado fecha de vencimiento");
                    }


                    //recargar detcod
                    Carga_Cliente();
                }
            }
            else
            {
                MessageBox.Show("No hay cuenta para cobrar");
            }
        }

        private void panel_51_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Descobro.BackColor == Color.Wheat)
            {
                toolStripButton_Descobro.BackColor = Color.GreenYellow;
            }
            else
            {
                toolStripButton_Descobro.BackColor = Color.Wheat;
            }
        }


    }
}
