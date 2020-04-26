using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public partial class frmInicioCaja : Form
    {
        public frmInicioCaja()
        {
            InitializeComponent();
        }

        SqlConnection myConnection;
        bool mensajes, conexion;
        public string paso;
        public string IdVendedor;
        public static string PATH_IMAGES_LOCAL;
        public static string IMPRE_RECIBOS, RUTA_RECIBOS;





        private bool CompruebaClave(string clave, string pasword)
        {
            //determinar si clave en MD5 es igual a pasword
            bool resultado = false;

            if (Funciones.GetMd5(clave) == pasword) { resultado = true; }

            return resultado;
        }

        private void Mostrar(string texto)
        {
            if (mensajes)
            {
                MessageBox.Show(texto);
            }
        }

        private void Conectar_BD()
        {
            try
            {
                PATH_IMAGES_LOCAL = ""; IMPRE_RECIBOS = "";

                mensajes = true; conexion = false;
                //obtener datos conexión a BD (y el INTERVALO)
                string config = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\OrelessCFG.txt";
                string server = ""; string database = ""; string userid = "";
                string linea;
                paso = "1.- " + config + " " + server;
                StreamReader fichero = new StreamReader(config);
                paso = "2.- " + fichero;
                while ((linea = fichero.ReadLine()) != null)
                {
                    if (linea.StartsWith("REMOTO_BD")) { database = linea.Substring(linea.IndexOf(",") + 1); }
                    if (linea.StartsWith("REMOTO_SERVER")) { server = linea.Substring(linea.IndexOf(",") + 1); }
                    if (linea.StartsWith("PATH_IMAGES_LOCAL")) { PATH_IMAGES_LOCAL = linea.Substring(linea.IndexOf(",") + 1); }
                    if (linea.StartsWith("IMPRE_RECIBOS")) { IMPRE_RECIBOS = linea.Substring(linea.IndexOf(",") + 1); }
                    if (linea.StartsWith("RUTA_RECIBOS")) { RUTA_RECIBOS = linea.Substring(linea.IndexOf(",") + 1); }
                }
                paso = "3.- " + database + " " + server;
                if (server.IndexOf('\\') == -1)
                {
                    userid = server;
                }
                else
                {
                    userid = server.Substring(0, server.IndexOf('\\'));
                }
                paso = "4.- " + userid;
                fichero.Close();

                //abrir BD
                string base_datos = "user id=" + userid + "\\Administrador;password=;server=" + server + ";Trusted_Connection=yes;database=" + database + "; connection timeout=10";
                paso = "5.- " + base_datos;
                myConnection = new SqlConnection(base_datos);
                myConnection.Open();
                paso = "6.- Conectado " + base_datos;
                conexion = true;
            }
            catch (Exception ex)
            {
                conexion = false;
                Mostrar("Fallo en conexiones de inicio. " + ex.ToString());
                Mostrar(paso);
            }
        }

        private void Consulta_Pagares()
        {
            if (conexion)
            {
                bool pendientes = false;
                string consulta = "SELECT * FROM PAGARES WHERE Cobrado='N' AND FVencto<='" + DateTime.Today.ToShortDateString() + "'";

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(consulta, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        pendientes = true;
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Mostrar(ex.ToString());
                    conexion = false;
                }

                if (pendientes == true)
                {
                    MessageBox.Show("Tiene pagarés pendientes de cobro");
                }

            }
        }

        private void frmInicioCaja_Load(object sender, EventArgs e)
        {
            //button_Caja.Enabled = false;
            //button_Cobros.Enabled = false;
            //button_Gestion.Enabled = false;

            Conectar_BD();

            //usuarios
            //if (conexion == true)
            //{
            //    myConnection = myConnection ;
            //    //pedimos contraseña (tres intentos)
            //    frmPass Pass = new frmPass();
            //    int intentos = 0; bool encontrado = false;

            //    while (intentos < 3 && encontrado == false)
            //    {
            //        intentos++;
            //        if (Pass.ShowDialog() == DialogResult.OK)
            //        {
            //            string password = Pass.pass;
            //            string clave = "";
            //            string perfil = "";

            //            string strQ = "select * from VENDEDORES where UPPER(Vendedor)='" + Pass.user.ToUpper() + "'";
            //            try
            //            {
            //                SqlDataReader myReader = null;
            //                SqlCommand myCommand = new SqlCommand(strQ, myConnection);
            //                myReader = myCommand.ExecuteReader();
            //                while (myReader.Read())
            //                {
            //                    clave = myReader["Password"].ToString();
            //                    perfil = myReader["Perfil"].ToString();
            //                }
            //                myReader.Close();
            //            }
            //            catch (Exception ex)
            //            {
            //                Mostrar(ex.ToString());
            //                conexion = false;
            //            }

            //            //aquí se comprueba la clave

            //            encontrado = CompruebaClave(password, clave);

            //            if (encontrado)
            //            {
                            button_Caja.Enabled = true;
                            button_Cobros.Enabled = true;
            //                button_Gestion.Enabled = true;

            //            }

            //        }
            //    }
            //}
            this.Text = "COBROS Y CAJA " + GloblaVar.VERSION;

            Consulta_Pagares();
            IdVendedor = "1000";
            Seguridad();

            //advertencia de versión DEBUG o RELEASE

#if DEBUG 
            label_Debug.Text = "DEBUG";
#endif
        }

        private void frmInicioCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception ex)
            {
                Mostrar(ex.ToString());
            }
        }

        private void Seguridad()
        {
            switch (frmPpal.USUARIO)
            {
                case "1": //llorens

                    break;
                case "2":  //Carabal
                    break;
                case "3":       //ENDUMAR
                    button_Cobros.Visible = true;
                    button_Caja.Visible = true;
                    break;
                case "5": //Dialpesca
                    break;
                case "6":  //ABT
                    break;
                case "8": //VALPEIX
                    break;
            }
        } //private void Seguridad()

        private void button_Gestion_Click(object sender, EventArgs e)
        {
            //gestionar pagarés
            if (conexion)
            {
                frmPagares Pagares = new frmPagares();
                Pagares.myConnection = myConnection;
                Pagares.IdVendedor = IdVendedor;
                Pagares.Show();
            }
        }

        private void btnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FormGastos frm = new FormGastos();
            //frm.Show();
        }

        private void button_Cobros_Click(object sender, EventArgs e)
        {
            //cobros
            if (conexion)
            {
                frmCobros Cobros = new frmCobros();
                Cobros.myConnection = GloblaVar.gConRem;
                Cobros.mensajes = mensajes;
                Cobros.IdVendedor = IdVendedor;
                Cobros.WindowState = FormWindowState.Maximized;
                Cobros.Show();
            }
        }



        private void button_Caja_Click(object sender, EventArgs e)
        {
            //cuadrar caja
            if (conexion)
            {
                //frmCajaDia CajaDiaria = new frmCajaDia();
                ////CajaDiaria.myConnection = GloblaVar.gConRem ;
                //CajaDiaria.WindowState = FormWindowState.Maximized;
                //CajaDiaria.Show();
                frmHojaCaja2 frmHC2 = new frmHojaCaja2() ;
                frmHC2.Show();
            }
        }


    }
}
