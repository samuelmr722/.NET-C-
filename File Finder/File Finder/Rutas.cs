using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace File_Finder
{    
    class Rutas
    {
        #region"Atributos"              
        private string strError = String.Empty;
        #endregion    
    
        public string Error
        { get { return strError; } }

        public bool CrearBBDD()
        {
              try
              {                  
                    // Creamos la conexion a la BD. 
                    // El Data Source contiene la ruta del archivo de la BD 
                    SQLiteConnection conexion = new SQLiteConnection ("Data Source = RutasUsuario.sqlite;Version=3;New=True;Compress=True;");
                    conexion.Open();

                    // Creamos la primera tabla
                    string creacion = "CREATE TABLE Rutas (Codigo INTEGER PRIMARY KEY AUTOINCREMENT , Ruta VARCHAR(500));";
                    SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    conexion = null;
                    cmd = null;
                    return true;
              }
              catch(Exception ex)
              {
                    strError = "CLASE RUTAS::: " + ex.Message;                    
                    return false;
              }
        }

        public bool EjecutarQuery(string insercion)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                SQLiteConnection conexion =  new SQLiteConnection ("Data Source=RutasUsuario.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                SQLiteCommand Objcoman = new SQLiteCommand(insercion, conexion);
                Objcoman.ExecuteNonQuery();
                conexion.Close();
                conexion = null;
                Objcoman = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE RUTAS::: " + ex.Message;
                return false;                
            }
            
        }

        public bool LlenarGrillaRutas(DataGridView dgvRutas)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                SQLiteConnection conexion = new SQLiteConnection("Data Source=RutasUsuario.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                // Lanzamos la consulta y preparamos la estructura para leer datos
                string consulta = "select * from Rutas";
                SQLiteCommand Objcoman = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter objAdapter = new SQLiteDataAdapter(Objcoman);       
                DataTable objTable = new DataTable();
                objAdapter.Fill(objTable); 
                dgvRutas.DataSource = objTable; 
                dgvRutas.Refresh();
                dgvRutas.AutoResizeColumns();
                dgvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;       
                conexion.Close();
                conexion = null;
                objAdapter = null;
                objTable = null;
                Objcoman = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE RUTAS::: " + ex.Message;
                return false;
            }
        }

        public bool CargarTabla(DataTable TableRutas)
        {
            try
            {
                if (!ValidarDB())
                {                    
                    return false;
                } 
                SQLiteConnection conexion = new SQLiteConnection("Data Source=RutasUsuario.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                // Lanzamos la consulta y preparamos la estructura para leer datos
                string consulta = "select * from Rutas";
                SQLiteCommand Objcoman = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter objAdapter = new SQLiteDataAdapter(Objcoman);                
                objAdapter.Fill(TableRutas);                
                conexion.Close();
                conexion = null;
                objAdapter = null;
                Objcoman = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE RUTAS::: " + ex.Message;
                return false;
            }
        }

        private bool ValidarDB()
        {
            try
            {
                if (!File.Exists("RutasUsuario.sqlite"))
                {
                    strError = "CLASE RUTAS::: No existe la base de datos de rutas 'RutasUsuario.sqlite', utilice la opcion configuracion para crear una nueva  ";                                       
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }            
        }
    }
}



   

      


        

