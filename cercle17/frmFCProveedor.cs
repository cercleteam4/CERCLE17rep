using System;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmFCProveedor : Form
    {
        clsResizeForm RSF = new clsResizeForm();
        public frmFCProveedor()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        double Subtotal = 0;


        private void Cargar()
        {

            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
           
            ArrayList Lineas_Albaran = new ArrayList();
            ArrayList Albaranes = new ArrayList();
            ArrayList Numeros_Albaran = new ArrayList();

            string total_importes = "";
            label_Importes_Sel.Text  = "0";

            string strQ = @"SELECT LA.ComLpa, LA.ProCod, P.ProNom, LA.ComCfa, LA.Anyo, LA.ComLnl, LA.ArtCod, A.ArtDes, LA.ComLca, LA.ComLki, LA.ComLpr, LA.ComLim, LA.Facturado ";
            strQ+=" FROM ";
            strQ+= " COMALB_LINEAS AS LA INNER JOIN ARTICULOS AS A ON LA.ArtCod=A.ArtCod ";
            strQ+=" INNER JOIN PROVEEDORES AS P ON LA.ProCod=P.ProCod ";
            strQ+=" WHERE ";
            strQ+="(comcfa BETWEEN @dateIni AND @dateFin) ";
            if (checkTodosProv.CheckState==CheckState.Unchecked ) 
            {
                strQ+=" AND ";
                strQ+=" LA.ProCod=@proCodIni ";
            }
            strQ+=" AND ";
            strQ+=" ISNULL(Facturado,0) <> 1 ";
            strQ+=" ORDER BY LA.ComLpa, LA.ComLnl";

            this.Cursor = Cursors.WaitCursor;

            try
            {

                SqlCommand myCommand = new SqlCommand(strQ, CnO);                
                myCommand.Parameters.AddWithValue("@proCodIni", tProvIni.Text);                
                myCommand.Parameters.AddWithValue("@dateIni", dateTimePicker_Inicio.Text);
                myCommand.Parameters.AddWithValue("@dateFin", dateTimePicker_Fin.Text);

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    clase_linea_albcom linea_albcom = new clase_linea_albcom();                    

                    linea_albcom.ComLpa = myReader["ComLpa"].ToString();                    
                    linea_albcom.ProCod = myReader["ProCod"].ToString();
                    linea_albcom.ProNom = myReader["ProNom"].ToString();
                    linea_albcom.comcfa = myReader["comcfa"].ToString(); 
                    if (linea_albcom.comcfa.Length > 10) { linea_albcom.comcfa = linea_albcom.comcfa.Substring(0, 10); }
                    linea_albcom.ComLnl = myReader["ComLnl"].ToString();
                    linea_albcom.Anyo = myReader["Anyo"].ToString();                   
                    linea_albcom.ArtCod = myReader["ArtCod"].ToString();
                    linea_albcom.ArtDes = myReader["ArtDes"].ToString();
                    linea_albcom.ComLca = myReader["ComLca"].ToString(); 
                    linea_albcom.ComLki = Funciones.FormateaKilos(myReader["ComLki"].ToString());
                    linea_albcom.ComLpr = Funciones.Formatea(myReader["ComLpr"].ToString());
                    linea_albcom.ComLim = Funciones.Formatea(myReader["ComLim"].ToString());
                    linea_albcom.Facturado = false;

                    total_importes = Funciones.Suma(total_importes, linea_albcom.ComLim);

                    Lineas_Albaran.Add(linea_albcom);

                    if (!Numeros_Albaran.Contains(linea_albcom.ComLpa))
                    {
                        Numeros_Albaran.Add(linea_albcom.ComLpa);
                        Albaranes.Add(linea_albcom);
                    }
                }

                myReader.Close();

                dataGridView_ComAlbLineas.AutoGenerateColumns = false;
                dataGridView_ComAlbLineas.DataSource = Lineas_Albaran;

                dataGridView_ComAlb.AutoGenerateColumns = false;
                dataGridView_ComAlb.DataSource = Albaranes;

                if (dataGridView_ComAlbLineas.Rows.Count > 0)
                {
                    //aprovechamos para cambiar el nombre de algunas columnas
                    dataGridView_ComAlbLineas.Columns["ComLca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_ComAlbLineas.Columns["ComLki"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_ComAlbLineas.Columns["ComLpr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView_ComAlbLineas.Columns["ComLim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView_ComAlb.Columns["Facturado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    label_importes.Text = total_importes;
                }
                else
                {
                    label_importes.Text = "0";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + " ERROR " + ex.ToString());   
            }

            this.Cursor = Cursors.Default;
            //this.Au

        }       // Cargar

        private void frmFCProveedor_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            
            RSF.ResizeForm(this, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
           // this.Text = "Apoyo Facturación a Proveedores " + GloblaVar.gUTIL.VERSION;

        }

    //private void frmFCProveedor_Load(object sender, EventArgs e)

        private void frmFCProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("---------------------- SALIENDO de " + this.GetType().FullName);
        }

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            if ( (!string.IsNullOrEmpty(tProvIni.Text)) | (checkTodosProv.CheckState==CheckState.Checked) )
            {
                Cargar();
            }
        }

        private void dateTimePicker_Fin_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tProvIni.Text))
            {
                Cargar();
            }
        }

        private void llblProvIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "PROVEEDORES";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tProvIni.Text = GloblaVar.Cod_Buscado;
                lProvIni.Text = GloblaVar.Nom_Buscado;

                if (!string.IsNullOrEmpty(tProvIni.Text))
                {
                    Cargar();
                }

            }   //if (frmC.ShowDialog == DialogResult.OK)
        }
       
        private void tProvIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (!string.IsNullOrEmpty(tProvIni.Text))
                    {
                        lProvIni.Text = Funciones.DameNomPro(tProvIni.Text);
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("El proveedor es obligatorio");
                    }                    
                }
                else
                {
                    //No habríamos de hacer nada ya que quedaría el texto como está
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + " ERROR " + ex.ToString());
            }
        }

        private void dataGridView_ComAlb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Variable para Subtotal
           
            //código necesario para marcar Selección
            if (e.RowIndex >= 0)
            {
                //la columna 3 es la que se puede marcar
                if (e.ColumnIndex == 2)
                {
                    bool marcada = false;
                    int comLpa = 0;

                    if (dataGridView_ComAlb.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower() == "true")
                    {
                        marcada = true;
                    } //if (dataGridView_ComAlb.Rows[e.RowIndex].Cells[2].Value.ToString().ToLower() == "true")

                    if (marcada)
                    {
                        //si está marcada se va a desmarcar
                        dataGridView_ComAlb.Rows[e.RowIndex].Cells[2].Value = false;

                        comLpa = Convert.ToInt32(dataGridView_ComAlb.Rows[e.RowIndex].Cells[0].Value);

                        foreach (DataGridViewRow dvr in dataGridView_ComAlbLineas.Rows)
                        {
                            if (Convert.ToInt32(dvr.Cells[0].Value) == comLpa)
                            {
                                dvr.DefaultCellStyle.BackColor = Color.Empty;
                               
                            }
                        }
                    }
                    else
                    {
                        //y a la inversa
                        dataGridView_ComAlb.Rows[e.RowIndex].Cells[2].Value = true;

                        comLpa = Convert.ToInt32(dataGridView_ComAlb.Rows[e.RowIndex].Cells[0].Value);

                        foreach (DataGridViewRow dvr in dataGridView_ComAlbLineas.Rows)
                        {
                            if(Convert.ToInt32(dvr.Cells[0].Value) == comLpa)
                            {
                                dvr.DefaultCellStyle.BackColor = Color.LightSalmon;
                                //Subtotal = Subtotal + (Convert.ToDouble(dvr.Cells[7].Value) * Convert.ToDouble(dvr.Cells[8].Value));
                            }
                        }   //foreach (DataGridViewRow dvr in dataGridView_ComAlbLineas.Rows)
                    }   //if (marcada)

                    //Ahora Calcularemos el Subtotal
                    Subtotal = 0;
                    foreach (DataGridViewRow dvr in dataGridView_ComAlbLineas.Rows)
                    {
                        if (dvr.DefaultCellStyle.BackColor == Color.LightSalmon)
                        {
                            double aa=Convert.ToDouble(dvr.Cells[5].Value) *  Convert.ToDouble(dvr.Cells[6].Value);
                            Subtotal = Subtotal + (Convert.ToDouble(dvr.Cells[7].Value));
                        }
                    }   //foreach (DataGridViewRow dvr in dataGridView_ComAlbLineas.Rows)
                }
            }   //if (e.RowIndex >= 0)

            label_Importes_Sel.Text = Subtotal.ToString();
        }  //private void dataGridView_ComAlb_CellClick(object sender, DataGridViewCellEventArgs e)

        private void button_Facturar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            for (int x = 0; x < dataGridView_ComAlb.Rows.Count; x++ )
            {
                if (dataGridView_ComAlb.Rows[x].Cells[2].Value.ToString().ToLower() == "true")
                {
                    string strQ = @"UPDATE COMALB_LINEAS SET Facturado=1 WHERE ComLpa=@comLpa AND Anyo=@anyo";

                    try
                    {
                        SqlCommand myCommand = new SqlCommand(strQ, CnO);
                        myCommand.Parameters.AddWithValue("@comLpa", dataGridView_ComAlb.Rows[x].Cells[0].Value.ToString());
                        myCommand.Parameters.AddWithValue("@anyo", dataGridView_ComAlb.Rows[x].Cells[1].Value.ToString());

                        int rowsAffected = myCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        GloblaVar.gUTIL.ATraza(gIdent + " ERROR " + ex.ToString());
                    }
                }
            }

            if (!string.IsNullOrEmpty(tProvIni.Text))
            {
                Cargar();
            }
            else
            {
                MessageBox.Show("El proveedor es obligatorio para listar");
            }
               
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        /// </summary>
        public class clsResizeForm
        {
            float f_HeightRatio = new float();
            float f_WidthRatio = new float();
            public void ResizeForm(Form ObjForm, int DesignerWidth, int DesignerHeight)
            {
                int i_StandardHeight = DesignerHeight;
                int i_StandardWidth = DesignerWidth;
                int i_PresentHeight = Screen.PrimaryScreen.Bounds.Height;
                int i_PresentWidth = Screen.PrimaryScreen.Bounds.Width;
                f_HeightRatio = (Convert.ToSingle(i_PresentHeight) / Convert.ToSingle(i_StandardHeight));
                f_WidthRatio = (Convert.ToSingle(i_PresentWidth) / Convert.ToSingle(i_StandardWidth));
                ObjForm.AutoScaleMode = AutoScaleMode.None;
                ObjForm.Scale(new SizeF(f_WidthRatio, f_HeightRatio));
                foreach (Control c in ObjForm.Controls)
                {
                    if (c.HasChildren)
                    {
                        ResizeControlStore(c);
                    }
                    else
                    {
                        c.Font = new Font(c.Font.FontFamily, c.Font.Size * f_HeightRatio, c.Font.Style, c.Font.Unit, (Convert.ToByte(0)));
                    }
                }
                ObjForm.Font = new Font(ObjForm.Font.FontFamily, ObjForm.Font.Size * f_HeightRatio, ObjForm.Font.Style, ObjForm.Font.Unit, (Convert.ToByte(0)));
            }
            private void ResizeControlStore(Control objCtl)
            {
                if (objCtl.HasChildren)
                {
                    foreach (Control cChildren in objCtl.Controls)
                    {
                        if (cChildren.HasChildren)
                        {
                            ResizeControlStore(cChildren);
                        }
                        else
                        {
                            cChildren.Font = new Font(cChildren.Font.FontFamily, cChildren.Font.Size * f_HeightRatio, cChildren.Font.Style, cChildren.Font.Unit, (Convert.ToByte(0)));
                        }
                    }
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, (Convert.ToByte(0)));
                }
                else
                {
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * f_HeightRatio, objCtl.Font.Style, objCtl.Font.Unit, (Convert.ToByte(0)));
                }
            }
        }

        private void button_Salir_Click_1(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("---------------------- SALIENDO de " + this.GetType().FullName);
            this.Close();
        }

        private void frmFCProveedor_SizeChanged(object sender, EventArgs e)
        {
            //RSF.ResizeForm(this, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        } //  public class clsResizeForm

        private void checkTodosProv_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTodosProv.CheckState==CheckState.Checked)
                {
                    Cargar();
                }//if (checkTodosProv.CheckState=CheckState.checked)
        }

        private void dataGridView_ComAlb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tProvIni_TextChanged(object sender, EventArgs e)
        {

        }   //private void checkTodosProv_CheckedChanged(object sender, EventArgs e)

    }   // public partial class frmFCProveedor : Form
}  //namespacce
