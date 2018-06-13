using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

//Referenciar y sar
using LibConexionParametro;

namespace CalidadDatosDeudores
{
    class Sentencias
    {

        #region"Constructor"
        public Sentencias()
        {
            strError = string.Empty;
            objDataset = new DataSet();
        }
        #endregion

        #region "variables"
        private string strError;
        private DataSet objDataset;
        #endregion

        #region "Propiedades"
        public string Error
        { get { return strError; } }

        public DataSet MiDataset
        { get { return objDataset; } }
        #endregion

        public bool ConsultarTablas()
        {
            Conexion objCOnexion = new Conexion();
            try
            {
                objCOnexion.SQL = "select name NombreNodo from sys.objects where type_desc = 'USER_TABLE' and name like 'DatosDeudores%' order by create_date";
               objCOnexion.NombreTabla = "Tabla";
                if (!objCOnexion.LLenarDataSet(false))
                {
                    strError = objCOnexion.Error;
                    objCOnexion.CerrarConexion();
                    objCOnexion = null;
                    return false;
                }
                objDataset = objCOnexion.Midataset;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = "Clase Sentencia - " + ex.Message;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return false;
            }
        }

        public bool LlenarGrilla(DataGridView datos, string tabla)
        {
            try
            {
                Conexion objCon = new Conexion();
                objCon.SQL = "select * from " + tabla;
                objCon.NombreTabla = "TablaConsultada";
                if (!objCon.LLenarDataSet(false))
                {
                    MessageBox.Show("Error: " + objCon.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objCon = null;
                    return false;
                }
                datos.DataSource = objCon.Midataset.Tables["TablaConsultada"];
                datos.Refresh();
                datos.AutoResizeColumns();
                datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                objCon = null;

                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        public bool EjecutarLimpiadorBasico(string strTabla)
        {
            Conexion objCOnexion = new Conexion();
            try
            {
                objCOnexion.SQL = "USP_LimpiarBasico @tabla = '" + strTabla + "'";
                if (!objCOnexion.ConsultarValorUnico(false))
                {
                    strError = objCOnexion.Error;
                    objCOnexion.CerrarConexion();
                    objCOnexion = null;
                    return false;
                }
                strError = objCOnexion.ValorUnico;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = "Calse Sentencia - " + ex.Message;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return false;
            }
        }

        public bool RevisarDatosDeudores()
        {
            try
            {
                Conexion objCon = new Conexion();
                objCon.SQL = "[dbo].[Usp_DMD_ValidacionDatosDeudores]";
                objCon.NombreTabla = "Tabla";
                if (!objCon.LLenarDataSet(false))
                {
                    MessageBox.Show("Error: " + objCon.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objCon = null;
                    return false;
                }
                objDataset = objCon.Midataset;
                objCon = null;

                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }  

        public bool llenarTablaSQL(DataTable tb, string nombreTable)
        {
            try
            {
                //Carga los datos de excel en la tabla creada
                Conexion objconexion = new Conexion();
                if (!objconexion.llenarTablaSQL(tb, nombreTable))
                {
                    MessageBox.Show(objconexion.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objconexion = null;
                    return false;
                }
                objconexion = null;

                return true;
            }
            catch (Exception ex)
            {
                strError = "CLASE ConexionSQLite::: " + ex.Message;
                return false;
            }
        }

        public bool EliminarDataTabla(string NombreTable)
        {
            Conexion objCOnexion = new Conexion();
            try
            {
                objCOnexion.SQL = "TRUNCATE TABLE " + NombreTable;
                if (!objCOnexion.EjecutarSentencia(false))
                {
                    strError = objCOnexion.Error;
                    objCOnexion.CerrarConexion();
                    objCOnexion = null;
                    return false;
                }
                strError = objCOnexion.ValorUnico;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = "Calse Sentencia - " + ex.Message;
                objCOnexion.CerrarConexion();
                objCOnexion = null;
                return false;
            }
        }
    }
}
