using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cercle17
{
    public class clase_pagare
    {
        private string identifica;
        public string IdPagare
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

        private string nombre;
        public string NombreCliente
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string venfec;
        public string Fecha
        {
            get { return venfec; }
            set { venfec = value; }
        }

        private string ventot;
        public string Vencimiento
        {
            get { return ventot; }
            set { ventot = value; }
        }

        private string ventve;
        public string Cobrado
        {
            get { return ventve; }
            set { ventve = value; }
        }

        private string total;
        public string Importe
        {
            get { return total; }
            set { total = value; }
        }

        private string fcobro;
        public string FechaCobro
        {
            get { return fcobro; }
            set { fcobro = value; }
        }

        private bool marcador;
        public bool Cobrar
        {
            get { return marcador; }
            set { marcador = value; }
        }

        private string texto;
        public string Observaciones
        {
            get { return texto; }
            set { texto = value; }
        }
    }
}

