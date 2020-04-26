using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Net;

namespace cercle17
{
    public partial class frmCobros1 : Form
    {
        public frmCobros1()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public ArrayList Cuentas;
        public string Importe_Total, TOPE_CUENTA;
        public string detcod, IdVendedor, fecha_cobro, nombre_cliente;
        public bool Albaranes;
        public bool TIPO51;
        public string base_imponible, iva, recargo;
        public ArrayList DATOS_PAGARES;
        public ArrayList INSERT_PAGARES;


        private void Carga_Pagares()
        {
            if (myConnection != null)
            {

                DateTime fecha_vencimiento = new DateTime(2000, 1, 1);
                if (DateTime.TryParse(fecha_cobro, out fecha_vencimiento) == true)
                {
                    fecha_vencimiento = fecha_vencimiento.AddDays(2);
                }

                ArrayList Lista_Pagares = new ArrayList();
                //string select = "SELECT * FROM PAGARES WHERE Cobrado='N' and DetCod=" + detcod + " AND FVencto <= '" + fecha_vencimiento.ToShortDateString() + "' ORDER BY FVencto, IdPagare";
                string select = "SELECT * FROM PAGARES WHERE Cobrado='N' and DetCod=" + detcod + " ORDER BY FVencto, IdPagare";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(select, myConnection);
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

        private void frmCobros1_Load(object sender, EventArgs e)
        {
            textBox_Efectivo.Text = "0,00";
            textBox_Deuda.Text = "0,00";
            textBox_Transferencia.Text = "0,00";
            textBox_Talon.Text = "0,00";
            textBox_Tarjeta.Text = "0,00";
            textBox_Pagare.Text = "0,00";
            textBox_ACuenta.Text = "0,00";

            label_ACuenta.Visible = false;
            textBox_ACuenta.Visible = false;
            textBox_ACuenta.ReadOnly = true;

            Importe_Total = "0,00";
            TOPE_CUENTA = "";

            if (Cuentas != null)
            {
                for (int x = 0; x < Cuentas.Count; x++)
                {
                    clase_cuenta dato = (clase_cuenta)Cuentas[x];
                    if (dato.Tipo == "CC")
                    {
                        label_ACuenta.Visible = true;
                        textBox_ACuenta.Visible = true;
                        if (dato.Importe.StartsWith("-")) { dato.Importe = dato.Importe.Replace("-", ""); }
                        textBox_ACuenta.Text = Funciones.Suma(textBox_ACuenta.Text, dato.Importe);
                        if (Decimal.Parse(textBox_ACuenta.Text) > Decimal.Parse(Importe_Total))
                        {
                            textBox_ACuenta.Text = Importe_Total;
                        }
                    }
                    else
                    {
                        Importe_Total = Funciones.Suma(Importe_Total, dato.Importe);
                    }
                }
            }

            label_Importe_Total.Text = Importe_Total;

            if (label_ACuenta.Visible == true)
            {
                textBox_Efectivo.Text = Funciones.Resta(Importe_Total, textBox_ACuenta.Text);
                TOPE_CUENTA = textBox_ACuenta.Text;
            }
            else
            {
                textBox_Efectivo.Text = Importe_Total;
            }

            //FOCO
            textBox_Efectivo.Select();

            label_BI.Visible = TIPO51; textBox_BI.Visible = TIPO51; textBox_BI.Text = base_imponible;
            label_IVA.Visible = TIPO51; textBox_IVA.Visible = TIPO51; textBox_IVA.Text = iva;
            label_Recargo.Visible = TIPO51; textBox_Recargo.Visible = TIPO51; textBox_Recargo.Text = recargo;
            DATOS_PAGARES = new ArrayList();
            INSERT_PAGARES = new ArrayList();

            if (TIPO51)
            {
                textBox_Transferencia.Enabled = false; textBox_Obs_Transferencia.Enabled = false;
                textBox_Talon.Enabled = false; textBox_Obs_Talon.Enabled = false;
                textBox_Tarjeta.Enabled = false; textBox_Obs_Tarjeta.Enabled = false;
                textBox_Pagare.Enabled = false;
            }

            //imprimir los albaranes
            if (Albaranes == true)
            {
                if (Cuentas != null)
                {
                    string texto_albaranes = "";
                    for (int x = 0; x < Cuentas.Count; x++)
                    {
                        clase_cuenta dato = (clase_cuenta)Cuentas[x];
                        if (dato.Tipo == "AL")
                        {
                            //buscar si el archivo existe
                            bool encontrado = true;

                            string num_albaran = dato.Codigo;
                            string fecha_albaran = dato.Fecha;
                            string importe = dato.Importe;
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
                                    string ruta_inicial = path_images + "\\" + fecha_formateada + "\\" + fecha_formateada + "+" + detcod + "+" + num_albaran + "_ticket_" + importe + ".gif";
                                    string ruta = Devuelve_ruta(path_images, fecha_formateada, detcod, num_albaran);

                                    //comprobar si tenemos el ticket
                                    if (File.Exists(ruta) == true)
                                    {
                                        texto_albaranes += ruta + "\r\n";
                                    }
                                    else
                                    {
                                        encontrado = false; //si queremos que se advierta de que al menos un albarán no fue encontrado
                                    }
                                }
                            }

                            if (encontrado == false)
                            {
                                MessageBox.Show("No se ha encontrado ticket");
                            }

                        }
                    }

                    if (texto_albaranes.Length > 0)
                    {
                        //escribimos el fichero que imprime los albaranes seguidos
                        if (frmInicioCaja.IMPRE_RECIBOS != "")
                        {
                            string new_file = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\ImpAlbs.txt";
                            string impresora = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\ImprimeAlbsNet.exe";
                            try
                            {
                                if (File.Exists(new_file))
                                {
                                    File.Delete(new_file);
                                }

                                using (FileStream fs = File.Create(new_file))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes(frmInicioCaja.IMPRE_RECIBOS + "\r\n");
                                    fs.Write(info, 0, info.Length);

                                    Byte[] texto = new UTF8Encoding(true).GetBytes(texto_albaranes);
                                    fs.Write(texto, 0, texto.Length);
                                }

                                Process.Start(impresora);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No tiene impresora Configurada");
                        }
                    }

                }
            }

            //cargar pagarés vencidos si los hubiere
            Carga_Pagares();

        }

