using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace cercle17
{
    public class clase_UTILESdb
    {
        public int Datos_Configuración_BD()
        {
            int res = 0;
            string sQ = "SELECT * FROM CONTROL_CONTAB";

            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand(sQ, GloblaVar.gConRem);
            myReader = myCommand.ExecuteReader();
            try
            {
                if(myReader.HasRows)
                {
                    myReader.Read();
                    GloblaVar.gSubCtaBANCO = Convert.ToString(myReader["SubCtaBANCO"]);
                    GloblaVar.gSubCtaCAJA = Convert.ToString(myReader["SubCtaCAJA"]);
                    GloblaVar.gSubCtaIVA1 = Convert.ToString(myReader["SubCtaIVA1"]);
                    GloblaVar.gSubCtaREQ1 = Convert.ToString(myReader["SubCtaREQ1"]);
                    GloblaVar.gSubCtaVENTAS = Convert.ToString(myReader["SubCtaVENTAS"]);
                    GloblaVar.gSubCtaIVAconReq = Convert.ToString(myReader["SubCtaIVAconReq"]);
                    if (!myReader.IsDBNull(myReader.GetOrdinal("CliCod8048")))
                    {
                        GloblaVar.g8048 = new clase_detallista1();
                        GloblaVar.g8048.DetCod = myReader["CliCod8048"].ToString();
                        if (GloblaVar.g8048.CargaDatos("")) { GloblaVar.gUTIL.ATraza("Hay Cliente 8048 y está cargado"); }
                    }
                }                          
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GloblaVar.gUTIL.ATraza("clase_UTILESdb.Datos_Configuración_BD ERRORES EN OBTENCIÓN Valores de configuración de CONTROL_CONTAB");
                myReader.Dispose();
                return res;
            }
            myReader.Dispose();
            GloblaVar.gUTIL.ATraza("clase_UTILESdb.Datos_Configuración_BD Obtenidos Valores de configuración de CONTROL_CONTAB");
            return res;
        }  // public int Datos_Configuración_BD()

        public void SP1()
        {
            //conn.Open();

            SqlCommand command = new SqlCommand("OREMAPEREMdb.dbo.SP_AJUSTA_ALB_FACTURADOS", GloblaVar.gcnO);
            command.CommandType = CommandType.StoredProcedure;

            //SqlParameter paramId = new SqlParameter("Id", SqlDbType.Int);
            //paramId.Direction = ParameterDirection.Output;
            //command.Parameters.Add(paramId);

            //command.Parameters.AddWithValue("Nombre", nombre);
            //command.Parameters.AddWithValue("Direccion", direccion);
            //command.Parameters.AddWithValue("FechaNacimiento", fechaNacimiento);

            int rowsAffected = command.ExecuteNonQuery();

            //if (rowsAffected > 0)
            //{
            //    return Convert.ToInt32(command.Parameters["Id"].Value);
            //}
            //else
            //    return -1;


        } //public void SP1()

        public void SP2(string FI, string FF, int VI, int VF)
        {
            SqlCommand command = new SqlCommand("OREMAPEREMdb.dbo.SP_TR1_PREPARADATOS", GloblaVar.gConRem);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FI", FI);
            command.Parameters.AddWithValue("@FF", FF);
            command.Parameters.AddWithValue("@VI", VI);
            command.Parameters.AddWithValue("@VF", VF);

            int FilasAfectadas = command.ExecuteNonQuery();

            //SqlParameter parFI = new SqlParameter("FI", SqlDbType.VarChar);
            //parFI.Direction = ParameterDirection.Input ;
            //command.Parameters.Add(parFI);
            //SqlParameter parFF = new SqlParameter("FF", SqlDbType.VarChar);
            //parFF.Direction = ParameterDirection.Input;
            //command.Parameters.Add(parFF);

            //SqlParameter paramId = new SqlParameter("Id", SqlDbType.Int);
            //paramId.Direction = ParameterDirection.Output;
            //command.Parameters.Add(paramId);
            //SqlParameter paramId = new SqlParameter("Id", SqlDbType.Int);
            //paramId.Direction = ParameterDirection.Output;
            //command.Parameters.Add(paramId);
            //SqlParameter paramId = new SqlParameter("Id", SqlDbType.Int);
            //paramId.Direction = ParameterDirection.Output;
            //command.Parameters.Add(paramId);

        }//public void SP2()

        public void SP3(string Factura,string AñoFra,string SerieFra)
        {
            //Pondrá el importe de cobro a la factura correspondiente. Es decir, en el cobro de la factura
            //situará el importe de los albaranes que estén cobrados correspondientes
            //En FACTV_CABE completará los campos ImpteCobrado e ImptePendiente de la factura
            SqlCommand command = new SqlCommand("OREMAPEREMdb.dbo.SP_AJUSTA_COBRO_FACTURA", GloblaVar.gConRem);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Factura", Factura);
            command.Parameters.AddWithValue("@AñoFra", AñoFra);
            command.Parameters.AddWithValue("@SerieFra", SerieFra);

            int FilasAfectadas = command.ExecuteNonQuery();

        }//public void SP3(string Factura,string AñoFra,string SerieFra)
        
        public void SP4(string Albaran, string AñoAlb, string SerieFra)
        {
            //Facturará el Albarán dado con el num de Albarán y el año del mismo la serie de Factura que se pasa como parámetro
            SqlCommand command = new SqlCommand("OREMAPEREMdb.dbo.SP_FACTURAR_ALBARAN", GloblaVar.gConRem);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Alb", Albaran);
            command.Parameters.AddWithValue("@Año", AñoAlb);
            command.Parameters.AddWithValue("@Serie", SerieFra);

            int FilasAfectadas = command.ExecuteNonQuery();

        }   //public void SP4(string Albaran, string AñoAlb, string SerieFra)

        public bool ExisteTabla(string nombreTabla, string nombreBase)
        {
            string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES "; 
                sCmd+="WHERE TABLE_TYPE = 'BASE TABLE' " ;
                sCmd+="AND TABLE_NAME = '" +nombreTabla +"'";

            try
            {
                using (SqlConnection con =
                    new SqlConnection(GloblaVar.gCadConRem ))
                {
                    con.Open();

                    SqlCommand cmd =
                        new SqlCommand(sCmd, con);

                    //cmd.Parameters.AddWithValue("@nombreTabla", nombreTabla);

                    // Comprobamos si está
                    // Devuelve 1 si ya existe
                    // o 0 si no existe
                    int n = (int)cmd.ExecuteScalar();

                    con.Close();

                    return n > 0;
                }
            }
            catch
            {
                return false;
            }
        }  //public bool ExisteTabla(string nombreTabla, string nombreBase)

        public bool ExisteSP(string mySP,string nombreBase)
        {
            string sCmd = "SELECT * FROM sys.objects WHERE type='P' AND name='" + mySP + "'";

            try
            {
                Boolean res=false;
                SqlCommand cmd = new SqlCommand(sCmd, GloblaVar.gConRem);
                SqlDataReader myR = cmd.ExecuteReader();
                if (myR.Read()) { res = true; }
                ATraza("clase_UTILESdb.ExisteSP .El SP " +mySP +" existe? ==>" +res);
                myR.Close();
                return res;
            }
            catch (Exception ex)
            {
                ATraza("clase_UTILESdb.ExisteSP .El SP " + mySP + " NO EXISTE ");
                ATraza(ex.ToString());
                return false;
            }

        }  //public bool ExisteSP(string SP,string nombreBase)
        
        public bool ExisteCampo(string nombreTABLA, string columnName)
        {
            //Nos dirá si existe el campo buscado en la tabla de la base de datos Remota
           try
           { 
            IDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + nombreTABLA, GloblaVar.gConRem);
            reader = cmd.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    reader.Dispose();
                    return true;
                    
                }
            }

            reader.Dispose();
            GloblaVar.gUTIL.ATraza("El Campo " + columnName + "NO EXISTE en la Tabla " + nombreTABLA);
            return false;
               }  //try
            catch (Exception ex)
           {
               ATraza("clase_UTILESdb.ExisteCampo " +nombreTABLA + " - "+columnName );
               MessageBox.Show( ex.ToString());
               return false;

           }
            
        }  //public bool ExisteCampo(IDataReader reader, string columnName)

        public void Crear_TABLA_RENDIMIENTO02()
        {
            string sQ;

            sQ="CREATE TABLE [dbo].[RENDIMIENTO02](";
            sQ += "[Id] [int] IDENTITY(1,1) NOT NULL,";
            sQ +="[IdVendedor] [int] NOT NULL,";
	        sQ +="[ArtCod] [int] NOT NULL,";
	        sQ +="[Vendedor] [varchar](50) NULL,";
	        sQ +="[ArtDes] [varchar](30) NULL,";
	        sQ +="[FVenta] [datetime] NULL,";
	        sQ +="[KgsVenta] [real] NULL,";
	        sQ +="[PreVenta] [money] NULL,";
	        sQ +="[ImpteVenta] [money] NULL,";
	        sQ +="[Partida] [int] NULL,";
	        sQ +="[PartAnyo] [int] NULL,";
	        sQ +="[PartAlm] [varchar](10) NULL,";
	        sQ +="[PreCompra] [money] NULL,";
	        sQ +="[ImpteCompra] [money] NULL,";
	        sQ +="[Beneficio] [money] NULL,";
	        sQ +="[Margen]  [Real] NULL,";
	        sQ +="[DetCod] [int] NULL,";
	        sQ +="[DetNom] [varchar](50) NULL,";
	        sQ +="[ProCod] [int] NULL,";
	        sQ +="[ProNom] [varchar](50) NULL,";
            sQ +="CONSTRAINT [PK_RENDIMIENTO02] PRIMARY KEY CLUSTERED"; 
            sQ +="(";
	        sQ +="[Id] ASC";
            sQ +=")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
            sQ +=") ON [PRIMARY]";

            if (EjecutaNQ(sQ)==-1)
        {
            ATraza("clase_UTILESdb.Crear_TABLA_RENDIMIENTO02.Tabla RENDIMIENTO02 Creada CORRECTAMENTE");
        }
            else
        {
            ATraza("clase_UTILESdb.Crear_TABLA_RENDIMIENTO02  Fallo al Intentar Crear Tabla RENDIMIENTO02 ");
        }

        }//public void Crear_TABLA_RENDIMIENTO02

        public void CrearSP1()
        {
            string Scmd="-- ============================================= \n" ;
            Scmd+="-- Author:		Abel Gascón"; 
            Scmd+="-- Create date: 28/8/2015 ";
            Scmd+="-- Description:	Prepara los datos para el listad de RENDIMIENTO DE LOS VENDEDORES ";
            Scmd+="-- ============================================= ";
            Scmd+="CREATE PROCEDURE [dbo].[SP_TR1_PREPARADATOS]  ";
            Scmd+="	-- Add the parameters for the stored procedure here ";
            Scmd+="	@FI VARCHAR(10),  ";
            Scmd+="	@FF VARCHAR(10), ";
            Scmd+="	@VI INT, ";
            Scmd+="	@VF INT ";
	
            Scmd+="AS ";
            Scmd+="BEGIN ";
            Scmd+="	-- SET NOCOUNT ON added to prevent extra result sets from ";
            Scmd+="	-- interfering with SELECT statements. ";
            Scmd+="	SET NOCOUNT ON; ";
            Scmd+=" ";
            Scmd+="	DELETE FROM RENDIMIENTO02 ";
            Scmd+="	 ";
            Scmd+="    INSERT INTO RENDIMIENTO02 (IdVendedor,ArtCod,FVenta,KgsVenta,PreVenta,ImpteVenta,Partida,PartAnyo,PartAlm)  ";
            Scmd+="		SELECT   VENALB_CABE.IdVendedor,VENALB_LINEAS.ArtCod,VENALB_LINEAS.Velfec, VENALB_LINEAS.VelKil, VENALB_LINEAS.VelPre, VENALB_LINEAS.VelImp,  ";
            Scmd+="		VENALB_LINEAS.Partida, 	VENALB_LINEAS.PartAnyo, VENALB_LINEAS.PartAlm  ";
            Scmd+="		FROM    ";
            Scmd+="		VENALB_LINEAS  ";
            Scmd+="		INNER JOIN 	VENALB_CABE ON (VENALB_LINEAS.VelAlb = VENALB_CABE.VenAlb AND VENALB_LINEAS.Anyo = VENALB_CABE.Anyo)  ";
            Scmd+="		INNER JOIN	ARTICULOS ON VENALB_LINEAS.ArtCod = ARTICULOS.ArtCod  ";
            Scmd+="		WHERE  ";
            Scmd+="		VENALB_LINEAS.VelFec BETWEEN @FI AND @FF  ";
            Scmd+="		AND ";
            Scmd+="		VENALB_CABE.IdVendedor BETWEEN @VI and @VF ";
            Scmd+="		";
            Scmd+="    -- Insert statements for procedure here";
            Scmd+="	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2> ";
            Scmd+="END";
            if (EjecutaNQ(Scmd)==-1)
            {
                ATraza("clase_UTILESdb.CrearSP1  Creado  SP_TR1_PREPARADATOS ");
            }
            else
            {
                ATraza("clase_UTILESdb.CrearSP1  Fallo al Intentar Crear  SP_TR1_PREPARADATOS ");
            }//if (EjecutaNQ(Scmd)==1)

        }//public void CrearSP1()

        public void Leer_CONFIG(string FichConfig)
        {
            string linea;
            string Param;
            string Valor;
            GloblaVar.gUTIL.ATraza(" ===============================================");
            GloblaVar.gUTIL.ATraza("|         C O N F I G U R A C I Ó N             |"); 
            GloblaVar.gUTIL.ATraza(" ===============================================");
            StreamReader sr = new StreamReader(FichConfig);
            linea = sr.ReadLine();


            while (linea != null)
            {
                Param = linea.Substring(0, linea.IndexOf(",")).ToUpper();

                Valor = linea.Substring((linea.IndexOf(",") + 1), (linea.Length - 1 - linea.IndexOf(",")));

                switch (Param)
                {
                    case "LOCAL_SERVER":
                        GloblaVar.gLOCAL_SERVER = Valor;
                        GloblaVar.gUTIL.ATraza("LOCAL_SERVER," + Valor);
                        break;
                    case "LOCAL_BD":
                        GloblaVar.gLOCAL_BD = Valor;
                       GloblaVar.gUTIL.ATraza("LOCAL_BD," + Valor);
                       break;
                    case "LOCAL_UI":
                        GloblaVar.gLOCAL_UI = Valor;
                        GloblaVar.gUTIL.ATraza("LOCAL_UI," + Valor);
                        break;
                    case "LOCAL_PWD":
                        GloblaVar.gLOCAL_PWD = Valor;
                        GloblaVar.gUTIL.ATraza("LOCAL_PWD," + Valor);
                        break;
                    case "LOCAL_PORTDB":
                        GloblaVar.gLOCAL_PORTDB = Valor;
                        GloblaVar.gUTIL.ATraza("LOCAL_PORTDB," + Valor);
                        break;
                    case "REMOTO_SERVER":
                        GloblaVar.gREMOTO_SERVER = Valor;
                        GloblaVar.gUTIL.ATraza("REMOTO_SERVER," + Valor);
                        break;
                    case "REMOTO_BD":
                        GloblaVar.gREMOTO_BD = Valor;
                        GloblaVar.gUTIL.ATraza("REMOTO_BD," + Valor);
                        break;
                    case "REMOTO_UI":
                        GloblaVar.gREMOTO_UI = Valor;
                        GloblaVar.gUTIL.ATraza("REMOTO_UI," + Valor);
                        break;
                    case "REMOTO_PWD":
                        GloblaVar.gREMOTO_PWD = Valor;
                        GloblaVar.gUTIL.ATraza("REMOTO_PWD," + Valor);
                        break;
                    case "REMOTO_PORTDB":
                        GloblaVar.gREMOTO_PORTDB = Valor;
                        GloblaVar.gUTIL.ATraza("REMOTO_PORTDB," + Valor);
                        break;
                    case "PATH_IMAGES_REMOTO":
                        GloblaVar.gPATH_IMAGES_REMOTO = Valor;
                        GloblaVar.gUTIL.ATraza( "PATH_IMAGES_REMOTO," + Valor);
                        break;

                    case "CERCLE_100":
                        GloblaVar.gCERCLE_100 = Valor;
                        GloblaVar.gUTIL.ATraza("CERCLE_100," + Valor);
                        break;

                    case "CERCLE_103":
                        GloblaVar.gCERCLE_103 = Valor;
                        GloblaVar.gUTIL.ATraza("CERCLE_103," + Valor);
                        break;

                    case "NUMERO_TABLET":
                        GloblaVar.gNUMERO_TABLET = Valor;
                        GloblaVar.gUTIL.ATraza("NUMERO_TABLET," + Valor);
                        break;
                    case "CERCLE_105":
                        if (Valor == "SI") { GloblaVar.gCERCLE_105 = true; };
                        //GloblaVar.gUTIL.ATraza("NUMERO_TABLET," + Valor);
                        break;

                }  //Fin de  switch (Param)
                linea = sr.ReadLine();
            }

        } // fin de public void Leer_CONFIG(string FichConfig)

        public void AbreTraza()
        {
            // Nos abrirá el fichero donde guardaremos una traza de lo que va haciendo el programa
            if (Directory.Exists(GloblaVar.gPATH_IMAGES_REMOTO + "\\log\\" + GloblaVar.gNombreMaquina))
            {}
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(GloblaVar.gPATH_IMAGES_REMOTO +"\\log\\" + GloblaVar.gNombreMaquina );
            }

            GloblaVar.gFichTraza = GloblaVar.gPATH_IMAGES_REMOTO + "\\log\\" + GloblaVar.gNombreMaquina + "\\" + DateTime.Today.ToString("yyyyMMdd") + "_C17.txt";

            GloblaVar.gFTraza  = new FileStream(GloblaVar.gFichTraza, FileMode.Append, FileAccess.Write);
            GloblaVar.gApunta = new StreamWriter(GloblaVar.gFTraza);
            //StreamReader srTraza = new StreamReader(GloblaVar.gFichTraza);
            GloblaVar.TrazaAbierta = true;
            GloblaVar.gApunta.WriteLine(@"====================================================================================");
            GloblaVar.gApunta.WriteLine(@"!                                ENTRADA AL PROGRAMA                               ¡");
            GloblaVar.gApunta.WriteLine(@"====================================================================================");
            ATraza(this.GetType().FullName +" " +System.Reflection.MethodBase.GetCurrentMethod().Name + ". VERSIÓN " + GloblaVar.VERSION);

        } // Fin de AbreTraza

        public void ATraza(string linea)
        {
            if (GloblaVar.TrazaAbierta ) {GloblaVar.gApunta.WriteLine(DateTime.Now.ToString() + "  " + linea);}
        }

        public void CartelTraza(string Titulo)
        {
            try
            {
                int LongTitulo = Titulo.Length;
                int Despzto = (98 - LongTitulo) / 2;
                string LineaTitulo = "|";
                for (int i = 1; i <= Despzto; i++) { LineaTitulo += " "; }
                LineaTitulo += Titulo;
                for (int i = 1; i <= Despzto; i++) { LineaTitulo += " "; }
                LineaTitulo += "|";
                if (GloblaVar.TrazaAbierta)
                {
                    GloblaVar.gApunta.WriteLine("");
                    GloblaVar.gApunta.WriteLine("----------------------------------------------------------------------------------------------------");
                    GloblaVar.gApunta.WriteLine(LineaTitulo);
                    GloblaVar.gApunta.WriteLine("----------------------------------------------------------------------------------------------------");

                }//if (GloblaVar.TrazaAbierta)
            }
            catch (Exception ex)
            {
                GloblaVar.gApunta.WriteLine(" clase_UTILESdb.CarTelTraza "+ ex.ToString() );
                
            }
        }  //public void CartelTraza(string Titulo)

        public  int EjecutaNQ(string NonQuery)
        {
            int res = 0;

            try
            {
                SqlCommand myCommand = new SqlCommand(NonQuery, GloblaVar.gConRem );
                res = myCommand.ExecuteNonQuery();  //Devuelve el nº de filas afectadas -1 ex para crear una tabla
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ATraza("clase_UTILESdb.EjecutaNQ. ERROR al ejecutar " + NonQuery);
            }

            return res;
        }    //public static int EjecutaNonQuery(string NonQuery, SqlConnection CnO)

        public void AjustesDB()
        {
            try
            {
                if (ExisteCampo("CONTROL_CONTAB", "SubCtaBANCO"))
                {
                }
                else
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaBANCO VARCHAR(15) NULL", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaBANCO en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }

                if (ExisteCampo("CONTROL_CONTAB", "SubCtaIVAconReq"))
                {
                }
                else
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaIVAconReq VARCHAR(15) NULL", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaIVAconReq en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }

                if (ExisteTabla("RENDIMIENTO02", "OREMAPEREMdb"))
                {
                }
                else
                {
                    ATraza("clase_UTILESdb.AjustesDB. No existe la tabla RENDIMIENTO02. Se Intenta Crear");
                    try { Crear_TABLA_RENDIMIENTO02(); }
                    catch (Exception ex)
                    {
                        ATraza("clase_UTILESdb.AjustesDB. ERROR al Crear Tabla RENDIMIENTO02" + ex.ToString());
                    }
                }  //(ExisteTabla("RENDIMIENTO02", "OREMAPEREMdb")

                if (ExisteSP("SP_TR1_PREPARADATOS", GloblaVar.gREMOTO_BD))
                { }
                else
                {
                    ATraza("clase_UTILESdb.AjustesDB. No EXISTE SP_TR1_PREPARADATOS ");
                    CrearSP1();
                }//if (ExisteSP
                if (ExisteCampo("ARTICULOS", "ArtCodPadre"))
                {
                }
                else
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE ARTICULOS ADD  ArtCodPadre INT NULL", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo ArtCodPadre en ARTICULOS de " + GloblaVar.gREMOTO_BD);
                    Funciones.EjecutaNonQuery("ALTER TABLE ARTICULOS ADD  ArtCodPadre INT NULL", GloblaVar.gConEnlace );
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo ArtCodPadre en ARTICULOS de ENLACE1db");
                }
                if (!ExisteCampo("CONTROL_CONTAB", "SubCtaIVARepSinRec"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaIVARepSinRec VARCHAR(15) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET SubCtaIVARepSinRec='47700010'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaIVARepSinRec en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "SubCtaIVARepConRec"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaIVARepConRec VARCHAR(15) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET SubCtaIVARepConRec='47700082'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaIVARepConRec en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "Factura8048"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  Factura8048 INT NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET Factura8048=0", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo Factura8048 en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "Serie8048"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  Serie8048 VARCHAR(2) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET Serie8048='B'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo Serie8048 en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "CliCod8048"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  CliCod8048 INT NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET CliCod8048=9888", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo CliCod8048 en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "CliNom8048"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  CliNom8048 VARCHAR(50) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET CliNom8048='CLIENTE PENDIENTE 2008'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo CliNom8048 en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "SubCtaGastosExtra"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaGastosExtra VARCHAR(15) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET SubCtaGastosExtra='67800000'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaGastosExtra en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "SubCtaDevVentas"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaDevVentas VARCHAR(15) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET SubCtaDevVentas='70800000'", GloblaVar.gConRem);
                    MessageBox.Show("clase_UTILESdb.AjustesDB.Creado Campo SubCtaDevVentas en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaDevVentas en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }
                if (!ExisteCampo("CONTROL_CONTAB", "SubCtaVentas"))
                {
                    Funciones.EjecutaNonQuery("ALTER TABLE CONTROL_CONTAB ADD  SubCtaVENTAS VARCHAR(15) NULL", GloblaVar.gConRem);
                    Funciones.EjecutaNonQuery("UPDATE CONTROL_CONTAB SET SubCtaVENTAS='70000000'", GloblaVar.gConRem);
                    ATraza("clase_UTILESdb.AjustesDB. Creado Campo SubCtaVENTAS en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                    MessageBox.Show("clase_UTILESdb.AjustesDB. Creado Campo SubCtaVENTAS en CONTROL_CONTAB de " + GloblaVar.gREMOTO_BD);
                }

            }  //try
            catch (Exception ex1)
            {
                MessageBox.Show("clase_UTILESdb.AjustesDB. " + ex1.ToString());
                ATraza("clase_UTILESdb.AjustesDB. " +ex1.ToString());
            }

        }   //public void AjustesDB()

        public int ElementoTabla(string elem,string Tabla)
        {
            int res=0;
            string sQ="";
            

            switch(elem)
            {
                case "PRIMERO":
                    switch(Tabla)
                    {
                        case "DETALLISTAS":
                            sQ = "SELECT DetCod,DetNom FROM DETALLISTAS ORDER BY DetCod";
                            break;
                        case "ARTICULOS":
                            sQ = "SELECT ArtCod,ArtDes FROM ARTICULOS ORDER BY ArtCod";
                            break;
                        case "VENDEDORES":
                            sQ = "SELECT IdVendedor,Vendedor FROM VENDEDORES ORDER BY IdVendedor";
                            break;
                        case "PROVEEDORES":
                            sQ = "SELECT ProCod,ProNom FROM PROVEEDORES ORDER BY ProCod";
                            break;

                    }//switch(Tabla)
                    break;
                case "ULTIMO":
                    switch (Tabla)
                    {
                        case "DETALLISTAS":
                            sQ = "SELECT DetCod,DetNom FROM DETALLISTAS ORDER BY DetCod DESC";
                            break;
                        case "ARTICULOS":
                            sQ = "SELECT ArtCod,ArtDes FROM ARTICULOS ORDER BY ArtCod DESC";
                            break;
                        case "VENDEDORES":
                            sQ = "SELECT IdVendedor,Vendedor FROM VENDEDORES ORDER BY IdVendedor DESC";
                            break;
                        case "PROVEEDORES":
                            sQ = "SELECT ProCod,ProNom FROM PROVEEDORES ORDER BY ProCod DESC";
                            break;

                    }//switch(Tabla)
                    break;
            }//switch(elem)
            SqlCommand cmd = new SqlCommand(sQ, GloblaVar.gConRem);
            SqlDataReader Lector = cmd.ExecuteReader();
            if (Lector.HasRows )
            {
                Lector.Read();
                //string Nom = Lector.GetInt32(0);
                GloblaVar.Cod_Buscado = Lector.GetInt32(0).ToString();
                GloblaVar.Nom_Buscado = Lector.GetString(1);
                Lector.Dispose();
                cmd.Dispose();
                res = 1;
            }


        return res;
        }//public int ElementoTabla (string elem,string Tabla)


    

    } // class clase_UTILESdb
    
} //namespace cercle17
