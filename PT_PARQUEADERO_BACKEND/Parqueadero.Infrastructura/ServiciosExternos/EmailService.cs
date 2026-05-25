using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Parqueadero.Aplicacion.DTOs;
using Parqueadero.Aplicacion.Interfaces;

namespace Parqueadero.Infrastructura.ServiciosExternos
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;

        private const string BASE_URL =
            "https://dev-sites.similtech.co/api-email";

        private const string USERNAME =
            "proceso_pruebas";

        private const string PASSWORD =
            "das487d32_*";

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarCorreoSalidaAsync(ResultadoSalidaDTO dto)
        {
            // 1. Obtener token
            var token = await ObtenerTokenAsync();

            // 2. Configurar Authorization
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // 3. Crear body email
            var body = new
            {
                configParams = new
                {
                    idUser = "proceso_pruebas",
                    idMessage = Guid.NewGuid().ToString()
                },

                receivers = new
                {
                    emailOrigen = "juanesbol09@gmail.com",

                    to = new[]
                    {
                        "juanesbol09@gmail.com"
                    },

                    copyTo = Array.Empty<string>(),

                    hiddenCopyTo = Array.Empty<string>()
                },

                email = new
                {
                    subject = "Salida de Vehículo",

                    urlHeader = "",

                    urlFooter = "",

                    message = $@"
                        Vehículo registrado correctamente.<br/><br/>

                        <b>Placa:</b> {dto.Placa}<br/>
                        <b>Tipo:</b> {dto.Tipo}<br/>
                        <b>Tiempo total:</b> {dto.TotalMinutos} minutos<br/>
                        <b>Valor pagado:</b> ${dto.ValorPagado}
                    ",

                    url_files = Array.Empty<string>()
                }
            };

            var json = JsonSerializer.Serialize(body);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            // 4. Consumir API email
            var response = await _httpClient.PostAsync(
                $"{BASE_URL}/api/email/sendEmail",
                content
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new Exception(
                    $"Error enviando correo: {error}"
                );
            }
        }

        private async Task<string> ObtenerTokenAsync()
        {
            var tokenRequest = new TokenRequestDTO
            {
                Username = USERNAME,
                Password = PASSWORD
            };

            var json = JsonSerializer.Serialize(tokenRequest);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                $"{BASE_URL}/api/token",
                content
            );

            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine("EMAIL ENVIADO CORRECTAMENRETTE, RESPUESTA TOKEN:");
            Console.WriteLine(responseBody);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    "No fue posible obtener token JWT"
                );
            }

            var responseContent =
                await response.Content.ReadAsStringAsync();

            var tokenResponse =
                JsonSerializer.Deserialize<TokenResponseDTO>(
                    responseContent,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

            return tokenResponse?.Token
                ?? throw new Exception("Token inválido");
        }
    }
}