        private string Nuevo_Cobro()
        {
            string resultado = "0";

            string consulta = "SELECT MAX(IdCobro) FROM VENALB_COBROS";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, myConnection);
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

        private string Nuevo_Cobro51()
        {
            string resultado = "0";

            string consulta = "SELECT MAX(IdCobro) FROM VENALB_COBROS51";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, myConnection);
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

        private string Lee_VenTve(string Codigo, string Anyo)
        {
            string resultado = "0";

            string consulta = "SELECT VenTve FROM VENALB_CABE  WHERE Anyo=" + Anyo + " AND VenAlb=" + Codigo;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, myConnection);
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

        private int EjecutaNonQuery(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, myConnection);
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(NonQuery + "\r\n" + ex.ToString());
            }

            return res;
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            string Tipo_Cobro = "3";
            string IdCobro = "0";
            string texto_deuda = ""; string texto_transferencia = ""; string texto_talon = ""; string texto_tarjeta = ""; string texto_pagare = ""; string texto_efectivo = "";
            
            string efectivo_money = "0";
            string transferencia_money = "0";
            string tarjeta_money = "0";
            string talon_money = "0";
            string pagare_money = "0";
            string deuda_money = "0";

            if (TIPO51 == false)
            {
                //texto efectivo
                if (textBox_Efectivo.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            efectivo_money = Funciones.Formatea(textBox_Efectivo.Text).Replace(",", ".");
                            texto_efectivo = "Efectivo......" + Funciones.Formatea(textBox_Efectivo.Text).PadLeft(15, ' ');
                        }
                    }
                }


                //generar COBRO
                IdCobro = Nuevo_Cobro();


                //generar deuda
                if (textBox_Deuda.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Deuda.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            string observaciones = textBox_Obs_Deuda.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                            string insert_deuda = "INSERT INTO DEUDA(DetCod, Fecha, Importe, Observaciones, IdCobro) ";
                            insert_deuda += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', " + textBox_Deuda.Text.Replace(",", ".") + ", '" + observaciones + "', " + IdCobro + ")";

                            int res = EjecutaNonQuery(insert_deuda);

                            deuda_money = Funciones.Formatea(textBox_Deuda.Text).Replace(",", ".");
                            texto_deuda = "Deuda........." + Funciones.Formatea(textBox_Deuda.Text).PadLeft(15, ' ');
                        }
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
                            string observaciones = textBox_Obs_Transferencia.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                            string insert_transfer = "INSERT INTO TRANSFERENCIAS(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobro) ";
                            insert_transfer += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + textBox_Transferencia.Text.Replace(",", ".") + ", '" + observaciones + "', " + IdCobro + ")";

                            int res = EjecutaNonQuery(insert_transfer);

                            transferencia_money = Funciones.Formatea(textBox_Transferencia.Text).Replace(",", ".");
                            texto_transferencia = "Transferencia." + Funciones.Formatea(textBox_Transferencia.Text).PadLeft(15, ' ');
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
                            string observaciones = textBox_Obs_Talon.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                            string insert_talon = "INSERT INTO TALONES(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobro) ";
                            insert_talon += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + textBox_Talon.Text.Replace(",", ".") + ", '" + observaciones + "', " + IdCobro + ")";

                            int res = EjecutaNonQuery(insert_talon);

                            talon_money = Funciones.Formatea(textBox_Talon.Text).Replace(",", ".");
                            texto_talon = "Talón........." + Funciones.Formatea(textBox_Talon.Text).PadLeft(15, ' ');
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
                            string observaciones = textBox_Obs_Tarjeta.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                            string insert_tarjeta = "INSERT INTO CREDIT_CARDS(DetCod, Fecha, FechaCobro, Importe, Observaciones, IdCobro) ";
                            insert_tarjeta += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + DateTime.Today.ToShortDateString() + "', " + textBox_Tarjeta.Text.Replace(",", ".") + ", '" + observaciones + "', " + IdCobro + ")";

                            int res = EjecutaNonQuery(insert_tarjeta);

                            tarjeta_money = Funciones.Formatea(textBox_Tarjeta.Text).Replace(",", ".");
                            texto_tarjeta = "Tarjeta......." + Funciones.Formatea(textBox_Tarjeta.Text).PadLeft(15, ' ');
                        }
                    }
                }

                //comprobar si tenemos más de un pagaré
                /*if (INSERT_PAGARES.Count > 0)
                {
                    //primera línea
                    string insert_pagare = (string)INSERT_PAGARES[0];
                    insert_pagare += IdCobro + ")";

                    int res = EjecutaNonQuery(insert_pagare);

                    pagare_money = Funciones.Formatea(textBox_Pagare.Text).Replace(",", ".");

                    if (DATOS_PAGARES.Count > 0)
                    {
                        clase_pagare Paga1 = (clase_pagare)DATOS_PAGARES[0];

                        texto_pagare = "Pagare........" + Funciones.Formatea(Paga1.Importe).PadLeft(15, ' ') + "\r\n";
                        texto_pagare += "Observaciones: " + Paga1.Observaciones + "\r\n";
                        texto_pagare += "Fecha Vto: " + Paga1.Vencimiento.PadLeft(15, ' ');
                    }

                    //segunda línea
                    if (INSERT_PAGARES.Count > 1)
                    {
                        string insert_pagare2 = (string)INSERT_PAGARES[1];
                        insert_pagare2 += IdCobro + ")";

                        int res2 = EjecutaNonQuery(insert_pagare2);

                        if (DATOS_PAGARES.Count > 1)
                        {
                            clase_pagare Paga2 = (clase_pagare)DATOS_PAGARES[1];

                            texto_pagare += "\r\nPagare........" + Funciones.Formatea(Paga2.Importe).PadLeft(15, ' ') + "\r\n";
                            texto_pagare += "Observaciones: " + Paga2.Observaciones + "\r\n";
                            texto_pagare += "Fecha Vto: " + Paga2.Vencimiento.PadLeft(15, ' ');
                        }
                    }

                    //tercera línea
                    if (INSERT_PAGARES.Count > 2)
                    {
                        string insert_pagare3 = (string)INSERT_PAGARES[2];
                        insert_pagare3 += IdCobro + ")";

                        int res3 = EjecutaNonQuery(insert_pagare3);

                        if (DATOS_PAGARES.Count > 2)
                        {
                            clase_pagare Paga3 = (clase_pagare)DATOS_PAGARES[2];

                            texto_pagare += "\r\nPagare........" + Funciones.Formatea(Paga3.Importe).PadLeft(15, ' ') + "\r\n";
                            texto_pagare += "Observaciones: " + Paga3.Observaciones + "\r\n";
                            texto_pagare += "Fecha Vto: " + Paga3.Vencimiento.PadLeft(15, ' ');
                        }
                    }
                }
                else
                {
                    //generar pagaré, que aunque no esté cobrado toma el valor del IdCobro
                    if (textBox_Pagare.Text != "0,00")
                    {
                        decimal auxiliar = 0;
                        if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
                        {
                            if (auxiliar > 0)
                            {
                               
                                string insert_pagare = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones, IdCobro) ";
                                insert_pagare += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + textBox_Vencimiento.Text + "', " + textBox_Pagare.Text.Replace(",", ".") + ", '" + observaciones + "', " + IdCobro + ")";

                                int res = EjecutaNonQuery(insert_pagare);

                                pagare_money = Funciones.Formatea(textBox_Pagare.Text).Replace(",", ".");
                                texto_pagare = "Pagare........" + Funciones.Formatea(textBox_Pagare.Text).PadLeft(15, ' ') + "\r\n";
                                texto_pagare += "Observaciones: " + observaciones + "\r\n";
                                texto_pagare += "Fecha Vto: " + textBox_Vencimiento.Text.PadLeft(15, ' ');
                                
                            }
                        }
                    }
                }*/

                //cobrar pagarés
                if (textBox_Pagare.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            string observaciones_pagares = "";
                            string vencimientos_pagares = "";

                            for (int x = 0; x < gPagares.Rows.Count; x++)
                            {
                                if (gPagares.Rows[x].Cells[8].EditedFormattedValue.ToString().ToLower() == "true")
                                {
                                    string idpagare = gPagares.Rows[x].Cells[0].Value.ToString();
                                    string importe_pagare = gPagares.Rows[x].Cells[6].Value.ToString();
                                    string observaciones = gPagares.Rows[x].Cells[9].Value.ToString();
                                    string vencimiento = gPagares.Rows[x].Cells[4].Value.ToString();

                                    string update_pagare = "UPDATE PAGARES SET Cobrado='S', FechaCobro='" + fecha_cobro + "', IdCobro=" + IdCobro;
                                    update_pagare += "  WHERE IdPagare=" + idpagare;

                                    int res = EjecutaNonQuery(update_pagare);

                                    observaciones_pagares += observaciones + "\r\n";
                                    vencimientos_pagares += vencimiento.PadLeft(15, ' ') + "\r\n";
                                }                                
                            }
                            
                            pagare_money = Funciones.Formatea(textBox_Pagare.Text).Replace(",", ".");
                            texto_pagare = "Pagare........" + Funciones.Formatea(textBox_Pagare.Text).PadLeft(15, ' ') + "\r\n";
                            texto_pagare += "Observaciones: " + observaciones_pagares + "\r\n";
                            texto_pagare += "Fecha Vto: " + vencimientos_pagares;

                        }
                    }
                }

                //insertar el cobro

                if (textBox_Cambio.Text == "") { textBox_Cambio.Text = "0"; }
                efectivo_money = Funciones.Resta(efectivo_money, textBox_Cambio.Text).Replace(",", ".");

                string insert_cobro = "INSERT INTO VENALB_COBROS(IdCobro, DetCod, Cantidad, IdVendedor, IdTipoCobro, Fecha, Efectivo, Tarjeta, Talon, Pagare, Deuda, Transferencia) ";
                insert_cobro += " VALUES(" + IdCobro + ", " + detcod + ", " + Importe_Total.Replace(",", ".") + ", " + IdVendedor + ", " + Tipo_Cobro + ", '" + fecha_cobro + "', " + efectivo_money + ", " + tarjeta_money + ", " + talon_money + ", " + pagare_money + ", " + deuda_money + ", " + transferencia_money + ")";

                int res1 = EjecutaNonQuery(insert_cobro);

            }
            else
            {
                //tipo 51
                //texto efectivo
                if (textBox_Efectivo.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            efectivo_money = Funciones.Formatea(textBox_Efectivo.Text).Replace(",", ".");
                            texto_efectivo = "Efectivo......" + Funciones.Formatea(textBox_Efectivo.Text).PadLeft(15, ' ');
                        }
                    }
                }
                //generar deuda
                if (textBox_Deuda.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Deuda.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            deuda_money = Funciones.Formatea(textBox_Deuda.Text).Replace(",", ".");
                            texto_deuda = "Deuda........." + Funciones.Formatea(textBox_Deuda.Text).PadLeft(15, ' ');
                        }
                    }
                }

                //generar COBRO
                IdCobro = Nuevo_Cobro51();

                //insertar el cobro

                string insert_cobro = "INSERT INTO VENALB_COBROS51(IdCobro, DetCod, Cantidad, IdCajero, IdTipoCobro, Fecha, Efectivo, Deuda) ";
                insert_cobro += " VALUES(" + IdCobro + ", " + detcod + ", " + Importe_Total.Replace(",", ".") + ", 0, " + Tipo_Cobro + ", '" + fecha_cobro + "', " + efectivo_money + ", " + deuda_money + ")";

                int res1 = EjecutaNonQuery(insert_cobro);

            }

                //limpieza de deudas

                if (Cuentas != null)
                {
                    for (int x = 0; x < Cuentas.Count; x++)
                    {
                        clase_cuenta dato = (clase_cuenta)Cuentas[x];
                        if (dato.Tipo == "DE")
                        {
                            //anular deuda anterior
                            string update_deuda = "UPDATE DEUDA SET IdCobro=" + IdCobro + ", FechaCobro='" + fecha_cobro + "' ";
                            update_deuda += " WHERE IdDeuda=" + dato.Codigo;

                            int res2 = EjecutaNonQuery(update_deuda);
                        }
                        if (dato.Tipo == "AB")
                        {
                            //amortizar ABONO
                            string update_abono = "UPDATE ABONOS SET IdCobro=" + IdCobro + ", FechaCobro='" + fecha_cobro + "' ";
                            update_abono += " WHERE IdAbono=" + dato.Codigo;

                            int res4 = EjecutaNonQuery(update_abono);
                        }
                        if (dato.Tipo == "CC")
                        {
                            if (textBox_ACuenta.Text != "0,00")
                            {
                                decimal auxiliar = 0;
                                if (Decimal.TryParse(textBox_ACuenta.Text, out auxiliar) == true)
                                {
                                    if (auxiliar > 0)
                                    {
                                        //restar a Saldo la cantidad usada
                                        string nuevo_saldo = Funciones.Resta(dato.Importe, textBox_ACuenta.Text);
                                        string cancelado = "";

                                        if (nuevo_saldo.StartsWith("-"))
                                        {
                                            //importe era insuficiente, era menor que textbox_acuenta
                                            textBox_ACuenta.Text = Funciones.Resta(textBox_ACuenta.Text, dato.Importe);
                                            nuevo_saldo = "0";
                                            cancelado = " , FechaCancelado='" + DateTime.Today.ToShortDateString() + "' ";
                                            dato.Anyo = "-" + dato.Importe;
                                        }
                                        else
                                        {
                                            dato.Anyo = "-" + textBox_ACuenta.Text;
                                        }

                                        //amortizar cobro a cuenta
                                        string update_cuenta = "UPDATE COBROS_CUENTA SET IdCobro=" + IdCobro + ", FechaCobro='" + fecha_cobro + "', Saldo=" + nuevo_saldo.Replace(",", ".") + cancelado;
                                        update_cuenta += " WHERE IdCC=" + dato.Codigo;

                                        int res3 = EjecutaNonQuery(update_cuenta);

                                        //update venalb_cobros
                                        if (TIPO51 == false)
                                        {
                                            string update_cobro = "UPDATE VENALB_COBROS SET IdCC=" + dato.Codigo + ", CC=" + Funciones.Formatea(textBox_ACuenta.Text).Replace(",", ".");
                                            update_cobro += " WHERE IdCobro=" + IdCobro;

                                            int res_cobro = EjecutaNonQuery(update_cobro);
                                        }
                                        else
                                        {
                                        }

                                    }
                                }
                            }
                        }
                        if (dato.Tipo == "AL")
                        {
                            //dar por pagados los albaranes

                            string update_Albaran = "";

                            //leer VenTve del albarán a actualizar
                            string ventve = Lee_VenTve(dato.Codigo, dato.Anyo);

                            if (ventve == "1")
                            {
                                update_Albaran = "UPDATE VENALB_CABE SET VenTve=" + Tipo_Cobro + ", IdCobro=" + IdCobro + ", FechaCobro='" + fecha_cobro + "' ";
                            }
                            else
                            {
                                update_Albaran = "UPDATE VENALB_CABE SET IdCobro=" + IdCobro + ", FechaCobro='" + fecha_cobro + "' ";
                            }
                            
                            update_Albaran += " WHERE Anyo=" + dato.Anyo + " AND VenAlb=" + dato.Codigo;

                            int res4 = EjecutaNonQuery(update_Albaran);
                        }
                    }
                }

                for (int retardo = 0; retardo < 10000; retardo++)
                {
                }


            //generar RECIBO con nombre {IdCobro}.txt
                if (TIPO51 == false)
                {
                    try
                    {
                        string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\RECIBOS\\" + IdCobro + ".txt";

                        TextWriter tw = new StreamWriter(fichero);

                        string texto_archivo = "";
                        string linea = "JOSE CARABAL, S.L.";
                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";
                        linea = "Mercavalencia, Modulos 12-13";
                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";
                        linea = "46013 VALENCIA";
                        tw.WriteLine(linea); tw.WriteLine(""); texto_archivo += linea + "\r\n\r\n";

                        linea = "Recibo  " + IdCobro + "  " + DateTime.Today.ToShortDateString(); //if (TIPO51 == true) { linea = "Recibo  " + IdCobro + "  " + DateTime.Today.ToShortDateString(); }
                        tw.WriteLine(linea); tw.WriteLine(""); texto_archivo += linea + "\r\n\r\n";

                        linea = "Cliente " + detcod;
                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

                        linea = "        " + nombre_cliente; if (TIPO51 == true) { linea = "        *" + nombre_cliente + "*"; }
                        tw.WriteLine(linea); tw.WriteLine(""); texto_archivo += linea + "\r\n\r\n";

                        linea = " FECHA          ALBARAN   IMPORTE";
                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

                        linea = "=================================";
                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

                        for (int x = 0; x < Cuentas.Count; x++)
                        {
                            clase_cuenta dato = (clase_cuenta)Cuentas[x];
                            if (dato.Tipo == "AB")
                            {
                                linea = dato.Fecha + "      " + "ABONO" + "  " + dato.Importe.PadLeft(8, ' ');
                            }
                            if (dato.Tipo == "AL")
                            {
                                linea = dato.Fecha + "      " + dato.Codigo + "  " + dato.Importe.PadLeft(8, ' ');
                            }
                            if (dato.Tipo == "CC")
                            {
                                linea = dato.Fecha + "      CC      " + dato.Anyo.PadLeft(8, ' ');
                            }
                            if (dato.Tipo == "DE")
                            {
                                linea = dato.Fecha + "      DE      " + dato.Importe.PadLeft(8, ' ');
                            }
                            tw.WriteLine(linea); texto_archivo += linea + "\r\n";
                        }

                        linea = "\r\nTotal.....     " + Importe_Total.PadLeft(14, ' '); //24 de anchura
                        tw.WriteLine(linea); texto_archivo += "\r\n" + linea + "\r\n";

                        if (texto_efectivo != "")
                        {
                            tw.WriteLine(texto_efectivo); texto_archivo += texto_efectivo + "\r\n";
                        }

                        if (textBox_Cambio.Text != "")
                        {
                            tw.WriteLine("Cambio........" + textBox_Cambio.Text.PadLeft(15, ' ')); texto_archivo += "Cambio........" + textBox_Cambio.Text + "\r\n";
                        }

                        if (texto_transferencia != "")
                        {
                            tw.WriteLine(texto_transferencia); texto_archivo += texto_transferencia + "\r\n";
                        }

                        if (texto_talon != "")
                        {
                            tw.WriteLine(texto_talon); texto_archivo += texto_talon + "\r\n";
                        }

                        if (texto_tarjeta != "")
                        {
                            tw.WriteLine(texto_tarjeta); texto_archivo += texto_tarjeta + "\r\n";
                        }

                        if (texto_deuda != "")
                        {
                            tw.WriteLine(texto_deuda); texto_archivo += texto_deuda + "\r\n";
                        }

                        if (texto_pagare != "")
                        {
                            tw.WriteLine(texto_pagare); texto_archivo += texto_pagare + "\r\n";
                        }


                        //Añadir 6 líneas en blanco
#if !DEBUG
                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
                        texto_archivo += "\r\n\r\n\r\n\r\n\r\n\r\n";
#endif
                        tw.Close();


                        //Imprimir 2 RECIBOS (uno para el cliente y otro para uso propio)

                        printDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                        string impresora = frmInicioCaja.RUTA_RECIBOS;
                        if (impresora == "") { impresora = printDialog1.PrinterSettings.PrinterName; }

                        AbreCajon(impresora);
                        RawPrinterHelper.SendFileToPrinter(impresora, fichero);
                        CortaTicket(impresora);


#if !DEBUG
                        AbreCajon(impresora);
                        RawPrinterHelper.SendStringToPrinter(impresora, texto_archivo);
                        CortaTicket(impresora);
#endif

                        MessageBox.Show("Impreso recibo " + IdCobro);


                        /*
                        System.Drawing.Font printFont; printFont = new System.Drawing.Font("Arial", 8);
                        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(fichero);
                        psi.Verb = "PRINT";                
                
                        Process.Start(psi);
                        */

                        /*
                        textBox1.Text = texto_archivo;
                        Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
                        //System.Globalization.CultureInfo.                
                        CultureInfo newCulture = new CultureInfo("es-ES", false);
                        Thread.CurrentThread.CurrentCulture = newCulture;
                        Thread.CurrentThread.CurrentUICulture = newCulture;
                        excel.Application.Workbooks.Add(true);

                        int rowIndex = 1;
                        if (textBox1.Lines.Length > 0)
                        {
                            foreach (string linea1 in textBox1.Lines)
                            {
                                if (linea1 != "")
                                {
                                    excel.Cells[rowIndex, 1] = linea1;
                                }

                                rowIndex++;
                            }
                        }

                        excel.Visible = true;
                        Microsoft.Office.Interop.Excel._Worksheet worksheet = (Worksheet)excel.ActiveSheet;

                        //worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                        //worksheet.PrintOut(Type.Missing, Type.Missing, 1, false, printDialog1.PrinterSettings.PrinterName, false, false, Type.Missing);

                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(worksheet);
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excel);*/
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
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

        private void Totalizar()
        {
            //calcular cifras
            string total = Importe_Total;
            decimal auxiliar = 0;

            if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Efectivo.Text); textBox_Cambio.Text = "";
                if (total.StartsWith("-") == true)
                {
                    //total negativo, se ha dado más efectivo que Total, dar el Cambio
                    textBox_Cambio.Text = total.Substring(1);
                    total = "0,00";
                }
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
                    string importe_pagare= gPagares.Rows[x].Cells[6].Value.ToString();

                    textBox_Pagare.Text = Funciones.Suma(textBox_Pagare.Text, importe_pagare);
                }
            }

            if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
            {
                total = Funciones.Resta(total, textBox_Pagare.Text);
            }

            if (textBox_ACuenta.Visible == true)
            {
                if (Decimal.TryParse(textBox_ACuenta.Text, out auxiliar) == true)
                {
                    total = Funciones.Resta(total, textBox_ACuenta.Text);
                    if (total.StartsWith("-") == true)
                    {
                        //total negativo, puede que se haya dado más efectivo que Total, dar el Cambio
                        textBox_Cambio.Text = total.Substring(1);
                        total = "0,00";
                    }
                }
            }

            textBox_Deuda.Text = Funciones.Formatea(total);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Totalizar();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void textBox_Pagare_TextChanged(object sender, EventArgs e)
        {
            //si se escribe algo que sea un número superior a 0, se bloquea botón y desbloquea vencimiento
            /*
            decimal auxiliar = 0;
            if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
            {
                if (auxiliar > 0)
                {
                    button_Aceptar.Enabled = false;
                    textBox_Vencimiento.ReadOnly = false;
                }
                if (auxiliar == 0)
                {
                    button_Aceptar.Enabled = true;
                    textBox_Vencimiento.ReadOnly = true;
                }
            }*/
        }

        private void textBox_Vencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar.ToString() == "\r")
            {
                //si es una fecha válida se desbloquea botón
                if (textBox_Vencimiento.Text != "")
                {
                    if (textBox_Vencimiento.Text != "*")
                    {
                        button_Aceptar.Enabled = false;
                        DateTime resultado = new DateTime(2000, 1, 1);
                        if (DateTime.TryParse(textBox_Vencimiento.Text, out resultado) == true)
                        {
                            if (resultado.Year > 2000)
                            {
                                textBox_Vencimiento.Text = resultado.Day.ToString() + "/" + resultado.Month.ToString() + "/" + resultado.Year.ToString();
                                button_Aceptar.Enabled = true;
                            }
                        }
                        else
                        {
                            textBox_Vencimiento.Text = textBox_Vencimiento.Text + "/" + DateTime.Today.Year.ToString();
                            if (DateTime.TryParse(textBox_Vencimiento.Text, out resultado) == true)
                            {
                                button_Aceptar.Enabled = true;
                            }
                        }
                    }
                }
            }*/
        }

        private void textBox_Efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //saltar al siguiente
            if (e.KeyChar.ToString() == "\r")
            {
                textBox_Transferencia.Focus();
            }
        }

        private void textBox_Transferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //saltar al siguiente
            if (e.KeyChar.ToString() == "\r")
            {
                textBox_Talon.Focus();
            }
        }

        private void textBox_Talon_KeyPress(object sender, KeyPressEventArgs e)
        {
            //saltar al siguiente
            if (e.KeyChar.ToString() == "\r")
            {
                textBox_Tarjeta.Focus();
            }
        }

        private void textBox_Tarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //saltar al siguiente
            if (e.KeyChar.ToString() == "\r")
            {
                textBox_Pagare.Focus();
            }
        }

        private void textBox_Pagare_KeyPress(object sender, KeyPressEventArgs e)
        {
            //foco en botón Aceptar
            if (e.KeyChar.ToString() == "\r")
            {
                button_Aceptar.Focus();
            }
        }

        private void textBox_Efectivo_Enter(object sender, EventArgs e)
        {
            textBox_Efectivo.BackColor = Color.Yellow;
        }

        private void textBox_Efectivo_Leave(object sender, EventArgs e)
        {
            textBox_Efectivo.BackColor = Color.White;
            
            decimal auxiliar = 0;

            if (Decimal.TryParse(textBox_Efectivo.Text, out auxiliar) == true)
            {
                if (auxiliar < 0)
                {
                    textBox_Efectivo.BackColor = Color.Pink;
                }
            }
        }

        private void textBox_Transferencia_Enter(object sender, EventArgs e)
        {
            textBox_Transferencia.BackColor = Color.Yellow;
        }

        private void textBox_Transferencia_Leave(object sender, EventArgs e)
        {
            textBox_Transferencia.BackColor = Color.White;
        }

        private void textBox_Talon_Enter(object sender, EventArgs e)
        {
            textBox_Talon.BackColor = Color.Yellow;
        }

        private void textBox_Talon_Leave(object sender, EventArgs e)
        {
            textBox_Talon.BackColor = Color.White;
        }

        private void textBox_Tarjeta_Enter(object sender, EventArgs e)
        {
            textBox_Tarjeta.BackColor = Color.Yellow;
        }

        private void textBox_Tarjeta_Leave(object sender, EventArgs e)
        {
            textBox_Tarjeta.BackColor = Color.White;
        }

        private void textBox_Pagare_Enter(object sender, EventArgs e)
        {
            //textBox_Pagare.BackColor = Color.Yellow;
        }

        private void textBox_Pagare_Leave(object sender, EventArgs e)
        {
            //textBox_Pagare.BackColor = Color.White;
        }

        private void textBox_Obs_Talon_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Talon.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Talon_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Talon.BackColor = Color.White;
        }

        private void textBox_Obs_Transferencia_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Transferencia.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Transferencia_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Transferencia.BackColor = Color.White;
        }

        private void textBox_Obs_Tarjeta_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Tarjeta.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Tarjeta_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Tarjeta.BackColor = Color.White;
        }

        private void textBox_Obs_Deuda_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Deuda.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Deuda_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Deuda.BackColor = Color.White;
        }

        private void button_Pagares_Click(object sender, EventArgs e)
        {
            /*frmCobros2 Cobro_Pagares = new frmCobros2();
            Cobro_Pagares.DATOS_PAGARES = DATOS_PAGARES;
            Cobro_Pagares.detcod = detcod;
            if (Cobro_Pagares.ShowDialog() == DialogResult.OK)
            {
                DATOS_PAGARES = Cobro_Pagares.DATOS_PAGARES;
                INSERT_PAGARES = Cobro_Pagares.INSERT_PAGARES;
                textBox_Pagare.Text = Cobro_Pagares.Total;
                textBox_Pagare.Enabled = false; //se bloquea
                //vencimiento
                textBox_Vencimiento.Text = "*"; //usamos este código para indicar que los datos están en el otro form
            }*/
        }

        private void textBox_Vencimiento_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox_Vencimiento.Text == "*")
            {
                button_Aceptar.Enabled = true;
            }*/
        }

        private void textBox_ACuenta_TextChanged(object sender, EventArgs e)
        {
            //comprobar que no se supera el TOPE
            if (TOPE_CUENTA != "")
            {
                decimal tope = 0;
                if (Decimal.TryParse(TOPE_CUENTA, out tope))
                {
                    decimal valor = 0;
                    if (Decimal.TryParse(textBox_ACuenta.Text, out valor))
                    {
                        //comprobamos
                        if (valor > tope)
                        {
                            textBox_ACuenta.Text = TOPE_CUENTA;
                        }
                    }
                }
            }
        }

        private void gPagares_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //comprobar si se ha clicado sobre el botón de cobrar pagaré
            if (e.ColumnIndex == 8)
            {

            }
        }

    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }

}
