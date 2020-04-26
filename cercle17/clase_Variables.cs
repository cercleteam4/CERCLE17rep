using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace cercle17
{ 
    public static class GloblaVar
    {
        public const string VERSION = "v 3.86 ";
        //3.86 Abel 25/04/2020    (ENDUMAR) Se han creado bajo el botón de cobros, La entrada de cobros, la caja del dia. Y en la caja del dia los botones y forms de entrada de 
        //                         pagos y Pagos desde caja. Esta versión corre en paralelo con lo que está haciendo Encarni de Entrada de facturas de compras y arreglos para facturación 
        //                         de Ventas de algunos apaños que yo había hecho. También se incluye el artículo 99 junto al 7001 para que no compute kilos én compras y listado CR14 
        //                         a petición de Vicky.
        //                          AQUI COMBINAMOS CON LA VERSIÓN DE ENCARNI. Ya está todo lo necesario. No se han tocado las clases que tenia la version 3.85. Solamente se han añadido la clase_Detallistas1 y la clase_EXPORT_CPLUS
        //3.84 Encarni 30/03/2020 (Endumar) Facturación de compras
        //3.83 Encarni 27/03/2020 Solucionar errores de la facturación de ventas debido a los cambios de la versión 3.79 
        //3.82 Encarni 26/03/2020 (Endumar) Añadir en la entrada de compras 'frmCOMPRAS_Entrada_ENDU' el Lote del proveedor
        //                        Modificar la entrada de compras 'frmCOMPRAS_Entrada' porque al editar el albarán y modificar el Lote no se actualizaba en BBDD (PARTIDAS(Ref), COMALB_LINEAS(Ref))
        //3.81 Encarni 23/03/2020 Añadir en la entrada de compras 'frmCOMPRAS_Entrada' el Lote del proveedor
        //3.80 Encarni 16/03/2020 En Facturación Propia 'frmFPVPropia' poner Total Registros (cuenta los registros que aparecen en el grid)
        //3.79 Abel    07/03/2020 (Endumar) Se incluye el botón Cobros, donde se incluirá todo lo relativo a los cobros de ENDUMAR y la caja del día  
        //3.78 Encarni 04/03/2020 (Dialpesca) Al cargar la Facturación Propia seleccione por defecto la periodicidad=diaria
        //3.77 Encarni 26/02/2020 (Dialpesca-Valpeix) Poner filtro de periodicidad en Facturación Propia (DETALLISTAS (detcpm) puede ser 'D', 'S', 'Q', 'M')
        //3.76 Encarni 26/02/2020 Modificar la exportación a contaplus cobros OREMAPE 'frmEXPORT_CPLUS_CobORE' para solucionar el error que genera al exportar sólo RECOBROS
        //3.75 Encarni 25/02/2020 Modificar la clase 'clase_linea_albcom' porque al insertar en COMALB_LINEAS da un error de que 'ComLim' es un campo calculado.
        //                        Esto me imagino que es porque en ENDUMAR el campo ComLim (COMALB_LINEAS) no es un campo calculado y se puede hacer INSERT en ese campo
        //                        (Sólo Dialpesca) Modificar el albarán de compras para que al crear la partida le pase el campo del ARTICULO(AnomCongel) a PARTIDAS(CondEsps)
        //3.74 Encarni 17/02/2020 Unificar mis versiones 3.63, 3.64 y 3.65 con las versiones de Abel
        //                        3.65 Encarni. (Valpeix) Facturación periódica (frmFPVPeriodo) poner nuevo campo Fecha factura, por defecto la fecha de hoy
        //                        3.64 Encarni. (Valpeix) Nuevo informe de rendimientos según formato pasado por María
        //                        3.63 Encarni. (Valpeix) Modificar el formato de la factura y cambiar el nuevo logo
        //                                      Modificar la facturación periódica para que tenga en cuenta todos los detallistas con DetTve=4 (F.Propia, NO FACTURAR) y que tengan DetCpm distinto de nulo                
        //3.73 Abel 09/02/2020  Se incluye Segarra(9057) en el grupo de los gastos a 0,50. Solucionado problema de Cotiers que no tiene Barco asignado
        //3.72 Abel 04/2/2020   Se soluciona problema que impedia añadir linea a ENDUMAR y se actua sobre el listado de gastos
        //3.71 Abel 01/2/2020   Se soluciona problema que impedia añadir linea para compras de ENDUMAR
        //3.70 Abel 29/1/2020   Se agregan totales de gastos y gastos+BI al listado de Compras
        //3.69 Abel 27/1/2020   Total de Kilos y Base imponible en listado y arregalado gastos de Calpe y SanCarlos
        //                      Arregladas Zonas de Captura y Fechas de desembarco, etc.
        //3.68 Abel 20/1/2020   Corregido problema con la fórmula de los gastos en el Listado del Albarán de ENDUMAR
        //3.67 Abel 17/1/2020   Se graba ComLim para ENDUMAR para que los sistados y todo salga perfecto
        //                      Y se ajusta FCaptura y Desembarco para que sea la fecha del dia anterior según Celia
        //                      También se soluciona el problema de la grabación de la matrícula del Barco en la grabación de Partida
        //3.66 Abel 2/1/2020    Se hace que al grabar albarán de compras de ENDUMAR el foco vaya al código de proveedor.
        //3.65 Abel 10/12/2019 Se colorean los textbox enfocados en Entradas de Compras de ENDUMAR y se corrige el pto de desembarco para lineas diferentes de la 1
        //3.64 Abel 4/12/2019  Se incluye el total+gastos en la estadística de compras por proveedor de ENDUMAR.
        //          8/12/2019  Se incluye total de linea entes de insertarla y botón de Borrar Albarán en Albaran de compras ENDUMAR.
        //3.63 Abel 2/12/2019 Se corrige elListado de Compras para ENDUMAR, ahora apunta a la base de datos OREMAPEREMdb y además se ha puesto en la fórmula de CR además del intervalo de fechas, horas
        //              para que salga todo entre las 00:00:00 y 23:59:00. Si no se pone esto, No salen las lineas porque llevan marcada la hora de grabación
        //3.62 Abel 28/11/2019  Arreglos en el Listado de Compras por Proveedores y Albaranes
        //3.61 Encarni. Modificar el Albarán de compras de ENDUMAR (frmCOMPRAS_Entrada_ENDU) para que si proveedor es el 33, 266 o 9057 los Gastos los calcule así (16%*BI + 0,50*totalKilos) 
        //              Modificar el Buscador de albaranes (frmCOMPRAS_Albaranes) para que al cargar muestre los albaranes del filtro de fechas, desde 01/01/año actual hasta dia de hoy
        //3.60 Abel.    Modificación para ENDUMAR. Se añade el Listado de Ventas por Proveedor para ENDUMAR.
        //              Se añade el Listado de Compras por Artículo. Sin terminar para ENDUMAR
        //3.59 Abel.    Modificar el Albarán de compras de ENDUMAR (frmCOMPRAS_Entrada_ENDU) para que incluya total+gastos, la tecla F12.
        //3.58 Encarni. Modificar el Albarán de compras de ENDUMAR (frmCOMPRAS_Entrada_ENDU) para añadir Total cajas, Total kilos y Gastos (16%*BI + 0,40*totalKilos)
        //3.57 Abel.    Se introduce Albarán de compras de ENDUMAR que tendrá algunas particularidades con respecto al otro.
        //3.56 Encarni. (Cefalópodos) Modificar para que no exporte los Albaranes anulados
        //3.55 Encarni. Adaptar Cercle17 para Cefalópodos (CERCLE_100,9). Exportar Albaranes de ventas filtrados por fecha y Artículos
        //3.54 Encarni. (Valpeix) Modificar el formato de la factura según modelo
        //3.53 Encarni. Adaptar Cercle17 para Valpeix (CERCLE_100,8), con la funcionalidad de Dialpesca
        //3.52 Abel     Modificar para añadir CExp1, 2, 3 y ConEsps Pero la parte ce CExp está un poco chapuza ya que no lo coge de la tabla. Version para Endumar. En Entrada de Albaranes de Compras
        //3.51 Encarni. Modificar el frmCOMPRAS_Entrada para insertar en la Partida los siguientes campos: Pais (lo coge del Proveedor, si no tiene pondremos 'ESPAÑA'), PExpedidor1 (Proveedor 'ProNom'), PExpedidor2 (Proveedor, 'ProDom'), NRS1 (Control, 'ConRsa1'), NRS2 (Control, 'ConRsa2') y NRS3 (Control, 'ConRsa3')
        //3.50 Encarni. (Dialpesca) Modificar el frmFPVPropia (Fact. Propias) para que filtre por fechas desde y hasta. También poner fecha factura para poder crear la factura con esta fecha.
        //                          Modificar el frmEXPORT_CPLUS_FraORE (Exportar a contaplus cobros facturas ventas) para poder seleccionar todos.
        //3.49 Abel.    (Endumar y todos) Si no existe el campo ArtCodPadre se grea en las Bases OREMAPEREMdb y ENLACE1db
        //3.48 Abel.    (Endumar) Se habilita el botón de entrada de Compras
        //3.47 Encarni. (Dialpesca) Modificar la exportación a Contaplus de facturas ventas, ventas2 y Oremape para que en el Concepto pase : VENTA MERC. FRA. XXXX-X
        //3.46 Encarni. (Botella) Al exportar a excel, Facturas propias y Facturas OREMAPE, si no tienen recargo que ponga %RE='' y RE='' 
        //3.45 Encarni. (Carabal) Cambiar la nueva serie AR de facturación semanal a AW porque ésta se utiliza con las facturas rectificativas.
        //3.44 Encarni. (Carabal) Cambiar la serie AS de facturación semanal a AR porque OREMAPE utiliza AS. Modificar el frmFPVPeriodo función 'Proceso'
        //3.43 Encarni. Error excel, en Referencias Microsoft.Office.Interop.Excel configurar Incrustar tipos de interoperabilida a true
        //3.42 Encarni. (Botella) Al exportar excel ponga la fecha como dd/mm/aaaa y el total con formato decimal
        //              Modificar el frmEmpr04, exportación a excel, y poner intervalo de fechas (desde-hasta) y agrupar exportación en el mismo excel. Crear carpeta con la fecha del campo 'Hasta'.
        //              Modificar todas las exportaciones a excel para que exporte 430 + DetCod (últimos 4 dígitos). Los DetCod 79000 quitará el 7, 4309000
        //              Al exportar los Cobros de Oremape poner en descripción 'Número de Serie + Número de factura' y poder diferenciar los que son Abonos crédito (serie S o M - Cuenta 5720025) y los que son Cobro caja (serie C - Cuenta 5700000)
        //              Al exportar los Cobros Propios diferenciar entre Abono crédito (campo 'DetMay' de la tabla DETALLISTAS tiene valor, empieza con 8 - Cuenta 5720025) y Cobro caja (campo 'DetMay' no tiene valor - Cuenta 570000)
        //3.41 Encarni. (Botella) Modificar exportar facturas y cobros OREMAPE para que lo haga a la vez
        //3.40 Encarni. (Carabal) Cambiar la serie AM de facturación mensual a AN porque OREMAPE utiliza AM. Modificar el frmFPVPeriodo función 'Proceso'
        //3.39 Encarni. (Botella) Añadir funcionalidad de exportar facturas y cobros OREMAPE a excel en frmEmpr04
        //3.38 Encarni. (Botella) Añadir funcionalidad de exportar cobros facturas propias a excel en frmEmpr04
        //3.37 Encarni. (Dialpesca) Error en 'frmCOMPRAS_Entrada' al buscar el proveedor. Se modifica el evento 'btnProvBuscar_Click' para que al llamar a la función 'CargarDatosProveedor' le pase el ProCod
        //3.36 Encarni. (Botella) Añadir funcionalidad de exportar facturas a excel en frmEmpr04
        //              clase_Excel: modificar el método 'exportarExcel' para que finalice el proceso EXCEL.EXE
        //3.35 Encarni. Se modifica frmEXPORT_CPLUS_CobORE para que funcione para todos los Usuarios, se comenta la línea if (frmPpal.USUARIO == "5") //DIALPESCA
        //              Esto se hace por el error detectado en CARABAL                    
        //3.34 Encarni. (Dialpesca) Modificar el albarán de compras para que ponga la Zona de captura y Fecha de captura. Por defecto cogerá los datos del proveedor pero si el artículo 
        //              tiene ZFao pondrá esta
        //3.33 Encarni. (Dialpesca) Modificar el cobro de la factura para que al cobrar la factura completa (pendiente = 0) cobre todos los albaranes donde IdCobro sea igual a null
        //              (Dialpesca) Modificar BBDD OREMAPEREMdb y crear la tabla TRANSFERENCIAS y añadir campo IdCobroFact
        //3.32 Encarni. (Carabal) Nuevo listado de compras agrupado por proveedor
        //3.31 Encarni. Modificar listado de ventas para que muestre el total de los kilos.
        //              Modificar los permisos del 'frmCENTRAL_Export_Contaplus.cs' para que el perfil CAJERO vea 'Exportar a contaplus cobros en caja'
        //3.30 Encarni. Modificar el formulario 'frmFPVentas' porque al "Ver factura" te pedía el parámetro 'detcod' del informe. Esto viene por la versión 3.28
        //              (Carabal) Nuevo listado de ventas agrupado por detallista
        //3.29 Abel. Se modifica frmEXPORT_CPLUS_CobORE para soportar los dos tipos de ficheros de cobros que envía Oremape unos con 35 caracteres en cada linea y otros con 36
        //3.28 Encarni. (Dialpesca). Modidicar el informe de la factura de venta para que muestre el código del detallista
        //3.27 Encarni. Modificar el mantenimiento de artículos: añadir campo 'Etiqueta obligatoria' y añadir más tipos en el desplegable.
        //              Modificar BBDD OREMAPEREMdb Y ENLACEdb tabla ARTICULOS (Tipo1, varchar(2))
        //3.26 Encarni. Modificar el filtro de fechas del listado de albaranes de compras porque no funcionaba bien.
        //              Modificar el informe de Listar albaranes agrupados para que muestre la partida (Referencia).
        //              Terminar el informe de Listar albaranes hojas separadas
        //3.25 Encarni. Crear el fichero SubCuentas (Detallistas) para exportar a Contaplus
        //3.24 Abel. Se incluye en la partida el relleno de los campos de AlbCompras y FCompras en la entrada de albaranes de compras
        //3.23 Abel. Derivado del anterior un error consistente en que al modificar una linea sin cuadrar la deja cuadrada a fecha '1-1-1900'
        //3.22 Abel. Se corrige el problema detectado consistente en que al modificar precio de una linea de albarán de compras, se descuadra la partida FCua=""
        //3.21 Abel. Se arregla el problema de volver a cargar un albarán para modificarlo. Problema relacionado con campo Facturado de COMALB_LINEAS
        //3.20 Abel. Varias trazas en cuadre y en entrada de compras para ver donde está el problema de que se descuadran partidas.
        //3.20 Abel. Incorporamos ver e Imprimir albaranes de compras agrupados Para DialPesca.
        //3.19 Abel. Incorporamos botón para Valpeix CERCLE100=6 para que haga el cuadre como DIALPESCA 
        //3.18 Abel. Se habilita Exportacion Contaplus Cobros de Facturas de Ventas para Dialpesca
        //3.18 Abel. Resolvemos el problema de los abonos. Al generar el albarán de ventas da un error de clave duplicada porque está cogiendo albarán 0  : No se modifica nada. Se detecta QUE NO PUEDE HABER TABLET 00
        //3.17 Abel. Solucionado exportación a excel de Listado de Rendimiento06
        //3.16 Abel. Solucionado el problema de los decimales de listados excell. Modificada prinbcipalmente clase Excell y algunos retoques de estilo de forms.
        //3.15 Abel. Se tratan de solucionar problemas de Abonos ajustando por defecto el Vendedor 1000 y el IdTipoCobro a 0 CONTADO
        //3.14 Abel. Se modifica frmSeleccionDatos para que en el listado de existencias (Report 8) Se incluyan los artículos con existencias en negativo. Solo se excluyen los artículos cuadrados
        //3.13 Abel. Se establece CERCLE_100=6 para ABT y se incluye en la exportación de facturas de Oremape a Contaplus la letra de la serie en el concepto de la factura. Pedido ABT
        //3.12 Abel. Según Juanjo para Dialpesca CERCLE_105 Eliminamos la posibilidad de facturar en Facturación Manual Albaranes de tipo 3 CONTADO OREMAPE
        //3.11 Abel. Se habilita el botón de Abonos para Dialpesca(5) y se incluye la serie de Oremape en la factura de oremape cuando pasa a contaplus
        //3.10 Abel. Modificamos frmSeleccionDatos en lo referente a Report 3 que es el listado de Facturas para que aparezcan las correspondientes a Cobradas, Pendientes o todas.
        //3.09 Abel. Añadimos la posibilidad de facturar los albaranes de tipo de venta 5 para Dialpesca usamos CERCLE_105
        //3.07 Encarni. Modificar algunas cosillas de albaranes de compra
        //3.06 Encarni. Desarrollo de albaranes de compras
        //3.05 Abel. Incorporo los frmCOMPRAS y frmCOMPRAS_Entrada para que Encarni pueda desarrollar
        //3.04 Encarni. (Botella) Modifico la consulta de Cobros Caja para que agrupe por FechaCobro y no por VenFec
        //3.03 Encarni. (Botella) Modifico la función 'exportarExcel' de la clase_excel para que haga la suma total de la columna que le pasamos como parámetro.
        //     Modifico las consultas de Ventas Caja y Ventas Banco para la exportación a excel.
        //     Modifico las consultas de Cobros Caja y Cobros Banco para que cumplan el nuevo formato que quiere Botella.
        //3.02 Abel. Solo una pequeña modificación al Listado de stock por artículos que en la formula de crystal ponia FCua=NULL. Esto en crystal da error por lo que ha 
        //      habido que sustituirlo por ISNULL(FCua)
        //3.01 Encarni. Modificaciones para Dialpesca: Cuadre, Listado de diferencias de stock, Facturación propia agrupar por Detallista, Informe factura nuevo para Dialpesca
        //3.00 Abel. Últimos ajustes en el fichero de Botella. espero que ya esté bien.
        //2.99 Abel. Se modifican unas cuantas cosas para la exportación a excell de Botella según correos recibidos.
        //2.98 Encarni. Cambio la propiedad Copia local = true en la libreria de Microsoft.Office.Interop.Excel para que la exportación a excel funcione en versiones antiguas de excel 
        //2.97 Encarni. Exportar a excel desde 'frmEmpr04' (modificaciones a Botella)
        //2.96 Abel. Se añade frmEmpr05 y frmEmpr05_CUADRE para soportar el cuadre en Dialpesca
        //2.94 Abel. Se modifica frmEXPORT_CPLUS_CobORE para que ponga en todos los albaranes la fecha del Cobro como fecha del Albarán ya que si no ContaPlus da un 
        //      error a la hora de importar el asiento, ya que ytodos los apuntes del asiento han de tener la misma fecha. El error que da es:
        //      
        //2.93 Abel. Añado Listado de Stock por Artículos, basado en tabla de PARTIDAS y solamente visible para Mayorista con CERCLE_100=5
        //2.92 Listado de rentabilidad de vendedores 06 (Excel), modifico la consulta SQL por el error del tipo de datos Date que no reconoce el SQL Server 2005
        //2.91 Listado de rentabilidad de vendedores 06 (Excel)
        //2.90 Abel. Ajuste de visualización de botones en frmFACTURACION para que en Llorens no aparezcan funcionalidades no usadas
        //2.89 Modificaciones para la nueva empresa:
        //     Nueva facturación propia: creará una factura de la serie AA por cada albarán
        //     Nueva exportación a contaplus para SAGE 50
        //2.88 Modificaciones exportación contaplus facturas propias, se modifica el campo TerIdNif para que pase 1
        //     Se modifican las tres exportaciones ( Oremape, Propias y 8000s) para que quite del NIF el guión
        //2.87 Modificaciones exportacion contaplus facturas de 8000s
        //2.86 Modificaciones exportación contaplus facturas de OREMAPE se añade el nif y el nombre del detallista
        //2.85 Modificaciones en la emisión facturas rectificativas
        //2.84 En construcción
        //2.83  Se implementa La exportación de 8000 con datos de total y desglose IVA
        //2.81  Se Implementa la Facturación Manual para hacer los albaranes de 8000 para Carabal       
        //2.80  Se implementa la Facturación de Nuevos albaranes de Abono
        //2.46 Se pone tw.close al final de la exportación a Contaplus de facturas de OREMAPE para que no se coma la última linea del fichero
        //     También se le pone la banda estandar superior de botones a frmFACTURACIÓN
        //2.68 Se quita de los listados de contabilidad los totales para que la exportación a Excell sea más manejable CR002 y CR005.
        //2.69 Se modifica frmPpal para mejorar el acceso seguro de los usuarios (Carabal). Se modifica Load y Seguridad
        //2.70 Modifica Encarni y pone Mantenimiento de Articulos y Detallistas
        //2.71. Abel. Modifica Funciones.Nuevo_Albarán para que incorpore el numero de tablet en el intervalo a obtener el número de albarán
        //      Se modifica frmSeleccionaDATOS.button_Exportar_Click para que excluya a los detallistas cuyo campo sea DetMay en blanco (modificados
        //      tras haber sido incluidos en la lista.
        //2.72. Se incluye la opción Todos los Proveedores en frmFCProveedor
        //2.73. Se incluye un subtotal para piunteo de proveedores conteniendo el total de los albaranes seleccionados
        //2.74. Retoques formales y de control de logs tras descubrir quees necesario el Native Client 11 para que los reports salgan correctamente.
        //2.75 en frmEXPORT_CPLUS_FraORE hacemos una incursión para comprobar que se pueden crear y borrar ficheros dbf por un posible intento de generar 
        //      ficheros en este formato para poder importarlos en ContaPlus.
        //      Se modifica Mantenimiento de Artículos para soportar el Tipo2 de Carabal.
        //2.76. Se adopta CERCLE_100 3 para Endumar y 4 Para Botella
        //      Se actúa sobre frmSeleccionDatos.button_Exportar_Click para que no pasen los albaranes de Detallistas que han dejado de tener un código DetMay
        //      Se añade frmEmpr03_CUADRE para los mayoristas que deseen cuadrar.
        //2.77. Se hacen modificaciones que afectan a frmEmpr03_CUADRE para mejorar el proceso de ENDUMAR
        //2.79  Se da acceso a listado de facturas del perfil CAJERO de carabal

        public static string gSubCtaVENTAS;
        public static string gSubCtaIVA1;
        public static string gSubCtaREQ1;
        public static string gSubCtaBANCO;
        public static string gSubCtaCAJA;
        public static string gSubCtaIVAconReq;

        public static SqlConnection gcnO;      //Conexión a OREMAPE global
        public static string TeMp;              //para usos diversos pero breves

        public static string PerfilUser;        //Perfil de usuario que se empleará para mostrar controles

        public static Int16 TIPO_REPORT = 0;    //Tipo de Listado. Se usa para identificar el listado de Crystal reports.
        public static string sQReport = "";

        public static string TIPO_CONSULTA = "DETALLISTAS";

        public static string Cod_Buscado="";       // Se usarán para consultas
        public static string Nom_Buscado = "";    // Se usarán para consultas

        public  static clase_UTILESdb gUTIL ;

        public static string gCadConRem = "";       //Cadena de conexión a la base de datos remota
        public static SqlConnection gConRem;        //Objeto SqlConnection de conexión a la base remota
        public static string gCadConEnlace = "";    //Cadena de conexión a la base de datos enlace
        public static SqlConnection gConEnlace;     //Objeto SQLConnection a la base de datos de ENLACE      
        public static SqlConnection gConEndu;       //Objeto SQLConnection a la base de datos de ENDUMARdb      
        public static string gFichTraza = "";       //Nombre del Fichero para guardar la traza
        public static FileStream gFTraza;           //Fichero de Traza Propiamente dicho
        public static StreamWriter gApunta;         //puntero para escribir en el fichero de traza
        public static Boolean TrazaAbierta = false; // Para saber si el fichero de traza está abierto o cerrado
        public static string gIdent = "";           //Identificará  cada formulario y method que nos ubiquemos para pasarlo a la traza

        public static string gLOCAL_SERVER;
        public static string gLOCAL_BD;
        public static string gLOCAL_UI;
        public static string gLOCAL_PWD;
        public static string gLOCAL_PORTDB;
        public static string gREMOTO_SERVER;
        public static string gREMOTO_BD;
        public static string gREMOTO_UI;
        public static string gREMOTO_PWD;
        public static string gREMOTO_PORTDB;
        public static string gCERCLE_100;
        public static string gCERCLE_103;
        public static Boolean  gCERCLE_105=false ;
        public static string gPATH_IMAGES_REMOTO;
        public static string gNUMERO_TABLET;

        public static string gNombreMaquina=Environment.MachineName ;

        public static string gMayCod;               // Albergará el código del mayorista
        public static string gIdVendedor;           //El IdVendedor que ha iniciado sesion
        public static string gIdTipoCobro;          //Tipo de cobro que se hace. Normalmente 0  es efectivo

        public static clase_detallista gDETBUSCADO;
        public static clase_detallista gACRBUSCADO;
        public static Image gIMAGEN_FONDO_TICKET;
        public static string gBD;                   //Base de datos. Uso para ENDUMAR algunas veces
        public static string gIMPRESORA_DERECHA;
        public static string gPathExcell;           //Cogerá el valor de ConPathExcell de la tabla de control y es el path donde se guardarán lso ficheros excell
        public static clase_detallista1 g8048;            //Almacena los datos del detallista 8048 para ENDUMAR

    }
}      