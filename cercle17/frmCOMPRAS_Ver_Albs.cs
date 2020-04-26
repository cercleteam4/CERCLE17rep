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
using System.Collections;

namespace cercle17
{
    public partial class frmCOMPRAS_Ver_Albs : Form
    {
        public frmCOMPRAS_Ver_Albs()
        {
            InitializeComponent();
        }
        public SqlConnection CnO;
        public string ConEMail, ConEDNSSMTP, ConAutPwd;

        private void Cargar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("Cargando dgVC " + this.GetType().FullName);
            ArrayList Lista_AlbC = new ArrayList();

            string total_importes = "0";

            //Query a presentar
            string sQ = "SELECT  CC.ComCpa AS ALBARAN, CC.ComCfa AS FECHA, CC.ProCod AS C_Prov, P.ProNom AS PROVEEDOR, CC.comcim AS Importe, ";
            sQ += " CC.Anyo AS Año, CC.Facturado ";
            sQ += "FROM  ";
            sQ += "COMALB_CABE AS CC INNER JOIN PROVEEDORES  AS P ON CC.ProCod = P.ProCod";

            if (checkBox_Fecha.Checked == true)
            {
                //filtro por fecha
                sQ += " WHERE (convert(date,CC.ComCfa) >= '" + dateTimePicker_Inicio.Text + "' AND convert(date,CC.ComCfa) <= '" + dateTimePicker_Fin.Text + "') ";
                if (tb_ProCod.Text != "Cod_Proveedor"  && tb_ProCod.Text !="" )
                {
                    sQ += " AND CC.ProCod=" + tb_ProCod.Text;
                }
            }
            else
            {
                if (tb_ProCod.Text != "Cod_Proveedor" && tb_ProCod.Text != "")
                {
                    sQ += " WHERE CC.ProCod=" + tb_ProCod.Text;
                }
            }//if (checkBox_Fecha.Checked == true)           

            //ordenar
            sQ += " ORDER BY CC.ComCfa,CC.ProCod ";           

            try
            {
                SqlDataReader myR = null;
                SqlCommand myCmd = new SqlCommand(sQ, GloblaVar.gcnO);
                myR = myCmd.ExecuteReader();
                while (myR.Read())
                {
                    clase_albcom AlbC = new clase_albcom();

                    AlbC.ComCpa = myR["ALBARAN"].ToString();
                    AlbC.ComCfa =Convert.ToDateTime( myR["FECHA"].ToString()).ToShortDateString() ;
                    AlbC.ProCod = myR["C_Prov"].ToString();
                    AlbC.Proveedor = myR["PROVEEDOR"].ToString();
                    AlbC.comcim = myR["Importe"].ToString();
                    AlbC.Anyo = myR["Año"].ToString();
                    //AlbC.Facturado = Convert.ToBoolean(myR["Facturado"]);
                    AlbC.Facturado = false;

                    //filtros
                    bool agregar = true;
                    if (tb_ProCod.Text != "Cod_Proveedor")
                    {
                        if (AlbC.ProCod.Contains(tb_ProCod.Text) == false) { agregar = false; }
                    }

                    if (agregar == true)    //si no incumple el filtro se agrega al array Lista_Albaranes
                    {
                        Lista_AlbC.Add(AlbC);
                        total_importes = Funciones.Suma(total_importes, AlbC.comcim);

                    } // if (agregar == true) 
                } //while (myR.Read())
                myR.Close();

                // Cargar la lista en el grid

                dgVC.DataSource = Lista_AlbC;

                if (dgVC.Rows.Count > 0)
                {
                    dgVC.Columns[0].HeaderText = "ALBARÁN";
                    dgVC.Columns[1].HeaderText = "AÑO";
                    dgVC.Columns[2].HeaderText = "C.PROV";
                    dgVC.Columns[3].HeaderText = "FECHA";
                    dgVC.Columns[3].DisplayIndex = 1;
                    dgVC.Columns[4].Visible = false;
                    dgVC.Columns[5].Visible = false;
                    dgVC.Columns[6].Visible = false;
                    //dgVC.Columns[7].HeaderText = "IMPORTE";
                    dgVC.Columns[7].Visible = false;
                    dgVC.Columns[8].Visible = false;
                    dgVC.Columns[9].Visible = false;
                    dgVC.Columns[10].HeaderText = "PROVEEDOR";
                    dgVC.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dgVC.Columns[11].HeaderText = "Facturado";
                    //dgVC.Columns[11].Visible = false;
                    dgVC.Columns[11].HeaderText = "Selección";

                    //dgVC.Columns[7].HeaderText = "ALBARÁN";

                } //if (dgVC.Rows.Count>0)
            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }   //private void Cargar()

