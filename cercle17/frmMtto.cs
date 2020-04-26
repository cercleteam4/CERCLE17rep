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
    public partial class frmMtto : Form
    {
        public frmMtto()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void button_Usuarios_Click(object sender, EventArgs e)
        {
            frmMttoVENDEDORES Usuarios = new frmMttoVENDEDORES();
            Usuarios.CnO = CnO;
            Usuarios.Show();
        }

        private void button_Barcos_Click(object sender, EventArgs e)
        {
            frmMttoBARCOS Barcos = new frmMttoBARCOS();
            Barcos.CnO = CnO;
            Barcos.Show();
        }

        private void button_Control_Click(object sender, EventArgs e)
        {
            frmMttoCONTROL Control = new frmMttoCONTROL();
            string ivm51 = "";

            //select
            if (CnO != null)
            {
                string strQ = "SELECT ivm51 FROM CONTROL";
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        ivm51 = myReader[0].ToString();
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                Control.ivm51 = ivm51;
                if (Control.ShowDialog() == DialogResult.OK)
                {
                    if (Control.ivm51 != "")
                    {
                        //update
                        string update = "UPDATE CONTROL SET ivm51=" + Control.ivm51.Replace(",", ".");

                        SqlCommand myCommand = new SqlCommand(update, CnO);
                        int res = myCommand.ExecuteNonQuery();

                        if (res > 0)
                        {
                            MessageBox.Show("CONTROL actualizado");
                        }
                        else
                        {
                            MessageBox.Show("No pudo actualizarse CONTROL");
                        }
                    }
                }
            }
        }

        private void frmMtto_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);
            this.Text = " MANTENIMIENTO   " + GloblaVar.VERSION;

            //mostrar y ocultar botones según cliente (USUARIO)
            //button_Barcos.Visible = false;
            //button_Control.Visible = false;
            //button_Usuarios.Visible = false;

            //switch (frmPpal.USUARIO)
            //{
            //    case "1":
            //        button_Barcos.Visible = true;
            //        button_EXPORT_Sbta_Det.Visible = false;
            //        break;
            //    case "2":
            //        button_Barcos.Visible = true;
            //        button_EXPORT_Sbta_Det.Visible = true;
            //        button_EXPORT_Sbta_Prov.Visible = true;
            //        button_Usuarios.Visible = true;
            //        break;
            //    default:
            //        button_Barcos.Visible = false;
            //        button_Control.Visible = false;
            //        button_Usuarios.Visible = false;
            //        break;
            //}
            Seguridad();
        }   //private void frmMtto_Load(object sender, EventArgs e)


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
                            button_Barcos.Visible = true;
                            button_Usuarios.Visible = true;
                            button_Control.Visible = true;
                            button_Control.Visible = true;
                            button_EXPORT_Sbta_Det.Visible = true;
                            button_EXPORT_Sbta_Prov.Visible = true;
                            button_Detallistas.Visible = true;
                            button_Articulos.Visible = true;
                            break;
                        case "VENDECOMPRA":
                            break;
                        case "CONTABILIDAD":
                            button_Barcos.Visible = true;
                            break;
                        case "CAJERO":
                            button_Articulos.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad


        private void button_EXPORT_Sbta_Det_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sQ = @"SELECT * FROM DETALLISTAS";
            string Linea = "";  //Linea que conformaremos para escribir en el fichero

            if (! Directory.Exists(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus"))
            {
                Directory.CreateDirectory(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus");
            }
            else
            {
            }
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\SUBCUENTAS_DET_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            string fichero_asientos = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\ASIENTOS_DET_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter tw = new StreamWriter(fichero);
            TextWriter tw_asiento = new StreamWriter(fichero_asientos);
            string SubCuenta;
            int asiento = 1;
            string L1 = "";
            string L2 = "";
            string L3 = "";
            string L4 = "";
            string L5 = "";

            try
            {
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader LectorD = null;
                LectorD = cmd.ExecuteReader();
                while (LectorD.Read())
                {
                    SubCuenta = LectorD["SubCta"].ToString();
                    L1 = asiento.ToString().PadLeft (6,' ')+"20151123";
                    L2 = asiento.ToString().PadLeft(6, ' ') + "20151123570000000   ";
                    L3 = asiento.ToString().PadLeft(6, ' ') + "20151123570000000   ";
                    L4 = asiento.ToString().PadLeft(6, ' ') + "20151123477000021   ";
                    L5 = L1;    

                    L1+=SubCuenta;
                    L1+="   700000000               0.00n/Factura                            0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002          100.99            0.00            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L2 += SubCuenta;
                    L2 += "               0.00Cobro n/Factura                      0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002          100.99            0.00            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L3 += SubCuenta;
                    L3 += "               0.00n/Factura                            0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00           83.46            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L4 += SubCuenta;
                    L4 += "               0.00n/Factura                            0.00       0            0.0021.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00           17.53           83.46F                  0            0.00            0.00F        EF      F            F        20151123                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                112345678Z      Cuenta de cliente prueba                         F          FF            0.00            0                                        EG                                        F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 1                                        ";
                    L5 += SubCuenta;
                    L5 += "   570000000               0.00Cobro n/Factura                      0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00          100.99            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";


                    Linea = "";
                    Linea += LectorD["SubCta"].ToString().PadRight(12, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetNom"].ToString().PadRight(40, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetNif"].ToString().PadRight(15, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetVia"].ToString().PadRight(35, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetMun"].ToString().PadRight(25, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetPro"].ToString().PadRight(20, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["DetCop"].ToString().PadRight(5, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += "        "; //Divisa (1 caracter) y código de divisa (5 caracteres), Documento (1),Ajustes ME(1)
                    Linea += "G"; // Tipo IVA G.-Regimen General
                    GloblaVar.gUTIL.ATraza(Linea);
                    tw.WriteLine(Linea);
                    tw_asiento.WriteLine(L1);
                    tw_asiento.WriteLine(L2);
                    tw_asiento.WriteLine(L3);
                    tw_asiento.WriteLine(L4);
                    tw_asiento.WriteLine(L5);
                    asiento++;

                }// while (LectorD.Read())
                LectorD.Dispose();
                cmd.Dispose();
                tw.Close();
                tw_asiento.Close();
                MessageBox.Show("Fichero de SubCuentas Generado: " + fichero);
                GloblaVar.gUTIL.ATraza("Fichero de SubCuentas Generado: " + fichero);
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent +" " + ex.Message );
                GloblaVar.gUTIL.ATraza(gIdent + "ERROR " + ex);
            }
            //MessageBox.Show("YA");
           

        } //private void button_EXPORT_Sbta_Det_Click(object sender, EventArgs e)

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------SALIENDO de " + this.GetType().FullName);
            this.Close();

        }//private void button_Salir_Click(object sender, EventArgs e)

        private void button_EXPORT_Sbta_Prov_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sQ = @"SELECT * FROM PROVEEDORES";
            string Linea = "";  //Linea que conformaremos para escribir en el fichero

            if (!Directory.Exists(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus"))
            {
                Directory.CreateDirectory(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus");
            }
            else
            {
            }
            string fichero = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\SUBCUENTAS_PROV_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            string fichero_asientos = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "\\OREMAPE\\ContaPlus\\ASIENTOS_PROV_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString().PadLeft(2, '0') + DateTime.Today.Day.ToString().PadLeft(2, '0') + ".txt";
            TextWriter tw = new StreamWriter(fichero);
            TextWriter tw_asiento = new StreamWriter(fichero_asientos);
            string SubCuenta;
            int asiento = 1;
            string L1 = "";
            string L2 = "";
            string L3 = "";
            string L4 = "";
            string L5 = "";

            try
            {
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader LectorD = null;
                LectorD = cmd.ExecuteReader();
                while (LectorD.Read())
                {
                    SubCuenta = LectorD["SubCta"].ToString();
                    L1 = asiento.ToString().PadLeft(6, ' ') + "20151123";
                    L2 = asiento.ToString().PadLeft(6, ' ') + "20151123570000000   ";
                    L3 = asiento.ToString().PadLeft(6, ' ') + "20151123570000000   ";
                    L4 = asiento.ToString().PadLeft(6, ' ') + "20151123477000021   ";
                    L5 = L1;

                    L1 += SubCuenta;
                    L1 += "   700000000               0.00n/Factura                            0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002          100.99            0.00            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L2 += SubCuenta;
                    L2 += "               0.00Cobro n/Factura                      0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002          100.99            0.00            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  T   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L3 += SubCuenta;
                    L3 += "               0.00n/Factura                            0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00           83.46            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";
                    L4 += SubCuenta;
                    L4 += "               0.00n/Factura                            0.00       0            0.0021.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00           17.53           83.46F                  0            0.00            0.00F        EF      F            F        20151123                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                112345678Z      Cuenta de cliente prueba                         F          FF            0.00            0                                        EG                                        F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 1                                        ";
                    L5 += SubCuenta;
                    L5 += "   570000000               0.00Cobro n/Factura                      0.00       0            0.00 0.00 0.00Doc1                     00     0        0.000000            0.00            0.00                       0.002            0.00          100.99            0.00F                  0            0.00            0.00F        EF      F            F                                0.00 0.00     0            0.00                                                                                                                                                                                                                1                                                                                0                                                                F          FF            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0 0         0                       0.00FF 0                                        ";


                    Linea = "";
                    Linea += LectorD["SubCuenta"].ToString().PadRight(12, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProNom"].ToString().PadRight(40, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProCif"].ToString().PadRight(15, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProDom"].ToString().PadRight(35, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProPob"].ToString().PadRight(25, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProvIncia"].ToString().PadRight(20, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += LectorD["ProCop"].ToString().PadRight(5, ' ');
                    //GloblaVar.gUTIL.ATraza(Linea);
                    Linea += "        "; //Divisa (1 caracter) y código de divisa (5 caracteres), Documento (1),Ajustes ME(1)
                    Linea += "G"; // Tipo IVA G.-Regimen General
                    GloblaVar.gUTIL.ATraza(Linea);
                    tw.WriteLine(Linea);
                    tw_asiento.WriteLine(L1);
                    tw_asiento.WriteLine(L2);
                    tw_asiento.WriteLine(L3);
                    tw_asiento.WriteLine(L4);
                    tw_asiento.WriteLine(L5);
                    asiento++;

                }// while (LectorD.Read())
                LectorD.Dispose();
                cmd.Dispose();
                tw.Close();
                tw_asiento.Close();
                MessageBox.Show("Fichero de SubCuentas Generado: " + fichero);
                GloblaVar.gUTIL.ATraza("Fichero de SubCuentas Generado: " + fichero);
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + " " + ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + "ERROR " + ex);
            }
            //MessageBox.Show("YA");
           

        }

        private void button_Detallistas_Click(object sender, EventArgs e)
        {
            frmMttoDETALLISTAS Detallistas = new frmMttoDETALLISTAS();
            Detallistas.CnO = CnO;
            Detallistas.Show();
        }

        private void button_Articulos_Click(object sender, EventArgs e)
        {
            frmMttoARTICULOS Articulos = new frmMttoARTICULOS();
            Articulos.CnO = CnO;
            Articulos.Show();
        }  

        // private void button_EXPORT_Sbta_Prov_Click(object sender, EventArgs e)

    }   //public partial class frmMtto : Form

  
}   //namespace cercle17
