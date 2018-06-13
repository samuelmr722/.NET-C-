using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscar_Factura
{
    class AbrirPDF
    {
        #region"Constructor"
        public AbrirPDF()
        {
            strError = String.Empty;
            strDireccionPDF = String.Empty;            
        }
        #endregion

        #region"Atributos"        
        private string strDireccionPDF;        
        private string strError;
        #endregion

        #region"Propiedades"
        public string DireccionPDF
        { set { strDireccionPDF = value; } }

        public string Error
        { get { return strError; } }
        #endregion

        public bool AbrirelPDF()
        {
            try
            {
                if (strDireccionPDF == "")
                {
                    strError = "Clase AbrirPDF, no hay ruta especificada";
                    return false;                    
                }
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = strDireccionPDF;
                proc.Start();
                proc.Close();
                return true;                
            }
            catch (Exception ex)
            {
                strError = "Clase AbrirPDF, " + ex.Message;                
                return false;
            }

        }    
    }
}
