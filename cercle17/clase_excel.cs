using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using excel=Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;

namespace cercle17
{
    public class clase_excel
    {
        public SqlConnection CnO { get; set; }

        public string Query { get; set; }

        public string Path { get; set; }

        public string NombreFichero { get; set; }  
      
        private DataTable crearDataTable()
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(Query, CnO))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;          
        }

        //Parámetro opcional 'columnaTotal'. 
        //Si le pasamos la letra de la columna, por ejemplo, "P", nos hace la suma total de la columna en el excel
        //Si no le pasamos nada, no hace nada 
        public string exportarExcel(DateTime fecha, string columnaTotal = "", decimal total = 0 )
        {
            string error = "";

            excel.Application excelApp = new excel.Application();

            try
            {
                DataTable dt = crearDataTable();

                string directorio = Path + "\\" + fecha.ToString("yyyy-MM-dd") + "\\";
                string nomFichero = NombreFichero + ".xlsx";
                GloblaVar.gUTIL.ATraza("Se va a exportar el fichero " + directorio + nomFichero);

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
               
                excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
                excel.Worksheet excelWorksheet = (excel.Worksheet)excelWorkbook.ActiveSheet;
                excelWorksheet.Name = NombreFichero;

                //Cabecera
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    excelWorksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }
                
                //Filas 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                        switch (dt.Columns[j].DataType.Name)
                        {
                            case "String":
                                excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString().Trim();
                                break;
                            case "DateTime":
                                if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                { 
                                    excelWorksheet.Cells[i + 2, j + 1] = Convert.ToDateTime(dt.Rows[i][j].ToString()).ToString("MM/dd/yyyy");
                                }
                                else
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = "";
                                }
                                break;
                            case "Int32":
                                excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                                break;
                            case "Decimal":
                                if(dt.Rows[i][j] == DBNull.Value)
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = "";
                                }
                                else
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                                }
                                break;
                            case "Single":
                                if (dt.Rows[i][j] == DBNull.Value)
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = "";
                                }
                                else
                                {
                                    excelWorksheet.Cells[i + 2, j + 1] = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                                }
                                break;
                            default:
                                excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                                break;
                        }//switch (dt.Columns[j].DataType.Name)
                    }
                }

                if (columnaTotal != "")
                {                   
                    ((excel.Range)excelWorksheet.Cells[dt.Rows.Count + 3, dt.Columns.Count]).Formula = string.Format("=SUMA({0}2:{0}{1})", columnaTotal, dt.Rows.Count + 1);
                }

                if(total != 0)
                {
                    excelWorksheet.Cells[dt.Rows.Count + 3, dt.Columns.Count] = Math.Round(total,2);
                }

                excelWorkbook.SaveAs(directorio + nomFichero);


            }
            catch (Exception ex)
            {
                error += "Al exportar a excel se ha producido el siguiente error: \n\n" + ex.Message;
                GloblaVar.gUTIL.ATraza("clase_excel.exportarExcel. " + ex.Message);
            }
            finally
            {           
                //Este código es para que mate el proceso EXCEL.EXE
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (excelApp != null)
                {
                    excelApp.Quit();
                    int hWnd = excelApp.Application.Hwnd;
                    uint processID;
                    GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                    Process[] procs = Process.GetProcessesByName("EXCEL");
                    foreach (Process p in procs)
                    {
                        if (p.Id == processID)
                            p.Kill();
                    }
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }
           
            return error;
            
        }

        public string exportarExcelArticulos(DateTime fecha)
        {
            string error = "";

            excel.Application excelApp = new excel.Application();

            try
            {
                DataTable dt = crearDataTable();

                //string directorio = Path + "\\" + fecha.ToString("yyyy-MM-dd") + "\\";
                string directorio = Path + "\\";
                string nomFichero = NombreFichero + ".xls";
                GloblaVar.gUTIL.ATraza("Se va a exportar el fichero " + directorio + nomFichero);

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
                excel.Worksheet excelWorksheet = (excel.Worksheet)excelWorkbook.ActiveSheet;
                excelWorksheet.Name = NombreFichero;                
                
                //Filas 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //excelWorksheet.Range["A1"].Value2 = "Range 1";
                        excelWorksheet.Range[dt.Columns[j].ColumnName + (i+1).ToString()].Value2 = dt.Rows[i][j].ToString();
                    }
                }               

                excelWorkbook.SaveAs(directorio + nomFichero);

            }
            catch (Exception ex)
            {
                error += "Al exportar los Artículos a excel se ha producido el siguiente error: \n\n" + ex.Message;
                GloblaVar.gUTIL.ATraza("clase_excel.exportarExcelArticulos. " + ex.Message);
            }
            finally
            {
                //Este código es para que mate el proceso EXCEL.EXE
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (excelApp != null)
                {
                    excelApp.Quit();
                    int hWnd = excelApp.Application.Hwnd;
                    uint processID;
                    GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                    Process[] procs = Process.GetProcessesByName("EXCEL");
                    foreach (Process p in procs)
                    {
                        if (p.Id == processID)
                            p.Kill();
                    }
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }

            return error;

        }

        public string exportarExcelVentas(DateTime fecha)
        {
            string error = "";

            excel.Application excelApp = new excel.Application();

            try
            {
                DataTable dt = crearDataTable();

                string directorio = Path + "\\" + fecha.ToString("yyyy-MM-dd") + "\\";                
                string nomFichero = NombreFichero + ".xls";
                GloblaVar.gUTIL.ATraza("Se va a exportar el fichero " + directorio + nomFichero);

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
                excel.Worksheet excelWorksheet = (excel.Worksheet)excelWorkbook.ActiveSheet;
                excelWorksheet.Name = NombreFichero;

                //Filas 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {   
                        switch (dt.Columns[j].DataType.Name)
                        {
                            case "String":
                                excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = dt.Rows[i][j].ToString().Trim();
                                break;
                            case "DateTime":
                                if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = Convert.ToDateTime(dt.Rows[i][j].ToString()).ToString("MM/dd/yyyy");
                                }
                                else
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = "";
                                }
                                break;
                            case "Int32":
                                excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = dt.Rows[i][j];
                                break;
                            case "Decimal":
                                if (dt.Rows[i][j] == DBNull.Value)
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = "";
                                }
                                else
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                                }                                
                                break;
                            case "Single":
                                if (dt.Rows[i][j] == DBNull.Value)
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = "";
                                }
                                else
                                {
                                    excelWorksheet.Range[dt.Columns[j].ColumnName + (i + 1).ToString()].Value2 = Math.Round(Convert.ToDecimal(dt.Rows[i][j]), 2);
                                }                                    
                                break;
                            default:
                                excelWorksheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                                break;
                        }//switch (dt.Columns[j].DataType.Name)
                    }
                }

                excelWorkbook.SaveAs(directorio + nomFichero);

            }
            catch (Exception ex)
            {
                error += "Al exportar las Ventas a excel se ha producido el siguiente error: \n\n" + ex.Message;
                GloblaVar.gUTIL.ATraza("clase_excel.exportarExcelVentas. " + ex.Message);
            }
            finally
            {
                //Este código es para que mate el proceso EXCEL.EXE
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (excelApp != null)
                {
                    excelApp.Quit();
                    int hWnd = excelApp.Application.Hwnd;
                    uint processID;
                    GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                    Process[] procs = Process.GetProcessesByName("EXCEL");
                    foreach (Process p in procs)
                    {
                        if (p.Id == processID)
                            p.Kill();
                    }
                    Marshal.FinalReleaseComObject(excelApp);
                }
            }

            return error;

        }

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);      


    }
}
