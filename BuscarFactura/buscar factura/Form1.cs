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


namespace Buscar_Factura
{
    public partial class Bucar_Factura : Form
    {
        public Bucar_Factura()
        {
            InitializeComponent();
            DireccionPDF = String.Empty;
            NumFactu = String.Empty;
            NumGuia = String.Empty;
            string R2009 = String.Empty;
            string R2010 = String.Empty;
            string R2011 = String.Empty;
            string R2012 = String.Empty;
            string R2013 = String.Empty;
        }

        #region"Atributos"        
        private string DireccionPDF;  
        private string NumFactu;
        private string NumGuia;
        private string R2009;
        private string R2010;
        private string R2011;
        private string R2012;
        private string R2013;
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMensaje.Text = "Buscando...";

                if (!ValidarDato())
                {
                    this.lblMensaje.Text = "Debe ingresar un valor valido";                    
                    return;
                }
                
                NumFactu = txtNumeroFactura.Text.Trim();

                //Buscamnos las rutas
                Rutas ObjRuta = new Rutas();
                if (!ObjRuta.LeerDirecciones())
                {
                    this.lblMensaje.Text = ObjRuta.Error;
                    ObjRuta = null;
                    return;
                }
                 R2009 = ObjRuta.Direccion2009;
                 R2010 = ObjRuta.Direccion2010;
                 R2011 = ObjRuta.Direccion2011;
                 R2012 = ObjRuta.Direccion2012;
                 R2013 = ObjRuta.Direccion2013;
                ObjRuta = null;

                //Se consulta el numero de la guia si se ha selecionado los años 2012 o 2013
                if (this.rbtn2012.Checked || this.rbtn2013.Checked)
                {
                    ConsultaBD ObjConsulta = new ConsultaBD();
                    ObjConsulta.NumFactura = NumFactu;
                    if (!ObjConsulta.ConsultarFAC())
                    {
                        this.lblMensaje.Text = ObjConsulta.Error;
                        ObjConsulta = null;
                        return;
                    }
                    if (ObjConsulta.Dato == "")
                    {
                        this.lblMensaje.Text = "La factura no existe en la base de datos o no tiene remision";
                    }
                    else
                    {
                        NumGuia = ObjConsulta.Dato;
                    }
                    
                    ObjConsulta = null;
                }                

                //Buscar la ubicacion del PDF                
                BuscarPDF ObjBuscar = new BuscarPDF();
                ObjBuscar.NumFactura = NumFactu;
                ObjBuscar.NumGuia = NumGuia;
                
                if (this.rbtn2009.Checked)
                {
                    ObjBuscar.DireccionBase = R2009;
                    if (!ObjBuscar.Buscar2009())
                    {
                        this.lblMensaje.Text = ObjBuscar.Error;
                        ObjBuscar = null;
                        return;
                    }
                }
                if (this.rbtn2010.Checked)
                {
                    ObjBuscar.DireccionBase = R2010;
                    if (!ObjBuscar.Buscar2010())
                    {
                        this.lblMensaje.Text = ObjBuscar.Error;
                        ObjBuscar = null;
                        return;
                    }
                }
                if (this.rbtn2011.Checked)
                {
                    ObjBuscar.DireccionBase = R2011;
                    if (!ObjBuscar.Buscar2011())
                    {
                        this.lblMensaje.Text = ObjBuscar.Error;
                        ObjBuscar = null;
                        return;
                    }
                }
                if (this.rbtn2012.Checked)
                {
                    ObjBuscar.DireccionBase = R2012;                    
                    if (!ObjBuscar.Buscar2012())
                    {
                        this.lblMensaje.Text = ObjBuscar.Error;
                        ObjBuscar = null;
                        return;
                    }
                }
                if (this.rbtn2013.Checked)
                {
                    ObjBuscar.DireccionBase = R2013;                    
                    if (!ObjBuscar.Buscar2013())
                    {
                        this.lblMensaje.Text = ObjBuscar.Error;
                        ObjBuscar = null;
                        return;
                    }
                }

                DireccionPDF = ObjBuscar.DireccionPDF;
                ObjBuscar = null;
                
                //Si existe el PDF, lo abro
                if (DireccionPDF == "")
                {
                    this.lblMensaje.Text = "El PDF no existe";
                    return;
                }
                else
                {
                    AbrirPDF ObjAbrir = new AbrirPDF();
                    ObjAbrir.DireccionPDF = DireccionPDF;

                    if (!ObjAbrir.AbrirelPDF())
                    {
                        this.lblMensaje.Text = ObjAbrir.Error;
                        ObjAbrir = null;
                        return;
                    }
                    ObjAbrir = null;
                    Limpiar();
                }              
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                return;
            }
        }       

        public bool ValidarDato()
        {
            if (this.txtNumeroFactura.Text == "")
            {
                return false;
            }
            else
            {
                if (!IsNumeric(this.txtNumeroFactura.Text))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }        

        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = String.Empty;
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(null, null);
            }
        }          

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Rutas ObjRutas = new Rutas();
                if (!ObjRutas.LeerDirecciones())
                {
                    this.lblMensaje.Text = ObjRutas.Error;
                    ObjRutas = null;
                    return;
                }
                string DireccionGenerador = ObjRutas.DireccionGenerador;
                ObjRutas = null;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = DireccionGenerador;
                proc.Start();
                proc.Close();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = Convert.ToString(ex);                
                return;
            }

        }                

        public void Limpiar()
        {
            txtNumeroFactura.Text = String.Empty;
            lblMensaje.Text = String.Empty;
            this.txtNumeroFactura.Focus();
            DireccionPDF = String.Empty;

        }                
       

    }
}