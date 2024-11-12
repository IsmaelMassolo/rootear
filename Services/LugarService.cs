using rootear.mvvm.Models;
using rootear.Utils;
using System.Net.Http.Json;
using System.Text.Json;


namespace rootear.Services
{
    public class LugarService : ILugarService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public LugarService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Lugar>> ObtenerLugaresAsync()
        {
            var response = await client.GetAsync(Constants.ObtenerLugaresEndpoint);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Lugar>>(options);
            return default;
        }
    }
}