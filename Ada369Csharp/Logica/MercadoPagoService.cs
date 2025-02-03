using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;

namespace Ada369Csharp.Logica
{
    public class MercadoPagoService
    {
        public string CrearPago(string descripcion, decimal monto)
        {
            //string accessToken = ConfigurationManager.AppSettings["MercadoPagoAccessToken"];
            string accessToken = "TOKEN";
           string url = "https://api.mercadopago.com/checkout/preferences";

            string jsonData = $@"
            {{
                ""items"": [
                    {{
                        ""title"": ""{descripcion}"",
                        ""quantity"": 1,
                        ""unit_price"": {monto.ToString("F2").Replace(",", ".")}
                    }}
                ],
                ""payment_methods"": {{
                    ""excluded_payment_types"": [
                        {{ ""id"": ""ticket"" }}
                    ]
                }},
                ""external_reference"": ""ReferenciaExterna12345""
            }}";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", $"Bearer {accessToken}");

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        string initPoint = ExtraerValorDeJson(result, "init_point");
                        return initPoint;
                    }
                }
            }
            catch (WebException ex)
            {
                using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string errorResponse = streamReader.ReadToEnd();
                    throw new Exception($"Error al crear el pago: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private string ExtraerValorDeJson(string json, string campo)
        {
            string buscaCampo = $"\"{campo}\":\"";
            int inicio = json.IndexOf(buscaCampo) + buscaCampo.Length;
            int fin = json.IndexOf("\"", inicio);
            return json.Substring(inicio, fin - inicio);
        }
    }
}
