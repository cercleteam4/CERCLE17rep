using System;
using System.Collections;
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
    public partial class frmFPVAbono1 : Form
    {

        ArrayList Lista_Albaranes = new ArrayList();
        string sQ = "";

        public frmFPVAbono1()
        {
            InitializeComponent();
        }
        private void CargarGrid()
        {
            //dGV1.C
            sQ = "SELECT AC.Albaran,AC.Fecha,AC.Anyo,AC.DetCod,D.DetNom as CLIENTE, AC.BI1 as BImp,AC.IVA1,AC.RE1,AC.Total ";
            sQ += "  FROM ABONG_CABE as AC  INNER JOIN DETALLISTAS as D ON AC.DetCod=D.DetCod ";
            sQ += " WHERE Factura IS NULL";
            SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dGV1.DataSource = dt;
            dGV1.Refresh();
            dt.Dispose();
            da.Dispose();
            cmd.Dispose();
        }//private void CargarGrid
        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2": //Carabal
                    //button3.Visible = false;
                    //button4.Visible = false;
                    CargarGrid();
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            panel1.Visible = true;

                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            panel1.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
            } //switch(frmPpal.USUARIO )
        }  //private void Seguridad()

        private void frmFPVAbono1_Load(object sender, EventArgs e)
        {
            Seguridad();
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + sender.ToString());

            string Albaran = dGV1.CurrentRow.Cells["Albaran"].Value.ToString();
            string Fecha = dGV1.CurrentRow.Cells["Fecha"].Value.ToString();
            string Año = dGV1.CurrentRow.Cells["Anyo"].Value.ToString();
            //string Det = dGV1.CurrentRow.Cells["C_Det"].Value.ToString();
            //string BI = dGV1.CurrentRow.Cells["BI1"].Value.ToString();
            //string IVA = dGV1.CurrentRow.Cells["IVA1"].Value.ToString();
            //string RE = dGV1.CurrentRow.Cells["RE1"].Value.ToString();
            //string Total = dGV1.CurrentRow.Cells["Total"].Value.ToString();
            //string Vendedor = dGV1.CurrentRow.Cells["C_Vend"].Value.ToString();
            //Cobrar_Albaran(Albaran, Fecha, Año, Det, BI, IVA, RE, Total, Vendedor);

           
                int a = 2;
                if (a == 1)
                {
                    MessageBox.Show("Fase de PRUEBAS. Todavia no facture abonos.");
                    this.Close();
                }
                else
                {

                    clase_ABONG_CABE AlbAbono = new clase_ABONG_CABE();
                    ArrayList Lista_Lineas_Abono = new ArrayList();
                    clase_linea_factura linea_abono = null;
                    string idFactura = "";

                    if (AlbAbono.CargaAlbaran(Albaran, Año))
                    {
                        string error = Comprobaciones(AlbAbono);
                        if (error == "")
                        {
                            //idFactura = Funciones.FacturarAbono1(AlbAbono, "AB", "Albaran de Abono de " + Funciones.DameNomDet(AlbAbono.DetCod.ToString()));
                            idFactura = Funciones.FacturarAbono1(AlbAbono, "AB", "La presente FACTURA RECTIFICATIVA modifica la factura NÚMERO: " + AlbAbono.RectificaFact + "  AÑO: " + AlbAbono.RectificaAnyoFact + "  SERIE: " + AlbAbono.RectificaSerieFact);

                        }                         
                        else
                        {
                            MessageBox.Show(error);
                        }


                       


                    }   //if (AlbAbono.CargaAlbaran(Albaran,Año))



                    if (idFactura != "")
                    {
                        AlbAbono = null;
                        MessageBox.Show("La FACTURA RECTIFICATIVA se ha generado correctamente. \n \n Numero de FACTURA: " + idFactura );
                        CargarGrid();
                    }
                }

           

        } //private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)

        private string Comprobaciones(clase_ABONG_CABE albAbono)
        {
            string mensaje = "";

            //int? rectificaAlb1 = albAbono.RectificaAlb;
            string rectificaAlb = albAbono.RectificaAlb.ToString();
            string rectificaAnyoAlb = albAbono.RectificaAnyoAlb.ToString(); ;
            string rectificaFact = albAbono.RectificaFact.ToString();
            string rectificaAnyoFact = albAbono.RectificaAnyoFact.ToString();
            string rectificaSerieFact = albAbono.RectificaSerieFact.ToString();

            string venNfp = "";
            string anyoFra = "";
            string serieFra = "";


            //El abono tiene albarán de origen
            if (!string.IsNullOrEmpty(rectificaAlb) && !string.IsNullOrEmpty(rectificaAnyoAlb))
            {
                //El abono no tiene referencia a factura porque el albarán no estaba facturado todavía en el momento de la creación del abono
                //Deberemos comprobar si ahora el albarán ya está facturado
                if (string.IsNullOrEmpty(rectificaFact) && string.IsNullOrEmpty(rectificaAnyoFact) && string.IsNullOrEmpty(rectificaSerieFact))
                {
                    string sql = @"SELECT VenAlb, Anyo, VenNfp, AnyoFra, SerieFra 
                                    FROM VENALB_CABE 
                                    WHERE VenAlb=@Albaran and Anyo=@Anyo";

                    using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
                    {
                        cmd.Parameters.AddWithValue("@Albaran", rectificaAlb);
                        cmd.Parameters.AddWithValue("@Anyo", rectificaAnyoAlb);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                venNfp = reader["VenNfp"].ToString();
                                anyoFra = reader["AnyoFra"].ToString();
                                serieFra = reader["SerieFra"].ToString();                               
                            }
                        }                       

                        reader.Close();

                    }

                    //Ahora está facturado el albarán
                    if(!string.IsNullOrEmpty(venNfp) && !string.IsNullOrEmpty(anyoFra) && !string.IsNullOrEmpty(serieFra))
                    {
                        albAbono.RectificaFact = int.Parse(venNfp);
                        albAbono.RectificaAnyoFact = int.Parse(anyoFra);
                        albAbono.RectificaSerieFact = serieFra;

                        //Modificamos el abono y le añadimos los datos de la factura 
                        sql = @"UPDATE ABONG_CABE SET RectificaFact=" + albAbono.RectificaFact + ",RectificaAnyoFact=" + albAbono.RectificaAnyoFact + ",RectificaSerieFact='" + albAbono.RectificaSerieFact + "'";
                        sql += " WHERE Albaran=" + albAbono.Albaran + " AND Anyo=" + albAbono.Anyo;

                        int resUpdateAlbNG = Funciones.EjecutaNonQuery(sql, GloblaVar.gConRem);

                    }
                    else
                    {
                        //El albarán de origen no está facturado por el mayorista pero puede haberlo facturado OREMAPE
                        if(MessageBox.Show("El albarán de origen no está facturado, \n¿desea introducir los datos de la factura de OREMAPE?", "", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                        {
                            frmDatosFactOremape DatosFactOremape = new frmDatosFactOremape();
 
                            if(DatosFactOremape.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                albAbono.RectificaFact = int.Parse(DatosFactOremape.OremapeFactura);
                                albAbono.RectificaAnyoFact = int.Parse(DatosFactOremape.OremapeAñoFact);
                                albAbono.RectificaSerieFact = DatosFactOremape.OremapeSerieFact;

                                //Modificamos el abono y le añadimos los datos de la factura de OREMAPE
                                sql = @"UPDATE ABONG_CABE SET RectificaFact=" + albAbono.RectificaFact + ",RectificaAnyoFact=" + albAbono.RectificaAnyoFact + ",RectificaSerieFact='" + albAbono.RectificaSerieFact + "'";
                                sql += " WHERE Albaran=" + albAbono.Albaran + " AND Anyo=" + albAbono.Anyo;

                                int resUpdateAlbNG = Funciones.EjecutaNonQuery(sql, GloblaVar.gConRem);

                            }
                            else
                            {
                                mensaje = "El albarán de origen no está facturado";
                            }

                        }
                        else
                        {
                            mensaje = "El albarán de origen no está facturado";
                        }                        
                    }
                }
            }
            else
            {
                mensaje = "El abono no tiene albarán de origen";
            }

            return mensaje;

        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("---------------------- SALIENDO de " + this.GetType().FullName);
            this.Close();
        } 
    }
}
