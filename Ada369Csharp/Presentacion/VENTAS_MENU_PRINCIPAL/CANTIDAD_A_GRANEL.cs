using Ada369Csharp.Datos;
using Ada369Csharp.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class CANTIDAD_A_GRANEL : Form
    {
        public CANTIDAD_A_GRANEL()
        {
            InitializeComponent();
        }
        private string BufeerRespuesta;
        private delegate void DelegadoAcceso(string accion);
        public  double preciounitario;
        string puertoBalanza;
        string estadoPuerto;
        private void AccesoForm(string accion)
        {
            BufeerRespuesta = accion;
            txtcantidad.Text = BufeerRespuesta;
        }
        private void accesoInterrupcion(string accion)
        {
            DelegadoAcceso Var_delagadoacceso;
            Var_delagadoacceso = new DelegadoAcceso(AccesoForm);
            Object[] arg = { accion };
            base.Invoke(Var_delagadoacceso, arg);
        }
        private void puertos_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            accesoInterrupcion(puertos.ReadExisting());
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            VENTAS_MENU_PRINCIPALOK.txtpantalla=Convert.ToDouble (txtcantidad.Text) ;
            Dispose();
        }

        private void CANTIDAD_A_GRANEL_Load(object sender, EventArgs e)
        {
            txtprecio_unitario.Text = Convert.ToString(preciounitario);
            mostrarPuertos();
        }
        private void abrirPuertosBalanza()
        {
            puertos.Close();
            try
            {
                puertos.BaudRate = 9600;
                puertos.DataBits = 8;
                puertos.Parity = Parity.None;
                puertos.StopBits = (StopBits)1;
                puertos.PortName = puertoBalanza;
                puertos.Open();
                if (puertos.IsOpen)
                {
                    estadoPuerto = "Conectado";
                }
                else
                {
                    estadoPuerto = "Fallo la conexion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void mostrarPuertos()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarPuertos(ref dt);
            foreach (DataRow rdr in dt.Rows)
            {
                puertoBalanza = rdr["PuertoBalanza"].ToString();
                estadoPuerto = rdr["EstadoBalanza"].ToString();
            }
            MessageBox.Show(estadoPuerto);
            if (estadoPuerto == "CONFIRMADO")
            {
                abrirPuertosBalanza();
            }
        }
        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }
        private void calcularTotal()
        {
            try
            {
            double total;
            double cantidad;
            cantidad =Convert.ToDouble ( txtcantidad.Text);
            total = preciounitario * cantidad;
            txttotal.Text =Convert.ToString ( total);
            }
            catch (Exception)
            {

            }
            
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtcantidad, e);
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txttotal, e);

        }
    }
}
