using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {
            InitializeComponent();
        }

        public SqlConnection CnO;

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("ENTRADA a " + this.GetType().FullName);
            //permisos
            this.Text = "FACTURACIÓN " + GloblaVar.VERSION;


            Seguridad();
        }//private void frmFacturacion_Load(object sender, EventArgs e)


        private void Seguridad()
        {
            button_Cuadre.Visible = false;
            button_Exportar.Visible = false;
            button_Descobro.Visible = false;
            switch (frmPpal.USUARIO)
            {
                case "1":  //Llorens
                    button_Cuadre.Visible = false;
                    button_Exportar.Visible = true;
                    button_Descobro.Visible = true;
                    panel2.Visible = false;
                    break;
                case "2": //Carabal
                    //button3.Visible = false;
                    //button4.Visible = false;

                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            button_Cuadre.Visible = true;
                            button_Exportar.Visible = true;
                            button_Descobro.Visible = true;
                            btn_FPV8000.Visible = true;
                            button_FPVAbono.Visible = true;
                            button_FPVAbono1.Visible = true;
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            button_Cuadre.Visible = true;
                            button_Exportar.Visible = true;
                            button_Descobro.Visible = true;
                            btn_FPV8000.Visible = true;
                            button_FPVAbono.Visible = true;
                            button_FPVAbono1.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "3": //ENDUMAR
                    button_FPVPropia.Visible = false;
                    button_Periodos.Visible = false;
                    button_FCompras.Visible = true;
                    button_FCManual.Visible = true;
                    button_FCProveedor.Visible = false;
                    break;
                case "5":  //DIALPESCA
                    button_FPVAbono.Visible = true;
                    //button_FPVAbono1.Visible = true;
                    button_Exportar.Visible = true;
                    break;
                case "8":  //VALPEIX
                    button_FPVAbono.Visible = true;
                    //button_FPVAbono1.Visible = true;
                    button_Exportar.Visible = true;
                    break;

            } //switch(frmPpal.USUARIO )
        }  //private void Seguridad()

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza("---------------------- SALIENDO de " + this.GetType().FullName);
            this.Close();
        }


        #region "Ventas"

        private void button_FPVManual_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturación manual
            frmFPVManual FactManual = new frmFPVManual();
            FactManual.CnO = CnO;
            FactManual.Show();
        }

        private void button_FVentas_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturas ventas
            frmFPVentas FactVentas = new frmFPVentas();
            FactVentas.CnO = CnO;
            FactVentas.Show();
        }

        private void button_Periodos_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturación periódica
            frmFPVPeriodo FactPeriodo = new frmFPVPeriodo();
            FactPeriodo.CnO = CnO;
            FactPeriodo.Show();
        }

        private void btn_FPV8000_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                frmFPV8000 frm8000 = new frmFPV8000();
                frm8000.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_FPVPropia_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ";
            try
            {
                frmFPVPropia frmPropia = new frmFPVPropia();
                frmPropia.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_FPVAbono_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a " + sender.ToString());

            //facturación abonos
            frmFPVAbono FactAbono = new frmFPVAbono();
            FactAbono.CnO = CnO;
            FactAbono.Show();
        }

        private void button_FPVAbono1_Click(object sender, EventArgs e)
        {
            //Facturación de Abonos nueva. Se ofrecerán los albaranes para facturar cuyo albarán de abono esté en la nueva tabla ABONNG_CABE 
            //y ABONNG Lineas y tenga el status=1 o el IdCobro y fechaCobro Grabados
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + " Entrada a  " + sender.ToString());
            frmFPVAbono1 FactAbono1 = new frmFPVAbono1();

            FactAbono1.Show();

        }

        private void button_Descobro_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //abrir formulario de Descobro
            FormDescobro Descobro = new FormDescobro();
            Descobro.CnO = CnO;
            Descobro.ShowDialog();
        }



        #endregion

        #region "Compras"

        private void button_FCProveedor_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturación proveedor
            frmFCProveedor FactProveedor = new frmFCProveedor();
            FactProveedor.CnO = CnO;
            FactProveedor.Show();

        }

        private void button_FCompras_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturas compras
            frmFCompras FactCompras = new frmFCompras();
            FactCompras.CnO = CnO;
            FactCompras.Show();
        }

        private void button_FCManual_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //facturación manual
            frmFCManual FactComprasManual = new frmFCManual();
            FactComprasManual.CnO = CnO;
            FactComprasManual.Show();
        }

        #endregion

        #region "Contabilidad"

        private void button_Exportar_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //formulario de selección de facturas
            frmCENTRAL_Export_Contaplus Exportar = new frmCENTRAL_Export_Contaplus();
            Exportar.CnO = CnO;
            Exportar.Show();
        }

        private void button_Cuadre_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //ABRIR formulario de cuadres caja día
            frmCuadreDia Cuadres = new frmCuadreDia();
            Cuadres.CnO = CnO;
            Cuadres.Show();
        }

        #endregion

       
    }
}


