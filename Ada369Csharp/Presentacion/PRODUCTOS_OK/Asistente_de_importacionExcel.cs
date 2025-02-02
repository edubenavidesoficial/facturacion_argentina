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
namespace Ada369Csharp.Presentacion.PRODUCTOS_OK
{
    public partial class Asistente_de_importacionExcel : Form
    {
        public Asistente_de_importacionExcel()
        {
            InitializeComponent();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void TSIGUIENTE_Y_GUARDAR__Click(object sender, EventArgs e)
        {
            PanelDescarga_de_archivo.Visible = false;
            PanelCargarArchivo.Visible = true;
            B1.Enabled = false;
            B2.Enabled = true;
            B3.Enabled = false;
            Paso1.Visible = false;
            Paso2.Visible = true;
            Paso3.Visible = false;




        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            
        }
        private void archivo_correcto()
        {
            PanelCargarArchivo.BackColor = Color.White;
            lblarchivoCargado.Visible = true;
           label3.Visible = false;
            MenuStrip1.Visible = true;
            Pcsv.Visible = true;
            LinkLabel3.LinkColor  = Color.Black;
            lblnombre_Del_archivo.ForeColor = Color.FromArgb(64, 64, 64);
            PanelCargarArchivo.BackgroundImage = null;
 
        }

        private void LinkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog myFileDialog = new OpenFileDialog();
            myFileDialog.InitialDirectory = @"c:\\temp\";
            myFileDialog.Filter = "CSV files|*.csv;*.CSV)";
            myFileDialog.FilterIndex = 2;
            myFileDialog.RestoreDirectory = true;
            myFileDialog.Title = "Elija el Archivo .CSV";
            if (myFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblnombre_Del_archivo.Text = myFileDialog.SafeFileName.ToString();
                lblArchivoListo.Text = lblnombre_Del_archivo.Text;
                lblRuta.Text = myFileDialog.FileName.ToString();
                archivo_correcto();
            }
        }

        private void PanelCargarArchivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop ))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void PanelCargarArchivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach ( string path in files )
            {
                lblRuta.Text = path;
                string ruta = lblRuta.Text;
                if (ruta.Contains(".csv"))
                {
                    archivo_correcto();
                    lblnombre_Del_archivo.Text = Path.GetFileName(ruta);
                    lblArchivoListo.Text = lblnombre_Del_archivo.Text;
                }
                else
                {
                    MessageBox.Show("Archivo Incorrecto", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void Asistente_de_importacionExcel_Load(object sender, EventArgs e)
        {
            B1.Enabled = true;
            B2.Enabled = false;
            B3.Enabled = false;
            Paso1.Visible = true;
            Paso2.Visible = false;
            Paso3.Visible = false;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelCargarArchivo.Visible = false;
            PanelGuardarData.Visible = true;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = true;
            Paso1.Visible = false;
            Paso2.Visible = false;
            Paso3.Visible = true;
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            guardar_datos_Precargados();
        }
        private void guardar_datos_Precargados()
        {
            string Textlines = "";
            string[] Splitline;
            if (System.IO.File.Exists(lblRuta.Text) == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(lblRuta.Text);
                while (objReader.Peek() != -1)
                {
                    Textlines = objReader.ReadLine();
                    Splitline = Textlines.Split(';');
                    datalistado.ColumnCount = Splitline.Length;
                    datalistado.Rows.Add(Splitline);

                }
            }
            else
            {
                MessageBox.Show("Archivo Inexistente", "CSV Inexistente");
            }

            try
            {
              foreach (DataGridViewRow row in datalistado.Rows )
                {
                    rellenar_vacios();
                    string CODIGO = Convert.ToString(row.Cells["Codigo"].Value);
                    string descripcion = Convert.ToString(row.Cells["Descripcion"].Value);
                    SqlCommand cmd;
                    CONEXION.CONEXIONMAESTRA.conectar.Open ();
                    cmd = new SqlCommand("insertar_Producto_Importacion", CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Imagen", ".");
                    cmd.Parameters.AddWithValue("@Usa_inventarios", "SI");
                    cmd.Parameters.AddWithValue("@Stock", 0);
                    cmd.Parameters.AddWithValue("@Precio_de_compra", 0);
                    cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Precio_de_venta", 0);
                    cmd.Parameters.AddWithValue("@Codigo", CODIGO);

                    cmd.Parameters.AddWithValue("@Se_vende_a", "Unidad");
                    cmd.Parameters.AddWithValue("@Impuesto", 0);
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Precio_mayoreo", 0);
                    cmd.Parameters.AddWithValue("@A_partir_de", 0);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto");
                    cmd.Parameters.AddWithValue("@Cantidad", 0);
                    cmd.Parameters.AddWithValue("@Id_usuario", Productos_ok.idusuario);
                    cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                    cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                    cmd.Parameters.AddWithValue("@Id_caja", Productos_ok.idcaja);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.conectar.Close ();


                }
                MessageBox.Show("Importacion Exitosa", "Importacion de Datos");
                Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
        }
        private void rellenar_vacios()
        {
            foreach (DataGridViewRow row in datalistado.Rows )
            {
                if (row.Cells ["Descripcion"].Value.ToString ()=="")
                {
                    row.Cells["Descripcion"].Value = "VACIO@";
                }
                if (row.Cells ["Codigo"].Value.ToString ()=="")
                {
                    row.Cells["Codigo"].Value = "VACIO@";
                }
            }
        }

    }
}
