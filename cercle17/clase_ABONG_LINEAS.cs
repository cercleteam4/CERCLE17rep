using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace cercle17
{
    public class clase_ABONG_LINEAS
    {

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
        private Int32 linea;
        public Int32 Linea
        {
            get { return linea; }
            set { linea = value; }
        }
        private Int32 artcod;
        public Int32 ArtCod
        {
            get { return artcod; }
            set
            {
                artcod = value;
                artdes = Funciones.DameNomArt(artcod.ToString());
                //if (artdes != "NO EXISTE" && artdes != "CÓDIGO ERRÓNEO") { tipoiva = GlobalVar.gARTBUSCADO.TipoIva; }
                //if (artdes != "NO EXISTE" && artdes != "CÓDIGO ERRÓNEO") { nomcie = GlobalVar.gARTBUSCADO.NomCie; }
                ////Necesitamos averiguar factoriva y factorrec
                //Funciones.IVA_Fecha(fecha);
                //factoriva = GlobalVar.gTIVABUSCADO.IVA/100;
                //factorrec = GlobalVar.gTIVABUSCADO.Recargo/100;
            }
        }

        private string nomcie;
        public string NomCie
        {
            get { return nomcie; }
            set { nomcie = value; }
        }
        private Decimal factoriva;
        public Decimal FactorIVA
        {
            get { return factoriva; }
        }
        private Decimal factorrec;
        public Decimal FactorRec
        {
            get { return factorrec; }
        }

        private string artdes;
        public string Artdes
        {
            get { return artdes; }
            set { artdes = value; }
        }

        private Decimal cajas;
        public Decimal Cajas
        {
            get { return cajas; }
            set { cajas = value; }
        }
        private Decimal kilos;
        public Decimal Kilos
        {
            get { return kilos; }
            set
            {
                kilos = value;
                if (precio > 0)
                {
                    importe = kilos * precio;
                }
            }
        }
        private Decimal precio;
        public Decimal Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                if (kilos > 0)
                {
                    importe = kilos * precio;
                }
            }
        }
        private string tipoiva;
        public string TipoIva
        {
            get { return tipoiva; }
            set { tipoiva = value; }
        }
        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private Decimal importe;
        public Decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        #region methods
        public bool GrabarL()
        {
            bool respuesta = false;
            try
            {
                if (artcod > 0 && artdes != "" && kilos > 0 && precio > 0 && importe > 0)
                {
                    string sQ = "INSERT INTO ABONG_LINEAS (Albaran,Anyo,Linea,Fecha,ArtCod,Cajas,Kilos,Precio,Importe) VALUES (";
                    sQ += albaran.ToString() + ",";
                    sQ += anyo.ToString() + ",";
                    sQ += linea.ToString() + ",";
                    sQ += "'" + fecha.ToShortDateString() + "',";
                    sQ += artcod.ToString() + ",";
                    sQ += cajas.ToString() + ",";
                    sQ += kilos.ToString().Replace(",", ".") + ",";
                    sQ += precio.ToString().Replace(",", ".") + ",";
                    sQ += importe.ToString().Replace(",", ".") + ")";


                    Funciones.EjecutaNonQuery(sQ, GloblaVar.gConRem);
                    respuesta = true;
                }

                return respuesta;
            }
            catch (Exception ex)
            {

                GloblaVar.gUTIL.ATraza("clase_ABONG_LINEAS.GrabarL " + ex.Message );
                return false;
            }
        }
        #endregion
    }
}
