using Ada369Csharp.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ada369Csharp.Logica;
namespace Ada369Csharp.Presentacion.CAJA
{
    public partial class CierreTurno : Form
    {
        public CierreTurno()
        {
            InitializeComponent();
        }
        string correobase;
        string contraseña;
        string estado;
        double dinerocalculado;
        double resultado;
        string correoReceptor;
        int idusuario;
        int idcaja;
        string usuario;
        private void CierreTurno_Load(object sender, EventArgs e)
        {
            lblDeberiaHaber.Text = CIERRE_DE_CAJA.dineroencaja.ToString ();
            dinerocalculado = Convert.ToDouble ( lblDeberiaHaber.Text);
            mostrarCorreoBase();
            mostrarcorreodeEnvio();
            mostrarUsuarioSesion();
        }
        private void mostrarUsuarioSesion()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarUsuariosSesion(ref dt);
            foreach (DataRow row in dt.Rows )
            {
                usuario = row["Nombres_y_Apellidos"].ToString();
            }
        }
        public void mostrarcorreodeEnvio()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_empresa(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                correoReceptor = row["Correo_para_envio_de_reportes"].ToString();
                txtcorreo.Text = correoReceptor;
            }
        }
       private void mostrarCorreoBase()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarCorreoBase(ref dt);
           foreach (DataRow row in dt.Rows )
            {
                estado =Bases.Desencriptar(row["EstadoEnvio"].ToString());
                correobase= Bases.Desencriptar(row["Correo"].ToString());
                contraseña = Bases.Desencriptar(row["Password"].ToString());         
            }
           if (estado =="Sincronizado")
            {
                checkCorreo.Checked = true;
            }
           else
            {
                checkCorreo.Checked = false ;

            }
        }
        private void txthay_TextChanged(object sender, EventArgs e)
        {
            calcular();
           
        }
        private void validacionesCalculo()
        {
            if (resultado==0)
            {
                lblanuncio.Text = "Genial, Todo esta perfecto";
                lblanuncio.ForeColor = Color.FromArgb(0, 166, 63);
                lbldiferencia.ForeColor = Color.FromArgb(0, 166, 63);
                lblanuncio.Visible = true;

            }
            if (resultado < dinerocalculado & resultado !=0)
            {
                lblanuncio.Text = "La diferencia sera Registrada en su Turno y se enviara a Gerencia";
                lblanuncio.ForeColor = Color.FromArgb(231, 63, 67);
                lbldiferencia.ForeColor = Color.FromArgb(231, 63, 67);
                lblanuncio.Visible = true;

            }
            if(resultado > dinerocalculado)
            {
                lblanuncio.Text = "La diferencia sera Registrada en su Turno y se enviara a Gerencia";
                lblanuncio.ForeColor = Color.FromArgb(231, 63, 67);
                lbldiferencia.ForeColor = Color.FromArgb(231, 63, 67);
                lblanuncio.Visible = true;
            }
        }
        private void calcular()
        {
            try
            {

           
            double hay;
            hay = Convert.ToDouble(txthay.Text);
                if (string.IsNullOrEmpty( txthay.Text))
                {
                    hay = 0;
                }        
            resultado = hay - dinerocalculado;
            lbldiferencia.Text = resultado.ToString ();
            validacionesCalculo();
            }
            catch (Exception)
            {

             
            }
           
        }

        private void checkCorreo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkCorreo_Click(object sender, EventArgs e)
        {
            if(estado !="Sincronizado")
            {
                Presentacion.CorreoBase.ConfigurarCorreo frm = new Presentacion.CorreoBase.ConfigurarCorreo();
                frm.FormClosing += Frm_FormClosing;
                frm.ShowDialog();
            }
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrarCorreoBase();
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            cerrarCaja();

        }

        private void cerrarCaja()
        {
            
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);

            Lmcaja parametros = new Lmcaja();
            Editar_datos funcion = new Editar_datos();
            parametros.fechafin = DateTime.Now;
            parametros.fechacierre = DateTime.Now;
            parametros.ingresos = CIERRE_DE_CAJA.Ingresos;
            parametros.egresos = CIERRE_DE_CAJA.Egresos;
            parametros.Saldo_queda_en_caja = 0;
            parametros.Id_usuario = idusuario;
            parametros.Total_calculado = dinerocalculado;
            parametros.Total_real = Convert.ToDouble (txthay.Text);
            parametros.Estado = "CAJA CERRADA";
            parametros.Diferencia = resultado;
            parametros.Id_caja = idcaja;
           if (funcion.cerrarCaja(parametros)==true)
            {
                enviarcorreo();             
            }
        }
        
        private void enviarcorreo()
        {
            if (checkCorreo.Checked==true)
            {
                ReemplazarHtml();
                bool estado;
                estado = Bases.enviarCorreo(correobase, contraseña, htmldeEnvio.Text, "Cierre de caja ada369", txtcorreo.Text, "");
                if (estado == true)
                {
                    MessageBox.Show("Reporte de cierre de caja enviado");
                    generarCopiaBd();

                }
                else
                {
                    MessageBox.Show("Error de envio al correo");
                    generarCopiaBd();
                }
                
            }
            else
            {
                generarCopiaBd();
            }
               
        }
        private void generarCopiaBd()
        {
                Dispose();
                CopiasBd.GeneradorAutomatico frm = new CopiasBd.GeneradorAutomatico();
                frm.ShowDialog();
        }
        public void ReemplazarHtml()
        {
            
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@ventas_totales", CIERRE_DE_CAJA.ventastotales.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Ganancias", CIERRE_DE_CAJA.ganancias.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@fecha", DateTime.Now.ToString () );
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@usuario_nombre", usuario);
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@fondo_caja", CIERRE_DE_CAJA.saldoInicial.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@ventas_efectivo", CIERRE_DE_CAJA.ventasefectivo.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@pagos", "0");
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@cobros",CIERRE_DE_CAJA.CobrosTotal .ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@ingresosvarios", CIERRE_DE_CAJA.ingresosefectivo.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@gastosvarios", CIERRE_DE_CAJA.gastosefectivo.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@esperado", lblDeberiaHaber.Text);
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@vefectivo", CIERRE_DE_CAJA.ventasefectivo.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@vtarjeta", CIERRE_DE_CAJA.ventastarjeta.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@vcredito", CIERRE_DE_CAJA.ventascredito.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Tventas", CIERRE_DE_CAJA.ventastotales.ToString());

        }

        private void txthay_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txthay, e);

        }
    }
}
