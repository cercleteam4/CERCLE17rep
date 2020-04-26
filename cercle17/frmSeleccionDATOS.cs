using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cercle17
{
    public partial class frmSeleccionDatos : Form
    {
        public frmSeleccionDatos()
        {
            InitializeComponent();
        }

        string Base = "OREMAPE";
        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------SALIENDO de " + this.GetType().FullName);
            this.Close();
        }

        private void frmSeleccionDatos_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            this.Text = "SELECCIÓN DE DATOS PARA LISTADOS  " + GloblaVar.VERSION;

            //Mostraremos al cargar el form los paneles de selección de datos necesarios para cada Listado
            switch (GloblaVar.TIPO_REPORT)
            {
                case 1:     //Listado de RENTABILIDAD DE VENDEDORES
                    panelFec.Visible = true; dateTimePicker_Inicio.Text = ""; dateTimePicker_Fin.Text = "";
                    panelVended.Visible = true; 
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO","VENDEDORES")==1)
                    {
                        tVendedIni.Text = GloblaVar.Cod_Buscado ;
                        lVendedIni.Text = GloblaVar.Nom_Buscado;
                    }
                    tVendedFin.Text = GloblaVar.Cod_Buscado;
                    lVendedFin.Text = GloblaVar.Nom_Buscado;
                    panelArt.Visible = true;
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO","ARTICULOS")==1)
                    {
                        tArtIni.Text = GloblaVar.Cod_Buscado ;
                        lArtIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO","ARTICULOS")==1)
                    {
                        tArtFin.Text = GloblaVar.Cod_Buscado;
                        lArtFin.Text = GloblaVar.Nom_Buscado;
                    }
                    break;
                case 2:     //Listado de Venta: Fecha, Articulos, Detallistas
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelDet.Visible = true;
                    tDetIni.Text = "1";
                    lDetIni.Text = "";
                    tDetFin.Text = "1";
                    lDetFin.Text = "";
                    panelArt.Visible = true;
                    tArtIni.Text = "1";
                    lArtIni.Text = "";
                    tArtFin.Text = "1";
                    lArtFin.Text="";
                    break;
                case 3:     //LISTADO DE FACTURAS DE CLIENTES
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelDet.Visible = true;
                    panelDet.Location = new Point(220, 93);
                    tDetIni.Text = "1";
                    lDetIni.Text = "";
                    tDetFin.Text = "1";
                    lDetFin.Text = "";
                    panelFact1.Visible = true;
                    panelFact1.Location = new Point(593,93);
                    break;
                case 4:     //FICHERO DE FACTURACIÓN PROPIA DE BOTELLA PARA OMP
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelDet.Visible = true;
                    panelExclDet.Visible = true;
                    panelInclDet.Visible = true;
                    tDetIni.Text = "1";
                    lDetIni.Text = "";
                    tDetFin.Text = "1";
                    lDetFin.Text = "";
                    tDetIni.Focus();
                    break;
                case 5:     //Listado de Compras: Fecha, Artículos Proveedores
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelDet.Visible = false;
                    panelArt.Visible = true;
                    tArtIni.Text = "1";
                    lArtIni.Text = "";
                    tArtFin.Text = "1";
                    lArtFin.Text="";
                    panelProv.Visible = true;
                    tProvIni.Text = "1";
                    lProvIni.Text = "";
                    tProvFin.Text = "1";
                    lProvFin.Text = "";
                    tProvIni.Focus();
                    break;
                case 6:     //Listado de Rendimiento para Dialpesca por vendedores
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelVended.Visible = false; 
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO","VENDEDORES")==1)
                    {
                        tVendedIni.Text = GloblaVar.Cod_Buscado ;
                        lVendedIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO", "VENDEDORES") == 1)
                    {
                        tVendedFin.Text = GloblaVar.Cod_Buscado;
                        lVendedFin.Text = GloblaVar.Nom_Buscado;
                    }                   
                    break;               
                case 8: //Listado de Stock por Artículos (Basado en partidas)
                    panelFec.Visible = true;
                    panelArt.Visible = true;
                    tArtIni.Text = "1";
                    lArtIni.Text = "";
                    tArtFin.Text = "1";
                    lArtFin.Text="";
                    break;
                case 9: //Listado de Diferencias de Stock
                    panelFec.Visible = true;
                    break;
                case 11:    //Listado de Ventas por Detallista
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";                   
                    break;
                case 12:    //Listado de Comprar por Proveedor
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    break;
                case 13:    //Listado de Ventas por Proveedor y Artículo. ENDUMAR
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelArt.Visible = true;
                    tArtIni.Text = "1";
                    lArtIni.Text = "";
                    tArtFin.Text = "1";
                    lArtFin.Text = "";
                    panelProv.Visible = true;
                    tProvIni.Text = "1";
                    lProvIni.Text = "";
                    tProvFin.Text = "1";
                    lProvFin.Text = "";
                    break;
                case 14:    //Estadisticas de Compras por Artículo. ENDUMAR
                    Base = "OREMAPEREMdb";
                    panelFec.Visible = true;
                    dateTimePicker_Inicio.Text = "";
                    dateTimePicker_Fin.Text = "";
                    panelArt.Visible = true;
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO", "ARTICULOS") == 1)
                    {
                        tArtIni.Text = GloblaVar.Cod_Buscado;
                        lArtIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO", "ARTICULOS") == 1)
                    {
                        tArtFin.Text = GloblaVar.Cod_Buscado;
                        lArtFin.Text = GloblaVar.Nom_Buscado;
                    }
                    panelProv.Visible = true;
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO", "PROVEEDORES") == 1)
                    {
                        tProvIni.Text = GloblaVar.Cod_Buscado;
                        lProvIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO", "PROVEEDORES") == 1)
                    {
                        tProvFin.Text = GloblaVar.Cod_Buscado;
                        lProvFin.Text = GloblaVar.Nom_Buscado;
                    }
                    break;
                case 15:     //Listado de RENTABILIDAD DE VENDEDORES
                    panelFec.Visible = true; dateTimePicker_Inicio.Text = ""; dateTimePicker_Fin.Text = "";
                    panelVended.Visible = false;
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO", "VENDEDORES") == 1)
                    {
                        tVendedIni.Text = GloblaVar.Cod_Buscado;
                        lVendedIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO", "VENDEDORES") == 1)
                    {
                        tVendedFin.Text = GloblaVar.Cod_Buscado;
                        lVendedFin.Text = GloblaVar.Nom_Buscado;
                    }
                    panelArt.Visible = true;
                    if (GloblaVar.gUTIL.ElementoTabla("PRIMERO", "ARTICULOS") == 1)
                    {
                        tArtIni.Text = GloblaVar.Cod_Buscado;
                        lArtIni.Text = GloblaVar.Nom_Buscado;
                    }
                    if (GloblaVar.gUTIL.ElementoTabla("ULTIMO", "ARTICULOS") == 1)
                    {
                        tArtFin.Text = GloblaVar.Cod_Buscado;
                        lArtFin.Text = GloblaVar.Nom_Buscado;
                    }
                    break;
            }
           // tDetIni.Focus();
        }  //private void frmSeleccionDatos_Load(object sender, EventArgs e)

        private void btnF5_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + "Listado Tipo " + GloblaVar.TIPO_REPORT);
            // Planteamos el query según el TIPO_REPORT que hayamos elegido y llamamos para mostrarlo a frmCR
            switch (GloblaVar.TIPO_REPORT)
            {
                case 1: //Listado de Rendimiento para Carabal
                    GloblaVar.gUTIL.SP2(dateTimePicker_Inicio.Value.Date.ToShortDateString() , dateTimePicker_Fin.Value.ToShortDateString(), int.Parse(tVendedIni.Text),int.Parse(tVendedFin.Text) ) ;
                    GloblaVar.gUTIL.ATraza("btnF5_Click().- Preparada lista con datos para listar ");
                    GloblaVar.sQReport = "{Comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    //MessageBox.Show("HOLA");

                    break;
                case 2: //Listado de Ventas de Articulos, Fecha y Detallistas
                    GloblaVar.sQReport = "{Comando.VelFec} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.DetCod} IN " + tDetIni.Text + " TO " + tDetFin.Text;
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    break;
                case 3:     //LISTADO DE FACTURAS DE CLIENTES

                    GloblaVar.sQReport = "{Comando.FechaEmision} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.DetCod} IN " + tDetIni.Text + " TO " + tDetFin.Text;
                    if (OptFacturasCobradas.Checked ) { GloblaVar.sQReport += " AND {Comando.ImptePendiente}=0"; }
                    if (OptFactPendientes.Checked ) { GloblaVar.sQReport += " AND {Comando.ImptePendiente}>0"; }
                    break;
                case 4:
                    MessageBox.Show("Nada que Listar");
                    break;
                case 5: //Listado de Compras: Fecha, Artículos Proveedores
                    GloblaVar.sQReport = "{Comando.ComCfa} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ProCod} IN " + tProvIni.Text + " TO " + tProvFin.Text;
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    break;
                case 6:  //Listado de Rendimiento para Dialpesca por vendedores
                    GloblaVar.gUTIL.SP2(dateTimePicker_Inicio.Value.Date.ToShortDateString(), dateTimePicker_Fin.Value.ToShortDateString(), int.Parse(tVendedIni.Text),int.Parse(tVendedFin.Text) ) ;
                    GloblaVar.gUTIL.ATraza("btnF5_Click().- Preparada lista con datos para listar ");
                    //GloblaVar.sQReport = "{Comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    break;
                case 8:  //Listado de Stock por Artículos Basado en Partidas
                    GloblaVar.sQReport = "{Comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    if (GloblaVar.gCERCLE_105 == true) { }
                    else
                    {
                        GloblaVar.sQReport += " AND ";
                        GloblaVar.sQReport += " {comando.Stock}>0";
                    }
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " ISNULL({comando.FCua})";
                    break;
                case 9: //Listado de Diferencias de Stock
                    //GloblaVar.gUTIL.SP2( dateTimePicker_Inicio.Value.Date.ToShortDateString(), dateTimePicker_Fin.Value.ToShortDateString(), 0, 0 ) ;
                    GloblaVar.gUTIL.ATraza("btnF5_Click().- Preparada lista con datos para listar Diferencias de Stock ");
                    break;
                case 11: //Listado de Ventas por Detallistas
                    GloblaVar.sQReport = "{Comando.VelFec} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";                  
                    break;
                case 12: //Listado de Compras por Proveedor
                    GloblaVar.sQReport = "{Comando.comcfa} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";
                    break;
                case 13:
                    GloblaVar.sQReport = "{Comando.VelFec} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )";
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",00,00,00)";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ProCod} IN " + tProvIni.Text + " TO " + tProvFin.Text;
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    break;
                case 14:        //Estadisticas de Compras por Proveedor_Artículo para ENDUMAR
                    GloblaVar.sQReport = "{Comando.ComCfa} in DateTime (" + dateTimePicker_Inicio.Value.Year + "," + dateTimePicker_Inicio.Value.Month + "," + dateTimePicker_Inicio.Value.Day + ",00,00,00 )" ;
                    GloblaVar.sQReport += " to DateTime  (" + dateTimePicker_Fin.Value.Year + "," + dateTimePicker_Fin.Value.Month + "," + dateTimePicker_Fin.Value.Day + ",23,59,59)" ;
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ProCod} IN " + tProvIni.Text + " TO " + tProvFin.Text;
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " {comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    break;
                case 15: //Listado de Rendimiento para Valpeix
                    GloblaVar.gUTIL.SP2(dateTimePicker_Inicio.Value.Date.ToShortDateString(), dateTimePicker_Fin.Value.ToShortDateString(), int.Parse(tVendedIni.Text), int.Parse(tVendedFin.Text));
                    GloblaVar.gUTIL.ATraza("btnF5_Click().- Preparada lista con datos para listar  ");
                    GloblaVar.sQReport = "{Comando.ArtCod} IN " + tArtIni.Text + " TO " + tArtFin.Text;
                    //MessageBox.Show("HOLA");
                    break;

            }

            frmCR1 frmREPORT = new frmCR1();

            switch (GloblaVar.TIPO_REPORT )
            { 
                case 4:
                    break;
                case 6:
                    //Llamada a Rutina o Código para generar fichero Excel con el Listado                                      
                    try
                    {
                        string query = @"SELECT ArtCod as C_Art, ArtDes as Artículo, Vendedor, ProCod as C_Prov, ProNom as Proveedor, DetCod as Cod_Cli, DetNom as Detallista, 
                                        convert(varchar, FVenta, 103) as F_Venta, KgsVenta as Kgs_Venta, PreVenta as Pr_Venta, PreCompra as Pr_Compra, Partida, PartAnyo as Año_Pda, 
                                        ImpteVenta as Impte_Venta, ImpteCompra as Impte_Compra, Beneficio, Margen as [Margen (%)]
                                        FROM RENDIMIENTO02 
                                        ORDER BY FVenta ASC, ArtCod ASC";

                        DataTable dtRendimiento = new DataTable();

                        using (SqlCommand cmd = new SqlCommand(query, GloblaVar.gConRem))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtRendimiento);
                        }

                        ExportarExcel(dtRendimiento);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Al exportar a excel se ha producido el siguiente error: \n\n" + ex.Message);
                    }

                    MessageBox.Show("La exportación a excel se ha realizado correctamente");        

                    break;
                case 9: //Llamada a Rutina o Código para generar fichero Excel con el Listado de Diferencias de Stock

                    string mensaje = "";

                    string sql = "SELECT p.Partida, p.Anyo, p.AlmMay, p.ArtCod as CodArt, p.ProCod as CodProv, p.StockInicial, p.Stock, p.FCua As Fecha_Cuadre, a.ComLpr as PCompra,(p.Stock * a.ComLpr) * -1 As [Beneficio/Perdida] ";
                    sql += "FROM PARTIDAS p INNER JOIN [COMALB_LINEAS] a ON p.Partida=a.Partida and p.Anyo=a.anyo and p.AlmMay=a.AlmMay ";
                    sql += "WHERE ";
                    sql += "p.Stock<>0 ";
                    sql += "AND p.FCua is not NULL AND (p.FCua>='" + dateTimePicker_Inicio.Text + "' AND p.FCua<='" + dateTimePicker_Fin.Text + "') ";
                    //sql += " ORDER BY VENALB_CABE.AUX1 asc";

                    //string path = "C:\\CERCLE\\Excell";
                    string path = obtenerPath();

                    MessageBox.Show("Se va a generar listado excell en " + path);

                    if (!string.IsNullOrEmpty(path))
                    {
                        clase_excel excel = new clase_excel();

                        excel.CnO = GloblaVar.gConRem;
                        excel.Query = sql;
                        excel.Path = path;
                        excel.NombreFichero = "Diferencias_STOCK";

                        mensaje = excel.exportarExcel(dateTimePicker_Inicio.Value);

                        if (mensaje != "")
                        {
                            MessageBox.Show(mensaje);
                        }
                        else
                        {
                            MessageBox.Show("La exportación a excel se ha realizado correctamente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ubicación de los ficheros es obligatoria. Debe rellenar el campo 'ConPathExcell' de la tabla 'CONTROL");
                    }

                    break;

                case 11:

                    frmREPORT.fechaDesde = dateTimePicker_Inicio.Text;
                    frmREPORT.fechaHasta = dateTimePicker_Fin.Text;
                    frmREPORT.Show();
                    break;

                case 12:

                    frmREPORT.fechaDesde = dateTimePicker_Inicio.Text;
                    frmREPORT.fechaHasta = dateTimePicker_Fin.Text;
                    frmREPORT.Show();
                    break;

                case 15:

                    frmREPORT.fechaDesde = dateTimePicker_Inicio.Text;
                    frmREPORT.fechaHasta = dateTimePicker_Fin.Text;
                    frmREPORT.artCodDesde = tArtIni.Text;
                    frmREPORT.artCodHasta = tArtFin.Text;
                    frmREPORT.Show();
                    break;

                default : 

                    frmREPORT.Show();
                    break;

            }  //switch (GloblaVar.TIPO_REPORT )

            //if (GloblaVar.TIPO_REPORT==4)
            //{
            //    //Genera_File_FP_OMP();
            //}
            //else
            //{
            //frmCR1 frmREPORT = new frmCR1();
            //frmREPORT.Show();
            //}

        } // private void btnF5_Click(object sender, EventArgs e)

        private string obtenerPath()
        {
            string path = "";

            using (SqlCommand cmd = new SqlCommand("SELECT ConPathExcell FROM CONTROL", GloblaVar.gConRem))
            {
                path = Convert.ToString(cmd.ExecuteScalar());
            }

            return path;
        }

        private void ExportarExcel (DataTable dt)
        {           
            string path = "C:\\CERCLE\\RENDIMIENTO\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DateTime fecha = DateTime.Now;
            string nombreFichero = "Rentabilidad_Vendedores_" + fecha.Year.ToString() + fecha.Month.ToString().PadLeft(2, '0') + fecha.Day.ToString().PadLeft(2, '0') + "_" + fecha.Hour.ToString().PadLeft(2, '0') + fecha.Minute.ToString().PadLeft(2, '0') + fecha.Second.ToString().PadLeft(2, '0') + ".xlsx";


            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);          
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.ActiveSheet;
            excelWorksheet.Name = "Rentabilidad_Vendedores";

            //Cabecera
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                excelWorksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            }

            //Filas 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    switch (dt.Columns[j].DataType.Name)
                    {
                        case "String":
                            excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString().Trim();
                            break;
                        case "DateTime":
                            excelWorksheet.Cells[i + 2, j + 1] = Convert.ToDateTime(dt.Rows[i][j].ToString()).ToShortDateString();
                            break;
                        case "Int32":
                            excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                            break;
                        case "Decimal":
                            excelWorksheet.Cells[i + 2, j + 1] = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                            //excelWorksheet.Cells.NumberFormat = "####.00";
                            break;
                        case "Single":
                            excelWorksheet.Cells[i + 2, j + 1] = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                            //excelWorksheet.Cells[i + 2, j + 1].NumberFormat = "####.00";
                            break;
                        default:
                            excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                            break;
                    }//switch (dt.Columns[j].DataType.Name)
                }
            }
                       
            excelWorkbook.SaveAs(path + nombreFichero);
           
            excelWorkbook.Close();
            excelApp.Quit();

        }

        private void button_Exportar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + "Click en exportar ");
            
            switch (GloblaVar.TIPO_REPORT)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    GloblaVar.sQReport = "SELECT     VENALB_CABE.VenAlb, VENALB_CABE.VenFec, VENALB_CABE.DetCod, VENALB_CABE.VenTve, VENALB_CABE.VenBru, VENALB_CABE.VenIva, ";
                    GloblaVar.sQReport += " VENALB_CABE.VenRec, VENALB_CABE.VenTot, VENALB_CABE.FechaDiskette, VENALB_CABE.Anulado, VENALB_CABE.IdCobro, ";
                    GloblaVar.sQReport += "VENALB_CABE.FechaCobro, DETALLISTAS.DetNom, DETALLISTAS.DetMay,VENALB_CABE.ValidacionTarjeta ";
                    GloblaVar.sQReport += " FROM         VENALB_CABE INNER JOIN";
                    GloblaVar.sQReport += " DETALLISTAS ON VENALB_CABE.DetCod = DETALLISTAS.DetCod";
                    GloblaVar.sQReport += " WHERE ";
                    GloblaVar.sQReport += " (VENALB_CABE.VenFec BETWEEN '" + dateTimePicker_Inicio.Value.Date.ToShortDateString() + "' AND '" + dateTimePicker_Fin.Value.ToShortDateString() + "') ";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " VENALB_CABE.Anulado<>1 ";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " VENALB_CABE.VenTve=4 ";
                    GloblaVar.sQReport += " AND ";
                    GloblaVar.sQReport += " DETALLISTAS.DetCod IN ";
                    GloblaVar.sQReport += "(SELECT DetCod FROM DETALLISTAS WHERE DetMay<>'' AND (DetCod BETWEEN " + tDetIni.Text + " AND " + tDetFin.Text + "))";
                    if (ListDetExc.Items.Count > 0)
                    {
                        GloblaVar.sQReport += " AND DETALLISTAS.DetCod NOT IN ( ";
                        foreach (object item in ListDetExc.Items)
                        {
                            //L1.Items.Add(Funciones.DameNomDet(item.ToString()));
                            GloblaVar.sQReport += item.ToString() + ",";
                        }
                        GloblaVar.sQReport = GloblaVar.sQReport.Substring(0, GloblaVar.sQReport.Length - 1);
                        GloblaVar.sQReport += ")";
                    }
                    if (ListDetInc.Items.Count > 0)
                    {
                        GloblaVar.sQReport += " AND DETALLISTAS.DetCod  IN ( ";
                        foreach (object item in ListDetInc.Items)
                        {
                            //L1.Items.Add(Funciones.DameNomDet(item.ToString()));
                            GloblaVar.sQReport += item.ToString() + ",";
                        }
                        GloblaVar.sQReport = GloblaVar.sQReport.Substring(0, GloblaVar.sQReport.Length - 1);
                        GloblaVar.sQReport += ")";
                    }
                    GloblaVar.TeMp="INFORME ENVIO OREMAPE 1";
                    frmEmpr04 frm2=new frmEmpr04();
                    frm2.Show();
                    this.Close();

                    break;
                default:
                    break;
            }
        } //private void tArtFin_KeyPress(object sender, KeyPressEventArgs e)


        private void llDetIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "DETALLISTAS";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tDetIni.Text = GloblaVar.Cod_Buscado;
                lDetIni.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)
        }

        private void llDetFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "DETALLISTAS";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tDetFin.Text = GloblaVar.Cod_Buscado;
                lDetFin.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)

        }

        private void llVendedIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "VENDEDORES";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tVendedIni.Text = GloblaVar.Cod_Buscado;
                lVendedIni.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)

        }

        private void llVendedFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "VENDEDORES";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tVendedFin.Text = GloblaVar.Cod_Buscado;
                lVendedFin.Text = GloblaVar.Nom_Buscado;
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
        } // private void tDetIni_KeyPress(object sender, KeyPressEventArgs e)

 

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
        }// private void tDetFin_KeyPress(object sender, KeyPressEventArgs e)

        private void tVendedIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lVendedIni.Text  = Funciones.DameNomVen(tVendedIni.Text );
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

        } //private void tVendedIni_KeyPress(object sender, KeyPressEventArgs e)

        private void tVendedFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lVendedFin.Text = Funciones.DameNomVen(tVendedFin.Text );
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

        private void llArtIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "ARTICULOS";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tArtIni.Text = GloblaVar.Cod_Buscado;
                lArtIni.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)
            

        }

        private void llArtFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "ARTICULOS";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tArtFin.Text = GloblaVar.Cod_Buscado;
                lArtFin.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)

        }



        private void tArtIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lArtIni.Text = Funciones.DameNomArt(tArtIni.Text);
                    tArtFin.Focus();
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

        } //private void tArtIni_KeyPress(object sender, KeyPressEventArgs e)

        private void tArtFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lArtFin.Text = Funciones.DameNomArt(tArtFin.Text);
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

        private void llProvIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "PROVEEDORES";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tProvIni.Text = GloblaVar.Cod_Buscado;
                lProvIni.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)
        }   // private void llProvIni_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void llProvFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            GloblaVar.TIPO_CONSULTA = "PROVEEDORES";
            frmCONSULTA frmC = new frmCONSULTA();
            //frmC.Show();
            if (frmC.ShowDialog() == DialogResult.OK)
            {
                tProvFin.Text = GloblaVar.Cod_Buscado;
                lProvFin.Text = GloblaVar.Nom_Buscado;

            }   //if (frmC.ShowDialog == DialogResult.OK)
        }   //private void llProvFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)


        private void tProvIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lProvIni.Text = Funciones.DameNomPro(tProvIni.Text);
                    tProvFin.Focus();
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
        } // private void tProvIni_KeyPress(object sender, KeyPressEventArgs e)



        private void tProvFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    lProvFin.Text = Funciones.DameNomPro(tProvFin.Text);
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
        }// private void tProvFin_KeyPress(object sender, KeyPressEventArgs e)
        private void tDetExc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    //lVendedFin.Text = Funciones.DameNomVen(tVendedFin.Text);
                    ListDetExc.Items.Add(tDetExc.Text);
                    L1.Items.Add(Funciones.DameNomDet(tDetExc.Text));
                    tDetExc.Text = "";
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

        private void tDetInc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    //lVendedFin.Text = Funciones.DameNomVen(tVendedFin.Text);
                    ListDetInc.Items.Add(tDetInc.Text);
                    L2.Items.Add(Funciones.DameNomDet(tDetInc.Text));
                    tDetInc.Text = "";
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
        }   //private void tDetInc_KeyPress(object sender, KeyPressEventArgs e)

        private void ListDetExc_MouseClick(object sender, MouseEventArgs e)
        {
            int a = ListDetExc.SelectedIndex;
            ListDetExc.Items.Remove(ListDetExc.SelectedItem );
            Carga_L1();
        }

        private void Carga_L1()
        {
        L1.Clear();
            foreach(object item in ListDetExc.Items)
            {
                L1.Items.Add(Funciones.DameNomDet(item.ToString() ));
            }
        }

        private void dateTimePicker_Inicio_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_Fin.Value = dateTimePicker_Inicio.Value;
        }

        private void tArtIni_TextChanged(object sender, EventArgs e)
        {

        }








    }  //public partial class frmSeleccionDatos : Form
    
}  //namespace cercle17
