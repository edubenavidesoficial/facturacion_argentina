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
namespace Ada369Csharp.Presentacion.DISEÑADOR_DE_COMPROBANTES
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }
        string txttipo;
        private void Ticket_Load(object sender, EventArgs e)
        {
            Mostrar_formato_ticket();
            obtener_datos();
        }
        private void Mostrar_formato_ticket()
        {
            try
            {


                DataTable dt = new DataTable();
                SqlDataAdapter da;
                CONEXION.CONEXIONMAESTRA.conectar.Open();
                da = new SqlDataAdapter("Mostrar_formato_ticket", CONEXION.CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                datalistado_tickets.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void obtener_datos()
        {
            try
            {
                txttipo = datalistado_tickets.SelectedCells[13].Value.ToString();
                if (txttipo == "Ticket No Fiscal")
                {
                    btnTicket.BackColor = Color.FromArgb(255, 204, 1);
                    btnFacturaBoleta.BackColor = Color.White;
                    txtAutorizacion_fiscal.Visible = false;
                }
                else
                {
                    btnFacturaBoleta.BackColor = Color.FromArgb(255, 204, 1);
                    btnTicket.BackColor = Color.White;
                    txtAutorizacion_fiscal.Visible = true;
                }
                ICONO.BackgroundImage = null;
                byte[] b = (Byte[])datalistado_tickets.SelectedCells[1].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image= Image.FromStream(ms);

                txtempresaTICKET.Text = datalistado_tickets.SelectedCells[2].Value.ToString();
                txtEmpresa_RUC.Text = datalistado_tickets.SelectedCells[5].Value.ToString();
                txtDireccion.Text = datalistado_tickets.SelectedCells[6].Value.ToString();
                txtProvincia_departamento.Text = datalistado_tickets.SelectedCells[7].Value.ToString();
                txtMoneda_String.Text = datalistado_tickets.SelectedCells[8].Value.ToString();
                txtAgradecimiento.Text = datalistado_tickets.SelectedCells[9].Value.ToString();
                txtpagina_o_facebook.Text = datalistado_tickets.SelectedCells[10].Value.ToString();
                TXTANUNCIO.Text = datalistado_tickets.SelectedCells[11].Value.ToString();
                txtAutorizacion_fiscal.Text = datalistado_tickets.SelectedCells[12].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            txttipo = "Ticket No Fiscal";
            btnTicket.BackColor = Color.FromArgb(255, 204, 1);
        btnFacturaBoleta.BackColor = Color.White;
            txtAutorizacion_fiscal.Visible = false;
        }

        private void btnFacturaBoleta_Click(object sender, EventArgs e)
        {
            txttipo = "Factura-Boleta";
            btnTicket.BackColor = Color.White;
            btnFacturaBoleta.BackColor = Color.FromArgb(255, 204, 1);
            txtAutorizacion_fiscal.Visible = true ;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "Imagenes|*.jpg;*.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Title = "Cargador de Imagenes Ada 369";
            if (openFileDialog1.ShowDialog  ()== DialogResult.OK )
            {
                ICONO.BackgroundImage = null;
                ICONO.Image = new Bitmap(openFileDialog1.FileName);
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
               CONEXION.CONEXIONMAESTRA.conectar .Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_FORMATO_TICKET", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificador_fiscal", txtEmpresa_RUC.Text);
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@Provincia_Departamento_Pais", txtProvincia_departamento.Text);
                cmd.Parameters.AddWithValue("@Nombre_de_Moneda", txtMoneda_String.Text);
                cmd.Parameters.AddWithValue("@Agradecimiento", txtAgradecimiento.Text);
                cmd.Parameters.AddWithValue("@pagina_Web_Facebook", txtpagina_o_facebook.Text);
                cmd.Parameters.AddWithValue("@Anuncio", TXTANUNCIO.Text);
                if (txttipo== "Ticket No Fiscal")
                {
                cmd.Parameters.AddWithValue("@Datos_fiscales_de_autorizacion", "-");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Datos_fiscales_de_autorizacion", txtAutorizacion_fiscal.Text );
                }
                cmd.Parameters.AddWithValue("@Por_defecto", txttipo);
                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresaTICKET.Text);
                MemoryStream ms = new MemoryStream();
                ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Logo", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.conectar.Close();
                MessageBox.Show("Datos actualizados correctamente", "Actualizando datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.StackTrace);
            }
        }
    }
}
