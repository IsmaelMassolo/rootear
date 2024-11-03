using rootear.mvvm.Models;
using rootear.mvvm.Models.DTO;
using rootear.Utils;
using System.Text;
using System.Text.Json;

namespace rootear.Services;

public class ReservaService : IReservaService
{
    HttpClient client;

    private static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public ReservaService()
    {
        client = new HttpClient();
    }

    public async Task<IEnumerable<Viaje>> GetDetalleReservaPorId()
    {
        try
        {
            var response = await client.GetAsync($"{Constants.DetalleReservaEndpoint}/{Transport.IdSalaReserva}");
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

    public async Task<bool> AgregarA_DetalleReserva(DetalleReservaDTO _detalleReserva)
    {
        try
        {
            var serializedProduct = JsonSerializer.Serialize(_detalleReserva);
            var content = new StringContent(
                serializedProduct,
                Encoding.UTF8,
                "application/json"
            );


            var response = await client.PostAsync(Constants.AgregarEnReservaEndpoint, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Detalles: {responseContent}");
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> EliminarViajeAsync(DetalleReservaDTO dto)
    {
        try
        {
            // Serializamos el objeto a JSON
            var jsonProducto = JsonSerializer.Serialize(dto, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            // Creamos el contenido JSON para enviarlo en la solicitud
            var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

            // Construimos la solicitud de tipo DELETE con un cuerpo JSON
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(Constants.EliminarDetalleReservaEndpoint),
                Content = content
            };

            // Enviamos la solicitud
            var response = await client.SendAsync(request);

            // Verificamos si la solicitud fue exitosa
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            // Manejo de errores, en este caso devolvemos false si falla
            return false;
        }
    }
}