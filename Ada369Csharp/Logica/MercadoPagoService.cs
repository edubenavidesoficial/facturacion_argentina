using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using QRCoder;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace Ada369Csharp.Logica
{
    public class MercadoPagoService
    {
        public string CrearPago(string descripcion, decimal monto)
        {
            string accessToken = "APP_USR-924945722609402-012503-6b2b821bc55156d2f01fa692c29472b3-2045207444";
            string url = "https://api.mercadopago.com/instore/orders/qr/seller/collectors/446566691/pos/SUC001POS001/qrs";

            string jsonData = $@"
            {{
                ""external_reference"": ""ReferenciaExterna12345"",
                ""title"": ""{descripcion}"",
                ""description"": ""Pago de {descripcion}"",
                ""notification_url"": ""https://www.tuservidor.com/notifications"",
                ""total_amount"": {monto.ToString("F2").Replace(",", ".")},
                ""items"": [
                    {{
                        ""sku_number"": ""12345"",
                        ""category"": ""others"",
                        ""title"": ""{descripcion}"",
                        ""description"": ""Pago de {descripcion}"",
                        ""unit_price"": {monto.ToString("F2").Replace(",", ".")},
                        ""quantity"": 1,
                        ""unit_measure"": ""unit"",
                        ""total_amount"": {monto.ToString("F2").Replace(",", ".")}
                    }}
                ],
                ""sponsor"": {{
                    ""id"": 662208785
                }},
                ""cash_out"": {{
                    ""amount"": 0
                }}
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
                        JObject jsonResponse = JObject.Parse(result);

                        // Extraer el QR de la respuesta
                        string qrCodeUrl = jsonResponse["qr_data"]?.ToString();
                        MessageBox.Show(qrCodeUrl);
                        if (!string.IsNullOrEmpty(qrCodeUrl))
                        {
                            MostrarCodigoQR(qrCodeUrl);
                            return qrCodeUrl;
                        }
                        else
                        {
                            throw new Exception("No se generó un código QR en la respuesta de Mercado Pago.");
                        }
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

        public void MostrarCodigoQR(string url)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);

                        // Mostrar el QR en una ventana
                        Form form = new Form
                        {
                            Text = "Código QR de Pago",
                            Width = 300,
                            Height = 300
                        };

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = qrCodeImage,
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.Zoom
                        };

                        form.Controls.Add(pictureBox);
                        form.ShowDialog();
                    }
                }
            }
        }
      
    }
}