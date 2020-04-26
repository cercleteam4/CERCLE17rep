using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    class clase_cuenta
    {
        private string tipo_cobro;
        public string Tipo
        {
            get { return tipo_cobro; }
            set { tipo_cobro = value; }
        }

        private string venalb;
        public string Codigo
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

        private string texto;
        public string Concepto
        {
            get { return texto; }
            set { texto = value; }
        }

        private string ventot;
        public string Importe
        {
            get { return ventot; }
            set { ventot = value; }
        }
        
        private string ejercicio;
        public string Anyo
        {
            get { return ejercicio; }
            set { ejercicio = value; }
        }
    }
}
