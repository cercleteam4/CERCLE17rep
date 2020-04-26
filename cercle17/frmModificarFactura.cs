using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmModificarFactura : Form
    {
        public frmModificarFactura()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;
        public ArrayList Lista_detallistas;
        public clase_cabecera_factura factura;


        //definimos el binding del primer grid, donde pondremos los albaranes

        private BindingList<clase_albaran> dataSource1 = new BindingList<clase_albaran>();
        private BindingSource bs1 = new BindingSource();

        //y el binding del segundo grid, donde pondremos las lineas de factura

        private BindingList<clase_linea_factura> dataSource2 = new BindingList<clase_linea_factura>();
        private BindingSource bs2 = new BindingSource();


        private void Cargar()
        {
            //select de cabeceras albaranes de venta (no facturados) por detallista

            string strQ = "SELECT * FROM VENALB_CABE WHERE (DetCod=" + textBox_DetCod.Text + ") AND ((VenNfp = " + textBox_Factura.Text + " AND AnyoFra = " + factura.Anyo  + " AND SerieFra = '" + factura.Serie + "') OR (VenNfp IS NULL AND AnyoFra IS NULL AND SerieFra IS NULL)) AND (Anulado<>1) order by VenFec, VenAlb";

            this.Cursor = Cursors.WaitCursor;

            //limpiamos ambos grids por el binding
            dataSource1.Clear();
            dataSource2.Clear();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_albaran alba = new clase_albaran();

                    alba.Albaran = myReader["VenAlb"].ToString();
                    alba.Año = myReader["Anyo"].ToString();
                    alba.Facturar = false; if (myReader["VenNfp"].ToString() == textBox_Factura.Text) { alba.Facturar = true; }
                    alba.Fecha = myReader["VenFec"].ToString(); if (alba.Fecha.Length > 10) { alba.Fecha = alba.Fecha.Substring(0, 10); }
                    alba.TV = myReader["VenTve"].ToString();
                    alba.Total = Funciones.Formatea(myReader["VenTot"].ToString());
                    alba.BI = myReader["VenBru"].ToString();
                    alba.IVA = myReader["VenIva"].ToString();
                    alba.Recargo = myReader["VenRec"].ToString();

                    dataSource1.Add(alba);
                }
                myReader.Close();

                if (dataGridView_Albaranes.Rows.Count > 0)
                {
                    dataGridView_Albaranes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView_Albaranes.Columns[6].Visible = false;
                    dataGridView_Albaranes.Columns[7].Visible = false;
                    dataGridView_Albaranes.Columns[8].Visible = false;
                    dataGridView_Albaranes.Columns[9].Visible = false;
                    dataGridView_Albaranes.Columns[10].Visible = false;
                    dataGridView_Albaranes.Columns[11].Visible = false;
                    dataGridView_Albaranes.Columns[12].Visible = false;
                    dataGridView_Albaranes.Columns[13].Visible = false;
                    dataGridView_Albaranes.Columns[14].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Cursor = Cursors.Default;

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
                    dataGridView_Facturado.Rows[x].Cells[1].Value = contador.ToString(); //la celda 1 es Pos
                }
            }
        }

        private void Formato_Facturado()
        {
            //esta función ajusta las columnas de lineas de factura

            if (dataGridView_Facturado.Rows.Count > 0)
            {
                dataGridView_Facturado.Columns[0].Visible = false;
                dataGridView_Facturado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[2].Visible = false;
                dataGridView_Facturado.Columns[3].Visible = false;
                dataGridView_Facturado.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[5].Visible = false;
                dataGridView_Facturado.Columns[6].Visible = false;
                dataGridView_Facturado.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_Facturado.Columns[13].Visible = false;
                dataGridView_Facturado.Columns[14].Visible = false;
                dataGridView_Facturado.Columns[15].Visible = false;
            }
        }

        private void Marcaciones(int indice)
        {
            //esta función se activa cuando se marca un albarán

            string VenAlb = dataGridView_Albaranes.Rows[indice].Cells[1].Value.ToString();
            string Anyo = dataGridView_Albaranes.Rows[indice].Cells[3].Value.ToString();
            string VenFec = dataGridView_Albaranes.Rows[indice].Cells[4].Value.ToString();

            string VenBru = dataGridView_Albaranes.Rows[indice].Cells[6].Value.ToString();
            string VenIva = dataGridView_Albaranes.Rows[indice].Cells[7].Value.ToString();
            string VenRec = dataGridView_Albaranes.Rows[indice].Cells[8].Value.ToString();


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

                        if (dataGridView_Facturado.Rows[x].Cells[4].Value.ToString() == VenAlb)
                        {
                            encontrada = true;
                            row = x;
                        }

                        if (encontrada == true)
                        {
                            dataGridView_Facturado.Rows.Remove(dataGridView_Facturado.Rows[row]);
                            Renumerar_Grid();
                        }
                    }
                }

            }
            else
            {
                dataGridView_Albaranes.Rows[indice].Cells[0].Value = true;
                int contador = dataGridView_Facturado.Rows.Count + 1;

                //lectura de lineas de albarán
                ArrayList Lineas = Funciones.Lineas_Albaran(VenAlb, Anyo, CnO);

                for (int x = 0; x < Lineas.Count; x++)
                {
                    detalle_linea_albaran linea_albaran = (detalle_linea_albaran)Lineas[x];

                    clase_linea_factura linea_factura = new clase_linea_factura();

                    linea_factura.Albaran = VenAlb;
                    linea_factura.Anyo = textBox_Anyo.Text;
                    linea_factura.AnyoAlb = Anyo;
                    linea_factura.ArtCod = linea_albaran.ArtCod;
                    linea_factura.Cajas = linea_albaran.VelBul;
                    linea_factura.Factura = "";
                    linea_factura.Importe = Funciones.Formatea(linea_albaran.VelImp);
                    linea_factura.Kilos = linea_albaran.VelKil;
                    linea_factura.Linea = contador.ToString();
                    linea_factura.LineaAlbaran = linea_albaran.VelLin;
                    linea_factura.PartAnyo = linea_albaran.PartAnyo;
                    linea_factura.Partida = linea_albaran.Partida;
                    linea_factura.Precio = linea_albaran.VelPre;
                    linea_factura.Serie = textBox_Serie.Text;
                    linea_factura.Traza = linea_albaran.VelTrz;
                    linea_factura.PartAlm = linea_albaran.PartAlm;

                    //se ha creado una línea de factura a partir de las lineas del albarán y ahora se agrega por binding

                    dataSource2.Add(linea_factura);

                    contador++;
                }

            }

        }

        private void Leer_Albaranes()
        {
            for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
            {
                if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                {
                    dataGridView_Albaranes.Rows[x].Cells[0].Value = "False";
                    Marcaciones(x);
                }
            }
            Formato_Facturado();
        }

        private void frmModificarFactura_Load(object sender, EventArgs e)
        {
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);

            textBox_DetCod.Text = factura.DetCod;
            textBox_Anyo.Text = factura.Anyo;
            textBox_DetNom.Text = factura.DetNom;
            textBox_Factura.Text = factura.Factura;
            textBox_Serie.Text = factura.Serie;

            //leer los campos de cabecera
            string strQ = "select Observaciones, TextoPie, TextoCabe FROM FACTV_CABE WHERE Factura=" + textBox_Factura.Text + " AND Anyo=" + textBox_Anyo.Text + " AND Serie='" + textBox_Serie.Text + "'";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    textBox_Observaciones.Text = myReader["Observaciones"].ToString();
                    textBox_TextoCabecera.Text = myReader["TextoCabe"].ToString();
                    textBox_TextoPie.Text = myReader["TextoPie"].ToString();
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //limpiamos los datagrid y hacemos binding
            dataSource1.Clear();
            bs1.DataSource = dataSource1;
            dataGridView_Albaranes.DataSource = bs1;

            dataSource2.Clear();
            bs2.DataSource = dataSource2;
            dataGridView_Facturado.DataSource = bs2;

            //se cargan todos los albaranes del detallista + los que pertenecen a esta factura
            //se marcan los albaranes que pertenecen a esta factura
            Cargar();

            //pero para que entren en el grid de facturados no basta con haberlos marcado por código (hay que pulsar con el ratón)
            //ahora leemos los marcados, solo porque hay que hacerlo la primera vez que se entra
            Leer_Albaranes();

            //array de detallistas
            Lista_detallistas = new ArrayList();
            strQ = "SELECT * FROM DETALLISTAS order by DetCod";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    clase_detallista detal = new clase_detallista();

                    detal.DetCod = myReader["DetCod"].ToString();
                    detal.DetNom = myReader["DetNom"].ToString();
                    detal.DetCpf = "";
                    detal.DetEMail = myReader["DetEMail"].ToString();
                    detal.detvia = myReader["detvia"].ToString();
                    detal.DetCop = myReader["DetCop"].ToString();
                    detal.detmun = myReader["DetMun"].ToString();
                    detal.DetNif = myReader["DetNif"].ToString();

                    Lista_detallistas.Add(detal);
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private int EjecutaNonQuery(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, CnO);
                res = myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return res;
        }

        private void button_Grabar_Click(object sender, EventArgs e)
        {
            //grabar las líneas
            ArrayList Lista_Albaranes = new ArrayList();

            for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
            {
                if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                {
                    dato_albaran dato = new dato_albaran();

                    dato.VenAlb = dataGridView_Albaranes.Rows[x].Cells[1].Value.ToString();
                    dato.Anyo = dataGridView_Albaranes.Rows[x].Cells[3].Value.ToString();

                    Lista_Albaranes.Add(dato);
                }
            }

            //comprobar si la factura tiene líneas
            if (Lista_Albaranes.Count > 0)
            {
                //si tiene se graban los cambios
                //pero tiene que hacerse con un UPDATE en vez de un INSERT

                //cabecera

                string observaciones = textBox_Observaciones.Text.Replace("'", "''"); if (observaciones.Length > 99) { observaciones = observaciones.Substring(0, 99); }
                string textopie = textBox_TextoPie.Text.Replace("'", "''"); if (textopie.Length > 199) { textopie = textopie.Substring(0, 199); }
                string textocabe = textBox_TextoCabecera.Text.Replace("'", "''"); if (textocabe.Length > 199) { textocabe = textocabe.Substring(0, 199); }

                string update_cabecera = "UPDATE FACTV_CABE SET DetCod=" + textBox_DetCod.Text + ", BI1=" + textBox_BI.Text.Replace(",", ".") + ", IVA1=" + textBox_IVA.Text.Replace(",", ".") + ", RE1=" + textBox_Recargo.Text.Replace(",", ".") + ", ImpteFactura=" + textBox_Importe.Text.Replace(",", ".") + ", ImptePendiente=" + textBox_Importe.Text.Replace(",", ".") + ", ";
                update_cabecera += " Observaciones='" + observaciones + "', TextoPie='" + textopie + "', TextoCabe='" + textocabe + "' ";
                update_cabecera += " WHERE Factura=" + textBox_Factura.Text + " AND Anyo=" + textBox_Anyo.Text + " AND Serie='" + textBox_Serie.Text + "' ";

                int res_cabecera = EjecutaNonQuery(update_cabecera);

                Funciones.Escribe_LOG("Se ha modificado una factura. Se incluye el update a continuación.", "MODIFICAR", CnO);
                Funciones.Escribe_LOG(update_cabecera, "MODIFICAR", CnO);

                //hay que borrar las líneas anteriores y escribir las nuevas

                string delete_lineas = "DELETE FACTV_LINEAS WHERE Factura=" + textBox_Factura.Text + " AND Anyo=" + textBox_Anyo.Text + " AND Serie='" + textBox_Serie.Text + "' ";
                int res_delete = EjecutaNonQuery(delete_lineas);

                //hay que desmarcar también los albaranes que estaban marcados

                string desmarca_albaranes = "UPDATE VENALB_CABE SET VenNfp = NULL, AnyoFra = NULL, SerieFra = NULL WHERE VenNfp=" + textBox_Factura.Text + " AND AnyoFra=" + textBox_Anyo.Text + " AND SerieFra='" + textBox_Serie.Text + "' ";
                int res_desmarcar = EjecutaNonQuery(desmarca_albaranes);

                //y marcar los nuevos

                Funciones.Marcar_Ventas(textBox_Factura.Text, textBox_Anyo.Text, textBox_Serie.Text, Lista_Albaranes, CnO);

                //y ahora escribimos las nuevas, código basado en Funciones.Facturar

                ArrayList Lista_Lineas_Factura = new ArrayList();
                int contador = 1;

                for (int y = 0; y < Lista_Albaranes.Count; y++)
                {
                    dato_albaran albaran = (dato_albaran)Lista_Albaranes[y];

                    ArrayList Lista_Lineas_Albaran = Funciones.Lineas_Albaran(albaran.VenAlb, albaran.Anyo, CnO);

                    if (Lista_Lineas_Albaran != null)
                    {
                        for (int x = 0; x < Lista_Lineas_Albaran.Count; x++)
                        {
                            detalle_linea_albaran linea_albaran = (detalle_linea_albaran)Lista_Lineas_Albaran[x];

                            clase_linea_factura linea_factura = new clase_linea_factura();

                            linea_factura.Albaran = albaran.VenAlb;
                            linea_factura.Anyo = textBox_Anyo.Text;
                            linea_factura.AnyoAlb = albaran.Anyo;
                            linea_factura.ArtCod = linea_albaran.ArtCod;
                            linea_factura.Cajas = linea_albaran.VelBul;
                            linea_factura.Factura = textBox_Factura.Text;
                            linea_factura.Importe = linea_albaran.VelImp;
                            linea_factura.Kilos = linea_albaran.VelKil;
                            linea_factura.Linea = contador.ToString();
                            linea_factura.LineaAlbaran = linea_albaran.VelLin;
                            linea_factura.PartAnyo = linea_albaran.PartAnyo;
                            linea_factura.Partida = linea_albaran.Partida;
                            linea_factura.Precio = linea_albaran.VelPre;
                            linea_factura.Serie = textBox_Serie.Text;
                            linea_factura.Traza = linea_albaran.VelTrz;
                            linea_factura.PartAlm = linea_albaran.PartAlm;

                            Lista_Lineas_Factura.Add(linea_factura);

                            contador++;
                        }
                    }

                }

                for (int x = 0; x < Lista_Lineas_Factura.Count; x++)
                {
                    clase_linea_factura linea = (clase_linea_factura)Lista_Lineas_Factura[x];

                    string insert_linea = "INSERT FACTV_LINEAS(Factura, Anyo, Serie, LinF, VelAlb, AnyoAlb, VelLin, ArtCod, VelBul, VelKil, VelPre, VelTrz, VelImp, Partida, PartAnyo, PartAlm) ";
                    insert_linea += " VALUES (" + textBox_Factura.Text + ", " + textBox_Anyo.Text + ", '" + textBox_Serie.Text + "', " + linea.Linea + ", " + linea.Albaran + ", " + linea.AnyoAlb + ", " + linea.LineaAlbaran + ", " + linea.ArtCod + ", " + linea.Cajas.Replace(",", ".") + ", " + linea.Kilos.Replace(",", ".") + ", " + linea.Precio.Replace(",", ".") + ", '" + linea.Traza + "', " + linea.Importe.Replace(",", ".") + ", " + linea.Partida + ", " + linea.PartAnyo + ", '" + linea.PartAlm + "')";

                    int res_linea = EjecutaNonQuery(insert_linea);
                }

                //y ya está todo hecho
                //cerraremos el formulario y devolverá un OK

            }
            else
            {
                //si no tiene se avisa
                MessageBox.Show("No se puede grabar una factura sin líneas");

                //el formulario se cerrará pero no habrá hecho ningún cambio en la BD
            }
        }

        private void Recuento_Importes_Albaranes()
        {
            if (dataGridView_Albaranes.Rows.Count > 0)
            {
                string base_imponible = "0";
                string iva = "0";
                string recargo = "0";
                string importe_total = "0";

                for (int x = 0; x < dataGridView_Albaranes.Rows.Count; x++)
                {
                    if (dataGridView_Albaranes.Rows[x].Cells[0].FormattedValue.ToString().ToLower() == "true")
                    {
                        string VenTot = dataGridView_Albaranes.Rows[x].Cells[5].Value.ToString();
                        string VenBru = dataGridView_Albaranes.Rows[x].Cells[6].Value.ToString();
                        string VenIva = dataGridView_Albaranes.Rows[x].Cells[7].Value.ToString();
                        string VenRec = dataGridView_Albaranes.Rows[x].Cells[8].Value.ToString();

                        base_imponible = Funciones.Suma(base_imponible, VenBru);
                        iva = Funciones.Suma(iva, VenIva);
                        recargo = Funciones.Suma(recargo, VenRec);
                        importe_total = Funciones.Suma(importe_total, VenTot);
                    }
                }

                textBox_BI.Text = Funciones.Formatea(base_imponible);
                textBox_IVA.Text = Funciones.Formatea(iva);
                textBox_Recargo.Text = Funciones.Formatea(recargo);
                textBox_Importe.Text = Funciones.Formatea(importe_total);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //temporizador para recuento
            Recuento_Importes_Albaranes();
        }

        private void dataGridView_Albaranes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //comprobar que se ha pulsado la primera columna
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    Marcaciones(e.RowIndex);
                    Formato_Facturado();
                }
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Consulta_Click(object sender, EventArgs e)
        {
            //abrir formulario para consulta de Detallista
            FormDetallistas Consulta = new FormDetallistas();
            Consulta.Lista_detallistas = Lista_detallistas;
            if (Consulta.ShowDialog() == DialogResult.OK)
            {
                if (Consulta.DetCod != "")
                {
                    textBox_DetCod.Text = Consulta.DetCod;
                    textBox_DetNom.Text = Consulta.Nombre_Det;
                    Cargar();
                }
            }
        }
    }
}
