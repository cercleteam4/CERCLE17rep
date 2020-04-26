using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public class clase_ABONG_CABE
    {
        public clase_ABONG_LINEAS[] line = new clase_ABONG_LINEAS[5];
        private string sQ = "";


        private Int32 albaran;
        public Int32 Albaran
        {
            get { return albaran; }
            set { albaran = value; }
        }
        private Int32 anyo;
        public Int32 Anyo
        {
            get { return anyo; }
            set { anyo = value; }
        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                anyo = fecha.Year;
            }
        }
        private Int32 detcod;
        public Int32 DetCod
        {
            get { return detcod; }
            set
            {
                detcod = value;
                detnom = Funciones.DameNomDet(detcod.ToString());
                if (detnom != "NO EXISTE" && detnom != "CÓDIGO ERRÓNEO") { detnif = GloblaVar.gDETBUSCADO.DetNif; }
                if (detnom != "NO EXISTE" && detnom != "CÓDIGO ERRÓNEO") { detdireccion = GloblaVar.gDETBUSCADO.detvia; }
                if (detnom != "NO EXISTE" && detnom != "CÓDIGO ERRÓNEO") { detmun = GloblaVar.gDETBUSCADO.detmun; }
                if (detnom != "NO EXISTE" && detnom != "CÓDIGO ERRÓNEO") { detrec = GloblaVar.gDETBUSCADO.DetRec; }
                if (detrec == "N") { re1 = 0; }
            }
        }

        private string detrec;
        public string DetRec
        {
            get { return detrec; }
        }

        private string detnif;
        public string DetNif
        {
            get { return detnif; }
        }
        private string detdireccion;
        public string DetDireccion
        {
            get { return detdireccion; }
        }
        private string detnom;
        public string DetNom
        {
            get { return detnom; }
        }

        private string detmun;
        public string DetMun
        {
            get { return detmun; }
        }
        private String ventve;
        public String VenTve
        {
            get { return ventve; }
            set { ventve = value; }
        }
        private String tipo;
        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private String estado;
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private Decimal bi1;
        public Decimal BI1
        {
            get
            {

                return bi1;
            }
            //set { bi1 = value; }
        }
        private Decimal iva1;
        public Decimal IVA1
        {
            get
            {

                return iva1;
            }
            //set { iva1 = value; }
        }
        private Decimal re1;
        public Decimal RE1
        {
            get
            {
                return re1;
            }
        }
        private Decimal bi2;
        public Decimal BI2
        {
            get
            {
                return bi2;
            }
            //set { bi2 = value; }
        }
        private Decimal iva2;
        public Decimal IVA2
        {
            get
            {
                return iva2;
            }
            //set { iva2 = value; }
        }
        private Decimal re2;
        public Decimal RE2
        {
            get
            {
                return re2;
            }
        }

        private Decimal bi3;
        public Decimal BI3
        {
            get
            {
                return bi3;
            }
            //set { bi3 = value; }
        }
        private Decimal iva3;
        public Decimal IVA3
        {
            get
            {
                return iva3;
            }
        }
        private Decimal re3;
        public Decimal RE3
        {
            get
            {
                return re3;
            }
        }
        private Decimal bi4;
        public Decimal BI4
        {
            get
            {
                return bi4;
            }
            set { bi4 = value; }
        }
        private Decimal iva4;
        public Decimal IVA4
        {
            get
            {
                return iva4;
            }
        }
        private Decimal re4;
        public Decimal RE4
        {
            get
            {
                return re4;
            }
        }
        private Decimal total;
        public Decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                AjustaIVAs();
            }
        }
        private int numlineas;
        public int NumLineas
        {
            get
            {
                return numlineas;
            }
        }

        private int idvendedor;
        public int IdVendedor
        {
            get { return idvendedor; }
            set { idvendedor = value; }
        }

        public int? RectificaAlb { get; set; }
        public int? RectificaAnyoAlb { get; set; }
        public int? RectificaFact { get; set; }
        public int? RectificaAnyoFact { get; set; }
        public string RectificaSerieFact { get; set; }

         


        #region methods
        public bool GrabaAlbaran()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            //GlobalVar.gUTIL.CartelTraza("ENTRADA EN FormRendimientosTipo");
            bool respuesta = false;
            try
            {

                for (int i = 1; i < 5; ++i)
                {
                    line[i].Albaran = albaran;
                    line[i].Anyo = anyo;
                    line[i].Linea = i;
                    if (line[i].GrabarL())
                    {
                        GloblaVar.gUTIL.ATraza(gIdent + " Linea " + i.ToString() + " GRABADA OK");
                    }

                };
                //Supuestamente aquí ya se deben haber grabado las lineas. Ahora toca la cabecera
                sQ = "INSERT INTO ABONG_CABE (Albaran,Anyo,DetCod,Fecha,BI1,IVA1,RE1,Total,IdVendedor) VALUES (";
                sQ += albaran.ToString() + ",";
                sQ += anyo.ToString() + ",";
                sQ += detcod.ToString() + ",";
                sQ += "'" + fecha + "',";
                sQ += bi1.ToString("##0.00").Replace(",", ".") + ",";
                sQ += iva1.ToString("##0.00").Replace(",", ".") + ",";
                sQ += re1.ToString("##0.00").Replace(",", ".") + ",";
                //sQ += bi1.ToString("##0.00").Replace(",", ".") + ",";
                //sQ += iva1.ToString("##0.00").Replace(",", ".") + ",";
                //sQ += re1.ToString("##0.00").Replace(",", ".") + ",";
                sQ += total.ToString("##0.00").Replace(",", ".") + ",";
                sQ += GloblaVar.gIdVendedor + ")";
                Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
                //Albarán Grabado. Ahora crearemos la Imagen
                clase_ImagenAlbaran Im_Alb = new clase_ImagenAlbaran();
                Im_Alb.NumAlbaran = albaran.ToString();
                Im_Alb.Año = anyo.ToString();
                Im_Alb.ComponAlbaran1();

                respuesta = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                //rst.Close();
                return respuesta;
            }

        }  //public bool GrabaAlbaran

        public bool CargaAlbaran(string Alb, string Año)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            bool respuesta = false;
            try
            {
                sQ = "SELECT * FROM ABONG_CABE WHERE Albaran=" + Alb + " AND Anyo=" + Año;
                SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                SqlDataReader rst = cmd.ExecuteReader();
                if (rst.Read())
                {
                    albaran = Convert.ToInt32(Alb);
                    anyo = Convert.ToInt32(Año);
                    fecha = Convert.ToDateTime(rst["Fecha"]);
                    detcod = Convert.ToInt32(rst["DetCod"]);
                    detnom = Funciones.DameNomDet(rst["DetCod"].ToString());
                    detdireccion = GloblaVar.gDETBUSCADO.detvia ;
                    detmun = GloblaVar.gDETBUSCADO.detmun ;
                    detnif = GloblaVar.gDETBUSCADO.DetNif;
                    detrec = GloblaVar.gDETBUSCADO.DetRec;
                    bi1 = Convert.ToDecimal(rst["BI1"]);
                    iva1 = Convert.ToDecimal(rst["IVA1"]);
                    if (detrec == "S") { re1 = Convert.ToDecimal(rst["RE1"]); } else { re1 = 0; }
                    total = Convert.ToDecimal(rst["Total"]);
                    RectificaAlb = rst["RectificaAlb"]==DBNull.Value? (int?) null : Convert.ToInt32(rst["RectificaAlb"]);
                    RectificaAnyoAlb = rst["RectificaAnyoAlb"] == DBNull.Value ? (int?)null : Convert.ToInt32(rst["RectificaAnyoAlb"]);
                    RectificaFact = rst["RectificaFact"] == DBNull.Value ? (int?)null : Convert.ToInt32(rst["RectificaFact"]);
                    RectificaAnyoFact = rst["RectificaAnyoFact"] == DBNull.Value ? (int?)null : Convert.ToInt32(rst["RectificaAnyoFact"]);
                    RectificaSerieFact = rst["RectificaSerieFact"].ToString();

                    //detpro = GlobalVar.gDETBUSCADO.DetPro;
                }
                rst.Close();
                cmd.Dispose();
                rst.Close();
                sQ = "SELECT * FROM ABONG_LINEAS WHERE Albaran=" + Alb + " AND Anyo=" + Año;
                cmd = new SqlCommand(sQ, GloblaVar.gConRem);
                rst = cmd.ExecuteReader();
                int i = 1;
                while (rst.Read())
                {
                    line[i] = new clase_ABONG_LINEAS();
                    line[i].Albaran = albaran;
                    line[i].Anyo = anyo;
                    line[i].Fecha = Convert.ToDateTime(rst["Fecha"]);
                    line[i].ArtCod = Convert.ToInt32(rst["ArtCod"].ToString());
                    line[i].Cajas = Convert.ToInt32(rst["Cajas"]);
                    line[i].Kilos = Convert.ToDecimal(rst["Kilos"]);
                    line[i].Precio = Convert.ToDecimal(rst["Precio"]);
                    line[i].Importe = Convert.ToDecimal(rst["Importe"]);
                    i++;
                }

                rst.Close();
                numlineas = i;
                return true;
            }
            catch (Exception ex)
            {
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                return respuesta;
            }

        }   //public bool CargaAlbaran(string Alb,string Año)
        public void AjustaIVAs()
        {
            bi1 = iva1 = re1 = bi2 = iva2 = re2 = bi3 = iva3 = re3 = bi4 = iva4 = re4 = 0;
            for (int i = 1; i < 5; i++)
            {
                if (LCompleta(i))
                {
                    switch (line[i].TipoIva)
                    {
                        case "1":
                            bi1 = bi1 + line[i].Importe;
                            iva1 = iva1 + line[i].Importe * line[i].FactorIVA;
                            if (detrec == "S") { re1 = re1 + line[i].Importe * line[i].FactorRec; }
                            break;
                        case "2":
                            bi2 = bi2 + line[i].Importe;
                            iva2 = iva2 + line[i].Importe * line[i].FactorIVA;
                            if (detrec == "S") { re2 = re2 + line[i].Importe * line[i].FactorRec; }
                            break;
                        case "3":
                            bi3 = bi3 + line[i].Importe;
                            iva3 = iva3 + line[i].Importe * line[i].FactorIVA;
                            if (detrec == "S") { re3 = re3 + line[i].Importe * line[i].FactorRec; }
                            break;
                        case "4":
                            bi4 = bi4 + line[i].Importe;
                            iva4 = iva4 + line[i].Importe * line[i].FactorIVA;
                            if (detrec == "S") { re4 = re4 + line[i].Importe * line[i].FactorRec; }
                            break;
                    }

                }
            }  //for (int i = 1; i < 5; i++)

        }  //private void AjustaIVAs()

        private bool LCompleta(int NLinea)
        {
            //será true cuando una linea esté completa
            if (line[NLinea].ArtCod > 0 && line[NLinea].Kilos > 0 && line[NLinea].Precio >= 0)
            { return true; }
            else
            { return false; }
        }  //    private bool LCompleta(int NLinea)
        #endregion

    }
}
