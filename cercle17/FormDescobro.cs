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
    public partial class FormDescobro : Form
    {
        public FormDescobro()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void Descobro()
        {
            //descobrar una factura

            //la factura puede tener varios idcobrofact asociados

            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            textBox_Factura.Text = Funciones.numerales(textBox_Factura.Text);

            if (textBox_Factura.Text != "")
            {
                //comprobar que el cobro es de fecha actual???

                string strQ = "select * FROM FACTV_COBROS WHERE Factura=" + textBox_Factura.Text + " AND Anyo=" + textBox_Anyo.Text + " AND Serie='" + textBox_Serie.Text + "'";

                //creamos una lista de cobros que luego borraremos
                //lo normal es que solo haya un cobro, pero pueden haber varios

                ArrayList Lista_Cobros = new ArrayList();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        string id_cobro_fact = myReader["IdCobroFact"].ToString();
                        Lista_Cobros.Add(id_cobro_fact);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (Lista_Cobros.Count > 0)
                {
                    for (int x = 0; x < Lista_Cobros.Count; x++)
                    {
                        string IdCobroFact = (string)Lista_Cobros[x];

                        int res = 0;

                        //borramos talones
                        string delete_talon = "DELETE FROM TALONES WHERE IdCobroFact=" + IdCobroFact;
                        res = Funciones.EjecutaNonQuery(delete_talon, CnO);

                        //borramos pagarés
                        string delete_pagares = "DELETE FROM PAGARES WHERE IdCobroFact=" + IdCobroFact;
                        res = Funciones.EjecutaNonQuery(delete_pagares, CnO);

                        //borramos transferencias
                        string delete_trans = "DELETE FROM TRANSFERENCIAS WHERE IdCobroFact=" + IdCobroFact;
                        res = Funciones.EjecutaNonQuery(delete_trans, CnO);

                        //borramos tarjetas
                        string delete_tarjetas = "DELETE FROM CREDIT_CARDS WHERE IdCobroFact=" + IdCobroFact;
                        res = Funciones.EjecutaNonQuery(delete_tarjetas, CnO);

                        //borramos el cobro
                        string delete_cobro = "DELETE FROM FACTV_COBROS WHERE IdCobroFact=" + IdCobroFact;
                        res = Funciones.EjecutaNonQuery(delete_cobro, CnO);

                    }


                        //update de la factura, para que esté descobrada
                    string update_factura = "UPDATE FACTV_CABE SET FechaCobro=NULL, ImpteCobrado=0, ImptePendiente=ImpteFactura WHERE Factura=" + textBox_Factura.Text + " AND Anyo=" + textBox_Anyo.Text + " AND Serie='" + textBox_Serie.Text + "'";
                    int res_factura = Funciones.EjecutaNonQuery(update_factura, CnO);

                    string mensaje_log = "Se ha descobrado la Factura=" + textBox_Factura.Text + " : Anyo=" + textBox_Anyo.Text + " : Serie='" + textBox_Serie.Text + "'";

                    Funciones.Escribe_LOG(mensaje_log, "DESCOBRO", CnO);
                }

            }
            

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Descobro();
        }

        private void FormDescobro_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            textBox_Anyo.Text = DateTime.Today.Year.ToString();
            textBox_Serie.Text = "AA";
        }
    }
}
