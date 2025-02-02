using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;
using Ada369Csharp.Logica;
using Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL;
using Ada369Csharp.Datos;
using System.Security.Cryptography.X509Certificates;
using Ada369Csharp.Presentacion.Admin_nivel_dios;
using System.IO.Ports;
using System.Drawing.Imaging;

namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class VENTAS_MENU_PRINCIPALOK : Form
    {
        public VENTAS_MENU_PRINCIPALOK()
        {
            InitializeComponent();
        }

        int contador_stock_detalle_de_venta;
        int idproducto;
        int idClienteEstandar;
        public static int idusuario_que_inicio_sesion;
        public static int idVenta;
        int iddetalleventa;
        int Contador;
        public static double txtpantalla;
        double lblStock_de_Productos;
        public static double total;
        public static int Id_caja;
        string SerialPC;
        string sevendePor;
        public static string txtventagenerada;
        double txtprecio_unitario;
        string usainventarios;
        string ResultadoLicencia;
        string FechaFinal;
        double cantidad;
        string Tema;
        int contadorVentasEspera;
        string Ip;
        bool EstadoCobrar = false;
        public static   bool EstadoMediosPago = false;
        Panel panel_mostrador_de_productos = new Panel();

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void VENTAS_MENU_PRINCIPALOK_Load(object sender, EventArgs e)
        {
            validarLicencia();
            Bases.Cambiar_idioma_regional();
            Bases.Obtener_serialPC(ref SerialPC);
            Obtener_datos.Obtener_id_caja_PorSerial(ref Id_caja);

            Obtener_id_de_cliente_estandar();
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario_que_inicio_sesion);

            ValidarTiposBusqueda();
            ValidarTemaCaja();
            Limpiar_para_venta_nueva();
            ObtenerIpLocal();


        }
        private void ValidarTiposBusqueda()
        {
            MOSTRAR_TIPO_DE_BUSQUEDA();
            if (Tipo_de_busqueda == "TECLADO")
            {
                lbltipodebusqueda2.Text = "Buscar con TECLADO";
                BTNLECTORA.BackColor = Color.WhiteSmoke;
                BTNTECLADO.BackColor = Color.LightGreen;
                txtbuscar.Clear();
                txtbuscar.Focus();
            }
            else
            {
                lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
                BTNLECTORA.BackColor = Color.LightGreen;
                BTNTECLADO.BackColor = Color.WhiteSmoke;
                txtbuscar.Focus();
                txtbuscar.Clear();

            }
        }
        private void ObtenerIpLocal()
        {

            this.Text = Bases.ObtenerIp(ref Ip);
        }
        private void ContarVentasEspera()
        {
            Obtener_datos.contarVentasEspera(ref contadorVentasEspera);
            if (contadorVentasEspera == 0)
            {
                panelNotificacionEspera.Visible = false;
            }
            else
            {
                panelNotificacionEspera.Visible = true;
                lblContadorEspera.Text = contadorVentasEspera.ToString();
            }
        }
        private void ValidarTemaCaja()
        {
            Obtener_datos.mostrarTemaCaja(ref Tema);
            if (Tema == "Redentor")
            {
                TemaClaro();
                IndicadorTema.Checked = false;
            }
            else
            {
                TemaOscuro();
                IndicadorTema.Checked = true;

            }
        }
        private void validarLicencia()
        {
            DLicencias funcion = new DLicencias();
            funcion.ValidarLicencias(ref ResultadoLicencia, ref FechaFinal);
            if (ResultadoLicencia == "VENCIDA")
            {
                funcion.EditarMarcanVencidas();
                Dispose();
                LICENCIAS_MENBRESIAS.MembresiasNuevo frm = new LICENCIAS_MENBRESIAS.MembresiasNuevo();
                frm.ShowDialog();
            }



        }
        private void Limpiar_para_venta_nueva()
        {
            idVenta = 0;
            Listarproductosagregados();
            txtventagenerada = "VENTA NUEVA";
            sumar();
            PanelEnespera.Visible = false;
            panelBienvenida.Visible = true;
            PanelOperaciones.Visible = false;
            ContarVentasEspera();
            EstadoMediosPago = false;
        }


        private void sumar()
        {
            try
            {

                int x;
                x = dgDetalleventa.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in dgDetalleventa.Rows)
                {

                    totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                    txt_total_suma.Text = Convert.ToString(totalpagar);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void LISTAR_PRODUCTOS_Abuscador()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                CONEXION.CONEXIONMAESTRA.abrir();
                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_oka", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscar.Text);
                da.Fill(dt);
                dgProductos.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.cerrar();
                dgProductos.Columns[0].Visible = false;
                dgProductos.Columns[1].Visible = false;
                dgProductos.Columns[2].Width = 600;
                dgProductos.Columns[3].Visible = false;
                dgProductos.Columns[4].Visible = false;
                dgProductos.Columns[5].Visible = false;
                dgProductos.Columns[6].Visible = false;
                dgProductos.Columns[7].Visible = false;
                dgProductos.Columns[8].Visible = false;
                dgProductos.Columns[9].Visible = false;
                dgProductos.Columns[10].Visible = false;
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }



        string Tipo_de_busqueda;
        private void MOSTRAR_TIPO_DE_BUSQUEDA()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("Select Modo_de_busqueda  from EMPRESA", con);

            try
            {
                con.Open();
                Tipo_de_busqueda = Convert.ToString(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.StackTrace);
            }
        }


        private void btnTecladoVirtual_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {

        }



        private void MenuStrip9_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (Tipo_de_busqueda == "LECTORA")
            {
                ValidarVentasNuevas();
                lbltipodebusqueda2.Visible = false;
                TimerBUSCADORcodigodebarras.Start();
            }
            else if (Tipo_de_busqueda == "TECLADO")
            {
                if (txtbuscar.Text == "")
                {
                    ocultar_mostrar_productos();
                }
                else if (txtbuscar.Text != "")
                {
                    mostrar_productos();
                }
                LISTAR_PRODUCTOS_Abuscador();

            }

        }
        private void mostrar_productos()
        {
            panel_mostrador_de_productos.Size = new System.Drawing.Size(600, 186);
            panel_mostrador_de_productos.BackColor = Color.White;
            panel_mostrador_de_productos.Location = new Point(panelReferenciaProductos.Location.X, panelReferenciaProductos.Location.Y);
            panel_mostrador_de_productos.Visible = true;
            dgProductos.Visible = true;
            dgProductos.Dock = DockStyle.Fill;
            dgProductos.BackgroundColor = Color.White;
            lbltipodebusqueda2.Visible = false;
            panel_mostrador_de_productos.Controls.Add(dgProductos);

            this.Controls.Add(panel_mostrador_de_productos);
            panel_mostrador_de_productos.BringToFront();
        }
        private void ocultar_mostrar_productos()
        {
            panel_mostrador_de_productos.Visible = false;
            dgProductos.Visible = false;
            lbltipodebusqueda2.Visible = true;
        }
        private void DATALISTADO_PRODUCTOS_OKA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            vender_por_teclado();

        }
        public void ValidarVentasNuevas()
        {
            if (dgDetalleventa.RowCount == 0)
            {
                Limpiar_para_venta_nueva();
            }
        }
        private void vender_por_teclado()
        {
            //Validamos las ventas nuevas
            ValidarVentasNuevas();
            txtbuscar.Text = dgProductos.SelectedCells[10].Value.ToString();
            idproducto = Convert.ToInt32(dgProductos.SelectedCells[1].Value.ToString());
            // mostramos los registros del producto en el detalle de venta
            mostrar_stock_de_detalle_de_ventas();
            contar_stock_detalle_ventas();

            if (contador_stock_detalle_de_venta == 0)
            {
                // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
                lblStock_de_Productos = Convert.ToDouble(dgProductos.SelectedCells[4].Value.ToString());
            }
            else
            {
                //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
                lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
            }
            //Extraemos los datos del producto de la tabla Productos directamente
            usainventarios = dgProductos.SelectedCells[3].Value.ToString();
            lbldescripcion.Text = dgProductos.SelectedCells[9].Value.ToString();
            lblcodigo.Text = dgProductos.SelectedCells[10].Value.ToString();
            lblcosto.Text = dgProductos.SelectedCells[5].Value.ToString();
            sevendePor = dgProductos.SelectedCells[8].Value.ToString();
            txtprecio_unitario = Convert.ToDouble(dgProductos.SelectedCells[6].Value.ToString());
            //Preguntamos que tipo de producto sera el que se agrege al detalle de venta
            if (sevendePor == "Granel")
            {
                vender_a_granel();
            }
            else if (sevendePor == "Unidad")
            {
                txtpantalla = 1;
                vender_por_unidad();
            }

        }
        private void vender_a_granel()
        {

            CANTIDAD_A_GRANEL frm = new CANTIDAD_A_GRANEL();
            frm.preciounitario = txtprecio_unitario;
            frm.FormClosing += Frm_FormClosing;
            frm.ShowDialog();


        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ejecutar_ventas_a_granel();
        }

        public void ejecutar_ventas_a_granel()
        {

            ejecutar_insertar_ventas();
            if (txtventagenerada == "VENTA GENERADA")
            {
                insertar_detalle_venta();
                Listarproductosagregados();
                txtbuscar.Text = "";
                txtbuscar.Focus();

            }

        }
        private void Obtener_id_de_cliente_estandar()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("select idclientev  from clientes where Estado=0", con);
            try
            {
                con.Open();
                idClienteEstandar = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void Obtener_id_venta_recien_Creada()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("mostrar_id_venta_por_Id_caja", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id_caja", Id_caja);
            try
            {
                con.Open();
                idVenta = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mostrar_id_venta_por_Id_caja");
            }
        }
        private void vender_por_unidad()
        {
            try
            {
                if (txtbuscar.Text == dgProductos.SelectedCells[10].Value.ToString())
                {
                    dgProductos.Visible = true;
                    ejecutar_insertar_ventas();
                    if (txtventagenerada == "VENTA GENERADA")
                    {
                        insertar_detalle_venta();
                        Listarproductosagregados();
                        txtbuscar.Text = "";
                        txtbuscar.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void ejecutar_insertar_ventas()
        {
            if (txtventagenerada == "VENTA NUEVA")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_venta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", idClienteEstandar);
                    cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Today);
                    cmd.Parameters.AddWithValue("@nume_documento", 0);
                    cmd.Parameters.AddWithValue("@montototal", 0);
                    cmd.Parameters.AddWithValue("@Tipo_de_pago", 0);
                    cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                    cmd.Parameters.AddWithValue("@IGV", 0);
                    cmd.Parameters.AddWithValue("@Comprobante", 0);
                    cmd.Parameters.AddWithValue("@id_usuario", idusuario_que_inicio_sesion);
                    cmd.Parameters.AddWithValue("@Fecha_de_pago", DateTime.Today);
                    cmd.Parameters.AddWithValue("@ACCION", "VENTA");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.Parameters.AddWithValue("@Pago_con", 0);
                    cmd.Parameters.AddWithValue("@Porcentaje_IGV", 0);
                    cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
                    cmd.Parameters.AddWithValue("@Referencia_tarjeta", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Obtener_id_venta_recien_Creada();
                    txtventagenerada = "VENTA GENERADA";
                    mostrar_panel_de_Cobro();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("insertar_venta");
                }

            }
        }
        private void mostrar_panel_de_Cobro()
        {
            panelBienvenida.Visible = false;
            PanelOperaciones.Visible = true;
        }
        private void Listarproductosagregados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_productos_agregados_a_venta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idventa", idVenta);
                da.Fill(dt);
                dgDetalleventa.DataSource = dt;
                con.Close();
                dgDetalleventa.Columns[0].Width = 50;
                dgDetalleventa.Columns[1].Width = 50;
                dgDetalleventa.Columns[2].Width = 50;
                dgDetalleventa.Columns[3].Visible = false;
                dgDetalleventa.Columns[4].Width = 250;
                dgDetalleventa.Columns[5].Width = 100;
                dgDetalleventa.Columns[6].Width = 100;
                dgDetalleventa.Columns[7].Width = 100;
                dgDetalleventa.Columns[8].Visible = false;
                dgDetalleventa.Columns[9].Visible = false;
                dgDetalleventa.Columns[10].Visible = false;
                dgDetalleventa.Columns[11].Width = dgDetalleventa.Width - (dgDetalleventa.Columns[0].Width - dgDetalleventa.Columns[1].Width - dgDetalleventa.Columns[2].Width -
                dgDetalleventa.Columns[4].Width - dgDetalleventa.Columns[5].Width - dgDetalleventa.Columns[6].Width - dgDetalleventa.Columns[7].Width);
                dgDetalleventa.Columns[12].Visible = false;
                dgDetalleventa.Columns[13].Visible = false;
                dgDetalleventa.Columns[14].Visible = false;
                dgDetalleventa.Columns[15].Visible = false;
                dgDetalleventa.Columns[16].Visible = false;
                dgDetalleventa.Columns[17].Visible = false;
                dgDetalleventa.Columns[18].Visible = false;
                if (Tema == "Redentor")
                {
                    Bases.Multilinea(ref dgDetalleventa);
                }
                else
                {

                    Bases.MultilineaTemaOscuro(ref dgDetalleventa);
                }

                sumar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_detalle_venta()
        {
            try
            {
                if (usainventarios == "SI")
                {
                    if (lblStock_de_Productos >= txtpantalla)
                    {
                        insertar_detalle_venta_Validado();
                    }
                    else
                    {
                        TimerLABEL_STOCK.Start();
                    }
                }

                else if (usainventarios == "NO")
                {
                    insertar_detalle_venta_SIN_VALIDAR();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void insertar_detalle_venta_Validado()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@moneda", 0);
                cmd.Parameters.AddWithValue("@unidades", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Usa_inventarios", usainventarios);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                disminuir_stock_en_detalle_de_venta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void insertar_detalle_venta_SIN_VALIDAR()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@moneda", 0);
                cmd.Parameters.AddWithValue("@unidades", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Usa_inventarios", usainventarios);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void contar_stock_detalle_ventas()
        {
            int x;
            x = datalistado_stock_detalle_venta.Rows.Count;
            contador_stock_detalle_de_venta = (x);
        }
        private void mostrar_stock_de_detalle_de_ventas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_stock_de_detalle_de_ventas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_producto", idproducto);
                da.Fill(dt);
                datalistado_stock_detalle_venta.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void ejecutar_editar_detalle_venta_sumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {


            }

        }
        private void disminuir_stock_en_detalle_de_venta()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("disminuir_stock_en_detalle_de_venta", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {


            }
        }
        private void Obtener_datos_del_detalle_de_venta()
        {

            try
            {
                iddetalleventa = Convert.ToInt32(dgDetalleventa.SelectedCells[9].Value.ToString());
                idproducto = Convert.ToInt32(dgDetalleventa.SelectedCells[8].Value.ToString());
                sevendePor = dgDetalleventa.SelectedCells[17].Value.ToString();
                usainventarios = dgDetalleventa.SelectedCells[16].Value.ToString();
                cantidad = Convert.ToDouble(dgDetalleventa.SelectedCells[5].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editar_detalle_venta_sumar()
        {


            if (usainventarios == "SI")
            {
                lblStock_de_Productos = Convert.ToDouble(dgDetalleventa.SelectedCells[15].Value.ToString());
                if (lblStock_de_Productos > 0)
                {

                    ejecutar_editar_detalle_venta_sumar();
                    disminuir_stock_en_detalle_de_venta();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }

            }
            else
            {
                ejecutar_editar_detalle_venta_sumar();
            }
            Listarproductosagregados();





        }
        private void editar_detalle_venta_restar()
        {

            if (usainventarios == "SI")
            {
                ejecutar_editar_detalle_venta_restar();
                aumentar_stock_en_detalle_de_venta();
            }
            else
            {
                ejecutar_editar_detalle_venta_restar();
            }
            Listarproductosagregados();
        }
        private void aumentar_stock_en_detalle_de_venta()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("aumentar_stock_en_detalle_de_venta", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

            }
        }
        private void ejecutar_editar_detalle_venta_restar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle_venta", iddetalleventa);
                cmd.Parameters.AddWithValue("cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Obtener_datos_del_detalle_de_venta();


            if (e.ColumnIndex == this.dgDetalleventa.Columns["S"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_sumar();
            }
            if (e.ColumnIndex == this.dgDetalleventa.Columns["R"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_restar();
                EliminarVentas();
            }


            if (e.ColumnIndex == this.dgDetalleventa.Columns["EL"].Index)
            {

                int iddetalle_venta = Convert.ToInt32(dgDetalleventa.SelectedCells[9].Value);
                try
                {
                    SqlCommand cmd;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    cmd = new SqlCommand("eliminar_detalle_venta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetalleventa", iddetalle_venta);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtpantalla = Convert.ToDouble(dgDetalleventa.SelectedCells[5].Value);
                    aumentar_stock_en_detalle_de_venta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Listarproductosagregados();
                EliminarVentas();
            }
        }
        private void EliminarVentas()
        {
            contar_tablas_ventas();
            if (Contador == 0)
            {
                eliminar_venta_al_agregar_productos();
                Limpiar_para_venta_nueva();
            }
        }
        private void eliminar_venta_al_agregar_productos()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("eliminar_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void contar_tablas_ventas()
        {
            int x;
            x = dgDetalleventa.Rows.Count;
            Contador = (x);
        }


        private void datalistadoDetalleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgDetalleventa.RowCount > 0)
            {
                Obtener_datos_del_detalle_de_venta();
                if (e.KeyChar == Convert.ToChar("+"))
                {
                    editar_detalle_venta_sumar();
                }
                if (e.KeyChar == Convert.ToChar("-"))
                {
                    editar_detalle_venta_restar();
                    contar_tablas_ventas();
                    if (Contador == 0)
                    {
                        eliminar_venta_al_agregar_productos();
                        txtventagenerada = "VENTA NUEVA";
                    }
                }
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";
        }
        bool SECUENCIA = true;
        private void btnSeparador_Click(object sender, EventArgs e)
        {
            if (SECUENCIA == true)
            {
                txtmonto.Text = txtmonto.Text + ".";
                SECUENCIA = false;
            }
            else
            {
                return;
            }
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {
            //if (SECUENCIA == true)
            //{
            //    txtmonto.Text = txtmonto.Text + ".";
            //    SECUENCIA = false;
            //}
            //else
            //{
            //    return;
            //}
        }
        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtmonto, e);
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtmonto.Clear();
            SECUENCIA = true;
        }

        private void TimerBUSCADORcodigodebarras_Tick(object sender, EventArgs e)
        {
            TimerBUSCADORcodigodebarras.Stop();
            vender_por_lectora_de_barras();
        }
        private void vender_por_lectora_de_barras()
        {
            try
            {
                if (txtbuscar.Text == "")
                {
                    dgProductos.Visible = false;
                    lbltipodebusqueda2.Visible = true;
                }
                if (txtbuscar.Text != "")
                {
                    dgProductos.Visible = true;
                    lbltipodebusqueda2.Visible = false;
                    LISTAR_PRODUCTOS_Abuscador();

                    idproducto = Convert.ToInt32(dgProductos.SelectedCells[1].Value.ToString());
                    mostrar_stock_de_detalle_de_ventas();
                    contar_stock_detalle_ventas();

                    if (contador_stock_detalle_de_venta == 0)
                    {
                        lblStock_de_Productos = Convert.ToDouble(dgProductos.SelectedCells[4].Value.ToString());
                    }
                    else
                    {
                        lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
                    }
                    usainventarios = dgProductos.SelectedCells[3].Value.ToString();
                    lbldescripcion.Text = dgProductos.SelectedCells[9].Value.ToString();
                    lblcodigo.Text = dgProductos.SelectedCells[10].Value.ToString();
                    lblcosto.Text = dgProductos.SelectedCells[5].Value.ToString();
                    txtprecio_unitario = Convert.ToDouble(dgProductos.SelectedCells[6].Value.ToString());
                    sevendePor = dgProductos.SelectedCells[8].Value.ToString();
                    if (sevendePor == "Unidad")
                    {
                        txtpantalla = 1;
                        vender_por_unidad();
                    }

                }
            }
            catch (Exception)
            {


            }

        }
        private void lbltipodebusqueda2_Click(object sender, EventArgs e)
        {

        }
        private void editar_detalle_venta_CANTIDAD()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_CANTIDAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                Listarproductosagregados();
                txtmonto.Clear();
                txtmonto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button21_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmonto.Text))
            {
                if (dgDetalleventa.RowCount > 0)
                {

                    if (sevendePor == "Unidad")

                    {
                        string cadena = txtmonto.Text;
                        if (cadena.Contains("."))
                        {
                            MessageBox.Show("Este Producto no acepta decimales ya que esta configurado para ser vendido por UNIDAD", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            BotonCantidad();


                        }
                    }
                    else if (sevendePor == "Granel")
                    {
                        BotonCantidad();
                    }
                }
                else
                {
                    txtmonto.Clear();
                    txtmonto.Focus();
                }
            }

        }
        private void BotonCantidad()
        {

            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(dgDetalleventa.SelectedCells[5].Value);

            double stock;
            double condicional;
            string ControlStock;
            ControlStock = dgDetalleventa.SelectedCells[16].Value.ToString();
            if (ControlStock == "SI")
            {
                stock = Convert.ToDouble(dgDetalleventa.SelectedCells[11].Value);
                condicional = Cantidad + stock;
                if (condicional >= MontoaIngresar)
                {
                    BotonCantidadEjecuta();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
            }
            else
            {
                BotonCantidadEjecuta();
            }


        }
        private void BotonCantidadEjecuta()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(dgDetalleventa.SelectedCells[5].Value);

            if (MontoaIngresar > Cantidad)
            {
                txtpantalla = MontoaIngresar - Cantidad;
                editar_detalle_venta_sumar();
            }
            else if (MontoaIngresar < Cantidad)
            {
                txtpantalla = Cantidad - MontoaIngresar;
                editar_detalle_venta_restar();
            }
        }
        private void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (EstadoMediosPago == true)
            {
                Limpiar_para_venta_nueva();
            }
        }

        private void Panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TimerLABEL_STOCK_Tick(object sender, EventArgs e)
        {
            if (ProgressBarETIQUETA_STOCK.Value < 100)
            {
                ProgressBarETIQUETA_STOCK.Value = ProgressBarETIQUETA_STOCK.Value + 10;
                LABEL_STOCK.Visible = true;
                LABEL_STOCK.Dock = DockStyle.Fill;
            }
            else
            {
                LABEL_STOCK.Visible = false;
                LABEL_STOCK.Dock = DockStyle.None;
                ProgressBarETIQUETA_STOCK.Value = 0;
                TimerLABEL_STOCK.Stop();
            }
        }

        private void befectivo_Click_1(object sender, EventArgs e)
        {
            Cobrar();
        }
        private void Cobrar()
        {
            if (dgDetalleventa.RowCount > 0)
            {
                total = Convert.ToDouble(txt_total_suma.Text);
                MEDIOS_DE_PAGO frm = new MEDIOS_DE_PAGO();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.ShowDialog();
            }

        }


        private void btnrestaurar_Click_1(object sender, EventArgs e)
        {
            Ventas_en_espera frm = new Ventas_en_espera();
            frm.FormClosing += Frm_FormClosing1;
            frm.ShowDialog();
        }

        private void Frm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Listarproductosagregados();
            mostrar_panel_de_Cobro();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgDetalleventa.RowCount > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿Realmente desea eliminar esta Venta?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    Eliminar_datos.eliminar_venta(idVenta);
                    Limpiar_para_venta_nueva();
                }
            }


        }

        private void btnespera_Click(object sender, EventArgs e)
        {
            if (dgDetalleventa.RowCount > 0)
            {
                PanelEnespera.Visible = true;
                PanelEnespera.BringToFront();
                PanelEnespera.Dock = DockStyle.Fill;
                txtnombre.Clear();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();
        }

        private void ocularPanelenEspera()
        {
            PanelEnespera.Visible = false;
            PanelEnespera.Dock = DockStyle.None;
        }
        private void btnGuardarEspera_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                editarVentaEspera();
            }
            else
            {
                MessageBox.Show("Ingrese una referencia");
            }

        }
        private void editarVentaEspera()

        {
            Editar_datos.ingresar_nombre_a_venta_en_espera(idVenta, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }
        private void btnAutomaticoEspera_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "Ticket" + idVenta;
            editarVentaEspera();
        }



        private void BTNLECTORA_Click_1(object sender, EventArgs e)
        {
            ModoLectora();
        }
        private void ModoLectora()
        {
            ocultar_mostrar_productos();
            lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            Tipo_de_busqueda = "LECTORA";
            BTNLECTORA.BackColor = Color.LightGreen;
            BTNTECLADO.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }
        private void BTNTECLADO_Click_1(object sender, EventArgs e)
        {
            ModoTeclado();
        }
        private void ModoTeclado()
        {
            ocultar_mostrar_productos();
            lbltipodebusqueda2.Text = "Buscar con  TECLADO";
            Tipo_de_busqueda = "TECLADO";
            BTNTECLADO.BackColor = Color.LightGreen;
            BTNLECTORA.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }
        private void btnverMovimientosCaja_Click(object sender, EventArgs e)
        {
            CAJA.Listado_gastos_ingresos frm = new CAJA.Listado_gastos_ingresos();
            frm.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            Gastos_varios.Gastos frm = new Gastos_varios.Gastos();
            frm.ShowDialog();
        }

        private void btnIngresosCaja_Click(object sender, EventArgs e)
        {
            Ingresos_varios.IngresosVarios frm = new Ingresos_varios.IngresosVarios();
            frm.ShowDialog();

        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            Dispose();
            CAJA.CIERRE_DE_CAJA frm = new CAJA.CIERRE_DE_CAJA();
            frm.ShowDialog();

        }

        private void btnCreditoPagar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorPagar frm = new Apertura_de_credito.PorPagar();
            frm.ShowDialog();
        }

        private void btnCreditoCobrar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorCobrarOk frm = new Apertura_de_credito.PorCobrarOk();
            frm.ShowDialog();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            Dispose();
            DASHBOARD_PRINCIPAL frm = new DASHBOARD_PRINCIPAL();
            frm.ShowDialog();

        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("¿Realmente desea Cerrar el Sistema?", "Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Dispose();
                CopiasBd.GeneradorAutomatico frm = new CopiasBd.GeneradorAutomatico();
                frm.ShowDialog();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            Cobros.CobrosForm frm = new Cobros.CobrosForm();
            frm.ShowDialog();
        }

        private void btnMayoreo_Click(object sender, EventArgs e)
        {
            aplicar_precio_mayoreo();
        }
        private void aplicar_precio_mayoreo()
        {
            if (dgDetalleventa.Rows.Count > 0)
            {
                LdetalleVenta parametros = new LdetalleVenta();
                Editar_datos funcion = new Editar_datos();
                parametros.Id_producto = idproducto;
                parametros.iddetalle_venta = iddetalleventa;
                if (funcion.aplicar_precio_mayoreo(parametros) == true)
                {
                    Listarproductosagregados();
                }
            }

        }

        private void datalistadoDetalleVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnprecio_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmonto.Text))
            {
                LdetalleVenta parametros = new LdetalleVenta();
                Editar_datos funcion = new Editar_datos();
                parametros.iddetalle_venta = iddetalleventa;
                parametros.preciounitario = Convert.ToDouble(txtmonto.Text);
                if (funcion.editarPrecioVenta(parametros) == true)
                {
                    Listarproductosagregados();
                }
            }
        }

        private void btndevoluciones_Click(object sender, EventArgs e)
        {
            HistorialVentas.HistorialVentasForm frm = new HistorialVentas.HistorialVentasForm();
            frm.ShowDialog();
        }

        private void IndicadorTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndicadorTema.Checked == true)
            {
                Tema = "Oscuro";
                EditarTemaCaja();
                TemaOscuro();
                Listarproductosagregados();
            }
            else
            {
                Tema = "Redentor";
                EditarTemaCaja();
                TemaClaro();
                Listarproductosagregados();

            }
        }
        private void EditarTemaCaja()
        {
            Lcaja parametros = new Lcaja();
            Editar_datos funcion = new Editar_datos();
            parametros.Tema = Tema;
            funcion.EditarTemaCaja(parametros);

        }
        private void TemaOscuro()
        {
            //PanelC1 Encabezado
            PanelC1.BackColor = Color.FromArgb(35, 35, 35);
            lblNombreSoftware.ForeColor = Color.White;
            btnadmin.ForeColor = Color.White;
            txtbuscar.BackColor = Color.FromArgb(20, 20, 20);
            txtbuscar.ForeColor = Color.White;
            lbltipodebusqueda2.BackColor = Color.FromArgb(20, 20, 20);
            //PanelC2 Intermedio
            panelC2.BackColor = Color.FromArgb(35, 35, 35);
            btnCobros.BackColor = Color.FromArgb(45, 45, 45);
            btnCobros.ForeColor = Color.White;


            btnCreditoCobrar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoCobrar.ForeColor = Color.White;
            btnCreditoPagar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoPagar.ForeColor = Color.White;

            //PanelC3
            PanelC3.BackColor = Color.FromArgb(35, 35, 35);
            btnMayoreo.BackColor = Color.FromArgb(45, 45, 45);
            btnMayoreo.ForeColor = Color.White;
            btnIngresosCaja.BackColor = Color.FromArgb(45, 45, 45);
            btnIngresosCaja.ForeColor = Color.White;
            btnGastos.BackColor = Color.FromArgb(45, 45, 45);
            btnGastos.ForeColor = Color.White;
            BtnTecladoV.BackColor = Color.FromArgb(45, 45, 45);
            BtnTecladoV.ForeColor = Color.White;
            //PanelC4 Pie de pagina
            panelC4.BackColor = Color.FromArgb(20, 20, 20);
            btnespera.BackColor = Color.FromArgb(20, 20, 20);
            btnespera.ForeColor = Color.White;
            btnrestaurar.BackColor = Color.FromArgb(20, 20, 20);
            btnrestaurar.ForeColor = Color.White;
            btneliminar.BackColor = Color.FromArgb(20, 20, 20);
            btneliminar.ForeColor = Color.White;
            btndevoluciones.BackColor = Color.FromArgb(20, 20, 20);
            btndevoluciones.ForeColor = Color.White;
            //PanelOperaciones
            PanelOperaciones.BackColor = Color.FromArgb(28, 28, 28);
            txt_total_suma.ForeColor = Color.WhiteSmoke;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.FromArgb(35, 35, 35);
            label8.ForeColor = Color.WhiteSmoke;
            Listarproductosagregados();



        }
        private void TemaClaro()
        {
            //PanelC1 encabezado
            PanelC1.BackColor = Color.White;
            lblNombreSoftware.ForeColor = Color.Black;
            btnadmin.ForeColor = Color.Black;
            txtbuscar.BackColor = Color.White;
            txtbuscar.ForeColor = Color.Black;
            lbltipodebusqueda2.BackColor = Color.White;

            //PanelC2 intermedio
            panelC2.BackColor = Color.White;
            btnCobros.BackColor = Color.WhiteSmoke;
            btnCobros.ForeColor = Color.Black;


            btnCreditoCobrar.BackColor = Color.WhiteSmoke;
            btnCreditoCobrar.ForeColor = Color.Black;
            btnCreditoPagar.BackColor = Color.WhiteSmoke;
            btnCreditoPagar.ForeColor = Color.Black;

            //PanelC3
            PanelC3.BackColor = Color.White;
            btnMayoreo.BackColor = Color.WhiteSmoke;
            btnMayoreo.ForeColor = Color.Black;
            btnIngresosCaja.BackColor = Color.WhiteSmoke;
            btnIngresosCaja.ForeColor = Color.Black;
            btnGastos.BackColor = Color.WhiteSmoke;
            btnGastos.ForeColor = Color.Black;
            BtnTecladoV.BackColor = Color.WhiteSmoke;
            BtnTecladoV.ForeColor = Color.Black;
            //PanelC4 pie de pagina
            panelC4.BackColor = Color.Gainsboro;
            btnespera.BackColor = Color.Gainsboro;
            btnespera.ForeColor = Color.Black;
            btnrestaurar.BackColor = Color.Gainsboro;
            btnrestaurar.ForeColor = Color.Black;
            btneliminar.BackColor = Color.Gainsboro;
            btneliminar.ForeColor = Color.Black;
            btndevoluciones.BackColor = Color.Gainsboro;
            btndevoluciones.ForeColor = Color.Black;
            //PanelOperaciones
            PanelOperaciones.BackColor = Color.FromArgb(242, 243, 245);
            txt_total_suma.ForeColor = Color.Black;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.White;
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            Listarproductosagregados();


        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            EventosTiposbusqueda(e);
            EventosNavegarDgproductos(e);
            EventosNavegarDgDetallVenta(e);
        }
        private void EventosNavegarDgDetallVenta(KeyEventArgs e)
        {
            if (dgProductos.Visible == false)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    dgDetalleventa.Focus();
                }

            }
        }

        private void EventosNavegarDgproductos(KeyEventArgs e)
        {
            EstadoCobrar = true;
            if (dgProductos.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EstadoCobrar = false;
                    vender_por_teclado();
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    dgProductos.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter && EstadoCobrar == true)
                {
                    Cobrar();
                }

            }

        }

        private void datalistadoDetalleVenta_KeyDown(object sender, KeyEventArgs e)
        {
            EventosTiposbusqueda(e);
            EventoCobros(e);
        }
        private void EventoCobros(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgProductos.Visible == false)
            {
                Cobrar();
            }
        }
        private void EventosTiposbusqueda(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ModoLectora();
            }
            if (e.KeyCode == Keys.F2)
            {
                ModoTeclado();
            }
            if (e.KeyCode == Keys.Escape)
            {
                ValidarTiposBusqueda();
            }

        }

        private void dgProductos_KeyDown(object sender, KeyEventArgs e)
        {
            EventosNavegarDgproductos(e);
            EventosTiposbusqueda(e);

        }



    }
}
