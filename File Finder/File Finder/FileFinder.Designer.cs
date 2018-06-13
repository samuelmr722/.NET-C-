namespace File_Finder
{
    partial class FileFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileFinder));
            this.dgvDatosTutilo = new System.Windows.Forms.DataGridView();
            this.Open = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LkLblConfiguracion = new System.Windows.Forms.LinkLabel();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosTutilo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosTutilo
            // 
            this.dgvDatosTutilo.AllowUserToDeleteRows = false;
            this.dgvDatosTutilo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosTutilo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Open});
            this.dgvDatosTutilo.Location = new System.Drawing.Point(0, 34);
            this.dgvDatosTutilo.MultiSelect = false;
            this.dgvDatosTutilo.Name = "dgvDatosTutilo";
            this.dgvDatosTutilo.ReadOnly = true;
            this.dgvDatosTutilo.Size = new System.Drawing.Size(815, 274);
            this.dgvDatosTutilo.TabIndex = 1;
            this.dgvDatosTutilo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosTutilo_CellClick);
            // 
            // Open
            // 
            this.Open.Frozen = true;
            this.Open.HeaderText = "Open";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.Text = "Click";
            this.Open.UseColumnTextForButtonValue = true;
            this.Open.Width = 50;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(71, 8);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(587, 20);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Finder: ";
            // 
            // LkLblConfiguracion
            // 
            this.LkLblConfiguracion.AutoSize = true;
            this.LkLblConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LkLblConfiguracion.Location = new System.Drawing.Point(724, 11);
            this.LkLblConfiguracion.Name = "LkLblConfiguracion";
            this.LkLblConfiguracion.Size = new System.Drawing.Size(82, 13);
            this.LkLblConfiguracion.TabIndex = 5;
            this.LkLblConfiguracion.TabStop = true;
            this.LkLblConfiguracion.Text = "Configuration";
            this.LkLblConfiguracion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkLblConfiguracion_LinkClicked);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(681, 1);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(33, 27);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FileFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(819, 308);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.LkLblConfiguracion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvDatosTutilo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Finder   Vrc 1.0";
            this.Load += new System.EventHandler(this.FileFinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosTutilo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosTutilo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LkLblConfiguracion;
        private System.Windows.Forms.DataGridViewButtonColumn Open;
        private System.Windows.Forms.Button btnActualizar;
    }
}

