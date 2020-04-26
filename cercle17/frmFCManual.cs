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
    public partial class frmFCManual : Form
    {
        public frmFCManual()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        //definimos el binding del primer grid, donde pondremos los albaranes
        private BindingList<clase_albcom> dataSource1 = new BindingList<clase_albcom>();
        private BindingSource bs1 = new BindingSource();

        //y el binding del segundo grid, donde pondremos las lineas de factura
        private BindingList<clase_linea_factcom> dataSource2 = new BindingList<clase_linea_factcom>();
        private BindingSource bs2 = new BindingSource();

        private ArrayList listaProveedores = new ArrayList();

        private void frmFCManual_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            //cargar datos factura nueva
            textBox_Anyo.Text = DateTime.Today.Year.ToString();            
            comboBox_Serie.Text = "AA";

            //limpiamos los datagrid y hacemos binding
            dataGridView_Albaranes.AutoGenerateColumns = false;
            dataSource1.Clear();
            bs1.DataSource = dataSource1;
            dataGridView_Albaranes.DataSource = bs1;

            dataGridView_Facturado.AutoGenerateColumns = false;
            dataSource2.Clear();
            bs2.DataSource = dataSource2;
            dataGridView_Facturado.DataSource = bs2;

            textBox_ProCod.Focus();
        }

        private void Cargar(string cadenaProv)
        {
            //select de cabeceras albaranes de compras (no facturados) 
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);
                        
            string strQ = "SELECT C.ComCpa, C.Anyo, C.ComCfa, C.ProCod, P.ProNom, C.comcim ";
            strQ += "FROM COMALB_CABE AS C INNER JOIN PROVEEDORES AS P ON C.ProCod=P.ProCod ";
            strQ += "WHERE (C.ProCod IN (" + cadenaProv + ")) ";
            strQ += "AND (C.Facturado IS NULL) ";            
            strQ += "ORDER by Convert(Date,C.ComCfa) ASC, C.ProCod ASC";
            
            this.Cursor = Cursors.WaitCursor;
            
            //limpiamos ambos grids por el binding
            dataSource1.Clear();
            dataSource2.Clear();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ,GloblaVar.gConRem );
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_albcom alba = new clase_albcom();

                    alba.Facturar = false;
                    alba.ComCpa = myReader["ComCpa"].ToString();
                    alba.Anyo = myReader["Anyo"].ToString();                    
                    alba.ComCfa = myReader["ComCfa"].ToString(); if (alba.ComCfa.Length > 10) { alba.ComCfa = alba.ComCfa.Substring(0, 10); } 
                    alba.ProCod = myReader["ProCod"].ToString();
                    alba.Proveedor = myReader["ProNom"].ToString();
                    alba.comcim = Funciones.Formatea(myReader["comcim"].ToString());                   

                    dataSource1.Add(alba);
                }
                myReader.Close();                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

            this.Cursor = Cursors.Default;

        }       

        private void LimpiarFactura()
        {
            //Limpia datos tras una grabación            
            textBox_ProCod.Text = "";
            textBox_ProNom.Text = "";

            lblOtrosProveedores.Text = "";
            listaProveedores.Clear();

            dataSource1.Clear();
            dataSource2.Clear();

            textBox_Anyo.Text = DateTime.Today.Year.ToString(); 
            dtpProFechaFact.Value = DateTime.Now;
            tbProNumFact.Text = "";
            comboBox_Serie.SelectedIndex = 0;
            textBox_TextoCabecera.Text = "";
            textBox_Observaciones.Text = "";
            textBox_TextoPie.Text = "";

            textBox_BI.Text = "";
            textBox_IVA.Text = "";
            textBox_Importe.Text = "";

        }

        private void button_Consulta_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                GloblaVar.TIPO_CONSULTA = "PROVEEDORES";

                frmCONSULTA frmC = new frmCONSULTA();

                if (frmC.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox_ProCod.Text = GloblaVar.Cod_Buscado;
                    textBox_ProNom.Text = GloblaVar.Nom_Buscado;

                    Cargar(textBox_ProCod.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }           
        }     

        private void textBox_ProCod_Enter(object sender, EventArgs e)
        {
            textBox_ProCod.BackColor = Color.Yellow;
        }

        private void textBox_ProCod_Leave(object sender, EventArgs e)
        {
            textBox_ProCod.BackColor = Color.White;
        }

        private void textBox_ProCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                if (textBox_ProCod.Text != "")
                {
                    textBox_ProNom.Text = Funciones.DameNomPro(textBox_ProCod.Text);
                    Cargar(textBox_ProCod.Text);
                }
                else
                {
                    textBox_ProCod.Text = "";
                }
            }
        }

        //private void Cobrar_factura(string IdFactura)
        //{
        //    //abrir un formulario de cobro sobre IdFactura
        //    string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
        //    GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);

        //    try 
        //    {
        //        clase_cabecera_factura factura = new clase_cabecera_factura();

        //        factura.Factura = IdFactura;
        //        factura.Anyo = textBox_Anyo.Text;
        //        factura.Serie = comboBox_Serie.Text;
        //        factura.DetCod = textBox_ProCod.Text;
        //        factura.FechaEmision = DateTime.Today.ToShortDateString();
        //        factura.ImportePendiente = textBox_Importe.Text;

        //        frmFPCobros Cobros = new frmFPCobros();
        //        Cobros.CnO = CnO;
        //        Cobros.COBRO_AGRUPADO = false;
        //        Cobros.factura = factura;

        //        Cobros.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
        //    }

        //}        

        private void button_Grabar_Click(object sender, EventArgs e)
        {
            //GRABAR LA FACTURA
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Click en Grabar Factura Compras Manual");

            string resp = "";

            //grabar las líneas
            ArrayList Lista_Albaranes = new ArrayList();

            for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
            {
                if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                {
                    clase_albcom albC = new clase_albcom();

                    albC.ComCpa = dataGridView_Albaranes.Rows[x].Cells[1].Value.ToString();
                    albC.Anyo = dataGridView_Albaranes.Rows[x].Cells[2].Value.ToString();
                   
                    Lista_Albaranes.Add(albC);
                }
            }
            GloblaVar.gUTIL.ATraza(gIdent + " Recopiladas lineas que formarán parte de la factura");

            if (string.IsNullOrEmpty(textBox_ProCod.Text) || string.IsNullOrEmpty(tbProNumFact.Text) || Lista_Albaranes.Count == 0)
            {
                if (string.IsNullOrEmpty(textBox_ProCod.Text))
                {
                    GloblaVar.gUTIL.ATraza(gIdent + " Se dejaron el Código de proveedor vacio ");
                    resp = " - El proveedor es obligatorio\n";
                }

                if (string.IsNullOrEmpty(tbProNumFact.Text))
                {
                    GloblaVar.gUTIL.ATraza(gIdent + " Se dejaron Número de factura del proveedor vacio ");
                    resp = " - El número de factura del proveedor es obligatorio\n";
                }

                if (Lista_Albaranes.Count == 0)
                {
                    GloblaVar.gUTIL.ATraza(gIdent + " Debe seleccionar algún albarán de compra");
                    resp += " - Debe seleccionar algún albarán\n";
                }

                MessageBox.Show("Los siguientes campos son obligatorios: \n\n" + resp);
                GloblaVar.gUTIL.ATraza(gIdent + " Los siguientes campos son obligatorios: " + resp);

            }
            else
            {
                string proFechaFact = dtpProFechaFact.Text;
                string proNumFact = tbProNumFact.Text.Replace("'", "''"); 
                string textocabe = textBox_TextoCabecera.Text.Replace("'", "''"); if (textocabe.Length > 199) { textocabe = textocabe.Substring(0, 199); }
                string observaciones = textBox_Observaciones.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }
                string textopie = textBox_TextoPie.Text.Replace("'", "''"); if (textopie.Length > 199) { textopie = textopie.Substring(0, 199); }               

                clase_factcom factura = new clase_factcom();              

                factura.Anyo = textBox_Anyo.Text;
                factura.Serie = comboBox_Serie.Text;
                factura.FechaEmision = DateTime.Today.ToShortDateString();
                factura.ProCod = textBox_ProCod.Text;
                factura.BI1 = textBox_BI.Text.Replace(",", ".");
                factura.IVA1 = textBox_IVA.Text.Replace(",", ".");
                factura.ImpteFactura = textBox_Importe.Text.Replace(",", ".");
                factura.ImptePendiente = textBox_Importe.Text.Replace(",", ".");
                factura.ImptePagado = "0";
                factura.Observaciones = observaciones;
                factura.TextoPie = textopie;
                factura.TextoCabe = textocabe;
                factura.ProNumFact = proNumFact;
                factura.ProFechaFact = proFechaFact;

                factura.lineas = dataSource2.ToList();

                resp = factura.Insertar();

                if (resp == "")
                {
                    MessageBox.Show("La Factura número " + factura.Factura + " se ha insertado correctamente");

                    LimpiarFactura();

                    //Una vez hecha la factura ponemos los albaranes como facturados
                    foreach (clase_albcom albC in Lista_Albaranes)
                    {
                        clase_albcom albaranCompras = new clase_albcom();
                        resp = albaranCompras.PonerAlbaranFacturado(albC.ComCpa, albC.Anyo);
                    }

                    if(resp!="")
                    {
                        MessageBox.Show("Error al poner los albaranes como facturados: \n\n" + resp);
                        GloblaVar.gUTIL.ATraza(gIdent + " Error al poner los albaranes como facturados: " + resp);
                    }                                       
                }
                else
                {
                    MessageBox.Show("Error al insertar la factura: \n\n" + resp);
                    GloblaVar.gUTIL.ATraza(gIdent + " Error al insertar el albarán: " + resp);
                }
            }
        }

        private void Renumerar_Grid()
        {
            //esta función es necesaria porque se pueden marcar y desmarcar muchos albaranes
            //y es mejor renumerar las líneas de factura para que sean correlativas

            if (dataGridView_Facturado.Rows.Count > 0)
            {
                for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                {
                    int contador = x + 1;
                    dataGridView_Facturado.Rows[x].Cells[3].Value = contador.ToString(); //la celda 3 es LinF
                }
            }
        }

        //private void Formato_Facturado()
        //{
        //    //esta función ajusta las columnas de lineas de factura
        //    if (dataGridView_Facturado.Rows.Count > 0)
        //    {
        //        dataGridView_Facturado.Columns[0].Visible = false;
        //        dataGridView_Facturado.Columns[1].Visible = false;
        //        dataGridView_Facturado.Columns[2].Visible = false;
        //        dataGridView_Facturado.Columns[3].Visible = true;
        //        dataGridView_Facturado.Columns[4].Visible = true;
        //        dataGridView_Facturado.Columns[5].Visible = false;
        //        dataGridView_Facturado.Columns[6].Visible = false;
        //        dataGridView_Facturado.Columns[7].Visible = true;
        //        dataGridView_Facturado.Columns[8].Visible = true;
        //        dataGridView_Facturado.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //        dataGridView_Facturado.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //        dataGridView_Facturado.Columns[11].Visible = true;
        //        dataGridView_Facturado.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //        dataGridView_Facturado.Columns[13].Visible = false;
        //        dataGridView_Facturado.Columns[14].Visible = false;
        //        dataGridView_Facturado.Columns[15].Visible = false;
        //    }
        //}

        private void Marcaciones(int indice)
        {
            //esta función se activa cuando se marca un albarán
            string ComCpa = dataGridView_Albaranes.Rows[indice].Cells[1].Value.ToString();
            string Anyo = dataGridView_Albaranes.Rows[indice].Cells[2].Value.ToString();

            //comprobar si estaba marcada
            bool marcada = false;

            if (dataGridView_Albaranes.Rows[indice].Cells[0].Value.ToString().ToLower() == "true")
            {
                marcada = true;
            }

            if (marcada)
            {
                //si esta marcada se va a desmarcar
                dataGridView_Albaranes.Rows[indice].Cells[0].Value = false;

                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < dataGridView_Facturado.Rows.Count; x++)
                    {
                        int row = 0; bool encontrada = false;

                        if (dataGridView_Facturado.Rows[x].Cells[1].Value.ToString() == ComCpa)
                        {
                            encontrada = true;
                            row = x;
                        }

                        if (encontrada == true)
                        {
                            dataGridView_Facturado.Rows.Remove(dataGridView_Facturado.Rows[row]);
                            Renumerar_Grid();
                            x--;
                        }
                    }
                }

            }
            else
            {
                dataGridView_Albaranes.Rows[indice].Cells[0].Value = true;
                int contador = dataGridView_Facturado.Rows.Count + 1;

                //lectura de lineas de albarán               
                clase_linea_albcom linea = new clase_linea_albcom();
                List<clase_linea_albcom> lineas = linea.CogerLineasAlbaranPorCodigo(ComCpa, Anyo);
               
                foreach(clase_linea_albcom linAlbCom in lineas)
                {                  

                    clase_linea_factcom linea_factura = new clase_linea_factcom();

                    linea_factura.Factura = "";
                    linea_factura.Anyo = textBox_Anyo.Text;
                    linea_factura.Serie = comboBox_Serie.Text;                    
                    linea_factura.LinF = contador.ToString();
                    linea_factura.ComLpa = ComCpa;
                    linea_factura.AnyoAlb = Anyo;
                    linea_factura.ComLnl = linAlbCom.ComLnl;
                    linea_factura.ArtCod = linAlbCom.ArtCod;
                    linea_factura.ArtDes = linAlbCom.ArtDes;
                    linea_factura.ComLca = linAlbCom.ComLca;
                    linea_factura.ComLki = Funciones.FormateaKilos(linAlbCom.ComLki);
                    linea_factura.ComLpr = Funciones.Formatea(linAlbCom.ComLpr);
                    linea_factura.ComLim = Funciones.Formatea(linAlbCom.ComLim);
                    linea_factura.ComTrz = linAlbCom.Ref;

                    //se ha creado una línea de factura a partir de las lineas del albarán y ahora se agrega por binding
                    dataSource2.Add(linea_factura);

                    contador++;
                }
            }
        }

        private void dataGridView_Albaranes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //comprobar que se ha pulsado la primera columna
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    Marcaciones(e.RowIndex);
                    //Formato_Facturado();
                }
            }
        }

        private void Recuento_Importes_Albaranes()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);

            try
            {
                if (dataGridView_Albaranes.Rows.Count > 0)
                {
                    string base_imponible = "0";
                    string iva = "0";
                    //string recargo = "0";
                    string importe_total = "0";

                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                        {
                            string ComImp = dataGridView_Albaranes.Rows[x].Cells[6].Value.ToString(); 
                            base_imponible = Funciones.Suma(base_imponible, ComImp);                                                             
                        }
                    }

                    iva = Funciones.Multiplica("0,10", base_imponible);                    
                    importe_total = Funciones.Suma(base_imponible, iva);

                    textBox_BI.Text = Funciones.Formatea(base_imponible);
                    textBox_IVA.Text = Funciones.Formatea(iva);                   
                    textBox_Importe.Text = Funciones.Formatea(importe_total);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //temporizador para recuento
            Recuento_Importes_Albaranes();
        }

        private void checkBox_Marcar_CheckedChanged(object sender, EventArgs e)
        {
            //marcar todos los albaranes para facturar

            if (dataGridView_Albaranes.Rows.Count > 100)
            {
                MessageBox.Show("Hay más de 100 albaranes, el proceso llevaría demasiado tiempo");
            }
            else
            {

                this.Cursor = Cursors.WaitCursor;

                dataSource2.Clear();
                if (checkBox_Marcar.Checked == true)
                {
                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        dataGridView_Albaranes.Rows[x].Cells[0].Value = "False";
                        Marcaciones(x);
                    }
                   //Formato_Facturado();
                }
                else
                {
                    for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                    {
                        dataGridView_Albaranes.Rows[x].Cells[0].Value = "True";
                        Marcaciones(x);
                    }
                    //Formato_Facturado();
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAñadirProveedores_Click(object sender, EventArgs e)
        {
            if (textBox_ProCod.Text != "")
            {
                string strQ = "SELECT ProCod, ProNom FROM PROVEEDORES";
                //if (Filtro != "") { strQ += Filtro; }
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(strQ, GloblaVar.gcnO);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgvProveedores.DataSource = dt;
                dgvProveedores.AutoGenerateColumns = false;
                panelProveedores.Visible = true;

                if(listaProveedores.Count>0)
                {
                    //Recorremos el grid y marcamos los proveedores que teníamos seleccionados 
                    foreach(DataGridViewRow row in dgvProveedores.Rows)
                    {
                        if (listaProveedores.Contains(row.Cells["ProCodigo"].Value.ToString()))
                        {
                            row.Cells["Selec"].Value = true;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el proveedor de la factura");
            }

        }        

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //comprobar que se ha pulsado la primera columna
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dgvProveedores.Rows[e.RowIndex].Cells[0];

                    string proCod = dgvProveedores.Rows[e.RowIndex].Cells["ProCodigo"].Value.ToString();

                    if (ch1.Value == null)
                    {
                        ch1.Value = false;
                    }
                       
                    switch (ch1.Value.ToString())
                    {
                        case "True":
                            ch1.Value = false;
                            if(listaProveedores.Contains(proCod))
                            {
                                listaProveedores.Remove(proCod);
                            }                           
                            break;
                        case "False":
                            ch1.Value = true;
                            if(!listaProveedores.Contains(proCod))
                            {
                                listaProveedores.Add(proCod);
                            }                            
                            break;
                    }                  
                }
            }
        }

        private void btnAceptarProveedores_Click(object sender, EventArgs e)
        {            
            string cadenaProveedores = "";

            for (int i=0; i< listaProveedores.Count; i++)
            {
                if(i==listaProveedores.Count-1)
                {
                    cadenaProveedores += listaProveedores[i];
                }
                else
                {
                    cadenaProveedores += listaProveedores[i] + ", ";
                }
            }

            lblOtrosProveedores.Text = cadenaProveedores;
            panelProveedores.Visible = false;


            if (listaProveedores.Count > 0)
            {
                if (!listaProveedores.Contains(textBox_ProCod.Text))
                {
                    cadenaProveedores += ", " + textBox_ProCod.Text;
                }
            }
            else
            {
                cadenaProveedores = textBox_ProCod.Text;
            }

            Cargar(cadenaProveedores); 
        }
    }
}
