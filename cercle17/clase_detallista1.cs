using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cercle17
{
    public class clase_detallista1
    {
        public string DetCod { get; set; }
        public string DetNom { get; set; }
        public string DetCpf;
        public string DetCpm;
        public string FPVCorreo;
        public string DetEMail;
        public string FPVImpresion;
        public string detvia;
        public string detmun;
        public string DetCop;
        public string DetNif;
        public string DetRec { get; set; }
        public string SubCta { get; set; }

        public bool CargaDatos(string Codigo)
        {
            string gIdent = "clase_detallista.CargaDatos ";
            bool respuesta = false;
            try
            {
                if (Codigo == "") { Codigo = DetCod; }
                string sQ = "SELECT * FROM DETALLISTAS WHERE DetCod=" + Codigo;
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                rst.Read();

                if (rst.HasRows)
                {
                    DetCod = rst["DetCod"].ToString();
                    DetNom = rst["DetNom"].ToString();
                    DetCpf = "";
                    DetEMail = rst["DetEMail"].ToString();
                    detvia = rst["detvia"].ToString();
                    DetCop = rst["DetCop"].ToString();
                    detmun = rst["DetMun"].ToString();
                    DetNif = rst["DetNif"].ToString();
                    SubCta = rst["SubCta"].ToString();
                    respuesta = true;
                }
                rst.Close();
                cmd.Dispose();
                return respuesta;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                return respuesta;
            }

        }  //clase_detallista.CargaDatos
    }
}
