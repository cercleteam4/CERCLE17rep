using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    public class detalle_linea_cobro
    {
        private string identifica;
        public string Cobro
        {
            get { return identifica; }
            set { identifica = value; }
        }

        private string detcod;
        public string Detallista
        {
            get { return detcod; }
            set { detcod = value; }
        }

        private string idfactura;
        public string Factura
        {
            get { return idfactura; }
            set { idfactura = value; }
        }

        private string campo1;
        public string Importe
        {
            get { return campo1; }
            set { campo1 = value; }
        }

        private string campo2;
        public string Medio
        {
            get { return campo2; }
            set { campo2 = value; }
        }

        private string campo3;
        public string Observaciones
        {
            get { return campo3; }
            set { campo3 = value; }
        }
    }
}
