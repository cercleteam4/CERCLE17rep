using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cercle17
{
    class clase_linea_factcom
    {
        //Líneas de Facturas de compras (FACTC_LINEAS)
        public string Factura { get; set; }
        public string Anyo { get; set; }
        public string Serie { get; set; }
        public string LinF { get; set; }
        public string ComLpa { get; set; }
        public string AnyoAlb { get; set; }
        public string ComLnl { get; set; }
        public string ArtCod { get; set; }
        public string ComLca { get; set; }
        public string ComLki { get; set; }
        public string ComLpr { get; set; }
        public string ComTrz { get; set; }
        public string ComLim { get; set; }
        public string Partida { get; set; }
        public string PartAnyo { get; set; }
        public string PartAlm { get; set; }
        public string ArtDes { get; set; }

        public string Insertar(ref SqlTransaction sqlTran)
        {
            string resp = "";
            string sqlLinea = "";
                        
            sqlLinea = @"INSERT FACTC_LINEAS(Factura, Anyo, Serie, LinF, ComLpa, AnyoAlb, ComLnl, ArtCod, ComLca, ComLki, ComLpr, ComTrz, ComLim)
                         VALUES (@Factura, @Anyo, @Serie, @LinF, @ComLpa, @AnyoAlb, @ComLnl, @ArtCod, @ComLca, @ComLki, @ComLpr, @ComTrz, @ComLim) ";
           
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlLinea, GloblaVar.gConRem, sqlTran))
                {
                    cmd.Parameters.AddWithValue("@Factura", this.Factura);
                    cmd.Parameters.AddWithValue("@Anyo", this.Anyo);
                    cmd.Parameters.AddWithValue("@Serie", this.Serie);
                    cmd.Parameters.AddWithValue("@LinF", this.LinF);
                    cmd.Parameters.AddWithValue("@ComLpa", this.ComLpa);
                    cmd.Parameters.AddWithValue("@AnyoAlb", this.AnyoAlb);
                    cmd.Parameters.AddWithValue("@ComLnl", this.ComLnl);
                    cmd.Parameters.AddWithValue("@ArtCod", this.ArtCod);
                    cmd.Parameters.AddWithValue("@ComLca", this.ComLca);
                    cmd.Parameters.AddWithValue("@ComLki", this.ComLki.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComLpr", this.ComLpr.Replace(",", "."));
                    cmd.Parameters.AddWithValue("@ComTrz", this.ComTrz);
                    cmd.Parameters.AddWithValue("@ComLim", this.ComLim.Replace(",", "."));
                                        
                    resp = cmd.ExecuteNonQuery() >= 1 ? "" : "La línea de factura no se ha podido insertar";
                }
            }
            catch (Exception ex)
            {
                resp = ex.Message;
                GloblaVar.gUTIL.ATraza("clase_linea_factcom.Insertar--> " + ex.Message);
            }

            return resp;

        }

    }
}
