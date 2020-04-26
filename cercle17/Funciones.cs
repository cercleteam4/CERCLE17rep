using System;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Diagnostics;

namespace cercle17
{
    public class Funciones
    {
        // ABEl

        public static string Ultimo_Artículo(string Base)
        {
            Int32  UA =1;
            string select_UA = "SELECT MAX(ArtCod) FROM ARTICULOS";
            SqlCommand cmd = new SqlCommand()  ;
            cmd.CommandText = select_UA;
            SqlDataReader myReader = null;
            
            try
            {
                
                switch(Base)
                {
                    case "ENDUMAR":
                        
                        cmd.Connection = GloblaVar.gConEndu;
                        //cmd = new SqlCommand(select_UA, GloblaVar.gConEndu);
                        break;
                    case "OREMAPE":
                        cmd.Connection = GloblaVar.gConRem;
                        break;

                }
                myReader =cmd.ExecuteReader();
                myReader.Read();
                UA = myReader.GetInt32(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                UA = 1;
            }
            return UA.ToString() ;
        } //public static string Ultimo_Artículo(string Base)

        public static string Fecha_aaaammdd(DateTime Dia)
        {
            string CadFecha;
            try
            {
                CadFecha = Dia.Year.ToString();
                CadFecha += Dia.Month.ToString(); 
                CadFecha += Dia.Day.ToString() ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                CadFecha = "";
            }

            return CadFecha ;
        } //public static string Fecha1(DateTime Dia)

        //Jorge lo de abajo
        public static string DameSubctaDet(string DetCod, SqlConnection cn)
        {
            string SubCta="";

            string select_subcuenta = "select SubCta FROM DETALLISTAS WHERE DetCod=" + DetCod;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(select_subcuenta, cn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    SubCta  = myReader["SubCta"].ToString();
                }
                myReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                SubCta = "";
            }
            return SubCta;
        } //DameSubCtaDet

