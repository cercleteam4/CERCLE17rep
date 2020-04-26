using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace cercle17
{
    class clase_EXPORT_CPLUS
    {

        public string sAsiento { get; set; }
        private string fecha;
        public string Fecha   //OJO. La fecha es en formato corto dd/mm/aaaa
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string TipoAsiento { get; set; }
        public string sDetCod { get; set; }
        public string FichExport { get; set; }   //Fichero al que se exportará el asiento
        public string sBI { get; set; }
        public string sIVA { get; set; }
        public string sReq { get; set; }
        public string sTotal { get; set; }
        public string sSubCta { get; set; }
        public string sFactura { get; set; }
        public string sSerie { get; set; }
        public string sPercentIVA { get; set; }
        public string sPercentRec { get; set; }
        private clase_detallista1 D=new clase_detallista1();

        public  Boolean  CobroCaja()
        {   //Va a meter en el fichero FichExport un asiento de cobros
            string gIdent = "clase_EXPORT_CPLUS.CobroCaja" + " ";
        bool  respuesta = false;    
        try
            {
                string linea = "";
                linea=ApunteAsiento(sAsiento , sSubCta , GloblaVar.gSubCtaCAJA, "Cobro Pte8048 " + fecha , "0.00", "0.00",  "0.00", sTotal.Replace(",", "."), "0.00", fecha , "","","","","0.00","0.00");
                File.AppendAllLines(FichExport,new string[] { linea});
                linea = ApunteAsiento(sAsiento, GloblaVar.gSubCtaCAJA, sSubCta, "Cobro Pte8048 " + fecha, "0.00", "0.00",sTotal.Replace(",", "."), "0.00", "0.00", fecha, "","","","", "0.00", "0.00");
                File.AppendAllLines(FichExport, new string[] { linea });
                respuesta = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + " " + ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent +ex.ToString());
            return respuesta;
            }
        } //public  Boolean  CobroCaja()

        public Boolean FacturaB()
        {   //Va a meter en el fichero FichExport un asiento de Facturas de serie B
            string gIdent = "clase_EXPORT_CPLUS.FacturaB" + " ";
            bool respuesta = false;
            try
            {
                D.CargaDatos(sDetCod);
                sBI = Math.Round(Convert.ToDecimal(sBI.Replace(".",",")), 2).ToString().Replace(",", ".");
                sIVA = Math.Round(Convert.ToDecimal(sIVA.Replace(".", ",")), 2).ToString().Replace(",", ".");
                sTotal = Math.Round(Convert.ToDecimal(sTotal.Replace(".", ",")), 2).ToString().Replace(",", ".");
                string linea = "";
                linea = ApunteAsiento(sAsiento, GloblaVar.gSubCtaVENTAS , D.SubCta  , "FRA.VENTA Nº" + sSerie +sFactura , "0.00", "0.00","0.00", sBI.Replace(",", "."), "0.00", fecha, sSerie ,sFactura ,"","", "0.00", "0.00");
                File.AppendAllLines(FichExport, new string[] { linea });
                linea = ApunteAsiento(sAsiento, GloblaVar.gSubCtaIVA1 , D.SubCta , "FRA.VENTA Nº" + sSerie + sFactura, "0.00", "0.00", "0.00", sIVA.Replace(",", "."), sBI.Replace(",", "."), fecha, sSerie , sFactura,D.DetNif,D.DetNom, sPercentIVA , "0.00");
                File.AppendAllLines(FichExport, new string[] { linea });
                linea = ApunteAsiento(sAsiento, D.SubCta, GloblaVar.gSubCtaVENTAS, "FRA.VENTA Nº" + sSerie + sFactura, "0.00", "0.00", sTotal.Replace(",", "."), "0.00","0.00", fecha, sSerie ,sFactura,"","", "0.00", "0.00");
                File.AppendAllLines(FichExport, new string[] { linea });
                respuesta = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(gIdent + " " + ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                return respuesta;
            }
        } //public  Boolean  FacturaB()

        private static string ApunteAsiento(string Asto, string CtaCargo, string CtaContraPart, string Concepto, string IVA, string Req, string Debe, string Haber,string BI, string FechaCobro, 
            string Serie,string Factura,string DetNif,string DetNom,string PerCentIva,string PercentRec)
        {

            string cero_cero = "0.00";
            string cero_seis = "0.000000";
            string cero = "0";
            string uno = "1";
            string blanco = " ";


            if (FechaCobro.Length > 8)
            {
                FechaCobro = FechaCobro.Substring(6, 4) + FechaCobro.Substring(3, 2) + FechaCobro.Substring(0, 2);

            }
            string Apunte = Asto.ToString().PadLeft(6, ' ');        //Num Asiento justificado a la dcha 6 digitos


            Apunte += FechaCobro.ToString().PadRight(8, ' ');  // Fecha contable del asiento. la fecha de cobro normalmente. 8 digitos .ej 20160105
            Apunte += CtaCargo.PadRight(12, ' ');       //Codigo de la subcuenta 
            Apunte += CtaContraPart.PadRight(12, ' ');  //Codigo de la contrapartida e importe al debe en pesetas
            Apunte += cero_cero.PadLeft(16, ' ');       // Importe al Debe en pesetas. No se usa.16.2
            Apunte += Concepto.PadRight(25, ' ');       //Concepto del asiento. 25 caracteres
            Apunte += cero_cero.PadLeft(16, ' ');       // Importe al haber en pesetas. No se usa.16.2
            Apunte += Factura.PadLeft(8, ' ');          //Nº de factura al IVA
            Apunte += cero_cero.PadLeft(16, ' ');       //Base Imponible del IVA en pesetas.16.2
            Apunte += PerCentIva.PadLeft(5, ' ');        //% del IVA  5.2
            Apunte += cero_cero.PadLeft(5, ' ');        //% Recargo Equivalencia. 5.2
            Apunte += blanco.PadLeft(10, ' ');          // Num. Documento
            Apunte += blanco.PadLeft(3, ' ');           //Código de departamento
            Apunte += blanco.PadLeft(6, ' ');           //Código del proyecto
            Apunte += blanco;                           //Punteo (interno)
            Apunte += cero.PadLeft(6, ' ');             //Numérico de casación
            Apunte += cero;                             //Tipo de casado (interno)
            Apunte += cero.PadLeft(6, ' ');             //Número de pago
            Apunte += cero_seis.PadLeft(16, ' ');       //Cambio a aplicar 16.6
            Apunte += cero_cero.PadLeft(16, ' ');       //Impte Debe moneda extranjera.   16.2
            Apunte += cero_cero.PadLeft(16, ' ');       //Impte HABER moneda extranjera.  16.2
            Apunte += "*";                              //Interno
            Apunte += Serie.PadLeft(1, ' ');            //Serie de la facturación
            Apunte += blanco.PadLeft(4, ' ');           //Sin uso
            Apunte += blanco.PadLeft(5, ' ');           //Código de la divisa
            Apunte += cero_cero.PadLeft(16, ' ');       //Impte auxiliar moneda extranjera
            Apunte += "2";                              //Moneda de uso. 2=Euros
            Apunte += Debe.PadLeft(16, ' ');            // Importe al debe 16.2
            Apunte += Haber.PadLeft(16, ' ');           //Importe al Haber 16.2
            Apunte +=BI.PadLeft(16, ' ');               //Base Imponible del IVA 16.2
            Apunte += "F";                              //(interno)
            Apunte += blanco.PadLeft(10, ' ');          //Código de Activo
            Apunte += blanco;                           //Serie de la Factura Rectificada
            Apunte += cero.PadLeft(8, ' ');             //Numero factura rectificada
            Apunte += cero_cero.PadLeft(16, ' ');       //Base imponible factura rectificada  16.2
            Apunte += cero_cero.PadLeft(16, ' ');       //Base imponible factura rectificativa  16.2
            Apunte += "F";                              //(.T.) En caso de factura rectificativa (true/False)
            Apunte += blanco.PadLeft(8, ' ');           //Fecha factura rectificada  8
            Apunte += "E";                              //Valores posibles para asientos:
                                                        //VACIO->Asiento válido solo P.G.C.
                                                        //E->Asiento válido para P.G.C.y para las normas NIC.
            Apunte += "F";                              //Libre
            Apunte += blanco.PadLeft(6, ' ');           //Libre 6
            Apunte += "F";                              //Operaciones interrumpidas     (campo42)
            Apunte += blanco.PadLeft(6, ' ');           //Segmentos Actividades
            Apunte += blanco.PadLeft(6, ' ');
            Apunte += "F";
            Apunte += blanco.PadLeft(8, ' ');           //Fecha operación Modelo 349
            Apunte += FechaCobro.PadLeft(8, ' ');       //Fecha operación Modelo 340
            Apunte += blanco.PadLeft(5, ' ');
            Apunte += blanco.PadLeft(10, ' ');
            Apunte += cero_cero.PadLeft(5, ' ');        //Porcen_Ana N 5 2 Sin uso (campo50)
            Apunte += cero_cero.PadLeft(5, ' ');
            Apunte += cero.PadLeft(6, ' ');
            Apunte += cero_cero.PadLeft(16, ' ');
            Apunte += blanco.PadLeft(100, ' ');
            Apunte += blanco.PadLeft(50, ' ');
            Apunte += blanco.PadLeft(50, ' ');
            Apunte += blanco;
            Apunte += uno.PadLeft(8, ' ');
            Apunte += blanco.PadLeft(40, ' ');
            Apunte += blanco.PadLeft(40, ' ');          //NumAcuFin C 40 Número de factura final de la agrupación.  Sólo para claves A o B  (campo 60)
            Apunte += "1";                              //Clave de identificación del tercero 1.-NIF
            Apunte += DetNif.PadRight(15, ' ');          //TerNif C 15 NIF del tercero (subcuenta de contrapartida del apunte de IVA)
            Apunte += DetNom.PadRight(40, ' ');         //TerNom C 40 Nombre/Razón social del tercero
            Apunte += blanco.PadLeft(9, ' ');
            Apunte += "F";
            Apunte += blanco.PadLeft(10, ' ');          //TBienCod C 10 Código de inventario de la factura de transmisión de bienes de inversión (campo 66)
            Apunte += "F";
            Apunte += "F";                              //Metal L 1 Apunte con cobro en metálico (campo 68)                           
            Apunte += "            0.00";               //MetalImp N 16 2 Importe del cobro realizada en metálico
            Apunte += "            ";                   //Cliente C 12 Código de subcuenta del cliente del que se realiza el cobro en metálico
            Apunte += "0";                              //OpBienes N 1 Tipo de bienes en operaciones de compras. Valores posibles:
                                                        //  1.Bienes y servicios corrientes.
                                                        //  2.Bienes de inversión.
                                                        //Campo opcional. Se podrá dejar en blanco o con valor cero para las partidas en las que no aplique
            Apunte += Factura.PadRight(40, ' ');        //FacturaEx C 40 Nº Factura expedición. Para facturas de compra(Modelo 340)
            Apunte += " ";                              //TipoFac C 1 “E” = Emitida “R” = Recibida
            Apunte += " ";                              //TipoIVA C 1 Tipo de IVA de la subcuenta (*3)
            Apunte += blanco.PadLeft(40, ' ');          //GUID C 40 (Uso interno) Sage Drive. GUID diferente por apunte
            Apunte += "F   0                                               0.00                                                                        0.00                                         0F0                         0 0 0F                    0.00                                            0.00                                                    F                                   F                                         0";

            return Apunte;
        }//private string ApunteAsientoENDU

        //1.- COBRADOS PDTE 8048

    } //class clase_EXPORT_CPLUS_CAJA_END
}  //namespace cercle17

