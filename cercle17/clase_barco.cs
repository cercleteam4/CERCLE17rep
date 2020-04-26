using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    public class clase_barco
    {
        private string artcod;
        public string Matricula
        {
            get { return artcod; }
            set { artcod = value; }
        }

        private string artdes;
        public string Nombre
        {
            get { return artdes; }
            set { artdes = value; }
        }

        private string codpro;
        public string ProCod
        {
            get { return codpro; }
            set { codpro = value; }
        }

        private string nomprov;
        public string Proveedor
        {
            get { return nomprov; }
            set { nomprov = value; }
        }
    }
}
