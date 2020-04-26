using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmCobros2 : Form
    {
        public frmCobros2()
        {
            InitializeComponent();
        }

        public ArrayList DATOS_PAGARES;
        public ArrayList INSERT_PAGARES;
        public string Total, detcod;


        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            //crear datos
            DATOS_PAGARES = new ArrayList();
            
            clase_pagare Pagare1 = new clase_pagare();
            Pagare1.Importe = textBox_Pagare.Text;
            Pagare1.Observaciones = textBox_Obs_Pagare.Text;
            Pagare1.Vencimiento = textBox_Vencimiento.Text;

            DATOS_PAGARES.Add(Pagare1);

            clase_pagare Pagare2 = new clase_pagare();
            Pagare2.Importe = textBox_Pagare2.Text;
            Pagare2.Observaciones = textBox_Obs_Pagare2.Text;
            Pagare2.Vencimiento = textBox_Vencimiento2.Text;

            DATOS_PAGARES.Add(Pagare2);

            clase_pagare Pagare3 = new clase_pagare();
            Pagare3.Importe = textBox_Pagare3.Text;
            Pagare3.Observaciones = textBox_Obs_Pagare3.Text;
            Pagare3.Vencimiento = textBox_Vencimiento3.Text;

            DATOS_PAGARES.Add(Pagare3);


            //crear inserts
            INSERT_PAGARES = new ArrayList();

            if (textBox_Pagare.Text != "")
            {
                if (textBox_Pagare.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            string observaciones = textBox_Obs_Pagare.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }

                            string insert_pagare = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones, IdCobro) ";
                            insert_pagare += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + textBox_Vencimiento.Text + "', " + textBox_Pagare.Text.Replace(",", ".") + ", '" + observaciones + "', ";

                            INSERT_PAGARES.Add(insert_pagare);
                        }
                    }
                }
            }

            if (textBox_Pagare2.Text != "")
            {
                if (textBox_Pagare2.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Pagare2.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            string observaciones2 = textBox_Obs_Pagare2.Text.Replace("'", "''"); if (observaciones2.Length > 99) { observaciones2 = observaciones2.Substring(0, 99); }

                            string insert_pagare2 = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones, IdCobro) ";
                            insert_pagare2 += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + textBox_Vencimiento2.Text + "', " + textBox_Pagare2.Text.Replace(",", ".") + ", '" + observaciones2 + "', ";

                            INSERT_PAGARES.Add(insert_pagare2);
                        }
                    }
                }
            }

            if (textBox_Pagare3.Text != "")
            {
                if (textBox_Pagare3.Text != "0,00")
                {
                    decimal auxiliar = 0;
                    if (Decimal.TryParse(textBox_Pagare3.Text, out auxiliar) == true)
                    {
                        if (auxiliar > 0)
                        {
                            string observaciones3 = textBox_Obs_Pagare3.Text.Replace("'", "''"); if (observaciones3.Length > 99) { observaciones3 = observaciones3.Substring(0, 99); }

                            string insert_pagare3 = "INSERT INTO PAGARES(DetCod, Fecha, FVencto, Importe, Observaciones, IdCobro) ";
                            insert_pagare3 += " VALUES(" + detcod + ", '" + DateTime.Today.ToShortDateString() + "', '" + textBox_Vencimiento3.Text + "', " + textBox_Pagare3.Text.Replace(",", ".") + ", '" + observaciones3 + "', ";

                            INSERT_PAGARES.Add(insert_pagare3);
                        }
                    }
                }
            }

            //TOTAL
            Total = textBox_TOTAL.Text;
        }

        private void frmCobros2_Load(object sender, EventArgs e)
        {
            //comprobar si tenemos datos de una apertura anterior
            if (DATOS_PAGARES != null)
            {
                if (DATOS_PAGARES.Count > 0)
                {
                    clase_pagare Pagare1 = (clase_pagare)DATOS_PAGARES[0];
                    textBox_Pagare.Text = Pagare1.Importe;
                    textBox_Obs_Pagare.Text = Pagare1.Observaciones;
                    textBox_Vencimiento.Text = Pagare1.Vencimiento;

                    clase_pagare Pagare2 = (clase_pagare)DATOS_PAGARES[1];
                    textBox_Pagare2.Text = Pagare2.Importe;
                    textBox_Obs_Pagare2.Text = Pagare2.Observaciones;
                    textBox_Vencimiento2.Text = Pagare2.Vencimiento;

                    clase_pagare Pagare3 = (clase_pagare)DATOS_PAGARES[2];
                    textBox_Pagare3.Text = Pagare3.Importe;
                    textBox_Obs_Pagare3.Text = Pagare3.Observaciones;
                    textBox_Vencimiento3.Text = Pagare3.Vencimiento;

                }
            }
        }

        private void textBox_Pagare_Enter(object sender, EventArgs e)
        {
            textBox_Pagare.BackColor = Color.Yellow;
        }

        private void textBox_Pagare_Leave(object sender, EventArgs e)
        {
            textBox_Pagare.BackColor = Color.White;
        }

        private void textBox_Pagare_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_Pagare2_Enter(object sender, EventArgs e)
        {
            textBox_Pagare2.BackColor = Color.Yellow;
        }

        private void textBox_Pagare2_Leave(object sender, EventArgs e)
        {
            textBox_Pagare2.BackColor = Color.White;
        }

        private void textBox_Pagare2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_Pagare3_Enter(object sender, EventArgs e)
        {
            textBox_Pagare3.BackColor = Color.Yellow;
        }

        private void textBox_Pagare3_Leave(object sender, EventArgs e)
        {
            textBox_Pagare3.BackColor = Color.White;
        }

        private void textBox_Pagare3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_Obs_Pagare_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Pagare.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Pagare_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Pagare.BackColor = Color.White;
        }

        private void textBox_Obs_Pagare2_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Pagare2.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Pagare2_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Pagare2.BackColor = Color.White;
        }

        private void textBox_Obs_Pagare3_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Pagare3.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Pagare3_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Pagare3.BackColor = Color.White;
        }

        private void textBox_Vencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                //si es una fecha válida se desbloquea botón
                if (textBox_Vencimiento.Text != "")
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
        }

        private void textBox_Vencimiento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                //si es una fecha válida se desbloquea botón
                if (textBox_Vencimiento2.Text != "")
                {
                    button_Aceptar.Enabled = false;
                    DateTime resultado = new DateTime(2000, 1, 1);
                    if (DateTime.TryParse(textBox_Vencimiento2.Text, out resultado) == true)
                    {
                        if (resultado.Year > 2000)
                        {
                            textBox_Vencimiento2.Text = resultado.Day.ToString() + "/" + resultado.Month.ToString() + "/" + resultado.Year.ToString();
                            button_Aceptar.Enabled = true;
                        }
                    }
                    else
                    {
                        textBox_Vencimiento2.Text = textBox_Vencimiento2.Text + "/" + DateTime.Today.Year.ToString();
                        if (DateTime.TryParse(textBox_Vencimiento2.Text, out resultado) == true)
                        {
                            button_Aceptar.Enabled = true;
                        }
                    }
                }
            }
        }

        private void textBox_Vencimiento3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                //si es una fecha válida se desbloquea botón
                if (textBox_Vencimiento3.Text != "")
                {
                    button_Aceptar.Enabled = false;
                    DateTime resultado = new DateTime(2000, 1, 1);
                    if (DateTime.TryParse(textBox_Vencimiento3.Text, out resultado) == true)
                    {
                        if (resultado.Year > 2000)
                        {
                            textBox_Vencimiento3.Text = resultado.Day.ToString() + "/" + resultado.Month.ToString() + "/" + resultado.Year.ToString();
                            button_Aceptar.Enabled = true;
                        }
                    }
                    else
                    {
                        textBox_Vencimiento3.Text = textBox_Vencimiento3.Text + "/" + DateTime.Today.Year.ToString();
                        if (DateTime.TryParse(textBox_Vencimiento3.Text, out resultado) == true)
                        {
                            button_Aceptar.Enabled = true;
                        }
                    }
                }
            }
        }

        private void textBox_Pagare_TextChanged(object sender, EventArgs e)
        {
            //si se escribe algo que sea un número superior a 0, se bloquea botón y desbloquea vencimiento

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
            }
        }

        private void textBox_Pagare2_TextChanged(object sender, EventArgs e)
        {
            //si se escribe algo que sea un número superior a 0, se bloquea botón y desbloquea vencimiento

            decimal auxiliar = 0;
            if (Decimal.TryParse(textBox_Pagare2.Text, out auxiliar) == true)
            {
                if (auxiliar > 0)
                {
                    button_Aceptar.Enabled = false;
                    textBox_Vencimiento2.ReadOnly = false;
                }
                if (auxiliar == 0)
                {
                    button_Aceptar.Enabled = true;
                    textBox_Vencimiento2.ReadOnly = true;
                }
            }
        }

        private void textBox_Pagare3_TextChanged(object sender, EventArgs e)
        {//si se escribe algo que sea un número superior a 0, se bloquea botón y desbloquea vencimiento

            decimal auxiliar = 0;
            if (Decimal.TryParse(textBox_Pagare3.Text, out auxiliar) == true)
            {
                if (auxiliar > 0)
                {
                    button_Aceptar.Enabled = false;
                    textBox_Vencimiento3.ReadOnly = false;
                }
                if (auxiliar == 0)
                {
                    button_Aceptar.Enabled = true;
                    textBox_Vencimiento3.ReadOnly = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //calcular cifras
            string total = "0,00";
            decimal auxiliar = 0;

            if (Decimal.TryParse(textBox_Pagare.Text, out auxiliar) == true)
            {
                total = Funciones.Suma(total, textBox_Pagare.Text);
            }

            if (Decimal.TryParse(textBox_Pagare2.Text, out auxiliar) == true)
            {
                total = Funciones.Suma(total, textBox_Pagare2.Text);
            }

            if (Decimal.TryParse(textBox_Pagare3.Text, out auxiliar) == true)
            {
                total = Funciones.Suma(total, textBox_Pagare3.Text);
            }

            textBox_TOTAL.Text = Funciones.Formatea(total);
        }
    }
}
