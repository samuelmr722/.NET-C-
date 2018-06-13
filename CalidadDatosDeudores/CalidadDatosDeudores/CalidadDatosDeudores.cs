using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CalidadDatosDeudores
{
    public partial class CalidadDatosDeudores : Form
    {
        public CalidadDatosDeudores()
        {
            InitializeComponent();
        }

        public void Abrir_Programa()
        {
            CalidadDatosDeudores f = new CalidadDatosDeudores();
            f.ShowDialog();
            f = null;
        }

        public void CargarTablas()
        {
            try
            {
                tvTablas.Nodes.Clear();
                Sentencias objSentencia = new Sentencias();
                if (!objSentencia.ConsultarTablas())
                {
                    MessageBox.Show("Error: " + objSentencia.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objSentencia = null;
                    return;
                }

                DataView dataViewHijos = new DataView(objSentencia.MiDataset.Tables[0]);
                objSentencia = null;
                foreach (DataRowView dataRowCurrent in dataViewHijos)
                {
                    TreeNode nuevoNodo = new TreeNode();
                    nuevoNodo.Text = dataRowCurrent["NombreNodo"].ToString().Trim();
                    tvTablas.Nodes.Add(nuevoNodo);
                }
                dataViewHijos = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion())
                    return;
                Sentencias objSen = new Sentencias();
                if (!objSen.LlenarGrilla(this.dgvDatos, this.tvTablas.SelectedNode.Text))
                {
                    MessageBox.Show("Error: " + objSen.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objSen = null;
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool ValidarSeleccion()
        {
            try
            {
                if ((!this.tvTablas.SelectedNode.IsSelected) || (!this.tvTablas.SelectedNode.IsSelected))
                {
                    MessageBox.Show("Debe seleccionar una tabla", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar una tabla", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTablas();
        }

        public bool ValidarCampos()
        {
            try
            {
                if (this.txtRutaArchivo.Text == string.Empty)
                {
                    MessageBox.Show("seleccione un archivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                //Recupera datos de excel
                Excel objExc = new Excel();
                if (!objExc.CargarArchivo(txtRutaArchivo.Text.Trim(), cbHojaExcel.Text.Trim()))
                {
                    MessageBox.Show(objExc.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objExc = null;
                    return;
                }
                DataTable tb = objExc.tablita;
                objExc = null;

                //Eliminar data de la tabla
                Sentencias objSentencia = new Sentencias();
                if (!objSentencia.EliminarDataTabla("DatosDeudoresValidar"))
                {
                    MessageBox.Show(objSentencia.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objSentencia = null;
                    return;
                }
                objSentencia = null;

                //Carga los datos de excel en la tabla
                Sentencias obj = new Sentencias();
                if (!obj.llenarTablaSQL(tb, "DatosDeudoresValidar"))
                {
                    MessageBox.Show(obj.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obj = null;
                    return;
                }
                obj = null;

                //Correr el limpiador basico
                if (true)
                {
                    Sentencias objSentencia1 = new Sentencias();
                    if (!objSentencia1.EjecutarLimpiadorBasico("DatosDeudoresValidar"))
                    {
                        MessageBox.Show(objSentencia1.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        objSentencia1 = null;
                        return;
                    }
                    objSentencia1 = null;
                }

                //Actualizar TreeView
                CargarTablas();
                MessageBox.Show("Archivo cargado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog objDialog = new OpenFileDialog();
                objDialog.Title = "Escoja el archivo a cargar";
                objDialog.ShowDialog();
                if (objDialog.FileName == "")
                {
                    return;
                }
                txtRutaArchivo.Text = objDialog.FileName;
                objDialog = null;

                //Recupera nombre hojas de excel
                Excel objExc = new Excel();
                if (!objExc.GetExcelSheetNames(txtRutaArchivo.Text.Trim()))
                {
                    MessageBox.Show(objExc.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objExc = null;
                    return;
                }
                this.cbHojaExcel.DataSource = objExc.Vector;
                objExc = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarCalidadDatos_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarSeleccion())
                { return; }

                if (String.Compare(this.tvTablas.SelectedNode.Text, "DatosDeudoresValidar") != 0)
                {
                    MessageBox.Show("La tabla Seleccionada no es correcta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Sentencias objSentencia = new Sentencias();
                if (!objSentencia.RevisarDatosDeudores())
                {
                    MessageBox.Show(objSentencia.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objSentencia = null;
                    return;
                }
                DataSet ds = new DataSet();
                ds = objSentencia.MiDataset;
                objSentencia = null;

                //Paso las tablas a un archivo de excel
                Excel objExcel = new Excel();
                if (!objExcel.GenerarExcel(ds))
                {
                    MessageBox.Show(objExcel.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objExcel = null;
                    return;
                }
                ds = null;
                objExcel = null;
                MessageBox.Show("Archivo Generado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalidadDatosDeudores_Load(object sender, EventArgs e)
        {
            CargarTablas();
        }
    }
}
