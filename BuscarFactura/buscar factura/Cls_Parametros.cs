using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y usar.
using System.Xml;
using System.Windows.Forms;

namespace Buscar_Factura
{
    public class Cls_Parametros
    {
        #region"Constructor"

        public Cls_Parametros()
        {
            strServidor = string.Empty;
            strBaseDatos = string.Empty;
            strUsuario = string.Empty;
            strClave = string.Empty;
            strStringConexion = string.Empty;
            strSeguridadIntegrada = string.Empty;
            strError = string.Empty;
            strArchivoXml = string.Empty;
        }

        #endregion

        #region"Atributos"
        private string strServidor;
        private string strBaseDatos;
        private string strUsuario;
        private string strClave;
        private string strStringConexion;
        private string strSeguridadIntegrada;
        private string strError;
        private string strArchivoXml;
        private XmlDocument objDocumento = new XmlDocument();
        private XmlNode objNodo;
        #endregion

        #region"Propiedades"

        public string StringConexion
        {
            get { return strStringConexion; }
        }

        public string Error
        {
            get { return strError; }
        }


        #endregion

        #region"Metodos Publicos"

        public bool GenerarCadena()
        {
            string strNombreAplicacion = AppDomain.CurrentDomain.BaseDirectory + "Parametros.xml";
            strArchivoXml = strNombreAplicacion;

            try
            {
                objDocumento.Load(strArchivoXml);
                objNodo = objDocumento.SelectSingleNode("//Servidor");
                strServidor = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//BaseDatos");
                strBaseDatos = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Usuario");
                strUsuario = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Clave");
                strClave = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//SeguridadIntegrada");
                strSeguridadIntegrada = objNodo.InnerText;

                if (strSeguridadIntegrada.ToLower() == "si")
                    strStringConexion = "Data Source=" + strServidor + "; Initial Catalog=" + strBaseDatos + ";Integrated Security=SSPI";
                else
                    strStringConexion = "Data source=" + strServidor + ";Initial Catalog=" + strBaseDatos + ";User id=" + strUsuario + ";Password=" + strClave + ";";

                objDocumento = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase parametros" + ex.Message;
                objDocumento = null;
                return false;
            }

        }


        #endregion

    }
}
