using BancoSolidario.NuevoPlanAhorro.API.RemoteContracts;
using BancoSolidario.NuevoPlanAhorro.API.RemotModel;
using System.Text.Json;

namespace BancoSolidario.NuevoPlanAhorro.API.RemoteServices
{
    public class ClientServices : IClientServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ClientServices> _logger;

        public ClientServices(IHttpClientFactory httpClient, ILogger<ClientServices> logger)
        {
            _httpClient = httpClient ??
           throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ??
           throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(bool resultado, ClientRemote, string ErrorMessage)> GetClient(string id)
        {
            try
            {
                var client = _httpClient.CreateClient("ClienteBancoSolidario");
                var response = await client.GetAsync($"api/0v1/Client/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<ClientRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
