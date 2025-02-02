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
using Ada369Csharp.Logica;
namespace Ada369Csharp.Presentacion.SERIALIZACION_DE_COMPROBANTES
{
    public partial class SERIALIZACION : Form
    {

        public SERIALIZACION()
        {
            InitializeComponent();
        }
        string valor_por_defecto;
        int idserie;
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            GUARDAR.Visible = true;
            GUARDARCAMBIOS.Visible = false;
            TXTCOMPRO.Clear();
            TXTCANTIDADDECEROS.Clear();
            txtnumerofin.Clear();
            txtSerie.Clear();
            checkDefecto.Checked = false;
            checkDefecto.Visible = false;
        }

        private void SERIALIZACION_Load(object sender, EventArgs e)
        {
            Listar();
            panel3.Visible = false;

        }

        private void GUARDAR_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@numeroinicio", TXTCANTIDADDECEROS.Text);
                cmd.Parameters.AddWithValue("@numerofin", txtnumerofin.Text);
                cmd.Parameters.AddWithValue("@Destino", "OTROS");
                cmd.Parameters.AddWithValue("@tipodoc", TXTCOMPRO.Text);
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();
                Listar();
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
           
        }
        private void Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_Tipo_de_documentos_para_insertar_estos_mismos", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[2].Visible = false;
                datalistado.Columns[3].Visible = false;
                datalistado.Columns[4].Visible = false;
                datalistado.Columns[5].Width = 220;
                datalistado.Columns[6].Width  = 520;
                Bases.Multilinea(ref datalistado);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void GUARDARCAMBIOS_Click(object sender, EventArgs e)
        {
            ELEJIR_POR_DEFECTO();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie", txtSerie.Text);
                cmd.Parameters.AddWithValue("@Cantidad_de_numeros", TXTCANTIDADDECEROS.Text);
                cmd.Parameters.AddWithValue("@numerofin", txtnumerofin.Text);
                cmd.Parameters.AddWithValue("@Tipo", TXTCOMPRO.Text);
                cmd.Parameters.AddWithValue("@Id_serie",idserie );
                cmd.ExecuteNonQuery();
                con.Close();
                Listar();
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void ELEJIR_POR_DEFECTO()
        {
            if (checkDefecto .Checked ==true )
            {
              try
            {
                idserie = Convert.ToInt32(datalistado.SelectedCells[4].Value.ToString());
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_serializacion_POR_DEFECTO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_serie", idserie);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            }
           

        }

        private void MenuStrip5_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void datalistado_DoubleClick(object sender, EventArgs e)
        {
            panel3.Visible = true;
            try
            {
                TXTCOMPRO.Text = datalistado.SelectedCells[6].Value.ToString();
                TXTCANTIDADDECEROS.Text = datalistado.SelectedCells[2].Value.ToString();
                txtnumerofin.Text = datalistado.SelectedCells[3].Value.ToString();
                txtSerie.Text = datalistado.SelectedCells[1].Value.ToString();
                GUARDAR.Visible = false;
                GUARDARCAMBIOS.Visible = true;
                valor_por_defecto = datalistado.SelectedCells[7].Value.ToString();
                if (valor_por_defecto == "SI")
                {
                    checkDefecto.Visible = false;
                    checkDefecto.Checked = true;
                }
                else
                {
                    checkDefecto.Visible = true;
                    checkDefecto.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿Realmente desea eliminar los registros seleccionados?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {

                foreach (DataGridViewRow row in datalistado.SelectedRows)
                {
                    int onekey = Convert.ToInt32(row.Cells["Id_serializacion"].Value);
                    try
                    {

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;

                        con.Open();
                        SqlCommand cmd;
                        cmd = new SqlCommand("eliminar_Serializacion", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", onekey);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            Listar();
        }

        private void VOLVEROK_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
