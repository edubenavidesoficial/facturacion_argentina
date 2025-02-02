using System;

using System.Data;

using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ada369Csharp.Presentacion.REPORTES.REPORTES_DE_KARDEX_listo.REPORTES_DE_INVENTARIOS_todos
{
    public partial class FormInventariosTodos : Form
    {
        public FormInventariosTodos()
        {
            InitializeComponent();
        }
        ReportInventarios_Todos rptFREPORT2=new ReportInventarios_Todos();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("imprimir_inventarios_todos", con);
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new ReportInventarios_Todos();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void FormInventariosTodos_Load(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
