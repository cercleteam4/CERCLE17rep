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
    public partial class frmPagares : Form
    {
        public frmPagares()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public string IdVendedor;

        private void Cargar()
        {
            ArrayList Lista_Pagares = new ArrayList();
            string select = "SELECT * FROM PAGARES WHERE Cobrado='N' ORDER BY FVencto, IdPagare";
            
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

                    bool agregar = true;

                    if (textBox_CodCliente.Text != "")
                    {
                        if (pagare.Detallista != textBox_CodCliente.Text)
                        {
                            agregar = false;
                        }
                    }

                    if (agregar == true)
                    {
                        Lista_Pagares.Add(pagare);
                    }

                }
                myReader.Close();

                gPagares.DataSource = Lista_Pagares;

                if (gPagares.Rows.Count > 0)
                {
                    gPagares.Columns[0].Visible = false;
                    gPagares.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[2].Visible = false;
                    gPagares.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[5].Visible = false;
                    gPagares.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    gPagares.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmPagares_Load(object sender, EventArgs e)
        {
            Cargar();
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
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

//        private void gPagares_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            //comprobar si se ha clicado sobre el botón de cobrar pagaré
//            if (e.ColumnIndex == 8)
//            {
//                string idpagare = gPagares.Rows[e.RowIndex].Cells[0].Value.ToString();
//                string detcod = gPagares.Rows[e.RowIndex].Cells[1].Value.ToString();
//                string fecha_Vto = gPagares.Rows[e.RowIndex].Cells[4].Value.ToString();
//                string Importe_Total = gPagares.Rows[e.RowIndex].Cells[6].Value.ToString();
//                string Tipo_Cobro = "3";
//                bool cobrarse = true;

//                //comprobar que la fecha de vencimiento no sea superior a la actual (todavía no ha vencido)
//                DateTime fecha_vencimiento = new DateTime(2000, 1, 1);
//                if (DateTime.TryParse(fecha_Vto, out fecha_vencimiento) == true)
//                {
//                    //comprobar
//                    /*if (DateTime.Compare(DateTime.Today, fecha_vencimiento.AddDays(-2)) < 0)
//                    {
//                        MessageBox.Show("No puede cobrarse un pagaré cuya fecha de vencimiento todavía no ha llegado");
//                        cobrarse = false;
//                    }
//                    else
//                    {
//                        //nada, seguimos
//                    }*/

//                    if (cobrarse == true)
//                    {
//                        //pedir confirmación
//                        if (MessageBox.Show("¿Desea hacer efectivo el cobro del Pagaré?", "Confirmar", MessageBoxButtons.OKCancel) == DialogResult.OK)
//                        {
//                            //introducir fecha de cobro
//                            bool fecha_valida = false;
//                            bool cancelar = false;

//                            do
//                            {
//                                frmCobrarPagareFecha PagareFecha = new frmCobrarPagareFecha();

//                                if (PagareFecha.ShowDialog() == DialogResult.OK)
//                                {
//                                    //comprobar la validez de la fecha
//                                    if (PagareFecha.Fecha_Cobro != "")
//                                    {
//                                        DateTime resultado = new DateTime(2000, 1, 1);
//                                        if (DateTime.TryParse(PagareFecha.Fecha_Cobro, out resultado) == true)
//                                        {
//                                            if (resultado.Year > 2000)
//                                            {
//                                                fecha_valida = true;

//                                                //generar COBRO
//                                                string IdCobro = Nuevo_Cobro();
//                                                string insert_cobro = "INSERT INTO VENALB_COBROS(IdCobro, DetCod, Cantidad, IdVendedor, IdTipoCobro, Fecha, Pagare) ";
//                                                insert_cobro += " VALUES(" + IdCobro + ", " + detcod + ", " + Importe_Total.Replace(",", ".") + ", " + IdVendedor + ", " + Tipo_Cobro + ", '" + PagareFecha.Fecha_Cobro + "', " + Importe_Total.Replace(",", ".") + ")";

//                                                int res1 = EjecutaNonQuery(insert_cobro);

//                                                //se tienen que dar por cobrados los albaranes asociados al pagaré, si los hubiese

//                                                string update_albaranes = "UPDATE VENALB_CABE SET FechaCobro='" + resultado.ToShortDateString() + "', IdCobro=" + IdCobro + " WHERE IdPagare=" + idpagare;

//                                                int res2 = EjecutaNonQuery(update_albaranes);

//                                                if (res2 > 0)
//                                                {
//                                                    //generar un recibo

//                                                    try
//                                                    {
//                                                        string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\RECIBOS\\" + IdCobro + ".txt";

//                                                        TextWriter tw = new StreamWriter(fichero);

//                                                        string texto_archivo = "";
//                                                        string linea = "JOSE CARABAL, S.L.";
//                                                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";
//                                                        linea = "Mercavalencia, Modulos 12-13";
//                                                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";
//                                                        linea = "46013 VALENCIA";
//                                                        tw.WriteLine(linea); tw.WriteLine(""); texto_archivo += linea + "\r\n\r\n";

//                                                        linea = "Recibo  " + IdCobro + "  PAGARE  " + DateTime.Today.ToShortDateString(); //if (TIPO51 == true) { linea = "Recibo  " + IdCobro + "  " + DateTime.Today.ToShortDateString(); }
//                                                        tw.WriteLine(linea); tw.WriteLine(""); texto_archivo += linea + "\r\n\r\n";

//                                                        linea = "Cliente " + detcod;
//                                                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

//                                                        linea = " FECHA          ALBARAN   IMPORTE";
//                                                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

//                                                        linea = "=================================";
//                                                        tw.WriteLine(linea); texto_archivo += linea + "\r\n";

//                                                        string select_albaranes = "SELECT VenFec, VenAlb, VenTot FROM VENALB_CABE WHERE IdPagare=" + idpagare;


//                                                        SqlDataReader myReader = null;
//                                                        SqlCommand myCommand = new SqlCommand(select_albaranes, myConnection);
//                                                        myReader = myCommand.ExecuteReader();
//                                                        while (myReader.Read())
//                                                        {
//                                                            string fecha = myReader["VenFec"].ToString(); if (fecha.Contains(' ')) { fecha = fecha.Substring(0, fecha.IndexOf(' ')); }

//                                                            linea = fecha + "      " + myReader["VenAlb"].ToString() + "  " + Funciones.Formatea(myReader["VenTot"].ToString()).PadLeft(8, ' ');

//                                                            tw.WriteLine(linea); texto_archivo += linea + "\r\n";
//                                                        }
//                                                        myReader.Close();

//                                                        linea = "\r\nTotal.....     " + Importe_Total.PadLeft(14, ' '); //24 de anchura
//                                                        tw.WriteLine(linea); texto_archivo += "\r\n" + linea + "\r\n";


//                                                        //Añadir 6 líneas en blanco
//#if !DEBUG
//                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
//                        tw.WriteLine(""); tw.WriteLine(""); tw.WriteLine("");
//                        texto_archivo += "\r\n\r\n\r\n\r\n\r\n\r\n";
//#endif
//                                                        tw.Close();

//                                                        printDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
//                                                        string impresora = frmInicioCaja.RUTA_RECIBOS;
//                                                        if (impresora == "") { impresora = printDialog1.PrinterSettings.PrinterName; }

//                                                        AbreCajon(impresora);
//                                                        RawPrinterHelper.SendFileToPrinter(impresora, fichero);
//                                                        CortaTicket(impresora);
//                                                    }
//                                                    catch (System.Exception ex)
//                                                    {
//                                                        MessageBox.Show(ex.ToString());
//                                                    }

//                                                }

//                                                //se dan por cobrados los abonos asociados, si los hubiese
//                                                string update_abonos = "UPDATE ABONOS SET FechaCobro='" + resultado.ToShortDateString() + "', IdCobro=" + IdCobro + " WHERE IdPagare=" + idpagare;
//                                                int res3 = EjecutaNonQuery(update_abonos);

//                                                //update
//                                                string update = "UPDATE PAGARES SET Cobrado='S', FechaCobro='" + resultado.ToShortDateString() + "', IdCobro=" + IdCobro;
//                                                update += "  WHERE IdPagare=" + idpagare;

//                                                int res = EjecutaNonQuery(update);

//                                                Cargar();
//                                            }
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    cancelar = true;
//                                }

//                                if (fecha_valida == false)
//                                {
//                                    MessageBox.Show("No se ha introducido fecha válida");
//                                }

//                            }
//                            while (fecha_valida == false && cancelar == false);

//                        }
//                        else
//                        {
//                            if (MessageBox.Show("¿Desea pasar a Deuda el importe del Pagaré más los gastos?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
//                            {
//                                //preguntar importe de los gastos
//                                string gastos_sumables = "0,00";
//                                bool importe_valido = false;
//                                bool cancelar = false;

//                                do
//                                {
//                                    frmPagareDeuda DeudaPagare = new frmPagareDeuda();

//                                    if (DeudaPagare.ShowDialog() == DialogResult.OK)
//                                    {
//                                        //comprobar la validez
//                                        if (DeudaPagare.gastos != "0,00")
//                                        {
//                                            decimal auxiliar = 0;
//                                            if (Decimal.TryParse(DeudaPagare.gastos, out auxiliar) == true)
//                                            {
//                                                if (auxiliar > 0)
//                                                {
//                                                    importe_valido = true;
//                                                    gastos_sumables = DeudaPagare.gastos;
//                                                }
//                                            }
//                                        }
//                                        else
//                                        { importe_valido = true; }  //cero también será válido

//                                        if (importe_valido == true)
//                                        {
//                                            //generamos la deuda de Importe_Total + gastos
//                                            Importe_Total = Funciones.Suma(Importe_Total, gastos_sumables);

//                                            string insert_deuda = "INSERT INTO DEUDA(DetCod, Fecha, Importe, Observaciones) ";
//                                            insert_deuda += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', " + Importe_Total.Replace(",", ".") + ", 'Pagaré no cobrado, más gastos bancarios')";

//                                            int res1 = EjecutaNonQuery(insert_deuda);

//                                            //update
//                                            string update = "UPDATE PAGARES SET Cobrado='S' ";
//                                            update += "  WHERE IdPagare=" + idpagare;

//                                            int res = EjecutaNonQuery(update);

//                                            Cargar();
//                                        }

//                                    }
//                                    else
//                                    {
//                                        cancelar = true;
//                                    }

//                                    if (importe_valido == false)
//                                    {
//                                        MessageBox.Show("No se ha introducido un importe de gastos válido");
//                                    }

//                                }
//                                while (importe_valido == false && cancelar == false);

//                            }
//                        }
//                    }

//                }

//            }
//        }

        private void textBox_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Cargar();
            }
        }

        private void Eliminar(object sender, EventArgs e)
        {
            DataGridViewCellCollection fila = (DataGridViewCellCollection)((ToolStripMenuItem)sender).Tag;

            string idpagare = fila[0].Value.ToString();
            string detcod = fila[1].Value.ToString();
            string vencimiento = fila[4].Value.ToString();

            if (MessageBox.Show("¿Desea eliminar el pagaré del Detallista '" + detcod + "' con Vencimiento en '" + vencimiento + "' ?", "Confirmar borrado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //delete y recarga

                string delete = "DELETE FROM PAGARES WHERE IdPagare=" + idpagare;

                int res = EjecutaNonQuery(delete);

                if (res == 1)
                {
                    MessageBox.Show("El pagaré ha sido borrado con éxito");
                    Cargar();
                }
                else
                {
                    MessageBox.Show("Problema al intentar borrar el pagaré");
                }

            }
        }

        private void button_Crear_Click(object sender, EventArgs e)
        {
            frmNuevoPagare NuevoPagare = new frmNuevoPagare();
            NuevoPagare.codcliente = textBox_CodCliente.Text;
            NuevoPagare.adosado = false;
            NuevoPagare.myConnection = myConnection;

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
                Cargar();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (gPagares.SelectedCells[0].RowIndex >= 0)
            {
                DataGridViewCellCollection fila = gPagares.Rows[gPagares.SelectedCells[0].RowIndex].Cells;
                contextMenuStrip1.Items.Clear();
                ToolStripMenuItem item = new ToolStripMenuItem("Borrar Pagaré", null, Eliminar);
                item.Tag = fila;
                contextMenuStrip1.Items.Add(item);
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
    }

}
