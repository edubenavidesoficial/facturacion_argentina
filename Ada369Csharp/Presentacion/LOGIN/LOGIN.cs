using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Xml;
using Ada369Csharp.Logica;
using Ada369Csharp.CONEXION;
using Ada369Csharp.Datos;

namespace Ada369Csharp.Presentacion

{
   
    public partial class LOGIN : Form

    {
       
        int contador;
        int contadorCajas;
        int contador_Movimientos_de_caja;
        public static int idusuariovariable;
        public static int idcajavariable;
        int idusuarioVerificador;
        string lblSerialPc;
        string lblSerialPcLocal;
        string cajero= "Cajero (Si esta autorizado para manejar dinero)";
        string vendedor= "Solo Ventas (no esta autorizado para manejar dinero)";
        string administrador= "Administrador (Control total)";
        string lblRol;
        string txtlogin;
        string lblApertura_De_caja;
        string ResultadoLicencia;
        string FechaFinal;
        string Ip;
        public LOGIN()
              
        {
            InitializeComponent();

        }

        public void DIBUJARusuarios()

        {
            try
            {          
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select * from USUARIO2 WHERE Estado = 'ACTIVO'", con);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Label b = new Label();
                Panel p1 = new Panel();
                PictureBox I1 = new PictureBox();

                b.Text = rdr["Login"].ToString();
                b.Name = rdr["idUsuario"].ToString();
                b.Size = new System.Drawing.Size(175, 25);
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);    
                b.BackColor = Color.FromArgb(20, 20, 20);
                b.ForeColor = Color.White;
                b.Dock = DockStyle.Bottom;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Cursor = Cursors.Hand;

                p1.Size = new System.Drawing.Size(155, 167);
                p1.BorderStyle = BorderStyle.None;         
                p1.BackColor = Color.FromArgb(20, 20, 20);
                

                I1.Size = new System.Drawing.Size(175, 132);
                I1.Dock = DockStyle.Top;
                I1.BackgroundImage = null;
                byte[] bi = (Byte[])rdr["Icono"];

                MemoryStream ms = new MemoryStream(bi);
                I1.Image = Image.FromStream(ms);
                I1.SizeMode = PictureBoxSizeMode.Zoom;
                I1.Tag = rdr["Login"].ToString();
                I1.Cursor = Cursors.Hand;

                p1.Controls.Add(b);
                p1.Controls.Add(I1);
                b.BringToFront();
                flowLayoutPanel1 .Controls.Add(p1);

                b.Click += new EventHandler(mieventoLabel);
                I1.Click += new EventHandler(miEventoImagen);
            }
            con.Close();

            }
            catch (Exception ex)
            {

            }
        }
        private  void mostrar_roles()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
           
            SqlCommand com = new SqlCommand("mostrar_permisos_por_usuario_ROL_UNICO", con);
            com.CommandType = CommandType.StoredProcedure ;
            com.Parameters.AddWithValue("@idusario", idusuariovariable);
    
      
         
            try
            {
                con.Open();
                lblRol = Convert.ToString(com.ExecuteScalar());
                con.Close ();
              

            }
            catch (Exception ex)
            {
  
            }



        }
        private void miEventoImagen(System.Object sender, EventArgs e)
        {
            txtlogin = Convert.ToString(((PictureBox)sender).Tag);
            PanelIngreso_de_contraseña.Visible = true;
            PanelUsuarios.Visible = false;
           
        }
        
        private void mieventoLabel (System.Object sender, EventArgs e)
        {
            txtlogin = ((Label)sender).Text;
            PanelIngreso_de_contraseña.Visible = true;
            PanelUsuarios.Visible = false;
           
        }
        private void LOGIN_Load(object sender, EventArgs e)
        {
           
            validar_conexion();
            escalar_paneles();
            Bases.Obtener_serialPC(ref lblSerialPc);
            ObtenerIpLocal();
        }
        private void ObtenerIpLocal()
        {
               
            this.Text = Bases.ObtenerIp(ref Ip);
        }
       private void validarLicencia()
        {
            DLicencias funcion = new DLicencias();
            funcion.ValidarLicencias(ref ResultadoLicencia, ref FechaFinal );
            if (ResultadoLicencia== "?ACTIVO?")
            {
                lblestadoLicencia.Text = "Licencia de Prueba Activada hasta el: " + FechaFinal;
            }
            if (ResultadoLicencia == "?ACTIVADO PRO?")
            {
                lblestadoLicencia.Text = "Licencia PROFESIONAL Activada hasta el: " + FechaFinal;
            }
            if (ResultadoLicencia == "VENCIDA")
            {
                funcion.EditarMarcanVencidas();
                Dispose();
                LICENCIAS_MENBRESIAS.MembresiasNuevo frm = new LICENCIAS_MENBRESIAS.MembresiasNuevo();
                frm.ShowDialog();
            }



        }
        void escalar_paneles()
        {
            PanelUsuarios.Size = new System.Drawing.Size (1005, 649);
            PanelIngreso_de_contraseña.Size = new System.Drawing.Size(397, 654);
            PdeCarga.Size = new System.Drawing.Size(397, 654);
            PanelRestaurarCuenta.Size = new System.Drawing.Size(538, 654);
            PanelIngreso_de_contraseña.Visible = false;
            PdeCarga.Location = new Point((Width - PdeCarga.Width) / 2, (Height - PdeCarga.Height) / 2);
            PanelIngreso_de_contraseña.Location = new Point((Width - PanelIngreso_de_contraseña.Width) / 2, (Height - PanelIngreso_de_contraseña.Height) / 2);
            PanelUsuarios.Location = new Point((Width - PanelUsuarios.Width) / 2, (Height - PanelUsuarios.Height) / 2);
            PanelRestaurarCuenta.Location = new Point((Width - PanelRestaurarCuenta.Width) / 2, (Height - PanelRestaurarCuenta.Height) / 2);
            PanelUsuarios.Visible = true;
        }
        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Listarcierres_de_caja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void txtpaswwor_TextChanged(object sender, EventArgs e)
        {
            Iniciar_sesion_correcto();
        }
        private void contar_cierres_de_caja()
        {
            int x;

            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

        }
        private void aperturar_detalle_de_cierre_caja()
        {
            try
            {

           


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini",DateTime.Now );
            cmd.Parameters.AddWithValue("@fechafin", DateTime.Now);
                //cmd.Parameters.AddWithValue("@fecha", DateTime.Today);

                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Now);
            cmd.Parameters.AddWithValue("@ingresos", "0.00");
            cmd.Parameters.AddWithValue("@egresos", "0.00");
            cmd.Parameters.AddWithValue("@saldo", "0.00");
            cmd.Parameters.AddWithValue("@idusuario", idusuariovariable);
            cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
            cmd.Parameters.AddWithValue("@totalreal", "0.00");

            cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
            cmd.Parameters.AddWithValue("@diferencia", "0.00");
            cmd.Parameters.AddWithValue("@id_caja", idcajavariable );

                cmd.ExecuteNonQuery();
                con.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void obtener_idusuario()
        {
            try
            {
                idusuariovariable =Convert.ToInt32 ( datalistado.SelectedCells[1].Value);

            }
            catch
            {

            }
        }
        private void Iniciar_sesion_correcto()
        {
            cargarusuarios();
            contar();
            
          if (contador > 0)
            {
            obtener_idusuario();
            mostrar_roles();
               if (lblRol !=cajero )
                 {
                   timerValidarRol.Start();
                 }
               else if(lblRol ==cajero)
                 {
                    validar_aperturas_de_caja();
                 }
            }

       
        }
        private void obtener_usuario_que_aperturo_caja()
        {
            try
            {
                lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
            }
            catch
            {

            }
        }
        private void validar_aperturas_de_caja()
        {
            Listarcierres_de_caja();
            contar_cierres_de_caja(); 
            if (contadorCajas==0)
            {
                aperturar_detalle_de_cierre_caja();
                lblApertura_De_caja = "Nuevo*****";
                timerValidarRol.Start();
                
            }
            else
            {
                mostrar_movimientos_de_caja_por_serial_y_usuario();
                contar_movimientos_de_caja_por_usuario();
               
                if (contador_Movimientos_de_caja==0)
                {
                    obtener_usuario_que_aperturo_caja();
                    MessageBox.Show("Para poder continuar con el Turno de *" + lblnombredeCajero.Text + "* ,Inicia sesion con el Usuario " + lblusuario_queinicioCaja.Text + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblApertura_De_caja = "Aperturado";
                    timerValidarRol.Start();
                    
                }
            }                                  
         }
        private void mostrar_movimientos_de_caja_por_serial_y_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc);
                da.SelectCommand.Parameters.AddWithValue("@idusuario", idusuariovariable);
                da.Fill(dt);
                datalistado_movimientos_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_movimientos_de_caja_por_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contador_Movimientos_de_caja = (x);

        }
        private void contar()
        {
            int x;
         
            x = datalistado.Rows.Count;
            contador= (x);
          
        }
        private void cargarusuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password",Bases.Encriptar ( txtpaswwor .Text));
                da.SelectCommand.Parameters.AddWithValue("@login", txtlogin);

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

          

        }

        private void mostrar_correos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("select Correo from USUARIO2 where Estado='ACTIVO'", con);
               
                da.Fill(dt);
                txtcorreo.DisplayMember = "Correo";
                txtcorreo.ValueMember = "Correo";
                txtcorreo.DataSource = dt;
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = true;
            mostrar_correos();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = false;

        }

        private void mostrar_usuarios_por_correo()
        {
            try
            {
                //string resultado;                       
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;           
              SqlCommand   da = new SqlCommand ("buscar_USUARIO_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", txtcorreo.Text);

                con.Open();
                lblResultadoContraseña.Text  =  Convert.ToString (da.ExecuteScalar());
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
        
        private void Button3_Click(object sender, EventArgs e)

        {
            enviarCorreo();
        }
        private void enviarCorreo()
        {
            mostrar_usuarios_por_correo();
            richTextBox1.Text = richTextBox1.Text.Replace("@pass", lblResultadoContraseña.Text );
            Bases.enviarCorreo("francisco.udemy.2020@gmail.com","asdasdasd", richTextBox1.Text, "Solicitud de Contraseña",  txtcorreo.Text, "");

        }
        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        string INDICADOR;
        private void mostrar_usuarios_registrados()
        {
            try
            {
                
                CONEXIONMAESTRA.abrir();
                SqlCommand  da = new SqlCommand("select idUsuario from USUARIO2", CONEXIONMAESTRA.conectar );
                idusuarioVerificador =Convert.ToInt32 ( da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();       
                INDICADOR = "CORRECTO";
            }
            catch (Exception)
            {
                INDICADOR = "INCORRECTO";
                idusuarioVerificador = 0;
            }
        }
   
        int txtcontador_USUARIOS;
      private void validar_conexion()
        {
            mostrar_usuarios_registrados();


            if (INDICADOR == "CORRECTO")
            {

                if (idusuarioVerificador == 0)
                {
                    Dispose();
                    Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA();
                    frm.ShowDialog();
                    
                }
                else
                {
                    validarLicencia();
                    DIBUJARusuarios();
                }
            }



            if (INDICADOR == "INCORRECTO")
            {
                Dispose();
                Presentacion.ASISTENTE_DE_INSTALACION_servidor.Eleccion_Servidor_o_remoto frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.Eleccion_Servidor_o_remoto();
                frm.ShowDialog();
                
            }

          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
         
          
        }
        private void Ingresar_por_licencia_Temporal()
        {
            lblestadoLicencia.Text = "Licencia de Prueba Activada hasta el: " + txtfecha_final_licencia_temporal.Text;

        }
        private void Ingresar_por_licencia_de_paga()
        {
            lblestadoLicencia.Text = "Licencia PROFESIONAL Activada hasta el: " + txtfecha_final_licencia_temporal.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "0";

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtpaswwor.Text = txtpaswwor.Text + "9";
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtpaswwor.Clear();

        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        
        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtpaswwor.Text != "")
                    {
                    largo = txtpaswwor.Text.Length;
                    label4.Text = Convert.ToString(largo);
                    txtpaswwor.Text =Mid(txtpaswwor.Text, 0, largo - 1);
                    }
            }
            catch
            {

            }
        }
        
        private void tver_Click(object sender, EventArgs e)
        {

            txtpaswwor.PasswordChar = '\0';
            tocultar.Visible = true;
            tver.Visible = false ;
        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtpaswwor.PasswordChar  = '*';
            tocultar.Visible = false ;
            tver.Visible = true ;
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario o contraseña Incorrectos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void editar_inicio_De_sesion()
        {
            try
            {


                CONEXIONMAESTRA.abrir();
              
                SqlCommand cmd = new SqlCommand("editar_inicio_De_sesion", CONEXIONMAESTRA.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_serial_Pc", lblSerialPc);
                cmd.Parameters.AddWithValue("@id_usuario", idusuariovariable);                            
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerValidarRol_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                BackColor = Color.FromArgb(26, 26, 26);
                progressBar1.Value = progressBar1.Value + 10;
                PdeCarga.Visible = true;

            }
            else
            {
                progressBar1.Value = 0;
                timerValidarRol.Stop();            
                if (lblRol  == administrador )
                {
                
                    editar_inicio_De_sesion();
                    Dispose();
                    Admin_nivel_dios.DASHBOARD_PRINCIPAL  frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
                    frm.ShowDialog();
                    
                }
                else
                { 
                if (lblApertura_De_caja == "Nuevo*****" & lblRol == cajero )
                {
                    editar_inicio_De_sesion();
                    Dispose();
                    CAJA.APERTURA_DE_CAJA  frm = new CAJA.APERTURA_DE_CAJA();
                    frm.ShowDialog();
                       
                    }
               else if (lblApertura_De_caja == "Aperturado" & lblRol == cajero)
                {
                    editar_inicio_De_sesion();
                    Dispose();
                    VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frm = new VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
                    frm.ShowDialog();
                        
                    }
                else if(lblRol == vendedor)
                {
                    editar_inicio_De_sesion();
                    Dispose();
                    VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK  frm = new VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
                    frm.ShowDialog();
                        

                    }
             }

            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            

        }

        private void btncambioUsuario_Click(object sender, EventArgs e)
        {
            PanelUsuarios.Visible = true;
            PanelIngreso_de_contraseña.Visible = false;
            txtpaswwor.Clear();
        }
    }
}
