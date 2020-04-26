using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace cercle17
{
    class clase_ImagenAlbaran
    {
        // El propósito de esta clase es proporcionar las herramientas para Componer, Presentar e Imprimir un albarán de Abonos 

        //private clase_ABONG_CABE Albaran =new clase_ABONG_CABE();

        StringFormat formatoCentrado = new StringFormat();
        StringFormat formatoDerecha = new StringFormat();

        private float F = (float)1.75; // Factor de relación de tamaño
        Font latinFaoFont = new Font("Lucida console", 12, FontStyle.Bold);
        Font printFont = new Font("Lucida console", 7, System.Drawing.FontStyle.Bold);
        Font printFont2 = new Font("Arial", 6, System.Drawing.FontStyle.Bold);
        Font miniprintFont1 = new Font("Arial", 5, System.Drawing.FontStyle.Bold);
        Font miniprintFont2 = new Font("Franklin Gothic Book", 5, System.Drawing.FontStyle.Bold);
        Font miniprintFont3 = new Font("Bodoni MT Poster", 4, System.Drawing.FontStyle.Bold);
        Font CabecerasFont = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
        Font albaranFont = new Font("Arial", 24, System.Drawing.FontStyle.Bold);
        Font FechaFont = new Font("Arial", 24, System.Drawing.FontStyle.Bold);
        Font HoraFont = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
        Font validacionFont = new Font("Arial", 28, System.Drawing.FontStyle.Bold);
        Font detallistaFont = new Font("Arial", 40, System.Drawing.FontStyle.Bold);
        Font nombreFont = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
        Font anularFont = new Font("Arial", 80, System.Drawing.FontStyle.Bold);
        Font articulosFont = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
        Font cantidadesFont = new Font("Arial", 22, System.Drawing.FontStyle.Bold);
        Font subtotFont = new Font("Arial", 20, System.Drawing.FontStyle.Bold);
        Font articulos2Font = new Font("Arial", 18, System.Drawing.FontStyle.Bold);
        Font articulos3Font = new Font("Arial", 14, System.Drawing.FontStyle.Bold);
        Font articulos4Font = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        Font totalFont = new Font("Arial", 24, System.Drawing.FontStyle.Bold);
        Font extrasFont = new Font("Arial", 32, System.Drawing.FontStyle.Bold);


        private string numalbaran;
        public string NumAlbaran
        {
            set { numalbaran = value; }
        }
        private string año;
        public string Año
        {
            set { año = value; }
        }

        public void ComponAlbaran1()
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            clase_ABONG_CABE Albaran = new clase_ABONG_CABE();
            if (Albaran.CargaAlbaran(numalbaran, año))
            {
                GloblaVar.gIMAGEN_FONDO_TICKET = Image.FromFile(GloblaVar.gPATH_IMAGES_REMOTO + "\\plantilla_ticket_impreso.bmp");

                Graphics g = Graphics.FromImage(GloblaVar.gIMAGEN_FONDO_TICKET);
                // ******************** INICIO GRABAR Texto sobre la Imagen impresa **************************
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                formatoCentrado.Alignment = StringAlignment.Center;
                formatoDerecha.Alignment = StringAlignment.Far;
                try
                {
                    ImprimeTituloColumnas(g);
                    g.DrawString(numalbaran, albaranFont, Brushes.Black, (float)(1270 * F), (float)(18 * F));
                    //g.DrawString("NºPEDIDO", articulos4Font, Brushes.Black,(float) ( 1150 * F),(float) ( 53 * F));
                    //g.DrawString(frmPrincipal.TxtNPedidoC.Text.ToString, articulos3Font, Brushes.Black,(float) ( 1270 * F),(float) ( 52 * F));
                    //    g.DrawString("NºPEDIDO:", articulos3Font, Brushes.Black, 730 * F, 547 * F)
                    //    g.DrawString(frmPrincipal.TxtNPedidoC.Text.ToString, articulos2Font, Brushes.Black, 838 * F, 541 * F)
                    g.DrawString(Albaran.Fecha.ToShortDateString(), FechaFont, Brushes.Black, (float)(1270 * F), (float)(70 * F));
                    g.DrawString(DateTime.Now.ToShortTimeString(), HoraFont, Brushes.Black, (float)(1270 * F), (float)(120 * F));
                    g.DrawString(Albaran.IdVendedor.ToString(), latinFaoFont, Brushes.Black, (float)(1270 * F), (float)(160 * F));
                    g.DrawString(Albaran.DetCod.ToString(), detallistaFont, Brushes.Black, (float)(890 * F), (float)(70 * F));
                    g.DrawString(Albaran.DetNom, nombreFont, Brushes.Black, (float)(390 * F), (float)(20 * F));
                    g.DrawString(Albaran.DetNif, articulosFont, Brushes.Black, 390 * F, 50 * F);
                    g.DrawString(Albaran.DetDireccion, articulosFont, Brushes.Black, 390 * F, 80 * F);
                    g.DrawString(Albaran.DetMun, articulosFont, Brushes.Black, 390 * F, 110 * F);

                    string cajas = "";
                    for (int i = 1; i < Albaran.NumLineas; i++)
                    {
                        if (Albaran.line[i].Cajas > 0) { cajas = Albaran.line[i].Cajas.ToString(); } else { cajas = ""; }
                        g.DrawString(cajas, cantidadesFont, Brushes.Black, 429 * F, (230 + ((i - 1) * 52)) * F, formatoDerecha);
                        g.DrawString(Albaran.line[i].Kilos.ToString(), cantidadesFont, Brushes.Black, 569 * F, (230 + ((i - 1) * 52)) * F, formatoDerecha);
                        g.DrawString(Albaran.line[i].Artdes, articulos2Font, Brushes.Black, 635 * F, (230 + ((i - 1) * 52)) * F);
                        g.DrawString(Albaran.line[i].NomCie, latinFaoFont, Brushes.Black, 650 * F, (260 + ((i - 1) * 52)) * F);
                        //g.DrawString(frmPrincipal.TTraza_1.Text, articulos3Font, Brushes.Black, 1084 * F, 240 * F)
                        g.DrawString(Albaran.line[i].Precio.ToString("##,##0.00"), cantidadesFont, Brushes.Black, 1320 * F, (230 + ((i - 1) * 52)) * F, formatoDerecha);
                        g.DrawString(Albaran.line[i].Importe.ToString("##,##0.00"), cantidadesFont, Brushes.Black, 1464 * F, (230 + ((i - 1) * 52)) * F, formatoDerecha);
                    }  // for . fin de recorrido de las lineas
                    //decimal a = Albaran.IVA1  ;
                    g.DrawString(Albaran.BI1.ToString("##,##0.00"), subtotFont, Brushes.Black, 1464 * F, 450 * F, formatoDerecha);
                    g.DrawString(Albaran.IVA1.ToString("##,##0.00"), subtotFont, Brushes.Black, 1464 * F, 480 * F, formatoDerecha);
                    g.DrawString(Albaran.RE1.ToString("##,##0.00"), subtotFont, Brushes.Black, 1464 * F, 510 * F, formatoDerecha);
                    g.DrawString(Albaran.Total.ToString("##,##0.00"), totalFont, Brushes.Black, 1464 * F, 537 * F, formatoDerecha);
                    g.DrawString("ABONO SIN GEN.", detallistaFont, Brushes.Black, 680 * F, 460 * F);

                    string pathImagenTicket = GloblaVar.gPATH_IMAGES_REMOTO + "\\ABONOS\\" + DateTime.Today.ToString("yyyyMMdd") + "_" + Albaran.Albaran.ToString("000000#") + ".gif";
                    GloblaVar.gIMAGEN_FONDO_TICKET.Save(pathImagenTicket, System.Drawing.Imaging.ImageFormat.Gif);
                    GloblaVar.gUTIL.ATraza(gIdent + "Generado el albarán " + pathImagenTicket);

                }
                catch (Exception ex)
                {
                    GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());

                }
            }

        }  //private void ComponAlbaran1

        private void ImprimeTituloColumnas(Graphics g)
        {
            string sTitulo = "CAJAS         KILOS                            ARTICULO                                                                         PRECIO         IMPORTE";
            g.DrawString(sTitulo, articulos3Font, Brushes.Black, 380 * F, 187 * F);
            g.DrawString("BASE IMPO", articulos3Font, Brushes.Black, (float)(1204 * F), (float)(460 * F));
            g.DrawString("IVA", articulos3Font, Brushes.Black, (float)(1204 * F), (float)(489 * F));
            g.DrawString("RE", articulos3Font, Brushes.Black, (float)(1204 * F), (float)(518 * F));
            g.DrawString("TOTAL", articulosFont, Brushes.Black, (float)(1202 * F), (float)(542 * F));
        }   //private void ImprimeTituloColumnas(Graphics g) 

    }  //class clase_ImagenAlbaran
}  //namespace Compras1

