using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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

        private void btnAlmacenarFirma_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Certificados PFX (*.pfx)|*.pfx",
                Title = "Seleccionar Certificado Digital"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string certPath = openFileDialog.FileName;
                string certPassword = PromptPassword();

                if (!string.IsNullOrEmpty(certPassword))
                {
                    try
                    {
                        // Cargar el certificado para validar que la contraseña es correcta
                        X509Certificate2 cert = new X509Certificate2(certPath, certPassword);

                        // Pedir al usuario dónde quiere guardar el archivo
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Archivo de Configuración (*.txt)|*.txt",
                            Title = "Guardar Configuración de Firma",
                            FileName = "firma_config.txt"
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string savePath = saveFileDialog.FileName;
                            File.WriteAllText(savePath, certPath + "|" + certPassword);
                            MessageBox.Show("Firma almacenada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al almacenar la firma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Método para solicitar la contraseña al usuario
        private string PromptPassword()
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Ingresar Contraseña",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblText = new Label() { Left = 20, Top = 20, Text = "Contraseña:" };
            TextBox txtPassword = new TextBox() { Left = 20, Top = 50, Width = 200, UseSystemPasswordChar = true };
            Button btnOk = new Button() { Text = "Aceptar", Left = 150, Width = 70, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(txtPassword);
            prompt.Controls.Add(btnOk);
            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == DialogResult.OK ? txtPassword.Text : "";
        }

        private void btnMercadoPago_Click(object sender, EventArgs e)
        {
           var token_mercado_pago = PromptMercadoPago();
            if (string.IsNullOrWhiteSpace(token_mercado_pago))
            {
                MessageBox.Show("No ingresaste un token válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivos de datos (*.dat)|*.dat|Todos los archivos (*.*)|*.*";
                saveFileDialog.Title = "Guardar Token Mercado Pago";
                saveFileDialog.FileName = "token.dat";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] encryptedData = ProtectedData.Protect(
                            Encoding.UTF8.GetBytes(token_mercado_pago),
                            null,
                            DataProtectionScope.CurrentUser
                        );

                        File.WriteAllBytes(saveFileDialog.FileName, encryptedData);
                        MessageBox.Show("Token guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el token: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            /*
             * Deencriptar
             byte[] encryptedData = File.ReadAllBytes(path);
string token = Encoding.UTF8.GetString(ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser));
             */
        }
        private string PromptMercadoPago()
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Ingresar Token de Mercado Pago",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblText = new Label() { Left = 20, Top = 20, Text = "Token:" };
            TextBox txtPassword = new TextBox() { Left = 20, Top = 50, Width = 200, UseSystemPasswordChar = false };
            Button btnOk = new Button() { Text = "Aceptar", Left = 150, Width = 70, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(txtPassword);
            prompt.Controls.Add(btnOk);
            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == DialogResult.OK ? txtPassword.Text : "";
        }
    }

}
