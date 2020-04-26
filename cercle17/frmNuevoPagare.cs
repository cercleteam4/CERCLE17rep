using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmNuevoPagare : Form
    {
        public frmNuevoPagare()
        {
            InitializeComponent();
        }

        public string codcliente, importe_pagare, observaciones, fecha_vto;
        public bool cliente_valido, adosado;
        public SqlConnection myConnection;



        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            //se almacenan los datos en las variables públicas para que puedan leerse desde el formulario que nos invocó

            codcliente = textBox_CodCliente.Text;
            importe_pagare = textBox_Pagare.Text;
            observaciones = textBox_Obs_Pagare.Text;
            fecha_vto = textBox_Vencimiento.Text;

            cliente_valido = false;
            if (textBox_DetNom.Text != "")
            {
                if (textBox_DetNom.Text != "NO EXISTE")
                {
                    cliente_valido = true;
                }
            }

            this.Close();
        }

        private void Carga_Cliente()
        {
            //se lee el nombre del cliente a partir de su código

            this.Cursor = Cursors.WaitCursor;
            bool encontrado = false;
            textBox_DetNom.Text = "";

            if (textBox_CodCliente.Text != "")
            {
                string consulta = "SELECT * FROM DETALLISTAS WHERE DetCod=" + textBox_CodCliente.Text;

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        encontrado = true;
                        textBox_DetNom.Text = myReader["DetNom"].ToString();
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (encontrado == false)
                {
                    textBox_DetNom.Text = "NO EXISTE";
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void frmNuevoPagare_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            if (codcliente != "") 
            { 
                textBox_CodCliente.Text = codcliente;
                Carga_Cliente();
            }

            //en esta versión no hay pagarés adosados, pero se deja el código por si acaso (ver programa Cobros para ejemplo de su uso)

            if (adosado)
            {
                textBox_CodCliente.ReadOnly = true;
                textBox_Pagare.Text = importe_pagare;
                textBox_Pagare.ReadOnly = true;
            }
        }

        private void textBox_CodCliente_Enter(object sender, EventArgs e)
        {
            textBox_CodCliente.BackColor = Color.Yellow;
        }

        private void textBox_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                Carga_Cliente();
                textBox_Pagare.Focus();
            }
        }

        private void textBox_CodCliente_Leave(object sender, EventArgs e)
        {
            textBox_CodCliente.BackColor = Color.White;
        }

        private void textBox_Pagare_Enter(object sender, EventArgs e)
        {
            textBox_Pagare.BackColor = Color.Yellow;
        }

        private void textBox_Pagare_KeyPress(object sender, KeyPressEventArgs e)
        {
            //foco en botón Aceptar
            if (e.KeyChar.ToString() == "\r")
            {
                button_Aceptar.Focus();
            }
        }

        private void textBox_Pagare_Leave(object sender, EventArgs e)
        {
            textBox_Pagare.BackColor = Color.White;
        }

        private void textBox_Obs_Pagare_Enter(object sender, EventArgs e)
        {
            textBox_Obs_Pagare.BackColor = Color.Yellow;
        }

        private void textBox_Obs_Pagare_Leave(object sender, EventArgs e)
        {
            textBox_Obs_Pagare.BackColor = Color.White;
        }

        private void Avisar_Sabado()
        {
            DateTime resultado = new DateTime(2000, 1, 1);
            if (DateTime.TryParse(textBox_Vencimiento.Text, out resultado) == true)
            {
                if (resultado.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("El día de vencimiento corresponde a un sábado");
                }
                if (resultado.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("El día de vencimiento corresponde a un domingo");
                }
                if (resultado.DayOfWeek == DayOfWeek.Monday)
                {
                    MessageBox.Show("El día de vencimiento corresponde a un lunes");
                }
            }
        }

        private void textBox_Vencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
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
                                Avisar_Sabado();
                            }
                        }
                        else
                        {
                            textBox_Vencimiento.Text = textBox_Vencimiento.Text + "/" + DateTime.Today.Year.ToString();
                            if (DateTime.TryParse(textBox_Vencimiento.Text, out resultado) == true)
                            {
                                button_Aceptar.Enabled = true;
                                Avisar_Sabado();
                            }
                        }
                    }
                }
            }
        }

        private void textBox_Vencimiento_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Vencimiento.Text == "*")
            {
                button_Aceptar.Enabled = true;
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

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
