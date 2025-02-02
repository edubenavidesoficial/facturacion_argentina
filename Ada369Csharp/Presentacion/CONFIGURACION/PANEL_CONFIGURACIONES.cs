using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ada369Csharp.Presentacion.CONFIGURACION
{
    public partial class PANEL_CONFIGURACIONES : Form
    {
        public PANEL_CONFIGURACIONES()
        {
            InitializeComponent();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Dispose();
            PRODUCTOS_OK.Productos_ok frm = new PRODUCTOS_OK.Productos_ok();
          
            frm.ShowDialog();
        }

       

    

     
        private void Logo_empresa_Click(object sender, EventArgs e)
        {
            Configurar_empresa();

        }

        private void Configurar_empresa()
        {
       
          EMPRESA_CONFIGURACION.EMPRESA_CONFIG frm = new EMPRESA_CONFIGURACION.EMPRESA_CONFIG();
          frm.ShowDialog();
        }
        private void Label47_Click(object sender, EventArgs e)
        {
            Configurar_empresa();
        }

        private void PANEL_CONFIGURACIONES_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Usuarios();
        }
        private void Usuarios()
        {
            usuariosok frm = new usuariosok();
            frm.ShowDialog();

        }

        private void Label26_Click(object sender, EventArgs e)
        {
            Usuarios();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            mostrar_cajas();
        }
        private void mostrar_cajas()
        {
            Dispose();
            CAJA.Cajas_form frm = new CAJA.Cajas_form();
            frm.ShowDialog();
        }

        private void Label27_Click(object sender, EventArgs e)
        {
            mostrar_cajas();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
           
       
            CLIENTES_PROVEEDORES.ClientesOk  frm = new CLIENTES_PROVEEDORES.ClientesOk();
            frm.ShowDialog();

        
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            CLIENTES_PROVEEDORES.Proveedores frm = new CLIENTES_PROVEEDORES.Proveedores();
            frm.ShowDialog();
        }

        private void btncorreo_Click(object sender, EventArgs e)
        {
            Presentacion.CorreoBase.ConfigurarCorreo frm = new Presentacion.CorreoBase.ConfigurarCorreo();
            frm.ShowDialog();
        }

        private void btnimpresoras_Click(object sender, EventArgs e)
        {
            Impresoras.Admin_impresoras frm = new Impresoras.Admin_impresoras();
            frm.ShowDialog();
        }

        private void btndiseñador_Click(object sender, EventArgs e)
        {
            DISEÑADOR_DE_COMPROBANTES.Ticket frm = new DISEÑADOR_DE_COMPROBANTES.Ticket();
            frm.ShowDialog();
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            Dispose();
            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
            frm.ShowDialog();
        }

        private void btnRespaldos_Click(object sender, EventArgs e)
        {
            CopiasBd.CrearCopiaBd frm = new CopiasBd.CrearCopiaBd();
            frm.ShowDialog();
        }

        private void PANEL_CONFIGURACIONES_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
            frm.ShowDialog();
        }

        private void btnBalanza_Click(object sender, EventArgs e)
        {
            BalanzaElectronica.BalanzaForm frm = new BalanzaElectronica.BalanzaForm();
            frm.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SERIALIZACION_DE_COMPROBANTES.SERIALIZACION frm = new SERIALIZACION_DE_COMPROBANTES.SERIALIZACION();
            frm.ShowDialog();
        }
    }
}
