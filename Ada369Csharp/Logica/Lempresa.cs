using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ada369Csharp.Logica
{
   public  class Lempresa
    {
        public int Id_empresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public byte[] Logo { get; set; }
        public string Impuesto { get; set; }
        public double  Porcentaje_impuesto { get; set; }
        public string Moneda { get; set; }
        public string Trabajas_con_impuestos { get; set; }
        public string Modo_de_busqueda { get; set; }
        public string Carpeta_para_copias_de_seguridad { get; set; }
        public string Correo_para_envio_de_reportes { get; set; }
        public string Ultima_fecha_de_copia_de_seguridad { get; set; }
        public DateTime Ultima_fecha_de_copia_date { get; set; }
        public int Frecuencia_de_copias { get; set; }
        public string Estado { get; set; }
        public string Tipo_de_empresa { get; set; }
        public string Pais { get; set; }
        public string Redondeo_de_total { get; set; }

    }
}
