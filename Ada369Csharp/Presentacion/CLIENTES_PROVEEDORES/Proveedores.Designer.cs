﻿namespace Ada369Csharp.Presentacion.CLIENTES_PROVEEDORES
{
    partial class Proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedores));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.txtcelular = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Panelregistro = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.pNuevo = new System.Windows.Forms.PictureBox();
            this.Panel29 = new System.Windows.Forms.Panel();
            this.txtbusca = new System.Windows.Forms.TextBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Panelregistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pNuevo)).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Editar
            // 
            this.Editar.HeaderText = "";
            this.Editar.Image = ((System.Drawing.Image)(resources.GetObject("Editar.Image")));
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.datalistado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Editar});
            this.datalistado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datalistado.EnableHeadersVisualStyles = false;
            this.datalistado.Location = new System.Drawing.Point(0, 83);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.RowHeadersWidth = 9;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro;
            this.datalistado.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.datalistado.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.datalistado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado.RowTemplate.Height = 40;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(1073, 519);
            this.datalistado.TabIndex = 362;
            this.datalistado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel5.Location = new System.Drawing.Point(142, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(490, 1);
            this.panel5.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel4.Location = new System.Drawing.Point(141, 109);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(490, 1);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel3.Location = new System.Drawing.Point(142, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 1);
            this.panel3.TabIndex = 6;
            // 
            // txtdireccion
            // 
            this.txtdireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdireccion.Location = new System.Drawing.Point(142, 84);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(489, 19);
            this.txtdireccion.TabIndex = 5;
            // 
            // txtcelular
            // 
            this.txtcelular.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcelular.Location = new System.Drawing.Point(141, 52);
            this.txtcelular.Name = "txtcelular";
            this.txtcelular.Size = new System.Drawing.Size(490, 19);
            this.txtcelular.TabIndex = 4;
            // 
            // txtnombre
            // 
            this.txtnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnombre.Location = new System.Drawing.Point(141, 18);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(490, 19);
            this.txtnombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Direccion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Celular/ Tel: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(12, 63);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(565, 26);
            this.txtIdentificador.TabIndex = 338;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(9, 31);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(137, 20);
            this.Label14.TabIndex = 337;
            this.Label14.Text = "Identificador fiscal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdentificador);
            this.groupBox1.Controls.Add(this.Label14);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 99);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de FACTURACION (Opcional)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(138, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Location = new System.Drawing.Point(147, 3);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(164, 38);
            this.btnGuardarCambios.TabIndex = 8;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.Color.White;
            this.BtnVolver.FlatAppearance.BorderSize = 0;
            this.BtnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(317, 3);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(138, 38);
            this.BtnVolver.TabIndex = 8;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnGuardar);
            this.flowLayoutPanel1.Controls.Add(this.btnGuardarCambios);
            this.flowLayoutPanel1.Controls.Add(this.BtnVolver);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 226);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 45);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // Panelregistro
            // 
            this.Panelregistro.BackColor = System.Drawing.Color.White;
            this.Panelregistro.Controls.Add(this.flowLayoutPanel1);
            this.Panelregistro.Controls.Add(this.groupBox1);
            this.Panelregistro.Controls.Add(this.panel5);
            this.Panelregistro.Controls.Add(this.panel4);
            this.Panelregistro.Controls.Add(this.panel3);
            this.Panelregistro.Controls.Add(this.txtdireccion);
            this.Panelregistro.Controls.Add(this.txtcelular);
            this.Panelregistro.Controls.Add(this.txtnombre);
            this.Panelregistro.Controls.Add(this.label4);
            this.Panelregistro.Controls.Add(this.label3);
            this.Panelregistro.Controls.Add(this.label2);
            this.Panelregistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panelregistro.Location = new System.Drawing.Point(142, 114);
            this.Panelregistro.Name = "Panelregistro";
            this.Panelregistro.Size = new System.Drawing.Size(676, 350);
            this.Panelregistro.TabIndex = 361;
            this.Panelregistro.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1073, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedores";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(126, 41);
            this.ToolStripMenuItem4.Text = "ToolStripMenuItem3";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.AutoSize = false;
            this.ToolStripMenuItem5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ToolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripMenuItem5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.ToolStripMenuItem5.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem5.Image")));
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(50, 30);
            this.ToolStripMenuItem5.Text = "+";
            this.ToolStripMenuItem5.ToolTipText = "Guardar ";
            // 
            // pNuevo
            // 
            this.pNuevo.BackColor = System.Drawing.Color.White;
            this.pNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pNuevo.Image = ((System.Drawing.Image)(resources.GetObject("pNuevo.Image")));
            this.pNuevo.Location = new System.Drawing.Point(356, 38);
            this.pNuevo.Name = "pNuevo";
            this.pNuevo.Size = new System.Drawing.Size(111, 42);
            this.pNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pNuevo.TabIndex = 537;
            this.pNuevo.TabStop = false;
            this.pNuevo.Click += new System.EventHandler(this.pNuevo_Click);
            // 
            // Panel29
            // 
            this.Panel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.Panel29.Location = new System.Drawing.Point(12, 75);
            this.Panel29.Name = "Panel29";
            this.Panel29.Size = new System.Drawing.Size(273, 2);
            this.Panel29.TabIndex = 536;
            // 
            // txtbusca
            // 
            this.txtbusca.BackColor = System.Drawing.Color.White;
            this.txtbusca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbusca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtbusca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtbusca.ForeColor = System.Drawing.Color.Black;
            this.txtbusca.Location = new System.Drawing.Point(12, 50);
            this.txtbusca.Name = "txtbusca";
            this.txtbusca.Size = new System.Drawing.Size(272, 22);
            this.txtbusca.TabIndex = 534;
            this.txtbusca.TextChanged += new System.EventHandler(this.txtbusca_TextChanged);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.AutoSize = false;
            this.MenuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem5,
            this.ToolStripMenuItem4});
            this.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip1.Location = new System.Drawing.Point(286, 41);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.ShowItemToolTips = true;
            this.MenuStrip1.Size = new System.Drawing.Size(67, 45);
            this.MenuStrip1.TabIndex = 535;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pNuevo);
            this.panel1.Controls.Add(this.Panel29);
            this.panel1.Controls.Add(this.txtbusca);
            this.panel1.Controls.Add(this.MenuStrip1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 83);
            this.panel1.TabIndex = 360;
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 602);
            this.Controls.Add(this.Panelregistro);
            this.Controls.Add(this.datalistado);
            this.Controls.Add(this.panel1);
            this.Name = "Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Proveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Panelregistro.ResumeLayout(false);
            this.Panelregistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pNuevo)).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridViewImageColumn Editar;
        internal System.Windows.Forms.DataGridView datalistado;
        internal System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.TextBox txtcelular;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentificador;
        internal System.Windows.Forms.Label Label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel Panelregistro;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;
        internal System.Windows.Forms.PictureBox pNuevo;
        internal System.Windows.Forms.Panel Panel29;
        internal System.Windows.Forms.TextBox txtbusca;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.Panel panel1;
    }
}