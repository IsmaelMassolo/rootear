using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Utils;
using System.Text;
using System.Text.Json;

namespace rootear.Services;

public class ViajeService : IViajeService
{
    HttpClient client;

    public ViajeService()
    {
        client = new HttpClient();
    }

    public async Task<IEnumerable<Viaje>> GetViajes()
    {
        try
        {
            var response = await client.GetAsync(Constants.ObtenerViajesEndpoint);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var responseObject = JsonSerializer.Deserialize<List<Viaje>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    Exception exception = new Exception("Resource Not Found");
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                Exception exception = new Exception("Request failed with status code " + response.StatusCode);
                throw new Exception(exception.Message);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public async Task<Viaje> GetViajePorId(int id)
    {
        try
        {
            var response = await client.GetAsync(Constants.ObtenerViajeEndpoint);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    // Inside the ApiService class
                    var responseObject = JsonSerializer.Deserialize<Viaje>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });
                    return responseObject!;
                }
                else
                {
                    Exception exception = new Exception("Resource Not Found");
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                Exception exception = new Exception("Request failed with status code " + response.StatusCode);
                throw new Exception(exception.Message);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public async Task<bool> CrearViaje(ViajeDTO _viaje)
    {
        try
        {
            var content = new StringContent(
                    JsonSerializer.Serialize(_viaje),
                    Encoding.UTF8, "application/json"
                );

            var result = await client.PostAsync(Constants.CrearViajeEndpoint, content).ConfigureAwait(false);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> EliminarViajeAsync(int id)
    {
        var response = await client.DeleteAsync($"{Constants.EliminarViajeEndpoint}/{id}");


        return response.IsSuccessStatusCode;
    }
}