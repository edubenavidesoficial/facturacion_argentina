using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ada369Csharp.Logica
{
   public  class Lventas
    {
        public int idventa { get; set; }
        public int idclientev { get; set; }
        public DateTime fecha_venta { get; set; }
        public string Numero_de_doc { get; set; }
        public double  Monto_total { get; set; }
        public string Tipo_de_pago { get; set; }
        public string Estado { get; set; }
        public double IGV { get; set; }
        public string Comprobante { get; set; }
        public int Id_usuario { get; set; }
        public string Fecha_de_pago { get; set; }
        public string ACCION { get; set; }
        public double Saldo { get; set; }
        public double Pago_con { get; set; }
        public double Porcentaje_IGV { get; set; }
        public int Id_caja { get; set; }
        public string Referencia_tarjeta { get; set; }
        public double Vuelto { get; set; }
        public double Efectivo { get; set; }
        public double Credito { get; set; }
        public double Tarjeta { get; set; }

    }
}
