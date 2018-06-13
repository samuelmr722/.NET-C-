using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VistaQM
{
    public partial class frmPlanes : Form
    {
        public frmPlanes()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private DataTable dt;

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                progressBar1.Value = 50;
                //Recupera datos de excel
                Excel objExc = new Excel();
                if (!objExc.CargarArchivo(txtRutaArchivo.Text.Trim(),cbHojaExcel.Text.Trim()))
                {
                    MessageBox.Show(objExc.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 100;
                    objExc = null;
                    return;
                }
                DataTable tb = objExc.tablita;
                objExc = null;

                //Crea la tabla a cargar
                ConexionSQLite objSQLite = new ConexionSQLite();
                if (!objSQLite.CrearTabla(this.txtNombreTabla.Text))
                {
                    MessageBox.Show(objSQLite.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 100;
                    objSQLite = null;
                    return;
                }
                objSQLite = null;

                //Carga los datos de excel en la tabla creada
                ConexionSQLite objSQLite2 = new ConexionSQLite();
                if (!objSQLite2.CargarExcel(tb, this.txtNombreTabla.Text))
                {
                    MessageBox.Show(objSQLite2.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 100;
                    objSQLite2 = null;
                    return;
                }
                objSQLite2 = null;

                //Actualizar TreeView
                CargarTablas();
                progressBar1.Value = 100;
                MessageBox.Show("Archivo cargado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 100;
            }
        }

        public bool ValidarCampos()
        {
            try
            {
                if (this.txtNombreTabla.Text == string.Empty || this.txtRutaArchivo.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un nombre de tabla y seleccione un archivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                this.txtNombreTabla.Text = objDialog.SafeFileName.Substring(0, objDialog.SafeFileName.Length - 5).Replace(" ", "").Replace("  ", "");
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

        private void frmPlanes_Load(object sender, EventArgs e)
        {
            CargarTablas();
        }        

        public void CargarTablas()
        {
            try
            {
                tvTablas.Nodes.Clear();
                ConexionSQLite SQLite = new ConexionSQLite();
                if (!SQLite.ConsultarTablas())
                {
                    MessageBox.Show("Error: " + SQLite.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SQLite = null;
                    return;
                }
                dt = SQLite.Tabla;
                SQLite = null;
                CrearNodos();
                dt.Clear();
                this.dgvDatos.DataSource = null;
                this.dgvDatos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CrearNodos()
        {
            DataView dataViewHijos = new DataView(dt);

            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["NombreNodo"].ToString().Trim();
                tvTablas.Nodes.Add(nuevoNodo);
            }
            dataViewHijos = null;
        }

        private void btnEliminarTabla_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion())
                    return;

                if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                progressBar1.Value = 50;
                ConexionSQLite SQLite = new ConexionSQLite();
                if (!SQLite.EliminarTabla(this.tvTablas.SelectedNode.Text))
                {
                    MessageBox.Show("Error: " + SQLite.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SQLite = null;
                    progressBar1.Value = 100;
                    return;
                }
                MessageBox.Show("Se borro la tabla correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLite = null;
                CargarTablas();
                progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 100;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTablas();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion())
                   return;
                ConexionSQLite SQLite = new ConexionSQLite();
                if (!SQLite.LlenarGrilla(this.dgvDatos, this.tvTablas.SelectedNode.Text))
                {
                    MessageBox.Show("Error: " + SQLite.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SQLite = null;
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarSeleccion())
                    return;
                progressBar1.Value = 50;
                //Recupera datos de excel
                Excel objExc = new Excel();
                if (!objExc.CargarArchivo(txtRutaArchivo.Text.Trim(), cbHojaExcel.Text.Trim()))
                {
                    MessageBox.Show(objExc.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 100;
                    objExc = null;
                    return;
                }
                DataTable tb = objExc.tablita;
                objExc = null;

                //Crea la tabla y realcionar y hacer la consulta
                ConexionSQLite objSQLite = new ConexionSQLite();
                if (!objSQLite.GenerarDataMarestra(tb, this.tvTablas.SelectedNode.Text,this.dgvDatos))
                {
                    MessageBox.Show(objSQLite.Error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 100;
                    objSQLite = null;
                    return;
                }
                objSQLite = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
