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
    public partial class frmListaTerminales : Form
    {
        public frmListaTerminales()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void Cargar()
        {
            //relación de terminales con sus vendedores asignados

            textBox_Listado.Text = "";
            string terminal_actual = "";

            string strQ = "SELECT TV.IdTerminal, V.Vendedor, TV.IdVendedor FROM  TERMINAL_VENDEDOR TV, VENDEDORES V WHERE TV.IdVendedor=V.IdVendedor order by IdTerminal, TV.IdVendedor";
            
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string id_terminal = myReader["IdTerminal"].ToString();
                    string nombre = myReader["Vendedor"].ToString();

                    if (terminal_actual != id_terminal)
                    {
                        //nueva línea
                        if (textBox_Listado.Text.Length > 3)
                        {
                            textBox_Listado.Text = textBox_Listado.Text.Substring(0, textBox_Listado.Text.Length - 2);
                        }

                        textBox_Listado.Text += "\r\n" + id_terminal + ": " + nombre + ", ";

                        terminal_actual = id_terminal;
                    }
                    else
                    {
                        //se añade
                        textBox_Listado.Text += nombre + ", ";
                    }

                }
                myReader.Close();

                if (textBox_Listado.Text.Length > 3)
                {
                    textBox_Listado.Text = textBox_Listado.Text.Substring(0, textBox_Listado.Text.Length - 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void frmListaTerminales_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            Cargar();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
