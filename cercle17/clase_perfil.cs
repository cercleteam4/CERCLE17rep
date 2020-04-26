using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    class clase_perfil
    {
        private string ident;
        public string Perfil
        {
            get { return ident; }
            set { ident = value; }
        }

        private bool permiso1;
        public bool Compras
        {
            get { return permiso1; }
            set { permiso1 = value; }
        }

        private bool permiso2;
        public bool TPV
        {
            get { return permiso2; }
            set { permiso2 = value; }
        }

        private bool permiso3;
        public bool Cobros
        {
            get { return permiso3; }
            set { permiso3 = value; }
        }

        private bool permiso4;
        public bool Caja
        {
            get { return permiso4; }
            set { permiso4 = value; }
        }

        private bool permiso5;
        public bool Cuadres
        {
            get { return permiso5; }
            set { permiso5 = value; }
        }

        private bool permiso6;
        public bool Mayoristas
        {
            get { return permiso6; }
            set { permiso6 = value; }
        }
    }
}
