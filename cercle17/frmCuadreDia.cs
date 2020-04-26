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
    public partial class frmCuadreDia : Form
    {
        public frmCuadreDia()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        
        //estos procesos leen las cantidades para el día en Fecha

        private void Cobros_Efectivo()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Efectivo.Text = "0,00";

            string consulta = "SELECT SUM(Efectivo) FROM FACTV_COBROS WHERE Fecha='" + textBox_Fecha.Text + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Efectivo.Text = Funciones.Formatea(myReader[0].ToString());
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cobros_Pagares()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Pagares.Text = "0,00";

            string consulta = "SELECT SUM(Importe) FROM PAGARES WHERE FechaCobro='" + textBox_Fecha.Text + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Pagares.Text = Funciones.Formatea(myReader[0].ToString());
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cobros_Talones()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Talones.Text = "0,00";

            string consulta = "SELECT SUM(Importe) FROM TALONES WHERE FechaCobro='" + textBox_Fecha.Text + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Talones.Text = Funciones.Formatea(myReader[0].ToString());
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cobros_Tarjetas()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Tarjeta.Text = "0,00";

            string consulta = "SELECT SUM(Importe) FROM CREDIT_CARDS WHERE FechaCobro='" + textBox_Fecha.Text + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Tarjeta.Text = Funciones.Formatea(myReader[0].ToString());
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cobros_Transferencias()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Transferencia.Text = "0,00";

            string consulta = "SELECT SUM(Importe) FROM TRANSFERENCIAS WHERE FechaCobro='" + textBox_Fecha.Text + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Transferencia.Text = Funciones.Formatea(myReader[0].ToString());
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //estos procesos leen las observaciones para añadirlas al grid

        private string Leer_Talon(string idcobro)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string resultado = "";

            string strQ = "SELECT * FROM TALONES WHERE IdCobroFact=" + idcobro;
            
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string vencimiento = myReader["Fecha"].ToString(); if (vencimiento.Contains(' ')) { vencimiento = vencimiento.Substring(0, vencimiento.IndexOf(' ')); }
                    resultado += "Vencimiento: " + vencimiento + ". ";
                    resultado += myReader["Observaciones"].ToString();
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private string Leer_Tarjeta(string idcobro)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string resultado = "";

            string strQ = "SELECT * FROM CREDIT_CARDS WHERE IdCobroFact=" + idcobro;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado += myReader["Observaciones"].ToString();
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private string Leer_Transferencia(string idcobro)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string resultado = "";

            string strQ = "SELECT * FROM TRANSFERENCIAS WHERE IdCobroFact=" + idcobro;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado += myReader["Observaciones"].ToString();
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private string Leer_Pagare(string idcobro)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string resultado = "";

            string strQ = "SELECT * FROM PAGARES WHERE IdCobroFact=" + idcobro;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string vencimiento = myReader["FVencto"].ToString(); if (vencimiento.Contains(' ')) { vencimiento = vencimiento.Substring(0, vencimiento.IndexOf(' ')); }

                    resultado += "Vencimiento: " + vencimiento + ". ";
                    resultado += myReader["Observaciones"].ToString();
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        //este es el proceso principal

        private void Carga_Datos_Dia()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string strQ = "SELECT FCO.*, D.DetNom FROM FACTV_COBROS FCO, FACTV_CABE FCA, DETALLISTAS D WHERE FCO.Fecha='" + textBox_Fecha.Text + "' and FCO.Factura=FCA.Factura AND FCO.Serie=FCA.Serie AND FCO.Anyo=FCA.Anyo AND FCA.DetCod=D.DetCod";
            ArrayList Detalles = new ArrayList();

            string total_importes = "0";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    detalle_linea_cobro linea = new detalle_linea_cobro();

                    linea.Cobro = myReader["IdCobroFact"].ToString();
                    linea.Detallista = myReader["DetNom"].ToString();
                    linea.Factura = myReader["Factura"].ToString();
                    linea.Importe = "0";
                    linea.Medio = "";
                    linea.Observaciones = "";

                    string efectivo = Funciones.Formatea(myReader["Efectivo"].ToString());
                    string talon = Funciones.Formatea(myReader["Talon"].ToString());
                    string pagare = Funciones.Formatea(myReader["Pagare"].ToString());
                    string tarjeta = Funciones.Formatea(myReader["Tarjeta"].ToString());
                    string transferencia = Funciones.Formatea(myReader["Transferencia"].ToString());
                    string observaciones = myReader["Observaciones"].ToString();
                    string vencimiento = myReader["Vencimiento"].ToString();

                    if (efectivo != "0,00")
                    {
                        linea.Importe = efectivo;
                        linea.Medio = "Efectivo";
                        linea.Observaciones = observaciones;
                    }
                    else
                    {
                        if (talon != "0,00")
                        {
                            linea.Importe = talon;
                            linea.Medio = "Talón";
                            linea.Observaciones = observaciones;
                        }
                        else
                        {
                            if (tarjeta != "0,00")
                            {
                                linea.Importe = tarjeta;
                                linea.Medio = "Tarjeta";
                            }
                            else
                            {
                                if (transferencia != "0,00")
                                {
                                    linea.Importe = transferencia;
                                    linea.Medio = "Transferencia";
                                }
                                else
                                {
                                    if (pagare != "0,00")
                                    {
                                        linea.Importe = pagare;
                                        linea.Medio = "Pagaré";
                                    }
                                    else
                                    {
                                        linea.Medio = "Desconocido";
                                    }
                                }
                            }
                        }
                    }

                    total_importes = Funciones.Suma(total_importes, linea.Importe);

                    Detalles.Add(linea);
                }
                myReader.Close();

                dataGridView1.DataSource = Detalles;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        //proceso de lectura de observaciones en las tablas que corresponden a cada forma de pago
                        string idcobro = dataGridView1.Rows[x].Cells[0].Value.ToString();
                        string medio = dataGridView1.Rows[x].Cells[4].Value.ToString();

                        switch (medio)
                        {
                            case "Talón":
                                dataGridView1.Rows[x].Cells[5].Value += "  " + Leer_Talon(idcobro);
                                break;
                            case "Tarjeta":
                                dataGridView1.Rows[x].Cells[5].Value = Leer_Tarjeta(idcobro);
                                break;
                            case "Transferencia":
                                dataGridView1.Rows[x].Cells[5].Value = Leer_Transferencia(idcobro);
                                break;
                            case "Pagaré":
                                dataGridView1.Rows[x].Cells[5].Value = Leer_Pagare(idcobro);
                                break;
                            default:
                                break;
                        }


                    }

                }

                //escribimos el total de importes
                textBox_Total.Text = total_importes;

                //leemos para llenar las casillas
                Cobros_Efectivo();
                Cobros_Pagares();
                Cobros_Talones();
                Cobros_Tarjetas();
                Cobros_Transferencias();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmCuadreDia_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Fecha.Text = DateTime.Today.ToShortDateString();
            Carga_Datos_Dia();
        }

        private void Restaurar_fecha()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Fecha.Text = DateTime.Today.ToShortDateString();
        }

        private bool Comprobar_Cobros(string fecha)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            bool resultado = false;

            string comprobar = "SELECT * FROM FACTV_COBROS WHERE Fecha='" + fecha + "'";
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(comprobar, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado = true;   //Sí que tenemos ventas para esta fecha
                }
                myReader.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        private void textBox_Fecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (e.KeyChar.ToString() == "\r")
            {
                //comprobar si es fecha válida
                bool valida = false;
                bool superior = false;
                bool tiene_datos = false;
                DateTime resultado = new DateTime(2000, 1, 1);
                if (DateTime.TryParse(textBox_Fecha.Text, out resultado) == true)
                {
                    if (resultado.Year > 2000)
                    {
                        valida = true;
                        //comprobar si es superior al día de hoy
                        if (resultado.CompareTo(DateTime.Today) > 0)
                        {
                            superior = true;
                        }
                        //comprobar si tiene datos de cobros
                        string CobroFecha = resultado.Day.ToString() + "/" + resultado.Month.ToString() + "/" + resultado.Year.ToString();
                        tiene_datos = Comprobar_Cobros(CobroFecha);
                    }
                }

                if (valida == true)
                {
                    if (superior == false)
                    {
                        if (tiene_datos == false)
                        {
                            MessageBox.Show("No hay datos para esa fecha");
                            Restaurar_fecha();
                        }
                        else
                        {
                            //superadas todas las comprobaciones se cargan los datos de la fecha

                            Carga_Datos_Dia();
                            //Cerrar(); //bloqueo de botones
                        }
                    }
                    else
                    {
                        MessageBox.Show("No puede cargarse una fecha futura");
                        Restaurar_fecha();
                    }
                }
                else
                {
                    MessageBox.Show("Fecha no válida");
                }
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.Close();
        }

        private void button_Imprimir_Click(object sender, EventArgs e)
        {
            //pasar a impresora el cuadre
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            this.Cursor = Cursors.WaitCursor;

            Report_Cuadre_code Imprimir = new Report_Cuadre_code();
            Imprimir.fecha = textBox_Fecha.Text;
            Imprimir.Show();

            this.Cursor = Cursors.Default;
        }
    }
}
