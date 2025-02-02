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
namespace Ada369Csharp.Presentacion.NOTIFICACIONES
{
    public partial class Notificaciones_form : Form
    {
        public Notificaciones_form()
        {
            InitializeComponent();
        }

        private void dibujarPRODUCTOS_vencidos()
        {
try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("contar_productos_vencidos", con);
                SqlDataReader rdr = cmd.ExecuteReader ();
                while (rdr.Read ())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox I1 = new PictureBox() ;
                    PictureBox I2 = new PictureBox();
                    Label L = new Label();

                    b.Text = "Tienes Productos Vencidos";
                    b.Name = rdr["id"].ToString();
                    b.Size = new System.Drawing.Size(430, 35);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.Black;
                    b.Dock = DockStyle.Top;
                    b.TextAlign = ContentAlignment.MiddleLeft;

                    L.Text = "(" + rdr["id"].ToString() + ") Producto(s) Vencido(s)";
                    L.Name = rdr["id"].ToString();
                    L.Size = new System.Drawing.Size(430, 18);
                    L.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                    L.BackColor = Color.Transparent;
                    L.ForeColor = Color.Gray;
                    L.Dock = DockStyle.Fill;
                    L.TextAlign = ContentAlignment.MiddleLeft;

                    I2.BackgroundImage = Properties.Resources.advertencia;
                    I2.BackgroundImageLayout = ImageLayout.Zoom;
                    I2.Size = new System.Drawing.Size(18, 18);
                    I2.Dock = DockStyle.Left;

                    p1.Size = new System.Drawing.Size(430, 67);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Top ;
                    p1.BackColor = Color.White;

                    p2.Size = new System.Drawing.Size(287, 22);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent ;

                    I1.BackgroundImage  = Properties.Resources.calendario;
                    I1.BackgroundImageLayout  = ImageLayout .Zoom;
                    I1.Size = new System.Drawing.Size(90, 69);
                    I1.Dock = DockStyle.Left;
                    I1.BackColor = Color.Transparent;


                    p1.Controls.Add(b);
                    p1.Controls.Add(I1);
                    p1.Controls.Add(p2);
                    p2.Controls.Add(I2);
                    p2.Controls.Add(L);

                    p2.BringToFront();
                    b.SendToBack();
                    I1.SendToBack();
                    L.BringToFront();

                    PanelCONTENEDORDENOTIFICACIONES.Controls.Add(p1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void Notificaciones_form_Load(object sender, EventArgs e)
        {
            dibujarPRODUCTOS_vencidos();

        }
    }
}
