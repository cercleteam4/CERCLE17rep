using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace cercle17
{
    public class clase_partidas
    {
        public string Partida { get; set; }
        public string Anyo { get; set; }
        public string AlmMay { get; set; }
        public string Ref { get; set; }
        public string Pais { get; set; }
        public string ZCaptura { get; set; }
        public string PDesembarco { get; set; }
        public string FDesembarco { get; set; }
        public string FExped { get; set; }
        public string FCaptura { get; set; }
        public string Stock { get; set; }
        public string ArtCod { get; set; }
        public string ProCod { get; set; }
        public string FElaboracion { get; set; }
        public string FCaducidad { get; set; }
        public string StockInicial { get; set; }
        public string ArtePesca { get; set; }
        public string Obtencion { get; set; }
        public string Presentacion { get; set; }
        public string Matricula { get; set; }
        public string Barco { get; set; }
        public string FCua { get; set; }
        public string AlbCompra { get; set; }
        public string FCompra { get; set; }
        public string PExpedidor1 { get; set; }
        public string PExpedidor2 { get; set; }
        public string PExpedidor3 { get; set; }
        public string NRS1 { get; set; }
        public string NRS2 { get; set;}
        public string NRS3 { get; set; }
        public string CExped1 { get; set; }
        public string CExped2 { get; set; }
        public string CExped3 { get; set; }
        public string CondEsps { get; set; }

        public string Insertar (ref SqlTransaction sqlTran)
        {
            string resp = "";
            
            try
            {
                resp = CogerDatosControl(ref sqlTran);
                if(resp == "")
                {
                    this.Partida = ObtenerNumeroPartida(this.Anyo, this.AlmMay, ref sqlTran);

                    if(string.IsNullOrEmpty(this.Ref))
                    {
                        this.Ref = "A" + this.Anyo.Substring(2) + "/" + this.Partida;
                    }

                    string sqlPartida = @"INSERT INTO PARTIDAS (Partida, Anyo, AlmMay, AlbCompra, FCompra, Ref, ArtCod, ProCod, StockInicial, ArtePesca, Presentacion, Obtencion, FCaducidad, FDesembarco, FElaboracion, PDesembarco, Matricula,Barco, ZCaptura, FCaptura, Pais, PExpedidor1, PExpedidor2, CExped1, CExped2, CExped3, CondEsps, NRS1, NRS2, NRS3)  
                                      VALUES (@Partida, @Anyo, @AlmMay, @AlbCompra, @FCompra, @Ref, @ArtCod, @ProCod, @StockInicial, @ArtePesca, @Presentacion, @Obtencion, @FCaducidad, @FDesembarco, @FElaboracion, @PDesembarco, @Matricula, @Barco, @ZCaptura, @FCaptura, @Pais, @PExpedidor1, @PExpedidor2, @CExped1, @CExped2, @CExped3, @CondEsps, @NRS1, @NRS2, @NRS3)";

                    using (SqlCommand cmd = new SqlCommand(sqlPartida, GloblaVar.gConRem, sqlTran))
                    {
                        cmd.Parameters.AddWithValue("@Partida", this.Partida);
                        cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                        cmd.Parameters.AddWithValue("@AlmMay", this.AlmMay);
                        cmd.Parameters.AddWithValue("@AlbCompra", this.AlbCompra);
                        cmd.Parameters.AddWithValue("@FCompra", this.FCompra);
                        cmd.Parameters.AddWithValue("@Ref", this.Ref);
                        cmd.Parameters.AddWithValue("@ArtCod", this.ArtCod);
                        cmd.Parameters.AddWithValue("@ProCod", this.ProCod);
                        cmd.Parameters.AddWithValue("@StockInicial", this.StockInicial.Replace(",", "."));
                        cmd.Parameters.AddWithValue("@ArtePesca", this.ArtePesca);
                        cmd.Parameters.AddWithValue("@Presentacion", this.Presentacion);
                        cmd.Parameters.AddWithValue("@Obtencion", this.Obtencion);
                        cmd.Parameters.AddWithValue("@FCaducidad", this.FCaducidad == "" ? (object)DBNull.Value : this.FCaducidad);
                        cmd.Parameters.AddWithValue("@FDesembarco", this.FDesembarco);
                        cmd.Parameters.AddWithValue("@FElaboracion", this.FElaboracion == "" ? (object)DBNull.Value : this.FElaboracion);
                        cmd.Parameters.AddWithValue("@PDesembarco", this.PDesembarco);
                        cmd.Parameters.AddWithValue("@Matricula", this.Matricula);
                        if (this.Matricula == "-") { this.Barco = "AGRUP. BARCOS"; }
                        if (this.Barco  == null) { cmd.Parameters.AddWithValue("@Barco", "AGRUP. BARCOS"); } else { cmd.Parameters.AddWithValue("@Barco", this.Barco); }
                        cmd.Parameters.AddWithValue("@ZCaptura", this.ZCaptura);
                        cmd.Parameters.AddWithValue("@FCaptura", this.FCaptura);
                        cmd.Parameters.AddWithValue("@Pais", this.Pais);
                        cmd.Parameters.AddWithValue("@PExpedidor1", this.PExpedidor1);
                        cmd.Parameters.AddWithValue("@PExpedidor2", this.PExpedidor2);
                        //cmd.Parameters.AddWithValue("@PExpedidor3", this.PExpedidor3);
                        cmd.Parameters.AddWithValue("@NRS1", this.NRS1);
                        cmd.Parameters.AddWithValue("@NRS2", this.NRS2);
                        cmd.Parameters.AddWithValue("@NRS3", this.NRS3);
                        cmd.Parameters.AddWithValue("@CExped1", this.CExped1);                  //Añadidos 3.52
                        cmd.Parameters.AddWithValue("@CExped2", this.CExped2);                  //Añadidos 3.52
                        cmd.Parameters.AddWithValue("@CExped3", this.CExped3);                  //Añadidos 3.52
                        cmd.Parameters.AddWithValue("@CondEsps", this.CondEsps);                //Añadidos 3.52

                        resp = cmd.ExecuteNonQuery() == 1 ? "" : "La partida no se ha podido insertar";

                    }

                }
                else
                {
                    resp = "Error al cargar los datos de CONTROL:\n\n" + resp;
                }
                

            }
            catch (Exception ex)
            {                
                GloblaVar.gUTIL.ATraza("clase_partidas.Insertar. " + ex.Message);
                resp = ex.Message;
            }

            return resp;

        }

        //Para modificar una Partida primero eliminamos la partida y luego la insertamos
        public string Modificar()
        {
            string resp = "";

            try
            {            

                resp = Eliminar();
                if(resp == "")
                {
                    resp = CogerDatosControl();
                    if (resp == "")
                    {

                        string nuevoStock = RecalcularStock();

                        string sqlPartida = @"INSERT INTO PARTIDAS (Partida, Anyo, AlmMay,AlbCompra,FCompra, Ref, Stock, ArtCod, ProCod, StockInicial, ArtePesca, Presentacion, Obtencion, FCaducidad, FDesembarco, FElaboracion, PDesembarco, Matricula, FCua, ZCaptura, FCaptura, Pais, PExpedidor1, PExpedidor2,CExped1,CExped2,CExped3,CondEsps, NRS1, NRS2, NRS3)  
                                          VALUES (@Partida, @Anyo, @AlmMay,@AlbCompra,@Fcompra, @Ref, @Stock, @ArtCod, @ProCod, @StockInicial, @ArtePesca, @Presentacion, @Obtencion, @FCaducidad, @FDesembarco, @FElaboracion, @PDesembarco, @Matricula, @FCua, @ZCaptura, @FCaptura, @Pais, @PExpedidor1, @PExpedidor2,@CExped1,@CExped2,@CExped3,@CondEsps, @NRS1, @NRS2, @NRS3)";

                        using (SqlCommand cmd = new SqlCommand(sqlPartida, GloblaVar.gConRem))
                        {
                            cmd.Parameters.AddWithValue("@Partida", this.Partida);
                            cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                            cmd.Parameters.AddWithValue("@AlmMay", this.AlmMay);
                            cmd.Parameters.AddWithValue("@AlbCompra", this.AlbCompra);
                            cmd.Parameters.AddWithValue("@FCompra", this.FCompra);
                            cmd.Parameters.AddWithValue("@Ref", this.Ref);
                            cmd.Parameters.AddWithValue("@Stock", nuevoStock.Replace(",", "."));
                            cmd.Parameters.AddWithValue("@ArtCod", this.ArtCod);
                            cmd.Parameters.AddWithValue("@ProCod", this.ProCod);
                            cmd.Parameters.AddWithValue("@StockInicial", this.StockInicial.Replace(",", "."));
                            cmd.Parameters.AddWithValue("@ArtePesca", this.ArtePesca);
                            cmd.Parameters.AddWithValue("@Presentacion", this.Presentacion);
                            cmd.Parameters.AddWithValue("@Obtencion", this.Obtencion);
                            cmd.Parameters.AddWithValue("@FCaducidad", this.FCaducidad == "" ? (object)DBNull.Value : this.FCaducidad);
                            cmd.Parameters.AddWithValue("@FDesembarco", this.FDesembarco);
                            cmd.Parameters.AddWithValue("@FElaboracion", this.FElaboracion == "" ? (object)DBNull.Value : this.FElaboracion);
                            cmd.Parameters.AddWithValue("@PDesembarco", this.PDesembarco);
                            cmd.Parameters.AddWithValue("@Matricula", this.Matricula);
                            if (this.FCua == "") { cmd.Parameters.AddWithValue("@FCua", DBNull.Value); } else { cmd.Parameters.AddWithValue("@FCua", this.FCua); }
                            //cmd.Parameters.AddWithValue("@FCua", this.FCua);
                            cmd.Parameters.AddWithValue("@ZCaptura", this.ZCaptura);
                            cmd.Parameters.AddWithValue("@FCaptura", this.FCaptura);
                            cmd.Parameters.AddWithValue("@Pais", this.Pais);
                            cmd.Parameters.AddWithValue("@PExpedidor1", this.PExpedidor1);
                            cmd.Parameters.AddWithValue("@PExpedidor2", this.PExpedidor2);
                            //cmd.Parameters.AddWithValue("@PExpedidor3", this.PExpedidor3);
                            cmd.Parameters.AddWithValue("@NRS1", this.NRS1);
                            cmd.Parameters.AddWithValue("@NRS2", this.NRS2);
                            cmd.Parameters.AddWithValue("@NRS3", this.NRS3);
                            cmd.Parameters.AddWithValue("@CExped1", this.CExped1);
                            cmd.Parameters.AddWithValue("@CExped2", this.CExped2);
                            cmd.Parameters.AddWithValue("@CExped3", this.CExped3);
                            cmd.Parameters.AddWithValue("@CondEsps", this.CondEsps );
                            resp = cmd.ExecuteNonQuery() == 1 ? "" : "La partida no se ha podido insertar";

                        }
                    }
                    else
                    {
                        resp = "Error al cargar los datos de CONTROL:\n\n" + resp;
                    }
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;                
            }

            return resp;
        }

        private string CogerDatosControl(ref SqlTransaction sqlTran)
        {
            string resp = "";

            try
            {

                string sql = @"SELECT ConRsa1, ConRsa2, ConRsa3 FROM CONTROL";

                using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem, sqlTran))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        this.NRS1 = Convert.ToString(reader["ConRsa1"]);
                        this.NRS2 = Convert.ToString(reader["ConRsa2"]);
                        this.NRS3 = Convert.ToString(reader["ConRsa3"]);
                    }

                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;                
            }

            return resp;
        }

        private string CogerDatosControl()
        {
            string resp = "";

            try
            {

                string sql = @"SELECT ConRsa1, ConRsa2, ConRsa3 FROM CONTROL";

                using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        this.NRS1 = Convert.ToString(reader["ConRsa1"]);
                        this.NRS2 = Convert.ToString(reader["ConRsa2"]);
                        this.NRS3 = Convert.ToString(reader["ConRsa3"]);
                    }

                    reader.Close();
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
                string sqlUpdate = @"UPDATE PARTIDAS SET ProCod=@ProCod WHERE Partida=@Partida and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ProCod", proCod);
                    cmd.Parameters.AddWithValue("@Partida", this.Partida);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "El código de proveedor no se ha podido modificar en la partida";

                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;

        }

        public string Eliminar()
        {
            string resp = "";

            try
            {
                //string sqlDelete = @"DELETE FROM PARTIDAS WHERE Ref=@Ref";
                string sqlDelete = @"DELETE FROM PARTIDAS WHERE Partida=@Partida and Anyo=@Anyo";

                using (SqlCommand cmd = new SqlCommand(sqlDelete, GloblaVar.gConRem))
                {
                    //cmd.Parameters.AddWithValue("@Ref", this.Ref);
                    cmd.Parameters.AddWithValue("@Partida", this.Partida);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "La partida no se ha podido eliminar";
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;
        }

        //public string Eliminar(string referencia, ref SqlTransaction sqlTran)
        public string Eliminar(string parti, string año, ref SqlTransaction sqlTran)
        {
            string resp = "";

            try
            {
                string sqlDelete = @"DELETE FROM PARTIDAS WHERE Partida=@Partida and Anyo=@Anyo";
                GloblaVar.gUTIL.ATraza("clase_partidas.Eliminar " +sqlDelete );

                using (SqlCommand cmd = new SqlCommand(sqlDelete, GloblaVar.gConRem, sqlTran))
                {
                    //cmd.Parameters.AddWithValue("@Ref", referencia);
                    cmd.Parameters.AddWithValue("@Partida", parti);
                    cmd.Parameters.AddWithValue("@Anyo", año);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "La partida no se ha podido eliminar";
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }

            return resp;
        }

        //public clase_partidas CogerPartidaPorRef(string referencia)
        public clase_partidas CogerPartida(string parti, string año)
        {
            clase_partidas partida = new clase_partidas();

            string sql = @"SELECT Partida, Anyo, AlmMay, AlbCompra, FCompra, Ref, Stock, ArtCod, ProCod, StockInicial, ArtePesca, Presentacion, Obtencion, FCaducidad, FDesembarco, FElaboracion, PDesembarco, Matricula, FCua, ZCaptura, FCaptura, Pais, PExpedidor1, PExpedidor2, PExpedidor3, CondEsps 
                           FROM PARTIDAS WHERE Partida=@Partida and Anyo=@Anyo";

            using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
            {
                //cmd.Parameters.AddWithValue("@Ref", referencia);
                cmd.Parameters.AddWithValue("@Partida", parti);
                cmd.Parameters.AddWithValue("@Anyo", año);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    partida = CargarPartida(reader);
                }

                reader.Close();
            }


            return partida;

        }       

        public string ObtenerNumeroPartida(string año, string almMayorista, ref SqlTransaction sqlTran)
        {
            //obtener próximo número de partida
            string resultado = "1";

            string sql = "SELECT MAX(Partida) FROM PARTIDAS WHERE Anyo=@Anyo and AlmMay=@AlmMay";

            using (SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem, sqlTran))
            {
                cmd.Parameters.AddWithValue("@Anyo", año);
                cmd.Parameters.AddWithValue("@AlmMay", almMayorista);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    string parti = reader[0].ToString();

                    if (System.Int32.TryParse(parti, out int aux) == true)
                    {
                        aux++;
                        resultado = aux.ToString();
                    }
                }

                reader.Close();

            }           

            return resultado;
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

            nuevoStock = Funciones.Resta(this.StockInicial, nuevoStock);

            return nuevoStock;

        }       

        private clase_partidas CargarPartida(IDataReader reader)
        {
            clase_partidas partida = new clase_partidas();

            partida.Partida = Convert.ToString(reader["Partida"]);
            partida.Anyo = Convert.ToString(reader["Anyo"]);
            partida.AlmMay = Convert.ToString(reader["AlmMay"]);
            partida.AlbCompra = Convert.ToString(reader["AlbCompra"]);
            partida.FCompra = Convert.ToString(reader["FCompra"]);
            partida.Ref = Convert.ToString(reader["Ref"]);
            partida.Stock = Convert.ToString(reader["Stock"]);
            partida.PDesembarco = Convert.ToString(reader["PDesembarco"]);
            partida.FDesembarco = Convert.ToString(reader["FDesembarco"]);
            partida.ArtCod = Convert.ToString(reader["ArtCod"]);
            partida.ProCod = Convert.ToString(reader["ProCod"]);
            partida.FElaboracion = Convert.ToString(reader["FElaboracion"]);
            partida.FCaducidad = Convert.ToString(reader["FCaducidad"]);
            partida.StockInicial = Convert.ToString(reader["StockInicial"]);
            partida.ArtePesca = Convert.ToString(reader["ArtePesca"]);
            partida.Obtencion = Convert.ToString(reader["Obtencion"]);
            partida.Presentacion = Convert.ToString(reader["Presentacion"]);
            partida.Matricula = Convert.ToString(reader["Matricula"]);
            partida.FCua = Convert.ToString(reader["FCua"]);
            partida.ZCaptura = Convert.ToString(reader["ZCaptura"]);
            partida.FCaptura = Convert.ToString(reader["FCaptura"]);
            partida.Pais = Convert.ToString(reader["Pais"]);
            partida.PExpedidor1 = Convert.ToString(reader["PExpedidor1"]);
            partida.PExpedidor2 = Convert.ToString(reader["PExpedidor2"]);
            partida.PExpedidor3 = Convert.ToString(reader["PExpedidor3"]);
            partida.CondEsps = Convert.ToString(reader["CondEsps"]);            
            
            return partida;

        }

    }
}
