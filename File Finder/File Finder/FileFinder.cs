using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_Finder
{
    public partial class FileFinder : Form
    {
        public FileFinder()
        {
            InitializeComponent();                     
        }        

        #region "Atributos"         
        DataView objview = new DataView();
        #endregion
       
        private void LkLblConfiguracion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaestroRutas f = new MaestroRutas();
            f.Show();
            f = null;
        }

        private void FileFinder_Load(object sender, EventArgs e)
        {
            try
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.SetToolTip(this.btnActualizar, "Cargar de nuevo");
                toolTip1 = null;
                CargarArchivos();                                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }               

        private void dgvDatosTutilo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string strDireccionDoc = dgvDatosTutilo.Rows[e.RowIndex].Cells[1].Value.ToString();
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = strDireccionDoc;
                    proc.Start();
                    proc.Close();
                    proc = null;
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            objview.RowFilter = string.Format("[Archivo] like '%{0}%'", txtBuscar.Text);
        }

        private void CargarArchivos()
        {
            try
            {                
                DataTable objTableRutas = new DataTable();
                DataTable objTableArchivos = new DataTable();
                string[] directories = new string[1000];

                //Crear columnas en el objeto tabla
                objTableArchivos.Columns.Add("Archivo");
                //objTableArchivos.Columns.Add("Ruta");

                //Obtener las rutas de usuario
                Rutas objR = new Rutas();
                if (!objR.CargarTabla(objTableRutas))
                {
                    MessageBox.Show(objR.Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objR = null;
                    objTableRutas = null;
                    objTableArchivos = null;
                    directories = null;
                    return;
                }
                objR = null;

                for (int j = 0; j < objTableRutas.Rows.Count; j++)
                {
                    directories = Directory.GetFiles(objTableRutas.Rows[j][1].ToString());

                    //Pasar los datos al objeto tabla
                    for (int i = 0; i < directories.Length; i++)
                    {
                        if (directories[i] != null)
                        {
                            objTableArchivos.Rows.Add(directories[i]);
                        }
                    }
                }

                //Del objeto tabla pasar a un dataview y luego pasar a la grilla
                objview = objTableArchivos.DefaultView;
                dgvDatosTutilo.DataSource = objview;
                dgvDatosTutilo.AutoResizeColumns();
                dgvDatosTutilo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                objTableRutas = null;
                objTableArchivos = null;
                directories = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            txtBuscar.Text = String.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarArchivos();
        }
    }
}

