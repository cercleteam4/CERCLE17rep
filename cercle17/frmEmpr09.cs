using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace cercle17
{
    public partial class frmEmpr09 : Form
    {
        public frmEmpr09()
        {
            InitializeComponent();          
        }

        private void frmEmpr09_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " ENTRADA EN frmEmpr09");
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("SALIENDO de " + gIdent);
            this.Close();
        }

        private void btnExportarVentas_Click(object sender, EventArgs e)
        {
            btnExportarVentas.Enabled = false;

            string mensaje = "";

            mensaje = PreparaVENALB_CABE(dtpFechaDesde.Value, dtpFechaHasta.Value);

            if (mensaje == "")
            {
                string sql = @"SELECT case when(VC.VenTve=1) then 3 else 1 end as A
                                  ,VC.VenAlb as B      
                                  ,CONVERT(date,VC.VenFec) as D
	                              ,0 as E
	                              ,VC.AUX1 as F
                                  ,VC.AUX2 as I
	                              ,D.DetNom as J
	                              ,0 as P
	                              ,case when(VC.VenRec>0) then 1 else 0 end as Q
	                              ,VC.BI3 as S
	                              ,VC.BI1 as T
	                              ,VC.BI2 as U
	                              ,VC.BI3 as AT
	                              ,VC.BI1 as AU
	                              ,VC.BI2 as AV
	                              ,21.00 as AW
	                              ,10.00 as AX
	                              ,4.00 as AY
	                              ,VC.IVA3 as AZ
	                              ,VC.IVA1 as BA
	                              ,VC.IVA2 as BB
	                              ,5.20 as BC
	                              ,1.40 as BD
	                              ,0.50 as BE
	                              ,VC.Recargo3 as BF
	                              ,VC.Recargo1 as BG
	                              ,VC.Recargo2 as BH
	                              ,VC.VenTot as BK      
                              FROM VENALB_CABE as VC INNER JOIN DETALLISTAS as D ON VC.DetCod=D.DetCod
                              WHERE VC.VenFec>='" + dtpFechaDesde.Text + "' and VC.VenFec<='" + dtpFechaHasta.Text + "' and VC.Anulado=0 ORDER BY VC.VenAlb ASC";

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "ALB";                   

                    mensaje = excel.exportarExcelVentas(dtpFechaHasta.Value);                  

                    if (mensaje != "")
                    {
                        MessageBox.Show("Error al exportar las Cabeceras de ventas: \n" + mensaje);
                    }
                    else
                    {
                        sql = @"SELECT case when(VC.VenTve=1) then 3 else 1 end as A
	                               ,VL.VelAlb as B
	                               ,VL.VelLin as C
	                               ,VL.ArtCod as D
	                               ,A.ArtDes as E
	                               ,VL.VelKil as F
	                               ,VL.VelPre as J
	                               ,VL.VelImp as K
	                               ,case when(VL.PerCentIVA=21) then 0 else case when (VL.PerCentIVA=10) then 1 else case when (VL.PerCentIVA=4) then 2 else 3 end end end as L
	                               ,0 as Z
                            FROM VENALB_LINEAS as VL 
                            INNER JOIN VENALB_CABE as VC ON VL.VelAlb=VC.VenAlb AND VL.Anyo=VC.Anyo
                            INNER JOIN ARTICULOS as A ON VL.ArtCod=A.ArtCod
                            WHERE VL.VelFec>='" + dtpFechaDesde.Text + "' and VL.VelFec<='" + dtpFechaHasta.Text + "' and VC.Anulado=0 ORDER BY VL.VelAlb, VL.VelLin ASC";

                        excel.Query = sql;                       
                        excel.NombreFichero = "LAL";

                        mensaje = excel.exportarExcelVentas(dtpFechaHasta.Value);

                        if(mensaje != "")
                        {
                            MessageBox.Show("Error al exportar las Líneas de ventas: \n" + mensaje);
                        }
                        else
                        {
                            MessageBox.Show("La exportación de VENTAS a excel se ha realizado correctamente");
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }
            }
            else
            {
                MessageBox.Show(mensaje);
            }

            btnExportarVentas.Enabled = true;

        }

        private void btnExportarArticulos_Click(object sender, EventArgs e)
        {
            btnExportarArticulos.Enabled = false;

            string mensaje = "";

            mensaje = PreparaARTICULOS();

            if (mensaje == "")
            {
                string sql = "SELECT ArtCod as A, ArtDes as F, CuentaVentas as AF, case when(TipoIva=3) then 0 else case when (TipoIVA=1) then 1 else case when (TipoIVA=2) then 2 else 3 end end end as J ";
                sql += "FROM ARTICULOS ";
                sql += "ORDER BY ArtCod asc";

                string path = obtenerPath();

                if (!string.IsNullOrEmpty(path))
                {
                    clase_excel excel = new clase_excel();

                    excel.CnO = GloblaVar.gConRem;
                    excel.Query = sql;
                    excel.Path = path;
                    excel.NombreFichero = "ART";

                    mensaje = excel.exportarExcelArticulos(dtpFechaHasta.Value);
                    
                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje);
                    }
                    else
                    {
                        MessageBox.Show("La exportación de ARTÍCULOS a excel se ha realizado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                }
            }
            else
            {
                MessageBox.Show(mensaje);
            }

            btnExportarArticulos.Enabled = true;

        }

        private string obtenerPath()
        {
            string path = "";

            using (SqlCommand cmd = new SqlCommand("SELECT ConPathExcell FROM CONTROL", GloblaVar.gConRem))
            {
                path = Convert.ToString(cmd.ExecuteScalar());
            }

            return path;
        }

        private string PreparaARTICULOS()
        {
            string gIdent = "PreparaARTICULOS ";

            string error = "", query = "";

            try
            {
                query = @"UPDATE ARTICULOS SET CuentaVentas='7010000' where (ArtCod>=1 and ArtCod<=2999) or (ArtCod>=9000 and ArtCod<=9999);
                          UPDATE ARTICULOS SET CuentaVentas='7010001' where (ArtCod>=20000 and ArtCod<=20999) or (ArtCod>=30000 and ArtCod<=31100) or (ArtCod>=40000 and ArtCod<=40999);
                          UPDATE ARTICULOS SET CuentaVentas='7010007' where (ArtCod>=6000 and ArtCod<=6999);
                          UPDATE ARTICULOS SET CuentaVentas='7010009' where (ArtCod>=7000 and ArtCod<=7999);
                          UPDATE ARTICULOS SET CuentaVentas='7010008' where (ArtCod>=8000 and ArtCod<=8999);
                          UPDATE ARTICULOS SET CuentaVentas='7010010' where (ArtCod>=3000 and ArtCod<=3999);
                          UPDATE ARTICULOS SET CuentaVentas='7010004' where (ArtCod>=910200 and ArtCod<=9618000);
                          UPDATE ARTICULOS SET TipoIVA=1 where TipoIva is null;";

                int res = Funciones.EjecutaNonQuery(query, GloblaVar.gConRem);

            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                error += "Se ha producido un error en 'PreparaARTICULOS': \n\n" + ex.Message;
            }

            return error;

        }

        private string PreparaVENALB_CABE(DateTime fechaDesde, DateTime fechaHasta)
        {
            string gIdent = "PreparaVENALB_CABE ";

            int albaran, anyo, tablet, detCod, AUX2 = 0;
            string AUX1 = "";
            string query1, query2;
            
            DateTime venFec;

            string error = "";

            query1 = "SELECT VenAlb, VenFec, Anyo, Tablet, DetCod ";
            query1+= "FROM VENALB_CABE WHERE VenFec>='" + fechaDesde.ToShortDateString() + "' and VenFec<='" + fechaHasta.ToShortDateString() + "' and Anulado=0 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query1, GloblaVar.gConRem))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        albaran = Convert.ToInt32(reader["VenAlb"]);
                        anyo = Convert.ToInt32(reader["Anyo"]);                        
                        venFec = Convert.ToDateTime(reader["VenFec"]);
                        tablet = Convert.ToInt32(reader["Tablet"]);
                        detCod = Convert.ToInt32(reader["DetCod"]);                        

                        //Guardamos en el campo AUX1 el código del almacén
                        switch (tablet)
                        {
                            case 1:
                            case 2:
                            case 8:
                                if(detCod == 8000)
                                {
                                    AUX1 = "AL3";
                                }
                                else
                                {
                                    AUX1 = "AL2";
                                }
                                break;

                            case 3:
                                AUX1 = "AL4";
                                break;

                            case 4:
                                AUX1 = "AL7";
                                break;

                            case 5:
                                AUX1 = "AL9";
                                break;

                            case 6:
                                AUX1 = "AL6";
                                break;

                            case 7:
                                AUX1 = "AL8";
                                break;

                        }

                        //Guardamos en AUX2 el código del detallista que tiene en Factusol
                        if (detCod == 8000)
                        {
                            AUX2 = 30001;
                        }

                        if (detCod >= 5 && detCod <= 7100)
                        {
                            AUX2 = 30000 + detCod;
                        }

                        if(detCod >= 30000)
                        {
                            AUX2 = detCod;
                        }

                        query2 = string.Format("UPDATE VENALB_CABE SET AUX1='{0}', AUX2={1} WHERE VenAlb={2} AND Anyo={3}", AUX1, AUX2, albaran, anyo);

                        int res = Funciones.EjecutaNonQuery(query2, GloblaVar.gConRem);

                    }

                    reader.Close();

                }
                

            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                error += "Se ha producido un error en 'PreparaVENALB_CABE': \n\n" + ex.Message;
            }

            return error;
        }

       

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    lblExcel.Visible = !lblExcel.Visible;
        //}
    }
}
