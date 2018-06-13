using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y usar.
using System.Data;
using System.Data.SqlClient;

namespace Buscar_Factura
{
    public class ConexionBD
    {
        #region"Constructor"

        public ConexionBD()
        {
            objConexionBD = new SqlConnection();
            objCommand = new SqlCommand();
            objAdapter = new SqlDataAdapter();
            objDataset = new DataSet();
            //objReader = new SqlDataReader();
        }

        #endregion

        #region"Atributos"

        private string strStringConexion;
        private string strNombreTabla;
        private string strVrUnico;
        private string strSQL;
        private string strError;
        private bool blnAbrio;
        private SqlConnection objConexionBD;
        private SqlCommand objCommand;
        private SqlDataReader objReader;
        private SqlDataAdapter objAdapter;
        private DataSet objDataset;

        #endregion

        #region"Propiedades"

        public string SQL
        { set { strSQL = value; } }

        public string NombreTabla
        { set { strNombreTabla = value; } }

        public string ValorUnico
        { get { return strVrUnico; } }

        public string Error
        { get { return strError; } }

        public DataSet Midataset
        { get { return objDataset; } }

        public SqlDataReader Reader
        { get { return objReader; } }

        #endregion

        #region"Metodos Privados"

        private bool GenerarString()
        {
            Cls_Parametros objParametros = new Cls_Parametros();
            if (!objParametros.GenerarCadena())
            {
                strError = objParametros.Error;
                objParametros = null;
                return false;
            }

            strStringConexion = objParametros.StringConexion;
            objParametros = null;
            return true;
        }

        private bool AbrirConexion()
        {
            if (!GenerarString())
                return false;

            objConexionBD.ConnectionString = strStringConexion;

            try
            {
                objConexionBD.Open();
                blnAbrio = true;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Conexion" + ex.Message;
                blnAbrio = false;
                return false;
            }
        }

        #endregion

        #region"Metodos Publicos"

        public void CerrarConexion()
        {
            try
            {
                objConexionBD.Close();
                objConexionBD = null;
            }
            catch (Exception ex)
            {
                strError = "Clase Conexion, no cerro o abrio la Conexion " + ex.Message;
            }
        }

        public bool Consultar(bool blnParametros)
        {
            try //para controlar el error.
            {
                if (string.IsNullOrEmpty(strSQL))
                {
                    strError = "No definio la instruccion SQL";
                    return false;
                }
                if (!blnAbrio)
                {
                    if (!AbrirConexion())
                        return false;
                }
                objCommand.Connection = objConexionBD;
                objCommand.CommandText = strSQL;
                if (blnParametros)
                    objCommand.CommandType = CommandType.StoredProcedure;
                else
                    objCommand.CommandType = CommandType.Text;
                //Realizar la transaccion en la BD.
                objReader = objCommand.ExecuteReader();
                //bool sam = objReader.HasRows;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Conexion" + ex.Message;
                return false;
            }
        }

        public bool ConsultarValorUnico(bool blnParametros)
        {
            try
            {

                if (string.IsNullOrEmpty(strSQL))
                {
                    strError = "No se definio la instruccion SQL";
                    return false;
                }
                if (!blnAbrio)
                {
                    if (!AbrirConexion())
                        return false;
                }

                objCommand.Connection = objConexionBD;
                objCommand.CommandText = strSQL;
                if (blnParametros)
                    objCommand.CommandType = CommandType.StoredProcedure;
                else
                    objCommand.CommandType = CommandType.Text;

                //Realizar la trasaccion en la base de datos.
                strVrUnico = objCommand.ExecuteScalar().ToString();
                return true;

            }
            catch (Exception ex)
            {
                strError = "Clase Conexion" + ex.Message;
                return false;
            }
        }

        public bool EjecutarSentencia(bool blnParametros)
        {
            try
            {

                if (string.IsNullOrEmpty(strSQL))
                {
                    strError = "No se definio la instruccion SQL";
                    return false;
                }
                if (!blnAbrio)
                {
                    if (!AbrirConexion())
                        return false;
                }

                objCommand.Connection = objConexionBD;
                objCommand.CommandText = strSQL;
                if (blnParametros)
                    objCommand.CommandType = CommandType.StoredProcedure;
                else
                    objCommand.CommandType = CommandType.Text;

                //Realizar la trasaccion en la base de datos.
                objCommand.ExecuteNonQuery().ToString();
                return true;

            }
            catch (Exception ex)
            {
                strError = "Clase Conexion" + ex.Message;
                return false;
            }
        }

        public bool LLenarDataSet(bool blnParametros)
        {
            try
            {

                if (string.IsNullOrEmpty(strSQL))
                {
                    strError = "No se definio la instruccion SQL";
                    return false;
                }
                if (!blnAbrio)
                {
                    if (!AbrirConexion())
                        return false;
                }

                objCommand.Connection = objConexionBD;
                objCommand.CommandText = strSQL;
                if (blnParametros)
                    objCommand.CommandType = CommandType.StoredProcedure;
                else
                    objCommand.CommandType = CommandType.Text;

                //El DataAdapter utiliza en Command para la transaccion.
                objAdapter.SelectCommand = objCommand;

                //Realizar la transaccion en la BD y el llenado del Dataset/DataTable
                objAdapter.Fill(objDataset, strNombreTabla);
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase Conexion" + ex.Message;
                return false;
            }
        }

        #endregion
    }
}
