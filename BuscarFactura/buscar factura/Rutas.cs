using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Referenciar y usar.
using System.Xml;

namespace Buscar_Factura
{
    class Rutas
    {
        #region"Constructor"
        public Rutas()
        {
            strArchivoXml = String.Empty;
            strError = String.Empty;
            strDireccion2009 = String.Empty;
            strDireccion2010 = String.Empty;
            strDireccion2011 = String.Empty;
            strDireccion2009 = String.Empty;
            strDireccion2012 = String.Empty;
            strDireccion2013 = String.Empty;
            strDireccionGenerador = String.Empty;            
        }
        #endregion

        #region"Atributos"

        private string strArchivoXml;
        private XmlDocument objDocumento = new XmlDocument();
        private XmlNode objNodo;
        private string strError;
        private string strDireccion2009;
        private string strDireccion2010;
        private string strDireccion2011;
        private string strDireccion2012;
        private string strDireccion2013;
        private string strDireccionGenerador;

        #endregion

        #region"Propiedades"

        public string Direccion2009
        {
            get { return strDireccion2009; }
        }
        public string Direccion2010
        {
            get { return strDireccion2010; }
        }
        public string Direccion2011
        {
            get { return strDireccion2011; }
        }
        public string Direccion2012
        {
            get { return strDireccion2012; }
        }
        public string Direccion2013
        {
            get { return strDireccion2013; }
        }
        public string DireccionGenerador
        {
            get { return strDireccionGenerador; }
        }
        public string Error
        {
            get { return strError; }
        }


        #endregion       

        public bool LeerDirecciones()
        {
            string strNombreAplicacion = AppDomain.CurrentDomain.BaseDirectory + "Rutas.xml";
            strArchivoXml = strNombreAplicacion;

            try
            {
                objDocumento.Load(strArchivoXml);

                objNodo = objDocumento.SelectSingleNode("//DireccionGenerador");
                strDireccionGenerador = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Direccion2009");
                strDireccion2009 = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Direccion2010");
                strDireccion2010 = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Direccion2011");
                strDireccion2011 = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Direccion2012");
                strDireccion2012 = objNodo.InnerText;

                objNodo = objDocumento.SelectSingleNode("//Direccion2013");
                strDireccion2013 = objNodo.InnerText;

                objDocumento = null;
                return true;

            }
            catch (Exception ex)
            {
                strError = "Clase Rutas, " + ex.Message;
                objDocumento = null;
                return false;
            }
        }

    }
}
