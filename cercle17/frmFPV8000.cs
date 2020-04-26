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
    public partial class frmFPV8000 : Form
    {
        public frmFPV8000()
        {
            InitializeComponent();
        }

        private const int Col_Selecc = 0;
        private void frmFPV8000_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("Entrada a  frmFPV8000");
            this.Text = "Facturas de 8000 diarias " + GloblaVar.VERSION;
 //           dTP1.Text = DateTime.Today.ToShortDateString();
            CargardGV();
            Seguridad();
            Calcula_Totales();
        }  // private void frmFPV8000_Load(object sender, EventArgs e)

        private void CargardGV()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            int cols_A_quitar;
            try
            {
                cols_A_quitar = dGV1.ColumnCount  - 7;
                if (cols_A_quitar > 0) 
                { 
                    //for (int i=1;i<=cols_A_quitar;i++)
                    //{
                    //dGV1.Columns.Remove("Selecc");

                    //}
                }

                dGV1.Refresh();
                string sQ = "SELECT VenAlb as Albaran,VenFec as Fecha, DetNuevo as Nombre, VenBru as BImp,VenIVA as IVA,VenRec as Recargo,Ventot as TOTAL FROM VENALB_CABE ";
                sQ += " WHERE ";
                sQ += " VenFec='" + Convert.ToDateTime(dTP1.Text).ToShortDateString() +"'";
                sQ += " AND ";
                sQ += " DetCod=8000 ";
                sQ += " AND ";
                sQ += " VenNfp IS NULL  ";
                sQ += " AND Anulado<>1 ";

                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dGV1.DataSource = dt;

                DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
                doWork.HeaderText = "Selecc";
                doWork.FalseValue = "0";
                doWork.TrueValue = "1";
                if (dGV1.Columns[0].HeaderText != "Selecc") { dGV1.Columns.Insert(0, doWork); } //else { }
                

                dt.Dispose();
                da.Dispose();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            }
        }  // private void CargardGV()

        private void Calcula_Totales()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                decimal Total = 0;
                decimal TotalSel = 0;
                decimal TotalFila=0;
                foreach (DataGridViewRow Fila in dGV1.Rows)
                {
                    DataGridViewCheckBoxCell CelChk;
                    if ((dGV1.RowCount > 1) && ( Fila.Index < dGV1.RowCount-1) ) 
                    {
                        TotalFila = Convert.ToDecimal(Fila.Cells["TOTAL"].Value.ToString());
                        CelChk = Fila.Cells[Col_Selecc] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(CelChk.EditedFormattedValue) == false)
                        {
                            Total = Total + TotalFila;
                            
                        }
                        else
                        {
                            Total = Total + TotalFila;
                            TotalSel = TotalSel + TotalFila;
                        }                    
                    }

                }
                lTotal.Text = Total.ToString();
                lTotalSelecc.Text = TotalSel.ToString();
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
            }

        }  //private void Calcula_Totales()

        private void dTP1_ValueChanged(object sender, EventArgs e)
        {
            CargardGV();
            Calcula_Totales();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Selecc_Todas_Click(object sender, EventArgs e)
        {
            //DataGridViewRow Fila;
            DataGridViewCheckBoxCell oCell;
            bool bChecked;
            switch (btn_Selecc_Todas.Text)
            {
                case "Todas":
                    bChecked = true;
                    foreach (DataGridViewRow row in dGV1.Rows)
                    {
                        oCell = row.Cells[Col_Selecc ] as DataGridViewCheckBoxCell;
                        if (row.Index < dGV1.RowCount - 1) { row.Cells[Col_Selecc].Value = bChecked; }
                    }
                    btn_Selecc_Todas.Text = "Ninguna";
                    break;
                case "Ninguna":
                    bChecked = false;
                    foreach (DataGridViewRow row in dGV1.Rows)
                    {
                        oCell = row.Cells[Col_Selecc] as DataGridViewCheckBoxCell;
                        if (row.Index < dGV1.RowCount - 1) { row.Cells[Col_Selecc].Value = bChecked; }
                    }

                    btn_Selecc_Todas.Text = "Todas";
                    break;
            }
            Calcula_Totales();
        }   //private void btn_Selecc_Todas_Click(object sender, EventArgs e)

        private void btn_Grabar_Facturas_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + sender.ToString());

            try
            {
                const Int32 col_Albaran = 1;
                const Int32 col_Fecha = 2;
                DataGridViewCheckBoxCell CelChk;
                foreach (DataGridViewRow Fila in dGV1.Rows)
                {
                    CelChk=Fila.Cells[Col_Selecc ] as DataGridViewCheckBoxCell ;
                    if (Convert.ToBoolean(CelChk.EditedFormattedValue)==true)
                    {

                        GloblaVar.gUTIL.SP4(Fila.Cells["Albaran"].Value.ToString(), Convert.ToDateTime(Fila.Cells["Fecha"].Value.ToString()).Year.ToString(), "AA");
                        //CargardGV();
                        //clase__FACTURA F8 = new clase__FACTURA();

                        //F8.Serie = "AA";
                        //string a = Fila.Cells["Fecha"].Value.ToString();
                        //F8.Anyo = Convert.ToInt32(Convert.ToDateTime(Fila.Cells[col_Fecha].Value.ToString()).Year);
                        //F8.Obten_Factura();
                        //clase_albaran Alb=new clase_albaran();
                        //Alb.Albaran=Fila.Cells["Albaran"].Value.ToString();
                        //Alb.Año=F8.Anyo.ToString() ;
                        //F8.Lista_Albs.Add(Alb);

                    } //if (Fila.Cells["Selecc"].Value.Equals(true ))
                }  //foreach (DataGridViewRow Fila in dGV1.Rows)
                CargardGV();
                Calcula_Totales();
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                MessageBox.Show(ex.ToString());
            }

        }//private void btn_Grabar_Facturas_Click(object sender, EventArgs e)

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2": //Carabal
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            btn_Grabar_Facturas.Visible  = true;
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            btn_Grabar_Facturas.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad()

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==Col_Selecc )
            {
                DataGridViewCheckBoxCell cb = dGV1.Rows[e.RowIndex].Cells[Col_Selecc] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cb.EditedFormattedValue )==true)
                {

                }
                Calcula_Totales();
            }
        } // private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    }
}
