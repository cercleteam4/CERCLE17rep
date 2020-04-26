using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace cercle17
{
    public partial class frmEXPORT_CPLUS_CAJA : Form
    {
        public frmEXPORT_CPLUS_CAJA()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        ArrayList albaranes;        


        private void frmEXPORT_CPLUS_CAJA_Load(object sender, EventArgs e)
        {
            CnO = GloblaVar.gConRem; 
            
            Cargar();
            Seguridad();
        }

        private void Cargar(string CampoOrden="VenAlb")
        {

            albaranes = new ArrayList();

            //string strQ = "SELECT * FROM VENALB_CABE WHERE (DetCod=" + textBox_DetCod.Text + ") AND (VenNfp IS NULL) AND (AnyoFra IS NULL) AND (SerieFra IS NULL) AND (Anulado<>1) order by VenFec, VenAlb";
            string strQ = @"SELECT vc.VenAlb, vc.Anyo, vc.VenFec, vc.DetCod, d.DetNom, d.SubCta, vc.VenTve, Vc.IdCobro, vc.FechaCobro, vc.VenTot, vc.PerCentIva FROM VENALB_CABE as vc ";
            strQ+=" INNER JOIN DETALLISTAS as d on d.DetCod = vc.DetCod " ;
            strQ += " WHERE ";
            //strQ += "(vc.VenFec='" + dtpFecha.Text + "')";
            //strQ += " AND ";
            strQ += "(vc.Anulado<>1) ";
            strQ += " AND ";
            strQ += " (vc.VenTve NOT IN (1,51,43)) ";
            strQ += " AND ";
            strQ += "vc.FechaCobro='" + dtpFecha.Text +"'";
            if (radioButton2.Checked) { CampoOrden = "DetCod"; }
            switch(CampoOrden)
            {
                case "DetCod":
                    strQ += " ORDER by vc.DetCod";
                    break;
                case "VenAlb":
                    strQ += " ORDER by vc.VenAlb";
                    break;
                default:
                    strQ += " ORDER by vc.VenFec, vc.VenAlb";
                    break;
            }
            

            this.Cursor = Cursors.WaitCursor;

            try
            {
                double  Total_Lista = 0;

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_albaran alba = new clase_albaran();

                    
                    alba.Albaran = myReader["VenAlb"].ToString();
                    alba.Fecha = myReader["VenFec"].ToString(); if (alba.Fecha.Length > 10) { alba.Fecha = alba.Fecha.Substring(0, 10); }
                    alba.Año = myReader["Anyo"].ToString();
                    alba.CodDetallista = myReader["DetCod"].ToString();
                    alba.NomDetallista = myReader["DetNom"].ToString();
                    alba.SubCtaDetallista = myReader["SubCta"].ToString();
                    alba.TV = myReader["VenTve"].ToString();
                    alba.NumCobro = myReader["IdCobro"].ToString();
                    alba.FecCobro = myReader["FechaCobro"].ToString(); if (alba.FecCobro.Length > 10) { alba.FecCobro = alba.FecCobro.Substring(0, 10); }
                    
                    alba.Total = Funciones.Formatea(myReader["VenTot"].ToString());
                    Total_Lista += Convert.ToDouble(alba.Total);
                    alba.PorcentajeIva = Funciones.Formatea(myReader["PerCentIva"].ToString());

                    albaranes.Add(alba);
                }
                myReader.Close();

                dataGridView_Albaranes.AutoGenerateColumns = false;
                dataGridView_Albaranes.DataSource = albaranes;
                label1.Text = Total_Lista.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Cursor = Cursors.Default;

        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------SALIENDO DE " + this.GetType().FullName);
            this.Close();

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void button_Exportar_Click(object sender, EventArgs e)
        {
            //Se realizará lista de asientos de albaranes cobrados al fichero \\CONTAPLUS\yyyymmdd_COBROS_CAJA.txt
            // Para ello cada asiento de cobro tendrá dos apuntes

            // 1.- Cuenta de cliente.................Total al Haber
            // 2.- Cuenta de Caja ...................Total al Debe

            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string lineaCli = "";
            string lineaCaja = "";

            try{

                //1.- Abrimos y preparamos el fichero
                GloblaVar.gUTIL.ATraza(gIdent + " Abriendo el fichero preparado contaplus CAJA ");

                string FechaFichero = dtpFecha.Text.Substring(6, 4) + dtpFecha.Text.Substring(3, 2) + dtpFecha.Text.Substring(0, 2);
                string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\"+ FechaFichero + "_COBROS_CAJA.txt" ;
                lFichero.Text = "Se generará el Archivo: " + fichero;
                TextWriter tw = new StreamWriter(fichero, false, System.Text.Encoding.ASCII);

                //2.- Inicializamos Contador de asiento
                int NumAsto = 1;
            

                //3.- Entramos en bucle de lista de albaranes del grid
                //for (int i=1;i<89 ;i++ )
                //{

                foreach(clase_albaran alba in albaranes)
                {
                //    3.1.- Preparamos Apunte Cuenta cliente, Total al haber

                    lineaCli = Funciones.ApunteAsiento(NumAsto.ToString(), alba.SubCtaDetallista, "", "COBRO ALB. " + alba.Albaran + "/" + alba.Año, "0.00", "0.00", alba.Total.Replace(',', '.'), "0.00", FechaFichero, "");
                    tw.WriteLine(lineaCli);

                //    3.2.- Preparamos apunte Cuenta de caja al debe

                    lineaCaja = Funciones.ApunteAsiento(NumAsto.ToString(), GloblaVar.gSubCtaCAJA, "", "COBRO ALB. " + alba.Albaran + "/" + alba.Año, "0.00", "0.00", "0.00", alba.Total.Replace(',', '.'), FechaFichero, "");
                    tw.WriteLine(lineaCaja);
   
                //    3.3.- Incrementamos contador de asientos
                    NumAsto++;

                }  //for (int i=1;i<=dataGridView_Albaranes.Rows )

                //4.- Cerramos el fichero
                tw.Close();

                GloblaVar.gUTIL.ATraza(gIdent + " Cerrando el fichero preparado contaplus CAJA ");

                MessageBox.Show("El archivo '" + FechaFichero + "_COBROS_CAJA.txt' se ha generado correctamente");

            } //try
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ". " + ex.ToString());
            }

        }  //private void button_Exportar_Click(object sender, EventArgs e)

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2":
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            button_Exportar.Visible = true;
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            button_Exportar.Visible = true;
                            //button_Facturas.Enabled = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Cargar("VenAlb");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Cargar("DetCod");
        } 
    }
}
