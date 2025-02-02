namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    partial class CANTIDAD_A_GRANEL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CANTIDAD_A_GRANEL));
            this.LblcantidadAumentar = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtprecio_unitario = new System.Windows.Forms.Label();
            this.Label38 = new System.Windows.Forms.Label();
            this.BtnCerrar_turno = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.puertos = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // LblcantidadAumentar
            // 
            this.LblcantidadAumentar.AutoSize = true;
            this.LblcantidadAumentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LblcantidadAumentar.ForeColor = System.Drawing.Color.Gray;
            this.LblcantidadAumentar.Location = new System.Drawing.Point(14, 48);
            this.LblcantidadAumentar.Name = "LblcantidadAumentar";
            this.LblcantidadAumentar.Size = new System.Drawing.Size(197, 25);
            this.LblcantidadAumentar.TabIndex = 537;
            this.LblcantidadAumentar.Text = "Cantidad a Aumentar";
            this.LblcantidadAumentar.Visible = false;
            // 
            // txtProducto
            // 
            this.txtProducto.AutoSize = true;
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.txtProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(63)))));
            this.txtProducto.Location = new System.Drawing.Point(12, 9);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(195, 39);
            this.txtProducto.TabIndex = 538;
            this.txtProducto.Text = "txtproducto";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.txtcantidad.Location = new System.Drawing.Point(28, 117);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(163, 45);
            this.txtcantidad.TabIndex = 547;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // txttotal
            // 
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.txttotal.Location = new System.Drawing.Point(226, 117);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(205, 45);
            this.txttotal.TabIndex = 546;
            this.txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotal_KeyPress);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Label27.ForeColor = System.Drawing.Color.Gray;
            this.Label27.Location = new System.Drawing.Point(262, 89);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(137, 25);
            this.Label27.TabIndex = 544;
            this.Label27.Text = "Importe Actual";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(50, 89);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(97, 25);
            this.Label14.TabIndex = 545;
            this.Label14.Text = "Cantidad:";
            // 
            // txtprecio_unitario
            // 
            this.txtprecio_unitario.AutoSize = true;
            this.txtprecio_unitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtprecio_unitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(63)))));
            this.txtprecio_unitario.Location = new System.Drawing.Point(251, 177);
            this.txtprecio_unitario.Name = "txtprecio_unitario";
            this.txtprecio_unitario.Size = new System.Drawing.Size(30, 31);
            this.txtprecio_unitario.TabIndex = 548;
            this.txtprecio_unitario.Text = "0";
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.Label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(63)))));
            this.Label38.Location = new System.Drawing.Point(22, 177);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(235, 31);
            this.Label38.TabIndex = 549;
            this.Label38.Text = "Precio unitario = ";
            // 
            // BtnCerrar_turno
            // 
            this.BtnCerrar_turno.BackColor = System.Drawing.Color.Transparent;
            this.BtnCerrar_turno.BackgroundImage = global::Ada369Csharp.Properties.Resources.naranja;
            this.BtnCerrar_turno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCerrar_turno.FlatAppearance.BorderSize = 0;
            this.BtnCerrar_turno.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnCerrar_turno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnCerrar_turno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar_turno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar_turno.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar_turno.Location = new System.Drawing.Point(449, 71);
            this.BtnCerrar_turno.Name = "BtnCerrar_turno";
            this.BtnCerrar_turno.Size = new System.Drawing.Size(124, 43);
            this.BtnCerrar_turno.TabIndex = 601;
            this.BtnCerrar_turno.Text = "Agregar";
            this.BtnCerrar_turno.UseVisualStyleBackColor = false;
            this.BtnCerrar_turno.Click += new System.EventHandler(this.BtnCerrar_turno_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Ada369Csharp.Properties.Resources.Rojo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(449, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 43);
            this.button1.TabIndex = 602;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // puertos
            // 
            this.puertos.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.puertos_DataReceived);
            // 
            // CANTIDAD_A_GRANEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 229);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnCerrar_turno);
            this.Controls.Add(this.txtprecio_unitario);
            this.Controls.Add(this.Label38);
            this.Controls.Add(this.txtcantidad);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.LblcantidadAumentar);
            this.Controls.Add(this.txtProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CANTIDAD_A_GRANEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ada 369";
            this.Load += new System.EventHandler(this.CANTIDAD_A_GRANEL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblcantidadAumentar;
        internal System.Windows.Forms.Label txtProducto;
        internal System.Windows.Forms.TextBox txtcantidad;
        internal System.Windows.Forms.TextBox txttotal;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label txtprecio_unitario;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Button BtnCerrar_turno;
        internal System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort puertos;
    }
}