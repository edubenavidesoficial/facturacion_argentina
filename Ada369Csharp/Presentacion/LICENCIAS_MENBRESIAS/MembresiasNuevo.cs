using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ada369Csharp.Logica;
using System.IO;
using System.Xml;
using Ada369Csharp.CONEXION;
using System.Security.Cryptography;
using Ada369Csharp.Datos;
namespace Ada369Csharp.Presentacion.LICENCIAS_MENBRESIAS
{
    public partial class MembresiasNuevo : Form
    {
        public MembresiasNuevo()
        {
            InitializeComponent();
        }
        string serialPc;
        string ruta;
        string dbcnString;
        string LicenciaDescifrada;
        private AES aes = new AES();
        string SerialPcLicencia;
        string FechaFinLicencia;
        string EstadoLicencia;
        string NombreSoftwareLicencia;
        string Resultado;
        private void btncomprar_Click(object sender, EventArgs e)
        {
            Process.Start("https://codigo369.com/");
        }

        private void MembresiasNuevo_Load(object sender, EventArgs e)
        {
            obtenerSerialPc();
          

        }
        private void obtenerSerialPc()
        {
            Bases.Obtener_serialPC(ref serialPc);     
            txtSerial.Text = serialPc;

        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSerial.Text);
        }

        private void btnActivacioManual_Click(object sender, EventArgs e)
        {
            dlg.Filter = "Licencias Ada369|*.xml";
            dlg.Title = "Cargador de Licencias ada369";
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                ruta = Path.GetFullPath(dlg.FileName);
                DescifrarLicencia();
                string cadena = LicenciaDescifrada;
                string[] separadas = cadena.Split('|');
                SerialPcLicencia = separadas[1];
                FechaFinLicencia = separadas[2];
                EstadoLicencia = separadas[3];
                NombreSoftwareLicencia = separadas[4];
                if (NombreSoftwareLicencia =="Ada_369")
                {
                    if (EstadoLicencia=="PENDIENTE")
                    {
                        if(SerialPcLicencia == serialPc)
                        {
                            activarLicenciaManual();
                        }
                    }
                }

            }
        }
        private void activarLicenciaManual()
        {
            Bases.Obtener_serialPC(ref serialPc);
            string fechaFin = Bases.Encriptar(FechaFinLicencia);
            string estado = Bases.Encriptar("?ACTIVADO PRO?");
            string  fechaActivacion = Bases.Encriptar(FechaInicio.Text);
            LMarcan parametros = new LMarcan();
            Editar_datos funcion = new Editar_datos();
            parametros.E = estado;
            parametros.FA = fechaActivacion;
            parametros.F = fechaFin;
            parametros.S = txtSerial.Text ;
          

            if (funcion.editarMarcan(parametros)==true)
            {
                MessageBox.Show("Licencia activada, se cerrara el sistema para un nuevo Inicio");
                Application.Exit();
            }
        }
        private void DescifrarLicencia()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ruta);
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes.Item(0).Value;
                LicenciaDescifrada = (aes.Decrypt(dbcnString, Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (CryptographicException ex)
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
