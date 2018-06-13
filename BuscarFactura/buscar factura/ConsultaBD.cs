using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
//Referenciar y usar.
using System.Data.SqlClient;

namespace Buscar_Factura
{
    class ConsultaBD
    {
        #region"Constructor"

        public ConsultaBD()
        {
            strNumFactura = string.Empty;
            strError = string.Empty;            
            strDato = string.Empty;
        }

        #endregion

        #region"Atributos"
        private string strNumFactura;
        private string strError;        
        private string strDato;
        #endregion

        #region"Propiedades"
        public string NumFactura
        {
            set { strNumFactura = value; }
        }
        public string Error
        {
            get { return strError; }
        }       
        public string Dato
        {
            get { return strDato; }
        }
        #endregion

        public bool ConsultarFAC()
        {
            ConexionBD objCOnexion = new ConexionBD();
            try
            {
                objCOnexion.SQL = "select rtrim(ltrim(remision)) as remision from lineadirecta.dbo.trade where origen = 'fac' and tipodcto = 'fs' and tipomvto = '651' and nrodcto = '" + strNumFactura + "'";
                if (!objCOnexion.Consultar(false))
                {
                    strError = objCOnexion.Error;
                    objCOnexion = null;
                    return false;
                }
                
                if (objCOnexion.Reader.HasRows)
                {
                    objCOnexion.Reader.Read();
                    strDato = objCOnexion.Reader[0].ToString(); 
                }                               
                objCOnexion.Reader.Close();
                objCOnexion.CerrarConexion();
                objCOnexion = null;                
                return true;

            }
            catch (Exception ex)
            {
                strError = "Calse ConsultaBD, " + ex.Message;
                objCOnexion = null;
                return false;
            }
        }
    }
}
