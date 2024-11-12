using rootear.mvvm.Models;
using rootear.Utils;
using System.Text.Json;

namespace rootear.Services;

public class HistorialService : IHistorialService
{
    HttpClient client;

    private static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public HistorialService()
    {
        client = new HttpClient();
    }

    public async Task<IEnumerable<Viaje>> GetHistorialPorId()
    {
        try
        {
            var response = await client.GetAsync($"{Constants.ObtenerHistorialEndpoint}/{Transport.IdUsuario}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Deserializar como una lista de DetalleReserva
                    var responseObject = JsonSerializer.Deserialize<IEnumerable<Viaje>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    throw new Exception("Resource Not Found");
                }
            }
            else
            {
                throw new Exception("Request failed with status code " + response.StatusCode);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
}