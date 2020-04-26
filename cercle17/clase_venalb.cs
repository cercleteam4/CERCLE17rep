using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    public class clase_venalb
    {
        private string venany;
        public string Anyo
        {
            get { return venany; }
            set { venany = value; }
        }

        private string detnuevo;
        public string Nuevo
        {
            get { return detnuevo; }
            set { detnuevo = value; }
        }

        private string venalb;
        public string Albaran
        {
            get { return venalb; }
            set { venalb = value; }
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

        private string ventve;
        public string TipoVenta
        {
            get { return ventve; }
            set { ventve = value; }
        }

        private bool marcador;
        public bool Cobrar
        {
            get { return marcador; }
            set { marcador = value; }
        }

        private string idpagare;
        public string Pagare
        {
            get { return idpagare; }
            set { idpagare = value; }
        }
    }
}
