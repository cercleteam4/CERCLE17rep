using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cercle17
{
    public partial class frmEXPORT_CPLUS_CobORE : Form
    {
        string FechaFichero;
        //decimal TotalRV = 0;    //Cobros del dia (albaranes de venta del dia de Oremape que el banco abona en el día al mayorista)
        //decimal TotalRR = 0;    //Total de Recobross (cobros que fueron devueltos y que el banco después ha podido cobrar)
        //decimal TotalRD = 0;    //Total de Adeudos o cobros devueltos en el banco
        //decimal TotalPV = 0;    //Total de albaranes cobrados por el mayorista
        int NumFras = 0;        //Num de lineas del fichero de Oremape
        Boolean F6 = false;     // Nos indica si el fichero es con fqacturas de 6 digitos o 7


        int PrgBar = 0;
        public frmEXPORT_CPLUS_CobORE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string linea;
            string Mayorista;
            string FechaAlb="";
            string FechaCobro="";
            //string Serie;
            string Albaran="";
            string Año="";
            string DetCod="";
            //string BI;
            //string IVA;
            //string Req;
            string Importe="";
            //string Signo;
            string SubCtaCli="";
            string Tipo="";
            string Tipo1="";


            GloblaVar.gUTIL.ATraza(gIdent+"Comenzar a Importar Cobros de OREMAPE");
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //1.- LEEMOS EL FICHERO QUE NOS PASA OREMAPE, lo tenemos en sr
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                string nombreFichero =Path.GetFileName( openFileDialog1.FileName);
                FechaFichero =   "20" + nombreFichero.Substring(6, 2)+ nombreFichero.Substring(4, 2)+nombreFichero.Substring(2, 2);
                GloblaVar.gUTIL.ATraza(gIdent + "Fichero recibido: "+ nombreFichero +" Fecha: "+ FechaFichero );
                //MessageBox.Show(sr.ReadToEnd());

                //2.- Borramos la tabla en la que vamos a insertar los registros
                //int res = EjecutaNonQuery("DELETE FROM CONTAB_COBROS_OREMAPE");
                int res = GloblaVar.gUTIL.EjecutaNQ("DELETE FROM CONTAB_COBROS_OREMAPE");
                NumFras = 0; // Inicializamos el nº de albaranes que se van a leer

                F6 = false;
                while ((linea = sr.ReadLine()) != null)
                {
                    //LEEMOS LINEA a LINEA  y miramos si la longitud es >39

                    if (linea.Length>39)
                    {
                        
                        NumFras++;
                        Mayorista = linea.Substring(0, 2);
                        DetCod = linea.Substring(2, 4);
                        //if (frmPpal.USUARIO == "5")  //DIALPESCA
                        //{
                            if (linea.Trim().Length ==35)
                            {
                                F6 = true;
                                Albaran = linea.Substring(6, 6);        //Para Albaranes de 6 dígitos
                                FechaAlb = linea.Substring(12, 6);
                                GloblaVar.gUTIL.ATraza(gIdent + "Albarán: " + Albaran + " Fecha: " + FechaAlb);
                                if (frmPpal.USUARIO == "1") { FechaAlb = FechaFichero.Substring(6, 2) + FechaFichero.Substring(4, 2) + FechaFichero.Substring(2, 2); }   //Llorens
                                FechaAlb = FechaAlb.Substring(0, 2) + "/" + FechaAlb.Substring(2, 2) + "/20" + FechaAlb.Substring(4, 2);
                                Año = FechaAlb.Substring(6, 4);
                                FechaCobro = linea.Substring(18, 6);
                                if (frmPpal.USUARIO == "1") { FechaCobro = FechaFichero.Substring(6, 2) + FechaFichero.Substring(4, 2) + FechaFichero.Substring(2, 2); }   //Llorens
                                FechaCobro = FechaCobro.Substring(0, 2) + "/" + FechaCobro.Substring(2, 2) + "/20" + FechaCobro.Substring(4, 2);
                                Importe = linea.Substring(24, 7) + "." + linea.Substring(31, 2);
                                Tipo = linea.Substring(33, 2);
                                SubCtaCli = Funciones.DameSubctaDet(DetCod, GloblaVar.gConRem);
                            }//albaranes de 6 digitos
                            else
                            {
                                Albaran = linea.Substring(6, 7);        //Ahora los albaranes son de 7 dígitos
                                FechaAlb = linea.Substring(13, 6);
                                GloblaVar.gUTIL.ATraza(gIdent + "Albarán: " + Albaran + " Fecha: " + FechaAlb);
                                if (frmPpal.USUARIO == "1") { FechaAlb = FechaFichero.Substring(6, 2) + FechaFichero.Substring(4, 2) + FechaFichero.Substring(2, 2); }   //Llorens
                                FechaAlb = FechaAlb.Substring(0, 2) + "/" + FechaAlb.Substring(2, 2) + "/20" + FechaAlb.Substring(4, 2);
                                Año = FechaAlb.Substring(6, 4);
                                FechaCobro = linea.Substring(19, 6);
                                if (frmPpal.USUARIO == "1") { FechaCobro = FechaFichero.Substring(6, 2) + FechaFichero.Substring(4, 2) + FechaFichero.Substring(2, 2); }   //Llorens
                                FechaCobro = FechaCobro.Substring(0, 2) + "/" + FechaCobro.Substring(2, 2) + "/20" + FechaCobro.Substring(4, 2);
                                Importe = linea.Substring(25, 7) + "." + linea.Substring(32, 2);
                                Tipo = linea.Substring(34, 2);
                                SubCtaCli = Funciones.DameSubctaDet(DetCod, GloblaVar.gConRem);
                            }//Alabaranes de 7 dígitos
                        //}

                        switch (Tipo)
                        {
                            case "RR":
                                Tipo1 = "Recobro Alb. n. " + Albaran ;
                                break;
                            case "RV":
                                Tipo1 = "Cobro Alb. n. " + Albaran;
                                break;
                            case "RD":
                                Tipo1 = "Devolución Alb. " + Albaran;
                                break;
                            case "PV":
                                Tipo1 = "Contado OMP " + Albaran;
                                break;
                            default:
                                Tipo1 = "ERROR";
                                break;
                        } //switch(tipo)

                        string sQ = "INSERT INTO CONTAB_COBROS_OREMAPE (";
                        sQ += "MayCod,DetCod,Albaran,Anyo,FechaAlb,FechaCob,Subcuenta,Tipo,Tipo1,Importe";
                        sQ += ") VALUES (";
                        sQ += Mayorista  + ",";
                        sQ += DetCod + ",";
                        sQ += Albaran + ",";
                        sQ += Año  + ",";
                        sQ += "'" + FechaAlb + "',";
                        sQ += "'" + FechaCobro + "',";
                        sQ += "'" + SubCtaCli + "',";
                        sQ += "'" + Tipo  + "',";
                        sQ += "'" + Tipo1  + "',";
                        sQ += Importe;
                        sQ += ")";

                        GloblaVar.gUTIL.ATraza(gIdent + "Command: " +sQ);
                        //        //INSERTAMOS LINEA A LINEA EN LA TABLA
                        res =GloblaVar.gUTIL.EjecutaNQ (sQ);
                    }
                    //} // while ((linea = sr.ReadLine()) != null)
                    
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = NumFras;
                    progressBar1.Value = 0;
                    //4.- YA TENEMOS LA TABLA CON LOS COBROS LEÍDOS. AHORA DEBEMOS PREPARAR EL FICHERO PARA CONTAPLUS
                }// while
                Exportar_Cobros_Oremape();
                sr.Close();
            }
            MessageBox.Show("PROCESO TERMINADO. " +NumFras +" albaranes Procesados");
        }  // private void button1_Click(object sender, EventArgs e)

        private void Exportar_Cobros_Oremape()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string lineaTot="";     //contendrá la linea de totales de los grupos RV,RR y RD
            string lineaAlb = "";   //Contendrá la linea de albarán  

            //string Mayorista;
            string FechaAlb;
            string FechaCobro;
            string Albaran;
            string Año;
            string DetCod;
            string Importe;
            string SubCtaCli;
            //string Tipo;
            string Tipo1;


            try
            {
                //1.-Preparamos el fichero para meter  las lineas
                string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\COBROS_OMP_" + FechaFichero;
                if (F6 == true) { fichero += "_6" + ".txt"; } else { fichero += "_7" + ".txt"; };

                lFichero.Text = "Se generará el Archivo: " + fichero;
                TextWriter tw = new StreamWriter(fichero,true,System.Text.Encoding.ASCII );

                //2.- Inicializamos contador de asientos
                int NumAsto = 1;

                //3.- Totales de ADEUDOS
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT SUM(IMPORTE) as Total FROM CONTAB_COBROS_OREMAPE GROUP BY TIPO HAVING CONTAB_COBROS_OREMAPE.TIPO='RD'", GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();
                double dTotalRD = 0;
                lRD.Text = "";
                if (myReader.HasRows)
                {
                    myReader.Read();
                    dTotalRD = Convert.ToDouble(myReader.GetValue(0));

                    string sTotalRD = Funciones.Formatea(myReader["Total"].ToString()).Replace(',', '.');
                    lRD.Text = "TOTAL ADEUDOS (Devueltos): " + sTotalRD;
                    myReader.Close();

                    //Ahora toca escribir el asiento el cual consta de
                    //  1 apunte a la cuenta del banco con el total de todos los albaranes RD al HABER
                    //  1 apunte por cada albarán RD a la cuenta del cliente con el importe del albarán al debe

                    lineaTot = ApunteAsiento(NumAsto.ToString(), GloblaVar.gSubCtaBANCO, "", "ADEUDO CREDITO" + FechaFichero, "10", "0", sTotalRD, "0.00", FechaFichero, "");
                    tw.WriteLine(lineaTot);


                    //4.- LEEMOS LOS COBROS DE ADEUDOS de LA TABLA CONTAB_COBROS_OREMAPE y LOS PASAMOS EN ASIENTO AL FICHERO
                    myReader.Close();
                    myCommand.Dispose();
                    myCommand = new SqlCommand("SELECT * FROM CONTAB_COBROS_OREMAPE WHERE Tipo='RD'", GloblaVar.gConRem);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        PrgBar = PrgBar++;
                        progressBar1.Value = PrgBar;
                        Albaran = myReader["Albaran"].ToString();
                        FechaAlb = myReader["FechaAlb"].ToString();
                        FechaCobro = myReader["FechaCob"].ToString();
                        Año = myReader["Anyo"].ToString();
                        DetCod = myReader["DetCod"].ToString();
                        Importe = Funciones.Formatea(myReader["Importe"].ToString()).Replace(',', '.');
                        SubCtaCli = myReader["Subcuenta"].ToString();
                        Tipo1 = myReader["Tipo1"].ToString();
                        //  1 apunte por cada albarán RD a la cuenta del cliente con el importe del albarán al debe
                        lineaAlb = ApunteAsiento(NumAsto.ToString(), SubCtaCli, "", Tipo1, "0.00", "0.00", "0.00", Importe, FechaCobro, "");
                        tw.WriteLine(lineaAlb);

                    } // while myReader.Read
                    
                   
                    NumAsto++;
                }  //if (myReader.HasRows)
                myCommand.Dispose();
                myReader.Close();

                //5.- LEEMOS LOS RECOBROS de LA TABLA CONTAB_COBROS_OREMAPE y LOS PASAMOS EN ASIENTO AL FICHERO

                //Ahora toca escribir el asiento el cual consta de
                //  1 apunte a la cuenta del banco con el total de todos los albaranes RR al DEBE
                //  1 apunte por cada albarán RR a la cuenta del cliente con el importe del albarán al HABER
                myCommand = new SqlCommand("SELECT SUM(IMPORTE) as Total FROM CONTAB_COBROS_OREMAPE GROUP BY TIPO HAVING CONTAB_COBROS_OREMAPE.TIPO='RR'", GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();
                
                double dTotalRR = 0;
                lRR.Text = "";
                if (myReader.HasRows)
                {
                    myReader.Read();
                    dTotalRR = Convert.ToDouble(myReader.GetValue(0));
                    string sTotalRR = Funciones.Formatea(myReader["Total"].ToString()).Replace(',', '.');
                    lRR.Text = "TOTAL RECOBROS: " + sTotalRR;
                    myReader.Close();
                    myCommand.Dispose();

                    lineaTot = ApunteAsiento(NumAsto.ToString(), GloblaVar.gSubCtaBANCO, "", "RECOBRO CREDITO " + FechaFichero, "10", "0", "0.00", sTotalRR, FechaFichero, "");
                    tw.WriteLine(lineaTot);
                    myCommand = new SqlCommand("SELECT * FROM CONTAB_COBROS_OREMAPE WHERE Tipo='RR'", GloblaVar.gConRem);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        PrgBar = PrgBar++;
                        progressBar1.Value = PrgBar;
                        Albaran = myReader["Albaran"].ToString();
                        FechaAlb = myReader["FechaAlb"].ToString();
                        FechaCobro = myReader["FechaCob"].ToString();
                        Año = myReader["Anyo"].ToString();
                        DetCod = myReader["DetCod"].ToString();
                        Importe = Funciones.Formatea(myReader["Importe"].ToString()).Replace(',', '.');
                        SubCtaCli = myReader["Subcuenta"].ToString();
                        Tipo1 = myReader["Tipo1"].ToString();
                        //  1 apunte por cada albarán RD a la cuenta del cliente con el importe del albarán al debe
                        lineaAlb = ApunteAsiento(NumAsto.ToString(), SubCtaCli, "", Tipo1, "0.00", "0.00", Importe, "0.00", FechaCobro, "");
                        tw.WriteLine(lineaAlb);

                    } // while myReader.Read
                    NumAsto++;
                } //if (myReader.HasRows)
                myReader.Close();
                myCommand.Dispose();
                

                //6.- LEEMOS LOS COBROS DEL DIA de CREDITO RV de LA TABLA CONTAB_COBROS_OREMAPE y LOS PASAMOS EN ASIENTO AL FICHERO
                //Ahora toca escribir el asiento el cual consta de
                //  1 apunte a la cuenta del banco con el total de todos los albaranes RV al DEBE
                //  1 apunte por cada albarán RV a la cuenta del cliente con el importe del albarán al HABER
                myCommand = new SqlCommand("SELECT SUM(IMPORTE) as Total FROM CONTAB_COBROS_OREMAPE GROUP BY TIPO HAVING CONTAB_COBROS_OREMAPE.TIPO='RV'", GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();

                double dTotalRV = 0;
                string sTotalRV = "";

                if (myReader.HasRows)
                {
                    myReader.Read();
                    lRV.Text = "";
                    dTotalRV = Convert.ToDouble(myReader.GetValue(0));
                    sTotalRV = Funciones.Formatea(myReader["Total"].ToString()).Replace(',', '.');
                    lRV.Text = "TOTAL COBROS OREMAPE " + FechaFichero.Substring(6, 2) + "/" + FechaFichero.Substring(4, 2) + "/" + FechaFichero.Substring(0, 4) + ": " + sTotalRV;


                    myReader.Close();
                    myCommand.Dispose();

                    lineaTot = ApunteAsiento(NumAsto.ToString(), GloblaVar.gSubCtaBANCO, "", "COBRO CREDTO OMP " + FechaFichero, "10", "0", "0.00", sTotalRV, FechaFichero, "");
                    tw.WriteLine(lineaTot);
                    myCommand = new SqlCommand("SELECT * FROM CONTAB_COBROS_OREMAPE WHERE Tipo='RV'", GloblaVar.gConRem);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        PrgBar = PrgBar++;
                        progressBar1.Value = PrgBar;
                        Albaran = myReader["Albaran"].ToString();
                        FechaAlb = myReader["FechaAlb"].ToString();
                        FechaCobro = myReader["FechaCob"].ToString();
                        Año = myReader["Anyo"].ToString();
                        DetCod = myReader["DetCod"].ToString();
                        Importe = Funciones.Formatea(myReader["Importe"].ToString()).Replace(',', '.');
                        SubCtaCli = myReader["Subcuenta"].ToString();
                        Tipo1 = myReader["Tipo1"].ToString();
                        //  1 apunte por cada albarán RD a la cuenta del cliente con el importe del albarán al debe
                        lineaAlb = ApunteAsiento(NumAsto.ToString(), SubCtaCli, "", Tipo1, "0.00", "0.00", Importe, "0.00", FechaCobro, "");
                        tw.WriteLine(lineaAlb);

                    } // while myReader.Read
                    NumAsto++;
                }
                myReader.Close();
                myCommand.Dispose();
                

                //7.- CERRAMOS EL FICHERO

                tw.Close();
            } //try
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ". " + ex.ToString());

            }
        } // private void Exportar_Cobros_Oremape

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------SALIENDO DE " + this.GetType().FullName);
            this.Close();

        }  //       private void button_Salir_Click(object sender, EventArgs e)

        public static string ApunteAsiento(string Asto,string CtaCargo,string CtaContraPart,string Concepto,string IVA, string Req, string Haber,string Debe,string FechaCobro,string Serie)
        {

            string cero_cero = "0.00";
            string cero_seis = "0.000000";
            string cero = "0";
            //string uno = "1";
            string blanco = " ";
            
            
            if (FechaCobro.Length>8)
            {
                FechaCobro = FechaCobro.Substring(6, 4) + FechaCobro.Substring(3, 2) + FechaCobro.Substring(0, 2);
               
            }
            string Apunte = Asto.ToString().PadLeft(6, ' ');        //Num Asiento justificado a la dcha 6 digitos
            
            
            Apunte += FechaCobro.ToString().PadRight (8,' ');  // Fecha contable del asiento. la fecha de cobro normalmente. 8 digitos .ej 20160105
            Apunte += CtaCargo.PadRight(12, ' ');   //Codigo de la subcuenta 
            Apunte += cero_cero.PadLeft(28, ' ');   //Codigo de la contrapartida e importe al debe en pesetas
            Apunte += Concepto.PadRight(25, ' ');   //Concepto del asiento. 25 caracteres
            Apunte += cero_cero.PadLeft(16, ' ');   // Importe al haber en pesetas. No se usa.16.2
            Apunte += cero.PadLeft(8, ' ');         //Nº de factura al IVA
            Apunte += cero_cero.PadLeft(16, ' ');   //Base Imponible del IVA en pesetas.16.2
            Apunte += cero_cero.PadLeft(5, ' ');    //% del IVA  5.2
            Apunte += cero_cero.PadLeft(5, ' ');    //% Recargo Equivalencia. 5.2
            Apunte += blanco.PadLeft(10, ' ');      // Num. Documento
            Apunte += blanco.PadLeft(3, ' ');       //Código de departamento
            Apunte += blanco.PadLeft(6, ' ');       //Código del proyecto
            Apunte += blanco;                       //Punteo (interno)
            Apunte += cero.PadLeft(6, ' ');         //Numérico de casación
            Apunte += cero;                         //Tipo de casado (interno)
            Apunte += cero.PadLeft(6, ' ');         //Número de pago
            Apunte += cero_seis.PadLeft(16, ' ');   //Cambio a aplicar 16.6
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte Debe moneda extranjera.   16.2
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte HABER moneda extranjera.  16.2
            Apunte += "*";                          //Interno
            Apunte += Serie.PadLeft(1,' ');         //Serie de la facturación
            Apunte += blanco.PadLeft(4, ' ');       //Sin uso
            Apunte += blanco.PadLeft(5, ' ');       //Código de la divisa
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte auxiliar moneda extranjera
            Apunte += "2";                          //Moneda de uso. 2=Euros
            Apunte += Debe.PadLeft(16, ' ');        // Importe al debe 16.2
            Apunte += Haber.PadLeft(16, ' ');       //Importe al Haber 16.2
            Apunte += cero_cero.PadLeft(16, ' ');   //Base Imponible del IVA 16.2
            Apunte += "F";                          //(interno)
            //Apunte += blanco.PadLeft(10, ' ');      //Código de Activo
            //Apunte += blanco;
            //Apunte += cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
            //Apunte += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
            //Apunte += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
            //Apunte += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

            return Apunte ;
        }//private string ApunteAsiento

        private void frmEXPORT_CPLUS_CobORE_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);
            Seguridad();
            lRD.Text = lRR.Text = lRV.Text = "";
            lFichero.Text = "";
        }   //private void frmEXPORT_CPLUS_CobORE_Load(object sender, EventArgs e)

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":   //Llorens
                    break;
                case "2":   //Carabal
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            //button_Mantenimiento.Visible = false;
                            //button_Facturas.Enabled = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "5":  //DialPesca
                    break;
                case "8":  //VALPEIX
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad

 
    }
}
