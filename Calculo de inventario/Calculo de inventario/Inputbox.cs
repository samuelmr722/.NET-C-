using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculo_de_inventario
{
    public static class Inputbox
    {
        static Form _f;
        static Label _l;
        static TextBox _t;
        static Button _b1;
        static Button _b2;
        static String _Cadena;
        private static String cadena
        {
            get
            {
                return _Cadena;
            }
            set
            {
                _Cadena = value;
            }
        }
        private static void Aceptar()
        {
            cadena = _t.Text;
            _f.Dispose();
        }
        private static void Cancelar()
        {
            cadena = null;
            _f.Dispose();
        }
        private static String getmensaje(String a)
        {
            _l = new Label();
            _l.Visible = true;
            _l.BackColor = System.Drawing.SystemColors.Control;
            _l.AutoSize = false;
            _l.Location = new System.Drawing.Point(9, 9);
            _l.Size = new System.Drawing.Size(232, 50);
            _l.Text = a;
            return _l.Text;
        }
        /// <summary>
        /// Objeto Estático que muestra un pequeño diálogo para introducir datos
        /// </summary>
        /// <param name="title">Título del diálogo</param>
        /// <param name="prompt">Texto de información</param>
        /// <param name="posicion">Posición de inicio</param>
        /// <returns>Devuelve la escrito en la caja de texto como string</returns>
        public static String Show(String titulo, String Mensaje, FormStartPosition posicion)
        {
            getmensaje(Mensaje);
            _f = new Form();
            _f.Text = titulo;
            _f.ShowIcon = false;
            _f.Icon = null;
            _f.KeyPreview = true;
            _f.ShowInTaskbar = false;
            _f.MinimizeBox = false;
            _f.MaximizeBox = false;
            _f.Width = 250;
            _f.FormBorderStyle = FormBorderStyle.FixedDialog;
            _f.Height = 150;
            _f.StartPosition = posicion;            

            _t = new TextBox();
            _t.Left = 5;
            _t.Width = 232;
            _t.Top = 60;

            _b1 = new Button();
            _b1.Text = "Aceptar";
            _b1.Click += new EventHandler(b1_Click);

            _b2 = new Button();
            _b2.Text = "Cancelar";
            _b2.Click += new EventHandler(b2_Click);
            _f.Controls.Add(_l);
            _f.Controls.Add(_t);
            _f.Controls.Add(_b1);
            _f.Controls.Add(_b2);

            _l = new Label();
            _l.Visible = true;
            _l.BackColor = System.Drawing.SystemColors.Control;
            _l.AutoSize = false;
            _l.Location = new System.Drawing.Point(9, 9);
            _l.Size = new System.Drawing.Size(232, 50);
            _l.Text = Mensaje;


            _l.Visible = true;
            _l.AutoSize = false;

            _b1.Left = 165;
            _b1.Top = 90;

            _b2.Left = 90;
            _b2.Top = 90;

            _f.ShowDialog();
            return (_Cadena);
        }
        
        static void b1_Click(object sender, EventArgs e)
        {
            if (_t.Text != "")
            {
                Aceptar();
            }
            else
            {
                MessageBox.Show("No ha ingresado un valor", "ERROR");
            }

        }

        static void b2_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}
