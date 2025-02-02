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
using System.Management;
using Ada369Csharp.Logica;
using Ada369Csharp.Datos;

namespace Ada369Csharp.Presentacion.ASISTENTE_DE_INSTALACION_servidor
{
    public partial class USUARIOS_AUTORIZADOS_AL_SISTEMA : Form
    {
        public USUARIOS_AUTORIZADOS_AL_SISTEMA()
        {
            InitializeComponent();
        }
        string lblIDSERIAL;
        private void USUARIOS_AUTORIZADOS_AL_SISTEMA_Load(object sender, EventArgs e)
        {
            Panel2.Location = new Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2);

            Bases.Obtener_serialPC(ref lblIDSERIAL);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && TXTCONTRASEÑA.Text != "" && TXTUSUARIO.Text != "")
              {
                if (TXTCONTRASEÑA.Text == txtconfirmarcontraseña.Text)
                    {
                    string contraseña_encryptada;
                    contraseña_encryptada = Bases.Encriptar(this.TXTCONTRASEÑA.Text.Trim());
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                        cmd.Parameters.AddWithValue("@Login", TXTUSUARIO.Text);
                        cmd.Parameters.AddWithValue("@Password", contraseña_encryptada);

                        cmd.Parameters.AddWithValue("@Correo", Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA.correo );
                        cmd.Parameters.AddWithValue("@Rol", "Administrador (Control total)");
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat);


                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("@Nombre_de_icono", "Ada_369");
                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Insertar_licencia_de_prueba_30_dias();
                        insertar_cliente_standar();
                        insertar_grupo_por_defecto();
                        insertar_proveedor_standar();
                        insertar_inicio_De_sesion();
                        MessageBox.Show("!LISTO! RECUERDA que para Iniciar Sesión tu Usuario es: " + TXTUSUARIO.Text + " y tu Contraseña es: " + TXTCONTRASEÑA.Text, "Registro Exitoso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        Dispose();
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no Coinciden", "Contraseñas Incompatibles", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Falta ingresar Datos", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private void Insertar_licencia_de_prueba_30_dias()
        {
            DateTime today = DateTime.Now;
            DateTime fechaFinal = today.AddDays(30);
            txtfechaFinalOK.Text = Convert.ToString(fechaFinal);
            string SERIALpC;
            SERIALpC = lblIDSERIAL;
            string FECHA_FINAL;
            FECHA_FINAL = Bases.Encriptar(this.txtfechaFinalOK.Text.Trim());
            string estado;
            estado = Bases.Encriptar("?ACTIVO?");
            string fecha_activacion;
            fecha_activacion = Bases.Encriptar(this.txtfechaInicio.Text.Trim());


            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_marcan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@s", SERIALpC);
                cmd.Parameters.AddWithValue("@f", FECHA_FINAL);
                cmd.Parameters.AddWithValue("@e", estado);
                cmd.Parameters.AddWithValue("@fa", fecha_activacion);
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_cliente_standar()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_clientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", "GENERICO");
                cmd.Parameters.AddWithValue("@Direccion", 0);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal ", 0);
                cmd.Parameters.AddWithValue("@Celular", 0);
                cmd.Parameters.AddWithValue("@Estado ", 0);
                cmd.Parameters.AddWithValue("@Saldo", 0);
           
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_grupo_por_defecto()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Grupo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", "General");
                cmd.Parameters.AddWithValue("@Por_defecto", "Si");
               
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_inicio_De_sesion()
        {
            try
            {

                string serialPC;
                serialPC = lblIDSERIAL;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_inicio_De_sesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_serial_Pc", serialPC);

                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_proveedor_standar()
        {
            var funcion = new Dproveedores();
            var parametros = new Lproveedores();
            parametros.Nombre = "GENERICO";
            parametros.Direccion = "0";
            parametros.IdentificadorFiscal = "0";
            parametros.Celular = "0";
            parametros.Estado = "0";
            parametros.Saldo = 0;
            funcion.insertar_Proveedores(parametros);
        }
    }
}
