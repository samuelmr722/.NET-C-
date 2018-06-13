namespace Calculo_de_inventario
{
    partial class FrmSentencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSentencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.rbtEnGrilla = new System.Windows.Forms.RadioButton();
            this.rbtEnExcel = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtEnExcel);
            this.panel1.Controls.Add(this.rbtEnGrilla);
            this.panel1.Controls.Add(this.lblServer);
            this.panel1.Controls.Add(this.btnEjecutar);
            this.panel1.Controls.Add(this.txtCadena);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 218);
            this.panel1.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(4, 178);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(31, 13);
            this.lblServer.TabIndex = 3;
            this.lblServer.Text = "--------";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Location = new System.Drawing.Point(360, 178);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(128, 40);
            this.btnEjecutar.TabIndex = 1;
            this.btnEjecutar.Text = "Calcular";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // txtCadena
            // 
            this.txtCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadena.Location = new System.Drawing.Point(4, 3);
            this.txtCadena.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCadena.MaxLength = 400000;
            this.txtCadena.Multiline = true;
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCadena.Size = new System.Drawing.Size(858, 169);
            this.txtCadena.TabIndex = 0;
            this.txtCadena.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCadena_KeyUp);
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Location = new System.Drawing.Point(2, 227);
            this.dgvResultado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.Size = new System.Drawing.Size(864, 501);
            this.dgvResultado.TabIndex = 2;
            // 
            // rbtEnGrilla
            // 
            this.rbtEnGrilla.AutoSize = true;
            this.rbtEnGrilla.Checked = true;
            this.rbtEnGrilla.Location = new System.Drawing.Point(770, 178);
            this.rbtEnGrilla.Name = "rbtEnGrilla";
            this.rbtEnGrilla.Size = new System.Drawing.Size(62, 17);
            this.rbtEnGrilla.TabIndex = 4;
            this.rbtEnGrilla.TabStop = true;
            this.rbtEnGrilla.Text = "En grilla";
            this.rbtEnGrilla.UseVisualStyleBackColor = true;
            // 
            // rbtEnExcel
            // 
            this.rbtEnExcel.AutoSize = true;
            this.rbtEnExcel.Location = new System.Drawing.Point(770, 201);
            this.rbtEnExcel.Name = "rbtEnExcel";
            this.rbtEnExcel.Size = new System.Drawing.Size(67, 17);
            this.rbtEnExcel.TabIndex = 5;
            this.rbtEnExcel.Text = "En Excel";
            this.rbtEnExcel.UseVisualStyleBackColor = true;
            // 
            // FrmSentencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 731);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FrmSentencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculo de inventario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblServer;        
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.RadioButton rbtEnExcel;
        private System.Windows.Forms.RadioButton rbtEnGrilla;
    }
}

