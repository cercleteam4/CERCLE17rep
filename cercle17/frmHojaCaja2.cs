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
using Microsoft.Office.Interop;
using System.IO;

namespace cercle17
{ 
    public partial class frmHojaCaja2 : Form
    {
        decimal CambioDA = 0;
        decimal TotalTalones = 0;
        decimal TotalCobros = 0;
        decimal TotalCaja = 0;
        decimal TotalPagos = 0;
        decimal Efectivo = 0;
        decimal Resto = 0;
        decimal CambioMañana = 0;
        decimal IngresoBanco = 0;
        decimal Descuadre = 0;
        decimal Cobros3 = 0;
        decimal Cobros8048 = 0;
        decimal CobrosFP = 0;


        public frmHojaCaja2()
        {
            InitializeComponent();
        }
        private void ToTaLiZa()
        {//Hara los calculos de la cakja del día y visualizará de forma pertinente

            CambioDA = Convert.ToDecimal(txt_CambioDA.Text.Replace(".", ","));
            TotalCobros = Convert.ToDecimal(lTotalCobros.Text.Replace(".", ","));
            TotalPagos= Convert.ToDecimal(lTotalPagos.Text.Replace(".", ","));
            Efectivo= Convert.ToDecimal(txtEFECTIVO.Text.Replace(".", ","));
            IngresoBanco= Convert.ToDecimal(txtINGRESOB.Text.Replace(".", ","));
            TotalTalones= Convert.ToDecimal(txtTALONES.Text.Replace(".", ","));
            TotalCaja = CambioDA + TotalCobros;
            Resto = TotalCaja - TotalPagos;
            txtResto.Text = Resto.ToString();
            Descuadre =  Efectivo + TotalTalones -Resto;
            lDescuadre.Text = Descuadre.ToString();
            PintaFondoLabel(lDescuadre, Descuadre);
        }

        private void frmHojaCaja2_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza(" ENTRANDO A " + this.GetType().FullName);
            this.Text = "CAJA DEL DIA " + GloblaVar.VERSION;
            Seguridad();
            //PresentaDatos(dTP_Fecha.Value.ToShortDateString());
        } //private void frmHojaCaja1_Load(object sender, EventArgs e)

        private void dTP_Fecha_ValueChanged(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                //PresentaDatos(dTP_Fecha.Value.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        } // private void dTP_Fecha_ValueChanged(object sender, EventArgs e)

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        } //private void btnSALIR_Click(object sender, EventArgs e)

