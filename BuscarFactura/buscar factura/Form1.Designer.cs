namespace Buscar_Factura
{
    partial class Bucar_Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bucar_Factura));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.FrmIngreso = new System.Windows.Forms.GroupBox();
            this.rbtn2013 = new System.Windows.Forms.RadioButton();
            this.rbtn2012 = new System.Windows.Forms.RadioButton();
            this.rbtn2011 = new System.Windows.Forms.RadioButton();
            this.rbtn2010 = new System.Windows.Forms.RadioButton();
            this.rbtn2009 = new System.Windows.Forms.RadioButton();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.FrmIngreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de la factura:";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(147, 16);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(108, 20);
            this.txtNumeroFactura.TabIndex = 1;
            this.txtNumeroFactura.TextChanged += new System.EventHandler(this.txtNumeroFactura_TextChanged);
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            // 
            // FrmIngreso
            // 
            this.FrmIngreso.Controls.Add(this.rbtn2013);
            this.FrmIngreso.Controls.Add(this.rbtn2012);
            this.FrmIngreso.Controls.Add(this.rbtn2011);
            this.FrmIngreso.Controls.Add(this.rbtn2010);
            this.FrmIngreso.Controls.Add(this.rbtn2009);
            this.FrmIngreso.Controls.Add(this.btnGenerar);
            this.FrmIngreso.Controls.Add(this.lblMensaje);
            this.FrmIngreso.Controls.Add(this.btnBuscar);
            this.FrmIngreso.Controls.Add(this.label1);
            this.FrmIngreso.Controls.Add(this.txtNumeroFactura);
            this.FrmIngreso.Location = new System.Drawing.Point(12, 10);
            this.FrmIngreso.Name = "FrmIngreso";
            this.FrmIngreso.Size = new System.Drawing.Size(364, 222);
            this.FrmIngreso.TabIndex = 2;
            this.FrmIngreso.TabStop = false;
            // 
            // rbtn2013
            // 
            this.rbtn2013.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rbtn2013.AutoSize = true;
            this.rbtn2013.Checked = true;
            this.rbtn2013.Location = new System.Drawing.Point(273, 125);
            this.rbtn2013.Name = "rbtn2013";
            this.rbtn2013.Size = new System.Drawing.Size(70, 17);
            this.rbtn2013.TabIndex = 15;
            this.rbtn2013.TabStop = true;
            this.rbtn2013.Text = "año 2013";
            this.rbtn2013.UseVisualStyleBackColor = true;
            // 
            // rbtn2012
            // 
            this.rbtn2012.AutoSize = true;
            this.rbtn2012.Location = new System.Drawing.Point(273, 102);
            this.rbtn2012.Name = "rbtn2012";
            this.rbtn2012.Size = new System.Drawing.Size(70, 17);
            this.rbtn2012.TabIndex = 14;
            this.rbtn2012.Text = "año 2012";
            this.rbtn2012.UseVisualStyleBackColor = true;
            //this.rbtn2012.CheckedChanged += new System.EventHandler(this.rbtn2012_CheckedChanged);
            // 
            // rbtn2011
            // 
            this.rbtn2011.AutoSize = true;
            this.rbtn2011.Location = new System.Drawing.Point(273, 79);
            this.rbtn2011.Name = "rbtn2011";
            this.rbtn2011.Size = new System.Drawing.Size(70, 17);
            this.rbtn2011.TabIndex = 13;
            this.rbtn2011.Text = "año 2011";
            this.rbtn2011.UseVisualStyleBackColor = true;
            //this.rbtn2011.CheckedChanged += new System.EventHandler(this.rbtn2012_CheckedChanged);
            // 
            // rbtn2010
            // 
            this.rbtn2010.AutoSize = true;
            this.rbtn2010.Location = new System.Drawing.Point(273, 56);
            this.rbtn2010.Name = "rbtn2010";
            this.rbtn2010.Size = new System.Drawing.Size(70, 17);
            this.rbtn2010.TabIndex = 12;
            this.rbtn2010.Text = "año 2010";
            this.rbtn2010.UseVisualStyleBackColor = true;
            //this.rbtn2010.CheckedChanged += new System.EventHandler(this.rbtn2012_CheckedChanged);
            // 
            // rbtn2009
            // 
            this.rbtn2009.AutoSize = true;
            this.rbtn2009.Location = new System.Drawing.Point(273, 33);
            this.rbtn2009.Name = "rbtn2009";
            this.rbtn2009.Size = new System.Drawing.Size(70, 17);
            this.rbtn2009.TabIndex = 11;
            this.rbtn2009.Text = "año 2009";
            this.rbtn2009.UseVisualStyleBackColor = true;
            //this.rbtn2009.CheckedChanged += new System.EventHandler(this.rbtn2012_CheckedChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(140, 72);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(96, 30);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(6, 154);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(352, 60);
            this.lblMensaje.TabIndex = 9;
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(21, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Bucar_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 235);
            this.Controls.Add(this.FrmIngreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bucar_Factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Factura";
            this.FrmIngreso.ResumeLayout(false);
            this.FrmIngreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.GroupBox FrmIngreso;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.RadioButton rbtn2010;
        private System.Windows.Forms.RadioButton rbtn2009;
        private System.Windows.Forms.RadioButton rbtn2012;
        private System.Windows.Forms.RadioButton rbtn2011;
        private System.Windows.Forms.RadioButton rbtn2013;
    }
}

