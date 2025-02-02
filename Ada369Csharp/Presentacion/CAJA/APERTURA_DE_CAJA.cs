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
using Ada369Csharp.Datos;
namespace Ada369Csharp.Presentacion.CAJA
{
    public partial class APERTURA_DE_CAJA : Form
    {
        public APERTURA_DE_CAJA()
        {
            InitializeComponent();
        }
        int txtidcaja;
       

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (txtmonto.Text ))
            {
                txtmonto.Text = "0";
            }
            bool  estado = Editar_datos.editar_dinero_caja_inicial(txtidcaja, Convert.ToDouble(txtmonto.Text));
            if (estado ==true )
            {
                pasar_a_ventas();
            }       
        }

  
        private void APERTURA_DE_CAJA_Load(object sender, EventArgs e)
        {
            Bases.Cambiar_idioma_regional();
            Obtener_datos.Obtener_id_caja_PorSerial(ref txtidcaja);
            centrar_panel();
        }
        private void centrar_panel()
        {
            PanelCaja.Location = new Point((Width - PanelCaja.Width) / 2, (Height - PanelCaja.Height) / 2);
        }

        private void btnomitir_Click(object sender, EventArgs e)
        {
            pasar_a_ventas();
        }
        private void pasar_a_ventas()
        {
            Dispose();
            VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frm = new VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
            frm.ShowDialog();
           
        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtmonto, e);

        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
