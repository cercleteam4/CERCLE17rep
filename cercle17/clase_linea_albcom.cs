using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cercle17
{
    //Líneas de albaranes de compra (COMALB_LINEAS)
    public class clase_linea_albcom
    {
        public clase_linea_albcom()
        {
            this.cPartida = new clase_partidas();
        }

        public string ComLpa { get; set; }
        public string ComLnl { get; set; }
        public string comcfa { get; set; }
        public string Anyo { get; set; }
        public string ProCod { get; set; }
        public string ProNom { get; set; }          
        public string ArtCod { get; set; }
        public string ArtDes { get; set; }
        public string ComLca { get; set; }
        public string ComLki { get; set; }
        public string ComLpr { get; set; }
        public string ComLim { get; set; }
        public bool Facturado { get; set; }
        public string comltl { get; set; }
        public string comlcp { get; set; }
        public string comlkp { get; set; }
        public string ComLal { get; set; }
        public string Stock { get; set; }
        public string Partida { get; set; }
        public string Ref{ get; set; }
        public string AlmMay { get; set; }

        public clase_partidas cPartida { get; set; }

        public string Insertar(ref SqlTransaction sqlTran)
        {
            string resp = "";
            string sqlLinea = "";

            if (frmPpal.USUARIO == "3")
            {
                sqlLinea = @"INSERT INTO COMALB_LINEAS (ComLpa, ProCod, comcfa, ComLnl, comltl, ArtCod, ComLca, ComLki, comlcp, comlkp, ComLpr,ComLim, ComLal, Stock, Partida, Anyo, Ref, AlmMay) 
                             VALUES (@ComLpa, @ProCod, @comcfa, @ComLnl, @comltl, @ArtCod, @ComLca, @ComLki, @comlcp, @comlkp, @ComLpr,@ComLim, @ComLal, @Stock, @Partida, @Anyo, @Ref, @AlmMay) ";
            }
            else
            {
                sqlLinea = @"INSERT INTO COMALB_LINEAS (ComLpa, ProCod, comcfa, ComLnl, comltl, ArtCod, ComLca, ComLki, comlcp, comlkp, ComLpr, ComLal, Stock, Partida, Anyo, Ref, AlmMay) 
                                VALUES (@ComLpa, @ProCod, @comcfa, @ComLnl, @comltl, @ArtCod, @ComLca, @ComLki, @comlcp, @comlkp, @ComLpr, @ComLal, @Stock, @Partida, @Anyo, @Ref, @AlmMay) ";

            }            

            try
            {  
                using(SqlCommand cmd = new SqlCommand(sqlLinea, GloblaVar.gConRem, sqlTran))
                {
                    cmd.Parameters.AddWithValue("@ComLpa", this.ComLpa);
                    cmd.Parameters.AddWithValue("@ProCod", this.ProCod);
                    cmd.Parameters.AddWithValue("@comcfa", this.comcfa);
                    cmd.Parameters.AddWithValue("@ComLnl", this.ComLnl);
                    cmd.Parameters.AddWithValue("@comltl", this.comltl);
                    cmd.Parameters.AddWithValue("@ArtCod", this.ArtCod);
                    cmd.Parameters.AddWithValue("@ComLca", this.ComLca);
                    cmd.Parameters.AddWithValue("@ComLki", this.ComLki.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@comlcp", this.comlcp.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@comlkp", this.comlkp.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComLpr", this.ComLpr.Replace(",", "."));

                    if (frmPpal.USUARIO == "3")
                    {
                        cmd.Parameters.AddWithValue("@ComLim", this.ComLim.Replace(",", "."));
                        GloblaVar.gUTIL.ATraza(" Importe: " + this.ComLim.Replace(",", "."));
                    }
                    
                    cmd.Parameters.AddWithValue("@ComLal", this.ComLal);
                    cmd.Parameters.AddWithValue("@Stock", this.Stock.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@Partida", this.Partida);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                    cmd.Parameters.AddWithValue("@Ref", this.Ref);
                    cmd.Parameters.AddWithValue("@AlmMay", this.AlmMay);
                    //cmd.Parameters.AddWithValue("@Facturado", this.Facturado );
                    //GloblaVar.gUTIL.ATraza("clase_linea_albcom.Insertar " +sqlLinea );
                    resp = cmd.ExecuteNonQuery() >= 1 ? "" : "La línea de albaran no se ha podido insertar";
                }
            }
            catch(Exception ex)
            {
                resp = ex.Message;
                GloblaVar.gUTIL.ATraza("clase_linea_albcom.Insertar--> " +ex.Message );
            }

            return resp;            

        }

        public string Modificar()
        {
            string resp = "";         

            try
            {
                string nuevoStock = RecalcularStock();

                string sqlUpdate = ""; 

                if (frmPpal.USUARIO == "3")
                {
                    sqlUpdate = @"UPDATE COMALB_LINEAS SET ArtCod=@ArtCod, ComLca=@ComLca, ComLki=@ComLki, comlcp=@ComLca, comlkp=@ComLki, ComLpr=@ComLpr, ComLim=@ComLim, Stock=@Stock, Ref=@Ref WHERE ComLpa=@ComLpa and ComLnl=@ComLnl and Anyo=@Anyo";

                }
                else
                {
                    sqlUpdate = @"UPDATE COMALB_LINEAS SET ArtCod=@ArtCod, ComLca=@ComLca, ComLki=@ComLki, comlcp=@ComLca, comlkp=@ComLki, ComLpr=@ComLpr, Stock=@Stock, Ref=@Ref WHERE ComLpa=@ComLpa and ComLnl=@ComLnl and Anyo=@Anyo";
                }                    

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ArtCod", this.ArtCod);
                    cmd.Parameters.AddWithValue("@ComLca", this.ComLca);
                    cmd.Parameters.AddWithValue("@ComLki", this.ComLki.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComLpr", this.ComLpr.Replace(",", "."));
                    if (frmPpal.USUARIO == "3")
                    {
                        cmd.Parameters.AddWithValue("@ComLim", this.ComLim.Replace(",", "."));
                        GloblaVar.gUTIL.ATraza(" Importe: " + this.ComLim.Replace(",", "."));
                    }
                    cmd.Parameters.AddWithValue("@Stock", nuevoStock.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComLpa", this.ComLpa);
                    cmd.Parameters.AddWithValue("@ComLnl", this.ComLnl);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                    cmd.Parameters.AddWithValue("@Ref", this.Ref);

                    resp = cmd.ExecuteNonQuery() >= 1 ? "" : "El código de proveedor no se ha podido modificar en la línea de albarán";                   

                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;

        }

        public string ModificarProCod(string proCod)
        {
            string resp = "";

            try
            {
                string sqlUpdate = @"UPDATE COMALB_LINEAS SET ProCod=@ProCod WHERE ComLpa=@ComLpa and ComLnl=@ComLnl and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ProCod", proCod);
                    cmd.Parameters.AddWithValue("@ComLpa", this.ComLpa);
                    cmd.Parameters.AddWithValue("@ComLnl", this.ComLnl);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);

                    resp = cmd.ExecuteNonQuery() >= 1 ? "" : "El código de proveedor no se ha podido modificar en la línea de albarán";
                    if (resp == "")
                    {
                        resp = cPartida.ModificarProCod(proCod);
                    }
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;

        }

        public string Eliminar(string comLpa, string comLnl, string anyo, string partida, ref SqlTransaction sqlTran)
        {
            string resp = "";

            try
            {
                string sqlDelete = @"DELETE FROM COMALB_LINEAS WHERE ComLpa=@ComLpa and ComLnl=@ComLnl and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlDelete, GloblaVar.gConRem, sqlTran))
                {
                    cmd.Parameters.AddWithValue("@ComLpa", comLpa);
                    cmd.Parameters.AddWithValue("@ComLnl", comLnl);
                    cmd.Parameters.AddWithValue("@Anyo", anyo);

                    resp = cmd.ExecuteNonQuery() >= 1 ? "" : "La línea no se ha podido eliminar";
                    if (resp == "")
                    {
                        resp = cPartida.Eliminar(partida, anyo, ref sqlTran);
                    }
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;
        }       

        public List<clase_linea_albcom> CogerLineasAlbaranPorCodigo(string comLpa, string anyo)
        {           

            List<clase_linea_albcom> list = new List<clase_linea_albcom>();

            string sql = "";

            if (frmPpal.USUARIO == "3")
            {
                sql = @"SELECT LC.ComLpa, LC.ProCod, LC.comcfa, LC.ComLnl, LC.comltl, LC.ArtCod, A.ArtDes, LC.ComLca, LC.ComLki, LC.comlcp, LC.comlkp, LC.ComLpr, LC.ComLim, LC.ComLal, LC.Stock, LC.Partida, LC.Anyo, LC.Ref, LC.AlmMay, LC.Facturado 
                        FROM COMALB_LINEAS LC INNER JOIN ARTICULOS AS A ON LC.ArtCod=A.ArtCod
                        WHERE LC.ComLpa=@ComCpa and LC.Anyo=@Anyo";
            }
            else
            {
                sql = @"SELECT ComLpa, ProCod, comcfa, ComLnl, comltl, ArtCod, ComLca, ComLki, comlcp, comlkp, ComLpr, ComLal, Stock, Partida, Anyo, Ref, AlmMay,Facturado FROM COMALB_LINEAS WHERE ComLpa=@ComCpa and Anyo=@Anyo";
            }
                

            using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
            {
                cmd.Parameters.AddWithValue("@ComCpa", comLpa);
                cmd.Parameters.AddWithValue("@Anyo", anyo);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(CargarLineasAlbaran(reader));                        
                }

                reader.Close();
            }            

            return list;

        }

        public clase_linea_albcom CogerLineaAlbaranPorCodigoYLinea(string comLpa, string anyo, string comLnl)
        {

            clase_linea_albcom linea = new clase_linea_albcom();

            string sql = "";

            if(frmPpal.USUARIO=="3")
            {
                sql = @"SELECT ComLpa, ProCod, comcfa, ComLnl, comltl, ArtCod, ComLca, ComLki, ComLim, comlcp, comlkp, ComLpr, ComLal, Stock, Partida, Anyo, Ref, AlmMay,Facturado FROM COMALB_LINEAS WHERE ComLpa=@ComCpa and Anyo=@Anyo and ComLnl=@ComLnl";
            }
            else
            {
                sql = @"SELECT ComLpa, ProCod, comcfa, ComLnl, comltl, ArtCod, ComLca, ComLki, comlcp, comlkp, ComLpr, ComLal, Stock, Partida, Anyo, Ref, AlmMay,Facturado FROM COMALB_LINEAS WHERE ComLpa=@ComCpa and Anyo=@Anyo and ComLnl=@ComLnl";
            }           

            using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
            {
                cmd.Parameters.AddWithValue("@ComCpa", comLpa);                
                cmd.Parameters.AddWithValue("@Anyo", anyo);
                cmd.Parameters.AddWithValue("@ComLnl", comLnl);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    linea = CargarLineasAlbaran(reader);
                }

                reader.Close();
            }

            return linea;

        }

        public string ObtenerNumeroLineaAlbaran(string comLpa, string anyo)
        {
            //obtener próximo número de línea
            int numLinea = 1;

            string query = "SELECT MAX(ComLnl) FROM COMALB_LINEAS WHERE ComLpa=@ComLpa and Anyo=@Anyo";

            using (SqlCommand cmd = new SqlCommand(query, GloblaVar.gConRem))
            {
                cmd.Parameters.AddWithValue("@ComLpa", comLpa);
                cmd.Parameters.AddWithValue("@Anyo", anyo);

                //object result = cmd.ExecuteScalar();
                //if(result != DBNull.Value)
                //{
                //    numLinea = Convert.ToInt32(result);
                //    numLinea++;
                //}

                string result = cmd.ExecuteScalar().ToString();
                if (result != "")
                {
                    numLinea = Convert.ToInt32(result);
                    numLinea++;
                }                

            }

            return numLinea.ToString();

        }

        private string RecalcularStock()
        {
            string nuevoStock = "0";

            string query = "SELECT SUM(VL.VelKil) FROM VENALB_LINEAS VL, VENALB_CABE VC WHERE (VL.Partida=@Partida) AND (VL.PartAlm = '01') AND (VL.PartAnyo=@Anyo) AND (VL.VelAlb=VC.VenAlb) AND (VC.Anulado = 0) AND (VL.VelFec = VC.VenFec)";

            using (SqlCommand cmd = new SqlCommand(query, GloblaVar.gConRem))
            {
                cmd.Parameters.AddWithValue("@Partida", this.Partida);
                cmd.Parameters.AddWithValue("@Anyo", this.Anyo);

                nuevoStock = cmd.ExecuteScalar().ToString();

            }

            nuevoStock = Funciones.Resta(this.ComLki, nuevoStock);

            return nuevoStock;

        }

        private clase_linea_albcom CargarLineasAlbaran(IDataReader reader)
        {
            clase_linea_albcom linea = new clase_linea_albcom();
            try
            {
                linea.ComLpa = Convert.ToString(reader["ComLpa"]);
                linea.ProCod = Convert.ToString(reader["ProCod"]);
                linea.comcfa = Convert.ToString(reader["comcfa"]);
                linea.ComLnl = Convert.ToString(reader["ComLnl"]);
                linea.comltl = Convert.ToString(reader["comltl"]);
                linea.ArtCod = Convert.ToString(reader["ArtCod"]);
                linea.ComLca = Convert.ToString(reader["ComLca"]);
                linea.ComLki = Convert.ToString(reader["ComLki"]);
                if (frmPpal.USUARIO == "3")
                {
                    linea.ComLim = Convert.ToString(reader["ComLim"]);
                    linea.ArtDes = Convert.ToString(reader["ArtDes"]);
                }
                linea.comlcp = Convert.ToString(reader["comlcp"]);
                linea.comlkp = Convert.ToString(reader["comlkp"]);
                linea.ComLpr = Convert.ToString(reader["ComLpr"]);
                linea.ComLal = Convert.ToString(reader["ComLal"]);
                linea.Stock = Convert.ToString(reader["Stock"]);
                linea.Partida = Convert.ToString(reader["Partida"]);
                linea.Anyo = Convert.ToString(reader["Anyo"]);
                linea.Ref = Convert.ToString(reader["Ref"]);
                linea.AlmMay = Convert.ToString(reader["AlmMay"]);
                if (reader["Facturado"] == System.DBNull.Value) { linea.Facturado = false; } else { linea.Facturado = Convert.ToBoolean(reader["Facturado"]); }

                linea.cPartida = cPartida.CogerPartida(linea.Partida, linea.Anyo);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(" clase_linea_albcom.CargarLineasAlbaran " + ex.ToString());
            }

            return linea;

        }

    }
}
