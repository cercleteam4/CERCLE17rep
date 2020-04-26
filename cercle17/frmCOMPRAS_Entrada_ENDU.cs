using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cercle17
{
    public partial class frmCOMPRAS_Entrada_ENDU : Form
    {
        private bool esEdicion = false;
        private bool esEdicionLinea = false;        
        private int contLinea = 0;
        private clase_albcom albaran = null;
        
        //Esta lista/clase la he creado para cargar los datos del grid. Datos de la línea de albarán y de la partida
        private List<clase_lineaAlbCom_partida> lineasAlbPartida = null; 

        public frmCOMPRAS_Entrada_ENDU()
        {
            InitializeComponent();
        }       
        
        private void limpiar()
        {
            esEdicion = false;
            dtpComCfa.Value = DateTime.Now;
            tbComCpa.Text = string.Empty;
            tbAnyo.Text = string.Empty;
            tbProCod.Text = string.Empty;
            tbProNom.Text = string.Empty;
            tbPortes.Text = string.Empty;
            tbColla.Text = string.Empty;
            lblTotalAlbaran.Text = "TOTAL ALBARÁN:     0,00";
            lblTotalCajas.Text = "TOTAL CAJAS:     0";
            lblTotalKilos.Text = "TOTAL KILOS:     0,00";
            lblGastos.Text = "GASTOS:     0,00";
            lblTotalconGastos.Text  = "TOTAL+GASTOS:  0,00";

            albaran = new clase_albcom();
            lineasAlbPartida.Clear();

            contLinea = 0;

            cargarGridLineas();

            btnNuevo.Enabled = false;
            dtpComCfa.Enabled = true;
            btnBorrarAlb.Visible = false;
            
        }

        private void limpiarDetalleLinea()
        {
            esEdicionLinea = false;

           
            tbComLnl.Text = string.Empty;
            tbComLim.Text = string.Empty;
            tbArtCod.Text = string.Empty;
            tbArtDes.Text = string.Empty;
            tbComLca.Text = string.Empty;
            tbComLki.Text = string.Empty;
            tbComLpr.Text = string.Empty;
            tbRef.Text = string.Empty;
            tbPartida.Text = string.Empty;
            cbArtePesca.Text = string.Empty;
            cbObtencion.Text = string.Empty;
            cbPresentacion.Text = string.Empty;
            //cbPtoDbco.Text = string.Empty;
            cbPais.Text = "ESPAÑA";
            tbPExpedidor2.Text = "";
            lCondEsps.Text = "CONSERVAR ENTRE 0 y 5º";
            lImpteLinea.Text = "";
            cbZonaCaptura.Text = string.Empty;
            
            if (tbProCod.Text != "")
            {
                CargarDatosProveedor(tbProCod.Text);
            }
            else
            {
                cbBarco.Text = "";
                cbBarco.DataSource = null;
                lBarco.Text = "";
                cbZonaCaptura.Text = "";

            }

            //cbPtoDbco.SelectedIndex = 0;

            dtpFCaptura.Value = dtpComCfa.Value.AddDays(-1);
            dtpFDesembarco.Value = dtpFCaptura.Value;
            dtpFElaboracion.Value = dtpComCfa.Value;
            tbFElaboracion.Text = string.Empty;
            dtpFCaducidad.Value = dtpComCfa.Value;           
            tbFCaducidad.Text = string.Empty;
          
        }

        private void frmCOMPRAS_Entrada_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
            GloblaVar.gUTIL.CartelTraza(gIdent + ".ENTRADA a " + gIdent);

            this.Text = "Albarán de Compras de ENDUMAR " + GloblaVar.VERSION;
            this.KeyPreview = true;
            albaran = new clase_albcom ();
            lineasAlbPartida = new List<clase_lineaAlbCom_partida>();

            cbPais.Text = "ESPAÑA";

            DataTable dtPtosDbco = Funciones.LlenarDataTable("SELECT IdPuerto, Puerto FROM PUERTOS_DBCO");            
            cbPtoDbco.DataSource = dtPtosDbco;
            cbPtoDbco.DisplayMember = "Puerto";
            cbPtoDbco.ValueMember = "IdPuerto";

            DataTable dtZonasCaptura = Funciones.LlenarDataTable("SELECT IdZC, ZC FROM ZONAS_CAPTURA");
            cbZonaCaptura.DataSource = dtZonasCaptura;
            cbZonaCaptura.DisplayMember = "ZC";
            cbZonaCaptura.ValueMember = "IdZC";
            cbZonaCaptura.Text = "";

            dtpFCaptura.Value = DateTime.Now.AddDays(-1);
            dtpFDesembarco.Value = dtpFCaptura.Value;

            if (esEdicion)
            {
                btnNuevo.Enabled = true;
                dtpComCfa.Enabled = false;
                tbArtCod.Focus();
            }
            else
            {
                btnNuevo.Enabled = false;
                dtpComCfa.Enabled = true;
                tbProCod.Focus();
            }      
            
        }       

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name +" ";
            GloblaVar.gUTIL.ATraza(gIdent + ".SALIENDO de " + gIdent);
           
            this.Close();
        }

        private void button_Listado_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscarAlbaran_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";

            string resp = "";

            frmCOMPRAS_Albaranes frm = new frmCOMPRAS_Albaranes();

            if(frm.ShowDialog() == DialogResult.OK)
            {

                resp = albaran.CogerAlbaranPorCodigo(frm.NumAlbaran, frm.AnyoAlbaran);
                GloblaVar.gUTIL.ATraza(gIdent + ".Buscar Albarán " + frm.NumAlbaran +"/" + frm.AnyoAlbaran);

                if (resp == "")
                {
                    tbComCpa.Text = albaran.ComCpa;
                    tbAnyo.Text = albaran.Anyo;
                    dtpComCfa.Value = Convert.ToDateTime(albaran.ComCfa);
                    tbProCod.Text = albaran.ProCod;
                    tbProNom.Text = Funciones.DameNomPro(albaran.ProCod);
                    tbPortes.Text = Funciones.Formatea(albaran.Portes);
                    tbColla.Text = Funciones.Formatea(albaran.Colla);

                    albaran.CogerAlbaranYLineasPorCodigo(albaran.ComCpa, albaran.Anyo);

                    cargarListaAlbPartida();
                    cargarGridLineas();
                    calcularTotalAlbaran();
                    calcularTotalCajas();
                    calcularTotalKilos();
                    calcularGastos();

                    CargarDatosProveedor(tbProCod.Text);

                    esEdicion = true;
                    btnNuevo.Enabled = true;
                    dtpComCfa.Enabled = false;
                    btnBorrarAlb.Visible = true;
                }
                else
                {
                    MessageBox.Show("Error al cargar el albarán\n" + resp);
                }
            }

        }

        private void btnProvBuscar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                GloblaVar.TIPO_CONSULTA = "PROVEEDORES";

                frmCONSULTA frmC = new frmCONSULTA();

                if (frmC.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbProCod.Text = GloblaVar.Cod_Buscado;
                    tbProNom.Text = GloblaVar.Nom_Buscado;

                    CargarDatosProveedor(tbProCod.Text);
                    btnBorrarAlb.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbProCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    tbProNom.Text = Funciones.DameNomPro(tbProCod.Text);

                    CargarDatosProveedor(tbProCod.Text);
                    //tbColla.Focus();
                    System.Windows.Forms.SendKeys.Send("{ENTER}");
                    //tbArtCod.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }

        }

        private void CargarDatosProveedor(string proCod)
        {
            if (proCod != "")
            { 

                DataTable dtBarcos = Funciones.LlenarDataTable(string.Format("SELECT Matricula, ProCod FROM BARCOS WHERE ProCod={0}", proCod));
                cbBarco.Text = "";
                lBarco.Text = "";
                cbBarco.DataSource = dtBarcos;
                cbBarco.DisplayMember = "Matricula";
                cbBarco.ValueMember = "Matricula";
                cbBarco.Text = "";

                DataTable dtProveedor = Funciones.LlenarDataTable(string.Format("SELECT IdZC, Matricula, IdPuerto, Pais, ProDom, ProPob  FROM PROVEEDORES WHERE ProCod={0}", proCod));

                if (dtProveedor != null && dtProveedor.Rows.Count > 0)
                {
                    DataRow dr = dtProveedor.Rows[0];

                    cbZonaCaptura.Text = "";

                    if(!dr.IsNull("Pais"))
                    {
                        cbPais.Text = Convert.ToString(dr["Pais"]);
                    }
                    else
                    {
                        cbPais.Text = "ESPAÑA";
                    }

                    if(!dr.IsNull("ProDom"))
                    {
                        tbPExpedidor2.Text = Convert.ToString(dr["ProDom"]);
                    }

                    cbZonaCaptura.Text = string.Empty;
                    DataTable dtZonasCaptura = Funciones.LlenarDataTable("SELECT IdZC, ZC FROM ZONAS_CAPTURA");
                    cbZonaCaptura.DataSource = dtZonasCaptura;
                    cbZonaCaptura.DisplayMember = "ZC";
                    cbZonaCaptura.ValueMember = "IdZC";
                    //cbZonaCaptura.Text = "";

                    if (!dr.IsNull("IdZC"))
                    {
                        cbZonaCaptura.SelectedValue = dr["IdZC"];
                    }
                    else
                    {
                        cbZonaCaptura.Text = "";
                    }

                    if (!dr.IsNull("Matricula"))
                    {
                        cbBarco.SelectedValue = dr["Matricula"];
                        lBarco.Text = dr["Matricula"].ToString();
                    }

                    if (!dr.IsNull("IdPuerto"))
                    {
                        cbPtoDbco.SelectedValue = dr["IdPuerto"];
                    }
                    else
                    {
                        cbPtoDbco.Text = "";
                    }

                    //if (cbBarco.SelectedValue == "") { cbBarco.Text = "-"; };

                    //if (!dr.IsNull("Matricula"))
                    //{
                    //    cbBarco.SelectedValue = dr["Matricula"];
                    //}
                }             
                
            }

        } //private void CargarDatosProveedor(string proCod)

        private void btnArtBuscar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                GloblaVar.TIPO_CONSULTA = "ARTICULOS";

                frmCONSULTA frmC = new frmCONSULTA();

                if (frmC.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbArtCod.Text = GloblaVar.Cod_Buscado;
                    //tbArtDes.Text = GloblaVar.Nom_Buscado;

                    cargarDatosArticulo(tbArtCod.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void tbArtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;           

            try
            {                

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    //tbArtDes.Text = Funciones.DameNomArt(tbArtCod.Text);

                    cargarDatosArticulo(tbArtCod.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

        private void cargarDatosArticulo(string artCod)
        {
            string resp = "";

            clase_articulo articulo = new clase_articulo();

            resp = articulo.CargarDatosArticuloPorCod(artCod);

            if(resp == "")
            {
                tbArtDes.Text = articulo.ArtDes;
                cbArtePesca.Text = articulo.ArtePesca;
                cbObtencion.Text = articulo.Obtencion;
                cbPresentacion.Text = articulo.Presentacion;

                if (!string.IsNullOrEmpty(articulo.ZFao ))
                {
                    cbZonaCaptura.Text = articulo.ZFao;
                }
            }
            else
            {
                MessageBox.Show("Error al cargar los datos del artículo: \n\n" + resp);
            }

        }

        private void cargarGridLineas()
        {
            dgvAlbLineas.AutoGenerateColumns = false;
            dgvAlbLineas.DataSource = null;
            dgvAlbLineas.DataSource = lineasAlbPartida;

            dgvAlbLineas.Columns["ComLca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbLineas.Columns["ComLki"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbLineas.Columns["ComLpr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAlbLineas.Columns["ComLim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvAlbLineas.Columns["FDesembarco"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvAlbLineas.Columns["FElaboracion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvAlbLineas.Columns["FCaducidad"].DefaultCellStyle.Format = "dd/MM/yyyy";

            //dgvAlbLineas.Columns[0].Visible = false;
        }       

        private void dgvAlbLineas_DoubleClick(object sender, EventArgs e)
        {
            string selec = dgvAlbLineas.CurrentRow.Cells["ComLnl"].Value.ToString();

            clase_lineaAlbCom_partida lineaSel = lineasAlbPartida.FirstOrDefault(x => x.ComLnl == selec);

            if (lineaSel != null)
            {
                tbComLnl.Text = lineaSel.ComLnl;               
                tbArtCod.Text = lineaSel.ArtCod;
                tbArtDes.Text = lineaSel.ArtDes;
                tbComLca.Text = lineaSel.ComLca;
                tbComLki.Text = lineaSel.ComLki;
                tbComLpr.Text = lineaSel.ComLpr;
                tbComLim.Text = lineaSel.ComLim;
                tbRef.Text = lineaSel.Ref;
                tbPartida.Text = lineaSel.Partida;
                cbArtePesca.Text = lineaSel.ArtePesca;
                cbObtencion.Text = lineaSel.Obtencion;
                cbPresentacion.Text = lineaSel.Presentacion;
                cbZonaCaptura.Text = lineaSel.ZCaptura;
                cbPais.Text = lineaSel.Pais;
                tbPExpedidor2.Text = lineaSel.PExpedidor2;

                if(lineaSel.FCaptura != "")
                {
                    dtpFCaptura.Value = Convert.ToDateTime(lineaSel.FCaptura);
                }
                
                cbBarco.Text = lineaSel.Matricula;
                cbPtoDbco.Text = lineaSel.PDesembarco;
                dtpFDesembarco.Value = Convert.ToDateTime(lineaSel.FDesembarco);

                if (lineaSel.FElaboracion != "")
                {
                    dtpFElaboracion.Value = Convert.ToDateTime(lineaSel.FElaboracion);
                }                   
               
                tbFElaboracion.Text = lineaSel.FElaboracion;
                if(lineaSel.FCaducidad!="")
                {
                    dtpFCaducidad.Value = Convert.ToDateTime(lineaSel.FCaducidad);
                }
                    
                tbFCaducidad.Text = lineaSel.FCaducidad;

                esEdicionLinea = true;
                
            }

        }

        private void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";

                if(lineasAlbPartida.Count > 0)
                {
                    string lineaSel = dgvAlbLineas.CurrentRow.Cells["ComLnl"].Value.ToString();                    

                    if(esEdicion)
                    {
                        clase_lineaAlbCom_partida lineaAP = lineasAlbPartida.FirstOrDefault(x => x.ComLnl == lineaSel);

                        if (lineaSel != null)
                        {
                            clase_linea_albcom linea = new clase_linea_albcom();

                            SqlTransaction sqlTran = GloblaVar.gConRem.BeginTransaction();

                            resp = linea.Eliminar(tbComCpa.Text, lineaSel, tbAnyo.Text, lineaAP.Partida, ref sqlTran);

                            if (resp == "")
                            {
                                sqlTran.Commit();
                            }
                            else
                            {
                                sqlTran.Rollback();
                            }        

                        }

                    }

                    if(resp == "")
                    {
                        lineasAlbPartida.RemoveAll(x => x.ComLnl == lineaSel);

                        cargarGridLineas();
                        calcularTotalAlbaran();
                        calcularTotalCajas();
                        calcularTotalKilos();
                        calcularGastos();

                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la línea del albarán:\n\n" + resp);
                    }
                }              

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la línea del albarán:\n\n" + ex.Message);
            }

        }

        private void btnAceptarLinea_Click(object sender, EventArgs e)
        {
            if (tbArtCod.Text == string.Empty || tbComLki.Text == string.Empty || tbComLpr.Text == string.Empty)
            {
                MessageBox.Show("Los campos artículo, kilos y precio son obligatorios");
            }
            else
            {
                if(esEdicion) //Edición albarán
                {
                    string resp = "";

                    if(esEdicionLinea)
                    {
                        clase_lineaAlbCom_partida lineaSel = lineasAlbPartida.FirstOrDefault(x => x.ComLnl == tbComLnl.Text);

                        lineaSel.ArtCod = tbArtCod.Text;
                        lineaSel.ArtDes = tbArtDes.Text;
                        lineaSel.ComLca = tbComLca.Text;
                        lineaSel.ComLki = Funciones.FormateaKilos(tbComLki.Text);
                        lineaSel.ComLpr = Funciones.Formatea(tbComLpr.Text);
                        lineaSel.ComLim = Funciones.Formatea(Funciones.Multiplica(lineaSel.ComLki, lineaSel.ComLpr));
                        lineaSel.Ref = tbRef.Text;
                        lineaSel.Partida = tbPartida.Text;
                        lineaSel.ArtePesca = cbArtePesca.Text;
                        lineaSel.Obtencion = cbObtencion.Text;
                        lineaSel.Presentacion = cbPresentacion.Text;
                        if (cbBarco.Text == "") { lineaSel.Matricula = lBarco.Text; } else       { lineaSel.Matricula = cbBarco.Text; }
                        lineaSel.PDesembarco = cbPtoDbco.Text;
                        lineaSel.FDesembarco = dtpFDesembarco.Value.ToShortDateString();
                        //lineaSel.FElaboracion = dtpFElaboracion.Value.ToShortDateString();
                        lineaSel.FElaboracion = tbFElaboracion.Text;
                        //lineaSel.FCaducidad = dtpFCaducidad.Value.ToShortDateString();
                        lineaSel.FCaducidad = tbFCaducidad.Text;
                        lineaSel.ZCaptura = cbZonaCaptura.Text;
                        lineaSel.FCaptura = dtpFCaptura.Value.ToShortDateString();
                        lineaSel.Pais = cbPais.Text;
                        lineaSel.PExpedidor1 = tbProNom.Text;
                        lineaSel.PExpedidor2 = tbPExpedidor2.Text;
                        lineaSel.CExped1 = lCExped1.Text;
                        lineaSel.CExped2 = lCExped2.Text;
                        lineaSel.CExped3 = lCExped3.Text;
                        lineaSel.CondEsps = lCondEsps.Text;
                        
                        //Modificamos la base de datos

                        clase_linea_albcom lineaAlb = new clase_linea_albcom();

                        lineaAlb = lineaAlb.CogerLineaAlbaranPorCodigoYLinea(tbComCpa.Text, tbAnyo.Text, tbComLnl.Text);
                        //lineaAlb.cPartida.CogerPartidaPorRef(lineaSel.Ref);
                        
                        lineaAlb.ArtCod = lineaSel.ArtCod;                       
                        lineaAlb.ComLca = lineaSel.ComLca;
                        lineaAlb.ComLki = lineaSel.ComLki;
                        lineaAlb.ComLpr = lineaSel.ComLpr;                        
                        lineaAlb.comlcp = lineaSel.ComLca;
                        lineaAlb.comlkp = lineaSel.ComLki;
                        lineaAlb.ComLim = lineaSel.ComLim;
                        lineaAlb.Ref = lineaSel.Ref;
                        //lineaAlb.Stock = lineaSel.ComLki;

                        lineaAlb.cPartida.PDesembarco = lineaSel.PDesembarco;
                        lineaAlb.cPartida.FDesembarco = lineaSel.FDesembarco;
                        lineaAlb.cPartida.FElaboracion = lineaSel.FElaboracion;
                        lineaAlb.cPartida.FCaducidad = lineaSel.FCaducidad;
                        lineaAlb.cPartida.ArtePesca = lineaSel.ArtePesca;
                        lineaAlb.cPartida.Obtencion = lineaSel.Obtencion;
                        lineaAlb.cPartida.Presentacion = lineaSel.Presentacion;
                        lineaAlb.cPartida.Matricula = lineaSel.Matricula;
                        lineaAlb.cPartida.ArtCod = lineaSel.ArtCod;
                        lineaAlb.cPartida.StockInicial = lineaSel.ComLki;
                        lineaAlb.cPartida.ZCaptura = lineaSel.ZCaptura;
                        lineaAlb.cPartida.FCaptura = lineaSel.FCaptura;
                        lineaAlb.cPartida.Pais = lineaSel.Pais;
                        lineaAlb.cPartida.PExpedidor1 = lineaSel.PExpedidor1;
                        lineaAlb.cPartida.PExpedidor2 = lineaSel.PExpedidor2;
                        lineaAlb.cPartida.CExped1 = lineaSel.CExped1;
                        lineaAlb.cPartida.CExped2 = lineaSel.CExped2;
                        lineaAlb.cPartida.CExped3 = lineaSel.CExped3;
                        lineaAlb.cPartida.CondEsps = lineaSel.CondEsps;
                        lineaAlb.cPartida.Ref = lineaSel.Ref;

                        //lineaAlb.cPartida.Stock = lineaSel.ComLki;                        

                        resp = lineaAlb.cPartida.Modificar();
                        if (resp == "")
                        {
                            resp = lineaAlb.Modificar();
                            if(resp == "")
                            {
                                cargarGridLineas();
                                calcularTotalAlbaran();
                                calcularTotalCajas();
                                calcularTotalKilos();
                                calcularGastos();
                                limpiarDetalleLinea();
                                //CargarDatosProveedor(tbProCod.Text);
                            }
                            else
                            {
                                MessageBox.Show("Error al modificar la línea del albarán:\n\n" + resp);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar la partida:\n\n" + resp);
                        }
                    }
                    else //Nueva línea
                    {
                        
                        clase_linea_albcom lineaAlb = new clase_linea_albcom();
                        string nuevaLnl = lineaAlb.ObtenerNumeroLineaAlbaran(tbComCpa.Text, tbAnyo.Text);

                        clase_lineaAlbCom_partida nueva = new clase_lineaAlbCom_partida();

                        nueva.ComLnl = nuevaLnl;
                        nueva.ArtCod = tbArtCod.Text;
                        nueva.ArtDes = tbArtDes.Text;
                        nueva.ComLca = tbComLca.Text;
                        nueva.ComLki = Funciones.FormateaKilos(tbComLki.Text);
                        nueva.ComLpr = Funciones.Formatea(tbComLpr.Text);
                        nueva.ComLim = Funciones.Formatea(Funciones.Multiplica(nueva.ComLki, nueva.ComLpr));
                        nueva.Ref = tbRef.Text;
                        nueva.ArtePesca = cbArtePesca.Text;
                        nueva.Obtencion = cbObtencion.Text;
                        nueva.Presentacion = cbPresentacion.Text;
                        nueva.Matricula = cbBarco.Text;
                        if (cbBarco.Text == "") { nueva.Matricula = lBarco.Text; } else { nueva.Matricula = cbBarco.Text; }
                        nueva.PDesembarco = cbPtoDbco.Text;
                        nueva.FDesembarco = dtpFDesembarco.Value.ToShortDateString();
                        //nueva.FElaboracion = dtpFElaboracion.Value.ToShortDateString();
                        nueva.FElaboracion = tbFElaboracion.Text;
                        //nueva.FCaducidad = dtpFCaducidad.Value.ToShortDateString();
                        nueva.FCaducidad = tbFCaducidad.Text;
                        nueva.ZCaptura = cbZonaCaptura.Text;
                        nueva.FCaptura = dtpFCaptura.Value.ToShortDateString();
                        nueva.Pais = cbPais.Text;
                        nueva.PExpedidor1 = tbProNom.Text;
                        nueva.PExpedidor2 = tbPExpedidor2.Text;
                        nueva.CExped1 = lCExped1.Text;
                        nueva.CExped2 = lCExped2.Text;
                        nueva.CExped3 = lCExped3.Text;
                        nueva.CondEsps = lCondEsps.Text;

                        //Ahora insertamos en base de datos                  

                        lineaAlb.ComLpa = tbComCpa.Text;
                        lineaAlb.ProCod = tbProCod.Text;
                        lineaAlb.comcfa = dtpComCfa.Value.ToString();
                        lineaAlb.ComLnl = nuevaLnl;
                        lineaAlb.comltl = "N";
                        lineaAlb.ArtCod = nueva.ArtCod;
                        lineaAlb.ComLca = nueva.ComLca;
                        lineaAlb.ComLki = nueva.ComLki;
                        lineaAlb.comlcp = nueva.ComLca;
                        lineaAlb.comlkp = nueva.ComLki;
                        lineaAlb.ComLpr = nueva.ComLpr;
                        lineaAlb.ComLim = nueva.ComLim;
                        lineaAlb.Ref = nueva.Ref;
                        lineaAlb.ComLal = "1";
                        lineaAlb.Stock = lineaAlb.ComLki;                        
                        lineaAlb.Anyo = tbAnyo.Text;                        
                        lineaAlb.AlmMay = "01";
                        lineaAlb.Facturado = false;

                        lineaAlb.cPartida.Anyo = tbAnyo.Text;
                        lineaAlb.cPartida.AlmMay = "01";
                        lineaAlb.cPartida.Ref = nueva.Ref;
                        lineaAlb.cPartida.PDesembarco = nueva.PDesembarco;
                        lineaAlb.cPartida.FDesembarco = nueva.FDesembarco;
                        lineaAlb.cPartida.ArtCod = nueva.ArtCod;
                        lineaAlb.cPartida.ProCod = tbProCod.Text;
                        lineaAlb.cPartida.FElaboracion = nueva.FElaboracion;
                        lineaAlb.cPartida.FCaducidad = nueva.FCaducidad;
                        lineaAlb.cPartida.StockInicial = nueva.ComLki;
                        lineaAlb.cPartida.ArtePesca = nueva.ArtePesca;
                        lineaAlb.cPartida.Obtencion = nueva.Obtencion;
                        lineaAlb.cPartida.Presentacion = nueva.Presentacion;
                        lineaAlb.cPartida.Matricula = nueva.Matricula;
                        lineaAlb.cPartida.AlbCompra = lineaAlb.ComLpa;
                        lineaAlb.cPartida.FCompra = lineaAlb.comcfa;
                        lineaAlb.cPartida.ZCaptura = nueva.ZCaptura;
                        lineaAlb.cPartida.FCaptura = nueva.FCaptura;
                        lineaAlb.cPartida.Pais = nueva.Pais;
                        lineaAlb.cPartida.PExpedidor1 = nueva.PExpedidor1;
                        lineaAlb.cPartida.PExpedidor2 = nueva.PExpedidor2;
                        lineaAlb.cPartida.CExped1 = nueva.CExped1;
                        lineaAlb.cPartida.CExped2 = nueva.CExped2;
                        lineaAlb.cPartida.CExped3 = nueva.CExped3;
                        lineaAlb.cPartida.CondEsps = nueva.CondEsps ;


                        SqlTransaction sqlTran = GloblaVar.gConRem.BeginTransaction();

                        resp = lineaAlb.cPartida.Insertar(ref sqlTran);
                        if (resp == "")
                        {
                            //Asignamos a la línea los datos que vienen de la partida (Partida y Ref)
                            lineaAlb.Partida = lineaAlb.cPartida.Partida;
                            lineaAlb.Ref = lineaAlb.cPartida.Ref;

                            nueva.Ref = lineaAlb.cPartida.Ref;
                            nueva.Partida = lineaAlb.Partida;
                            lineasAlbPartida.Add(nueva);                            

                            resp = lineaAlb.Insertar(ref sqlTran);                           

                        }                       

                        if (resp == "")
                        {
                            sqlTran.Commit();

                            cargarGridLineas();
                            calcularTotalAlbaran();
                            calcularTotalCajas();
                            calcularTotalKilos();
                            calcularGastos();
                            limpiarDetalleLinea();
                            //CargarDatosProveedor(tbProCod.Text);

                        }
                        else
                        {
                            sqlTran.Rollback();

                            MessageBox.Show("Error al insertar la línea del albarán:\n\n" + resp);
                        }

                    }

                }
                else //Nuevo albarán
                {
                    if (esEdicionLinea)
                    {
                        clase_lineaAlbCom_partida lineaSel = lineasAlbPartida.FirstOrDefault(x => x.ComLnl == tbComLnl.Text);

                        lineaSel.ArtCod = tbArtCod.Text;
                        lineaSel.ArtDes = tbArtDes.Text;
                        lineaSel.ComLca = tbComLca.Text;
                        lineaSel.ComLki = Funciones.FormateaKilos(tbComLki.Text);
                        lineaSel.ComLpr = Funciones.Formatea(tbComLpr.Text);
                        lineaSel.ComLim = Funciones.Formatea(Funciones.Multiplica(lineaSel.ComLki, lineaSel.ComLpr));
                        lineaSel.Ref = tbRef.Text;
                        //lineaSel.Partida = tbPartida.Text;
                        lineaSel.ArtePesca = cbArtePesca.Text;
                        lineaSel.Obtencion = cbObtencion.Text;
                        lineaSel.Presentacion = cbPresentacion.Text;
                        if (cbBarco.Text == "") { lineaSel.Matricula = lBarco.Text; } else { lineaSel.Matricula = cbBarco.Text; }
                        lineaSel.PDesembarco = cbPtoDbco.Text;
                        lineaSel.FDesembarco = dtpFDesembarco.Value.ToShortDateString();
                        //lineaSel.FElaboracion = dtpFElaboracion.Value.ToShortDateString();
                        lineaSel.FElaboracion = tbFElaboracion.Text;
                        //lineaSel.FCaducidad = dtpFCaducidad.Value.ToShortDateString();
                        lineaSel.FCaducidad = tbFCaducidad.Text;
                        lineaSel.ZCaptura = cbZonaCaptura.Text;
                        lineaSel.FCaptura = dtpFCaptura.Value.ToShortDateString();
                        lineaSel.Pais = cbPais.Text;
                        lineaSel.PExpedidor1 = tbProNom.Text;
                        lineaSel.PExpedidor2 = tbPExpedidor2.Text;
                        lineaSel.CExped1 = lCExped1.Text;
                        lineaSel.CExped2 = lCExped2.Text;
                        lineaSel.CExped3 = lCExped3.Text;
                        lineaSel.CondEsps = lCondEsps.Text;

                    }
                    else //Nueva línea
                    {
                        contLinea++;

                        clase_lineaAlbCom_partida nueva = new clase_lineaAlbCom_partida();

                        nueva.ComLnl = (contLinea).ToString();
                        nueva.ArtCod = tbArtCod.Text;
                        nueva.ArtDes = tbArtDes.Text;
                        nueva.ComLca = tbComLca.Text;
                        nueva.ComLki = Funciones.FormateaKilos(tbComLki.Text);
                        nueva.ComLpr = Funciones.Formatea(tbComLpr.Text);
                        nueva.ComLim = Funciones.Formatea(Funciones.Multiplica(nueva.ComLki, nueva.ComLpr));
                        nueva.Ref = tbRef.Text;                        
                        nueva.ArtePesca = cbArtePesca.Text;
                        nueva.Obtencion = cbObtencion.Text;
                        nueva.Presentacion = cbPresentacion.Text;
                        if (cbBarco.Text == "") { nueva.Matricula = lBarco.Text; } else { nueva.Matricula = cbBarco.Text; }
                        nueva.PDesembarco = cbPtoDbco.Text;
                        nueva.FDesembarco = dtpFDesembarco.Value.ToShortDateString();
                        //nueva.FElaboracion = dtpFElaboracion.Value.ToShortDateString();
                        nueva.FElaboracion = tbFElaboracion.Text;
                        //nueva.FCaducidad = dtpFCaducidad.Value.ToShortDateString();
                        nueva.FCaducidad = tbFCaducidad.Text;
                        nueva.ZCaptura = cbZonaCaptura.Text;
                        nueva.FCaptura = dtpFCaptura.Value.ToShortDateString();
                        nueva.Pais = cbPais.Text;
                        nueva.PExpedidor1 = tbProNom.Text;                        
                        nueva.PExpedidor2 = tbPExpedidor2.Text;
                        nueva.CExped1 = lCExped1.Text;
                        nueva.CExped2 = lCExped2.Text;
                        nueva.CExped3 = lCExped3.Text;
                        nueva.CondEsps = lCondEsps.Text;
                        lineasAlbPartida.Add(nueva);

                    }

                    cargarGridLineas();
                    EnsureVisibleRow(dgvAlbLineas, contLinea-1 );
                    calcularTotalAlbaran();
                    calcularTotalCajas();
                    calcularTotalKilos();
                    calcularGastos();
                    limpiarDetalleLinea();
                    //CargarDatosProveedor(tbProCod.Text);
                }

                tbArtCod.Focus();

            }            
        }

        private void btnCancelarLinea_Click(object sender, EventArgs e)
        {           
            limpiarDetalleLinea();
        }

        string importeTotal = "0,00";

        private void calcularTotalAlbaran()
        {
            lblTotalAlbaran.Text = "TOTAL ALBARÁN:     ";

            importeTotal = "0,00";

            for(int i = 0; i < dgvAlbLineas.Rows.Count; i++)
            {
                if(dgvAlbLineas.Rows[i].Cells[0].Value != null)
                {
                    string importe = dgvAlbLineas.Rows[i].Cells["ComLim"].FormattedValue.ToString();
                    importeTotal = Funciones.Formatea(Funciones.Suma(importeTotal, importe));                    
                }
            }

            lblTotalAlbaran.Text = lblTotalAlbaran.Text + importeTotal;

        }

        private void calcularTotalCajas()
        {
            lblTotalCajas.Text = "TOTAL CAJAS:     ";

            string totalCajas = "0";

            for (int i = 0; i < dgvAlbLineas.Rows.Count; i++)
            {
                if (dgvAlbLineas.Rows[i].Cells[0].Value != null)
                {
                    string cajas = dgvAlbLineas.Rows[i].Cells["ComLca"].FormattedValue.ToString();
                    totalCajas = Funciones.Suma(totalCajas, cajas);
                }
            }

            lblTotalCajas.Text = lblTotalCajas.Text + totalCajas;
        }

        string totalKilos = "0,00";

        private void calcularTotalKilos()
        {
            lblTotalKilos.Text = "TOTAL KILOS:     ";

            totalKilos = "0,00";

            for (int i = 0; i < dgvAlbLineas.Rows.Count; i++)
            {
                if (dgvAlbLineas.Rows[i].Cells[0].Value != null)
                {
                    string kilos = dgvAlbLineas.Rows[i].Cells["ComLki"].FormattedValue.ToString();
                    //La siguiente linea es para no considerar los kilos puestos en la linea de introduccion de cajas
                    if (dgvAlbLineas.Rows[i].Cells["ArtCod"].FormattedValue.ToString()!="7001") { totalKilos = Funciones.Formatea(Funciones.Suma(totalKilos, kilos)); }
                    
                }
            }

            lblTotalKilos.Text = lblTotalKilos.Text + totalKilos;
        }

        private void calcularGastos()
        {
            lblGastos.Text = "GASTOS:     ";

            string totalGastos = "";

            if(tbProCod.Text == "33" || tbProCod.Text == "266" || tbProCod.Text == "9057")
            {
                totalGastos = Funciones.Formatea(Funciones.Suma(Funciones.Multiplica("0,06", importeTotal), Funciones.Multiplica("0,50", totalKilos)));
            }
            else
            {
                totalGastos = Funciones.Formatea(Funciones.Suma(Funciones.Multiplica("0,06", importeTotal), Funciones.Multiplica("0,40", totalKilos)));
            }            

            lblGastos.Text = lblGastos.Text + totalGastos;

            string totalConGastos = Funciones.Formatea(Funciones.Suma(importeTotal, totalGastos));

            lblTotalconGastos.Text  = "TOTAL+GASTOS: " + totalConGastos;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name+" ";
            GloblaVar.gUTIL.ATraza(gIdent + "Comienza Grabación de Albarán ");
            try
            {
                string resp = "";

                if(tbProCod.Text == string.Empty || lineasAlbPartida.Count == 0)
                {
                    if(tbProCod.Text == string.Empty)
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + " Se dejaron el Código de proveedor vacio ");
                        resp = " - El proveedor es obligatorio\n";
                    }

                    if(lineasAlbPartida.Count == 0)
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + " Debe  añadir alguna linea de albarán ");
                        resp += " - Debe añadir alguna línea de albarán\n";
                    }

                    MessageBox.Show("Los siguientes campos son obligatorios: \n\n" + resp);
                    GloblaVar.gUTIL.ATraza(gIdent + " Los siguientes campos son obligatorios: " +resp);
                }
                else
                {
                    //Edición albarán, modifico sólo los datos generales del albarán, las líneas las iré modificando conforme las vaya editando
                    if(esEdicion)
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + " Modificando datos de Cabecera del albarán " );
                        bool modificaProCod = false;
                        if(albaran.ProCod!=tbProCod.Text)
                        {
                            modificaProCod = true;
                        }
                        albaran.ProCod = tbProCod.Text;
                        albaran.ComCfa = dtpComCfa.Value.ToString();
                        albaran.Anyo = dtpComCfa.Value.Year.ToString();
                        albaran.comcim = Funciones.Formatea(importeTotal);
                        albaran.Portes = Funciones.Formatea(tbPortes.Text);
                        albaran.Colla = Funciones.Formatea(tbColla.Text);

                        resp = albaran.Modificar(tbComCpa.Text, tbAnyo.Text, modificaProCod);
                        if (resp == "")
                        {
                            MessageBox.Show("El albarán se ha modificado correctamente");
                            GloblaVar.gUTIL.ATraza(gIdent + " El albarán se ha modificado correctamente ");
                            limpiar();
                            limpiarDetalleLinea();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar el albarán: \n\n" + resp);
                        }              

                    }
                    else //Nuevo albarán, inserto tanto los datos generales del albarán como las líneas
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + "Es Albarán Nuevo ");
                        albaran.ProCod = tbProCod.Text;
                        albaran.ComCfa = dtpComCfa.Value.ToString();
                        albaran.FpaCod = "1";
                        albaran.Comcpo = "0";
                        albaran.comctf = "P";
                        albaran.comcim = Funciones.Formatea(importeTotal);
                        albaran.Anyo = dtpComCfa.Value.Year.ToString();
                        albaran.Portes = Funciones.Formatea(tbPortes.Text);
                        albaran.Colla = Funciones.Formatea(tbColla.Text);

                        //albaran.lineas = lineasAlbPartida;

                        List<clase_linea_albcom> listLineasAlb = new List<clase_linea_albcom>();

                        foreach (clase_lineaAlbCom_partida lineaAP in lineasAlbPartida)
                        {
                            clase_linea_albcom lineaAlb = new clase_linea_albcom();

                            lineaAlb.ComLnl = lineaAP.ComLnl;
                            lineaAlb.ArtCod = lineaAP.ArtCod;
                            lineaAlb.ArtDes = lineaAP.ArtDes;
                            lineaAlb.ComLca = lineaAP.ComLca;
                            lineaAlb.ComLki = lineaAP.ComLki;
                            lineaAlb.ComLpr = lineaAP.ComLpr;
                            lineaAlb.ComLim = lineaAP.ComLim;
                            GloblaVar.gUTIL.ATraza(gIdent + "Linea " +lineaAP.ComLnl.ToString() + "Impte: " +lineaAP.ComLim.ToString());
                            lineaAlb.cPartida.Ref = lineaAP.Ref;
                            lineaAlb.cPartida.PDesembarco = lineaAP.PDesembarco;
                            lineaAlb.cPartida.FDesembarco = lineaAP.FDesembarco;
                            lineaAlb.cPartida.FElaboracion = lineaAP.FElaboracion;
                            lineaAlb.cPartida.FCaducidad = lineaAP.FCaducidad;
                            lineaAlb.cPartida.ArtePesca = lineaAP.ArtePesca;
                            lineaAlb.cPartida.Obtencion = lineaAP.Obtencion;
                            lineaAlb.cPartida.Presentacion = lineaAP.Presentacion;
                            lineaAlb.cPartida.Matricula = lineaAP.Matricula;
                            lineaAlb.cPartida.ZCaptura = lineaAP.ZCaptura;
                            lineaAlb.cPartida.FCaptura = lineaAP.FCaptura;
                            lineaAlb.cPartida.Pais = lineaAP.Pais;
                            lineaAlb.cPartida.PExpedidor1 = lineaAP.PExpedidor1;
                            lineaAlb.cPartida.PExpedidor2 = lineaAP.PExpedidor2;
                            lineaAlb.cPartida.CExped1 = lineaAP.CExped1;
                            lineaAlb.cPartida.CExped2 = lineaAP.CExped2;
                            lineaAlb.cPartida.CExped3 = lineaAP.CExped3;
                            lineaAlb.cPartida.CondEsps = lineaAP.CondEsps;

                            listLineasAlb.Add(lineaAlb);
                        }

                        albaran.lineas = listLineasAlb;

                        resp = albaran.Insertar();

                        if (resp == "")
                        {
                            MessageBox.Show("El albarán número " + albaran.ComCpa + " se ha insertado correctamente");

                            limpiar();
                            limpiarDetalleLinea();
                            tbProCod.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar el albarán: \n\n" + resp);
                        }                    
                    }
                    
                }                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
            }
        }

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            limpiarDetalleLinea();
        }

        private void cargarListaAlbPartida()
        {
            lineasAlbPartida.Clear();

            foreach(clase_linea_albcom lineaAlb in albaran.lineas)
            {
                clase_lineaAlbCom_partida lineaAP = new clase_lineaAlbCom_partida();

                lineaAP.ComLnl = lineaAlb.ComLnl;
                lineaAP.ArtCod = lineaAlb.ArtCod;
                lineaAP.ArtDes = Funciones.DameNomArt(lineaAlb.ArtCod);
                lineaAP.ComLca = lineaAlb.ComLca;
                lineaAP.ComLki = Funciones.FormateaKilos(lineaAlb.ComLki);
                lineaAP.ComLpr = Funciones.Formatea(lineaAlb.ComLpr);
                lineaAP.ComLim = Funciones.Formatea(Funciones.Multiplica(lineaAlb.ComLki, lineaAlb.ComLpr));
                lineaAP.Ref = lineaAlb.cPartida.Ref;
                lineaAP.Partida = lineaAlb.cPartida.Partida;
                lineaAP.ArtePesca = lineaAlb.cPartida.ArtePesca;
                lineaAP.Obtencion = lineaAlb.cPartida.Obtencion;
                lineaAP.Presentacion = lineaAlb.cPartida.Presentacion;
                lineaAP.Matricula = lineaAlb.cPartida.Matricula;
                lineaAP.PDesembarco = lineaAlb.cPartida.PDesembarco;
                lineaAP.FDesembarco = Convert.ToDateTime(lineaAlb.cPartida.FDesembarco).ToShortDateString();
                lineaAP.FElaboracion = lineaAlb.cPartida.FElaboracion;
                lineaAP.FCaducidad = lineaAlb.cPartida.FCaducidad;
                lineaAP.ZCaptura = lineaAlb.cPartida.ZCaptura;
                lineaAP.FCaptura = lineaAlb.cPartida.FCaptura;
                lineaAP.Pais = lineaAlb.cPartida.Pais;
                lineaAP.PExpedidor1 = lineaAlb.cPartida.PExpedidor1;
                lineaAP.PExpedidor2 = lineaAlb.cPartida.PExpedidor2;
                lineaAP.CExped1 = lineaAlb.cPartida.CExped1;
                lineaAP.CExped2 = lineaAlb.cPartida.CExped2;
                lineaAP.CExped3 = lineaAlb.cPartida.CExped3;
                lineaAP.CondEsps  = lineaAlb.cPartida.CondEsps ;

                lineasAlbPartida.Add(lineaAP);
            }
            
        }        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            limpiarDetalleLinea();

            //dtpComCfa.Enabled = true;
        }

        private void tbProCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbPortes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbColla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                //System.Windows.Forms.SendKeys.Send("{TAB}");
                tbArtCod.Focus();
            }                
        }

        private void tbArtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbComLca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbComLki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (tbComLpr.Text != "") { lImpteLinea.Text = Convert.ToString(Convert.ToDecimal(tbComLki.Text.Replace('.', ',')) * Convert.ToDecimal(tbComLpr.Text.Replace('.', ','))); } else { lImpteLinea.Text = ""; }
                System.Windows.Forms.SendKeys.Send("{TAB}");

            }
        }

        private void tbComLpr_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (tbComLki.Text != "") { lImpteLinea.Text = Convert.ToString(Convert.ToDecimal(tbComLki.Text.Replace('.',',')) * Convert.ToDecimal(tbComLpr.Text.Replace('.', ','))); } else { lImpteLinea.Text = ""; }

                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                System.Windows.Forms.SendKeys.Send("{TAB}");
                //System.Windows.Forms.SendKeys.Send("{TAB}");

            }
        }

        private void tbRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbArtePesca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbObtencion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbZonaCaptura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void dtpFCaptura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbBarco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cbPtoDbco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void dtpFDesembarco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbFElaboracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void tbFCaducidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void dtpFElaboracion_ValueChanged(object sender, EventArgs e)
        {
            tbFElaboracion.Text = dtpFElaboracion.Value.ToShortDateString();
        }

        private void dtpFCaducidad_ValueChanged(object sender, EventArgs e)
        {
            tbFCaducidad.Text = dtpFCaducidad.Value.ToShortDateString();
        }

        private void cbPais_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void frmCOMPRAS_Entrada_ENDU_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F12:
                    this.btnGuardar_Click(sender, e);
                    break;
            }
        }//private void frmCOMPRAS_Entrada_ENDU_KeyDown(object sender, KeyEventArgs e)

        private void frmCOMPRAS_Entrada_ENDU_Activated(object sender, EventArgs e)
        {
            tbProCod.Focus();
        }

        private void btnBorrarAlb_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            GloblaVar.gUTIL.ATraza(gIdent + "Comienza Borrar Albarán ");

            try
            {
                string sQC = "DELETE FROM COMALB_CABE WHERE Anyo=" + dtpComCfa.Value.Year + " AND ComCpa=" + tbComCpa.Text;
                string sQL= "DELETE FROM COMALB_LINEAS WHERE Anyo=" + dtpComCfa.Value.Year + " AND ComLpa=" + tbComCpa.Text;
                string sQP = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = GloblaVar.gConRem;
                foreach (clase_linea_albcom lineaAlb in albaran.lineas)
                {
                    sQP = "DELETE FROM PARTIDAS WHERE Partida=" +lineaAlb.Partida.ToString() +" AND Anyo=" + lineaAlb.Anyo.ToString() ;
                    
                    cmd.CommandText = sQP;
                    cmd.ExecuteNonQuery();
                    GloblaVar.gUTIL.ATraza(gIdent + "Borrada Partida " + lineaAlb.Partida.ToString() + "/" + lineaAlb.Anyo.ToString());

                }  //foreach (clase_linea_albcom lineaAlb in albaran.lineas)
                cmd.CommandText = sQL;
                cmd.ExecuteNonQuery();
                GloblaVar.gUTIL.ATraza(gIdent + "Borradas Lineas del Albarán " + tbComCpa.Text + "/" + dtpComCfa.Value.Year);
                cmd.CommandText = sQC;
                cmd.ExecuteNonQuery();
                GloblaVar.gUTIL.ATraza(gIdent + "Borrada Cabecera del Albarán " + tbComCpa.Text + "/" + dtpComCfa.Value.Year);
                GloblaVar.gUTIL.ATraza(gIdent + "Albarán " + tbComCpa.Text + "/" + dtpComCfa.Value.Year + " Completamente Borrado");
                limpiar();
                limpiarDetalleLinea();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + "Error al Borrar el Albarán " + tbComCpa.Text + "/" + dtpComCfa.Value.Year);
                GloblaVar.gUTIL.ATraza(ex.Message);
            }
        }  //private void btnBorrarAlb_Click(object sender, EventArgs e)

        private static void EnsureVisibleRow(DataGridView view, int rowToShow)
        {
            if (rowToShow >= 0 && rowToShow < view.RowCount)
            {
                var countVisible = view.DisplayedRowCount(false);
                var firstVisible = view.FirstDisplayedScrollingRowIndex;
                if (rowToShow < firstVisible)
                {
                    view.FirstDisplayedScrollingRowIndex = rowToShow;
                }
                else if (rowToShow >= firstVisible + countVisible)
                {
                    view.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
                }
            }
        }  //private static void EnsureVisibleRow(DataGridView view, int rowToShow)

        private void tb_Enter(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";

            try
            {
                TextBox TB = sender as TextBox;
                foreach (TextBox tbs in this.Controls.OfType<TextBox>())
                {
                    tbs.BackColor = Color.White;
                }
                if (sender is TextBox)
                {
                    TextBox tb = sender as TextBox;
                    tb.BackColor = Color.Yellow;
                }

                //TB.BackColor = Color.Yellow;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        }   //private void tb_Enter(object sender, EventArgs e)

        private void tb_Leave(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            
            try
            {
                TextBox TB = sender as TextBox;
                //foreach (TextBox tbs in this.Controls.OfType<TextBox>())
                //{
                //    tbs.BackColor = Color.White;
                //}
                if (sender is TextBox)
                {
                    TextBox tb = sender as TextBox;
                    tb.BackColor = Color.White;
                }

                //TB.BackColor = Color.Yellow;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }
        }   //private void tb_Leave(object sender, EventArgs e)

        private void dtpFCaptura_ValueChanged(object sender, EventArgs e)
        {
            dtpFDesembarco.Value = dtpFCaptura.Value;
        }

        private void dtpComCfa_ValueChanged(object sender, EventArgs e)
        {
            dtpFCaptura.Value = dtpComCfa.Value.Date.AddDays(-1);
            dtpFDesembarco.Value= dtpComCfa.Value.Date.AddDays(-1);
        }

        
    }
}
