using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    class clase_deuda
    {
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
        public string Importe
        {
            get { return texto; }
            set { texto = value; }
        }

        private string valor;
        public string Saldo
        {
            get { return valor; }
            set { valor = value; }
        }

        private bool marcador;
        public bool Cobrar
        {
            get { return marcador; }
            set { marcador = value; }
        }

        private string clase;
        public string Tipo
        {
            get { return clase; }
            set { clase = value; }
        }
    }
}
