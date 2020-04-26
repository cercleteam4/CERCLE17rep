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
    public partial class frmCENTRAL_Export_Contaplus : Form
    {
        public frmCENTRAL_Export_Contaplus()
        {
            InitializeComponent();
        }
        public SqlConnection CnO;


        private void frmCENTRAL_Export_Contaplus_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.Text = "CENTRAL DE EXPORTACIONES A CONTAPLUS " + GloblaVar.VERSION ;

            Seguridad();
        } //private void frmCENTRAL_Export_Contaplus_Load(object sender, EventArgs e)

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":   //Llorens
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case "2":  //Carabal
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            button1.Visible = true;
                            button2.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            button6.Visible = true;
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            button1.Visible = true;
                            button2.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            button5.Visible = true;
                            button6.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "5":   //DIALPESCA
                    button1.Visible = true;  //exportar facturas de ventas
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    btnExportarFraPro2.Visible = true;
                    break;
                case "6":   //ABT
                    break;
                case "8":   //VALPEIX
                    button1.Visible = true;  //exportar facturas de ventas
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    btnExportarFraPro2.Visible = true;
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad
 

        private void button1_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmEXPORT_CPLUS_FraPro ExportFVentas = new frmEXPORT_CPLUS_FraPro();
            ExportFVentas.CnO = CnO;
            ExportFVentas.Show();
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza("-----------------------------SALIENDO DE " + this.GetType().FullName);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmEXPORT_CPLUS_FraORE ExportFOremape = new frmEXPORT_CPLUS_FraORE();
            GloblaVar.TeMp = "EXPORTACIÓN FACTURAS DE OREMAPE";
            ExportFOremape.CnO = CnO;
            ExportFOremape.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TeMp = "EXPORTACIÓN COBROS PROPIOS";
            frmEXPORT_CPLUS_FraORE ExportFOremape = new frmEXPORT_CPLUS_FraORE();
            ExportFOremape.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TeMp = "EXPORTACIÓN COBROS RECIBIDOS DE OREMAPE";
            frmEXPORT_CPLUS_CobORE ExportCOremape = new frmEXPORT_CPLUS_CobORE();
            ExportCOremape.Show();

        }//private void button4_Click(object sender, EventArgs e)

        private void button5_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TeMp = "EXPORTACIÓN COBROS DE CAJA";
            frmEXPORT_CPLUS_CAJA ExportCaja = new frmEXPORT_CPLUS_CAJA();
            ExportCaja.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {//Exportar a Contaplus facturas de 8000
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TeMp = "EXPORTACIÓN FACTURAS DE 8000";
            frmEXPORT_CPLUS_FraPro ExportFVentas = new frmEXPORT_CPLUS_FraPro();
            ExportFVentas.CnO = GloblaVar.gConRem;
            ExportFVentas.Tipo = "8000_Resumen";
            ExportFVentas.Show();
        }

        private void btnExportarFraPro2_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmEXPORT_CPLUS_FraPro2 ExportFVentas2 = new frmEXPORT_CPLUS_FraPro2();
            ExportFVentas2.CnO = CnO;
            ExportFVentas2.Show();
        }


    }
}
