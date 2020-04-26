using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cercle17
{
    class clase_factcom
    {
        //Facturas de compras (FACTC_CABE)
        public clase_factcom()
        {
            this.lineas = new List<clase_linea_factcom>();   
        }
        public string Factura { get; set; }
        public string Anyo { get; set; }
        public string Serie { get; set; }
        public string SubSerie { get; set; }
        public string FechaEmision { get; set; }
        public string ProCod { get; set; }
        public string ProNom { get; set; }
        public string SubCuenta { get; set; }
        public string BI1 { get; set; }
        public string IVA1 { get; set; }
        public string RE1 { get; set; }
        public string BI2 { get; set; }
        public string IVA2 { get; set; }
        public string RE2 { get; set; }
        public string BI3 { get; set; }
        public string IVA3 { get; set; }
        public string RE3 { get; set; }
        public string BI4 { get; set; }
        public string IVA4 { get; set; }
        public string RE4 { get; set; }
        public string ImpteFactura { get; set; }
        public string ImptePagado { get; set; }
        public string ImptePendiente { get; set; }
        public string FechaPago { get; set; }
        public string FechaContab { get; set; }
        public string Observaciones { get; set; }
        public string TextoPie { get; set; }
        public string TextoCabe { get; set; }
        public string IdApunte { get; set; }
        public string ProNumFact { get; set; }
        public string ProFechaFact { get; set; }

        public List<clase_linea_factcom> lineas { get; set; }

        public string Insertar()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            string resp = "";

            try
            {
                this.Factura = ObtenerNumeroFactura(this.Anyo, this.Serie);

                string sqlInsert = @"INSERT INTO FACTC_CABE (Factura, Anyo, Serie, FechaEmision, ProCod, BI1, IVA1, ImpteFactura, ImptePagado, ImptePendiente, Observaciones, TextoPie, TextoCabe, ProNumFact, ProFechaFact) 
                                     VALUES (@Factura, @Anyo, @Serie, @FechaEmision, @ProCod, @BI1, @IVA1, @ImpteFactura, @ImptePagado, @ImptePendiente, @Observaciones, @TextoPie, @TextoCabe, @ProNumFact, @ProFechaFact)";

                SqlTransaction sqlTran = GloblaVar.gConRem.BeginTransaction();
                GloblaVar.gUTIL.ATraza(gIdent + sqlInsert);
                using (SqlCommand cmd = new SqlCommand(sqlInsert, GloblaVar.gConRem, sqlTran))
                {
                    cmd.Parameters.AddWithValue("@Factura", this.Factura);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                    cmd.Parameters.AddWithValue("@Serie", this.Serie);
                    cmd.Parameters.AddWithValue("@FechaEmision", this.FechaEmision);
                    cmd.Parameters.AddWithValue("@ProCod", this.ProCod);
                    cmd.Parameters.AddWithValue("@BI1", this.BI1);
                    cmd.Parameters.AddWithValue("@IVA1", this.IVA1);                    
                    cmd.Parameters.AddWithValue("@ImpteFactura", this.ImpteFactura.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ImptePagado", this.ImptePagado.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ImptePendiente", this.ImptePendiente.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@Observaciones", this.Observaciones);
                    cmd.Parameters.AddWithValue("@TextoPie", this.TextoPie);
                    cmd.Parameters.AddWithValue("@TextoCabe", this.TextoCabe);                    
                    cmd.Parameters.AddWithValue("@ProNumFact", this.ProNumFact);
                    cmd.Parameters.AddWithValue("@ProFechaFact", this.ProFechaFact);

                    resp = cmd.ExecuteNonQuery() == 1 ? "" : "La factura no se ha podido insertar";
                }

                if (resp == "")
                {
                    int contLinea = 0;

                    foreach (clase_linea_factcom lineaFact in this.lineas)
                    {
                        contLinea++;

                        //Añadimos a la línea los datos que faltan
                        lineaFact.Factura = this.Factura;
                        lineaFact.Anyo = this.Anyo;
                        lineaFact.Serie = this.Serie;
                        lineaFact.LinF = contLinea.ToString();
                        //lineaFact.ComLpa = "N";
                        //lineaFact.comlcp = lineaAlb.ComLca;
                        //lineaFact.comlkp = lineaAlb.ComLki;
                        //lineaFact.ComLal = "1";
                        //lineaFact.Stock = lineaAlb.ComLki;
                        //lineaFact.Partida = lineaAlb.cPartida.Partida;
                        //lineaFact.Anyo = this.Anyo;
                        //lineaFact.Ref = lineaAlb.cPartida.Ref;
                        //lineaFact.AlmMay = "01";
                        //lineaFact.Facturado = false;

                        //Llamar al método insertar de la clase clase_linea_albcom
                        resp = lineaFact.Insertar(ref sqlTran);
                        if (resp != "")
                        {
                            //MessageBox.Show(resp);
                            GloblaVar.gUTIL.ATraza(gIdent + resp);
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

        private string ObtenerNumeroFactura(string anyo, string serie)
        {
            //obtener siguiente número de factura
            string resultado = "1";

            string query = "SELECT MAX(Factura) FROM FACTC_CABE WHERE (Anyo=" + anyo + " AND Serie='" + serie + "')";

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(query, GloblaVar.gConRem);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string fact = myReader[0].ToString();
                int aux = 0;
                if (System.Int32.TryParse(fact, out aux) == true)
                {
                    aux++;
                    resultado = aux.ToString();
                }
            }
            myReader.Close();

            return resultado;
        }






    }
    
}
