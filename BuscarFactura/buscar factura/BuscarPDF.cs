using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Buscar_Factura
{
    class BuscarPDF
    {

        #region"Constructor"
        public BuscarPDF()
        {
            strError = String.Empty;
            strDireccionPDF = String.Empty;
            NumFactu = String.Empty;
            NumGui = String.Empty;
            strDireccionBase = String.Empty;                       
            directories = new string[100];

        }
        #endregion

        #region"Atributos"
        private string strDireccionBase;           
        private string strError;
        private string strDireccionPDF;
        private string[] directories;        
        private string NumFactu;
        private string NumGui; 
        #endregion

        #region"Propiedades"
        public string DireccionBase
        { set { strDireccionBase = value; } }

        public string NumFactura
        { set { NumFactu = value; } }

        public string NumGuia
        { set { NumGui = value; } }

        public string DireccionPDF
        { get { return strDireccionPDF; } }

        public string Error
        { get { return strError; } }
        
        #endregion

//----------------------------------------------------------------------------------------------------------------
        public bool Buscar2009()
        {
            try
            {              
                directories = Directory.GetDirectories(strDireccionBase);
                for (int i = 0; i <= (directories.LongLength - 1); i++)
                {
                    if (System.IO.File.Exists(directories[i] + "\\No. " + NumFactu + ".pdf"))
                    {
                        strDireccionPDF = directories[i] + "\\No. " + NumFactu + ".pdf";
                        i = 200;
                    }
                }                  
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase BuscarPDF" + ex.Message;
                return false;
            }
        }
//----------------------------------------------------------------------------------------------------------------
        public bool Buscar2010()
        {
            try
            {
                directories = Directory.GetDirectories(strDireccionBase);
                for (int i = 0; i <= (directories.LongLength - 1); i++)
                {
                    if (System.IO.File.Exists(directories[i] + "\\No. " + NumFactu + ".pdf"))
                    {
                        strDireccionPDF = directories[i] + "\\No. " + NumFactu + ".pdf";
                        i = 200;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase BuscarPDF" + ex.Message;
                return false;
            }
        }
//----------------------------------------------------------------------------------------------------------------
        public bool Buscar2011()
        {
            try
            {
                directories = Directory.GetDirectories(strDireccionBase);
                for (int i = 0; i <= (directories.LongLength - 1); i++)
                {
                    if (System.IO.File.Exists(directories[i] + "\\No. " + NumFactu + ".pdf"))
                    {
                        strDireccionPDF = directories[i] + "\\No. " + NumFactu + ".pdf";
                        i = 200;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase BuscarPDF" + ex.Message;
                return false;
            }
        }
//----------------------------------------------------------------------------------------------------------------
        public bool Buscar2012()
        {
            try
            {
                directories = Directory.GetDirectories(strDireccionBase);
                for (int i = 0; i <= (directories.LongLength - 1); i++)
                {
                    if (System.IO.File.Exists(directories[i] + "\\No. " + NumFactu + ".pdf"))
                    {
                        strDireccionPDF = directories[i] + "\\No. " + NumFactu + ".pdf";
                        i = 200;
                    }
                    if (i < 200)
                    {
                        if (System.IO.File.Exists(directories[i] + "\\" + NumGui + ".pdf"))
                        {
                            strDireccionPDF = directories[i] + "\\" + NumGui + ".pdf";
                            i = 200;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase BuscarPDF" + ex.Message;
                return false;
            }
        }
//----------------------------------------------------------------------------------------------------------------
       public bool Buscar2013()
        {
            try
            {
                if (System.IO.File.Exists(strDireccionBase + "\\" + NumGui + ".pdf"))
                {
                    strDireccionPDF = strDireccionBase + "\\" + NumGui + ".pdf";
                }
                else
                {
                    directories = Directory.GetDirectories(strDireccionBase);
                    for (int i = 0; i <= (directories.LongLength - 1); i++)
                    {
                        if (System.IO.File.Exists(directories[i] + "\\" + NumGui + ".pdf"))
                        {
                            strDireccionPDF = directories[i] + "\\" + NumGui + ".pdf";
                            i = 200;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                strError = "Clase BuscarPDF" + ex.Message;
                return false;
            }
        }
//----------------------------------------------------------------------------------------------------------------
  
    }
}
