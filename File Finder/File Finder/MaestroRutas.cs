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
    public partial class MaestroRutas : Form
    {
        public MaestroRutas()
        {
            InitializeComponent();
        }

        private void MaestroRutas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
       
        private void CargarGrilla()
        {
            try
            {
                Rutas obj = new Rutas();
                if (!obj.LlenarGrillaRutas(this.dgvRutas))
                {
                    MessageBox.Show(obj.Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obj = null;
                    return;
                }
                obj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        private void bntNuevaRuta_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog obj = new FolderBrowserDialog();
                obj.ShowNewFolderButton = false;
                DialogResult result = obj.ShowDialog(); 
                if (result == DialogResult.OK)
                {
                    if (MessageBox.Show("Confirma que desea crear la ruta: " + obj.SelectedPath + ".", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        InsertarNuevaRuta(obj.SelectedPath);
                    }
                }
                obj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void InsertarNuevaRuta(string Path)
        {
            try
            {
                Rutas obj = new Rutas();
                string strSql = "insert into Rutas (Ruta) values ('" + Path + "')";
                if (!obj.EjecutarQuery(strSql))
                {
                    MessageBox.Show(obj.Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obj = null;
                    return;
                }
                obj = null;
                MessageBox.Show("Se creo la ruta correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
        }

        private void btnEliminarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                string EliminarCod = String.Empty;

                for (int i = 0; i < dgvRutas.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvRutas[0, i].Value))
                    {
                        EliminarCod =  EliminarCod + "'" + dgvRutas[1, i].Value + "',";
                    }
                }
                if (EliminarCod == "")
                {
                    MessageBox.Show("Debe selecionar almenos una ruta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Elimina la como final que siempre queda
                EliminarCod = EliminarCod.Substring(0, (EliminarCod.Length - 1));
            
                //Obtener las rutas a eliminar
                Rutas obj = new Rutas();
                string strSql = "delete from rutas where codigo in (" + EliminarCod + ")";
                if (!obj.EjecutarQuery(strSql))
                {
                    MessageBox.Show(obj.Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    obj = null;
                    return;
                }
                obj = null;
                MessageBox.Show("Se elimino la ruta y/o rutas seleccoinadas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }


        private void btnCrearDbRutas_Click(object sender, EventArgs e)
        {
            try
            {                
                if (MessageBox.Show("Desea crear una nueva base de datos de rutas?, si acepta en caso de existir una actualmente se borrara y se creara una nueva, en caso de que no exista se creara una nueva ", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (File.Exists("RutasUsuario.sqlite"))
                    {
                        File.Delete("RutasUsuario.sqlite");
                    }
                    Rutas obj = new Rutas();
                    if (!obj.CrearBBDD())
                    {
                        MessageBox.Show(obj.Error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        obj = null;
                        return;
                    }
                    obj = null;
                    MessageBox.Show("Se crea una nuava base de datos correctamente 'RutasUsuario.sqlite'", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  
        }
    }
}
