using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace cercle17
{
    public partial class frmEmpr03_CUADRE : Form
    {
        int ColSelect = 11;
        int c_Partida=0;
        int c_AñoP=1;
        int c_Alm = 2;
        int c_ArtCod = 3;
        int c_ArtDes = 4;
        int c_ProCod = 5;
        int c_ProNom = 6;
        int c_SI = 7;
        int c_S = 8;
        int c_FCompra = 9;
        int c_FCua = 10;
        int c_Check = 11;
        public frmEmpr03_CUADRE()
        {
            InitializeComponent();
        }

        private void Carga_dG1()
        {   // Cargamos el Grid con las partidas sin cuadrar status<>'C'
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                //string nom = dG1.Columns[0].HeaderText;
                if (dG1.Columns.Count>c_FCua ) { dG1.Columns.RemoveAt(c_Check ); }
                GloblaVar.sQReport = "SELECT P.Partida,P.Anyo as Año,P.AlmMay as ALM,P.ArtCod as C_Art, A.ArtDes as ARTICULO, ";
                GloblaVar.sQReport += " P.ProCod AS C_Proveedor, ";
                GloblaVar.sQReport += " PR.ProNom AS C_Proveedor, ";
                GloblaVar.sQReport += " P.StockInicial, ";
                GloblaVar.sQReport += " P.Stock, ";
                GloblaVar.sQReport += " P.FCompra, ";
                GloblaVar.sQReport += " P.FCua ";
                GloblaVar.sQReport += " FROM PARTIDAS AS P INNER JOIN ARTICULOS AS A ON P.ArtCod=A.ArtCod ";
                GloblaVar.sQReport += " INNER JOIN PROVEEDORES as PR ON P.ProCod=PR.ProCod";
                GloblaVar.sQReport += "  WHERE (P.FCua IS NULL) or P.FCua='" +dtpFecha.Value.ToShortDateString() + "'";
                GloblaVar.sQReport += " AND ";
                GloblaVar.sQReport += "P.ProCod NOT IN (97)";
                SqlCommand cmd = new SqlCommand(GloblaVar.sQReport, GloblaVar.gConRem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dG1.DataSource = dt;
                //dG1.Columns[0].HeaderText = "PARTIDA";
                dG1.Columns[c_Partida ].Width = 60;//Partida
                dG1.Columns[c_AñoP ].Width = 50;//Año
                dG1.Columns[c_Alm].Width = 50;//Almacen
                dG1.Columns[c_ArtCod ].Width = 60;//Cod. Art
                dG1.Columns[c_ArtDes ].Width = 190;// Articulo
                dG1.Columns[c_ProCod].Width = 60;//Cod Proveedor
                dG1.Columns[c_ProNom ].Width = 180;//Proveedor
                dG1.Columns[c_SI ].Width = 60;//StockInicial
                dG1.Columns[c_S ].Width = 60;//Stock
                dG1.Columns[c_FCompra ].Width = 80;//FCompra
                dG1.Columns[c_FCua ].Width = 80;//FCua
                DataGridViewCheckBoxColumn Col_CUADRE = new DataGridViewCheckBoxColumn();
                dG1.Columns.Add(Col_CUADRE);
                dG1.Columns[c_Check ].Width = 60;//Check de Cuadre
                
                dG1.Columns[c_Check ].HeaderText = "CUADRADO";

                DataGridViewCheckBoxCell CeldaCUADRADO = new DataGridViewCheckBoxCell();
                for (int i = 0; i < dG1.RowCount - 1; i++)
                {
                    if (this.dG1[c_FCua, i].Value.ToString() != "") 
                    {
                        CeldaCUADRADO.Value = true;
                        this.dG1[c_Check , i].Value = CeldaCUADRADO.Value;
                    }
                    else 
                    {
                        CeldaCUADRADO.Value = false;
                        this.dG1[c_Check, i].Value = CeldaCUADRADO.Value;
                    }

                }

                //dG1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill();
                //dG1.Columns[0].Width = 60;//StockInicial
                cmd.Dispose();
                da.Dispose();
                dt.Dispose();
                GBPB.Visible = false;
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
            }
        }//private void Carga_dG1
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

                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "3":       //ENDUMAR
                    break;
                case "4":    //Botella'
                    this.Text = "Utilidades para J.B.BOTELLA " + GloblaVar.VERSION;
                    break;
            } //switch(frmPpal.USUARIO )
        } //Seguridad

        private void frmEmpr03_CUADRE_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
            GloblaVar.gUTIL.CartelTraza(" ENTRADA A " + this.GetType().FullName + " INFORME ENVIO OREMAPE 1");
            this.Text = " CUADRE  " + GloblaVar.VERSION;

            try
            {
                Seguridad();
                lPartida.Text = lAño.Text = lStockInicial.Text = lStock.Text = lAlmacen.Text=lArtCod.Text=lProCod.Text=lProNom.Text=LArtDes.Text=tObservaciones.Text = "";
                Carga_dG1();
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
            }
        }//private void frmEmpr03_CUADRE_Load(object sender, EventArgs e)

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("SALIENDO de " + gIdent);
            this.Close();

        }

        private void dG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Detecta si se ha seleccionado el header de la grilla
            //
            if (e.RowIndex == -1)
                return;


            if (dG1.Columns[e.ColumnIndex].HeaderText  == "CUADRADO")
            {

                //
                // Se toma la fila seleccionada
                //
                DataGridViewRow row = dG1.Rows[e.RowIndex];

                //
                // Se selecciona la celda del checkbox
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells[ColSelect ] as DataGridViewCheckBoxCell;


                if (!Convert.ToBoolean(cellSelecion.Value))
                {

                    //string mensaje = string.Format("Evento CellContentClick.\n\nSe ha seccionado, \nPartida: '{0}', \nAño: '{1}', \nStock: '{2}'",
                    //                                    row.Cells["Partida"].Value,
                    //                                    row.Cells["Año"].Value,
                    //                                    row.Cells["Stock"].Value);

                    //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lPartida.Text = row.Cells["Partida"].Value.ToString();
                    lAño.Text = row.Cells["Año"].Value.ToString();
                    lStock.Text = row.Cells["Stock"].Value.ToString();
                    lStockInicial.Text = row.Cells["StockInicial"].Value.ToString();
                    lProCod.Text = row.Cells["C_Proveedor"].Value.ToString();
                    lArtCod.Text = row.Cells["C_Art"].Value.ToString();
                    lAlmacen.Text = row.Cells["ALM"].Value.ToString();
                    lProNom.Text = Funciones.DameNomPro(lProCod.Text);
                    LArtDes.Text = row.Cells["ARTICULO"].Value.ToString();
                    tObservaciones.Text = "";

                }
                else
                {
                    string mensaje = string.Format("Evento CellContentClick.\n\nSe va adejar como NO CUADRADA la , \nPartida: '{0}', \nAño: '{1}', \nStock: '{2}'",
                                                        row.Cells["Partida"].Value,
                                                        row.Cells["Año"].Value,
                                                        row.Cells["Stock"].Value);

                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dG1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ////Detectaremos el click en la celda de check de selección para si es true mandarla a panel de cuadre
            //string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
            ////GloblaVar.gUTIL.ATraza("SALIENDO de " + gIdent);
            //try
            //{
            //    // Se toma la fila seleccionada
            //    //
            //    DataGridViewRow row = dG1.Rows[e.RowIndex];
 
            //    //
            //    // Se selecciona la celda del checkbox
            //    //
            //    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;
               
            //    //
            //    // Se valida si esta checkeada
            //    //
            //    if (Convert.ToBoolean(cellSelecion.Value))
            //    {

            //        string mensaje = string.Format("Evento CellValueChanged.\n\nSe ha seccionado, \nStock: '{0}', \nStockInicial: '{1}', \nPartida: '{2}'",
            //                                            row.Cells["Stock"].Value,
            //                                            row.Cells["StockInicial"].Value,
            //                                            row.Cells["Partida"].Value);

            //        MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }//if (Convert.ToBoolean(cellSelecion.Value)) 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(gIdent+ex.ToString());
            //    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            //}
        }

        private void button_Si_Cuadre_Partida_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name+ " ";
            try
            {
                string sQ = "UPDATE PARTIDAS SET FCua='" + dtpFecha.Value.ToShortDateString() + "' ";
                sQ += ", Observaciones='" + tObservaciones.Text + "'";
                sQ += " WHERE Partida=" + lPartida.Text + " AND Anyo=" + lAño.Text;
                Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
                lPartida.Text = lAño.Text = lStockInicial.Text = lStock.Text = lAlmacen.Text = lArtCod.Text = lProCod.Text = lProNom.Text = LArtDes.Text = tObservaciones.Text = "";
                Carga_dG1();
            
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            }
        }  //private void button_Si_Cuadre_Partida_Click(object sender, EventArgs e)

        private void button_SI_Seleccionadas_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                //for (int i=1; i<dG1.RowCount  ; i++)
                //{
                //    string Partida = dG1[c_Partida , i].Value.ToString();
                //    string AñoP = dG1[c_AñoP, i].Value.ToString();
                //    string Alm = dG1[c_Alm, i].Value.ToString();

                //    if (dG1[c_Check,i].Value.ToString() == true)
                //    {

                //    }

                //}
                GBPB.Visible = true;
                pB1.Minimum = 0;
                pB1.Maximum = dG1.RowCount-1;
                pB1.Value = 0;
                pB1.Step = 1;
                foreach (DataGridViewRow row in dG1.Rows)
                {
                    //CambiarProgreso("Fila " + row.Index.ToString(), row.Index);
                    pB1.PerformStep();
                    Application.DoEvents();
                    if (row.Index<dG1.RowCount && (Funciones.Valor_CheckGrid(row, c_Check) == true))
                    {
                        //La fila está seleccionada, entonces debemos de mirar si no  está cuadrada y cuadrarla entonces.
                        string Par = row.Cells[c_Partida].Value.ToString();
                        if (row.Cells[c_FCua].Value.ToString() != "")
                        {// La fila estaba cuadrada y se desea que permanezca así. luego no se hace nada
                            string a = row.Cells[c_Partida].Value.ToString();
                            LPB.Text = "Partida " + a + " permanece cuadrada  " ;
                            //if (row.Cells[c_Partida].Value != null) { CambiarProgreso("Partida " + a + " permanece cuadrada", row.Index); }
                        }
                        else
                        {//La fila no estaba cuadrada  y hay que cuadrarla
                            //CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " CUADRANDO", row.Index);
                            if (row.Cells[c_Partida].Value != null) { LPB.Text = "Partida " + row.Cells[c_Partida].Value.ToString() + " CUADRANDO"; }
                            CuadrarFila(row.Index, true);
                            row.Cells[c_FCua].Value = dtpFecha.Value.ToShortDateString();
                        }
                    }
                    else
                    {
                        //La fila no está seleccionada. Tiene que quedar sin cuadrar
                        if (row.Cells[c_FCua].Value != null && row.Cells[c_FCua].Value.ToString() != "")
                        {//La fila estaba cuadrada y hay que quitarle el cuadre
                            //if (row.Cells[c_Partida].Value != null) { CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " QUITANDO CUADRE", row.Index); }
                            if (row.Cells[c_Partida].Value != null) { LPB.Text = "Partida " + row.Cells[c_Partida].Value.ToString() + " QUITANDO CUADRE"; }
                            CuadrarFila(row.Index, false);
                            row.Cells[c_FCua].Value = "";
                        }
                        else
                        { //La fila no estaba cuadrada y hay que dejarla así
                            //if (row.Cells[c_Partida].Value != null) { CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " permanece sin cuadrar.", row.Index); }
                            if (row.Cells[c_Partida].Value != null) { LPB.Text = "Partida " + row.Cells[c_Partida].Value.ToString() + " permanece sin cuadrar."; }
                        }
                    }//else  de if ((Funciones.Valor_CheckGrid(row, c_Check) == true))
                    Thread.Sleep(50);
                }  //foreach                

                //CambiarProgreso( "Recargando estado del cuadre.... Sea Paciente.",0);
                LPB.Text = "Recargando estado del cuadre.... Sea Paciente.";
                Application.DoEvents();
                //Carga_dG1();
                GBPB.Visible = false;


                //ThreadStart delegado = new ThreadStart(CorrerProceso);
                //Thread Hilo=new Thread(delegado);
                //Hilo.Start();
                
                //GBPB.Visible = false;
                
                
                
            }  //try
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            } //catch

            

        } //private void button_SI_Seleccionadas_Click(object sender, EventArgs e)

        private void CuadrarFila(int NumFila,bool SN)
            //Será un método para cuadrar o descuadrar una fila determinada
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string sQ = "";
            try
            {
                DataGridViewRow Fila = dG1.Rows[NumFila];
                //if (Fila.Cells[c_FCua] != null) { return true; } else { return false; }
                string Partida=Fila.Cells[c_Partida ].Value.ToString();
                string AñoPartida=Fila.Cells[c_AñoP ].Value.ToString();
                string Almacen= Fila.Cells[c_Alm].Value.ToString().Trim();
                
                if (SN==true)
                {//Cuadrar la partida
                    sQ = "UPDATE PARTIDAS SET FCua='" + dtpFecha.Value.ToShortDateString() + "' WHERE ";
                    sQ += "Partida=" + Partida;
                    sQ += " AND ";
                    sQ += "Anyo=" + AñoPartida;
                    sQ += " AND ";
                    sQ += "AlmMay=" + Almacen ;
                    
                }
                else
                {//Descuadrar la partida
                    sQ = "UPDATE PARTIDAS SET FCua=NULL WHERE ";
                    sQ += "Partida=" + Partida;
                    sQ += " AND ";
                    sQ += "Anyo=" + AñoPartida;
                    sQ += " AND ";
                    sQ += "AlmMay='" + Almacen +"'";
                }
                Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + "sQ= " + sQ);
                GloblaVar.gUTIL.ATraza(gIdent+ ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
            }
        }   // private bool CuadrarFila

        private void btnLISTAR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
               GloblaVar.TIPO_REPORT = 6;  // Listado de CUADRE DEL DIA
                GloblaVar.sQReport = "";
               GloblaVar.sQReport = "(ISNULL({Comando.F_Cuadre}) ";
               GloblaVar.sQReport += " OR ";
               GloblaVar.sQReport += "{Comando.F_Cuadre}=#" + dtpFecha.Value.ToString("M/dd/yyyy") + "#)";
               //GloblaVar.sQReport += " AND ";
               GloblaVar.sQReport += " AND ";
               //GloblaVar.sQReport += "({Comando.C_Prov}<97)";
               //GloblaVar.sQReport+=" AND ";
               GloblaVar.sQReport += "( {Comando.C_Art}<7000)";

               //GloblaVar.sQReport += " {comando.ProCod} IN " + tProvIni.Text + " TO " + tProvFin.Text;
               //GloblaVar.sQReport += " AND ";
               //GloblaVar.sQReport += " {comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
               frmCR1 frmREPORT = new frmCR1();
               frmREPORT.Show();

            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            } //private void dG1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Carga_dG1();
        }

        private void CorrerProceso()
        {
            CambiarProgreso("Iniciando proceso...", 1);
            ////hagamos un ciclo que se repita 100 veces 
            //for (int i = 0; i < 100; i++)
            //{
            //    //esperaremos medio segundo en cada iteración 
            //    Thread.Sleep(500);
            //    //notificamos el avance al usuario 
            //    CambiarProgreso(string.Format("Posición {0}...", i), i);
            //}
            //CambiarProgreso("Completado :D", 100);
            GBPB.Visible = true;
            pB1.Minimum = 0;
            pB1.Maximum = dG1.RowCount;
            foreach (DataGridViewRow row in dG1.Rows)
            {
                CambiarProgreso("Fila " + row.Index.ToString(), row.Index);
                
                if ((Funciones.Valor_CheckGrid(row, c_Check) == true))
                {
                    //La fila está seleccionada, entonces debemos de mirar si no  está cuadrada y cuadrarla entonces.
                    if (row.Cells[c_FCua].Value.ToString() != "")
                    {// La fila estaba cuadrada y se desea que permanezca así. luego no se hace nada
                        string a = row.Cells[c_Partida].Value.ToString();
                        if (row.Cells[c_Partida].Value != null) { CambiarProgreso("Partida " + a + " permanece cuadrada", row.Index); }
                    }
                    else
                    {//La fila no estaba cuadrada  y hay que cuadrarla
                        CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " CUADRANDO", row.Index);
                        CuadrarFila(row.Index, true);
                        row.Cells[c_FCua].Value = dtpFecha.Value.ToShortDateString();
                    }
                }
                else
                {
                    //La fila no está seleccionada. Tiene que quedar sin cuadrar
                    if (row.Cells[c_FCua].Value != null && row.Cells[c_FCua].Value.ToString() != "")
                    {//La fila estaba cuadrada y hay que quitarle el cuadre
                        if (row.Cells[c_Partida].Value != null) { CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " QUITANDO CUADRE", row.Index); }
                        CuadrarFila(row.Index, false);
                        row.Cells[c_FCua].Value = "";
                    }
                    else
                    { //La fila no estaba cuadrada y hay que dejarla así
                        if (row.Cells[c_Partida].Value != null) {  CambiarProgreso("Partida " + row.Cells[c_Partida].Value.ToString() + " permanece sin cuadrar.", row.Index);  }
                    }
                }
                Thread.Sleep(50);
            }  //foreach                

            //CambiarProgreso( "Recargando estado del cuadre.... Sea Paciente.",0);
            GBPB.Visible = false;
            //Carga_dG1();
        }

        delegate void CambiarProgresoDelegado(string texto, int valor);
        private void CambiarProgreso(string texto, int valor)
        {
            if (this.InvokeRequired) //preguntamos si la llamada se hace desde un hilo 
            {
                //si es así entonces volvemos a llamar a CambiarProgreso pero esta vez a través del delegado 
                //instanciamos el delegado indicandole el método que va a ejecutar 
                CambiarProgresoDelegado delegado = new CambiarProgresoDelegado(CambiarProgreso);
                //ya que el delegado invocará a CambiarProgreso debemos indicarle los parámetros 
                object[] parametros = new object[] { texto, valor };
                //invocamos el método a través del mismo contexto del formulario (this) y enviamos los parámetros 
                this.Invoke(delegado, parametros);
            }
            else
            {
                //en caso contrario, se realiza el llamado a los controles 
                //GBPB.Visible = true;
                pB1.Value = valor;
                LPB.Text = texto;
            }
        }

        private void button_Marcar_Menor_1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {

                foreach (DataGridViewRow row in dG1.Rows)
                {
                    if (row.Index < dG1.RowCount-1 && (Convert.ToDecimal( row.Cells[c_S].Value.ToString()) <1))
                    {
                        row.Cells[c_Check].Value = true;
                    }
                    else
                    {
                        
                    }//else  de if ((Funciones.Valor_CheckGrid(row, c_Check) == true))
                }  //foreach                

            }  //try
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());

            } //catch

        } //private void button_Marcar_Menor_1_Click(object sender, EventArgs e)

    } //public partial class frmEmpr03_CUADRE : Form
}//namespace cercle17
  
