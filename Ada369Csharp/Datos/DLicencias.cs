using Ada369Csharp.CONEXION;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ada369Csharp.Logica;
namespace Ada369Csharp.Datos
{
    public  class DLicencias
    {
        DateTime fechaFinal;

        DateTime FechaInicial;
        string estado;
        string SerialPcLicencia;
        DateTime fechaSistema = DateTime.Today;
        string SerialPC;
       public void ValidarLicencias(ref string Resultado,ref string ResultFechafinal)
        {
			try
			{
                Bases.Obtener_serialPC(ref SerialPC);
                DataTable dt = new DataTable();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * From Marcan", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                foreach (DataRow rdr in dt.Rows )
                {
                    FechaInicial = Convert.ToDateTime(Bases.Desencriptar(rdr["FA"].ToString()));
                    estado = Bases.Desencriptar ( rdr["E"].ToString());
                    fechaFinal = Convert.ToDateTime ( Bases.Desencriptar(rdr["F"].ToString()));
                    fechaFinal.ToString("dd/MM/yyyy");              
                    SerialPcLicencia = rdr["S"].ToString();
                }

                if (estado=="VENCIDA")
                {
                    Resultado = "VENCIDA";

                }
                else
                {
                    if (fechaFinal >= fechaSistema)
                    {


                        if (FechaInicial <= fechaSistema)
                        {
                            if (SerialPcLicencia == SerialPC)
                            {
                                Resultado = estado;
                                ResultFechafinal = fechaFinal.ToString("dd/MM/yyyy");


                            }
                        }
                        else
                        {
                            Resultado = "VENCIDA";
                        }
                    }
                    else
                    {
                        Resultado = "VENCIDA";
                    }
                }
             

                
                
               
            }
            catch (Exception ex)
			{
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(FechaInicial.ToString());

            }
        }
       public void EditarMarcanVencidas()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("MarcanVencidas", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@E", Bases.Encriptar ("VENCIDA"));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
            finally
            {
                CONEXIONMAESTRA.cerrar();

            }
        }
    }
}
