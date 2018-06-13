namespace CalidadDatosDeudores
{
    partial class CalidadDatosDeudores
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalidadDatosDeudores));
            this.cbHojaExcel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRuta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnCargarExcel = new System.Windows.Forms.Button();
            this.btnGenerarCalidadDatos = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tvTablas = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHojaExcel
            // 
            this.cbHojaExcel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHojaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHojaExcel.FormattingEnabled = true;
            this.cbHojaExcel.Location = new System.Drawing.Point(345, 102);
            this.cbHojaExcel.Name = "cbHojaExcel";
            this.cbHojaExcel.Size = new System.Drawing.Size(116, 24);
            this.cbHojaExcel.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "Seleccione la hoja";
            // 
            // btnRuta
            // 
            this.btnRuta.Location = new System.Drawing.Point(617, 50);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(25, 20);
            this.btnRuta.TabIndex = 66;
            this.btnRuta.Text = "...";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Seleccione un archivo .xlsx";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaArchivo.Location = new System.Drawing.Point(345, 48);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(266, 22);
            this.txtRutaArchivo.TabIndex = 64;
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarExcel.Location = new System.Drawing.Point(488, 100);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(123, 26);
            this.btnCargarExcel.TabIndex = 63;
            this.btnCargarExcel.Text = "Cargar Excel";
            this.btnCargarExcel.UseVisualStyleBackColor = true;
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // btnGenerarCalidadDatos
            // 
            this.btnGenerarCalidadDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCalidadDatos.Location = new System.Drawing.Point(344, 195);
            this.btnGenerarCalidadDatos.Name = "btnGenerarCalidadDatos";
            this.btnGenerarCalidadDatos.Size = new System.Drawing.Size(267, 26);
            this.btnGenerarCalidadDatos.TabIndex = 48;
            this.btnGenerarCalidadDatos.Text = "Generar Calidad de datos";
            this.btnGenerarCalidadDatos.UseVisualStyleBackColor = true;
            this.btnGenerarCalidadDatos.Click += new System.EventHandler(this.btnGenerarCalidadDatos_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(488, 148);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 27);
            this.btnActualizar.TabIndex = 60;
            this.btnActualizar.Text = "Actualizar tablas";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(4, 266);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.Size = new System.Drawing.Size(647, 279);
            this.dgvDatos.TabIndex = 59;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(345, 148);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(116, 26);
            this.btnConsulta.TabIndex = 58;
            this.btnConsulta.Text = "Consultar tabla";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(317, 16);
            this.label7.TabIndex = 57;
            this.label7.Text = "Tablas de definicion de la data y tabla para analizar";
            // 
            // tvTablas
            // 
            this.tvTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvTablas.Location = new System.Drawing.Point(4, 28);
            this.tvTablas.Name = "tvTablas";
            this.tvTablas.Size = new System.Drawing.Size(321, 232);
            this.tvTablas.TabIndex = 56;
            // 
            // CalidadDatosDeudores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 547);
            this.Controls.Add(this.cbHojaExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.btnCargarExcel);
            this.Controls.Add(this.btnGenerarCalidadDatos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tvTablas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CalidadDatosDeudores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calidad de datos deudores";
            this.Load += new System.EventHandler(this.CalidadDatosDeudores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHojaExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button btnCargarExcel;
        private System.Windows.Forms.Button btnGenerarCalidadDatos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView tvTablas;
    }
}

