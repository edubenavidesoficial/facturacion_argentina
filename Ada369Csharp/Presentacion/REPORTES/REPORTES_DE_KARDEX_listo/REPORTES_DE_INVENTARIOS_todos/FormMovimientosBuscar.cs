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
namespace Ada369Csharp.Presentacion.REPORTES.REPORTES_DE_KARDEX_listo.REPORTES_DE_INVENTARIOS_todos
{
    public partial class FormMovimientosBuscar : Form
    {
        public FormMovimientosBuscar()
        {
            InitializeComponent();
        }

        private void FormMovimientosBuscar_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        ReportMovimientosBuscar rptFREPORT2 = new ReportMovimientosBuscar();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU.idProducto );
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new ReportMovimientosBuscar();
                rptFREPORT2.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport ();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
    }
}
