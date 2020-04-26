using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    public class clase_albaran
    {
        private bool marcador;
        public bool Facturar
        {
            get { return marcador; }
            set { marcador = value; }
        }

        private string venalb;
        public string Albaran
        {
            get { return venalb; }
            set { venalb = value; }
        }

        private string ventve;
        public string TV
        {
            get { return ventve; }
            set { ventve = value; }
        }

        private string anyo;
        public string Año
        {
            get { return anyo; }
            set { anyo = value; }
        }

        private string venfec;
        public string Fecha
        {
            get { return venfec; }
            set { venfec = value; }
        }

        private string ventot;
        public string Total
        {
            get { return ventot; }
            set { ventot = value; }
        }

        private string venbru;
        public string BI
        {
            get { return venbru; }
            set { venbru = value; }
        }

        private string veniva;
        public string IVA
        {
            get { return veniva; }
            set { veniva = value; }
        }

        private string venrec;
        public string Recargo
        {
            get { return venrec; }
            set { venrec = value; }
        }

        private string detcod;
        public string CodDetallista
        {
            get { return detcod; }
            set { detcod = value; }
        }

        private string detnom;
        public string NomDetallista
        {
            get { return detnom; }
            set { detnom = value; }
        }

        private string idcobro;
        public string NumCobro
        {
            get { return idcobro; }
            set { idcobro = value; }
        }

        private string fechacobro;
        public string FecCobro
        {
            get { return fechacobro; }
            set { fechacobro = value; }
        }

        private string subCuenta;
        public string SubCtaDetallista
        {
            get { return subCuenta; }
            set { subCuenta = value; }
        }
        private string perCentIva;
        public string PorcentajeIva
        {
            get { return perCentIva; }
            set { perCentIva = value; }
        }

    }
}
