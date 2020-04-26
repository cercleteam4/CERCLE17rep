using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmLISTADOS : Form
    {
        public frmLISTADOS()
        {
            InitializeComponent();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(" .-------------------- SALIDA DE " + this.GetType().FullName);
            this.Close();
        }  //private void button_Salir_Click(object sender, EventArgs e)

        private void frmLISTADOS_Load(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.CartelTraza( " ENTRADA EN frmLISTADOS "); 
            this.Text = "LISTADOS " + GloblaVar.VERSION;

            Seguridad();

        }  //private void frmLISTADOS_Load(object sender, EventArgs e)

        private void button1_Click(object sender, EventArgs e)
        {
            //Listado de RENtABILIDAD DE VENDEDORES
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 1;

            if (frmPpal.USUARIO == "8")
            {
                GloblaVar.TIPO_REPORT = 15;
            }

            frmSeleccionDatos frmSD=new frmSeleccionDatos();
            frmSD.Show();
            
        } //private void button1_Click(object sender, EventArgs e)

        private void button4_Click(object sender, EventArgs e)
        {
            //Listado de RENTABILIDAD DE VENDEDORES para DIALPESCA en EXCELL
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 6;
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();

        }  //private void button4_Click(object sender, EventArgs e)



        private void button6_Click(object sender, EventArgs e)
        {
            //LISTADO de STOCK por ARTÍCULOS (Solicitado por Juanjo Barredo)
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 8;
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();


        }  //private void button6_Click(object sender, EventArgs e)

        private void button3_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 3;  //LISTADO DE FACTURAS DE CLIENTES
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        }

        private void button2_Click(object sender, EventArgs e)  //Listado de Venta: Fecha, Articulos, Detallistas
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 2;  //Listado de Venta: Fecha, Articulos, Detallistas
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        } //private void button2_Click(object sender, EventArgs e)

        private void button5_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 5;  //Listado de Compras: Fecha, Artículos Proveedores
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        } //private void button4_Click(object sender, EventArgs e)
        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1":
                    break;
                case "2":
                    switch (GloblaVar.PerfilUser)
                    {
                        case "ADMIN":
                            button1.Visible = true;
                            button2.Visible = true;
                            button3.Visible = true;
                            button5.Visible = true;
                            BtnListadoVentas.Visible = true;
                            BtnListadoCompras.Visible = true;
                            break;
                        case "VENDEDOR":
                            break;
                        case "CAJERO":
                            //button_Mantenimiento.Visible = false;
                            //button_Facturas.Enabled = true;
                            panel4.Visible = false;
                            panel5.Visible = false;
                            button3.Visible = true;
                            break;
                    } //switch(GloblaVar.PerfilUser )
                    break;
                case "3":  //ENDUMAR
                    button8.Visible = true;
                    button9.Visible = true;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel2.Dock = DockStyle.Fill;
                    break;
                case "4":    //Botella'
                    break;
                case "5":   //DIALPESCA
                    button4.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    break;
                case "8":   //VALPEIX
                    button1.Visible = true;
                    button4.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad

        private void button7_Click(object sender, EventArgs e)
        {

            //Listado de DIFERENCIAS DE STOCK
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 9;
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();           

        }

        private void BtnListadoVentas_Click(object sender, EventArgs e)
        {
            //Listado de Ventas por Detallista
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 11;  //Listado de Ventas por detallista
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        }

        private void BtnListadoCompras_Click(object sender, EventArgs e)
        {
            //Listado de Compras por Proveedor
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 12;  //Listado de Ventas por detallista
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Listado de Ventas por Proveedor y Artículo. ENDUMAR
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 13;  //Listado de Ventas por Proveedor y Artículo. ENDUMAR
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Equivale a Estadisticas de Compras por Articulos ENDUMAR. Incluyendo los gastos que se aplican al programa
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.TIPO_REPORT = 14;  //Estadisticas de Compras por Articulos ENDUMAR
            frmSeleccionDatos frmSD = new frmSeleccionDatos();
            frmSD.Show();
        }
    }
}
