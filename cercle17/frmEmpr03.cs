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
    public partial class frmEmpr03 : Form
    {
        public frmEmpr03()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void button_ExportarExcel_Click(object sender, EventArgs e)
        {

             try
             {
                 string queryCompras = @"SELECT cc.ComCpa as [Nº Alb.], cc.Anyo as Año, cc.ComCfa as Fecha, cc.ProCod as [Cód. Prov.], p.Pronom as [Nombre proveedor], cl.ComLnl as [Línea], cl.ArtCod as [Cód. Art.], a.ArtDes as [Descripción artículo], cl.ComLca as Cajas, cl.ComLki as Kilos, cl.ComLpr as Precio, cl.ComLim as Importe
                                         FROM [dbo].[COMALB_CABE] as cc
                                         INNER JOIN [dbo].[COMALB_LINEAS] as cl ON cl.ComLpa = cc.ComCpa and cl.Anyo=cc.Anyo
                                         LEFT JOIN [dbo].[ARTICULOS] as a ON a.ArtCod = cl.ArtCod
                                         LEFT JOIN [dbo].[PROVEEDORES] as p ON p.ProCod = cc.ProCod 
                                         WHERE cc.ComCfa ='" + dtpFecha.Text + "' ORDER BY cc.ComCpa, cl.ComLnl";

                 string queryVentas = @"SELECT vc.VenAlb as [Nº Alb.], vc.Anyo as Año, vc.venFec as Fecha, vc.DetCod as [Cód. Det.], d.DetNom as [Nombre detallista], vc.VenBru as [Base imponible], vc.VenIva as Iva, vc.VenRec as Recargo, vc.VenTot as Total, vl.VelLin as [Línea], vl.ArtCod as [Cód. Art.], a.ArtDes as [Descripción artículo], vl.VelBul as Cajas, vl.VelKil as Kilos, vl.VelPre as Precio, vl.VelImp as Importe, vl.VelTrz as Traza
                                        FROM [dbo].[VENALB_CABE] as vc
                                        INNER JOIN [dbo].[VENALB_LINEAS] as vl ON vl.VelAlb = vc.VenAlb and vl.Anyo=vc.Anyo
                                        LEFT JOIN [dbo].[ARTICULOS] as a ON a.ArtCod = vl.ArtCod
                                        LEFT JOIN [dbo].[DETALLISTAS] as d ON d.DetCod = vc.DetCod  
                                        WHERE venFec='" + dtpFecha.Text + "' ORDER BY vc.VenAlb, vl.VelLin";

                DataTable dtCompras = new DataTable();
                DataTable dtVentas = new DataTable();

                using (SqlCommand cmd = new SqlCommand(queryCompras, CnO))
                {                                  
                    SqlDataAdapter da = new SqlDataAdapter(cmd);                    
                    da.Fill(dtCompras);                  
                }

                 using (SqlCommand cmd = new SqlCommand(queryVentas, CnO))
                 {
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     da.Fill(dtVentas); 
                 }

                ExportarComprasVentas(dtCompras, dtVentas);

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Al exportar a excel se ha producido el siguiente error: \n\n" + ex.Message);
             }

             MessageBox.Show("La exportación se ha realizado correctamente");           

        }

        private void ExportarComprasVentas(DataTable dtCompras, DataTable dtVentas)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            DateTime fecha = Convert.ToDateTime(dtpFecha.Text);
            fichero.FileName = "Compras_Ventas_" + fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0');
            fichero.Filter = "Excel (*.xls)|*.xls";

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook librosTrabajo;
                Microsoft.Office.Interop.Excel.Worksheet hojaTrabajoCompras;
                Microsoft.Office.Interop.Excel.Worksheet hojaTrabajoVentas;

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                librosTrabajo = aplicacion.Workbooks.Add();

                hojaTrabajoCompras = (Microsoft.Office.Interop.Excel.Worksheet)librosTrabajo.Worksheets.get_Item(1);
                hojaTrabajoCompras.Name = "COMPRAS";

                hojaTrabajoVentas = (Microsoft.Office.Interop.Excel.Worksheet)librosTrabajo.Worksheets.get_Item(2);
                hojaTrabajoVentas.Name = "VENTAS";

                //COMPRAS
                //Cabecera
                for (int i = 0; i < dtCompras.Columns.Count; i++)
                {
                    hojaTrabajoCompras.Cells[1, i + 1] = dtCompras.Columns[i].ColumnName;
                }

                //Filas 
                for (int i = 0; i < dtCompras.Rows.Count; i++)
                {
                    for (int j = 0; j < dtCompras.Columns.Count; j++)
                    {
                        hojaTrabajoCompras.Cells[i + 2, j + 1] = dtCompras.Rows[i][j].ToString();
                    }
                }


                //VENTAS
                //Cabecera
                for (int i = 0; i < dtVentas.Columns.Count; i++)
                {
                    hojaTrabajoVentas.Cells[1, i + 1] = dtVentas.Columns[i].ColumnName;
                }

                //Filas 
                for (int i = 0; i < dtVentas.Rows.Count; i++)
                {
                    for (int j = 0; j < dtVentas.Columns.Count; j++)
                    {
                        hojaTrabajoVentas.Cells[i + 2, j + 1] = dtVentas.Rows[i][j].ToString();
                    }
                } 
 
                librosTrabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                librosTrabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void button_CUADRE_Click(object sender, EventArgs e)
        {
            frmEmpr03_CUADRE frmE3C = new frmEmpr03_CUADRE();
            frmE3C.Show();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("SALIENDO de " + gIdent);
            this.Close();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
