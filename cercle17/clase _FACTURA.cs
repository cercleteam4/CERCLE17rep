using System;
//using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;

namespace cercle17
{
    public class clase__FACTURA
    {
       public clase_FACTURAS_LINEAS[] LineaF=new clase_FACTURAS_LINEAS[500];   //Creamos un array de Lineas que contendrá las lineas de la factura
       public ArrayList  Lista_Albs=new ArrayList();

        //class clase_FACTURA()
        //{
        //    //Este es el constructor de la clase que se ejecutará cada vez que se cree una instancia de la clase
        //    //No generaremos un número de factura porque si no
        //    //SqlCommand cmd=new SqlCommand("SELECT MAX(Factura) FROM FACTV_CABE WHERE Anyo=" +anyo +" AND Serie='" +serie +"'",GloblaVar.gConRem );
            
        //}
        
        #region Instance Properties

     private Int32 factura;
     public Int32 Factura
     { 
     get {return factura;}
     set {factura=value;} 
     }
     private Int32 anyo;
     public Int32 Anyo
     { 
     get {return anyo;}
     set {anyo=value;} 
     }
     private String serie;
     public String Serie
     { 
     get {return serie;}
     set {serie=value;} 
     }
     private String subserie;
     public String SubSerie
     { 
     get {return subserie;}
     set {subserie=value;} 
     }
     private DateTime fechaemision;
     public DateTime FechaEmision
     { 
     get {return fechaemision;}
     set {fechaemision=value;} 
     }
     private Int32 detcod;
     public Int32 DetCod
     { 
     get {return detcod;}
     set {detcod=value;} 
     }
     private String detnom;
     public String DetNom
     { 
     get {return detnom;}
     set {detnom=value;} 
     }
     private string subcuenta;
     public string SubCuenta
     { 
     get {return subcuenta;}
     set {subcuenta=value;} 
     }
     private Decimal bi1;
     public Decimal BI1
     { 
     get {return bi1;}
     set {bi1=value;} 
     }
     private Decimal iva1;
     public Decimal IVA1
     { 
     get {return iva1;}
     set {iva1=value;} 
     }
     private Decimal re1;
     public Decimal RE1
     { 
     get {return re1;}
     set {re1=value;} 
     }
     private Decimal bi2;
     public Decimal BI2
     { 
     get {return bi2;}
     set {bi2=value;} 
     }
     private Decimal iva2;
     public Decimal IVA2
     { 
     get {return iva2;}
     set {iva2=value;} 
     }
     private Decimal re2;
     public Decimal RE2
     { 
     get {return re2;}
     set {re2=value;} 
     }
     private Decimal bi3;
     public Decimal BI3
     { 
     get {return bi3;}
     set {bi3=value;} 
     }
     private Decimal iva3;
     public Decimal IVA3
     { 
     get {return iva3;}
     set {iva3=value;} 
     }
     private Decimal re3;
     public Decimal RE3
     { 
     get {return re3;}
     set {re3=value;} 
     }
     private Decimal bi4;
     public Decimal BI4
     { 
     get {return bi4;}
     set {bi4=value;} 
     }
     private Decimal iva4;
     public Decimal IVA4
     { 
     get {return iva4;}
     set {iva4=value;} 
     }
     private Decimal re4;
     public Decimal RE4
     { 
     get {return re4;}
     set {re4=value;} 
     }
     private Decimal imptefactura;
     public Decimal ImpteFactura
     { 
     get {return imptefactura;}
     set {imptefactura=value;} 
     }
     private Decimal imptecobrado;
     public Decimal ImpteCobrado
     { 
     get {return imptecobrado;}
     set {imptecobrado=value;} 
     }
     private Decimal imptependiente;
     public Decimal ImptePendiente
     { 
     get {return imptependiente;}
     set {imptependiente=value;} 
     }
     private DateTime fechacobro;
     public DateTime FechaCobro
     { 
     get {return fechacobro;}
     set {fechacobro=value;} 
     }
     private DateTime fechacontab;
     public DateTime FechaContab
     { 
     get {return fechacontab;}
     set {fechacontab=value;} 
     }
     private String observaciones;
     public String Observaciones
     { 
     get {return observaciones;}
     set {observaciones=value;} 
     }
     private String textopie;
     public String TextoPie
     { 
     get {return textopie;}
     set {textopie=value;} 
     }
     private String textocabe;
     public String TextoCabe
     { 
     get {return textocabe;}
     set {textocabe=value;} 
     }
    #endregion Instance Properties

        #region Metodos

        private void CargarLineas(string Factura,string Año, string Serie)
     {
            

     }  //private void CargarLineas(string Factura,string Año, string Serie)
        public void Obten_Factura()
        {
            //Nos dará el número de factura de la serie dada
            SqlCommand cmd = new SqlCommand("SELECT MAX(Factura) as MaxF FROM FACTV_CABE WHERE Anyo=" + anyo + " AND Serie='" + serie + "'", GloblaVar.gConRem);
            SqlDataReader rst = cmd.ExecuteReader();
            if (rst.Read() )
            {
                factura = Convert.ToInt32( rst["MaxF"]) + 1;
            }
            else //No hay registros
            {
                factura = 1;
            }
            cmd.Dispose();
            rst.Dispose();

        }  //public void Obten_Factura()

        //public void Grabar_Factura
        //{
        //    //string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
        //    //GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + gIdent);
        //    //SqlCommand cmd=New SqlCommand("SELECT * FROM VENALB_LINEAS WHERE VelAlb=" )
        //}
        #endregion Metodos
    }
}

