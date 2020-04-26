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
    public partial class frmFPVPropia : Form
    {
        public frmFPVPropia()
        {
            InitializeComponent();
        }

        private const int Col_Selecc = 0;
        private void frmFPVPropia_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("Entrada a  frmFPVPropia");
            this.Text = "Facturas Propias " + GloblaVar.VERSION;

            if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
            {
                lFechaFin.Visible = true;
                dateTimePicker_Fin.Visible = true;

                lFechaFactura.Visible = true;
                dateTimePicker_FechaFactura.Visible = true;

                panelPeriodicidad.Visible = true;

                cbPeriodicidad.Items.Add("<Seleccione>");
                cbPeriodicidad.Items.Add("Diaria");
                cbPeriodicidad.Items.Add("Semanal");
                cbPeriodicidad.Items.Add("Quincenal");
                cbPeriodicidad.Items.Add("Mensual");

                if(frmPpal.USUARIO == "5")
                {
                    cbPeriodicidad.SelectedIndex = 1; //Al cargar muestre periodicidad=Diaria
                }
                else
                {
                    cbPeriodicidad.SelectedIndex = 0;
                }                
            }

            CargardGV();               
        } 

        private void CargardGV()
        {
            string periodicidad = "";
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
                string sQ = "SELECT ALB.VenAlb as Albaran, ALB.VenFec as Fecha, ALB.DetCod as [Cod.Det], DET.DetNom as [Nom.Det], ALB.VenBru as BImp,";
                sQ += "ALB.VenIVA as IVA, ALB.VenRec as Recargo, ALB.Ventot as TOTAL";
                sQ += " FROM VENALB_CABE ALB LEFT JOIN DETALLISTAS DET ON ALB.DetCod=DET.DetCod";
                sQ += " WHERE";
                if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
                {
                    sQ += " ALB.VenFec>='" + Convert.ToDateTime(dateTimePicker_Inicio.Text).ToShortDateString() + "' AND ALB.VenFec<='" + Convert.ToDateTime(dateTimePicker_Fin.Text).ToShortDateString() + "'";
                }
                else
                {
                    sQ += " ALB.VenFec='" + Convert.ToDateTime(dateTimePicker_Inicio.Text).ToShortDateString() + "'";
                }                   
                    
                sQ += " AND";
                if (GloblaVar.gCERCLE_105==true) { sQ += " ALB.VenTve IN (4,5)"; } else { sQ += " ALB.VenTve=4"; }
                
                sQ += " AND";
                sQ += " ALB.VenNfp IS NULL";
                sQ += " AND ALB.Anulado<>1";

                if (!string.IsNullOrEmpty(tDetIni.Text))
                {
                    if(!string.IsNullOrEmpty(tDetFin.Text))
                    {
                        sQ += " AND ALB.DetCod>=" + Convert.ToInt32(tDetIni.Text) + " AND ALB.DetCod<=" + Convert.ToInt32(tDetFin.Text);
                    }
                    else
                    {
                        sQ += " AND ALB.DetCod=" + Convert.ToInt32(tDetIni.Text);
                    }
                }

                if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
                {

                    switch (cbPeriodicidad.SelectedItem.ToString())
                    {
                        case "Diaria":
                            periodicidad = "D";
                            break;
                        case "Semanal":
                            periodicidad = "S";
                            break;
                        case "Quincenal":
                            periodicidad = "Q";
                            break;
                        case "Mensual":
                            periodicidad = "M";
                            break;
                        default:
                            break;
                    }

                    if (periodicidad != "")
                    {
                        sQ += " AND DET.detcpm='" + periodicidad + "'";
                    }

                }

                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dGV1.DataSource = dt;

                DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();
                doWork.HeaderText = "Selecc";
                doWork.FalseValue = "0";
                doWork.TrueValue = "1";
                
                if (dGV1.Columns[0].HeaderText != "Selecc") { dGV1.Columns.Insert(0, doWork); }                

                dt.Dispose();
                da.Dispose();
                cmd.Dispose();

                lblTotalRegistros.Text = "Total Registros: " + dt.Rows.Count.ToString();
                
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            }
        }  // private void CargardGV()       

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Selecc_Todas_Click(object sender, EventArgs e)
        {            
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
        }

        //Antes creaba para cada albarán seleccionado una factura, ahora, a partir de la versión 3.01, crea una factura con todos los albaranes seleccionados de un detallista 
        private void btn_Grabar_Facturas_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + sender.ToString());

            if (MessageBox.Show("¿Seguro que desea emitir las facturas seleccionadas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                bool seleccion = false;
                this.Cursor = Cursors.WaitCursor;

                try
                {

                    List<dato_albaran> albaranesSeleccionados = new List<dato_albaran>();

                    DataGridViewCheckBoxCell CelChk;
                    foreach (DataGridViewRow Fila in dGV1.Rows)
                    {
                        CelChk = Fila.Cells[Col_Selecc] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(CelChk.EditedFormattedValue) == true)
                        {
                            //GloblaVar.gUTIL.SP4(Fila.Cells["Albaran"].Value.ToString(), Convert.ToDateTime(Fila.Cells["Fecha"].Value.ToString()).Year.ToString(), "AA");  

                            dato_albaran dato = new dato_albaran();
                            dato.VenAlb = Fila.Cells["Albaran"].Value.ToString();
                            dato.Anyo = Convert.ToDateTime(Fila.Cells["Fecha"].Value.ToString()).Year.ToString();
                            dato.CodDet = Fila.Cells["Cod.Det"].Value.ToString();

                            albaranesSeleccionados.Add(dato);

                            seleccion = true;

                        }
                    }

                    if(seleccion==true)
                    {
                        //obtiene los distintos detallistas (CodDet) de los albaranes que hemos seleccionado
                        var distinctCodDet = albaranesSeleccionados.GroupBy(x => x.CodDet).Select(group => group.First());

                        foreach (dato_albaran d in distinctCodDet)
                        {
                            //obtiene los albaranes de un detallista (CodDet)
                            ArrayList albaranesCodDet = new ArrayList(albaranesSeleccionados.Where(x => x.CodDet == d.CodDet).ToList());

                            if (frmPpal.USUARIO == "5" || frmPpal.USUARIO == "8")
                            {
                                Funciones.Facturar(d.CodDet, "AA", true, albaranesCodDet, GloblaVar.gConRem, dateTimePicker_FechaFactura.Text);
                            }
                            else
                            {
                                Funciones.Facturar(d.CodDet, "AA", true, albaranesCodDet, GloblaVar.gConRem, dateTimePicker_Inicio.Text);
                            }                     

                        }

                        CargardGV();                      

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar algún albarán para emitir la factura");
                    }                                    

                }
                catch (Exception ex)
                {
                    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                    MessageBox.Show(ex.ToString());
                }

                this.Cursor = Cursors.Default;  
            }

        }//private void btn_Grabar_Facturas_Click(object sender, EventArgs e)    
       

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            CargardGV();
        }

        private void dateTimePicker_Fin_ValueChanged(object sender, EventArgs e)
        {
            CargardGV();
        }

        private void llDetIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "DETALLISTAS";
            frmCONSULTA frmC = new frmCONSULTA();
            
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tDetIni.Text = GloblaVar.Cod_Buscado;
                lDetIni.Text = GloblaVar.Nom_Buscado;
            }  
        }

        private void llDetFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "DETALLISTAS";
            frmCONSULTA frmC = new frmCONSULTA();
            
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tDetFin.Text = GloblaVar.Cod_Buscado;
                lDetFin.Text = GloblaVar.Nom_Buscado;
            }  
        }

        private void tDetIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lDetIni.Text = Funciones.DameNomDet(tDetIni.Text);
                    tDetFin.Focus();
                }
                else
                {
                    //No habríamos de hacer nada ya que quedaría el texto como está
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        } 

        private void tDetFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lDetFin.Text = Funciones.DameNomDet(tDetFin.Text);
                }
                else
                {
                    //No habríamos de hacer nada ya que quedaría el texto como está
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tDetIni_TextChanged(object sender, EventArgs e)
        {
            CargardGV();
        }

        private void tDetFin_TextChanged(object sender, EventArgs e)
        {
            CargardGV();
        }

        private void cbPeriodicidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargardGV();
        }
    }
}
