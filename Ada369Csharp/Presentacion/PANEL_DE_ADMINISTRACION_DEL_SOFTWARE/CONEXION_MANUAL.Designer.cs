namespace Ada369Csharp.PANEL_DE_ADMINISTRACION_DEL_SOFTWARE
{
    partial class CONEXION_MANUAL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONEXION_MANUAL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Logo_empresa = new System.Windows.Forms.PictureBox();
            this.txtCnString = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.datalistado_movimientos_validar = new System.Windows.Forms.DataGridView();
            this.DataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.Eli = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_empresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_movimientos_validar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo_empresa
            // 
            this.Logo_empresa.BackColor = System.Drawing.Color.White;
            this.Logo_empresa.Image = ((System.Drawing.Image)(resources.GetObject("Logo_empresa.Image")));
            this.Logo_empresa.Location = new System.Drawing.Point(580, 35);
            this.Logo_empresa.Name = "Logo_empresa";
            this.Logo_empresa.Size = new System.Drawing.Size(63, 54);
            this.Logo_empresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_empresa.TabIndex = 596;
            this.Logo_empresa.TabStop = false;
            // 
            // txtCnString
            // 
            this.txtCnString.BackColor = System.Drawing.Color.White;
            this.txtCnString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnString.Location = new System.Drawing.Point(14, 95);
            this.txtCnString.Multiline = true;
            this.txtCnString.Name = "txtCnString";
            this.txtCnString.Size = new System.Drawing.Size(629, 91);
            this.txtCnString.TabIndex = 591;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.BackColor = System.Drawing.Color.White;
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.Black;
            this.Button2.Location = new System.Drawing.Point(637, 7);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(27, 25);
            this.Button2.TabIndex = 595;
            this.Button2.Text = "X";
            this.Button2.UseVisualStyleBackColor = false;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(12, 35);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(375, 19);
            this.Label3.TabIndex = 592;
            this.Label3.Text = "Ingrese la cadena de conexion LOCAL\r\n";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(63)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageKey = "disk.png";
            this.btnSave.Location = new System.Drawing.Point(15, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(222, 28);
            this.btnSave.TabIndex = 594;
            this.btnSave.Text = "Generar cadena de conexion";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 7F);
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label2.Location = new System.Drawing.Point(9, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(449, 40);
            this.Label2.TabIndex = 593;
            this.Label2.Text = "Una vez que estes listo dale a \"Generar cadena de conexion\", se creara un Archivo" +
    " que contendra\r\ntu conexion Encryptada. Ahora tu conexion es mas Segura ante Pos" +
    "ibles hackers";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datalistado_movimientos_validar
            // 
            this.datalistado_movimientos_validar.AllowUserToAddRows = false;
            this.datalistado_movimientos_validar.AllowUserToDeleteRows = false;
            this.datalistado_movimientos_validar.AllowUserToResizeRows = false;
            this.datalistado_movimientos_validar.BackgroundColor = System.Drawing.Color.White;
            this.datalistado_movimientos_validar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado_movimientos_validar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datalistado_movimientos_validar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado_movimientos_validar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewCheckBoxColumn5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datalistado_movimientos_validar.DefaultCellStyle = dataGridViewCellStyle2;
            this.datalistado_movimientos_validar.Location = new System.Drawing.Point(299, 102);
            this.datalistado_movimientos_validar.Name = "datalistado_movimientos_validar";
            this.datalistado_movimientos_validar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado_movimientos_validar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datalistado_movimientos_validar.RowHeadersVisible = false;
            this.datalistado_movimientos_validar.RowHeadersWidth = 5;
            this.datalistado_movimientos_validar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.ForestGreen;
            this.datalistado_movimientos_validar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado_movimientos_validar.Size = new System.Drawing.Size(88, 44);
            this.datalistado_movimientos_validar.TabIndex = 597;
            // 
            // DataGridViewCheckBoxColumn5
            // 
            this.DataGridViewCheckBoxColumn5.DataPropertyName = "Activo";
            this.DataGridViewCheckBoxColumn5.HeaderText = "Activo";
            this.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5";
            this.DataGridViewCheckBoxColumn5.ReadOnly = true;
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToResizeRows = false;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eli});
            this.datalistado.EnableHeadersVisualStyles = false;
            this.datalistado.Location = new System.Drawing.Point(299, 192);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado.RowTemplate.Height = 30;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(180, 89);
            this.datalistado.TabIndex = 598;
            // 
            // Eli
            // 
            this.Eli.HeaderText = "";
            this.Eli.Image = ((System.Drawing.Image)(resources.GetObject("Eli.Image")));
            this.Eli.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eli.Name = "Eli";
            this.Eli.ReadOnly = true;
            // 
            // CONEXION_MANUAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 283);
            this.Controls.Add(this.datalistado);
            this.Controls.Add(this.Logo_empresa);
            this.Controls.Add(this.txtCnString);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.datalistado_movimientos_validar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CONEXION_MANUAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONEXION_MANUAL";
            this.Load += new System.EventHandler(this.CONEXION_MANUAL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo_empresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_movimientos_validar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox Logo_empresa;
        internal System.Windows.Forms.TextBox txtCnString;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label Label2;
        public System.Windows.Forms.DataGridView datalistado_movimientos_validar;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridView datalistado;
        private System.Windows.Forms.DataGridViewImageColumn Eli;
    }
}