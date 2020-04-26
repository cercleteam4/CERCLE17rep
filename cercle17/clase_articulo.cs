using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace cercle17
{
    public class clase_articulo
    {
        public string ArtCod { get; set; }
        public string ArtDes { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public string EtiqOblig { get; set; }
        public string Obtencion { get; set; }
        public string Presentacion { get; set; }
        public string ArtePesca { get; set; }
        public string ZFao { get; set; }
        public string AnomCongel { get; set; }
        

       
        public string CargarDatosArticuloPorCod(string artCod)
        {
            string resp = "";

            try
            {
                string sql = @"SELECT ArtCod, ArtDes, Obtencion, Presentacion, ArtePesca, ZFao, AnomCongel FROM ARTICULOS WHERE ArtCod=@Artcod";

                using(SqlCommand cmd = new SqlCommand(sql, GloblaVar.gConRem))
                {
                    cmd.Parameters.AddWithValue("@ArtCod", artCod);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        this.ArtCod = Convert.ToString(reader["ArtCod"]);
                        this.ArtDes = Convert.ToString(reader["ArtDes"]);
                        this.Obtencion = Convert.ToString(reader["Obtencion"]);
                        this.Presentacion = Convert.ToString(reader["Presentacion"]);
                        this.ArtePesca = Convert.ToString(reader["ArtePesca"]);
                        this.ZFao = Convert.ToString(reader["ZFao"]);
                        this.AnomCongel = Convert.ToString(reader["AnomCongel"]);
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


    }
}
