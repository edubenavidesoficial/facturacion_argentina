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
using System.Management;
using Ada369Csharp.Logica;
using Ada369Csharp.Datos;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Ada369Csharp.Presentacion.Admin_nivel_dios
{
    public partial class DASHBOARD_PRINCIPAL : Form
    {
        public DASHBOARD_PRINCIPAL()
        {
            InitializeComponent();
        }
        int contadorCajas;
        int contador_Movimientos_de_caja;
        string lblApertura_De_caja;
        string lblIDSERIAL;
        int idcajavariable;
        int idusuariovariable;
        string Base_De_datos = "BASEADACURSO";
        string Servidor = @".\SQLEXPRESS";
        string ruta;
        string ResultadoLicencia;
        string FechaFinal;
        double PorCobrar;
        double PorPagar;
        double GananciasGenerales;
        int ProductoMinimo;
        int CantClientes;
        int CantProductos;
        string moneda;
        DataTable dtventas;
        double totalVentas;
        double gananciasFecha;
        DataTable dtProductos;
        int año;
        private void DASHBOARD_PRINCIPAL_Load(object sender, EventArgs e)
        {
            validarLicencia();
            Bases.Obtener_serialPC(ref lblIDSERIAL);
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcajavariable);
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuariovariable);
            mostrarMoneda();
            ReportePorCobrar();
            ReportePorPagar();
           
            ReporteProductoBajoMinimo();
            ReporteCantClientes();
            ReporteCantProductos();
            mostrarVentasGrafica();
            chekFiltros.Checked = false;
            mostrarPmasVendidos();
            ReporteGastosAnioCombo();
            ObtenerMesAñoActual();
        }
        private void ObtenerMesAñoActual()

        {
            int año = DateTime.Today.Year;
            DateTime fechaactual = DateTime.Now;
            string mes = fechaactual.ToString("MMMM") + " " + año.ToString();
            lblfechaHoy.Text = mes;
        }
        private void ReporteGastosMesCombo()
        {

            DataTable dt = new DataTable();
            año = Convert.ToInt32 ( txtaño_gasto.Text);
            Obtener_datos.ReporteGastosMesCombo(ref dt, año);
            txtmes_gasto.DisplayMember = "mes";
            txtmes_gasto.ValueMember = "mes";
            txtmes_gasto.DataSource = dt;
        }
        private void ReporteGastosAnioCombo()
        {
            DataTable dt = new DataTable();
            Obtener_datos.ReporteGastosAnioCombo(ref dt);
            txtaño_gasto.DisplayMember = "anio";
            txtaño_gasto.ValueMember = "anio";
            txtaño_gasto.DataSource = dt;
        }
        private void mostrarPmasVendidos()
        {
            ArrayList cantidad = new ArrayList();
            ArrayList producto = new ArrayList();
            dtProductos = new DataTable();
            Obtener_datos.mostrarPmasVendidos(ref dtProductos);
            foreach (DataRow filas in dtProductos.Rows )
            {
                cantidad.Add(filas["Cantidad"]);
                producto.Add(filas["Descripcion"]);
            }
            chartProductos.Series[0].Points.DataBindXY(producto, cantidad);
        }
        private void ReporteGananciasFecha()
        {
            Obtener_datos.ReporteGananciasFecha(ref gananciasFecha, TXTFI.Value, TXTFF.Value);
            lblgananciasok.Text = moneda + " " + gananciasFecha.ToString();
        }
        private void ReporteTotalVentasFechas()
        {
            Obtener_datos.ReporteTotalVentasFechas(ref totalVentas, TXTFI.Value, TXTFF.Value);
            txtventas.Text = moneda + " " + totalVentas.ToString();
        }

        private void ReporteTotalVentas()
        {
            Obtener_datos.ReporteTotalVentas(ref totalVentas);
            txtventas.Text = moneda + " " + totalVentas.ToString();
        }
        private void mostrarVentasGrafica()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtventas = new DataTable();
            Obtener_datos.mostrarVentasGrafica(ref dtventas);
            foreach (DataRow filas in dtventas.Rows)
            {
                fecha.Add(filas["fecha"]);
                monto.Add(filas["Total"]);
            }
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            ReporteTotalVentas();
            ReporteGanancias();
        }
        private void mostrarVentasGraficaFechas()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtventas = new DataTable();
            Obtener_datos.mostrarVentasGraficaFechas(ref dtventas, TXTFI.Value ,TXTFF.Value );
            foreach (DataRow filas in dtventas.Rows)
            {
                fecha.Add(filas["fecha"]);
                monto.Add(filas["Total"]);
            }
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            ReporteTotalVentasFechas();
            ReporteGananciasFecha();
        }
        private void mostrarMoneda()
        {
            Obtener_datos.MostrarMoneda(ref moneda);
        }
        private void ReporteCantProductos()
        {
            Obtener_datos.ReporteCantProductos(ref CantProductos);
            lblProductos.Text = CantProductos.ToString ();
        }
        private void ReporteCantClientes()
        {
            Obtener_datos.ReporteCantClientes(ref CantClientes);
            lblNclientes.Text = CantClientes.ToString();
        }
        private void ReporteProductoBajoMinimo()
        {
            Obtener_datos.ReporteProductoBajoMinimo(ref ProductoMinimo);
            lblStockBajo.Text = ProductoMinimo.ToString();
        }
        private void ReporteGanancias()
        {
            Obtener_datos.ReporteGanancias(ref GananciasGenerales);
            lblGanancias.Text = moneda + " " + GananciasGenerales.ToString ();
            lblgananciasok.Text = lblGanancias.Text;
        }

        private void ReportePorCobrar()
        {       
            Obtener_datos.ReportePorCobrar(ref PorCobrar);
            lblPorcobrar.Text = moneda +" " +  PorCobrar.ToString();
        }
        private void ReportePorPagar()
        {
            Obtener_datos.ReportePorPagar (ref PorPagar);
            lblPorPagar.Text = moneda + " " + PorPagar.ToString();
        }
        private void validarLicencia()
        {
            DLicencias funcion = new DLicencias();
            funcion.ValidarLicencias(ref ResultadoLicencia, ref FechaFinal);
            if (ResultadoLicencia == "?ACTIVO?")
            {
                lblestadoLicencia.Text = "Licencia de Prueba Activada hasta el: " + FechaFinal;
                btnLicencia.Visible = true;
            }
            if (ResultadoLicencia == "?ACTIVADO PRO?")
            {
                lblestadoLicencia.Text = "Licencia PROFESIONAL Activada hasta el: " + FechaFinal;
                btnLicencia.Visible = false;
            }
            if (ResultadoLicencia == "VENCIDA")

            {
                funcion.EditarMarcanVencidas();
                Dispose();
                LICENCIAS_MENBRESIAS.MembresiasNuevo frm = new LICENCIAS_MENBRESIAS.MembresiasNuevo();
                frm.ShowDialog();

            }



        }



        private void button3_Click(object sender, EventArgs e)
        {
            Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU frm = new Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU();
            frm.ShowDialog();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            CONFIGURACION.PANEL_CONFIGURACIONES frm = new CONFIGURACION.PANEL_CONFIGURACIONES();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            Dispose();
            frm.ShowDialog();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
            frm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Dispose();
            CONFIGURACION.PANEL_CONFIGURACIONES frm = new CONFIGURACION.PANEL_CONFIGURACIONES();
            frm.ShowDialog();
        }

        private void btnvender_Click(object sender, EventArgs e)
        {
            validar_aperturas_de_caja();
        }
        private void Listarcierres_de_caja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_cierres_de_caja()
        {
            int x;

            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

        }
        private void aperturar_detalle_de_cierre_caja()
        {
            try
            {


            
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini", DateTime.Now);
                cmd.Parameters.AddWithValue("@fechafin", DateTime.Now);
                //cmd.Parameters.AddWithValue("@fecha", DateTime.Today);

                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Now);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@idusuario", idusuariovariable);
                cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
                cmd.Parameters.AddWithValue("@totalreal", "0.00");

                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");
                cmd.Parameters.AddWithValue("@id_caja", idcajavariable);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void mostrar_movimientos_de_caja_por_serial_y_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL );
                da.SelectCommand.Parameters.AddWithValue("@idusuario", idusuariovariable);
                da.Fill(dt);
                datalistado_movimientos_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_movimientos_de_caja_por_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contador_Movimientos_de_caja = (x);

        }
        private void obtener_usuario_que_aperturo_caja()
        {
            try
            {
                lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
            }
            catch
            {

            }
        }
        private void validar_aperturas_de_caja()
        {
            Listarcierres_de_caja();
            contar_cierres_de_caja();
            if (contadorCajas == 0)
            {
                aperturar_detalle_de_cierre_caja();
                lblApertura_De_caja = "Nuevo*****";
                Ingresar_a_ventas();

            }
            else
            {
                mostrar_movimientos_de_caja_por_serial_y_usuario();
                contar_movimientos_de_caja_por_usuario();

                if (contador_Movimientos_de_caja == 0)
                {
                    obtener_usuario_que_aperturo_caja();
                    MessageBox.Show("Continuaras Turno de *" + lblnombredeCajero.Text + " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }        
                    lblApertura_De_caja = "Aperturado";
                    Ingresar_a_ventas();

                
            }
        }
        private void Ingresar_a_ventas()
        {
            if (lblApertura_De_caja == "Nuevo*****")
            {             
                Dispose();
                CAJA.APERTURA_DE_CAJA frmCaja = new CAJA.APERTURA_DE_CAJA();
                frmCaja.ShowDialog();

            }
            else if (lblApertura_De_caja == "Aperturado")
            {
          
                Dispose();
                VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frmVentas = new VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
                frmVentas.ShowDialog();

            }
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CopiasBd.CrearCopiaBd frm = new CopiasBd.CrearCopiaBd();
            frm.ShowDialog();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            RestaurarBdExpress();
        }
        private void RestaurarBdExpress()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Backup " + Base_De_datos + "|*.bak";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Backup";
            if (dlg.ShowDialog()==DialogResult.OK )
            {
                ruta = Path.GetFullPath(dlg.FileName);
                DialogResult  pregunta = MessageBox.Show("Usted está a punto de restaurar la base de datos,"  + "asegurese de que el archivo .bak sea reciente, de"  + "lo contrario podría perder información y no podrá"  + "recuperarla, ¿desea continuar?", "Restauración de base de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (pregunta== DialogResult.Yes)
                {
                    SqlConnection cnn = new SqlConnection("Server=" + Servidor + ";database=master; integrated security=yes");
                    try
                    {
                        cnn.Open();
                        string Proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + Base_De_datos + "' USE [master] ALTER DATABASE [" + Base_De_datos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + Base_De_datos + "] RESTORE DATABASE " + Base_De_datos + " FROM DISK = N'" + ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
                        SqlCommand BorraRestaura = new SqlCommand(Proceso, cnn);
                        BorraRestaura.ExecuteNonQuery();
                        MessageBox.Show("La base de datos ha sido restaurada satisfactoriamente! Vuelve a Iniciar El Aplicativo", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();


                    }
                    catch (Exception)
                    {
                        RestaurarNoExpress();
                    }
                    finally
                    {
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }

                    }


                }
            }
        }
        private void RestaurarNoExpress()
        {
                    Servidor = ".";
                    SqlConnection cnn = new SqlConnection("Server=" + Servidor + ";database=master; integrated security=yes");
                    try
                    {
                        cnn.Open();
                        string Proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + Base_De_datos + "' USE [master] ALTER DATABASE [" + Base_De_datos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + Base_De_datos + "] RESTORE DATABASE " + Base_De_datos + " FROM DISK = N'" + ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
                        SqlCommand BorraRestaura = new SqlCommand(Proceso, cnn);
                        BorraRestaura.ExecuteNonQuery();
                        MessageBox.Show("La base de datos ha sido restaurada satisfactoriamente! Vuelve a Iniciar El Aplicativo", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();


                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        if (cnn.State == ConnectionState.Open)
                        {
                            cnn.Close();
                        }

                    }                  
        }

        private void btnLicencia_Click(object sender, EventArgs e)
        {
            LICENCIAS_MENBRESIAS.MembresiasNuevo frm = new LICENCIAS_MENBRESIAS.MembresiasNuevo();
            frm.ShowDialog();
        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void chekFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (chekFiltros.Checked ==true)
            {
                PanelHoy.Visible = false;
                PanelFiltros.Visible = true;
                mostrarVentasGraficaFechas();
            }
            else
            {
                PanelHoy.Visible = true;
                PanelFiltros.Visible = false;
                mostrarVentasGrafica();
            }
        }

        private void TXTFI_ValueChanged(object sender, EventArgs e)
        {
            mostrarVentasGraficaFechas();
        }

        private void TXTFF_ValueChanged(object sender, EventArgs e)
        {
            mostrarVentasGraficaFechas();
        }

        private void lblhastaHoy_Click(object sender, EventArgs e)
        {
            mostrarVentasGrafica();
          
        }

        private void txtaño_gasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReporteGastosAnio();
            ReporteGastosMesCombo();
        }
        private void ReporteGastosAnio()
        {
            DataTable dt = new DataTable();
            año =Convert.ToInt32 (txtaño_gasto.Text);
            Obtener_datos.ReporteGastosAnio(ref dt, año);
            ArrayList monto = new ArrayList();
            ArrayList descripcion = new ArrayList();
            foreach (DataRow filas in dt.Rows )
            {
                monto.Add(filas["Monto"]);
                descripcion.Add(filas["Descripcion"]);
            }
            chartGastosAño.Series[0].Points.DataBindXY(descripcion, monto);
        }
        private void ReporteGastosAnioMesGrafica()
        {
            DataTable dt = new DataTable();
            año = Convert.ToInt32(txtaño_gasto.Text);
            Obtener_datos.ReporteGastosAnioMesGrafica(ref dt, año, txtmes_gasto.Text);
            ArrayList monto = new ArrayList();
            ArrayList descripcion = new ArrayList();
            foreach (DataRow filas in dt.Rows)
            {
                monto.Add(filas["Monto"]);
                descripcion.Add(filas["Descripcion"]);
            }
            chartGastosMes.Series[0].Points.DataBindXY(descripcion, monto);
        }

        private void txtmes_gasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReporteGastosAnioMesGrafica();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            REPORTES.MenuReportes frm = new REPORTES.MenuReportes() ;
            frm.ShowDialog();
        }

        private void btncomprar_Click(object sender, EventArgs e)
        {
            var frm = new Compras.Admincompras();
            frm.ShowDialog();
        }
    }  
    
}
