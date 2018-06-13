namespace File_Finder
{
    partial class MaestroRutas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaestroRutas));
            this.dgvRutas = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bntNuevaRuta = new System.Windows.Forms.Button();
            this.btnEliminarRuta = new System.Windows.Forms.Button();
            this.btnCrearDbRutas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRutas
            // 
            this.dgvRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRutas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvRutas.Location = new System.Drawing.Point(1, 1);
            this.dgvRutas.Name = "dgvRutas";
            this.dgvRutas.Size = new System.Drawing.Size(687, 226);
            this.dgvRutas.TabIndex = 0;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // bntNuevaRuta
            // 
            this.bntNuevaRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntNuevaRuta.Location = new System.Drawing.Point(1, 233);
            this.bntNuevaRuta.Name = "bntNuevaRuta";
            this.bntNuevaRuta.Size = new System.Drawing.Size(146, 35);
            this.bntNuevaRuta.TabIndex = 1;
            this.bntNuevaRuta.Text = "Buscar nueva ruta";
            this.bntNuevaRuta.UseVisualStyleBackColor = true;
            this.bntNuevaRuta.Click += new System.EventHandler(this.bntNuevaRuta_Click);
            // 
            // btnEliminarRuta
            // 
            this.btnEliminarRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRuta.Location = new System.Drawing.Point(171, 233);
            this.btnEliminarRuta.Name = "btnEliminarRuta";
            this.btnEliminarRuta.Size = new System.Drawing.Size(120, 35);
            this.btnEliminarRuta.TabIndex = 2;
            this.btnEliminarRuta.Text = "Eliminar ruta";
            this.btnEliminarRuta.UseVisualStyleBackColor = true;
            this.btnEliminarRuta.Click += new System.EventHandler(this.btnEliminarRuta_Click);
            // 
            // btnCrearDbRutas
            // 
            this.btnCrearDbRutas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearDbRutas.Location = new System.Drawing.Point(313, 233);
            this.btnCrearDbRutas.Name = "btnCrearDbRutas";
            this.btnCrearDbRutas.Size = new System.Drawing.Size(230, 35);
            this.btnCrearDbRutas.TabIndex = 3;
            this.btnCrearDbRutas.Text = "Crear una nueva Base de datos";
            this.btnCrearDbRutas.UseVisualStyleBackColor = true;
            this.btnCrearDbRutas.Click += new System.EventHandler(this.btnCrearDbRutas_Click);
            // 
            // MaestroRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 271);
            this.Controls.Add(this.btnCrearDbRutas);
            this.Controls.Add(this.btnEliminarRuta);
            this.Controls.Add(this.bntNuevaRuta);
            this.Controls.Add(this.dgvRutas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaestroRutas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Routes";
            this.Load += new System.EventHandler(this.MaestroRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRutas;
        private System.Windows.Forms.Button bntNuevaRuta;
        private System.Windows.Forms.Button btnEliminarRuta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Button btnCrearDbRutas;
    }
}