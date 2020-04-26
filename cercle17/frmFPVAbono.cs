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
    public partial class frmFPVAbono : Form
    {
        public frmFPVAbono()
        {
            InitializeComponent();
        }


        public SqlConnection CnO;
        public ArrayList Lista_detallistas;

        decimal dTipo_iva = 0;
        decimal dTipo_recargo = 0;
        bool llevaRecargo = false;


        private void Cargar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name+" ";

            if(textBox_DetCod.Text != "")
            {
                string selectDetRecargo = "SELECT DetRec FROM DETALLISTAS WHERE DetCod = " + textBox_DetCod.Text;

                using (SqlCommand cmd = new SqlCommand(selectDetRecargo, CnO))
                {
                    try
                    {
                        llevaRecargo = Convert.ToChar(cmd.ExecuteScalar()) == 'S' ? true : false;
                    }
                    catch (Exception ex)
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                        MessageBox.Show("Al connsultar si el detallista lleva recargo se ha producido el siguiente error: \n\n " + ex.Message);
                    }
                }
            }
            
        }

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
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

        private void frmFPVAbono_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //se ejecuta al cargar el formulario

            if (CnO != null)
            {
                clase_UTILESdb cla=new clase_UTILESdb() ;
                //cla.SP1();
                
                //array de detallistas
                Lista_detallistas = new ArrayList();
                string strQ = "SELECT * FROM DETALLISTAS order by DetCod";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        clase_detallista detal = new clase_detallista();

                        detal.DetCod = myReader["DetCod"].ToString();
                        detal.DetNom = myReader["DetNom"].ToString();
                        detal.DetCpf = "";
                        detal.DetEMail = myReader["DetEMail"].ToString();
                        detal.detvia = myReader["detvia"].ToString();
                        detal.DetCop = myReader["DetCop"].ToString();
                        detal.detmun = myReader["DetMun"].ToString();
                        detal.DetNif = myReader["DetNif"].ToString();

                        Lista_detallistas.Add(detal);
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                    MessageBox.Show(ex.ToString());
                }

                //dTipo_iva = 0;

                string selectTipoIva = "SELECT TOP(1)IVA, Recargo FROM [dbo].[TIPOS_IVA] ORDER BY Fecha desc";

                using (SqlCommand cmd = new SqlCommand(selectTipoIva, CnO))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while(reader.Read())
                        {
                            dTipo_iva = decimal.Parse(reader["IVA"].ToString());
                            dTipo_recargo = decimal.Parse(reader["Recargo"].ToString());
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Al consultar el tipo de iva se ha producido el siguiente error: \n\n " + ex.Message);
                    }
                }

                
            }

            //cargar datos factura nueva
            textBox_Anyo.Text = DateTime.Today.Year.ToString();
            //textBox_Factura.Text = Nuevo_Factura();
            comboBox_Serie.Text = "AB";

            textBox_DetCod.Focus();
        }//private void frmFPVAbono_Load(object sender, EventArgs e)

        private void Limpieza_Factura()
        {
            //Limpia datos tras una grabación
            textBox_DetCod.Text = "";
            textBox_DetNom.Text = "";

            tbArtCod1.Text = "";
            tbArtDes1.Text = "";
            tbVelKil1.Text = "";
            tbVelPre1.Text = "";
            tbVelImp1.Text = "";

            tbArtCod2.Text = "";
            tbArtDes2.Text = "";
            tbVelKil2.Text = "";
            tbVelPre2.Text = "";
            tbVelImp2.Text = "";

            tbArtCod3.Text = "";
            tbArtDes3.Text = "";
            tbVelKil3.Text = "";
            tbVelPre3.Text = "";
            tbVelImp3.Text = "";

            tbArtCod4.Text = "";
            tbArtDes4.Text = "";
            tbVelKil4.Text = "";
            tbVelPre4.Text = "";
            tbVelImp4.Text = "";

            dtpFechaFra.Text = DateTime.Today.ToString();
            textBox_Observaciones.Text = "";           
        }

        private void button_Consulta_Click(object sender, EventArgs e)
        {
            //abrir formulario para consulta de Detallista
            FormDetallistas Consulta = new FormDetallistas();
            Consulta.Lista_detallistas = Lista_detallistas;
            if (Consulta.ShowDialog() == DialogResult.OK)
            {
                if (Consulta.DetCod != "")
                {
                    textBox_DetCod.Text = Consulta.DetCod;
                    textBox_DetNom.Text = Consulta.Nombre_Det;
                    //Cargar();
                }
            }
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
            if (e.KeyChar.ToString() == "\r")
            {

                if(textBox_DetCod.Text != "")
                {
                    if (Lista_detallistas != null)
                    {
                        for (int x = 0; x < Lista_detallistas.Count; x++)
                        {
                            clase_detallista detall = (clase_detallista)Lista_detallistas[x];

                            if (detall.DetCod == textBox_DetCod.Text)
                            {
                                textBox_DetNom.Text = detall.DetNom;
                                tbArtCod1.Focus();
                            }
                        }
                    }

                    Cargar();
                }
                else
                {
                    textBox_DetNom.Text = "";                  
                }

                
            }
        }   //private void textBox_DetCod_Enter(object sender, EventArgs e)     

        private void button_Grabar_Click(object sender, EventArgs e)
        {

            if (textBox_DetCod.Text != "")
             {            
                //Grabar el abono
                string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
                GloblaVar.gUTIL.ATraza(gIdent + " Click en Grabar Abono");

                //grabar las líneas
                ArrayList Lista_Lineas_Abono = new ArrayList();

                clase_linea_factura linea_abono = null;                    

                if(!string.IsNullOrEmpty(tbArtCod1.Text))
                {
                    linea_abono = new clase_linea_factura();

                    linea_abono.Linea = "1";
                    linea_abono.ArtCod = tbArtCod1.Text;
                    linea_abono.Kilos = Funciones.Formatea(tbVelKil1.Text);
                    linea_abono.Precio = Funciones.Formatea(tbVelPre1.Text);
                    linea_abono.Importe = Funciones.Formatea(tbVelImp1.Text);

                    Lista_Lineas_Abono.Add(linea_abono);                
                }

                if (!string.IsNullOrEmpty(tbArtCod2.Text))
                {
                    linea_abono = new clase_linea_factura();

                    linea_abono.Linea = "2";
                    linea_abono.ArtCod = tbArtCod2.Text;
                    linea_abono.Kilos = Funciones.Formatea(tbVelKil2.Text);
                    linea_abono.Precio = Funciones.Formatea(tbVelPre2.Text);
                    linea_abono.Importe = Funciones.Formatea(tbVelImp2.Text);

                    Lista_Lineas_Abono.Add(linea_abono);
                }

                if (!string.IsNullOrEmpty(tbArtCod3.Text))
                {
                    linea_abono = new clase_linea_factura();

                    linea_abono.Linea = "3";
                    linea_abono.ArtCod = tbArtCod3.Text;
                    linea_abono.Kilos = Funciones.Formatea(tbVelKil3.Text);
                    linea_abono.Precio = Funciones.Formatea(tbVelPre3.Text);
                    linea_abono.Importe = Funciones.Formatea(tbVelImp3.Text);

                    Lista_Lineas_Abono.Add(linea_abono);
                }

                if (!string.IsNullOrEmpty(tbArtCod4.Text))
                {
                    linea_abono = new clase_linea_factura();

                    linea_abono.Linea = "4";
                    linea_abono.ArtCod = tbArtCod4.Text;
                    linea_abono.Kilos = Funciones.Formatea(tbVelKil4.Text);
                    linea_abono.Precio = Funciones.Formatea(tbVelPre4.Text);
                    linea_abono.Importe = Funciones.Formatea(tbVelImp4.Text);

                    Lista_Lineas_Abono.Add(linea_abono);
                }
                //GloblaVar.gIdVendedor;
                string idFactura = Funciones.FacturarAbono(textBox_DetCod.Text, textBox_Anyo.Text, comboBox_Serie.Text, Convert.ToDateTime(dtpFechaFra.Text), Lista_Lineas_Abono, textBox_Observaciones.Text, textBox_BI.Text, textBox_IVA.Text, textBox_Recargo.Text, textBox_Importe.Text, dTipo_iva, CnO);


                if(idFactura!="")
                {               
                    Limpieza_Factura();
                    MessageBox.Show("El abono se ha realizado correctamente");
                    GloblaVar.gUTIL.ATraza(gIdent +"El abono se ha realizado correctamente");
                }

            }
            else
            {
                MessageBox.Show("El detallista es obligatorio");
            }
           
        }    

        private void Recuento_Importes()
        {
            string base_imponible = "0,00";
            string importe_iva = "0,00";
            string importe_recargo = "0,00";  
            string importe_total = "0,00";

            decimal dBase_imponible = 0;
            decimal dImporte_iva = 0;
            decimal dImporte_recargo = 0;
            decimal dImporte_total = 0;
                     
            base_imponible = Funciones.Suma(base_imponible, tbVelImp1.Text);
             base_imponible = Funciones.Suma(base_imponible, tbVelImp2.Text);
            base_imponible = Funciones.Suma(base_imponible, tbVelImp3.Text);
            base_imponible = Funciones.Suma(base_imponible, tbVelImp4.Text);

            if(llevaRecargo)
            {
                dBase_imponible = decimal.Parse(base_imponible);

                dImporte_iva = (dBase_imponible * dTipo_iva) / 100;
                importe_iva = Funciones.Formatea(dImporte_iva.ToString());
                dImporte_iva = decimal.Parse(importe_iva);

                dImporte_recargo = (dBase_imponible * dTipo_recargo) / 100;
                importe_recargo = Funciones.Formatea(dImporte_recargo.ToString());
                dImporte_recargo = decimal.Parse(importe_recargo);

                dImporte_total = dBase_imponible + dImporte_iva + dImporte_recargo;
                importe_total = dImporte_total.ToString();

                textBox_BI.Text = Funciones.Formatea("-" + base_imponible);
                textBox_IVA.Text = Funciones.Formatea("-" + importe_iva);
                textBox_Recargo.Text = Funciones.Formatea("-" + importe_recargo);
                textBox_Importe.Text = Funciones.Formatea("-" + importe_total);
            }
            else
            {
                dBase_imponible = decimal.Parse(base_imponible);

                dImporte_iva = dBase_imponible * dTipo_iva /100;
                importe_iva = dImporte_iva.ToString();

                dImporte_total = dBase_imponible + dImporte_iva;
                importe_total = dImporte_total.ToString();

                textBox_BI.Text = Funciones.Formatea("-" + base_imponible);
                textBox_IVA.Text = Funciones.Formatea("-" + importe_iva);
                textBox_Recargo.Text = Funciones.Formatea("-" + importe_recargo);
                textBox_Importe.Text = Funciones.Formatea("-"+ importe_total);
            }
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //temporizador para recuento
            Recuento_Importes();
        }      

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbArtCod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtDes1.Text = Funciones.DameNomArt(tbArtCod1.Text);
                    tbVelKil1.Focus();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }        

        private void btnBuscarArt1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            { 
                GloblaVar.TIPO_CONSULTA = "ARTICULOS";
                frmCONSULTA frmC = new frmCONSULTA();
                //frmC.Show();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    tbArtCod1.Text = GloblaVar.Cod_Buscado;
                    tbArtDes1.Text = GloblaVar.Nom_Buscado;
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

        }

        private void tbArtCod2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtDes2.Text = Funciones.DameNomArt(tbArtCod2.Text);
                    tbVelKil2.Focus();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void btnBuscarArt2_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try 
            { 
                GloblaVar.TIPO_CONSULTA = "ARTICULOS";
                frmCONSULTA frmC = new frmCONSULTA();
                //frmC.Show();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    tbArtCod2.Text = GloblaVar.Cod_Buscado;
                    tbArtDes2.Text = GloblaVar.Nom_Buscado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbArtCod3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtDes3.Text = Funciones.DameNomArt(tbArtCod3.Text);
                    tbVelKil3.Focus();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void btnBuscarArt3_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try 
            { 
                GloblaVar.TIPO_CONSULTA = "ARTICULOS";
                frmCONSULTA frmC = new frmCONSULTA();
                //frmC.Show();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    tbArtCod3.Text = GloblaVar.Cod_Buscado;
                    tbArtDes3.Text = GloblaVar.Nom_Buscado;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }
        private void tbArtCod4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtDes4.Text = Funciones.DameNomArt(tbArtCod4.Text);
                    tbVelKil4.Focus();                    
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void btnBuscarArt4_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            { 
                GloblaVar.TIPO_CONSULTA = "ARTICULOS";
                frmCONSULTA frmC = new frmCONSULTA();
                //frmC.Show();
                if (frmC.ShowDialog() == DialogResult.OK)
                {
                    tbArtCod4.Text = GloblaVar.Cod_Buscado;
                    tbArtDes4.Text = GloblaVar.Nom_Buscado;
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void dtpFechaFra_ValueChanged(object sender, EventArgs e)
        {
            string anyo = dtpFechaFra.Text.Substring(6, 4);
            textBox_Anyo.Text = anyo;
        }

        private void tbVelKil1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelPre1.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelKil2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelPre2.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelKil3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelPre3.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());                
            }
        }

        private void tbVelKil4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelPre4.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelPre1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelImp1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelPre2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelImp2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelPre3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbVelImp3.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelPre4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar (Keys.Return))
                {
                    tbVelImp4.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

        }

        private void tbVelImp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtCod2.Focus();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelImp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtCod3.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelImp3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbArtCod4.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbVelImp4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if(e.KeyChar == Convert.ToChar (Keys.Return))
                {
                    textBox_Observaciones.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

    }
}
