using WebApplication.Models;
using Newtonsoft.Json;
namespace WebApplication.Services
{
    public class ServicioAspirante
    {
        private readonly HttpClient _httpClient;

        public ServicioAspirante(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Aspirante>> ObtenerAspirantesAsync()
        {
            var respuesta = await _httpClient.GetAsync("https://localhost:7139/Aspirante");
            respuesta.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

            var contenido = await respuesta.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Aspirante>>(contenido);
        }
    }
}
