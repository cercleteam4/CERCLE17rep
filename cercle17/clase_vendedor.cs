using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    class clase_vendedor
    {
        private string ident;
        public string IdVendedor
        {
            get { return ident; }
            set { ident = value; }
        }

        private string nombre;
        public string Vendedor
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string telef;
        public string Tfno
        {
            get { return telef; }
            set { telef = value; }
        }

        private string almacen;
        public string AlmMay
        {
            get { return almacen; }
            set { almacen = value; }
        }

        private string nivel;
        public string Perfil
        {
            get { return nivel; }
            set { nivel = value; }
        }

        private string terminal;
        public string Terminales
        {
            get { return terminal; }
            set { terminal = value; }
        }

        private string path;
        public string Foto
        {
            get { return path; }
            set { path = value; }
        }
    }
}
