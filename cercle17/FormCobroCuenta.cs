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
    public partial class FormCobroCuenta : Form
    {
        public FormCobroCuenta()
        {
            InitializeComponent();
        }

        public string detcod, fecha_actual, detnom;
        public SqlConnection myConnection;

        private void FormCobroCuenta_Load(object sender, EventArgs e)
        {
            label_Cliente.Visible = false;

            //cargamos datos de detallista y fecha
            if (detcod != "")
            {
                textBox_DetCod.Text = detcod;
            }
            if (fecha_actual != "")
            {
                textBox_Fecha.Text = fecha_actual;
            }

            //foco
            textBox_Importe.Select();
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
            //comprobar si existe el detallista
            if (e.KeyChar.ToString() == "\r")
            {
                bool encontrado = false;
                string consulta = "SELECT * FROM DETALLISTAS WHERE DetCod=" + textBox_DetCod.Text;

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        encontrado = true;
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (encontrado == true)
                {
                    label_Cliente.Visible = false;
                    button_Aceptar.Enabled = true;
                }
                else
                {
                    label_Cliente.Visible = true;
                    button_Aceptar.Enabled = false;
                }
            }
        }

        private void textBox_Fecha_Enter(object sender, EventArgs e)
        {
            textBox_Fecha.BackColor = Color.Yellow;
        }

        private void textBox_Fecha_Leave(object sender, EventArgs e)
        {
            textBox_Fecha.BackColor = Color.White;
        }

        private void textBox_Fecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //comprobar si la fecha es válida
            if (e.KeyChar.ToString() == "\r")
            {
                //si es una fecha válida se desbloquea botón
                if (textBox_Fecha.Text != "")
                {
                    button_Aceptar.Enabled = false;
                    DateTime resultado = new DateTime(2000, 1, 1);
                    if (DateTime.TryParse(textBox_Fecha.Text, out resultado) == true)
                    {
                        if (resultado.Year > 2000)
                        {
                            textBox_Fecha.Text = resultado.Day.ToString() + "/" + resultado.Month.ToString() + "/" + resultado.Year.ToString();
                            button_Aceptar.Enabled = true;
                        }
                    }
                    else
                    {
                        textBox_Fecha.Text = textBox_Fecha.Text + "/" + DateTime.Today.Year.ToString();
                        if (DateTime.TryParse(textBox_Fecha.Text, out resultado) == true)
                        {
                            button_Aceptar.Enabled = true;
                        }
                    }
                }
            }
        }

        private void textBox_Importe_Enter(object sender, EventArgs e)
        {
            textBox_Importe.BackColor = Color.Yellow;
        }

        private void textBox_Importe_Leave(object sender, EventArgs e)
        {
            textBox_Importe.BackColor = Color.White;
        }

        private void textBox_Observaciones_Enter(object sender, EventArgs e)
        {
            textBox_Observaciones.BackColor = Color.Yellow;
        }

        private void textBox_Observaciones_Leave(object sender, EventArgs e)
        {
            textBox_Observaciones.BackColor = Color.White;
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //importe
                if (textBox_Importe.Text != "")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Importe.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            textBox_Importe.Text = Funciones.Formatea(textBox_Importe.Text).Replace(",", ".");
                        }
                    }
                }
                //detcod
                if (textBox_DetCod.Text != "")
                {
                    //insertar cobro

                    string insert = "INSERT INTO COBROS_CUENTA(DetCod, FechaRecibido, Importe, Saldo, Observaciones) ";
                    insert += " VALUES(" + textBox_DetCod.Text + ", '" + textBox_Fecha.Text + "', " + textBox_Importe.Text + ", " + textBox_Importe.Text + ", '" + textBox_Observaciones.Text.Replace("'", "''") + "')";

                    SqlCommand myCommand = new SqlCommand(insert, myConnection);
                    int res = myCommand.ExecuteNonQuery();

                    if (res == 1)
                    {
                        MessageBox.Show("El cobro a cuenta ha sido almacenado");

                        //imprimir recibo
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

                            linea = DateTime.Today.ToShortDateString();
                            tw.WriteLine(linea); tw.WriteLine("");

                            linea = "Cliente " + detcod;
                            tw.WriteLine(linea);

                            linea = "        " + detnom;
                            tw.WriteLine(linea); tw.WriteLine("");

                            linea = " Entregado a cuenta: " + textBox_Importe.Text;
                            tw.WriteLine(linea);

                            linea = " ";
                            tw.WriteLine(linea);

                            if (textBox_Observaciones.Text != "")
                            {
                                linea = " Observaciones: " + textBox_Observaciones.Text;
                                tw.WriteLine(linea);
                            }

                            //Añadir 6 líneas en blanco (para la versión Release)
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

                            //si se compila como Release se imprimen dos copias:

#if !DEBUG
                            AbreCajon(impresora);
                            RawPrinterHelper.SendFileToPrinter(impresora, fichero);
                            CortaTicket(impresora);
#endif
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }          

                    }
                    else
                    {
                        MessageBox.Show("Error. No se pudo registrar el cobro a cuenta");
                    }
                }
                else
                {
                    MessageBox.Show("No se ha dado código de cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