        private void PresentaDatos(string Fecha)
        {//Presentará todos los datos en los dos datagrids dGIngr y dGGast
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";

            try
            {
                //Primero limpiamos los grid
                dGIngr.Rows.Clear();
                dGIngr.RowHeadersVisible = false;
                dGIngr.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dGGast.Rows.Clear();
                dGGast.RowHeadersVisible = false;
                dGTalo.Rows.Clear();
                dGTalo.RowHeadersVisible = false;
                TotalTalones = 0;
                TotalCobros = 0;
                TotalPagos = 0;
                Resto = 0;
                Efectivo = 0;

                //Calculamos el cambio del dia anterior
                DateTime fecha = Convert.ToDateTime(Fecha);
                string IdCaja = fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0');
                string sQ = "SELECT TOP 1 * FROM CAJADIA_VENTAS WHERE IdCaja<=" +IdCaja +" ORDER BY IdCaja DESC";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                if (rst["IdCaja"].ToString()==IdCaja )
                {//El registro es del dia actual. Cogemos el Cambio ya gradbado
                    txt_CambioDA.Text = rst["Cambio"].ToString();
                    txt_CambioDA.Text = Math.Round(Convert.ToDecimal(txt_CambioDA.Text), 2).ToString();
                }
                else
                { //El registro es de un dia anterior. Cogemos el cambioSigte del ultimo dia
                    
                    txt_CambioDA.Text = rst["CambioSgte"].ToString();
                    txt_CambioDA.Text = Math.Round(Convert.ToDecimal(txt_CambioDA.Text), 2).ToString();
                }
                rst.Close();
                cmd.Dispose();

                //AgregarFila(dGIngr, "Cobrado en el dia " + Fecha, CobradoDIA(Fecha));
                AgregarFila(dGIngr, "Cobrado en Caja el Dia " + Fecha, CobCajaDIA(Fecha));
                AgregarFila(dGIngr, "Cobrado Pendientes de 8048 del dia " + Fecha, CobPte8048(Fecha));
                FPs(Fecha);
                if (DevueltoOremape(Fecha) != "0.00") { AgregarFila(dGIngr, "Pte.o Cto.devuelto Oremape Cbdo.Caja", DevueltoOremape(Fecha)); }
                if (TotalCobradoTipo(Fecha, "53") != "0.00") { AgregarFila(dGIngr, "Credito Lista Cobrado caja 53", TotalCobradoTipo(Fecha, "53")); }
                if (TotalCobradoTipo(Fecha, "54") != "0.00") { AgregarFila(dGIngr, "Credito Lista Cobrado caja 54", TotalCobradoTipo(Fecha, "54")); }
                if (TotalCobradoTipo(Fecha, "55") != "0.00") { AgregarFila(dGIngr, "Credito Lista Cobrado cajao 55", TotalCobradoTipo(Fecha, "55")); }
                if (TotalCobradoTipo(Fecha, "56") != "0.00") { AgregarFila(dGIngr, "Credito Lista Cobrado caja 56", TotalCobradoTipo(Fecha, "56")); }
                if (TotalCobradoTipo(Fecha, "57") != "0.00") { AgregarFila(dGIngr, "Credito Pendiente en Lista", TotalCobradoTipo(Fecha, "57")); }
                if (TotalCobradoTipo(Fecha, "58") != "0.00") { AgregarFila(dGIngr, "Credito en Lista", TotalCobradoTipo(Fecha, "58")); }


                CargaPagos(Fecha);

                double Total_Ingresos = 0;
                //Total_Ingresos += Convert.ToDouble(txt_CambioDA.Text);  //El Cambio del Dia Anterior debe incluirse en los Ingresos
                for (int i = 0; i < dGIngr.Rows.Count; i++)
                {
                    if (dGIngr.Rows[i].Cells[1].Value != null)
                    {
                        if (dGIngr.Rows[i].Cells[1].Value.ToString() != "") { Total_Ingresos += Convert.ToDouble(dGIngr.Rows[i].Cells[1].Value); }

                    }
                }//for (int i=1; i==dGIngr.RowCount; i++)
                TotalCobros = Math.Round(Convert.ToDecimal(Total_Ingresos),2);
                //Total_Ingresos += Convert.ToDouble(txt_CambioDA.Text.ToString());
                lTotalCobros.Text = TotalCobros.ToString();
                double Total_Pagos = 0;
                for (int i = 0; i < dGGast.Rows.Count; i++)
                {
                    if (dGGast.Rows[i].Cells[2].Value != null)
                    {
                        if (dGGast.Rows[i].Cells[2].Value.ToString() != "") { Total_Pagos += Convert.ToDouble(dGGast.Rows[i].Cells[2].Value); }

                    }
                }//for (int i=1; i==dGIngr.RowCount; i++)
                //Total_Pagos += Convert.ToDouble(txt_CambioDA.Text.ToString());
                //TotalPagos = Math.Round(TotalPagos, 2);
                lTotalPagos.Text =Total_Pagos.ToString();
                CargaTalones(Fecha);
                //TotalPagos = Convert.ToDecimal(Total_Pagos);
                txtTALONES.Text = TotalTalones.ToString();
                ////Efectivo = TotalCobros - TotalTalones;
                //txtEFECTIVO.Text = Efectivo.ToString();
                //Resto = Math.Round( Convert.ToDecimal(txt_CambioDA.Text.ToString().Replace(".",",")) +TotalCobros - TotalPagos,2);
                //txtResto.Text = Resto.ToString();
                //Descuadre = -TotalCobros + TotalTalones + Efectivo;
                //if (txtEFECTIVO.Text!="") { lDescuadre.Text = Descuadre.ToString(); }
                ToTaLiZa();

            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

        }  //private void PresentaDatos()



        private string CobradoDIA(string Fecha)
        {   //Nos dará el total de la venta del día
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            string resultado = "0.00";
            try
            {
                string sQ = "SELECT SUM(Cantidad) as TotalDia FROM VENALB_COBROS  WHERE Fecha='" + Fecha + "'";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                resultado = rst[0].ToString();
                if (resultado == "") { resultado = "0.00"; }
                rst.Close();
                cmd.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                return resultado;
            }
        } //private  string CobradoDIA (string Fecha)

        private string CobCajaDIA(string Fecha)
        {   //Nos dará el total de lo que se ha cobrado en la CAJA en el dia
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            string resultado = "0.00";
            try
            {
                decimal total = 0;
                string sQ = "SELECT SUM(Ventot) AS TotalDia FROM VENALB_CABE  WHERE VenFec='" + Fecha + "'  AND VenTve=3";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                resultado = rst[0].ToString();
                if (resultado == "")
                { resultado = "0.00"; }
                else
                {
                    total = Math.Round(Convert.ToDecimal(resultado), 2);
                    Cobros3 = total;  //Almacenamo este valor para usarlo en la grabación de la caja
                    resultado = total.ToString();
                }
                rst.Close();
                cmd.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                return resultado;
            }
        } //private  string CobCajaDIA (string Fecha)

        private string CobPte8048(string Fecha)
        {   //Nos dará el total de los cobrados de Pendiente de 8048 en el dia
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            string resultado = "0.00";
            try
            {
                decimal total = 0;
                string sQ = "SELECT SUM(VenTot)  FROM VENALB_CABE  WHERE IdCobro IN ( SELECT IdCobro FROM VENALB_COBROS WHERE Fecha='" + Fecha + "') ";
                sQ += " AND  VenFec<'" + Fecha + "' AND VenTve=59 ";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                resultado = rst[0].ToString();
                if (resultado == "")
                { resultado = "0.00"; }
                else
                {
                    total = Math.Round(Convert.ToDecimal(resultado), 2);
                    Cobros8048 = total;
                    resultado = total.ToString();
                }

                rst.Close();
                cmd.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                return resultado;
            }
        } //private  string CobPte8048 (string Fecha)

        private string TotalCobradoTipo(string Fecha, string TV)
        {   //Nos dará el total de los cobrados de un tipo de venta predeterminado
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            string resultado = "0.00";
            try
            {
                decimal TotalDia = 0;
                string SelectAlb = "(SELECT VenAlb FROM VENALB_CABE WHERE IdCobro IN (SELECT IdCobro FROM VENALB_COBROS WHERE Fecha='" + Fecha + "'))";
                string sQ = "SELECT SUM(Ventot) AS TotalDia FROM VENALB_CABE WHERE  VenAlb IN " + SelectAlb + " AND  (VenTve=" + TV + ") AND  Anyo=" + Convert.ToDateTime(Fecha).Year;
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                resultado = rst[0].ToString();
                if (resultado == "")
                { resultado = "0.00"; }
                else
                {
                    TotalDia = Math.Round(Convert.ToDecimal(resultado), 2);
                    resultado = TotalDia.ToString();
                }

                
                rst.Close();
                cmd.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                return resultado;
            }
        } //private string TotalCobradoTipo(string Fecha,string TV )

        private string DevueltoOremape(string Fecha)
        {   //Nos dará el total de los cobrados de un tipo de venta predeterminado
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            string resultado = "0.00";
            try
            {
                string SelectAlb = "(SELECT VenAlb FROM VENALB_CABE WHERE IdCobro IN (SELECT IdCobro FROM VENALB_COBROS WHERE Fecha='" + Fecha + "'))";
                string sQ = "SELECT SUM(Ventot) AS TotalDia FROM VENALB_CABE WHERE  VenAlb IN " + SelectAlb + " AND  (VenTve IN (53,54)) AND  Anyo=" + Convert.ToDateTime(Fecha).Year;
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();
                resultado = rst[0].ToString();
                if (resultado == "") { resultado = "0.00"; }
                rst.Close();
                cmd.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
                return resultado;
            }
        } //private string DevueltoOremape(string Fecha)

        private void CargaPagos(string Fecha)
        {   //Nos dará el total de los cobrados de FACTURACIÓN PROPIA
            //1.-Cobrados a Cuenta
            //2.- Cobradas facturas completas de Facturación Propia
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            decimal Importe = 0;
            try
            {
                string sQ = "SELECT * FROM COMPRAS_GASTOS WHERE FechaPago='" + Fecha + "' AND TipoApunte='P' AND TipoPago='CAJA'";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                while (rst.Read())
                {
                    Importe = Math.Round( Convert.ToDecimal(rst["Total"].ToString().Replace(".",",")), 2);
                    AgregarFilaPagos(dGGast, Funciones.DameNomAcr(rst["Codigo"].ToString()), rst["Concepto"].ToString(), Importe.ToString());
                }
                rst.Close();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        }//private void CargaPagos(string Fecha)

        private void CargaTalones(string Fecha)
        {   //Cargará datos de Talones cobrados en el dia de hoy
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            decimal Importe = 0;
            try
            {
                string sQ = "SELECT DetCod,Observaciones,Importe FROM TALONES WHERE  IdCobro IN (SELECT IdCobro FROM VENALB_COBROS WHERE Fecha='" + Fecha + "')";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                while (rst.Read())
                {
                    Importe = Math.Round(Convert.ToDecimal(rst["Importe"].ToString().Replace(".", ",")), 2);
                    AgregarFilaPagos(dGTalo, rst["DetCod"].ToString(), rst["Observaciones"].ToString(), Importe.ToString());
                    TotalTalones += Convert.ToDecimal(rst["Importe"]);
                }
                TotalTalones = Math.Round(TotalTalones, 2);
                rst.Close();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        } //private void CargaTalones(string Fecha)


        private void FPs(string Fecha)
        {   //Nos dará el total de los cobrados de FACTURACIÓN PROPIA
            //1.-Cobrados a Cuenta
            //2.- Cobradas facturas completas de Facturación Propia
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            try
            {
                string sQ = "SELECT DetCod,SUM(VenTot) AS TCC  FROM VENALB_CABE  WHERE IdCobro IN (SELECT IdCobro FROM VENALB_COBROS WHERE Fecha='" + Fecha + "')";
                sQ += " AND VenTve IN (50,52) AND (VenNfp IS NULL) GROUP BY DetCod";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                
                while (rst.Read())
                {
                    CobrosFP += Math.Round(Convert.ToDecimal(rst["TCC"].ToString().Replace(".", ",")), 2);
                    AgregarFila(dGIngr, "Cobrado a/CTA " + Funciones.DameNomDet(rst["DetCod"].ToString()), rst["TCC"].ToString());
                }
                rst.Close();
                cmd.Dispose();

                sQ = "SELECT FacTuras.FacNfp,FACTURAS.Anyo,FACTURAS.DetCod,FACTURAS.FacTot,VENALB_COBROS.Fecha FROM  FACTURAS INNER JOIN VENALB_COBROS ";
                sQ += " ON FACTURAS.IdCobro=VENALB_COBROS.IdCobro WHERE  VENALB_COBROS.Fecha='" + Fecha + "' AND FacTot>0";
                cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                rst = cmd.ExecuteReader();
                while (rst.Read())
                {
                    sQ = "SELECT * FROM VENALB_CABE WHERE VenNfp = " + rst["FacNfp"].ToString() + " AND AnyoFP = " + rst["Anyo"].ToString() + " AND FechaCobro<>'" + Fecha + "'";
                    SqlCommand cmd1 = new SqlCommand(sQ, GloblaVar.gConRem);
                    SqlDataReader rst1 = cmd1.ExecuteReader();
                    if (!rst1.HasRows)
                    {
                        CobrosFP += Math.Round(Convert.ToDecimal(rst1["FacTot"].ToString().Replace(".", ",")), 2);
                        AgregarFila(dGIngr, "Cobrado Fra. " + Funciones.DameNomDet(rst1["DetCod"].ToString()), rst1["FacTot"].ToString());
                    }
                    rst1.Close();
                    cmd1.Dispose();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        } //private void  FPs(string Fecha)

        private void AgregarFila(DataGridView dgv, string concepto, string cantidad)
        {//Insertará una fila más en el DataGridView dgv
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dgv);
                fila.Cells[0].Value = concepto;
                fila.Cells[1].Value = cantidad;
                dgv.Rows.Add(fila);
                fila.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

        }  //private void AgregarFila(DataGridView dgv,string concepto,string cantidad)

        private void AgregarFilaPagos(DataGridView dgv, string titular, string concepto, string cantidad)
        {//Insertará una fila más en el DataGridView dgv
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dgv);
                fila.Cells[0].Value = titular;
                fila.Cells[1].Value = concepto;
                fila.Cells[2].Value = cantidad;
                dgv.Rows.Add(fila);
                fila.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

        }  //private void AgregarFilaPagos(DataGridView dgv,string concepto,string cantidad)

        private void Seguridad()
        {
            //dTP_Fecha.Value = DateTime.Today;
            switch (frmPpal.USUARIO)
            {
                case "1": //llorens

                    break;
                case "2":  //Carabal
                    break;
                case "3":       //ENDUMAR
                    break;
                case "5": //Dialpesca
                    break;
                case "6":  //ABT
                    break;
                case "8": //VALPEIX
                    break;
            }
        } //private void Seguridad()

        private void btn_PresentaDAtos_Click(object sender, EventArgs e)
        {
            PresentaDatos(dTP_Fecha.Value.ToShortDateString());
            btn_CONTABILIZAR.Visible = true;
            btnListadoXLS.Visible = true;
        }

        private void btn_Add_Pagos_Click(object sender, EventArgs e)
        {
            //FormGastos frm = new FormGastos();
            //frm.Show();
        }

        private void btn_Add_Pagos_CAJA_Click(object sender, EventArgs e)
        {
            //FormGastos01 frm = new FormGastos01();
            //frm.Show();

        }

        private void txtINGRESOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (txtEFECTIVO.Text == "") { txtEFECTIVO.Text = "0,00"; }
                    IngresoBanco = Convert.ToDecimal(txtINGRESOB.Text.Replace(".", ","));
                    CambioMañana = Math.Round(Efectivo - IngresoBanco, 2);
                    txtCAMBIODS.Text = CambioMañana.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }


        } //private void txtINGRESOB_KeyPress(object sender, KeyPressEventArgs e)

        private void txtEFECTIVO_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (txtEFECTIVO.Text=="") { txtEFECTIVO.Text = "0,00"; }
                    Efectivo = Convert.ToDecimal(txtEFECTIVO.Text.Replace(".", ","));
                    ToTaLiZa();
                    txtINGRESOB_KeyPress(this, new KeyPressEventArgs((char)(Keys.Enter)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

        }  //private void txtEFECTIVO_KeyPress(object sender, KeyPressEventArgs e)

        private void PintaFondoLabel(Label L, decimal Valor)
        {
            //Pone el fondo del Label en verde si es positivo y en rojo si el calor que contiene es negativo
            if (Valor > 0) { L.BackColor = Color.ForestGreen; }
            if (Valor < 0) { L.BackColor = Color.Crimson ; }
            if (Valor == 0) { L.BackColor = Color.Wheat; }
        }  //private void PintaFondoLabel(Label L, decimal Valor)

        private void btnListadoXLS_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                DateTime fecha = dTP_Fecha.Value;
                string nombreFichero = "CAJA_DIA_" + fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0') + "_" + fecha.Hour.ToString().PadLeft(2, '0') + fecha.Minute.ToString().PadLeft(2, '0') + fecha.Second.ToString().PadLeft(2, '0') + ".xlsx";


                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range rango;
                //Microsoft.Office.Interop.Excel.For
                excelWorksheet.Name = nombreFichero;

                //Filas de COBROS
                int fila = 0;           //fila del DataGridView
                int filaXLS = 1;          //fila de la hoja excell
                int colm = 0;
                int colmXLS = 0;

                excelWorksheet.Cells[filaXLS, 2] = "CAJA DEL DIA " + dTP_Fecha.Value.ToShortDateString();
                excelWorksheet.Cells[filaXLS, 2].Font.Bold = true;
                excelWorksheet.Cells[filaXLS, 2].Font.Size = 20;
                excelWorksheet.get_Range("A" + filaXLS, "C" + filaXLS).Merge(true);
                filaXLS++;
                filaXLS++;

                //excelWorksheet.Columns[2] = 300;
                //excelWorksheet.Columns[2].ColumnWidth = 300;
                excelWorksheet.Cells[filaXLS , 2] = "     C O B R O S ";
                excelWorksheet.Cells[filaXLS, 4] = "Total";
                rango = excelWorksheet.get_Range("A"+filaXLS , "D"+filaXLS );
                rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Wheat );

                //}

                filaXLS++;

                // Primero Añadimos la Caja del dia anterior
                excelWorksheet.Cells[filaXLS, 2] = "CAMBIO DIA ANTERIOR ";
                excelWorksheet.Cells[filaXLS, 3] = Math.Round(Convert.ToDecimal(txt_CambioDA.Text.Replace(".",",")), 2);
                filaXLS++;
                //Ahora los Ingresos
                while ((dGIngr.Rows[fila].Cells[colm].Value) != null)
                {

                    excelWorksheet.Cells[filaXLS,2] = dGIngr.Rows[fila].Cells[0].Value.ToString().Trim();
                    excelWorksheet.Cells[filaXLS, 3] = Math.Round(Convert.ToDecimal(dGIngr.Rows[fila].Cells[1].Value.ToString()), 2);
                    fila++;
                    filaXLS++;
                }
                //filaXLS++;
                excelWorksheet.Cells[filaXLS, 4] = Math.Round(TotalCaja, 2);

                //Procedemos a colocar los PAGOS. Para lo cual avanzamos 3 filas hacia abajo
                filaXLS += 3;
                excelWorksheet.Cells[filaXLS, 1] = "Prov/Acr";
                excelWorksheet.Cells[filaXLS, 2] = "   P A G O S";
                excelWorksheet.Cells[filaXLS, 4] = " Total";
                rango = excelWorksheet.get_Range("A" + filaXLS, "D" + filaXLS);
                rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Wheat);
                filaXLS++;
                //excelWorksheet.Cells[filaXLS, 4] = Math.Round(TotalPagos, 2);
                fila = 0;
                while ((dGGast.Rows[fila].Cells[colm].Value) != null)
                {
                    excelWorksheet.Cells[filaXLS, 1] = dGGast.Rows[fila].Cells[0].Value.ToString().Trim();
                    excelWorksheet.Cells[filaXLS, 2] = dGGast.Rows[fila].Cells[1].Value.ToString().Trim();
                    excelWorksheet.Cells[filaXLS, 3] = Math.Round(Convert.ToDecimal(dGGast.Rows[fila].Cells[2].Value.ToString()), 2);
                    fila++;
                    filaXLS++;
                    
                }
                excelWorksheet.Cells[filaXLS, 4] = Math.Round(TotalPagos,2);
                filaXLS++;
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] ="TOTAL DIA..............";
                excelWorksheet.Cells[filaXLS, 4] = Math.Round(TotalCaja-TotalPagos  , 2);
                filaXLS++;
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] = "Efectivo";
                excelWorksheet.Cells[filaXLS, 3] = Math.Round(Efectivo , 2);
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] = "Talones";
                excelWorksheet.Cells[filaXLS, 3] = Math.Round(TotalTalones, 2);
                filaXLS++;
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] = "DESCUADRE..............";
                excelWorksheet.Cells[filaXLS, 4] = Math.Round(Descuadre, 2);
                filaXLS++;
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] = "Cambio Dia Siguiente ";
                excelWorksheet.Cells[filaXLS, 3] = Math.Round(CambioMañana , 2);
                filaXLS++;
                filaXLS++;
                excelWorksheet.Cells[filaXLS, 2] = "Ingreso Efectivo..............";
                excelWorksheet.Cells[filaXLS, 4] = Math.Round(IngresoBanco , 2);
                filaXLS++;
                filaXLS++;
                fila = 0;
                //Ya tenemos los pagos. Ahora los talones
                excelWorksheet.Cells[filaXLS, 1] = "Cod.Clie";
                excelWorksheet.Cells[filaXLS, 2] = " DATOS TALÓN";
                excelWorksheet.Cells[filaXLS, 3] = "Importe";
                rango = excelWorksheet.get_Range("A" + filaXLS, "C" + filaXLS);
                rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Wheat);
                filaXLS++;

                if (dGTalo.RowCount  > 1)
                {
                    while ((dGTalo.Rows[fila].Cells[colm].Value) != null)
                    {
                        excelWorksheet.Cells[filaXLS, 1] = dGTalo.Rows[fila].Cells[0].Value.ToString().Trim();
                        excelWorksheet.Cells[filaXLS, 2] = dGTalo.Rows[fila].Cells[1].Value.ToString().Trim();
                        excelWorksheet.Cells[filaXLS, 3] = Math.Round(Convert.ToDecimal(dGTalo.Rows[fila].Cells[2].Value.ToString().Replace(".",",")), 2);
                        fila++;
                        filaXLS++;
                    }
                }

                //filaXLS++;
                //filaXLS++;
                //string R1 = "B" + filaXLS;
                //excelWorksheet.Cells[filaXLS, 2] = "CAJA DEL DIA :";
                //excelWorksheet.Cells[filaXLS, 3] = dTP_Fecha.Value.ToShortDateString();
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "CAMBIO DIA ANTERIOR:";
                //excelWorksheet.Cells[filaXLS, 3] = txt_CambioDA.Text ;
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "TOTAL COBROS:";
                //excelWorksheet.Cells[filaXLS, 3] = Convert.ToDecimal( lTotalCobros.Text);
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "TOTAL PAGOS";
                //excelWorksheet.Cells[filaXLS, 3] = Convert.ToDecimal(lTotalPagos.Text) ;
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "TOTAL CAJA DEL DIA:";
                //excelWorksheet.Cells[filaXLS, 3] = Convert.ToDecimal(txtResto.Text);
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "EFECTIVO:";
                //excelWorksheet.Cells[filaXLS, 3] = txtEFECTIVO.Text;
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "TALONES:";
                //excelWorksheet.Cells[filaXLS, 3] = Convert.ToDecimal(txtTALONES.Text.Replace(".",","));
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "CAMBIO DIA SIGUIENTE:";
                //excelWorksheet.Cells[filaXLS, 3] = Convert.ToDecimal(txtCAMBIODS.Text);
                //filaXLS++;
                //excelWorksheet.Cells[filaXLS, 2] = "INGRESO EN BANCO:";
                //excelWorksheet.Cells[filaXLS, 3] = txtINGRESOB.Text ;
                //string R2 = "C" + filaXLS;
                //rango = excelWorksheet.get_Range(R1, R2);
                //rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold);

                //filaXLS++;
                //R2= R2 = "C" + filaXLS;
                //rango.BorderAround2(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium , Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

                excelWorkbook.SaveAs(GloblaVar.gPathExcell + nombreFichero);

                excelWorkbook.Close();
                excelApp.Quit();
                MessageBox.Show(GloblaVar.gPathExcell + nombreFichero + " creada");
                Funciones.AbreExcell(GloblaVar.gPathExcell + nombreFichero);

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        } //ListarXLS



        private void btnGRABAR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string sQ = "";
            try
            {
                
                DateTime fecha = dTP_Fecha.Value;
                string IdCaja = fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0');  //+ "_" + fecha.Hour.ToString().PadLeft(2, '0') + fecha.Minute.ToString().PadLeft(2, '0') + fecha.Second.ToString().PadLeft(2, '0') + ".xlsx";
                if (Funciones.ExisteCAJADIA(IdCaja))
                {
                    sQ = "UPDATE CAJADIA_VENTAS SET ";
                    sQ+="Cambio=" +txt_CambioDA.Text.Replace(",",".") + ",";
                    sQ += "Cobros3=" + Cobros3.ToString().Replace(",", ".") + ",";
                    sQ += "Cobros8048=" + Cobros8048.ToString().Replace(",", ".") + ",";
                    sQ += "CobrosFP=" + CobrosFP.ToString().Replace(",", ".") + ",";
                    sQ += "Pagos=" + TotalPagos.ToString().Replace(",", ".") + ",";
                    sQ += "Efectivo=" + Efectivo.ToString().Replace(",", ".") + ",";
                    sQ += "Talones=" + TotalTalones.ToString().Replace(",", ".") + ",";
                    sQ += "Descuadre=" + Descuadre.ToString().Replace(",", ".") + ",";
                    sQ += "Ingreso=" + IngresoBanco.ToString().Replace(",", ".") + ",";
                    sQ += "CambioSgte=" +CambioMañana.ToString().Replace(",", ".") + "";
                    //sQ += "CobroEsp1=" & CobroEsp1 & ","
                    //sQ += "CobroEsp2=" & CobroEsp2 & ""
                    sQ += " WHERE IdCaja=" + IdCaja + "";
                    Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
                    MessageBox.Show("ACTUALIZADA CAJA del DIA con Identificador " + IdCaja);
                    GloblaVar.gUTIL.ATraza(gIdent + "ACTUALIZADA CAJA del DIA con Identificador " + IdCaja);
                }
                else
                {
                    sQ = "INSERT INTO CAJADIA_VENTAS(IdCaja, Cambio, Cobros3, Cobros8048, CobrosFP, Pagos, Efectivo, Talones, Descuadre, Ingreso, CambioSgte) ";
                    sQ += " VALUES ";
                    sQ += "(" + IdCaja + ",";
                    sQ += txt_CambioDA.Text.Replace(",", ".") + ",";
                    sQ += Cobros3.ToString().Replace(",", ".") + ",";
                    sQ += Cobros8048.ToString().Replace(",", ".") + ",";
                    sQ += CobrosFP.ToString().Replace(",", ".") + ",";
                    sQ += TotalPagos.ToString().Replace(",", ".") + ",";
                    sQ += Efectivo.ToString().Replace(",", ".") + ",";
                    sQ += TotalTalones.ToString().Replace(",", ".") + ",";
                    sQ += Descuadre.ToString().Replace(",", ".") + ",";
                    sQ += IngresoBanco.ToString().Replace(",", ".") + ",";
                    sQ += CambioMañana.ToString().Replace(",", ".") + "";
                    //                sQ += CobroEsp1 + ","
                    //    '           sQ += CobroEsp2;
                    sQ += ")";
                    Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
                    MessageBox.Show("Grabada CAJA del DIA con Identificador " + IdCaja);
                    GloblaVar.gUTIL.ATraza(gIdent + "GRABADA CAJA del DIA con Identificador " + IdCaja);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        }//        private void btnGRABAR_Click(object sender, EventArgs e)

        private void btn_CONTABILIZAR_Click(object sender, EventArgs e)
        
            {
                //Establecerá el fichero de exportación de contaplus de la caja del dia y todo lo que conlleva
                DateTime Fec = dTP_Fecha.Value;
                string FechaFichero = Fec.Year.ToString() + Fec.Month.ToString().PadLeft(2, '0') + Fec.Day.ToString().PadLeft(2, '0');
                string FichCaja = @"C:\CERCLE\CONTABILIDAD\" + FechaFichero + "_CAJADIA.txt";
                string linea = "";
                int asiento = 1;
                //'1.-Cobrado Pdtes 8048
                //    Traza1 SO_des, vbCrLf & Now & " ASIENTO PARA COBROS 8048"
                //    Traza1 SO_des, Now & " ==================================="
                //    cmdCobro8048_Click

                TextWriter tw = new StreamWriter(FichCaja, false, System.Text.Encoding.ASCII);
            clase_detallista1 det8048 = new clase_detallista1();
            if (GloblaVar.g8048.SubCta !="")
            {
                //linea = Funciones.ApunteAsientoENDU(asiento.ToString(), GloblaVar.g8048.SubCta , GloblaVar.gSubCtaCAJA, "Cobro Pte8048 " + Fec.ToShortDateString(), "0.00", "0.00", Cobros8048.ToString().Replace(",", "."), "0.00", FechaFichero, "");
                //tw.WriteLine(linea);
                //linea = Funciones.ApunteAsientoENDU(asiento.ToString(), GloblaVar.gSubCtaCAJA, GloblaVar.g8048.SubCta, "Cobro Pte8048 " + Fec.ToShortDateString(), "0.00", "0.00", "0.00", Cobros8048.ToString().Replace(",", "."), FechaFichero, "");
                //tw.WriteLine(linea);
                clase_EXPORT_CPLUS ExpCplus = new clase_EXPORT_CPLUS();
                ExpCplus.Fecha = Fec.ToShortDateString();
                ExpCplus.FichExport = FichCaja;
                ExpCplus.sDetCod = GloblaVar.g8048.DetCod;
                ExpCplus.sSubCta = GloblaVar.g8048.SubCta;
                ExpCplus.sTotal = Cobros8048.ToString();
                ExpCplus.sAsiento = asiento.ToString();
                tw.Close();
                if (ExpCplus.CobroCaja()) { asiento++; }
                ExpCplus = null;
            }
            //'2.- Hacer Factura  de albaranes de Pte 8048 del día
            //====================================================
            Hacer_Factura_8048_1(Fec);

            //3.- CONTABILIZAR FACTURAS SERIE B
            //    =============================         Leeremos todas las facturas de serie B del dia en la tabla FACTURAS1 y las pasamos  al fichero de texto
            string sQ = "SELECT * FROM FACTURAS1 WHERE Fecha='" + Fec.ToShortDateString() + "' AND Serie='B'";
            SqlCommand cmd = new SqlCommand(sQ,GloblaVar.gConRem );
            SqlDataReader rst = cmd.ExecuteReader() ;
            if (rst.HasRows )
            {
                while (rst.Read())
                {
                    clase_EXPORT_CPLUS exFB = new clase_EXPORT_CPLUS();
                    exFB.sDetCod = rst["CliPro"].ToString();
                    exFB.sAsiento = asiento.ToString();
                    exFB.sFactura = rst["Factura"].ToString();
                    exFB.sBI = rst["BI"].ToString().Replace(",", ".");
                    exFB.sIVA  = rst["IVA"].ToString().Replace(",", ".");
                    exFB.sReq = rst["Recargo"].ToString().Replace(",", ".");
                    exFB.sTotal  = rst["Total"].ToString().Replace(",", ".");
                    exFB.sSerie = "B";
                    exFB.Fecha = Fec.ToShortDateString();
                    exFB.FichExport = FichCaja;
                    exFB.sPercentIVA = "10.00";
                    if (exFB.FacturaB()) { asiento++; }
                    exFB = null;
                }
            }
            
            //4.- COBROS A CUENTA DE FACTURAS PROPIAS
            //   =======================================

        }  //private void btn_CONTABILIZAR_Click(object sender, EventArgs e)

        private void Hacer_Factura_8048_1(DateTime  Dia)
        {
            // Haremos facturas de 8048 limitando a 400 euros
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string sQry = "";
            Int32 NF;

            try
            {
                string serie = "'B'";
                decimal BI = 0;
                decimal IVA = 0;
                decimal Req = 0;
                decimal Total = 0;
                decimal TotalPrevisto = 0;
                decimal TotalSgte = 0;
                //Dim Alb(100) As Long
                string Concepto = "";
                string Referencia;
                int i = 0;

                serie = "'B'";
                sQry = "SELECT VenAlb,DetCod,VenTot  FROM VENALB_CABE ";
                sQry += " WHERE ";
                sQry += " Ventve=59";  //Tipo de venta para los 8048
                sQry += " AND ";
                sQry += " VenFec='" + Dia.ToShortDateString() + "'";
                SqlCommand cmd = new SqlCommand(sQry, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                //Tenemos los Albaranes de los cuales vamos a hacer la Factura de Pdtes de 8048

                if (!rst.HasRows) { return; }
                Concepto = "FRA 8048 ";
                while (rst.Read())
                {
                    TotalPrevisto=Total+ Convert.ToDecimal(rst["VenTot"].ToString());

                    if (TotalPrevisto >400)
                    {  //Hay que hacer la factura puesto que se han superado los 400 euros y continuar con 
                        i++; //Nos servirá para guardar la Referencia
                        Referencia = Dia.Year.ToString() + Dia.Month.ToString().PadLeft(2, '0') + Dia.Day.ToString().PadLeft(2, '0') + "F8048_" + i.ToString();
                        if (Funciones.Existe_FACTURA2("B", Referencia))
                        {
                            sQry = "DELETE FROM FACTURAS1 WHERE Fecha = '" + Dia.ToShortDateString() + "' AND SERIE = " + serie;
                            Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                            sQry = "DELETE FROM FACTURAS1_LINEAS WHERE Fecha = '" + Dia.ToShortDateString() + "' AND SERIE = " + serie;
                            Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                            NF = Convert.ToInt32(GloblaVar.TeMp);
                        }
                        else
                        {
                            NF = Funciones.NuevoNum("FACTURAS1", "Factura", "WHERE Serie='B'");
                        }
                        sQry = "INSERT INTO FACTURAS1 (Factura,Serie,Referencia,Fecha,CliPro,BI,IVA,Total) VALUES (";
                        sQry += NF.ToString() + ",";
                        sQry += serie + ",";
                        sQry += "'" + Referencia + "'" + ",";
                        sQry += "'" + Dia.ToShortDateString() + "'" + ",";
                        sQry += GloblaVar.g8048.DetCod + ",";
                        sQry += BI.ToString().Replace(",", ".") + ",";
                        sQry += IVA.ToString().Replace(",", ".") + ",";
                        sQry += Total.ToString().Replace(",", ".");
                        sQry += ")";
                        Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                        sQry = "INSERT INTO FACTURAS1_LINEAS (Linea,Factura,Serie,Referencia,Fecha,Cantidad";
                        sQry += ",Concepto,Precio,Importe) VALUES (";
                        sQry += "1,";
                        sQry += NF.ToString() + ",";
                        sQry += serie + ",";
                        sQry += "'" + Referencia + "'" + ",";
                        sQry += "'" + Dia.ToShortDateString() + "'" + ",";
                        sQry += "1" + ",";
                        sQry += "'Facturación 8048 " + Dia.ToShortDateString() +"_"+ i + "'" + ",";
                        sQry += Total.ToString().Replace(",", ".") + ",";
                        sQry += Total.ToString().Replace(",", ".");
                        sQry += ")";
                        Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                        Total = Convert.ToDecimal(rst["VenTot"].ToString());
                        BI = Math.Round((Total / (1 + (Funciones.IVA_Fecha(Dia) / 100))), 2);
                        IVA = Total - BI;
                        Req = 0;
                    }
                    else
                    {//Seguir totalizando y leyendo Albaranes
                        Total+= Convert.ToDecimal(rst["VenTot"].ToString());
                        BI = Math.Round((Total / (1 + (Funciones.IVA_Fecha(Dia) / 100))), 2);
                        IVA = Total - BI;
                        Req = 0;

                    }




                }//While
                if (Total > 0)
                {
                    //Habríamos de hacer la ultima factura o la única si se tartase de una sola
                    i++; //Nos servirá para guardar la Referencia
                    Referencia = Dia.Year.ToString() + Dia.Month.ToString().PadLeft(2, '0') + Dia.Day.ToString().PadLeft(2, '0') + "F8048_" + i.ToString();
                    if (Funciones.Existe_FACTURA2("B", Referencia))
                    {
                        sQry = "DELETE FROM FACTURAS1 WHERE Fecha = '" + Dia.ToShortDateString() + "' AND SERIE = " + serie;
                        Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                        sQry = "DELETE FROM FACTURAS1_LINEAS WHERE Fecha = '" + Dia.ToShortDateString() + "' AND SERIE = " + serie;
                        Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                        NF = Convert.ToInt32(GloblaVar.TeMp);
                    }
                    else
                    {
                        NF = Funciones.NuevoNum("FACTURAS1", "Factura", "WHERE Serie='B'");
                    }
                    sQry = "INSERT INTO FACTURAS1 (Factura,Serie,Referencia,Fecha,CliPro,BI,IVA,Total) VALUES (";
                    sQry += NF.ToString() + ",";
                    sQry += serie + ",";
                    sQry += "'" + Referencia + "'" + ",";
                    sQry += "'" + Dia.ToShortDateString() + "'" + ",";
                    sQry += GloblaVar.g8048.DetCod + ",";
                    sQry += BI.ToString().Replace(",", ".") + ",";
                    sQry += IVA.ToString().Replace(",", ".") + ",";
                    sQry += Total.ToString().Replace(",", ".");
                    sQry += ")";
                    Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                    sQry = "INSERT INTO FACTURAS1_LINEAS (Linea,Factura,Serie,Referencia,Fecha,Cantidad";
                    sQry += ",Concepto,Precio,Importe) VALUES (";
                    sQry += "1,";
                    sQry += NF.ToString() + ",";
                    sQry += serie + ",";
                    sQry += "'" + Referencia + "'" + ",";
                    sQry += "'" + Dia.ToShortDateString() + "'" + ",";
                    sQry += "1" + ",";
                    sQry += "'Facturación 8048 " + Dia.ToShortDateString() + "_" + i + "'" + ",";
                    sQry += Total.ToString().Replace(",", ".") + ",";
                    sQry += Total.ToString().Replace(",", ".");
                    sQry += ")";
                    Funciones.EjecutaNonQuery(sQry, GloblaVar.gConRem);
                    //Total = Convert.ToDecimal(rst["VenTot"].ToString());
                    //BI = Math.Round((Total / (1 + (Funciones.IVA_Fecha(Dia) / 100))), 2);
                    //IVA = Total - BI;
                    //Req = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

        }  //        private void Hacer_Factura_8048_1(string Dia)

    }   //partial class
}  //namespace

