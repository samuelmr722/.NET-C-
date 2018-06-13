using System;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;


namespace CalidadDatosDeudores
{
    public class Excel
    {

        public Excel()
        {
            strError = string.Empty;
            dt = new System.Data.DataTable();
        }

        #region"Atributos"
        public string strError;
        private System.Data.DataTable dt;
        private String[] excelSheets;
        #endregion

        #region"Propiedades"
        public string Error
        { get { return strError; } }

        public System.Data.DataTable tablita
        { get { return dt; } }

        public String[] Vector
        { get { return excelSheets; } }

        #endregion

        public bool GenerarExcel(DataSet ds)
        {
            try
            {
                //creo el excel
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excelApp;
                Microsoft.Office.Interop.Excel.Workbook myworkbook;
                Microsoft.Office.Interop.Excel.Worksheet myWorkSheet;

                //nueva aplicación excel.
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                excelApp.ScreenUpdating = true;

                //añadimos un workbook
                myworkbook = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                int i = 0;

                foreach (System.Data.DataTable dataTable in ds.Tables)
                {
                    //selecciono la última worksheet creada para escribir ahí los datos
                    myWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myworkbook.Sheets[i + 1];
                    myWorkSheet.get_Range("A1", "XFD1048576").NumberFormat = "@";
                    if (ds.Tables[i].Columns[0].ColumnName.Length >= 30)
                    {
                        myWorkSheet.Name = ds.Tables[i].Columns[3].ColumnName.Substring(0, 30);
                    }
                    else
                    {
                        myWorkSheet.Name = ds.Tables[i].Columns[3].ColumnName;
                    }

                    //Colocamos los titulos
                    int f = 1;
                    foreach (DataColumn col in ds.Tables[i].Columns)
                    {
                        myWorkSheet.Cells[1, f] = col.Caption.ToString();
                        f++;
                    }

                    //Pegamos la data
                    int rowIndex = 2;
                    foreach (DataRow row in ds.Tables[i].Rows)
                    {
                        int columnIndex = 1;

                        foreach (object dc in row.ItemArray)
                        {
                            myWorkSheet.Cells[rowIndex, columnIndex] = dc.ToString();
                            columnIndex++;
                        }
                        rowIndex++;
                    }
                    myworkbook.Worksheets.Add(misValue, excelApp.ActiveWorkbook.Worksheets[excelApp.ActiveWorkbook.Worksheets.Count], 1, misValue);
                    i++;
                }
                misValue = null;
                excelApp = null;
                myworkbook = null;
                myWorkSheet = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Excel - " + ex.Message;
                return false;
            }
        }

        public bool GetExcelSheetNames(string excelFile)
        {
            try
            {
                // Connection String. Change the excel file to the file you               
                String connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source= " + excelFile + " ;" + "Extended Properties=Excel 12.0 ";
                // Create connection object by using the preceding connection string.
                OleDbConnection objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    strError = "Clase Excel - No hay datos en el libro de excel";
                    return false;
                }

                excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString().Substring(0, row["TABLE_NAME"].ToString().Length - 1);
                    i++;
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Excel - " + ex.Message;
                return false;
            }
        }

        public bool CargarArchivo(string Ruta, string NombreHoja)
        {
            try
            {
                //string sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source= " + Ruta + " ;" + "Extended Properties=Excel 8.0 ";
                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source= " + Ruta + " ;" + "Extended Properties=Excel 12.0 ";
                string sqlExcel = "SELECT * FROM [Excel 8.0;Database=" + Ruta + "].[" + NombreHoja + "$]";
                DataSet dsCarga = new DataSet();
                OleDbConnection oledbConn = new OleDbConnection(sConnectionString);
                OleDbCommand oledbCmd = new OleDbCommand(sqlExcel, oledbConn);
                oledbConn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(oledbCmd);
                da.Fill(dsCarga);
                dt = dsCarga.Tables[0];
                dsCarga = null;
                oledbConn.Close();
                oledbConn = null;
                oledbCmd = null;
                da = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Excel - " + ex.Message;
                return false;
            }
        }
    }
}


