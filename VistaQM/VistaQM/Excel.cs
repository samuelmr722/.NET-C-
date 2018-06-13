using System;
using System.Data;
using System.Data.OleDb;


namespace VistaQM
{
    public class Excel
    {

        public Excel()
        {
            strError = string.Empty;
            dt = new System.Data.DataTable();
        }

        #region"Atributos"
        private string strError;
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

        public bool CargarArchivo(string Ruta, string NombreHoja)
        {
            try
            {
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
                DataTable dt = new DataTable();
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
                    excelSheets[i] = row["TABLE_NAME"].ToString().Replace("'", "").Replace("$", "");
                    i++;
                }
                objConn.Close();
                objConn = null;
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