        public static string DameNomArt(string Codigo)
        {
            //Nos dará el Nombre de un ARTICULO localizado a través de su código

            string gIdent = "Funciones_DameNomArt ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Buscando Nombre del ARTICULO " + Codigo);
            string ArtBuscado = "";
            try
            {
                SqlDataReader myR = null;
                SqlCommand myC = new SqlCommand("SELECT ArtDes FROM ARTICULOS WHERE ArtCod=" + Codigo, GloblaVar.gConRem);
                myR = myC.ExecuteReader();
                if (myR.Read())
                {
                    ArtBuscado = myR["ArtDes"].ToString();
                    myR.Close();
                    return ArtBuscado;
                }
                else
                {
                    myR.Close();
                    return "NO EXISTE";
                }
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + " CÓDIGO ERRÓNEO " + ex.ToString());
                return "CÓDIGO ERRÓNEO";
            }

        }  //public static string DameNomArt(string Codigo)

        public static string DameNomDet(string Codigo)
        {
            //Nos dará el Nombre de un Detallista localizado a través de su código

            string gIdent = "Funciones_DameNomDet ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Buscando Nombre del Detallista " + Codigo);
            string DetBuscado = "";
            try
            { 
                SqlDataReader myR = null;
                SqlCommand myC = new SqlCommand("SELECT * FROM DETALLISTAS WHERE DetCod=" + Codigo, GloblaVar.gConRem);
                myR = myC.ExecuteReader();
                if (myR.Read()) 
                {
                    DetBuscado = myR["DetNom"].ToString().Trim();
                    GloblaVar.gDETBUSCADO = null;
                    GloblaVar.gDETBUSCADO=new clase_detallista();
                    GloblaVar.gDETBUSCADO.DetCod = Codigo;
                    GloblaVar.gDETBUSCADO.DetNom=DetBuscado;
                    if (myR["DetNif"]!= DBNull.Value) { GloblaVar.gDETBUSCADO.DetNif=myR["DetNif"].ToString().Trim();}
                    if (myR["DetMun"]!=DBNull.Value) {GloblaVar.gDETBUSCADO.detmun=myR["DetMun"].ToString().Trim();}
                    if (myR["Detvia"]!=DBNull.Value) {GloblaVar.gDETBUSCADO.detvia=myR["Detvia"].ToString().Trim();}
                    if (myR["DetRec"]!=DBNull.Value) {GloblaVar.gDETBUSCADO.DetRec =myR["DetRec"].ToString().Trim();}
                    if (myR["DetCop"] != DBNull.Value) { GloblaVar.gDETBUSCADO.DetCop = myR["DetCop"].ToString().Trim(); }

                    myR.Close();
                    return DetBuscado ; 
                }
                else 
                {
                    myR.Close();
                    return "NO EXISTE";
                }
            }
            catch (Exception ex)
            { 
                GloblaVar.gUTIL.ATraza(gIdent + " CÓDIGO ERRÓNEO "+ex.ToString());
                return "CÓDIGO ERRÓNEO"; 
            }

        }  //public static string DameNomDet(string Codigo)

        public static string DameNomPro(string Codigo)
        {
            //Nos dará el Nombre de un Detallista localizado a través de su código

            string gIdent = "Funciones_DameNomPro ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Buscando Nombre del Proveedor " + Codigo);
            string ProBuscado = "";
            try
            {
                SqlDataReader myR = null;
                SqlCommand myC = new SqlCommand("SELECT ProNom FROM PROVEEDORES WHERE ProCod=" + Codigo, GloblaVar.gConRem);
                myR = myC.ExecuteReader();
                if (myR.Read())
                {
                    ProBuscado = myR["ProNom"].ToString();
                    myR.Close();
                    return ProBuscado;
                }
                else
                {
                    myR.Close();
                    return "NO EXISTE";
                }
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + " CÓDIGO ERRÓNEO " + ex.ToString());
                return "CÓDIGO ERRÓNEO";
            }

        }  //public static string DameNomDet(string Codigo)

        public static string DameNomVen(string Codigo)
        {
            string gIdent = "Funciones_DameNomVen ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Buscando Nombre del Vendedor " + Codigo);
            string VenBuscado = "";
            try
            {
                SqlDataReader myR = null;
                SqlCommand myC = new SqlCommand("SELECT Vendedor FROM VENDEDORES WHERE IdVendedor=" + Codigo, GloblaVar.gConRem);
                myR = myC.ExecuteReader();
                if (myR.Read())
                {
                    VenBuscado = myR["Vendedor"].ToString();
                    myR.Close();
                    return VenBuscado;
                }
                else
                {
                    myR.Close();
                    return "NO EXISTE";
                }
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + " CÓDIGO ERRÓNEO " + ex.ToString());
                return "CÓDIGO ERRÓNEO";
            }
        } //public static string DameNomVen(string Codigo)

        public static int EjecutaNonQuery(string NonQuery, SqlConnection CnO)
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
                GloblaVar.gUTIL.ATraza("Funciones.EjecutaNonQuery  " + NonQuery);
                GloblaVar.gUTIL.ATraza("Funciones.EjecutaNonQuery " +ex.ToString());
            }

            return res;
        }

        public static object EjecutaScalar( string sql, SqlConnection CnO)
        {
            object valor = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, CnO))
                {
                    valor = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza("Funciones.EjecutaScalar  " + sql);
                GloblaVar.gUTIL.ATraza("Funciones.EjecutaScalar " + ex.ToString());
            }           

            return valor;

        }

        public static void Escribe_LOG(string mensaje, string clave, SqlConnection CnO)
        {
            try
            {
                string insert_log = "INSERT INTO LOGS(Mensaje, Ventas) VALUES('" + mensaje.Replace("'", "''") + "', '" + clave + "')";
                EjecutaNonQuery(insert_log, CnO);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static clase_money Leer_Money(string VenAlb, string Anyo, SqlConnection CnO)
        {
            clase_money resultado = new clase_money();

            string select = "SELECT VenBru, VenIva, VenRec, VenTot FROM VENALB_CABE WHERE VenAlb=" + VenAlb + " AND Anyo=" + Anyo;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(select, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    resultado.VenBru = myReader["VenBru"].ToString();
                    resultado.VenIva = myReader["VenIva"].ToString();
                    resultado.VenRec = myReader["VenRec"].ToString();
                    resultado.VenTot = myReader["VenTot"].ToString();
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        public static void Marcar_Ventas(string IdFactura, string Anyo, string Serie, ArrayList Lista_Albaranes, SqlConnection CnO)
        {
            if (Lista_Albaranes != null)
            {
                for (int y = 0; y < Lista_Albaranes.Count; y++)
                {
                    dato_albaran albaran = (dato_albaran)Lista_Albaranes[y];

                    string update = "UPDATE VENALB_CABE SET  VenNfp=" + IdFactura + ", AnyoFra=" + Anyo + ", SerieFra='" + Serie + "'  WHERE VenAlb=" + albaran.VenAlb + " AND Anyo=" + albaran.Anyo;

                    int res = EjecutaNonQuery(update, CnO);
                    switch(frmPpal.USUARIO )
                    {
                        case "2":
                            
                            break;
                    }
                }
            }
        }

        public static void Marcar_Ventas_Cobros(string IdFactura, string Anyo, string Serie, dato_albaran Albaran, string IdCobro, string FechaCobro,  SqlConnection CnO)
        {
            if (Albaran != null)
            {
                string updateVenalbCabe = @"UPDATE VENALB_CABE SET  VenNfp=" + IdFactura + ", AnyoFra=" + Anyo + ", SerieFra='" + Serie + "', IdCobro=" + IdCobro + ", FechaCobro='" + FechaCobro + "' WHERE VenAlb=" + Albaran.VenAlb + " AND Anyo=" + Albaran.Anyo;

                int resVenalbCabe = EjecutaNonQuery(updateVenalbCabe, CnO);

                string updateFactvCabe = @"UPDATE FACTV_CABE SET FechaCobro='" + FechaCobro +"', ImptePendiente=0 WHERE Factura=" + IdFactura + " AND Anyo=" + Anyo + " AND Serie='" + Serie + "'";
                
                int resFactvCabe = EjecutaNonQuery(updateFactvCabe, CnO);
                   
            }
        }
        
        public static ArrayList Lineas_Albaran(string VelAlb, string Anyo, SqlConnection CnO)
        {
            ArrayList resultado = new ArrayList();

            string strQ = "select * FROM VENALB_LINEAS WHERE VelAlb=" + VelAlb + " AND Anyo=" + Anyo + " ORDER BY VelLin";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    detalle_linea_albaran linea = new detalle_linea_albaran();

                    linea.ArtCod = myReader["ArtCod"].ToString();
                    linea.DetCod = myReader["DetCod"].ToString();
                    linea.ProCod = myReader["ProCod"].ToString();
                    linea.VelBul = myReader["VelBul"].ToString();
                    linea.VelFec = myReader["VelFec"].ToString();
                    linea.VelImp = myReader["VelImp"].ToString();
                    linea.VelKil = myReader["VelKil"].ToString();
                    linea.VelLin = myReader["VelLin"].ToString();
                    linea.VelPre = myReader["VelPre"].ToString();
                    linea.VelTrz = myReader["VelTrz"].ToString();
                    linea.Partida = myReader["Partida"].ToString();
                    linea.PartAnyo = myReader["PartAnyo"].ToString();
                    linea.PartAlm = myReader["PartAlm"].ToString();

                    resultado.Add(linea);
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        public static string Nuevo_Factura(string anyo, string serie, SqlConnection CnO)
        {
            string select = "SELECT MAX(Factura) FROM FACTV_CABE WHERE Anyo=" + anyo + " AND Serie='" + serie + "'";
            string ident = "0";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(select, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() != "")
                    {
                        ident = myReader[0].ToString();
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int aux = 0;
            if (System.Int32.TryParse(ident, out aux))
            {
                aux++;
                ident = aux.ToString();
            }

            return ident;
        }

        public static bool Albaran_Facturado(string id_albaran, string Anyo, SqlConnection CnO)
        {
            bool resultado = false;

            string strQ = "select VenNfp FROM VENALB_CABE WHERE VenAlb=" + id_albaran + " AND Anyo=" + Anyo;

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() != "")
                    {
                        resultado = true;
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        public static string Facturar(string DetCod, string Serie, bool cabecera, ArrayList Lista_Albaranes, SqlConnection CnO, string fechaFactura = "")
        {
            //crear líneas (+-CABECERA) para una factura de los albaranes recibidos en el array
            string gIdent = "Funciones_Facturar .";
            string resultado = "";
            string IVA_BI = "";           //Cantidad de IVA calculada de la base Imponible
            try
            {
                
                string anyo = "";
                string fechaFac = "";
                string base_imponible = "0";
                string iva = "0";
                string recargo = "0";
                string importe_total = "0";

                if (fechaFactura == "")
                {
                    anyo = DateTime.Today.Year.ToString();
                    fechaFac = DateTime.Today.ToShortDateString();
                }
                else
                {
                    anyo = Convert.ToDateTime(fechaFactura).Year.ToString();
                    fechaFac = fechaFactura;
                }

                string IdFactura = Nuevo_Factura(anyo, Serie, CnO);

                ArrayList Lista_Lineas_Factura = new ArrayList();

                if (Lista_Albaranes != null)
                {
                    int contador = 1;
                    bool seguir = true;

                    for (int y = 0; y < Lista_Albaranes.Count; y++)
                    {
                        dato_albaran albaran = (dato_albaran)Lista_Albaranes[y];

                        //comprobar que los albaranes no están facturados
                        bool facturado = Albaran_Facturado(albaran.VenAlb, albaran.Anyo, CnO);

                        if (facturado == true) { seguir = false; }  //si hubiese uno solo facturado se impide grabar factura

                        ArrayList Lista_Lineas_Albaran = Lineas_Albaran(albaran.VenAlb, albaran.Anyo, CnO);

                        clase_money importes = Leer_Money(albaran.VenAlb, albaran.Anyo, CnO);

                        base_imponible = Suma(base_imponible, importes.VenBru);
                        iva = Suma(iva, importes.VenIva);
                        IVA_BI=Multiplica("0.10",base_imponible );
                        if (iva != IVA_BI)
                        {
                            GloblaVar.gUTIL.ATraza(gIdent + " IVA diferente ");
                        }
                        
                        recargo = Suma(recargo, importes.VenRec);
                        importe_total = Suma(importe_total, importes.VenTot);

                        if (Lista_Lineas_Albaran != null)
                        {
                            for (int x = 0; x < Lista_Lineas_Albaran.Count; x++)
                            {
                                detalle_linea_albaran linea_albaran = (detalle_linea_albaran)Lista_Lineas_Albaran[x];

                                clase_linea_factura linea_factura = new clase_linea_factura();

                                linea_factura.Albaran = albaran.VenAlb;
                                linea_factura.Anyo = anyo;
                                linea_factura.AnyoAlb = albaran.Anyo;
                                linea_factura.ArtCod = linea_albaran.ArtCod;
                                linea_factura.Cajas = linea_albaran.VelBul;
                                linea_factura.Factura = IdFactura;
                                linea_factura.Importe = linea_albaran.VelImp;
                                linea_factura.Kilos = linea_albaran.VelKil;
                                linea_factura.Linea = contador.ToString();
                                linea_factura.LineaAlbaran = linea_albaran.VelLin;
                                linea_factura.PartAnyo = linea_albaran.PartAnyo;
                                linea_factura.Partida = linea_albaran.Partida;
                                linea_factura.Precio = linea_albaran.VelPre;
                                linea_factura.Serie = Serie;
                                linea_factura.Traza = linea_albaran.VelTrz;
                                linea_factura.PartAlm = linea_albaran.PartAlm;

                                Lista_Lineas_Factura.Add(linea_factura);

                                contador++;
                            }
                        }

                    }

                    //insert

                    if (seguir == true)
                    {
                        if (cabecera == true)
                        {
                            string insert_cabecera = "INSERT INTO FACTV_CABE(Factura, Anyo, Serie, FechaEmision, DetCod, BI1, IVA1, RE1, ImpteFactura, ImpteCobrado, ImptePendiente) ";
                            insert_cabecera += " VALUES(" + IdFactura + "," + anyo + ", '" + Serie + "', '" + fechaFac + "', " + DetCod + ", " + base_imponible.Replace(",", ".") + ", " + iva.Replace(",", ".") + ", " + recargo.Replace(",", ".") + ", " + importe_total.Replace(",", ".") + ", 0, " + importe_total.Replace(",", ".") + ")";

                            int res_cabecera = EjecutaNonQuery(insert_cabecera, CnO);

                            if (res_cabecera != 1)
                            {
                                seguir = false;
                            }
                            else
                            {
                                
                                Marcar_Ventas(IdFactura, anyo, Serie, Lista_Albaranes, CnO);
                                GloblaVar.gUTIL.SP3(IdFactura, anyo, Serie);
                            }
                        }

                        if (seguir == true)
                        {
                            for (int x = 0; x < Lista_Lineas_Factura.Count; x++)
                            {
                                clase_linea_factura linea = (clase_linea_factura)Lista_Lineas_Factura[x];

                                string insert_linea = "INSERT FACTV_LINEAS(Factura, Anyo, Serie, LinF, VelAlb, AnyoAlb, VelLin, ArtCod, VelBul, VelKil, VelPre, VelTrz, VelImp, Partida, PartAnyo, PartAlm) ";
                                insert_linea += " VALUES (" + IdFactura + ", " + anyo + ", '" + Serie + "', " + linea.Linea + ", " + linea.Albaran + ", " + linea.AnyoAlb + ", " + linea.LineaAlbaran + ", " + linea.ArtCod + ", " + linea.Cajas.Replace(",", ".") + ", " + linea.Kilos.Replace(",", ".") + ", " + linea.Precio.Replace(",", ".") + ", '" + linea.Traza + "', " + linea.Importe.Replace(",", ".") + ", " + linea.Partida + ", " + linea.PartAnyo + ", '" + linea.PartAlm + "')";

                                int res_linea = EjecutaNonQuery(insert_linea, CnO);

                            }

                           
                            resultado = IdFactura;
                        }
                    }
                    else
                    {
                        //no podemos seguir porque duplicaríamos factura
                        //de momento no se genera aviso
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;
        }

        public static string FacturarAbono (string DetCod, string anyo, string serie, DateTime fecha, ArrayList Lista_Lineas_Abono, string observaciones, string base_imponible, string importe_iva, string importe_recargo, string importe_total, decimal tipo_iva, SqlConnection CnO)
        {
            string resultado = "";            
          
            try
            {

                //Creamos el albarán
                string venAlb = Nuevo_Albaran(anyo, CnO);

                string insertVenalbCabe = @"INSERT INTO VENALB_CABE (VenAlb, Anyo, VenFec, DetCod, IdVendedor,Tablet,VenTve, VenBru, VenIva, VenRec, VenTot, FechaDiskette, Anulado, PerCentIVA, PerCentRec, AppExt)
                                        VALUES (" + venAlb + ", " + anyo + ", '" + fecha.ToShortDateString() + "', " + DetCod + ", " + GloblaVar.gIdVendedor +"," +GloblaVar.gNUMERO_TABLET + ", 4, " + base_imponible.Replace(",", ".") + ", " + importe_iva.Replace(",", ".") + ", " + importe_recargo.Replace(",", ".") + ", " + importe_total.Replace(",", ".") + ", '" + fecha.ToShortDateString() + "', 0, " + tipo_iva + ", 0, 0)";

                int resVenalbCabe = EjecutaNonQuery(insertVenalbCabe, CnO);

                if (resVenalbCabe == 1)
                {
                    for (int x = 0; x < Lista_Lineas_Abono.Count; x++)
                    {
                        clase_linea_factura linea_abono = (clase_linea_factura)Lista_Lineas_Abono[x];

                        string insertVenalbLinea = @"INSERT INTO VENALB_LINEAS (VelAlb, VelFec, DetCod, ArtCod, ProCod, VelBul, VelKil, VelPre, VelLin, VelImp, Anyo,Partida,PartAnyo,PartAlm, AppExt) 
                                                 VALUES 
                                                (" + venAlb + ", '" 
                                                   + fecha.ToShortDateString() 
                                                   + "', " + DetCod + ", " 
                                                   + linea_abono.ArtCod
                                                   + ", 1, 0, " 
                                                   + linea_abono.Kilos.Replace(",", ".") + ", -" 
                                                   + linea_abono.Precio.Replace(",", ".") + ", "
                                                   + linea_abono.Linea + ", -" 
                                                   + linea_abono.Importe.Replace(",", ".") + ", "
                                                   + anyo + ","
                                                   + "-1" + ","     //Partida
                                                   + fecha.Year + ","
                                                   + "'01'" + ","
                                                   + " 0)";

                        int resVenalbLinea = EjecutaNonQuery(insertVenalbLinea, CnO);
                        if (resVenalbLinea == 0)
                        {
                            GloblaVar.gUTIL.ATraza(  "Error al ejecutar "+insertVenalbLinea );
                            MessageBox.Show("Error al crear las líneas del albarán");
                            return "";
                        }
                    }

                   
                }
                else
                {
                    MessageBox.Show("Error al crear la cabecera del albarán");
                    return "";
                }                

                ArrayList Lista_Lineas_Albaran = Lineas_Albaran(venAlb, anyo, CnO);

                //Creamos la factura
                string idFactura = Nuevo_Factura(anyo, serie, CnO);

                string insertFactvCabe = @"INSERT INTO FACTV_CABE(Factura, Anyo, Serie, FechaEmision, DetCod, BI1, IVA1, RE1, ImpteFactura, ImpteCobrado, ImptePendiente, Observaciones) 
                                          VALUES(" + idFactura + "," + anyo + ",'" + serie + "','" + fecha.ToShortDateString() + "'," + DetCod + "," + base_imponible.Replace(",", ".") + "," + importe_iva.Replace(",", ".") + ", " + importe_recargo.Replace(",", ".") + ", " + importe_total.Replace(",", ".") + ",0," + importe_total.Replace(",", ".") + ",'" + observaciones + "')";

                int resFactvCabe = EjecutaNonQuery(insertFactvCabe, CnO);

                if (resFactvCabe == 1)
                {                   

                    dato_albaran dato = new dato_albaran();
                    dato.VenAlb = venAlb;
                    dato.Anyo = anyo;                   
                    

                    //Cobro del albarán
                    string idCobro = Nuevo_Cobro_Albaran(CnO);

                    string insertVenalbCobros = @"INSERT INTO VENALB_COBROS(IdCobro, DetCod, Cantidad, IdVendedor, IdTipoCobro, Fecha, Efectivo, Deuda)";
                    insertVenalbCobros += " VALUES (" + idCobro + ", " + DetCod + ", " + importe_total.Replace(",", ".") + ", " + GloblaVar.gIdVendedor.ToString() + ",";
                    insertVenalbCobros += GloblaVar.gIdTipoCobro.ToString() + ", '" + fecha.ToShortDateString() + "', " + importe_total.Replace(",", ".") + ", 0.00)";

                    int resVenalbCobros = EjecutaNonQuery(insertVenalbCobros, CnO);

                    if (resVenalbCobros==1)
                    {
                        Marcar_Ventas_Cobros(idFactura, anyo, serie, dato, idCobro, fecha.ToShortDateString(), CnO);
                    }

                    
                    GloblaVar.gUTIL.SP3(idFactura, anyo, serie);

                    if (Lista_Lineas_Albaran != null)
                    {
                        for (int x = 0; x < Lista_Lineas_Albaran.Count; x++)
                        {
                            detalle_linea_albaran linea_albaran = (detalle_linea_albaran)Lista_Lineas_Albaran[x];

                            string insertFactvLinea = @"INSERT FACTV_LINEAS(Factura, Anyo, Serie, LinF, VelAlb, AnyoAlb, VelLin, ArtCod, VelBul, VelKil, VelPre, VelImp) 
                                                        VALUES(" + idFactura + ", " + anyo + ", '" + serie + "', " + linea_albaran.VelLin + ", " + venAlb + ", " + anyo + ", " + linea_albaran.VelLin + ", "  + linea_albaran.ArtCod + ", 0, " + linea_albaran.VelKil.Replace(",", ".") + ", " + linea_albaran.VelPre.Replace(",", ".") + ", " + linea_albaran.VelImp.Replace(",", ".") + ")";

                            int resFactvLinea = EjecutaNonQuery(insertFactvLinea, CnO);
                            if (resFactvLinea == 0)
                            {
                                MessageBox.Show("Error al crear las líneas de la factura");
                                return "";
                            }
                        }
                    }

                    resultado = idFactura;
                }
                else
                {
                    MessageBox.Show("Error al crear la cabecera de la factura");
                    return "";
                }    

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());              
            }

            return resultado;
        }
        
        public static string FacturarAbono1( clase_ABONG_CABE Abono,string serie,string Observaciones)
        {
            // Trasladará el albarán de Abono a una Factura de Abono. Para ello solamente necesitamos el nº de Albarán de Abono y el Año. 
            //Damos por hecho que el Albarán de Abono está cobrado (campos IdCobro y FechaCobro con los correspondientes valores
            string gIdent = "Funciones_FacturarAbono1 ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Facturando Abono " + Abono.Albaran +"/" +Abono.Anyo );
            string resultado = "";
            string sQ = "";
            // Primero obtenemos un num de factura
            string idFactura = Nuevo_Factura(Abono.Anyo.ToString(), serie, GloblaVar.gConRem);
            try
            {

                //Enr Abono tenemos el Albarán de Abono que vamos a facturar


                sQ = @"INSERT INTO FACTV_CABE(Factura, Anyo, Serie,SubSerie, FechaEmision, DetCod, BI1, IVA1, RE1, ImpteFactura, ImpteCobrado, ImptePendiente, Observaciones, RectificaFact, RectificaAnyoFact, RectificaSerieFect)"; 
                sQ+= " VALUES (";
                sQ += idFactura + ",";
                sQ+= Abono.Anyo.ToString() + ",";
                sQ += "'" + serie + "',";
                sQ += "'ASG',";     //Para identificar que es un abono sin devolución de Género a la hora de sacar la factura por crystal reports
                sQ += "'" + DateTime.Today.ToShortDateString() + "',";
                sQ += Abono.DetCod  + ",";
                sQ += (-Abono.BI1).ToString().Replace(",", ".") + ",";
                sQ +=(-Abono.IVA1).ToString().Replace(",", ".") + ", ";
                sQ +=(-Abono.RE1).ToString().Replace(",", ".") + ",";
                sQ += (-Abono.Total).ToString().Replace(",", ".") + ",";
                sQ += (-Abono.Total).ToString().Replace(",", ".") + ",";       //Como damos por hecho que la factura estaba cobrada. El Impte total es el cobrado/Abonado
                sQ += "0,";                                                 // Puesto que está cobrada el Importe pendiente es 0
                sQ += "'" + Observaciones + "',";
                sQ += Abono.RectificaFact + ",";
                sQ += Abono.RectificaAnyoFact + ",";
                sQ += "'" + Abono.RectificaSerieFact + "'";
                sQ += ")";


                int resFactvCabe = EjecutaNonQuery(sQ, GloblaVar.gConRem );

                if (resFactvCabe == 0)
                {
                    GloblaVar.gUTIL.ATraza(gIdent+" Error al ejecutar " + sQ);
                    MessageBox.Show("Error al intentar grabar la factura");
                    return "";
                }
                else
                {
                    for (int i=1;i<(Abono.NumLineas);i++ )
                    {
                        sQ = @"INSERT FACTV_LINEAS(Factura, Anyo, Serie, LinF, VelAlb, AnyoAlb, VelLin, ArtCod, VelBul, VelKil, VelPre, VelImp) ";
                        sQ += " VALUES (";
                        sQ += idFactura + ", ";
                        sQ += Abono.Anyo.ToString() + ",";
                        sQ += "'" + serie + "', ";
                        sQ += i + ", ";
                        sQ += Abono.Albaran.ToString() + ", ";
                        sQ += Abono.Anyo.ToString() + ", ";
                        sQ += i + ", ";
                        sQ += Abono.line[i].ArtCod.ToString() + ",";
                        sQ += Abono.line[i].Cajas.ToString() + ", ";
                        sQ += Abono.line[i].Kilos.ToString().Replace(",", ".") + ", ";
                        sQ += (-Abono.line[i].Precio).ToString().Replace(",", ".") + ", ";
                        sQ += (-Abono.line[i].Importe).ToString().Replace(",", ".");
                        sQ += ")";

                        int resFactvLinea = EjecutaNonQuery(sQ, GloblaVar.gConRem );
                        if (resFactvLinea == 0)
                        {
                            MessageBox.Show("Error al crear las líneas de la factura. Linea: "+i.ToString());
                            return "";
                        }
                    }

                }

                // Ahora debieramos de actualizar el albarán con el numero y serie de factura
                sQ = "UPDATE ABONG_CABE SET Factura=" + idFactura + ",AnyoFra=" + Abono.Anyo.ToString() + ",SerieFra='" + serie + "'";
                sQ += " WHERE Albaran=" + Abono.Albaran.ToString() + " AND Anyo=" + Abono.Anyo.ToString();
                int resUpdateAlbNG = EjecutaNonQuery(sQ, GloblaVar.gConRem);

            }
            catch (Exception ex)
            {
                    GloblaVar.gUTIL.ATraza(gIdent+" Error al Grabar Factura del Albarán " + Abono.Albaran );
                    MessageBox.Show("Error al intentar grabar la factura");
                    return "";
            }

            return idFactura +"/"+ Abono.Anyo.ToString() + "-" + serie;
        }

        public static string FacturarAbono2(string DetCod, string anyo, string serie, DateTime fecha, clase_linea_factura linea_factura, string observaciones, string importe_total, SqlConnection CnO)
        {
            string resultado = "";

            try
            {
                string idFactura = "";

                string sImporte_total = importe_total;
                string sBase_imponible = "0,00";
                string sImporte_iva = "0,00";
                string sImporte_recargo = "0,00";

                decimal dBase_imponible = 0;
                decimal dImporte_iva = 0;
                decimal dImporte_total = 0;
                decimal dImporte_recargo = 0;

                decimal dTipo_iva = 0;
                decimal dTipo_recargo = 0;

                bool llevaRecargo = false;

                string selectTipoIva = "SELECT TOP(1)IVA, Recargo FROM TIPOS_IVA ORDER BY Fecha desc";

                using (SqlCommand cmd = new SqlCommand(selectTipoIva, CnO))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            dTipo_iva = decimal.Parse(reader["IVA"].ToString());
                            dTipo_recargo = decimal.Parse(reader["Recargo"].ToString());
                        }

                        reader.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Al consultar el tipo de iva se ha producido el siguiente error: \n\n " + ex.Message);
                        return "";
                    }
                }

                string selectDetRecargo = "SELECT DetRec FROM DETALLISTAS WHERE DetCod = " + DetCod;

                using (SqlCommand cmd = new SqlCommand(selectDetRecargo, CnO))
                {

                    try
                    {
                        llevaRecargo = Convert.ToChar(cmd.ExecuteScalar()) == 'S' ? true : false;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Al consultar si el detallista lleva recargo se ha producido el siguiente error: \n\n " + ex.Message);
                        return "";
                    }

                }


                //Si lleva recargo, para cuadrar los decimales, calculamos el importe recargo con la resta de importe total - base imponible - importe iva
                if (llevaRecargo)
                {
                    dImporte_total = decimal.Parse(sImporte_total);
                    //sImporte_total = Funciones.Formatea("-" + dImporte_total.ToString());

                    dBase_imponible = dImporte_total / (1 + ((dTipo_iva + dTipo_recargo) / 100));
                    sBase_imponible = Funciones.Formatea(dBase_imponible.ToString());
                    dBase_imponible = decimal.Parse(sBase_imponible);

                    dImporte_iva = (dBase_imponible * dTipo_iva) / 100;
                    sImporte_iva = Funciones.Formatea(dImporte_iva.ToString());
                    dImporte_iva = decimal.Parse(sImporte_iva);

                    dImporte_recargo = dImporte_total - dBase_imponible - dImporte_iva;
                    sImporte_recargo = Funciones.Formatea(dImporte_recargo.ToString());
                }
                else //si no lleva recargo, para cuadrar los decimales, calculamos el importe iva con la resta de importe total - base imponible                
                {
                    dImporte_total = decimal.Parse(sImporte_total);
                    //sImporte_total = Funciones.Formatea("-" + dImporte_total.ToString());

                    dBase_imponible = dImporte_total / (1 + (dTipo_iva / 100));
                    sBase_imponible = Funciones.Formatea(dBase_imponible.ToString());
                    dBase_imponible = decimal.Parse(sBase_imponible);

                    dImporte_iva = dImporte_total - dBase_imponible;
                    sImporte_iva = Funciones.Formatea(dImporte_iva.ToString());
                }

                if (linea_factura != null)
                {
                    //Creamos el albarán
                    string venAlb = Nuevo_Albaran(anyo, CnO);

                    string insertVenalbCabe = @"INSERT INTO VENALB_CABE (VenAlb, Anyo, VenFec, DetCod, VenTve, VenBru, VenIva, VenRec, VenTot, FechaDiskette, Anulado, PerCentIVA, PerCentRec, AppExt)
                                                VALUES (" + venAlb + ", " + anyo + ", '" + fecha.ToShortDateString() + "', " + DetCod + ", 4, -" + sBase_imponible.Replace(",", ".") + ", -" + sImporte_iva.Replace(",", ".") + ", -" + sImporte_recargo.Replace(",", ".") + ", -" + sImporte_total.Replace(",", ".") + ", '" + fecha.ToShortDateString() + "', 0, " + dTipo_iva.ToString().Replace(",", ".") + ", " + dTipo_recargo.ToString().Replace(",", ".") + ", 0)";

                    int resVenalbCabe = EjecutaNonQuery(insertVenalbCabe, CnO);

                    if (resVenalbCabe == 1)
                    {
                        //ComentadoEncarni
                        //string insertVenalbLinea = @"INSERT INTO VENALB_LINEAS (VelAlb, VelFec, DetCod, ArtCod, ProCod, VelBul, VelKil, VelPre, VelLin, VelImp, Anyo, AppExt) 
                        //                            VALUES (" + venAlb + ", '" + fecha.ToShortDateString() + "', " + DetCod + ", " + linea_factura.ArtCod + ", 1, 0, 1, -" + sBase_imponible.Replace(",", ".") + ", " + linea_factura.LinF + ", -" + sBase_imponible.Replace(",", ".") + ", " + anyo + ", 0)";

                        string insertVenalbLinea = "";

                        int resVenalbLinea = EjecutaNonQuery(insertVenalbLinea, CnO);
                        if (resVenalbLinea == 0)
                        {
                            MessageBox.Show("Error al crear las líneas del albarán");
                            return "";
                        }

                        idFactura = Nuevo_Factura(anyo, serie, CnO);

                        string insertFactvCabe = @"INSERT INTO FACTV_CABE(Factura, Anyo, Serie, FechaEmision, DetCod, BI1, IVA1, RE1, ImpteFactura, ImpteCobrado, ImptePendiente, Observaciones) 
                                                    VALUES(" + idFactura + "," + anyo + ",'" + serie + "','" + fecha.ToShortDateString() + "'," + DetCod + ", -" + sBase_imponible.Replace(",", ".") + ", -" + sImporte_iva.Replace(",", ".") + ", -" + sImporte_recargo.Replace(",", ".") + ", -" + sImporte_total.Replace(",", ".") + ",0, -" + sImporte_total.Replace(",", ".") + ",'" + observaciones + "')";

                        int resFactvCabe = EjecutaNonQuery(insertFactvCabe, CnO);

                        if (resFactvCabe == 1)
                        {

                            //GloblaVar.gUTIL.SP3(idFactura, anyo, serie);

                            string updateVenalbCabe = @"UPDATE VENALB_CABE SET  VenNfp=" + idFactura + ", AnyoFra=" + anyo + ", SerieFra='" + serie + "' WHERE VenAlb=" + venAlb + " AND Anyo=" + anyo;

                            int resUptVenalbCabe = EjecutaNonQuery(updateVenalbCabe, CnO);
                            if (resUptVenalbCabe == 0)
                            {
                                MessageBox.Show("Error al modificar el albarán");
                                return "";
                            }

                            //ComentadoEncarni
                            //string insertFactvLinea = @"INSERT FACTV_LINEAS(Factura, Anyo, Serie, LinF, VelAlb, AnyoAlb, VelLin, ArtCod, VelBul, VelKil, VelPre, VelImp) 
                            //                            VALUES(" + idFactura + ", " + anyo + ", '" + serie + "', " + linea_factura.LinF + ", " + venAlb + ", " + anyo + ", " + linea_factura.LinF + ", " + linea_factura.ArtCod + ", 0, 1, -" + sBase_imponible.Replace(",", ".") + ", -" + sBase_imponible.Replace(",", ".") + ")";
                            string insertFactvLinea = "";

                            int resFactvLinea = EjecutaNonQuery(insertFactvLinea, CnO);
                            if (resFactvLinea == 0)
                            {
                                MessageBox.Show("Error al crear las líneas de la factura");
                                return "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al crear la cabecera de la factura");
                            return "";
                        }

                        resultado = idFactura;

                    }
                    else
                    {
                        MessageBox.Show("Error al crear la cabecera del albarán");
                        return "";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return resultado;

        } //FacturarAbono2

        private static string Nuevo_Albaran(string anyo, SqlConnection CnO)
        {
            string gIdent = "Funciones.Nuevo_Albaran ";
            Int32 CotaInf =Convert.ToInt32(GloblaVar.gNUMERO_TABLET + "000000");
            Int32 CotaSup = CotaInf + 1000000;
            
            string select = "SELECT MAX(VenAlb) FROM VENALB_CABE WHERE Anyo=" + anyo +" AND VenAlb BETWEEN "+CotaInf +" AND " +CotaSup;
            string ident = "0";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(select, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() != "")
                    {
                        ident = myReader[0].ToString();
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int aux = 0;
            if (System.Int32.TryParse(ident, out aux))
            {
                aux++;
                ident = aux.ToString();
            }

            if (ident=="1")     {ident=Convert.ToString(CotaInf);   }

            GloblaVar.gUTIL.ATraza(gIdent + " Albarán Nuevo ");
            return ident;        
        }

        public static string Nuevo_Cobro_Albaran(SqlConnection CnO)
        {
            string select = "SELECT MAX(IdCobro) FROM VENALB_COBROS";
            string ident = "0";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(select, CnO);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader[0].ToString() != "")
                    {
                        ident = myReader[0].ToString();
                    }
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int aux = 0;
            if (System.Int32.TryParse(ident, out aux))
            {
                aux++;
                ident = aux.ToString();
            }

            return ident;
        }

        public static string GetMd5(string str)
        {
            // First we need to convert the string into bytes, which means using a text encoder.
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            // Build the final string by converting each byte into hex and appending it to a StringBuilder
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            // And return it
            if (str == "")
            {
                return "";
            }
            else
            {
                return sb.ToString();
            }
        }

        public static string Suma(string uno, string dos)
        {
            decimal primero = 0;
            decimal segundo = 0;
            uno = uno.Replace('.', ',');
            dos = dos.Replace('.', ',');
            Decimal.TryParse(uno, out primero);
            Decimal.TryParse(dos, out segundo);
            decimal tercero = primero + segundo;
            return tercero.ToString();
        }

        public static string Resta(string uno, string dos)
        {
            decimal primero = 0;
            decimal segundo = 0;
            uno = uno.Replace('.', ',');
            dos = dos.Replace('.', ',');
            Decimal.TryParse(uno, out primero);
            Decimal.TryParse(dos, out segundo);
            decimal tercero = primero - segundo;
            return tercero.ToString();
        }

        public static string Multiplica(string uno, string dos)
        {
            //devuelve una cadena string con el resultado de multiplicar dos cadenas
            decimal primero = 0;
            decimal segundo = 0;
            uno = uno.Replace('.', ',');
            dos = dos.Replace('.', ',');
            Decimal.TryParse(uno, out primero);
            Decimal.TryParse(dos, out segundo);
            decimal tercero = primero * segundo;
            return tercero.ToString();
        }

        public static string Divide(string uno, string dos)
        {
            //devuelve una cadena string con el resultado de dividir dos cadenas
            decimal primero = 0;
            decimal segundo = 0;
            uno = uno.Replace('.', ',');
            dos = dos.Replace('.', ',');
            Decimal.TryParse(uno, out primero);
            Decimal.TryParse(dos, out segundo);
            if (segundo != 0)
            {
                decimal tercero = primero / segundo;
                return tercero.ToString();
            }
            else
            {
                return "0";
            }
        }

        public static string numerales(string cifra)
        {
            //elimar de cifra todo lo que no sean números
            for (int x = 0; x < cifra.Length; x++)
            {
                int numero = 0;
                string letra = cifra[x].ToString();
                if (letra != "," && letra != ".")
                {
                    if (System.Int32.TryParse(letra, out numero) == false)
                    {
                        cifra = cifra.Replace(letra, "");
                        x--;
                    }
                }
            }

            return cifra;
        }

        public static string Formatea(string basica)
        {
            if (basica == "") { basica = "0"; }
            if (basica.StartsWith("-") == false)
            {
                basica = numerales(basica);
            }
            if (basica.Contains('.')) { basica = basica.Replace(".", ","); }
            if (basica.Contains(','))
            {
                decimal num_basico = 0;
                if (Decimal.TryParse(basica, out num_basico))
                {
                    num_basico = Decimal.Round(num_basico, 2, MidpointRounding.AwayFromZero);
                    basica = String.Format("{0:0.00}", num_basico);
                }
            }
            else
            {
                basica = Formatea(basica + ",00");
            }

            return basica;
        }

        public static string Format_Num_Cadena(string Num,int ent,int dec)
        {
            string resultado = "";
            string Parte_Entera = "";
            string Parte_Dec = "";
            try
            {
                Parte_Entera = Num.Substring(0, Num.IndexOf(",")).PadLeft(ent,'0');
                Parte_Dec = Num.Substring(Num.IndexOf(",") + 1, 2);
                resultado = Parte_Entera + Parte_Dec;
                return resultado;
            
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza("Funciones.Format_Num_Cadena " + ex.Message );
                return "Error";
            }
        } //public static string Format_Num_Cadena(string Num)
        
        public static string FormateaKilos(string basica)
        {
            if (basica == "") { basica = "0"; }
            if (basica.StartsWith("-") == false)
            {
                basica = numerales(basica);
            }
            if (basica.Contains('.')) { basica = basica.Replace(".", ","); }
            if (basica.Contains(','))
            {
                decimal num_basico = 0;
                if (Decimal.TryParse(basica, out num_basico))
                {
                    num_basico = Decimal.Round(num_basico, 2, MidpointRounding.AwayFromZero);
                    basica = String.Format("{0:0.000}", num_basico);
                }
            }
            else
            {
                basica = FormateaKilos(basica + ",000");
            }

            return basica;
        }//public static string FormateaKilos(string basica)

        public static string ImpteCobrado(string Fra,string Año)
        {
            //Nos calculará el importe cobrado de una factura para Carabal. Esto se hará calculando el importe de los albaranes 
            //cobrados que contiene la factura

            //double ICobrado = 0;
            string cICobrado = "0";

            try
            {
                string sQ = "SELECT SUM(VenTot) as TotalCobrado FROM VENALB_CABE WHERE VenNfp=" + Fra + " AND Anyo=" + Año; // + " AND FechaCobro<>NULL";
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    
                    if (rd["TotalCobrado"] != null)
                    {
                        //ICobrado = rd.GetInt32(0);
                        //ICobrado = rd.GetDouble(0);
                        cICobrado = rd["TotalCobrado"].ToString();
                    }

                }
                rd.Close();
                return cICobrado;
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza("ERROR en Funciones.ImpteCobrado (Factura: "+ Fra +"/" +Año +": " +ex.ToString());
                return cICobrado;
            }
        } //public static string ImpteCobrado(string Fra,string Año)

        public static string ApunteAsiento(string Asto, string CtaCargo, string CtaContraPart, string Concepto, string IVA, string Req, string Haber, string Debe, string FechaCobro, string Serie)
        {

            string cero_cero = "0.00";
            string cero_seis = "0.000000";
            string cero = "0";
            //string uno = "1";
            string blanco = " ";


            if (FechaCobro.Length > 8)
            {
                FechaCobro = FechaCobro.Substring(6, 4) + FechaCobro.Substring(3, 2) + FechaCobro.Substring(0, 2);

            }
            string Apunte = Asto.ToString().PadLeft(6, ' ');        //Num Asiento justificado a la dcha 6 digitos


            Apunte += FechaCobro.ToString().PadRight(8, ' ');  // Fecha contable del asiento. la fecha de cobro normalmente. 8 digitos .ej 20160105
            Apunte += CtaCargo.PadRight(12, ' ');   //Codigo de la subcuenta 
            Apunte += cero_cero.PadLeft(28, ' ');   //Codigo de la contrapartida e importe al debe en pesetas
            Apunte += Concepto.PadRight(25, ' ');   //Concepto del asiento. 25 caracteres
            Apunte += cero_cero.PadLeft(16, ' ');   // Importe al haber en pesetas. No se usa.16.2
            Apunte += cero.PadLeft(8, ' ');         //Nº de factura al IVA
            Apunte += cero_cero.PadLeft(16, ' ');   //Base Imponible del IVA en pesetas.16.2
            Apunte += cero_cero.PadLeft(5, ' ');    //% del IVA  5.2
            Apunte += cero_cero.PadLeft(5, ' ');    //% Recargo Equivalencia. 5.2
            Apunte += blanco.PadLeft(10, ' ');      // Num. Documento
            Apunte += blanco.PadLeft(3, ' ');       //Código de departamento
            Apunte += blanco.PadLeft(6, ' ');       //Código del proyecto
            Apunte += blanco;                       //Punteo (interno)
            Apunte += cero.PadLeft(6, ' ');         //Numérico de casación
            Apunte += cero;                         //Tipo de casado (interno)
            Apunte += cero.PadLeft(6, ' ');         //Número de pago
            Apunte += cero_seis.PadLeft(16, ' ');   //Cambio a aplicar 16.6
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte Debe moneda extranjera.   16.2
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte HABER moneda extranjera.  16.2
            Apunte += "*";                          //Interno
            Apunte += Serie.PadLeft(1, ' ');         //Serie de la facturación
            Apunte += blanco.PadLeft(4, ' ');       //Sin uso
            Apunte += blanco.PadLeft(5, ' ');       //Código de la divisa
            Apunte += cero_cero.PadLeft(16, ' ');   //Impte auxiliar moneda extranjera
            Apunte += "2";                          //Moneda de uso. 2=Euros
            Apunte += Debe.PadLeft(16, ' ');        // Importe al debe 16.2
            Apunte += Haber.PadLeft(16, ' ');       //Importe al Haber 16.2
            Apunte += cero_cero.PadLeft(16, ' ');   //Base Imponible del IVA 16.2
            Apunte += "F";                          //(interno)
            //Apunte += blanco.PadLeft(10, ' ');      //Código de Activo
            //Apunte += blanco;
            //Apunte += cero.PadLeft(8, ' ') + cero_cero.PadLeft(16, ' ') + cero_cero.PadLeft(16, ' ') + "F" + blanco.PadLeft(8, ' ') + "E" + "F" + blanco.PadLeft(6, ' ') + "F" + blanco.PadLeft(6, ' ') + blanco.PadLeft(6, ' ') + "F";
            //Apunte += blanco.PadLeft(8, ' ') + blanco.PadLeft(8, ' ') + blanco.PadLeft(5, ' ') + blanco.PadLeft(10, ' ') + cero_cero.PadLeft(5, ' ') + cero_cero.PadLeft(5, ' ') + cero.PadLeft(6, ' ') + cero_cero.PadLeft(16, ' ');
            //Apunte += blanco.PadLeft(100, ' ') + blanco.PadLeft(50, ' ') + blanco.PadLeft(50, ' ') + blanco + uno.PadLeft(8, ' ') + blanco.PadLeft(40, ' ') + blanco.PadLeft(40, ' ') + "0" + blanco.PadLeft(15, ' ') + blanco.PadRight(40, ' ');
            //Apunte += blanco.PadLeft(9, ' ') + "F" + blanco.PadLeft(10, ' ') + "F" + "F            0.00            0                                                                                  F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

            return Apunte;
        }//private string ApunteAsiento

        public static bool Valor_CheckGrid(DataGridViewRow Fila,int Columna)
        {
            string gIdent ="Funciones._ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                //GloblaVar.gUTIL.ATraza(gIdent + "PARTIDA " + Fila.Cells[0].Value.ToString());
                if (Convert.ToBoolean(Fila.Cells[Columna].Value) == true) { return true; } else { return false; }
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(ex.ToString());
                MessageBox.Show(gIdent + " " + ex.ToString());
                return false;
            }
        }  //public static bool Valor_CheckGrid(DataGridViewRow Fila,int Columna)
    
        //prepara el campo AUX1 para el Listado
        public static string PreparaListado(DateTime fechaDesde, DateTime fechaHasta, SqlConnection CnO)
        {
            string gIdent = "Funciones.PreparaListado ";

            int status=0, albaran, ivaReq=0, venTve, anyo;
            string tipoBotella="";
            string query1, query2;
            string vensta, vencoe, venpca;
            double venRec;
            DateTime venFec;

            string error = "";

            query1 =  "SELECT VenAlb, VenFec, Anyo, VenTve, vensta, vencoe, VenPca, VenRec ";
            query1 += "FROM VENALB_CABE WHERE VenFec>='" + fechaDesde.ToShortDateString() + "' and VenFec<='" + fechaHasta.ToShortDateString() + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query1, CnO))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        albaran = Convert.ToInt32(reader["VenAlb"]);
                        venTve = Convert.ToInt32(reader["VenTve"]);
                        vensta = Convert.ToString(reader["vensta"]);
                        vencoe = Convert.ToString(reader["vencoe"]);
                        venpca = Convert.ToString(reader["venpca"]);
                        venRec = Convert.ToDouble(reader["VenRec"]);
                        venFec = Convert.ToDateTime(reader["VenFec"]);
                        anyo = Convert.ToInt32(reader["Anyo"]);

                        switch (venTve)
                        {
                            case 1: //CREDITO
                                if(!string.IsNullOrEmpty(vensta))
                                {
                                    status = Convert.ToInt32(vensta);
                                }
                                else
                                {
                                    status = 0;
                                }

                                switch (status)
	                            {
                                    case 0:                                           
                                    case 2:                                           
                                    case 4:
                                        tipoBotella = "01 CREDITO";                                            
                                        break;
	                            }

                                switch (vencoe)
	                            {
                                    case "L":
                                        tipoBotella = "010 SERIE L RETENIDOS";
                                        break;
                                    case "M":
                                        tipoBotella = "011 SERIE L AL BANCO";
                                        break;
                                    case "Z":
                                    case "P":
                                        tipoBotella = "01 CREDITO";
                                        break;
	                            }

                                if (venpca == "S")
                                {
                                    tipoBotella = "05 PENDIENTE CASA";
                                }                                   
                                    
                                break;

                            case 2: //CONTADO PENDIENTE
                                tipoBotella = "02 CONTADO PENDIENTE";

                                if (!string.IsNullOrEmpty(vensta))
                                {
                                    status = Convert.ToInt32(vensta);
                                }
                                else
                                {
                                    status = 0;
                                }

                                switch (status)
	                            {
                                    case 0:
                                    case 2:
                                    case 4:
                                        tipoBotella = "02 CONTADO PENDIENTE";
                                        break;                                        
	                            }

                                switch (vencoe)
                                {
                                    case "L":
                                        tipoBotella = "011 SERIE L AL BANCO";
                                        break;
                                    case "M":
                                        tipoBotella = "020 SERIE M RETENIDOS";
                                        break;                                        
                                    case "Z":
                                        tipoBotella = "02 CONTADO PENDIENTE";
                                        break;
                                }

                                if (venpca == "S")
                                {
                                    tipoBotella = "05 PENDIENTE CASA";
                                }                                   
                                    
                                break;

                            case 3: //CONTADO PAGADO
                                tipoBotella = "03 CONTADO PAGADO";

                                if(string.IsNullOrEmpty(venpca))
                                {
                                    tipoBotella = "03 CONTADO PAGADO";
                                }
                                else if (venpca == "S") //Albarán Pdte casa
                                {
                                    tipoBotella = "05 PENDIENTE CASA";
                                }

                                break;

                            case 4: //NO FACTURAR. Aquí están los de facturación propia
                                if(venpca == "S")
                                {
                                    tipoBotella = "06 F.PROPIA PENDIENTE CASA";
                                }
                                else
                                {
                                    tipoBotella = "04 F.PROPIA PAGADO";
                                }
                                break;

                        }

                        if (venRec > 0)
                        {
                            ivaReq = 11; //Int(IVA_Fecha(FechaSP(Rst!VenFec)) + Recargo_Fecha(FechaSP(Rst!VenFec)))

                        }
                        else if (venRec == 0)
                        {
                            ivaReq = 10; //IVA_Fecha(FechaSP(Rst!VenFec))
                        }

                        query2 = string.Format("UPDATE VENALB_CABE SET AUX1='{0}', AUX2={1}, vensta={2} WHERE VenAlb={3} AND Anyo={4}", tipoBotella, ivaReq, status, albaran, anyo);

                        int res = EjecutaNonQuery(query2, CnO);

                    }

                    reader.Close();
                    
                }

                 PreparaZAnteriores(fechaHasta, CnO);

                 PreparaModif435(fechaDesde, fechaHasta, CnO);

            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message );
                error +="Se ha producido un error en 'Funciones.PreparaListado': \n\n" + ex.Message;               
            }

            return error;
        }

        //Pondrá la etiqueta a los albaranes que tengan en Vencoe'Z' y sean de días anteriores
        private static void PreparaZAnteriores (DateTime fecha, SqlConnection CnO)
        {
            int albaran, detCod, ivaReq=0, anyo;
            double venRec;
            string query1, query2, modelo03 = "";

            query1 =  "SELECT VenAlb, DetCod, VenRec FROM VENALB_CABE ";
            query1 += "WHERE VenCoe='Z' AND VenFec <= '" + fecha.ToShortDateString() + "'";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query1, CnO))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        albaran = Convert.ToInt32(reader["VenAlb"]);
                        detCod = Convert.ToInt32(reader["detCod"]);
                        venRec = Convert.ToDouble(reader["VenRec"]);
                        anyo = Convert.ToInt32(reader["Anyo"]);

                        if(detCod >= 0 && detCod <= 2999)
                        {
                            modelo03 = "011 SERIE L AL BANCO";
                        }

                        if(detCod >= 3000 && detCod <= 5999)
                        {
                            modelo03 = "021 SERIE M AL BANCO";
                        }

                        if (venRec > 0)
                        {
                            ivaReq = 11; //Int(IVA_Fecha(FechaSP(Rst!VenFec)) + Recargo_Fecha(FechaSP(Rst!VenFec)))

                        }
                        else if (venRec == 0)
                        {
                            ivaReq = 10; //IVA_Fecha(FechaSP(Rst!VenFec))
                        }

                        query2 = string.Format("UPDATE VENALB_CABE SET AUX1='{0}', AUX2={1} WHERE VenAlb={2} AND Anyo={3}", modelo03, ivaReq, albaran, anyo);

                        int res = EjecutaNonQuery(query2, CnO);

                    }

                    reader.Close();
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Error en 'Funciones.PreparaZAnteriores':\n" + ex.Message);                
            }          

        }

        //Pondrá la etiqueta a los albaranes que sean de detallistas Que tengan Código en DetMay
        //Esto se aplica a partir de la versión 4.35 a petición de Jorge Botella el 2/3/2017
        private static void PreparaModif435(DateTime fechaDesde, DateTime fechaHasta, SqlConnection CnO)
        {
            int albaran, ivaReq=0, anyo;
            double venRec;
            string query1, query2, query3, modelo03="";

            query1 =  "SELECT VenAlb, Anyo, DetCod, VenRec FROM VENALB_CABE ";
            query1 += "WHERE DetCod IN (SELECT DetCod FROM DETALLISTAS WHERE DetMay<>'') ";
            query1 += "AND (VenFec>='" + fechaDesde.ToShortDateString() + "' AND VenFec<='" + fechaHasta.ToShortDateString() + "') AND Anulado=0";

            try
            {
                using(SqlCommand cmd = new SqlCommand(query1, CnO))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        albaran = Convert.ToInt32(reader["VenAlb"]);
                        venRec = Convert.ToDouble(reader["VenRec"]);
                        anyo = Convert.ToInt32(reader["Anyo"]);

                        modelo03 = "07 FACT. PROPIA CREDITO";

                        if (venRec > 0)
                        {
                            ivaReq = 11; //Int(IVA_Fecha(FechaSP(Rst!VenFec)) + Recargo_Fecha(FechaSP(Rst!VenFec)))

                        }
                        else if (venRec == 0)
                        {
                            ivaReq = 10; //IVA_Fecha(FechaSP(Rst!VenFec))
                        }

                        query2 = string.Format("UPDATE VENALB_CABE SET AUX1='{0}', AUX2={1} WHERE VenAlb={2} AND Anyo={3}", modelo03, ivaReq, albaran, anyo);

                        int res2 = EjecutaNonQuery(query2, CnO);
                    }

                    reader.Close();
                }

                query3 = "UPDATE DETALLISTAS SET DetMay=NULL WHERE DetMay=''";
                int res3 = EjecutaNonQuery(query3, CnO);

            }
            catch (Exception ex)
            {
                throw new Exception("Error en 'Funciones.PreparaModif435':\n" + ex.Message);
            }

        }

        public static DataTable LlenarDataTable(string cadena)
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlCommand cmd = new SqlCommand(cadena, GloblaVar.gConRem))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                }     
            }
            catch (Exception)
            {
                dt = null;
            }            

            return dt;
        }  //public static DataTable LlenarDataTable(string cadena)

        public static void AbreExcell(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }   //public static void AbreExcell(string f)
        public static bool ExisteCAJADIA(string IdCaja)
        {
            string gIdent = "Funciones.ExisteCAJADIA.  ";
            bool resultado = false;



            try
            {
                string strQ = "SELECT * FROM CAJADIA_VENTAS WHERE IdCaja=" + IdCaja;
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    resultado = true;
                }
                myReader.Close();
                myCommand.Dispose();
                return resultado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());

                return resultado;
            }


        }   //public static bool ExisteCAJADIA(string IdCaja)

        public static bool Existe_FACTURA2(string serie, string refer)
        {
            string gIdent = "Funciones.Existe_FACTURA2.  ";
            bool resultado = false;



            try
            {
                string strQ = "SELECT Factura FROM FACTURAS1 WHERE Referencia='" + refer + "' AND Serie='" + serie + "'";
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, GloblaVar.gConRem);

                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    myReader.Read();
                    GloblaVar.TeMp = myReader["Factura"].ToString();
                    resultado = true;
                }
                myReader.Close();
                myCommand.Dispose();
                return resultado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());

                return resultado;
            }


        }   //public static bool Existe_FACTURA2(string IdCaja)

        public static Int32 NuevoNum(string Tabla, string Campo, string Condición)
        {
            //Nos dará el valor correspondiente al siguiente registro a insertar en una tabla en la que insertamos elementos consecutivos
            //Sea Facturas, Albaranes, etc
            string gIdent = "Funciones.NuevoNum.  ";
            Int32 resultado = 1;

            try
            {
                string strQ = "SELECT max(" + Campo + ") FROM " + Tabla + " " + Condición;
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQ, GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    myReader.Read();
                    resultado = myReader.GetInt32(0) + 1;
                }
                myReader.Close();
                myCommand.Dispose();
                return resultado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());

                return resultado;
            }
        } //public Int32  NuevoNum(string Tabla,string Campo,string Condición)

        public static decimal IVA_Fecha(DateTime Fecha)
        {
            string gIdent = "Funciones.IVA_Fecha.  ";
            decimal respuesta = 10;

            //lectura de IVA y Recargo
            DateTime fecha_bd = new DateTime(2000, 1, 1);
            string consulta_IVA = "SELECT Fecha, IVA, Recargo FROM TIPOS_IVA order by Fecha";

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(consulta_IVA, GloblaVar.gConRem);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string fecha = myReader["Fecha"].ToString();

                    if (DateTime.TryParse(fecha, out fecha_bd) == true)
                    {
                        if (Fecha.CompareTo(fecha_bd) >= 0)
                        {
                            respuesta = Convert.ToDecimal(myReader["IVA"].ToString());
                            //RECARGO = myReader["Recargo"].ToString(); if (label_Recargo.Text != "") { label_Recargo.Text = RECARGO; }
                        }
                    }
                }

                myReader.Close();
                myCommand.Dispose();
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                return respuesta;
            }

        }  //public static  decimal IVA_Fecha(string Fecha)
        public static string DameNomAcr(string Codigo)
        {
            //Nos dará el Nombre de un Acreedor localizado a través de su código

            string gIdent = "Funciones_DameNomAcr ."; //this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Buscando Nombre del Acreedor " + Codigo);
            string AcrBuscado = "";
            try
            {
                SqlDataReader myR = null;
                SqlCommand myC = new SqlCommand("SELECT * FROM ACREEDORES WHERE IdAcreedor=" + Codigo, GloblaVar.gConRem);
                myR = myC.ExecuteReader();
                if (myR.Read())
                {
                    AcrBuscado = myR["Nombre"].ToString().Trim();
                    GloblaVar.gACRBUSCADO = null;
                    GloblaVar.gACRBUSCADO = new clase_detallista();
                    GloblaVar.gACRBUSCADO.DetCod = Codigo;
                    GloblaVar.gACRBUSCADO.DetNom = AcrBuscado;
                    //if (myR["AcrNif"] != DBNull.Value) { GloblaVar.gAcrBUSCADO.AcrNif = myR["AcrNif"].ToString().Trim(); }
                    //if (myR["AcrMun"] != DBNull.Value) { GloblaVar.gAcrBUSCADO.Acrmun = myR["AcrMun"].ToString().Trim(); }
                    //if (myR["Acrvia"] != DBNull.Value) { GloblaVar.gAcrBUSCADO.Acrvia = myR["Acrvia"].ToString().Trim(); }
                    //if (myR["AcrRec"] != DBNull.Value) { GloblaVar.gAcrBUSCADO.AcrRec = myR["AcrRec"].ToString().Trim(); }
                    //if (myR["AcrCop"] != DBNull.Value) { GloblaVar.gAcrBUSCADO.AcrCop = myR["AcrCop"].ToString().Trim(); }

                    myR.Close();
                    return AcrBuscado;
                }
                else
                {
                    myR.Close();
                    return "NO EXISTE";
                }
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + " CÓDIGO ERRÓNEO " + ex.ToString());
                return "CÓDIGO ERRÓNEO";
            }
        }  //public static string DameNomAcr(string Codigo)

    }  //public class funciones
}  //namespace cercle17
