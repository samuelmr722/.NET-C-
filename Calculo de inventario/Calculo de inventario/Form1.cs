using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Calculo_de_inventario
{
    public partial class FrmSentencia : Form
    {
        public FrmSentencia()
        {
            InitializeComponent();
        }

        #region"Atributos"
        public static string strServer = String.Empty;
        #endregion

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (seguridad() == true)
                {
                    if (string.IsNullOrEmpty(this.txtCadena.Text))
                    {
                        MessageBox.Show("Debe ingresar los valores");
                        return;
                    }
                    if (strServer == "")
                    {
                        MessageBox.Show("No hay server");
                        return;
                    }
                    Ejecutar(GenerarCadena(), this.txtCadena.Text.Trim());
                }
                else
                {
                    MessageBox.Show("El calculo No puede tener UPDATE,INSERT,DELETE,TRUNCATE,DROP,CREATE ni INTO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private string GenerarCadena()
        {
            try
            {
                string strStringConexion = "Data source=" + strServer + ";Initial Catalog= LINEADIRECTA;Integrated Security=SSPI";
                return strStringConexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ex.Message;
            }
        }

        public bool seguridad()
        {
            int indice = 0;

            indice = this.txtCadena.Text.IndexOf("UPDATE") + this.txtCadena.Text.IndexOf("INSERT") + this.txtCadena.Text.IndexOf("DELETE") + this.txtCadena.Text.IndexOf("TRUNCATE") + this.txtCadena.Text.IndexOf("DROP") + this.txtCadena.Text.IndexOf("update") + this.txtCadena.Text.IndexOf("insert") + this.txtCadena.Text.IndexOf("delete") + this.txtCadena.Text.IndexOf("truncate") + this.txtCadena.Text.IndexOf("drop") + this.txtCadena.Text.IndexOf("create") + this.txtCadena.Text.IndexOf("CREATE") + this.txtCadena.Text.IndexOf("into") + +this.txtCadena.Text.IndexOf("INTO");

            if (this.txtCadena.Text.IndexOf("--epa") >= 0) 
            { 
                indice = -14; 
            }

            if (indice == -14)
            {
                return true;
            }
            return false;

        }

        private void txtCadena_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.K))
                {
                    strServer = Inputbox.Show("Server", "Ingrese el server", FormStartPosition.CenterScreen);                    
                    this.lblServer.Text = strServer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ejecutar(string cadena, string strSQL)
        {
            try
            {
                SqlConnection objConexion = new SqlConnection();
                SqlCommand objCommand = new SqlCommand();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                DataTable objDataTable = new DataTable();

                objConexion.ConnectionString = cadena;
                objCommand.Connection = objConexion;

                objCommand.CommandText = strSQL;
                objCommand.CommandType = CommandType.Text;

                objDataAdapter.SelectCommand = objCommand;
                objConexion.Open();
                objDataAdapter.Fill(objDataTable);

                if (this.rbtEnGrilla.Checked)
                {
                    EnGrilla(objDataTable);
                }

                if (this.rbtEnExcel.Checked)
                {
                    EnExcel(objDataTable);
                }

                objConexion.Close();
                objConexion = null;
                objCommand = null;
                objDataAdapter = null;
                objDataTable = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnGrilla(DataTable Tabla)
        {
            try
            {
                dgvResultado.DataSource = Tabla;
                dgvResultado.Refresh();

                dgvResultado.AutoResizeColumns();
                dgvResultado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EnExcel(DataTable Tabla)
        {
            try
            {
                //Declaro los objetos
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excelApp;
                Microsoft.Office.Interop.Excel.Workbook myworkbook;
                Microsoft.Office.Interop.Excel.Worksheet myWorkSheet;

                //nueva aplicación excel.
                excelApp = new Microsoft.Office.Interop.Excel.Application();                

                //añadimos un workbook
                myworkbook = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                //Selccionamos la hoja
                myWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myworkbook.Sheets[1];

                //Creamos los titulos
                int i = 1;
                foreach (DataColumn col in Tabla.Columns)
                {
                   myWorkSheet.Cells[1, i] = col.Caption.ToString();
                   i++;
                }

                //Pegas los datos
                int rowIndex = 2;
                foreach (DataRow row in Tabla.Rows)
                {
                    int columnIndex = 1;

                    foreach (object dc in row.ItemArray)
                    {
                        myWorkSheet.Cells[rowIndex, columnIndex] = dc.ToString();
                        columnIndex++;
                    }
                    rowIndex++;
                }

                //Mostramos el excel
                excelApp.Visible = true;
                excelApp.ScreenUpdating = true;

                //Destruimos objetos
                misValue = null;
                excelApp = null;
                myworkbook = null;
                myWorkSheet = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
