using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace VistaQM
{
    class ConexionSQLite
    {
        #region"Atributos"
        private string strError = String.Empty;
        private DataTable dt;
        #endregion

        public string Error
        { get { return strError; } }

        public DataTable Tabla
        { get { return dt; } }

        public bool CrearBBDD()
        {
            try
            {
                // Creamos BD. 
                SQLiteConnection conexion = new SQLiteConnection("Data Source = Planes.sqlite;Version=3;New=True;Compress=True;");
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        public bool CrearTabla(string nametabla)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                // Creamos la conexion
                SQLiteConnection conexion = new SQLiteConnection("Data Source = Planes.sqlite;Version=3;New=True;Compress=True;");
                conexion.Open();

                // Creamos la tabla
                string creacion = "CREATE TABLE IF NOT EXISTS " + nametabla + " (Centro varchar(500),Utilizacion varchar(500),StatusHojaRuta varchar(500),PuestoTrabajo varchar(500),ClaveControl varchar(500),DescripcionOperacion varchar(500),Caracteristica varchar(500),DescripcionCaracteristica varchar(500),ProcesoMuestreo varchar(500))";
                SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                conexion = null;
                cmd = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        public bool EliminarTabla(string nametabla)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                // Creamos la conexion
                SQLiteConnection conexion = new SQLiteConnection("Data Source = Planes.sqlite;Version=3;New=True;Compress=True;");
                conexion.Open();

                // Creamos la tabla
                string creacion = "DROP TABLE IF EXISTS " + nametabla;
                SQLiteCommand cmd = new SQLiteCommand(creacion, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                conexion = null;
                cmd = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        public bool CargarExcel (DataTable MyDataTable,string nametabla)
        {
            try
            {
                // Creamos la conexion
                SQLiteConnection conexion = new SQLiteConnection("Data Source=Planes.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                using (var cmd = new SQLiteCommand(conexion))
                {
                    using (var transaction = conexion.BeginTransaction())
                    {
                        // inserts
                        int Fila = 0;
                        foreach (DataRow row in MyDataTable.Rows)
                        {
                            cmd.CommandText = "INSERT INTO " + nametabla + " (Centro ,Utilizacion ,StatusHojaRuta ,PuestoTrabajo ,ClaveControl ,DescripcionOperacion ,Caracteristica ,DescripcionCaracteristica ,ProcesoMuestreo ) VALUES ("
                            + "'" + MyDataTable.Rows[Fila][0].ToString() + "','" + MyDataTable.Rows[Fila][1].ToString() + "','" + MyDataTable.Rows[Fila][2].ToString() + "','" + MyDataTable.Rows[Fila][3].ToString() + "','" + MyDataTable.Rows[Fila][4].ToString() + "','" + MyDataTable.Rows[Fila][5].ToString() + "','" + MyDataTable.Rows[Fila][6].ToString() + "','" + MyDataTable.Rows[Fila][7].ToString() + "','" + MyDataTable.Rows[Fila][8].ToString() + "')";
                            cmd.ExecuteNonQuery();
                            Fila++;
                        }                        
                     transaction.Commit();
                    }
                }

                conexion.Close();
                conexion = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }

        }

        public bool ConsultarTablas()
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                SQLiteConnection conexion = new SQLiteConnection("Data Source=Planes.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                // Lanzamos la consulta y preparamos la estructura para leer datos
                string consulta = "select name NombreNodo from sqlite_master where type = 'table'";
                SQLiteCommand Objcoman = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter objAdapter = new SQLiteDataAdapter(Objcoman);
                DataTable objTable = new DataTable();
                objAdapter.Fill(objTable);
                dt = objTable;
                conexion.Close();
                conexion = null;
                objAdapter = null;
                objTable = null;
                Objcoman = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE Co::: " + ex.Message;
                return false;
            }
        }

        public bool LlenarGrilla(DataGridView datos,string tabla)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                SQLiteConnection conexion = new SQLiteConnection("Data Source=Planes.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();

                // Lanzamos la consulta y preparamos la estructura para leer datos
                string consulta = "select * from " + tabla;
                SQLiteCommand Objcoman = new SQLiteCommand(consulta, conexion);
                SQLiteDataAdapter objAdapter = new SQLiteDataAdapter(Objcoman);
                DataTable objTable = new DataTable();
                objAdapter.Fill(objTable);
                datos.DataSource = objTable;
                datos.Refresh();
                datos.AutoResizeColumns();
                datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                conexion.Close();
                conexion = null;
                objAdapter = null;
                objTable = null;
                Objcoman = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        private bool ValidarDB()
        {
            try
            {
                if (!File.Exists("Planes.sqlite"))
                {
                    if (MessageBox.Show("CLASE ConexionSQLite::: No existe la base de datos Planes 'Planes.sqlite', desea crearla?.", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CrearBBDD();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool GenerarDataMarestra(DataTable tb, string nametable, DataGridView datos)
        {
            try
            {
                if (!ValidarDB())
                {
                    return false;
                }
                // Creamos la conexion
                SQLiteConnection conexion = new SQLiteConnection("Data Source = Planes.sqlite;Version=3;New=True;Compress=True;");
                conexion.Open();

                //Crear, Insertar y consultar
                using (var cmd = new SQLiteCommand(conexion))
                {
                    using (var transaction = conexion.BeginTransaction())
                    {
                        //Crear tabla
                        cmd.CommandText = "CREATE TABLE IF NOT EXISTS Deltas (Material varchar(500),Centro varchar(500))";
                        cmd.ExecuteNonQuery();

                        // Inserts
                        int Fila = 0;
                        foreach (DataRow row in tb.Rows)
                        {
                            cmd.CommandText = "INSERT INTO Deltas (Material,Centro) VALUES ('" + tb.Rows[Fila][0].ToString() + "','" + tb.Rows[Fila][1].ToString() + "')";
                            cmd.ExecuteNonQuery();
                            Fila++;
                        }
                        transaction.Commit();
                    }

                    //Consultar
                    cmd.CommandText = "select d.Material,d.Centro ,i.Utilizacion ,i.StatusHojaRuta ,i.PuestoTrabajo ,i.ClaveControl ,i.DescripcionOperacion ,i.Caracteristica ,i.DescripcionCaracteristica ,i.ProcesoMuestreo from Deltas d inner join " + nametable + " i on d.Centro = i.Centro order by Material,Utilizacion";
                    SQLiteDataAdapter objAdapter = new SQLiteDataAdapter(cmd);
                    DataTable objTable = new DataTable();
                    objAdapter.Fill(objTable);
                    datos.DataSource = objTable;
                    datos.Refresh();
                    datos.AutoResizeColumns();
                    datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    objAdapter = null;
                    objTable = null;

                    //Borramos tabla Delta
                    cmd.CommandText = "DROP TABLE IF EXISTS Deltas";
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                    conexion = null;                    
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