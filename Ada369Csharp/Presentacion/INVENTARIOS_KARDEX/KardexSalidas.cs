using Ada369Csharp.Datos;
using Ada369Csharp.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ada369Csharp.Presentacion.INVENTARIOS_KARDEX
{
    public partial class KardexSalidas : Form
    {
        public KardexSalidas()
        {
            InitializeComponent();
        }
        int Idproducto;
        double CantidadActual;
        private void TXTBUSCARProducto_TextChanged(object sender, EventArgs e)
        {
            BUSCAR_PRODUCTOS_KARDEX();
        }
        private void BUSCAR_PRODUCTOS_KARDEX()
        {
            DataTable dt = new DataTable();

            Obtener_datos.BUSCAR_PRODUCTOS_KARDEX(ref dt, TXTBUSCARProducto.Text);
            DatalistadoProductos.DataSource = dt;
            DatalistadoProductos.Visible = true;
            DatalistadoProductos.Columns[1].Visible = false;
            DatalistadoProductos.Columns[3].Visible = false;
            DatalistadoProductos.Columns[4].Visible = false;
            DatalistadoProductos.Columns[5].Visible = false;
            DatalistadoProductos.Columns[6].Visible = false;
            DatalistadoProductos.Columns[7].Visible = false;
            DatalistadoProductos.Columns[8].Visible = false;
            DatalistadoProductos.Columns[9].Visible = false;
            DatalistadoProductos.Columns[10].Visible = false;
            DatalistadoProductos.Columns[11].Visible = false;
            DatalistadoProductos.Columns[12].Visible = false;
            DatalistadoProductos.Columns[13].Visible = false;
            DatalistadoProductos.Columns[14].Visible = false;
            DatalistadoProductos.Columns[15].Visible = false;
            DatalistadoProductos.Columns[16].Visible = false;

            Bases.Multilinea(ref DatalistadoProductos);


        }

        private void txtagregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtagregar, e);

        }

        

       
        private void KardexSalidas_Load(object sender, EventArgs e)
        {

        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            validaciones();
        }
        private void validaciones()
        {
            if (!string.IsNullOrEmpty(txtagregar.Text))
            {
                if (string.IsNullOrEmpty(txtcmotivo.Text))
                {
                    txtcmotivo.Text = "SIN MOTIVO";
                }
                double cantDisminuir = Convert.ToDouble(txtagregar.Text); 
                if (cantDisminuir <=CantidadActual )
                {
                   disminuir_stock();
                }
                else
                {
                    MessageBox.Show("Se esta restando mas de lo que hay en Stock", "Error");

                }

            }
            else
            {
                MessageBox.Show("El valor a agregar no puede estar vacio", "Valores vacios");
                txtagregar.Focus();
            }
        }
        private void insertar_KARDEX_SALIDA()
        {
            LKardex parametros = new LKardex();
            Insertar_datos funcion = new Insertar_datos();
            parametros.Fecha = txtfecha.Value;
            parametros.Motivo = txtcmotivo.Text;
            parametros.Cantidad = Convert.ToDouble(txtagregar.Text);
            parametros.Id_producto = Idproducto;
            if (funcion.insertar_KARDEX_SALIDA(parametros) == true)
            {
                TXTBUSCARProducto.Text = "";
                TXTBUSCARProducto.Focus();
                DatalistadoProductos.Visible = true;
                MessageBox.Show("Registro realizado correctamente");
            }

        }
        private void disminuir_stock()
        {
            Lproductos parametros = new Lproductos();
            Editar_datos funcion = new Editar_datos();
            parametros.Id_Producto1 = Idproducto;
            parametros.Stock = txtagregar.Text;
            if (funcion.disminuir_stock(parametros) == true)
            {
                insertar_KARDEX_SALIDA();
            }
        }

        private void DatalistadoProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
        }
        private void obtenerDatos()
        {
            Idproducto = Convert.ToInt32(DatalistadoProductos.SelectedCells[1].Value);
            CantidadActual = Convert.ToDouble(DatalistadoProductos.SelectedCells[6].Value);
        
            lblcantidadactual.Text = CantidadActual.ToString();
            txtagregar.Text = "";
            txtcmotivo.Text = "";          
            TXTBUSCARProducto.Text = DatalistadoProductos.SelectedCells[2].Value.ToString();
            DatalistadoProductos.Visible = false;
        }
    }
}
