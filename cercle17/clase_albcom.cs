using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cercle17
{
    //Albaranes de compra (COMALB_CABE)
    public class clase_albcom
    {

        public clase_albcom()
        {
            this.lineas = new List<clase_linea_albcom>();
        }

        public bool Facturar { get; set; }
        public string ComCpa { get; set; }
        public string Anyo { get; set; }
        public string ProCod { get; set; }
        public string ComCfa { get; set; }
        public string FpaCod { get; set; }
        public string Comcpo { get; set; }
        public string comctf { get; set; }
        public string comcim { get; set; }
        public string Portes { get; set; }
        public string Colla { get; set; }
        public string Proveedor { get; set; }
        public bool Facturado { get; set; }
        public string PerCentIVA { get; set; }
        public string PerCentRec { get; set; }                                                      
        
        public List<clase_linea_albcom> lineas { get; set; }

        public string Insertar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";

            try
            {
                this.ComCpa = ObtenerNumeroAlbaran(this.Anyo);

                string sqlInsert = @"INSERT INTO COMALB_CABE (ComCpa, ProCod, ComCfa, FpaCod, comcpo, comctf, comcim, Anyo, Portes, Colla) 
                                     VALUES (@ComCpa, @ProCod, @ComCfa, @FpaCod, @comcpo, @comctf, @comcim, @Anyo, @Portes, @Colla)";

                SqlTransaction sqlTran = GloblaVar.gConRem.BeginTransaction();
                GloblaVar.gUTIL.ATraza(gIdent + sqlInsert);
                using(SqlCommand cmd = new SqlCommand(sqlInsert, GloblaVar.gConRem, sqlTran))
                {
                    cmd.Parameters.AddWithValue("@ComCpa", this.ComCpa);
                    cmd.Parameters.AddWithValue("@ProCod", this.ProCod);
                    cmd.Parameters.AddWithValue("@ComCfa", this.ComCfa);
                    cmd.Parameters.AddWithValue("@FpaCod", this.FpaCod);
                    cmd.Parameters.AddWithValue("@comcpo", this.Comcpo);
                    cmd.Parameters.AddWithValue("@comctf", this.comctf);
                    cmd.Parameters.AddWithValue("@comcim", this.comcim.Replace(",","."));
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                    cmd.Parameters.AddWithValue("@Portes", this.Portes.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@Colla", this.Colla.Replace(",", "."));

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "El albarán no se ha podido insertar";
                }

                if (resp == "")
                {
                    int contLinea = 0;

                    foreach (clase_linea_albcom lineaAlb in this.lineas)
                    {
                        contLinea++;

                        //Añadimos a la partida los datos que faltan
                        lineaAlb.cPartida.Anyo = this.Anyo;
                        lineaAlb.cPartida.AlmMay = "01";
                        lineaAlb.cPartida.StockInicial = lineaAlb.ComLki;
                        lineaAlb.cPartida.ArtCod = lineaAlb.ArtCod;
                        lineaAlb.cPartida.ProCod = this.ProCod;
                        lineaAlb.cPartida.AlbCompra = this.ComCpa;
                        lineaAlb.cPartida.FCompra = this.ComCfa;
                        //lineaAlb.cPartida.ZCaptura = lineaAlb.cPartida.ZCaptura;
                        //Llamar al método insertar de la clase clase_partidas
                        resp = lineaAlb.cPartida.Insertar(ref sqlTran);
                        if (resp != "")
                        {
                            break;
                        }

                        //Añadimos a la línea los datos que faltan
                        lineaAlb.ComLpa = this.ComCpa;
                        lineaAlb.ProCod = this.ProCod;
                        lineaAlb.comcfa = this.ComCfa;
                        lineaAlb.ComLnl = contLinea.ToString();
                        lineaAlb.comltl = "N";
                        lineaAlb.comlcp = lineaAlb.ComLca;
                        lineaAlb.comlkp = lineaAlb.ComLki;
                        lineaAlb.ComLal = "1";
                        lineaAlb.Stock = lineaAlb.ComLki;
                        lineaAlb.Partida = lineaAlb.cPartida.Partida;
                        lineaAlb.Anyo = this.Anyo;
                        lineaAlb.Ref = lineaAlb.cPartida.Ref; 
                        lineaAlb.AlmMay = "01";
                        lineaAlb.Facturado = false;

                        //Llamar al método insertar de la clase clase_linea_albcom
                        resp = lineaAlb.Insertar(ref sqlTran);
                        if (resp != "")
                        {
                            MessageBox.Show(resp);
                            break;
                        }
                    }
                }

                if (resp == "")
                {
                    sqlTran.Commit();
                }
                else
                {
                    sqlTran.Rollback();
                }
            
            }
            catch (Exception ex)
            {
                //MessageBox.Show(gIdent + ex.Message);
                resp = ex.Message;
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

            return resp;

        }

        public string Modificar(string comCpa, string anyo, bool modificaProCod)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";

            try
            {
                //string sqlUpdate = @"UPDATE COMALB_CABE SET ProCod=@ProCod, ComCfa=@ComCfa, Anyo=@Anyo, Portes=@Portes, Colla=@Colla WHERE ComCpa=@ComCpa and Anyo=@Anyo2";
                string sqlUpdate = @"UPDATE COMALB_CABE SET ProCod=@ProCod, comcim=@comcim, Portes=@Portes, Colla=@Colla WHERE ComCpa=@ComCpa and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ProCod", this.ProCod);                    
                    cmd.Parameters.AddWithValue("@comcim", this.comcim.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@Portes", this.Portes.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@Colla", this.Colla.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComCpa", comCpa);
                    cmd.Parameters.AddWithValue("@Anyo", anyo);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "El albarán no se ha podido modificar";
                    if(resp == "")
                    {
                        if(modificaProCod)
                        {
                            foreach (clase_linea_albcom lineaAlb in lineas)
                            {
                                resp = lineaAlb.ModificarProCod(this.ProCod);
                                if (resp != "")
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(gIdent + ex.Message);
                resp = ex.Message;
            }

            return resp;

        }

        public string Eliminar()
        {
            string resp = "";

            try
            {

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;
        }

        private string ObtenerNumeroAlbaran(string anyo)
        {           
            //obtener próximo número de albarán
            string resultado = "1";

            string query = "SELECT MAX(ComCpa) FROM COMALB_CABE WHERE (Anyo=" + anyo + ")";
            
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(query, GloblaVar.gConRem);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string alba = myReader[0].ToString();
                int aux = 0;
                if (System.Int32.TryParse(alba, out aux) == true)
                {
                    aux++;
                    resultado = aux.ToString();
                }
            }
            myReader.Close();
            
            return resultado;
        }

        public string CogerAlbaranPorCodigo(string comCpa, string anyo)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";
            try
            {
                string sql = @"SELECT ComCpa, Anyo, ProCod, ComCfa, FpaCod, comcpo, comctf, comcim, Portes, Colla FROM COMALB_CABE WHERE ComCpa=@ComCpa and Anyo=@Anyo";

                using(SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ComCpa", comCpa);
                    cmd.Parameters.AddWithValue("@Anyo", anyo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        resp = CargarAlbaran(reader);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

            return resp;

        }

        public string CogerAlbaranYLineasPorCodigo(string comCpa, string anyo)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";
            try
            {
                string sql = @"SELECT ComCpa, Anyo, ProCod, ComCfa, FpaCod, comcpo, comctf, comcim, Portes, Colla FROM COMALB_CABE WHERE ComCpa=@ComCpa and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ComCpa", comCpa);
                    cmd.Parameters.AddWithValue("@Anyo", anyo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        resp = CargarAlbaran(reader);
                        if(resp == "")
                        {
                            clase_linea_albcom linea = new clase_linea_albcom();
                            this.lineas = linea.CogerLineasAlbaranPorCodigo(comCpa, anyo);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
                //MessageBox.Show(ex.Message);
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

            return resp;

        }

        public string PonerAlbaranFacturado(string comCpa, string anyo)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";

            try
            {               
                string sqlUpdate = @"UPDATE COMALB_CABE SET Facturado=1 WHERE ComCpa=@ComCpa and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ComCpa", comCpa);
                    cmd.Parameters.AddWithValue("@Anyo", anyo);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "El albarán " + comCpa + " no se ha podido poner como facturado\n";
                   
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;
        }

        private string CargarAlbaran(IDataReader reader)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";

            try
            {
                this.ComCpa = Convert.ToString(reader["ComCpa"]);
                this.Anyo = Convert.ToString(reader["Anyo"]);
                this.ProCod = Convert.ToString(reader["ProCod"]);
                this.ComCfa = Convert.ToString(reader["ComCfa"]);
                this.FpaCod = Convert.ToString(reader["FpaCod"]);
                this.Comcpo = Convert.ToString(reader["comcpo"]);
                this.comctf = Convert.ToString(reader["comctf"]);
                this.comcim = Convert.ToString(reader["comcim"]);
                this.Portes = Convert.ToString(reader["Portes"]);
                this.Colla = Convert.ToString(reader["Colla"]);

            }
            catch (Exception ex)
            {
                resp = ex.Message;
                GloblaVar.gUTIL.ATraza(gIdent + ex.Message);
            }

            return resp;

        }
       
    }
}