        private void frmCOMPRAS_Ver_Albs_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);


            //iniciar filtros por defecto
            checkBox_Fecha.Checked  = false;

            //cargar facturas
            Seguridad();
            Cargar();
        }

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Fecha.Checked)
            {
                Cargar();
            }
        }  //private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)

        private void checkBox_Fecha_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btn_Listar_Albaranes_Click(object sender, EventArgs e)
        {
            GloblaVar.TIPO_REPORT = 9;
            GloblaVar.sQReport = "";
            int c_Check = 11;
            int c_Alb = 0;
            int c_Año = 1;
            foreach (DataGridViewRow row in dgVC.Rows )
            {
                if (row.Index < dgVC.RowCount && (Funciones.Valor_CheckGrid(row, c_Check) == true))
                {
                    if (GloblaVar.sQReport=="")
                    {
                        GloblaVar.sQReport = "({Comando.ComLpa}=" + row.Cells[c_Alb].Value.ToString() + " AND {Comando.Anyo}=" + row.Cells[c_Año].Value.ToString() + ")";
                    }
                    else
                    {
                        GloblaVar.sQReport += " OR ({Comando.ComLpa}=" + row.Cells[c_Alb].Value.ToString() + " AND {Comando.Anyo}=" + row.Cells[c_Año].Value.ToString() + ")";
                    }
                }

            }  //foreach (DataGridViewRow row in dgVC.Rows )
            
            frmCR1 frmREPORT = new frmCR1();
            frmREPORT.Show();
        }  //private void btn_Listar_Albaranes_Click(object sender, EventArgs e)

        private void btn_Listar_Albaranes_Separ_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza (gIdent+ " " + this.GetType().FullName);
            GloblaVar.TIPO_REPORT = 10;
            GloblaVar.sQReport = "";
            int c_Check = 11;
            int c_Alb = 0;
            int c_Año = 1;
            foreach (DataGridViewRow row in dgVC.Rows)
            {
                if (row.Index < dgVC.RowCount && (Funciones.Valor_CheckGrid(row, c_Check) == true))
                {
                    if (GloblaVar.sQReport == "")
                    {
                        GloblaVar.sQReport = "({Comando.ComLpa}=" + row.Cells[c_Alb].Value.ToString() + " AND {Comando.Anyo}=" + row.Cells[c_Año].Value.ToString() + ")";
                    }
                    else
                    {
                        GloblaVar.sQReport += " OR ({Comando.ComLpa}=" + row.Cells[c_Alb].Value.ToString() + " AND {Comando.Anyo}=" + row.Cells[c_Año].Value.ToString() + ")";
                    }
                }

            }  //foreach (DataGridViewRow row in dgVC.Rows )

            frmCR1 frmREPORT = new frmCR1();
            frmREPORT.Show();

        }  // private void btn_Listar_Albaranes_Separ_Click(object sender, EventArgs e)

        private void tb_ProCod_TextChanged(object sender, EventArgs e)
        {
            //if (e.KeyChar==Key.Return)
        }

        private void tb_ProCod_KeyPress(object sender,
                System.Windows.Forms.KeyPressEventArgs e)
        {
            // Si se pulsa la tecla Intro, pasar al siguiente
            //if( e.KeyChar == Convert.ToChar('\r') ){
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                Cargar();
                //txtFecha.Focus();
            }
            //else if (e.KeyChar == '.')
            //{
            //    // si se pulsa en el punto se convertirá en coma
            //    e.Handled = true;
            //    SendKeys.Send(",");
            //}
        }

 

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    Cargar();
                    break;
                case "2":
                    break;
                case "5": //Dialpesca
                    Cargar();
                    break;
                case "6":  //ABT
                    break;
                case "8": //VALPEIX
                    Cargar();
                    break;
            }
        } //private void Seguridad()

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        }
    }
}
