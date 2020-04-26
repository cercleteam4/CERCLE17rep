using System;
using System.Collections.Generic;
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
    public partial class frmPpal : Form
    {
        
        public frmPpal()
        {
            InitializeComponent();
        }


        public SqlConnection CnO;
        public static bool mensajes, conexion; 
        public static string DATABASE, SERVER, LOCAL, USUARIO, DATOS_MAYORISTA;


        private bool CompruebaClave(string clave, string pasword)
        {
            //determinar si clave en MD5 es igual a pasword
            //gUTIL.ATraza("CompruebaClave " + clave + " " + pasword);
            //clase_UTILESdb.Atraza(" ");
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
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent +" Conectar_BD");
            try
            {
                mensajes = true; conexion = false;
                //obtener datos conexión a BD (y el INTERVALO)
                //string config = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "oremape\\OrelessCFG.txt";
                //SERVER = ""; DATABASE = ""; string userid = ""; LOCAL = ""; USUARIO = "";
                //DATOS_MAYORISTA = "";
                //string linea;
                //StreamReader fichero = new StreamReader(config);
                //while ((linea = fichero.ReadLine()) != null)
                //{
                //    //estos datos son necesarios para conectar con la BD y para el Crystal Reports
                //    if (linea.StartsWith("REMOTO_BD")) { DATABASE = linea.Substring(linea.IndexOf(",") + 1); }
                //    if (linea.StartsWith("REMOTO_SERVER")) { SERVER = linea.Substring(linea.IndexOf(",") + 1); }
                //    if (linea.StartsWith("LOCAL_SERVER")) { LOCAL = linea.Substring(linea.IndexOf(",") + 1); }
                //    //este dato es el que personaliza el programa según el mayorista
                //    if (linea.StartsWith("CERCLE_100")) { USUARIO = linea.Substring(linea.IndexOf(",") + 1); }
                //}

                //if (SERVER.IndexOf('\\') == -1)
                //{
                //    userid = SERVER;
                //}
                //else
                //{
                //    userid = SERVER.Substring(0, SERVER.IndexOf('\\'));
                //}
                //fichero.Close();

                USUARIO = GloblaVar.gCERCLE_100;

                //abrir BD
                //string base_datos = "user id=" + userid + "\\Administrador;password=;server=" + SERVER + ";Trusted_Connection=yes;database=" + DATABASE + "; connection timeout=10"; 
                GloblaVar.gCadConRem = "user id=;password=;server=" + GloblaVar.gREMOTO_SERVER + ";Trusted_Connection=yes;database=" + GloblaVar.gREMOTO_BD + "; connection timeout=10;MultipleActiveResultSets=true";
                CnO = new SqlConnection(GloblaVar.gCadConRem );
                CnO.Open();
                GloblaVar.gUTIL.ATraza(gIdent  + ".CONEXIÓN EXITOSA a " + GloblaVar.gREMOTO_BD+" " + GloblaVar.gCadConRem);
                GloblaVar.gConRem = CnO;
                //Intento de conexión a la base de datos de ENLACE1db
                GloblaVar.gCadConEnlace  = "user id=;password=;server=" + GloblaVar.gREMOTO_SERVER + ";Trusted_Connection=yes;database=ENLACE1db; connection timeout=10;MultipleActiveResultSets=false";
                GloblaVar.gConEnlace  = new SqlConnection(GloblaVar.gCadConEnlace );
                GloblaVar.gConEnlace.Open();
                GloblaVar.gUTIL.ATraza(gIdent + ".CONEXIÓN EXITOSA a ENLACE1db " + GloblaVar.gCadConEnlace );

                if (USUARIO=="3")   //Si es ENDUMAR conectaremos también a la base de datos ENDUMARdb
                {
                    GloblaVar.gCadConEnlace = "user id=;password=;server=" + GloblaVar.gREMOTO_SERVER + ";Trusted_Connection=yes;database=ENDUMARdb; connection timeout=10;MultipleActiveResultSets=false";
                    GloblaVar.gConEndu = new SqlConnection(GloblaVar.gCadConEnlace);
                    GloblaVar.gConEndu.Open();
                    GloblaVar.gUTIL.ATraza(gIdent + ".CONEXIÓN EXITOSA a ENDUMARdb " + GloblaVar.gCadConEnlace);
                }

                //Inicializar Configuraciones y vbles globales
                //clase_UTILESdb clsCONFIG=new clase_UTILESdb();
                GloblaVar.gUTIL.ATraza("Ajustes en BD");
                GloblaVar.gUTIL.AjustesDB();

                GloblaVar.gcnO = CnO;
                GloblaVar.gUTIL.ATraza(gIdent  +".Obteniendo de la Base los datos de configuración");
                GloblaVar.gUTIL.Datos_Configuración_BD();

                conexion = true;
            }
            catch (Exception ex)
            {
                conexion = false;
                GloblaVar.gUTIL.ATraza(gIdent + ex.ToString());
                Mostrar("Fallo en conexiones de inicio. " + ex.ToString());
            }
        }

        private void Cargar_mayorista()
        {
            //leemos los datos del mayorista para poder incluirlos en el report de factura
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent +".Cargando Valores del Mayorista");
            string strQ = "SELECT * FROM CONTROL";

            string conNom = ""; string condir = ""; string condpo = ""; string conmun = ""; string connif = "";

            try
            {
                SqlDataReader miLector = null;
                SqlCommand miComando = new SqlCommand(strQ, CnO);

                miLector = miComando.ExecuteReader();
                while (miLector.Read())
                {
                    conNom = miLector["ConNom"].ToString();
                    condir = miLector["condir"].ToString();
                    condpo = miLector["condpo"].ToString();
                    conmun = miLector["ConMun"].ToString();
                    connif = miLector["connif"].ToString();
                    GloblaVar.gMayCod = miLector["ConMay"].ToString();
                }
                miLector.Close();

                switch (frmPpal.USUARIO)
                {
                    case "1": DATOS_MAYORISTA = connif; ;
                        break;
                    default: DATOS_MAYORISTA = conNom + "\r\n" + condir + "\r\n" + condpo + " " + conmun + "\r\n" + connif;
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza(gIdent + ". " + ex.ToString());
            }
        }

        private void frmPpal_Load(object sender, EventArgs e)
        {
            //inicializar conexión BD
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;    
            GloblaVar.gUTIL.ATraza(gIdent  +" ENTRADA EN frmPpal");
            conexion = false;
            GloblaVar.gUTIL.ATraza(gIdent  +" Intentaremos conectar a BD");
            Conectar_BD();
            if (conexion == true)
            {
                Cargar_mayorista();

                bool necesita_password = false;
                label_Version.Text = GloblaVar.VERSION;
                GloblaVar.gUTIL.ATraza(gIdent  + " USUARIO " +USUARIO );
                switch (USUARIO)
                {
                    
                    //de momento el usuario 1 no necesita dar contraseña pero el resto sí
                    //la idea es que Carabal sea el usuario 2

                    case "1": necesita_password = false;
                         button_Facturas.Visible = true;
                        //button_Mantenimiento.Visible = true;

                        break;
                    case "2": necesita_password = true;     //CARABAL
                        GloblaVar.gUTIL.ATraza(gIdent + " Requerir password= " + necesita_password);

                        //pedimos contraseña (tres intentos)
                        frmPass Pass = new frmPass();
                        int intentos = 0; bool encontrado = false;

                        while (intentos < 3 && encontrado == false)
                        {
                            intentos++;
                            if (Pass.ShowDialog() == DialogResult.OK)
                            {
                                string password = Pass.pass;
                                string clave = "";
                                string perfil = "";

                                string strQ = "select * from VENDEDORES where UPPER(Vendedor)='" + Pass.user.ToUpper() + "'";
                                try
                                {
                                    SqlDataReader myReader = null;
                                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                                    myReader = myCommand.ExecuteReader();
                                    while (myReader.Read())
                                    {
                                        clave = myReader["Password"].ToString();
                                        perfil = myReader["Perfil"].ToString();
                                        GloblaVar.PerfilUser = perfil;
                                        GloblaVar.gIdVendedor = myReader["IdVendedor"].ToString();
                                    }
                                    myReader.Close();
                                }
                                catch (Exception ex)
                                {
                                    Mostrar(ex.ToString());
                                    conexion = false;
                                }

                                //aquí se comprueba la clave

                                encontrado = CompruebaClave(password, clave);
                                if (encontrado) Seguridad();


                            } //if (Pass.ShowDialog() == DialogResult.OK)
                        }  //while (intentos < 3 && encontrado == false)

                        break;
                    case "3":   //Endumar
                        necesita_password = false;
                        button_Facturas.Visible = true;
                        button_LISTADOS.Visible = true;
                        button_Mantenimiento.Visible = false;
                        button_Usos.Visible = true;
                        button_COMPRAS.Visible = true;
                        button_COBROS.Visible = true;
                        //Debemos establecer conexión a la base de datos ENDUMAR
                        break;
                    case "4":   //BOTELLA
                        necesita_password = false;
                        button_Usos.Visible = true;
                        break;
                    case "5":   //Dialpesca
                        necesita_password = false;
                        button_LISTADOS.Visible = true;
                        button_Facturas.Visible = true;
                        button_Usos.Visible = true;
                        button_COMPRAS.Visible = true;
                        GloblaVar.gIdVendedor = "1000";
                        GloblaVar.gIdTipoCobro = "0"; 
                        GloblaVar.gUTIL.ATraza( "Usamos vendedor: " + GloblaVar.gIdVendedor.ToString());
                        break;
                    case "6":   //ABT
                        necesita_password = false;
                        button_Usos.Visible = true;
                        break;
                    case "7":  //FRIOMED
                        necesita_password = false;
                        button_Usos.Visible = true;
                        break;
                    case "8":   //VALPEIX
                        necesita_password = false;
                        button_LISTADOS.Visible = true;
                        button_Facturas.Visible = true;
                        button_Usos.Visible = true;
                        button_COMPRAS.Visible = true;
                        GloblaVar.gIdVendedor = "1000";
                        GloblaVar.gIdTipoCobro = "0";
                        GloblaVar.gUTIL.ATraza("Usamos vendedor: " + GloblaVar.gIdVendedor.ToString());
                        break;
                    case "9":   //CEFALOPODOS
                        necesita_password = false;
                        button_Usos.Visible = true;
                        break;
                    default: necesita_password = true;
                        GloblaVar.gUTIL.ATraza(gIdent + " Requerir password= " + necesita_password);

                         //pedimos contraseña (tres intentos)
                        frmPass Pass1 = new frmPass();
                        int intentos1 = 0; bool encontrado1 = false;

                        while (intentos1 < 3 && encontrado1 == false)
                        {
                            intentos1++;
                            if (Pass1.ShowDialog() == DialogResult.OK)
                            {
                                string password = Pass1.pass;
                                string clave = "";
                                string perfil = "";

                                string strQ = "select * from VENDEDORES where UPPER(Vendedor)='" + Pass1.user.ToUpper() + "'";
                                try
                                {
                                    SqlDataReader myReader = null;
                                    SqlCommand myCommand = new SqlCommand(strQ, CnO);
                                    myReader = myCommand.ExecuteReader();
                                    while (myReader.Read())
                                    {
                                        clave = myReader["Password"].ToString();
                                        perfil = myReader["Perfil"].ToString();
                                        GloblaVar.PerfilUser = perfil;
                                    }
                                    myReader.Close();
                                }
                                catch (Exception ex)
                                {
                                    Mostrar(ex.ToString());
                                    conexion = false;
                                }

                                //aquí se comprueba la clave

                                encontrado1 = CompruebaClave(password, clave);
                                if (encontrado1)      Seguridad();

                            } //if (Pass1.ShowDialog() == DialogResult.OK)
                        }  //while (intentos1 < 3 && encontrado1 == false)


                        break;
                }

            }
            UbicaButtons();
        } //private void frmPpal_Load(object sender, EventArgs e)

       private void Seguridad()
        {
           switch(frmPpal.USUARIO )
           {
               case "1":   //LLORENS
                   button_Facturas.Visible = true;
                   //button_Mantenimiento.Visible = true;
                   break;
               case "2":   //CARABAL
                   switch(GloblaVar.PerfilUser )
                   {
                       case "ADMIN":
                           button_Facturas.Visible = true;
                           button_LISTADOS.Visible = true;
                           button_Mantenimiento.Visible = true;
                           break;
                       case "VENDECOMPRA":
                           break;
                       case "CONTABILIDAD":
                           button_Mantenimiento.Visible = true;
                           button_Facturas.Visible  = true;
                           break;
                       case "CAJERO":
                           button_Mantenimiento.Visible = true;
                           button_Facturas.Visible  = true;
                           button_LISTADOS.Visible = true;
                           break;
                   } //switch(GloblaVar.PerfilUser )
                   break;
               case "3":    //ENDUMAR'
                   button_Usos.Visible = true;
                   button_Facturas.Visible = false;
                   button_Mantenimiento.Visible = false;
                   button_LISTADOS.Visible = true;
                   button_COBROS.Visible = true;
                   break;
               case "4":    //BOTELLA'
                   button_Usos.Visible = true;
                   button_Facturas.Visible = false;
                   button_Mantenimiento.Visible = false;
                   break;
               case "5":    //DIALPESCA
                   button_Usos.Visible = true;
                   button_Facturas.Visible = true;
                   button_LISTADOS.Visible = true;
                   button_COMPRAS.Visible = true;
                   break;
                case "6":  //ABT
                    button_Facturas.Visible = true;
                    break;
                case "8":    //VALPEIX
                    button_Usos.Visible = true;
                    button_Facturas.Visible = true;
                    button_LISTADOS.Visible = true;
                    button_COMPRAS.Visible = true;
                    break;
                case "9":    //CEFALOPODOS
                    button_Usos.Visible = true;
                    button_Facturas.Visible = false;
                    button_Mantenimiento.Visible = false;
                    break;
            } //switch(frmPpal.USUARIO )
        } //private void Seguridad
        private void button_Mantenimiento_Click(object sender, EventArgs e)
        {
            frmMtto Mantenimiento = new frmMtto();
            Mantenimiento.CnO = CnO;
            Mantenimiento.Show();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + ".SALIDA ORDENADA DEL PROGRAMA");
            GloblaVar.gApunta.Close();
            GloblaVar.gFTraza.Close();
            this.Close();
        }

        private void frmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CnO.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_COBROS_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCobros");
            frmInicioCaja  frmCo = new frmInicioCaja();
            frmCo.Show();
        }

        private void button_Facturas_Click(object sender, EventArgs e)
        {
            frmFacturacion Facturacion = new frmFacturacion();
            Facturacion.CnO = CnO;
            Facturacion.Show();
        }

        private void button_LISTADOS_Click(object sender, EventArgs e)
        {
            frmLISTADOS formLISTADOS = new frmLISTADOS();
            formLISTADOS.Show();
        }

        private void button_Usos_Click(object sender, EventArgs e)
        {
            switch (frmPpal.USUARIO )
            {
                case "3":  //ENDUMAR
                    frmEmpr03 frmEmpr03 = new frmEmpr03();
                    frmEmpr03.CnO = CnO;
                    frmEmpr03.Show();
                    break;
                case "4":  //BOTELLA
                    frmEmpr04 frmEmpr04 = new frmEmpr04();
                    frmEmpr04.Show();
                    break;
                case "5":  //DIALPESCA
                    frmEmpr05 frmEmpr05 = new frmEmpr05();
                    frmEmpr05.CnO = CnO;
                    frmEmpr05.Show();
                    break;
                case "6":  //ABT
                    frmEmpr05 frmEmpr06 = new frmEmpr05();
                    frmEmpr06.CnO = CnO;
                    frmEmpr06.Show();
                    break;
                case "7":  //FRIOMED
                    break;
                case "8":  //VALPEIX
                    frmEmpr05 frmEmpr08 = new frmEmpr05();
                    frmEmpr08.CnO = CnO;
                    frmEmpr08.Show();
                    break;
                case "9":  //CEFALOPODOS
                    frmEmpr09 frmEmpr09 = new frmEmpr09();
                    frmEmpr09.Show();
                    //Form1 f1 = new Form1();
                    //f1.Show();
                    break;
                default:
                    break;
            }
        }  //private void button_Usos_Click(object sender, EventArgs e)

        private void UbicaButtons()
        {
            if (!button_LISTADOS.Visible) { button_Facturas.Location = new Point(button_LISTADOS.Location.X, button_LISTADOS.Location.Y); }
            if (!button_Facturas.Visible) { button_COMPRAS.Location = new Point(button_Facturas.Location.X, button_Facturas.Location.Y); }
            switch (frmPpal.USUARIO)
            {
                case "3": //ENDUMAR
                    button_COBROS.Location = new Point(button_Mantenimiento.Location.X, button_Mantenimiento.Location.Y);
                    break;
                default:
                    break;
            }
        }//private void UbicaButtons()

        private void button_COMPRAS_Click(object sender, EventArgs e)
        {
            string gIdent = this.GetType().FullName + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GloblaVar.gUTIL.ATraza(gIdent + ".ENTRADA a frmCOMPRAS");
            frmCOMPRAS frmC01=new frmCOMPRAS();
            frmC01.Show();
        } //private void button_COMPRAS_Click(object sender, EventArgs e)
    }
}
